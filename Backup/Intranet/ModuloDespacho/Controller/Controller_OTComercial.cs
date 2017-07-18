using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloDespacho.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloDespacho.Controller
{
    public class Controller_OTComercial
    {
        public OTComercial Cargar_OT(string Folio,string OT,string NombreOT,int TirajeOt,int cantidadenviada,
            int peso,string descripcion,string EnviadaPor,string RecepcionadaPor,int procedimiento)
        {
            Conexion con = new Conexion();
            OTComercial des = new OTComercial();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_OTComercial_Operaciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@TirajeOT", TirajeOt);
                cmd.Parameters.AddWithValue("@CantidadEnviada", cantidadenviada);
                cmd.Parameters.AddWithValue("@Peso", peso);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@EnviadaPor", EnviadaPor);
                cmd.Parameters.AddWithValue("@RecepcionadaPor", RecepcionadaPor);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    des.OT = reader["OT"].ToString();
                    des.NombreOT = reader["NombreOT"].ToString();
                    des.TirajeOT = reader["TirajeOT"].ToString();

                }
            }
            con.CerrarConexion();
            return des;
        }
        public bool insertOTComercial(string Folio, string OT, string NombreOT, int TirajeOt, int cantidadenviada,
            int peso, string descripcion, string EnviadaPor, string RecepcionadaPor, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_OTComercial_Operaciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@TirajeOT", TirajeOt);
                cmd.Parameters.AddWithValue("@CantidadEnviada", cantidadenviada);
                cmd.Parameters.AddWithValue("@Peso", peso);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@EnviadaPor", EnviadaPor);
                cmd.Parameters.AddWithValue("@RecepcionadaPor", RecepcionadaPor);
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

        public string buscarFolio(string Folio, string OT, string NombreOT, int TirajeOt, int cantidadenviada,
            int peso, string descripcion, string EnviadaPor, string RecepcionadaPor, int procedimiento)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Desp_OTComercial_Operaciones]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@TirajeOT", TirajeOt);
                cmd.Parameters.AddWithValue("@CantidadEnviada", cantidadenviada);
                cmd.Parameters.AddWithValue("@Peso", peso);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@EnviadaPor", EnviadaPor);
                cmd.Parameters.AddWithValue("@RecepcionadaPor", RecepcionadaPor);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado = reader["folio"].ToString();
                }
                
            }
            con.CerrarConexion();
            return resultado;
        }

        public OTComercial Cargar_OTComercial(string Folio, string OT, string NombreOT, int TirajeOt, int cantidadenviada,
    int peso, string descripcion, string EnviadaPor, string RecepcionadaPor, int procedimiento)
        {
            Conexion con = new Conexion();
            OTComercial des = new OTComercial();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_OTComercial_Operaciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@TirajeOT", TirajeOt);
                cmd.Parameters.AddWithValue("@CantidadEnviada", cantidadenviada);
                cmd.Parameters.AddWithValue("@Peso", peso);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@EnviadaPor", EnviadaPor);
                cmd.Parameters.AddWithValue("@RecepcionadaPor", RecepcionadaPor);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    des.OT = reader["OT"].ToString();
                    des.Folio = reader["Folio"].ToString();
                    des.NombreOT = reader["NombreOT"].ToString();
                    des.TirajeOT = reader["TirajeOT"].ToString();
                    des.CantidadEnviada = reader["CantidadEnviada"].ToString();
                    des.Peso = reader["Peso"].ToString();
                    des.Descripcion = reader["Descripcion"].ToString();
                    des.EnviadaPor = reader["EnviadaPor"].ToString();
                    des.FechaEnvio = reader["FechaEnvio"].ToString();
                    des.RecepcionadoPor = reader["RecepcionadoPor"].ToString();
                    des.FechaRecepcion = reader["FechaRecepcion"].ToString();
                    des.Estado = reader["Estado"].ToString();

                }
            }
            con.CerrarConexion();
            return des;
        }


        public List<OTComercial> Cargar_OTComercial_Grilla(string Folio, string OT, string NombreOT, int TirajeOt, int cantidadenviada,
    int peso, string descripcion, string EnviadaPor, string RecepcionadaPor, int procedimiento)
        {
            List<OTComercial> lista = new List<OTComercial>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_OTComercial_Operaciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@TirajeOT", TirajeOt);
                cmd.Parameters.AddWithValue("@CantidadEnviada", cantidadenviada);
                cmd.Parameters.AddWithValue("@Peso", peso);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@EnviadaPor", EnviadaPor);
                cmd.Parameters.AddWithValue("@RecepcionadaPor", RecepcionadaPor);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OTComercial des = new OTComercial();

                    des.OT = reader["OT"].ToString();
                    des.Folio = reader["Folio"].ToString();
                    des.NombreOT = reader["NombreOT"].ToString();
                    int ti = Convert.ToInt32(reader["TirajeOT"].ToString());
                    des.TirajeOT = ti.ToString("N0").Replace(",", ".");

                    int ce = Convert.ToInt32(reader["CantidadEnviada"].ToString());
                    des.CantidadEnviada = ce.ToString("N0").Replace(",", ".");

                    int pe = Convert.ToInt32(reader["Peso"].ToString());
                    des.Peso = pe.ToString("N0").Replace(",", ".");
                    des.Descripcion = reader["Descripcion"].ToString();
                    des.EnviadaPor = reader["EnviadaPor"].ToString();

                    DateTime fe=Convert.ToDateTime(reader["FechaEnvio"].ToString());
                    des.FechaEnvio = fe.ToString("dd/MM/yyyy HH:mm");
                    des.RecepcionadoPor = reader["RecepcionadoPor"].ToString();
                    des.FechaRecepcion = reader["FechaRecepcion"].ToString();
                    des.Estado = reader["Estado"].ToString();
                    if (des.Estado == "1")
                    {
                        des.Estado = "<div style='Color:Blue;'>Generada</div>";
                    }
                    else if (des.Estado == "2")
                    {
                        des.Estado = "<div style='Color:Green;'>Recepcionada</div>";
                    }
                    else if (des.Estado == "0")
                    {
                        des.Estado = "<div style='Color:Red;'>Rechazada</div>";
                    }
                   

                    lista.Add(des);
                }
            }
            con.CerrarConexion();
            return lista;
        }


        public bool AprobaroRechazarOTComercial(string Folio, string OT, string NombreOT, int TirajeOt, int cantidadenviada,
    int peso, string descripcion, string EnviadaPor, string RecepcionadaPor, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_OTComercial_Operaciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@TirajeOT", TirajeOt);
                cmd.Parameters.AddWithValue("@CantidadEnviada", cantidadenviada);
                cmd.Parameters.AddWithValue("@Peso", peso);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@EnviadaPor", EnviadaPor);
                cmd.Parameters.AddWithValue("@RecepcionadaPor", RecepcionadaPor);
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