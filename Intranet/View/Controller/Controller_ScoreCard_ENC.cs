using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Intranet.View.Controller
{
    public class Controller_ScoreCard_ENC
    {
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
            else if (Titulo == "Rango")
            {
                NombreTitulo = "Score Card Encuadernación " + FechaInicio.ToString("dd/MM/yyyy") + " al " + FechaTermino.ToString("dd/MM/yyyy");
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
                }
                if (reader.Read() == false)
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
                }
                if (reader.Read() == false)
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
                }
                if (reader.Read() == false)
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
    }
}