using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace Project5
{
    public class Authentication
    {
        /*authentification function*/
        private bool Authenticate(string username, string password)
        {
            string ret = "0";
            try
            {
                string userData = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");

                XDocument xdoc = XDocument.Load(userData);
                //iterate through each user in the userData
                foreach (XElement usr in xdoc.Descendants("user"))
                {
                    //if node containing username matches the password return authentication match
                    if (usr.Element("username").Value == username)
                    {
                        if (usr.Element("password").Value == password)
                        {
                            ret = "Authenticated";
                        }
                        else
                        {
                            ret = "Incorrect Password";
                        }
                    }
                }
                if (ret == "0")
                {
                    ret = string.Format("user {0} not found", username); //user name is not found if code reaches this point
                }

            }
            catch (Exception ex)
            {
                string err = string.Format("```error: user data could not be found\n current directory: {0} ex: {1}", "", ex);
                ret = err;
            }


            if (ret == "Authenticated")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}