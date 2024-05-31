using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Factory
{
    public class CartFactory
    {
        public static Cart createCart(string id, string BookId, int qty, string type)
        {
            Cart cart = new Cart();
            cart.Id = id;
            cart.BookID = BookId;
            cart.Quantity = qty;
            cart.Type = type;
            return cart;
        }
    }
}