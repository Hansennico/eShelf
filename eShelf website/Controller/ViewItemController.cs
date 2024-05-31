using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.View
{
    public class ViewItemController
    {
        BookRepository bookRepo = new BookRepository();
        CatalogRepository catalogRepo = new CatalogRepository();
        TransactionRepository transRepo = new TransactionRepository();
        CartRepository cartRepo = new CartRepository();

        public bool validateId(string id)
        {
            if (String.IsNullOrEmpty(id))
                return false;
            return true;
        }
        public Book getBook(string id)
        {
            Book book = bookRepo.getBook(id);
            return book;
        }

        public Catalog getCatalog(string id)
        {
            Catalog catalog = catalogRepo.getCatalog(id);
            return catalog;
        }

        public bool validateAddCart(string quantity, bool physical, bool digital, string bookId)
        {
            if (String.IsNullOrEmpty(quantity) || quantity.Length <= 0 || (physical == false && digital == false))
            {
                return false;
            }

            Catalog catalog = catalogRepo.getCatalog(bookId);
            int qty = Convert.ToInt32(quantity);

            if (physical)
            {
                if ( qty<= 0 || qty > catalog.QuantityPhysical)
                {
                    return false;
                }
            }
            else if (digital)
            {
                if (qty <= 0 || qty > catalog.QuantityDigital)
                {
                    return false;
                }
            }

            
            return true;
        }

        public void addItemToCart(string userId, string bookId, int qty, string type)
        {
            string transactionID = transRepo.checkTransactionExist(userId);

            if (transactionID == null)
            {
                transactionID = generateId();
                transRepo.createTransaction(transactionID, userId, "PM001");
            }

            if(cartRepo.validateCart(transactionID, bookId, type))
            {
                cartRepo.addCart(transactionID, bookId, qty, type);
            }
            else
            {
                cartRepo.createCart(transactionID, bookId, qty, type);
                
            }
            catalogRepo.updateMinQuantity(bookId, qty, type);
        }

        private string generateId()
        {
            string newId = "";
            string lastId = transRepo.getLastId();

            if (lastId == null)
            {
                newId = "TR001";
            }
            else
            {
                int idNum = Convert.ToInt32(lastId.Substring(2));
                idNum++;
                newId = String.Format("TR{0:000}", idNum);
            }
            return newId;
        }
    }
}