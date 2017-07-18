using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class DetalleInformeProductosTerminados : System.Web.UI.Page
    {
        Controller_Enc Enc = new Controller_Enc();
        protected void Page_Load(object sender, EventArgs e)
        {

                string p = Request.QueryString["p"];
                Label1.Text = Request.QueryString["ot"] + " - " + Request.QueryString["nOT"];
                DateTime fec = Convert.ToDateTime("01-01-1900");

                RadGrid3.DataSource = Enc.CargarAprobadosPT(Request.QueryString["ot"], "", fec, fec, 2);
                RadGrid3.DataBind();

                if (p == "1")
                {
                    btnImprimir.Visible = false;
                    btnCerrar.Visible = false;
                    string popupScript = "<script language='JavaScript'>window.print();</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
           
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'>window.close();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleInformeProductosTerminados.aspx?ot=" + Request.QueryString["ot"] + "&not=" + Request.QueryString["nOT"] + "&p=1");
        }

    }
}