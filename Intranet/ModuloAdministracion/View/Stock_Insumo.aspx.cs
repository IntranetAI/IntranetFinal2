using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Stock_Insumo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGridInsumo.DataSource = "";
                RadGridInsumo.DataBind();
            }
        }

        public void CargarDatos()
        {
            Controller_Consumo controlConsumo = new Controller_Consumo();
            string codigo = txtCodItem.Text;
            string Descripcion = txtDescrip.Text;
            string Grupo = txtGrupo.Text;
            RadGridInsumo.DataSource = controlConsumo.ListarStockInsumo(codigo,Descripcion,Grupo);
            RadGridInsumo.DataBind();

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}