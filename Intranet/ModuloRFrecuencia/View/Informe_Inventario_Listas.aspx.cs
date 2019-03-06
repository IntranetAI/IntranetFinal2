using Intranet.ModuloBobina.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Informe_Inventario_Listas : System.Web.UI.Page
    {
        InventarioController ic = new InventarioController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = ic.Listado_Inventarios();
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtIdLista.Text != "")
            {
                try
                {
                    if (ic.EliminaInventario(Convert.ToInt32(txtIdLista.Text)) != "Error")
                    {
                        Response.Redirect("Informe_Inventario_Listas.aspx");
                    }
                }catch(Exception ex)
                {

                }
            }
        }
    }
}