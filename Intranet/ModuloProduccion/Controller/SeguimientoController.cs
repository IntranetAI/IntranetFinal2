using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloProduccion.Model;
using System.Globalization;

namespace Intranet.ModuloProduccion.Controller
{
    public class SeguimientoController
    {

        public List<InformeProgramacion> Lista_ProgramaProduccion(string Seccion, string Maquina, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeProgramacion> lista = new List<InformeProgramacion>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_Informe_ProgramacionProduccion]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Seccion", Seccion);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeProgramacion pro = new InformeProgramacion();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    pro.Maquina = reader["Maquina"].ToString();
                    pro.NroForma = Convert.ToInt32(reader["NroFormas"].ToString()).ToString("N0").Replace(",", ".");
                    pro.FechaInicio = reader["FechaInicio"].ToString();//).ToString("dd/MM/yyyy HH:mm");
                    pro.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.Pliegos = Convert.ToInt32(reader["Pliegos"].ToString()).ToString("N0").Replace(",", ".");
                    TimeSpan time;
                    time = (Convert.ToDateTime(reader["FechaTermino"].ToString()) - Convert.ToDateTime(reader["FechaInicio"].ToString()));
                    pro.Horas = time.ToString();
                    pro.VBdet = reader["VB"].ToString();
                    if (reader["VB"].ToString() != "")
                    {
                        pro.VB = "<div style='color:Green;' title='" + reader["VB"].ToString() + "'>SI</div>";
                    }
                    else
                    {
                        pro.VB = "<div style='color:Red;'>NO</div>";
                    }

                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }


        public List<InformeProgramacion> Lista_ProgramaProduccion2(string Seccion, string Maquina, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeProgramacion> lista = new List<InformeProgramacion>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_Informe_ProgramacionProduccion2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Seccion", Seccion);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeProgramacion pro = new InformeProgramacion();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    pro.Maquina = reader["Maquina"].ToString();

                    if (reader["NroFormas"].ToString().Trim().Contains(" ") == true)
                    {
                        pro.NroForma = reader["Idprocesso"].ToString().ToLower();
                    }
                    else if (reader["NroFormas"].ToString().Trim().Contains("-") == true || reader["NroFormas"].ToString().Trim().Contains("ENC") == true)
                    {
                        pro.NroForma = reader["Idprocesso"].ToString();
                    }
                    else
                    {
                        pro.NroForma = reader["NroFormas"].ToString().Replace(".", "");
                    }
                    pro.FechaInicio = reader["FechaInicio"].ToString();//).ToString("dd/MM/yyyy HH:mm");
                    pro.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.Pliegos = Convert.ToInt32(reader["Pliegos"].ToString()).ToString("N0").Replace(",", ".");
                    TimeSpan time;
                    time = (Convert.ToDateTime(reader["FechaTermino"].ToString()) - Convert.ToDateTime(reader["FechaInicio"].ToString()));
                    pro.Horas = time.ToString();
                    pro.VBdet = reader["VB"].ToString();
                    if (reader["VB"].ToString() != "")
                    {
                        pro.VB = "<div style='color:Green;' title='" + reader["VB"].ToString() + "'>SI</div>";
                    }
                    else
                    {
                        pro.VB = "<div style='color:Red;'>NO</div>";
                    }

                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }




        public List<InformeProgramacion> Lista_ProgramaProduccionInfoGeneral(string Seccion, string Maquina, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeProgramacion> lista = new List<InformeProgramacion>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_Informe_ProgramacionProduccion3]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Seccion", Seccion);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeProgramacion pro = new InformeProgramacion();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    pro.Maquina = reader["Maquina"].ToString();

                    pro.NroForma = reader["NroFormas"].ToString();//Nro de Formas (pliegos-componente)

                    pro.FechaInicio = reader["FechaInicio"].ToString();//).ToString("dd/MM/yyyy HH:mm");


                    TimeSpan time;
                    int Pliego1 = 0;
                    int Pliego2 = 0;


                    string[] str = reader["FechaInicio"].ToString().Split('/');
                    string feci = str[1] + "/" + str[0] + "/" + str[2].Substring(0, 4);
                    string[] str2 = reader["FechaTermino"].ToString().Split('/');
                    string fect = str2[1] + "/" + str2[0] + "/" + str2[2].Substring(0, 4);


                    if (feci == fect)//hacer cambio hora en el pliego
                    {
                        pro.Pliegos = Convert.ToInt32(reader["Pliegos"].ToString()).ToString("N0").Replace(",", ".");
                        time = (Convert.ToDateTime(reader["FechaTermino"].ToString()) - Convert.ToDateTime(reader["FechaInicio"].ToString()));
                        pro.Horas = time.ToString();
                        pro.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        // pro.Pliegos = Convert.ToInt32(reader["Pliegos"].ToString()).ToString("N0").Replace(",", ".");

                        string time1 = reader["FechaTermino"].ToString();
                        string time2 = str[0] + "/" + str[1] + "/" + str[2].Substring(0, 4) + " 23:59:59";

                        pro.FechaTermino = Convert.ToDateTime(str[0] + "/" + str[1] + "/" + str[2].Substring(0, 4) + " 23:59:59").ToString("dd/MM/yyyy HH:mm");
                        time = (Convert.ToDateTime(str[0] + "/" + str[1] + "/" + str[2].Substring(0, 4) + " 23:59:59") - Convert.ToDateTime(reader["FechaInicio"].ToString()));
                        pro.Horas = time.ToString();

                        TimeSpan timeTotal;
                        timeTotal = (Convert.ToDateTime(reader["FechaTermino"].ToString()) - Convert.ToDateTime(reader["FechaInicio"].ToString()));

                        int totalHoras = ((int.Parse(timeTotal.Minutes.ToString())) + ((int.Parse(timeTotal.Hours.ToString()) * 60)) + (int.Parse(timeTotal.Days.ToString()) * 1440));
                        int total1 = ((int.Parse(time.Minutes.ToString())) + ((int.Parse(time.Hours.ToString()) * 60)));

                        Pliego1 = ((Convert.ToInt32(reader["Pliegos"].ToString()) * total1) / totalHoras);
                        Pliego2 = ((Convert.ToInt32(reader["Pliegos"].ToString()) * (totalHoras - total1)) / totalHoras);
                        pro.Pliegos = Pliego1.ToString("N0").Replace(",", ".");

                    }


                    pro.VBdet = reader["VB"].ToString();
                    if (reader["VB"].ToString() != "")
                    {
                        pro.VB = "<div style='color:Green;' title='" + reader["VB"].ToString() + "'>SI</div>";
                    }
                    else
                    {
                        pro.VB = "<div style='color:Red;'>NO</div>";
                    }

                    if (Convert.ToDateTime(reader["FechaInicio"].ToString()).ToString("dd/MM/yyyy") != Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy"))
                    {
                        InformeProgramacion pro2 = new InformeProgramacion();
                        pro2.OT = reader["OT"].ToString();
                        pro2.NombreOT = reader["NombreOT"].ToString();
                        pro2.Maquina = reader["Maquina"].ToString();
                        pro2.NroForma = reader["NroFormas"].ToString();
                        string gggg = reader["FechaTermino"].ToString();
                        pro2.FechaInicio = Convert.ToDateTime(Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy")).ToString();//Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy");// reader["FechaInicio"].ToString();
                        pro2.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm");
                        pro2.Pliegos = Pliego2.ToString("N0").Replace(",", ".");
                        TimeSpan time2;
                        time2 = (Convert.ToDateTime(reader["FechaTermino"].ToString()) - Convert.ToDateTime(str2[0] + "/" + str2[1] + "/" + str2[2].Substring(0, 4) + " 00:00:00"));
                        int nh = int.Parse(time2.Hours.ToString()) * 60;


                        int n = int.Parse(time2.Minutes.ToString());
                        int total = nh + n;
                        pro2.Horas = time2.ToString();

                        pro2.VBdet = reader["VB"].ToString();
                        if (reader["VB"].ToString() != "")
                        {
                            pro2.VB = "<div style='color:Green;' title='" + reader["VB"].ToString() + "'>SI</div>";
                        }
                        else
                        {
                            pro2.VB = "<div style='color:Red;'>NO</div>";
                        }
                        lista.Add(pro2);
                    }



                    lista.Add(pro);

                }

            }
            conexion.CerrarConexion();

            return lista.OrderBy(p => Convert.ToDateTime(p.FechaInicio)).ToList();
        }

        public string Carga_Programacion_PDF(string Seccion, string Maquina, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            DateTime fecAntLitho = Convert.ToDateTime("1900-01-01");
            CultureInfo espanol = new CultureInfo("es-ES");
            string encabezado = "<table border='1' >" +
                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td>OT</td>" +
                "<td colspan='3'>Nombre OT</td>" +
                "<td>Pliegos</td>" +
                "<td colspan='2'>Hora Inicio</td>" +
                "<td colspan='2'>Hora Termino</td>" +
                "<td>Horas</td>" +
                "<td>Formas</td>" +
                "<td>V.B</td>" +
                "</tr>";
            string LITHOMAN = "";
            string WEB1 = "";
            string WEB2 = "";
            string M600 = "";
            string GOSS = "";
            string p10 = "";
            string p8 = "";
            string p4 = "";
            string CD = "";
            string XL = "";
            int pliegosLithoman = 0;
            //TimeSpan horasLithoman = TimeSpan.Parse("00:00:00");
            string horasLithoman = "00:00:00";
            int FormasLithoman = 0;
            List<InformeProgramacion> lista = Lista_ProgramaProduccion(Seccion, Maquina, Fechainicio, FechaTermino, Procedimiento);
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "LITHOMAN"))
            {

                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntLitho.ToString("dd/MM/yyyy"))
                {
                    if (LITHOMAN != "")
                    {
                        LITHOMAN = LITHOMAN + "</tbody></table>";
                        LITHOMAN = LITHOMAN + "<table style='border: 1px solid #CCC;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosLithoman.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasLithoman.ToString() + "</td>" +
"<td>" + FormasLithoman + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        pliegosLithoman = 0;
                        FormasLithoman = 0;
                        horasLithoman = "00:00:00";
                    }
                    else
                    {
                        LITHOMAN = LITHOMAN + "<h2>LITHOMAN</h2>";
                    }
                    LITHOMAN = LITHOMAN + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + " <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntLitho = Convert.ToDateTime(ip.FechaInicio);

                    horasLithoman = (TimeSpan.Parse(horasLithoman) + TimeSpan.Parse(ip.Horas)).ToString();
                    pliegosLithoman = pliegosLithoman + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasLithoman = FormasLithoman + Convert.ToInt32(ip.NroForma);

                }
                else
                {
                    LITHOMAN = LITHOMAN + "  </br> <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td>" +
                    ip.OT + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntLitho = Convert.ToDateTime(ip.FechaInicio);

                    horasLithoman = (TimeSpan.Parse(horasLithoman) + TimeSpan.Parse(ip.Horas)).ToString(); ;//TimeSpan.Parse(ip.Horas);
                    pliegosLithoman = pliegosLithoman + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasLithoman = FormasLithoman + Convert.ToInt32(ip.NroForma);
                }

            }
            if (LITHOMAN == "")
            {
                LITHOMAN = "";
            }
            else
            {
                LITHOMAN = LITHOMAN + "</tbody></table>";
                LITHOMAN = LITHOMAN + "<table style='border: 1px solid #CCC;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosLithoman.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasLithoman.ToString() + "</td>" +
"<td>" + FormasLithoman + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                pliegosLithoman = 0;
                FormasLithoman = 0;
                horasLithoman = "00:00:00";
            }

            /////////////////////////////////////////////// web1///////////////////////////////////////////////////////////////////////////
            DateTime fecAntWeb1 = Convert.ToDateTime("1900-01-01");
            int pliegosWeb1 = 0;
            string horasWeb1 = "00:00:00";
            int FormasWeb1 = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "WEB 1"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntWeb1.ToString("dd/MM/yyyy"))
                {
                    if (WEB1 != "")
                    {
                        WEB1 = WEB1 + "</tbody></table>";
                        WEB1 = WEB1 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosWeb1.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasWeb1.ToString() + "</td>" +
"<td>" + FormasWeb1 + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        pliegosWeb1 = 0;
                        FormasWeb1 = 0;
                        horasWeb1 = "00:00:00";
                    }
                    else
                    {
                        WEB1 = WEB1 + "<h2>WEB 1</h2>";
                    }
                    WEB1 = WEB1 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "   <br /><tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'> " +
                     ip.NombreOT.ToLower().ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2''>" +
                    ip.FechaTermino + " </td>" +
                    "<td >" +
                    ip.Horas + " </td>" +
                    "<td >" +
                    ip.NroForma + " </td>" +
                    "<td >" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntWeb1 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosWeb1 = pliegosWeb1 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasWeb1 = FormasWeb1 + Convert.ToInt32(ip.NroForma);
                    horasWeb1 = (TimeSpan.Parse(horasWeb1) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    WEB1 = WEB1 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td>" +
                    ip.OT.ToLower() + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntWeb1 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosWeb1 = pliegosWeb1 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasWeb1 = FormasWeb1 + Convert.ToInt32(ip.NroForma);
                    horasWeb1 = (TimeSpan.Parse(horasWeb1) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (WEB1 == "")
            {
                WEB1 = "";
            }
            else
            {
                WEB1 = WEB1 + "</tbody></table>";
                WEB1 = WEB1 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosWeb1.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasWeb1.ToString() + "</td>" +
"<td>" + FormasWeb1 + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                pliegosWeb1 = 0;
                FormasWeb1 = 0;
                horasWeb1 = "00:00:00";
            }


            /////////////////////////////////////////////// web2///////////////////////////////////////////////////////////////////////////
            DateTime fecAntWeb2 = Convert.ToDateTime("1900-01-01");
            int pliegosWeb2 = 0;
            string horasWeb2 = "00:00:00";
            int FormasWeb2 = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "WEB 2"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntWeb2.ToString("dd/MM/yyyy"))
                {
                    if (WEB2 != "")
                    {
                        WEB2 = WEB2 + "</tbody></table>";
                        WEB2 = WEB2 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosWeb2.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasWeb2.ToString() + "</td>" +
"<td>" + FormasWeb2 + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        pliegosWeb2 = 0;
                        FormasWeb2 = 0;
                        horasWeb2 = "00:00:00";
                    }
                    else
                    {
                        WEB2 = WEB2 + "<h2>WEB 1</h2>";
                    }
                    WEB2 = WEB2 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "   <br /><tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'> " +
                     ip.NombreOT.ToLower().ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2''>" +
                    ip.FechaTermino + " </td>" +
                    "<td >" +
                    ip.Horas + " </td>" +
                    "<td >" +
                    ip.NroForma + " </td>" +
                    "<td >" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntWeb2 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosWeb2 = pliegosWeb2 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasWeb2 = FormasWeb2 + Convert.ToInt32(ip.NroForma);
                    horasWeb2 = (TimeSpan.Parse(horasWeb2) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    WEB2 = WEB2 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td>" +
                    ip.OT.ToLower() + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntWeb2 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosWeb2 = pliegosWeb2 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasWeb2 = FormasWeb2 + Convert.ToInt32(ip.NroForma);
                    horasWeb2 = (TimeSpan.Parse(horasWeb2) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (WEB2 == "")
            {
                WEB2 = "";
            }
            else
            {
                WEB2 = WEB2 + "</tbody></table>";
                WEB2 = WEB2 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosWeb2.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasWeb2.ToString() + "</td>" +
"<td>" + FormasWeb2 + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                pliegosWeb2 = 0;
                FormasWeb2 = 0;
                horasWeb2 = "00:00:00";
            }



            /////////////////////////////////////////////// M600M600M600M600M600M600M600///////////////////////////////////////////////////////////////////////////
            DateTime fecAntM600 = Convert.ToDateTime("1900-01-01");
            int pliegosM600 = 0;
            string horasM600 = "00:00:00";
            int FormasM600 = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "M600"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntM600.ToString("dd/MM/yyyy"))
                {
                    if (M600 != "")
                    {
                        M600 = M600 + "</tbody></table>";
                        M600 = M600 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosM600.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasM600.ToString() + "</td>" +
"<td>" + FormasM600 + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        pliegosM600 = 0;
                        FormasM600 = 0;
                        horasM600 = "00:00:00";
                    }
                    else
                    {
                        M600 = M600 + "<h2>M-600</h2>";
                    }
                    M600 = M600 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + "<table></table>" + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntM600 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosM600 = pliegosM600 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasM600 = FormasM600 + Convert.ToInt32(ip.NroForma);
                    horasM600 = (TimeSpan.Parse(horasM600) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    M600 = M600 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                    ip.OT + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntM600 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosM600 = pliegosM600 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasM600 = FormasM600 + Convert.ToInt32(ip.NroForma);
                    horasM600 = (TimeSpan.Parse(horasM600) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (M600 == "")
            {
                M600 = "";
            }
            else
            {
                M600 = M600 + "</tbody></table>";
                M600 = M600 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosM600.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasM600.ToString() + "</td>" +
"<td>" + FormasM600 + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                pliegosM600 = 0;
                FormasM600 = 0;
                horasM600 = "00:00:00";
            }



            /////////////////////////////////////////////// GOSSGOSSGOSSGOSSGOSSGOSSGOSSGOSS///////////////////////////////////////////////////////////////////////////
            DateTime fecAntGOSS = Convert.ToDateTime("1900-01-01");
            int pliegosGOSS = 0;
            string horasGOSS = "00:00:00";
            int FormasGOSS = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "GOSS C150"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntGOSS.ToString("dd/MM/yyyy"))
                {
                    if (GOSS != "")
                    {
                        GOSS = GOSS + "</tbody></table>";
                        GOSS = GOSS + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosGOSS.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasGOSS.ToString() + "</td>" +
"<td>" + FormasGOSS + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        pliegosGOSS = 0;
                        FormasGOSS = 0;
                        horasGOSS = "00:00:00";
                    }
                    else
                    {
                        GOSS = GOSS + "<h2>GOSS</h2>";
                    }
                    GOSS = GOSS + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntGOSS = Convert.ToDateTime(ip.FechaInicio);
                    pliegosGOSS = pliegosGOSS + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasGOSS = FormasGOSS + Convert.ToInt32(ip.NroForma);
                    horasGOSS = (TimeSpan.Parse(horasGOSS) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    GOSS = GOSS + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                    ip.OT + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntGOSS = Convert.ToDateTime(ip.FechaInicio);
                    pliegosGOSS = pliegosGOSS + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasGOSS = FormasGOSS + Convert.ToInt32(ip.NroForma);
                    horasGOSS = (TimeSpan.Parse(horasGOSS) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (GOSS == "")
            {
                GOSS = "";
            }
            else
            {
                GOSS = GOSS + "</tbody></table>";
                GOSS = GOSS + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosGOSS.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasGOSS.ToString() + "</td>" +
"<td>" + FormasGOSS + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                pliegosGOSS = 0;
                FormasGOSS = 0;
                horasGOSS = "00:00:00";
            }

            /////////////////////////////////////////////// 10p10p10p10p10p10p10p10p10p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt10p = Convert.ToDateTime("1900-01-01");
            int pliegos10P = 0;
            string horas10P = "00:00:00";
            int Formas10P = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "10P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt10p.ToString("dd/MM/yyyy"))
                {
                    if (p10 != "")
                    {
                        p10 = p10 + "</tbody></table>";
                        p10 = p10 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegos10P.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horas10P.ToString() + "</td>" +
"<td>" + Formas10P + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        pliegos10P = 0;
                        Formas10P = 0;
                        horas10P = "00:00:00";
                    }
                    else
                    {
                        p10 = p10 + "<h2>10P</h2>";
                    }
                    p10 = p10 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAnt10p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos10P = pliegos10P + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas10P = Formas10P + Convert.ToInt32(ip.NroForma);
                    horas10P = (TimeSpan.Parse(horas10P) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    p10 = p10 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                    ip.OT + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAnt10p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos10P = pliegos10P + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas10P = Formas10P + Convert.ToInt32(ip.NroForma);
                    horas10P = (TimeSpan.Parse(horas10P) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (p10 == "")
            {
                p10 = "";
            }
            else
            {
                p10 = p10 + "</tbody></table>";
                p10 = p10 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegos10P.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horas10P.ToString() + "</td>" +
"<td>" + Formas10P + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                pliegos10P = 0;
                Formas10P = 0;
                horas10P = "00:00:00";
            }


            /////////////////////////////////////////////// 8p8p8p8p8p8p8p8p8p8p8p8p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt8p = Convert.ToDateTime("1900-01-01");
            int pliegos8P = 0;
            string horas8P = "00:00:00";
            int Formas8P = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "8P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt8p.ToString("dd/MM/yyyy"))
                {
                    if (p8 != "")
                    {
                        p8 = p8 + "</tbody></table>";
                        p8 = p8 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegos8P.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horas8P.ToString() + "</td>" +
"<td>" + Formas8P + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        pliegos8P = 0;
                        Formas8P = 0;
                        horas8P = "00:00:00";
                    }
                    else
                    {
                        p8 = p8 + "<h2>8P</h2>";
                    }
                    p8 = p8 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAnt8p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos8P = pliegos8P + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas8P = Formas8P + Convert.ToInt32(ip.NroForma);
                    horas8P = (TimeSpan.Parse(horas8P) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    p8 = p8 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                    ip.OT + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAnt8p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos8P = pliegos8P + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas8P = Formas8P + Convert.ToInt32(ip.NroForma);
                    horas8P = (TimeSpan.Parse(horas8P) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (p8 == "")
            {
                p8 = "";
            }
            else
            {
                p8 = p8 + "</tbody></table>";
                p8 = p8 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegos8P.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horas8P.ToString() + "</td>" +
"<td>" + Formas8P + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                pliegos8P = 0;
                Formas8P = 0;
                horas8P = "00:00:00";
            }

            /////////////////////////////////////////////// 4p4p4p4p4p4p4p4p4p4p4p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt4p = Convert.ToDateTime("1900-01-01");
            int pliegos4p = 0;
            string horas4p = "00:00:00";
            int Formas4p = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "4P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt4p.ToString("dd/MM/yyyy"))
                {
                    if (p4 != "")
                    {
                        p4 = p4 + "</tbody></table>";
                        p4 = p4 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegos4p.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horas4p.ToString() + "</td>" +
"<td>" + Formas4p + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        pliegos4p = 0;
                        Formas4p = 0;
                        horas4p = "00:00:00";
                    }
                    else
                    {
                        p4 = p4 + "<h2>4P</h2>";
                    }
                    p4 = p4 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                      "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAnt4p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos4p = pliegos4p + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas4p = Formas4p + Convert.ToInt32(ip.NroForma);
                    horas4p = (TimeSpan.Parse(horas4p) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    p4 = p4 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                    ip.OT + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAnt4p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos4p = pliegos4p + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas4p = Formas4p + Convert.ToInt32(ip.NroForma);
                    horas4p = (TimeSpan.Parse(horas4p) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (p4 == "")
            {
                p4 = "";
            }
            else
            {
                p4 = p4 + "</tbody></table>";
                p4 = p4 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegos4p.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horas4p.ToString() + "</td>" +
"<td>" + Formas4p + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                pliegos4p = 0;
                Formas4p = 0;
                horas4p = "00:00:00";
            }


            ///////////////////////////////////////////////CDCDCDCDCDCDCDCD///////////////////////////////////////////////////////////////////////////
            DateTime fecAntCD = Convert.ToDateTime("1900-01-01");
            int pliegosCD = 0;
            string horasCD = "00:00:00";
            int FormasCD = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "CD"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntCD.ToString("dd/MM/yyyy"))
                {
                    if (CD != "")
                    {
                        CD = CD + "</tbody></table>";
                        CD = CD + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosCD.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasCD.ToString() + "</td>" +
"<td>" + FormasCD + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        pliegosCD = 0;
                        FormasCD = 0;
                        horasCD = "00:00:00";
                    }
                    else
                    {
                        CD = CD + "<h2>CD</h2>";
                    }
                    CD = CD + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntCD = Convert.ToDateTime(ip.FechaInicio);
                    pliegosCD = pliegosCD + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasCD = FormasCD + Convert.ToInt32(ip.NroForma);
                    horasCD = (TimeSpan.Parse(horasCD) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    CD = CD + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                    ip.OT + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntCD = Convert.ToDateTime(ip.FechaInicio);
                    pliegosCD = pliegosCD + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasCD = FormasCD + Convert.ToInt32(ip.NroForma);
                    horasCD = (TimeSpan.Parse(horasCD) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (CD == "")
            {
                CD = "";
            }
            else
            {
                CD = CD + "</tbody></table>";
                CD = CD + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosCD.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasCD.ToString() + "</td>" +
"<td>" + FormasCD + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                pliegosCD = 0;
                FormasCD = 0;
                horasCD = "00:00:00";
            }


            ///////////////////////////////////////////////xlxlxllxlxlxllxlxlxlxlx///////////////////////////////////////////////////////////////////////////
            DateTime fecAntXL = Convert.ToDateTime("1900-01-01");
            int pliegosXL = 0;
            string horasXL = "00:00:00";
            int FormasXL = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "XL"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntXL.ToString("dd/MM/yyyy"))
                {
                    if (XL != "")
                    {
                        XL = XL + "</tbody></table>";
                        XL = XL + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td></td>" +
"<td colspan='3'>TOTAL</td>" +
"<td>" + pliegosXL.ToString("N0").Replace(",", ".") + "</td>" +
"<td colspan='2'></td>" +
"<td colspan='2'></td>" +
"<td>" + horasXL.ToString() + "</td>" +
"<td>" + FormasXL + "</td>" +
"<td></td>" +
"</tr></tbody></table>";
                        FormasXL = 0;
                        FormasXL = 0;
                        horasXL = "00:00:00";
                    }
                    else
                    {
                        XL = XL + "<h2>XL</h2>";
                    }
                    XL = XL + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                     ip.OT + " </td>" +
                    "<td colspan='3'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntXL = Convert.ToDateTime(ip.FechaInicio);
                    pliegosXL = pliegosXL + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasXL = FormasXL + Convert.ToInt32(ip.NroForma);
                    horasXL = (TimeSpan.Parse(horasXL) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    XL = XL + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:55px;'>" +
                    ip.OT + " </td>" +
                    "<td colspan='3'>" +
                    ip.NombreOT.ToLower() + " </td>" +
                    "<td>" +
                    ip.Pliegos + " </td>" +
                    "<td colspan='2'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td colspan='2'>" +
                    ip.FechaTermino + " </td>" +
                    "<td>" +
                    ip.Horas + " </td>" +
                    "<td>" +
                    ip.NroForma + " </td>" +
                    "<td>" +
                    ip.VB + "</td>" +
                    "</tr>";
                    fecAntXL = Convert.ToDateTime(ip.FechaInicio);
                    pliegosXL = pliegosXL + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasXL = FormasXL + Convert.ToInt32(ip.NroForma);
                    horasXL = (TimeSpan.Parse(horasXL) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (XL == "")
            {
                XL = "";
            }
            else
            {
                XL = XL + "</tbody></table>";
                XL = XL + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td></td>" +
                "<td colspan='3'>TOTAL</td>" +
                "<td>" + pliegosXL.ToString("N0").Replace(",", ".") + "</td>" +
                "<td colspan='2'></td>" +
                "<td colspan='2'></td>" +
                "<td>" + horasXL.ToString() + "</td>" +
                "<td>" + FormasXL + "</td>" +
                "<td></td>" +
                "</tr></tbody></table>";
                pliegosXL = 0;
                FormasXL = 0;
                horasXL = "00:00:00";
            }


            return LITHOMAN + WEB1 + WEB2 + M600 + GOSS + p10 + p8 + p4 + CD + XL;
        }

        public List<Maquina> ListMaquinas(string valor)
        {
            List<Maquina> lista = new List<Maquina>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_CargaMaquina]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Seccion", valor);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Maquina pro = new Maquina();
                    pro.ID = reader["NombreMaquina"].ToString();
                    pro.Name = reader["NombreMaquina"].ToString();

                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
        public List<Maquina> ListMaquinasMetrics(string Area,string Maquina, int Procedimiento)
        {
            List<Maquina> lista = new List<Maquina>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_ListaMaquinasMetrics]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Maquina pro = new Maquina();
                    pro.ID = reader["CodRecurso"].ToString();
                    pro.Name = reader["Descricao"].ToString();

                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }


        public string Carga_Programacion(string Seccion, string Maquina, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            DateTime fecAntLitho = Convert.ToDateTime("1900-01-01");
            CultureInfo espanol = new CultureInfo("es-ES");
            string encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>OT</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Nombre OT</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Pliegos</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>Hora Inicio</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>Hora Termino</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Horas</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Nro. Formas</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>V.B</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
                "</tr>";
            string LITHOMAN = "";
            string WEB1 = "";
            string M600 = "";
            string GOSS = "";
            string p10 = "";
            string p8 = "";
            string p4 = "";
            string CD = "";
            string XL = "";
            string KBA = "";
            int pliegosLithoman = 0;
            //TimeSpan horasLithoman = TimeSpan.Parse("00:00:00");
            string horasLithoman = "00:00:00";
            int FormasLithoman = 0;
            List<InformeProgramacion> lista = Lista_ProgramaProduccion(Seccion, Maquina, Fechainicio, FechaTermino, Procedimiento);
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "LITHOMAN"))
            {

                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntLitho.ToString("dd/MM/yyyy"))
                {
                    if (LITHOMAN != "")
                    {
                        LITHOMAN = LITHOMAN + "</tbody></table>";
                        LITHOMAN = LITHOMAN + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
                        "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosLithoman.ToString("N0").Replace(",", ".") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasLithoman.ToString() + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasLithoman + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
                        "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
                        "</tr></tbody></table>";
                        pliegosLithoman = 0;
                        FormasLithoman = 0;
                        horasLithoman = "00:00:00";
                    }
                    else
                    {
                        LITHOMAN = LITHOMAN + "<h2>LITHOMAN</h2>";
                    }
                    LITHOMAN = LITHOMAN + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntLitho = Convert.ToDateTime(ip.FechaInicio);

                    horasLithoman = (TimeSpan.Parse(horasLithoman) + TimeSpan.Parse(ip.Horas)).ToString();
                    pliegosLithoman = pliegosLithoman + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasLithoman = FormasLithoman + Convert.ToInt32(ip.NroForma);

                }
                else
                {
                    LITHOMAN = LITHOMAN + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntLitho = Convert.ToDateTime(ip.FechaInicio);

                    horasLithoman = (TimeSpan.Parse(horasLithoman) + TimeSpan.Parse(ip.Horas)).ToString(); ;//TimeSpan.Parse(ip.Horas);
                    pliegosLithoman = pliegosLithoman + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasLithoman = FormasLithoman + Convert.ToInt32(ip.NroForma);
                }

            }
            if (LITHOMAN == "")
            {
                LITHOMAN = "";
            }
            else
            {
                LITHOMAN = LITHOMAN + "</tbody></table>";
                LITHOMAN = LITHOMAN + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosLithoman.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasLithoman.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasLithoman + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegosLithoman = 0;
                FormasLithoman = 0;
                horasLithoman = "00:00:00";
            }

            /////////////////////////////////////////////// web1///////////////////////////////////////////////////////////////////////////
            DateTime fecAntWeb1 = Convert.ToDateTime("1900-01-01");
            int pliegosWeb1 = 0;
            string horasWeb1 = "00:00:00";
            int FormasWeb1 = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "WEB 1"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntWeb1.ToString("dd/MM/yyyy"))
                {
                    if (WEB1 != "")
                    {
                        WEB1 = WEB1 + "</tbody></table>";
                        WEB1 = WEB1 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosWeb1.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasWeb1.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasWeb1 + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                        pliegosWeb1 = 0;
                        FormasWeb1 = 0;
                        horasWeb1 = "00:00:00";
                    }
                    else
                    {
                        WEB1 = WEB1 + "<h2>WEB 1</h2>";
                    }
                    WEB1 = WEB1 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr  style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntWeb1 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosWeb1 = pliegosWeb1 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasWeb1 = FormasWeb1 + Convert.ToInt32(ip.NroForma);
                    horasWeb1 = (TimeSpan.Parse(horasWeb1) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    WEB1 = WEB1 + "  <tr  style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntWeb1 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosWeb1 = pliegosWeb1 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasWeb1 = FormasWeb1 + Convert.ToInt32(ip.NroForma);
                    horasWeb1 = (TimeSpan.Parse(horasWeb1) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (WEB1 == "")
            {
                WEB1 = "";
            }
            else
            {
                WEB1 = WEB1 + "</tbody></table>";
                WEB1 = WEB1 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosWeb1.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasWeb1.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasWeb1 + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegosWeb1 = 0;
                FormasWeb1 = 0;
                horasWeb1 = "00:00:00";
            }



            /////////////////////////////////////////////// M600M600M600M600M600M600M600///////////////////////////////////////////////////////////////////////////
            DateTime fecAntM600 = Convert.ToDateTime("1900-01-01");
            int pliegosM600 = 0;
            string horasM600 = "00:00:00";
            int FormasM600 = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "M600"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntM600.ToString("dd/MM/yyyy"))
                {
                    if (M600 != "")
                    {
                        M600 = M600 + "</tbody></table>";
                        M600 = M600 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosM600.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasM600.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasM600 + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                        pliegosM600 = 0;
                        FormasM600 = 0;
                        horasM600 = "00:00:00";
                    }
                    else
                    {
                        M600 = M600 + "<h2>M-600</h2>";
                    }
                    M600 = M600 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntM600 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosM600 = pliegosM600 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasM600 = FormasM600 + Convert.ToInt32(ip.NroForma);
                    horasM600 = (TimeSpan.Parse(horasM600) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    M600 = M600 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntM600 = Convert.ToDateTime(ip.FechaInicio);
                    pliegosM600 = pliegosM600 + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasM600 = FormasM600 + Convert.ToInt32(ip.NroForma);
                    horasM600 = (TimeSpan.Parse(horasM600) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (M600 == "")
            {
                M600 = "";
            }
            else
            {
                M600 = M600 + "</tbody></table>";
                M600 = M600 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosM600.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasM600.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasM600 + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegosM600 = 0;
                FormasM600 = 0;
                horasM600 = "00:00:00";
            }



            /////////////////////////////////////////////// GOSSGOSSGOSSGOSSGOSSGOSSGOSSGOSS///////////////////////////////////////////////////////////////////////////
            DateTime fecAntGOSS = Convert.ToDateTime("1900-01-01");
            int pliegosGOSS = 0;
            string horasGOSS = "00:00:00";
            int FormasGOSS = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "GOSS C150"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntGOSS.ToString("dd/MM/yyyy"))
                {
                    if (GOSS != "")
                    {
                        GOSS = GOSS + "</tbody></table>";
                        GOSS = GOSS + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosGOSS.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasGOSS.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasGOSS + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                        pliegosGOSS = 0;
                        FormasGOSS = 0;
                        horasGOSS = "00:00:00";
                    }
                    else
                    {
                        GOSS = GOSS + "<h2>GOSS</h2>";
                    }
                    GOSS = GOSS + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntGOSS = Convert.ToDateTime(ip.FechaInicio);
                    pliegosGOSS = pliegosGOSS + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasGOSS = FormasGOSS + Convert.ToInt32(ip.NroForma);
                    horasGOSS = (TimeSpan.Parse(horasGOSS) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    GOSS = GOSS + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntGOSS = Convert.ToDateTime(ip.FechaInicio);
                    pliegosGOSS = pliegosGOSS + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasGOSS = FormasGOSS + Convert.ToInt32(ip.NroForma);
                    horasGOSS = (TimeSpan.Parse(horasGOSS) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (GOSS == "")
            {
                GOSS = "";
            }
            else
            {
                GOSS = GOSS + "</tbody></table>";
                GOSS = GOSS + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosGOSS.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasGOSS.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasGOSS + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegosGOSS = 0;
                FormasGOSS = 0;
                horasGOSS = "00:00:00";
            }

            /////////////////////////////////////////////// 10p10p10p10p10p10p10p10p10p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt10p = Convert.ToDateTime("1900-01-01");
            int pliegos10P = 0;
            string horas10P = "00:00:00";
            int Formas10P = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "10P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt10p.ToString("dd/MM/yyyy"))
                {
                    if (p10 != "")
                    {
                        p10 = p10 + "</tbody></table>";
                        p10 = p10 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegos10P.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horas10P.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + Formas10P + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                        pliegos10P = 0;
                        Formas10P = 0;
                        horas10P = "00:00:00";
                    }
                    else
                    {
                        p10 = p10 + "<h2>10P</h2>";
                    }
                    p10 = p10 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt10p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos10P = pliegos10P + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas10P = Formas10P + Convert.ToInt32(ip.NroForma);
                    horas10P = (TimeSpan.Parse(horas10P) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    p10 = p10 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt10p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos10P = pliegos10P + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas10P = Formas10P + Convert.ToInt32(ip.NroForma);
                    horas10P = (TimeSpan.Parse(horas10P) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (p10 == "")
            {
                p10 = "";
            }
            else
            {
                p10 = p10 + "</tbody></table>";
                p10 = p10 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegos10P.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horas10P.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + Formas10P + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegos10P = 0;
                Formas10P = 0;
                horas10P = "00:00:00";
            }


            /////////////////////////////////////////////// 8p8p8p8p8p8p8p8p8p8p8p8p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt8p = Convert.ToDateTime("1900-01-01");
            int pliegos8P = 0;
            string horas8P = "00:00:00";
            int Formas8P = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "8P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt8p.ToString("dd/MM/yyyy"))
                {
                    if (p8 != "")
                    {
                        p8 = p8 + "</tbody></table>";
                        p8 = p8 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegos8P.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horas8P.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + Formas8P + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                        pliegos8P = 0;
                        Formas8P = 0;
                        horas8P = "00:00:00";
                    }
                    else
                    {
                        p8 = p8 + "<h2>8P</h2>";
                    }
                    p8 = p8 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt8p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos8P = pliegos8P + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas8P = Formas8P + Convert.ToInt32(ip.NroForma);
                    horas8P = (TimeSpan.Parse(horas8P) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    p8 = p8 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt8p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos8P = pliegos8P + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas8P = Formas8P + Convert.ToInt32(ip.NroForma);
                    horas8P = (TimeSpan.Parse(horas8P) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (p8 == "")
            {
                p8 = "";
            }
            else
            {
                p8 = p8 + "</tbody></table>";
                p8 = p8 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegos8P.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horas8P.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + Formas8P + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegos8P = 0;
                Formas8P = 0;
                horas8P = "00:00:00";
            }

            /////////////////////////////////////////////// 4p4p4p4p4p4p4p4p4p4p4p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt4p = Convert.ToDateTime("1900-01-01");
            int pliegos4p = 0;
            string horas4p = "00:00:00";
            int Formas4p = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "4P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt4p.ToString("dd/MM/yyyy"))
                {
                    if (p4 != "")
                    {
                        p4 = p4 + "</tbody></table>";
                        p4 = p4 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegos4p.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horas4p.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + Formas4p + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                        pliegos4p = 0;
                        Formas4p = 0;
                        horas4p = "00:00:00";
                    }
                    else
                    {
                        p4 = p4 + "<h2>4P</h2>";
                    }
                    p4 = p4 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt4p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos4p = pliegos4p + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas4p = Formas4p + Convert.ToInt32(ip.NroForma);
                    horas4p = (TimeSpan.Parse(horas4p) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    p4 = p4 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt4p = Convert.ToDateTime(ip.FechaInicio);
                    pliegos4p = pliegos4p + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    Formas4p = Formas4p + Convert.ToInt32(ip.NroForma);
                    horas4p = (TimeSpan.Parse(horas4p) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (p4 == "")
            {
                p4 = "";
            }
            else
            {
                p4 = p4 + "</tbody></table>";
                p4 = p4 + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegos4p.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horas4p.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + Formas4p + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegos4p = 0;
                Formas4p = 0;
                horas4p = "00:00:00";
            }


            ///////////////////////////////////////////////CDCDCDCDCDCDCDCD///////////////////////////////////////////////////////////////////////////
            DateTime fecAntCD = Convert.ToDateTime("1900-01-01");
            int pliegosCD = 0;
            string horasCD = "00:00:00";
            int FormasCD = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "CD"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntCD.ToString("dd/MM/yyyy"))
                {
                    if (CD != "")
                    {
                        CD = CD + "</tbody></table>";
                        CD = CD + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosCD.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasCD.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasCD + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                        pliegosCD = 0;
                        FormasCD = 0;
                        horasCD = "00:00:00";
                    }
                    else
                    {
                        CD = CD + "<h2>CD</h2>";
                    }
                    CD = CD + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntCD = Convert.ToDateTime(ip.FechaInicio);
                    pliegosCD = pliegosCD + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasCD = FormasCD + Convert.ToInt32(ip.NroForma);
                    horasCD = (TimeSpan.Parse(horasCD) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    CD = CD + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntCD = Convert.ToDateTime(ip.FechaInicio);
                    pliegosCD = pliegosCD + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasCD = FormasCD + Convert.ToInt32(ip.NroForma);
                    horasCD = (TimeSpan.Parse(horasCD) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (CD == "")
            {
                CD = "";
            }
            else
            {
                CD = CD + "</tbody></table>";
                CD = CD + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosCD.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:90px;'>" + horasCD.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasCD + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegosCD = 0;
                FormasCD = 0;
                horasCD = "00:00:00";
            }


            ///////////////////////////////////////////////xlxlxllxlxlxllxlxlxlxlx///////////////////////////////////////////////////////////////////////////
            DateTime fecAntXL = Convert.ToDateTime("1900-01-01");
            int pliegosXL = 0;
            string horasXL = "00:00:00";
            int FormasXL = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "XL"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntXL.ToString("dd/MM/yyyy"))
                {
                    if (XL != "")
                    {
                        XL = XL + "</tbody></table>";
                        XL = XL + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosXL.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasXL.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasXL + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                        FormasXL = 0;
                        FormasXL = 0;
                        horasXL = "00:00:00";
                    }
                    else
                    {
                        XL = XL + "<h2>XL</h2>";
                    }
                    XL = XL + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntXL = Convert.ToDateTime(ip.FechaInicio);
                    pliegosXL = pliegosXL + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasXL = FormasXL + Convert.ToInt32(ip.NroForma);
                    horasXL = (TimeSpan.Parse(horasXL) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    XL = XL + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntXL = Convert.ToDateTime(ip.FechaInicio);
                    pliegosXL = pliegosXL + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasXL = FormasXL + Convert.ToInt32(ip.NroForma);
                    horasXL = (TimeSpan.Parse(horasXL) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (XL == "")
            {
                XL = "";
            }
            else
            {
                XL = XL + "</tbody></table>";
                XL = XL + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosXL.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasXL.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasXL + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegosXL = 0;
                FormasXL = 0;
                horasXL = "00:00:00";
            }


            ///////////////////////////////////////////////KBA///////////////////////////////////////////////////////////////////////////
            DateTime fecAntKBA = Convert.ToDateTime("1900-01-01");
            int pliegosKBA = 0;
            string horasKBA = "00:00:00";
            int FormasKBA = 0;
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "KBA Rapida 106"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntKBA.ToString("dd/MM/yyyy"))
                {
                    if (KBA != "")
                    {
                        KBA = KBA + "</tbody></table>";
                        KBA = KBA + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosXL.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasXL.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasXL + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                        FormasKBA = 0;
                        FormasKBA = 0;
                        horasKBA = "00:00:00";
                    }
                    else
                    {
                        KBA = KBA + "<h2>KBA</h2>";
                    }
                    KBA = KBA + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntKBA = Convert.ToDateTime(ip.FechaInicio);
                    pliegosKBA = pliegosKBA + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasKBA = FormasKBA + Convert.ToInt32(ip.NroForma);
                    horasKBA = (TimeSpan.Parse(horasKBA) + TimeSpan.Parse(ip.Horas)).ToString();
                }
                else
                {
                    KBA = KBA + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntKBA = Convert.ToDateTime(ip.FechaInicio);
                    pliegosKBA = pliegosKBA + Convert.ToInt32(ip.Pliegos.Replace(".", ""));
                    FormasKBA = FormasKBA + Convert.ToInt32(ip.NroForma);
                    horasKBA = (TimeSpan.Parse(horasKBA) + TimeSpan.Parse(ip.Horas)).ToString();
                }

            }
            if (KBA == "")
            {
                KBA = "";
            }
            else
            {
                KBA = KBA + "</tbody></table>";
                KBA = KBA + "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
"<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
"<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>TOTAL</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;text-align: right;'>" + pliegosKBA.ToString("N0").Replace(",", ".") + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" + horasKBA.ToString() + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;text-align: right;'>" + FormasKBA + "</td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'></td>" +
"<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
"</tr></tbody></table>";
                pliegosKBA = 0;
                FormasKBA = 0;
                horasKBA = "00:00:00";
            }

            return LITHOMAN + WEB1 + M600 + GOSS + p10 + p8 + p4 + CD + XL+ KBA;
        }








        public string Carga_PapelesOT(string OT)
        {

            string Titulo = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1090px;margin-left:15px;'>" +
                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>Nombre Componente</td>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Pliego</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Papel</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Ancho (Bobina)</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Largo</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Grs</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Formato Immpresión</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Consumo KGs</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Consumo PLs</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Colores</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>Páginas</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Barniz</td>" +
                "</tr>";
            string RackLibre = "";
            string OTa = "";
            string barniz = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {

                cmd.CommandText = "[Seguimiento_InformeProduccion_PapelesOT]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();

                string v1 = "";
                string v2 = "";
                while (reader.Read())
                {
                    if (reader["Barniz"].ToString() == "AB")
                    {
                        barniz = "Acuoso Brillante";
                    }
                    else if (reader["Barniz"].ToString() == "AB C/R")
                    {
                        barniz = "Acuoso Brillante C/Reserva";
                    }
                    else if (reader["Barniz"].ToString() == "AO")
                    {
                        barniz = "Acuoso Opaco";
                    }
                    else if (reader["Barniz"].ToString() == "AO C/R")
                    {
                        barniz = "Acuoso Opaco C/Reserva";
                    }
                    else if (reader["Barniz"].ToString() == "ASM")
                    {
                        barniz = "Acuoso Semi-Brillo";
                    }
                    else if (reader["Barniz"].ToString() == "ASB C/R")
                    {
                        barniz = "Acuoso Semi-Brillo C/Reserva";
                    }
                    else if (reader["Barniz"].ToString() == "OB")
                    {
                        barniz = "Oleoso Brillante";
                    }
                    else if (reader["Barniz"].ToString() == "OO")
                    {
                        barniz = "Oleoso Opaco";
                    }
                    else
                    {
                        barniz = reader["Barniz"].ToString();
                    }



                    string a = reader["OT"].ToString();
                    if (OTa != reader["OT"].ToString())
                    {
                        if (RackLibre != "")
                        {
                            RackLibre = RackLibre + "</tbody></table>";
                        }

                        try
                        {
                            string[] str = reader["FormatoPapel"].ToString().Split('x');
                            v1 = str[0];
                            v2 = str[1];
                        }
                        catch
                        {
                            v1 = reader["FormatoPapel"].ToString();
                            v2 = "";
                        }
                        string Estado = "";
                        if (reader["EstadoOT"].ToString() == "E")
                        {
                            Estado = "<label style='color:Green'>Liquidada</label>";
                        }
                        else
                        {
                            Estado = "<label style='color:Blue'>En Proceso</label>";
                        }


                        string vv = reader["ConsumoKG"].ToString();
                        string v = reader["ConsumoPL"].ToString();
                        RackLibre = RackLibre + "<div align='center'><strong>OT:&nbsp" + reader["OT"].ToString() + "&nbsp;&nbsp;-&nbsp;&nbsp;" + reader["NombreOT"].ToString() + "</strong></br><strong>Estado:</strong> " + Estado + "</div>" + Titulo +
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:130px;'>" +
                               reader["Description"].ToString().Replace("IMP", "").Replace("PLANA", "").Replace("ROTATIVA", "") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                               reader["Pliegos"].ToString().Replace(".", "") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                               reader["NombrePapel"].ToString() + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            v1 + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                            v2 + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                            reader["Gramaje"].ToString() + "</td>" +

                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                            reader["Ancho"].ToString() + "x" + reader["Alto"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            Convert.ToInt32(reader["ConsumoKG"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            Convert.ToInt32(reader["ConsumoPL"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                            reader["Colores"].ToString() + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                             reader["Paginas"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                             barniz + "</td>" +
                          "</tr>";
                    }
                    else
                    {
                        try
                        {
                            string[] str = reader["FormatoPapel"].ToString().Split('x');
                            v1 = str[0];
                            v2 = str[1];
                        }
                        catch
                        {
                            v1 = reader["FormatoPapel"].ToString();
                            v2 = "";
                        }
                        RackLibre = RackLibre +
                            "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:130px;'>" +
                               reader["Description"].ToString().Replace("IMP", "").Replace("PLANA", "").Replace("ROTATIVA", "") + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                             reader["Pliegos"].ToString().Replace(".", "") + "</td>" +

                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                               reader["NombrePapel"].ToString() + "</td>" +
                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                           v1 + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                            v2 + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>" +
                            reader["Gramaje"].ToString() + "</td>" +

                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                            reader["Ancho"].ToString() + "x" + reader["Alto"].ToString() + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            Convert.ToInt32(reader["ConsumoKG"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                            Convert.ToInt32(reader["ConsumoPL"].ToString()).ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                            reader["Colores"].ToString() + "</td>" +

                             "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:50px;'>" +
                             reader["Paginas"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                            barniz + "</td>" +
                          "</tr>";
                    }
                    OTa = reader["OT"].ToString();


                }
                RackLibre = RackLibre + "</tbody></table>";
            }
            con.CerrarConexion();
            return RackLibre;
        }





        public string Carga_Programacion2(string Seccion, string Maquina, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            DateTime fecAntLitho = Convert.ToDateTime("1900-01-01");
            CultureInfo espanol = new CultureInfo("es-ES");
            string encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>OT</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Nombre OT</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Pliego</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Cant. Pliegos</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>Hora Inicio</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>Hora Termino</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Horas</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>V.B</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
                "</tr>";
            string LITHOMAN = "";
            string WEB1 = "";
            string M600 = "";
            string GOSS = "";
            string p10 = "";
            string p8 = "";
            string p4 = "";
            string CD = "";
            string XL = "";
            string KBA = "";
            List<InformeProgramacion> lista = Lista_ProgramaProduccion2(Seccion, Maquina, Fechainicio, FechaTermino, Procedimiento);
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "LITHOMAN"))
            {

                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntLitho.ToString("dd/MM/yyyy"))
                {
                    if (LITHOMAN != "")
                    {
                        LITHOMAN = LITHOMAN + "</tbody></table>";
                    }
                    else
                    {
                        LITHOMAN = LITHOMAN + "<h2>LITHOMAN</h2>";
                    }
                    LITHOMAN = LITHOMAN + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntLitho = Convert.ToDateTime(ip.FechaInicio);



                }
                else
                {
                    LITHOMAN = LITHOMAN + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntLitho = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (LITHOMAN != "")
            {
                LITHOMAN = LITHOMAN + "</tbody></table>";
            }
            /////////////////////////////////////////////// web1///////////////////////////////////////////////////////////////////////////
            DateTime fecAntWeb1 = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "WEB 1"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntWeb1.ToString("dd/MM/yyyy"))
                {
                    if (WEB1 != "")
                    {
                        WEB1 = WEB1 + "</tbody></table>";
                    }
                    else
                    {
                        WEB1 = WEB1 + "<h2>WEB 1</h2>";
                    }
                    WEB1 = WEB1 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr  style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntWeb1 = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    WEB1 = WEB1 + "  <tr  style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntWeb1 = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (WEB1 == "")
            {
                WEB1 = "";
            }
            else
            {
                WEB1 = WEB1 + "</tbody></table>";
            }



            /////////////////////////////////////////////// M600M600M600M600M600M600M600///////////////////////////////////////////////////////////////////////////
            DateTime fecAntM600 = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "M600"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntM600.ToString("dd/MM/yyyy"))
                {
                    if (M600 != "")
                    {
                        M600 = M600 + "</tbody></table>";
                    }
                    else
                    {
                        M600 = M600 + "<h2>M-600</h2>";
                    }
                    M600 = M600 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntM600 = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    M600 = M600 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntM600 = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (M600 == "")
            {
                M600 = "";
            }
            else
            {
                M600 = M600 + "</tbody></table>";
            }



            /////////////////////////////////////////////// GOSSGOSSGOSSGOSSGOSSGOSSGOSSGOSS///////////////////////////////////////////////////////////////////////////
            DateTime fecAntGOSS = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "GOSS C150"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntGOSS.ToString("dd/MM/yyyy"))
                {
                    if (GOSS != "")
                    {
                        GOSS = GOSS + "</tbody></table>";
                    }
                    else
                    {
                        GOSS = GOSS + "<h2>GOSS</h2>";
                    }
                    GOSS = GOSS + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntGOSS = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    GOSS = GOSS + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntGOSS = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (GOSS == "")
            {
                GOSS = "";
            }
            else
            {
                GOSS = GOSS + "</tbody></table>";
            }

            /////////////////////////////////////////////// 10p10p10p10p10p10p10p10p10p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt10p = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "10P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt10p.ToString("dd/MM/yyyy"))
                {
                    if (p10 != "")
                    {
                        p10 = p10 + "</tbody></table>";
                    }
                    else
                    {
                        p10 = p10 + "<h2>10P</h2>";
                    }
                    p10 = p10 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt10p = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    p10 = p10 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt10p = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (p10 == "")
            {
                p10 = "";
            }
            else
            {
                p10 = p10 + "</tbody></table>";
            }


            /////////////////////////////////////////////// 8p8p8p8p8p8p8p8p8p8p8p8p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt8p = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "8P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt8p.ToString("dd/MM/yyyy"))
                {
                    if (p8 != "")
                    {
                        p8 = p8 + "</tbody></table>";
                    }
                    else
                    {
                        p8 = p8 + "<h2>8P</h2>";
                    }
                    p8 = p8 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt8p = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    p8 = p8 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt8p = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (p8 == "")
            {
                p8 = "";
            }
            else
            {
                p8 = p8 + "</tbody></table>";
            }

            /////////////////////////////////////////////// 4p4p4p4p4p4p4p4p4p4p4p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt4p = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "4P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt4p.ToString("dd/MM/yyyy"))
                {
                    if (p4 != "")
                    {
                        p4 = p4 + "</tbody></table>";
                    }
                    else
                    {
                        p4 = p4 + "<h2>4P</h2>";
                    }
                    p4 = p4 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt4p = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    p4 = p4 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt4p = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (p4 == "")
            {
                p4 = "";
            }
            else
            {
                p4 = p4 + "</tbody></table>";
            }


            ///////////////////////////////////////////////CDCDCDCDCDCDCDCD///////////////////////////////////////////////////////////////////////////
            DateTime fecAntCD = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "CD"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntCD.ToString("dd/MM/yyyy"))
                {
                    if (CD != "")
                    {
                        CD = CD + "</tbody></table>";
                    }
                    else
                    {
                        CD = CD + "<h2>CD</h2>";
                    }
                    CD = CD + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntCD = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    CD = CD + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntCD = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (CD == "")
            {
                CD = "";
            }
            else
            {
                CD = CD + "</tbody></table>";
            }


            ///////////////////////////////////////////////xlxlxllxlxlxllxlxlxlxlx///////////////////////////////////////////////////////////////////////////
            DateTime fecAntXL = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "XL"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntXL.ToString("dd/MM/yyyy"))
                {
                    if (XL != "")
                    {
                        XL = XL + "</tbody></table>";
                    }
                    else
                    {
                        XL = XL + "<h2>XL</h2>";
                    }
                    XL = XL + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntXL = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    XL = XL + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntXL = Convert.ToDateTime(ip.FechaInicio);


                }

            }
            if (XL == "")
            {
                XL = "";
            }
            else
            {
                XL = XL + "</tbody></table>";
            }

            ///////////////////////////////////////////////KBA///////////////////////////////////////////////////////////////////////////
            DateTime fecAntKBA = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "KBA Rapida 106"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntKBA.ToString("dd/MM/yyyy"))
                {
                    if (KBA != "")
                    {
                        KBA = KBA + "</tbody></table>";
                    }
                    else
                    {
                        KBA = KBA + "<h2>KBA</h2>";
                    }
                    KBA = KBA + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntKBA = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    KBA = KBA + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntKBA = Convert.ToDateTime(ip.FechaInicio);


                }

            }
            if (KBA == "")
            {
                KBA = "";
            }
            else
            {
                KBA = KBA + "</tbody></table>";
            }

            return LITHOMAN + WEB1 + M600 + GOSS + p10 + p8 + p4 + CD + XL+KBA;
        }




        //  INICIO GENERAL



        public string Carga_ProgramacionInfGeneral(string Seccion, string Maquina, DateTime Fechainicio, DateTime FechaTermino, int Procedimiento)
        {
            DateTime fecAntLitho = Convert.ToDateTime("1900-01-01");
            CultureInfo espanol = new CultureInfo("es-ES");
            string encabezado = "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:880px;margin-left:15px;'>" +
                "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>OT</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;'>Nombre OT</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Componente</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Cant. Pliegos</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>Hora Inicio</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>Hora Termino</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>Horas</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>V.B</td>" +
                "<td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'></td>" +
                "</tr>";
            string LITHOMAN = "";
            string WEB1 = "";
            string WEB2 = "";
            string M600 = "";
            string GOSS = "";
            string p10 = "";
            string p8 = "";
            string p4 = "";
            string CD = "";
            string XL = "";
            string KBA = "";
            List<InformeProgramacion> lista = Lista_ProgramaProduccionInfoGeneral(Seccion, Maquina, Fechainicio, FechaTermino, Procedimiento);
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "LITHOMAN"))
            {

                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntLitho.ToString("dd/MM/yyyy"))
                {
                    if (LITHOMAN != "")
                    {
                        LITHOMAN = LITHOMAN + "</tbody></table>";
                    }
                    else
                    {
                        LITHOMAN = LITHOMAN + "<h2>LITHOMAN</h2>";
                    }
                    LITHOMAN = LITHOMAN + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntLitho = Convert.ToDateTime(ip.FechaInicio);



                }
                else
                {

                    //if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != Convert.ToDateTime(ip.FechaTermino).ToString("dd/MM/yyyy"))
                    //{
                    //    InformeProgramacion pro = new InformeProgramacion();
                    //    pro.OT = ip.OT;
                    //    pro.NombreOT = ip.NombreOT;
                    //    pro.Maquina = ip.Maquina;

                    //    pro.NroForma = ip.NroForma;

                    //    pro.FechaInicio = ip.FechaInicio;
                    //    pro.FechaTermino = ip.FechaTermino;
                    //    pro.Pliegos = ip.Pliegos;
                    //    TimeSpan time;
                    //    time = (Convert.ToDateTime(ip.FechaInicio.ToString()) - Convert.ToDateTime(ip.FechaTermino.ToString()));
                    //    pro.Horas = time.ToString();
                    //    pro.VBdet = ip.VB;
                    //    if (ip.VB.ToString() != "")
                    //    {
                    //        pro.VB = "<div style='color:Green;' title='" + ip.VB.ToString() + "'>SI</div>";
                    //    }
                    //    else
                    //    {
                    //        pro.VB = "<div style='color:Red;'>NO</div>";
                    //    }

                    //    lista.Add(pro);
                    //}


                    LITHOMAN = LITHOMAN + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntLitho = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (LITHOMAN != "")
            {
                LITHOMAN = LITHOMAN + "</tbody></table>";
            }
            /////////////////////////////////////////////// web1///////////////////////////////////////////////////////////////////////////
            DateTime fecAntWeb1 = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "WEB 1"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntWeb1.ToString("dd/MM/yyyy"))
                {
                    if (WEB1 != "")
                    {
                        WEB1 = WEB1 + "</tbody></table>";
                    }
                    else
                    {
                        WEB1 = WEB1 + "<h2>WEB 1</h2>";
                    }
                    WEB1 = WEB1 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr  style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntWeb1 = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    WEB1 = WEB1 + "  <tr  style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntWeb1 = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (WEB1 == "")
            {
                WEB1 = "";
            }
            else
            {
                WEB1 = WEB1 + "</tbody></table>";
            }

            /////////////////////////////////////////////// web2///////////////////////////////////////////////////////////////////////////
            DateTime fecAntWeb2 = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "WEB 2"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntWeb2.ToString("dd/MM/yyyy"))
                {
                    if (WEB2 != "")
                    {
                        WEB2 = WEB2 + "</tbody></table>";
                    }
                    else
                    {
                        WEB2 = WEB2 + "<h2>WEB 2</h2>";
                    }
                    WEB2 = WEB2 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr  style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntWeb2 = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    WEB2 = WEB2 + "  <tr  style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntWeb2 = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (WEB2 == "")
            {
                WEB2 = "";
            }
            else
            {
                WEB2 = WEB2 + "</tbody></table>";
            }

            /////////////////////////////////////////////// M600M600M600M600M600M600M600///////////////////////////////////////////////////////////////////////////
            DateTime fecAntM600 = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "M600"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntM600.ToString("dd/MM/yyyy"))
                {
                    if (M600 != "")
                    {
                        M600 = M600 + "</tbody></table>";
                    }
                    else
                    {
                        M600 = M600 + "<h2>M-600</h2>";
                    }
                    M600 = M600 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntM600 = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    M600 = M600 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntM600 = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (M600 == "")
            {
                M600 = "";
            }
            else
            {
                M600 = M600 + "</tbody></table>";
            }



            /////////////////////////////////////////////// GOSSGOSSGOSSGOSSGOSSGOSSGOSSGOSS///////////////////////////////////////////////////////////////////////////
            DateTime fecAntGOSS = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "GOSS C150"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntGOSS.ToString("dd/MM/yyyy"))
                {
                    if (GOSS != "")
                    {
                        GOSS = GOSS + "</tbody></table>";
                    }
                    else
                    {
                        GOSS = GOSS + "<h2>GOSS</h2>";
                    }
                    GOSS = GOSS + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntGOSS = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    GOSS = GOSS + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntGOSS = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (GOSS == "")
            {
                GOSS = "";
            }
            else
            {
                GOSS = GOSS + "</tbody></table>";
            }

            /////////////////////////////////////////////// 10p10p10p10p10p10p10p10p10p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt10p = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "10P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt10p.ToString("dd/MM/yyyy"))
                {
                    if (p10 != "")
                    {
                        p10 = p10 + "</tbody></table>";
                    }
                    else
                    {
                        p10 = p10 + "<h2>10P</h2>";
                    }
                    p10 = p10 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt10p = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    p10 = p10 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt10p = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (p10 == "")
            {
                p10 = "";
            }
            else
            {
                p10 = p10 + "</tbody></table>";
            }


            /////////////////////////////////////////////// 8p8p8p8p8p8p8p8p8p8p8p8p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt8p = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "8P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt8p.ToString("dd/MM/yyyy"))
                {
                    if (p8 != "")
                    {
                        p8 = p8 + "</tbody></table>";
                    }
                    else
                    {
                        p8 = p8 + "<h2>8P</h2>";
                    }
                    p8 = p8 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt8p = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    p8 = p8 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt8p = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (p8 == "")
            {
                p8 = "";
            }
            else
            {
                p8 = p8 + "</tbody></table>";
            }

            /////////////////////////////////////////////// 4p4p4p4p4p4p4p4p4p4p4p///////////////////////////////////////////////////////////////////////////
            DateTime fecAnt4p = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "4P"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAnt4p.ToString("dd/MM/yyyy"))
                {
                    if (p4 != "")
                    {
                        p4 = p4 + "</tbody></table>";
                    }
                    else
                    {
                        p4 = p4 + "<h2>4P</h2>";
                    }
                    p4 = p4 + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt4p = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    p4 = p4 + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                     "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAnt4p = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (p4 == "")
            {
                p4 = "";
            }
            else
            {
                p4 = p4 + "</tbody></table>";
            }


            ///////////////////////////////////////////////CDCDCDCDCDCDCDCD///////////////////////////////////////////////////////////////////////////
            DateTime fecAntCD = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "CD"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntCD.ToString("dd/MM/yyyy"))
                {
                    if (CD != "")
                    {
                        CD = CD + "</tbody></table>";
                    }
                    else
                    {
                        CD = CD + "<h2>CD</h2>";
                    }
                    CD = CD + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntCD = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    CD = CD + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntCD = Convert.ToDateTime(ip.FechaInicio);
                }

            }
            if (CD == "")
            {
                CD = "";
            }
            else
            {
                CD = CD + "</tbody></table>";
            }


            ///////////////////////////////////////////////xlxlxllxlxlxllxlxlxlxlx///////////////////////////////////////////////////////////////////////////
            DateTime fecAntXL = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "XL"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntXL.ToString("dd/MM/yyyy"))
                {
                    if (XL != "")
                    {
                        XL = XL + "</tbody></table>";
                    }
                    else
                    {
                        XL = XL + "<h2>XL</h2>";
                    }
                    XL = XL + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntXL = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    XL = XL + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntXL = Convert.ToDateTime(ip.FechaInicio);


                }

            }
            if (XL == "")
            {
                XL = "";
            }
            else
            {
                XL = XL + "</tbody></table>";
            }

            ///////////////////////////////////////////////KBA///////////////////////////////////////////////////////////////////////////
            DateTime fecAntKBA = Convert.ToDateTime("1900-01-01");
            foreach (InformeProgramacion ip in lista.Where(o => o.Maquina == "KBA Rapida 106"))
            {
                if (Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy") != fecAntKBA.ToString("dd/MM/yyyy"))
                {
                    if (KBA != "")
                    {
                        KBA = KBA + "</tbody></table>";
                    }
                    else
                    {
                        KBA = KBA + "<h2>KBA</h2>";
                    }
                    KBA = KBA + Convert.ToDateTime(ip.FechaInicio).ToString("dddd d, MMMM", espanol) + encabezado + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntKBA = Convert.ToDateTime(ip.FechaInicio);
                }
                else
                {
                    KBA = KBA + "  <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:45px;'>" +
                     ip.OT + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:250px;'>" +
                     ip.NombreOT.ToLower() + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.NroForma + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                    ip.Pliegos + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    Convert.ToDateTime(ip.FechaInicio).ToString("dd/MM/yyyy HH:mm") + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:130px;'>" +
                    ip.FechaTermino + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    ip.Horas + " </td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:25px;'>" +
                    ip.VB + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;'>" +
                    "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + ip.OT.Trim() + "\")'>Ver Más</a></td>" +
                    "</tr>";
                    fecAntKBA = Convert.ToDateTime(ip.FechaInicio);


                }

            }
            if (KBA == "")
            {
                KBA = "";
            }
            else
            {
                KBA = KBA + "</tbody></table>";
            }

            return LITHOMAN + WEB1 + WEB2 + M600 + GOSS + p10 + p8 + p4 + CD + XL+ KBA;
        }





        public List<InformeProgramacion> Lista_ProgramaProduccion_Imprimir(DateTime Fechainicio, DateTime FechaTermino)
        {
            List<InformeProgramacion> lista = new List<InformeProgramacion>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_Informe_ProgramacionProduccion_Imprimir]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeProgramacion pro = new InformeProgramacion();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString().ToLower();
                    pro.FechaInicio = reader["FechaInicio"].ToString();
                    pro.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    TimeSpan time;
                    time = (Convert.ToDateTime(reader["FechaTermino"].ToString()) - Convert.ToDateTime(reader["FechaInicio"].ToString()));
                    string Hora = "";
                    string Minuto = "";
                    if (time.Hours.ToString().Count() == 1)
                    {
                        Hora = "0" + time.Hours;
                    }
                    else
                    {
                        Hora = time.Hours.ToString();
                    }
                    if (time.Minutes.ToString().Count() == 1)
                    {
                        Minuto = "0" + time.Minutes;
                    }
                    else
                    {
                        Minuto = time.Minutes.ToString();
                    }
                    pro.Horas = Hora + ":" + Minuto;
                    pro.VB = Convert.ToDateTime(reader["FI"].ToString()).ToString("dd/MM/yyyy");
                    pro.Maquina = reader["Maquina"].ToString();
                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }

        public List<InformeProgramacion> Lista_ProgramaProduccion_Imprimir2(DateTime Fechainicio, DateTime FechaTermino, string Seccion, string Maquina)
        {
            List<InformeProgramacion> lista = new List<InformeProgramacion>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Seguimiento_Informe_ProgramacionProduccion_Imprimir]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        InformeProgramacion pro = new InformeProgramacion();
                        pro.OT = reader["OT"].ToString();
                        pro.NombreOT = reader["NombreOT"].ToString().ToLower();
                        pro.Maquina = reader["Maquina"].ToString().Replace("KBA Rapida 106","KBA");
                       // pro.Pliegos = "(" + reader["NumPliego"].ToString() + ")";
                        pro.FechaTermino = reader["CodSetor"].ToString();//Sector
                        if (pro.FechaTermino == "TERCEROS")
                        {
                            pro.VBdet = "Terceros";
                            pro.Pliegos = "(" + reader["NumPliego"].ToString() + ")";
                        }
                        else if (pro.FechaTermino == "IMP DIG")
                        {
                            pro.VBdet = "Digital";
                            pro.Pliegos = "(" + reader["NumPliego"].ToString() + ")";
                        }
                        else if (pro.FechaTermino == "IMP ROT")
                        {
                            pro.VBdet = "Rotativa";
                            pro.Pliegos = "(" + reader["NumPliego"].ToString() + ")";
                        }
                        else if (pro.FechaTermino == "ENCADERN")
                        {
                            pro.VBdet = "Encuadernación";
                            pro.Pliegos = "(" + reader["NumPliego"].ToString() + ")";
                        }
                        else if (pro.FechaTermino == "MANUAL")
                        {
                            pro.VBdet = "Manualidades";
                            pro.Pliegos = "(" + reader["NumPliego"].ToString() + ")";
                        }
                        else
                        {
                            pro.VBdet = "Planas";
                            pro.Pliegos = "(" + reader["NumPliego"].ToString() + ")";
                        }

                        TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["TiempoDif"].ToString()));
                        int Dias1 = t1.Days * 24;
                        string Ceros = "00";
                        pro.Horas = (t1.Hours + Dias1).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString();
                        pro.NroForma = reader["TiempoDif"].ToString();
                        pro.VB = reader["CantPliegos"].ToString();
                        pro.FechaInicio = Convert.ToDateTime(reader["FI"].ToString()).ToString("dd-MM-yyyy");
                        if (Seccion == "Todas")
                        {
                            lista.Add(pro);
                        }
                        else if(Seccion==pro.VBdet)
                        {
                            if (Maquina == "Seleccione...")
                            {
                                lista.Add(pro);
                            }
                            else if (Maquina.ToUpper().Trim() == pro.Maquina.ToUpper().Trim())
                            {
                                lista.Add(pro);
                            }
                        }
                    }
                }
                catch
                {
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
    }
}