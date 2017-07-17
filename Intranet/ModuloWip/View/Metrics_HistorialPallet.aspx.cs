using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;

namespace Intranet.ModuloWip.View
{
    public partial class Metrics_HistorialPallet : System.Web.UI.Page
    {
        Controller_MetricsWIP mw = new Controller_MetricsWIP();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Model_MetricsWIP w = mw.Lista_Encabezado_HistorialPallet(Request.QueryString["idP"], "", "", DateTime.Now, DateTime.Now, "0", 1);
                    lblEncabezado.Text = "<div style='font-size:17px;'><b>" + w.OT + " - " + w.NombreOT + "</b></div>" +
                                    "<div style='font-size:13px;'>" + w.Pliego + "</div>";
                    RadGridOT.DataSource = mw.listar_HistorialPallet(Request.QueryString["idP"], "", "", DateTime.Now, DateTime.Now, "0", 2);
                    RadGridOT.DataBind();
                }
                catch
                {
                    lblEncabezado.Text = "<div style='font-size:25px;'><b>Ha ocurrido un error, vuelve a intentarlo</b></div>";
                }
            }
        }
    }
}