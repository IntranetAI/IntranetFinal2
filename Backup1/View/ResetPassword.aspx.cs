using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.View.Controller;
using Intranet.View.Model;
namespace Intranet.View
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        bool respuesta;
        bool verifica;
        int idUsu;
        string Codigo = GetRandomPassword(25);
        string Codigo2 = GetRandomPassword2(25);
        bool respInserM;
        Controller_ResetPassword RP = new Controller_ResetPassword();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void ibRecuperar_Click(object sender, ImageClickEventArgs e)
        {    
            CaptchaControl1.ValidateCaptcha(txtCaptcha.Text);


            if (txtCorreo.Text == "" & txtUsuario.Text != "")
            {
                string popupScript = "<script language='JavaScript'> alert('El campo Correo es obligatorio.');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else if (txtCorreo.Text != "" & txtUsuario.Text == "")
            {
                string popupScript = "<script language='JavaScript'> alert('El campo Usuario es obligatorio.');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else if (txtCorreo.Text == "" && txtUsuario.Text == "")
            {
                string popupScript = "<script language='JavaScript'> alert('Los campos usuario y Correo son obligatorios.');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
                if (txtCaptcha.Text != "")
                {
                    if (CaptchaControl1.UserValidated)
                    {
                        respuesta = RP.verificaResetPassword(txtUsuario.Text, txtCorreo.Text);
                        if (respuesta == true)
                        {
                            Controller_Login lo = new Controller_Login();
                            idUsu = lo.BuscarIDUsuario(txtUsuario.Text);
                            lblpaso.Text = idUsu.ToString();

                            verifica = RP.verificaEstadoReset(Convert.ToInt32(idUsu.ToString()));
                            if (verifica != false)
                            {
                                string popupScript = "<script language='JavaScript'> alert('¡Estimado Usuario:\\n\\n Ya existe una solicitud pendiente de cambio de contraseña en su correo electrónico. ! ');location.href='Login.aspx'</script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);
                            }
                            else
                            {


                                respInserM = RP.insertCambioMail(idUsu, Codigo);
                                if (respInserM == true)
                                {
                                    EnviarCorreo();
                                    string popupScript = "<script language='JavaScript'> alert('Estimado Usuario:\\n\\n Los Datos solicitados han sido enviados a su correo electrónico.');location.href='Login.aspx'</script>";
                                    Page.RegisterStartupScript("PopupScript", popupScript);
                                }
                                else
                                {
                                    string popupScript = "<script language='JavaScript'> alert('Estimado Usuario:\\n\\n Ya existe una solicitud pendiente de cambio de contraseña en su correo electrónico.');location.href='Login.aspx'</script>";
                                    Page.RegisterStartupScript("PopupScript", popupScript);
                                }
                            }
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('Los datos proporcionados son incorrectos, favor corregir.');</script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                            
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('El código de seguridad no coincide, vuelve a intentarlo.');</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                        txtCaptcha.Text = ""; 
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('El campo código de seguridad es obligatorio.');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }

            
            


        }

        protected void ibSalir_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        public static string GetRandomPassword(int length)
        {
            char[] chars = "$%@!*abcdefghijklmnopqrstuvwxyz1234567890¿¡;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^".ToCharArray();
            string password = string.Empty; Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int x = random.Next(length, chars.Length); //Don't Allow Repetation of Characters 
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else i--;
            }

            return password;
        }
        public static string GetRandomPassword2(int length)
        {
            char[] chars = "$%@!*abcdefghijklmnopqrstuvwxyz1234567890¿¡;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^".ToCharArray();
            string password = string.Empty; Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int x = random.Next(1, chars.Length); //Don't Allow Repetation of Characters 
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else i--;
            }

            return password;
        } 
        //Metodo enviar Correo
        public bool EnviarCorreo()
        {
            //string Codigo = GetRandomPassword(25);
            //string Codigo2 = GetRandomPassword2(25);
            //se inseta en la bdd
           

           
            /* Carga de PAra la base de Datos*/
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(txtCorreo.Text);
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Cambio de Clave Secreta";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("juan.venegas@aimpresores.cl"); //Opcional


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
                   "Para iniciar el proceso de reestablecimiento de contraseña de tu cuenta de " +
                   "" + txtCorreo.Text + " , haz clic en el siguiente enlace:<br />" +
                    "<br />" +
                    "http://Intranet.qgchile.cl/View/CambioClave.aspx?c=" + Codigo2 + "&i=" + idUsu.ToString() + "&co=" + Codigo +"&e=0"+ "<br />" +
                    "<br />" +
                    "Si eso no funciona, copia la URL y pégala en una ventana nueva del navegador." +
                    "<br />" +
                    "<br />" +
                    "Si has recibido este mensaje por error, es probable que otro usuario haya " +
                    "introducido sin darse cuenta tu dirección de correo electrónico al intentar " +
                    "restablecer una contraseña. Si no has iniciado el proceso de solicitud, no " +
                    "es necesario que hagas nada al respecto y puedes ignorar este mensaje " +
                    "tranquilamente." +
                    "<br />" +
                    "<br />" +
                    "Si " + txtCorreo.Text + " no es tu correo de cuenta de Usuario o no quieres cambiar tu clave secreta, haz clic en el " +
                    "siguiente enlace para eliminar la solicitud de cambio de clave secreta:" +
                    "" +
                    "<br />" +
                    "<br />" +
                      "http://Intranet.qgchile.cl/View/CambioClave.aspx?c=" + Codigo2 + "&i=" + idUsu.ToString() + "&co=" + Codigo +"&e=1"+ "<br />" +
                     "<br />" +
                    "<br />" +
                    "Atentamente," +
                     "<br />" +
                    "Equipo de desarrollo A Impresores S.A"+
                "</td>"+
            "</tr>"+
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

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            /*
            cliente.Port = 587;
            cliente.EnableSsl = true;
            */

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