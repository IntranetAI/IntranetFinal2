using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Intranet.ModuloBodegaPliegos.Controller
{
    public class Controller_Reserva
    {
        public bool Reservar(int idPapel, int CantidadAsignada,string FolioSolicitud,string Usuario, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "BodegaPliegos_ReservaPapel";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@IDPapel", idPapel);
                cmd.Parameters.AddWithValue("@CantidadAsignada", CantidadAsignada);
                cmd.Parameters.AddWithValue("@Folio", FolioSolicitud);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
    }
}