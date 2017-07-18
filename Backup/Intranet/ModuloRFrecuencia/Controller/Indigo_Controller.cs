using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloRFrecuencia.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloRFrecuencia.Controller
{
    public class Indigo_Controller
    {
        public List<Indigo> ListIndigo()
        {
            List<Indigo> lista = new List<Indigo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Indigo_List";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Indigo ind = new Indigo();
                    ind.Maquina = reader["Maquina"].ToString();
                    ind.OT = reader["OT"].ToString();
                    ind.NombreOT = reader["NombreOT"].ToString();
                    ind.Pliego = reader["Pliego"].ToString();
                    ind.Papel = reader["Papel"].ToString();
                    ind.Tiraje = Convert.ToInt32(reader["Tiraje"].ToString());
                    ind.Color = reader["Color"].ToString();
                    ind.Buenos = Convert.ToInt32(reader["Buenos"].ToString());
                    ind.Malos = Convert.ToInt32(reader["Malo"].ToString());
                    lista.Add(ind);
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public bool InsertIndigo(Indigo ind)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Indigo_InsertParte";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maquina",ind.Maquina);
                cmd.Parameters.AddWithValue("@Pliego",ind.Pliego);
                cmd.Parameters.AddWithValue("@OT",ind.OT);
                cmd.Parameters.AddWithValue("@NombreOT",ind.NombreOT);
                cmd.Parameters.AddWithValue("@Papel",ind.Papel);
                cmd.Parameters.AddWithValue("@Tiraje",ind.Tiraje);
                cmd.Parameters.AddWithValue("@Color",ind.Color);
                cmd.Parameters.AddWithValue("@ClickInicio",ind.ClickInicio);
                cmd.Parameters.AddWithValue("@ClickFinal",ind.ClickFinal);
                cmd.Parameters.AddWithValue("@Cantidad_Click",ind.CantidadClick);
                cmd.Parameters.AddWithValue("@Buenos",ind.Buenos);
                cmd.Parameters.AddWithValue("@Malo",ind.Malos);
                cmd.Parameters.AddWithValue("@Formato",ind.Formato);
                cmd.Parameters.AddWithValue("@Observacion",ind.Observacion);
                cmd.Parameters.AddWithValue("@Usuario",ind.Usuario);
                cmd.ExecuteReader();
                respuesta = true;
            }
            return respuesta;
        }

        public int MaxClick()
        {
            int maxClick = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Indigo_MaxClick";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    maxClick = Convert.ToInt32(reader["ClickFinal"].ToString());
                }
                con.CerrarConexion();
            }
            return maxClick;
        }
    }
}