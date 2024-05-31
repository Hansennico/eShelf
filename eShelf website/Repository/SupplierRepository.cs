using eShelf_website.Factory;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Repository
{
    public class SupplierRepository
    {
        DatabaseEntities db = Singleton.createInstance();

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = (from x in db.Suppliers select x).ToList();
            return suppliers;
        }
    }
}