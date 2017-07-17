using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class EstadisticaPartesManualesDiario : System.Web.UI.Page
    {
        Controller_PartesManuales pp = new Controller_PartesManuales();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaInicio.Text = "01/03/2015";
                txtFechaTermino.Text = "31/03/2015";

                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                RadGrid2.DataSource = "";
                RadGrid2.DataBind();
                RadGrid3.DataSource = "";
                RadGrid3.DataBind();
                RadGrid4.DataSource = "";
                RadGrid4.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                //Web2
                RadGrid1.DataSource = pp.Lista_Resumen_PartesManualesDiario("M2016", fi, ft, 0);
                RadGrid1.DataBind();

                //C150  GOSS
                RadGrid2.DataSource = pp.Lista_Resumen_PartesManualesDiario("C150", fi, ft, 0);
                RadGrid2.DataBind();
                //SHCD cd
                RadGrid3.DataSource = pp.Lista_Resumen_PartesManualesDiario("SHCD", fi, ft, 0);
                RadGrid3.DataBind();
                //SH402 4p
                RadGrid4.DataSource = pp.Lista_Resumen_PartesManualesDiario("SH402", fi, ft, 0);
                RadGrid4.DataBind();

            }
        }
    }
}