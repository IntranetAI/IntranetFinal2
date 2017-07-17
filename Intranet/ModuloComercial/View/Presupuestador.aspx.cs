using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloComercial.Controller;
using System.Web.Services;
using Intranet.ModuloComercial.Model;

namespace Intranet.ModuloComercial.View
{
    public partial class Presupuestador : System.Web.UI.Page
    {
        Presupuesto_Controller pc = new Presupuesto_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTipoProducto.DataSource = pc.Lista_Producto(0);
                ddlTipoProducto.DataTextField = "Producto";
                ddlTipoProducto.DataValueField = "Producto";
                ddlTipoProducto.DataBind();

                txtTiraje.Text = "32";

                ddlFormatoAbierto.DataSource = pc.Lista_FormatoAbierto(1);
                ddlFormatoAbierto.DataTextField = "FormatoAbierto";
                ddlFormatoAbierto.DataValueField = "FormatoAbierto";
                ddlFormatoAbierto.DataBind();
                ddlFormatoAbierto.SelectedValue = "210x297";

                ddlFormatoCerrado.DataSource = pc.Lista_FormatoAbierto(1);
                ddlFormatoCerrado.DataTextField = "FormatoAbierto";
                ddlFormatoCerrado.DataValueField = "FormatoAbierto";
                ddlFormatoCerrado.DataBind();
                ddlFormatoCerrado.SelectedValue = "297x420";


                lblFormatoPag.Text = "A4";
                lblPagXPliego.Text = "4";

                ddlPaginasInterior.DataSource = pc.Lista_PaginasInterior(2);
                ddlPaginasInterior.DataTextField = "CantidadPaginas";
                ddlPaginasInterior.DataValueField = "CantidadPaginas";
                ddlPaginasInterior.DataBind();
                ddlPaginasInterior.SelectedValue = "10";
            }
        }
        [WebMethod]
        public static string[] MyMethod(string firstName)
        {
            Presupuesto_Controller pc = new Presupuesto_Controller();
            PresupuestadorM m = pc.Carga_Paginas_Pliegos(firstName, 0);
            return new[] { m.FormatoPagina, m.PaginasxPliego };
        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }
    }
}