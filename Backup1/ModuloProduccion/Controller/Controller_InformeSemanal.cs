using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloProduccion.Controller
{
    public class Controller_InformeSemanal
    {
        public List<InformeSemanal> ListaInformeMaquina( string Area, string Maquina, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeSemanal> lista = new List<InformeSemanal>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string ceros = "00";
            int Entr = 0;
            double HorasPrep = 0;
            double promPrep = 0;
            double HorasTir = 0;
            double horasImp = 0;
            int Bons = 0;
            double produ = 0;
            int Velocidad = 0;
            int count = 0;
            if (cmd != null)
            {
                cmd.CommandText = "Produccion_InformePorSemana";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeSemanal p = new InformeSemanal();
                    p.Semana = reader["Semana"].ToString();
                    p.Maquina = reader["Maquina"].ToString();
                    int Buenos = Convert.ToInt32(reader["Buenos"].ToString());
                    Bons += Buenos;
                    p.Buenos = Buenos.ToString("N0").Replace(",", ".");
                    p.Entradas = reader["Entradas"].ToString();
                    Entr += Convert.ToInt32(reader["Entradas"].ToString());
                    TimeSpan t0 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                    int Dias0 = t0.Days * 24;
                    p.HorasTiraje = (t0.Hours + Dias0).ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Minutes.ToString().Length) + t0.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Seconds.ToString().Length) + t0.Seconds.ToString();
                    HorasTir += Convert.ToDouble(reader["HorasTiraje"].ToString());

                    TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                    int Dias1 = t1.Days * 24;
                    p.HorasPreparacion = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();
                    HorasPrep += Convert.ToDouble(reader["HorasPreparacion"].ToString());

                    TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                    int Dias2 = t2.Days * 24;
                    p.HorasImproductivas = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                    horasImp += Convert.ToDouble(reader["HorasImproductivas"].ToString());

                    TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["PromedioPreparacion"].ToString()));
                    int Dias3 = t3.Days * 24;
                    p.PromedioPreparacion = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();
                    promPrep += Convert.ToDouble(reader["PromedioPreparacion"].ToString());

                    double Buenos2 = Convert.ToDouble(reader["Buenos"].ToString());
                    double TotalBuenos2 = Convert.ToDouble(reader["TotalBuenos"].ToString());
                    p.Productividad = ((Buenos2 / TotalBuenos2) * 100).ToString("N1") + "%";

                    produ += ((Buenos2 / TotalBuenos2) * 100);

                    int HorasProduccion = (Convert.ToInt32(reader["HorasTiraje"].ToString()) / 3600);
                    if (HorasProduccion > 0)
                    {
                        p.Velocidad = (Buenos / HorasProduccion).ToString("N0").Replace(",", ".");
                        Velocidad += (Buenos / HorasProduccion);
                    }
                    else
                    {
                        p.Velocidad = "0";
                    }
                    
                    count++;
                    lista.Add(p);
                }
                if (reader.Read() == false)
                {
                    InformeSemanal p = new InformeSemanal();
                    p.Semana = "";
                    p.Maquina = "<b>TOTALES:</b>";
                    p.Buenos = "<b>" + Bons.ToString("N0").Replace(",", ".") + "</b>";
                    p.Entradas = "<b>" + Entr.ToString() + "</b>";
                    TimeSpan t0 = TimeSpan.FromSeconds(HorasTir);
                    int Dias0 = t0.Days * 24;
                    p.HorasTiraje = "<b>" + (t0.Hours + Dias0).ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Minutes.ToString().Length) + t0.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t0.Seconds.ToString().Length) + t0.Seconds.ToString() + "</b>";

                    TimeSpan t1 = TimeSpan.FromSeconds(HorasPrep);
                    int Dias1 = t1.Days * 24;
                    p.HorasPreparacion = "<b>" + (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString() + "</b>";

                    TimeSpan t2 = TimeSpan.FromSeconds(horasImp);
                    int Dias2 = t2.Days * 24;
                    p.HorasImproductivas = "<b>" + (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString() + "</b>";

                    TimeSpan t3 = TimeSpan.FromSeconds(promPrep/count);
                    int Dias3 = t3.Days * 24;
                    p.PromedioPreparacion = "<b>" + (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString() + "</b>";

                    p.Productividad = "<b>" + produ.ToString() + "%</b>";
                    p.Velocidad = "<b>" + (((Convert.ToDouble(Bons)) / (HorasTir / 3600))).ToString("N0").Replace(",", ".") + "</b>";
                    lista.Add(p);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
        public List<InformeSemanal> ListaInformeMaquinaPorTurno(string Area, string Maquina, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeSemanal> lista = new List<InformeSemanal>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string ceros = "00";
            int Tnoche = 0;
            int TMañana = 0;
            int TTarde = 0;
            double Total = 0;
            if (cmd != null)
            {
                cmd.CommandText = "Produccion_InformePorSemana";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeSemanal p = new InformeSemanal();
                    p.Semana = reader["Semana"].ToString();
                    p.Maquina = reader["Maquina"].ToString();
                    int Noc = Convert.ToInt32(reader["Noche"].ToString());
                    Tnoche += Noc;
                    int Man = Convert.ToInt32(reader["Mañana"].ToString());
                    TMañana += Man;
                    int Tar = Convert.ToInt32(reader["Tarde"].ToString());
                    TTarde += Tar;
                    double TotalTurnos = Convert.ToDouble(reader["TotalTurnos"].ToString());
                    p.Noche = Noc.ToString("N0").Replace(",", ".");
                    p.Mañana = Man.ToString("N0").Replace(",", ".");
                    p.Tarde = Tar.ToString("N0").Replace(",", ".");
                    p.PorcNoche = ((Convert.ToDouble(Noc) / TotalTurnos) * 100).ToString("N2") + "%";
                    p.PorcMañana = ((Convert.ToDouble(Man) / TotalTurnos) * 100).ToString("N2") + "%";
                    p.PorcTarde = ((Convert.ToDouble(Tar) / TotalTurnos) * 100).ToString("N2") + "%";
                    p.Generales = Convert.ToInt32(reader["TotalTurnos"].ToString()).ToString("N0").Replace(",", ".");
                    Total = Convert.ToDouble(reader["TotalBuenos"].ToString());
                    lista.Add(p);
                }
                if (reader.Read() == false)
                {
                    InformeSemanal p = new InformeSemanal();
                    p.Semana = "";
                    p.Maquina = "<b>TOTALES:</b>";
                    p.Noche = "<b>" + Tnoche.ToString("N0").Replace(",", ".") + "</b>";
                    p.Mañana = "<b>" + TMañana.ToString("N0").Replace(",", ".") + "</b>";
                    p.Tarde = "<b>" + TTarde.ToString("N0").Replace(",", ".") + "</b>";
                    p.PorcNoche = "<b>" + ((Convert.ToDouble(Tnoche)/Total)*100).ToString("N2") + "%</b>";
                    p.PorcMañana = "<b>" + ((Convert.ToDouble(TMañana) / Total) * 100).ToString("N2") + "%</b>";
                    p.PorcTarde= "<b>" + ((Convert.ToDouble(TTarde) / Total)*100).ToString("N2") + "%</b>";
                    p.Generales = "<b>" + Convert.ToInt32(Total).ToString("N0").Replace(",", ".") + "</b>";
                    lista.Add(p);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }

        public List<InformeSemanal> ListaInformeDiarioEncuadernacion(string Area, string Maquina, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeSemanal> lista = new List<InformeSemanal>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Produccion_InformePorSemana";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeSemanal p = new InformeSemanal();
                    p.Dia = Convert.ToDateTime(reader["Dia"].ToString()).ToString("dd/MM/yyyy");
                    p.Maquina = reader["CodRecurso"].ToString();
                    p.Noche = Convert.ToInt32(reader["TurnoNoche"].ToString()).ToString("N0").Replace(",", ".");
                    double noche = Convert.ToDouble(reader["TurnoNoche"].ToString());
                    double total = Convert.ToDouble(reader["TotalDia"].ToString());
                    if (noche >0)
                    {
                        p.PorcNoche = "<b>" + Convert.ToDouble((noche / total) * 100).ToString("N2") + " %" + "</b>"; 
                    }
                    else
                    {
                        p.PorcNoche = "<b>0,00 %</b>";
                    }
                    double mañana = Convert.ToDouble(reader["TurnoDia"].ToString());
                    p.Mañana = Convert.ToInt32(reader["TurnoDia"].ToString()).ToString("N0").Replace(",", ".");
                    if (mañana > 0)
                    {
                        p.PorcMañana = "<b>" + Convert.ToDouble((mañana / total) * 100).ToString("N2") + " %" + "</b>"; 
                    }
                    else
                    {
                        p.PorcMañana = "<b>0,00 %</b>";
                    }

                    double tarde = Convert.ToDouble(reader["TurnoTarde"].ToString());
                    p.Tarde = Convert.ToInt32(reader["TurnoTarde"].ToString()).ToString("N0").Replace(",", ".");
                    if (tarde > 0)
                    {
                        p.PorcTarde = "<b>" + Convert.ToDouble((tarde / total) * 100).ToString("N2") + " %" + "</b>";
                    }
                    else
                    {
                        p.PorcTarde = "<b>0,00 %</b>";
                    }
                    p.TotalProducido = "<b>" + Convert.ToInt32(reader["TotalDia"].ToString()).ToString("N0").Replace(",", ".") + "</b>";
                    //p.Corona = Convert.ToInt32(reader["Corona"].ToString()).ToString("N0").Replace(",", ".");
                    //p.Nordbinder = Convert.ToInt32(reader["Nordbinder"].ToString()).ToString("N0").Replace(",", ".");
                    //p.Muller1 = Convert.ToInt32(reader["Muller1"].ToString()).ToString("N0").Replace(",", ".");
                    //p.Muller2 = Convert.ToInt32(reader["Muller2"].ToString()).ToString("N0").Replace(",", ".");
                    //p.MullerPrima = Convert.ToInt32(reader["MullerPrima"].ToString()).ToString("N0").Replace(",", ".");
                    //p.TotalProducido = Convert.ToInt32(reader["TotalDia"].ToString()).ToString("N0").Replace(",", ".");

                    //p.PorcCorona = (((Convert.ToDouble(reader["Corona"].ToString())) / Convert.ToDouble(reader["TotalCorona"].ToString())) * 100).ToString("N2").Replace("NaN", "0,00") + "%";
                    //p.PorcNordbinder = (((Convert.ToDouble(reader["Nordbinder"].ToString())) / Convert.ToDouble(reader["TotalNordbinder"].ToString())) * 100).ToString("N2").Replace("NaN", "0,00") + "%";
                    //p.PorcMuller1 = (((Convert.ToDouble(reader["Muller1"].ToString())) / Convert.ToDouble(reader["TotalMuller1"].ToString())) * 100).ToString("N2").Replace("NaN", "0,00") + "%";
                    //p.PorcMuller2 = (((Convert.ToDouble(reader["Muller2"].ToString())) / Convert.ToDouble(reader["TotalMuller2"].ToString())) * 100).ToString("N2").Replace("NaN", "0,00") + "%";
                    //p.PorcMullerPrima = (((Convert.ToDouble(reader["MullerPrima"].ToString())) / Convert.ToDouble(reader["TotalMullerPrima"].ToString())) * 100).ToString("N2").Replace("NaN", "0,00") + "%";

                    //p.PorcTotalProducido = (((Convert.ToDouble(reader["TotalDia"].ToString())) / Convert.ToDouble(reader["TotalDiaCompleto"].ToString())) * 100).ToString("N2").Replace("NaN", "0,00") + "%";

                    //TCorona = Convert.ToDouble(reader["TotalCorona"].ToString());
                    //TNordbinder = Convert.ToDouble(reader["TotalNordbinder"].ToString());
                    //TMuller1 = Convert.ToDouble(reader["TotalMuller1"].ToString());
                    //TMuller2 = Convert.ToDouble(reader["TotalMuller2"].ToString());
                    //TPrima = Convert.ToDouble(reader["TotalMullerPrima"].ToString());
                    //TProducido = Convert.ToDouble(reader["TotalDiaCompleto"].ToString());
                    lista.Add(p);
                }
                //if (reader.Read() == false)
                //{
                //    InformeSemanal p = new InformeSemanal();
                //    p.Dia = "<b>TOTALES:</b>";
                //    p.Corona = "<b>" + Convert.ToInt32(TCorona).ToString("N0").Replace(",", ".") + "</b>";
                //    p.Nordbinder = "<b>" + Convert.ToInt32(TNordbinder).ToString("N0").Replace(",", ".") + "</b>";
                //    p.Muller1 = "<b>" + Convert.ToInt32(TMuller1).ToString("N0").Replace(",", ".") + "</b>";
                //    p.Muller2 = "<b>" + Convert.ToInt32(TMuller2).ToString("N0").Replace(",", ".") + "</b>";
                //    p.MullerPrima = "<b>" + Convert.ToInt32(TPrima).ToString("N0").Replace(",", ".") + "</b>";
                //    p.TotalProducido = "<b>" + Convert.ToInt32(TProducido).ToString("N0").Replace(",", ".") + "</b>";

                //    if (Convert.ToInt32(TCorona) == 0)
                //    {
                //        p.PorcCorona = "<b>0,00%</b>";
                //    }
                //    else
                //    {
                //        p.PorcCorona = "<b>100%</b>";
                //    }
                //    if (Convert.ToInt32(TNordbinder) == 0)
                //    {
                //        p.PorcNordbinder = "<b>0,00%</b>";
                //    }
                //    else
                //    {
                //        p.PorcNordbinder = "<b>100%</b>";
                //    }
                //    if (Convert.ToInt32(TMuller1) == 0)
                //    {
                //        p.PorcMuller1 = "<b>0,00%</b>";
                //    }
                //    else
                //    {
                //        p.PorcMuller1 = "<b>100%</b>";
                //    }
                //    if (Convert.ToInt32(TMuller2) == 0)
                //    {
                //        p.PorcMuller2 = "<b>0,00%</b>";
                //    }
                //    else
                //    {
                //        p.PorcMuller2 = "<b>100%</b>";
                //    }
                //    if (Convert.ToInt32(TPrima) == 0)
                //    {
                //        p.PorcMullerPrima = "<b>0,00%</b>";
                //    }
                //    else
                //    {
                //        p.PorcMullerPrima = "<b>100%</b>";
                //    }
                //    if (Convert.ToInt32(TProducido) == 0)
                //    {
                //        p.PorcTotalProducido = "<b>0,00%</b>";
                //    }
                //    else
                //    {
                //        p.PorcTotalProducido = "<b>100%</b>";
                //    }
                //    lista.Add(p);
                //}

            }
            conexion.CerrarConexion();

            return lista;
        }

        public List<InformeSemanal> ListaInformeMaquinaAcumuladoMes(string Area, string Maquina, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeSemanal> lista = new List<InformeSemanal>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            double TMes= 0;
            if (cmd != null)
            {
                cmd.CommandText = "Produccion_InformePorSemana";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeSemanal p = new InformeSemanal();
                    p.Maquina = reader["Maquina"].ToString();
                    p.TotalProducido = Convert.ToInt32(reader["TotalMaquina"].ToString()).ToString("N0").Replace(",", ".");
                    TMes= Convert.ToDouble(reader["TotalMes"].ToString());
                    double porc=(Convert.ToDouble(reader["TotalMaquina"].ToString()));
                    p.PorcTotalProducido = ((porc / TMes)*100).ToString("N2") + "%";
                    lista.Add(p);
                }
                if (reader.Read() == false)
                {
                    InformeSemanal p = new InformeSemanal();
                    p.Maquina = "<b>TOTALES:</b>";
                    p.TotalProducido = "<b>" + Convert.ToInt32(TMes).ToString("N0").Replace(",", ".") + "</b>";
                    p.PorcTotalProducido = "<b>100%</b>";

                    lista.Add(p);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
    }
}