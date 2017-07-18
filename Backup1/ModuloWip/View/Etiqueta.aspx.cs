using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using Intranet.ModuloWip.Model;
using Intranet.ModuloWip.Controller;

namespace Intranet.ModuloWip.View
{
    public partial class Etiqueta : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelKit.BarcodeGenerator code = new LabelKit.BarcodeGenerator();

            System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);

            g = Graphics.FromImage(bmp);
            Label2.Text = "POLAR-BI";
            code.DrawCode128(g, Label2.Text, 0, 0).Save(Server.MapPath("./barcodes/bc.png"), ImageFormat.Png);
            Image1.ImageUrl = "./barcodes/bc.png";
        }

        

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}