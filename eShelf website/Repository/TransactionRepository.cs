using eShelf_website.Factory;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Repository
{
    public class TransactionRepository
    {
        DatabaseEntities db = Singleton.createInstance();

        public string checkTransactionExist(string userId)
        {
            string transactionID = (from x in db.Transactions
                                    where x.UserID == userId && x.IsCheckout == 0
                                    select x.Id).FirstOrDefault();
            return transactionID;
        }

        public string getLastId()
        {
            string id = (from x in db.Transactions select x.Id).ToList().LastOrDefault();
            return id;
        }

        public void createTransaction(string id, string userId, string paymentMethodId)
        {
            Transaction trans = TransactionFactory.createTransaction(id, userId, paymentMethodId);
            db.Transactions.Add(trans);
            db.SaveChanges();
        }

        public string getTransactionId(string userId)
        {
            string id = (from x in db.Transactions where 
                         x.UserID == userId && x.IsCheckout == 0 
                         select x.Id).FirstOrDefault();
            return id;
        }

        public void checkOut(string transactionId, string pmId)
        {
            Transaction trans = (from x in db.Transactions
                                 where x.Id == transactionId
                                 select x).FirstOrDefault();
            trans.IsCheckout = 1;
            trans.PaymentMethodID = pmId;
            trans.TransactionDate = DateTime.Now;
            db.SaveChanges();
        }

        public List<Transaction> getTransactions(string userId)
        {
            List<Transaction> transList = (from x in db.Transactions
                                           where
                                           x.UserID == userId && x.IsCheckout == 1
                                           select x).ToList();
            return transList;
        }
    }
}