using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class SolicitudDimensionadoPapel : System.Web.UI.Page
    {
        Controller_Dimensionadora d = new Controller_Dimensionadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                int gramaje = 0; int ancho = 0; string Certi = "";
                if (txtGramaje.Text != "")
                {
                    gramaje = Convert.ToInt32(txtGramaje.Text);
                }
                if (txtAncho.Text != "")
                {
                    ancho = Convert.ToInt32(txtAncho.Text);
                }
                if (ddlCertificacion.SelectedValue.ToString() != "Seleccione...")
                {
                    Certi = ddlCertificacion.SelectedValue.ToString();
                }
                RadGrid1.DataSource = d.ListaStockDisponible(txtSku.Text, txtPapel.Text, gramaje, ancho, txtMarca.Text, Certi, 0);
                RadGrid1.DataBind();
            }
            catch
            {
            }
        }

    }
}