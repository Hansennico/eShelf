using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eShelf_website.Factory
{
    public class Singleton
    {
        public static DatabaseEntities db = null;

        public static DatabaseEntities createInstance()
        {
            if (db == null) { 
                db  = new DatabaseEntities();
            }
            return db;
        }
    }
}