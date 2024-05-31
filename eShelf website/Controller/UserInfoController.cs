using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace eShelf_website.Controller
{
    public class UserInfoController
    {
        UserRepository userRepo = new UserRepository();
        TransactionRepository transRepo = new TransactionRepository();
        PaymentMethodRepository pmRepo = new PaymentMethodRepository();
        CartRepository cartRepo = new CartRepository();
        BookRepository bookRepo = new BookRepository();

        public User getUser(string id)
        {
            return userRepo.getUser(id);            
        }

        private List<Country> getCountryList()
        {
            Country Indonesia = new Country("Indonesia", "+62", "ID");
            Country Phillipines = new Country("Phillipines", "+63", "PH");
            Country Singapore = new Country("Singapore", "+65", "SG");
            Country Malaysia = new Country("Malaysia", "+60", "MY");
            Country Japan = new Country("Japan", "+81", "JP");

            List<Country> countries = new List<Country> { Indonesia, Phillipines, Singapore, Malaysia, Japan };
            return countries;
        }

        public string getPhoneCode(string name)
        {
            List<Country> countryList = getCountryList();
            foreach(var c in countryList)
            {
                if(c.getName() == name)
                    return c.getDialCode();
            }
            return null;
        }

        public List<Transaction> getTransactions(string userId)
        {
            return transRepo.getTransactions(userId);
        }

        public string getPaymentName(string id)
        {
            return pmRepo.getPMName(id);
        }

        public double getAmount(string id)
        {
            List<Cart> carts = cartRepo.getCarts(id);
            double amount = 0;

            foreach(var c in carts)
            {
                Book b = bookRepo.getBook(c.BookID);
                amount += b.Price * c.Quantity;
            }

            return amount * 1.1;
        }

        public HtmlGenericControl createDiv(DateTime date, string method, double amount)
        {
            
            HtmlGenericControl container = new HtmlGenericControl("div");
            container.Attributes["class"] = "TransactionDetail";

            HtmlGenericControl spanDate = new HtmlGenericControl("span");
            spanDate.Attributes["class"] = "tDate";
            spanDate.InnerHtml = date.ToString("dd MMMM yyyy");
            container.Controls.Add(spanDate);

            HtmlGenericControl spanMethod = new HtmlGenericControl("span");
            spanMethod.Attributes["class"] = "tMethod";
            spanMethod.InnerHtml = method;
            container.Controls.Add(spanMethod);

            HtmlGenericControl spanAmount = new HtmlGenericControl("span");
            spanAmount.Attributes["class"] = "tAmount";
            spanAmount.InnerHtml = "Rp. " + amount.ToString("###,###,##0.00");
            container.Controls.Add(spanAmount);

            return container;
        }
    }
}