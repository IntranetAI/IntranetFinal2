using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.View.Controller;
using System.Text.RegularExpressions;
namespace Intranet.View.Model
{
    public partial class Registro : System.Web.UI.Page
    {
        bool respuesta;
        string result;
        Controller_Registro cReg = new Controller_Registro();
        Controller_Login cLogin = new Controller_Login();
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtRut.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtRut.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtPin.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtPin2.Attributes.Add("onkeypress", "return solonumeros(event);");

        }
        public static bool IsValidEmail(string strMailAddress)
        {
            // validacion de correo extension qgchile y qgchilenc
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])(@aimpresores.cl|@qgchilenc.cl)))");
        }
        public bool isValidPass(string Passw)
        {
            //return Regex.IsMatch(Passw, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)|(-_!@#~*.€¬}?¿)^([a-zA-Z0-9]{6,50})$");
            return Regex.IsMatch(Passw, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{0,10})|(-_!@#~*.€¬}?¿)$");
        }

        protected void ibCrearCuenta_Click(object sender, ImageClickEventArgs e)
        {
            string Nombre = TextBox2.Text;
            string Rut = txtRut.Text;
            string Usuario = txtUsername.Text;
            string pass = txtPass.Text;
            string pass2 = txtPass2.Text;
            string correo = txtCorreo.Text;
            string Pin = txtPin.Text;
            string pin2 = txtPin2.Text;

            CaptchaControl1.ValidateCaptcha(txtCaptcha.Text);

            if (Usuario == "")
            {
                string popupScript = "<script language='JavaScript'> alert(' El Campo Usuario es Obligatorio.'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                txtUsername.Focus();
                txtCaptcha.Text = "";
            }
            else if (pass == "")
            {
                string popupScript = "<script language='JavaScript'> alert(' El Campo Password es Obligatorio.'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                txtPass.Focus();
                txtCaptcha.Text = "";
            }
            else if (pass2 == "")
            {
                string popupScript = "<script language='JavaScript'> alert(' El Campo reingrese Password es Obligatorio.'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                txtPass2.Focus();
                txtCaptcha.Text = "";
            }

            else if (correo == "")
            {
                string popupScript = "<script language='JavaScript'> alert(' El Campo Correo es Obligatorio.'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                txtCorreo.Focus();
                txtCaptcha.Text = "";
            }
            else if (Pin == "")
            {
                string popupScript = "<script language='JavaScript'> alert(' El Campo PIN es Obligatorio.'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                txtPin.Focus();
                txtCaptcha.Text = "";
            }
            else if (pin2 == "")
            {
                string popupScript = "<script language='JavaScript'> alert(' El Campo reingrese PIN es Obligatorio.'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                txtPin2.Focus();
                txtCaptcha.Text = "";
            }
            else
            {
                if (isValidPass(txtPass.Text) == true)
                {
                    if (pass != "1234" || pass != "4321")
                    {
                        if (pass == pass2)
                        {
                            if (Pin == pin2)
                            {
                                if (IsValidEmail(txtCorreo.Text) == true)
                                {

                                    if (CaptchaControl1.UserValidated)
                                    {

                                        respuesta = cReg.RegistroUsuario(Nombre, Rut, Usuario, pass, correo, Convert.ToInt32(Pin),txtCargo.Text,txtCentroCosto.Text);

                                        if (respuesta != false)
                                        {
                                            generarCorreo();
                                            string popupScript = "<script language='JavaScript'> alert(' Cuenta de Usuario creada correctamente.\\n\\n Su cuenta se encuentra Inactiva. ');location.href='Login.aspx' </script>";
                                            Page.RegisterStartupScript("PopupScript", popupScript);
                                        }
                                        else
                                        {
                                            string popupScript = "<script language='JavaScript'> alert(' El nombre de usuario y/o rut ya existe, vuelva a intentarlo.'); </script>";
                                            Page.RegisterStartupScript("PopupScript", popupScript);
                                        }
                                    }
                                    else
                                    {
                                        string popupScript = "<script language='JavaScript'> alert(' Código de Seguridad Incorrecto, vuelva a intentarlo.'); </script>";
                                        Page.RegisterStartupScript("PopupScript", popupScript);
                                        txtCaptcha.Text = "";
                                    }
                                }
                                else
                                {
                                    string popupScript = "<script language='JavaScript'> alert('El correo no tiene el formato correcto, sólo se permiten correos de la empresa.\\n\\n Por Ejemplo: Alguien@aimpresores.cl o Alguien@qgchilenc.cl'); </script>";
                                    Page.RegisterStartupScript("PopupScript", popupScript);
                                }
                            }
                            else
                            {
                                string popupScript = "<script language='JavaScript'> alert(' Los códigos PIN NO coinciden'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);
                                txtCaptcha.Text = "";
                            }
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert(' Las Claves Secretas NO Coinciden'); </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                            txtCaptcha.Text = "";
                        }
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('El código PIN es poco seguro, vuelva a intentarlo'); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('Estimado Usuario: \\n\\nPor seguridad su clave debe contener Número y letras ademas de un minimo de 6 caracteres.'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }



        }


        protected void ibValidar_Click(object sender, ImageClickEventArgs e)
        {
            if (txtRut.Text != "" & txtDV.Text != "")
            {

                string resultado = digitoVerificador(Convert.ToInt32(txtRut.Text));

                if (resultado == txtDV.Text.ToUpper())
                {
                   LoginSistema sis= cReg.verificarRUT(Convert.ToInt32(txtRut.Text));

                   if (sis.Nombre != "")
                   {
                     
                       //lblNombre.Text = sis.Nombre;
                       txtCargo.Text = sis.cargo;
                       txtCentroCosto.Text = sis.CentroCosto;

                       pnlRespuesta.Visible = true;
                       pnlRut.Visible = false;
                       TextBox2.Text = sis.Nombre;
                       txtRutCompleto.Text = txtRut.Text + "-" + txtDV.Text;
                   }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('No existe en la bdd'); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                        txtRut.Text = "";
                        txtDV.Text = "";
                        txtRut.Focus();

                    }
                }     
                else
                {
                    string popupScript = "<script language='JavaScript'> alert(' Rut incorrecto.'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                    txtRut.Text = "";
                    txtDV.Text = "";
                    txtRut.Focus();
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert(' El Campo Rut es Obligatorio.'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
        //funcion valida Rut
        public string digitoVerificador(int rut)
        {
            int Digito;
            int Contador;
            int Multiplo;
            int Acumulador;
            string RutDigito;

            Contador = 2;
            Acumulador = 0;

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                {
                    Contador = 2;
                }

            }

            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
            {
                RutDigito = "K";
            }
            if (Digito == 11)
            {
                RutDigito = "0";
            }
            return (RutDigito);
        }

        public bool generarCorreo()
        {
            //txtusername

            string nombre = "";
            string correo = "";
            
            LoginSistema sis = cReg.ActivarUsuariosCorreo(txtCentroCosto.Text);
            try
            {
                 nombre = sis.Nombre;
                 correo = sis.Correo;
            }
            catch
            {
                nombre = "";
                correo = "";
            }
            LoginSistema lgSis = cLogin.buscarPorID(txtUsername.Text);
            int idUs = Convert.ToInt32(lgSis.IDLogin);


            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(correo);
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = mmsg.Subject = "Solicitud Usuario - " + TextBox2.Text;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("juan.venegas@aimpresores.cl"); //Opcional

            string nomb = TextBox2.Text;
            string[] str = nomb.Split(' ');
            string n = str[0]+"_"+str[2]+"_"+str[3];
            //Cuerpo del Mensaje
            //mmsg.Body = "asdasd redireccion: algo.aspx?c="+Codigo2+"&i=" + idUsu.ToString() + "&co=" + Codigo;
            mmsg.Body = "<table style='width:100%;'>" +
            "<tr>" +
                "<td>" +
                    "<img src='http://intranet.qgchile.cl/images/Logo color lateral.jpg' width='267px'  height='67px' />" +
                    //"<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
                "</td>" +
            "</tr>" +
            "<tr>" +
                "<td>" +
                    "&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>" +
                    "Estimado(a) "+nombre+":"+
                    "<br />"+
                      "<br />" +
                        "<br />" +
                    "El Usuario "+TextBox2.Text+" ha iniciado el proceso de activación de su cuenta,"+
                    " haz clic en el siguiente enlace para realizar la activacion: <br />"+
                     "<br />" +
                    "Nota: Para Activar la cuenta de usuario, debe estar previamente autentificado en el sistema." +
                    "<br />" +
                    "http://Intranet.qgchile.cl/ModuloJefatura/View/asignarModulos.aspx?i=" + idUs.ToString() + "&n="+n+"&e="+0+"" +
                    "<br />" +
                      "<br />" +
                    "Si eso no funciona, copia la URL y pégala en una ventana nueva del navegador." +
                    "<br />" +
                    "<br />" +
                    "Si has recibido este mensaje y el usuario " + TextBox2.Text + " no esta encargado a tu área " +
                    ", haz clic en el " +
                    "siguiente enlace para eliminar la solicitud de Activación de Cuenta:" +
                   
                    "<br />" +
                    "<br />" +
                   "http://Intranet.qgchile.cl/ModuloJefatura/View/asignarModulos.aspx?i=" + idUs.ToString() + "&n=" + n + "&e=" + 1 + "" + "<br />" +
                     "<br />" +
                    "<br />" +
                    "Atentamente," +
                     "<br />" +
                    "Equipo de desarrollo A Impresores S.A" +
                "</td>" +
            "</tr>" +
            "</table>";

            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");

            cliente.Host = "mail.aimpresores.cl";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
                return true;
                //lblaglo.Text = "enviado correctamente";

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
                //Aquí gestionamos los errores al intentar enviar el correo
                //lblaglo.Text = "error al enviar el correo";
            }
        }
    }
}