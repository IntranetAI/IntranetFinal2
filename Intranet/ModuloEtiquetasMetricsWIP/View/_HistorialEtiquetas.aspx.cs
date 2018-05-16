using Intranet.ModuloEtiquetasMetricsWIP.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloEtiquetasMetricsWIP.View
{
    public partial class _HistorialEtiquetas : System.Web.UI.Page
    {
        EtiquetasController ec = new EtiquetasController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ot = Request.QueryString["ot"];
                string pliego = Request.QueryString["pl"];
                string nOT= Request.QueryString["not"];

                lblOT.Text = ot;
                lblNombreOT.Text = nOT;
                lblPliego.Text = pliego;
                lblTabla.Text = ec.HistorialEtiquetas(ot, pliego);
            }
        }
    }
}