using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.View.Controller;
using Intranet.View.Model;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.View
{
    public partial class Login : System.Web.UI.Page
    {
        string usuario;
        string password;
        bool respuesta;
        bool rConex;
        string IP;
        bool respPendiente;
        Controller_Conexion cConex = new Controller_Conexion();
        ControllerSubMenu submenu = new ControllerSubMenu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPIN.Attributes.Add("onkeypress", "return solonumeros(event);");
                txtUsername.Focus();
                string popupScript = "<script language='JavaScript'> tamaño(); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            //txtUsername.Text = "j.venegas";
            //txtPassword.Text = "456";
            //txtPIN.Text = "456";
            //ibIngresar_Click(null, null);
           
        }

        protected void ibIngresar_Click(object sender, ImageClickEventArgs e)
        {
            usuario = txtUsername.Text;
            password = txtPassword.Text;
            //CaptchaControl1.ValidateCaptcha(txtCaptcha.Text);
            IP = GetDireccionIp(Request);
            //if (CaptchaControl1.UserValidated)
            //{
                if (usuario.Length > 0 & password.Length > 0 & txtPIN.Text.Length > 0)
                {
                    respPendiente = cConex.CerrarConexionPendiente(usuario);

                    respuesta = Controller_Login.Login_sistema(usuario, password, Convert.ToInt32(txtPIN.Text));
                    // objNegocio.LoginServicios(rut, password);

                    if (respuesta == true)
                    {
                        //inserta la sesión
                        rConex = cConex.IngresaConexion(usuario, IP);
                        LoginSistema sis = new LoginSistema();
                        Controller_Login controlLo = new Controller_Login();
                        sis = controlLo.buscarPorID(txtUsername.Text);
                        string tipousuario = sis.user;
                    if (sis.estado == 1)
                    {

                        Session["Estado"] = sis.estado;
                        Session["Usuario"] = usuario;
                        Session["Nombre"] = sis.Nombre;
                        Session["centroCosto"] = sis.CentroCosto;
                        Session["MenuProduccion"] = submenu.CargarSubMenu(sis.Usuario, Convert.ToInt32(1));
                        Session["MenuAdministracion"] = submenu.CargarSubMenu(sis.Usuario, Convert.ToInt32(6));
                        Session["Perfil"] = sis.user;
                        if (usuario.ToUpper() == "KBA")
                        {
                            Response.Redirect("../ModuloEtiquetasMetricsWIP/view/EtiquetasWip.aspx?id=1");
                        }
                        else
                        {
                            if (tipousuario != "Normal")
                            {
                                //Response.Redirect("../ModuloProduccion/view/Suscripcion.aspx?id=1");
                                Response.Redirect("../ModuloProduccion/view/EstadoOT.aspx?id=1");
                            }
                            else
                            {
                                Response.Redirect("../ModuloProduccion/view/EstadoOT.aspx?id=1");
                            }
                        }
                    }
                    else if (sis.estado == 2)
                    {
                        string popupScript = "<script language='JavaScript'> alert('Su Cuenta ha sido Deshabilitada.\\n - Ha superado el número de intentos permitidos.\\n\\n * Contactese con el Administrador.');location.href='login.aspx' </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    else if (sis.estado == 4)
                    {
                        Session["Estado"] = sis.estado;
                        Session["Usuario"] = usuario;
                        Session["Nombre"] = sis.Nombre;
                        Session["centroCosto"] = sis.CentroCosto;
                        Session["MenuProduccion"] = submenu.CargarSubMenu(sis.Usuario, Convert.ToInt32(1));
                        Session["MenuAdministracion"] = submenu.CargarSubMenu(sis.Usuario, Convert.ToInt32(6));
                        Session["Perfil"] = sis.user;

                        if (tipousuario != "Normal")
                        {
                            // Response.Redirect("../ModuloProduccion/view/Suscripcion.aspx?id=1");
                            Response.Redirect("../ModuloProduccion/view/EstadoOT.aspx?id=1");
                        }
                        else
                        {
                            Response.Redirect("../ModuloProduccion/view/EstadoOT.aspx?id=1");
                        }
                    }
                   
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('¡ Usuario, clave y/o pin no coinciden !'); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                        //txtCaptcha.Text = "";
                    }



                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert(' Debe ingresar todos los campos'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                    //txtCaptcha.Text = "";

                }
            //}
            //else
            //{
            //    string popupScript = "<script language='JavaScript'> alert(' Codigo de Seguridad Incorrecto '); </script>";
            //    Page.RegisterStartupScript("PopupScript", popupScript);
            //    txtCaptcha.Text = "";
            //}
        }
        //capturar IP Conexion

        public static string GetDireccionIp(System.Web.HttpRequest request)
        {
            // Recuperamos la IP de la máquina del cliente
            // Primero comprobamos si se accede desde un proxy
            string ipAddress1 = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            // Acceso desde una máquina particular
            string ipAddress2 = request.ServerVariables["REMOTE_ADDR"];

            string ipAddress = string.IsNullOrEmpty(ipAddress1) ? ipAddress2 : ipAddress1;

            // Devolvemos la ip
            return ipAddress;
        }

       

    }
}