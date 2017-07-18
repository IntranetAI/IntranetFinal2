using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloComercial.Controller;

namespace Intranet.ModuloComercial.View
{
    public partial class Mantenedor_ValorTrimestral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Request.QueryString["User"];
            }
        }

        [WebMethod]
        public static string GuardarCambios(string Usuario, string NuevoQ, string Mes)
        {
            string respuesta = "Error";
            Presupuesto_Controller controlpres = new Presupuesto_Controller();
            if (Usuario != "" && NuevoQ != "")
            {
                int Month= 0;
                string MesComienzo = "";
                string MesPromedio = "";
                switch (Mes)
                {
                    case "Enero": Month = 2; MesComienzo = "Noviembre"; MesPromedio = "Octubre"; break;
                    case "Febrero": Month = 3; MesComienzo = "Diciembre"; MesPromedio = "Noviembre"; break;
                    case "Marzo": Month = 4; MesComienzo = "Enero"; MesPromedio = "Diciembre"; break;
                    case "Abril": Month = 5; MesComienzo = "Febrero"; MesPromedio = "Enero"; break;
                    case "Mayo": Month = 6; MesComienzo = "Marzo"; MesPromedio = "Febrero"; break;
                    case "Junio": Month = 7; MesComienzo = "Abril"; MesPromedio = "Marzo"; break;
                    case "Julio": Month = 8; MesComienzo = "Mayo"; MesPromedio = "Abril"; break;
                    case "Agosto": Month = 9; MesComienzo = "Junio"; MesPromedio = "Mayo"; break;
                    case "Septiembre": Month = 10; MesComienzo = "Julio"; MesPromedio = "Junio"; break;
                    case "Octubre": Month = 11; MesComienzo = "Agosto"; MesPromedio = "Julio"; break;
                    case "Noviembre": Month = 12; MesComienzo = "Septiembre"; MesPromedio = "Agosto"; break;
                    default: Month = 1; MesComienzo = "Octubre"; MesPromedio = "Septiembre"; break;
                }
                DateTime now = DateTime.Today;
                int Año = now.Year;
                if (now.Month > Month)
                {
                    Año = Año +1;
                }

                string FechaTermino = new DateTime(Año, Month, 1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
                if (controlpres.InsertCambioValorTrimestral(Usuario, NuevoQ, FechaTermino, MesComienzo, MesPromedio))
                {
                    respuesta = "OK";
                }
            }
            return respuesta;
        }
    }
}