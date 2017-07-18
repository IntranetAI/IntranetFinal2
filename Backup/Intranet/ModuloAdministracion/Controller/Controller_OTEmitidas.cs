using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloBodegaPliegos.Model;
using Intranet.ModuloAdministracion.Model;

namespace Intranet.ModuloAdministracion.Controller
{
    public class Controller_OTEmitidas
    {
        public bool ingresaOTEmitida(string OT,string NombreOT,string Cliente,int Tiraje,string EstadoOT,DateTime FechaEmision,DateTime UltimaModificacion,string Observacion,string Usuario,int proce)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Adm_OTEmitida";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Tiraje", Tiraje);
                cmd.Parameters.AddWithValue("@EstadoOT", EstadoOT);
                cmd.Parameters.AddWithValue("@FechaEmision", FechaEmision);
                cmd.Parameters.AddWithValue("@UltimaModificacion", UltimaModificacion);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", proce);

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
        public BodegaPliegos BuscaDatosOT(string OT, string NombreOT, string Cliente, int Tiraje, string EstadoOT, DateTime FechaEmision, DateTime UltimaModificacion, string Observacion, string Usuario, int proce)
        {
            BodegaPliegos d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_OTEmitida";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Tiraje", Tiraje);
                cmd.Parameters.AddWithValue("@EstadoOT", EstadoOT);
                cmd.Parameters.AddWithValue("@FechaEmision", FechaEmision);
                cmd.Parameters.AddWithValue("@UltimaModificacion", UltimaModificacion);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", proce);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new BodegaPliegos();
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaEmision"].ToString()).ToString("dd/MM/yyyy");
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString();
                    d.Cliente = reader["Cliente"].ToString();
                    d.Pliegos = Convert.ToInt32(reader["TirajeOT"].ToString()).ToString("N0").Replace(",", ".");
                    d.Estado = reader["EstadoOT"].ToString();
                    d.Accion = Convert.ToDateTime(reader["UltimaModificacion"].ToString()).ToString("dd/MM/yyyy HH:mm");
                }
            }
            conexion.CerrarConexion();
            return d;
        }
        public List<OTEmitidas> ListarOTEmitidas(string ot,string nombreot,string cliente,string estado,DateTime fechaini,DateTime fechater,int procedimiento)
        {
            List<OTEmitidas> lista = new List<OTEmitidas>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "Adm_OTEmitidas_Informe";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                cmd.Parameters.AddWithValue("@Cliente", cliente);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaini);
                cmd.Parameters.AddWithValue("@FechaTermino", fechater);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OTEmitidas o = new OTEmitidas();
                    o.OT = reader["OT"].ToString();
                    o.NombreOT = reader["NombreOT"].ToString().ToLower();
                    o.Cliente = reader["Cliente"].ToString().ToLower();
                    o.Tiraje = reader["Tiraje"].ToString();
                    o.EstadoOT = reader["EstadoOT"].ToString();
                    o.FechaEmision = Convert.ToDateTime(reader["FechaEmision"].ToString()).ToString("dd/MM/yyyy");
                    o.UltimaModificacion = Convert.ToDateTime(reader["UltimaModificacion"].ToString()).ToString("dd/MM/yyyy");
                    o.Observacion = reader["Observacion"].ToString();
                    o.Ingreso = reader["Usuario"].ToString();
                    o.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"].ToString()).ToString("dd/MM/yyyy");
                    lista.Add(o);
                }
                con.CerrarConexion();
            }
            return lista;
        }
    }
}