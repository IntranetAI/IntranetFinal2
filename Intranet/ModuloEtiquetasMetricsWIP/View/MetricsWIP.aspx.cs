using Intranet.ModuloEtiquetasMetricsWIP.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloEtiquetasMetricsWIP.View
{
    public partial class MetricsWIP : System.Web.UI.Page
    {
        EtiquetasController ec = new EtiquetasController();
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {
            lblTabla.Text = ec.ResultadoFiltro("113858","", "KBA", 0);
        }
    }
}