using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;
using Intranet.ModuloBodegaPliegos.Model;
using System.Drawing;
using System.Drawing.Imaging;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class EtiquetaBP : System.Web.UI.Page
    {
        Controller_Cortadora c = new Controller_Cortadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string folio = Request.QueryString["Folio"];
                int proc = Convert.ToInt32(Request.QueryString["Pro"]);
                BodegaPliegos b = c.CargaEtiquetaBP(folio, proc);
                lblOT.Text = b.OT;
                lblNombreOT.Text = b.NombreOT.ToUpper();
                lblComponente.Text = b.Componente;
                lblSKU.Text = b.CodigoProducto;
                lblPapel.Text = b.Papel.ToUpper();
                lblGramaje.Text = b.Gramaje;
                lblAncho.Text = b.FCAncho;
                lblLargo.Text = b.FCLargo;
                lblFormatoAnterior.Text = b.Ancho + "x" + b.Largo;
                lblCantidadPliegos.Text = b.SolicitadoFL;
                lblPesoPallet.Text = b.SolicitadoKG;
                lblOperador.Text = b.Seleccionar.ToUpper();
                lblFechaCreacion.Text = b.FechaCreacion;
                LabelKit.BarcodeGenerator code = new LabelKit.BarcodeGenerator();
                System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);
                g = Graphics.FromImage(bmp);
                code.DrawCode128(g, folio.Trim(), 0, 0).Save(Server.MapPath("./barcodes/bc.png"), ImageFormat.Png);
                imgCodigo.ImageUrl = "./barcodes/bc.png";
                lblCodigo.Text = folio;
            }
            catch
            {
            }
        }
    }
}