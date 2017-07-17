using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;

namespace Intranet.ModuloAdministracion.View
{
    public partial class DetalleFacturaProveedor : System.Web.UI.Page
    {
        Controller_Factura cf = new Controller_Factura();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCerrarVentana.Attributes.Add("onclick", "window.close();");
            btnImprimir.Attributes.Add("onclick", "window.print();"); 
            Label1.Text = "Nro. Factura: " + Request.QueryString["folio"] + " <br/> Proveedor: " + Request.QueryString["rut"] + " - " + Request.QueryString["emi"];

            RadGrid1.DataSource = cf.Listar_DetalleFacturas("", Request.QueryString["emi"], Request.QueryString["folio"] + ".0", "", "", "", "", "", 3);
            RadGrid1.DataBind();


        }

        protected void btnCerrarVentana_Click(object sender, EventArgs e)
        {

        }

    }
}