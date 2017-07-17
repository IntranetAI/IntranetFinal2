using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.View.Controller;

namespace Intranet.Pags
{
    public partial class Nosotros : System.Web.UI.Page
    {
        bool respuesta;
        Controller_Conexion cCon = new Controller_Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Usuario"] = Session["Usuario"].ToString();
            Session["Nombre"] = Session["Nombre"].ToString();
            lblNombreUsuario.Text = "Bienvenido Sr(a): " + Session["Nombre"].ToString();
        }

        protected void lkCerrarSesion_Click(object sender, EventArgs e)
        {
            respuesta = cCon.CerrarConexion(Session["Usuario"].ToString());

            Session.RemoveAll();
            Response.Redirect("http://Intranet.qgchile.cl");
        }
    }
}