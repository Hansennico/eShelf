using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Factory
{
    public class RestockDetailFactory
    {
        public static RestockDetail createRD(string id, string bookId)
        {
            RestockDetail rd = new RestockDetail();
            rd.Id = id;
            rd.BookID = bookId;
            rd.QuantityDigital = 50;
            rd.QuantityPhysical = 50;
            return rd;
        }
    }
}