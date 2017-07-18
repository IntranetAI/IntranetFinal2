using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloProduccion.Controller
{
    public class Controller_InfScoreCard
    {

        public List<ScoreCard> Lista_Detalle(string Ot,string Pliego,string Area,string Maquina,DateTime FechaInicio,DateTime FechaTermino, int Procedimiento)
        {
            List<ScoreCard> lista = new List<ScoreCard>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string ceros = "00";
            if (cmd != null)
            {
                cmd.CommandText = "Produccion_InformeScoreCard";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", Ot);
                cmd.Parameters.AddWithValue("@Pliego", Pliego);
                cmd.Parameters.AddWithValue("@Area", Area);
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
                    p.OT = reader["NumOrdem"].ToString();
                    p.NombreOT = reader["descricao"].ToString().ToLower();
                    p.Pliego = reader["Pliego"].ToString();
                    p.Cliente = reader["Cliente"].ToString().ToLower();
                    //p.Entradas = reader["Entradas"].ToString();
                    p.Planificado = Convert.ToInt32(reader["QtdPlanejado"].ToString()).ToString("N0").Replace(",", ".");
                    //p.Entradas = CargaEntradas(p.OT, reader["processo"].ToString(), reader["CodRecurso"].ToString(), FechaInicio, FechaTermino, 1); //Convert.ToInt32(reader["Entradas"].ToString()).ToString("N0").Replace(",", ".");
                    //p.Giros = "";// Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".");
                    //p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                    //p.HorasPreparacion = reader["HorasPreparacion"].ToString();
                   
                    TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    int Dias1 = t1.Days * 24;
                    p.HorasPreparacion = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();
                    //p.HorasTiraje = reader["HorasTiraje"].ToString();
                    TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    int Dias2 = t2.Days * 24;
                    p.HorasTiraje = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                    //p.HorasImproductivas = reader["HorasImproductivas"].ToString();
                    TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    int Dias3 = t3.Days * 24;
                    p.HorasImproductivas = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();
                    //p.HorasSinTrabajo = reader["HorasSinTrabajo"].ToString();
                    //TimeSpan t4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinTrabajo"].ToString()));
                    //int Dias4 = t4.Days * 24;
                    //p.HorasSinTrabajo = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();
                    ////p.HorasSinPersonal = reader["HorasSinPersonal"].ToString();
                    //TimeSpan t5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinPersonal"].ToString()));
                    //int Dias5 = t5.Days * 24;
                    //p.HorasSinPersonal = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();
                    ////p.HorasMantencion = reader["HorasMantencion"].ToString();
                    //TimeSpan t6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasMantencion"].ToString()));
                    //int Dias6 = t6.Days * 24;
                    //p.HorasMantencion = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();
                    //p.Planchas = Convert.ToInt32(reader["Planchas"].ToString()).ToString("N0").Replace(",", ".");
                    //p.Preparaciones = Convert.ToInt32(reader["Entradas"].ToString()).ToString("N0").Replace(",", ".");

                    TimeSpan t7 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()) + Convert.ToDouble(reader["HorasTiraje"].ToString()) + Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    int Dias7 = t7.Days * 24;
                    p.HorasDirectas = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                    //TimeSpan t8 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasDisponibles"].ToString())+1);
                    //int Dias8 = t8.Days * 24;
                    //p.HorasDisponibles = (t8.Hours + Dias8).ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Minutes.ToString().Length) + t8.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Seconds.ToString().Length) + t8.Seconds.ToString();
                    //p.Escarpe = reader["Escarpe"].ToString();
                    //p.Cono = reader["PesoCono"].ToString();
                    //p.ConsumoPapel = reader["Consumo"].ToString();
      
                    p.Giros = Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".");

                    if (reader["CodRecurso"].ToString().ToLower() == "mr408")
                    {
                        p.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");

                        p.MermaArranque = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                        p.MermaTiraje = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    }
                    else if (reader["CodRecurso"].ToString().ToLower() == "c150")
                    {
                        p.Buenos = (Convert.ToInt32(reader["Giros"].ToString()) * 2).ToString("N0").Replace(",", ".");
                        p.MermaArranque = (Convert.ToInt32(reader["GirosMalosPreparacion"].ToString()) * 2).ToString("N0").Replace(",", ".");
                        p.MermaTiraje = (Convert.ToInt32(reader["GirosMalosTiraje"].ToString()) * 2).ToString("N0").Replace(",", ".");
                    }
                    else
                    {
                        p.Buenos = Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".");
                        p.MermaArranque = Convert.ToInt32(reader["GirosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                        p.MermaTiraje = Convert.ToInt32(reader["GirosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
                    }



                    if (reader["HorasTiraje"].ToString() == "0")
                    {
                        p.VPromedio = "0/Hr";
                    }
                    else
                    {
                        double valor = Convert.ToDouble(Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600);
                        p.VPromedio = Convert.ToInt32(((Convert.ToDouble(reader["Giros"].ToString())) / valor)).ToString("N0").Replace(",", ".") + "/Hr";
                    }

                    double horasimp = Convert.ToDouble(reader["HorasImproductivas"].ToString()) / 3600;
                    double horastir = Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600;

                    double result = ((horastir / (horastir + horasimp)) * 100);

                    p.Uptime = result.ToString("0.00").Replace("NaN", "0") + "%";

                    p.Colores = CargaPlanchas(reader["numordem"].ToString(), reader["processo"].ToString(), "", DateTime.Now, DateTime.Now, -1);

                    p.CodRecurso = reader["CodRecurso"].ToString();
                   
                    try
                    {
                        if (p.Colores == "")
                        {
                            p.Planchas = "";
                        }
                        else
                        {
                            string[] str = p.Colores.Split('x');
                            p.Planchas = (Convert.ToInt32(str[0]) + Convert.ToInt32(str[1])).ToString();
                        }
                    }
                    catch
                    {
                        p.Planchas = "";
                    }
                    lista.Add(p);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
        public string CargaPlanchas(string ot,string Pliego,string Maquina,DateTime FechaInicio,DateTime FechaTermino,int Procedimiento)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "Produccion_InformeScoreCard";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Pliego", Pliego);
                cmd.Parameters.AddWithValue("@Area", "");
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["Colores"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;
        }
    }
}