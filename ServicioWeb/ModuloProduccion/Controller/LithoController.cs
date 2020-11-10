using ServicioWeb.ModuloProduccion.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Controller
{
    public class LithoController
    {
        public JsonLitho ListarRegistro()
        {
            JsonLitho lista = new JsonLitho();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Litho_OTPliego";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lista.OT = reader["ot"].ToString();
                        lista.Pliego = reader["pliego"].ToString();

                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public bool InsertConsumo(ConsumoEnergia consu)
        {
            bool respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Litho_ConsumoEnergia]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdApontamento", consu.IdApontamento);
                    cmd.Parameters.AddWithValue("@Consumo", consu.Consumo);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        respuesta = Convert.ToBoolean(reader["respuesta"].ToString());
                    }
                }
                catch(Exception ex)
                {
                    respuesta = false;
                }
            }
            con.CerrarConexion();
            return respuesta;
        }
        public List<PliegosFinalizados> PliegosFinalizados(DateTime FI,DateTime FT,int Procedimiento)
        {
            List<PliegosFinalizados> lista = new List<PliegosFinalizados>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Preprensa_PliegosFinalizados";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", FI);
                    cmd.Parameters.AddWithValue("@FechaTermino", FT);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PliegosFinalizados pf = new PliegosFinalizados();
                        pf.Maquina = reader["Maquina"].ToString();
                        pf.Sector = reader["CodSetor"].ToString();
                        pf.OT = reader["NumOrdem"].ToString();
                        pf.NombreOT = reader["NombreOT"].ToString();
                        pf.Pliego = reader["Processo"].ToString();
                        pf.Buenos = Convert.ToInt32(reader["Buenos"].ToString());
                        pf.Planficado = Convert.ToInt32(reader["Planificado"].ToString());
                        lista.Add(pf);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}