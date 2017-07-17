using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloUsuario.View
{
    public partial class NewMessenger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{ 
            //    string path =HttpContext.Current.Request.Url.AbsolutePath;
            //    if(path.Substring(0,17) !="ModuloRFrecuencia")
            //    {
            //        string popupScript = "<script language='JavaScript'>window.close(); </script>";
            //        Page.RegisterStartupScript("PopupScript", popupScript);
            //    }
            //}
        }

        protected void vorschausubmit1_Click(object sender, EventArgs e)
        {
            if (txtMensaje.Text.Length > 10)
            {
                if (EnviarCorreo(txtAsunto.Text.Trim(), txtMensaje.Text.Trim(), txtOT.Text.Trim(), Session["Usuario"].ToString(), txtMaquina.Text))
                {
                    string popupScript = "<script language='JavaScript'>window.close(); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                else
                {
                    string popupScript = "<script language='JavaScript'>alert(' Ha ocurrido un error al ingresar, vuelva a intentarlo '); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'>alert(' Mensaje muy corto, vuelva a intentarlo '); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        public bool EnviarCorreo(string asunto, string mensaje, string OT, string Usuario, string Maquina)
        {
            Boolean respuesta = false;
            
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add("mauricio.moya@aimpresores.cl@aimpresores.cl");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("juan.venegas@aimpresores.cl"); //Opcional
            

            //Cuerpo del Mensaje
            mmsg.Body = "<table style='width:100%;'>" +
            "<tr>" +
                "<td>" +
                    "<img src='http://intranet.qgchile.cl/images/Logo color lateral.jpg' width='267px'  height='67px' />" +
                    //"<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
                    "&nbsp;</td>" +
            "</tr>" +
            "</table>" +
                //termino cargar logo
        "<table style='width:100%;'>" +
            "<tr>" +
                "<td style='width:194px;'>" +
                    "OT y/o Pliego:&nbsp;&nbsp;"+ OT + "</td>" +
            "</tr>" +
            "<tr>" +
                "<td style='width:194px;'>" +
                    "Maquina :" + Maquina + "</td>" +
            "</tr>" +
            "<tr>" +
                "<td style='width:500px;'>" + mensaje + " </td>" +
            "</tr>" +
                 "</table><br />Atentamente "+Usuario;

            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");//"fecha.produccion@aimpresores.cl");


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
                respuesta = true;
                //Label1.Text = "enviado correctamente";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                //Label1.Text = "error al enviar el correo";
            }
            return respuesta;
        }
    }
}