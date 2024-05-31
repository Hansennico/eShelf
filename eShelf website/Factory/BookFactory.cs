using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace eShelf_website.Factory
{
    public class BookFactory
    {
        public static Book createBook(string id, string title, string author, string sypnosis, float price, float rating, 
                string genre, string publisher, DateTime publishDate, string cover, string supplierID)
        {

            Book book = new Book();
            book.Id = id;
            book.Title = title;
            book.Author = author;
            book.Sypnosis = sypnosis;
            book.Price = price;
            book.Rating = rating;
            book.Genre  = genre;
            book.Publisher = publisher;
            book.PublishDate = publishDate;
            book.Cover = cover;
            book.SupplierID = supplierID;
            return book;
        }
    }
}