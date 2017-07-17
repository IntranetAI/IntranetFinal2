using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloDespacho.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloDespacho.Controller
{
    public class Controller_Proveedor
    {

        public ProveedorMod cargarPliegosOT(string ot,int idGuiaDet,int procedimiento)
        {
            Conexion con = new Conexion(); 
            ProveedorMod des = new ProveedorMod();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Proveedor_ListaPliegos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@idGuiaDet", idGuiaDet);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    des.NombreOT = reader["NombreOT"].ToString();
                    des.TirajeOT = reader["TirajeGuiaDet"].ToString();

               }
               
            }
            con.CerrarConexion();
            return des;
        }
        public ProveedorMod cargarDatosPliegos(string ot,int idGuiaDet, int procedimiento)
        {
            Conexion con = new Conexion();
            ProveedorMod des = new ProveedorMod();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Proveedor_ListaPliegos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@idGuiaDet", idGuiaDet);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    des.ProcesoExterno = reader["NombreProcesoExterno"].ToString();
                    des.CantidadPliego = reader["CANTIDADTIPOELEMENTO"].ToString();
                    des.Forma = reader["NombreForma"].ToString();
                    des.Total = reader["Total"].ToString();
                    des.id_ProcesoExterno = reader["IdProcesoExterno"].ToString();

                }
               
            }
            con.CerrarConexion();
            return des;
        }


        public List<ProveedorMod> CargaPliegos(string ot,int idGuiaDet,int Procedimiento)
        {
            List<ProveedorMod> lista = new List<ProveedorMod>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Proveedor_ListaPliegos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@idGuiaDet", idGuiaDet);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProveedorMod des = new ProveedorMod();

                   
                    des.NombrePliego = reader["NombrePliego"].ToString().ToUpper();
                    des.CantidadPliego = reader["IDGUIADET"].ToString().ToLower();
                    lista.Add(des);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool InsertarEnvioProveedor(int id_procesoExterno,int idGuiaDet, string Ot, string Nombreot,string pliego,string forma,int totalpliego,string procesoexterno,int cantidadenviada,string generadapor)
        {
            SqlDataReader dr;
            bool respuesta = true;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Desp_Proveedor_Add";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ProcesoExterno", id_procesoExterno);
                cmd.Parameters.AddWithValue("@idGuiaDet", idGuiaDet);
                cmd.Parameters.AddWithValue("@OT", Ot);
                cmd.Parameters.AddWithValue("@NombreOT", Nombreot);
                cmd.Parameters.AddWithValue("@Pliego", pliego);
                cmd.Parameters.AddWithValue("@Forma", forma);
                cmd.Parameters.AddWithValue("@TotalPliego", totalpliego);
                cmd.Parameters.AddWithValue("@ProcesoExterno", procesoexterno);
                cmd.Parameters.AddWithValue("@CantidadEnviada", cantidadenviada);
                cmd.Parameters.AddWithValue("@GeneradaPor", generadapor);
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
            con.CerrarConexion();
            return respuesta;
        }


        public List<ProveedorMod> lista_EnviosProveedor(string ot, int idGuiaDet, int Procedimiento)
        {
            List<ProveedorMod> lista = new List<ProveedorMod>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Proveedor_ListaPliegos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@idGuiaDet", idGuiaDet);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProveedorMod des = new ProveedorMod();

                    des.id_Proveedor = reader["id_Proveedor"].ToString();
                    des.OT = reader["OT"].ToString();
                    des.NombreOT = reader["NombreOT"].ToString();
                    des.NombrePliego = reader["Pliego"].ToString().ToUpper();
                    des.Forma = reader["Forma"].ToString();
                    des.CantidadPliego = reader["TotalPliego"].ToString();
                    des.ProcesoExterno = reader["ProcesoExterno"].ToString();
                    des.Total = reader["CantidadEnviada"].ToString();
                    des.GeneradaPor = reader["GeneradaPor"].ToString();
                    des.FechaGeneracion = reader["FechaGeneracion"].ToString();
                    des.Estado = reader["Estado"].ToString();
                    lista.Add(des);
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}