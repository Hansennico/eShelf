using eShelf_website.Controller;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eShelf_website.View
{
    public partial class ConfirmRestock : System.Web.UI.Page
    {
        RestockController rCon = new RestockController();  
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
                        User user = rCon.getUser(userId);
                        Session["user"] = user;
                    }

                    User userd = (User)Session["user"];
                    if (!rCon.isAdmin(userd.Id))
                    {
                        Response.Redirect("Home.aspx");
                    }

                    if (!isId())
                    {
                        Response.Redirect("Inventory.aspx");
                    }
                    PNpopUp.Visible = false;
                }
                
            }
            setItem();
        }

        private bool isId()
        {
            string restockId = Request.QueryString["RestockId"];
            if(String.IsNullOrEmpty(restockId))
                return false;
            return true;
        }

        private void setItem()
        {
            string restockId = Request.QueryString["RestockId"];
            List<RestockDetail> rds = rCon.getRestockDetails(restockId);
            
            if (rds == null)
                Response.Redirect("Inventory.aspx");

            foreach(var r in rds)
            {
                Book b = rCon.getBook(r.BookID);
                addItem(r, b);
            }

        }

        private void addItem(RestockDetail r, Book b)
        {

            HtmlGenericControl ContainerBookRow = rCon.createDiv("ContainerBookRow");

            HtmlGenericControl BookId = rCon.createDiv("BookInfo", r.BookID);
            ContainerBookRow.Controls.Add(BookId);

            HtmlGenericControl BookTitle = rCon.createDiv("BookInfo", b.Title);
            ContainerBookRow.Controls.Add(BookTitle);

            TextBox BookPhysical = rCon.createTB(r.BookID, "Physical", "BookInfo BookTB", r.QuantityPhysical.ToString());
            ContainerBookRow.Controls.Add(BookPhysical);

            TextBox BookDigital = rCon.createTB(r.BookID, "Digital", "BookInfo BookTB", r.QuantityDigital.ToString());
            ContainerBookRow.Controls.Add(BookDigital);

            PNbookItem.Controls.Add(ContainerBookRow);
        }

        protected void BTNconfirm_Click(object sender, EventArgs e)
        {
            string restockId = Request.QueryString["RestockId"];

            foreach (Control control in PNbookItem.Controls)
            {
                if (control is HtmlGenericControl div)
                {
                    foreach (Control childControl in div.Controls)
                    {

                        if (childControl is TextBox textBoxP && textBoxP.ID.Contains("TBPhysical"))
                        {
                            string[] temp = textBoxP.ID.Split('_');
                            string bookId = temp[1];

                            int qty = rCon.validateQty(textBoxP.Text);
                            rCon.updateQty(restockId, bookId, qty, "Physical");
                        }

                        if (childControl is TextBox textBoxD && textBoxD.ID.Contains("TBDigital"))
                        {
                            string[] temp = textBoxD.ID.Split('_');
                            string bookId = temp[1];

                            int qty = rCon.validateQty(textBoxD.Text);
                            rCon.updateQty(restockId, bookId, qty, "Digital");

                        }

                    }
                }
            }

            List<RestockDetail> rds = rCon.getRestockDetails(restockId);
            rCon.updateCatalog(rds);
            PNpopUp.Visible = true;

        }

        protected void BTNcancel_Click(object sender, EventArgs e)
        {
            string restockId = Request.QueryString["RestockId"];
            rCon.cancelRestock(restockId);
            Response.Redirect("Inventory.aspx");
        }

        protected void BTNclose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }
    }
}