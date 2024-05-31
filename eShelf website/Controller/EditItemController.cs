using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Controller
{
    public class EditItemController
    {
        BookRepository bookRepo = new BookRepository();
        UserRepository userRepo = new UserRepository();

        public User getUser(string id)
        {
            return userRepo.getUser(id);
        }

        public bool isAdmin(string id)
        {
            if (id.Contains("AD"))
                return true;
            return false;
        }

        public List<string> getGenres()
        {
            List<string> genres = new List<string>
            {
                "Adventure",
                "Biography",
                "Classic",
                "Comedy",
                "Crime",
                "Dystopian",
                "Fantasy",
                "Historical Fiction",
                "Horror",
                "Mystery",
                "Non-Fiction",
                "Paranormal",
                "Poetry",
                "Romance",
                "Science Fiction",
                "Self-Help",
                "Short Stories",
                "Thriller",
                "Travel",
                "Young Adult"
            };
            return genres;
        }
        public Book getBook(string id)
        {
            return bookRepo.getBook(id);
        }

        public bool validateInput(string title, string author, string sypnosis, string genre,
            string price, string publisher, string publisherDate)
        {
            if (!validateStr(title) || !validateStr(author) || !validateStr(sypnosis) ||
                !validateStr(genre) || !validatePrice(price) || !validateStr(publisher)
                || !validateStr(publisherDate))
                return false;

            return true;
        }

        private bool validateStr(string str)
        {
            if (String.IsNullOrEmpty(str))
                return false;
            return true;
        }

        private bool validatePrice(string price)
        {
            if (String.IsNullOrEmpty(price))
                return false;

            int p = Convert.ToInt32(price);
            if (p <= 0)
                return false;

            return true;
        }
    
        public void updateBook(string id, string title, string author, string sypnosis, string genre,
            string price, string publisher, string publisherDate)
        {
            float intPrice;
            float.TryParse(price, out intPrice);

            DateTime publishDate = DateTime.Parse(publisherDate);

            bookRepo.updateBook(id, title, author, sypnosis, genre, intPrice, publisher, publishDate);
        }
    }
}