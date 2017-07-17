using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class DetallePliegos : System.Web.UI.Page
    {
        Partes p = new Partes();
        protected void Page_Load(object sender, EventArgs e)
        {
            string ot = Request.QueryString["ot"];
            string pl = Request.QueryString["pl"];
            lblTitulo.Text = "OT: " + ot + "  -   Pliego: " + pl;


            lblContenido.Text = p.Carga_Detalle_Pliego(ot, pl);
        }
    }
}