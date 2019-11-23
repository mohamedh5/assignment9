using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Store
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["Auth"];
            if (cookie == null)
                return;
            User user = Cookie.getUsetFromCookie(cookie);
            if(user.isMember)
                Response.Redirect("~/Member.aspx");
            else
                Response.Redirect("~/Staff.aspx");
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string pass = txt_pass.Text;

            if(name.Equals("") || pass.Equals(""))
            {
                error.InnerText = "Invalid username or password";
                return;
            }
            pass = Encryption.EncryptionDecryption.encrypt(pass);
            string userData = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");
            bool found = false;
            XDocument xdoc = XDocument.Load(userData);

            foreach (XElement usr in xdoc.Descendants("user"))
            {
                //if node containing username matches the password return authentication match
                if (usr.Element("username").Value == name)
                {
                    if (usr.Element("password").Value == pass)
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                error.InnerText = "Invalid username or password";
                return;
            }
            Response.Redirect("~/Member.aspx");
        }
    }
}