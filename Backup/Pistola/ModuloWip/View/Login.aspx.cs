using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Model;
using Intranet.ModuloWip.Controller;

namespace Intranet.ModuloWip.View
{
    public partial class Login : System.Web.UI.Page
    {
        bool respPendiente;
        bool respuesta;
        bool rConex;
        string IP;
        Controller_Conexion cConex = new Controller_Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUsuario.Focus();
            }
        }
        
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            IP = GetDireccionIp(Request);
            string tipo = "";
            if (txtUsuario.Text.Length > 0 & txtPassword.Text.Length > 0)
            {
                respPendiente = cConex.CerrarConexionPendiente(txtUsuario.Text);

                respuesta = Controller_Login.Login_sistema(txtUsuario.Text, txtPassword.Text);
                // objNegocio.LoginServicios(rut, password);

                if (respuesta == true)
                {
                    //inserta la sesión
                    rConex = cConex.IngresaConexion(txtUsuario.Text, IP);
                    Login_Sistema sis = new Login_Sistema();
                    Controller_Login controlLo = new Controller_Login();
                    sis = controlLo.buscarPorID(txtUsuario.Text);

                    if (sis.estado == 2)
                    {
                        string popupScript = "<script language='JavaScript'> alert('Su Cuenta ha sido Deshabilitada.\\n - Ha superado el número de intentos permitidos.\\n\\n * Contactese con el Administrador.');location.href='login.aspx' </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    else
                    {
                        Session["Estado"] = sis.estado;
                        Session["Usuario"] = txtUsuario.Text;
                        Session["Nombre"] = sis.Nombre;
                        Session["centroCosto"] = sis.CentroCosto;

                        //if (sis.CentroCosto.Contains("WIP"))
                        //{
                        //    tipo = "WIP";
                        //}
                        //else
                        //{
                        //    tipo = "BP";
                        //}
                        Response.Redirect("Menu.aspx?id=" + txtUsuario.Text + "&Tipo=WIP");
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
        }

        
    }
}