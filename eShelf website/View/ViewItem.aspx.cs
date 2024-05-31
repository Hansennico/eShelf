using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShelf_website.View
{
    public partial class ViewItem : System.Web.UI.Page
    {
        ViewItemController viCon = new ViewItemController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LBerror.Visible = false;
                string id = Request.QueryString["BookId"];

                if (!viCon.validateId(id))
                {
                    Response.Redirect("Home.aspx");
                    return;
                }

                Book viewBook = viCon.getBook(id);
                Catalog viewCatalog = viCon.getCatalog(id);
                setPage(viewBook, viewCatalog);
            }
        }

        private void setPage(Book viewBook, Catalog viewCatalog)
        {
            itemBookCover.Attributes["style"] = $"background-image: url('{viewBook.Cover}');";
            LBtitle.Text = viewBook.Title;
            LBauthor.Text = viewBook.Author;
            BookSypnosis.Text = viewBook.Sypnosis;
            LBpublish.Text = viewBook.Genre + " . " + "Published by " + viewBook.Publisher + " . " + viewBook.PublishDate.ToString("dd MMMM yyyy") + " . ";
            LBrating.Text = viewBook.Rating.ToString("0.0");
            LBprice.Text = "Rp. " + viewBook.Price.ToString("###,###,##0.00");
            LBphysicalStock.Text = viewCatalog.QuantityPhysical + " in Stock";
            LBdigitalStock.Text = viewCatalog.QuantityDigital + " in Stock";
        }

        protected void BTNaddCart_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            //Temporary User ID
            User user = (User)Session["user"];

            string bookId = Request.QueryString["BookId"];

            string quantity = TBquantity.Text;
            bool physical = RBphysical.Checked;
            bool digital = RBdigital.Checked;

            if(!viCon.validateAddCart(quantity, physical, digital, bookId))
            {
                LBerror.Visible = true;
                LBerror.Text = "Quantity must be at least 1";
                return;
            }

            int qty = Convert.ToInt32(quantity);
            string type = "";

            if (physical)
                type = "Physical";
            else
                type = "Digital";

            viCon.addItemToCart(user.Id, bookId, qty, type);

            Catalog viewCatalog = viCon.getCatalog(bookId);
            LBphysicalStock.Text = viewCatalog.QuantityPhysical + " in Stock";
            LBdigitalStock.Text = viewCatalog.QuantityDigital + " in Stock";
            TBquantity.Text = "";

        }
    }
}