using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capthca
{
    public partial class ImageProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            ImageVerifier.ServiceClient imageService = new ImageVerifier.ServiceClient();
            string generated;
            if (Session["generated"] == null)
            {
                generated = imageService.GetVerifierString("6");
                Session["generated"] = generated;
            }
            else
            {
                generated = Session["generated"].ToString();
            }

            Stream myStream = imageService.GetImage(generated);
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
            Response.ContentType = "image/jpeg";
            myImage.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}