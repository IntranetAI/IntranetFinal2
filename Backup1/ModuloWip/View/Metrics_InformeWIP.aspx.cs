using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;

namespace Intranet.ModuloWip.View
{
    public partial class Metrics_InformeWIP : System.Web.UI.Page
    {
        Controller_MetricsWIP mw = new Controller_MetricsWIP();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGridOT.DataSource = "";
                RadGridOT.DataBind();
                Controller_MetricsWIP mw = new Controller_MetricsWIP();
                ddlBodegas.DataSource = mw.listar_BodegasWip("", "", "", DateTime.Now, DateTime.Now, "", -2);
                ddlBodegas.DataTextField = "Posicion";
                ddlBodegas.DataValueField = "Ubicacion";
                ddlBodegas.DataBind();
                ddlBodegas.Items.Insert(0, new ListItem("Todos", "Todos"));

            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOT.Text != "")
                {
                    RadGridOT.DataSource = mw.Lista_InformeMetricsWIP(txtOT.Text, ddlPliegos.SelectedValue.ToString().Replace("Todos", ""), ddlBodegas.SelectedValue.ToString().Replace("Todos", ""), DateTime.Now, DateTime.Now, ddlEstado.SelectedValue.ToString().Replace("0", ""), -1);
                    RadGridOT.DataBind();
                }
                else if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");

                    RadGridOT.DataSource = mw.Lista_InformeMetricsWIP(txtOT.Text, ddlPliegos.SelectedValue.ToString().Replace("Todos", ""), ddlBodegas.SelectedValue.ToString().Replace("Todos", ""), fi, ft, ddlEstado.SelectedValue.ToString().Replace("0", ""), 0);
                    RadGridOT.DataBind();
                }
                else
                {
                }
            }
            catch
            {
            }
        }

        protected void txtOT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOT.Text != "")
                {
                    Controller_MetricsWIP mw = new Controller_MetricsWIP();
                    ddlPliegos.DataSource = mw.listar_PliegosOT(txtOT.Text.Trim(), "", "", DateTime.Now, DateTime.Now, "", 3);
                    ddlPliegos.DataTextField = "Pliego";
                    ddlPliegos.DataValueField = "Pliego";
                    ddlPliegos.DataBind();
                    ddlPliegos.Items.Insert(0, new ListItem("Todos", "Todos"));
                }
                else
                {
                    ddlPliegos.ClearSelection();
                }
            }
            catch
            {
            }
        }
    }
}