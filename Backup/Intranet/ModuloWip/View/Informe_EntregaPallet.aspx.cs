using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;

namespace Intranet.ModuloWip.View
{
    public partial class Informe_EntregaPallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGridInforme.DataSource = "";
                RadGridInforme.DataBind();
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtOT.Text.ToString().Trim() != "")
            {
                Controller_WipControl control_Wip = new Controller_WipControl();
                RadGridInforme.DataSource = control_Wip.ListarInformeEntregaPallet(txtOT.Text.ToString().Trim());
                RadGridInforme.DataBind();

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}