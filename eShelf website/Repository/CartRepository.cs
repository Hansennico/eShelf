using eShelf_website.Factory;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Repository
{
    public class CartRepository
    {
        DatabaseEntities db = new DatabaseEntities();

        public void createCart(string id, string bookId, int qty, string type)
        {
           
            Cart cart = CartFactory.createCart(id, bookId, qty, type);
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public bool validateCart(string id, string bookId, string type)
        {
            Cart cart = (from x in db.Carts
                         where
                         x.Id == id && x.BookID == bookId && x.Type == type
                         select x).FirstOrDefault();

            if (cart == null) return false;
            return true;
        }

        public void addCart(string id, string bookId, int qty, string type)
        {
            Cart cart = (from x in db.Carts
                         where
                         x.Id == id && x.BookID == bookId && x.Type == type
                         select x).FirstOrDefault();
            cart.Quantity += qty;
            db.SaveChanges();
        }

        public List<Cart> getCarts(string transactionId)
        {
            List<Cart> carts = (from x in db.Carts
                                where x.Id == transactionId
                                select x).ToList();
            return carts;
        }

        public Cart getCart(string transactionId, string bookId, string type)
        {
            Cart cart = (from x in db.Carts
                         where
                         x.Id == transactionId && x.BookID == bookId && x.Type == type
                         select x).FirstOrDefault();
            return cart;
        }

        public void setQtyCart(string transactionId, string bookId, string type, int qty)
        {
            Cart cart = (from x in db.Carts
                         where
                         x.Id == transactionId && x.BookID == bookId && x.Type == type
                         select x).FirstOrDefault();
            cart.Quantity = qty;
            db.SaveChanges();
        }

        public void delCart(string transactionId, string bookId, string type)
        {
            Cart cart = (from x in db.Carts
                         where
                         x.Id == transactionId && x.BookID == bookId && x.Type == type
                         select x).FirstOrDefault();
            db.Carts.Remove(cart);
            db.SaveChanges();
        }
    }
}