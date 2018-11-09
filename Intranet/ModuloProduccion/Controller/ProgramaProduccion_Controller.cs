using Intranet.ModuloProduccion.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Controller
{
    public class ProgramaProduccion_Controller
    {
        public List<ProgramaProduccion_Extendido> Programa_Extendido(DateTime Fechainicio, DateTime FechaTermino, string Maquinas)
        {
            List<ProgramaProduccion_Extendido> lista = new List<ProgramaProduccion_Extendido>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[ProgramaProduccion_Extendido]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", Fechainicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    cmd.Parameters.AddWithValue("@Maquinas", Maquinas.Replace("'",""));
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProgramaProduccion_Extendido pro = new ProgramaProduccion_Extendido();
                        pro.OT = reader["OT"].ToString();
                        pro.NombreOT = reader["NombreOT"].ToString().ToLower();
                        pro.Maquina = reader["Maquina"].ToString();
                        pro.Sector = reader["CodSetor"].ToString();//Sector
                        pro.FechaInicio = Convert.ToDateTime(reader["FI"].ToString()).ToString("dd-MM-yyyy");
                        pro.NumPliego = reader["NumPliego"].ToString();
                        TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["TiempoDif"].ToString()));
                        int Dias1 = t1.Days * 24;string Ceros = "00";
                        pro.TiempoDif = (t1.Hours + Dias1).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString();

                        pro.Dia = Convert.ToDateTime(reader["FI"].ToString()).Day;
                        pro.Mes = Convert.ToDateTime(reader["FI"].ToString()).Month;
                        pro.Año = Convert.ToDateTime(reader["FI"].ToString()).Year;

                        // TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(reader["TiempoDif"].ToString()));
                        //int Dias1 = t1.Days * 24;
                        //string Ceros = "00";
                        //pro.Horas = (t1.Hours + Dias1).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString();
                        lista.Add(pro);
                    }
                }
                catch(Exception ex)
                {
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
    }
}