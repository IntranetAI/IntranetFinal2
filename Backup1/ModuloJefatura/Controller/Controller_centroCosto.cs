using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloJefatura.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloJefatura.Controller
{
    public class Controller_centroCosto
    {
        public static List<centroCosto> ListarArea(int filt)
        {
            List<centroCosto> lista = new List<centroCosto>();
            Conexion con = new Conexion();
            //SqlCommand cmd = con.AbrirConexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "SP_Administrador";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filt", filt);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    centroCosto task = new centroCosto();
                    task.IDArea = Convert.ToInt32(reader["IDArea"].ToString());
                    task.NombreArea = reader["Nombre_Area"].ToString();

                    lista.Add(task);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public  List<centroCosto> ListarCentroCosto()
        {
            List<centroCosto> lista = new List<centroCosto>();
            Conexion con = new Conexion();
            //SqlCommand cmd = con.AbrirConexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "SP_CentroCostoList";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    centroCosto task = new centroCosto();
                    task.cod_CentroCosto = Convert.ToInt32(reader["cod_centro_costo"].ToString());
                    task.CentroCosto = reader["centro_costo"].ToString();

                    lista.Add(task);
                }
            }

            con.CerrarConexion();
            return lista;
        }

        public bool AsignarGerencia(int IDArea,List<centroCosto> list)
        {
            string insert = "";
            foreach (centroCosto asi in list)
            {
                insert = insert + "insert into dbo.area_centroCosto(IDArea,cod_centro_costo,centro_costo) values(" + IDArea + "," + asi.cod_CentroCosto + ",'" + asi.CentroCosto + "');";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }

                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
            
        }

        public List<centroCosto> ListarCCAsignados(int filt, int idArea)
        {
            List<centroCosto> lista = new List<centroCosto>();
            Conexion con = new Conexion();

            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "SP_Administrador";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filt", filt);
                cmd.Parameters.AddWithValue("@idArea", idArea);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    centroCosto task = new centroCosto();
                    task.cod_CentroCosto = Convert.ToInt32(reader["cod_centro_Costo"].ToString());
                    task.CentroCosto = reader["centro_costo"].ToString();
                    task.IDArea_Centro = Convert.ToInt32(reader["IDArea_Centro"].ToString());

                    lista.Add(task);
                }
                
            }
            con.CerrarConexion();
            return lista;
        }

        public bool DESAsignarGerencia(List<centroCosto> list)
        {
            string insert = "";
            foreach (centroCosto asi in list)
            {
                insert = insert + "delete from dbo.area_centroCosto where cod_centro_costo=" + asi.cod_CentroCosto + "and centro_costo='" + asi.CentroCosto + "';";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }
    }
}