using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class AtenderSolicitudPesa : System.Web.UI.Page
    {
        Controller_Cortadora cc = new Controller_Cortadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            RadGrid1.DataSource = cc.CargaPendientesPesa();
            RadGrid1.DataBind();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }
    }
}