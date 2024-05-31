using eShelf_website.Controller;
using eShelf_website.Factory;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace eShelf_website.Repository
{
    public class RestockDetailRepository
    {
        DatabaseEntities db = new DatabaseEntities();

        public void createRD(string id, string bookId)
        {
            RestockDetail rd1 = RestockDetailFactory.createRD(id, bookId);
            db.RestockDetails.Add(rd1);
            db.SaveChanges();
        }
        
        public List<RestockDetail> getRestockDetails(string id)
        {
            List<RestockDetail> rds = (from x in db.RestockDetails
                                       where x.Id == id
                                       select x).ToList();
            return rds;
        }

        public void updateRestockDetails(string restockId, string bookId, int qty, string type)
        {
            RestockDetail rd = (from x in db.RestockDetails
                                where x.Id == restockId && x.BookID == bookId
                                select x).FirstOrDefault();
            
            if(type == "Physical")
                rd.QuantityPhysical = qty;
            else
                rd.QuantityDigital = qty;
            db.SaveChanges();
        }

        public void removeRestockDetails(string restockId)
        {
            List<RestockDetail> rds = (from x in db.RestockDetails
                                       where x.Id == restockId
                                       select x).ToList();

            foreach(var r in rds)
            {
                db.RestockDetails.Remove(r);
            }
            db.SaveChanges();
        }
        
    }
}