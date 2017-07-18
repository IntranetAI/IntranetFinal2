using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class DetallePapel : System.Web.UI.Page
    {
        SeguimientoController sc = new SeguimientoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = sc.Carga_PapelesOT(Request.QueryString["ot"]);
        }
    }
}