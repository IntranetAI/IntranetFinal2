using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Model;
using Intranet.ModuloBodegaPliegos.Controller;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class InventarioMetricsBobina : System.Web.UI.Page
    {
        Controller_BodegaPliegos bp = new Controller_BodegaPliegos();
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<BodegaPliegos> lista = new List<BodegaPliegos>();
            //BodegaPliegos b = new BodegaPliegos();
            //b.CodigoProducto = "xxxx";
            //b.Marca = "mmmnmm";
            //b.descripcion = "dddd";
            //b.Gramaje = "90";
            //b.Ancho = "100";
            //b.Certificacion = "PEFC";
            //b.StockFL = "300";
            //b.Antiguedad = "5";
            //b.Seleccionar = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Solicitud();'>Solicitar</a>";
            
            //lista.Add(b);
            //string ot = Request.QueryString["ot"];
            //string componente = Request.QueryString["componente"];
            //string codigo = Request.QueryString["codproducto"];
            //string papel = Request.QueryString["papel"];
            //int gramaje = Convert.ToInt32(Request.QueryString["gramaje"]);
            //int ancho = Convert.ToInt32(Request.QueryString["ancho"]);

            //RadGrid1.DataSource = bp.BobinasMetrics(ot,componente,"", papel, gramaje, ancho, 0);
            //RadGrid1.DataBind();

            //RadGrid2.DataSource = "";
            //RadGrid2.DataBind();
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> javascript:window.close();  </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> javascript:window.close();  </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> javascript:window.close();  </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }
    }
}