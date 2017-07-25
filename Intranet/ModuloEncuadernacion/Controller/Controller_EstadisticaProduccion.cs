using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloEncuadernacion.Model;
using System.Data.SqlClient;
using System.Globalization;

namespace Intranet.ModuloEncuadernacion.Controller
{
    public class Controller_EstadisticaProduccion
    {
        public string EncabezadoMaquina(string Nombre)
        {
            return "<table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; margin-left:3px;width:98%;'> " +
          "<tbody><tr style='height: 15px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;font-size:13px;'colspan='25'>  " +
                Nombre + " </td></tr> " +
            "<tr style='height: 20px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='15'>  " +
                "Horas  </td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='10'>  " +
                "Produccion  </td>" +
                "</tr> " +
              "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Mes</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "OT<br /> Trabajadas</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Entradas</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Preparacion</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Promedio<br />" +
                "Preparacion</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Produccion</td> " +
           " <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Improd OT</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Improd</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "S/Carga</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Esp. Mat.<br />" +
                "Impresion</td>  " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Total<br />" +
                "Horas</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Horas<br />" +
                "Produciendo</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Sin" +
                "<br />" +
                "Carga</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Horas<br /> Sin Producir</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
              "  Esp. Mat.<br />" +
                "Impresion</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Buenos</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Tiraje<br />" +
                "Promedio</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Buenos<br />" +
                "Anual</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Merma<br /> Tiraje</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Merma<br />" +
                "Preparación</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Malos c/r Buenos</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Promedio<br />Personal</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Velocidad</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Rend(PP)</td> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                "Rend<br />" +
                "(Impro)</td> " +
          "</tr>";
        }
        public string ListarRegistro(int MesInicialTrimestre, int MesTerminoTrimestre,int Año,string Maquina, int Procedimiento)
        {
            Conexion con = new Conexion(); string ceros = "00"; string resultado = ""; string MaquinaAnt = "";
            double OTS = 0; double TotalOts = 0; double Entradas = 0; double TotalEntradas = 0; string Preparacion = ""; string TotalPreparacion = ""; string PromedioPrep = "" ; double promPrep = 0; double TotalPromPrep = 0; string Produccion = ""; string ImpOT = ""; string Imp = ""; string sCarga = ""; string EMaterial = ""; string HTotal = ""; double HorasTiraje = 0; double TotalHorasTiraje = 0; double ImprodOT = 0; double TotalImprodOT = 0;
            double TotalHPrep = 0; double Improd = 0; double TotalImprod = 0; double sinCarga = 0; double TotalSincarga = 0; double EspMaterial = 0; double TotalEspMaterial = 0; double TotalHoras = 0; double TotalTotalHoras = 0; string PorcHorasTiraje = ""; string TirajeProm = ""; string RendPP = ""; string RendImpro = "";
            string porcTotalHorasTiraje = ""; string porcSinCarga = ""; string TotalPorcSinCarga = ""; string porcSinProducir = ""; string TotalPorcSinProducir = ""; string PorcEsperaMaterial = ""; string TotalPorcEsperaMaterial = ""; string Velocidad = ""; string BuenosAnual = "";
            double Buenos = 0; double TotalBuenos = 0; double PorcBuenosAnual = 0; double TotalPorcBuenosAnual = 0; double MalosPrep = 0; double MalosTiraje = 0 ; double TotalMalosPrep = 0;double TotalMalosTiraje=0; string PorcMalosvsBuenos = ""; string TotalPorcMalosVsBuenos = "";
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "ENC_InformeProduccion";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MesInicialTrimestre", MesInicialTrimestre);
                    cmd.Parameters.AddWithValue("@MesTerminoTrimestre", MesTerminoTrimestre);
                    cmd.Parameters.AddWithValue("@Año", Año);
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (MaquinaAnt == "" || MaquinaAnt == reader["Maquina"].ToString())
                        {
                            if (MaquinaAnt == "")
                            {
                                resultado += EncabezadoMaquina(reader["Maquina"].ToString() + " - " + reader["CodRecurso"].ToString());
                            }
                            OTS = Convert.ToDouble(reader["OTsTrabajadas"].ToString());
                            Entradas = Convert.ToDouble(reader["Entradas"].ToString());
                            #region Horas
                            TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPrep"].ToString()));
                            int Dias1 = t1.Days * 24;
                            Preparacion = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                            int Dias2 = t2.Days * 24;
                            Produccion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                            TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivasOT"].ToString()));
                            int Dias3 = t3.Days * 24;
                            ImpOT = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                            TimeSpan t4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                            int Dias4 = t4.Days * 24;
                            Imp = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();

                            TimeSpan t5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinCarga"].ToString()));
                            int Dias5 = t5.Days * 24;
                            sCarga = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                            TimeSpan t6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasEsperaMaterial"].ToString()));
                            int Dias6 = t6.Days * 24;
                            EMaterial = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                            TimeSpan t7 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTotal"].ToString()));
                            int Dias7 = t7.Days * 24;
                            HTotal = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                            TimeSpan t8 = TimeSpan.FromSeconds((Convert.ToDouble(reader["HorasPrep"].ToString())) / (Entradas > 0 ? Entradas : 1));
                            int Dias8 = t8.Days * 24;
                            PromedioPrep = (t8.Hours + Dias8).ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Minutes.ToString().Length) + t8.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Seconds.ToString().Length) + t8.Seconds.ToString();
                            #endregion
                            Buenos = Convert.ToDouble(reader["Buenos"].ToString());
                            MalosPrep = Convert.ToDouble(reader["MalosPreparacion"].ToString());
                            MalosTiraje = Convert.ToDouble(reader["MalosTiraje"].ToString());

                            PorcHorasTiraje = (((Convert.ToDouble(reader["HorasPrep"].ToString()) + Convert.ToDouble(reader["HorasTiraje"].ToString())) / (Convert.ToDouble(reader["HorasTotal"].ToString()) > 0 ? Convert.ToDouble(reader["HorasTotal"].ToString()) : 1)) * 100).ToString("N2") + "%";
                            porcSinCarga = (((Convert.ToDouble(reader["HorasSinCarga"].ToString())) / (Convert.ToDouble(reader["HorasTotal"].ToString()) > 0 ? Convert.ToDouble(reader["HorasTotal"].ToString()) : 1)) * 100).ToString("N2") + "%";
                            porcSinProducir = (((Convert.ToDouble(reader["HorasImproductivasOT"].ToString()) + Convert.ToDouble(reader["HorasImproductivas"].ToString())) / (Convert.ToDouble(reader["HorasTotal"].ToString()) > 0 ? Convert.ToDouble(reader["HorasTotal"].ToString()) : 1)) * 100).ToString("N2") + "%";
                            PorcEsperaMaterial = (((Convert.ToDouble(reader["HorasEsperaMaterial"].ToString())) / (Convert.ToDouble(reader["HorasTotal"].ToString()) > 0 ? Convert.ToDouble(reader["HorasTotal"].ToString()) : 1)) * 100).ToString("N2") + "%";

                            TirajeProm = ((Convert.ToDouble(reader["Buenos"].ToString())) / (Entradas > 0 ? Entradas : 1)).ToString("N0").Replace(",", ".");
                            PorcMalosvsBuenos = (((MalosPrep + MalosTiraje) / (Buenos > 0 ? Buenos : 1)) * 100).ToString("N2") + "%";
                            Velocidad = ((Buenos) / (Convert.ToDouble(reader["HorasTiraje"].ToString()) > 0 ? (Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600) : 1)).ToString("N0").Replace(",", ".");
                            RendPP = ((Buenos) / ((Convert.ToDouble(reader["HorasTiraje"].ToString()) + Convert.ToDouble(reader["HorasPrep"].ToString())) > 0 ? (Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600 + Convert.ToDouble(reader["HorasPrep"].ToString()) / 3600) : 1)).ToString("N0").Replace(",", ".");
                            RendImpro = ((Buenos) / ((Convert.ToDouble(reader["HorasTiraje"].ToString()) + Convert.ToDouble(reader["HorasPrep"].ToString()) + Convert.ToDouble(reader["HorasImproductivasOT"].ToString())) > 0 ? (Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600 + Convert.ToDouble(reader["HorasPrep"].ToString()) / 3600 + Convert.ToDouble(reader["HorasImproductivasOT"].ToString()) / 3600) : 1)).ToString("N0").Replace(",", ".");
                            PorcBuenosAnual = (((Buenos) / (Convert.ToDouble(reader["BuenosAnual"].ToString()) > 0 ? Convert.ToDouble(reader["BuenosAnual"].ToString()) : 1)) * 100);
                            //Totales
                            TotalBuenos += Buenos;
                            TotalMalosPrep += MalosPrep;
                            TotalMalosTiraje += MalosTiraje;
                            TotalOts += OTS;
                            TotalEntradas += Entradas;
                            TotalHPrep += Convert.ToDouble(reader["HorasPrep"].ToString());
                            TotalHorasTiraje += Convert.ToDouble(reader["HorasTiraje"].ToString());
                            TotalImprodOT += Convert.ToDouble(reader["HorasImproductivasOT"].ToString());
                            TotalImprod += Convert.ToDouble(reader["HorasImproductivas"].ToString());
                            TotalSincarga += Convert.ToDouble(reader["HorasSinCarga"].ToString());
                            TotalEspMaterial += Convert.ToDouble(reader["HorasEsperaMaterial"].ToString());
                            TotalTotalHoras += Convert.ToDouble(reader["HorasTotal"].ToString());
                            TotalPorcBuenosAnual += PorcBuenosAnual;

                            resultado = resultado + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            reader["Mes"].ToString() + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            OTS.ToString() + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            Entradas.ToString() + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            Preparacion + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            PromedioPrep + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            Produccion + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            ImpOT + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            Imp + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            sCarga + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            EMaterial + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            HTotal + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            PorcHorasTiraje + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            porcSinCarga + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            porcSinProducir + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            PorcEsperaMaterial + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            Buenos.ToString("N0").Replace(",", ".") + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            TirajeProm + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            PorcBuenosAnual.ToString("N2") + "%</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            MalosTiraje.ToString("N0").Replace(",", ".") + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            MalosPrep.ToString("N0").Replace(",", ".") + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            PorcMalosvsBuenos + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            "-</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            Velocidad + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            RendPP + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            RendImpro + "</td> " +
                                        "</tr>";
                            MaquinaAnt = reader["Maquina"].ToString();
                        }
                        else
                        {
                            //tabla Totales
                            #region HorasTotales
                            TimeSpan t11 = TimeSpan.FromSeconds(TotalHPrep);
                            int Dias11 = t11.Days * 24;
                            Preparacion = (t11.Hours + Dias11).ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Minutes.ToString().Length) + t11.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Seconds.ToString().Length) + t11.Seconds.ToString();

                            TimeSpan t21 = TimeSpan.FromSeconds(TotalHorasTiraje);
                            int Dias21 = t21.Days * 24;
                            Produccion = (t21.Hours + Dias21).ToString() + ":" + ceros.Substring(0, ceros.Length - t21.Minutes.ToString().Length) + t21.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t21.Seconds.ToString().Length) + t21.Seconds.ToString();

                            TimeSpan t31 = TimeSpan.FromSeconds(TotalImprodOT);
                            int Dias31 = t31.Days * 24;
                            ImpOT = (t31.Hours + Dias31).ToString() + ":" + ceros.Substring(0, ceros.Length - t31.Minutes.ToString().Length) + t31.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t31.Seconds.ToString().Length) + t31.Seconds.ToString();

                            TimeSpan t41 = TimeSpan.FromSeconds(TotalImprod);
                            int Dias41 = t41.Days * 24;
                            Imp = (t41.Hours + Dias41).ToString() + ":" + ceros.Substring(0, ceros.Length - t41.Minutes.ToString().Length) + t41.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t41.Seconds.ToString().Length) + t41.Seconds.ToString();

                            TimeSpan t51 = TimeSpan.FromSeconds(TotalSincarga);
                            int Dias51 = t51.Days * 24;
                            sCarga = (t51.Hours + Dias51).ToString() + ":" + ceros.Substring(0, ceros.Length - t51.Minutes.ToString().Length) + t51.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t51.Seconds.ToString().Length) + t51.Seconds.ToString();

                            TimeSpan t61 = TimeSpan.FromSeconds(TotalEspMaterial);
                            int Dias61 = t61.Days * 24;
                            EMaterial = (t61.Hours + Dias61).ToString() + ":" + ceros.Substring(0, ceros.Length - t61.Minutes.ToString().Length) + t61.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t61.Seconds.ToString().Length) + t61.Seconds.ToString();

                            TimeSpan t71 = TimeSpan.FromSeconds(TotalTotalHoras);
                            int Dias71 = t71.Days * 24;
                            HTotal = (t71.Hours + Dias71).ToString() + ":" + ceros.Substring(0, ceros.Length - t71.Minutes.ToString().Length) + t71.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t71.Seconds.ToString().Length) + t71.Seconds.ToString();

                            TimeSpan t81 = TimeSpan.FromSeconds((TotalHPrep) / (TotalEntradas > 0 ? TotalEntradas : 1));
                            int Dias81 = t81.Days * 24;
                            PromedioPrep = (t81.Hours + Dias81).ToString() + ":" + ceros.Substring(0, ceros.Length - t81.Minutes.ToString().Length) + t81.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t81.Seconds.ToString().Length) + t81.Seconds.ToString();

                            Buenos = TotalBuenos;
                            MalosPrep = TotalMalosPrep;
                            MalosTiraje = TotalMalosTiraje;

                            PorcHorasTiraje = (((TotalHPrep + TotalHorasTiraje) / (TotalTotalHoras > 0 ? TotalTotalHoras : 1)) * 100).ToString("N2") + "%";
                            porcSinCarga = (((TotalSincarga) / (TotalTotalHoras > 0 ? TotalTotalHoras : 1)) * 100).ToString("N2") + "%";
                            porcSinProducir = (((TotalImprodOT + TotalImprod) / (TotalTotalHoras > 0 ? TotalTotalHoras : 1)) * 100).ToString("N2") + "%";
                            PorcEsperaMaterial = (((TotalEspMaterial) / (TotalTotalHoras > 0 ? TotalTotalHoras : 1)) * 100).ToString("N2") + "%";

                            TirajeProm = ((TotalBuenos) / (TotalEntradas > 0 ? TotalEntradas : 1)).ToString("N0").Replace(",", ".");
                            PorcMalosvsBuenos = (((MalosPrep + MalosTiraje) / (Buenos > 0 ? Buenos : 1)) * 100).ToString("N2") + "%";
                            Velocidad = ((Buenos) / (TotalHorasTiraje > 0 ? (TotalHorasTiraje / 3600) : 1)).ToString("N0").Replace(",", ".");
                            RendPP = ((Buenos) / ((TotalHorasTiraje + TotalHPrep) > 0 ? (TotalHorasTiraje / 3600 + TotalHPrep / 3600) : 1)).ToString("N0").Replace(",", ".");
                            RendImpro = ((Buenos) / ((TotalHorasTiraje + TotalHPrep + TotalImprodOT) > 0 ? (TotalHorasTiraje / 3600 + TotalHPrep / 3600 + TotalImprodOT / 3600) : 1)).ToString("N0").Replace(",", ".");
                            #endregion

                            resultado += "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>Totales:</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + TotalOts.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + TotalEntradas.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + Preparacion + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + PromedioPrep + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + Produccion + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + ImpOT + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + Imp + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + sCarga + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + EMaterial + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HTotal + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + PorcHorasTiraje + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + porcSinCarga + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + porcSinProducir + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + PorcEsperaMaterial + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + Buenos.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + TirajeProm + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + TotalPorcBuenosAnual.ToString("N2") + "%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + MalosTiraje.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + MalosPrep.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + PorcMalosvsBuenos + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + "-</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + Velocidad + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + RendPP + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + RendImpro + "</b></td> " +
                                      "</tr>" + ListarAcumulado12M(1, MesTerminoTrimestre, Año, MaquinaAnt, 1);


                            //cuando es una maquina nueva
                            OTS = Convert.ToDouble(reader["OTsTrabajadas"].ToString());
                            Entradas = Convert.ToDouble(reader["Entradas"].ToString());
                            #region Horas
                            TotalHPrep = Convert.ToDouble(reader["HorasPrep"].ToString());
                            TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasPrep"].ToString()));
                            int Dias1 = t1.Days * 24;
                            Preparacion = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                            TotalHorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString());
                            TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTiraje"].ToString()));
                            int Dias2 = t2.Days * 24;
                            Produccion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                            TotalImprodOT = Convert.ToDouble(reader["HorasImproductivasOT"].ToString());
                            TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivasOT"].ToString()));
                            int Dias3 = t3.Days * 24;
                            ImpOT = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                            TotalImprod = Convert.ToDouble(reader["HorasImproductivas"].ToString());
                            TimeSpan t4 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasImproductivas"].ToString()));
                            int Dias4 = t4.Days * 24;
                            Imp = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();

                            TotalSincarga = Convert.ToDouble(reader["HorasSinCarga"].ToString());
                            TimeSpan t5 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasSinCarga"].ToString()));
                            int Dias5 = t5.Days * 24;
                            sCarga = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                            TotalEspMaterial = Convert.ToDouble(reader["HorasEsperaMaterial"].ToString());
                            TimeSpan t6 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasEsperaMaterial"].ToString()));
                            int Dias6 = t6.Days * 24;
                            EMaterial = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                            TotalTotalHoras = Convert.ToDouble(reader["HorasTotal"].ToString());
                            TimeSpan t7 = TimeSpan.FromSeconds(Convert.ToDouble(reader["HorasTotal"].ToString()));
                            int Dias7 = t7.Days * 24;
                            HTotal = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                            TimeSpan t8 = TimeSpan.FromSeconds((Convert.ToDouble(reader["HorasPrep"].ToString())) / (Entradas > 0 ? Entradas : 1));
                            int Dias8 = t8.Days * 24;
                            PromedioPrep = (t8.Hours + Dias8).ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Minutes.ToString().Length) + t8.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Seconds.ToString().Length) + t8.Seconds.ToString();
                            #endregion
                            Buenos = Convert.ToDouble(reader["Buenos"].ToString());
                            MalosPrep = Convert.ToDouble(reader["MalosPreparacion"].ToString());
                            MalosTiraje = Convert.ToDouble(reader["MalosTiraje"].ToString());

                            PorcHorasTiraje = (((Convert.ToDouble(reader["HorasPrep"].ToString()) + Convert.ToDouble(reader["HorasTiraje"].ToString())) / (Convert.ToDouble(reader["HorasTotal"].ToString()) > 0 ? Convert.ToDouble(reader["HorasTotal"].ToString()) : 1)) * 100).ToString("N2") + "%";
                            porcSinCarga = (((Convert.ToDouble(reader["HorasSinCarga"].ToString())) / (Convert.ToDouble(reader["HorasTotal"].ToString()) > 0 ? Convert.ToDouble(reader["HorasTotal"].ToString()) : 1)) * 100).ToString("N2") + "%";
                            porcSinProducir = (((Convert.ToDouble(reader["HorasImproductivasOT"].ToString()) + Convert.ToDouble(reader["HorasImproductivas"].ToString())) / (Convert.ToDouble(reader["HorasTotal"].ToString()) > 0 ? Convert.ToDouble(reader["HorasTotal"].ToString()) : 1)) * 100).ToString("N2") + "%";
                            PorcEsperaMaterial = (((Convert.ToDouble(reader["HorasEsperaMaterial"].ToString())) / (Convert.ToDouble(reader["HorasTotal"].ToString()) > 0 ? Convert.ToDouble(reader["HorasTotal"].ToString()) : 1)) * 100).ToString("N2") + "%";

                            TirajeProm = ((Convert.ToDouble(reader["Buenos"].ToString())) / (Entradas > 0 ? Entradas : 1)).ToString("N0").Replace(",", ".");
                            PorcMalosvsBuenos = (((MalosPrep + MalosTiraje) / (Buenos > 0 ? Buenos : 1)) * 100).ToString("N2") + "%";
                            Velocidad = ((Buenos) / (Convert.ToDouble(reader["HorasTiraje"].ToString()) > 0 ? (Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600) : 1)).ToString("N0").Replace(",", ".");
                            RendPP = ((Buenos) / ((Convert.ToDouble(reader["HorasTiraje"].ToString()) + Convert.ToDouble(reader["HorasPrep"].ToString())) > 0 ? (Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600 + Convert.ToDouble(reader["HorasPrep"].ToString()) / 3600) : 1)).ToString("N0").Replace(",", ".");
                            RendImpro = ((Buenos) / ((Convert.ToDouble(reader["HorasTiraje"].ToString()) + Convert.ToDouble(reader["HorasPrep"].ToString()) + Convert.ToDouble(reader["HorasImproductivasOT"].ToString())) > 0 ? (Convert.ToDouble(reader["HorasTiraje"].ToString()) / 3600 + Convert.ToDouble(reader["HorasPrep"].ToString()) / 3600 + Convert.ToDouble(reader["HorasImproductivasOT"].ToString()) / 3600) : 1)).ToString("N0").Replace(",", ".");
                            PorcBuenosAnual = (((Buenos) / (Convert.ToDouble(reader["BuenosAnual"].ToString()) > 0 ? Convert.ToDouble(reader["BuenosAnual"].ToString()) : 1)) * 100);
                            //Totales
                            TotalBuenos = 0; TotalBuenos += Buenos;
                            TotalMalosPrep = 0; TotalMalosPrep += MalosPrep;
                            TotalMalosTiraje = 0; TotalMalosTiraje += MalosTiraje;
                            TotalOts = 0; TotalOts += OTS;
                            TotalEntradas = 0; TotalEntradas += Entradas;
                            TotalHPrep = 0; TotalHPrep += Convert.ToDouble(reader["HorasPrep"].ToString());
                            TotalHorasTiraje = 0; TotalHorasTiraje += Convert.ToDouble(reader["HorasTiraje"].ToString());
                            TotalImprodOT = 0; TotalImprodOT += Convert.ToDouble(reader["HorasImproductivasOT"].ToString());
                            TotalImprod = 0; TotalImprod += Convert.ToDouble(reader["HorasImproductivas"].ToString());
                            TotalSincarga = 0; TotalSincarga += Convert.ToDouble(reader["HorasSinCarga"].ToString());
                            TotalEspMaterial = 0; TotalEspMaterial += Convert.ToDouble(reader["HorasEsperaMaterial"].ToString());
                            TotalTotalHoras = 0; TotalTotalHoras += Convert.ToDouble(reader["HorasTotal"].ToString());
                            TotalPorcBuenosAnual = 0; TotalPorcBuenosAnual += PorcBuenosAnual;

                            resultado = resultado + "</tbody></table><espacio>" + EncabezadoMaquina(reader["Maquina"].ToString() + " - " + reader["CodRecurso"].ToString()) + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            reader["Mes"].ToString() + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            OTS.ToString() + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            Entradas.ToString() + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            Preparacion + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            PromedioPrep + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            Produccion + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            ImpOT + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            Imp + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            sCarga + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            EMaterial + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                            HTotal + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            PorcHorasTiraje + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            porcSinCarga + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            porcSinProducir + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            PorcEsperaMaterial + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            Buenos.ToString("N0").Replace(",", ".") + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            TirajeProm + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                             PorcBuenosAnual.ToString("N2") + "%</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            MalosTiraje.ToString("N0").Replace(",", ".") + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            MalosPrep.ToString("N0").Replace(",", ".") + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            PorcMalosvsBuenos + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            "-</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            Velocidad + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            RendPP + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                            RendImpro + "</td> " +
                                        "</tr>";
                            MaquinaAnt = reader["Maquina"].ToString();
                        }
                    } if (reader.Read() == false)
                    {
                        #region HorasTotales
                        TimeSpan t11 = TimeSpan.FromSeconds(TotalHPrep);
                        int Dias11 = t11.Days * 24;
                        Preparacion = (t11.Hours + Dias11).ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Minutes.ToString().Length) + t11.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Seconds.ToString().Length) + t11.Seconds.ToString();

                        TimeSpan t21 = TimeSpan.FromSeconds(TotalHorasTiraje);
                        int Dias21 = t21.Days * 24;
                        Produccion = (t21.Hours + Dias21).ToString() + ":" + ceros.Substring(0, ceros.Length - t21.Minutes.ToString().Length) + t21.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t21.Seconds.ToString().Length) + t21.Seconds.ToString();

                        TimeSpan t31 = TimeSpan.FromSeconds(TotalImprodOT);
                        int Dias31 = t31.Days * 24;
                        ImpOT = (t31.Hours + Dias31).ToString() + ":" + ceros.Substring(0, ceros.Length - t31.Minutes.ToString().Length) + t31.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t31.Seconds.ToString().Length) + t31.Seconds.ToString();

                        TimeSpan t41 = TimeSpan.FromSeconds(TotalImprod);
                        int Dias41 = t41.Days * 24;
                        Imp = (t41.Hours + Dias41).ToString() + ":" + ceros.Substring(0, ceros.Length - t41.Minutes.ToString().Length) + t41.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t41.Seconds.ToString().Length) + t41.Seconds.ToString();

                        TimeSpan t51 = TimeSpan.FromSeconds(TotalSincarga);
                        int Dias51 = t51.Days * 24;
                        sCarga = (t51.Hours + Dias51).ToString() + ":" + ceros.Substring(0, ceros.Length - t51.Minutes.ToString().Length) + t51.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t51.Seconds.ToString().Length) + t51.Seconds.ToString();

                        TimeSpan t61 = TimeSpan.FromSeconds(TotalEspMaterial);
                        int Dias61 = t61.Days * 24;
                        EMaterial = (t61.Hours + Dias61).ToString() + ":" + ceros.Substring(0, ceros.Length - t61.Minutes.ToString().Length) + t61.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t61.Seconds.ToString().Length) + t61.Seconds.ToString();

                        TimeSpan t71 = TimeSpan.FromSeconds(TotalTotalHoras);
                        int Dias71 = t71.Days * 24;
                        HTotal = (t71.Hours + Dias71).ToString() + ":" + ceros.Substring(0, ceros.Length - t71.Minutes.ToString().Length) + t71.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t71.Seconds.ToString().Length) + t71.Seconds.ToString();

                        TimeSpan t81 = TimeSpan.FromSeconds((TotalHPrep) / (TotalEntradas > 0 ? TotalEntradas : 1));
                        int Dias81 = t81.Days * 24;
                        PromedioPrep = (t81.Hours + Dias81).ToString() + ":" + ceros.Substring(0, ceros.Length - t81.Minutes.ToString().Length) + t81.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t81.Seconds.ToString().Length) + t81.Seconds.ToString();

                        Buenos = TotalBuenos;
                        MalosPrep = TotalMalosPrep;
                        MalosTiraje = TotalMalosTiraje;

                        PorcHorasTiraje = (((TotalHPrep + TotalHorasTiraje) / (TotalTotalHoras > 0 ? TotalTotalHoras : 1)) * 100).ToString("N2") + "%";
                        porcSinCarga = (((TotalSincarga) / (TotalTotalHoras > 0 ? TotalTotalHoras : 1)) * 100).ToString("N2") + "%";
                        porcSinProducir = (((TotalImprodOT + TotalImprod) / (TotalTotalHoras > 0 ? TotalTotalHoras : 1)) * 100).ToString("N2") + "%";
                        PorcEsperaMaterial = (((TotalEspMaterial) / (TotalTotalHoras > 0 ? TotalTotalHoras : 1)) * 100).ToString("N2") + "%";

                        TirajeProm = ((TotalBuenos) / (TotalEntradas > 0 ? TotalEntradas : 1)).ToString("N0").Replace(",", ".");
                        PorcMalosvsBuenos = (((MalosPrep + MalosTiraje) / (Buenos > 0 ? Buenos : 1)) * 100).ToString("N2") + "%";
                        Velocidad = ((Buenos) / (TotalHorasTiraje > 0 ? (TotalHorasTiraje / 3600) : 1)).ToString("N0").Replace(",", ".");
                        RendPP = ((Buenos) / ((TotalHorasTiraje + TotalHPrep) > 0 ? (TotalHorasTiraje / 3600 + TotalHPrep / 3600) : 1)).ToString("N0").Replace(",", ".");
                        RendImpro = ((Buenos) / ((TotalHorasTiraje + TotalHPrep + TotalImprodOT) > 0 ? (TotalHorasTiraje / 3600 + TotalHPrep / 3600 + TotalImprodOT / 3600) : 1)).ToString("N0").Replace(",", ".");
                        #endregion

                        resultado += "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                      "<b>Totales:</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + TotalOts.ToString("N0").Replace(",", ".") + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + TotalEntradas.ToString("N0").Replace(",", ".") + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                      "<b>" + Preparacion + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                      "<b>" + PromedioPrep + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                      "<b>" + Produccion + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                      "<b>" + ImpOT + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                      "<b>" + Imp + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                      "<b>" + sCarga + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                      "<b>" + EMaterial + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                      "<b>" + HTotal + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + PorcHorasTiraje + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + porcSinCarga + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + porcSinProducir + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + PorcEsperaMaterial + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + Buenos.ToString("N0").Replace(",", ".") + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + TirajeProm + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + TotalPorcBuenosAnual.ToString("N2") + "%</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + MalosTiraje.ToString("N0").Replace(",", ".") + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + MalosPrep.ToString("N0").Replace(",", ".") + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + PorcMalosvsBuenos + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + "-</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + Velocidad + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + RendPP + "</b></td> " +
                                  "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                      "<b>" + RendImpro + "</b></td> " +
                                  "</tr>" + ListarAcumulado12M(1,MesTerminoTrimestre,Año, MaquinaAnt, 1) + "<tbody></table>";
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public string ListarAcumulado12M(int MesInicialTrimestre, int MesTerminoTrimestre, int Año, string Maquina, int Procedimiento)
        {
            Conexion con = new Conexion(); string Resultado = ""; string ceros = "00";
            double Ots = 0; double Entradas = 0; double Preparacion = 0; double PromedioPreparacion = 0; double Produccion = 0; double ImprodOT = 0; double Improd = 0; double sinCarga = 0;
            double EspMaterial = 0; double TotalHoras = 0; double PorcHorasProducuendo = 0; double PorcSinCarga = 0; double PorcHorasSinProducir = 0; double porcEspMaterial = 0; double Buenos = 0;
            double MalosPrep = 0; double MalosTiraje = 0; string MalosVsBuenos = ""; string Velocidad = ""; string RendPP = ""; string RendImpro = "";
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "ENC_InformeProduccion";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MesInicialTrimestre", MesInicialTrimestre);
                    cmd.Parameters.AddWithValue("@MesTerminoTrimestre", MesTerminoTrimestre);
                    cmd.Parameters.AddWithValue("@Año", Año);
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                    cmd.Parameters.AddWithValue("@Procedimiento", 1);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ots = Convert.ToDouble(reader["OTsTrabajadas"].ToString());
                        Entradas = Convert.ToDouble(reader["Entradas"].ToString());
                        Preparacion = Convert.ToDouble(reader["HorasPrep"].ToString());
                        Produccion = Convert.ToDouble(reader["HorasTiraje"].ToString());
                        ImprodOT = Convert.ToDouble(reader["HorasImproductivasOT"].ToString());
                        Improd = Convert.ToDouble(reader["HorasImproductivas"].ToString());
                        sinCarga = Convert.ToDouble(reader["HorasSinCarga"].ToString());
                        EspMaterial = Convert.ToDouble(reader["HorasEsperaMaterial"].ToString());
                        TotalHoras = Convert.ToDouble(reader["HorasTotal"].ToString());
                        PorcHorasProducuendo = ((TotalHoras > 0 ? ((Preparacion + Produccion) / TotalHoras) : 0) * 100);
                        PorcSinCarga = ((TotalHoras > 0 ? ((sinCarga) / TotalHoras) : 0) * 100);
                        PorcHorasSinProducir = ((TotalHoras > 0 ? ((ImprodOT + Improd) / TotalHoras) : 0) * 100);
                        porcEspMaterial = ((TotalHoras > 0 ? ((EspMaterial) / TotalHoras) : 0) * 100);
                        Buenos = Convert.ToDouble(reader["Buenos"].ToString());
                        MalosPrep = Convert.ToDouble(reader["MalosPreparacion"].ToString());
                        MalosTiraje = Convert.ToDouble(reader["MalosTiraje"].ToString());
                        MalosVsBuenos = (((Buenos > 0 ? ((MalosPrep + MalosTiraje) / Buenos) : 0)) * 100).ToString("N2") + "%";
                        Velocidad = (((Produccion / 3600) > 0 ? ((Buenos) / (Produccion / 3600)) : 0)).ToString("N0").Replace(",", ".");
                        RendPP = ((((Produccion / 3600) + (Preparacion / 3600)) > 0 ? ((Buenos) / ((Produccion / 3600) + (Preparacion / 3600))) : 0)).ToString("N0").Replace(",", ".");
                        RendImpro = ((((Produccion / 3600) + (Preparacion / 3600) + (ImprodOT / 3600)) > 0 ? ((Buenos) / ((Produccion / 3600) + (Preparacion / 3600) + (ImprodOT / 3600))) : 0)).ToString("N0").Replace(",", ".");
                        #region Horas
                        string HPrep = ""; string PromPrep = ""; string HProduccion = ""; string HImprodOT = ""; string HImprod = ""; string HSCarga = ""; string HEspMaterial = ""; string HTotal = "";
                        TimeSpan t1 = TimeSpan.FromSeconds(Preparacion);
                        int Dias1 = t1.Days * 24;
                        HPrep = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                        TimeSpan t2 = TimeSpan.FromSeconds((Entradas > 0 ? (Preparacion / Entradas) : 0));
                        int Dias2 = t2.Days * 24;
                        PromPrep = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                        TimeSpan t3 = TimeSpan.FromSeconds(Produccion);
                        int Dias3 = t3.Days * 24;
                        HProduccion = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                        TimeSpan t4 = TimeSpan.FromSeconds(ImprodOT);
                        int Dias4 = t4.Days * 24;
                        HImprodOT = (t4.Hours + Dias4).ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t4.Seconds.ToString().Length) + t4.Seconds.ToString();

                        TimeSpan t5 = TimeSpan.FromSeconds(Improd);
                        int Dias5 = t5.Days * 24;
                        HImprod = (t5.Hours + Dias5).ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t5.Seconds.ToString().Length) + t5.Seconds.ToString();

                        TimeSpan t6 = TimeSpan.FromSeconds(sinCarga);
                        int Dias6 = t6.Days * 24;
                        HSCarga = (t6.Hours + Dias6).ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t6.Seconds.ToString().Length) + t6.Seconds.ToString();

                        TimeSpan t7 = TimeSpan.FromSeconds(EspMaterial);
                        int Dias7 = t7.Days * 24;
                        HEspMaterial = (t7.Hours + Dias7).ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t7.Seconds.ToString().Length) + t7.Seconds.ToString();

                        TimeSpan t8 = TimeSpan.FromSeconds(TotalHoras);
                        int Dias8 = t8.Days * 24;
                        HTotal = (t8.Hours + Dias8).ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Minutes.ToString().Length) + t8.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t8.Seconds.ToString().Length) + t8.Seconds.ToString();




                        #endregion
                        Resultado = "<tr style='height: 8px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "</tr>" +
                                      "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>Acum.12M</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + Ots.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + Entradas.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HPrep + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + PromPrep + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HProduccion + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HImprodOT + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HImprod + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HSCarga + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HEspMaterial + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HTotal + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + PorcHorasProducuendo.ToString("N2") + "%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + PorcSinCarga.ToString("N2") + "%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + PorcHorasSinProducir.ToString("N2") + "%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + porcEspMaterial.ToString("N2") + "%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + Buenos.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>100%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + MalosTiraje.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + MalosPrep.ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + MalosVsBuenos + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + "-</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + Velocidad + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + RendPP + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + RendImpro + "</b></td> " +
                                      "</tr>";
                        TimeSpan t9 = TimeSpan.FromSeconds(Preparacion / 12);
                        int Dias9 = t9.Days * 24;
                        HPrep = (t9.Hours + Dias9).ToString() + ":" + ceros.Substring(0, ceros.Length - t9.Minutes.ToString().Length) + t9.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t9.Seconds.ToString().Length) + t9.Seconds.ToString();

                        TimeSpan t10 = TimeSpan.FromSeconds((Entradas > 0 ? ((Preparacion / Entradas) / 12) : 0));
                        int Dias10 = t10.Days * 24;
                        PromPrep = (t10.Hours + Dias10).ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Minutes.ToString().Length) + t10.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t10.Seconds.ToString().Length) + t10.Seconds.ToString();

                        TimeSpan t11 = TimeSpan.FromSeconds(Produccion / 12);
                        int Dias11 = t11.Days * 24;
                        HProduccion = (t11.Hours + Dias11).ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Minutes.ToString().Length) + t11.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t11.Seconds.ToString().Length) + t11.Seconds.ToString();

                        TimeSpan t12 = TimeSpan.FromSeconds(ImprodOT / 12);
                        int Dias12 = t12.Days * 24;
                        HImprodOT = (t12.Hours + Dias12).ToString() + ":" + ceros.Substring(0, ceros.Length - t12.Minutes.ToString().Length) + t12.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t12.Seconds.ToString().Length) + t12.Seconds.ToString();

                        TimeSpan t13 = TimeSpan.FromSeconds(Improd / 12);
                        int Dias13 = t13.Days * 24;
                        HImprod = (t13.Hours + Dias13).ToString() + ":" + ceros.Substring(0, ceros.Length - t13.Minutes.ToString().Length) + t13.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t13.Seconds.ToString().Length) + t13.Seconds.ToString();

                        TimeSpan t14 = TimeSpan.FromSeconds(sinCarga / 12);
                        int Dias14 = t14.Days * 24;
                        HSCarga = (t14.Hours + Dias14).ToString() + ":" + ceros.Substring(0, ceros.Length - t14.Minutes.ToString().Length) + t14.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t14.Seconds.ToString().Length) + t14.Seconds.ToString();

                        TimeSpan t15 = TimeSpan.FromSeconds(EspMaterial / 12);
                        int Dias15 = t15.Days * 24;
                        HEspMaterial = (t15.Hours + Dias15).ToString() + ":" + ceros.Substring(0, ceros.Length - t15.Minutes.ToString().Length) + t15.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t15.Seconds.ToString().Length) + t15.Seconds.ToString();

                        TimeSpan t16 = TimeSpan.FromSeconds(TotalHoras / 12);
                        int Dias16 = t16.Days * 24;
                        HTotal = (t16.Hours + Dias16).ToString() + ":" + ceros.Substring(0, ceros.Length - t16.Minutes.ToString().Length) + t16.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t16.Seconds.ToString().Length) + t16.Seconds.ToString();
                        
                        Resultado+= "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>Prom.12M</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + (Ots / 12).ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + (Entradas / 12).ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HPrep + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + PromPrep + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HProduccion + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HImprodOT + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HImprod + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HSCarga + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HEspMaterial + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                          "<b>" + HTotal + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + (PorcHorasProducuendo / 12).ToString("N2") + "%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + (PorcSinCarga / 12).ToString("N2") + "%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + (PorcHorasSinProducir / 12).ToString("N2") + "%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + (porcEspMaterial / 12).ToString("N2") + "%</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + (Buenos / 12).ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + (MalosTiraje / 12).ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b>" + (MalosPrep / 12).ToString("N0").Replace(",", ".") + "</b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                          "<b></b></td> " +
                                      "</tr>";
                    }
                }
                catch
                {
                }
            }
        con.CerrarConexion();
        return Resultado;

        }
        public string ListarImproductivosMaquina(int MesInicialTrimestre, int MesTerminoTrimestre, int Año, string Maquina, int Procedimiento)
        {

            Conexion con = new Conexion(); string Resultado = ""; string ceros = "00"; string HImpro = ""; string MaquinaAnt = ""; string PorcHoras = ""; double Impro = 0; double Totalh = 0; double TotalAnterior = 0;
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "ENC_InformeProduccion";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MesInicialTrimestre", MesInicialTrimestre);
                    cmd.Parameters.AddWithValue("@MesTerminoTrimestre", MesTerminoTrimestre);
                    cmd.Parameters.AddWithValue("@Año", Año);
                    cmd.Parameters.AddWithValue("@Maquina", Maquina);
                    cmd.Parameters.AddWithValue("@Procedimiento", 2);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (MaquinaAnt == "" || MaquinaAnt == reader["Maquina"].ToString())
                        {
                            if (MaquinaAnt == "")
                            {
                                Resultado += "<td><table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; margin-left:3px;'> " +
                                      "<tbody><tr style='height: 25px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>  " +
                                       " <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='6'>   " +
                                        reader["Maquina"].ToString() + "</td></tr>  " +
                                        "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>  " +
                                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='4'>   " +
                                         "   Detalle  </td> " +
                                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>   " +
                                         "   Horas  </td> " +
                                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>   " +
                                         "   %  </td> " +
                                          "  </tr>  ";
                            }
                            Impro = Convert.ToDouble(reader["HorasImproductivas"].ToString());
                            Totalh = Convert.ToDouble(reader["TotalHoras"].ToString());
                            TotalAnterior = Totalh;
                            TimeSpan t1 = TimeSpan.FromSeconds(Impro);
                            int Dias1 = t1.Days * 24;
                            HImpro = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();

                            PorcHoras = (((Totalh > 0) ? (Impro / Totalh) : 0) * 100).ToString("N2");
                            Resultado += "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' colspan='4'> " +
                                        reader["Descricao"].ToString() + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;' colspan='1'> " +
                                        HImpro + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;' colspan='1'> " +
                                        PorcHoras+"</td> " +
                                        "</tr>";
                            MaquinaAnt = reader["Maquina"].ToString();
                        }
                        else
                        {
                            TimeSpan t2 = TimeSpan.FromSeconds(TotalAnterior);
                            int Dias2 = t2.Days * 24;
                            HImpro = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                            Resultado += "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' colspan='4'> " +
                                        "<b>Total</b></td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;' colspan='1'> " +
                                        "<b>"+HImpro + "</b></td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;' colspan='1'> " +
                                        "<b>100%</b></td> " +
                                        "</tr></tbody></table></td>";
                            Resultado += "<td><table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; margin-left:3px;'> " +
                                          "<tbody><tr style='height: 25px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>  " +
                                         " <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='6'>   " +
                                        reader["Maquina"].ToString() + "</td></tr>  " +
                                        "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>  " +
                                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='4'>   " +
                                         "   Detalle  </td> " +
                                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>   " +
                                         "   Horas  </td> " +
                                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>   " +
                                         "   %  </td> " +
                                          "  </tr>  ";
                            Impro = Convert.ToDouble(reader["HorasImproductivas"].ToString());
                            Totalh = Convert.ToDouble(reader["TotalHoras"].ToString());
                            TimeSpan t1 = TimeSpan.FromSeconds(Impro);
                            int Dias1 = t1.Days * 24;
                            HImpro = (t1.Hours + Dias1).ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t1.Seconds.ToString().Length) + t1.Seconds.ToString();
                            PorcHoras = (((Totalh > 0) ? (Impro / Totalh) : 0) * 100).ToString("N2");
                            Resultado += "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'> " +
                                              "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' colspan='4'> " +
                                        reader["Descricao"].ToString() + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;' colspan='1'> " +
                                        HImpro + "</td> " +
                                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;' colspan='1'> " +
                                        PorcHoras+"</td> " +
                                        "</tr>";
                            MaquinaAnt = reader["Maquina"].ToString();
                        }
                        //
                    } if (reader.Read() == false)
                    {
                        TimeSpan t2 = TimeSpan.FromSeconds(TotalAnterior);
                        int Dias2 = t2.Days * 24;
                        HImpro = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();

                        Resultado += "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' colspan='4'> " +
                                    "<b>Total</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;' colspan='1'> " +
                                    "<b>" + HImpro + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;' colspan='1'> " +
                                    "<b>100%</b></td> " +
                                    "</tr></tbody></table></td>";
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return Resultado;

        }
        public List<EstadisticaProduccion> ListaMaquina(int Procedimiento)
        {
            List<EstadisticaProduccion> lista = new List<EstadisticaProduccion>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[ENC_InformeProduccion]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MesInicialTrimestre", 0);
                cmd.Parameters.AddWithValue("@MesTerminoTrimestre", 0);
                cmd.Parameters.AddWithValue("@Año", 0);
                cmd.Parameters.AddWithValue("@Maquina", "");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EstadisticaProduccion pro = new EstadisticaProduccion();
                    pro.OTS = reader["Sector"].ToString();
                    lista.Add(pro);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }


        //INFORME FINISH
        public string ListarInformeFinish(int Mes, int Año, string Maquina, int Procedimiento)
        {
            Conexion con = new Conexion(); string ceros = "00"; string resultado = ""; string SectorAnt = ""; double HorasPrep = 0; double PromedioPersonas = 0; double LaborHrs = 0; double HorasDirectas = 0;
            double Entradas = 0;  string Preparacion = ""; double HorasTiraje = 0; double Improd = 0; double sinCarga = 0; double TotalHoras = 0; double Buenos = 0; double LaborHrsEquipe = 0; double HorasDirectasEquipe = 0; double PromedioPersonasEquipe = 0;

            double TotalBuenos = 0; double TotalEntradas = 0; double TotalHorasPrep = 0; double TotalHorasTiraje = 0; double TotalImprod = 0; double TotalPromedioPersonas = 0; double TotalPromedioPersonasEquipe = 0; double Contador = 0;
            double TotalSincarga = 0; string TotalPreparacion = ""; double TotalLaborHrs = 0; double TotalHorasDirectas = 0; double TotalLaborHrsEquipe = 0; double TotalHorasDirectasEquipe = 0; double TotalTotalHoras = 0;

            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "ENC_InformeFinish";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Mes", Mes);
                    cmd.Parameters.AddWithValue("@Año", Año);
                    cmd.Parameters.AddWithValue("@Sector", Maquina);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (SectorAnt == "" || SectorAnt == reader["Sector"].ToString())
                        {
                            Buenos = Convert.ToDouble(reader["Buenos"].ToString()); TotalBuenos += Buenos;
                            Entradas = Convert.ToDouble(reader["Entradas"].ToString()); TotalEntradas += Entradas;
                            HorasPrep = Convert.ToDouble(reader["HorasPrep"].ToString()); TotalHorasPrep += HorasPrep;
                            HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString()); TotalHorasTiraje += HorasTiraje;
                            Improd = Convert.ToDouble(reader["HorasImproductivasOT"].ToString()) + Convert.ToDouble(reader["HorasImproductivas"].ToString()); TotalImprod += Improd;
                            PromedioPersonas = Convert.ToDouble(reader["PromedioPersonas"].ToString()); TotalPromedioPersonas += PromedioPersonas;
                            PromedioPersonasEquipe = Convert.ToDouble(reader["PromedioEquipe"].ToString()); TotalPromedioPersonasEquipe += PromedioPersonasEquipe;
                            sinCarga = Convert.ToDouble(reader["HorasSinCarga"].ToString()); TotalSincarga += sinCarga;
                            TimeSpan t2 = TimeSpan.FromSeconds((Entradas > 0 ? (HorasPrep / Entradas) : 0));
                            int Dias2 = t2.Days * 24;
                            Preparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                            LaborHrs = (((HorasPrep + HorasTiraje + Improd + sinCarga) - (HorasPrep + HorasTiraje + Improd)) * PromedioPersonas); 
                            HorasDirectas = ((HorasPrep + HorasTiraje + Improd) * PromedioPersonas);

                            LaborHrsEquipe = (((HorasPrep + HorasTiraje + Improd + sinCarga) - (HorasPrep + HorasTiraje + Improd)) * PromedioPersonasEquipe);
                            HorasDirectasEquipe = ((HorasPrep + HorasTiraje + Improd) * PromedioPersonasEquipe);
                            TotalHoras = Convert.ToDouble(reader["HorasTotal"].ToString()); TotalTotalHoras += TotalHoras;
                            double dias = DateTime.DaysInMonth(2017, 6);

                            resultado += "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                    reader["Maquina"].ToString() + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (Buenos / 1000).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (Entradas > 0 ? (Buenos / Entradas) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    Preparacion + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (((HorasTiraje + Improd + HorasPrep) / 3600) > 0 ? (Buenos / ((HorasTiraje + Improd + HorasPrep) / 3600)) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0.0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasTiraje > 0 ? (Buenos / (HorasTiraje / 3600)) : 0)).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasTiraje / 3600 + Improd / 3600) > 0 ? (Buenos / (HorasTiraje / 3600 + Improd / 3600)) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (((HorasTiraje + Improd) > 0 ? (HorasTiraje / (HorasTiraje + Improd)) : 0) * 100).ToString("N2") + "%</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (((HorasTiraje + Improd + HorasPrep) / 3600) > 0 ? (Buenos / (((HorasTiraje + Improd + HorasPrep) / 3600) * PromedioPersonas)) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasTiraje + Improd + HorasPrep) > 0 ? (((HorasTiraje + Improd + HorasPrep) * PromedioPersonas) / (HorasTiraje + Improd + HorasPrep)) : 0).ToString("N1") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasDirectas + LaborHrs) > 0 ? ((LaborHrs / (LaborHrs + HorasDirectas)) * 100) : 0).ToString("N2") + "%</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((Buenos > 0) ? ((TotalHoras / 3600) / Buenos)*1000 : 0).ToString("N2") + "</td> " +
                                                                  
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (((HorasTiraje + Improd + HorasPrep) / 3600) > 0 ? (Buenos / (((HorasTiraje + Improd + HorasPrep) / 3600) * PromedioPersonasEquipe)) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasTiraje + Improd + HorasPrep) > 0 ? (((HorasTiraje + Improd + HorasPrep) * PromedioPersonasEquipe) / (HorasTiraje + Improd + HorasPrep)) : 0).ToString("N1") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasDirectasEquipe + LaborHrsEquipe) > 0 ? ((LaborHrsEquipe / (LaborHrsEquipe + HorasDirectasEquipe)) * 100) : 0).ToString("N2") + "%</td> " +
                                    
                                    
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((dias * 24) > 0 ? ((((HorasPrep + HorasTiraje + Improd) / 3600) / (dias * 24)) * 100) : 0).ToString("N2") + "%</td> " +
                                    "</tr>";
                            Contador = Contador + 1;
                            SectorAnt = reader["Sector"].ToString();
                        }
                        else
                        {
                            TimeSpan t3 = TimeSpan.FromSeconds((TotalEntradas > 0 ? (TotalHorasPrep / TotalEntradas) : 0));
                            int Dias3 = t3.Days * 24;
                            Preparacion = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                            TotalLaborHrs = (((TotalHorasPrep + TotalHorasTiraje + TotalImprod + TotalSincarga) - (TotalHorasPrep + TotalHorasTiraje + TotalImprod)) * (TotalPromedioPersonas/Contador));
                            TotalHorasDirectas = ((TotalHorasPrep + TotalHorasTiraje + TotalImprod) * (TotalPromedioPersonas/Contador));

                            TotalLaborHrsEquipe = (((TotalHorasPrep + TotalHorasTiraje + TotalImprod + TotalSincarga) - (TotalHorasPrep + TotalHorasTiraje + TotalImprod)) * (TotalPromedioPersonasEquipe/Contador));
                            TotalHorasDirectasEquipe = ((TotalHorasPrep + TotalHorasTiraje + TotalImprod) * TotalPromedioPersonasEquipe);

                            double dias8 = DateTime.DaysInMonth(2017, 6);
                            resultado += "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                    "<b>TOTAL " + SectorAnt.ToUpper() + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + (TotalBuenos / 1000).ToString("N0").Replace(",", ".") + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + (TotalEntradas > 0 ? (TotalBuenos / TotalEntradas) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + Preparacion + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) > 0 ? (TotalBuenos / ((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600)) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0.0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + ((TotalHorasTiraje > 0 ? (TotalBuenos / (TotalHorasTiraje / 3600)) : 0)).ToString("N0").Replace(",", ".") + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + ((TotalHorasTiraje / 3600 + TotalImprod / 3600) > 0 ? (TotalBuenos / (TotalHorasTiraje / 3600 + TotalImprod / 3600)) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + (((TotalHorasTiraje + TotalImprod) > 0 ? (TotalHorasTiraje / (TotalHorasTiraje + TotalImprod)) : 0) * 100).ToString("N2") + "%</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) > 0 ? (TotalBuenos / (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) * (TotalPromedioPersonas / Contador))) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + ((TotalHorasTiraje + TotalImprod + TotalHorasPrep) > 0 ? (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) * (TotalPromedioPersonas / Contador)) / (TotalHorasTiraje + TotalImprod + TotalHorasPrep)) : 0).ToString("N1") + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + ((TotalHorasDirectas + TotalLaborHrs) > 0 ? ((TotalLaborHrs / (TotalLaborHrs + TotalHorasDirectas)) * 100) : 0).ToString("N2") + "%</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + ((TotalBuenos > 0) ? ((TotalTotalHoras / 3600) / TotalBuenos) * 1000 : 0).ToString("N2") + "</b></td> " +

                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) > 0 ? (TotalBuenos / (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) * (TotalPromedioPersonasEquipe / Contador))) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + ((TotalHorasTiraje + TotalImprod + TotalHorasPrep) > 0 ? (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) * (TotalPromedioPersonasEquipe / Contador)) / (TotalHorasTiraje + TotalImprod + TotalHorasPrep)) : 0).ToString("N1") + "</b></td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + ((TotalHorasDirectasEquipe + TotalLaborHrsEquipe) > 0 ? ((TotalLaborHrsEquipe / (TotalLaborHrsEquipe + TotalHorasDirectasEquipe)) * 100) : 0).ToString("N2") + "%</b></td> " +


                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    "<b>" + (((dias8 * Contador) * 24) > 0 ? ((((TotalHorasPrep + TotalHorasTiraje + TotalImprod) / 3600) / ((dias8 * Contador) * 24)) * 100) : 0).ToString("N2") + "%</b></td> " +
                                    "</tr>";


                            Buenos = Convert.ToDouble(reader["Buenos"].ToString()); TotalBuenos = 0; TotalBuenos += Buenos;
                            Entradas = Convert.ToDouble(reader["Entradas"].ToString()); TotalEntradas = 0; TotalEntradas += Entradas;
                            HorasPrep = Convert.ToDouble(reader["HorasPrep"].ToString()); TotalHorasPrep = 0; TotalHorasPrep += HorasPrep;
                            HorasTiraje = Convert.ToDouble(reader["HorasTiraje"].ToString()); TotalHorasTiraje = 0; TotalHorasTiraje += HorasTiraje;
                            Improd = Convert.ToDouble(reader["HorasImproductivasOT"].ToString()) + Convert.ToDouble(reader["HorasImproductivas"].ToString()); TotalImprod = 0; TotalImprod += Improd;
                            PromedioPersonas = Convert.ToDouble(reader["PromedioPersonas"].ToString()); TotalPromedioPersonas = 0; TotalPromedioPersonas += PromedioPersonas;
                            PromedioPersonasEquipe = Convert.ToDouble(reader["PromedioEquipe"].ToString()); TotalPromedioPersonasEquipe = 0; TotalPromedioPersonasEquipe += PromedioPersonasEquipe;
                            sinCarga = Convert.ToDouble(reader["HorasSinCarga"].ToString()); TotalSincarga = 0; TotalSincarga += sinCarga;
                            TimeSpan t2 = TimeSpan.FromSeconds((Entradas > 0 ? (HorasPrep / Entradas) : 0));
                            int Dias2 = t2.Days * 24;
                            Preparacion = (t2.Hours + Dias2).ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t2.Seconds.ToString().Length) + t2.Seconds.ToString();
                            LaborHrs = (((HorasPrep + HorasTiraje + Improd + sinCarga) - (HorasPrep + HorasTiraje + Improd)) * PromedioPersonas);
                            HorasDirectas = ((HorasPrep + HorasTiraje + Improd) * PromedioPersonas);

                            LaborHrsEquipe = (((HorasPrep + HorasTiraje + Improd + sinCarga) - (HorasPrep + HorasTiraje + Improd)) * PromedioPersonasEquipe);
                            HorasDirectasEquipe = ((HorasPrep + HorasTiraje + Improd) * PromedioPersonasEquipe);
                            TotalHoras = Convert.ToDouble(reader["HorasTotal"].ToString()); TotalTotalHoras += TotalHoras;
                            double dias = DateTime.DaysInMonth(2017, 6);

                            resultado += "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                    reader["Maquina"].ToString() + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (Buenos / 1000).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (Entradas > 0 ? (Buenos / Entradas) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    Preparacion + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (((HorasTiraje + Improd + HorasPrep) / 3600) > 0 ? (Buenos / ((HorasTiraje + Improd + HorasPrep) / 3600)) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0.0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasTiraje > 0 ? (Buenos / (HorasTiraje / 3600)) : 0)).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasTiraje / 3600 + Improd / 3600) > 0 ? (Buenos / (HorasTiraje / 3600 + Improd / 3600)) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (((HorasTiraje + Improd) > 0 ? (HorasTiraje / (HorasTiraje + Improd)) : 0) * 100).ToString("N2") + "%</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (((HorasTiraje + Improd + HorasPrep) / 3600) > 0 ? (Buenos / (((HorasTiraje + Improd + HorasPrep) / 3600) * PromedioPersonas)) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasTiraje + Improd + HorasPrep) > 0 ? (((HorasTiraje + Improd + HorasPrep) * PromedioPersonas) / (HorasTiraje + Improd + HorasPrep)) : 0).ToString("N1") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasDirectas + LaborHrs) > 0 ? ((LaborHrs / (LaborHrs + HorasDirectas)) * 100) : 0).ToString("N2") + "%</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((Buenos > 0) ? ((TotalHoras / 3600) / Buenos) * 1000 : 0).ToString("N2") + "</td> " +

                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    (((HorasTiraje + Improd + HorasPrep) / 3600) > 0 ? (Buenos / (((HorasTiraje + Improd + HorasPrep) / 3600) * PromedioPersonasEquipe)) : 0).ToString("N0").Replace(",", ".") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasTiraje + Improd + HorasPrep) > 0 ? (((HorasTiraje + Improd + HorasPrep) * PromedioPersonasEquipe) / (HorasTiraje + Improd + HorasPrep)) : 0).ToString("N1") + "</td> " +
                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((HorasDirectasEquipe + LaborHrsEquipe) > 0 ? ((LaborHrsEquipe / (LaborHrsEquipe + HorasDirectasEquipe)) * 100) : 0).ToString("N2") + "%</td> " +


                                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                    ((dias * 24) > 0 ? ((((HorasPrep + HorasTiraje + Improd) / 3600) / (dias * 24)) * 100) : 0).ToString("N2") + "%</td> " +
                                    "</tr>";
                            Contador = 1;
                            SectorAnt = reader["Sector"].ToString();
                        }
                    } if (reader.Read() == false)
                    {
                        TimeSpan t3 = TimeSpan.FromSeconds((TotalEntradas > 0 ? (TotalHorasPrep / TotalEntradas) : 0));
                        int Dias3 = t3.Days * 24;
                        Preparacion = (t3.Hours + Dias3).ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + ":" + ceros.Substring(0, ceros.Length - t3.Seconds.ToString().Length) + t3.Seconds.ToString();

                        TotalLaborHrs = (((TotalHorasPrep + TotalHorasTiraje + TotalImprod + TotalSincarga) - (TotalHorasPrep + TotalHorasTiraje + TotalImprod)) * (TotalPromedioPersonas / Contador));
                        TotalHorasDirectas = ((TotalHorasPrep + TotalHorasTiraje + TotalImprod) * (TotalPromedioPersonas / Contador));

                        TotalLaborHrsEquipe = (((TotalHorasPrep + TotalHorasTiraje + TotalImprod + TotalSincarga) - (TotalHorasPrep + TotalHorasTiraje + TotalImprod)) * (TotalPromedioPersonasEquipe / Contador));
                        TotalHorasDirectasEquipe = ((TotalHorasPrep + TotalHorasTiraje + TotalImprod) * TotalPromedioPersonasEquipe);

                        double dias8 = DateTime.DaysInMonth(2017, 6);
                        resultado += "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'> " +
                                "<b>TOTAL " + SectorAnt.ToUpper() + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + (TotalBuenos / 1000).ToString("N0").Replace(",", ".") + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + (TotalEntradas > 0 ? (TotalBuenos / TotalEntradas) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + Preparacion + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) > 0 ? (TotalBuenos / ((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600)) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0.0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + ((TotalHorasTiraje > 0 ? (TotalBuenos / (TotalHorasTiraje / 3600)) : 0)).ToString("N0").Replace(",", ".") + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + ((TotalHorasTiraje / 3600 + TotalImprod / 3600) > 0 ? (TotalBuenos / (TotalHorasTiraje / 3600 + TotalImprod / 3600)) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + (((TotalHorasTiraje + TotalImprod) > 0 ? (TotalHorasTiraje / (TotalHorasTiraje + TotalImprod)) : 0) * 100).ToString("N2") + "%</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) > 0 ? (TotalBuenos / (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) * (TotalPromedioPersonas / Contador))) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + ((TotalHorasTiraje + TotalImprod + TotalHorasPrep) > 0 ? (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) * (TotalPromedioPersonas / Contador)) / (TotalHorasTiraje + TotalImprod + TotalHorasPrep)) : 0).ToString("N1") + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + ((TotalHorasDirectas + TotalLaborHrs) > 0 ? ((TotalLaborHrs / (TotalLaborHrs + TotalHorasDirectas)) * 100) : 0).ToString("N2") + "%</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + ((TotalBuenos > 0) ? ((TotalTotalHoras / 3600) / TotalBuenos) * 1000 : 0).ToString("N2") + "</b></td> " +

                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) > 0 ? (TotalBuenos / (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) / 3600) * (TotalPromedioPersonasEquipe / Contador))) : 0).ToString("N0").Replace(",", ".") + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + ((TotalHorasTiraje + TotalImprod + TotalHorasPrep) > 0 ? (((TotalHorasTiraje + TotalImprod + TotalHorasPrep) * (TotalPromedioPersonasEquipe / Contador)) / (TotalHorasTiraje + TotalImprod + TotalHorasPrep)) : 0).ToString("N1") + "</b></td> " +
                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + ((TotalHorasDirectasEquipe + TotalLaborHrsEquipe) > 0 ? ((TotalLaborHrsEquipe / (TotalLaborHrsEquipe + TotalHorasDirectasEquipe)) * 100) : 0).ToString("N2") + "%</b></td> " +


                                "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'> " +
                                "<b>" + (((dias8 * Contador) * 24) > 0 ? ((((TotalHorasPrep + TotalHorasTiraje + TotalImprod) / 3600) / ((dias8 * Contador) * 24)) * 100) : 0).ToString("N2") + "%</b></td> " +
                                "</tr>";
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            }
            catch {  }

            string nombreMes = DateTimeFormatInfo.CurrentInfo.MonthNames[Mes - 1].ToString();
            #region Encabezado
            string enca = "<table id='tblRegistro' runat='server' cellspacing='0'style='width:100%;border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; margin-left:3px;'> " +
          "<tbody><tr style='height: 25px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px;font-size:18px; border-right: 1px solid #ccc;text-align:left;'colspan='16'>  " +
                "Reporte Finish - " + nombreMes.ToUpper() + " " + Año + " </td></tr> " +
            "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' colspan='2'>  " +
                "Unidades Producidas  </td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' colspan='1'>  " +
                "MR Min/Setup  </td>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='2'>  " +
                "Producción  </td>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='2'>  " +
                "Improductivos  </td>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='4'>  " +
                "Trabajo  </td>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='3'>  " +
                "Equipe </td>" +
                "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                  "</td>" +
                "</tr> " +
            "<tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'> " +
            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Máquina  </td>" +
            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' colspan='1'>  " +
                "Buenos ('000's)  </td>" +
            "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' colspan='1'>  " +
                "Producción <br /> Promedio</td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "MR (min)  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Velocidad <br />(MRD)  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Velocidad  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Velocidad <br />(RD) </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Uptime  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Buenos/Hr  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Promedio <br />Personal  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Ind %  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Buenos <br />Hrs/1000(WC)" +
                "</td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Buenos/Hr  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Promedio <br />Personal  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Ind %  </td>" +
                "<td style='padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'colspan='1'>  " +
                "Capacidad </td>" +
                "</tr> ";
            #endregion
            return enca + resultado + "</tbody></table>";
        }

    }
}