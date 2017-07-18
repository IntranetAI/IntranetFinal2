using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Intranet.ModuloProduccion.Controller
{
    public class InformeProduccion_Controller
    {
        public List<InformeProduccionM> Produccion_InformeProduccion(string OT, string NombreOT, string Area, string Maquina, string Operador, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_InformeProduccion]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Operador", Operador);
                cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 3000000;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeProduccionM pro = new InformeProduccionM();
                    pro.OT = reader["NumOrdem"].ToString();
                    pro.NombreOT = reader["Descricao"].ToString().ToLower();
                    string pli = Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty);
                    int horasprep = Convert.ToInt32(reader["HorasPreparacion"].ToString());
                    int hor = (horasprep / 3600);
                    string hor2 = "";
                    int min = ((horasprep - hor * 3600) / 60);
                    string min2 = "";
                    if (hor.ToString().Length == 1)
                    {
                        hor2 = "0" + hor;
                    }
                    else
                    {
                        hor2 = hor.ToString();
                    }
                    if (min.ToString().Length == 1)
                    {
                        min2 = "0" + min;
                    }
                    else
                    {
                        min2 = min.ToString();
                    }
                    string horaspp = hor2 + ":" + min2 + ":00";
                    pro.Tipo = horaspp;
                    pro.Pliego = pli.ToString();
                    pro.Planificado = Convert.ToInt32(reader["QtdPlanejado"].ToString()).ToString("N0").Replace(",", ".");
                    pro.Producido = Convert.ToInt32(reader["bons"].ToString()).ToString("N0").Replace(",", ".");
                    pro.FechaInicio = Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.FechaTermino = Convert.ToDateTime(reader["HoraFin"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.Maquina = reader["Maquina"].ToString().ToLower();
                    if (reader["Maquina"].ToString().ToLower() == "kba" || reader["Maquina"].ToString().ToLower() == "m2016")
                    {
                        pro.VerMas = "";
                    }
                    else
                    {
                        pro.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openDetalle(\"" + reader["NumOrdem"].ToString() + "\",\"" + reader["Processo"].ToString() + "\",\"" + reader["Descricao"].ToString() + "\",\"" + pro.Pliego + "\")'>Ver Más</a>";
                    }
                   
                    
                    double buenos = Convert.ToDouble(reader["bons"].ToString());
                    double dvirando = Convert.ToDouble(reader["DVirando"].ToString());
                    string a = reader["DAcerto"].ToString();
                    string b = reader["DVirando"].ToString();
                    pro.DAcerto = Convert.ToInt32(reader["DAcerto"].ToString()).ToString("N0").Replace(",", ".");// % preparacion
                    if (buenos <= 0)
                    {
                        pro.DVirando = "0,00%";
                    }
                    else
                    {
                        pro.DVirando = Convert.ToDouble((dvirando / buenos) * 100).ToString("0.00") + "%";
                    }
                    if (reader["HorasTiraje2"].ToString() == "0")
                    {
                        pro.Clasificacion = "0/Hr";
                    }
                    else
                    {
                        double valor = Convert.ToDouble(Convert.ToDouble(reader["HorasTiraje2"].ToString()) / 3600);
                        pro.Clasificacion = Convert.ToInt32(((Convert.ToDouble(reader["bons"].ToString())) / valor)).ToString("N0").Replace(",", ".") + "/Hr";
                    }
                    //if (Procedimiento == 0 || Procedimiento == 4 || Procedimiento == 5 || Procedimiento == 6)
                    //{
                    //    pro.Operador = "";
                    //}
                    //else
                    //{
                    pro.Operador = reader["Operador"].ToString().ToLower();
                    

                    double horasimp = Convert.ToDouble(reader["HorasImproductivas"].ToString())/3600;
                    double horastir = Convert.ToDouble(reader["HorasTiraje2"].ToString()) / 3600;

                    double result = ((horastir / (horastir + horasimp)) * 100);

                    pro.Observacion = result.ToString("0.00").Replace("NaN", "0") + "%";

                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
        public List<InformeProduccionM> InformeProduccion_General(string OT,string NombreOT,string Area,string Maquina,string Operador, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Programa_Produccion_General]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Operador", Operador);
                cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 3000000;
                    
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeProduccionM pro = new InformeProduccionM();
                    pro.OT = reader["NumOrdem"].ToString();
                    pro.NombreOT = reader["Descricao"].ToString().ToLower();
                    string pli = Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty);
                    pro.Pliego = pli.ToString();
                    pro.Planificado = Convert.ToInt32(reader["QtdPlanejado"].ToString()).ToString("N0").Replace(",", ".");
                    pro.Producido = Convert.ToInt32(reader["bons"].ToString()).ToString("N0").Replace(",", ".");
                    pro.FechaInicio = Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.FechaTermino = Convert.ToDateTime(reader["HoraFin"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.Maquina = reader["Maquina"].ToString();
                    pro.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openDetalle(\"" + reader["NumOrdem"].ToString() + "\",\"" + reader["Processo"].ToString() + "\",\"" + reader["Descricao"].ToString() + "\",\"" + pro.Pliego + "\")'>Ver Más</a>";
                    //agregado %mermas mas velocidad promedio
                    if (Procedimiento == 5 || Procedimiento == 4 || Procedimiento == 6 || Procedimiento == 0)
                    {
                        string a = reader["MermaPreparacion"].ToString();
                        string b = reader["MermaTiraje"].ToString();
                        pro.DAcerto = Convert.ToInt32(reader["MermaPreparacion"].ToString()).ToString("N0").Replace(",", ".");// % preparacion
                        pro.DVirando = Convert.ToDouble(reader["MermaTiraje"].ToString()).ToString("0.00") + "%";

                        if (reader["HorasTiraje"].ToString() == "0")
                        {
                            pro.Clasificacion = "0/Hr";
                        }
                        else
                        {
                            double valor = Convert.ToDouble(Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600);
                            pro.Clasificacion = Convert.ToInt32(((Convert.ToDouble(reader["bons"].ToString())) / valor)).ToString("N0").Replace(",", ".") + "/Hr";
                        }
                    }
                    else
                    {
                        pro.DAcerto = "0";
                        pro.DVirando = "0";
                        pro.Clasificacion = "0";
                    }
                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
        public List<InformeProduccionM> ListaOperador(string Maquina, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Programa_Produccion_General]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", "");
                cmd.Parameters.AddWithValue("@NombreOT", "");
                cmd.Parameters.AddWithValue("@Area", "");
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Operador", "");
                cmd.Parameters.AddWithValue("@FechaInicio", "1900-01-01");
                cmd.Parameters.AddWithValue("@FechaTermino", "1900-01-01");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        InformeProduccionM pro = new InformeProduccionM();
                        pro.Operador = reader["Operador"].ToString();
                        pro.CodMaquina = reader["CodOperador"].ToString();
                        lista.Add(pro);
                    }
                }
                catch
                {
                }

            }
            conexion.CerrarConexion();
                
            return lista;
        }
        public List<InformeProduccionM> ListaMaquina(string Maquina, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Programa_Produccion_General]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", "");
                cmd.Parameters.AddWithValue("@NombreOT", "");
                cmd.Parameters.AddWithValue("@Area", "");
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Operador", "");
                cmd.Parameters.AddWithValue("@FechaInicio", "1900-01-01");
                cmd.Parameters.AddWithValue("@FechaTermino", "1900-01-01");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeProduccionM pro = new InformeProduccionM();
                    if (reader["codRecurso"].ToString() == "")
                    {
                        pro.Maquina = "Otros";
                        pro.CodMaquina = "Otros";
                    }
                    else
                    {
                        pro.Maquina = reader["Maquina"].ToString();
                        pro.CodMaquina = reader["CodRecurso"].ToString();
                    }
                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }

        public List<InformeProduccionM> DetalleInformeProduccion_Pliego(string OT,string Pliego, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();
            int buenos = 0;
            int planificado = 0;
            int malospreparacion = 0;
            int malosTiraje = 0;
            int HorasPreparacion = 0;
            int MinutosPreparacion = 0;
            int HorasTiraje = 0;
            int MinutosTiraje = 0;

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Programa_Produccion_General]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", Pliego);
                cmd.Parameters.AddWithValue("@Area", "");
                cmd.Parameters.AddWithValue("@Maquina", "");
                cmd.Parameters.AddWithValue("@Operador", "");
                cmd.Parameters.AddWithValue("@FechaInicio", "1900-01-01");
                cmd.Parameters.AddWithValue("@FechaTermino", "1900-01-01");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeProduccionM pro = new InformeProduccionM();
                    pro.Maquina = reader["Maquina"].ToString();
                    string pli = Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty);
                    pro.Pliego = pli.ToString();
                    pro.Proceso = reader["Proceso"].ToString().ToLower();
                    pro.Observacion = reader["obs"].ToString().ToLower();
                    pro.Producido = Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".");
                    pro.DesperdicioAcerto = reader["DesperdicioAcerto"].ToString();
                    pro.DesperdicioVirando = reader["DesperdicioVirando"].ToString();
                    pro.DAcerto = Convert.ToInt32(reader["DAcerto"].ToString()).ToString("N0").Replace(",", ".");
                    pro.DVirando = Convert.ToInt32(reader["DVirando"].ToString()).ToString("N0").Replace(",", ".");
                    pro.Operador = reader["Operador"].ToString();
                    pro.FechaInicio = Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.FechaTermino = Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    TimeSpan time;
                    time = (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString()));
                    pro.Horas = time.ToString();
                    

                    if (reader["Tipo"].ToString() == "P")
                    {

                        HorasTiraje = HorasTiraje + time.Hours;

                        MinutosTiraje = MinutosTiraje + time.Minutes;
                        if (MinutosTiraje > 59)
                        {
                            MinutosTiraje = MinutosTiraje - 60;
                            HorasTiraje = HorasTiraje + 1;
                        }



                    }
                    if (reader["Tipo"].ToString() == "S")
                    {

                        HorasPreparacion = HorasPreparacion + time.Hours;
                        MinutosPreparacion = MinutosPreparacion + time.Minutes;
                        if (MinutosPreparacion > 59)
                        {
                            MinutosPreparacion = MinutosPreparacion - 60;
                            HorasPreparacion = HorasPreparacion + 1;
                        }

                    }


                    buenos = Convert.ToInt32(reader["Buenos"].ToString());
                    planificado = Convert.ToInt32(reader["QtdPlanejado"].ToString());
                    malospreparacion = Convert.ToInt32(reader["DAcerto"].ToString());
                    malosTiraje = Convert.ToInt32(reader["DVirando"].ToString());
                    lista.Add(pro);
                }
                if (reader.Read() == false)
                {
                    InformeProduccionM pro2 = new InformeProduccionM();
                    pro2.Maquina = "";
                    pro2.Pliego = "";
                    pro2.Proceso = "";
                    pro2.Observacion = "";
                    pro2.Producido = "";
                    pro2.DesperdicioAcerto = "";
                    pro2.DesperdicioVirando = "";
                    pro2.DAcerto = "";
                    pro2.DVirando = "";
                    pro2.Operador = "";
                    pro2.FechaInicio = "";
                    pro2.FechaTermino = "<b>Planificado:</b>";
                    pro2.Horas = planificado.ToString("N0").Replace(",", ".");
                    lista.Add(pro2);
                    InformeProduccionM pro = new InformeProduccionM();
                    pro.Maquina = "";
                    pro.Pliego = "";
                    pro.Proceso = "";
                    pro.Observacion = "";
                    pro.Producido = "";
                    pro.DesperdicioAcerto = "";
                    pro.DesperdicioVirando = "";
                    pro.DAcerto = "";
                    pro.DVirando = "";
                    pro.Operador = "";
                    pro.FechaInicio = "";
                    pro.FechaTermino = "<b>Buenos:</b>";
                    pro.Horas = buenos.ToString("N0").Replace(",", ".");
                    lista.Add(pro);
                    InformeProduccionM pro3 = new InformeProduccionM();
                    pro3.Maquina = "";
                    pro3.Pliego = "";
                    pro3.Proceso = "";
                    pro3.Observacion = "";
                    pro3.Producido = "";
                    pro3.DesperdicioAcerto = "";
                    pro3.DesperdicioVirando = "";
                    pro3.DAcerto = "";
                    pro3.DVirando = "";
                    pro3.Operador = "";
                    pro3.FechaInicio = "";
                    pro3.FechaTermino = "<b>Malos Prep.:</b>";
                    pro3.Horas = malospreparacion.ToString("N0").Replace(",", ".");
                    lista.Add(pro3);
                    InformeProduccionM pro4 = new InformeProduccionM();
                    pro4.Maquina = "";
                    pro4.Pliego = "";
                    pro4.Proceso = "";
                    pro4.Observacion = "";
                    pro4.Producido = "";
                    pro4.DesperdicioAcerto = "";
                    pro4.DesperdicioVirando = "";
                    pro4.DAcerto = "";
                    pro4.DVirando = "";
                    pro4.Operador = "";
                    pro4.FechaInicio = "";
                    pro4.FechaTermino = "<b>Malos Tiraje:</b>";
                    pro4.Horas = malosTiraje.ToString("N0").Replace(",", ".");
                    lista.Add(pro4);
                    InformeProduccionM pro5 = new InformeProduccionM();
                    pro5.Maquina = "";
                    pro5.Pliego = "";
                    pro5.Proceso = "";
                    pro5.Observacion = "";
                    pro5.Producido = "";
                    pro5.DesperdicioAcerto = "";
                    pro5.DesperdicioVirando = "";
                    pro5.DAcerto = "";
                    pro5.DVirando = "";
                    pro5.Operador = "";
                    pro5.FechaInicio = "";
                    pro5.FechaTermino = "<b>Horas Tiraje:</b>";
                    string horasT = "";
                    string minutosT = "";
                    if (HorasTiraje.ToString().Length == 1)
                    {
                        horasT = "0" + HorasTiraje;
                    }
                    else
                    {
                        horasT = HorasTiraje.ToString();
                    }

                    if (MinutosTiraje.ToString().Length == 1)
                    {
                        minutosT = "0" + MinutosTiraje;
                    }
                    else
                    {
                        minutosT = MinutosTiraje.ToString();
                    }
                    pro5.Horas = horasT + ":" + minutosT + ":00";
                    lista.Add(pro5);
                    InformeProduccionM pro6 = new InformeProduccionM();
                    pro6.Maquina = "";
                    pro6.Pliego = "";
                    pro6.Proceso = "";
                    pro6.Observacion = "";
                    pro6.Producido = "";
                    pro6.DesperdicioAcerto = "";
                    pro6.DesperdicioVirando = "";
                    pro6.DAcerto = "";
                    pro6.DVirando = "";
                    pro6.Operador = "";
                    pro6.FechaInicio = "";
                    pro6.FechaTermino = "<b>Horas Prep.:</b>";
                    string horas = "";
                    string minutos = "";
                    if (HorasPreparacion.ToString().Length == 1)
                    {
                        horas = "0" + HorasPreparacion;
                    }
                    else
                    {
                        horas = HorasPreparacion.ToString();
                    }

                    if (MinutosPreparacion.ToString().Length == 1)
                    {
                        minutos = "0" + MinutosPreparacion;
                    }
                    else
                    {
                        minutos = MinutosPreparacion.ToString();
                    }
                    pro6.Horas = horas + ":" + minutos + ":00";
                    lista.Add(pro6);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }

        public List<InformeProduccionM> AnalisisProduccion(string OTs,string NombreOT, string Maquinas, string FechaInicio, string FechaTermino, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if(cmd!=null)
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
                        InformeProduccionM i = new InformeProduccionM();
                        i.Maquina = reader["Maquina"].ToString();
                        i.OT = reader["NumOrdem"].ToString();
                        i.NombreOT = reader["NM"].ToString();
                        i.Proceso = reader["Entradas"].ToString();
                       
                        TimeSpan t1= TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                        int Dias1 = t1.Days * 24;
                        i.Planificado = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                        TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                        int Dias2 = t2.Days * 24;
                        i.Producido = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                        TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                        int Dias3 = t3.Days * 24;
                        i.DesperdicioVirando = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                        i.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                        i.VerMas = i.Buenos;
                        i.DVirando = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                        i.DAcerto = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
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
        public List<InformeProduccionM> AnalisisProduccion_Lithoman(string OTs, string NombreOT, string Maquinas, string FechaInicio, string FechaTermino, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Produccion_AnalisisProduccion_Lithoman";
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
                        InformeProduccionM i = new InformeProduccionM();
                        i.Maquina = reader["Maquina"].ToString();
                        i.OT = reader["NumOrdem"].ToString();
                        i.NombreOT = reader["NM"].ToString();
                        i.Proceso = reader["Entradas"].ToString();

                        TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPreparacion"].ToString()));
                        int Dias1 = t1.Days * 24;
                        i.Planificado = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                        TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                        int Dias2 = t2.Days * 24;
                        i.Producido = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                        TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                        int Dias3 = t3.Days * 24;
                        i.DesperdicioVirando = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();
                        i.Buenos = Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".");
                        i.VerMas = Convert.ToInt32(reader["Giros"].ToString()).ToString("N0").Replace(",", ".");
                        i.DVirando = Convert.ToInt32(reader["PliegosMalosPreparacion"].ToString()).ToString("N0").Replace(",", ".");
                        i.DAcerto = Convert.ToInt32(reader["PliegosMalosTiraje"].ToString()).ToString("N0").Replace(",", ".");
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
        public string DetalleInformeProduccion_OT(string OT,  int Procedimiento)
        {
            string Tabla = "";
            int intEnc = 0;
            int HorasPreparacion = 0;
            int MinutosPreparacion = 0;
            int HorasTiraje = 0;
            int MinutosTiraje = 0;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string PliegoActual = "";
            string PliegoAnterior = "";
            #region Encabezado
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1110px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Máquina</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>Pliego</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:210px;'>Proceso</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:210px;'>Observación</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:64px;'>Producido</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:63px;'>Malos Preparacion</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:63px;'>Malos Tiraje</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Operador</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Inicio</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Termino</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>Horas</td>" +
          "</tr>";
            #endregion


            if (cmd != null)
            {
                cmd.CommandText = "[Programa_Produccion_General]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", "");
                cmd.Parameters.AddWithValue("@Area", "");
                cmd.Parameters.AddWithValue("@Maquina", "");
                cmd.Parameters.AddWithValue("@Operador", "");
                cmd.Parameters.AddWithValue("@FechaInicio", "1900-01-01");
                cmd.Parameters.AddWithValue("@FechaTermino", "1900-01-01");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (PliegoActual == reader["Pliego"].ToString())
                    {
                        TimeSpan time;
                        time = (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString()));
                        if (reader["Tipo"].ToString() == "P")
                        {

                            HorasTiraje = HorasTiraje + time.Hours;

                            MinutosTiraje = MinutosTiraje + time.Minutes;
                            if (MinutosTiraje > 59)
                            {
                                MinutosTiraje = MinutosTiraje - 60;
                                HorasTiraje = HorasTiraje + 1;
                            }



                        }
                        if (reader["Tipo"].ToString() == "S")
                        {

                            HorasPreparacion = HorasPreparacion + time.Hours;
                            MinutosPreparacion = MinutosPreparacion + time.Minutes;
                            if (MinutosPreparacion > 59)
                            {
                                MinutosPreparacion = MinutosPreparacion - 60;
                                HorasPreparacion = HorasPreparacion + 1;
                            }

                        }
                        Tabla = Tabla + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                reader["Maquina"].ToString() + "</td>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
               Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["Proceso"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["obs"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:64px;'>" +
                Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                               "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioAcerto"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioVirando"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +

                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                reader["Operador"].ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString())).ToString() + "</td>" +
          "</tr>";
                        PliegoActual = reader["Pliego"].ToString();
                        PliegoAnterior = reader["Processo"].ToString();

                    }
                    else
                    {
                        if (intEnc == 0)
                        {
                            TimeSpan time;
                            time = (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString()));
                            if (reader["Tipo"].ToString() == "P")
                            {

                                HorasTiraje = HorasTiraje + time.Hours;

                                MinutosTiraje = MinutosTiraje + time.Minutes;
                                if (MinutosTiraje > 59)
                                {
                                    MinutosTiraje = MinutosTiraje - 60;
                                    HorasTiraje = HorasTiraje + 1;
                                }



                            }
                            if (reader["Tipo"].ToString() == "S")
                            {

                                HorasPreparacion = HorasPreparacion + time.Hours;
                                MinutosPreparacion = MinutosPreparacion + time.Minutes;
                                if (MinutosPreparacion > 59)
                                {
                                    MinutosPreparacion = MinutosPreparacion - 60;
                                    HorasPreparacion = HorasPreparacion + 1;
                                }

                            }

                            Tabla = Tabla + "</br><b>&nbsp;Pliego " + Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</b>" + Encabezado + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                reader["Maquina"].ToString() + "</td>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
               Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["Proceso"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["obs"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:64px;'>" +
                Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                               "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioAcerto"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioVirando"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +

                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                reader["Operador"].ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString())).ToString() + "</td>" +
          "</tr>";
                            PliegoActual = reader["Pliego"].ToString();
                            PliegoAnterior = reader["Processo"].ToString();
                            intEnc = intEnc + 1;
                        }
                        else
                        {
                            string horasT = "";
                            string minutosT = "";
                            if (HorasTiraje.ToString().Length == 1)
                            {
                                horasT = "0" + HorasTiraje;
                            }
                            else
                            {
                                horasT = HorasTiraje.ToString();
                            }

                            if (MinutosTiraje.ToString().Length == 1)
                            {
                                minutosT = "0" + MinutosTiraje;
                            }
                            else
                            {
                                minutosT = MinutosTiraje.ToString();
                            }
                            string horas = "";
                            string minutos = "";
                            if (HorasPreparacion.ToString().Length == 1)
                            {
                                horas = "0" + HorasPreparacion;
                            }
                            else
                            {
                                horas = HorasPreparacion.ToString();
                            }

                            if (MinutosPreparacion.ToString().Length == 1)
                            {
                                minutos = "0" + MinutosPreparacion;
                            }
                            else
                            {
                                minutos = MinutosPreparacion.ToString();
                            }
                            Tabla = Tabla + "</tbody></table>" +


                                DetalleInformeProduccion_DetalleAgrupacion(OT, PliegoAnterior, horasT + ":" + minutosT + ":00", horas + ":" + minutos + ":00", 9)

+
                                      "</br><b>&nbsp;Pliego " + Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</b>" + Encabezado + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                reader["Maquina"].ToString() + "</td>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
               Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["Proceso"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["obs"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:64px;'>" +
                Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioAcerto"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioVirando"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +

                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                reader["Operador"].ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString())).ToString() + "</td>" +
          "</tr>";

                            PliegoActual = reader["Pliego"].ToString();
                            PliegoAnterior = reader["Processo"].ToString();

                            HorasPreparacion = 0;
                            MinutosPreparacion = 0;
                            HorasTiraje = 0;
                            MinutosTiraje = 0;

                            TimeSpan time;
                            time = (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString()));
                            if (reader["Tipo"].ToString() == "P")
                            {

                                HorasTiraje = HorasTiraje + time.Hours;

                                MinutosTiraje = MinutosTiraje + time.Minutes;
                                if (MinutosTiraje > 59)
                                {
                                    MinutosTiraje = MinutosTiraje - 60;
                                    HorasTiraje = HorasTiraje + 1;
                                }



                            }
                            if (reader["Tipo"].ToString() == "S")
                            {

                                HorasPreparacion = HorasPreparacion + time.Hours;
                                MinutosPreparacion = MinutosPreparacion + time.Minutes;
                                if (MinutosPreparacion > 59)
                                {
                                    MinutosPreparacion = MinutosPreparacion - 60;
                                    HorasPreparacion = HorasPreparacion + 1;
                                }

                            }
                        }

                    }
                }
                string horasT2 = "";
                string minutosT2 = "";
                if (HorasTiraje.ToString().Length == 1)
                {
                    horasT2 = "0" + HorasTiraje;
                }
                else
                {
                    horasT2 = HorasTiraje.ToString();
                }

                if (MinutosTiraje.ToString().Length == 1)
                {
                    minutosT2 = "0" + MinutosTiraje;
                }
                else
                {
                    minutosT2 = MinutosTiraje.ToString();
                }
                string horas2 = "";
                string minutos2 = "";
                if (HorasPreparacion.ToString().Length == 1)
                {
                    horas2 = "0" + HorasPreparacion;
                }
                else
                {
                    horas2 = HorasPreparacion.ToString();
                }

                if (MinutosPreparacion.ToString().Length == 1)
                {
                    minutos2 = "0" + MinutosPreparacion;
                }
                else
                {
                    minutos2 = MinutosPreparacion.ToString();
                }

                Tabla = Tabla + "</tbody></table>" + DetalleInformeProduccion_DetalleAgrupacion(OT, PliegoAnterior, horasT2 + ":" + minutosT2 + ":00", horas2 + ":" + minutos2 + ":00", 9);
            }
            conexion.CerrarConexion();

            return Tabla; 
        }

        public string DetalleInformeProduccion_DetalleAgrupacion(string OT,string pliego,string HorasTiraje,string HorasPreparacion, int Procedimiento)
        {
            string Valor = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Programa_Produccion_General]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", pliego);
                cmd.Parameters.AddWithValue("@Area", "");
                cmd.Parameters.AddWithValue("@Maquina", "");
                cmd.Parameters.AddWithValue("@Operador", "");
                cmd.Parameters.AddWithValue("@FechaInicio", "1900-01-01");
                cmd.Parameters.AddWithValue("@FechaTermino", "1900-01-01");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Valor = "<div style='margin-left:620px;'><table id='tblRegistro2' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:490px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +

            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Planificado</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Buenos</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Malos Preparación</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Malos Tiraje</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Horas Tiraje</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:120px;'>Horas Preparación</td>" +
          "</tr>" +

          "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                Convert.ToInt32(reader["QtdPlanejado"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;;'>" +
                Convert.ToInt32(reader["Buenos"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                Convert.ToInt32(reader["DAcerto"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                Convert.ToInt32(reader["DVirando"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                HorasTiraje.ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                HorasPreparacion.ToString() + "</td>" +
          "</tr>" +
          "</tbody></table></div>";
                }



            }
            conexion.CerrarConexion();

            return Valor;
        }





                      
        public string DetalleInformeProduccion_PliegoTabla(string OT, string pliego,int Procedimiento)
        {
            string Tabla = "";  int intEnc = 0; int HorasPreparacion = 0; int MinutosPreparacion = 0;int HorasTiraje = 0;
            int MinutosTiraje = 0;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string PliegoActual = "";
            string PliegoAnterior = "";
            #region Encabezado
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1110px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Máquina</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>Pliego</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:210px;'>Proceso</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:210px;'>Observación</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:64px;'>Producido</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:63px;'>Malos Preparacion</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:63px;'>Malos Tiraje</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Operador</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Inicio</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Termino</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>Horas</td>" +
          "</tr>";
            #endregion


            if (cmd != null)
            {
                cmd.CommandText = "[Programa_Produccion_General]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", pliego);
                cmd.Parameters.AddWithValue("@Area", "");
                cmd.Parameters.AddWithValue("@Maquina", "");
                cmd.Parameters.AddWithValue("@Operador", "");
                cmd.Parameters.AddWithValue("@FechaInicio", "1900-01-01");
                cmd.Parameters.AddWithValue("@FechaTermino", "1900-01-01");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (PliegoActual == reader["Pliego"].ToString())
                    {
                        TimeSpan time;
                        time = (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString()));
                        if (reader["Tipo"].ToString() == "P")
                        {

                            HorasTiraje = HorasTiraje + time.Hours;

                            MinutosTiraje = MinutosTiraje + time.Minutes;
                            if (MinutosTiraje > 59)
                            {
                                MinutosTiraje = MinutosTiraje - 60;
                                HorasTiraje = HorasTiraje + 1;
                            }



                        }
                        if (reader["Tipo"].ToString() == "S")
                        {

                            HorasPreparacion = HorasPreparacion + time.Hours;
                            MinutosPreparacion = MinutosPreparacion + time.Minutes;
                            if (MinutosPreparacion > 59)
                            {
                                MinutosPreparacion = MinutosPreparacion - 60;
                                HorasPreparacion = HorasPreparacion + 1;
                            }

                        }
                        Tabla = Tabla + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                reader["Maquina"].ToString() + "</td>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
               Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["Proceso"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["obs"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:64px;'>" +
                Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                 "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioAcerto"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioVirando"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
               
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                reader["Operador"].ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString())).ToString() + "</td>" +
          "</tr>";
                        PliegoActual = reader["Pliego"].ToString();
                        PliegoAnterior = reader["Proceso"].ToString();

                    }
                    else
                    {
                        if (intEnc == 0)
                        {
                            TimeSpan time;
                            time = (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString()));
                            if (reader["Tipo"].ToString() == "P")
                            {

                                HorasTiraje = HorasTiraje + time.Hours;

                                MinutosTiraje = MinutosTiraje + time.Minutes;
                                if (MinutosTiraje > 59)
                                {
                                    MinutosTiraje = MinutosTiraje - 60;
                                    HorasTiraje = HorasTiraje + 1;
                                }



                            }
                            if (reader["Tipo"].ToString() == "S")
                            {

                                HorasPreparacion = HorasPreparacion + time.Hours;
                                MinutosPreparacion = MinutosPreparacion + time.Minutes;
                                if (MinutosPreparacion > 59)
                                {
                                    MinutosPreparacion = MinutosPreparacion - 60;
                                    HorasPreparacion = HorasPreparacion + 1;
                                }

                            }

                            Tabla = Tabla + "</br><b>&nbsp;Pliego " + Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</b>" + Encabezado + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                reader["Maquina"].ToString() + "</td>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
               Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["Proceso"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["obs"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:64px;'>" +
                Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioAcerto"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioVirando"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +

                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                reader["Operador"].ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString())).ToString() + "</td>" +
          "</tr>";
                            PliegoActual = reader["Pliego"].ToString();
                            PliegoAnterior = reader["Proceso"].ToString();
                            intEnc = intEnc + 1;
                        }
                        else
                        {
                            string horasT = "";
                            string minutosT = "";
                            if (HorasTiraje.ToString().Length == 1)
                            {
                                horasT = "0" + HorasTiraje;
                            }
                            else
                            {
                                horasT = HorasTiraje.ToString();
                            }

                            if (MinutosTiraje.ToString().Length == 1)
                            {
                                minutosT = "0" + MinutosTiraje;
                            }
                            else
                            {
                                minutosT = MinutosTiraje.ToString();
                            }
                            string horas = "";
                            string minutos = "";
                            if (HorasPreparacion.ToString().Length == 1)
                            {
                                horas = "0" + HorasPreparacion;
                            }
                            else
                            {
                                horas = HorasPreparacion.ToString();
                            }

                            if (MinutosPreparacion.ToString().Length == 1)
                            {
                                minutos = "0" + MinutosPreparacion;
                            }
                            else
                            {
                                minutos = MinutosPreparacion.ToString();
                            }
                            Tabla = Tabla + "</tbody></table>" +


                                DetalleInformeProduccion_DetalleAgrupacion(OT, PliegoAnterior, horasT + ":" + minutosT + ":00", horas + ":" + minutos + ":00", 9)

+
                                      "</br><b>&nbsp;Pliego " + Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</b>" + Encabezado + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                reader["Maquina"].ToString() + "</td>" +
            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
               Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["Proceso"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                reader["obs"].ToString().ToLower() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:64px;'>" +
                Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioAcerto"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                Convert.ToInt32(reader["DesperdicioVirando"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +

                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                reader["Operador"].ToString() + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString())).ToString() + "</td>" +
          "</tr>";

                            PliegoActual = reader["Pliego"].ToString();
                            PliegoAnterior = reader["Proceso"].ToString();

                            HorasPreparacion = 0;
                            MinutosPreparacion = 0;
                            HorasTiraje = 0;
                            MinutosTiraje = 0;

                            TimeSpan time;
                            time = (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString()));
                            if (reader["Tipo"].ToString() == "P")
                            {

                                HorasTiraje = HorasTiraje + time.Hours;

                                MinutosTiraje = MinutosTiraje + time.Minutes;
                                if (MinutosTiraje > 59)
                                {
                                    MinutosTiraje = MinutosTiraje - 60;
                                    HorasTiraje = HorasTiraje + 1;
                                }



                            }
                            if (reader["Tipo"].ToString() == "S")
                            {

                                HorasPreparacion = HorasPreparacion + time.Hours;
                                MinutosPreparacion = MinutosPreparacion + time.Minutes;
                                if (MinutosPreparacion > 59)
                                {
                                    MinutosPreparacion = MinutosPreparacion - 60;
                                    HorasPreparacion = HorasPreparacion + 1;
                                }

                            }
                        }

                    }
                }
                string horasT2 = "";
                string minutosT2 = "";
                if (HorasTiraje.ToString().Length == 1)
                {
                    horasT2 = "0" + HorasTiraje;
                }
                else
                {
                    horasT2 = HorasTiraje.ToString();
                }

                if (MinutosTiraje.ToString().Length == 1)
                {
                    minutosT2 = "0" + MinutosTiraje;
                }
                else
                {
                    minutosT2 = MinutosTiraje.ToString();
                }
                string horas2 = "";
                string minutos2 = "";
                if (HorasPreparacion.ToString().Length == 1)
                {
                    horas2 = "0" + HorasPreparacion;
                }
                else
                {
                    horas2 = HorasPreparacion.ToString();
                }

                if (MinutosPreparacion.ToString().Length == 1)
                {
                    minutos2 = "0" + MinutosPreparacion;
                }
                else
                {
                    minutos2 = MinutosPreparacion.ToString();
                }

                Tabla = Tabla + "</tbody></table>";
                Tabla = Tabla + DetalleInformeProduccion_DetalleAgrupacion(OT, pliego, horasT2 + ":" + minutosT2 + ":00", horas2 + ":" + minutos2 + ":00", 9);
            }
            conexion.CerrarConexion();

            return Tabla;
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

       

        public string DetalleInformeProduccion_PliegoTabla_V2(string OT, string pliego,string Area, int Procedimiento)
        {
            string Contenido = ""; string PliegoAnt = ""; double TotalBuenos = 0; double TotalMalosPreparacion = 0; double TotalMalosTiraje = 0;
            Conexion conexion = new Conexion(); string Horas = ""; string ceros = "00"; string HorasTiraje = ""; string HorasPreparacion = ""; double UCantidadPlanificada = 0;
            double uHorasTiraje = 0; double uHorasPreparacion = 0; string PrimerPliego = "";
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            #region Encabezado
            string Encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1110px;margin-left:3px;'>" +
          "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Máquina</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>Pliego</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:210px;'>Proceso</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:210px;'>Observación</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:64px;'>Producido</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:63px;'>Malos Preparacion</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:63px;'>Malos Tiraje</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>Operador</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Inicio</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>Fecha Termino</td>" +
            "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>Horas</td>" +
          "</tr>";
            #endregion
            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_InformeProduccion_Detalle]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliego", pliego);
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (PliegoAnt == "" || reader["Processo"].ToString() == PliegoAnt)
                    {
                        if (PliegoAnt == "")
                        {
                            PrimerPliego = "</br><b>&nbsp;Pliego " + Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</b>";
                        }
                        TotalBuenos += Convert.ToDouble(reader["Producido"].ToString());
                        TotalMalosPreparacion += Convert.ToDouble(reader["DesperdicioAcerto"].ToString());
                        TotalMalosTiraje += Convert.ToDouble(reader["DesperdicioVirando"].ToString());
                        if (Convert.ToDouble(reader["Horas"].ToString()) > -1)
                        {
                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["Horas"].ToString()));
                            int Dias2 = t2.Days * 24;
                            Horas = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                        }
                        else
                        {
                            Horas = "En Proceso";
                        }
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            reader["Maquina"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
                            Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                            reader["Proceso"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                            reader["obs"].ToString().ToLower() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:64px;'>" +
                            Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                            Convert.ToInt32(reader["DesperdicioAcerto"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                            Convert.ToInt32(reader["DesperdicioVirando"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                            reader["Operador"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                            Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                            Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                            Horas + "</td>" +
                            "</tr>";
                        PliegoAnt = reader["Processo"].ToString();
                        UCantidadPlanificada = Convert.ToDouble(reader["QtdPlanejado"].ToString());
                        uHorasPreparacion = Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        uHorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString());
                    }
                    else
                    {

                        TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(uHorasTiraje));
                        int Dias3= t3.Days * 24;
                        HorasTiraje = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                        TimeSpan t4 = TimeSpan.FromSeconds(Convert.ToDouble(uHorasPreparacion));
                        int Dias4 = t4.Days * 24;
                        HorasPreparacion = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();
                        //cierre con totales
                        Contenido = Contenido + "</tbody></table><div style='margin-left:620px;'><table id='tblRegistro2' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:490px;margin-left:3px;'>" +
                            "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                              "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Planificado</td>" +
                              "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Buenos</td>" +
                              "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Malos Preparación</td>" +
                              "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Malos Tiraje</td>" +
                              "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Horas Tiraje</td>" +
                              "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:120px;'>Horas Preparación</td>" +
                            "</tr>"+

                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                UCantidadPlanificada.ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;;'>" +
                                TotalBuenos.ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                TotalMalosPreparacion.ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                                TotalMalosTiraje.ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                HorasTiraje.ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                                HorasPreparacion.ToString() + "</td>" +
                            "</tr>" +
                            "</tbody></table></div>";
                        //impresion nuevo pliego

                        TotalBuenos = 0; TotalBuenos += Convert.ToDouble(reader["Producido"].ToString());
                        TotalMalosPreparacion = 0; TotalMalosPreparacion += Convert.ToDouble(reader["DesperdicioAcerto"].ToString());
                        TotalMalosTiraje = 0; TotalMalosTiraje += Convert.ToDouble(reader["DesperdicioVirando"].ToString());
                        if (Convert.ToDouble(reader["Horas"].ToString()) > -1)
                        {
                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["Horas"].ToString()));
                            int Dias2 = t2.Days * 24;
                            Horas = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                        }
                        else
                        {
                            Horas = "En Proceso";
                        }
                        Contenido = Contenido + "</br><b>&nbsp;Pliego " + Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</b>" +
                                        Encabezado + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                                        reader["Maquina"].ToString() + "</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:40px;'>" +
                                        Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty).ToString() + "</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                                        reader["Proceso"].ToString().ToLower() + "</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:210px;'>" +
                                        reader["obs"].ToString().ToLower() + "</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:64px;'>" +
                                        Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                                        Convert.ToInt32(reader["DesperdicioAcerto"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:63px;'>" +
                                        Convert.ToInt32(reader["DesperdicioVirando"].ToString()).ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" +
                                        reader["Operador"].ToString() + "</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                                        Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;'>" +
                                        Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                                        Horas + "</td>" +
                                        "</tr>";
                        PliegoAnt = reader["Processo"].ToString();
                        UCantidadPlanificada = Convert.ToDouble(reader["QtdPlanejado"].ToString());
                        uHorasPreparacion = Convert.ToDouble(reader["HorasPreparacion"].ToString());
                        uHorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString());
                    }
                }
                if (reader.Read() == false)
                {
                    TimeSpan t3 = TimeSpan.FromSeconds(uHorasTiraje);
                    int Dias3 = t3.Days * 24;
                    HorasTiraje = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                    TimeSpan t4 = TimeSpan.FromSeconds(uHorasPreparacion);
                    int Dias4 = t4.Days * 24;
                    HorasPreparacion = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();
                    //cierre con totales
                    Contenido = Contenido + "</tbody></table><div style='margin-left:620px;'><table id='tblRegistro2' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:490px;margin-left:3px;'>" +
                        "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                          "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Planificado</td>" +
                          "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Buenos</td>" +
                          "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Malos Preparación</td>" +
                          "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Malos Tiraje</td>" +
                          "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Horas Tiraje</td>" +
                          "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:120px;'>Horas Preparación</td>" +
                        "</tr>" +

                        "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            UCantidadPlanificada.ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;;'>" +
                            TotalBuenos.ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            TotalMalosPreparacion.ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                            TotalMalosTiraje.ToString("N0").Replace(",", ".") + "&nbsp;</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            HorasTiraje.ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            HorasPreparacion.ToString() + "</td>" +
                        "</tr>" +
                        "</tbody></table></div>";
                }

            }
            conexion.CerrarConexion();
            return PrimerPliego + Encabezado + Contenido;
        }


        public List<InformeProduccionM> Listar_TeoricoRealComparativoPro(string OT,string Area, string FechaInicio, string FechaTermino, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string Sector = "";
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Produccion_CorreoComparativo_RealTeorico]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@Area", Area);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    cmd.CommandTimeout = 3000;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        InformeProduccionM info = new InformeProduccionM();
                        info.Maquina = reader["Maquina"].ToString().Replace("C150","").Trim();
                        info.OT = reader["OT"].ToString();
                        info.NombreOT = reader["NombreOT"].ToString().ToLower();
                       // info.Pliego = "<a title='" + reader["Processo"].ToString() + "'>" + reader["Componente"].ToString()+ reader["Processo"].ToString().Replace("IMP PLANA", "").Replace("IMP ROTATIVA", "").Replace(reader["Componente"].ToString(), "").Trim().ToLower() + "</a>";
                        info.Pliego = reader["Componente"].ToString() + reader["Processo"].ToString().Replace("IMP PLANA", "").Replace("IMP ROTATIVA", "").Replace(reader["Componente"].ToString(), "").Trim().ToLower();
                        info.Planificado = reader["Planificado"].ToString();
                        info.Buenos = reader["Giros"].ToString();
                        info.Producido = (Convert.ToInt32(info.Buenos) - Convert.ToInt32(info.Planificado)).ToString() + " (" + (Convert.ToDouble((Convert.ToDouble(Convert.ToDouble(info.Buenos) - Convert.ToDouble(info.Planificado))) / Convert.ToDouble(info.Planificado))*100).ToString("N2")+"%)";
                        info.Proceso = reader["Wip_PliegosWip"].ToString();
                        info.Tipo = reader["DescPapel"].ToString();//Papeles
                        info.CodMaquina = reader["CodItem"].ToString();//Costo sobreimpresion
                        info.FechaInicio = Convert.ToDouble(reader["QtdePapelUnidade1"].ToString()).ToString("N2");//Consumo KG
                        info.Operador = reader["Operador"].ToString().ToLower();
                        lista.Add(info);
                    }
                }
                catch
                {//248,51
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public List<InformeProduccionM> Listar_InformeMensualSobreProd(string FechaInicio, string FechaTermino)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Produccion_InformeSobreImpresionMensual2";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio",FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino",FechaTermino);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    InformeProduccionM infp = new InformeProduccionM();
                    infp.Clasificacion = reader["CodSetor"].ToString();
                    infp.Maquina = reader["Maquina"].ToString();
                    infp.OT = reader["NumOrdem"].ToString();
                    infp.Planificado = reader["Planificado"].ToString();
                    infp.Producido = reader["Giros"].ToString();
                    infp.CodMaquina = reader["TipoConsumo"].ToString();
                    //if (infp.Maquina == "KBA Rapida 106")
                    //{
                    //    infp.Producido = reader["GirosKBA"].ToString();
                    //}
                    //else
                    //{
                    //    infp.Producido = reader["Giros"].ToString();
                    //}
                    lista.Add(infp);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        //CORREO MERMAS Y PRODUCCION
        public string Produccion_CorreoMermas_V2(string Usuario,DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
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
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Control WIP</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Operador</td>" +
          "</tr>";
            #endregion;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_CorreoMermas_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
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
                            reader["Operador"].ToString().Substring(0, reader["Operador"].ToString().Length - 1).ToLower() + "</td>" +
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
                           reader["Operador"].ToString().Substring(0, reader["Operador"].ToString().Length - 1).ToLower() + "</td>" +
                           "</tr>";
                    }
                    MaquinaAnt = reader["CodRecurso"].ToString();
                }
            }
            conexion.CerrarConexion();
            return Encabezado + Contenido + Totales + "</tbody></table>";
        }

        public string Produccion_CorreoMermas_ENC_V2(DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
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
                cmd.CommandTimeout = 99900000;
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
    }
}

