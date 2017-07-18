using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;
using System.Drawing;

namespace Intranet.ModuloDespacho.View
{
    public partial class RechazarRecepcion : System.Web.UI.Page
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
        }


        protected void btnRechazar_Click1(object sender, EventArgs e)
        {
            if (txtDecripcion.Text != "")
            {
                bool r = des.RecepcionEnc(Request.QueryString["Cod"], Request.QueryString["Usu"], txtDecripcion.Text, 2);
                if (r == true)
                {
                    divMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.Text = "Devolución Rechazada Correctamente.";
                    lblMensaje.ForeColor = Color.White;
                    divMensaje.Attributes.Add("style", "background-color:Green");
                    btnCancelar.Text = "Salir";
                }
                else
                {
                    //error
                } 
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> window.close(); </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }



    }
}