using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Factory
{
    public class SupplierFactory
    {
        public static Supplier createSupplier(string id, string name, string email, string phone, string address)
        {
            Supplier supplier = new Supplier();
            supplier.Id = id;
            supplier.Name = name;
            supplier.Email = email;
            supplier.Phone = phone;
            supplier.Address = address;
            return supplier;
        }
    }
}