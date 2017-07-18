using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloDespacho.Controller;
using System.Drawing;
using System.Drawing.Imaging;

namespace Intranet.ModuloDespacho.View
{
    public partial class DetalleOTComercial : System.Web.UI.Page
    {
        Controller_OTComercial des = new Controller_OTComercial();
        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo = Request.QueryString["Cod"];

            OTComercial d = des.Cargar_OTComercial(codigo, "", "", 0, 0, 0, "", "", "", 3);
            lblOT.Text = d.OT.ToUpper();
            lblProducto.Text = d.NombreOT;
            lblTirajeOT.Text = d.TirajeOT;
            lblCantidad.Text = d.CantidadEnviada;
            lblPeso.Text = d.Peso;
            lblObservacion.Text = d.Descripcion;

            if (d.Estado == "1")
            {
                lblCreadaPor.Text = "Material Enviado Por: " + d.EnviadaPor + "  " + Convert.ToDateTime(d.FechaEnvio).ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                string n = "Material Enviado Por: " + d.EnviadaPor + "  " + Convert.ToDateTime(d.FechaEnvio).ToString("dd/MM/yyyy HH:mm") + "@";
                
                n += "Material Recibido Por: " + d.RecepcionadoPor + "  " + Convert.ToDateTime(d.FechaRecepcion).ToString("dd/MM/yyyy HH:mm");
                lblCreadaPor.Text = n;
            }


            lblFolio.Text = d.Folio;



            LabelKit.BarcodeGenerator code = new LabelKit.BarcodeGenerator();

            System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);

            g = Graphics.FromImage(bmp);
            lblFolio.Text = d.Folio;
            code.DrawCode128(g, codigo, 0, 0).Save(Server.MapPath("./barcodes/bc.png"), ImageFormat.Png);
            imgCodigo.ImageUrl = "./barcodes/bc.png";
        }
    }
}