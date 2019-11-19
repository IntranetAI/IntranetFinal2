using MySql.Data.MySqlClient;
using ServicioWeb2.Controllers;
using ServicioWeb2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Services;

namespace ServicioWeb2
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {

            string[] str = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime ft = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
            string[] str2 = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy").Split('/');
            DateTime fi = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

            List<Oportunidades> opo = ListadoOportunidades(fi,ft);
            List<Cuentas> cue = ListadoCuentas(ft,ft);
            List<Reuniones> reu = ListadoReuniones(fi,ft);
            List<Ejecutivos> eje = ListadoEjecutivos();

            string a = correoEjecutivos(opo,eje,reu,cue,fi,ft);
            

                return "OK";
        }
        public string TablaOportunidades(List<Oportunidades> opo, string NombreEjecutivo)
        {
            if (NombreEjecutivo== "Patricio Alcalde")
            {

            }
            string Color = ""; string Contenido = ""; int Contador = 0; Int64 Total = 0;
            string Encabezado = "<h2>Ejecutivo: " + NombreEjecutivo + "</h2>" +
               "<h3 style='color:#003e7e'>Oportunidades</h3>"+
                 "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:990px;margin-left:3px;'>" +
                                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Oportunidad</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Cliente</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Monto</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Etapa Venta</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Cierre</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Producción</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Creación</td>" +
                                "</tr>";
            foreach (var item in opo)
            {
                Total += Convert.ToInt64(item.Monto);
                Color = ((Contador % 2) == 0 ? "#fff": "#f3f4f9" );
                Contenido += "<tr style='height: 22px; background: " + Color + "; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                        item.NombreOportunidad.ToLower() + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                        item.NombreCliente.ToLower() + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                        Convert.ToInt32(item.Monto).ToString("N0").Replace(",",".") + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:80px;'>" +
                      (item.EtapaVentas) + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        Convert.ToDateTime(item.FechaCierre).ToString("dd/MM/yyyy") + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        Convert.ToDateTime(item.FechaProduccion).ToString("dd/MM/yyyy") + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        Convert.ToDateTime(item.FechaCreacion).ToString("dd/MM/yyyy") + "</td>" +
                      "</tr>";
                Contador++;
            }
            string subTotales = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:200px;margin-left:3px;'>" +
                                   "<tbody><tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                     "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Oportunidades</td>" +
                                     "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Monto Total</td>" +
                                     "</tr><tr style='height: 22px; background:#f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                                     Contador.ToString("N0").Replace(",",".") + "</td>" +
                                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                                     Total.ToString("N0").Replace(",",".") + "</td></tr></tbody></table>";
            return Encabezado + Contenido + "<tbody></table>"+subTotales;
        }
        public string TablaReuniones(List<Reuniones> reu, string NombreEjecutivo)
        {
            string Color = ""; string Contenido = ""; int Contador = 0; int Total = 0;string Meta = "";
            string Encabezado = "<h3 style='color:#003e7e'>Reuniones </h3>" +
                 "<table id='tblRegistro2' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:770px;margin-left:3px;'>" +
                                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Asunto</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Estado</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Relación</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Relacionado</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Reunion</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Creación</td>" +
                                "</tr>";
            foreach (var item in reu)
            {
                Color = ((Contador % 2) == 0 ? "#fff": "#f3f4f9");
                Contenido += "<tr style='height: 22px; background: " + Color + "; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                        item.Asunto.ToLower() + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:50px;'>" +
                        item.Estado + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:100px;'>" +
                        item.Relacion + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                      item.relacionado + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        Convert.ToDateTime(item.FechaInicio).ToString("dd/MM/yyyy") + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        Convert.ToDateTime(item.FechaCreacion).ToString("dd/MM/yyyy") + "</td>" +
                      "</tr>";
                Contador++;
            }
            Meta = ((Contador > 0) ? ((Convert.ToDouble(Contador)/10)*100).ToString("N0")+"%" : "0%");
            string subTotales = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:200px;margin-left:3px;'>" +
                                   "<tbody><tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                     "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Reuniones</td>" +
                                     "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Meta Semanal</td>" +
                                     "</tr><tr style='height: 22px; background:#f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                                     Contador.ToString("N0").Replace(",", ".") + "</td>" +
                                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                                     Meta + "</td></tr></tbody></table>";
            return Encabezado + Contenido + "<tbody></table>" + subTotales;
        }
        public string TablaCuentas(List<Cuentas> cue, string NombreEjecutivo)
        {
            string Color = ""; string Contenido = ""; int Contador = 0; int Total = 0;
            string Encabezado = "<h3 style = 'color:#003e7e'> Cuentas </h3>" +
                 "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:620px;margin-left:3px;'>" +
                                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Nombre</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>RUT</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Tipo Cuenta</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Vertical</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Segmento</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Creación</td>" +
                                "</tr>";
            foreach (var item in cue)
            {
                Color = ((Contador % 2) == 0 ? "#fff" : "#f3f4f9");
                Contenido += "<tr style='height: 22px; background: " + Color + "; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                        item.NombreCuenta + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:80px;'>" +
                        item.RUT + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                        item.TipoCuenta + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:100px;'>" +
                      item.Vertical + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                       item.Segmento + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        Convert.ToDateTime(item.FechaCreacion).ToString("dd/MM/yyyy") + "</td>" +
                      "</tr>";
                Contador++;
            }
            string subTotales = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:200px;margin-left:3px;'>" +
                                   "<tbody><tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                     "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Cuentas Nuevas</td>" +
                                     "</tr><tr style='height: 22px; background:#f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                    
                                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                                     Contador.ToString("N0").Replace(",", ".") + "</td></tr></tbody></table>";
            return Encabezado + Contenido + "<tbody></table>" + subTotales;
        }
        public string EnvioCorreoEjecutivos(string Contenido,string ContenidoReuniones,string ContenidoCuentas)
        {
            DateTime ft = DateTime.Now.AddDays(-1);
            DateTime fi = DateTime.Now.AddDays(-7);
            int NumSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(fi, CalendarWeekRule.FirstDay, fi.DayOfWeek);

            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
            mmsg.Body =// "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                "<img src='http://copesa.aimpresores.cl/imagenes/logo_a.png' alt='A Impresores'  width='267px'  height='67px'  />" +
            "<br/>Estimado(a):" +
                        "<br/><br/>Este informe se obtiene de forma automática desde <b>SuiteCRM</b>, siendo esta información correspondiente a la <b>semana " + NumSemana+ "</b> del período <b>" + fi.ToString("dd/MM/yyyy")+ " al " + ft.ToString("dd/MM/yyyy") + "</b>"+
                "<br/>" +
                Contenido+
                ContenidoReuniones+
                ContenidoCuentas+
                        "<br />" +
                        "Atentamente," +
                        "<br />" +
                        "<b>Equipo de desarrollo A Impresores S.A.</b>";

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            mmsg.Subject = "Informe semanal SuiteCRM - Semana "+NumSemana;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.Host = "smtp.office365.com";
            _smtpClient.Port = 587;
            _smtpClient.EnableSsl = true;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "Octubre2019");
            try
            {
                _smtpClient.Send(mmsg);
                return "OK";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return "Error";
            }
        }

        public string EnvioCorreoOportunidadesGerente(string Contenido)
        {
            DateTime ft = DateTime.Now.AddDays(-1);
            DateTime fi = DateTime.Now.AddDays(-7);
            int NumSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(fi, CalendarWeekRule.FirstDay, fi.DayOfWeek);

            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
            mmsg.Body =// "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                "<img src='http://copesa.aimpresores.cl/imagenes/logo_a.png' alt='A Impresores'  width='267px'  height='67px'  />" +
            "<br/>Estimado(a):" +
                        "<br/><br/>Este informe se obtiene de forma automática desde <b>SuiteCRM</b>, siendo esta información correspondiente a la <b>semana " + NumSemana + "</b> del período <b>" + fi.ToString("dd/MM/yyyy") + " al " + ft.ToString("dd/MM/yyyy") + "</b>" +
                "<br/>" +
                Contenido +
                        "<br />" +
                        "Atentamente," +
                        "<br />" +
                        "<b>Equipo de desarrollo A Impresores S.A.</b>";

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            mmsg.Subject = "Informe Semanal Oportunidades SuiteCRM - Semana " + NumSemana;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.Host = "smtp.office365.com";
            _smtpClient.Port = 587;
            _smtpClient.EnableSsl = true;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "Octubre2019");
            try
            {
                _smtpClient.Send(mmsg);
                return "OK";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return "Error";
            }
        }
        public string EnvioCorreoReunionesGerente(string Contenido)
        {
            DateTime ft = DateTime.Now.AddDays(-1);
            DateTime fi = DateTime.Now.AddDays(-7);
            int NumSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(fi, CalendarWeekRule.FirstDay, fi.DayOfWeek);

            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
            mmsg.Body =// "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                "<img src='http://copesa.aimpresores.cl/imagenes/logo_a.png' alt='A Impresores'  width='267px'  height='67px'  />" +
            "<br/>Estimado(a):" +
                        "<br/><br/>Este informe se obtiene de forma automática desde <b>SuiteCRM</b>, siendo esta información correspondiente a la <b>semana " + NumSemana + "</b> del período <b>" + fi.ToString("dd/MM/yyyy") + " al " + ft.ToString("dd/MM/yyyy") + "</b>" +
                "<br/>" +
                Contenido +
                        "<br />" +
                        "Atentamente," +
                        "<br />" +
                        "<b>Equipo de desarrollo A Impresores S.A.</b>";

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            mmsg.Subject = "Informe Semanal Reuniones SuiteCRM - Semana " + NumSemana;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.Host = "smtp.office365.com";
            _smtpClient.Port = 587;
            _smtpClient.EnableSsl = true;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "Octubre2019");
            try
            {
                _smtpClient.Send(mmsg);
                return "OK";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return "Error";
            }
        }
        public string EnvioCorreoCuentasGerente(string Contenido)
        {
            DateTime ft = DateTime.Now.AddDays(-1);
            DateTime fi = DateTime.Now.AddDays(-7);
            int NumSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(fi, CalendarWeekRule.FirstDay, fi.DayOfWeek);

            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
            mmsg.Body =// "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                "<img src='http://copesa.aimpresores.cl/imagenes/logo_a.png' alt='A Impresores'  width='267px'  height='67px'  />" +
            "<br/>Estimado(a):" +
                        "<br/><br/>Este informe se obtiene de forma automática desde <b>SuiteCRM</b>, siendo esta información correspondiente a la <b>semana " + NumSemana + "</b> del período <b>" + fi.ToString("dd/MM/yyyy") + " al " + ft.ToString("dd/MM/yyyy") + "</b>" +
                "<br/>" +
                Contenido +
                        "<br />" +
                        "Atentamente," +
                        "<br />" +
                        "<b>Equipo de desarrollo A Impresores S.A.</b>";

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            mmsg.Subject = "Informe Semanal Cuentas SuiteCRM - Semana " + NumSemana;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.Host = "smtp.office365.com";
            _smtpClient.Port = 587;
            _smtpClient.EnableSsl = true;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "Octubre2019");
            try
            {
                _smtpClient.Send(mmsg);
                return "OK";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return "Error";
            }
        }

        public string correoEjecutivos(List<Oportunidades> opo,List<Ejecutivos> eje,List<Reuniones> reu,List<Cuentas> cue, DateTime fi,DateTime ft)
        {
            try
            {


                string ContenidoOportunidades = "";string ContenidoReuniones = "";string ContenidoCuentas = "";string ContenidoOpoGerentes = ""; string ContenidoReuGerentes = ""; string ContenidoCueGerentes = "";
                string OpoGerenciaVentasEditoriales = "<h1>Gerencia de Ventas Editoriales</h1>"; string OpoGerenciaNuevosNegocios = "<h2>Gerencia de Nuevos Negocios</h2>"; string OpoSubgerenciaDigital = "<h2>Subgerencia Digital</h2>";
                string ReuGerenciaVentasEditoriales = "<h1>Gerencia de Ventas Editoriales</h1>"; string ReuGerenciaNuevosNegocios = "<h2>Gerencia de Nuevos Negocios</h2>"; string ReuSubgerenciaDigital = "<h2>Subgerencia Digital</h2>";
                string  GeneralCuentasGerentes = "<br/><h3 style = 'color:#003e7e'> Resumen Reuniones </h3>" +
                        "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:400px;margin-left:3px;'>" +
                                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:200px;'>Ejecutivo</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:10px;'>Reuniones</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Meta Semanal</td>" +
                                "</tr>";
                string GeneralOportunidadesGerentes = "<br/><h3 style = 'color:#003e7e'> Resumen Reuniones </h3>" +
                        "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:400px;margin-left:3px;'>" +
                                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:200px;'>Ejecutivo</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:10px;'>Oportunidades</td>" +
                                  "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Monto Total</td>" +
                                "</tr>";
                double ContadorNN = 0; double ContadorVE = 0; double ContadorID = 0; string GeneralCuentasGerentesVE = ""; string GeneralCuentasGerentesNN = ""; string GeneralCuentasGerentesID = "";
                string GeneralOportunidadesGerentesVE = ""; string GeneralOportunidadesGerentesNN = ""; string GeneralOportunidadesGerentesID = "";int contadorOPONN = 0;Int64 TotalOPONN = 0; int contadorOPOVE = 0; Int64 TotalOPOVE = 0; int contadorOPOID = 0; Int64 TotalOPOID = 0;

                if (opo.Count > 0)
                {
                    foreach (var it in eje)
                    {
                        ContenidoOportunidades = TablaOportunidades(opo.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList(), it.NombreEjecutivo);
                        ContenidoReuniones = TablaReuniones(reu.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList(), it.NombreEjecutivo);
                        ContenidoCuentas = TablaCuentas(cue.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList(), it.NombreEjecutivo);
                        EnvioCorreoEjecutivos(ContenidoOportunidades, ContenidoReuniones, ContenidoCuentas);
                        //ContenidoOpoGerentes += ContenidoOportunidades;
                        //ContenidoReuGerentes += "<h2>Ejecutivo: " + it.NombreEjecutivo + "</h2>" + ContenidoReuniones;
                        ContenidoCueGerentes += "<h2>Ejecutivo: " + it.NombreEjecutivo + "</h2>" + ContenidoCuentas;
                        double CantReuniones = reu.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList().Count();
                        double CantOport= opo.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList().Count();
                        Int64 MontoOport = 0;
                        if(it.UsuarioEjecutivo != "patricio.alcalde@aimpresores.cl")
                        {
                            MontoOport = opo.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList().Sum(p => p.Monto);
                        }
                        else
                        {
                            try
                            {
                                MontoOport = opo.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList().Sum(p => p.Monto);
                            }
                            catch (Exception ex)
                            {

                            }

                        }
                        if (it.UsuarioEjecutivo == "patricio.alcalde@aimpresores.cl" || it.UsuarioEjecutivo == "andrea.vinagre@aimpresores.cl" || it.UsuarioEjecutivo == "ronald.black@aimpresores.cl" || it.UsuarioEjecutivo == "juan.beheran@aimpresores.cl" || it.UsuarioEjecutivo == "michaela.schauerova@aimpresores.cl" || it.UsuarioEjecutivo == "isabel.balbontin@aimpresores.cl")
                        {
                            OpoGerenciaVentasEditoriales += ContenidoOportunidades.Replace("<h3 style='color:#003e7e'>Oportunidades</h3>", "");
                            ReuGerenciaVentasEditoriales += "<h2>Ejecutivo: " + it.NombreEjecutivo + "</h2>" + ContenidoReuniones.Replace("<h3 style='color:#003e7e'>Reuniones </h3>", "");
                            ContadorVE += reu.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList().Count();
                            contadorOPOVE += Convert.ToInt32(CantOport);
                            TotalOPOVE += MontoOport;
                             

                            //SUBTOTAL REUNIONES
                            GeneralCuentasGerentesVE += "<tr style='height: 22px; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              it.NombreEjecutivo + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              Convert.ToInt32(CantReuniones).ToString("N0") + " </td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              ((CantReuniones > 0) ? ((CantReuniones / 10) * 100).ToString("N0") + "%" : "0%") + " </td></tr>";
                            //SUBTOTAL OPORTUNIDADES
                            GeneralOportunidadesGerentesVE += "<tr style='height: 22px; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              it.NombreEjecutivo + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             CantOport.ToString("N0") + " </td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              MontoOport.ToString("N0").Replace(",",".") + "</td></tr>";


                        }
                        else if (it.UsuarioEjecutivo == "mariajose.ricaurte@aimpresores.cl")
                        {
                            OpoSubgerenciaDigital += ContenidoOportunidades.Replace("<h3 style='color:#003e7e'>Oportunidades</h3>", "");
                            ReuSubgerenciaDigital += "<h2>Ejecutivo: " + it.NombreEjecutivo + "</h2>" + ContenidoReuniones.Replace("<h3 style='color:#003e7e'>Reuniones </h3>", "");
                            ContadorID += reu.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList().Count();
                            contadorOPOID += Convert.ToInt32(CantOport);
                            TotalOPOID += MontoOport;

                            GeneralCuentasGerentesID += "<tr style='height: 22px; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              it.NombreEjecutivo + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              Convert.ToInt32(CantReuniones).ToString("N0") + " </td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              ((CantReuniones > 0) ? ((CantReuniones / 10) * 100).ToString("N0") + "%" : "0%") + " </td></tr>";

                            //SUBTOTAL OPORTUNIDADES
                            GeneralOportunidadesGerentesID += "<tr style='height: 22px; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              it.NombreEjecutivo + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             CantOport.ToString("N0") + " </td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              MontoOport.ToString("N0").Replace(",", ".")+" </td></tr>";
                        }
                        else
                        {
                            OpoGerenciaNuevosNegocios += ContenidoOportunidades.Replace("<h3 style='color:#003e7e'>Oportunidades</h3>", "");
                            ReuGerenciaNuevosNegocios += "<h2>Ejecutivo: " + it.NombreEjecutivo + "</h2>" + ContenidoReuniones.Replace("<h3 style='color:#003e7e'>Reuniones </h3>", "");
                            ContadorNN += reu.Where(x => x.Asignado == it.UsuarioEjecutivo).ToList().Count();
                            contadorOPONN += Convert.ToInt32(CantOport);
                            TotalOPONN += MontoOport;

                            GeneralCuentasGerentesNN += "<tr style='height: 22px;font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              it.NombreEjecutivo + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              Convert.ToInt32(CantReuniones).ToString("N0") + " </td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              ((CantReuniones > 0) ? ((CantReuniones / 10) * 100).ToString("N0") + "%" : "0%") + " </td></tr>";

                            //SUBTOTAL OPORTUNIDADES
                            GeneralOportunidadesGerentesNN += "<tr style='height: 22px; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              it.NombreEjecutivo + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             CantOport.ToString("N0") + " </td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              MontoOport.ToString("N0").Replace(",", ".")+"</td></tr>";
                        }
                        //Total Resumen Reuniones
                        

                    }

                    //      Color = ((Contador % 2) == 0 ? "#fff" : "#f3f4f9");ss
                    double a = reu.ToList().Count();
                    double b = eje.ToList().Count();
                    double ab = ((ContadorNN / 60) * 100);
                    double Totales = (a / (b * 10)) * 100;
                    string SubTotalNN = "<tr style='height: 22px; background: #dadbe0; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              "<b>Gerencia de Nuevos Negocios</b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              "<b>"+ContadorNN.ToString() + " </b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + ((ContadorNN/30)*100).ToString("N0") + "% </b></td></tr>";
                    string SubTotalVE = "<tr style='height: 22px; background:#dadbe0 ; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              "<b>Gerencia de Ventas Editoriales</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + ContadorVE.ToString() + " </b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + ((ContadorVE / 60) * 100).ToString("N0") + "% </b></td></tr>";
                    string SubTotalID = "<tr style='height: 22px; background:#dadbe0 ; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              "<b>SubGerencia Digital</b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + ContadorID.ToString() + " </b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + ((ContadorID / 10) * 100).ToString("N0") + "% </b></td></tr>";

                    //TOTALES OPORTUNIDADES
                    string SubTotalOPONN = "<tr style='height: 22px; background: #dadbe0; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              "<b>Gerencia de Nuevos Negocios</b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                              "<b>" + contadorOPONN.ToString() + " </b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + (TotalOPONN).ToString("N0") + "</b></td></tr>";
                    string SubTotalOPOVE = "<tr style='height: 22px; background:#dadbe0 ; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              "<b>Gerencia de Ventas Editoriales</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + contadorOPOVE.ToString() + " </b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + (TotalOPOVE).ToString("N0") + "</b></td></tr>";
                    string SubTotalOPOID = "<tr style='height: 22px; background:#dadbe0 ; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                              "<b>SubGerencia Digital</b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + contadorOPOID.ToString() + " </b></td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                             "<b>" + (TotalOPOID).ToString("N0") + "</b></td></tr>";


                    GeneralCuentasGerentes += GeneralCuentasGerentesVE + SubTotalVE + GeneralCuentasGerentesNN + SubTotalNN + GeneralCuentasGerentesID + SubTotalID + "<tr style='height: 22px; background:#dadbe0 ; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                           "<b>TOTAL GERENCIAS </b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                           "<b>" + reu.ToList().Count().ToString() + " </b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                           "<b>" + Totales.ToString("N0") + "%" + " </b></td></tr>";

                    GeneralOportunidadesGerentes += GeneralOportunidadesGerentesVE + SubTotalOPOVE + GeneralOportunidadesGerentesNN + SubTotalOPONN + GeneralOportunidadesGerentesID + SubTotalOPOID + "<tr style='height: 22px; background:#dadbe0 ; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:200px;'>" +
                           "<b>TOTAL GERENCIAS </b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                           "<b>" + opo.ToList().Count().ToString() + " </b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                           "<b>" + opo.ToList().Sum(x=>x.Monto).ToString("N0").Replace(",",".") +"</b></td></tr>";

                    EnvioCorreoOportunidadesGerente(OpoGerenciaVentasEditoriales + "<br/><br/>" + OpoGerenciaNuevosNegocios + "<br/><br/>" + OpoSubgerenciaDigital + GeneralOportunidadesGerentes + "</tbody></table>");
                    EnvioCorreoReunionesGerente(ReuGerenciaVentasEditoriales + "<br/><br/>" + ReuGerenciaNuevosNegocios + "<br/><br/>" + ReuSubgerenciaDigital + GeneralCuentasGerentes + "</tbody></table>");
                        EnvioCorreoCuentasGerente(ContenidoCueGerentes);
                    
                }
                else
                {
                    return "Error";
                }                         
            }
            catch
            {
                return "Error";
            }
            return "";
        }
        
        public List<Ejecutivos> ListadoEjecutivos()
        {
            List<Ejecutivos> Ejecutivos = new List<Ejecutivos>();
            try
            {
                MySqlConnection connection = new MySqlConnection("Database=crm_db;Data Source=172.16.1.8;User Id=root;Password=daco2018.");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select user_name as Asignado,concat(first_name,' ', last_name) as NombreEjecutivo from users where employee_status='Active' and user_name not in ('admin','araldo.hinrichsen@aimpresores.cl','prueba','juanpablo.allamand@aimpresores.cl','alejandro.garces@aimpresores.cl','cjerias','alfred.east@aimpresores.cl')";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ejecutivos op = new Ejecutivos();
                    op.UsuarioEjecutivo = reader["Asignado"].ToString();
                    op.NombreEjecutivo= reader["NombreEjecutivo"].ToString();

                    Ejecutivos.Add(op);
                }
                reader.Close();
            }
            catch
            {

            }
            return Ejecutivos;
        }
        public List<Oportunidades> ListadoOportunidades(DateTime fi,DateTime ft)
        {
            List<Oportunidades> Oportunidades = new List<Oportunidades>();
            try
            {
                MySqlConnection connection = new MySqlConnection("Database=crm_db;Data Source=172.16.1.8;User Id=root;Password=daco2018.;CharSet=utf8;");
   
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select nombre, monto, nombrecuenta, EtapaVenta, asignado, FechaCreacion, FechaProduccion, fechaCierre from cjr_Oportunidades_v2 " +
                                           " where fechacreacion between '"+fi.ToString("yyyy/MM/dd")+"' and '"+ft.ToString("yyyy/MM/dd") + "' ";//and asignado = 'ronald.black@aimpresores.cl'
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Oportunidades op = new Oportunidades();
                    op.NombreOportunidad = reader["nombre"].ToString();
                    op.NombreCliente = reader["nombrecuenta"].ToString();
                    op.Monto = Convert.ToInt32(reader["monto"].ToString());
                    op.EtapaVentas = reader["EtapaVenta"].ToString();
                    op.FechaCierre = Convert.ToDateTime(reader["fechaCierre"].ToString());
                    op.FechaProduccion = Convert.ToDateTime(reader["FechaProduccion"].ToString());
                    op.Asignado = reader["asignado"].ToString();
                    op.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    Oportunidades.Add(op);
                }
                reader.Close();
            }
            catch
            {

            }
            return Oportunidades;
        }
        public List<Cuentas> ListadoCuentas(DateTime fi, DateTime ft)
        {
            List<Cuentas> Cuentas = new List<Cuentas>();
            try
            {
                MySqlConnection connection = new MySqlConnection("Database=crm_db;Data Source=172.16.1.8;User Id=root;Password=daco2018.");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = " select name as nombreCuenta,rut,TipoCuenta,vertical_c,segmento_c,asignado,FechaCreacion from cjr_Cuentas_v2 "+
                                        "where fechacreacion between '" + fi.ToString("yyyy/MM/dd") + "' and '" + ft.ToString("yyyy/MM/dd") + "' ";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cuentas op = new Cuentas();
                    op.NombreCuenta = reader["nombreCuenta"].ToString();
                    op.RUT = reader["rut"].ToString();
                    op.TipoCuenta = reader["TipoCuenta"].ToString();
                    op.Vertical = reader["vertical_c"].ToString();
                    op.Segmento = reader["segmento_c"].ToString();
                    op.Asignado = reader["asignado"].ToString();
                    op.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    Cuentas.Add(op);
                }
                reader.Close();
            }
            catch
            {

            }
            return Cuentas;
        }
        public List<Reuniones> ListadoReuniones(DateTime fi, DateTime ft)
        {
            List<Reuniones> Reuniones = new List<Reuniones>();
            try
            {
                MySqlConnection connection = new MySqlConnection("Database=crm_db;Data Source=172.16.1.8;User Id=root;Password=daco2018.");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "  select asunto,estado,relacion,asociado as relacionado,FechaInicio,Asignado,FechaCreacion from cjr_Reuniones_v2 where fechacreacion between '" + fi.ToString("yyyy/MM/dd") + "' and '" + ft.ToString("yyyy/MM/dd") + "' ";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Reuniones op = new Reuniones();
                    op.Asunto = reader["asunto"].ToString();
                    op.Estado = reader["estado"].ToString();
                    op.Relacion = reader["relacion"].ToString();
                    op.relacionado = reader["relacionado"].ToString();
                    op.FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString());
                    op.Asignado = reader["asignado"].ToString();
                    op.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    Reuniones.Add(op);
                }
                reader.Close();
            }
            catch
            {

            }
            return Reuniones;
        }
    }
}
