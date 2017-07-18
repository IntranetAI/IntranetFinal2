using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class AsignarBobinas : System.Web.UI.Page
    {
        Controller_BodegaPliegos bp = new Controller_BodegaPliegos();
        protected void Page_Load(object sender, EventArgs e)
        {
            string ot = Request.QueryString["ot"];
            string componente = Request.QueryString["componente"];
            string codigo = Request.QueryString["codproducto"];


            RadGrid1.DataSource = bp.BobinasMetrics(ot, componente, codigo, "", 0, 0, 1);
            RadGrid1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventarioMetricsBobina.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventarioMetricsBobina.aspx");
        }
    }
}