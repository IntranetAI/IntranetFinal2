using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ServicioWeb.ModuloProduccion.Model;

namespace ServicioWeb.ModuloProduccion.Controller
{
    public class ProduccionController
    {
        public bool GenerarCorreoErrordeEnvio(string NombreCorreo, string TipoError, string NomProcedimiento, string Variables, string Error)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("claudio.valle@aimpresores.cl");
            //mmsg.To.Add("juan.venegas@aimpresores.cl");
            //mmsg.To.Add("carlos.jerias.r@aimpresores.cl");

            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1172px;margin-left:3px;'>" +
              "<thead><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='15'>Error Correo</td></tr>" +
                  "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    "Tipo Correo</td> " +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    "Tipo Error</td> " +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:83px;'>" +
                    "Nombre Procedimiento.</td> " +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:83px;'>" +
                    "Variables</td> " +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                 "   Motivo</td>" +
              "</tr></thead>";
            #endregion;

            mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                        "<br/><br/>Estimados " +

                "<br/><br/>" +
                        "<br/><br/>" +
                        Encabezado +
                        "<tbody><tr>" +
                            "<td>" + NombreCorreo + "</td>" +
                            "<td>" + TipoError + "</td>" +
                            "<td>" + NomProcedimiento + "</td>" +
                            "<td>" + Variables + "</td>" +
                            "<td>" + Error + "</td>" +
                        "</tr></tbody></table>" +
                        "<br/>" +

                        "<br/>" +
                        "<br />" +
                        "Atentamente," +
                        "<br />" +
                        "<b>Equipo de desarrollo A Impresores S.A.</b>";

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            mmsg.Subject = "Informe de Error de Correo";
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

        public string Produccion_CorreoComparativo_TeoricoReal(string Area, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = ""; string SectorAnt = ""; double OTS = 0; double Pliegos = 0; double TotalPlanificado = 0; double TotalProducido = 0;
            double Planificado = 0; double Producido = 0; double TeoricoPreparacion = 0; double MalosPreparacion = 0; double TotalTeoricoPreparacion = 0;
            double TotalMalosPreparacion = 0; double TeoricoTiraje = 0; double MalosTiraje = 0; double TotalTeoricoTiraje = 0; double TotalMalosTiraje = 0;
            string PorcProduccion = ""; string PorcMalosPreparacion = ""; string porcMalosTiraje = ""; double ValorProxKG = 0;
            double Costosobreimpresion = 0; double TotalCostoSobreImp = 0;
            double CantSobreImpresion = 0;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_CorreoComparativo_RealTeorico]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", "");
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@FechaTermino", FechaInicio.ToString("yyyy-MM-dd" + " 23:59:59"));
                cmd.Parameters.AddWithValue("@Procedimiento", 0);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (SectorAnt == "" || SectorAnt == reader["Maquina"].ToString())
                    {
                        Planificado = Convert.ToDouble(reader["Planificado"].ToString());
                        TotalPlanificado += Convert.ToDouble(reader["Planificado"].ToString());
                        Producido = Convert.ToDouble(reader["Giros"].ToString());
                        TotalProducido += Convert.ToDouble(reader["Giros"].ToString());
                        TeoricoPreparacion = Convert.ToDouble(reader["TeoricaPreparacion"].ToString());
                        TotalTeoricoPreparacion += Convert.ToDouble(reader["TeoricaPreparacion"].ToString());
                        MalosPreparacion = Convert.ToDouble(reader["MalosPreparacion"].ToString());
                        TotalMalosPreparacion += Convert.ToDouble(reader["MalosPreparacion"].ToString());
                        TeoricoTiraje = Convert.ToDouble(reader["TeoricaTiraje"].ToString());
                        TotalTeoricoTiraje += Convert.ToDouble(reader["TeoricaTiraje"].ToString());
                        MalosTiraje = Convert.ToDouble(reader["MalosTiraje"].ToString());
                        TotalMalosTiraje += Convert.ToDouble(reader["MalosTiraje"].ToString());

                        if (SectorAnt == "" || SectorAnt != reader["Maquina"].ToString())
                        {
                            Contenido = Contenido + Encabezado(reader["Maquina"].ToString(), Procedimiento);
                        }
                        if (Planificado > 0)
                        {
                            PorcProduccion = (Producido - Planificado).ToString("N0").Replace(",", ".") + " (" + (((Producido - Planificado) / (Planificado)) * 100).ToString("N2") + "%)";
                            if ((Producido - Planificado) > 0)
                            {
                                CantSobreImpresion += (Producido - Planificado);
                            }
                        }
                        else
                        {
                            PorcProduccion = "0,00%";
                        }
                        if (TeoricoPreparacion > 0)
                        {
                            PorcMalosPreparacion = (MalosPreparacion - TeoricoPreparacion).ToString("N0").Replace(",", ".") + " (" + (((MalosPreparacion - TeoricoPreparacion) / (TeoricoPreparacion)) * 100).ToString("N2") + "%)";
                        }
                        else
                        {
                            PorcMalosPreparacion = "0,00%";
                        }
                        if (TeoricoTiraje > 0)
                        {
                            porcMalosTiraje = (MalosTiraje - TeoricoTiraje).ToString("N0").Replace(",", ".") + " (" + (((MalosTiraje - TeoricoTiraje) / (TeoricoTiraje)) * 100).ToString("N2") + "%)";
                        }
                        else
                        {
                            porcMalosTiraje = "0,00%";
                        }
                        if (reader["CodItem"].ToString() != "")
                        {
                            ValorProxKG = Convert.ToDouble(reader["CodItem"].ToString());
                            if ((Producido - Planificado) > 0)
                            {
                                Costosobreimpresion = Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["QtdePapelUnidade1"].ToString()) / Convert.ToInt32(Producido)) * (Producido - Planificado)) * ValorProxKG);
                            }
                            else
                            {
                                Costosobreimpresion = 0;
                            }
                            TotalCostoSobreImp += Costosobreimpresion;
                        }
                        string CostoPesos = "";
                        if (Procedimiento == 0)
                        {
                            CostoPesos = "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>$" +
                           Costosobreimpresion.ToString("N2") + "</td>";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td styl  e='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                           reader["OT"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:243px;'>" +
                           reader["NombreOT"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                           reader["Pliego"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Planificado.ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Producido.ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           PorcProduccion + "</td>" +

                           //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;width:73px;'>" +
                            //Convert.ToDouble(reader["MalosPreparacion"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Convert.ToDouble(reader["Wip_PliegosWip"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;width:210px;'>" +
                            reader["DescPapel"].ToString() + "</td>" +
                            CostoPesos +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["QtdePapelUnidade1"].ToString()).ToString("N2") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //TeoricoPreparacion.ToString("N0").Replace(",", ".") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //MalosPreparacion.ToString("N0").Replace(",", ".") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //PorcMalosPreparacion + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //TeoricoTiraje.ToString("N0").Replace(",", ".") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //MalosTiraje.ToString("N0").Replace(",", ".") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //porcMalosTiraje + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:100px;'>" +
                           reader["Operador"].ToString().ToLower() + "</td>" +
                           "</tr>";
                        SectorAnt = reader["Maquina"].ToString();
                    }
                    else
                    {
                        string CostoPesosF = "";
                        if (Procedimiento == 0)
                        {
                            CostoPesosF = "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>$" +
                            TotalCostoSobreImp.ToString("N2") + "</td>";
                        }
                        //Totales
                        Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                           "<b>TOTALES:</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:243px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           "<b>" + TotalPlanificado.ToString("N0").Replace(",", ".") + "</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           "<b>" + TotalProducido.ToString("N0").Replace(",", ".") + "</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           CantSobreImpresion.ToString("N0").Replace(",", ".") + "</td>" +

                           //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:73px;'></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:210px;'>" +
                            "</td>" +
                            CostoPesosF +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                             "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //"<b>" + TotalTeoricoPreparacion.ToString("N0").Replace(",", ".") + "</b></td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //"<b>" + TotalMalosPreparacion.ToString("N0").Replace(",", ".") + "</b></td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //"%</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //"<b>" + TotalTeoricoTiraje.ToString("N0").Replace(",", ".") + "</b></td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //"<b>" + TotalMalosTiraje.ToString("N0").Replace(",", ".") + "</b></td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //"%</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:100px;'>" +
                           "</td>" +
                           "</tr></tbody></table>";

                        Planificado = Convert.ToDouble(reader["Planificado"].ToString());
                        TotalPlanificado = 0; TotalPlanificado += Convert.ToDouble(reader["Planificado"].ToString());
                        Producido = Convert.ToDouble(reader["Giros"].ToString());
                        TotalProducido = 0; TotalProducido += Convert.ToDouble(reader["Giros"].ToString());
                        TeoricoPreparacion = Convert.ToDouble(reader["TeoricaPreparacion"].ToString());
                        TotalTeoricoPreparacion = 0; TotalTeoricoPreparacion += Convert.ToDouble(reader["TeoricaPreparacion"].ToString());
                        MalosPreparacion = Convert.ToDouble(reader["MalosPreparacion"].ToString());
                        TotalMalosPreparacion = 0; TotalMalosPreparacion += Convert.ToDouble(reader["MalosPreparacion"].ToString());
                        TeoricoTiraje = Convert.ToDouble(reader["TeoricaTiraje"].ToString());
                        TotalTeoricoTiraje = 0; TotalTeoricoTiraje += Convert.ToDouble(reader["TeoricaTiraje"].ToString());
                        MalosTiraje = Convert.ToDouble(reader["MalosTiraje"].ToString());
                        TotalMalosTiraje = 0; TotalMalosTiraje += Convert.ToDouble(reader["MalosTiraje"].ToString());
                        TotalCostoSobreImp = 0; CantSobreImpresion = 0;
                        if (Planificado > 0)
                        {
                            PorcProduccion = (Producido - Planificado).ToString("N0").Replace(",", ".") + " (" + (((Producido - Planificado) / (Planificado)) * 100).ToString("N2") + "%)";
                            if ((Producido - Planificado) > 0)
                            {
                                CantSobreImpresion += (Producido - Planificado);
                            }
                        }
                        else
                        {
                            PorcProduccion = "0,00%";
                        }
                        if (TeoricoPreparacion > 0)
                        {
                            PorcMalosPreparacion = (MalosPreparacion - TeoricoPreparacion).ToString("N0").Replace(",", ".") + " (" + (((MalosPreparacion - TeoricoPreparacion) / (TeoricoPreparacion)) * 100).ToString("N2") + "%)";
                        }
                        else
                        {
                            PorcMalosPreparacion = "0,00%";
                        }
                        if (TeoricoTiraje > 0)
                        {
                            porcMalosTiraje = (MalosTiraje - TeoricoTiraje).ToString("N0").Replace(",", ".") + " (" + (((MalosTiraje - TeoricoTiraje) / (TeoricoTiraje)) * 100).ToString("N2") + "%)";
                        }
                        else
                        {
                            porcMalosTiraje = "0,00%";
                        }
                        if (reader["CodItem"].ToString() != "")
                        {
                            ValorProxKG = Convert.ToDouble(reader["CodItem"].ToString());
                            if ((Producido - Planificado) > 0)
                            {
                                Costosobreimpresion = Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["QtdePapelUnidade1"].ToString()) / Convert.ToInt32(Producido)) * (Producido - Planificado)) * ValorProxKG);
                            }
                            else
                            {
                                Costosobreimpresion = 0;
                            }
                            TotalCostoSobreImp += Costosobreimpresion;
                        }
                        string CostoPesos = "";
                        if (Procedimiento == 0)
                        {
                            CostoPesos = "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>$" +
                            Costosobreimpresion.ToString("N2") + "</td>";
                        }
                        Contenido = Contenido + Encabezado(reader["Maquina"].ToString(), Procedimiento);
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                           reader["OT"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:243px;'>" +
                           reader["NombreOT"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                           reader["Pliego"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Planificado.ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Producido.ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           PorcProduccion + "</td>" +

                           //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;width:73px;'>" +
                            //Convert.ToDouble(reader["MalosPreparacion"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Convert.ToDouble(reader["Wip_PliegosWip"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;width:210px;'>" +
                            reader["DescPapel"].ToString() + "</td>" +
                            CostoPesos +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["QtdePapelUnidade1"].ToString()).ToString("N2") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //TeoricoPreparacion.ToString("N0").Replace(",", ".") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //MalosPreparacion.ToString("N0").Replace(",", ".") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //PorcMalosPreparacion + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //TeoricoTiraje.ToString("N0").Replace(",", ".") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //MalosTiraje.ToString("N0").Replace(",", ".") + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            //porcMalosTiraje + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:100px;'>" +
                           reader["Operador"].ToString().ToLower() + "</td>" +
                           "</tr>";
                        SectorAnt = reader["Maquina"].ToString();
                    }
                }
                if (reader.Read() == false)
                {
                    string CostoPesosF = "";
                    if (Procedimiento == 0)
                    {
                        CostoPesosF = "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>$" +
                       TotalCostoSobreImp.ToString("N2") + "</td>";
                    }
                    Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                       "<b>TOTALES:</b></td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:243px;'>" +
                       "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                       "</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                       "<b>" + TotalPlanificado.ToString("N0").Replace(",", ".") + "</b></td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                       "<b>" + TotalProducido.ToString("N0").Replace(",", ".") + "</b></td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                       CantSobreImpresion.ToString("N0").Replace(",", ".") + "</td>" +

                       //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:73px;'></td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'></td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'></td>" +
                       CostoPesosF +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:73px;'></td>" +
                        //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //"<b>" + TotalTeoricoPreparacion.ToString("N0").Replace(",", ".") + "</b></td>" +
                        //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //"<b>" + TotalMalosPreparacion.ToString("N0").Replace(",", ".") + "</b></td>" +
                        //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //"%</td>" +
                        //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //"<b>" + TotalTeoricoTiraje.ToString("N0").Replace(",", ".") + "</b></td>" +
                        //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //"<b>" + TotalMalosTiraje.ToString("N0").Replace(",", ".") + "</b></td>" +
                        //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //"%</td>" +
                       "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:100px;'>" +
                       "</td>" +
                       "</tr>";
                }
            }
            conexion.CerrarConexion();
            return Contenido + "</tbody></table>";
        }

        private string Encabezado(string Maquina, int Procedimiento)
        {
            string CostoPapel = "";
            if (Procedimiento == 0)
            {
                CostoPapel = "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                " Costo sobreimpresión $  </td>";
            }
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1228px;margin-left:3px;'>" +
             "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
               "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='14'>Máquina: " + Maquina.ToString() + " </td></tr>" +
                 "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
               "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                   "OT</td> " +
               "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:243px;'>" +
                   "Nombre OT</td> " +
               "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                   "Pliego</td> " +
               "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                "   Cant. Planificado</td>" +
               "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                "   Cant. Producida</td> " +
               "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                "   % Producción</td>" +

                //"<td style='font-weight: bold; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>Malos Preparación</td>" +
                "<td style='font-weight: bold; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>Control Wip</td>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:210px;'>" +
                "  Papeles   </td>" +
                CostoPapel +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                " Consumo Kg  </td>" +

               //"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                //"    Teorico Malos Preparación</td>" +
                //"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                // "   Malos Preparacion</td> " +
                //"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                //"    % Merma Preparación</td> " +
                //"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                //"    Teorico Malos Tiraje</td> " +
                //"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                //"    Malos Tiraje</td> " +
                //"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                //"    % Merma Tiraje</td> " +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
               "    Operador</td> " +
             "</tr>";
            return Encabezado;
        }

        public string GenerarCorreoComparativo(string TipoCorreo, DateTime fi, DateTime ft, int Procedimiento)
        {
            try
            {
                string FI = fi.ToString("dd/MM/yyyy"); string FT = ft.ToString("dd/MM/yyyy");
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                if (Procedimiento == 0)
                {
                    mmsg.To.Add("reporte.sobre_impresiones@aimpresores.cl");
                    mmsg.To.Add("juan.venegas@aimpresores.cl");
                    mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                }
                else
                {
                    mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                    mmsg.To.Add("sobreimpresiones.prensas@aimpresores.cl");
                    mmsg.To.Add("juan.venegas@aimpresores.cl");
                }
                //mmsg.To.Add("claudio.valles@aimpresores.cl");
                mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                            "<br/><br/>Estimado(a):" +
                            "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta informacion correspondiente al día de ayer." +
                    "<br/><br/>" +
                    //"<a href='http://intranet.qgchile.cl/View/Imprimir_CorreoScoreCard.aspx?fi=" + FI + "' target='_blank'>Imprimir</a>" +
                            "<br/><br/>" +
                    //"<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                            Produccion_CorreoComparativo_TeoricoReal("Diario", fi, ft, Procedimiento) +
                            "<br/>" +

                            "<br/>" +
                    //"<div style='width:1203px;align=center;'>" + inf.Produccion_CorreoScoreCard_TiempoProduccion_V2("", fi, ft, 3) + "</div>" +
                            "<br />" +
                            "Atentamente," +
                            "<br />" +
                            "<b>Equipo de desarrollo A Impresores S.A.</b>";

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Informe de Sobreimpresiones del " + fi.ToString("dd/MM/yyyy");
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("sobreimpresiones@aimpresores.cl");
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials =
                    new System.Net.NetworkCredential("sobreimpresiones@aimpresores.cl", "info_sobreimpresiones");

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
                GenerarCorreoErrordeEnvio("GenerarCorreoComparativo", "Especifico", NombreProcedure, TipoCorreo + "," + fi.ToString("dd-MM.yyyy") + "," + ft.ToString("dd-MM-yyyy HH:mm:ss") + "," + Procedimiento, e.Message);
                return "Error Enviado";
            }
        }

        public string Produccion_CorreoScoreCard_V2(string Titulo, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = ""; string SectorAnt = ""; double TotalPliegos = 0; double TotalGiros = 0; double TotalMermaTiraje = 0; double HorasSinProducir = 0;
            double TotalMermaPreparacion = 0; double Entradas = 0; double TotalHorasTiraje = 0; double TotalHorasImp = 0; double TotalHorasPrep = 0; double TotalHorasSinProducir = 0;
            double HorasTiraje = 0; double HorasImp = 0; double HorasPrep = 0; string NombreTitulo = ""; string PromedioHorasPreparacion = ""; string ceros = "00"; double TotalHorasPreparacion = 0;
            double OTS = 0; double TotalOTS = 0;
            if (Titulo == "Diario")
            {
                NombreTitulo = "Score Card Diario " + FechaInicio.ToString("dd/MM/yyyy");
            }
            else if (Titulo == "Semanal")
            {
                NombreTitulo = "Score Card Semanal " + FechaInicio.ToString("dd/MM/yyyy") + " al " + FechaTermino.ToString("dd/MM/yyyy");
            }
            else
            {
                NombreTitulo = "Score Card Mensual " + FechaInicio.ToString("dd/MM/yyyy") + " al " + FechaTermino.ToString("dd/MM/yyyy");
            }
            string TirajePromedio = ""; string VelMRD = ""; string Velocidad = ""; string Uptime = ""; string MermaArranque = ""; string Capacidad = "";
            string MArranque = ""; string MTiraje = "";
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1172px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='15'>" + NombreTitulo + "</td></tr>" +
              "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                "Máquinas</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:83px;'>" +
                "Pliegos<br />&nbsp;16 Pags.</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:83px;'>" +
                "Giros</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Preparación Promedio</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Tiraje<br />&nbsp;Promedio</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Velocidad<br />(MRD)</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
            "Velocidad</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Uptime</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
            "    Mermas<br />Tiraje</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Mermas Arranque % </td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Mermas Arranque</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Capacidad</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "Horas Sin Vender</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Entradas</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   OTs <br />Trabajadas</td> " +
          "</tr>";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_CorreoScoreCard]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (SectorAnt == "" || SectorAnt == reader["CodSetor"].ToString())
                    {
                        TotalPliegos += Convert.ToDouble(reader["Buenos"].ToString());
                        TotalGiros += Convert.ToDouble(reader["Giros"].ToString());
                        TotalMermaTiraje += Convert.ToDouble(reader["PliegosMalosTiraje"].ToString());
                        TotalMermaPreparacion += Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString());
                        TotalHorasTiraje += Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;
                        TotalHorasPrep += Convert.ToDouble(reader["HorasPreparacion"].ToString()) / 3600;
                        TotalHorasPreparacion += Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        TotalHorasImp += Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                        TotalHorasSinProducir += Convert.ToDouble(reader["HorasSinTrabajo"].ToString()) / 3600;
                        HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;
                        HorasPrep = Convert.ToDouble(reader["HorasPreparacion"].ToString()) / 3600;
                        HorasImp = Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                        HorasSinProducir = Convert.ToDouble(reader["HorasSinTrabajo"].ToString()) / 3600;
                        Entradas += Convert.ToDouble(reader["Entradas"].ToString());
                        OTS = Convert.ToDouble(reader["OTS"].ToString());
                        TotalOTS += Convert.ToDouble(reader["OTS"].ToString());
                        if (Convert.ToInt32(reader["Entradas"].ToString()) > 0)
                        {
                            TirajePromedio = (Convert.ToInt32(reader["Giros"].ToString()) / Convert.ToInt32(reader["Entradas"].ToString())).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            TirajePromedio = "0";
                        }
                        if ((HorasPrep + HorasTiraje + HorasImp) > 0)
                        {
                            VelMRD = ((Convert.ToDouble(reader["Giros"].ToString())) / (HorasPrep + HorasTiraje + HorasImp)).ToString("N0");
                        }
                        else
                        {
                            VelMRD = "0";
                        }

                        if (HorasTiraje > 0)
                        {
                            Velocidad = (Convert.ToDouble(reader["Giros"].ToString()) / (HorasTiraje)).ToString("N0");
                        }
                        else
                        {
                            Velocidad = "0";
                        }
                        if ((HorasTiraje + HorasImp) > 0)
                        {
                            Uptime = (((HorasTiraje) / (HorasTiraje + HorasImp)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            Uptime = "0";
                        }

                        if (Convert.ToInt32(reader["Giros"].ToString()) > 0)
                        {
                            MermaArranque = ((Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString()) / Convert.ToDouble(reader["Giros"].ToString())) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            MermaArranque = "0,00%";
                        }
                        if (Titulo == "Diario")
                        {
                            Capacidad = (((HorasTiraje + HorasPrep + HorasImp) / Convert.ToDouble(24)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            Capacidad = (((HorasTiraje + HorasPrep + HorasImp) / Convert.ToDouble(24 * (Convert.ToDouble(FechaTermino.ToString("dd"))))) * 100).ToString("N2") + "%";
                        }
                        if (Titulo == "Diario")
                        {
                            MArranque = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                            MTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            if (Convert.ToDouble(reader["Entradas"].ToString()) > 0)
                            {
                                MArranque = (Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString()) / Convert.ToDouble(reader["Entradas"].ToString())).ToString("N0").Replace(",", ".");
                            }
                            else
                            {
                                MArranque = "0";
                            }

                            if (HorasTiraje > 0)
                            {
                                MTiraje = ((Convert.ToDouble(reader["PliegosMalosTiraje"].ToString()) / Convert.ToDouble(reader["Giros"].ToString())) * 100).ToString("N2") + "%";
                            }
                            else
                            {
                                MTiraje = "0,00%";
                            }
                        }
                        if (Convert.ToDouble(reader["Entradas"].ToString()) > 0)
                        {
                            //PromedioHorasPreparacion = ((HorasPrep) / Convert.ToDouble(reader["Entradas"].ToString())).ToString("N1");
                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()) / Convert.ToDouble(reader["Entradas"].ToString()));
                            int Dias2 = t2.Days * 24;
                            PromedioHorasPreparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                        }
                        else
                        {
                            PromedioHorasPreparacion = "0:00:00";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                           Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                           Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           PromedioHorasPreparacion + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           TirajePromedio + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           VelMRD + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Velocidad + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Uptime + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MTiraje + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MermaArranque + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MArranque + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Capacidad + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           (HorasSinProducir).ToString("N1") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Convert.ToInt32(reader["Entradas"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           OTS.ToString("N0").Replace(",", ".") + "</td>" +
                           "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                    else
                    {
                        string Cap = "";
                        if (Titulo == "Diario")
                        {
                            //if (rr == "IMP ROT")
                            //{
                            Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 4)) * 100).ToString("N2") + "%";
                            //}
                            //else
                            //{
                            //    Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 4)) * 100).ToString("N2") + "%";
                            //}                           
                        }
                        else
                        {
                            Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 5 * (Convert.ToDouble(FechaTermino.ToString("dd"))))) * 100).ToString("N2") + "%";
                        }
                        if (Titulo == "Diario")
                        {
                            MArranque = (TotalMermaPreparacion).ToString("N0").Replace(",", ".");
                            MTiraje = (TotalMermaTiraje).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            if (Entradas > 0)
                            {
                                MArranque = (TotalMermaPreparacion / Entradas).ToString("N0").Replace(",", ".");
                            }
                            else
                            {
                                MArranque = "0";
                            }
                            if (TotalHorasTiraje > 0)
                            {
                                MTiraje = (((TotalMermaTiraje) / TotalGiros) * 100).ToString("N2") + "%";
                            }
                            else
                            {
                                MTiraje = "0,00%";
                            }
                        }
                        if (Entradas > 0)
                        {
                            //PromedioHorasPreparacion = (TotalHorasPrep / Entradas).ToString("N1");
                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(TotalHorasPreparacion) / Entradas);
                            int Dias2 = t2.Days * 24;
                            PromedioHorasPreparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                        }
                        else
                        {
                            PromedioHorasPreparacion = "0:00:00";
                        }
                        //Totales
                        Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                          "<b>TOTAL ROTATIVAS</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                          "<b>" + Convert.ToInt32(TotalPliegos).ToString("N0").Replace(",", ".") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                          "<b>" + Convert.ToInt32(TotalGiros).ToString("N0").Replace(",", ".") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + PromedioHorasPreparacion + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + Convert.ToInt32((Convert.ToInt32(TotalGiros)) / (Convert.ToInt32(Entradas))).ToString("N0").Replace(",", ".") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + ((Convert.ToDouble(TotalGiros)) / (TotalHorasPrep + TotalHorasTiraje + TotalHorasImp)).ToString("N0") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + ((TotalGiros) / (TotalHorasTiraje)).ToString("N0") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + (((TotalHorasTiraje) / (TotalHorasTiraje + TotalHorasImp)) * 100).ToString("N2") + "%" + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + MTiraje + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + (((TotalMermaPreparacion) / (TotalGiros)) * 100).ToString("N2") + "%" + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + MArranque + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + Cap + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + (TotalHorasSinProducir).ToString("N1") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + Convert.ToInt32(Entradas).ToString("N0").Replace(",", ".") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + TotalOTS.ToString("N0").Replace(",", ".") + "</b></td>" +
                          "</tr>";

                        TotalPliegos = 0; TotalPliegos += Convert.ToDouble(reader["Buenos"].ToString());
                        TotalGiros = 0; TotalGiros += Convert.ToDouble(reader["Giros"].ToString());
                        TotalMermaTiraje = 0; TotalMermaTiraje += Convert.ToDouble(reader["PliegosMalosTiraje"].ToString());
                        TotalMermaPreparacion = 0; TotalMermaPreparacion += Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString());
                        TotalHorasTiraje = 0; TotalHorasTiraje += Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;
                        TotalHorasPrep = 0; TotalHorasPrep += Convert.ToDouble(reader["HorasPreparacion"].ToString()) / 3600;
                        TotalHorasPreparacion = 0; TotalHorasPreparacion += Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        TotalHorasImp = 0; TotalHorasImp += Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                        TotalHorasSinProducir = 0; TotalHorasSinProducir += Convert.ToDouble(reader["HorasSinTrabajo"].ToString()) / 3600;
                        HorasSinProducir = 0; HorasSinProducir += Convert.ToDouble(reader["HorasSinTrabajo"].ToString()) / 3600;
                        HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;
                        HorasPrep = Convert.ToDouble(reader["HorasPreparacion"].ToString()) / 3600;
                        HorasImp = Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                        Entradas = 0; Entradas += Convert.ToDouble(reader["Entradas"].ToString());
                        TotalOTS = 0; TotalOTS += Convert.ToDouble(reader["OTS"].ToString());
                        OTS = Convert.ToDouble(reader["OTS"].ToString());
                        if (Convert.ToInt32(reader["Entradas"].ToString()) > 0)
                        {
                            TirajePromedio = (Convert.ToInt32(reader["Giros"].ToString()) / Convert.ToInt32(reader["Entradas"].ToString())).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            TirajePromedio = "0";
                        }
                        if ((HorasPrep + HorasTiraje + HorasImp) > 0)
                        {
                            VelMRD = ((Convert.ToDouble(reader["Giros"].ToString())) / (HorasPrep + HorasTiraje + HorasImp)).ToString("N0");
                        }
                        else
                        {
                            VelMRD = "0";
                        }

                        if (HorasTiraje > 0)
                        {
                            Velocidad = (Convert.ToDouble(reader["Giros"].ToString()) / (HorasTiraje)).ToString("N0");
                        }
                        else
                        {
                            Velocidad = "0";
                        }
                        if ((HorasTiraje + HorasImp) > 0)
                        {
                            Uptime = (((HorasTiraje) / (HorasTiraje + HorasImp)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            Uptime = "0";
                        }

                        if (Convert.ToInt32(reader["Giros"].ToString()) > 0)
                        {
                            MermaArranque = ((Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString()) / Convert.ToDouble(reader["Giros"].ToString())) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            MermaArranque = "0,00%";
                        }

                        if (Titulo == "Diario")
                        {
                            Capacidad = (((HorasTiraje + HorasPrep + HorasImp) / Convert.ToDouble(24)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            Capacidad = (((HorasTiraje + HorasPrep + HorasImp) / Convert.ToDouble(24 * (Convert.ToDouble(FechaTermino.ToString("dd"))))) * 100).ToString("N2") + "%";
                        }
                        if (Titulo == "Diario")
                        {
                            MArranque = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                            MTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            if (Convert.ToDouble(reader["Entradas"].ToString()) > 0)
                            {
                                MArranque = (Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString()) / Convert.ToDouble(reader["Entradas"].ToString())).ToString("N0").Replace(",", ".");
                            }
                            else
                            {
                                MArranque = "0";
                            }
                            if (HorasTiraje > 0)
                            {
                                MTiraje = ((Convert.ToDouble(reader["PliegosMalosTiraje"].ToString()) / Convert.ToDouble(reader["Giros"].ToString())) * 100).ToString("N2") + "%";
                            }
                            else
                            {
                                MTiraje = "0,00%";
                            }
                        }
                        if (Convert.ToDouble(reader["Entradas"].ToString()) > 0)
                        {
                            //PromedioHorasPreparacion = ((HorasPrep) / Convert.ToDouble(reader["Entradas"].ToString())).ToString("N1");
                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()) / Convert.ToDouble(reader["Entradas"].ToString()));
                            int Dias2 = t2.Days * 24;
                            PromedioHorasPreparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                        }
                        else
                        {
                            PromedioHorasPreparacion = "0:00:00";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                           Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                           Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           PromedioHorasPreparacion + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           TirajePromedio + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           VelMRD + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Velocidad + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Uptime + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MTiraje + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MermaArranque + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MArranque + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Capacidad + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           (HorasSinProducir).ToString("N1") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Convert.ToInt32(reader["Entradas"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           OTS.ToString("N0").Replace(",", ".") + "</td>" +
                           "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                } if (reader.Read() == false)
                {
                    string TirajeProm = ""; string MRD = ""; string Vel = ""; string Upt = ""; string tGiros = ""; string Cap = "";
                    if (Entradas > 0)
                    {
                        TirajeProm = Convert.ToInt32((Convert.ToInt32(TotalGiros)) / (Convert.ToInt32(Entradas))).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        TirajeProm = "0";
                    }
                    if ((TotalHorasPrep + TotalHorasTiraje + TotalHorasImp) > 0)
                    {
                        MRD = ((Convert.ToDouble(TotalGiros)) / (TotalHorasPrep + TotalHorasTiraje + TotalHorasImp)).ToString("N0");
                    }
                    else
                    {
                        MRD = "0";
                    }
                    if ((TotalHorasTiraje) > 0)
                    {
                        Vel = ((TotalGiros) / (TotalHorasTiraje)).ToString("N0");
                    }
                    else
                    {
                        Vel = "0";
                    }//(TotalHorasTiraje + TotalHorasImp)
                    if ((TotalHorasTiraje + TotalHorasImp) > 0)
                    {
                        Upt = (((TotalHorasTiraje) / (TotalHorasTiraje + TotalHorasImp)) * 100).ToString("N2") + "%";
                    }
                    else
                    {
                        Upt = "0,00%";
                    }
                    if ((TotalGiros) > 0)
                    {
                        tGiros = (((TotalMermaPreparacion) / (TotalGiros)) * 100).ToString("N2") + "%";
                    }
                    else
                    {
                        tGiros = "0,00%";
                    }
                    if (Titulo == "Diario")
                    {
                        //if (reader["CodSetor"].ToString() == "IMP ROT")
                        //{
                        //    Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 5)) * 100).ToString("N2") + "%";
                        //}
                        //else
                        //{
                        Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 2)) * 100).ToString("N2") + "%";
                        //}    
                    }
                    else
                    {
                        Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 3 * (Convert.ToDouble(FechaTermino.ToString("dd"))))) * 100).ToString("N2") + "%";
                    }
                    if (Titulo == "Diario")
                    {
                        MArranque = (TotalMermaPreparacion).ToString("N0").Replace(",", ".");
                        MTiraje = (TotalMermaTiraje).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        if (Entradas > 0)
                        {
                            MArranque = (TotalMermaPreparacion / Entradas).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            MArranque = "0";
                        }
                        if (TotalHorasTiraje > 0)
                        {
                            MTiraje = (((TotalMermaTiraje) / TotalGiros) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            MTiraje = "0,00%";
                        }
                    }
                    if (Entradas > 0)
                    {
                        //PromedioHorasPreparacion = (TotalHorasPrep / Entradas).ToString("N1");
                        TimeSpan t2 = TimeSpan.FromSeconds(TotalHorasPreparacion / Entradas);
                        int Dias2 = t2.Days * 24;
                        PromedioHorasPreparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                    }
                    else
                    {
                        PromedioHorasPreparacion = "0:00:00";
                    }
                    Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                        "<b>TOTAL PLANAS</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                        "<b>" + Convert.ToInt32(TotalPliegos).ToString("N0").Replace(",", ".") + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                        "<b>" + Convert.ToInt32(TotalGiros).ToString("N0").Replace(",", ".") + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + PromedioHorasPreparacion + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + TirajeProm + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + MRD + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + Vel + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + Upt + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + MTiraje + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + tGiros + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + MArranque + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + Cap + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + (TotalHorasSinProducir).ToString("N1") + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + Convert.ToInt32(Entradas).ToString("N0").Replace(",", ".") + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + TotalOTS.ToString("N0").Replace(",", ".") + "</b></td>" +
                        "</tr>";
                }

            }
            conexion.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }

        public string Produccion_CorreoScoreCard_TiempoProduccion_V2(string Titulo, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = ""; string SectorAnt = ""; double Entradas = 0; double HorasTiraje = 0; double HorasPreparacion = 0; double HorasImp = 0; double HorasSinTrabajo = 0; double HorasSinPersonal = 0; double HorasMantencion = 0; double HorasPruebaImpresiom = 0;
            double TotalEntradas = 0; double TotalHorasTiraje = 0; double TotalHorasPreparacion = 0; double TotalHorasImp = 0; double TotalHorasSinTrabajo = 0; double TotalHorasSinPersonal = 0; double TotalHorasMantencion = 0; double TotalHorasPruebaImpresiom = 0; double TotalHoras = 0;
            string ceros = "00"; string HorasT = ""; string HorasP = ""; string HorasI = ""; string HorasST = ""; string HorasSP = ""; string HorasM = ""; string HorasPI = ""; string THoras = ""; string NombreTitulo = "";
            #region Encabezado;
            if (Titulo == "Diario")
            {
                NombreTitulo = "Detalle Horas Dia " + FechaInicio.ToString("dd/MM/yyyy");
            }
            else if (Titulo == "Semanal")
            {
                NombreTitulo = "Detalle Horas Semanal " + FechaInicio.ToString("dd/MM/yyyy") + " al " + FechaTermino.ToString("dd/MM/yyyy");
            }
            else
            {
                NombreTitulo = "Detalle Horas Mensual " + FechaInicio.ToString("dd/MM/yyyy") + " al " + FechaTermino.ToString("dd/MM/yyyy");
            }
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:782px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='14'>" + NombreTitulo + "</td></tr>" +
              "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                "Máquinas</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                "Entradas</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
                "Horas Preparación</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Horas Tiraje</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Horas Improductivas</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Horas Sin Trabajo</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
            "    Horas Sin Personal</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Horas Mantención</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
            "    Horas Maquina Parada entre OT</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
            "    Total Horas</td> " +
          "</tr>";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_CorreoScoreCard]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (SectorAnt == "" || SectorAnt == reader["CodSetor"].ToString())
                    {
                        Entradas = Convert.ToDouble(reader["Entradas"].ToString());
                        HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString());
                        HorasPreparacion = Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        HorasImp = Convert.ToDouble(reader["HorasImproductivas"].ToString());
                        HorasSinTrabajo = Convert.ToDouble(reader["HorasSinTrabajo"].ToString());
                        HorasSinPersonal = Convert.ToDouble(reader["HorasSinPersonal"].ToString());
                        HorasMantencion = Convert.ToDouble(reader["HorasMantencion"].ToString());
                        HorasPruebaImpresiom = Convert.ToDouble(reader["HorasMaquinaParada"].ToString());
                        TotalEntradas += Convert.ToDouble(reader["Entradas"].ToString());
                        TotalHorasTiraje += Convert.ToDouble(reader["HorasTiraje"].ToString());
                        TotalHorasPreparacion += Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        TotalHorasImp += Convert.ToDouble(reader["HorasImproductivas"].ToString());
                        TotalHorasSinTrabajo += Convert.ToDouble(reader["HorasSinTrabajo"].ToString());
                        TotalHorasSinPersonal += Convert.ToDouble(reader["HorasSinPersonal"].ToString());
                        TotalHorasMantencion += Convert.ToDouble(reader["HorasMantencion"].ToString());
                        TotalHorasPruebaImpresiom += Convert.ToDouble(reader["HorasMaquinaParada"].ToString());
                        TotalHoras = (HorasTiraje + HorasPreparacion + HorasImp + HorasSinTrabajo + HorasSinPersonal + HorasMantencion + HorasPruebaImpresiom);

                        TimeSpan t1 = TimeSpan.FromSeconds(HorasTiraje);
                        int Dias1 = t1.Days * 24;
                        HorasT = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                        TimeSpan t2 = TimeSpan.FromSeconds(HorasPreparacion);
                        int Dias2 = t2.Days * 24;
                        HorasP = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                        TimeSpan t3 = TimeSpan.FromSeconds(HorasImp);
                        int Dias3 = t3.Days * 24;
                        HorasI = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                        TimeSpan t4 = TimeSpan.FromSeconds(HorasSinTrabajo);
                        int Dias4 = t4.Days * 24;
                        HorasST = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();

                        TimeSpan t5 = TimeSpan.FromSeconds(HorasSinPersonal);
                        int Dias5 = t5.Days * 24;
                        HorasSP = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                        TimeSpan t6 = TimeSpan.FromSeconds(HorasMantencion);
                        int Dias6 = t6.Days * 24;
                        HorasM = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                        TimeSpan t7 = TimeSpan.FromSeconds(HorasPruebaImpresiom);
                        int Dias7 = t7.Days * 24;
                        HorasPI = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                        TimeSpan t8 = TimeSpan.FromSeconds(TotalHoras);
                        int Dias8 = t8.Days * 24;
                        THoras = (t8.Hours + Dias8).ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Minutes.ToString().Length) + t8.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Seconds.ToString().Length) + t8.Seconds.ToString();

                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Entradas.ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           HorasP + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           HorasT + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           HorasI + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           HorasST + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           HorasSP + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           HorasM + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           HorasPI + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           THoras + "</td>" +
                           "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                    else
                    {
                        TimeSpan t10 = TimeSpan.FromSeconds(TotalHorasTiraje);
                        int Dias10 = t10.Days * 24;
                        HorasT = (t10.Hours + Dias10).ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Minutes.ToString().Length) + t10.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Seconds.ToString().Length) + t10.Seconds.ToString();

                        TimeSpan t20 = TimeSpan.FromSeconds(TotalHorasPreparacion);
                        int Dias20 = t20.Days * 24;
                        HorasP = (t20.Hours + Dias20).ToString() + ":" + ceros.Substring(0, ceros.Length - t20.Minutes.ToString().Length) + t20.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t20.Seconds.ToString().Length) + t20.Seconds.ToString();

                        TimeSpan t30 = TimeSpan.FromSeconds(TotalHorasImp);
                        int Dias30 = t30.Days * 24;
                        HorasI = (t30.Hours + Dias30).ToString() + ":" + ceros.Substring(0, ceros.Length - t30.Minutes.ToString().Length) + t30.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t30.Seconds.ToString().Length) + t30.Seconds.ToString();

                        TimeSpan t40 = TimeSpan.FromSeconds(TotalHorasSinTrabajo);
                        int Dias40 = t40.Days * 24;
                        HorasST = (t40.Hours + Dias40).ToString() + ":" + ceros.Substring(0, ceros.Length - t40.Minutes.ToString().Length) + t40.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t40.Seconds.ToString().Length) + t40.Seconds.ToString();

                        TimeSpan t50 = TimeSpan.FromSeconds(TotalHorasSinPersonal);
                        int Dias50 = t50.Days * 24;
                        HorasSP = (t50.Hours + Dias50).ToString() + ":" + ceros.Substring(0, ceros.Length - t50.Minutes.ToString().Length) + t50.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t50.Seconds.ToString().Length) + t50.Seconds.ToString();

                        TimeSpan t60 = TimeSpan.FromSeconds(TotalHorasMantencion);
                        int Dias60 = t60.Days * 24;
                        HorasM = (t60.Hours + Dias60).ToString() + ":" + ceros.Substring(0, ceros.Length - t60.Minutes.ToString().Length) + t60.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t60.Seconds.ToString().Length) + t60.Seconds.ToString();

                        TimeSpan t70 = TimeSpan.FromSeconds(TotalHorasPruebaImpresiom);
                        int Dias70 = t70.Days * 24;
                        HorasPI = (t70.Hours + Dias70).ToString() + ":" + ceros.Substring(0, ceros.Length - t70.Minutes.ToString().Length) + t70.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t70.Seconds.ToString().Length) + t70.Seconds.ToString();
                        //Totales
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                                    "<b>TOTAL ROTATIVAS</b></td>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                    "<b>" + TotalEntradas.ToString("N0").Replace(",", ".") + "</b></td>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                    "<b>" + HorasP + "</b></td>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                    "<b>" + HorasT + "</b></td>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                    "<b>" + HorasI + "</b></td>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                    "<b>" + HorasST + "</b></td>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                    "<b>" + HorasSP + "</b></td>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                    "<b>" + HorasM + "</b></td>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                    "<b>" + HorasPI + "</b></td>" +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                    "</td>" +
                                    "</tr>";

                        Entradas = 0; Entradas = Convert.ToDouble(reader["Entradas"].ToString());
                        HorasTiraje = 0; HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString());
                        HorasPreparacion = 0; HorasPreparacion = Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        HorasImp = 0; HorasImp = Convert.ToDouble(reader["HorasImproductivas"].ToString());
                        HorasSinTrabajo = 0; HorasSinTrabajo = Convert.ToDouble(reader["HorasSinTrabajo"].ToString());
                        HorasSinPersonal = 0; HorasSinPersonal = Convert.ToDouble(reader["HorasSinPersonal"].ToString());
                        HorasMantencion = 0; HorasMantencion = Convert.ToDouble(reader["HorasMantencion"].ToString());
                        HorasPruebaImpresiom = 0; HorasPruebaImpresiom = Convert.ToDouble(reader["HorasMaquinaParada"].ToString());
                        TotalEntradas = 0; TotalEntradas += Convert.ToDouble(reader["Entradas"].ToString());
                        TotalHorasTiraje = 0; TotalHorasTiraje += Convert.ToDouble(reader["HorasTiraje"].ToString());
                        TotalHorasPreparacion = 0; TotalHorasPreparacion += Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        TotalHorasImp = 0; TotalHorasImp += Convert.ToDouble(reader["HorasImproductivas"].ToString());
                        TotalHorasSinTrabajo = 0; TotalHorasSinTrabajo += Convert.ToDouble(reader["HorasSinTrabajo"].ToString());
                        TotalHorasSinPersonal = 0; TotalHorasSinPersonal += Convert.ToDouble(reader["HorasSinPersonal"].ToString());
                        TotalHorasMantencion = 0; TotalHorasMantencion += Convert.ToDouble(reader["HorasMantencion"].ToString());
                        TotalHorasPruebaImpresiom = 0; TotalHorasPruebaImpresiom += Convert.ToDouble(reader["HorasMaquinaParada"].ToString());
                        TotalHoras = (HorasTiraje + HorasPreparacion + HorasImp + HorasSinTrabajo + HorasSinPersonal + HorasMantencion + HorasPruebaImpresiom);

                        TimeSpan t1 = TimeSpan.FromSeconds(HorasTiraje);
                        int Dias1 = t1.Days * 24;
                        HorasT = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                        TimeSpan t2 = TimeSpan.FromSeconds(HorasPreparacion);
                        int Dias2 = t2.Days * 24;
                        HorasP = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                        TimeSpan t3 = TimeSpan.FromSeconds(HorasImp);
                        int Dias3 = t3.Days * 24;
                        HorasI = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                        TimeSpan t4 = TimeSpan.FromSeconds(HorasSinTrabajo);
                        int Dias4 = t4.Days * 24;
                        HorasST = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();

                        TimeSpan t5 = TimeSpan.FromSeconds(HorasSinPersonal);
                        int Dias5 = t5.Days * 24;
                        HorasSP = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                        TimeSpan t6 = TimeSpan.FromSeconds(HorasMantencion);
                        int Dias6 = t6.Days * 24;
                        HorasM = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                        TimeSpan t7 = TimeSpan.FromSeconds(HorasPruebaImpresiom);
                        int Dias7 = t7.Days * 24;
                        HorasPI = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                        TimeSpan t8 = TimeSpan.FromSeconds(TotalHoras);
                        int Dias8 = t8.Days * 24;
                        THoras = (t8.Hours + Dias8).ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Minutes.ToString().Length) + t8.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Seconds.ToString().Length) + t8.Seconds.ToString();
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                                   reader["Maquina"].ToString() + "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                   Entradas.ToString("N0").Replace(",", ".") + "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                   HorasP + "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                   HorasT + "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                   HorasI + "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                   HorasST + "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                   HorasSP + "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                   HorasM + "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                   HorasPI + "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                   THoras + "</td>" +
                                   "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                } if (reader.Read() == false)
                {
                    TimeSpan t10 = TimeSpan.FromSeconds(TotalHorasTiraje);
                    int Dias10 = t10.Days * 24;
                    HorasT = (t10.Hours + Dias10).ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Minutes.ToString().Length) + t10.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Seconds.ToString().Length) + t10.Seconds.ToString();

                    TimeSpan t20 = TimeSpan.FromSeconds(TotalHorasPreparacion);
                    int Dias20 = t20.Days * 24;
                    HorasP = (t20.Hours + Dias20).ToString() + ":" + ceros.Substring(0, ceros.Length - t20.Minutes.ToString().Length) + t20.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t20.Seconds.ToString().Length) + t20.Seconds.ToString();

                    TimeSpan t30 = TimeSpan.FromSeconds(TotalHorasImp);
                    int Dias30 = t30.Days * 24;
                    HorasI = (t30.Hours + Dias30).ToString() + ":" + ceros.Substring(0, ceros.Length - t30.Minutes.ToString().Length) + t30.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t30.Seconds.ToString().Length) + t30.Seconds.ToString();

                    TimeSpan t40 = TimeSpan.FromSeconds(TotalHorasSinTrabajo);
                    int Dias40 = t40.Days * 24;
                    HorasST = (t40.Hours + Dias40).ToString() + ":" + ceros.Substring(0, ceros.Length - t40.Minutes.ToString().Length) + t40.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t40.Seconds.ToString().Length) + t40.Seconds.ToString();

                    TimeSpan t50 = TimeSpan.FromSeconds(TotalHorasSinPersonal);
                    int Dias50 = t50.Days * 24;
                    HorasSP = (t50.Hours + Dias50).ToString() + ":" + ceros.Substring(0, ceros.Length - t50.Minutes.ToString().Length) + t50.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t50.Seconds.ToString().Length) + t50.Seconds.ToString();

                    TimeSpan t60 = TimeSpan.FromSeconds(TotalHorasMantencion);
                    int Dias60 = t60.Days * 24;
                    HorasM = (t60.Hours + Dias60).ToString() + ":" + ceros.Substring(0, ceros.Length - t60.Minutes.ToString().Length) + t60.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t60.Seconds.ToString().Length) + t60.Seconds.ToString();

                    TimeSpan t70 = TimeSpan.FromSeconds(TotalHorasPruebaImpresiom);
                    int Dias70 = t70.Days * 24;

                    HorasPI = (t70.Hours + Dias70).ToString() + ":" + ceros.Substring(0, ceros.Length - t70.Minutes.ToString().Length) + t70.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t70.Seconds.ToString().Length) + t70.Seconds.ToString();
                    Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:125px;'>" +
                                "<b>TOTAL ROTATIVAS</b></td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                "<b>" + TotalEntradas.ToString("N0").Replace(",", ".") + "</b></td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                "<b>" + HorasP + "</b></td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                "<b>" + HorasT + "</b></td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                "<b>" + HorasI + "</b></td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                "<b>" + HorasST + "</b></td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                "<b>" + HorasSP + "</b></td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                "<b>" + HorasM + "</b></td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                "<b>" + HorasPI + "</b></td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                                "</td>" +
                                "</tr>";
                }

            }
            conexion.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }

        public string GenerarCorreoScoreCard(DateTime fi, DateTime ft, DateTime PrimerDia, DateTime DiaActual)
        {
            try
            {
                string FI = fi.ToString("dd/MM/yyyy"); string FT = ft.ToString("dd/MM/yyyy");
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.To.Add("reporte_produccion@aimpresores.cl");
                mmsg.To.Add("juan.venegas@aimpresores.cl");
                mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                            "<br/><br/>Estimado(a):" +
                            "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta informacion correspondiente al día de ayer." +
                    "<br/><br/>" +
                    "<a href='http://intranet.qgchile.cl/View/Imprimir_CorreoScoreCard.aspx?fi=" + FI + "' target='_blank'>Imprimir</a>" +
                            "<br/><br/>" +
                    //"<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                            Produccion_CorreoScoreCard_V2("Diario", fi, ft, 0) +
                            "<br/>" +
                            Produccion_CorreoScoreCard_V2("Mensual", PrimerDia, DiaActual, 1) +
                            "<br/>" +
                            "<div style='width:1203px;align=center;'>" + Produccion_CorreoScoreCard_TiempoProduccion_V2("Diario", fi, ft, 3) + "</div>" +
                            "<div style='width:1203px;align=center;'>" + Produccion_CorreoScoreCard_TiempoProduccion_V2("Mensual", PrimerDia, ft, 3) + "</div>" +
                            "<br />" +
                            "Atentamente," +
                            "<br />" +
                            "<b>Equipo de desarrollo A Impresores S.A.</b>";

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Informe ScoreCard Diario " + fi.ToString("dd/MM/yyyy");
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("scorecard.produccion@aimpresores.cl");
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials =
                    new System.Net.NetworkCredential("scorecard.produccion@aimpresores.cl", "abcdsco222.");

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
                GenerarCorreoErrordeEnvio("GenerarCorreoScoreCard", "Especifico", NombreProcedure, fi.ToString("dd-MM-yyy HH:mm:ss") + "," + ft.ToString("dd-MM-yyy HH:mm:ss") + "," + PrimerDia + "," + DiaActual, e.Message);
                return "Error Enviado";
            }
        }

        public string GenerarCorreoScoreCard_Semanal(DateTime fi, DateTime ft)
        {
            try
            {
                string FI = fi.ToString("dd/MM/yyyy"); string FT = ft.ToString("dd/MM/yyyy");
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.To.Add("GenerarCorreoScoreCard_Semanal");
                mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                            "<br/><br/>Estimado(a):" +
                            "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta información correspondiente desde el día " + FI + " al " + FT + "." +
                    "<br/>" +
                      "<a href='http://intranet.qgchile.cl/View/Imprimir_ScoreCard_Semanal.aspx?fi=" + FI + "&ft="+FT+"' target='_blank'>Imprimir</a>" +
                            "<br/><br/>" +
                    //"<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                    //Produccion_CorreoScoreCard_V2("Diario", fi, ft, 0) +
                    //"<br/>" +
                            Produccion_CorreoScoreCard_V2("Semanal", fi, ft, 1) +
                            "<br/>" +
                    //"<div style='width:1203px;align=center;'>" + Produccion_CorreoScoreCard_TiempoProduccion_V2("Diario", fi, ft, 3) + "</div>" +
                            "<div style='width:1203px;align=center;'>" + Produccion_CorreoScoreCard_TiempoProduccion_V2("Semanal", fi, ft, 3) + "</div>" +
                            "<br />" +
                            "Atentamente," +
                            "<br />" +
                            "<b>Equipo de desarrollo A Impresores S.A.</b>";

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Informe ScoreCard Semanal " + FI + " al " + FT;
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("scorecard.produccion@aimpresores.cl");
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials =
                    new System.Net.NetworkCredential("scorecard.produccion@aimpresores.cl", "abcdsco222.");

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
                GenerarCorreoErrordeEnvio("GenerarCorreoScoreCard", "Especifico", NombreProcedure, fi.ToString("dd-MM-yyy HH:mm:ss") + "," + ft.ToString("dd-MM-yyy HH:mm:ss") + "," + fi + "," + ft, e.Message);
                return "Error Enviado";
            }
        }




        public string Produccion_CorreoConsumoPapel_V2(DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = ""; string PrimeraMaquina = ""; string MaquinaAnt = ""; string Totales = ""; double PesoBobina = 0; double PesoTapa = 0; double PesoEscarpe = 0; double PesoEnvoltorio = 0; double Saldo = 0; double PesoCono = 0;
            double TotalPesoBobina = 0; double TotalPesoTapa = 0; double TotalPesoEscarpe = 0; double TotalPesoEnvoltorio = 0; double TotalSaldo = 0; double TotalPesoCono = 0;
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1243px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:82px;'>OT</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:240px;'>Nombre OT</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:140px;'>Pliego</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Codigo Bobina</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Papel</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>Gramaje</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>Peso Bobina</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>Peso Tapa</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>Peso Escarpe</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>Peso envoltorio</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>Peso Cono</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>Saldo</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Motivo</td>" +
          "</tr>";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_CorreoDesperdicioPapel]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    PesoBobina = Convert.ToDouble(reader["PesoOriginal"].ToString());
                    PesoTapa = Convert.ToDouble(reader["Peso_Tapas"].ToString());
                    PesoEscarpe = Convert.ToDouble(reader["Peso_Escarpe"].ToString());
                    PesoEnvoltorio = Convert.ToDouble(reader["Peso_Envoltorio"].ToString());
                    PesoCono = Convert.ToDouble(reader["Peso_Cono"].ToString());
                    Saldo = Convert.ToDouble(reader["Saldo"].ToString());
                    if (PrimeraMaquina == "")
                    {
                        PrimeraMaquina = reader["Maquina"].ToString();
                    }
                    if (reader["Maquina"].ToString() == MaquinaAnt || MaquinaAnt == "")
                    {
                        TotalPesoBobina = TotalPesoBobina + PesoBobina;
                        TotalPesoTapa = TotalPesoTapa + PesoTapa;
                        TotalPesoEscarpe = TotalPesoEscarpe + PesoEscarpe;
                        TotalPesoEnvoltorio = TotalPesoEnvoltorio + PesoEnvoltorio;
                        TotalPesoCono = TotalPesoCono + PesoCono;
                        TotalSaldo = TotalSaldo + Saldo;
                    }
                    Totales = "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:82px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:240px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:140px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           "<b>Totales:</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Convert.ToInt32(TotalPesoBobina).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           TotalPesoTapa.ToString("N2") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           TotalPesoEscarpe.ToString("N2") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           TotalPesoEnvoltorio.ToString("N2") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           TotalPesoCono.ToString("N2") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Convert.ToInt32(TotalSaldo).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                           "</td>" +
                           "</tr>";

                    if (reader["Maquina"].ToString() == MaquinaAnt || MaquinaAnt == "")
                    {
                        Contenido = Contenido +
                            //"<b><div style='font-size: 20px;'>" + reader["Maquina"].ToString() + "</div></b>" + Encabezado + 
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:82px;'>" +
                            reader["OT"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:240px;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:140px;'>" +
                            reader["Pliego"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                            reader["Codigo_Bobina"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:90px;'>" +
                            reader["Tipo_Papel"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            reader["Gramage"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            reader["PesoOriginal"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["Peso_Tapas"].ToString()).ToString("N2") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["Peso_Escarpe"].ToString()).ToString("N2") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["Peso_Envoltorio"].ToString()).ToString("N2") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["Peso_Cono"].ToString()).ToString("N2") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            reader["Saldo"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:90px;'>" +
                            reader["Nombre_Estado"].ToString() + "</td>" +
                            "</tr>";
                    }
                    else
                    {
                        TotalPesoBobina = 0; TotalPesoBobina = TotalPesoBobina + PesoBobina;
                        TotalPesoTapa = 0; TotalPesoTapa = TotalPesoTapa + PesoTapa;
                        TotalPesoEscarpe = 0; TotalPesoEscarpe = TotalPesoEscarpe + PesoEscarpe;
                        TotalPesoEnvoltorio = 0; TotalPesoEnvoltorio = TotalPesoEnvoltorio + PesoEnvoltorio;
                        TotalPesoCono = 0; TotalPesoCono = TotalPesoCono + PesoCono;
                        TotalSaldo = 0; TotalSaldo = TotalSaldo + Saldo;

                        Contenido = Contenido + Totales + "</tbody></table><br/>" + "<b><div style='font-size: 20px;'>" + reader["Maquina"].ToString() + "</div></b>" + Encabezado +
                           "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:82px;'>" +
                            reader["OT"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:240px;'>" +
                            reader["NombreOT"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:140px;'>" +
                            reader["Pliego"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                            reader["Codigo_Bobina"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:90px;'>" +
                            reader["Tipo_Papel"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            reader["Gramage"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            reader["PesoOriginal"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["Peso_Tapas"].ToString()).ToString("N2") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["Peso_Escarpe"].ToString()).ToString("N2") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["Peso_Envoltorio"].ToString()).ToString("N2") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            Convert.ToDouble(reader["Peso_Cono"].ToString()).ToString("N2") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                            reader["Saldo"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:90px;'>" +
                            reader["Nombre_Estado"].ToString() + "</td>" +
                            "</tr>";
                    }
                    MaquinaAnt = reader["Maquina"].ToString();
                }
            }
            conexion.CerrarConexion();
            return "<b><div style='font-size: 20px;'>" + PrimeraMaquina + "</div></b>" + Encabezado + Contenido + Totales + "</tbody></table>";
        }

        public string GenerarCorreoDesperdicioPapel(DateTime fi, DateTime ft)
        {
            try
            {
                string FI = fi.ToString("dd/MM/yyyy"); string FT = ft.ToString("dd/MM/yyyy");
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.To.Add("generarcorreodesperdiciopapel@aimpresores.cl");
                mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                            "<br/><br/>Estimado(a):" +
                            "<br/><br/>Este informe se obtiene de forma automática desde el control de Desperdicio de Papel, siendo esta informacion correspondiente al día de ayer.<br/> La columna motivo solo informara cuando el escarpe sea mayor o igual a 20 kgs." +
                    //"<br/><br/>" +
                    //"<a href='http://intranet.qgchile.cl/View/Imprimir_CorreoMerma.aspx?t=" + TipoCorreo + "&fi=" + FI + "&ft=" + FT + "' target='_blank'>Imprimir</a>" +
                            "<br/><br/>" +
                    //"<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                            Produccion_CorreoConsumoPapel_V2(fi, ft, 0) +
                            "<br/>" +
                            "<br />" +
                            "Atentamente," +
                            "<br />" +
                            "<b>Equipo de desarrollo A Impresores S.A.</b>";

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Informe Desperdicio de Papel " + fi.ToString("dd/MM/yyyy");
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
                GenerarCorreoErrordeEnvio("GenerarCorreoDesperdicioPapel", "Especifico", NombreProcedure, fi.ToString("dd-MM-yyy HH:mm:ss") + "," + ft.ToString("dd-MM-yyy HH:mm:ss"), e.Message);
                return "Error Enviado";
            }
        }

        //CORREO MERMAS Y PRODUCCION
        public string Produccion_CorreoMermas_V2(string FechaInicio, string FechaTermino, int Procedimiento)
        {
            string MaquinaAnt = ""; int TeoPrep = 0; int RealPrep = 0; int TeoTiraje = 0; int RealTiraje = 0; int Plani = 0; string MermaPrepReal = ""; string MermaTirReal = "";
            string TeoricoPrep = ""; string TeoricoTiraje = ""; string Totales = ""; int TotalTeoPreparacion = 0; int TotalRealPreparacion = 0; int TotalTeoTiraje = 0; string CantidadWIP = "";
            int TotalRealTiraje = 0; int TotalPlanificado = 0; int TotalProducido = 0; int TotalWIP = 0; string Contenido = ""; int Buenos = 0; int BuenosWIP = 0; int BuenosPositivo = 0; int BuenosNegativos = 0; int Giros = 0; int TotalGiros = 0;
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1210px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>Máquina</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:82px;'>OT</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:240px;'>Nombre OT</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Pliego</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Estado</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Merma Preparación Teórica</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Merma Preparación Real</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Merma Tiraje Teórica</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Merma Tiraje Real</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Cantidad Planificada</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Produccion Giros</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Produccion Pliegos</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:cs enter;width:60px;'>Control WIP</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Operador</td>" +
          "</tr>";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_CorreoMermas_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TeoPrep = Convert.ToInt32(reader["TeoricaPreparacion"].ToString());
                    RealPrep = Convert.ToInt32(reader["MalosPreparacion"].ToString());
                    TeoTiraje = Convert.ToInt32(reader["TeoricaTiraje"].ToString());
                    RealTiraje = Convert.ToInt32(reader["MalosTiraje"].ToString());
                    Plani = Convert.ToInt32(reader["Planificada"].ToString());
                    Giros = Convert.ToInt32(reader["Giros"].ToString());
                    Buenos = Convert.ToInt32(reader["Buenos"].ToString());
                    BuenosWIP = Convert.ToInt32(reader["PliegosWIP"].ToString());
                    BuenosPositivo = Buenos + ((Giros * 10) / 100);
                    BuenosNegativos = Buenos - ((Giros * 10) / 100);
                    TeoricoPrep = (Convert.ToDouble(Convert.ToDouble(TeoPrep) / Convert.ToDouble(Plani)) * 100).ToString("N2");
                    TeoricoTiraje = (Convert.ToDouble(Convert.ToDouble(TeoTiraje) / Convert.ToDouble(Plani)) * 100).ToString("N2");
                    if (BuenosWIP > BuenosPositivo || BuenosWIP < BuenosNegativos)
                    {
                        CantidadWIP = "<div style='color:red;'>" + BuenosWIP.ToString("N0").Replace(",", ".") + "<div/>";
                    }
                    else
                    {
                        CantidadWIP = BuenosWIP.ToString("N0").Replace(",", ".");
                    }

                    //Convert.ToInt32(reader["PliegosWIP"].ToString()).ToString("N0").Replace(",", ".")
                    #region Teoricos PRep y tiraje
                    if (TeoPrep == 0 && RealPrep == 0)
                    {
                        MermaPrepReal = "<div style='color:red;'>0 (0,00%)</div>";
                    }
                    else
                    {
                        if (RealPrep == 0)
                        {
                            MermaPrepReal = "<div style='color:red;'>0 (0,00%)</div>";
                        }
                        else if (RealPrep <= 1500)
                        {
                            MermaPrepReal = RealPrep.ToString("N0").Replace(",", ".") + " (" + ((Convert.ToDouble(Convert.ToDouble(RealPrep) / Convert.ToDouble(Giros)) * 100).ToString("N2")) + "%)";
                        }
                        else
                        {
                            MermaPrepReal = "<div style='color:orange;'>" + RealPrep.ToString("N0").Replace(",", ".") + " (" + ((Convert.ToDouble(Convert.ToDouble(RealPrep) / Convert.ToDouble(Giros)) * 100).ToString("N2")) + "%)" + "</div>";
                        }
                    }
                    if (TeoTiraje == 0 && RealTiraje == 0)
                    {
                        MermaTirReal = "0 (0,00%)";
                    }
                    else
                    {
                        if ((TeoTiraje - RealTiraje) >= 0)
                        {
                            MermaTirReal = RealTiraje.ToString("N0").Replace(",", ".") + " (" + (Convert.ToDouble(Convert.ToDouble(RealTiraje) / Convert.ToDouble(Giros)) * 100).ToString("N2") + "%)";
                        }
                        else
                        {
                            MermaTirReal = "<div style='color:red;'>" + RealTiraje.ToString("N0").Replace(",", ".") + " (" + (Convert.ToDouble(Convert.ToDouble(RealTiraje) / Convert.ToDouble(Giros)) * 100).ToString("N2") + "%)" + "</div>";
                        }
                    }
                    #endregion
                    if (reader["CodRecurso"].ToString() == MaquinaAnt || MaquinaAnt == "")
                    {
                        TotalTeoPreparacion = TotalTeoPreparacion + TeoPrep;
                        TotalRealPreparacion = TotalRealPreparacion + RealPrep;
                        TotalTeoTiraje = TotalTeoTiraje + TeoTiraje;
                        TotalRealTiraje = TotalRealTiraje + RealTiraje;
                        TotalPlanificado = TotalPlanificado + Plani;
                        TotalProducido = TotalProducido + Buenos;
                        TotalGiros = TotalGiros + Giros;
                        TotalWIP = TotalWIP + BuenosWIP;
                    }
                    Totales = "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:82px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:240px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                           "<b>Totales:</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                           "<b>" + TotalTeoPreparacion.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalTeoPreparacion) / Convert.ToDouble(TotalPlanificado)) * 100).ToString("N2") + "%)</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                           "<b>" + TotalRealPreparacion.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalRealPreparacion) / Convert.ToDouble(TotalGiros)) * 100).ToString("N2") + "%)</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                           "<b>" + TotalTeoTiraje.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalTeoTiraje) / Convert.ToDouble(TotalPlanificado)) * 100).ToString("N2") + "%)</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                           "<b>" + TotalRealTiraje.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalRealTiraje) / Convert.ToDouble(TotalGiros)) * 100).ToString("N2") + "%)</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                           "<b>" + TotalPlanificado.ToString("N0").Replace(",", ".") + "</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                           "<b>" + TotalGiros.ToString("N0").Replace(",", ".") + "</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                           "<b>" + TotalProducido.ToString("N0").Replace(",", ".") + "</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                           "<b>" + TotalWIP.ToString("N0").Replace(",", ".") + "</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'>" +
                           "</td>" +
                           "</tr>";

                    if (reader["CodRecurso"].ToString() == MaquinaAnt || MaquinaAnt == "")
                    {
                        string algo = "";
                        try
                        {
                            algo = reader["Operador"].ToString().Substring(0, reader["Operador"].ToString().Length - 1).ToLower();
                        }
                        catch
                        {
                            algo = reader["Operador"].ToString();
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>" +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:82px;'>" +
                           reader["OT"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:240px;'>" +
                           reader["NombreOT"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                           "<a title='" + reader["Processo"].ToString() + "'>" + reader["Pliego"].ToString() + "</a></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                           reader["Estado"].ToString().Replace("+", "'") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                            TeoPrep.ToString("N0").Replace(",", ".") + " (" + TeoricoPrep + "%)</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                            MermaPrepReal + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                            TeoTiraje.ToString("N0").Replace(",", ".") + " (" + TeoricoTiraje + "%)</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                            MermaTirReal + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                            Convert.ToInt32(reader["Planificada"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                            Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                            Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                            CantidadWIP + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:100px;'>" +
                            algo + "</td>" +
                            "</tr>";
                    }
                    else
                    {
                        TotalTeoPreparacion = 0; TotalTeoPreparacion = TotalTeoPreparacion + TeoPrep;
                        TotalRealPreparacion = 0; TotalRealPreparacion = TotalRealPreparacion + RealPrep;
                        TotalTeoTiraje = 0; TotalTeoTiraje = TotalTeoTiraje + TeoTiraje;
                        TotalRealTiraje = 0; TotalRealTiraje = TotalRealTiraje + RealTiraje;
                        TotalPlanificado = 0; TotalPlanificado = TotalPlanificado + Plani;
                        TotalProducido = 0; TotalProducido = TotalProducido + Buenos;
                        TotalGiros = 0; TotalGiros = TotalGiros + Giros;
                        TotalWIP = 0; TotalWIP = TotalWIP + BuenosWIP;
                        Contenido = Contenido + Totales + "</tbody></table><br/>" + Encabezado +
                           "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>" +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:82px;'>" +
                           reader["OT"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:240px;'>" +
                           reader["NombreOT"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                           "<a title='" + reader["Processo"].ToString() + "'>" + reader["Pliego"].ToString() + "</a></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                           reader["Estado"].ToString().Replace("+", "'") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                           TeoPrep.ToString("N0").Replace(",", ".") + " (" + TeoricoPrep + "%)</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                           MermaPrepReal + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                           TeoTiraje.ToString("N0").Replace(",", ".") + " (" + TeoricoTiraje + "%)</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:90px;'>" +
                           MermaTirReal + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                           Convert.ToInt32(reader["Planificada"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                           Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                           Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                           CantidadWIP + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:100px;'>" +
                          ((reader["Operador"].ToString().Length > 0) ? reader["Operador"].ToString().Substring(0, reader["Operador"].ToString().Length - 1).ToLower() : "") + "</td>" +
                           "</tr>";
                    }
                    MaquinaAnt = reader["CodRecurso"].ToString();
                }
            }
            conexion.CerrarConexion();
            return Encabezado + Contenido + Totales + "</tbody></table>";
        }

        public string Produccion_CorreoMermas_ENC_V2(string FechaInicio, string FechaTermino, int Procedimiento)
        {
            string MaquinaAnt = ""; int TeoPrep = 0; int RealPrep = 0; int TeoTiraje = 0; int RealTiraje = 0; int Plani = 0; string MermaPrepReal = ""; string MermaTirReal = "";
            string TeoricoPrep = ""; string TeoricoTiraje = ""; string Totales = ""; int TotalTeoPreparacion = 0; int TotalRealPreparacion = 0; int TotalTeoTiraje = 0; string Pliego = "";
            int TotalRealTiraje = 0; int TotalPlanificado = 0; int TotalProducido = 0; string Contenido = ""; int Buenos = 0; int BuenosPositivo = 0; int BuenosNegativos = 0;
            string Operador = "";
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1238px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:96px;'>Máquina</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>OT</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Nombre OT</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:150px;'>Pliego</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>Merma Preparación Teórica</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:99px;'>Merma Preparación Real</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:99px;'>Merma Tiraje Teórica</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:99px;'>Merma Tiraje Real</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:68px;'>Cantidad Planificada</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:69px;'>Cantidad Producida</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>Operador</td>" +
          "</tr>";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_CorreoMermas_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (MaquinaAnt == "" || reader["CodRecurso"].ToString() == MaquinaAnt)
                    {
                        TeoPrep = Convert.ToInt32(reader["TeoricaPreparacion"].ToString());
                        TotalTeoPreparacion += TeoPrep;
                        RealPrep = Convert.ToInt32(reader["MalosPreparacion"].ToString());
                        TotalRealPreparacion += RealPrep;
                        TeoTiraje = Convert.ToInt32(reader["TeoricaTiraje"].ToString());
                        TotalTeoTiraje += TeoTiraje;
                        RealTiraje = Convert.ToInt32(reader["MalosTiraje"].ToString());
                        TotalRealTiraje += RealTiraje;
                        Plani = Convert.ToInt32(reader["Planificada"].ToString());
                        TotalPlanificado += Plani;
                        Buenos = Convert.ToInt32(reader["Buenos"].ToString());
                        TotalProducido += Buenos;
                        BuenosPositivo = Buenos + ((Buenos * 10) / 100);
                        BuenosNegativos = Buenos - ((Buenos * 10) / 100);

                        if (Plani > 0)
                        {
                            TeoricoPrep = (Convert.ToDouble(Convert.ToDouble(TeoPrep) / Convert.ToDouble(Plani)) * 100).ToString("N2");
                            TeoricoTiraje = (Convert.ToDouble(Convert.ToDouble(TeoTiraje) / Convert.ToDouble(Plani)) * 100).ToString("N2");
                        }
                        else
                        {
                            TeoricoPrep = "0,00";
                            TeoricoTiraje = "0,00";
                        }
                        if (reader["Operador"].ToString().Trim() == "")
                        {
                            Operador = "";
                        }
                        else
                        {
                            Operador = reader["Operador"].ToString().Substring(0, reader["Operador"].ToString().Length - 1).ToLower();
                        }

                        if (reader["Componente"].ToString().ToLower().Trim() == "enc")
                        {
                            Pliego = "<a title='" + reader["Processo"].ToString() + "'>" + reader["Processo"].ToString().Replace(reader["Componente"].ToString(), "") + "</a>";
                        }
                        else
                        {
                            Pliego = "<a title='" + reader["Processo"].ToString() + "'>" + reader["Componente3"].ToString() + "</a>";
                        }
                        #region Teoricos PRep y tiraje
                        if (TeoPrep == 0 && RealPrep == 0)
                        {
                            MermaPrepReal = "<div style='color:red;'>0 (0,00%)</div>";
                        }
                        else
                        {
                            if (RealPrep == 0)
                            {
                                MermaPrepReal = "<div style='color:red;'>0 (0,00%)</div>";
                            }
                            else if (RealPrep <= 1500)
                            {
                                MermaPrepReal = RealPrep.ToString("N0").Replace(",", ".") + " (" + ((Convert.ToDouble(Convert.ToDouble(RealPrep) / Convert.ToDouble(Buenos)) * 100).ToString("N2")) + "%)";
                            }
                            else
                            {
                                MermaPrepReal = "<div style='color:orange;'>" + RealPrep.ToString("N0").Replace(",", ".") + " (" + ((Convert.ToDouble(Convert.ToDouble(RealPrep) / Convert.ToDouble(Buenos)) * 100).ToString("N2")) + "%)" + "</div>";
                            }
                        }
                        if (TeoTiraje == 0 && RealTiraje == 0)
                        {
                            MermaTirReal = "0 (0,00%)";
                        }
                        else
                        {
                            if ((TeoTiraje - RealTiraje) >= 0)
                            {
                                MermaTirReal = RealTiraje.ToString("N0").Replace(",", ".") + " (" + (Convert.ToDouble(Convert.ToDouble(RealTiraje) / Convert.ToDouble(Buenos)) * 100).ToString("N2") + "%)";
                            }
                            else
                            {
                                MermaTirReal = "<div style='color:red;'>" + RealTiraje.ToString("N0").Replace(",", ".") + " (" + (Convert.ToDouble(Convert.ToDouble(RealTiraje) / Convert.ToDouble(Buenos)) * 100).ToString("N2") + "%)" + "</div>";
                            }
                        }
                        #endregion
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:96px;'>" +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                           reader["OT"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                           reader["NombreOT"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:150px;'>" +
                           Pliego + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:88px;'>" +
                           TeoPrep.ToString("N0").Replace(",", ".") + " (" + TeoricoPrep + "%)</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                           MermaPrepReal + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                           TeoTiraje.ToString("N0").Replace(",", ".") + " (" + TeoricoTiraje + "%)</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                           MermaTirReal + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:68px;'>" +
                           Convert.ToInt32(reader["Planificada"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:69px;'>" +
                           Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:130px;'>" +
                           Operador + "</td>" +
                           "</tr>";
                    }
                    else
                    {
                        Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:96px;'>" +
                                   "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                                   "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                                   "</td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:150px;'>" +
                                   "<b>Totales:</b></td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:88px;'>" +
                                   "<b>" + TotalTeoPreparacion.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalTeoPreparacion) / Convert.ToDouble(TotalPlanificado)) * 100).ToString("N2") + "%)</b></td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                                   "<b>" + TotalRealPreparacion.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalRealPreparacion) / Convert.ToDouble(TotalProducido)) * 100).ToString("N2") + "%)</b></td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                                   "<b>" + TotalTeoTiraje.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalTeoTiraje) / Convert.ToDouble(TotalPlanificado)) * 100).ToString("N2") + "%)</b></td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                                   "<b>" + TotalRealTiraje.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalRealTiraje) / Convert.ToDouble(TotalProducido)) * 100).ToString("N2") + "%)</b></td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:68px;'>" +
                                   "<b>" + TotalPlanificado.ToString("N0").Replace(",", ".") + "</b></td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:69px;'>" +
                                   "<b>" + TotalProducido.ToString("N0").Replace(",", ".") + "</b></td>" +
                                   "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:130px;'>" +
                                   "</td>" +
                                   "</tr>";


                        TeoPrep = Convert.ToInt32(reader["TeoricaPreparacion"].ToString());
                        TotalTeoPreparacion = 0; TotalTeoPreparacion += TeoPrep;
                        RealPrep = Convert.ToInt32(reader["MalosPreparacion"].ToString());
                        TotalRealPreparacion = 0; TotalRealPreparacion += RealPrep;
                        TeoTiraje = Convert.ToInt32(reader["TeoricaTiraje"].ToString());
                        TotalTeoTiraje = 0; TotalTeoTiraje += TeoTiraje;
                        RealTiraje = Convert.ToInt32(reader["MalosTiraje"].ToString());
                        TotalRealTiraje = 0; TotalRealTiraje += RealTiraje;
                        Plani = Convert.ToInt32(reader["Planificada"].ToString());
                        TotalPlanificado = 0; TotalPlanificado += Plani;
                        Buenos = Convert.ToInt32(reader["Buenos"].ToString());
                        TotalProducido = 0; TotalProducido += Buenos;
                        BuenosPositivo = Buenos + ((Buenos * 10) / 100);
                        BuenosNegativos = Buenos - ((Buenos * 10) / 100);
                        #region Validaciones
                        if (Plani > 0)
                        {
                            TeoricoPrep = (Convert.ToDouble(Convert.ToDouble(TeoPrep) / Convert.ToDouble(Plani)) * 100).ToString("N2");
                            TeoricoTiraje = (Convert.ToDouble(Convert.ToDouble(TeoTiraje) / Convert.ToDouble(Plani)) * 100).ToString("N2");
                        }
                        else
                        {
                            TeoricoPrep = "0,00";
                            TeoricoTiraje = "0,00";
                        }

                        if (reader["Operador"].ToString().Trim() == "")
                        {
                            Operador = "";
                        }
                        else
                        {
                            Operador = reader["Operador"].ToString().Substring(0, reader["Operador"].ToString().Length - 1).ToLower();
                        }
                        if (reader["Componente"].ToString().ToLower().Trim() == "enc")
                        {
                            Pliego = "<a title='" + reader["Processo"].ToString() + "'>" + reader["Processo"].ToString().Replace(reader["Componente"].ToString(), "") + "</a>";
                        }
                        else
                        {
                            Pliego = "<a title='" + reader["Processo"].ToString() + "'>" + reader["Componente3"].ToString() + "</a>";
                        }
                        #region Teoricos PRep y tiraje
                        if (TeoPrep == 0 && RealPrep == 0)
                        {
                            MermaPrepReal = "<div style='color:red;'>0 (0,00%)</div>";
                        }
                        else
                        {
                            if (RealPrep == 0)
                            {
                                MermaPrepReal = "<div style='color:red;'>0 (0,00%)</div>";
                            }
                            else if (RealPrep <= 1500)
                            {
                                MermaPrepReal = RealPrep.ToString("N0").Replace(",", ".") + " (" + ((Convert.ToDouble(Convert.ToDouble(RealPrep) / Convert.ToDouble(Buenos)) * 100).ToString("N2")) + "%)";
                            }
                            else
                            {
                                MermaPrepReal = "<div style='color:orange;'>" + RealPrep.ToString("N0").Replace(",", ".") + " (" + ((Convert.ToDouble(Convert.ToDouble(RealPrep) / Convert.ToDouble(Buenos)) * 100).ToString("N2")) + "%)" + "</div>";
                            }
                        }
                        if (TeoTiraje == 0 && RealTiraje == 0)
                        {
                            MermaTirReal = "0 (0,00%)";
                        }
                        else
                        {
                            if ((TeoTiraje - RealTiraje) >= 0)
                            {
                                MermaTirReal = RealTiraje.ToString("N0").Replace(",", ".") + " (" + (Convert.ToDouble(Convert.ToDouble(RealTiraje) / Convert.ToDouble(Buenos)) * 100).ToString("N2") + "%)";
                            }
                            else
                            {
                                MermaTirReal = "<div style='color:red;'>" + RealTiraje.ToString("N0").Replace(",", ".") + " (" + (Convert.ToDouble(Convert.ToDouble(RealTiraje) / Convert.ToDouble(Buenos)) * 100).ToString("N2") + "%)" + "</div>";
                            }
                        }
                        #endregion
                        #endregion
                        Contenido = Contenido + "</tbody></table><br/>" + Encabezado +
                           "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:96px;'>" +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                           reader["OT"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                           reader["NombreOT"].ToString().ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:150px;'>" +
                           Pliego + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:88px;'>" +
                           TeoPrep.ToString("N0").Replace(",", ".") + " (" + TeoricoPrep + "%)</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                           MermaPrepReal + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                           TeoTiraje.ToString("N0").Replace(",", ".") + " (" + TeoricoTiraje + "%)</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                           MermaTirReal + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:68px;'>" +
                           Convert.ToInt32(reader["Planificada"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:69px;'>" +
                           Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:130px;'>" +
                           Operador + "</td>" +
                            //"<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                            //"</td>" +
                           "</tr>";
                    }
                    MaquinaAnt = reader["CodRecurso"].ToString();
                }
                if (reader.Read() == false)
                {
                    Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:96px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                           "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:150px;'>" +
                           "<b>Totales:</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:88px;'>" +
                           "<b>" + TotalTeoPreparacion.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalTeoPreparacion) / Convert.ToDouble(TotalPlanificado)) * 100).ToString("N2") + "%)</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                           "<b>" + TotalRealPreparacion.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalRealPreparacion) / Convert.ToDouble(TotalProducido)) * 100).ToString("N2") + "%)</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                           "<b>" + TotalTeoTiraje.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalTeoTiraje) / Convert.ToDouble(TotalPlanificado)) * 100).ToString("N2") + "%)</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:99px;'>" +
                           "<b>" + TotalRealTiraje.ToString("N0").Replace(",", ".") + "(" + (Convert.ToDouble(Convert.ToDouble(TotalRealTiraje) / Convert.ToDouble(TotalProducido)) * 100).ToString("N2") + "%)</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:68px;'>" +
                           "<b>" + TotalPlanificado.ToString("N0").Replace(",", ".") + "</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:69px;'>" +
                           "<b>" + TotalProducido.ToString("N0").Replace(",", ".") + "</b></td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:130px;'>" +
                           "</td>" +
                           "</tr>";
                }
            }
            conexion.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }

        public string GenerarCorreoMermas(string TipoCorreo, string fi, string ft)
        {
            try
            {
                string[] FechaInicio = fi.Substring(0, fi.IndexOf(' ')).Split('-');
                string[] FechaTermino = ft.Substring(0, ft.IndexOf(' ')).Split('-');
                string FI = FechaInicio[2] + "/" + FechaInicio[1] + "/" + FechaInicio[0];
                string FT = FechaTermino[2] + "/" + FechaTermino[1] + "/" + FechaTermino[0]; 
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                if (TipoCorreo == "Rotativas")
                {
                    mmsg.To.Add("reporte_rotativas@aimpresores.cl");
                    mmsg.To.Add("juan.venegas@aimpresores.cl");
                    mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                    mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                                "<br/><br/>Estimado(a):" +
                                "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta informacion correspondiente al día de ayer." +
                                "<br/><br/>" +
                                "<a href='http://intranet.qgchile.cl/View/Imprimir_CorreoMerma.aspx?t=" + TipoCorreo + "&fi=" + FI + "&ft=" + FT + "' target='_blank'>Imprimir</a>" +
                                "<br/><br/>" +
                                "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                                Produccion_CorreoMermas_V2(fi, ft, -1) +
                                "<br/>" +
                                "<br />" +
                                "Atentamente," +
                                "<br />" +
                                "<b>Equipo de desarrollo A Impresores S.A.</b>";
                }
                else if (TipoCorreo == "Planas")
                {
                    mmsg.To.Add("reporte_planas@aimpresores.cl");
                    mmsg.To.Add("juan.venegas@aimpresores.cl");
                    mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                    mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                        "<br/><br/>Estimado(a):" +
                        "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta informacion correspondiente al día de ayer." +
                        "<br/><br/>" +
                        "<a href='http://intranet.qgchile.cl/View/Imprimir_CorreoMerma.aspx?t=" + TipoCorreo + "&fi=" + FI + "&ft=" + FT + "' target='_blank'>Imprimir</a>" +
                        "<br/><br/>" +
                        "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                        Produccion_CorreoMermas_V2(fi, ft, 0) +
                        "<br/>" +
                        "<br />" +
                        "Atentamente," +
                        "<br />" +
                        "<b>Equipo de desarrollo A Impresores S.A.</b>";
                }
                else if (TipoCorreo == "ENC")
                {
                    mmsg.To.Add("reporte_encuadernacion@aencuadernadores.cl");
                    mmsg.To.Add("juan.venegas@aimpresores.cl");
                    mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                    mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                        "<br/><br/>Estimado(a):" +
                        "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta informacion correspondiente al día de ayer." +
                        "<br/><br/>" +
                        "<a href='http://intranet.qgchile.cl/View/Imprimir_CorreoMerma.aspx?t=" + TipoCorreo + "&fi=" + FI + "&ft=" + FT + "' target='_blank'>Imprimir</a>" +
                        "<br/><br/>" +
                        "<b><div style='font-size: 20px;'>Producción Encuadernación</div></b>" +
                        Produccion_CorreoMermas_ENC_V2(fi, ft, 1) +
                        "<br/>" +
                        "<br />" +
                        "Atentamente," +
                        "<br />" +
                        "<b>Equipo de desarrollo A Impresores S.A.</b>";
                }
                else
                {
                    mmsg.To.Add("reporte_produccion@aimpresores.cl");
                    mmsg.To.Add("juan.venegas@aimpresores.cl");
                    mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                    mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                        "<br/><br/>Estimado(a):" +
                        "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta informacion correspondiente al día de ayer." +
                        "<br/><br/>" +
                        "<a href='http://intranet.qgchile.cl/View/Imprimir_CorreoMerma.aspx?t=" + TipoCorreo + "&fi=" + FI + "&ft=" + FT + "' target='_blank'>Imprimir</a>" +
                        "<br/><br/>" +
                        "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                        Produccion_CorreoMermas_V2(fi, ft, -1) +
                        "<br/>" +
                        "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                        Produccion_CorreoMermas_V2(fi, ft, 0) +
                        "<br/>" +
                        "<b><div style='font-size: 20px;'>Producción Encuadernación</div></b>" +
                        Produccion_CorreoMermas_ENC_V2(fi, ft, 1) +
                        "<br/>" +
                        "<br />" +
                        "Atentamente," +
                        "<br />" +
                        "<b>Equipo de desarrollo A Impresores S.A.</b>";
                }
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Informe de Mermas y Producción " + fi;//.ToString("dd/MM/yyyy");
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("mermas.produccion@aimpresores.cl");
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials =
                    new System.Net.NetworkCredential("mermas.produccion@aimpresores.cl", "abcd55..");

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
                GenerarCorreoErrordeEnvio("GenerarCorreoMermas", "Especifico", NombreProcedure, fi//.ToString("dd-MM-yyy HH:mm:ss") 
                    + "," + ft//.ToString("dd-MM-yyy HH:mm:ss")
                    + "," + TipoCorreo, e.Message);
                return "Error Enviado";
            }
        }
        //FIN CORREO MERMAS Y PRODUCCION

        public string GenerarCorreoInformeNotasPendientes()
        {
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                List<Factura> lista = new List<Factura>();
                List<Factura> listaCorreo = new List<Factura>();

                if (cmd != null)
                {
                    try
                    {
                        cmd.CommandText = "Adm_Nota_ListCorreo";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Factura fac = new Factura();
                            fac.CantItem = reader["OT"].ToString();//OT
                            fac.CreadaPor = reader["NombreOT"].ToString();//Nombre OT
                            fac.FechaEmision = reader["Clasificacion"].ToString();//Clasificacion
                            fac.Folio = reader["TipoNota"].ToString();//TipoNota
                            fac.RutEmisor = reader["Responsable"].ToString();//Responsable
                            fac.Estado = reader["PersonaEncargada"].ToString();
                            fac.VerMas = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("MM-dd-yyyy HH:mm:ss");
                            lista.Add(fac);
                        }


                        string OT = ""; string Clasificacion = ""; string TipoNota = ""; int Contador = 0;
                        Factura itemFinal = new Factura();
                        foreach (Factura factu in lista)
                        {
                            Contador++;
                            if (Contador == 1)
                            {
                                listaCorreo.Add(factu);
                            }
                            if (Contador > 1)
                            {
                                if (OT != factu.CantItem)
                                {
                                    if (factu.Folio != "Solucion")
                                    {
                                        listaCorreo.Add(factu);
                                    }
                                }
                                else
                                {
                                    if (Clasificacion != factu.FechaEmision)
                                    {
                                        listaCorreo.Add(factu);
                                    }
                                }
                            }
                            OT = factu.CantItem;
                            Clasificacion = factu.FechaEmision;
                            TipoNota = factu.Folio;
                        }


                        System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                        mmsg.To.Add("generarcorreoinformenotaspendientes@aimpresores.cl");
                        mmsg.Body = "<table id='example' style='width: 100%;max-width: 100%;margin-bottom: 20px;border: 1px solid #ddd !important;background-color: transparent; " +
                        "border-collapse: collapse;box-sizing: border-box;font-family: Helvetica Neue, Helvetica, Arial, sans-serif;font-size: 14px;line-height: 1.42857143;color: #333;box-sizing: border-box;' cellspacing='0'> " +
                            "<thead>" +
                                "<tr>" +
                                    "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>OT</th>" +
                                    "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>Nombre OT</th>" +
                                    "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>Clasificación</th>" +
                                    "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>Encargado Responsable</th>" +
                                    "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>Persona Responsable</th>" +
                                    "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>Tiempo Trascurrido</th>" +
                                "</tr>" +
                            "</thead>" +
                                "<tbody style='display: table-row-group;vertical-align: middle;border-spacing: 2px;border-color: grey;border-color: inherit;'>";
                        string Correo = "";
                        foreach (Factura factu in listaCorreo)
                        {
                            TimeSpan time;
                            time = (DateTime.Now - Convert.ToDateTime(factu.VerMas));

                            Correo += "<tr  style='line-height: 1.42857143;vertical-align: top;border: 1px solid #ddd;background-color:#f5f5f5;'>" +
                                     "<td style='padding: 8px;border: 1px solid #ddd;text-align:right;'> " + factu.CantItem + "</td>" +
                                     "<td style='padding: 8px;border: 1px solid #ddd;text-align:left;'> " + factu.CreadaPor + "</td>" +
                                     "<td style='padding: 8px;border: 1px solid #ddd;text-align:left;'> " + factu.FechaEmision + "</td>" +
                                     "<td style='padding: 8px;border: 1px solid #ddd;text-align:left;'> " + factu.RutEmisor + "</td>" +
                                     "<td style='padding: 8px;border: 1px solid #ddd;text-align:left;'> " + factu.Estado + "</td>" +
                                     "<td style='padding: 8px;border: 1px solid #ddd;text-align:right;'> " + time.Days + " dias " + time.Hours + ":" + time.Minutes + ":" + time.Seconds + "</td>" +
                                     "</tr>";
                        }

                        mmsg.Body = mmsg.Body + Correo + "</tbody>" +
                                    "</table>" +
                                    "<br/>" +
                                    "<br />" +
                                    "Atentamente," +
                                        "<br />" +
                                    "Equipo de desarrollo A Impresores S.A";


                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                        mmsg.Subject = "Resumen Facturación " + DateTime.Now.ToString("MMMM");
                        mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                        mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                        mmsg.IsBodyHtml = true;
                        mmsg.From = new System.Net.Mail.MailAddress("reporte.facturacion@aimpresores.cl");
                        System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                        cliente.Credentials =
                            new System.Net.NetworkCredential("reporte.facturacion@aimpresores.cl", "fac66--");

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
                        GenerarCorreoErrordeEnvio("GenerarCorreoInformeNotasPendientes", "Especifico", NombreProcedure, "", e.Message);
                        return "Error Enviado";
                    }

                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception e)
            {
                string NombreProcedure0 = e.StackTrace.ToString().Substring(e.StackTrace.ToString().IndexOf("ProduccionController.") + 21, e.StackTrace.Length - (e.StackTrace.ToString().IndexOf("ProduccionController.") + 21));
                string NombreProcedure = NombreProcedure0.Substring(0, NombreProcedure0.IndexOf("("));
                GenerarCorreoErrordeEnvio("GenerarCorreoInformeNotasPendientes", "Especifico", NombreProcedure, "", e.Message);
                return "Error Enviado";
            }
        }

        public string Produccion_CorreoScoreCard_ENC(string Titulo, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = ""; string SectorAnt = ""; double TotalPliegos = 0; double TotalGiros = 0; double TotalMermaTiraje = 0; double HorasSinProducir = 0;
            double TotalMermaPreparacion = 0; double Entradas = 0; double TotalHorasTiraje = 0; double TotalHorasImp = 0; double TotalHorasPrep = 0; double TotalHorasSinProducir = 0;
            double HorasTiraje = 0; double HorasImp = 0; double HorasPrep = 0; string NombreTitulo = ""; string PromedioHorasPreparacion = ""; string ceros = "00"; double TotalHorasPreparacion = 0;
            double OTS = 0; double TotalOTS = 0; string TotalTirajePromedio = ""; string TotalVelocidadMDR = ""; string TotalVelocidad = ""; string TotalUptime = ""; string TotalPorcMermaPrep = "";
            if (Titulo == "Diario")
            {
                NombreTitulo = "Score Card Diario Encuadernación " + FechaInicio.ToString("dd/MM/yyyy");
            }
            else
            {
                NombreTitulo = "Score Card Mensual Encuadernación " + FechaInicio.ToString("dd/MM/yyyy") + " al " + FechaTermino.ToString("dd/MM/yyyy");
            }
            string TirajePromedio = ""; string VelMRD = ""; string Velocidad = ""; string Uptime = ""; string MermaArranque = ""; string Capacidad = "";
            string MArranque = ""; string MTiraje = "";
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1172px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font: 13px Arial;font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='15'>" + NombreTitulo + "</td></tr>" +
              "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                "Máquinas</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:83px;'>" +
                "Ejemplares</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:83px;'>" +
                "Giros</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Preparación Promedio</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Tiraje<br />&nbsp;Promedio</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Velocidad<br />(MRD)</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
            "Velocidad</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Uptime</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
            "    Mermas<br />Tiraje</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Mermas Arranque % </td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Mermas Arranque</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Capacidad</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "Horas Sin Vender</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   Entradas</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:73px;'>" +
             "   OTs <br />Trabajadas</td> " +
          "</tr>";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_CorreoScoreCard_ENC]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (SectorAnt == "" || SectorAnt == reader["CodSetor"].ToString())
                    {
                        TotalPliegos += Convert.ToDouble(reader["Buenos"].ToString());
                        TotalGiros += Convert.ToDouble(reader["Giros"].ToString());
                        TotalMermaTiraje += Convert.ToDouble(reader["PliegosMalosTiraje"].ToString());
                        TotalMermaPreparacion += Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString());
                        TotalHorasTiraje += Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;
                        TotalHorasPrep += Convert.ToDouble(reader["HorasPreparacion"].ToString()) / 3600;
                        TotalHorasPreparacion += Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        TotalHorasImp += Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                        TotalHorasSinProducir += Convert.ToDouble(reader["HorasSinTrabajo"].ToString()) / 3600;
                        HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;
                        HorasPrep = Convert.ToDouble(reader["HorasPreparacion"].ToString()) / 3600;
                        HorasImp = Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                        HorasSinProducir = Convert.ToDouble(reader["HorasSinTrabajo"].ToString()) / 3600;
                        Entradas += Convert.ToDouble(reader["Entradas"].ToString());
                        OTS = Convert.ToDouble(reader["OTS"].ToString());
                        TotalOTS += Convert.ToDouble(reader["OTS"].ToString());
                        if (Convert.ToInt32(reader["Entradas"].ToString()) > 0)
                        {
                            TirajePromedio = (Convert.ToInt32(reader["Giros"].ToString()) / Convert.ToInt32(reader["Entradas"].ToString())).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            TirajePromedio = "0";
                        }
                        if ((HorasPrep + HorasTiraje + HorasImp) > 0)
                        {
                            VelMRD = ((Convert.ToDouble(reader["Giros"].ToString())) / (HorasPrep + HorasTiraje + HorasImp)).ToString("N0");
                        }
                        else
                        {
                            VelMRD = "0";
                        }

                        if (HorasTiraje > 0)
                        {
                            Velocidad = (Convert.ToDouble(reader["Giros"].ToString()) / (HorasTiraje)).ToString("N0");
                        }
                        else
                        {
                            Velocidad = "0";
                        }
                        if ((HorasTiraje + HorasImp) > 0)
                        {
                            Uptime = (((HorasTiraje) / (HorasTiraje + HorasImp)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            Uptime = "0";
                        }

                        if (Convert.ToInt32(reader["Giros"].ToString()) > 0)
                        {
                            MermaArranque = ((Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString()) / Convert.ToDouble(reader["Giros"].ToString())) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            MermaArranque = "0,00%";
                        }
                        if (Titulo == "Diario")
                        {
                            Capacidad = (((HorasTiraje + HorasPrep + HorasImp) / Convert.ToDouble(24)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            Capacidad = (((HorasTiraje + HorasPrep + HorasImp) / Convert.ToDouble(24 * (Convert.ToDouble(FechaTermino.ToString("dd"))))) * 100).ToString("N2") + "%";
                        }
                        if (Titulo == "Diario")
                        {
                            MArranque = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                            MTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            if (Convert.ToDouble(reader["Entradas"].ToString()) > 0)
                            {
                                MArranque = (Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString()) / Convert.ToDouble(reader["Entradas"].ToString())).ToString("N0").Replace(",", ".");
                            }
                            else
                            {
                                MArranque = "0";
                            }

                            if (HorasTiraje > 0)
                            {
                                MTiraje = ((Convert.ToDouble(reader["PliegosMalosTiraje"].ToString()) / Convert.ToDouble(reader["Giros"].ToString())) * 100).ToString("N2") + "%";
                            }
                            else
                            {
                                MTiraje = "0,00%";
                            }
                        }
                        if (Convert.ToDouble(reader["Entradas"].ToString()) > 0)
                        {
                            //PromedioHorasPreparacion = ((HorasPrep) / Convert.ToDouble(reader["Entradas"].ToString())).ToString("N1");
                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()) / Convert.ToDouble(reader["Entradas"].ToString()));
                            int Dias2 = t2.Days * 24;
                            PromedioHorasPreparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                        }
                        else
                        {
                            PromedioHorasPreparacion = "0:00:00";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                           Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                           Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           PromedioHorasPreparacion + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           TirajePromedio + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           VelMRD + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Velocidad + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Uptime + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MTiraje + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MermaArranque + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MArranque + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Capacidad + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           (HorasSinProducir).ToString("N1") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Convert.ToInt32(reader["Entradas"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           OTS.ToString("N0").Replace(",", ".") + "</td>" +
                           "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                    else
                    {
                        string Cap = "";
                        if (Titulo == "Diario")
                        {
                            //if (rr == "IMP ROT")
                            //{
                            Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 4)) * 100).ToString("N2") + "%";
                            //}
                            //else
                            //{
                            //    Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 4)) * 100).ToString("N2") + "%";
                            //}                           
                        }
                        else
                        {
                            Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 5 * (Convert.ToDouble(FechaTermino.ToString("dd"))))) * 100).ToString("N2") + "%";
                        }
                        if (Titulo == "Diario")
                        {
                            MArranque = (TotalMermaPreparacion).ToString("N0").Replace(",", ".");
                            MTiraje = (TotalMermaTiraje).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            if (Entradas > 0)
                            {
                                MArranque = (TotalMermaPreparacion / Entradas).ToString("N0").Replace(",", ".");
                            }
                            else
                            {
                                MArranque = "0";
                            }
                            if (TotalHorasTiraje > 0)
                            {
                                MTiraje = (((TotalMermaTiraje) / TotalGiros) * 100).ToString("N2") + "%";
                            }
                            else
                            {
                                MTiraje = "0,00%";
                            }
                        }
                        if (Entradas > 0)
                        {
                            //PromedioHorasPreparacion = (TotalHorasPrep / Entradas).ToString("N1");
                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(TotalHorasPreparacion) / Entradas);
                            int Dias2 = t2.Days * 24;
                            PromedioHorasPreparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                            TotalTirajePromedio = Convert.ToInt32((Convert.ToInt32(TotalGiros)) / (Convert.ToInt32(Entradas))).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            PromedioHorasPreparacion = "0:00:00";
                            TotalTirajePromedio = "0";
                        }
                        if ((TotalHorasPrep + TotalHorasTiraje + TotalHorasImp) > 0)
                        {
                            TotalVelocidadMDR = ((Convert.ToDouble(TotalGiros)) / (TotalHorasPrep + TotalHorasTiraje + TotalHorasImp)).ToString("N0");
                        }
                        else
                        {
                            TotalVelocidadMDR = "0";
                        }
                        if (TotalHorasTiraje > 0)
                        {
                            TotalVelocidad = ((TotalGiros) / (TotalHorasTiraje)).ToString("N0");
                        }
                        else
                        {
                            TotalVelocidad = "0";
                        }
                        if ((TotalHorasTiraje + TotalHorasImp) > 0)
                        {
                            TotalUptime = (((TotalHorasTiraje) / (TotalHorasTiraje + TotalHorasImp)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            TotalUptime = "0,00%";
                        }
                        if (TotalGiros > 0)
                        {
                            TotalPorcMermaPrep = (((TotalMermaPreparacion) / (TotalGiros)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            TotalPorcMermaPrep = "0,00%";
                        }
                        //Totales
                        Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                          "<b>TOTAL " + SectorAnt + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                          "<b>" + Convert.ToInt32(TotalPliegos).ToString("N0").Replace(",", ".") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                          "<b>" + Convert.ToInt32(TotalGiros).ToString("N0").Replace(",", ".") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + PromedioHorasPreparacion + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + TotalTirajePromedio + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + TotalVelocidadMDR + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + TotalVelocidad + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + TotalUptime + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + MTiraje + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + TotalPorcMermaPrep + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + MArranque + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + Cap + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + (TotalHorasSinProducir).ToString("N1") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + Convert.ToInt32(Entradas).ToString("N0").Replace(",", ".") + "</b></td>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                          "<b>" + TotalOTS.ToString("N0").Replace(",", ".") + "</b></td>" +
                          "</tr>";

                        TotalPliegos = 0; TotalPliegos += Convert.ToDouble(reader["Buenos"].ToString());
                        TotalGiros = 0; TotalGiros += Convert.ToDouble(reader["Giros"].ToString());
                        TotalMermaTiraje = 0; TotalMermaTiraje += Convert.ToDouble(reader["PliegosMalosTiraje"].ToString());
                        TotalMermaPreparacion = 0; TotalMermaPreparacion += Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString());
                        TotalHorasTiraje = 0; TotalHorasTiraje += Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;
                        TotalHorasPrep = 0; TotalHorasPrep += Convert.ToDouble(reader["HorasPreparacion"].ToString()) / 3600;
                        TotalHorasPreparacion = 0; TotalHorasPreparacion += Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        TotalHorasImp = 0; TotalHorasImp += Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                        TotalHorasSinProducir = 0; TotalHorasSinProducir += Convert.ToDouble(reader["HorasSinTrabajo"].ToString()) / 3600;
                        HorasSinProducir = 0; HorasSinProducir += Convert.ToDouble(reader["HorasSinTrabajo"].ToString()) / 3600;
                        HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;
                        HorasPrep = Convert.ToDouble(reader["HorasPreparacion"].ToString()) / 3600;
                        HorasImp = Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                        Entradas = 0; Entradas += Convert.ToDouble(reader["Entradas"].ToString());
                        TotalOTS = 0; TotalOTS += Convert.ToDouble(reader["OTS"].ToString());
                        OTS = Convert.ToDouble(reader["OTS"].ToString());
                        if (Convert.ToInt32(reader["Entradas"].ToString()) > 0)
                        {
                            TirajePromedio = (Convert.ToInt32(reader["Giros"].ToString()) / Convert.ToInt32(reader["Entradas"].ToString())).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            TirajePromedio = "0";
                        }
                        if ((HorasPrep + HorasTiraje + HorasImp) > 0)
                        {
                            VelMRD = ((Convert.ToDouble(reader["Giros"].ToString())) / (HorasPrep + HorasTiraje + HorasImp)).ToString("N0");
                        }
                        else
                        {
                            VelMRD = "0";
                        }

                        if (HorasTiraje > 0)
                        {
                            Velocidad = (Convert.ToDouble(reader["Giros"].ToString()) / (HorasTiraje)).ToString("N0");
                        }
                        else
                        {
                            Velocidad = "0";
                        }
                        if ((HorasTiraje + HorasImp) > 0)
                        {
                            Uptime = (((HorasTiraje) / (HorasTiraje + HorasImp)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            Uptime = "0";
                        }

                        if (Convert.ToInt32(reader["Giros"].ToString()) > 0)
                        {
                            MermaArranque = ((Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString()) / Convert.ToDouble(reader["Giros"].ToString())) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            MermaArranque = "0,00%";
                        }

                        if (Titulo == "Diario")
                        {
                            Capacidad = (((HorasTiraje + HorasPrep + HorasImp) / Convert.ToDouble(24)) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            Capacidad = (((HorasTiraje + HorasPrep + HorasImp) / Convert.ToDouble(24 * (Convert.ToDouble(FechaTermino.ToString("dd"))))) * 100).ToString("N2") + "%";
                        }
                        if (Titulo == "Diario")
                        {
                            MArranque = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                            MTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            if (Convert.ToDouble(reader["Entradas"].ToString()) > 0)
                            {
                                MArranque = (Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString()) / Convert.ToDouble(reader["Entradas"].ToString())).ToString("N0").Replace(",", ".");
                            }
                            else
                            {
                                MArranque = "0";
                            }
                            if (HorasTiraje > 0)
                            {
                                MTiraje = ((Convert.ToDouble(reader["PliegosMalosTiraje"].ToString()) / Convert.ToDouble(reader["Giros"].ToString())) * 100).ToString("N2") + "%";
                            }
                            else
                            {
                                MTiraje = "0,00%";
                            }
                        }
                        if (Convert.ToDouble(reader["Entradas"].ToString()) > 0)
                        {
                            //PromedioHorasPreparacion = ((HorasPrep) / Convert.ToDouble(reader["Entradas"].ToString())).ToString("N1");
                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()) / Convert.ToDouble(reader["Entradas"].ToString()));
                            int Dias2 = t2.Days * 24;
                            PromedioHorasPreparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                        }
                        else
                        {
                            PromedioHorasPreparacion = "0:00:00";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                           Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                           Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           PromedioHorasPreparacion + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           TirajePromedio + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           VelMRD + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Velocidad + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Uptime + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MTiraje + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MermaArranque + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           MArranque + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Capacidad + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           (HorasSinProducir).ToString("N1") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           Convert.ToInt32(reader["Entradas"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                           OTS.ToString("N0").Replace(",", ".") + "</td>" +
                           "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                } if (reader.Read() == false)
                {
                    string TirajeProm = ""; string MRD = ""; string Vel = ""; string Upt = ""; string tGiros = ""; string Cap = "";
                    if (Entradas > 0)
                    {
                        TirajeProm = Convert.ToInt32((Convert.ToInt32(TotalGiros)) / (Convert.ToInt32(Entradas))).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        TirajeProm = "0";
                    }
                    if ((TotalHorasPrep + TotalHorasTiraje + TotalHorasImp) > 0)
                    {
                        MRD = ((Convert.ToDouble(TotalGiros)) / (TotalHorasPrep + TotalHorasTiraje + TotalHorasImp)).ToString("N0");
                    }
                    else
                    {
                        MRD = "0";
                    }
                    if ((TotalHorasTiraje) > 0)
                    {
                        Vel = ((TotalGiros) / (TotalHorasTiraje)).ToString("N0");
                    }
                    else
                    {
                        Vel = "0";
                    }//(TotalHorasTiraje + TotalHorasImp)
                    if ((TotalHorasTiraje + TotalHorasImp) > 0)
                    {
                        Upt = (((TotalHorasTiraje) / (TotalHorasTiraje + TotalHorasImp)) * 100).ToString("N2") + "%";
                    }
                    else
                    {
                        Upt = "0,00%";
                    }
                    if ((TotalGiros) > 0)
                    {
                        tGiros = (((TotalMermaPreparacion) / (TotalGiros)) * 100).ToString("N2") + "%";
                    }
                    else
                    {
                        tGiros = "0,00%";
                    }
                    if (Titulo == "Diario")
                    {
                        //if (reader["CodSetor"].ToString() == "IMP ROT")
                        //{
                        //    Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 5)) * 100).ToString("N2") + "%";
                        //}
                        //else
                        //{
                        Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 2)) * 100).ToString("N2") + "%";
                        //}    
                    }
                    else
                    {
                        Cap = (((TotalHorasTiraje + TotalHorasPrep + TotalHorasImp) / Convert.ToDouble(24 * 3 * (Convert.ToDouble(FechaTermino.ToString("dd"))))) * 100).ToString("N2") + "%";
                    }
                    if (Titulo == "Diario")
                    {
                        MArranque = (TotalMermaPreparacion).ToString("N0").Replace(",", ".");
                        MTiraje = (TotalMermaTiraje).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        if (Entradas > 0)
                        {
                            MArranque = (TotalMermaPreparacion / Entradas).ToString("N0").Replace(",", ".");
                        }
                        else
                        {
                            MArranque = "0";
                        }
                        if (TotalHorasTiraje > 0)
                        {
                            MTiraje = (((TotalMermaTiraje) / TotalGiros) * 100).ToString("N2") + "%";
                        }
                        else
                        {
                            MTiraje = "0,00%";
                        }
                    }
                    if (Entradas > 0)
                    {
                        //PromedioHorasPreparacion = (TotalHorasPrep / Entradas).ToString("N1");
                        TimeSpan t2 = TimeSpan.FromSeconds(TotalHorasPreparacion / Entradas);
                        int Dias2 = t2.Days * 24;
                        PromedioHorasPreparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                    }
                    else
                    {
                        PromedioHorasPreparacion = "0:00:00";
                    }
                    Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                        "<b>TOTAL " + SectorAnt + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                        "<b>" + Convert.ToInt32(TotalPliegos).ToString("N0").Replace(",", ".") + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                        "<b>" + Convert.ToInt32(TotalGiros).ToString("N0").Replace(",", ".") + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + PromedioHorasPreparacion + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + TirajeProm + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + MRD + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + Vel + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + Upt + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + MTiraje + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + tGiros + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + MArranque + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + Cap + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + (TotalHorasSinProducir).ToString("N1") + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + Convert.ToInt32(Entradas).ToString("N0").Replace(",", ".") + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        "<b>" + TotalOTS.ToString("N0").Replace(",", ".") + "</b></td>" +
                        "</tr>";
                }

            }
            conexion.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }

        public string GenerarCorreoScoreCard_ENC(DateTime fi, DateTime ft, DateTime PrimerDia, DateTime DiaActual)
        {
            try
            {
                string FI = fi.ToString("dd/MM/yyyy"); string FT = ft.ToString("dd/MM/yyyy");
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.To.Add("generarcorreoscorecard_enc@aimpresores.cl");

                mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                            "<br/><br/>Estimado(a):" +
                            "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta informacion correspondiente al día de ayer." +
                    "<br/>" +
                    "<a href='http://intranet.qgchile.cl/View/Imprimir_ScoreCard_Enc.aspx?fi=" + FI + "' target='_blank'>Imprimir</a>" +
                            "<br/><br/>" +
                    //"<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                            Produccion_CorreoScoreCard_ENC("Diario", fi, ft, 0) +
                            "<br/>" +
                            Produccion_CorreoScoreCard_ENC("Mensual",PrimerDia, ft, 1) +
                            "<br/>" +
                            "<div style='width:1203px;align=center;'>" +
                            "<br />" +
                             "Atentamente," +
                            "<br />" +
                            "<b>Equipo de desarrollo A Impresores S.A.</b>";

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Informe ScoreCard Encuadernación Diario " + fi.ToString("dd/MM/yyyy");
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("scorecard.produccion@aimpresores.cl");
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials =
                    new System.Net.NetworkCredential("scorecard.produccion@aimpresores.cl", "abcdsco222.");

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
                GenerarCorreoErrordeEnvio("GenerarCorreoScoreCard_ENC", "Especifico", NombreProcedure, fi.ToString("dd-MM-yyy HH:mm:ss") + "," + ft.ToString("dd-MM-yyy HH:mm:ss") + "," + PrimerDia + "," + DiaActual, e.Message);
                return "Error Enviado";
            }
        }

        //INICIO CORREO SEMANAL ENC
        public string Produccion_SemanalENC(DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = ""; string SectorAnt = ""; double TotalEntradas = 0; double TotalHorasPreparacion = 0; double TotalHorasTiraje = 0; double TotalHorasImproductivas = 0; double TotalBuenos = 0; string Velocidad = "";
            double Entradas = 0; double HorasPreparacion = 0; double TotalHPromedioPreparacion = 0; double HorasTiraje = 0; double HorasImproductivas = 0; double Buenos = 0; double HorasPromedioPreparacion = 0; string PorcProduccion = ""; string TotalVelocidad = ""; string TotalHPromPrep = "";
            string Hprep = ""; string PromPrep = ""; string HTiraje = ""; string HImp = ""; string ceros = "00"; double TotalProducido = 0;
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:914px;margin-left:3px;'>" +
            "<tbody>" +
            "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
            "<td style='font-size:14px;font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' colspan='9'> Producción por Semana</td></tr>" +
             " <tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:225px;'> " +
             "   Máquina</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
             "   Entradas</td>  " +
           " <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
           "     Horas Preparación</td> " +
           " <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
           "     Prom. Preparación</td>  " +
           " <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
           "     Horas Tiraje</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
            "    Horas Improductivas</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
            "    Buenos</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
             "   % Prod.</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:87px;'> " +
           "     Velocidad</td>  " +
          "</tr>";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_InformeDiario_ENC]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (SectorAnt == "" || SectorAnt == reader["CodSetor"].ToString())
                    {
                        Entradas = Convert.ToDouble(reader["Entradas"].ToString());
                        TotalEntradas += Entradas;
                        HorasPreparacion = Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        TotalHorasPreparacion += HorasPreparacion;
                        HorasPromedioPreparacion = Convert.ToDouble(reader["PromedioPreparacion"].ToString());
                        TotalHPromedioPreparacion += HorasPromedioPreparacion;
                        HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString());
                        TotalHorasTiraje += HorasTiraje;
                        HorasImproductivas = Convert.ToDouble(reader["HorasImproductivas"].ToString());
                        TotalHorasImproductivas += HorasImproductivas;
                        Buenos = Convert.ToDouble(reader["Buenos"].ToString());
                        TotalBuenos += Buenos;
                        TotalProducido = Convert.ToDouble(reader["TotalProducido"].ToString());

                        TimeSpan t8 = TimeSpan.FromSeconds(HorasPreparacion);
                        int Dias8 = t8.Days * 24;
                        Hprep = (t8.Hours + Dias8).ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Minutes.ToString().Length) + t8.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Seconds.ToString().Length) + t8.Seconds.ToString();

                        TimeSpan t7 = TimeSpan.FromSeconds(HorasPromedioPreparacion);
                        int Dias7 = t7.Days * 24;
                        PromPrep = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                        TimeSpan t6 = TimeSpan.FromSeconds(HorasTiraje);
                        int Dias6 = t6.Days * 24;
                        HTiraje = (t6.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                        TimeSpan t5 = TimeSpan.FromSeconds(HorasImproductivas);
                        int Dias5 = t5.Days * 24;
                        HImp = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                        if (HorasTiraje > 0)
                        {
                            Velocidad = (Buenos / (HorasTiraje / 3600)).ToString("N0");
                        }
                        else
                        {
                            Velocidad = "0";
                        }
                        if (TotalProducido > 0)
                        {
                            PorcProduccion = ((Buenos / TotalProducido) * 100).ToString("N2");
                        }
                        else
                        {
                            PorcProduccion = "0,00";
                        }

                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:225px;'> " +
                           reader["Maquina"].ToString() + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               Entradas.ToString("N0").Replace(",", ".") + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               Hprep + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               PromPrep + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               HTiraje + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               HImp + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               Buenos.ToString("N0").Replace(",", ".") + "</td> " +
                           "<td style='font-weight: normal; paddi ng: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               PorcProduccion.ToString() + "%</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:87px;'> " +
                               Velocidad + "</td> " +
                            "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                    else
                    {
                        TimeSpan t12 = TimeSpan.FromSeconds(TotalHPromedioPreparacion);
                        int Dias12 = t12.Days * 24;
                        TotalHPromPrep = (t12.Hours + Dias12).ToString() + ":" + ceros.Substring(0, ceros.Length - t12.Minutes.ToString().Length) + t12.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t12.Seconds.ToString().Length) + t12.Seconds.ToString();

                        TimeSpan t11 = TimeSpan.FromSeconds(TotalHorasTiraje);
                        int Dias11 = t11.Days * 24;
                        HTiraje = (t11.Hours + Dias11).ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Minutes.ToString().Length) + t11.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Seconds.ToString().Length) + t11.Seconds.ToString();

                        TimeSpan t10 = TimeSpan.FromSeconds(TotalHorasImproductivas);
                        int Dias10 = t10.Days * 24;
                        HImp = (t10.Hours + Dias10).ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Minutes.ToString().Length) + t10.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Seconds.ToString().Length) + t10.Seconds.ToString();

                        TimeSpan t9 = TimeSpan.FromSeconds(TotalHorasPreparacion);
                        int Dias9 = t9.Days * 24;
                        Hprep = (t9.Hours + Dias9).ToString() + ":" + ceros.Substring(0, ceros.Length - t9.Minutes.ToString().Length) + t9.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t9.Seconds.ToString().Length) + t9.Seconds.ToString();

                        if (TotalHorasTiraje > 0)
                        {
                            TotalVelocidad = (TotalBuenos / (TotalHorasTiraje / 3600)).ToString("N0");
                        }
                        else
                        {
                            TotalVelocidad = "0";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:225px;'> " +
                              "<b>TOTALES " + SectorAnt + "</b></td> " +
                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                              "<b>" + TotalEntradas.ToString() + "</b></td> " +
                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                              "<b>" + Hprep + "</b></td> " +
                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                              "<b>" + TotalHPromPrep + "</b></td> " +
                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                              "<b>" + HTiraje + "</b></td> " +
                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                              "<b>" + HImp + "</b></td> " +
                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                              "<b>" + TotalBuenos.ToString("N0").Replace(",", ".") + "</b></td> " +
                              "<td style='font-weight: normal; paddi ng: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                              "<b>100,00%</b></td> " +
                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:87px;'> " +
                              "<b>" + TotalVelocidad.ToString() + "</b></td> " +
                              "</tr>";
                        //FIN TOTALES


                        Entradas = Convert.ToDouble(reader["Entradas"].ToString());
                        TotalEntradas = 0; TotalEntradas += Entradas;
                        HorasPreparacion = Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        TotalHorasPreparacion = 0; TotalHorasPreparacion += HorasPreparacion;
                        HorasPromedioPreparacion = Convert.ToDouble(reader["PromedioPreparacion"].ToString());
                        TotalHPromedioPreparacion = 0; TotalHPromedioPreparacion += HorasPromedioPreparacion;
                        HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString());
                        TotalHorasTiraje = 0; TotalHorasTiraje += HorasTiraje;
                        HorasImproductivas = Convert.ToDouble(reader["HorasImproductivas"].ToString());
                        TotalHorasImproductivas = 0; TotalHorasImproductivas += HorasImproductivas;
                        Buenos = Convert.ToDouble(reader["Buenos"].ToString());
                        TotalBuenos = 0; TotalBuenos += Buenos;
                        TotalProducido = Convert.ToDouble(reader["TotalProducido"].ToString());

                        TimeSpan t8 = TimeSpan.FromSeconds(HorasPreparacion);
                        int Dias8 = t8.Days * 24;
                        Hprep = (t8.Hours + Dias8).ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Minutes.ToString().Length) + t8.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Seconds.ToString().Length) + t8.Seconds.ToString();

                        TimeSpan t7 = TimeSpan.FromSeconds(HorasPromedioPreparacion);
                        int Dias7 = t7.Days * 24;
                        PromPrep = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                        TimeSpan t6 = TimeSpan.FromSeconds(HorasTiraje);
                        int Dias6 = t6.Days * 24;
                        HTiraje = (t6.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                        TimeSpan t5 = TimeSpan.FromSeconds(HorasImproductivas);
                        int Dias5 = t5.Days * 24;
                        HImp = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                        if (HorasTiraje > 0)
                        {
                            Velocidad = (Buenos / (HorasTiraje / 3600)).ToString("N0");
                        }
                        else
                        {
                            Velocidad = "0";
                        }
                        if (TotalProducido > 0)
                        {
                            PorcProduccion = ((Buenos / TotalProducido) * 100).ToString("N2");
                        }
                        else
                        {
                            PorcProduccion = "0,00%";
                        }

                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:225px;'> " +
                           reader["Maquina"].ToString() + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               Entradas.ToString("N0").Replace(",", ".") + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               Hprep + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               PromPrep + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               HTiraje + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               HImp + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               Buenos.ToString("N0").Replace(",", ".") + "</td> " +
                           "<td style='font-weight: normal; paddi ng: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                               PorcProduccion.ToString() + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:87px;'> " +
                               Velocidad + "</td> " +
                            "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                }
                if (reader.Read() == false)
                {
                    TimeSpan t12 = TimeSpan.FromSeconds(TotalHPromedioPreparacion);
                    int Dias12 = t12.Days * 24;
                    TotalHPromPrep = (t12.Hours + Dias12).ToString() + ":" + ceros.Substring(0, ceros.Length - t12.Minutes.ToString().Length) + t12.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t12.Seconds.ToString().Length) + t12.Seconds.ToString();

                    TimeSpan t11 = TimeSpan.FromSeconds(TotalHorasTiraje);
                    int Dias11 = t11.Days * 24;
                    HTiraje = (t11.Hours + Dias11).ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Minutes.ToString().Length) + t11.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Seconds.ToString().Length) + t11.Seconds.ToString();

                    TimeSpan t10 = TimeSpan.FromSeconds(TotalHorasImproductivas);
                    int Dias10 = t10.Days * 24;
                    HImp = (t10.Hours + Dias10).ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Minutes.ToString().Length) + t10.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Seconds.ToString().Length) + t10.Seconds.ToString();

                    TimeSpan t9 = TimeSpan.FromSeconds(TotalHorasPreparacion);
                    int Dias9 = t9.Days * 24;
                    Hprep = (t9.Hours + Dias9).ToString() + ":" + ceros.Substring(0, ceros.Length - t9.Minutes.ToString().Length) + t9.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t9.Seconds.ToString().Length) + t9.Seconds.ToString();

                    if (TotalHorasTiraje > 0)
                    {
                        TotalVelocidad = (TotalBuenos / (TotalHorasTiraje / 3600)).ToString("N0");
                    }
                    else
                    {
                        TotalVelocidad = "0";
                    }
                    Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:225px;'> " +
                          "<b>TOTALES " + SectorAnt + "</b></td> " +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                          "<b>" + TotalEntradas.ToString() + "</b></td> " +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                          "<b>" + Hprep + "</b></td> " +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                          "<b>" + TotalHPromPrep + "</b></td> " +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                          "<b>" + HTiraje + "</b></td> " +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                          "<b>" + HImp + "</b></td> " +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                          "<b>" + TotalBuenos.ToString("N0").Replace(",", ".") + "</b></td> " +
                          "<td style='font-weight: normal; paddi ng: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                          "<b>100,00%</b></td> " +
                          "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:87px;'> " +
                          "<b>" + TotalVelocidad.ToString() + "</b></td> " +
                          "</tr>";
                    //FIN TOTALES
                }

            }
            conexion.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }

        public string Produccion_SemanalxTurnosENC(DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string Contenido = ""; string SectorAnt = "";
            double Noche = 0; double Mañana = 0; double Tarde = 0; double TotalNoche = 0; double TotalMañana = 0; double TotalTarde = 0; double TotalTurnos = 0; double TotalGeneralTurnos = 0; double TotalMensual = 0;
            string PorcNoche = ""; string PorcMañana = ""; string PorcTarde = "";
            #region Encabezado;
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:850px;margin-left:3px;'> " +
          "<tbody>" +
              "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:150px;' rowspan='2'>" +
                "Máquina</td>" +
            "<td style='font-size:14px;font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' colspan='3'> " +
                "Producción por Turnos</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;' rowspan='2'> " +
                "Total Semanal</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;' rowspan='2'> " +
                "Total Mensual<br/>(Últimos 30 días)</td>  " +
          "</tr>" +
          "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
                "Noche</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
                "Mañana</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:86px;'> " +
                "Tarde</td> " +
          "</tr>";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_InformeDiario_ENC]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader(); 
                while (reader.Read())
                {
                    if (SectorAnt == "" || SectorAnt == reader["CodSetor"].ToString())
                    {
                        Noche = Convert.ToDouble(reader["Noche"].ToString());
                        TotalNoche += Noche;
                        Mañana = Convert.ToDouble(reader["Mañana"].ToString());
                        TotalMañana += Mañana;
                        Tarde = Convert.ToDouble(reader["Tarde"].ToString());
                        TotalTarde += Tarde;
                        TotalTurnos = Convert.ToDouble(reader["TotalTurnos"].ToString());
                        TotalGeneralTurnos += TotalTurnos;
                        TotalMensual += Convert.ToDouble(reader["BuenosMensual"].ToString());
                        if (TotalTurnos > 0)
                        {
                            PorcNoche = Noche.ToString("N0").Replace(",", ".") + " (" + ((Noche / TotalTurnos) * 100).ToString("N2") + "%)";
                            PorcMañana = Mañana.ToString("N0").Replace(",", ".") + " (" + ((Mañana / TotalTurnos) * 100).ToString("N2") + "%)";
                            PorcTarde = Tarde.ToString("N0").Replace(",", ".") + " (" + ((Tarde / TotalTurnos) * 100).ToString("N2") + "%)";
                        }
                        else
                        {
                            PorcNoche = "0 (0,00%)";
                            PorcMañana = "0 (0,00%)";
                            PorcTarde = "0 (0,00%)";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:150px;'> " +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                           PorcNoche + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                           PorcMañana + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                           PorcTarde + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'> " +
                           TotalTurnos.ToString("N0").Replace(",", ".") + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'> " +
                           Convert.ToInt32(reader["BuenosMensual"].ToString()).ToString("N0").Replace(",", ".") + "</td> " +
                         "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                    else
                    {
                        if (TotalGeneralTurnos > 0)
                        {
                            PorcNoche = TotalNoche.ToString("N0").Replace(",", ".") + " (" + ((TotalNoche / TotalGeneralTurnos) * 100).ToString("N2") + "%)";
                            PorcMañana = TotalMañana.ToString("N0").Replace(",", ".") + " (" + ((TotalMañana / TotalGeneralTurnos) * 100).ToString("N2") + "%)";
                            PorcTarde = TotalTarde.ToString("N0").Replace(",", ".") + " (" + ((TotalTarde / TotalGeneralTurnos) * 100).ToString("N2") + "%)";
                        }
                        else
                        {
                            PorcNoche = "0 (0,00%)";
                            PorcMañana = "0 (0,00%)";
                            PorcTarde = "0 (0,00%)";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:150px;'> " +
                           "<b>TOTALES " + SectorAnt + "</b></td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                            "<b>" + PorcNoche + "</b></td> " +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                            "<b>" + PorcMañana + "</b></td> " +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                            "<b>" + PorcTarde + "</b></td> " +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'> " +
                            "<b>" + TotalGeneralTurnos.ToString("N0").Replace(",", ".") + "</b></td> " +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'> " +
                            "<b>" + TotalMensual.ToString("N0").Replace(",", ".") + "</b></td> " +
                          "</tr>";
                        //FIN TOTALES
                        Noche = Convert.ToDouble(reader["Noche"].ToString());
                        TotalNoche = 0; TotalNoche += Noche;
                        Mañana = Convert.ToDouble(reader["Mañana"].ToString());
                        TotalMañana = 0; TotalMañana += Mañana;
                        Tarde = Convert.ToDouble(reader["Tarde"].ToString());
                        TotalTarde = 0; TotalTarde += Tarde;
                        TotalTurnos = Convert.ToDouble(reader["TotalTurnos"].ToString());
                        TotalGeneralTurnos = 0; TotalGeneralTurnos += TotalTurnos;
                        TotalMensual = 0; TotalMensual += Convert.ToDouble(reader["BuenosMensual"].ToString());
                        if (TotalTurnos > 0)
                        {
                            PorcNoche = Noche.ToString("N0").Replace(",", ".") + " (" + ((Noche / TotalTurnos) * 100).ToString("N2") + "%)";
                            PorcMañana = Mañana.ToString("N0").Replace(",", ".") + " (" + ((Mañana / TotalTurnos) * 100).ToString("N2") + "%)";
                            PorcTarde = Tarde.ToString("N0").Replace(",", ".") + " (" + ((Tarde / TotalTurnos) * 100).ToString("N2") + "%)";
                        }
                        else
                        {
                            PorcNoche = "0 (0,00%)";
                            PorcMañana = "0 (0,00%)";
                            PorcTarde = "0 (0,00%)";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:150px;'> " +
                           reader["Maquina"].ToString() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                           PorcNoche + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                           PorcMañana + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                           PorcTarde + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'> " +
                           TotalTurnos.ToString("N0").Replace(",", ".") + "</td> " +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'> " +
                            Convert.ToInt32(reader["BuenosMensual"].ToString()).ToString("N0").Replace(",", ".") + "</td> " +
                         "</tr>";
                        SectorAnt = reader["CodSetor"].ToString();
                    }
                }
                if (reader.Read() == false)
                {
                    if (TotalGeneralTurnos > 0)
                    {
                        PorcNoche = TotalNoche.ToString("N0").Replace(",", ".") + " (" + ((TotalNoche / TotalGeneralTurnos) * 100).ToString("N2") + "%)";
                        PorcMañana = TotalMañana.ToString("N0").Replace(",", ".") + " (" + ((TotalMañana / TotalGeneralTurnos) * 100).ToString("N2") + "%)";
                        PorcTarde = TotalTarde.ToString("N0").Replace(",", ".") + " (" + ((TotalTarde / TotalGeneralTurnos) * 100).ToString("N2") + "%)";
                    }
                    else
                    {
                        PorcNoche = "0 (0,00%)";
                        PorcMañana = "0 (0,00%)";
                        PorcTarde = "0 (0,00%)";
                    }
                    Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:150px;'> " +
                       "<b>TOTALES " + SectorAnt + "</b></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                        "<b>" + PorcNoche + "</b></td> " +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                        "<b>" + PorcMañana + "</b></td> " +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:86px;'> " +
                        "<b>" + PorcTarde + "</b></td> " +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'> " +
                        "<b>" + TotalGeneralTurnos.ToString("N0").Replace(",", ".") + "</b></td> " +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:100px;'> " +
                        "<b>" + TotalMensual.ToString("N0").Replace(",", ".") + "</b></td> " +
                      "</tr>";
                    //FIN TOTALES
                }

            }
            conexion.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }

        public string GenerarCorreoSemanal_ENC(DateTime fi, DateTime ft)
        {
            try
            {
                string FI = fi.ToString("dd/MM/yyyy"); string FT = ft.ToString("dd/MM/yyyy");
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.To.Add("generarcorreosemanal_enc@aimpresores.cl");
                mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                            "<br/><br/>Estimado(a):" +
                            "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta información correspondiente desde el día <b>" + FI + " al " + FT + "<b>." +
                    "<br/>" +
                    "<a href='http://intranet.qgchile.cl/View/Imprimir_ProduccionENC_Semanal.aspx?fi=" + FI + "&ft=" + FT + "' target='_blank'>Imprimir</a>" +
                            "<br/><br/>" +
                     Produccion_SemanalENC(fi, ft, 0) +
                "<td>" +
                    Produccion_SemanalxTurnosENC(fi, ft, 1) +
                            "<br/>" +
                            "<br />" +
                             "Atentamente," +
                            "<br />" +
                            "<b>Equipo de desarrollo A Impresores S.A.</b>";

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Informe Producción por Semana " + FI + " al " + FT;
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
                GenerarCorreoErrordeEnvio("CorreoEncuadernacion_CorreoSemanal", "Especifico", NombreProcedure, fi.ToString("dd-MM-yyy HH:mm:ss") + "," + ft.ToString("dd-MM-yyy HH:mm:ss"), e.Message);
                return "Error Enviado";
            }
        }

        //FIN CORREO SEMANAL ENC
        public string GenerarCorreoInformeFacturacion(string año, string mes, string dia)
        {
            try
            {
                Facturacion_ElectronicaSII fact_2000 = DatosFacturacion2000(dia, mes, año);
                Facturacion_ElectronicaSII fact_2012 = DatosFacturacion2012(dia, mes, año);
                string DiferenciaSII = (Convert.ToDouble(fact_2000.Valor_Neto.ToString()) - Convert.ToDouble(fact_2012.Valor_Neto.ToString())).ToString();
                string PorFacturar = (Convert.ToInt32(fact_2012.Cantidad.ToString()) - Convert.ToInt32(fact_2012.Nfactura.ToString())).ToString();
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                mmsg.To.Add("generarcorreoinformefacturacion@aimpresores.cl");
                switch (mes)
                {
                    case "01": mes = "Enero"; break;
                    case "02": mes = "Febrero"; break;
                    case "03": mes = "Marzo"; break;
                    case "04": mes = "Abril"; break;
                    case "05": mes = "Mayo"; break;
                    case "06": mes = "Junio"; break;
                    case "07": mes = "Julio"; break;
                    case "08": mes = "Agosto"; break;
                    case "09": mes = "Septiembre"; break;
                    case "10": mes = "Octubre"; break;
                    case "11": mes = "Noviembre"; break;
                    default: mes = "Diciembre"; break;
                }
                string diaTitulo = "";
                if (DateTime.Now.AddDays(-8).ToString("MM") != mes)
                {
                    diaTitulo = dia;
                }
                else
                {
                    diaTitulo = DateTime.Now.AddDays(-8).ToString("dd");
                }

                string Titulo = "Informe diario de Facturación acumulada al " + diaTitulo + " de " + mes + " de " + año;
                mmsg.Body = "<table style='width: 100%;'><tr><td colspan='2' align ='center' style='font-family: Helvetica Neue, Helvetica, Arial, sans-serif;font-size: 16px;'><b>" + Titulo + "</b></td></tr><tr><td><img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' /></td><td align='right'>Fecha : " + DateTime.Now.ToString("dd-MM-yyyy") + "<br />Periodo : " + mes + " de " + año + " </td></tr></table>" +
                    "<table id='example' style='width: 100%;max-width: 100%;margin-bottom: 20px;border: 1px solid #ddd !important;background-color: transparent; " +
                "border-collapse: collapse;box-sizing: border-box;font-family: Helvetica Neue, Helvetica, Arial, sans-serif;font-size: 14px;line-height: 1.42857143;color: #333;box-sizing: border-box;background-color: #DADADA;' cellspacing='0'> " +
                    "<thead>" +
                        "<tr>" +
                            "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>Facturación Neta Nacional</th>" +
                            "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>Facturación Neta en SII</th>" +
                            "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>Diferencia con SII</th>" +
                            "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>Facturación Neta Exportación </th>" +
                            "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>N° OTs Liquidadas</th>" +
                            "<th style='vertical-align: bottom;padding: 8px;border-bottom: 2px solid #ddd;border: 1px solid #ddd;'>N° Ots Facturadas</th>" +
                        "</tr>" +
                    "</thead>" +


                    "<tbody style='display: table-row-group;vertical-align: middle;border-spacing: 2px;border-color: grey;border-color: inherit;'>" +
                        "<tr  style='line-height: 1.42857143;vertical-align: top;border: 1px solid #ddd;background-color:#f5f5f5;'>" +
                            "<td style='padding: 8px;border: 1px solid #ddd;text-align:center;'>$ " + Convert.ToDouble(fact_2000.Valor_Neto.ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='padding: 8px;border: 1px solid #ddd;text-align:center;'>$ " + Convert.ToDouble(fact_2012.Valor_Neto.ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='padding: 8px;border: 1px solid #ddd;text-align:center;'>$ " + Convert.ToDouble(DiferenciaSII).ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='padding: 8px;border: 1px solid #ddd;text-align:center;'>$ " + Convert.ToDouble(DatosFacturacionExp2000(dia, mes, año)).ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='padding: 8px;border: 1px solid #ddd;text-align:center;'>" + Convert.ToDouble(fact_2012.Cantidad.ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='padding: 8px;border: 1px solid #ddd;text-align:center;'>" + Convert.ToDouble(fact_2012.Nfactura.ToString()).ToString("N0").Replace(",", ".") + "</td>" +

                        "</tr>" +
                    "</tbody>" +
                "</table>" +
                "<br/>" +
                "<br/>" +
                "<br />" +
                "Atentamente," +
                    "<br />" +
                "Departamento de Facturación" +
                "<div align='center'>Powered by the Development Team A Impresores S.A</div>";



                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = Titulo;
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("reporte.facturacion@aimpresores.cl");
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials =
                    new System.Net.NetworkCredential("reporte.facturacion@aimpresores.cl", "fac66--");

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
                GenerarCorreoErrordeEnvio("GenerarCorreoInformeFacturacion", "Especifico", NombreProcedure, año + "," + mes + "," + dia, e.Message);
                return "Error Enviado";
            }
        }

        public string DatosFacturacionExp2000(string dia, string mes, string año)
        {
            string Valor_Neto = "0";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "SELECT id_folio_factura, " +
                                        "CASE " +
                                        "WHEN referencia_tipo_documento = 1 THEN 'FNC' " +
                                        "WHEN referencia_tipo_documento = 2 THEN 'FEX' " +
                                        "WHEN referencia_tipo_documento = 3 THEN 'FNX' " +
                                        "WHEN referencia_tipo_documento = 4 THEN 'CNC' " +
                                        "WHEN referencia_tipo_documento = 5 THEN 'CEX' " +
                                        "WHEN referencia_tipo_documento = 7 THEN 'DNC' " +
                                        "WHEN referencia_tipo_documento = 8 THEN 'DEX' " +
                                        "ELSE 'N/A' " +
                                        "END AS nombre_tipo_documento, " +
                                        "CASE " +
                                        "WHEN nombre_tipo_documento ='CEX' THEN (((cantidad * valor_producto) + valor_flete + valor_seguro) * valor_tipo_cambio) * -1 " +
                                        "WHEN nombre_tipo_documento ='CNC' THEN ((cantidad * valor_producto) + valor_flete + valor_seguro) * -1 " +
                                        "when referencia_tipo_documento = 4 then ((cantidad * valor_producto) + valor_flete + valor_seguro) * -1 " +
                                        "WHEN nombre_tipo_documento NOT IN('CEX','CNC') AND valor_tipo_cambio = 0 THEN " +
                                        "(cantidad * valor_producto) + valor_flete + valor_seguro " +
                                        "ELSE ((cantidad * valor_producto) + valor_flete + valor_seguro) * valor_tipo_cambio  " +
                                        "END AS total_venta " +
                                        "FROM facturacion..documentos_mercantil, " +
                                        "facturacion..productos_documentos_mercantil, " +
                                        "facturacion..productos p1, " +
                                        "facturacion..tipos_documento, " +
                                        "facturacion..tipos_cambio " +
                                        "WHERE id_documento_mercantil = referencia_documento_mercantil " +
                                        "AND referencia_producto = id_producto " +
                                        "AND referencia_tipo_documento = id_tipo_documento " +
                                        "AND referencia_tipo_cambio = id_tipo_cambio " +
                                        "AND fecha_emision BETWEEN '" + año + mes + "01' AND '" + año + mes + dia + " 23:59:59' " +
                                        "and referencia_tipo_documento = 2 " +
                                        "AND referencia_estado_documento in (5,7,8) " +
                                        "AND referencia_estado_documento > 0";
                    SqlDataReader reader = cmd.ExecuteReader();

                    double total = 0;
                    while (reader.Read())
                    {
                        total += Convert.ToDouble(reader["total_venta"].ToString());
                    }
                    Valor_Neto = total.ToString("N0").Replace(",", "");
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return Valor_Neto;
        }

        public Facturacion_ElectronicaSII DatosFacturacion2000(string dia, string mes, string año)
        {
            Facturacion_ElectronicaSII factura = new Facturacion_ElectronicaSII();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "SELECT id_folio_factura, " +
                                        "CASE " +
                                        "WHEN referencia_tipo_documento = 1 THEN 'FNC' " +
                                        "WHEN referencia_tipo_documento = 2 THEN 'FEX' " +
                                        "WHEN referencia_tipo_documento = 3 THEN 'FNX' " +
                                        "WHEN referencia_tipo_documento = 4 THEN 'CNC' " +
                                        "WHEN referencia_tipo_documento = 5 THEN 'CEX' " +
                                        "WHEN referencia_tipo_documento = 7 THEN 'DNC' " +
                                        "WHEN referencia_tipo_documento = 8 THEN 'DEX' " +
                                        "ELSE 'N/A' " +
                                        "END AS nombre_tipo_documento, " +
                                        "CASE " +
                                        "WHEN nombre_tipo_documento ='CEX' THEN (((cantidad * valor_producto) + valor_flete + valor_seguro) * valor_tipo_cambio) * -1 " +
                                        "WHEN nombre_tipo_documento ='CNC' THEN ((cantidad * valor_producto) + valor_flete + valor_seguro) * -1 " +
                                        "when referencia_tipo_documento = 4 then ((cantidad * valor_producto) + valor_flete + valor_seguro) * -1 " +
                                        "WHEN nombre_tipo_documento NOT IN('CEX','CNC') AND valor_tipo_cambio = 0 THEN " +
                                        "(cantidad * valor_producto) + valor_flete + valor_seguro " +
                                        "ELSE ((cantidad * valor_producto) + valor_flete + valor_seguro) * valor_tipo_cambio  " +
                                        "END AS total_venta " +
                                        "FROM facturacion..documentos_mercantil, " +
                                        "facturacion..productos_documentos_mercantil, " +
                                        "facturacion..productos p1, " +
                                        "facturacion..tipos_documento, " +
                                        "facturacion..tipos_cambio " +
                                        "WHERE id_documento_mercantil = referencia_documento_mercantil " +
                                        "AND referencia_producto = id_producto " +
                                        "AND referencia_tipo_documento = id_tipo_documento " +
                                        "AND referencia_tipo_cambio = id_tipo_cambio " +
                                        "AND fecha_emision BETWEEN '" + año + mes + "01' AND '" + año + mes + dia + " 23:59:59' " +
                                        "and referencia_tipo_documento != 2 " +
                                        "AND referencia_estado_documento in (5,7,8) " +
                                        "AND referencia_estado_documento > 0";
                    SqlDataReader reader = cmd.ExecuteReader();
                    factura.Valor_Neto = "0";
                    factura.Nfactura = "0";
                    int contador = 0;
                    double total = 0;
                    while (reader.Read())
                    {
                        if (reader["id_folio_factura"].ToString() != "-1     ")
                        {
                            contador++;
                        }
                        total += Convert.ToDouble(reader["total_venta"].ToString());
                    }
                    factura.Valor_Neto = total.ToString("N0").Replace(",", "");
                    factura.Nfactura = contador.ToString();
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return factura;
        }

        public Facturacion_ElectronicaSII DatosFacturacion2012(string dia, string mes, string año)
        {
            Facturacion_ElectronicaSII factura = new Facturacion_ElectronicaSII();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Adm_OTLiquidadas_detalle";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OTs", " ");
                    cmd.Parameters.AddWithValue("@año", año);
                    cmd.Parameters.AddWithValue("@mes", mes);
                    cmd.Parameters.AddWithValue("@dia", dia);
                    cmd.Parameters.AddWithValue("@procedimiento", 3);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<string> lista = new List<string>();
                    factura.Valor_Neto = "0";
                    factura.Nfactura = "0";
                    factura.Cantidad = "0";//CantidaddeOTLiquidadas
                    while (reader.Read())
                    {
                        factura.Valor_Neto = (Convert.ToDouble(factura.Valor_Neto) + Convert.ToDouble(reader["neto_item"])).ToString();
                        factura.Cantidad = reader["OTLiquidadas"].ToString();
                        factura.Nfactura = reader["OT"].ToString();
                        lista.Add(reader["OT"].ToString());
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return factura;
        }

        public string Encabezado(string NombreMaquina)
        {
            return "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1500px;margin-left:3px;'>" +
                      "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                    "<td style='font-size: 14px;font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='14'>" + NombreMaquina + "</td></tr>" +
                          "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
                            "OT</td> " +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:160px;'>" +
                            "Nombre OT</td> " +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                            "Componente</td> " +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:330px;'>" +
                            "Papel Planificado</td> " +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:65px;'>" +
                            "Planificado KG</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:330px;'>" +
                            "Papel Utilizado</td> " +
                       "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:65px;'>" +
                            "Consumido KG</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:65px;'>" +
                            "Cono<div>KG</div></td> " +
                         "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:65px;'>" +
                            "Embalaje<div>KG</div></td> " +
                         "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:65px;'>" +
                            "Escalpe<div>KG</div></td> " +
                         "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:65px;'>" +
                            "Tapa<div>KG</div></td> " +
                         "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:65px;'>" +
                            "M.Prep<div>KG</div></td> " +
                         "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:65px;'>" +
                            "M.Tiraje<div>KG</div></td> " +

                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:65px;'>" +
                            "Diferencia KG</td>" +
                      "</tr>";
        }

        public string Produccion_CorreoComparativo_ConsumoBobinas(DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {

            string Contenido = ""; string Maquina = ""; int TotalSolicitado = 0; string TotalUtilizado = ""; int TotalDif = 0; string TotalDiferencia = ""; int Solicitado = 0; int Utilizado = 0;
            int Cono = 0; int TotalCono = 0; int Embalaje = 0; int TotalEmbalaje = 0; int Escalpe = 0; int TotalEscalpe = 0; int Tapa = 0; int TotalTapa = 0; int Consumo = 0; int TotalConsumo = 0;
            int MPreparacion = 0; int TotalMPreparacion = 0; int MTiraje = 0; int TotalMTiraje = 0; string PapelUsado = ""; string PapelTeorico = ""; string Diferencia = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_Correo_ConsumoEnLinea]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Maquina == "" || Maquina == reader["Maquina"].ToString())
                    {
                        Solicitado = Convert.ToInt32(reader["PlanificadoKG"].ToString());
                        TotalSolicitado += Solicitado;
                        Cono = Convert.ToInt32(reader["Cono"].ToString());
                        TotalCono += Cono;
                        Embalaje = Convert.ToInt32(reader["Embalaje"].ToString());
                        TotalEmbalaje += Embalaje;
                        Escalpe = Convert.ToInt32(reader["Escalpe"].ToString());
                        TotalEscalpe += Escalpe;
                        Tapa = Convert.ToInt32(reader["Tapa"].ToString());
                        TotalTapa += Tapa;
                        MPreparacion = Convert.ToInt32(reader["MermaPreparacion"].ToString());
                        TotalMPreparacion += MPreparacion;
                        MTiraje = Convert.ToInt32(reader["MermaTiraje"].ToString());
                        TotalMTiraje += MTiraje;
                        Consumo = Convert.ToInt32(reader["ConsumidoKG"].ToString());
                        Utilizado = (Cono + Embalaje + Escalpe + Tapa + MPreparacion + MTiraje + Consumo);

                        if (reader["Maquina"].ToString() != "DIMENSIONADORA")
                        {
                            if (Solicitado < Utilizado)
                            {
                                Diferencia = "<div style='color:DarkGreen;'>" + (Utilizado - Solicitado).ToString() + "</div>";
                            }
                            else if (Solicitado > Utilizado)
                            {
                                Diferencia = "<div style='Color:Red;'>" + (Utilizado - Solicitado).ToString() + "</div>";
                            }
                            else
                            {
                                Diferencia = (Utilizado - Solicitado).ToString();
                            }
                            if (reader["PapelUtilizado"].ToString().ToLower() == reader["PapelSolicitado"].ToString().ToLower())
                            {
                                PapelUsado = reader["PapelUtilizado"].ToString().ToLower();
                                PapelTeorico = reader["PapelSolicitado"].ToString().ToLower();
                            }
                            else
                            {
                                PapelUsado = "<div style='color:DarkOrange;'>" + reader["PapelUtilizado"].ToString().ToLower() + "</div>";
                                PapelTeorico = "<div style='color:DarkOrange;'>" + reader["PapelSolicitado"].ToString().ToLower() + "</div>";
                            }
                        }
                        else
                        {
                            Diferencia = "";
                        }
                        if (Maquina == "")
                        {
                            Contenido = Contenido + Encabezado(reader["Maquina"].ToString());
                            PapelUsado = reader["PapelUtilizado"].ToString().ToLower();
                            PapelTeorico = reader["PapelSolicitado"].ToString().ToLower();
                        }

                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                          "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
                               reader["OT"].ToString() + "</td> " +
                            "<td style=' padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:left;width:160px;'>" +
                               reader["NombreOT"].ToString().ToLower() + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:left;width:50px;'>" +
                               reader["Componente"].ToString() + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:left;width:330px;'>" +
                                PapelTeorico.ToString() + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                               Solicitado.ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:left;width:330px;'>" +
                               PapelUsado.ToString() + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                              Utilizado.ToString("N0").Replace(",", ".") + "</td>" +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                               Cono.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                               Embalaje.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                                Escalpe.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                               Tapa.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                                MPreparacion.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                                MTiraje.ToString().Replace(",", ".") + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                              Diferencia + "</td>" +
                           "</tr>";
                        Maquina = reader["Maquina"].ToString();
                    }
                    else
                    {

                        //Totales
                        //Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                        //  "<b>TOTAL ROTATIVAS</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                        //  "<b>" + Convert.ToInt32(TotalPliegos).ToString("N0").Replace(",", ".") + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                        //  "<b>" + Convert.ToInt32(TotalGiros).ToString("N0").Replace(",", ".") + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + PromedioHorasPreparacion + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + Convert.ToInt32((Convert.ToInt32(TotalGiros)) / (Convert.ToInt32(Entradas))).ToString("N0").Replace(",", ".") + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + ((Convert.ToDouble(TotalGiros)) / (TotalHorasPrep + TotalHorasTiraje + TotalHorasImp)).ToString("N0") + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + ((TotalGiros) / (TotalHorasTiraje)).ToString("N0") + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + (((TotalHorasTiraje) / (TotalHorasTiraje + TotalHorasImp)) * 100).ToString("N2") + "%" + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + MTiraje + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + (((TotalMermaPreparacion) / (TotalGiros)) * 100).ToString("N2") + "%" + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + MArranque + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + Cap + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + (TotalHorasSinProducir).ToString("N1") + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + Convert.ToInt32(Entradas).ToString("N0").Replace(",", ".") + "</b></td>" +
                        //  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                        //  "<b>" + TotalOTS.ToString("N0").Replace(",", ".") + "</b></td>" +
                        //  "</tr>";
                        Contenido = Contenido + "</tbody></table>";


                        Solicitado = Convert.ToInt32(reader["PlanificadoKG"].ToString());
                        TotalSolicitado = 0; TotalSolicitado += Solicitado;
                        Cono = Convert.ToInt32(reader["Cono"].ToString());
                        TotalCono = 0; TotalCono += Cono;
                        Embalaje = Convert.ToInt32(reader["Embalaje"].ToString());
                        TotalEmbalaje = 0; TotalEmbalaje += Embalaje;
                        Escalpe = Convert.ToInt32(reader["Escalpe"].ToString());
                        TotalEscalpe = 0; TotalEscalpe += Escalpe;
                        Tapa = Convert.ToInt32(reader["Tapa"].ToString());
                        TotalTapa = 0; TotalTapa += Tapa;
                        MPreparacion = Convert.ToInt32(reader["MermaPreparacion"].ToString());
                        TotalMPreparacion = 0; TotalMPreparacion += MPreparacion;
                        MTiraje = Convert.ToInt32(reader["MermaTiraje"].ToString());
                        TotalMTiraje = 0; TotalMTiraje += MTiraje;
                        Consumo = Convert.ToInt32(reader["ConsumidoKG"].ToString());
                        Utilizado = (Cono + Embalaje + Escalpe + Tapa + MPreparacion + MTiraje + Consumo);

                        if (reader["Maquina"].ToString() != "DIMENSIONADORA")
                        {
                            if (Solicitado < Utilizado)
                            {
                                Diferencia = "<div style='Color:DarkGreen;'>" + (Utilizado - Solicitado).ToString() + "</div>";
                            }
                            else if (Solicitado > Utilizado)
                            {
                                Diferencia = "<div style='Color:Red;'>" + (Utilizado - Solicitado).ToString() + "</div>";
                            }
                            else
                            {
                                Diferencia = (Utilizado - Solicitado).ToString();
                            }
                            if (reader["PapelUtilizado"].ToString().ToLower() == reader["PapelSolicitado"].ToString().ToLower())
                            {
                                PapelUsado = reader["PapelUtilizado"].ToString().ToLower();
                                PapelTeorico = reader["PapelSolicitado"].ToString().ToLower();
                            }
                            else
                            {
                                PapelUsado = "<div style='color:DarkOrange;'>" + reader["PapelUtilizado"].ToString().ToLower() + "</div>";
                                PapelTeorico = "<div style='color:DarkOrange;'>" + reader["PapelSolicitado"].ToString().ToLower() + "</div>";
                            }
                        }
                        else
                        {
                            Diferencia = "";
                            PapelUsado = reader["PapelUtilizado"].ToString().ToLower();
                            PapelTeorico = reader["PapelSolicitado"].ToString().ToLower();
                        }

                        Contenido = Contenido + Encabezado(reader["Maquina"].ToString()) + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                        "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
                               reader["OT"].ToString() + "</td> " +
                            "<td style=' padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:left;width:160px;'>" +
                               reader["NombreOT"].ToString().ToLower() + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:left;width:50px;'>" +
                               reader["Componente"].ToString() + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:left;width:330px;'>" +
                                PapelTeorico.ToString() + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                               Solicitado.ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:left;width:330px;'>" +
                               PapelUsado.ToString() + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                              Utilizado.ToString("N0").Replace(",", ".") + "</td>" +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                               Cono.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                               Embalaje.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                                Escalpe.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                               Tapa.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                                MPreparacion.ToString().Replace(",", ".") + "</td> " +
                             "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                                MTiraje.ToString().Replace(",", ".") + "</td> " +
                            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:right;width:65px;'>" +
                              Diferencia + "</td>" +
                           "</tr>";
                        Maquina = reader["Maquina"].ToString();
                    }
                } if (reader.Read() == false)
                {
                    //Contenido = Contenido + "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    //    "<b>TOTAL PLANAS</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                    //    "<b>" + Convert.ToInt32(TotalPliegos).ToString("N0").Replace(",", ".") + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:83px;'>" +
                    //    "<b>" + Convert.ToInt32(TotalGiros).ToString("N0").Replace(",", ".") + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + PromedioHorasPreparacion + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + TirajeProm + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + MRD + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + Vel + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + Upt + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + MTiraje + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + tGiros + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + MArranque + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + Cap + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + (TotalHorasSinProducir).ToString("N1") + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + Convert.ToInt32(Entradas).ToString("N0").Replace(",", ".") + "</b></td>" +
                    //    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:73px;'>" +
                    //    "<b>" + TotalOTS.ToString("N0").Replace(",", ".") + "</b></td>" +
                    //    "</tr>";
                    Contenido = Contenido + "</tbody></table>";
                }

            }
            conexion.CerrarConexion();
            return Contenido;
        }
        
        public List<FechaDistribuccion> FechaDistruccion()
        {
            List<FechaDistribuccion> lista = new List<FechaDistribuccion>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Produccion_FechaDistribuccion_Listar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FechaDistribuccion dtDist = new FechaDistribuccion();
                        dtDist.OT = reader["NumOrdem"].ToString();
                        dtDist.NombreOT = reader["Descricao"].ToString();
                        dtDist.Cliente = reader["NomeCliente"].ToString();
                        dtDist.FechaPrevista = Convert.ToDateTime(reader["DtHoraPrevista"].ToString()).ToString("dd-MM-yyyy HH:mm:ss");
                        dtDist.Cantidad = Convert.ToDouble(reader["Quantidade"].ToString());
                        dtDist.TipoReparto = reader["TipoDeReparte"].ToString();
                        dtDist.Destinatario = reader["Destinatario"].ToString();
                        dtDist.Direccion = reader["Endereco"].ToString();
                        dtDist.Observacion = reader["Observacoes"].ToString();
                        dtDist.MedioTransporte = reader["MeioTransporte"].ToString();
                        dtDist.Ciudad = reader["Cidade"].ToString();
                        dtDist.Pais = reader["Pais"].ToString();
                        dtDist.Correo = reader["Correos"].ToString();
                        dtDist.Proceso = reader["Proceso"].ToString();
                        lista.Add(dtDist);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string FechaEntregaEnviodeCorreoAutomatico()
        {
            string QueryDtDistribuccion = "";
            List<FechaDistribuccion> lista = FechaDistruccion();
            if (lista.Count > 0)
            {
                foreach (string NumeroOT in lista.Select(o => o.OT).Distinct())
                {
                    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                    int count = 0;
                    string TabladtDistribuccuion = "";
                    string FechasDistribuccion = "";
                    foreach (FechaDistribuccion dt in lista.Where(o => o.OT == NumeroOT))
                    {
                        if (count == 0)
                        {
                            string[] splitCorreo = dt.Correo.Substring(0, dt.Correo.Length - 1).Split(';');
                            foreach (string correouser in splitCorreo)
                            {
                                mmsg.To.Add(correouser);
                            }
                            mmsg.To.Add("correofechadistribucionxot@aimpresores.cl");

                            if (dt.Proceso == "Insert")
                            {
                                mmsg.Subject = "Se Informa Fecha de Distribución de la OT : " + dt.OT;
                            }
                            else
                            {
                                mmsg.Subject = "Modificada Fecha de Distribución de la OT : " + dt.OT + " - " + dt.NombreOT;
                            }
                            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                            count++;
                        }
                        TabladtDistribuccuion += "<tr style='height: 22px; background: rgb(255, 255, 255); font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; font-stretch: normal; font-size: 11px; line-height: normal; font-family: arial, helvetica, sans-serif; color: rgb(51, 51, 51); vertical-align: text-top;'>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: right; width: 50px;'>" + dt.OT + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 143px;'>" + dt.NombreOT + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 123px;'>" + dt.Cliente + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 80px;'>" + dt.TipoReparto + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: right; width: 100px;'>" + dt.FechaPrevista + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: right; width: 73px;'>" + dt.Cantidad + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 73px;'>" + dt.MedioTransporte + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); width: 73px;'>" + dt.Destinatario + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 103px;'>" + dt.Direccion + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 73px;'>" + dt.Ciudad + "/" + dt.Pais + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 183px;'>" + dt.Observacion + "</td>" +
                                                 "</tr>";
                        string[] split1 = dt.FechaPrevista.Split(' ');
                        string[] splitFecha = split1[0].Split('-');
                        FechasDistribuccion += "insert into Produccion_FechaDistribuccion( NumOrdem,NombreOT,Cliente,Fecha_Prevista,Cantidad,TipodeReparto,Destinatario,Direccion, " +
                                                "Observacion,MedioTransporte,Ciudad,Pais) " +
                                                "values('" + dt.OT + "','" + dt.NombreOT + "','" + dt.Cliente + "','" + splitFecha[2] + "-" + splitFecha[1] + "-" + splitFecha[0] + " " + split1[1] + "','" + dt.Cantidad + "','" + dt.TipoReparto + "','" + dt.Destinatario +
                                                "','" + dt.Direccion + "','" + dt.Observacion + "','" + dt.MedioTransporte + "','" + dt.Ciudad + "','" + dt.Pais + "')";
                    }
                    mmsg.Body = "<html lang='en'><head>" +

        "<!--[if mso]>" +
            "<style>" +
                " * {" +
                    " font-family: sans-serif !important;" +
                "}" +
            "</style>" +
        "<![endif]-->" +

        "<!-- All other clients get the webfont reference; some will render the font and others will silently fail to the fallbacks. More on that here: http://stylecampaign.com/blog/2015/02/webfont-support-in-email/ -->" +
        "<!--[if !mso]><!-->" +
            "<!-- insert web font reference, eg: <link href='https://fonts.googleapis.com/css?family=Roboto:400,700' rel='stylesheet' type='text/css'> -->" +
        "<!--<![endif]-->" +

        "<!-- Web Font / @font-face : END -->" +

        "<!-- CSS Reset -->" +
        "<style>" +

            " html," +
            " body {" +
                " margin: 0 auto !important;" +
                " padding: 0 !important;" +
                " height: 100% !important;" +
                " width: 100% !important;" +
            " }" +

            " /* What it does: Stops email clients resizing small text. */" +
            " * {" +
                " -ms-text-size-adjust: 100%;" +
                " -webkit-text-size-adjust: 100%;" +
            " }" +

            " /* What it does: Centers email on Android 4.4 */" +
            " div[style*='margin: 16px 0'] {" +
                " margin:0 !important;" +
            " }" +

            " /* What it does: Stops Outlook from adding extra spacing to tables. */" +
            " table," +
            " td {" +
                " mso-table-lspace: 0pt !important;" +
                " mso-table-rspace: 0pt !important;" +
            " }" +

            " /* What it does: Fixes webkit padding issue. Fix for Yahoo mail table alignment bug. Applies table-layout to the first 2 tables then removes for anything nested deeper. */" +
            " table {" +
                " border-spacing: 0 !important;" +
                " border-collapse: collapse !important;" +
                " table-layout: fixed !important;" +
                " margin: 0 auto !important;" +
            " }" +
            " table table table {" +
                " table-layout: auto;" +
            " }" +

            " /* What it does: Uses a better rendering method when resizing images in IE. */" +
            " img {" +
                " -ms-interpolation-mode:bicubic;" +
            " }" +

            " /* What it does: A work-around for iOS meddling in triggered links. */" +
            " *[x-apple-data-detectors] {" +
                " color: inherit !important;" +
                " text-decoration: none !important;" +
            " }" +

            " /* What it does: A work-around for Gmail meddling in triggered links. */" +
            " .x-gmail-data-detectors," +
            " .x-gmail-data-detectors *," +
            " .aBn {" +
                " border-bottom: 0 !important;" +
                " cursor: default !important;" +
            " }" +

            " /* What it does: Prevents Gmail from displaying an download button on large, non-linked images. */" +
            " .a6S {" +
                " display: none !important;" +
                " opacity: 0.01 !important;" +
            " }" +
            " /* If the above doesn't work, add a .g-img class to any image in question. */" +
            " img.g-img + div {" +
                " display:none !important;" +
            " }" +

            " /* What it does: Prevents underlining the button text in Windows 10 */" +
            " .button-link {" +
                " text-decoration: none !important;" +
            " }" +

            " @media only screen and (min-device-width: 375px) and (max-device-width: 413px) { /* iPhone 6 and 6+ */" +
                " .email-container {" +
                    " min-width: 375px !important;" +
                " }" +
            " }" +

        " </style>" +

        " <!-- What it does: Makes background images in 72ppi Outlook render at correct size. -->" +
        " <!--[if gte mso 9]>" +
        " <xml>" +
            " <o:OfficeDocumentSettings>" +
                " <o:AllowPNG/>" +
                " <o:PixelsPerInch>96</o:PixelsPerInch>" +
            " </o:OfficeDocumentSettings>" +
        " </xml>" +
        " <![endif]-->" +

        " <!-- Progressive Enhancements -->" +
        " <style>" +

            " /* What it does: Hover styles for buttons */" +
            " .button-td," +
            " .button-a {" +
                " transition: all 100ms ease-in;" +
            " }" +
            " .button-td:hover," +
            " .button-a:hover {" +
                " background: #555555 !important;" +
                " border-color: #555555 !important;" +
            " }" +

        " </style>" +

    " </head>" +
    " <body width='100%' style='margin: 0; mso-line-height-rule: exactly;'>" +
        " <center style='width: 100%; text-align: left;'>" +

            " <!-- Visually Hidden Preheader Text : BEGIN -->" +
            " <div style='display:none;font-size:1px;line-height:1px;max-height:0px;max-width:0px;opacity:0;overflow:hidden;mso-hide:all;font-family: sans-serif;'>" +
                " Estimado(a) : Este informe entrega las fechas de Distribucción." +
            " </div>" +
            " <!-- Visually Hidden Preheader Text : END -->" +

            " <!--" +
                " Set the email width. Defined in two places:" +
                " 1. max-width for all clients except Desktop Windows Outlook, allowing the email to squish on narrow but never go wider than 1200px." +
                " 2. MSO tags for Desktop Windows Outlook enforce a 1200px width." +
            " -->" +
            " <div style='max-width: 1200px; margin: auto;' class='email-container'>" +
                " <!--[if mso]>" +
                " <table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' width='1200' align='center'>" +
                " <tr>" +
                " <td>" +
                " <![endif]-->" +

                " <!-- Email Header : BEGIN -->" +
                 "<table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' align='center' width='100%' style='max-width: 1200px;'> " +
                     "<tbody><tr> " +
                         "<td style='padding: 0 20px 0 20px; text-align: center'> " +
                             "<img src='http://intranet.qgchile.cl/images/Logo color lateral.jpg' aria-hidden='true' width='276' height='50' alt='alt_text' border='0' style='height: auto; background: #dddddd; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555;'> " +
                         " </td> " +
                     "</tr> " +
                 "</tbody></table> " +
                " <!-- Email Header : END --> " +

                 "<!-- Email Body : BEGIN --> " +
                " <table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' align='center' width='100%' style='max-width: 1200px;'> " +
                     "<!-- 1 Column Text + Button : BEGIN --> " +
                     "<tr> " +
                         "<td bgcolor='#ffffff'> " +
                             "<table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' width='100%'> " +
                                 "<tbody><tr> " +
                                     "<td style='padding: 40px; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555;'> " +
                                         "Estimado(a): <br /><br />" +
                                         "Este informe se obtiene de forma automática desde el control de Fecha Distribucción (Metrics Jobtrack)." +
                                         "<br><br> " +

                                     "</td> " +
                                     "</tr> " +

                     "<tr><td>  " +
                        "<table id='tblRegistro' cellspacing='0' cellpadding='0' style='border: 1px solid rgb(204, 204, 204); margin: 0px auto 15px 3px; width: 100%;'><tbody>" +
                            "<tr style='height: 22px; background: rgb(243, 244, 249); font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; font-stretch: normal; font-size: 11px; line-height: normal; font-family: arial, helvetica, sans-serif; color: rgb(0, 62, 126); text-align: left;'> " +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 50px;'>OT</td> " +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 143px;'>Nombre OT</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 123px;'>Cliente</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 80px;'>Tipo de Reparto</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 100px;'>Fecha Entrega</td> " +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 73px;'>Cantidad</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 73px;'>Medio de Transporte</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 73px;'>Destinatario</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 103px;'>Dirección</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 73px;'>Ciudad/Pais</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 183px;'>Observación</td>" +






                            "</tr>" +
                            TabladtDistribuccuion +
                    "</tbody></table> " +
                     "</td></tr>" +
                             "</tbody></table> " +
                         "</td> " +
                     "</tr> " +


                " </tbody></table>" +
                " <!-- Email Body : END -->" +

                " <!-- Email Footer : BEGIN -->" +
                " <table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' align='center' width='100%' style='max-width: 680px;'>" +
                    " <tbody><tr>" +
                        " <td style='padding: 40px 10px;width: 100%;font-size: 12px; font-family: sans-serif; line-height:18px; text-align: center; color: #888888;' class='x-gmail-data-detectors'>" +
                            " <webversion style='color:#cccccc; text-decoration:underline; font-weight: bold;'>Atentamente</webversion>" +
                            " <br><br> " +
                            " Equipo de desarrollo A Impresores S.A. " +
                            " <br><br>" +
                        " </td>" +
                    " </tr>" +
                " </tbody></table> " +
                " <!-- Email Footer : END --> " +

                " <!--[if mso]>" +
                " </td> " +
                " </tr> " +
                " </table> " +
                " <![endif]--> " +
            " </div> " +
        " </center> " +
    " </body></html>";
                    mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                    mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

                    mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");



                    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                    cliente.Credentials =
                        new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");


                    cliente.Host = "mail.aimpresores.cl";

                    try
                    {
                        cliente.Send(mmsg);
                        QueryDtDistribuccion += FechasDistribuccion;
                        FechasDistribuccion = "";
                    }
                    catch (System.Net.Mail.SmtpException ex)
                    {
                        FechasDistribuccion = "";
                        string NombreProcedure0 = ex.StackTrace.ToString().Substring(ex.StackTrace.ToString().IndexOf("ProduccionController.") + 21, ex.StackTrace.Length - (ex.StackTrace.ToString().IndexOf("ProduccionController.") + 21));
                        string NombreProcedure = NombreProcedure0.Substring(0, NombreProcedure0.IndexOf("("));
                        GenerarCorreoErrordeEnvio("FechaEntregaEnviodeCorreoAutomatico", "Especifico", NombreProcedure, DateTime.Now.ToString("dd-MM-yyyy"), ex.Message);
                        return "Error Enviado";
                    }
                }
            }
            else
            {
                QueryDtDistribuccion = "0";
            }
            return QueryDtDistribuccion;
        }

        public bool SincronizadorFechaEntragas(string Query)
        {
            string Insertquery = Query;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            Boolean retorno = false;
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = Insertquery;
                    cmd.ExecuteNonQuery();
                    retorno = true;
                }
                catch (Exception e)
                {
                    retorno = false;
                }
            }
            con.CerrarConexion();
            return retorno;
        }
        
        public string Produccion_CorreoAutomatico_OTLiberas()
        {
            string QueryOTLiberacion = "";
            List<OT_Liberadas> lista = ListarOTLiberadas();
            if (lista.Count > 0)
            {
                foreach (string NumeroOT in lista.Select(o => o.OT).Distinct())
                {
                    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                    int count = 0;
                    string TablaOTLiberadas = "";
                    //string FechasDistribuccion = "";
                    foreach (OT_Liberadas OT in lista.Where(o => o.OT == NumeroOT))
                    {
                        if (count == 0)
                        {
                            string[] splitCorreo = OT.Correo.Split(';');
                            foreach (string correouser in splitCorreo)
                            {
                                mmsg.To.Add(correouser);
                            }
                            mmsg.To.Add("correootliberadasgrupo1@aimpresores.cl");
                            if (OT.Usr_Liberada == "FDS")
                            {
                                mmsg.To.Add("correootliberadasgrupo2@aimpresores.cl");
                            }
                            mmsg.Subject = "Se Informa liberacion de la OT : " + OT.OT;
                            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                            count++;
                        }
                        TablaOTLiberadas += "<tr style='height: 22px; background: rgb(255, 255, 255); font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; font-stretch: normal; font-size: 11px; line-height: normal; font-family: arial, helvetica, sans-serif; color: rgb(51, 51, 51); vertical-align: text-top;'>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: right; width: 50px;'>" + OT.OT + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 143px;'>" + OT.NombreOT + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 123px;'>" + OT.Usr_Liberada + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 80px;'>" + OT.Liberada + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: right; width: 100px;'>" + OT.DtLiberacao + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: right; width: 73px;'>" + OT.Situacion + "</td>" +
                                                        "<td style='font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: left; width: 73px;'>" + OT.Usuario + "</td>" +
                                                 "</tr>";
                        string[] split1 = OT.DtLiberacao.Split(' ');
                        string[] splitFecha = split1[0].Split('-');
                        QueryOTLiberacion += "insert into Produccion_OTLiberada_RegistroEnvioCorreo( OT,NombreOT,usr_jfcliberada,Liberacao,Situacao,DtOcor,CodUsuario) " +
                                                "values('" + OT.OT + "','" + OT.NombreOT + "','" + OT.Usr_Liberada + "','" + OT.Liberada + "','" + OT.Situacion + "','" + splitFecha[2] + "-" + splitFecha[1] + "-" + splitFecha[0] + " " + split1[1] + "','" + OT.Usuario + "')";
                    }
                    mmsg.Body = "<html lang='en'><head>" +

        "<!--[if mso]>" +
            "<style>" +
                " * {" +
                    " font-family: sans-serif !important;" +
                "}" +
            "</style>" +
        "<![endif]-->" +

        "<!-- All other clients get the webfont reference; some will render the font and others will silently fail to the fallbacks. More on that here: http://stylecampaign.com/blog/2015/02/webfont-support-in-email/ -->" +
        "<!--[if !mso]><!-->" +
            "<!-- insert web font reference, eg: <link href='https://fonts.googleapis.com/css?family=Roboto:400,700' rel='stylesheet' type='text/css'> -->" +
        "<!--<![endif]-->" +

        "<!-- Web Font / @font-face : END -->" +

        "<!-- CSS Reset -->" +
        "<style>" +

            " html," +
            " body {" +
                " margin: 0 auto !important;" +
                " padding: 0 !important;" +
                " height: 100% !important;" +
                " width: 100% !important;" +
            " }" +

            " /* What it does: Stops email clients resizing small text. */" +
            " * {" +
                " -ms-text-size-adjust: 100%;" +
                " -webkit-text-size-adjust: 100%;" +
            " }" +

            " /* What it does: Centers email on Android 4.4 */" +
            " div[style*='margin: 16px 0'] {" +
                " margin:0 !important;" +
            " }" +

            " /* What it does: Stops Outlook from adding extra spacing to tables. */" +
            " table," +
            " td {" +
                " mso-table-lspace: 0pt !important;" +
                " mso-table-rspace: 0pt !important;" +
            " }" +

            " /* What it does: Fixes webkit padding issue. Fix for Yahoo mail table alignment bug. Applies table-layout to the first 2 tables then removes for anything nested deeper. */" +
            " table {" +
                " border-spacing: 0 !important;" +
                " border-collapse: collapse !important;" +
                " table-layout: fixed !important;" +
                " margin: 0 auto !important;" +
            " }" +
            " table table table {" +
                " table-layout: auto;" +
            " }" +

            " /* What it does: Uses a better rendering method when resizing images in IE. */" +
            " img {" +
                " -ms-interpolation-mode:bicubic;" +
            " }" +

            " /* What it does: A work-around for iOS meddling in triggered links. */" +
            " *[x-apple-data-detectors] {" +
                " color: inherit !important;" +
                " text-decoration: none !important;" +
            " }" +

            " /* What it does: A work-around for Gmail meddling in triggered links. */" +
            " .x-gmail-data-detectors," +
            " .x-gmail-data-detectors *," +
            " .aBn {" +
                " border-bottom: 0 !important;" +
                " cursor: default !important;" +
            " }" +

            " /* What it does: Prevents Gmail from displaying an download button on large, non-linked images. */" +
            " .a6S {" +
                " display: none !important;" +
                " opacity: 0.01 !important;" +
            " }" +
            " /* If the above doesn't work, add a .g-img class to any image in question. */" +
            " img.g-img + div {" +
                " display:none !important;" +
            " }" +

            " /* What it does: Prevents underlining the button text in Windows 10 */" +
            " .button-link {" +
                " text-decoration: none !important;" +
            " }" +

            " @media only screen and (min-device-width: 375px) and (max-device-width: 413px) { /* iPhone 6 and 6+ */" +
                " .email-container {" +
                    " min-width: 375px !important;" +
                " }" +
            " }" +

        " </style>" +

        " <!-- What it does: Makes background images in 72ppi Outlook render at correct size. -->" +
        " <!--[if gte mso 9]>" +
        " <xml>" +
            " <o:OfficeDocumentSettings>" +
                " <o:AllowPNG/>" +
                " <o:PixelsPerInch>96</o:PixelsPerInch>" +
            " </o:OfficeDocumentSettings>" +
        " </xml>" +
        " <![endif]-->" +

        " <!-- Progressive Enhancements -->" +
        " <style>" +

            " /* What it does: Hover styles for buttons */" +
            " .button-td," +
            " .button-a {" +
                " transition: all 100ms ease-in;" +
            " }" +
            " .button-td:hover," +
            " .button-a:hover {" +
                " background: #555555 !important;" +
                " border-color: #555555 !important;" +
            " }" +

        " </style>" +

    " </head>" +
    " <body width='100%' style='margin: 0; mso-line-height-rule: exactly;'>" +
        " <center style='width: 100%; text-align: left;'>" +

            " <!-- Visually Hidden Preheader Text : BEGIN -->" +
            " <div style='display:none;font-size:1px;line-height:1px;max-height:0px;max-width:0px;opacity:0;overflow:hidden;mso-hide:all;font-family: sans-serif;'>" +
                " Estimado(a) : Este informe entrega las fechas de Distribucción." +
            " </div>" +
            " <!-- Visually Hidden Preheader Text : END -->" +

            " <!--" +
                " Set the email width. Defined in two places:" +
                " 1. max-width for all clients except Desktop Windows Outlook, allowing the email to squish on narrow but never go wider than 1200px." +
                " 2. MSO tags for Desktop Windows Outlook enforce a 1200px width." +
            " -->" +
            " <div style='max-width: 1200px; margin: auto;' class='email-container'>" +
                " <!--[if mso]>" +
                " <table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' width='1200' align='center'>" +
                " <tr>" +
                " <td>" +
                " <![endif]-->" +

                " <!-- Email Header : BEGIN -->" +
                 "<table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' align='center' width='100%' style='max-width: 1200px;'> " +
                     "<tbody><tr> " +
                         "<td style='padding: 0 20px 0 20px; text-align: center'> " +
                             "<img src='http://intranet.qgchile.cl/images/Logo color lateral.jpg' aria-hidden='true' width='276' height='50' alt='alt_text' border='0' style='height: auto; background: #dddddd; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555;'> " +
                         " </td> " +
                     "</tr> " +
                 "</tbody></table> " +
                " <!-- Email Header : END --> " +

                 "<!-- Email Body : BEGIN --> " +
                " <table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' align='center' width='100%' style='max-width: 1200px;'> " +
                     "<!-- 1 Column Text + Button : BEGIN --> " +
                     "<tr> " +
                         "<td bgcolor='#ffffff'> " +
                             "<table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' width='100%'> " +
                                 "<tbody><tr> " +
                                     "<td style='padding: 40px; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555;'> " +
                                         "Estimado(a): <br /><br />" +
                                         "Este informe se obtiene de forma automática desde Orden de producción por parte de Customer (Metrics)." +
                                         "<br><br> " +

                                     "</td> " +
                                     "</tr> " +

                     "<tr><td>  " +
                        "<table id='tblRegistro' cellspacing='0' cellpadding='0' style='border: 1px solid rgb(204, 204, 204); margin: 0px auto 15px 3px; width: 100%;'><tbody>" +
                            "<tr style='height: 22px; background: rgb(243, 244, 249); font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; font-stretch: normal; font-size: 11px; line-height: normal; font-family: arial, helvetica, sans-serif; color: rgb(0, 62, 126); text-align: left;'> " +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 50px;'>OT</td> " +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 143px;'>Nombre OT</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 123px;'>Usr</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 80px;'>Liberacao</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 100px;'>Fecha Liberacion</td> " +
                                "<td style='font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 73px;'>Situacao</td>" +
                                "<td style='font-weight: bold; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 73px;'>codUsuario</td>" +






                            "</tr>" +
                            TablaOTLiberadas +
                    "</tbody></table> " +
                     "</td></tr>" +
                             "</tbody></table> " +
                         "</td> " +
                     "</tr> " +


                " </tbody></table>" +
                " <!-- Email Body : END -->" +

                " <!-- Email Footer : BEGIN -->" +
                " <table role='presentation' aria-hidden='true' cellspacing='0' cellpadding='0' border='0' align='center' width='100%' style='max-width: 680px;'>" +
                    " <tbody><tr>" +
                        " <td style='padding: 40px 10px;width: 100%;font-size: 12px; font-family: sans-serif; line-height:18px; text-align: center; color: #888888;' class='x-gmail-data-detectors'>" +
                            " <webversion style='color:#cccccc; text-decoration:underline; font-weight: bold;'>Atentamente</webversion>" +
                            " <br><br> " +
                            " Equipo de desarrollo A Impresores S.A. " +
                            " <br><br>" +
                        " </td>" +
                    " </tr>" +
                " </tbody></table> " +
                " <!-- Email Footer : END --> " +

                " <!--[if mso]>" +
                " </td> " +
                " </tr> " +
                " </table> " +
                " <![endif]--> " +
            " </div> " +
        " </center> " +
    " </body></html>";
                    mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                    mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

                    mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");



                    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                    cliente.Credentials =
                        new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");


                    cliente.Host = "mail.aimpresores.cl";

                    try
                    {
                        cliente.Send(mmsg);
                    }
                    catch (System.Net.Mail.SmtpException ex)
                    {
                        QueryOTLiberacion = "";
                        string NombreProcedure0 = ex.StackTrace.ToString().Substring(ex.StackTrace.ToString().IndexOf("ProduccionController.") + 21, ex.StackTrace.Length - (ex.StackTrace.ToString().IndexOf("ProduccionController.") + 21));
                        string NombreProcedure = NombreProcedure0.Substring(0, NombreProcedure0.IndexOf("("));
                        GenerarCorreoErrordeEnvio("FechaEntregaEnviodeCorreoAutomatico", "Especifico", NombreProcedure, DateTime.Now.ToString("dd-MM-yyyy"), ex.Message);
                        return "Error Enviado";
                    }
                }
            }
            else
            {
                QueryOTLiberacion = "No hay registro";
            }
            return QueryOTLiberacion;
        }

        public List<OT_Liberadas> ListarOTLiberadas()
        {
            List<OT_Liberadas> lista = new List<OT_Liberadas>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Produccion_OTLiberadas_Listar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OT_Liberadas otLiberada = new OT_Liberadas();
                        otLiberada.OT = reader["NumOrdem"].ToString();
                        otLiberada.NombreOT = reader["Descricao"].ToString();
                        otLiberada.Usr_Liberada = reader["usr_jfcliberada"].ToString();
                        otLiberada.Liberada = reader["liberacao"].ToString();
                        otLiberada.Situacion = reader["situacao"].ToString();
                        otLiberada.DtLiberacao = Convert.ToDateTime(reader["dtocor"].ToString()).ToString("dd-MM-yyyy HH:mm:ss");
                        otLiberada.Usuario = reader["codusuario"].ToString();
                        string Correo = reader["Correos"].ToString();
                        otLiberada.Correo = Correo.Substring(0, Correo.Length - 1);
                        lista.Add(otLiberada);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool SincronizadorOT()
        {
            try
            {
                List<SincronizarOT> lista = listaOTSincroOT();
                List<SincronizarOT> listaSincro = listaOTSincroMetrics();
                string query = "";
                if (listaSincro.Where(x => !lista.Any(y => y.OT == x.OT)).Count() > 0)
                {
                    foreach (SincronizarOT sincro in listaSincro.Where(x => !lista.Any(y => y.OT == x.OT)))
                    {
                        query = query + "INSERT INTO Data_P2B.dbo.QGPressJob (QG_RMS_JOB_NBR ,NM ,CTD_TMSTMP ,JOB_STS ,CUST_RUT ,CUST_NM, PRN_ORD_QTY,FECHA_LIQUIDACION, QG_RMS_TITLE_CD) VALUES" +
                                        "('" + sincro.OT.Trim() + "','" + sincro.NombreOT.Replace("'", "").Replace('"', ' ') + "','" + sincro.FechaCreacion + "'," + sincro.Estado + ",'" + sincro.ClienteRut + "','" +
                                        sincro.Cliente.Replace("'", "").Replace('"', ' ') + "'," + sincro.Tiraje + ",'" + sincro.FechaLiquidacion + "','Metric');";
                    }
                }
                if (listaSincro.Where(x => !lista.Any(y => y.OT == x.OT && y.NombreOT == x.NombreOT && y.Estado == x.Estado && y.FechaLiquidacion == x.FechaLiquidacion && y.Tiraje == x.Tiraje)).Count() > 0)
                {
                    foreach (SincronizarOT sincro in listaSincro.Where(x => !lista.Any(y => y.OT == x.OT && y.NombreOT == x.NombreOT && y.Estado == x.Estado && y.FechaLiquidacion == x.FechaLiquidacion && y.Tiraje == x.Tiraje)))
                    {
                        query = query + "UPDATE Data_P2B.dbo.QGPressJob SET NM = '" + sincro.NombreOT.Replace("'", "").Replace('"', ' ') + "',CUST_RUT = '" + sincro.ClienteRut + "',CUST_NM = '" + sincro.Cliente.Replace("'", "").Replace('"', ' ') + 
                            "',PRN_ORD_QTY = " + sincro.Tiraje + ", JOB_STS= " + sincro.Estado + ", Fecha_Liquidacion='" + sincro.FechaLiquidacion + "' WHERE QG_RMS_JOB_NBR = '" + sincro.OT.Trim() + "';";
                        
                    }
                }

                if (SincronizarQueryOT(query))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<SincronizarOT> listaOTSincroOT()
        {
            List<SincronizarOT> lista = new List<SincronizarOT>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_DataP2B();
            if (cmd != null)
            {
                cmd.CommandText = "select QG_RMS_JOB_NBR QG_RMS_JOB_NBR,NM,CUST_RUT,CUST_NM,PRN_ORD_QTY,JOB_STS,Fecha_Liquidacion from Data_P2B.dbo.QGPressJob where QG_RMS_JOB_NBR not like 'b%'";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SincronizarOT sincroOT = new SincronizarOT();
                    sincroOT.OT = reader["QG_RMS_JOB_NBR"].ToString().Trim();
                    sincroOT.NombreOT = reader["NM"].ToString();
                    sincroOT.ClienteRut = reader["CUST_RUT"].ToString();
                    sincroOT.Cliente = reader["CUST_NM"].ToString();
                    sincroOT.Tiraje = reader["PRN_ORD_QTY"].ToString();
                    sincroOT.Estado = reader["JOB_STS"].ToString();
                    sincroOT.FechaLiquidacion = (reader["Fecha_Liquidacion"].ToString()!="") ? Convert.ToDateTime(reader["Fecha_Liquidacion"].ToString()).ToString("dd-MM-yyyy") : "NULL";
                    lista.Add(sincroOT);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<SincronizarOT> listaOTSincroMetrics()
        {
            List<SincronizarOT> lista = new List<SincronizarOT>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Sincro_ListOTMetrics";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SincronizarOT sincroOT = new SincronizarOT();
                    sincroOT.OT = reader["QG_RMS_JOB_NBR"].ToString().Trim();
                    sincroOT.NombreOT = reader["NM"].ToString().Replace("'", "");
                    sincroOT.FechaCreacion = Convert.ToDateTime(reader["CTD_TMSTMP"].ToString()).ToString("dd-MM-yyyy");
                    sincroOT.Estado = (reader["Status_OP"].ToString() == "A") ? "1" : "2";
                    sincroOT.ClienteRut = reader["RUT_Cliente"].ToString();
                    sincroOT.Cliente = reader["Nome_Cliente"].ToString();
                    sincroOT.Tiraje = reader["Tiraje"].ToString();
                    sincroOT.FechaLiquidacion = (reader["Fecha_Liquidacion"].ToString()!= "") ? Convert.ToDateTime(reader["Fecha_Liquidacion"].ToString()).ToString("dd-MM-yyyy"): "NULL";
                    lista.Add(sincroOT);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool SincronizarQueryOT(string query)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_DataP2B();
            if (cmd != null)
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            con.CerrarConexion();
            return respuesta;
        }

        public string algo(int valor)
        {
            return valor.ToString();

        }

    }
}