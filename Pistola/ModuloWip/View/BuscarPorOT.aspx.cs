using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloWip.View
{
    public partial class BuscarPorOT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != "")
            {
                lblNombre.Text = Request.QueryString["id"];
                lblTipo.Text = Request.QueryString["Tipo"];
            }
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }
    }
}