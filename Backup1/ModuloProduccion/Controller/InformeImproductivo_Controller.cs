using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloProduccion.Controller
{
    public class InformeImproductivo_Controller
    {
        public List<InformeProduccionM> InformeImproductivo(string OT,string Area,string Maquina,string Operador,string clasificacion,string Tipo,DateTime FechaInicio,DateTime FechaTermino, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Programa_Improductivo]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Operador", Operador);
                cmd.Parameters.AddWithValue("@Clasificacion", clasificacion);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 30000000;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InformeProduccionM pro = new InformeProduccionM();
                    pro.OT = reader["NumOrdem"].ToString();
                    pro.NombreOT = reader["descricao"].ToString().ToLower();
                    pro.Maquina = reader["Maquina"].ToString().ToLower().Replace("321_2", "2").Replace("321_1", "1");
                    pro.Clasificacion = reader["Title"].ToString();
                    pro.Proceso = reader["Proceso"].ToString().ToLower();
                    pro.Observacion = reader["Obs"].ToString().ToLower();
                    pro.DAcerto = reader["DesperdicioAcerto"].ToString();
                    pro.DVirando = reader["DesperdicioVirando"].ToString();
                    pro.Operador = reader["Operador"].ToString();
                    pro.FechaInicio = Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    pro.FechaTermino = Convert.ToDateTime(reader["HoraFim"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    TimeSpan time;
                    time = (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString()));
                    if (time.ToString().Contains('-'))
                    {
                        pro.Horas = "<b>En Proceso</b>";
                    }
                    else
                    {
                        pro.Horas = time.ToString();
                    }
                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();

            return lista;
        }


        public List<InformeProduccionM> InformeImproductivo_ElectricayMecanica(string Maquina, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Produccion_FallasElectricaMecanica]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 30000000;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeProduccionM pro = new InformeProduccionM();
                    pro.VerMas = reader["CodApont"].ToString();
                    pro.Maquina = reader["Maquina"].ToString().ToLower().Replace("321_2", "2").Replace("321_1", "1");
                    pro.CodMaquina = reader["Classificacao"].ToString();
                    pro.NombreOT = reader["Descricao"].ToString();
                    pro.OT = reader["Title"].ToString();
                    pro.Pliego = Convert.ToDateTime(reader["dtProducao"].ToString()).ToString("dd/MM/yyyy");

                    TimeSpan time;
                    time = (Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString()));
                    if (time.ToString().Contains('-'))
                    {
                        pro.Horas = "<b>En Proceso</b>";
                    }
                    else
                    {
                        pro.Horas = time.ToString();
                    }
                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }



    }
}