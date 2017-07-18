using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloProduccion.Controller
{
    public class Controller_Requerimientos
    {
        public Requerimientos CargaDatosOT(string OT,string Cliente, int Procedimiento)
        {
            Requerimientos p = new Requerimientos();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "CSR_DatosSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p.OT = reader["OT"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString();
                    p.Cliente = reader["Cliente"].ToString();
                    p.FechaCreacion = reader["FechaCreacion"].ToString();
                    p.Tiraje = reader["Tiraje"].ToString();
                    p.Ancho = reader["Ancho"].ToString() + "X" + reader["Largo"].ToString();
                    p.Paginas = reader["Paginas"].ToString();
                    p.RutCliente = reader["RutCliente"].ToString();
                }

            }
            conexion.CerrarConexion();

            return p;
        }
        public List<Requerimientos> ListaDireccionesClientes(string OT, string Cliente, int Procedimiento)
        {
            List<Requerimientos> lista = new List<Requerimientos>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "CSR_DatosSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Requerimientos p = new Requerimientos();
                    p.Direccion = reader["CALLESUCURSAL"].ToString();
                    p.IDDireccion = reader["IDSUCURSAL"].ToString();
                    lista.Add(p);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
    }
}