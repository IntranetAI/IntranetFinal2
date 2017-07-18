using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Intranet.ModuloBodegaPliegos.Model;
using Intranet.ModuloBodegaPliegos.Controller;
using Intranet.ModuloWip.Model;
using Intranet.ModuloWip.Controller;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class Asignar_Ubicacion : System.Web.UI.Page
    {
        Controller_BodegaPliegos bp = new Controller_BodegaPliegos();
        Controller_Wip wipControl = new Controller_Wip();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCodigo.Focus();
                if (Request.QueryString["id"] != "")
                {
                    lblNombre.Text = Request.QueryString["id"];
                    lblTipo.Text = Request.QueryString["Tipo"];
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Codigo = txtCodigo.Text;
            string Ubicacion = txtUbicacion.Text;

            if (bp.VerificaPosicion("", "", Ubicacion, 0, 2))
            {
                if (bp.AsignarUbicacionPallet(Codigo, lblNombre.Text, Ubicacion, 0, 1))
                {
                    Response.Redirect("../../ModuloBodegaPliegos/View/Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
                }
            }
            else
            {
                btnGuardar.Visible = false;
                pnlDetalle.Visible = false;
                DivMensaje.Visible = true;
                DivMensaje.Attributes.Add("style", "background-color:Red");
                Image1.ImageUrl = "../../Images/cross.png";
                lblMensaje.ForeColor = Color.White;
                lblMensaje.Text = "Codigo de Ubicacion Incorrecto.";
                txtCodigo.Text = "";
                txtUbicacion.Text = "";
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asignar_Ubicacion.aspx?id=" + Request.QueryString["id"] + "&tipo=" + lblTipo.Text);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../ModuloWip/View/Menu.aspx?id=" + Request.QueryString["id"] + "&tipo=" + lblTipo.Text);
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            BodegaPliegos b = bp.BuscarBP_PorCodigo(codigo, "", "", 0, 0);
            if (b.OT != null)
            {
                DivMensaje.Visible = false;
                lblOT.Text = b.OT;
                lblNombreOT.Text = b.NombreOT;
                lblPapel.Text = b.Papel;
                lblCantidad.Text = b.Cantidad;
                if (b.UbicacionActual == "")
                {
                    lblUbicacion.Text = "Sin Ubicación";
                    btnGuardar.Visible = true;
                    pnlDetalle.Visible = true;
                    DivMensaje.Visible = false;
                    Label7.Visible = true;
                    txtUbicacion.Visible = true;
                    txtUbicacion.Focus();
                    btnNuevo.Visible = false;
                }
                else
                {
                    lblUbicacion.Text = b.UbicacionActual;
                    btnGuardar.Visible = false;
                    pnlDetalle.Visible = true;
                    btnNuevo.Visible = true;
                    DivMensaje.Visible = false;
                    Label7.Visible = false;
                    txtUbicacion.Visible = false;
                }

            }
            else
            {
                btnGuardar.Visible = false;
                pnlDetalle.Visible = false;
                DivMensaje.Visible = true;
                DivMensaje.Attributes.Add("style", "background-color:Red");
                Image1.ImageUrl = "../../Images/cross.png";
                lblMensaje.ForeColor = Color.White;
                lblMensaje.Text = "Codigo de Pallet Incorrecto.";
            }
        }
    }
}