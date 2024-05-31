using eShelf_website.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;
using System.Web.Services.Description;
using eShelf_website.Model;
using eShelf_website.Repository;
using System.Collections;
using System.IO;

namespace eShelf_website.Controller
{
    public class AddItemController
    {
        SupplierRepository supRepo = new SupplierRepository();
        BookRepository bookRepo = new BookRepository();
        CatalogRepository catalogRepo = new CatalogRepository();
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
    
        public List<Supplier> getSuppliers()
        {
            return supRepo.GetSuppliers();
        }

        public bool validateInput(string title, string author, string sypnosis, string genre,
            string price, string publisher, string publisherDate, string stockP, string stockD,
            string supplierId, string fileName)
        {
            if (!validateStr(title) || !validateStr(author) || !validateStr(sypnosis) ||
                !validateStr(genre) || !validatePrice(price) || !validateStr(publisher) 
                || !validateStr(publisherDate) || !validateStock(stockP) || 
                !validateStock(stockD) || !validateStr(supplierId) || !validateFile(fileName)) 
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

            int p = Convert.ToInt32 (price);
            if (p <= 0)
                return false;

            return true;
        }

        private bool validateStock(string stock)
        {
            if (String.IsNullOrEmpty(stock))
                return false;

            int p = Convert.ToInt32(stock);
            if (p < 0)
                return false;

            return true;
        }

        private bool validateFile(string file)
        {
            if (String.IsNullOrEmpty(file))
                return false;

            string extension = Path.GetExtension(file);

            if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
    
        public void addBook(string title, string author, string sypnosis, string genre,
            string price, string publisher, string publisherDate, string stockP, string stockD,
            string supplierId, string filePath)
        {
            DateTime publishDate = DateTime.Parse(publisherDate);
            string id = generateId();

            int qtyP = Convert.ToInt32(stockP);
            int qtyD = Convert.ToInt32(stockD);
            float intPrice;
            float.TryParse(price, out intPrice);

            bookRepo.addBook(id, title, author, sypnosis, genre, intPrice, publisher, publishDate,
                supplierId, filePath);

            catalogRepo.addCatalog(id, qtyP, qtyD);
        }

        private string generateId()
        {
            string newId = "";
            string lastId = bookRepo.getLastId();

            if (lastId == null)
            {
                newId = "BO001";
            }
            else
            {
                int idNum = Convert.ToInt32(lastId.Substring(2));
                idNum++;
                newId = String.Format("BO{0:000}", idNum);
            }
            return newId;
        }
    }
}
