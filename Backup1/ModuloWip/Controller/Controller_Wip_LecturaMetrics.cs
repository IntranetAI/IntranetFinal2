using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloWip.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloWip.Controller
{
    public class Controller_Wip_LecturaMetrics
    {
        public string ListaMaquinaProceso(string Codigo,int Procedimiento)
        {
            string Result = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Wip_ListMaquina_LecturaMetrics]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Result = reader["Nombre_Rack"].ToString();
                }
                con.CerrarConexion();
            }
            return Result;
        }
        public Wip ListaMaquinaENC(string Codigo, int Procedimiento)
        {
            Wip wp = new Wip();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Wip_ListMaquina_LecturaMetrics]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    wp.Maquina = reader["NombreMaquina"].ToString();
                    wp.ID_Control = reader["CodigoMaquina"].ToString();
                }
                con.CerrarConexion();
            }
            return wp;
        }
    }
}