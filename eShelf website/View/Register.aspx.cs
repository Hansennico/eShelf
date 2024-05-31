using eShelf_website.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShelf_website.View
{
    public partial class Register : System.Web.UI.Page
    {
        RegisterController regCon = new RegisterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LBerror.Visible = false;
            }
        }

        protected void BTNRegister_Click(object sender, EventArgs e)
        {
            string name = TBname.Text;
            string email = TBemail.Text;
            string password = TBpassword.Text;
            string confirm = TBconfirm.Text;
            bool tos = CBtos.Checked;

            if(!regCon.validateRegister(name, email, password, confirm, tos))
            {
                LBerror.Visible = true;
                LBerror.Text = "Invalid Credentials";
                TBname.Text = "";
                TBemail.Text = "";
                TBpassword.Text = "";
                TBconfirm.Text = "";
                return;
            }

            Session["user"] = regCon.getUser(email, password);
            Response.Redirect("~/View/AddressInfo.aspx");
        }

        protected void BTNtoLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }
    }
}