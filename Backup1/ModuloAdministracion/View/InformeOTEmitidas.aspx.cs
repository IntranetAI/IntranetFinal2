using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;

namespace Intranet.ModuloAdministracion.View
{
    public partial class InformeOTEmitidas : System.Web.UI.Page
    {
        Controller_OTEmitidas o = new Controller_OTEmitidas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            string Estado="";
            if (ddlEstado.SelectedValue.ToString() == "En Proceso")
            {
                Estado = "En Proceso";
            }
            else if (ddlEstado.SelectedValue.ToString() == "Liquidada")
            {
                Estado = "Liquidada";
            }
            else if (ddlEstado.SelectedValue.ToString() == "Anulada")
            {
                Estado = "Anulada";
            }
            else
            {
                Estado = "";
            }

            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                try
                {
                    RadGrid1.DataSource = o.ListarOTEmitidas(txtOT.Text, txtNombreOT.Text, txtCliente.Text, Estado, fi, ft, 1);
                    RadGrid1.DataBind();
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    RadGrid1.DataSource = o.ListarOTEmitidas(txtOT.Text, txtNombreOT.Text, txtCliente.Text, Estado, DateTime.Now, DateTime.Now, 0);
                    RadGrid1.DataBind();
                }
                catch
                {
                }
            }
        }
    }
}