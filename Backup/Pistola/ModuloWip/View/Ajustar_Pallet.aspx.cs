using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;
using System.Drawing;
using Intranet.ModuloWip.Model;

namespace Intranet.ModuloWip.View
{
    public partial class Ajustar_Pallet : System.Web.UI.Page
    {
        Controller_Wip wipControl = new Controller_Wip();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCodigo.Focus();
                if (Request.QueryString["id"] != "")
                {
                    lblNombre.Text = Request.QueryString["id"];
                    lblTipo.Text = Request.QueryString["Tipo"];
                }
            }
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            Wip wip = wipControl.BuscarPallet_Wip(codigo);

            if (wip.OT != null)
            {
                DivMensaje.Visible = false;
                lblOT.Text = wip.OT;
                lblNombreOT.Text = wip.NombreOT;
                txtcantidad.Text = wip.PliegosImpresos.ToString();
                txtPeso.Text = wip.PesoPallet.ToString();
                btnGuardar.Visible = true;
                pnlDetalle.Visible = true;
                DivMensaje.Visible = false;
                txtcantidad.Focus();
            }
            else
            {
                btnGuardar.Visible = false;
                pnlDetalle.Visible = false;
                DivMensaje.Visible = true;
                DivMensaje.Attributes.Add("style", "background-color:Red");
                Image1.ImageUrl = "../../Images/cross.png";
                lblMensaje.ForeColor = Color.White;
                lblMensaje.Text = "Codigo de Pallet Incorrecto.";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Codigo = txtCodigo.Text.Trim();
            int Cantidad = Convert.ToInt32(txtcantidad.Text.Trim());
            double Peso = Convert.ToDouble(txtPeso.Text.Trim());
            Wip wip = wipControl.BuscarPallet_Wip(Codigo);
            if (wipControl.UpdatePallet(Codigo, Cantidad, Peso, lblNombre.Text))
            {
                if (wip.EstadoPallet == 6)
                {
                    EnvioCorreo("Sunipac", lblNombre.Text, Codigo);
                }
                else if (wip.EstadoPallet == 7)
                {
                    EnvioCorreo("Despacho Servico Externo", lblNombre.Text, Codigo);
                }
                Response.Redirect("Ajustar_Pallet.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
            }
            else
            {
                DivMensaje.Visible = true;
                DivMensaje.Attributes.Add("style", "background-color:Red");
                Image1.ImageUrl = "../../Images/cross.png";
                lblMensaje.ForeColor = Color.White;
                lblMensaje.Text = "Error al Conectar al Servidor.";
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ajustar_Pallet.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }

        public bool EnvioCorreo(string Destino, string Usuario, string Codigo)
        {
            /* Carga de PAra la base de Datos*/
            /*-------------------------MENSAJE DE CORREO----------------------*/
            Wip wip = wipControl.BuscarPallet_Wip(Codigo);
            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add("juan.venegas@aimpresores.cl");
            if (Destino == "Sunipac")
            {
                //mmsg.To.Add("juan.venegas@aimpresores.cl");
                mmsg.To.Add("envio.sexterno@aimpresores.cl");
            }
            else if (Destino == "Despacho Servico Externo")
            {
                //mmsg.To.Add("juan.venegas@aimpresores.cl");
                mmsg.To.Add("pallet.despacho@aimpresores.cl");
            }
            //mmsg.To.Add("mariamilagros.paez@aimpresores.cl");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Devolución " + Destino + " OT: " + wip.OT + " Pliego: " + wip.Pliego;
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
                              // "<img src='<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
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
                            "<td colspan='3'>" + wip.Tiraje.ToString("N0").Replace(",", ".") + "</td>" +
                       "</tr>" +
                        "<tr>" +
                            "<td  style='width:194px;'>" +
                              " Fecha:</td>" +
                            "<td colspan='3'>" + dia + "/" + mes + "/" + año + "</td>" +
                       "</tr>" +
                        "<tr>" +
                            "<td  style='width:194px;'>" +
                               "Creador Por:</td>" +

                          "<td colspan='3'>" + Usuario +
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
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Proceso Realizado</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + Codigo + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + wip.Pliego + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;' align='right'>" + wip.PliegosImpresos.ToString("N0").Replace(",", ".") + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + wip.Maquina + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + wip.ProxProceso + "</td>" +
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