using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloBodegaPliegos.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloBodegaPliegos.Controller
{
    public class Controller_BodegaPliegos
    {
        public BodegaPliegos BuscarBP_PorCodigo(string Codigo,string Usuario,string NuevaUbicacion,int Cantidad,int Procedimiento)
        {
            BodegaPliegos bp = new BodegaPliegos();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_AsignarUbicacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@NuevaUbicacion", NuevaUbicacion);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bp.OT = reader["OT"].ToString();
                    bp.NombreOT = reader["NombreOT"].ToString().ToLower();
                    bp.Papel = reader["Papel"].ToString().ToLower();
                    bp.Cantidad = reader["CantidadAsignada"].ToString();
                    bp.UbicacionActual = reader["UbicacionActual"].ToString();
                }
            }
            return bp;
        }
        public bool AsignarUbicacionPallet(string Codigo, string Usuario, string NuevaUbicacion, int Cantidad, int Procedimiento)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_AsignarUbicacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@NuevaUbicacion", NuevaUbicacion);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            return respuesta;
        }
        public bool VerificaPosicion(string Codigo, string Usuario, string NuevaUbicacion, int Cantidad, int Procedimiento)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_AsignarUbicacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@NuevaUbicacion", NuevaUbicacion);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = Convert.ToBoolean(reader["respuesta"].ToString());
                }
            }
            return respuesta;
        }
    }
}