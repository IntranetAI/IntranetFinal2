using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdmin.Controller;

namespace Intranet.ModuloAdmin.View
{
    public partial class Help_Desk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
            Help_Desk_Controller controlMesa = new Help_Desk_Controller();
            RadGridHelpDesk.DataSource = controlMesa.ListarMesaAyuda();
            RadGridHelpDesk.DataBind();
        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}