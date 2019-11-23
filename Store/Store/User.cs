using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store
{
    public class User
    {
        public User() { }
        public User(string name, string pass)
        {
            this.name = name;
            this.pass = pass;
            this.isMember = true;
        }
        public string name { get; set; }
        public string pass { get; set; }
        public bool isMember { get; set; }

    }
}