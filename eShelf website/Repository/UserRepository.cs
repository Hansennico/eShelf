using eShelf_website.Factory;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Repository
{
    public class UserRepository
    {
        DatabaseEntities db = Singleton.createInstance();

        public User getUser(string email, string password)
        {
            User user = (from x in db.Users where x.Email == email && x.Password == password select x).FirstOrDefault();
            return user;
        }

        public User getUser(string id)
        {
            User user = (from x in db.Users where x.Id == id select x).FirstOrDefault();
            return user;
        }

        public string getLastId()
        {
            return (from x in db.Users select x.Id).ToList().LastOrDefault();
        }

        public void insertUser(string id, string name, string email, string password)
        {
            User user = UserFactory.createUser(id, name, email, password);
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void updateAddressInfo(string phone, string address, int postal, string country, string state, string city, string id)
        {
            User user = db.Users.Find(id);
            user.Phone = phone;
            user.BillingAddress = address;
            user.PostalCode = postal;
            user.Country = country;
            user.State = state;
            user.City = city;
            db.SaveChanges();
        }
    }
}