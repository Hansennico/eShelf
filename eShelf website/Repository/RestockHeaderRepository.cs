using eShelf_website.Factory;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Repository
{
    public class RestockHeaderRepository
    {
        DatabaseEntities db = Singleton.createInstance();
        public string getLastId()
        {
            return (from x in db.RestockHeaders select x.Id).ToList().LastOrDefault();
        }

        public void createRH(string id)
        {
            RestockHeader rh = RestockHeaderFactory.createRH(id);
            db.RestockHeaders.Add(rh);
            db.SaveChanges();
        }

        public void removeRH(string id)
        {
            RestockHeader rh = (from x in db.RestockHeaders
                                where x.Id == id
                                select x).FirstOrDefault();
            db.RestockHeaders.Remove(rh);
            db.SaveChanges();
        }
    }
}