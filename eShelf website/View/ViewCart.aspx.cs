using eShelf_website.Controller;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eShelf_website.View
{
    public partial class ViewCart : System.Web.UI.Page
    {
        ViewCartController vcCon = new ViewCartController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    if (Session["user"] == null)
                    {
                        string userId = Request.Cookies["user_cookie"].Value;
                        User user = vcCon.getUser(userId);
                        Session["user"] = user;
                    }
                    addPaymentMethodDDL();
                    PNpopUp.Visible = false;

                }
            }
            setItems();

        }

        private void addPaymentMethodDDL()
        {
            List<PaymentMethod> pms = vcCon.getAllPaymentMethods();
            foreach(var p in pms)
            {
                DDLpaymentMethod.Items.Add(new ListItem(p.Name));
            }
        }

        private void setItems()
        {
            //User user = (User)Session["user"];
            string transactionId = vcCon.getTransactionID("UD002");
            List<Cart> carts = vcCon.getAllCarts(transactionId);;

            if(carts == null || String.IsNullOrEmpty(transactionId))
            {
                PNempty.Visible = true;
                LBsubtotalPrice.Text = "Rp. 0.00";
                LBtaxPrice.Text = "Rp. 0.00";
                LBtotalPrice.Text = "Rp. 0.00";
                return;
            }
            else
            {
                PNempty.Visible = false;
            }

            double subtotal = 0;

            foreach(var c in carts)
            {
                Book book = vcCon.getBook(c.BookID);
                addItems(c, book);
                setOderDetail(c, book);
                subtotal += c.Quantity * book.Price;
            }
            setOrderDetailTotal(subtotal);
        }
        private void addItems(Cart c, Book b)
        {
            string formatId = $"{c.Id},{c.BookID},{c.Type}";

            //Container Item
            HtmlGenericControl divContainerItem = vcCon.setContainerItem();
            
            //Book Cover
            HtmlGenericControl bookCover = vcCon.setBookCover(c, b);
            divContainerItem.Controls.Add(bookCover);

            //Container Book Description
            HtmlGenericControl divContainerBookDescription = vcCon.setContainerBookDescription();

            //Header
            HtmlGenericControl divContainerBookDescriptionHeader = vcCon.setBookDescriptionHeader(c, b);
            divContainerBookDescription.Controls.Add(divContainerBookDescriptionHeader);



            //Tail
            HtmlGenericControl divContainerBookDescriptionTail = vcCon.setBookDesciptionTail();
            
            //Price
            Label LBBookPrice = vcCon.setBDTPrice(c, b);

            //Container Cart Button
            HtmlGenericControl divContainerCartButton = vcCon.setContainerCartButton();

            //BTN delete
            Button BTNdelete = vcCon.setBTNdelete(c, b);
            BTNdelete.CommandArgument = $"{c.Id},{c.BookID},{c.Type}";
            BTNdelete.Command += new CommandEventHandler(BTNdelete_click);

            //Container Update
            HtmlGenericControl divContainerUpdate = vcCon.setContainerUpdate();

            //BTN min item
            Button BTNminItem = vcCon.setBTNminItem(c, b);
            BTNminItem.CommandArgument = $"{c.Id},{c.BookID},{c.Type}";
            BTNminItem.Command += new CommandEventHandler(BTNminItem_click);
            
            //Book Quantity
            Label BookQuantity = vcCon.setBookQuantity(c, b);

            //BTN max item
            Button BTNmaxItem = vcCon.setBTNmaxItem(c, b);
            BTNmaxItem.CommandArgument = $"{c.Id},{c.BookID},{c.Type}";
            BTNmaxItem.Command += new CommandEventHandler(BTNmaxItem_click);

            divContainerUpdate.Controls.Add(BTNminItem);
            divContainerUpdate.Controls.Add(BookQuantity);
            divContainerUpdate.Controls.Add(BTNmaxItem);

            divContainerCartButton.Controls.Add(BTNdelete);
            divContainerCartButton.Controls.Add(divContainerUpdate);

            divContainerBookDescriptionTail.Controls.Add(LBBookPrice);
            divContainerBookDescriptionTail.Controls.Add(divContainerCartButton);
;           divContainerBookDescription.Controls.Add(divContainerBookDescriptionTail);



            divContainerItem.Controls.Add(divContainerBookDescription);

            HtmlGenericControl CartLine = vcCon.setCartLine();

            PNcontainerItem.Controls.Add(divContainerItem);
            PNcontainerItem.Controls.Add(CartLine);
        }

        private void setOderDetail(Cart c, Book b)
        {
            HtmlGenericControl divContainerOrderDetail = vcCon.setOderDetail(c, b);
            PNcontainerOrderDetail.Controls.Add(divContainerOrderDetail);
        }
        
        private void setOrderDetailTotal(double subtotal)
        {
            LBsubtotalPrice.Text = "Rp. " + subtotal.ToString("###,###,##0.00");
            LBtaxPrice.Text = "Rp. " + (subtotal * 0.1).ToString("###,###,##0.00");
            LBtotalPrice.Text = "Rp. " + (subtotal * 1.1).ToString("###,###,##0.00");
        }
        protected void BTNminItem_click(object sender, CommandEventArgs e)
        {
            
            Button btn = (Button)sender;
            string temp = btn.CommandArgument.ToString();
            string[] args = temp.Split(',');
            string transactionId = args[0];
            string bookId = args[1];
            string type = args[2];

            vcCon.minQty(transactionId, bookId, type);
            refreshPage();
        }

        private void BTNmaxItem_click(object sender, CommandEventArgs e)
        {
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(',');
            string transactionId = args[0];
            string bookId = args[1];
            string type = args[2];

            vcCon.addQty(transactionId, bookId, type);
            refreshPage();
        }

        private void BTNdelete_click(object sender, CommandEventArgs e)
        {
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(',');
            string transactionId = args[0];
            string bookId = args[1];
            string type = args[2];

            vcCon.delItem(transactionId, bookId, type);
            refreshPage();
        }

        private void refreshPage()
        {
            PNcontainerItem.Controls.Clear();
            PNcontainerOrderDetail.Controls.Clear();
            setItems();
        }

        protected void BTNcheckout_Click(object sender, EventArgs e)
        {
            string pm = DDLpaymentMethod.SelectedValue;
            
            //User user = (User)Session["user"];

            if (vcCon.isEmpty("UD002"))
            {
                return;
            }

            if (vcCon.isAddress("UD002"))
            { 
                Response.Redirect("AddressInfo.aspx");
                return;
            }

            PNpopUp.Visible = true;

            vcCon.checkOut("UD002", pm);

        }

        protected void BTNclose_Click(object sender, EventArgs e)
        {
            PNpopUp.Visible = false;
            refreshPage();
        }
    }
}