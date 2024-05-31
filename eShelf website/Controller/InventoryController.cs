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
    public class InventoryController
    {
        CatalogRepository catalogRepo = new CatalogRepository();
        BookRepository bookRepo = new BookRepository();
        RestockHeaderRepository rhRepo = new RestockHeaderRepository();
        RestockDetailRepository rdRepo = new RestockDetailRepository();
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

        public List<Catalog> getAllCatalog()
        {
            return catalogRepo.getAllCatalog();
        } 

        public Book getBook(string bookId)
        {
            return bookRepo.getBook(bookId);    
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

        public CheckBox createCB(string id, string css)
        {
            CheckBox cb = new CheckBox();
            cb.ID = $"CBrestock_{id}";
            cb.CssClass = css;
            return cb;
        }

        public LinkButton createBTN(string type, string id)
        {
            LinkButton btn = new LinkButton();
            btn.ID = $"BTNbook{type}_{id}";
            btn.CssClass = $"BookInfo BTNbook BTNbook{type}";
            btn.Text = type;
            return btn;
        }
    
        public string restock(List<Catalog> catalogs)
        {
            if (catalogs == null)
                return null;

            string id = generateId();
            rhRepo.createRH(id);

            foreach (var c in catalogs)
            {
                rdRepo.createRD(id, c.BookID);
            }

            return id;
        }

        private string generateId()
        {
            string newId = "";
            string lastId = rhRepo.getLastId();

            if (lastId == null)
            {
                newId = "RE001";
            }
            else
            {
                int idNum = Convert.ToInt32(lastId.Substring(2));
                idNum++;
                newId = String.Format("RE{0:000}", idNum);
            }
            return newId;
        }
        
        public Catalog getCatalog(string id)
        {
            return catalogRepo.getCatalog(id);
        }


    }
}