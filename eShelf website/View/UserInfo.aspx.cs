using eShelf_website.Controller;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eShelf_website.View
{
    public partial class UserInfo : System.Web.UI.Page
    {
        UserInfoController uiCon = new UserInfoController();    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    if (Session["user"] == null)
                    {
                        string userId = Request.Cookies["user_cookie"].Value;
                        User user = uiCon.getUser(userId);
                        Session["user"] = user;
                    }
                    setUser();
                    setHistory();

                }
            }
        }

        private void setUser()
        {
            User user = (User)Session["user"];

            if (user == null)
            {
                Response.Redirect("Home.aspx");
                return;
            }

            LBuserName.Text = user.Name;
            LBuserEmail.Text = user.Email;
            LBuserPhone.Text = getPhone(user.Phone, user.Country);
            LBuserAddress.Text = getText(user.BillingAddress);
            LBuserCountry.Text = getText(user.Country);
            LBuserPostalCode.Text = getText(user.PostalCode.ToString());
            LBuserState.Text = getText(user.State);
            LBuserCity.Text = getText(user.City);
        }

        private string getText(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return "-";
            }
            return text;
        }

        private string getPhone(string text, string country)
        {
            string phone = getText(text);
            if(phone != "-" && !String.IsNullOrEmpty(country))
            {
                string code = uiCon.getPhoneCode(country);
                phone = $"({code}) {phone}";
            }
            return phone;
        }

        private void setHistory()
        {
            User user = (User)Session["user"];
            string id = user.Id;
            List<Transaction> transList = uiCon.getTransactions(id);

            foreach(var t in transList)
            {
                string method = uiCon.getPaymentName(t.PaymentMethodID);
                double amount = uiCon.getAmount(t.Id);
                string dateStr = t.TransactionDate.ToString();
                DateTime date = DateTime.Parse(dateStr);
                addHistory(date, method, amount);
            }

        }

        private void addHistory(DateTime date, string method, double amount)
        {
            HtmlGenericControl transactionDetail = uiCon.createDiv(date, method, amount);
            PNhistory.Controls.Add(transactionDetail);
        }

        protected void BTNedit_Click(object sender, EventArgs e)
        {

        }
    }
}