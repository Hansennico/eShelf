using eShelf_website.Controller;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShelf_website.View
{
    public partial class Master : System.Web.UI.MasterPage
    {
        MasterController masterCon = new MasterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                    setUnlogged();
                }
                else
                {
                    if (Session["user"] == null)
                    {
                        string userId = Request.Cookies["user_cookie"].Value;
                        User user = masterCon.getUser(userId);
                        Session["user"] = user;
                    }

                    setLogged();
                }
            }


        }

        private void setUnlogged()
        {
            BTNcart.Visible = false;
            BTNinventory.Visible = false;
            BTNaccount.Visible = false;
            BTNlogin.Text = "Login";
            BTNregister.Visible = true;
        }

        private void setLogged()
        {
            User user = (User)Session["user"];
            BTNcart.Visible = true;
            BTNregister.Visible = false;
            BTNlogin.Text = "Logout";
            BTNaccount.Text = user.Name;

            if (masterCon.isAdmin(user.Id))
            {
                BTNinventory.Visible = true;
            }
            else
            {
                BTNinventory.Visible = false;
            }
        }

        protected void BTNcart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCart.aspx");
        }

        protected void BTNinventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }

        protected void BTNlogin_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                string[] cookie = Request.Cookies.AllKeys;
                foreach (string coo in cookie)
                {
                    HttpCookie delCookie = Request.Cookies[coo];
                    delCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(delCookie);
                }

                Session.Remove("user");
            }

            Response.Redirect("Login.aspx");
        }

        protected void BTNregister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void BTNaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfo.aspx");
        }

        protected void BTNhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void BTNsearch_Click(object sender, EventArgs e)
        {
            string text = TBsearchBar.Text;
            if (masterCon.validateText(text))
            {
                Response.Redirect($"Home.aspx?text={text}");
            }
        }
    }
}