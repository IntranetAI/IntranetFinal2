using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using Intranet.ModuloBodegaPliegos.Controller;
using Intranet.ModuloBodegaPliegos.Model;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class EtiquetaAtenderSolicitud : System.Web.UI.Page
    {
        Controller_BodegaPliegos bp = new Controller_BodegaPliegos();
        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo = Request.QueryString["cod"];
            lblOT.Text = Request.QueryString["ot"];
            lblNombreOT.Text = Request.QueryString["nomot"].ToUpper();
            lblCantidadAsignada.Text = Request.QueryString["solFL"];
            lblCantidadSolicitada.Text = Request.QueryString["solKG"];
            lblFormatoCorte.Text = Request.QueryString["formato"];
            lblFechaCreacion.Text = Request.QueryString["fecha"];
            lblCliente.Text = Request.QueryString["cliente"];
            lblComponente.Text = Request.QueryString["comp"];

            #region cargaCodigoBarra
            LabelKit.BarcodeGenerator code = new LabelKit.BarcodeGenerator();

            System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);

            g = Graphics.FromImage(bmp);

            code.DrawCode128(g, codigo.Trim(), 0, 0).Save(Server.MapPath("./barcodes/bc.png"), ImageFormat.Png);
            imgCodigo.ImageUrl = "./barcodes/bc.png";
            lblCodigo.Text = codigo;
#endregion

            BodegaPliegos bd = bp.CargaPapelSolicitado(codigo, 4);
            lblCodigoItem.Text = bd.CodigoProducto;
            lblPapel.Text = bd.Papel.ToUpper();
            lblMarca.Text = bd.Marca.ToUpper();
            lblCertificacion.Text = bd.Certificacion;
            lblGramaje.Text = bd.Gramaje;
            lblAncho.Text = bd.Ancho;
            lblLargo.Text = bd.Largo;
            lblAntiguedad.Text = bd.Antiguedad;


            //RadGrid1.DataSource = bp.CargaPapelSolicitud(codigo, 0);
            //RadGrid1.DataBind();

            RadGrid2.DataSource = bp.CargaPapelSolicitudDetalle(codigo, 1);
            RadGrid2.DataBind();

            int totalAsignado = bp.totalAsignado(lblOT.Text, lblComponente.Text, 0);
            lblAsignadoFL.Text = totalAsignado.ToString("N0").Replace(",", ".");
            lblSolicitadoFL.Text = Convert.ToInt32(Request.QueryString["solFL"]).ToString("N0").Replace(",", ".");
            lblSaldoFL.Text = (Convert.ToInt32(Request.QueryString["solFL"]) - totalAsignado).ToString("N0").Replace(",", ".");


            int FCA = Convert.ToInt32(bp.CargaFormatoCorte(codigo, "", 1));//formato corte ancho
            int FCL = Convert.ToInt32(bp.CargaFormatoCorte(codigo, "", 2));//formato corte Largo
            int Factor = Convert.ToInt32(bp.CargaFormatoCorte(codigo, "", 3));//formato Factor

            lblFCAncho.Text = FCA.ToString();
            lblFCLargo.Text = FCL.ToString();
            lblFactor.Text = Factor.ToString();
        }
    }
}