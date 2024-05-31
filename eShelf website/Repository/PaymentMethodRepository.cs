using eShelf_website.Factory;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Repository
{
    public class PaymentMethodRepository
    {
        DatabaseEntities db = Singleton.createInstance();
    
        public List<PaymentMethod> getAllPaymentMethods()
        {
            List<PaymentMethod> pms = (from x in db.PaymentMethods select x).ToList();
            return pms;
        }

        public string getPMID(string name)
        {
            string pm = (from x in db.PaymentMethods where x.Name == name select x.Id).FirstOrDefault();
            return pm;
        }

        public string getPMName(string id)
        {
            string name = (from x in db.PaymentMethods
                           where x.Id == id
                           select x.Name).FirstOrDefault();
            return name;
        }
    }
}