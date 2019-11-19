using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Controller
{
    public class PapelController
    {
        public string GenerarCorreoConsumoPapel(string Usuario)
        {
            try
            {
                string[] str = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                DateTime ft = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 23:59:59");
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                mmsg.To.Add("claudio.bravo@aimpresores.cl");
                mmsg.To.Add("cristopher.tarifeno@aimpresores.cl");
                //mmsg.To.Add("francisco.depablo@aimpresores.cl");
                mmsg.To.Add("consumo.papel.bobinas@aimpresores.cl");
                mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                            "<br/><br/>Estimado(a):" +
                            "<br/><br/>Este informe se obtiene de forma automática desde el control de Consumo de Papel (Metrics Volume), siendo esta información correspondiente al día de ayer." +
                            "<br/><br/>" +
                            "<br/><br/>" +
                            ConsumoPapel(fi,ft) +
                            "<br />" +
                            "Atentamente," +
                            "<br />" +
                            "<b>Equipo de desarrollo A Impresores S.A.</b>";

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Informe de Consumo Papel " + fi.ToString("dd/MM/yyyy");
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials =
                    new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");

                cliente.Host = "mail.aimpresores.cl";
                try
                {
                    cliente.Send(mmsg);
                    return "OK";
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    return "Error";
                }
            }
            catch (Exception e)
            {
                string NombreProcedure0 = e.StackTrace.ToString().Substring(e.StackTrace.ToString().IndexOf("ProduccionController.") + 21, e.StackTrace.Length - (e.StackTrace.ToString().IndexOf("ProduccionController.") + 21));
                string NombreProcedure = NombreProcedure0.Substring(0, NombreProcedure0.IndexOf("("));
               // GenerarCorreoErrordeEnvio("GenerarCorreoComparativo", "Especifico", NombreProcedure, TipoCorreo + "," + fi.ToString("dd-MM.yyyy") + "," + ft.ToString("dd-MM-yyyy HH:mm:ss") + "," + Procedimiento, e.Message);
                return "Error Enviado";
            }
        }



        public string ConsumoPapel(DateTime FI,DateTime FT)
        {
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1528px;margin-left:3px;'>" +
                                  "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>OT</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:240px;'>Nombre OT</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Bobina</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>SKU</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:360px;'>Material</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Alto</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Ancho</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Gramaje</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Cantidad</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>Unidad</td>" +
                                    //"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Valor</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Operacion</td>" +
                                    //"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:cs enter;width:110px;'>Fecha</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Usuario</td>" +
                                  "</tr>";
            string Contenido = "";int Contador = 1;string Color = "";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                if (cmd != null)
                {
                    cmd.CommandText = "[Correo_Transacciones_Papel]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", FI);
                    cmd.Parameters.AddWithValue("@FechaTermino", FT);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Color = ((Contador % 2) == 0 ? "#f3f4f9" : "#fff");

                        Contenido = Contenido + "<tr style='height: 22px; background: " + Color + "; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>" +
                       reader["Numordem"].ToString().ToLower() + "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:82px;'>" +
                       reader["Descricao"].ToString().ToLower() + "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                       reader["idBobina"].ToString() + "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:60px;'>" +
                       reader["ExtRef"].ToString() + "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:360px;'>" +
                       reader["Material"].ToString().ToLower() + "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                       reader["Height"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:50px;'>" +
                        reader["Width"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:50px;'>" +
                        reader["Gramaje"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                        Convert.ToDouble(reader["Consumo"].ToString()).ToString("N2") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:40px;'>" +
                        reader["UnidadeEst"].ToString() + "</td>" +
                        //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                        //Convert.ToDouble(reader["valor"].ToString()).ToString("N2") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                        reader["Name"].ToString().ToLower() + "</td>" +
                        //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        //Convert.ToDateTime(reader["DtExecucao"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                        reader["InsUser"].ToString() + "</td>" +
                        "</tr>";
                        Contador++;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            
            conexion.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }















        //CORREO CONSUMO FL

        public bool GenerarCorreoConsumoPapelFL(string Usuario)
        {
            try
            {
                string[] str = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                DateTime ft = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 23:59:59");

                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                mmsg.To.Add("claudio.bravo@aimpresores.cl");
                mmsg.To.Add("francisco.depablo@aimpresores.cl");
                mmsg.To.Add("cristopher.tarifeno@aimpresores.cl");
                mmsg.To.Add("rafael.maroto@aimpresores.cl");
                mmsg.To.Add("nicolas.makuc@aimpresores.cl");
                

                mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                            "<br/><br/>Estimado(a):" +
                            "<br/><br/>Este informe se obtiene de forma automática desde el control de Consumo de Papel (Metrics Volume), siendo esta información correspondiente al día de ayer." +
                            "<br/><br/>" +
                            StockFL(DateTime.Now, DateTime.Now)+
                            ConsumoPapelFL(fi, ft) +
                            "<br />" +
                            "Atentamente," +
                            "<br />" +
                            "<b>Equipo de desarrollo A Impresores S.A.</b>";

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Informe de Consumo Papel FL " + fi.ToString("dd/MM/yyyy");
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials =
                    new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");

                cliente.Host = "mail.aimpresores.cl";
                try
                {
                    cliente.Send(mmsg);
                    return true;
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                string NombreProcedure0 = e.StackTrace.ToString().Substring(e.StackTrace.ToString().IndexOf("ProduccionController.") + 21, e.StackTrace.Length - (e.StackTrace.ToString().IndexOf("ProduccionController.") + 21));
                string NombreProcedure = NombreProcedure0.Substring(0, NombreProcedure0.IndexOf("("));
                // GenerarCorreoErrordeEnvio("GenerarCorreoComparativo", "Especifico", NombreProcedure, TipoCorreo + "," + fi.ToString("dd-MM.yyyy") + "," + ft.ToString("dd-MM-yyyy HH:mm:ss") + "," + Procedimiento, e.Message);
                return false;
            }
        }
        public string ConsumoPapelFL(DateTime FI, DateTime FT)
        {
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1528px;margin-left:3px;'>" +
                                  "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>OT</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:240px;'>Nombre OT</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>SKU</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:360px;'>Material</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Alto</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Ancho</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Gramaje</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Cantidad</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>Unidad</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Centro Costo</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Operacion</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Usuario</td>" +
                                  "</tr>";
            string Contenido = ""; int Contador = 1; string Color = "";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                if (cmd != null)
                {
                    cmd.CommandText = "[Correo_Transacciones_PapelFL]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", FI);
                    cmd.Parameters.AddWithValue("@FechaTermino", FT);
                    cmd.Parameters.AddWithValue("@Procedimiento", 0);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Color = ((Contador % 2) == 0 ? "#f3f4f9" : "#fff");

                        Contenido = Contenido + "<tr style='height: 22px; background: " + Color + "; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>" +
                       reader["Numordem"].ToString().ToLower() + "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:82px;'>" +
                       reader["NombreoT"].ToString().ToLower() + "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:60px;'>" +
                       reader["coditem"].ToString() + "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:360px;'>" +
                       reader["material"].ToString().ToLower() + "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                       reader["largo"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:50px;'>" +
                        reader["ancho"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:50px;'>" +
                        reader["gramaje"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                        Convert.ToInt32(reader["cantidad"].ToString()).ToString("N0").Replace(",",".") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:40px;'>" +
                        "FL</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                        reader["centrocosto"].ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                        reader["transaccion"].ToString().ToLower() + "</td>" +
                        //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                        //Convert.ToDateTime(reader["DtExecucao"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                        reader["usuario"].ToString() + "</td>" +
                        "</tr>";
                        Contador++;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            conexion.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }
        public string StockFL(DateTime FI, DateTime FT)
        {
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:450px;margin-left:3px;'>" +
                                  "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>SKU Activos</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Pliegos</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Kilos</td>" +
                                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:120px;'>Valor Total</td>" +

                                  "</tr>";
            string Contenido = ""; int Contador = 1; string Color = "";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                if (cmd != null)
                {
                    cmd.CommandText = "[Correo_Transacciones_PapelFL]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", FI);
                    cmd.Parameters.AddWithValue("@FechaTermino", FT);
                    cmd.Parameters.AddWithValue("@Procedimiento", 1);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Color = ((Contador % 2) == 0 ? "#f3f4f9" : "#fff");

                        Contenido = Contenido + "<tr style='height: 22px; background: " + Color + "; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:88px;'>" +
                       Convert.ToInt32(reader["Activos"].ToString()).ToString("N0").Replace(",",".") + "&nbsp;</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:82px;'>" +
                       Convert.ToInt32(reader["Pliego"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                       Convert.ToInt32(reader["KG"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:120px;'>" +
                       "$ "+Convert.ToInt32(reader["Valor"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +

                        "</tr>";
                        Contador++;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            conexion.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }
    }
}