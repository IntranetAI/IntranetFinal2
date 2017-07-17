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
    public partial class AnularDevolucion : System.Web.UI.Page
    {
        Controller_Devoluciones des = new Controller_Devoluciones();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            Devoluciones dev = des.Buscar_Devolucion(txtFolio.Text, 0, "", "", 0);

                DivMensaje.Visible = false;
                lblOT.Text = dev.OT;

                if (lblOT.Text != "")
                {
                    lblid.Text = dev.id_Devolucion;
                    lblNombreOT.Text = dev.Producto;
                    lblCliente.Text = dev.Cliente;

                    lblTirajeOT.Text = Convert.ToInt32(dev.TirajeOT).ToString("N0").Replace(",", ".");

                    lblcanDevolucion.Text = Convert.ToInt32(dev.Total_Dev).ToString("N0").Replace(",", ".");

                    lblCausaDevolucion.Text = dev.CausaDevolucion;
                    lblObservacion.Text = dev.Observacion;
                    lblCreadaPor.Text = dev.CreadaPor;

                    if (dev.guia == "1")
                    {
                        lblEstadoDevolucion.Text = "<div style='color:Red;'>Creada</div>";
                    }
                    else if (dev.guia == "2")
                    {
                        lblEstadoDevolucion.Text = "<div style='color:Orange;'>Generada para Encuadernacion</div>";
                    }
                    else
                    {
                        lblEstadoDevolucion.Text = "<div style='color:Green;'>Recepcionada</div>";
                    }

                   
                    lblTipoDevolucion.Text = dev.sucursal;

                    txtFolio.Enabled = false;
                    btnFiltro.Enabled = false;

                    btnAnular.Enabled = true;
                    btnNuevo.Enabled = true;
            }
            else
            {
                DivMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "La Devolucion no ha sido encontrado.";
                lblMensaje.ForeColor = Color.White;
                DivMensaje.Attributes.Add("style", "background-color:Red");
            }
            
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            if (lblOT.Text != "" && txtDevolucion.Text != "")
            {
                bool resp = des.Anular_Devolucion("", Convert.ToInt32(lblid.Text), txtDevolucion.Text, Session["Usuario"].ToString(), 1);
                if (resp == true)
                {
                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.Text = "La Devolucion Anulada Correctamente.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Green");

                    btnAnular.Enabled = false;
                }
                else
                {
                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "Ha ocurrido un error, vuelva a intentarlo.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Red");
                }
            }
            else
            {
                DivMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "Debe ingresar Motivo de la devolucion para anularla.";
                lblMensaje.ForeColor = Color.White;
                DivMensaje.Attributes.Add("style", "background-color:Red");
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("anularDevolucion.aspx?id=8&Cat=6");
        }
    }
}