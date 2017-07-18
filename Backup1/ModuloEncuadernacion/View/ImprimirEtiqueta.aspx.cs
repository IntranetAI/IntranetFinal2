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
    public partial class ImprimirEtiqueta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label2.Text = Request.QueryString["op"];
            //Label4.Text = Request.QueryString["cod"];
            
            Controller_Enc Enc = new Controller_Enc();
            Productos pro = Enc.ImprimirEtiqueta(Request.QueryString["cod"], Request.QueryString["op"]);

            if (pro.Codigo != "")
            {
               
                lblOP.Text = pro.OP;
                lblNombreOP.Text = pro.NombreOP;
                lblTerminacion.Text = pro.Terminacion;
                lblEmbalaje.Text = pro.TipoEmbalaje;
                //cambio formato
                int cant = Convert.ToInt32(pro.Cantidad);
                lblCantidad.Text = cant.ToString("N0");//pro.Cantidad;
                //
                int ejemp = Convert.ToInt32(pro.Ejemplares);
                lblEjemplares.Text = ejemp.ToString("N0");//pro.Ejemplares;
                //
                int tot = Convert.ToInt32(pro.Total);
                lblTotal.Text = tot.ToString("N0");//pro.Total;
                
                //codigo
                DateTime fec = Convert.ToDateTime(pro.FechaCreacion);
                lblFechaCreacion.Text = fec.ToString("dd/MM/yyyy HH:mm");

                lblCliente.Text = pro.Cliente;
                int tir = Convert.ToInt32(pro.Tiraje);
                lblTiraje.Text = tir.ToString("N0");//pro.Tiraje;
                lblOperador.Text = pro.Operador;
                lblMaquina.Text = pro.Maquina;
                lblProceso.Text = pro.Proceso;

            }
            LabelKit.BarcodeGenerator code = new LabelKit.BarcodeGenerator();

            System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);

            g = Graphics.FromImage(bmp);

            code.DrawCode128(g, pro.Codigo, 0, 0).Save(Server.MapPath("./barcodes/bc.png"), ImageFormat.Png);
            imgCodigo.ImageUrl = "./barcodes/bc.png";
            lblCodigo.Text = pro.Codigo;
       //     btnGuardar.Visible = true;
        }
    }
}