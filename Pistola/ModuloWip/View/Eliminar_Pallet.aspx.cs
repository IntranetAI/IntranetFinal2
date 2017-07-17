using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;

namespace Intranet.ModuloWip.View
{
    public partial class Eliminar_Pallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            if (Request.QueryString["id"] != "")
            {
                lblNombre.Text = Request.QueryString["id"];
                lblTipo.Text = Request.QueryString["Tipo"];
            }
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ddlMotivo.Focus();
            pnlDetalle.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Controller_Wip controlWip = new Controller_Wip();
            string Codigo = txtCodigo.Text;
            string Observacion = ddlMotivo.SelectedItem.ToString();
            string Usuario = lblNombre.Text;
            if (controlWip.EliminarPallet(Codigo, Observacion, Usuario))
            {
                Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }
    }
}