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
    public partial class Inventory : System.Web.UI.Page
    {
        InventoryController ivCon = new InventoryController();
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
                        User user = ivCon.getUser(userId);
                        Session["user"] = user;  
                    }

                    User userd =  (User)Session["user"];
                    if (!ivCon.isAdmin(userd.Id))
                    {
                        Response.Redirect("Home.aspx");
                    }
                }
            }

            setItem();
        }

        private void setItem()
        {
            List<Catalog> catalogs = ivCon.getAllCatalog();

            foreach(var c in catalogs)
            {
                Book b = ivCon.getBook(c.BookID);
                addItem(c, b);
            }
        }

        private void addItem(Catalog c, Book b)
        {
            HtmlGenericControl ContainerBookRow = ivCon.createDiv("ContainerBookRow");

            CheckBox CBrestock = ivCon.createCB(c.BookID, "CBbook");
            ContainerBookRow.Controls.Add(CBrestock);

            HtmlGenericControl BookId = ivCon.createDiv("BookInfo", c.BookID);
            ContainerBookRow.Controls.Add(BookId);

            HtmlGenericControl BookTitle= ivCon.createDiv("BookInfo", b.Title);
            ContainerBookRow.Controls.Add(BookTitle);

            HtmlGenericControl BookPrice = ivCon.createDiv("BookInfo", $"Rp. {b.Price.ToString("###,###,##0.00")}");
            ContainerBookRow.Controls.Add(BookPrice);

            HtmlGenericControl BookPhysical = ivCon.createDiv("BookInfo", c.QuantityPhysical.ToString());
            ContainerBookRow.Controls.Add(BookPhysical);

            HtmlGenericControl BookDigital = ivCon.createDiv("BookInfo", c.QuantityDigital.ToString());
            ContainerBookRow.Controls.Add(BookDigital);

            LinkButton BTNedit = ivCon.createBTN("Edit", c.BookID);
            BTNedit.CommandArgument = c.BookID;
            BTNedit.Command += new CommandEventHandler(BTNedit_command);
            ContainerBookRow.Controls.Add(BTNedit);

            PNbookItem.Controls.Add(ContainerBookRow);
        }

        private void BTNedit_command(Object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect($"EditItem.aspx?BookId={id}");
        }

        protected void BTNrestock_Click(object sender, EventArgs e)
        {
            List<Catalog> catalogs = new List<Catalog>();

            if (CBrestockAll.Checked)
            {
                catalogs = ivCon.getAllCatalog();
            }
            else
            {
                foreach (Control control in PNbookItem.Controls)
                {
                    if (control is HtmlGenericControl div)
                    {
                        foreach (Control childControl in div.Controls)
                        {
                            if (childControl is CheckBox checkBox && checkBox.CssClass.Contains("CBbook"))
                            {

                                if (checkBox.Checked)
                                {
                                    string[] temp = checkBox.ID.Split('_');
                                    string id = temp[1];
                                    Catalog catalog = ivCon.getCatalog(id);
                                    catalogs.Add(catalog);
                                }
                            }
                        }
                    }
                }
            }

            string restockId = ivCon.restock(catalogs);
            
            if (String.IsNullOrEmpty(restockId))
                return;

            Response.Redirect($"Restock.aspx?RestockId={restockId}");
        }

        protected void BTNbook_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx");
        }

        
    }
}