using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloBodegaPliegos.Controller;
using Intranet.ModuloBodegaPliegos.Model;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class CrearPalletsMaquina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string[] BuscarOT(string OT)
        {
            Controller_Cortadora cc = new Controller_Cortadora();

                //BodegaPliegos d = cc.BuscaTotalCant(OT);
                //return new[] { d.OT, d.NombreOT, d.Componente, d.Papel, d.Gramaje, d.Ancho, d.Largo, d.StockFL };
            return new[] { "" };

        }
        [WebMethod]
        public static string[] CrearPallet(string OT, string nombreot, string compo, string papel, int ancho, int largo, int gramaje, int Asignado, float peso)
        {
            Controller_Cortadora cc = new Controller_Cortadora();

            //BodegaPliegos d = cc.BuscaTotalCant(OT);
            return new[] { "" };

        }
    }
}