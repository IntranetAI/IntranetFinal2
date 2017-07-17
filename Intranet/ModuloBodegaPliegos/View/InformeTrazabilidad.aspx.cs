using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class InformeTrazabilidad : System.Web.UI.Page
    {
        Controller_Dimensionadora c = new Controller_Dimensionadora();
        Controller_Devoluciones d = new Controller_Devoluciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }

        }

        protected void txtOT_TextChanged(object sender, EventArgs e)
        {
            if (txtOT.Text != "")
            {
                try
                {
                    ddlComponente.DataSource = c.ListaComponenteOT(txtOT.Text, "", 1);
                    ddlComponente.DataTextField = "Componente";
                    ddlComponente.DataValueField = "Componente";
                    ddlComponente.DataBind();
                    ddlComponente.Items.Insert(0, new ListItem("Seleccione..."));
                }
                catch
                { 
                }
            }

        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                RadGrid1.DataSource = d.CargaInformeTrazabilidad(txtOT.Text, ddlComponente.SelectedValue.ToString(), "", 0);
                RadGrid1.DataBind();
            }
            catch
            {
            }
        }
    }
}