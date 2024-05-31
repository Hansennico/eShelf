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
    public partial class AddItem : System.Web.UI.Page
    {
        AddItemController aiCon = new AddItemController();   
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
                        User user = aiCon.getUser(userId);
                        Session["user"] = user;
                    }

                    User userd = (User)Session["user"];
                    if (!aiCon.isAdmin(userd.Id))
                    {
                        Response.Redirect("Home.aspx");
                    }

                    LBerror.Visible = false;
                    PNpopUp.Visible = false;
                    setDDLgenre();
                    setDDLsupplier();
                }
            }
        }

        private void setDDLgenre()
        {
            List<string> genres = aiCon.getGenres();
            foreach(var g in genres)
            {
                DDLgenre.Items.Add(new ListItem(g));
            }
        }

        private void setDDLsupplier()
        {
            List<Supplier> suppliers = aiCon.getSuppliers();
            foreach(var s in suppliers)
            {
                DDLsupplier.Items.Add(new ListItem(s.Name, s.Id));
            }
        }

        protected void BTNcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }

        protected void BTNadd_Click(object sender, EventArgs e)
        {
            string title = TBtitle.Text;
            string author = TBauthor.Text;
            string sypnosis = TBsypnosis.Text;
            string genre = DDLgenre.Text;
            string price = TBprice.Text;
            string publisher = TBpublisher.Text;
            string publishDate = TBpublishDate.Text;
            string stockP = TBphysicalStock.Text;
            string stockD = TBdigitalStock.Text;
            string supplierId = DDLsupplier.SelectedValue.ToString();
            string fileName = Path.GetFileName(FFcover.FileName);
            
            
            if(!aiCon.validateInput(title, author, sypnosis, genre, price, publisher, publishDate,
                stockP, stockD, supplierId, fileName))
            {
                LBerror.Visible = true;
                return;
            }

            string filePath = Server.MapPath("../cover/") + fileName;
            FFcover.SaveAs(filePath);
            string filePathDB = "../cover/" + fileName;

            aiCon.addBook(title, author, sypnosis, genre, price, publisher, publishDate, stockP, stockD,
                supplierId, filePathDB);

            PNpopUp.Visible = true;
        }

        protected void BTNclose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }
    }
}