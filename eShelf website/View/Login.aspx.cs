using eShelf_website.Controller;
using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShelf_website.View
{
    public partial class Login : System.Web.UI.Page
    {
        LoginController loginCon = new LoginController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LBerror.Visible = false;
                checkCookie();
            }
        }

        protected void BTNtoRegister_Click(object sender, EventArgs e)
        {
            string[] cookie = Request.Cookies.AllKeys;
            foreach (string coo in cookie)
            {
                HttpCookie delCookie = Request.Cookies[coo];
                delCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(delCookie);
            }

            Session.Remove("user");

            Response.Redirect("~/View/Register.aspx");
        }

        protected void BTNlogin_Click(object sender, EventArgs e)
        {
            string email = TBemail.Text;
            string password = TBpassword.Text;
            

            User user = loginCon.validateLogin(email, password);

            if (user == null)
            {
                LBerror.Visible = true;
                LBerror.Text = "Invalid Credentials";
                return;
            }

            redirectHome(user);
        }

        private void redirectHome(User user)
        {
            Session["User"] = user;

            if(CBremember.Checked)
            {
                Response.Cookies.Add(loginCon.createCookie(user));
            }
            Response.Redirect("~/View/Home.aspx");

        }

        private void checkCookie()
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                string id = Request.Cookies["user_cookie"].Value;
                User user = loginCon.getUser(id);
                TBemail.Text = user.Email;
                TBpassword.Text = user.Password;
            }
        }
    }
}