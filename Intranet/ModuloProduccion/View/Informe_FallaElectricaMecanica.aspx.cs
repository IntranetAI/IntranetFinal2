using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class Informe_FallaElectricaMecanica : System.Web.UI.Page
    {
        InformeImproductivo_Controller i = new InformeImproductivo_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                if (ddlSeccion.SelectedValue.ToString() != "Seleccione...")
                {
                    if (ddlSeccion.SelectedValue.ToString().ToLower().Trim() == "c150" || ddlSeccion.SelectedValue.ToString().ToLower().Trim() == "m2016")
                    {
                        RadGrid1.DataSource = i.InformeImproductivo_ElectricayMecanica(ddlSeccion.SelectedValue.ToString(), fi, ft, 1);
                    }
                    else
                    {
                        RadGrid1.DataSource = i.InformeImproductivo_ElectricayMecanica(ddlSeccion.SelectedValue.ToString(), fi, ft, 0);
                    }
                    RadGrid1.DataBind();
                }
            }
            else
            {
            }
        }
    }
}