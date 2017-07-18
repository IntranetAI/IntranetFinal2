using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloProduccion.Controller
{
    public class Partes_V2
    {
        public List<PartesMetrics> EstadisticaProduccion_Lithoman_V2(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            string ceros = "00";
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_Estadistica_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);
                cmd.CommandTimeout = 3000000;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartesMetrics p = new PartesMetrics();
                    p.Semana = reader["semana"].ToString();
                    p.Maquina = reader["Maquina"].ToString();
                    p.Entradas = reader["Entradas"].ToString();
                    TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    TimeSpan time2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    TimeSpan time3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    TimeSpan time4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    TimeSpan time5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    TimeSpan time6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    TimeSpan time7 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPruebaImpresion"].ToString()));

                    TimeSpan t0 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    int Dias0 = t0.Days * 24;
                    p.HorasTiraje = (t0.Hours + Dias0).ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Minutes.ToString().Length) + t0.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Seconds.ToString().Length) + t0.Seconds.ToString();

                    TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    int Dias1 = t1.Days * 24;
                    p.HorasImproductivas = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                    TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    int Dias2 = t2.Days * 24;
                    p.HorasPreparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                    TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    int Dias3 = t3.Days * 24;
                    p.HorasPreparacion = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                    TimeSpan t4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    int Dias4 = t4.Days * 24;
                    p.HorasPreparacion = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();

                    TimeSpan t5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    int Dias5 = t5.Days * 24;
                    p.HorasPreparacion = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                    TimeSpan t6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPruebaImpresion"].ToString()));
                    int Dias6 = t6.Days * 24;
                    p.HorasPreparacion = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();



                    p.GirosBuenosTiraje = Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".");
                    p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                    p.GirosMalosPreparacion = Convert.ToInt32(reader["GirosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    p.GirosMalosTiraje = Convert.ToInt32(reader["GirosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");

                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}