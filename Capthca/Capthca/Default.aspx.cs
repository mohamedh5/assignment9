using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capthca
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sumbit_Click(object sender, EventArgs e)
        {
            if (!Session["generated"].Equals(toBeVerified))
            {
                Console.WriteLine("Invalid");
            }
            Console.WriteLine("valid");
        }
    }
}