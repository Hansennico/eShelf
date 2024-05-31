using eShelf_website.Controller;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShelf_website.View
{
    public partial class EditItem : System.Web.UI.Page
    {
        EditItemController eiCon = new EditItemController();
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
                        User user = eiCon.getUser(userId);
                        Session["user"] = user;
                    }

                    User userd = (User)Session["user"];
                    if (!eiCon.isAdmin(userd.Id))
                    {
                        Response.Redirect("Home.aspx");
                    }
                    LBerror.Visible = false;
                    PNpopUp.Visible = false;
                    setDDLgenre();
                    setItem();

                }
                
            }
            
        }

        private void setDDLgenre()
        {
            List<string> genres = eiCon.getGenres();
            foreach (var g in genres)
            {
                DDLgenre.Items.Add(new ListItem(g));
            }
        }

        private void setItem()
        {
            string id = Request.QueryString["BookId"];
            Book book = eiCon.getBook(id);
            if(book == null)
            {
                Response.Redirect("Inventory.aspx");
                return;
            }

            TBtitle.Text = book.Title;
            TBauthor.Text = book.Author;
            TBsypnosis.Text = book.Sypnosis;
            TBprice.Text = book.Price.ToString();
            TBpublisher.Text = book.Publisher;
        }

        protected void BTNedit_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["BookId"];

            string title = TBtitle.Text;
            string author = TBauthor.Text;
            string sypnosis = TBsypnosis.Text;
            string genre = DDLgenre.Text;
            string price = TBprice.Text;
            string publisher = TBpublisher.Text;
            string publishDate = TBpublishDate.Text;

            if (!eiCon.validateInput(title, author, sypnosis, genre, price, publisher, publishDate))
            {
                LBerror.Visible = true;
                return;
            }

            eiCon.updateBook(id, title, author, sypnosis, genre, price, publisher, publishDate);
           PNpopUp.Visible = true;
        }

        protected void BTNcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }

        protected void BTNclose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }
    }
}