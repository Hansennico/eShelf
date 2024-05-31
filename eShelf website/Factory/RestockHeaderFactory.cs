using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Factory
{
    public class RestockHeaderFactory
    {
       public static RestockHeader createRH(string id)
        {
            RestockHeader rh = new RestockHeader();
            rh.Id = id;
            rh.RestockDate = DateTime.Now;
            return rh;
        }
    }
}