using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.View.Controller;

namespace Intranet.View
{
    public partial class Pagina_Inicio : System.Web.UI.Page
    {
        bool respuesta;
        Controller_Conexion cCon = new Controller_Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
     
            Session["Usuario"] = Session["Usuario"].ToString();
            Session["Nombre"] = Session["Nombre"].ToString();

            if (Convert.ToInt32(Session["estado"].ToString()) == 4)
            {
                
            }
            else
            {
                Image1.Visible = false;
            }


            string nombre = Session["Nombre"].ToString();
            string[] str = nombre.Split(' ');
            string nom = str[0] + " " + str[2];
            lblNombreUsuario.Text = "Bienvenido Sr(a): " + nom;
           
        }

        protected void ibCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            respuesta = cCon.CerrarConexion(Session["Usuario"].ToString());
            Session.RemoveAll();
            Response.Redirect("http://Intranet.qgchile.cl");
        }

        //protected void lkCerrarSesion_Click(object sender, EventArgs e)
        //{
        //    respuesta = cCon.CerrarConexion(Session["Usuario"].ToString());

        //    Session.RemoveAll();
        //    Response.Redirect("http://Intranet.qgchile.cl");
        //}

    }
}