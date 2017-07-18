using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class ConsultaStock : System.Web.UI.Page
    {
        Controller_Informes ci = new Controller_Informes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = ci.InformeStock(txtSku.Text, txtPapel.Text, 0, 0, 0, txtMarca.Text, "", 1);
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            int gram = 0;
            int anch = 0;
            int larg = 0;
            string cert = "";
 
                if (txtGramaje.Text != "")
                {
                    gram = Convert.ToInt32(txtGramaje.Text);
                }
                if (txtAncho.Text != "")
                {
                    anch = Convert.ToInt32(txtAncho.Text);
                }
                if (txtLargo.Text != "")
                {
                    larg = Convert.ToInt32(txtLargo.Text);
                }
                if (ddlCertificacion.SelectedValue.ToString() != "Seleccione...") 
                {
                    cert = ddlCertificacion.SelectedValue.ToString();
                }
                RadGrid1.DataSource = ci.InformeStock(txtSku.Text, txtPapel.Text, gram, anch, larg, txtMarca.Text,cert, 0);
                RadGrid1.DataBind();

        }
    }
}