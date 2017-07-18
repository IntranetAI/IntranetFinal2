using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;
using System.Drawing;
using System.Drawing.Imaging;

namespace Intranet.ModuloWip.View
{
    public partial class Etiqueta_Wip2 : System.Web.UI.Page
    {
        Controller_WipControl wipControl = new Controller_WipControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Model_Wip_Control> lista = wipControl.BuscarWip_ControlPorCodigo2(Request.QueryString["cd"]);

            int contador = 0;
            string NombrePliego = "";
            int PliegosImpresos = 0;
            double PesoPallet = 0;
            foreach(Model_Wip_Control wip2 in lista)
            {
                if (contador == 0)
                {
                    lblOT.Text = wip2.OT.ToUpper();
                    lblNombreOT.Text = wip2.NombreOT;
                    lblFechaCreacion.Text = wip2.Fecha_Creacion.ToString("dd/MM/yyyy HH:mm:ss");
                    lblTiraje.Text = wip2.TotalTiraje.ToString("N0").Replace(',', '.');
                    lblCodigo.Text = wip2.ID_Control;
                    lblOperador.Text = wip2.Usuario;
                    lblMaquina.Text = wip2.Maquina;
                    lblDestino.Text = wip2.Ubicacion;
                    if (wip2.TipoPallet == "ESP")
                    {
                        lblTipoPallet.Text = "Pliego Normal";
                    }
                    else
                    {
                        lblTipoPallet.Text = "Pliego Especial";
                    }
                }
                NombrePliego += wip2.Pliego+",";
                PliegosImpresos += wip2.Pliegos_Impresos;
                PesoPallet += wip2.Peso_pallet;

            }
            lblPliego.Text = NombrePliego.Substring(0,NombrePliego.Length-1);
            lblPliegosImpresos.Text = PliegosImpresos.ToString("N0").Replace(',', '.');
            lblPesoPallet.Text = PesoPallet.ToString("N0").Replace(',', '.');
            LabelKit.BarcodeGenerator code = new LabelKit.BarcodeGenerator();

            System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);

            g = Graphics.FromImage(bmp);

            code.DrawCode128(g, lblCodigo.Text, 0, 0).Save(Server.MapPath("./barcodes/bc.png"), ImageFormat.Png);
            imgCodigo.ImageUrl = "./barcodes/bc.png";
        }
    }
}