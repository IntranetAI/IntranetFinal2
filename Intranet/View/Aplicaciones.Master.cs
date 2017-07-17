using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.View.Controller;

namespace Intranet.View
{
    public partial class Aplicaciones : System.Web.UI.MasterPage
    {
        bool respuesta;
        Controller_Conexion cCon = new Controller_Conexion();
        ControllerSubMenu submenu = new ControllerSubMenu();
        Controller_Login clog = new Controller_Login();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["Nombre"].ToString() != "")
                    {

                        string nombre = Session["Nombre"].ToString();
                        string[] str = nombre.Split(' ');
                        string nom = str[0] + " " + str[2];
                        lblNombreUsuario.Text = "Bienvenido Sr(a): " + nom;
                        if(clog.ActivarEnvioMensaje(nombre)){
                        mensaje.HRef = "";
                        }
                    }
                    else
                    {

                    }
                }

                catch
                {
                    Response.Redirect("http://intranet.qgchile.cl");
                }
            }
            try
            {
                string Seccion = Request.QueryString["id"];
                Label1.Text = submenu.CargarAplicaciones_Menu(Session["Usuario"].ToString(), Seccion, Convert.ToInt32(Request.QueryString["cat"]));
                string path = HttpContext.Current.Request.Url.AbsolutePath;
                int modulo = path.LastIndexOf('/') + 1;
                string url = path.Substring(modulo, path.Length - modulo);
                Label2.Text = submenu.CargarMenuRastro(url);
            }
            catch
            {
                //string Seccion = Request.QueryString["id"];
                //string categoria = Request.QueryString["cat"];
                //Label1.Text = submenu.CargarAplicaciones_Menu(Session["Usuario"].ToString(), Seccion, Convert.ToInt32(categoria));
                //menu Proyectos
                Label1.Text = submenu.CargarAplicaciones_Proyecto(Session["Usuario"].ToString());
            }
        }
    }
}