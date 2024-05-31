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
    public partial class AddressInfo : System.Web.UI.Page
    {
        AddressInfoController AIcon = new AddressInfoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("~/View/Register.aspx");
                }
                else
                {
                    LBerror.Visible = false;
                    addCountryItem();
                }

            }

        }

        protected void BTNsave_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            string phone = TBphone.Text;
            string address = TBaddress.Text;
            string postal = TBpostal.Text;
            string country = DDLcountry.SelectedItem.ToString();
            string state = TBstate.Text;
            string city = TBcity.Text;

            if(!AIcon.validateAddressInfo(phone, address, postal, country, state, city, user))
            {
                LBerror.Visible = true;
                LBerror.Text = "Please fill valid information";
                return;
                
            }
            Response.Redirect("~/View/Home.aspx");

        }

        protected void BTNskip_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        private void addCountryItem()
        {
            List<Country> countries = AIcon.getCountryList();
            foreach(var c in countries)
            {
                DDLcountry.Items.Add(new ListItem(c.getName(), c.getCode()));
            }
        }
    }
}