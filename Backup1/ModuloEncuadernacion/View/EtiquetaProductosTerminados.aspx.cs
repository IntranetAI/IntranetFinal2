using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Model;
using Intranet.ModuloEncuadernacion.Controller;
using System.Drawing;
using System.Drawing.Imaging;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class EtiquetaProductosTerminados : System.Web.UI.Page
    {
        Controller_ProductosTerminados cPT = new Controller_ProductosTerminados();
        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo=Request.QueryString["Cod"];
            lblPallet.Text = codigo;

            RadGrid1.DataSource = cPT.BuscaPalletCerrado(codigo);
            RadGrid1.DataBind();


            LabelKit.BarcodeGenerator code = new LabelKit.BarcodeGenerator();

            System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);

            g = Graphics.FromImage(bmp);

            code.DrawCode128(g,codigo , 0, 0).Save(Server.MapPath("./barcodes/bc.png"), ImageFormat.Png);
            imgCodigo.ImageUrl = "./barcodes/bc.png";
            lblCodigo.Text = codigo;
        }
    }
}