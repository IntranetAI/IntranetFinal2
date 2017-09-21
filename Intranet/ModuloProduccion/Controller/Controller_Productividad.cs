using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloProduccion.Controller
{
    public class Controller_Productividad
    {
        public List<ProductividadMaquina> ListarProductividadMaquina(string Maquina, int Procedimiento)
        {
            List<ProductividadMaquina> lista = new List<ProductividadMaquina>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Produccion_InformeProductividadMaquina";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maquina", Maquina.Replace("Speed Master","").Trim());
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    if (Procedimiento == 3)
                    {
                        cmd.CommandTimeout = 30000;
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductividadMaquina proMaquina = new ProductividadMaquina();
                        proMaquina.TotalHoras = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasTrabajadas"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.HorasTiraje = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasTiraje"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.HorasPreparacion = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasPreparacion"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.HorasImproductivo = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasImproductivas"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.Imp_Mantenimiento = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasMantencion"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.Imp_Almuerzo = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasColacion"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.Imp_SinTrabajo = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasIdle"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.Imp_Papel = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasPapel"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.Imp_Preprensa = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasPreprensa"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.Imp_Operacion = Math.Round(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(reader["HorasOperacion"]) / Convert.ToDouble(60)) / Convert.ToDouble(60)), 2);
                        proMaquina.Entradas = Convert.ToInt32(reader["Entradas"].ToString());
                        proMaquina.Pliegos_Impresos = Convert.ToInt32(reader["Buenos"].ToString());
                        if (Procedimiento == 0)
                        {
                            string[] d = Convert.ToDateTime(reader["Fecha"].ToString()).ToString("dd-ddd-MMM").Split('-');
                            string Mes = "";
                            string Dia = "";
                            switch (d[1])
                            {
                                case "Mon": Dia = "Lun."; break;
                                case "Tue": Dia = "Mar."; break;
                                case "Wed": Dia = "Mie."; break;
                                case "Thu": Dia = "Jue."; break;
                                case "Fri": Dia = "Vie."; break;
                                case "Sat": Dia = "Sab."; break;
                                default: Dia = "Dom."; break;

                            }

                            switch (d[2])
                            {
                                case "Jan": Mes = "Ene."; break;
                                case "Apr": Mes = "Abr."; break;
                                case "Aug": Mes = "Ago."; break;
                                case "Dec": Mes = "Dic"; break;
                                default: Mes = d[2]; break;
                            }
                            proMaquina.DiasSemana = Dia + " " + d[2] + " " + d[0];
                        }
                        else
                        {
                            proMaquina.DiasSemana = reader["Fecha"].ToString();
                        }
                        proMaquina.GirosImpresion = Convert.ToInt32(reader["Giros"].ToString());
                        lista.Add(proMaquina);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}