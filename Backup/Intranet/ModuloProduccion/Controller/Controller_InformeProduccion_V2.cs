using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloProduccion.Controller
{
    public class Controller_InformeProduccion_V2
    {
        public List<Analisis_Produccion_V2> AnalisisProduccion_V2(string OTs, string NombreOT, string Maquinas, string FechaInicio, string FechaTermino, int Procedimiento)
        {
            List<Analisis_Produccion_V2> lista = new List<Analisis_Produccion_V2>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Produccion_AnalisisProduccion";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OTs);
                    cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                    cmd.Parameters.AddWithValue("@Maquina", Maquinas);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    cmd.CommandTimeout = 300000; 
                    SqlDataReader reader = cmd.ExecuteReader();
                    string ceros = "00";
                    while (reader.Read())
                    {
                        Analisis_Produccion_V2 i = new Analisis_Produccion_V2();
                        i.Maquina = reader["Maquina"].ToString().Replace("M2016", "WEB 2");
                        i.OT = reader["NumOrdem"].ToString();
                        i.NombreOT = reader["NM"].ToString();
                        i.Entradas = reader["Entradas"].ToString();

                        TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                        int Dias1 = t1.Days * 24;
                        i.HorasPreparacion = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                        TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                        int Dias2 = t2.Days * 24;
                        i.HorasTiraje = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                        TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                        int Dias3 = t3.Days * 24;
                        i.HorasImproductivas = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                        i.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                        i.Giros = Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".");
                        i.MalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                        i.MalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                        lista.Add(i);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Informe_Produccion_V2> EstadisticaProduccion_V2(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<Informe_Produccion_V2> lista = new List<Informe_Produccion_V2>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_EstadisticaProduccion_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);
                cmd.CommandTimeout = 3000000;
                SqlDataReader reader = cmd.ExecuteReader();
                string ceros = "00";
                while (reader.Read())
                {
                    Informe_Produccion_V2 p = new Informe_Produccion_V2();
                    p.Semana = reader["semana"].ToString();
                    p.Maquina = reader["Maquina"].ToString().Replace("C150", "").Replace("M2016", "WEB 2");
                    p.Giros = Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".");
                    p.Entradas = reader["Entradas"].ToString();
                   
                    TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    int Dias1 = t1.Days * 24;
                    p.HorasTiraje = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                    TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    int Dias2 = t2.Days * 24;
                    p.HorasImproductivas = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                    TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    int Dias3 = t3.Days * 24;
                    p.HorasPreparacion = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                    TimeSpan t4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    int Dias4 = t4.Days * 24;
                    p.HorasSinTrabajo = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();

                    TimeSpan t5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    int Dias5 = t5.Days * 24;
                    p.HorasSinPersonal = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                    TimeSpan t6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    int Dias6 = t6.Days * 24;
                    p.HorasMantencion = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                    TimeSpan t7 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPruebaImpresion"].ToString()));
                    int Dias7 = t7.Days * 24;
                    p.HorasPruebaImpresion = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                    p.GirosMalosPreparacion = Convert.ToInt32(reader["GirosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    p.GirosMalosTiraje = Convert.ToInt32(reader["GirosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<Informe_Produccion_V2> EstadisticaProduccion_Diaria_V2(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<Informe_Produccion_V2> lista = new List<Informe_Produccion_V2>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_InformeProduccionDiaria_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);
                cmd.CommandTimeout = 3000000;
                SqlDataReader reader = cmd.ExecuteReader();
                string ceros = "00";
                while (reader.Read())
                {
                    Informe_Produccion_V2 p = new Informe_Produccion_V2();
                    p.Semana = Convert.ToDateTime(reader["Dia"].ToString()).ToString("dd/MM/yyyy");
                    p.Maquina = reader["Maquina"].ToString().Replace("C150", "").Replace("M2016", "WEB 2");
                    p.Giros = Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".");
                    p.Entradas = reader["Entradas"].ToString();

                    TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    int Dias1 = t1.Days * 24;
                    p.HorasTiraje = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                    TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    int Dias2 = t2.Days * 24;
                    p.HorasImproductivas = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                    TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    int Dias3 = t3.Days * 24;
                    p.HorasPreparacion = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                    TimeSpan t4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    int Dias4 = t4.Days * 24;
                    p.HorasSinTrabajo = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();

                    TimeSpan t5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    int Dias5 = t5.Days * 24;
                    p.HorasSinPersonal = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                    TimeSpan t6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    int Dias6 = t6.Days * 24;
                    p.HorasMantencion = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                    TimeSpan t7 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPruebaImpresion"].ToString()));
                    int Dias7 = t7.Days * 24;
                    p.HorasPruebaImpresion = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                    p.GirosMalosPreparacion = Convert.ToInt32(reader["GirosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    p.GirosMalosTiraje = Convert.ToInt32(reader["GirosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}