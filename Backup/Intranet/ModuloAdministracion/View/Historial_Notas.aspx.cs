using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloEncuadernacion.Model;
using Intranet.ModuloEncuadernacion.Controller;
using Intranet.ModuloAdministracion.Model;
using System.Web.Services;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Historial_Notas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string OT = Request.QueryString["ot"];
                OrdenController oc = new OrdenController();
                Label2.Text = "OT: " + OT + " -  " + oc.Seguimiento_BuscarNM(OT);
                try
                {
                    string mens = Request.QueryString["Mens"];
                    if (mens != null)
                    {
                        TabContainer1.ActiveTabIndex = 1;
                    }
                    else
                    {
                        TabContainer1.ActiveTabIndex = 0;
                    }
                }
                catch
                {
                    TabContainer1.ActiveTabIndex = 0;
                }
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
            Controller_EstadoOT eo = new Controller_EstadoOT();
            lblOT.Text = Request.QueryString["OT"];
            Intranet.ModuloDespacho.Model.Estado_OT et = eo.BuscarOTLiquidar(Request.QueryString["OT"], 1);
            lblNombreOT.Text = et.NombreOT;
            lblCliente.Text = et.Cliente;
            if(et.FechaMaxima!="")
            {
                lblFechaLiqui.Text = Convert.ToDateTime(et.FechaMaxima).ToString("dd-MM-yyyy");
            }

            Controller_Liquidacion controlliqui = new Controller_Liquidacion();
            RadGrid1.DataSource = controlliqui.ListarHistorialLiquidacion(Request.QueryString["OT"]);
            RadGrid1.DataBind();
            RadGrid3.DataSource = controlliqui.ListarHistorialNotas(Request.QueryString["OT"]);
            RadGrid3.DataBind();
            RadGridfacturacion.DataSource = controlliqui.ListarDetalleFacturacion(Request.QueryString["OT"]);
            RadGridfacturacion.DataBind();

            ddlProblema.DataSource = controlliqui.ListarDetalle();
            ddlProblema.DataTextField = "OT";
            ddlProblema.DataValueField = "TotalDesp";
            ddlProblema.DataBind();
            ddlProblema.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));
            ddlProblema.Attributes.Add("disabled", "disabled");

            RadGrid2.DataSource = controlliqui.ListarDespachos(Request.QueryString["OT"], 0);
            RadGrid2.DataBind();

            lblTabla.Text = controlliqui.ListaDetalleDespachos(Request.QueryString["OT"], 1);
            //string CSR = de.NombreOT;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Liquidar liqui = new Liquidar();
            Controller_Liquidacion controlliqui = new Controller_Liquidacion();
            liqui.VerMas = txtObservacion.Text;
            liqui.OT = lblOT.Text;
            liqui.NombreOT = lblNombreOT.Text;
            liqui.Cliente = lblCliente.Text;
            string Responsable = "";
            List<Liquidar> lista = controlliqui.CorreosResposable(ddlProblema.SelectedItem.Text, lblOT.Text);
            int contador = 0;
            foreach (Liquidar li in lista)
            {
                contador++;
                Responsable += li.Accion + ", ";
            } 
            if (contador > 0)
            {
                if (TextBox2.Text != "")
                {
                    liqui.Tiraje = TextBox2.Text;
                }
                else
                {
                    liqui.Tiraje = Responsable.Substring(0, Responsable.Length - 2);//responsable
                }
            }
            else
            {
                liqui.Tiraje = Responsable;
            }
            liqui.Accion = ddlProblema.SelectedItem.Text;//Asunto
            liqui.EstadoOT = Session["Usuario"].ToString();
            liqui.FechaFactura = lblAsunto.Text.Substring(0,lblAsunto.Text.Length-1);//TipoNota
            
            if (liqui.Tiraje != "" && liqui.Accion!="Seleccionar" & liqui.VerMas!="")
            {
                int id= controlliqui.AgregarNota(liqui);
                if (id != 0)
                {
                    GenerarCorreo(liqui.Accion, liqui.VerMas, liqui.OT, liqui.NombreOT, liqui.Cliente, lblFechaLiqui.Text, id);
                    Response.Redirect("Historial_Notas.aspx?OT=" + liqui.OT + "&Mens=OK");
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'>Alert('Error al Ingresar nota, todos los campos son Obligatorios.');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        public bool GenerarCorreo(string Asunto, string comentario, string OT,string NombreOT,string Cliente, string FechaLi, int id)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            Controller_Liquidacion controlliqui = new Controller_Liquidacion();
            if (TextBox2.Text == "")
            {
                List<Liquidar> lista = controlliqui.CorreosResposable(ddlProblema.SelectedItem.Text, lblOT.Text);

                foreach (Liquidar li in lista)
                {
                    mmsg.To.Add(li.Accion);
                }
            }
            else
            {
                try
                {
                    string[] str = TextBox2.Text.Split(',');
                    foreach (string correos in str)
                    {
                        mmsg.To.Add(correos);
                    }
                }
                catch
                {
                    mmsg.To.Add(TextBox2.Text);
                }
                
            }
            //mmsg.To.Add("juan.venegas@aimpresores.cl");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatar

            //Asunto
            mmsg.Subject = Asunto;
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
                    "Estimado(a):" +
                    "<br />" +
                      "<br />" +
                        "<br />" +
                    "Existe un requerimiento desde el area de Facturación," +
                     "<br />" +
                     "<div><div style='background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);"+
                                "background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);font-weight: bold;padding: 5px;border: 1px solid #959595;text-align: left;'>Detalle OP</div>"+
                            "<div style='padding: 10px;border: 1px solid #959595;border-top: 0px;margin-bottom: 2px;'>"+
                        "<table style='width: 100%;'>"+
                            "<tbody><tr>"+
                                "<td>&nbsp;</td>"+
                                "<td style='width:140px;font-weight:bold;'>Numero OT:</td>"+
                                "<td>"+OT+"</td>"+
                                "<td style='width:100px;font-weight:bold;'>Nombre OT:</td>"+
                                "<td>"+NombreOT+"</td>"+
                                "<td>&nbsp;</td>"+
                            "</tr><tr><td>&nbsp;</td><td style='font-weight:bold;'>Fecha Liquidación:</td>"+
                                "<td>"+FechaLi+"</td></tr></tbody></table></div>"+

                        "<div style='background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);" +
                                "background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);font-weight: bold;padding: 5px;border: 1px solid #959595;text-align: left;'>Detalle Problema</div>" +
                        "<div style='padding: 10px;border: 1px solid #959595;border-top: 0px;margin-bottom: 2px;'>" +
                            "<table style='width: 100%;'>"+
                                "<tbody><tr><td style='width:140px;font-weight:bold;'>Observación:</td><td>" + comentario + "</td></tr>"+
                                "<tr><td colspan='2' style='width:140px;font-weight:bold;'>Para Responder Acceda al siguiente link: http://resp_fact.qgchile.cl/index.aspx?soli=" + id + " </td></tr></tbody></table></div>" +
                    
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

        [WebMethod]
        public static string CorreosResponsable(string Problema, string OT)
        {
            Controller_Liquidacion controlliqui = new Controller_Liquidacion();
            List<Liquidar> lista = controlliqui.CorreosResposable(Problema, OT);
            string Correos = "";
            int contador = 0;
            foreach (Liquidar li in lista)
            {
                contador++;
                Correos += li.Accion + ", ";
            }
            if (contador > 0)
            {
                return Correos.Substring(0, Correos.Length - 2);
            }
            else
            {
                return Correos;
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 1;
            CargarDatos();
        }
    }
}