using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Intranet.ModuloProduccion.Controller
{
    public class Controller_EstadisticasProduccion
    {
        public List<EstProduccion> Produccion_InformeProduccion(string OT, string NombreOT, string Area, string Maquina, string Operador, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            List<EstProduccion> lista = new List<EstProduccion>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string ceros = "00";
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_InformeProduccion_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Operador", Operador);
                cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 9000000;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EstProduccion p = new EstProduccion();
                    p.Maquina = reader["Maquina"].ToString().Replace("Rapida 106", "").Replace("C150", "").Replace("C-18", "").ToLower();
                    p.OT = reader["OT"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString().ToLower();
                    p.Pliego = Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty);
                    double Plani = Convert.ToDouble(reader["Planificado"].ToString());
                    p.Planificado = Convert.ToInt32(reader["Planificado"].ToString()).ToString("N0").Replace(",", ".");
                    double Buenos = Convert.ToDouble(reader["Buenos"].ToString());
                    p.Producido = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                   
                    TimeSpan t0 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    int Dias0 = t0.Days * 24;
                    p.HorasTiraje = (t0.Hours + Dias0).ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Minutes.ToString().Length) + t0.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Seconds.ToString().Length) + t0.Seconds.ToString();

                    TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    int Dias1 = t1.Days * 24;
                    p.HorasPreparacion = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                    p.MermaTiraje = Convert.ToInt32(reader["MermaTiraje"].ToString()).ToString("N0").Replace(",", ".");

                    p.MermaPreparacion = Convert.ToInt32(reader["MermaPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    
                    p.FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    if (Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm") == "30/12/1899 00:00")
                    {
                        p.FechaTermino = "En Proceso";
                    }
                    else
                    {
                        p.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    }
                    double horastir = Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;
                    if (Buenos > 0)
                    {
                        p.Velocidad = Convert.ToInt32(Buenos / horastir).ToString("N0").Replace(",", ".") + "/Hr";
                    }
                    else
                    {
                        p.Velocidad = "0/Hr";
                    }

                    double HorasImp = Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                    if (horastir > 0)
                    {
                        p.Uptime = ((horastir / (horastir + HorasImp))*100).ToString("N2") + "%";
                    }
                    else
                    {
                        p.Uptime = "0,00%";
                    }
                    if (p.Maquina.ToLower().Contains("kba"))
                    {
                        p.VerMas = "";
                    }
                    else
                    {
                        p.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openDetalle(\"" + reader["OT"].ToString() + "\",\"" + reader["Processo"].ToString() + "\",\"" + reader["NombreOT"].ToString() + "\",\"" + p.Pliego + "\")'>Ver Más</a>";
                    }
                    if (Procedimiento == 3)
                    {
                        p.Operador = reader["Operador"].ToString();
                    }
                    else
                    {
                        p.Operador = "";
                    }
                    p.CodRecurso = reader["CodRecurso"].ToString();
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();

            return lista;
        }
        public string CargaErrores(string Maquina,DateTime FechaInicio, DateTime FechaTermino,int Procedimiento)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_InformeProduccion_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", "");
                cmd.Parameters.AddWithValue("@NombreOT", "");
                cmd.Parameters.AddWithValue("@Area", "");
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Operador", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["Errores"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;
        }

        //informe estadistica encuadernacion
        public List<EstEncuadernacion> Produccion_EstadisticaEnc(string Maquina, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            List<EstEncuadernacion> lista = new List<EstEncuadernacion>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string ceros = "00";
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_EstadisticaENC]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 9000000;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EstEncuadernacion p = new EstEncuadernacion();
                    p.Mes = reader["Mes"].ToString();
                    p.Maquina = reader["CodRecurso"].ToString();
                    p.OTS = reader["OTS"].ToString();
                    p.Entradas = reader["Entradas"].ToString();
                    //p.HorasPreparacion = reader["HorasPreparacion"].ToString();
                    TimeSpan t0 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    int Dias0 = t0.Days * 24;
                    p.HorasPreparacion = (t0.Hours + Dias0).ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Minutes.ToString().Length) + t0.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Seconds.ToString().Length) + t0.Seconds.ToString();
                    //p.HorasPreparacionPromedio = reader["PromedioPreparacion"].ToString();
                    TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["PromedioPreparacion"].ToString()));
                    int Dias1 = t1.Days * 24;
                    p.HorasPreparacionPromedio = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();
                   
                    //p.HorasImproductivas = reader["HorasImproductivas"].ToString();
                    TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    int Dias2 = t2.Days * 24;
                    p.HorasImproductivas = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                    //p.HorasSinTrabajo = reader["HorasSinTrabajo"].ToString();
                    TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    int Dias3 = t3.Days * 24;
                    p.HorasSinTrabajo = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();
                    //p.HorasSinPersonal = reader["HorasSinPersonal"].ToString();
                    TimeSpan t4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    int Dias4 = t4.Days * 24;
                    p.HorasSinPersonal = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();
                    //p.HorasMantencion = reader["HorasMantencion"].ToString();
                    TimeSpan t5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    int Dias5 = t5.Days * 24;
                    p.HorasMantencion = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();
                    //p.EsperaMaterial = reader["HorasEsperaMaterial"].ToString();
                    TimeSpan t6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasEsperaMaterial"].ToString()));
                    int Dias6 = t6.Days * 24;
                    p.EsperaMaterial = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                    double HTir = Convert.ToDouble(reader["HorasTiraje"].ToString());
                    double HPrep = Convert.ToDouble(reader["HorasPreparacion"].ToString());
                    double HImp = Convert.ToDouble(reader["HorasImproductivas"].ToString());
                    double HST = Convert.ToDouble(reader["HorasSinTrabajo"].ToString());
                    double HSP = Convert.ToDouble(reader["HorasSinPersonal"].ToString());
                    double HMan = Convert.ToDouble(reader["HorasMantencion"].ToString());
                    double HEM = Convert.ToDouble(reader["HorasEsperaMaterial"].ToString());
                    double THoras = (HPrep + HImp + HST + HSP + HMan + HEM + HTir);
                    TimeSpan t7 = TimeSpan.FromSeconds(THoras);
                    int Dias7 = t7.Days * 24;
                    p.TotalHoras = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                    TimeSpan t8 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    int Dias8 = t8.Days * 24;
                    p.HorasTiraje = (t8.Hours + Dias8).ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Minutes.ToString().Length) + t8.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Seconds.ToString().Length) + t8.Seconds.ToString();

                    p.PorcSinCarga = (((HST + HSP) / THoras) * 100).ToString("N2") + "%";
                    p.PorcProduciendo = (((HTir + HPrep) / THoras) * 100).ToString("N2") + "%";
                    p.PorcSinProducir = (((HImp + HMan) / THoras) * 100).ToString("N2") + "%";
                    p.PorcEsperaMaterial = ((HEM / THoras) * 100).ToString("N2") + "%";

                    double TBuenos = Convert.ToDouble(reader["Buenos"].ToString());
                    p.Buenos = Convert.ToInt32(TBuenos).ToString("N0").Replace(",", ".");
                    p.BuenosPromedio = Convert.ToInt32(reader["BuenosPromedio"].ToString()).ToString("N0").Replace(",", ".");

                    double MalosTiraje = Convert.ToDouble(reader["PliegosMalosTiraje"].ToString());
                    double MalosPrep = Convert.ToDouble(reader["PliegosMalosPreparacion"].ToString());
                    p.PliegosMalosPreparacion = Convert.ToInt32(MalosPrep).ToString("N0").Replace(",", ".");
                    p.PliegosMalosTiraje = Convert.ToInt32(MalosTiraje).ToString("N0").Replace(",", ".");

                    p.PorcBuenosMalos = ((MalosTiraje + MalosPrep) / (TBuenos)).ToString("N2") + "%";
                    p.Velocidad = (TBuenos / (HTir / 3600)).ToString("N0").Replace(",", ".") + "/Hr";
                    p.RendPP = (TBuenos / (((HTir / 3600) + (HPrep / 3600)))).ToString("N0").Replace(",", ".");
                    p.RendImp = (TBuenos / (((HTir / 3600) + (HPrep / 3600) + (HImp / 3600)))).ToString("N0").Replace(",", ".");

                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();

            return lista;
        }
    }
}