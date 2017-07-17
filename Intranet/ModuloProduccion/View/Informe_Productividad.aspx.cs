using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloProduccion.Model;
using System.Web.Script.Serialization;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class Informe_Productividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'>cargarGraficos();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        [WebMethod]
        public static string CargarDatosSemana1(string Maquina)
        {
            Controller_Productividad controlproduc = new Controller_Productividad();
            List<ProductividadMaquina> lista2 = controlproduc.ListarProductividadMaquina(Maquina,0);
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }

        [WebMethod]
        public static string CargarDatosAnuales(string Maquina,int Procedimiento)
        {
            Controller_Productividad controlproduc = new Controller_Productividad();
            List<ProductividadMaquina> lista2 = controlproduc.ListarProductividadMaquina(Maquina, Procedimiento);
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeguimientoController sc = new SeguimientoController();
            ddlMaquina.DataSource = sc.ListMaquinas(ddlSeccion.SelectedValue.ToString().Replace("Rotativas", "Rotativa"));
            ddlMaquina.DataTextField = "Name";
            ddlMaquina.DataValueField = "Name";
            ddlMaquina.DataBind();
            ddlMaquina.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
        }

    }
}