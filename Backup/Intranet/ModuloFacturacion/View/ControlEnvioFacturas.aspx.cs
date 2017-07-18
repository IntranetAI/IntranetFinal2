using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloFacturacion.Controller;

namespace Intranet.ModuloFacturacion.View
{
    public partial class ControlEnvioFacturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargardatos();
            }
        }

        public void Cargardatos()
        {
            Controller_Facturacion controlfact = new Controller_Facturacion();
            RadGrid1.DataSource = controlfact.listarFacturasPendientes().OrderBy(o => o.Nfactura);
            RadGrid1.DataBind();
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {

        }
    }
}