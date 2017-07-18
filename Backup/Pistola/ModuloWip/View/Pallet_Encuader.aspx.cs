using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Model;
using Intranet.ModuloWip.Controller;
using System.Drawing;

namespace Intranet.ModuloWip.View
{
    public partial class Pallet_Encuader : System.Web.UI.Page
    {
        Controller_Wip wipControl = new Controller_Wip();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCodigo.Focus();
            }
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            Wip wip = wipControl.BuscarWip_ControlPorCodigo(codigo, "Pistola", Session["Usuario"].ToString());

            if (wip.ProxProceso != null)
            {
                lblOT.Text = wip.OT;
                lblNombreOT.Text = wip.NombreOT;
                btnGuardar.Visible = true;
                pnlDetalle.Visible = true;
                DivMensaje.Visible = false;
            }
            else
            {
                DivMensaje.Visible = true;
                DivMensaje.Attributes.Add("style", "background-color:Red");
                Image1.ImageUrl = "../../Images/cross.png";
                lblMensaje.ForeColor = Color.White;
                lblMensaje.Text = "Codigo de Pallet Incorrecto.";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Codigo = txtCodigo.Text.Trim();
            string Maquina = txtMaquina.Text.Trim();
            //if ("Producto Terminados" != lblAct.Text)
            //{
            //    Maquina = ddlMaquina.SelectedItem.Text;
            //}
            //else
            //{
            //    Maquina = ddlMachine.SelectedItem.Text;
            //}

            //if (wipControl.ConsumirPorMaquina(Codigo, Maquina, Session["Usuario"].ToString()))
            //{
            //    btnNuevo.Visible = true;
            //    btnGuardar.Visible = false;
            //    DivMensaje.Visible = false;
            //}
            //else
            //{
            //    DivMensaje.Visible = true;
            //    DivMensaje.Attributes.Add("style", "background-color:Red");
            //    Image1.ImageUrl = "../../Images/cross.png";
            //    lblMensaje.ForeColor = Color.White;
            //    lblMensaje.Text = "Error al Conectar al Servidor.";
            //}
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consumir_Pallet.aspx");
        }


    }
}