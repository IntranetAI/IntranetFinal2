using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;
using System.Drawing;
using System.Drawing.Imaging;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class EtiquetaProductoEnProceso : System.Web.UI.Page
    {
        Controller_BodegaPliegos bp = new Controller_BodegaPliegos();
        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo = Request.QueryString["cod"];
            lblOT.Text = Request.QueryString["ot"];
            lblNombreOT.Text = Request.QueryString["nomot"].ToLower();
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

            RadGrid1.DataSource = bp.CargaPapelSolicitud(codigo, 2);
            RadGrid1.DataBind();

            RadGrid2.DataSource = bp.CargaPapelSolicitudDetalle(codigo, 3);
            RadGrid2.DataBind();

            int totalAsignado = bp.totalAsignado(lblOT.Text, lblComponente.Text, 0);
            lblAsignadoFL.Text = totalAsignado.ToString("N0").Replace(",", ".");
            lblSolicitadoFL.Text = Convert.ToInt32(Request.QueryString["solFL"]).ToString("N0").Replace(",", ".");
            lblSaldoFL.Text = (Convert.ToInt32(Request.QueryString["solFL"]) - totalAsignado).ToString("N0").Replace(",", ".");


            int FCA = 0;
            int FCL = 0;
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                FCA = Convert.ToInt32(RadGrid1.Items[i]["FCAncho"].Text);
                FCL = Convert.ToInt32(RadGrid1.Items[i]["FCLargo"].Text);
            }
            lblFCAncho.Text = FCA.ToString();
            lblFCLargo.Text = FCL.ToString();
        }
    }
}