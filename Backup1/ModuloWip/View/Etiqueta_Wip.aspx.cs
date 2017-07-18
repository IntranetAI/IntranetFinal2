using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;
using System.Drawing;
using System.Drawing.Imaging;

namespace Intranet.ModuloWip.View
{
    public partial class Etiqueta_Wip : System.Web.UI.Page
    {
        Controller_WipControl wipControl = new Controller_WipControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            Model_Wip_Control wip = wipControl.BuscarWip_ControlPorCodigo(Request.QueryString["cd"]);
            if (wip.ID_Control != "")
            {
                lblOT.Text = wip.OT;
                lblNombreOT.Text = wip.NombreOT;
                lblFechaCreacion.Text = wip.Fecha_Creacion.ToString("dd/MM/yyyy");
                lblHora.Text = wip.Fecha_Creacion.ToString("HH:mm:ss");
                lblTiraje.Text = wip.TotalTiraje.ToString("N0").Replace(',', '.');
                lblPliego.Text = wip.Pliego;
                if (wip.Pliegos_Impresos != 0)
                {
                    lblEjemplar.Text = wip.Pliegos_Impresos.ToString("N0").Replace(',', '.');
                }
                if (wip.Peso_pallet != 0)
                {
                    lblCantidad.Text = wip.Peso_pallet.ToString("N0").Replace(',', '.');
                }
                lblOperador.Text = wip.Usuario;
                lblMaquina.Text = wip.Maquina;
                lblDestino.Text = wip.Ubicacion;
                lblCodigo.Text = wip.ID_Control;
                lblDestino.Text = wip.Ubicacion;
                lblPallet.Text = " " + wip.TipoPallet;
                EnvioCorreo(wip);

            }
            LabelKit.BarcodeGenerator code = new LabelKit.BarcodeGenerator();

            System.Drawing.Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1, PixelFormat.Format32bppArgb);

            g = Graphics.FromImage(bmp);

            code.DrawCode128(g, wip.ID_Control, 0, 0).Save(Server.MapPath("./barcodes/bc.png"), ImageFormat.Png);
            imgCodigo.ImageUrl = "./barcodes/bc.png";
        }

        public bool EnvioCorreo(Model_Wip_Control wip)
        {
            /* Carga de PAra la base de Datos*/
            /*-------------------------MENSAJE DE CORREO----------------------*/
            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add("roxana.burgos@aimpresores.cl");
            mmsg.To.Add("gonzalo.vergara@aimpresores.cl");
            mmsg.To.Add("srubio@aencuadernadores.cl");

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Pallet Wip OT: " + wip.OT + " Pliego: " + wip.Pliego;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("juan.venegas@aimpresores.cl"); //Opcional
            DateTime hoy = DateTime.Now;
            string fecha = hoy.ToString("dd/MM/yyyy HH:mm");
            string[] str = fecha.Split('/');
            string dia = str[0];
            string mes = str[1];
            string año = str[2];
            //año = año.Substring(0, 4);
            //string hora = hoy.ToLongTimeString();

            //Cuerpo del Mensaje
            mmsg.Body =
                        "<table style='width:80%;'>" +
                        "<tr>" +
                            "<td>" +
                                 "<img src='http://intranet.qgchile.cl/images/Logo color lateral.jpg' width='267px'  height='67px' />" +
                                "&nbsp;</td>" +
                        "</tr>" +
                        "</table>" +
                //termino cargar logo
                            "<div style='border-color:Black;border-width:3px;border-style:solid;'>" +
                    "<table style='width:80%;'>" +
                       "<tr>" +
                            "<td style='width:194px;'>" +
                                "&nbsp;</td>" +
                            "<td colspan='3'>" +
                                "&nbsp;</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td  style='width:194px;'>" +
                                "OT Nro.: </td>" +
                            "<td>" + wip.OT.ToUpper() + "</td>" +
                            "<td  style='width:194px;'>" +
                                "Nombre OT: </td>" +
                            "<td>" + wip.NombreOT + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td  style='width:194px;'>" +
                              " Tiraje OT:</td>" +
                            "<td colspan='3'>" + wip.TotalTiraje.ToString("N0").Replace(",", ".") + "</td>" +
                       "</tr>" +
                        "<tr>" +
                            "<td  style='width:194px;'>" +
                              " Fecha:</td>" +
                            "<td colspan='3'>" + dia + "/" + mes + "/" + año + "</td>" +
                       "</tr>" +
                        "<tr>" +
                            "<td  style='width:194px;'>" +
                               "Creador Por:</td>" +

                          "<td colspan='3'>" + wip.Usuario +
                               "</td>" +
                       "</tr>" +
                             "</table>" +
                            "<br />" +
                            "</div>" +
                            "<table style='width:80%;'><tr>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Codigo Pallet</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Pliego</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Pliego Imp.</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Maquina</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + wip.ID_Control + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + wip.Pliego + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;' align='right'>" + wip.Pliegos_Impresos.ToString("N0").Replace(",", ".") + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + wip.Maquina + "</td>" +
                                "</tr></table>";

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
                return true;
                //Label1.Text = "enviado correctamente";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
                //Aquí gestionamos los errores al intentar enviar el correo
                //Label1.Text = "error al enviar el correo";
            }
        }
    }
}