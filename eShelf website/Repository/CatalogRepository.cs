using eShelf_website.Factory;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Repository
{
    public class CatalogRepository
    {
        DatabaseEntities db = Singleton.createInstance();

        public Catalog getCatalog(string bookId)
        {
            Catalog catalog = (from x in db.Catalogs where x.BookID == bookId select x).FirstOrDefault();
            return catalog;
        }

        public void updateMinQuantity(string bookId, int qty, string type)
        {
            Catalog catalog = db.Catalogs.Find(bookId);
            
            if(type == "Physical")
            {
                catalog.QuantityPhysical -= qty;
            }
            else
            {
                catalog.QuantityDigital -= qty;
            }
            db.SaveChanges();
        }

        public void setQtyCatalog(string bookId, string type, int qty)
        {
            Catalog catalog = db.Catalogs.Find(bookId);
            if (type == "Physical")
            {
                catalog.QuantityPhysical = qty;
            }
            else
            {
                catalog.QuantityDigital = qty;
            }
            db.SaveChanges();
        }

        public List<Catalog> getAllCatalog()
        {
            List<Catalog> catalogs = (from x in db.Catalogs select x).ToList();
            return catalogs;
        }

        public void restock(string bookId, int qtyP, int qtyD)
        {
            Catalog catalog = (from x in db.Catalogs where x.BookID == bookId select x).FirstOrDefault();
            catalog.QuantityPhysical += qtyP;
            catalog.QuantityDigital += qtyD;
            db.SaveChanges();
        }

        public void addCatalog(string id, int qtyP, int qtyD)
        {
            Catalog catalog = CatalogFatory.createCatalog(id, qtyP, qtyD);
            db.Catalogs.Add(catalog);
            db.SaveChanges();
        }
    }
}