using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShelf_website.Factory
{
    public class TransactionFactory
    {
        public static Transaction createTransaction(string id, string userId, string paymnetId) 
        {
            Transaction trans = new Transaction();
            trans.Id = id;
            trans.UserID = userId;
            trans.PaymentMethodID = paymnetId;
            trans.IsCheckout = 0;
            return trans;
        }
    }
}