using eShelf_website.Factory;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace eShelf_website.Repository
{
    public class BookRepository
    {
        DatabaseEntities db = new DatabaseEntities();

        public List<Book> getAllBook()
        {
            List<Book> books = (from x in db.Books select x).ToList();
            return books;
        }

        public List<Book> getAllBook(string text)
        {
            List<Book> books = (from x in db.Books where
                                x.Title.ToLower().Contains(text.ToLower()) ||
                                x.Author.ToLower().Contains(text.ToLower())
                                select x).ToList();
            return books;
        }

        public List<string> getGenres()
        {
            List<string> genres = (from x in db.Books select x.Genre).Distinct().ToList();
            return genres;
        }

        public List<Book> getFilterBook(string genre)
        {
            List<Book> books =(from x in db.Books where x.Genre == genre select x).ToList();
            return books;
        }

        public List<Book> getFilterBook(string genre, int min, int max)
        {
            List<Book> books = (from x in db.Books
                                where x.Genre == genre && x.Price >= min && x.Price <= max
                                select x).ToList();
            return books;   
        }

        public List<Book> getFilterBook(int min, int max)
        {
            List<Book> books = (from x in db.Books where
                                x.Price >= min && x.Price <= max
                                select x).ToList();
            return books;
        }

        public List<Book> getFilterBookMin(string genre, int min)
        {
            List<Book> books = (from x in db.Books
                                where x.Genre == genre && x.Price >= min
                                select x).ToList();
            return books;
        }

        public List<Book> getFilterBookMin(int min)
        {
            List<Book> books = (from x in db.Books
                                where  x.Price >= min
                                select x).ToList();
            return books;
        }

        public List<Book> getFilterBookMax(string genre, int max)
        {
            List<Book> books = (from x in db.Books
                                where x.Genre == genre && x.Price <= max
                                select x).ToList();
            return books;
        }

        public List<Book> getFilterBookMax(int max)
        {
            List<Book> books = (from x in db.Books
                                where x.Price <= max
                                select x).ToList();
            return books;
        }

        public Book getBook(string id)
        {
            Book book = (from x in db.Books where x.Id == id select x).FirstOrDefault();
            return book;
        }

        public void addBook(string id, string title, string author, string sypnosis, string genre,
            float price, string publisher, DateTime publishDate, string supplierId, string cover)
        {
            float rating;
            float.TryParse("2.5", out rating);

            Book book = BookFactory.createBook(id, title, author, sypnosis, price,  rating, genre, publisher,
                publishDate, cover, supplierId);

            db.Books.Add(book);
            db.SaveChanges();
        }

        

        public string getLastId()
        {
            return (from x in db.Books select x.Id).ToList().LastOrDefault();
        }

        public void updateBook(string id, string title, string author, string sypnosis, string genre,
            float price, string publisher, DateTime publishDate)
        {
            Book book = (from x in db.Books where x.Id == id select x).FirstOrDefault();
            book.Title = title;
            book.Author = author;
            book.Sypnosis = sypnosis;
            book.Genre = genre;
            book.Price = price;
            book.Publisher = publisher;
            book.PublishDate = publishDate;
            db.SaveChanges();
        }
    }
}