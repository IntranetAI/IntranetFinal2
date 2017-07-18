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
    public partial class Asignar_Ubicacion : System.Web.UI.Page
    {
        Controller_Wip wipControl = new Controller_Wip(); Controller_Wip_LecturaMetrics wlm = new Controller_Wip_LecturaMetrics();
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
            Wip wip = wipControl.BuscarWip_ControlPorCodigo(codigo,"Movil",lblNombre.Text);
            if (wip.OT != null)
            {
                lblOT.Text = wip.OT.ToUpper();
                lblNombreOT.Text = wip.NombreOT;
                pnlDetalle.Visible = true;
                string[] str = wipControl.UbicacionSugLibre(wip.OT).Split(',');
                lblRecomendacion.Text = str[1];
                lblRecomUbi.Text = str[0];
                btnGuardar.Visible = true;
                
            }
            else
            {
                DivMensaje.Visible = true;
                DivMensaje.Attributes.Add("style", "background-color:Red");
                lblMensaje.Text = "Error de Codigo. Vuelva a Intentarlos";
                lblMensaje.ForeColor = System.Drawing.Color.White;
                Image1.ImageUrl = "../../Images/cross.png";
                
            }
            txtUbicacion.Focus();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ////******************************************************************CODIGO INICIAL *****************************************************************************
            //string Codigo = txtCodigo.Text.Trim();
            //string Ubicacion = txtUbicacion.Text.Trim().ToUpper();
            //List<Wip> wp = wipControl.ListaMaquinaProceso(0);
            //string CodigosMachine = ",";
            //foreach (Wip w in wp)
            //{
            //    CodigosMachine = CodigosMachine + w.ID_Control + ",";
            //}
            ////Asignar ubicacion en Encuadernacion
            //int n = CodigosMachine.IndexOf(Ubicacion);
            //if (n > 0)
            //{
            //    if (wipControl.ConsumirPorEnc(Codigo, Ubicacion, lblNombre.Text))
            //    {
            //        Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
            //    }
            //}
            ////Asignar ubicacion en Servicio Externo
            //else if (Ubicacion == "SE002" || Ubicacion == "DSE01" || Ubicacion == "TD001" || Ubicacion == "DD003")
            //{
            //    string proceso = "";
            //    if (wipControl.ConsumirPorServicioExterno(Codigo, Ubicacion, lblNombre.Text, proceso))
            //    {
            //        if (Ubicacion == "SE002")
            //        {
            //            proceso = "Sunipac";
            //            EnvioCorreo(Ubicacion, lblNombre.Text, Codigo, proceso);
            //        }
            //        else if (Ubicacion == "DSE01")
            //        {
            //            proceso = "Despacho Servicio Externo";
            //            EnvioCorreo(Ubicacion, lblNombre.Text, Codigo, proceso);
            //        }
            //        else if (Ubicacion == "TD001")
            //        {
            //            proceso = "Taller Digital";
            //        }
            //        else if (Ubicacion == "DD003")
            //        {
            //            proceso = "Directo Despacho";
            //        }
            //        Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
            //    }
            //}
            ////Asignar Ubicacion en rack
            //else if (Ubicacion != "TD001" && Ubicacion != "ENC01" && Ubicacion != "SE002" && Ubicacion != "DSE01")
            //{
            //    List<Wip> wp2 = wipControl.ListaMaquinaProceso(1);
            //    if (wp2.Count(o => o.Maquina == Ubicacion) > 0)
            //    {
            //        if (wipControl.AsignarUbicacionPallet(Codigo, Ubicacion, lblNombre.Text))
            //        {
            //            Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
            //        }
            //    }
            //}
            try
            {
                string Codigo = txtCodigo.Text.Trim(); string Ubicacion = txtUbicacion.Text.Trim().ToUpper(); string CodigoMetrics = "";

                CodigoMetrics = wlm.ListaMaquinaProceso(Ubicacion, 1);
                if (CodigoMetrics != "0" && CodigoMetrics != "UNICO")
                {
                    //Asignar Ubicacion en rack
                    if (CodigoMetrics != "TD001" && CodigoMetrics != "ENC01" && CodigoMetrics != "SE002" && CodigoMetrics != "DSE01")
                    {
                        if (wipControl.AsignarUbicacionPallet(Codigo, CodigoMetrics, lblNombre.Text))
                        {
                            Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
                        }
                    }
                }
                //Asignar ubicacion en Servicio Externo
                else if (Ubicacion == "SE002" || Ubicacion == "DSE01" || Ubicacion == "TD001" || Ubicacion == "DD003")
                {
                    string proceso = "";
                    if (wipControl.ConsumirPorServicioExterno(Codigo, Ubicacion, lblNombre.Text, proceso))
                    {
                        if (Ubicacion == "SE002")
                        {
                            proceso = "Sunipac";
                            EnvioCorreo(Ubicacion, lblNombre.Text, Codigo, proceso);
                        }
                        else if (Ubicacion == "DSE01")
                        {
                            proceso = "Despacho Servicio Externo";
                            EnvioCorreo(Ubicacion, lblNombre.Text, Codigo, proceso);
                        }
                        else if (Ubicacion == "TD001")
                        {
                            proceso = "Taller Digital";
                        }
                        else if (Ubicacion == "DD003")
                        {
                            proceso = "Directo Despacho";
                        }
                        Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
                    }
                }
                //Ubicacion Maquinas ENC
                else
                {
                    Wip w2 = wlm.ListaMaquinaENC(Ubicacion, 2);
                    if (w2 != null)
                    {
                        if (wipControl.ConsumirPorEnc(Codigo, w2.ID_Control, lblNombre.Text))
                        {
                            Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('" + ex.ToString() + "');' </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }

        public bool EnvioCorreo(string Destino,string Usuario, string Codigo, string Proceso)
        {
            if (Destino == "SE002")
            {
                Destino = "Sunipac";
            }
            else if (Destino == "DSE01")
            {
                Destino = "Despacho Servico Externo";
            }
            /* Carga de PAra la base de Datos*/
            /*-------------------------MENSAJE DE CORREO----------------------*/
            Wip wip = wipControl.BuscarPallet_Wip(Codigo);
            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add("juan.venegas@aimpresores.cl");
            if (Destino == "Sunipac")
            {
                mmsg.To.Add("envio.sexterno@aimpresores.cl");
            }
            else if (Destino == "Despacho Servico Externo")
            {
                mmsg.To.Add("pallet.despacho@aimpresores.cl");
            }
            //mmsg.To.Add("mariamilagros.paez@aimpresores.cl");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject ="Destino "+Destino+" OT: "+wip.OT+ " Pliego: "+wip.Pliego;
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
                                //"<img src='//"<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +' />" +
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
                            "<td colspan='3'>" + wip.Tiraje.ToString("N0").Replace(",",".")+ "</td>" +
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
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Proveedor</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Codigo Pallet</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Pliego</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Pliego Imp.</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Maquina</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Proceso</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' align='center'>Peso Pallet</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + Destino + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + Codigo + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + wip.Pliego + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;' align='right'>" + wip.PliegosImpresos.ToString("N0").Replace(",",".") + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + wip.Maquina + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + Proceso  + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>"+wip.PesoPallet+"</td>" +
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