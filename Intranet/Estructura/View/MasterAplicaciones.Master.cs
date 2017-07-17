using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Estructura.Controller;

namespace Intranet.Estructura.View
{
    public partial class MasterAplicaciones : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string nombreCompleto = Session["Nombre"].ToString();
                    string[] str = nombreCompleto.Split(' ');
                    string nombrePila = str[0] + " " + str[2];
                    lblNombreUsuario.Text = "Bienvenido Sr(a): " + nombrePila;
                    Controller_MenuSecundario menuapli = new Controller_MenuSecundario();
                    try
                    {
                        string Seccion = Request.QueryString["id"];
                        
                        lblMenuAplicacionesPrincipal.Text = menuapli.CargarMenu_AplicacionesSeccion(Session["Usuario"].ToString(), Seccion, Convert.ToInt32(Request.QueryString["cat"]));
                        
                    }
                    catch
                    {
                        lblMenuAplicacionesPrincipal.Text = menuapli.CargarAplicaciones_Proyecto(Session["Usuario"].ToString());
                    }
                }
                catch
                {
                    Response.Redirect("http://intranet.qgchile.cl");
                }
            }
        }

        //public void MenuAplicaciones()
        //{
        //    lblMenuAplicacionesPrincipal.Text =
        //        "<div id='cssmenu'><ul><li><a href='../../ModuloProduccion/View/EstadoOT.aspx?id=1'><i class='fa fa-fw fa-home'></i>Inicio</a></li>" +
        //                "<li class='has-sub'><a><i class='fa fa-fw fa-bars'></i>Informes</a>" +
        //                    "<ul>" +
        //                        "<li><a href='../../ModuloProduccion/View/Informe_SobreImpresion.aspx?id=1&cat=4'>Inf. Diario Sobre Prod.</a></li>" +
        //                        "<li><a href='../../ModuloProduccion/View/Informe_MensualSobreProd.aspx?id=1&cat=4'>Inf. Mensual Sobre Prod.</a></li>" +
        //                    "</ul>" +
        //                "</li>" +
        //            "</ul>" +
        //        "</div>";
        //}
    }
}