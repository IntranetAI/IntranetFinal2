using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Controller;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class HPIndigo : System.Web.UI.Page
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
            Indigo_Controller controlHP = new Indigo_Controller();
            RadGridOT.DataSource = controlHP.ListIndigo();
            RadGridOT.DataBind();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}