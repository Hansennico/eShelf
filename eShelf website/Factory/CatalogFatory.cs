using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace eShelf_website.Factory
{
    public class CatalogFatory
    {
        public static Catalog createCatalog(string bookid, int physicalQuantity, int digitalQuantity)
        {
            Catalog catalog = new Catalog();
            catalog.BookID = bookid;
            catalog.QuantityPhysical = physicalQuantity;
            catalog.QuantityDigital = digitalQuantity;
            return catalog;
        }
    }
}