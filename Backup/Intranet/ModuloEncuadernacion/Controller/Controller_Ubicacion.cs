using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloEncuadernacion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloEncuadernacion.Controller
{
    public class Controller_Ubicacion
    {
        public  List<Ubicacion> ListaDetalle(int idUbicacion,string Ubicacion,string CodigoUbicacion,int Proc)
        {
            List<Ubicacion> lista = new List<Ubicacion>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "CargarUbicacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ubicacion", idUbicacion);
                cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                cmd.Parameters.AddWithValue("@CodigoUbicacion", CodigoUbicacion);
                cmd.Parameters.AddWithValue("@Procedimiento", Proc);
               

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Ubicacion u = new Ubicacion();
                    u.idUbicacion = reader["id_Ubicacion"].ToString();
                    u.UbicacionPro = reader["NombreUbicacion"].ToString();
                    lista.Add(u);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }
    }
}