using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloProduccion.Controller
{
    public class Controller_PartesManuales
    {

        public List<PartesMetrics> Lista_Resumen_PartesManuales(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[IngresoPartes_ResumenPartes]";
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

                    if (reader["Maquina"].ToString() == "C150")
                    {
                        p.GirosBuenosTiraje = reader["Buenos"].ToString();
                        p.Buenos = BuenosFactorSemana(Convert.ToInt32(reader["Semana"].ToString()));
                        p.PliegosMalosPreparacion = MalosPreparacionFactorSemana(Convert.ToInt32(reader["Semana"].ToString()));
                        p.PliegosMalosTiraje = MalosTirajeFactorSemana(Convert.ToInt32(reader["Semana"].ToString()));
                        p.GirosMalosPreparacion = reader["PliegosMalosPreparacion"].ToString();
                        p.GirosMalosTiraje = reader["PliegosMalosTiraje"].ToString();
                    }
                    else
                    {
                        p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString();
                        p.GirosBuenosTiraje = Convert.ToInt32(reader["Buenos"].ToString()).ToString();
                        p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString();
                        p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString();
                    }
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

                    //p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString();
                    //p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString();

                    lista.Add(p);
                    //PartesMetrics p = new PartesMetrics();
                    //p.Semana = reader["Semana"].ToString();
                    //p.Maquina = reader["Maquina"].ToString();
                    //p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                    //p.Entradas = reader["Entradas"].ToString();
                    //TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    //TimeSpan time2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    //TimeSpan time3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    //TimeSpan time4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    //TimeSpan time5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    //TimeSpan time6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    //#region Minutos
                    //string minutos = "";
                    //if (time.Minutes > 9)
                    //{
                    //    minutos = time.Minutes.ToString();
                    //}
                    //else
                    //{
                    //    minutos = "0" + time.Minutes;
                    //}
                    //string minutos2 = "";
                    //if (time2.Minutes > 9)
                    //{
                    //    minutos2 = time2.Minutes.ToString();
                    //}
                    //else
                    //{
                    //    minutos2 = "0" + time2.Minutes;
                    //}
                    //string minutos3 = "";
                    //if (time3.Minutes > 9)
                    //{
                    //    minutos3 = time3.Minutes.ToString();
                    //}
                    //else
                    //{
                    //    minutos3 = "0" + time3.Minutes;
                    //}
                    //string minutos4 = "";
                    //if (time4.Minutes > 9)
                    //{
                    //    minutos4 = time4.Minutes.ToString();
                    //}
                    //else
                    //{
                    //    minutos4 = "0" + time4.Minutes;
                    //}
                    //string minutos5 = "";
                    //if (time5.Minutes > 9)
                    //{
                    //    minutos5 = time5.Minutes.ToString();
                    //}
                    //else
                    //{
                    //    minutos5 = "0" + time5.Minutes;
                    //}
                    //string minutos6 = "";
                    //if (time6.Minutes > 9)
                    //{
                    //    minutos6 = time6.Minutes.ToString();
                    //}
                    //else
                    //{
                    //    minutos6 = "0" + time6.Minutes;
                    //}
                    //#endregion
                    //#region Tiempo
                    ////
                    //string segundos = "";
                    //if (time.Seconds > 9)
                    //{
                    //    segundos = time.Seconds.ToString();
                    //}
                    //else
                    //{
                    //    segundos = "0" + time.Seconds;
                    //}
                    //string segundos2 = "";
                    //if (time2.Seconds > 9)
                    //{
                    //    segundos2 = time2.Seconds.ToString();
                    //}
                    //else
                    //{
                    //    segundos2 = "0" + time2.Seconds;
                    //}
                    //string segundos3 = "";
                    //if (time3.Seconds > 9)
                    //{
                    //    segundos3 = time3.Seconds.ToString();
                    //}
                    //else
                    //{
                    //    segundos3 = "0" + time3.Seconds;
                    //}
                    //string segundos4 = "";
                    //if (time4.Seconds > 9)
                    //{
                    //    segundos4 = time4.Seconds.ToString();
                    //}
                    //else
                    //{
                    //    segundos4 = "0" + time4.Seconds;
                    //}
                    //string segundos5 = "";
                    //if (time5.Seconds > 9)
                    //{
                    //    segundos5 = time5.Seconds.ToString();
                    //}
                    //else
                    //{
                    //    segundos5 = "0" + time5.Seconds;
                    //}
                    //string segundos6 = "";
                    //if (time6.Seconds > 9)
                    //{
                    //    segundos6 = time6.Seconds.ToString();
                    //}
                    //else
                    //{
                    //    segundos6 = "0" + time6.Seconds;
                    //}









                    //if (time.Days > 0)
                    //{
                    //    p.HorasTiraje = ((time.Days * 24) + time.Hours) + ":" + minutos + ":" + segundos;

                    //}
                    //else
                    //{
                    //    p.HorasTiraje = time.Hours + ":" + minutos + ":" + segundos;
                    //}


                    //if (time2.Days > 0)
                    //{
                    //    p.HorasImproductivas = ((time2.Days * 24) + time2.Hours) + ":" + minutos2 + ":" + segundos2;
                    //}
                    //else
                    //{
                    //    p.HorasImproductivas = time2.Hours + ":" + minutos2 + ":" + segundos2;
                    //}

                    //if (time3.Days > 0)
                    //{
                    //    p.HorasPreparacion = ((time3.Days * 24) + time3.Hours) + ":" + minutos3 + ":" + segundos3;
                    //}
                    //else
                    //{
                    //    p.HorasPreparacion = time3.Hours + ":" + minutos3 + ":" + segundos3;
                    //}

                    //if (time4.Days > 0)
                    //{
                    //    p.HorasSinTrabajo = ((time4.Days * 24) + time4.Hours) + ":" + minutos4 + ":" + segundos4;
                    //}
                    //else
                    //{
                    //    p.HorasSinTrabajo = time4.Hours + ":" + minutos4 + ":" + segundos4;
                    //}

                    //if (time5.Days > 0)
                    //{
                    //    p.HorasSinPersonal = ((time5.Days * 24) + time5.Hours) + ":" + minutos5 + ":" + segundos5;
                    //}
                    //else
                    //{
                    //    p.HorasSinPersonal = time5.Hours + ":" + minutos5 + ":" + segundos5;
                    //}


                    //if (time6.Days > 0)
                    //{
                    //    p.HorasMantencion = ((time6.Days * 24) + time6.Hours) + ":" + minutos6 + ":" + segundos6;
                    //}
                    //else
                    //{
                    //    p.HorasMantencion = time6.Hours + ":" + minutos6 + ":" + segundos6;
                    //}
                    //#endregion

                    //p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                    //p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    ////p.GirosBuenosTiraje = reader["GirosBuenosTiraje"].ToString();
                    //p.GirosMalos = reader["GirosMalos"].ToString();
                    //p.GirosMalosPreparacion = reader["GirosMalosPreparacion"].ToString();
                    //p.GirosMalosTiraje = reader["GirosMalosTiraje"].ToString();

                   //// if (Maquina == "mr408")
                   //// {
                   //////     string va = GirosMetrics(Convert.ToInt32(p.Semana), fechainicio, fechatermino, Convert.ToInt32(p.Buenos));
                   ////  //   string[] str = va.Split('-');
                   ////     p.GirosBuenosTiraje = Convert.ToInt32(str[0]).ToString("N0").Replace(",", ".");
                   ////     p.Buenos = Convert.ToInt32(str[1]).ToString("N0").Replace(",", ".");
                   ////     //p.GirosBuenosTiraje =
                   ////     //  p.Buenos = BuenosMetrics(Convert.ToInt32(p.Semana), fechainicio, fechatermino, Convert.ToInt32(p.Buenos));
                   //// }
                   //// else
                   //// {
                   ////     p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                   ////     p.GirosBuenosTiraje = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");

                   //// }
                  // lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }


        public List<PartesMetrics> Lista_Resumen_PartesManualesDiario(string Maquina, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            List<PartesMetrics> lista = new List<PartesMetrics>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[IngresoPartes_ResumenPartesDiario]";
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

                    if (reader["Maquina"].ToString() == "C150") 
                    {
                        p.GirosBuenosTiraje = reader["Buenos"].ToString();
                        p.Buenos = BuenosFactor(Convert.ToDateTime(reader["Semana"].ToString()));
                        p.PliegosMalosPreparacion = MalosPreparacionFactor(Convert.ToDateTime(reader["Semana"].ToString()));
                        p.PliegosMalosTiraje=MalosTirajeFactor(Convert.ToDateTime(reader["Semana"].ToString()));
                    }
                    else
                    {
                        p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString();
                        p.GirosBuenosTiraje = Convert.ToInt32(reader["Buenos"].ToString()).ToString();
                        p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString();
                        p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString();
                    }
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

                    //p.PliegosMalosPreparacion = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString();
                    //p.PliegosMalosTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString();

                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string BuenosFactor(DateTime dia)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[IngresoParter_BuenosFactor]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dia", dia);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["Buenos"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;

        }
        public string MalosTirajeFactor(DateTime dia)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[IngresoParter_MalosTirajeFactor]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dia", dia);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["Buenos"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;
        }
        public string MalosPreparacionFactor(DateTime dia)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[IngresoParter_MalosPreparacionFactor]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dia", dia);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["Buenos"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;
        }
        public string BuenosFactorSemana(int dia)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[IngresoParter_BuenosFactorSemana]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dia", dia);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["Buenos"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;

        }
        public string MalosTirajeFactorSemana(int dia)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[IngresoParter_MalosTirajeFactorSemana]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dia", dia);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["Buenos"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;
        }
        public string MalosPreparacionFactorSemana(int dia)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[IngresoParter_MalosPreparacionFactorSemana]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dia", dia);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["Buenos"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;
        }
        public List<ScoreCard> HistorialPorDia(string Maquina, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<ScoreCard> lista = new List<ScoreCard>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string ceros = "00";
            if (cmd != null)
            {
                cmd.CommandText = "IngresoPartes_Historial";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ScoreCard p = new ScoreCard();
                    p.Maquina = reader["Maquina"].ToString();
                    p.OT = Convert.ToDateTime(reader["Semana"].ToString()).ToString("dd/MM/yyyy");
                    int horas = (Convert.ToInt32(reader["HorasTiraje"].ToString()) + Convert.ToInt32(reader["HorasImproductivas"].ToString()) + Convert.ToInt32(reader["HorasPreparacion"].ToString()) + Convert.ToInt32(reader["HorasSinTrabajo"].ToString()) + Convert.ToInt32(reader["HorasSinPersonal"].ToString()) + Convert.ToInt32(reader["HorasMantencion"].ToString()));
                    TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(horas));
                    int Dias3 = t3.Days * 24;
                    p.HorasDirectas = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();
                    //p.Entradas = reader["Errores"].ToString();
                    string fi = FechaInicio.ToString("dd/MM/yyyy");
                    string ft = FechaTermino.ToString("dd/MM/yyyy");
                    p.Buenos = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:CargaDiaParte(\"" + p.Maquina + "\",\"" + fi + "\",\"" + ft + "\",\"" + p.OT + "\");'>Modificar</a>";
                    lista.Add(p);
                }
                
            }
            conexion.CerrarConexion();

            return lista;
        }
        public List<PartesManuales> HistorialCargaParte(string Maquina, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<PartesManuales> lista = new List<PartesManuales>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string ceros = "00";
            if (cmd != null)
            {
                cmd.CommandText = "IngresoPartes_Historial";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartesManuales p = new PartesManuales();
                    p.IDParte = reader["id_parte"].ToString();
                    p.Maquina = reader["Maquina"].ToString();
                    p.Codigo = reader["Codigo"].ToString();
                    p.Pliego = reader["Pliego"].ToString();
                    p.OT = reader["ot"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString();
                    p.FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    p.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    p.Buenos = reader["Buenos"].ToString();
                    p.Maloss = reader["Malos"].ToString();
                    p.Factor = reader["user1"].ToString();
                    p.FechaParte = Convert.ToDateTime(reader["FechaParte"].ToString()).ToString("dd/MM/yyyy");
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();

            return lista;
        }

        public string CargaErrores(string Maquina, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "IngresoPartes_Historial";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
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

        public bool ModificaParte(string idparte,string Codigo,string pliego,string ot,DateTime fechainicio,DateTime fechatermino,int buenos,int malos,int factor,DateTime fechaparte,int procedimiento)
        {
            bool res = false;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[IngresoPartes_ModificaHistorial]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDParte", idparte);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Pliego", pliego);
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Buenos", buenos);
                cmd.Parameters.AddWithValue("@Malos", malos);
                cmd.Parameters.AddWithValue("@Factor", factor);
                cmd.Parameters.AddWithValue("@FechaParte", fechaparte);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = Convert.ToBoolean(reader["respuesta"].ToString());
                }
            }
            conexion.CerrarConexion();
            return res;
        }
    }
}