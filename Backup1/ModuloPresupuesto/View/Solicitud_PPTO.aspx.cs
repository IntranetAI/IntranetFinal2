using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace Intranet.ModuloPresupuesto.View
{
    public partial class Solicitud_PPTO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Sol_PPTO.aspx");
        }

    }
}