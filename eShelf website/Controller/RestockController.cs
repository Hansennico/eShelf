using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eShelf_website.Controller
{
    public class RestockController
    {
        RestockDetailRepository rdRepo = new RestockDetailRepository();
        BookRepository bookRepo = new BookRepository();
        CatalogRepository catalogRepo = new CatalogRepository();
        RestockHeaderRepository rhRepo = new RestockHeaderRepository();
        UserRepository userRepo = new UserRepository();

        public User getUser(string id)
        {
            return userRepo.getUser(id);
        }

        public bool isAdmin(string id)
        {
            if (id.Contains("AD"))
                return true;
            return false;
        }


        public List<RestockDetail> getRestockDetails(string id)
        {
            return rdRepo.getRestockDetails(id);
        }

        public Book getBook(string id)
        {
            return bookRepo.getBook(id);
        }

        public HtmlGenericControl createDiv(string css, string text)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes["class"] = css;
            div.InnerHtml = text;
            return div;
        }

        public HtmlGenericControl createDiv(string css)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes["class"] = css;
            return div;
        }

        public TextBox createTB(string id, string type, string css, string text)
        {
            TextBox tb = new TextBox();
            tb.ID = $"TB{type}_{id}";
            tb.CssClass = css;
            tb.Text = text;
            tb.TextMode = TextBoxMode.Number;
            return tb;
        }

        public int validateQty(string x)
        {
            int qty = Convert.ToInt32(x);
            if (qty < 0)
                qty = 0;
            return qty;
        }

        public void updateQty(string restockId, string bookId, int qty, string type)
        {
            rdRepo.updateRestockDetails(restockId, bookId, qty, type);
        }

        public void updateCatalog(List<RestockDetail> rds)
        {
            foreach(var r in rds)
            {
                catalogRepo.restock(r.BookID, r.QuantityPhysical, r.QuantityDigital);
            }
        }

        public void cancelRestock(string id)
        {
            rdRepo.removeRestockDetails(id);
            rhRepo.removeRH(id);
            
        }
    }
}