using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.View.Controller;
using System.Web.Services;
using Intranet.ModuloUsuario.Controller;
using System.IO;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.View
{
    public partial class index : System.Web.UI.MasterPage
    {
        bool respuesta;
        Controller_Conexion cCon = new Controller_Conexion();
        Mail_Controller controlMail = new Mail_Controller();
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
                        ControllerSubMenu submenu = new ControllerSubMenu();
                        if (!controlMail.CantidadMailSinLeer(Session["Usuario"].ToString()))
                        {
                            Image3.ImageUrl = "../Images/mensajeria-intento.png";
                        }
                        if (Request.QueryString["id"] == "1")
                        {
                            Label2.Text = Session["MenuProduccion"].ToString();
                        }
                        else
                        {
                            Label2.Text = Session["MenuAdministracion"].ToString();
                        }

                        //submenu.CargarSubMenu(Session["Usuario"].ToString(), Convert.ToInt32(Request.QueryString["id"]));

                        //Session["Menu"].ToString();
                        btnRedactar.Text = submenu.CargarMenuProyectos(Session["Usuario"].ToString());

                        //if (Label2.Text == "<ul id='accordion'></ul>")
                        //{
                        //    string popupScript = "<script language='JavaScript'> alert('Estimado Usuario:\\n Usted No tiene acceso al sistema de Administracion.');location.href='javascript:history.go(-1)'</script>";
                        //    Page.RegisterStartupScript("PopupScript", popupScript);
                        //}
                        if (Convert.ToInt32(Session["estado"].ToString()) == 4)
                        {

                        }
                        else
                        {
                            Image2.Visible = false;
                        }
                        string path = HttpContext.Current.Request.Url.AbsolutePath;
                        int modulo = path.LastIndexOf('/') + 1;
                        string url = path.Substring(modulo, path.Length - modulo);

                        lblTitulo.Text = submenu.CargarMenuRastro(url);

                       

                    }
                }
                catch
                {
                    Response.Redirect("http://intranet.qgchile.cl");
                }
            }
             
        }

        public Label boton1
        {
            get { return btnRedactar; }
            set { btnRedactar = value; }
        }

        protected void ibCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            respuesta = cCon.CerrarConexion(Session["Usuario"].ToString());


            Session.RemoveAll();
            Response.Redirect("http://intranet.qgchile.cl");
        }

    }
}