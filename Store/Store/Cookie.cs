using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store
{
    public class Cookie
    {
        public static HttpCookie setCookie(User user)
        {
            HttpCookie cookie = new HttpCookie("Auth");
            cookie["username"] = user.name;
            cookie["password"] = Encryption.EncryptionDecryption.encrypt(user.pass);
            cookie["isMember"] = user.isMember? "Y" : "F";
            cookie.Expires = DateTime.Now.AddMonths(1);
            return cookie;
        }

        public static User getUsetFromCookie(HttpCookie cookie)
        {
            User user = new User();
            user.name = cookie["username"];
            user.pass = Encryption.EncryptionDecryption.decrypt(cookie["password"]);
            user.isMember = cookie["isMember"].Equals("Y") ? true : false;
            return user;
        }
    }
}