using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.View
{
    public partial class DetalleDevolucion : System.Web.UI.Page
    {
        Controller_Devoluciones des = new Controller_Devoluciones();
        protected void Page_Load(object sender, EventArgs e)
        {





            string codigo = Request.QueryString["Cod"];

            Devoluciones d = des.ListaDevoluciones(codigo);
            lblOT.Text = d.OT.ToUpper();
            lblCliente.Text = d.Cliente;
            lblProducto.Text = d.Producto;
            lblCausa.Text = d.CausaDevolucion;
            lblObservacion.Text = d.Observacion;

            int can = Convert.ToInt32(d.Total_Dev);
            lblCantidad.Text = can.ToString("N0").Replace(",", ".");

            int tir = Convert.ToInt32(d.TirajeOT);
            lblTirajeOT.Text = tir.ToString("N0").Replace(",", ".");




            RadGrid1.DataSource = des.ListaGuias(Convert.ToInt32(d.id_Guias));
            RadGrid1.DataBind();


            RadGrid2.DataSource = des.ListasTipos(Convert.ToInt32(d.id_TipoDev));
            RadGrid2.DataBind();

            //lblPallet.Text = codigo;

            //// lblUsuario.Text = Session["Usuario"].ToString();

            //lblUsuario.Text = cPT.ValidadoPor(codigo);


            //lblFechaCreacion.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            //RadGrid1.DataSource = cPT.BuscaPalletDespachoImpresion(codigo);
            //RadGrid1.DataBind();


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