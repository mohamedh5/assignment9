using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capthca
{
    public partial class captcha : System.Web.UI.UserControl
    {
        ImageVerifier.ServiceClient imageVerifier = new ImageVerifier.ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/ImageProcess.aspx";
        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            string generated = imageVerifier.GetVerifierString("6");
            Session["generated"] = generated;
            Image1.Visible = true;
            btn_show.Text = "retry";
        }
    }
}