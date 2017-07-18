using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class DetalleInformeProduccion : System.Web.UI.Page
    {
        InformeProduccion_Controller ip = new InformeProduccion_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ot = Request.QueryString["ot"];
                string Pliego = Request.QueryString["pli"];
                string NombreOT = Request.QueryString["nOT"];
                string pliego2 = Request.QueryString["pliego"];

                Label1.Text = "OT: " + ot + " - " + NombreOT + "<br/>" + "Pliego: " + pliego2;

                lblPliego.Text = ip.DetalleInformeProduccion_PliegoTabla_V2(ot, Pliego, "Pliego", 0);//7
                lbDetalle.Text = ip.DetalleInformeProduccion_PliegoTabla_V2(ot, Pliego, "Impresion", 1); //ip.DetalleInformeProduccion_OT(ot, 8);//8
                lblDetalleENC.Text = ip.DetalleInformeProduccion_PliegoTabla_V2(ot, Pliego, "Encuadernacion", 2);
                //ip.DetalleInformeProduccion_PliegoTabla_V2(ot, Pliego, "", 1);
            }
            catch (Exception ee)
            {
                string popupScript = "<script language='JavaScript'> alert(" + ee.ToString() + "); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }
    }
}