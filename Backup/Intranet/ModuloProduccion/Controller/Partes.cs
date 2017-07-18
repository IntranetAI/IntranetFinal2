using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloProduccion.Controller
{
    public class Partes
    {
        //INICIO INFORME ESTADISTICA PRODUCCION MEJORADO
        public List<PartesMetrics> EstadisticaProduccion(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_EstadisticaProduccion]";
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
                    #region Minutos
                    string minutos = "";
                    if (time.Minutes > 9)
                    {
                        minutos = time.Minutes.ToString();
                    }
                    else
                    {
                        minutos = "0" + time.Minutes;
                    }
                    string minutos2 = "";
                    if (time2.Minutes > 9)
                    {
                        minutos2 = time2.Minutes.ToString();
                    }
                    else
                    {
                        minutos2 = "0" + time2.Minutes;
                    }
                    string minutos3 = "";
                    if (time3.Minutes > 9)
                    {
                        minutos3 = time3.Minutes.ToString();
                    }
                    else
                    {
                        minutos3 = "0" + time3.Minutes;
                    }
                    string minutos4 = "";
                    if (time4.Minutes > 9)
                    {
                        minutos4 = time4.Minutes.ToString();
                    }
                    else
                    {
                        minutos4 = "0" + time4.Minutes;
                    }
                    string minutos5 = "";
                    if (time5.Minutes > 9)
                    {
                        minutos5 = time5.Minutes.ToString();
                    }
                    else
                    {
                        minutos5 = "0" + time5.Minutes;
                    }
                    string minutos6 = "";
                    if (time6.Minutes > 9)
                    {
                        minutos6 = time6.Minutes.ToString();
                    }
                    else
                    {
                        minutos6 = "0" + time6.Minutes;
                    }
                    string minutos7 = "";
                    if (time7.Minutes > 9)
                    {
                        minutos7 = time7.Minutes.ToString();
                    }
                    else
                    {
                        minutos7 = "0" + time7.Minutes;
                    }
                    #endregion
                    #region Tiempo
                    //
                    string segundos = "";
                    if (time.Seconds > 9)
                    {
                        segundos = time.Seconds.ToString();
                    }
                    else
                    {
                        segundos = "0" + time.Seconds;
                    }
                    string segundos2 = "";
                    if (time2.Seconds > 9)
                    {
                        segundos2 = time2.Seconds.ToString();
                    }
                    else
                    {
                        segundos2 = "0" + time2.Seconds;
                    }
                    string segundos3 = "";
                    if (time3.Seconds > 9)
                    {
                        segundos3 = time3.Seconds.ToString();
                    }
                    else
                    {
                        segundos3 = "0" + time3.Seconds;
                    }
                    string segundos4 = "";
                    if (time4.Seconds > 9)
                    {
                        segundos4 = time4.Seconds.ToString();
                    }
                    else
                    {
                        segundos4 = "0" + time4.Seconds;
                    }
                    string segundos5 = "";
                    if (time5.Seconds > 9)
                    {
                        segundos5 = time5.Seconds.ToString();
                    }
                    else
                    {
                        segundos5 = "0" + time5.Seconds;
                    }
                    string segundos6 = "";
                    if (time6.Seconds > 9)
                    {
                        segundos6 = time6.Seconds.ToString();
                    }
                    else
                    {
                        segundos6 = "0" + time6.Seconds;
                    }
                    string segundos7 = "";
                    if (time7.Seconds > 9)
                    {
                        segundos7 = time7.Seconds.ToString();
                    }
                    else
                    {
                        segundos7 = "0" + time7.Seconds;
                    }








                    if (time.Days > 0)
                    {
                        p.HorasTiraje = ((time.Days * 24) + time.Hours) + ":" + minutos + ":" + segundos;

                    }
                    else
                    {
                        p.HorasTiraje = time.Hours + ":" + minutos + ":" + segundos;
                    }


                    if (time2.Days > 0)
                    {
                        p.HorasImproductivas = ((time2.Days * 24) + time2.Hours) + ":" + minutos2 + ":" + segundos2;
                    }
                    else
                    {
                        p.HorasImproductivas = time2.Hours + ":" + minutos2 + ":" + segundos2;
                    }

                    if (time3.Days > 0)
                    {
                        p.HorasPreparacion = ((time3.Days * 24) + time3.Hours) + ":" + minutos3 + ":" + segundos3;
                    }
                    else
                    {
                        p.HorasPreparacion = time3.Hours + ":" + minutos3 + ":" + segundos3;
                    }

                    if (time4.Days > 0)
                    {
                        p.HorasSinTrabajo = ((time4.Days * 24) + time4.Hours) + ":" + minutos4 + ":" + segundos4;
                    }
                    else
                    {
                        p.HorasSinTrabajo = time4.Hours + ":" + minutos4 + ":" + segundos4;
                    }

                    if (time5.Days > 0)
                    {
                        p.HorasSinPersonal = ((time5.Days * 24) + time5.Hours) + ":" + minutos5 + ":" + segundos5;
                    }
                    else
                    {
                        p.HorasSinPersonal = time5.Hours + ":" + minutos5 + ":" + segundos5;
                    }


                    if (time6.Days > 0)
                    {
                        p.HorasMantencion = ((time6.Days * 24) + time6.Hours) + ":" + minutos6 + ":" + segundos6;
                    }
                    else
                    {
                        p.HorasMantencion = time6.Hours + ":" + minutos6 + ":" + segundos6;
                    }
                    if (time7.Days > 0)
                    {
                        p.HorasPruebaImpresion = ((time7.Days * 24) + time7.Hours) + ":" + minutos7 + ":" + segundos7;
                    }
                    else
                    {
                        p.HorasPruebaImpresion = time7.Hours + ":" + minutos7 + ":" + segundos7;
                    }
                    #endregion
                    
                    p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    p.GirosMalosTiraje = p.PliegosMalosTiraje;
                    p.GirosMalosPreparacion = p.PliegosMalosPreparacion;
                    p.GirosBuenosTiraje = p.Buenos;
                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<PartesMetrics> EstadisticaProduccion_Lithoman(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_EstadisticaProduccion_Lithoman]";
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
                    #region Minutos
                    string minutos = "";
                    if (time.Minutes > 9)
                    {
                        minutos = time.Minutes.ToString();
                    }
                    else
                    {
                        minutos = "0" + time.Minutes;
                    }
                    string minutos2 = "";
                    if (time2.Minutes > 9)
                    {
                        minutos2 = time2.Minutes.ToString();
                    }
                    else
                    {
                        minutos2 = "0" + time2.Minutes;
                    }
                    string minutos3 = "";
                    if (time3.Minutes > 9)
                    {
                        minutos3 = time3.Minutes.ToString();
                    }
                    else
                    {
                        minutos3 = "0" + time3.Minutes;
                    }
                    string minutos4 = "";
                    if (time4.Minutes > 9)
                    {
                        minutos4 = time4.Minutes.ToString();
                    }
                    else
                    {
                        minutos4 = "0" + time4.Minutes;
                    }
                    string minutos5 = "";
                    if (time5.Minutes > 9)
                    {
                        minutos5 = time5.Minutes.ToString();
                    }
                    else
                    {
                        minutos5 = "0" + time5.Minutes;
                    }
                    string minutos6 = "";
                    if (time6.Minutes > 9)
                    {
                        minutos6 = time6.Minutes.ToString();
                    }
                    else
                    {
                        minutos6 = "0" + time6.Minutes;
                    }
                    string minutos7 = "";
                    if (time7.Minutes > 9)
                    {
                        minutos7 = time7.Minutes.ToString();
                    }
                    else
                    {
                        minutos7 = "0" + time7.Minutes;
                    }
                    #endregion
                    #region Tiempo
                    //
                    string segundos = "";
                    if (time.Seconds > 9)
                    {
                        segundos = time.Seconds.ToString();
                    }
                    else
                    {
                        segundos = "0" + time.Seconds;
                    }
                    string segundos2 = "";
                    if (time2.Seconds > 9)
                    {
                        segundos2 = time2.Seconds.ToString();
                    }
                    else
                    {
                        segundos2 = "0" + time2.Seconds;
                    }
                    string segundos3 = "";
                    if (time3.Seconds > 9)
                    {
                        segundos3 = time3.Seconds.ToString();
                    }
                    else
                    {
                        segundos3 = "0" + time3.Seconds;
                    }
                    string segundos4 = "";
                    if (time4.Seconds > 9)
                    {
                        segundos4 = time4.Seconds.ToString();
                    }
                    else
                    {
                        segundos4 = "0" + time4.Seconds;
                    }
                    string segundos5 = "";
                    if (time5.Seconds > 9)
                    {
                        segundos5 = time5.Seconds.ToString();
                    }
                    else
                    {
                        segundos5 = "0" + time5.Seconds;
                    }
                    string segundos6 = "";
                    if (time6.Seconds > 9)
                    {
                        segundos6 = time6.Seconds.ToString();
                    }
                    else
                    {
                        segundos6 = "0" + time6.Seconds;
                    }
                    string segundos7 = "";
                    if (time7.Seconds > 9)
                    {
                        segundos7 = time7.Seconds.ToString();
                    }
                    else
                    {
                        segundos7 = "0" + time7.Seconds;
                    }








                    if (time.Days > 0)
                    {
                        p.HorasTiraje = ((time.Days * 24) + time.Hours) + ":" + minutos + ":" + segundos;

                    }
                    else
                    {
                        p.HorasTiraje = time.Hours + ":" + minutos + ":" + segundos;
                    }


                    if (time2.Days > 0)
                    {
                        p.HorasImproductivas = ((time2.Days * 24) + time2.Hours) + ":" + minutos2 + ":" + segundos2;
                    }
                    else
                    {
                        p.HorasImproductivas = time2.Hours + ":" + minutos2 + ":" + segundos2;
                    }

                    if (time3.Days > 0)
                    {
                        p.HorasPreparacion = ((time3.Days * 24) + time3.Hours) + ":" + minutos3 + ":" + segundos3;
                    }
                    else
                    {
                        p.HorasPreparacion = time3.Hours + ":" + minutos3 + ":" + segundos3;
                    }

                    if (time4.Days > 0)
                    {
                        p.HorasSinTrabajo = ((time4.Days * 24) + time4.Hours) + ":" + minutos4 + ":" + segundos4;
                    }
                    else
                    {
                        p.HorasSinTrabajo = time4.Hours + ":" + minutos4 + ":" + segundos4;
                    }

                    if (time5.Days > 0)
                    {
                        p.HorasSinPersonal = ((time5.Days * 24) + time5.Hours) + ":" + minutos5 + ":" + segundos5;
                    }
                    else
                    {
                        p.HorasSinPersonal = time5.Hours + ":" + minutos5 + ":" + segundos5;
                    }


                    if (time6.Days > 0)
                    {
                        p.HorasMantencion = ((time6.Days * 24) + time6.Hours) + ":" + minutos6 + ":" + segundos6;
                    }
                    else
                    {
                        p.HorasMantencion = time6.Hours + ":" + minutos6 + ":" + segundos6;
                    }
                    if (time7.Days > 0)
                    {
                        p.HorasPruebaImpresion = ((time7.Days * 24) + time7.Hours) + ":" + minutos7 + ":" + segundos7;
                    }
                    else
                    {
                        p.HorasPruebaImpresion = time7.Hours + ":" + minutos7 + ":" + segundos7;
                    }
                    #endregion
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

        public List<PartesMetrics> EstadisticaProduccionDiaria(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_InformeProduccionDiaria]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);
                cmd.CommandTimeout = 30000000;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartesMetrics p = new PartesMetrics();
                    p.Semana = Convert.ToDateTime(reader["semana"].ToString()).ToString("dd/MM/yyyy");
                    p.Maquina = reader["Maquina"].ToString();
                    p.Entradas = reader["Entradas"].ToString();
                    TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    TimeSpan time2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    TimeSpan time3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    TimeSpan time4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    TimeSpan time5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    TimeSpan time6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    TimeSpan time7 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPruebaImpresion"].ToString()));
                    #region Minutos
                    string minutos = "";
                    if (time.Minutes > 9)
                    {
                        minutos = time.Minutes.ToString();
                    }
                    else
                    {
                        minutos = "0" + time.Minutes;
                    }
                    string minutos2 = "";
                    if (time2.Minutes > 9)
                    {
                        minutos2 = time2.Minutes.ToString();
                    }
                    else
                    {
                        minutos2 = "0" + time2.Minutes;
                    }
                    string minutos3 = "";
                    if (time3.Minutes > 9)
                    {
                        minutos3 = time3.Minutes.ToString();
                    }
                    else
                    {
                        minutos3 = "0" + time3.Minutes;
                    }
                    string minutos4 = "";
                    if (time4.Minutes > 9)
                    {
                        minutos4 = time4.Minutes.ToString();
                    }
                    else
                    {
                        minutos4 = "0" + time4.Minutes;
                    }
                    string minutos5 = "";
                    if (time5.Minutes > 9)
                    {
                        minutos5 = time5.Minutes.ToString();
                    }
                    else
                    {
                        minutos5 = "0" + time5.Minutes;
                    }
                    string minutos6 = "";
                    if (time6.Minutes > 9)
                    {
                        minutos6 = time6.Minutes.ToString();
                    }
                    else
                    {
                        minutos6 = "0" + time6.Minutes;
                    }
                    string minutos7 = "";
                    if (time7.Minutes > 9)
                    {
                        minutos7 = time7.Minutes.ToString();
                    }
                    else
                    {
                        minutos7 = "0" + time7.Minutes;
                    }
                    #endregion
                    #region Tiempo
                    //
                    string segundos = "";
                    if (time.Seconds > 9)
                    {
                        segundos = time.Seconds.ToString();
                    }
                    else
                    {
                        segundos = "0" + time.Seconds;
                    }
                    string segundos2 = "";
                    if (time2.Seconds > 9)
                    {
                        segundos2 = time2.Seconds.ToString();
                    }
                    else
                    {
                        segundos2 = "0" + time2.Seconds;
                    }
                    string segundos3 = "";
                    if (time3.Seconds > 9)
                    {
                        segundos3 = time3.Seconds.ToString();
                    }
                    else
                    {
                        segundos3 = "0" + time3.Seconds;
                    }
                    string segundos4 = "";
                    if (time4.Seconds > 9)
                    {
                        segundos4 = time4.Seconds.ToString();
                    }
                    else
                    {
                        segundos4 = "0" + time4.Seconds;
                    }
                    string segundos5 = "";
                    if (time5.Seconds > 9)
                    {
                        segundos5 = time5.Seconds.ToString();
                    }
                    else
                    {
                        segundos5 = "0" + time5.Seconds;
                    }
                    string segundos6 = "";
                    if (time6.Seconds > 9)
                    {
                        segundos6 = time6.Seconds.ToString();
                    }
                    else
                    {
                        segundos6 = "0" + time6.Seconds;
                    }
                    string segundos7 = "";
                    if (time7.Seconds > 9)
                    {
                        segundos7 = time7.Seconds.ToString();
                    }
                    else
                    {
                        segundos7 = "0" + time7.Seconds;
                    }








                    if (time.Days > 0)
                    {
                        p.HorasTiraje = ((time.Days * 24) + time.Hours) + ":" + minutos + ":" + segundos;

                    }
                    else
                    {
                        p.HorasTiraje = time.Hours + ":" + minutos + ":" + segundos;
                    }


                    if (time2.Days > 0)
                    {
                        p.HorasImproductivas = ((time2.Days * 24) + time2.Hours) + ":" + minutos2 + ":" + segundos2;
                    }
                    else
                    {
                        p.HorasImproductivas = time2.Hours + ":" + minutos2 + ":" + segundos2;
                    }

                    if (time3.Days > 0)
                    {
                        p.HorasPreparacion = ((time3.Days * 24) + time3.Hours) + ":" + minutos3 + ":" + segundos3;
                    }
                    else
                    {
                        p.HorasPreparacion = time3.Hours + ":" + minutos3 + ":" + segundos3;
                    }

                    if (time4.Days > 0)
                    {
                        p.HorasSinTrabajo = ((time4.Days * 24) + time4.Hours) + ":" + minutos4 + ":" + segundos4;
                    }
                    else
                    {
                        p.HorasSinTrabajo = time4.Hours + ":" + minutos4 + ":" + segundos4;
                    }

                    if (time5.Days > 0)
                    {
                        p.HorasSinPersonal = ((time5.Days * 24) + time5.Hours) + ":" + minutos5 + ":" + segundos5;
                    }
                    else
                    {
                        p.HorasSinPersonal = time5.Hours + ":" + minutos5 + ":" + segundos5;
                    }


                    if (time6.Days > 0)
                    {
                        p.HorasMantencion = ((time6.Days * 24) + time6.Hours) + ":" + minutos6 + ":" + segundos6;
                    }
                    else
                    {
                        p.HorasMantencion = time6.Hours + ":" + minutos6 + ":" + segundos6;
                    }
                    if (time7.Days > 0)
                    {
                        p.HorasPruebaImpresion = ((time7.Days * 24) + time7.Hours) + ":" + minutos7 + ":" + segundos7;
                    }
                    else
                    {
                        p.HorasPruebaImpresion = time7.Hours + ":" + minutos7 + ":" + segundos7;
                    }
                    #endregion

                    p.Buenos = Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    p.GirosMalosTiraje = p.PliegosMalosTiraje;
                    p.GirosMalosPreparacion = p.PliegosMalosPreparacion;
                    p.GirosBuenosTiraje = p.Buenos;
                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<PartesMetrics> EstadisticaProduccionDiaria_Lithoman(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_InformeProduccionDiaria_Lithoman]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);
                cmd.CommandTimeout = 30000000;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartesMetrics p = new PartesMetrics();
                    p.Semana = Convert.ToDateTime(reader["semana"].ToString()).ToString("dd/MM/yyyy");
                    p.Maquina = reader["Maquina"].ToString();
                    p.Entradas = reader["Entradas"].ToString();
                    TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    TimeSpan time2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    TimeSpan time3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    TimeSpan time4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    TimeSpan time5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    TimeSpan time6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    TimeSpan time7 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPruebaImpresion"].ToString()));
                    #region Minutos
                    string minutos = "";
                    if (time.Minutes > 9)
                    {
                        minutos = time.Minutes.ToString();
                    }
                    else
                    {
                        minutos = "0" + time.Minutes;
                    }
                    string minutos2 = "";
                    if (time2.Minutes > 9)
                    {
                        minutos2 = time2.Minutes.ToString();
                    }
                    else
                    {
                        minutos2 = "0" + time2.Minutes;
                    }
                    string minutos3 = "";
                    if (time3.Minutes > 9)
                    {
                        minutos3 = time3.Minutes.ToString();
                    }
                    else
                    {
                        minutos3 = "0" + time3.Minutes;
                    }
                    string minutos4 = "";
                    if (time4.Minutes > 9)
                    {
                        minutos4 = time4.Minutes.ToString();
                    }
                    else
                    {
                        minutos4 = "0" + time4.Minutes;
                    }
                    string minutos5 = "";
                    if (time5.Minutes > 9)
                    {
                        minutos5 = time5.Minutes.ToString();
                    }
                    else
                    {
                        minutos5 = "0" + time5.Minutes;
                    }
                    string minutos6 = "";
                    if (time6.Minutes > 9)
                    {
                        minutos6 = time6.Minutes.ToString();
                    }
                    else
                    {
                        minutos6 = "0" + time6.Minutes;
                    }
                    string minutos7 = "";
                    if (time7.Minutes > 9)
                    {
                        minutos7 = time7.Minutes.ToString();
                    }
                    else
                    {
                        minutos7 = "0" + time7.Minutes;
                    }
                    #endregion
                    #region Tiempo
                    //
                    string segundos = "";
                    if (time.Seconds > 9)
                    {
                        segundos = time.Seconds.ToString();
                    }
                    else
                    {
                        segundos = "0" + time.Seconds;
                    }
                    string segundos2 = "";
                    if (time2.Seconds > 9)
                    {
                        segundos2 = time2.Seconds.ToString();
                    }
                    else
                    {
                        segundos2 = "0" + time2.Seconds;
                    }
                    string segundos3 = "";
                    if (time3.Seconds > 9)
                    {
                        segundos3 = time3.Seconds.ToString();
                    }
                    else
                    {
                        segundos3 = "0" + time3.Seconds;
                    }
                    string segundos4 = "";
                    if (time4.Seconds > 9)
                    {
                        segundos4 = time4.Seconds.ToString();
                    }
                    else
                    {
                        segundos4 = "0" + time4.Seconds;
                    }
                    string segundos5 = "";
                    if (time5.Seconds > 9)
                    {
                        segundos5 = time5.Seconds.ToString();
                    }
                    else
                    {
                        segundos5 = "0" + time5.Seconds;
                    }
                    string segundos6 = "";
                    if (time6.Seconds > 9)
                    {
                        segundos6 = time6.Seconds.ToString();
                    }
                    else
                    {
                        segundos6 = "0" + time6.Seconds;
                    }
                    string segundos7 = "";
                    if (time7.Seconds > 9)
                    {
                        segundos7 = time7.Seconds.ToString();
                    }
                    else
                    {
                        segundos7 = "0" + time7.Seconds;
                    }








                    if (time.Days > 0)
                    {
                        p.HorasTiraje = ((time.Days * 24) + time.Hours) + ":" + minutos + ":" + segundos;

                    }
                    else
                    {
                        p.HorasTiraje = time.Hours + ":" + minutos + ":" + segundos;
                    }


                    if (time2.Days > 0)
                    {
                        p.HorasImproductivas = ((time2.Days * 24) + time2.Hours) + ":" + minutos2 + ":" + segundos2;
                    }
                    else
                    {
                        p.HorasImproductivas = time2.Hours + ":" + minutos2 + ":" + segundos2;
                    }

                    if (time3.Days > 0)
                    {
                        p.HorasPreparacion = ((time3.Days * 24) + time3.Hours) + ":" + minutos3 + ":" + segundos3;
                    }
                    else
                    {
                        p.HorasPreparacion = time3.Hours + ":" + minutos3 + ":" + segundos3;
                    }

                    if (time4.Days > 0)
                    {
                        p.HorasSinTrabajo = ((time4.Days * 24) + time4.Hours) + ":" + minutos4 + ":" + segundos4;
                    }
                    else
                    {
                        p.HorasSinTrabajo = time4.Hours + ":" + minutos4 + ":" + segundos4;
                    }

                    if (time5.Days > 0)
                    {
                        p.HorasSinPersonal = ((time5.Days * 24) + time5.Hours) + ":" + minutos5 + ":" + segundos5;
                    }
                    else
                    {
                        p.HorasSinPersonal = time5.Hours + ":" + minutos5 + ":" + segundos5;
                    }


                    if (time6.Days > 0)
                    {
                        p.HorasMantencion = ((time6.Days * 24) + time6.Hours) + ":" + minutos6 + ":" + segundos6;
                    }
                    else
                    {
                        p.HorasMantencion = time6.Hours + ":" + minutos6 + ":" + segundos6;
                    }
                    if (time7.Days > 0)
                    {
                        p.HorasPruebaImpresion = ((time7.Days * 24) + time7.Hours) + ":" + minutos7 + ":" + segundos7;
                    }
                    else
                    {
                        p.HorasPruebaImpresion = time7.Hours + ":" + minutos7 + ":" + segundos7;
                    }
                    #endregion
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

        //FIN INFORME ESTADISTICA PRODUCCION
        public List<PartesDeProduccion> Listar_Pliegos_Partes(string ot, string pliegos, string Cliente, string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesDeProduccion> lista = new List<PartesDeProduccion>();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_PARTES();
            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_PARTES_PRODUCCION]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@PLIEGO", pliegos);
                cmd.Parameters.AddWithValue("@CLIENTE", Cliente);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    PartesDeProduccion pro = new PartesDeProduccion();
                    pro.Pliegos = read["PLIEGOS"].ToString();

                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public string Carga_Cliente(string ot, string pliegos, string Cliente, string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionDataP2B2000_PARTES();

            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_PARTES_PRODUCCION]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@PLIEGO", pliegos);
                cmd.Parameters.AddWithValue("@CLIENTE", Cliente);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    //pro.Proceso = reader["NombreProceso"].ToString();
                   res = reader["CLIENTE"].ToString();


                }
            }
            conexion.CerrarConexion();
            return res;
        }
        public string Carga_Maquina(string ot, string pliegos, string Cliente, string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionDataP2B2000_PARTES();

            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_PARTES_PRODUCCION]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@PLIEGO", pliegos);
                cmd.Parameters.AddWithValue("@CLIENTE", Cliente);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    //pro.Proceso = reader["NombreProceso"].ToString();
                    res = reader["MAQUINA"].ToString();


                }
            }
            conexion.CerrarConexion();
            return res;
        }
        public List<PartesDeProduccion> Listar_Maquinas(string ot, string pliegos, string Cliente, string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesDeProduccion> lista = new List<PartesDeProduccion>();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_PARTES();
            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_PARTES_PRODUCCION]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@PLIEGO", pliegos); 
                cmd.Parameters.AddWithValue("@CLIENTE", Cliente);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    PartesDeProduccion pro = new PartesDeProduccion();
                    pro.ID_Maquina = read["ID_PP"].ToString();
                    pro.Maquina = read["NOMBRE_PP"].ToString();

                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<PartesDeProduccion> Resultado_Listar(string ot, string pliegos, string Cliente, string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesDeProduccion> lista = new List<PartesDeProduccion>();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_PARTES();
            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_PARTES_PRODUCCION]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@PLIEGO", pliegos);
                cmd.Parameters.AddWithValue("@CLIENTE", Cliente);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    PartesDeProduccion pro = new PartesDeProduccion();
                    pro.OT = read["OT"].ToString().ToUpper();
                    pro.NombreOT = read["Nombre_OT"].ToString().ToLower();
                    pro.Cliente = read["Cliente_OT"].ToString().ToLower();
                    pro.Forma = read["Forma"].ToString();
                    pro.Pliegos = read["Pliegos"].ToString();
                    pro.Maquina = read["Maquinas"].ToString().ToLower();
                    pro.Giros_Buenos = read["Giros_Buenos"].ToString();
                    pro.Malos_Arranque = Convert.ToInt32(read["Malos_Arranque"].ToString()).ToString("N0").Replace(",", ".");

                    try
                    {
                        pro.Buenos = Convert.ToInt32(read["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                        pro.Malos = Convert.ToInt32(read["Malos"].ToString()).ToString("N0").Replace(",", ".");
                        pro.TirajeOT = "";// Convert.ToInt32(read["TIRAJE_OT"].ToString()).ToString("N0").Replace(",", ".");
                    }
                    catch
                    {
                        pro.Buenos = read["Buenos"].ToString();
                        pro.Malos = read["Malos"].ToString();
                        pro.TirajeOT = "";//read["TIRAJE_OT"].ToString();
                    }
                    pro.Fecha_Inicio = Convert.ToDateTime(read["Fecha_Inicio"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.Fecha_Fin = Convert.ToDateTime(read["Fecha_Fin"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + pro.OT.Trim() + "\",\"" + pro.Pliegos + "\")'>Ver Más</a>";
                    // wp.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + wp.OT + "\",\"" + wp.ID_Control + "\")'>Ver Más</a>";
                   

                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string Carga_Detalle_Pliego(string OT,string Pliego)
        {
            
            string Historial = "<table cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px;width:95%;'>" +
                                  "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>NOMBRE OPERACION</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>INICIO PROCESO</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>FIN PROCESO</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc; Width:100px;'>HORAS TRABAJADAS</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>GIROS BUENOS</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>PLIEGOS BUENOS</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>GIROS MALOS</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>PLIEGOS MALOS</td>" +
                                  "</tr>";
            double plbuenos = 0;
            double MalosArranque = 0;
            double MalosTiraje = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_PARTES();
            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_DETALLE_PLIEGOS]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@PLIEGO", Pliego);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime ini = Convert.ToDateTime(reader["INICIO_PROCESO"].ToString());
                    DateTime fin = Convert.ToDateTime(reader["FIN_PROCESO"].ToString());
                    TimeSpan ts = fin - ini;
                    if (reader["NOMBRE_OPERACION"].ToString() == "ARRANQUE")
                    {
                        MalosArranque = MalosArranque + Convert.ToDouble(reader["MALOS"].ToString());
                    }
                    else if (reader["NOMBRE_OPERACION"].ToString() == "TIRAJE")
                    {
                        MalosTiraje = MalosTiraje + Convert.ToDouble(reader["MALOS"].ToString());
                    }

                    Historial = Historial + "<tr style='border-bottom:1px solid blue;height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;'>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: left;'>" + reader["NOMBRE_OPERACION"].ToString() + "&nbsp;&nbsp;&nbsp;</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: center;'>" + Convert.ToDateTime(reader["INICIO_PROCESO"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "&nbsp;&nbsp;&nbsp;</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: center;'>" + Convert.ToDateTime(reader["FIN_PROCESO"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "&nbsp;&nbsp;&nbsp;</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: center; Width:100px;'>" + ts.ToString() + "&nbsp;&nbsp;&nbsp;</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + Convert.ToDouble(reader["GIROS_BUENOS"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;&nbsp;</td>";//.Replace(",", ".")
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + Convert.ToDouble(reader["BUENOS"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;&nbsp;</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + Convert.ToDouble(reader["GIROS_MALOS"].ToString()).ToString("N0").Replace(",", ".").Replace(",", ".") + "&nbsp;&nbsp;&nbsp;</td>";
                    Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + Convert.ToDouble(reader["MALOS"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;&nbsp;&nbsp;</td>";
                    Historial = Historial + "</tr>";
                    plbuenos = plbuenos + Convert.ToDouble(reader["BUENOS"].ToString());
                  //  plmalos = plmalos + Convert.ToDouble(reader["MALOS"].ToString());
                }

                Historial = Historial + "</table>";

                Historial = Historial + "<div id='ubicacion' style='margin-left:623px;'>";

                Historial = Historial + "<table cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px;width:500px;'>" +
                                  "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'></td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Pliegos Buenos</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Malos Arranque</td>" +
                                    "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Malos Tiraje</td>" +
                                 "</tr>";
                Historial = Historial + "<tr style='border-bottom:1px solid blue;height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;'>";
                Historial = Historial + "<td style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e;font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>TOTAL PLIEGOS: </td>";
                Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: center;'>" + plbuenos.ToString("N0").Replace(",", ".") + "</td>";
                Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: center;'>" + MalosArranque.ToString("N0").Replace(",", ".") + "</td>";
                Historial = Historial + "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: center;'>" + MalosTiraje.ToString("N0").Replace(",", ".") + "</td>";
                Historial = Historial + "</table>";

                Historial = Historial + "</div>";

            }
            con.CerrarConexion();
            return Historial;
        }
        // PROCEDIMIENTOS HORAS IMPRODUCTIVAS PLANAS
        public List<PartesDeProduccion> Listar_Maquinas_Planas(string operacion, string Maquina,string seccion, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesDeProduccion> lista = new List<PartesDeProduccion>();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_PARTES();
            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_HORAS_IMPRODUCTIVAS_PLANAS]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OPERACION", operacion);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@SECCION", seccion);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    PartesDeProduccion pro = new PartesDeProduccion();
                    pro.ID_Maquina = read["ID_PP"].ToString();
                    pro.Maquina = read["NOMBRE_PP"].ToString();

                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<PartesDeProduccion> Listar_Operaciones(string operacion, string Maquina,string seccion, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesDeProduccion> lista = new List<PartesDeProduccion>();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_PARTES();
            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_HORAS_IMPRODUCTIVAS_PLANAS]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OPERACION", operacion);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@SECCION", seccion);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    PartesDeProduccion pro = new PartesDeProduccion();
                    pro.ID_Maquina = read["ID_OPERACION"].ToString();
                    pro.Maquina = read["NOMBRE_OPERACION"].ToString();

                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<PartesDeProduccion> Listar_Horas_Improductivas(string operacion, string Maquina,string Seccion, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesDeProduccion> lista = new List<PartesDeProduccion>();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_PARTES();
            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_HORAS_IMPRODUCTIVAS_PLANAS]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OPERACION", operacion);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@SECCION", Seccion);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    PartesDeProduccion pro = new PartesDeProduccion();
                   // pro.ID_Maquina = read["ID_OPERACION"].ToString();
                    pro.Maquina = read["Maquina"].ToString();
                    pro.OT = read["Operacion"].ToString();
                    pro.NombreOT = read["horas"].ToString();
                    pro.VerMas = "Ver Detalle";

                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<PartesDeProduccion> Listar_Maquinas_TODAS(string operacion, string Maquina, string seccion, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesDeProduccion> lista = new List<PartesDeProduccion>();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_PARTES();
            if (cmd != null)
            {
                cmd.CommandText = "[INTRANET_HORAS_IMPRODUCTIVAS_PLANAS]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OPERACION", operacion);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@SECCION", seccion);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    PartesDeProduccion pro = new PartesDeProduccion();
                    pro.ID_SECCION = read["ID_SECCION"].ToString();
                    pro.NOMBRE_SECCION = read["NOMBRE_SECCION"].ToString();

                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<PartesMetrics> Lista_Resumen_PartesProduccionMetrics(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_PartesMetrics]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartesMetrics p = new PartesMetrics();
                    p.Semana = reader["Semana"].ToString();
                    p.Maquina = reader["Maquina"].ToString();
                   // p.Buenos = reader["Buenos"].ToString();
                    //p.Entradas = reader["Entradas"].ToString();
                    p.Entradas = EntradasMetrics(Convert.ToInt32(p.Semana), p.Maquina, fechainicio, fechatermino);
                    TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    TimeSpan time2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    TimeSpan time3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    TimeSpan time4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    TimeSpan time5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    TimeSpan time6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    #region Minutos
                    string minutos = "";
                    if (time.Minutes > 9)
                    {
                        minutos = time.Minutes.ToString();
                    }
                    else
                    {
                        minutos = "0" + time.Minutes;
                    }
                    string minutos2 = "";
                    if (time2.Minutes > 9)
                    {
                        minutos2 = time2.Minutes.ToString();
                    }
                    else
                    {
                        minutos2 = "0" + time2.Minutes;
                    }
                    string minutos3 = "";
                    if (time3.Minutes > 9)
                    {
                        minutos3 = time3.Minutes.ToString();
                    }
                    else
                    {
                        minutos3 = "0" + time3.Minutes;
                    }
                    string minutos4 = "";
                    if (time4.Minutes > 9)
                    {
                        minutos4 = time4.Minutes.ToString();
                    }
                    else
                    {
                        minutos4 = "0" + time4.Minutes;
                    }
                    string minutos5 = "";
                    if (time5.Minutes > 9)
                    {
                        minutos5 = time5.Minutes.ToString();
                    }
                    else
                    {
                        minutos5 = "0" + time5.Minutes;
                    }
                    string minutos6 = "";
                    if (time6.Minutes > 9)
                    {
                        minutos6 = time6.Minutes.ToString();
                    }
                    else
                    {
                        minutos6 = "0" + time6.Minutes;
                    }
                    #endregion
                    #region Tiempo
                    //
                    string segundos = "";
                    if (time.Seconds > 9)
                    {
                        segundos = time.Seconds.ToString();
                    }
                    else
                    {
                        segundos = "0" + time.Seconds;
                    }
                    string segundos2 = "";
                    if (time2.Seconds > 9)
                    {
                        segundos2 = time2.Seconds.ToString();
                    }
                    else
                    {
                        segundos2 = "0" + time2.Seconds;
                    }
                    string segundos3 = "";
                    if (time3.Seconds > 9)
                    {
                        segundos3 = time3.Seconds.ToString();
                    }
                    else
                    {
                        segundos3 = "0" + time3.Seconds;
                    }
                    string segundos4 = "";
                    if (time4.Seconds > 9)
                    {
                        segundos4 = time4.Seconds.ToString();
                    }
                    else
                    {
                        segundos4 = "0" + time4.Seconds;
                    }
                    string segundos5 = "";
                    if (time5.Seconds > 9)
                    {
                        segundos5 = time5.Seconds.ToString();
                    }
                    else
                    {
                        segundos5 = "0" + time5.Seconds;
                    }
                    string segundos6 = "";
                    if (time6.Seconds > 9)
                    {
                        segundos6 = time6.Seconds.ToString();
                    }
                    else
                    {
                        segundos6 = "0" + time6.Seconds;
                    }









                    if (time.Days > 0)
                    {
                     p.HorasTiraje = ((time.Days * 24) + time.Hours) + ":" + minutos + ":" + segundos;
                        
                    }
                    else
                    {
                        p.HorasTiraje = time.Hours + ":" + minutos + ":" + segundos;
                    }

                    
                    if (time2.Days > 0)
                    {
                        p.HorasImproductivas = ((time2.Days * 24) + time2.Hours) + ":" + minutos2 + ":" + segundos2;
                    }
                    else
                    {
                        p.HorasImproductivas = time2.Hours + ":" + minutos2 + ":" + segundos2;
                    }
                   
                    if (time3.Days > 0)
                    {
                        p.HorasPreparacion = ((time3.Days * 24) + time3.Hours) + ":" + minutos3 + ":" + segundos3;
                    }
                    else
                    {
                        p.HorasPreparacion = time3.Hours + ":" + minutos3 + ":" + segundos3;
                    }
                   
                    if (time4.Days > 0)
                    {
                        p.HorasSinTrabajo = ((time4.Days * 24) + time4.Hours) + ":" + minutos4 + ":" + segundos4;
                    }
                    else
                    {
                        p.HorasSinTrabajo = time4.Hours + ":" + minutos4 + ":" + segundos4;
                    }
                    
                    if (time5.Days > 0)
                    {
                        p.HorasSinPersonal = ((time5.Days * 24) + time5.Hours) + ":" + minutos5 + ":" + segundos5;
                    }
                    else
                    {
                        p.HorasSinPersonal = time5.Hours + ":" + minutos5 + ":" + segundos5;
                    }

                  
                    if (time6.Days > 0)
                    {
                        p.HorasMantencion = ((time6.Days * 24) + time6.Hours) + ":" + minutos6 + ":" + segundos6;
                    }
                    else
                    {
                        p.HorasMantencion = time6.Hours + ":" + minutos6 + ":" + segundos6;
                    }
                    #endregion

                    p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString();//.Replace(",", ".");
                    p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString();
                    //p.GirosBuenosTiraje = reader["GirosBuenosTiraje"].ToString();
                    //p.GirosMalos = reader["GirosMalos"].ToString();
                    //p.GirosMalosPreparacion = reader["GirosMalosPreparacion"].ToString();
                    //p.GirosMalosTiraje = reader["GirosMalosTiraje"].ToString();

                    if (Maquina == "mr408")
                    {
                        string va= GirosMetrics(Convert.ToInt32(p.Semana), fechainicio, fechatermino, Convert.ToInt32(p.Buenos));
                        string[] str = va.Split('-');
                        p.GirosBuenosTiraje = Convert.ToInt32(str[0]).ToString();
                        //p.Buenos = Convert.ToInt32(str[1]).ToString();
                        p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                        //p.GirosBuenosTiraje =
                      //  p.Buenos = BuenosMetrics(Convert.ToInt32(p.Semana), fechainicio, fechatermino, Convert.ToInt32(p.Buenos));

                    }
                    else 
                    {
                        p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString();
                        p.GirosBuenosTiraje = Convert.ToInt32(reader["Buenos"].ToString()).ToString();

                    }
                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<PartesMetrics> Lista_Resumen_PartesProduccionDiario(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_PartesMetricsDiario]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);
                cmd.CommandTimeout = 30000000;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartesMetrics p = new PartesMetrics();
                    p.Semana = Convert.ToDateTime(reader["Semana"].ToString()).ToString("dd/MM/yyyy");
                    p.Maquina = reader["Maquina"].ToString();
                    // p.Buenos = reader["Buenos"].ToString();
                   // p.Entradas = reader["Entradas"].ToString();
                    p.Entradas = EntradasMetricsDiario(reader["Maquina"].ToString(), Convert.ToDateTime(reader["Semana"].ToString()));
                    TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    TimeSpan time2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    TimeSpan time3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    TimeSpan time4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    TimeSpan time5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    TimeSpan time6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    #region Minutos
                    string minutos = "";
                    if (time.Minutes > 9)
                    {
                        minutos = time.Minutes.ToString();
                    }
                    else
                    {
                        minutos = "0" + time.Minutes;
                    }
                    string minutos2 = "";
                    if (time2.Minutes > 9)
                    {
                        minutos2 = time2.Minutes.ToString();
                    }
                    else
                    {
                        minutos2 = "0" + time2.Minutes;
                    }
                    string minutos3 = "";
                    if (time3.Minutes > 9)
                    {
                        minutos3 = time3.Minutes.ToString();
                    }
                    else
                    {
                        minutos3 = "0" + time3.Minutes;
                    }
                    string minutos4 = "";
                    if (time4.Minutes > 9)
                    {
                        minutos4 = time4.Minutes.ToString();
                    }
                    else
                    {
                        minutos4 = "0" + time4.Minutes;
                    }
                    string minutos5 = "";
                    if (time5.Minutes > 9)
                    {
                        minutos5 = time5.Minutes.ToString();
                    }
                    else
                    {
                        minutos5 = "0" + time5.Minutes;
                    }
                    string minutos6 = "";
                    if (time6.Minutes > 9)
                    {
                        minutos6 = time6.Minutes.ToString();
                    }
                    else
                    {
                        minutos6 = "0" + time6.Minutes;
                    }
                    #endregion
                    #region Tiempo
                    //
                    string segundos = "";
                    if (time.Seconds > 9)
                    {
                        segundos = time.Seconds.ToString();
                    }
                    else
                    {
                        segundos = "0" + time.Seconds;
                    }
                    string segundos2 = "";
                    if (time2.Seconds > 9)
                    {
                        segundos2 = time2.Seconds.ToString();
                    }
                    else
                    {
                        segundos2 = "0" + time2.Seconds;
                    }
                    string segundos3 = "";
                    if (time3.Seconds > 9)
                    {
                        segundos3 = time3.Seconds.ToString();
                    }
                    else
                    {
                        segundos3 = "0" + time3.Seconds;
                    }
                    string segundos4 = "";
                    if (time4.Seconds > 9)
                    {
                        segundos4 = time4.Seconds.ToString();
                    }
                    else
                    {
                        segundos4 = "0" + time4.Seconds;
                    }
                    string segundos5 = "";
                    if (time5.Seconds > 9)
                    {
                        segundos5 = time5.Seconds.ToString();
                    }
                    else
                    {
                        segundos5 = "0" + time5.Seconds;
                    }
                    string segundos6 = "";
                    if (time6.Seconds > 9)
                    {
                        segundos6 = time6.Seconds.ToString();
                    }
                    else
                    {
                        segundos6 = "0" + time6.Seconds;
                    }









                    if (time.Days > 0)
                    {
                        p.HorasTiraje = ((time.Days * 24) + time.Hours) + ":" + minutos + ":" + segundos;

                    }
                    else
                    {
                        p.HorasTiraje = time.Hours + ":" + minutos + ":" + segundos;
                    }


                    if (time2.Days > 0)
                    {
                        p.HorasImproductivas = ((time2.Days * 24) + time2.Hours) + ":" + minutos2 + ":" + segundos2;
                    }
                    else
                    {
                        p.HorasImproductivas = time2.Hours + ":" + minutos2 + ":" + segundos2;
                    }

                    if (time3.Days > 0)
                    {
                        p.HorasPreparacion = ((time3.Days * 24) + time3.Hours) + ":" + minutos3 + ":" + segundos3;
                    }
                    else
                    {
                        p.HorasPreparacion = time3.Hours + ":" + minutos3 + ":" + segundos3;
                    }

                    if (time4.Days > 0)
                    {
                        p.HorasSinTrabajo = ((time4.Days * 24) + time4.Hours) + ":" + minutos4 + ":" + segundos4;
                    }
                    else
                    {
                        p.HorasSinTrabajo = time4.Hours + ":" + minutos4 + ":" + segundos4;
                    }

                    if (time5.Days > 0)
                    {
                        p.HorasSinPersonal = ((time5.Days * 24) + time5.Hours) + ":" + minutos5 + ":" + segundos5;
                    }
                    else
                    {
                        p.HorasSinPersonal = time5.Hours + ":" + minutos5 + ":" + segundos5;
                    }


                    if (time6.Days > 0)
                    {
                        p.HorasMantencion = ((time6.Days * 24) + time6.Hours) + ":" + minutos6 + ":" + segundos6;
                    }
                    else
                    {
                        p.HorasMantencion = time6.Hours + ":" + minutos6 + ":" + segundos6;
                    }
                    #endregion

                    if (Maquina == "mr408")
                    {
                        string va = GirosMetricsDiario2(Convert.ToDateTime(reader["Semana"].ToString()));
                        
                        p.GirosBuenosTiraje = Convert.ToInt32(va).ToString("N0").Replace(",", ".");
                        p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");// Convert.ToInt32(str[1]).ToString("N0").Replace(",", ".");


                        string ba = MalosMetricsDiario(Convert.ToDateTime(reader["Semana"].ToString()),1);
                        string[] str = ba.Split('-');

                        p.PliegosMalosPreparacion = Convert.ToInt32(str[0]).ToString("N0").Replace(",", ".");
                        p.PliegosMalosTiraje = Convert.ToInt32(str[1]).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                        p.GirosBuenosTiraje = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");

                        p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                        p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");

                    }
                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public string EntradasMetrics(int Semana, string Maquina, DateTime fechainicio, DateTime fechatermino)
        {
   
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string proceso = "";
            string fechaproceso = "";
            int entradas = 0;
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_EntradasMetrics]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SEMANA", Semana);
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    entradas = entradas + 1;
                }
            }
            conexion.CerrarConexion();
            return entradas.ToString();
        }
        public string EntradasMetricsDiario(string Maquina, DateTime fecha)
        {

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            int entradas = 0;
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_EntradasMetricsDiario]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHA", fecha);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    entradas = entradas + 1;
                }
            }
            conexion.CerrarConexion();
            return entradas.ToString();
        }
        public string GirosMetrics(int Semana, DateTime fechainicio, DateTime fechatermino, int totalBuenos)
        {

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            int Giros = 0;
            int buenos = 0;
            if (cmd != null)
            {
                cmd.CommandText = "[GirosMetrics]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SEMANA", Semana);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.CommandTimeout = 600000;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    buenos = buenos + (Convert.ToInt32(reader["Buenos"].ToString()));
                    string a = reader["Buenos"].ToString();
                    double fact = 0;
                    if (reader["Factor"].ToString() == "")
                    {
                        fact = 1;
                    }
                    else
                    {
                        fact = Convert.ToDouble(reader["Factor"].ToString());
                    }
                    
                    Giros = Giros + Convert.ToInt32((Convert.ToDouble(reader["Buenos"].ToString()) * Convert.ToDouble(fact)));//Convert.ToInt32(reader["Giros"].ToString())
                }
                //if ((totalBuenos-Giros) == 0)
                //{
                //    //mostrar giros por lithoman
                //}
                //else
                //{
                //    //mostrar giros + buenos
                //}
            }
            conexion.CerrarConexion();
            return Giros.ToString() + "-" + buenos.ToString();
        }
        public string MalosMetricsDiario(DateTime fecha , int procedimiento)
        {

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            int MalosPreparacion = 0;
            int MalosTiraje = 0;
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_MalosMetricsDiario]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FECHA", fecha);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                cmd.CommandTimeout = 600000;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    double fact = 0;
                    if (reader["Factor"].ToString() == "")
                    {
                        fact = 1;
                    }
                    else
                    {
                        fact = Convert.ToDouble(reader["Factor"].ToString());
                    }

                    MalosPreparacion = MalosPreparacion + Convert.ToInt32((Convert.ToDouble(reader["DesperdicioAcerto"].ToString()) * Convert.ToDouble(fact)));
                    MalosTiraje = MalosTiraje + Convert.ToInt32((Convert.ToDouble(reader["DesperdicioVirando"].ToString()) * Convert.ToDouble(fact)));
                }
            }
            conexion.CerrarConexion();
            return MalosPreparacion.ToString() + "-" + MalosTiraje.ToString();
        }
        public string GirosMetricsDiario2(DateTime fecha)
        {
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            int Giros = 0;
            if (cmd != null)
            {
                cmd.CommandText = "[GirosMetricsDiario]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FECHA", fecha);
                cmd.CommandTimeout = 600000;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    double fact = 0;
                    if (reader["Factor"].ToString() == "")
                    {
                        fact = 1;
                    }
                    else
                    {
                        fact = Convert.ToDouble(reader["Factor"].ToString());
                    }

                    Giros = Giros + Convert.ToInt32((Convert.ToDouble(reader["Buenos"].ToString()) * Convert.ToDouble(fact)));//Convert.ToInt32(reader["Giros"].ToString())
                }

            }
            conexion.CerrarConexion();
            return Giros.ToString();
        }
        public string GirosMetricsDiario(DateTime Semana, DateTime fechainicio, DateTime fechatermino, int totalBuenos)
        {

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            int Giros = 0;
            int buenos = 0;
            if (cmd != null)
            {
                cmd.CommandText = "[GirosMetricsDiario]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SEMANA", Semana);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.CommandTimeout = 600000;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    buenos = buenos + (Convert.ToInt32(reader["Buenos"].ToString()));
                    string a = reader["Buenos"].ToString();
                    double fact = 0;
                    if (reader["Factor"].ToString() == "")
                    {
                        fact = 1;
                    }
                    else
                    {
                        fact = Convert.ToDouble(reader["Factor"].ToString());
                    }

                    Giros = Giros + Convert.ToInt32((Convert.ToDouble(reader["Buenos"].ToString()) * Convert.ToDouble(fact)));//Convert.ToInt32(reader["Giros"].ToString())
                }
                //if ((totalBuenos-Giros) == 0)
                //{
                //    //mostrar giros por lithoman
                //}
                //else
                //{
                //    //mostrar giros + buenos
                //}
            }
            conexion.CerrarConexion();
            return Giros.ToString() + "-" + buenos.ToString();
        }

        public List<PartesMetrics> Lista_Resumen_PartesProduccionMetrics_Diario(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_PartesMetrics_Diario]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUINA", Maquina);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fechatermino);
                cmd.Parameters.AddWithValue("@PROCEDIMIENTO", procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartesMetrics p = new PartesMetrics();
                    p.Semana = Convert.ToDateTime(reader["Semana"].ToString()).ToString("dd/MM/yyyy");
                    p.Maquina = reader["Maquina"].ToString();
                    // p.Buenos = reader["Buenos"].ToString();
                    p.Entradas = reader["Entradas"].ToString();
                    TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    TimeSpan time2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    TimeSpan time3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    TimeSpan time4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    TimeSpan time5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    TimeSpan time6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    #region Minutos
                    string minutos = "";
                    if (time.Minutes > 9)
                    {
                        minutos = time.Minutes.ToString();
                    }
                    else
                    {
                        minutos = "0" + time.Minutes;
                    }
                    string minutos2 = "";
                    if (time2.Minutes > 9)
                    {
                        minutos2 = time2.Minutes.ToString();
                    }
                    else
                    {
                        minutos2 = "0" + time2.Minutes;
                    }
                    string minutos3 = "";
                    if (time3.Minutes > 9)
                    {
                        minutos3 = time3.Minutes.ToString();
                    }
                    else
                    {
                        minutos3 = "0" + time3.Minutes;
                    }
                    string minutos4 = "";
                    if (time4.Minutes > 9)
                    {
                        minutos4 = time4.Minutes.ToString();
                    }
                    else
                    {
                        minutos4 = "0" + time4.Minutes;
                    }
                    string minutos5 = "";
                    if (time5.Minutes > 9)
                    {
                        minutos5 = time5.Minutes.ToString();
                    }
                    else
                    {
                        minutos5 = "0" + time5.Minutes;
                    }
                    string minutos6 = "";
                    if (time6.Minutes > 9)
                    {
                        minutos6 = time6.Minutes.ToString();
                    }
                    else
                    {
                        minutos6 = "0" + time6.Minutes;
                    }
                    #endregion
                    #region Tiempo
                    //
                    string segundos = "";
                    if (time.Seconds > 9)
                    {
                        segundos = time.Seconds.ToString();
                    }
                    else
                    {
                        segundos = "0" + time.Seconds;
                    }
                    string segundos2 = "";
                    if (time2.Seconds > 9)
                    {
                        segundos2 = time2.Seconds.ToString();
                    }
                    else
                    {
                        segundos2 = "0" + time2.Seconds;
                    }
                    string segundos3 = "";
                    if (time3.Seconds > 9)
                    {
                        segundos3 = time3.Seconds.ToString();
                    }
                    else
                    {
                        segundos3 = "0" + time3.Seconds;
                    }
                    string segundos4 = "";
                    if (time4.Seconds > 9)
                    {
                        segundos4 = time4.Seconds.ToString();
                    }
                    else
                    {
                        segundos4 = "0" + time4.Seconds;
                    }
                    string segundos5 = "";
                    if (time5.Seconds > 9)
                    {
                        segundos5 = time5.Seconds.ToString();
                    }
                    else
                    {
                        segundos5 = "0" + time5.Seconds;
                    }
                    string segundos6 = "";
                    if (time6.Seconds > 9)
                    {
                        segundos6 = time6.Seconds.ToString();
                    }
                    else
                    {
                        segundos6 = "0" + time6.Seconds;
                    }









                    if (time.Days > 0)
                    {
                        p.HorasTiraje = ((time.Days * 24) + time.Hours) + ":" + minutos + ":" + segundos;

                    }
                    else
                    {
                        p.HorasTiraje = time.Hours + ":" + minutos + ":" + segundos;
                    }


                    if (time2.Days > 0)
                    {
                        p.HorasImproductivas = ((time2.Days * 24) + time2.Hours) + ":" + minutos2 + ":" + segundos2;
                    }
                    else
                    {
                        p.HorasImproductivas = time2.Hours + ":" + minutos2 + ":" + segundos2;
                    }

                    if (time3.Days > 0)
                    {
                        p.HorasPreparacion = ((time3.Days * 24) + time3.Hours) + ":" + minutos3 + ":" + segundos3;
                    }
                    else
                    {
                        p.HorasPreparacion = time3.Hours + ":" + minutos3 + ":" + segundos3;
                    }

                    if (time4.Days > 0)
                    {
                        p.HorasSinTrabajo = ((time4.Days * 24) + time4.Hours) + ":" + minutos4 + ":" + segundos4;
                    }
                    else
                    {
                        p.HorasSinTrabajo = time4.Hours + ":" + minutos4 + ":" + segundos4;
                    }

                    if (time5.Days > 0)
                    {
                        p.HorasSinPersonal = ((time5.Days * 24) + time5.Hours) + ":" + minutos5 + ":" + segundos5;
                    }
                    else
                    {
                        p.HorasSinPersonal = time5.Hours + ":" + minutos5 + ":" + segundos5;
                    }


                    if (time6.Days > 0)
                    {
                        p.HorasMantencion = ((time6.Days * 24) + time6.Hours) + ":" + minutos6 + ":" + segundos6;
                    }
                    else
                    {
                        p.HorasMantencion = time6.Hours + ":" + minutos6 + ":" + segundos6;
                    }
                    #endregion

                    p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    //p.GirosBuenosTiraje = reader["GirosBuenosTiraje"].ToString();
                    //p.GirosMalos = reader["GirosMalos"].ToString();
                    //p.GirosMalosPreparacion = reader["GirosMalosPreparacion"].ToString();
                    //p.GirosMalosTiraje = reader["GirosMalosTiraje"].ToString();

                    if (Maquina == "mr408")
                    {
                        string va = GirosMetrics(Convert.ToInt32(p.Semana), fechainicio, fechatermino, Convert.ToInt32(p.Buenos));
                        string[] str = va.Split('-');
                        p.GirosBuenosTiraje = Convert.ToInt32(str[0]).ToString("N0").Replace(",", ".");
                        p.Buenos = Convert.ToInt32(reader["Buenos"]).ToString("N0").Replace(",","."); // Convert.ToInt32(str[1]).ToString("N0").Replace(",", ".");
                        //p.GirosBuenosTiraje =
                        //  p.Buenos = BuenosMetrics(Convert.ToInt32(p.Semana), fechainicio, fechatermino, Convert.ToInt32(p.Buenos));
                    }
                    else
                    {
                        p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                        p.GirosBuenosTiraje = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");

                    }
                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }
















        //Cambios informe producc
        public List<PartesMetrics> EstadisticaProduccion_Lithoman_V2(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
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