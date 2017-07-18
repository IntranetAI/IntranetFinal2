using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloWip.Model;

namespace Intranet.ModuloWip.Controller
{
    public class Controller_Login
    {
        public static bool Login_sistema(string usuario, string passw)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "[SP_LoginSistemaPistola]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Password", passw);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;
                conexion.CerrarConexion();
            }
            return respuesta;
        }

        public Login_Sistema buscarPorID(string Usuario)
        {
            Login_Sistema ls = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "LoginSistema_Buscar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ls = new Login_Sistema();

                    ls.IDLogin = Convert.ToInt32(reader["idUsuario"].ToString());
                    ls.Nombre = reader["Nombre"].ToString();
                    ls.Usuario = reader["Usuario"].ToString();
                    ls.Password = reader["Passw"].ToString();
                    ls.Correo = reader["Correo"].ToString();
                    ls.estado = Convert.ToInt32(reader["Estado"].ToString());
                    ls.CentroCosto = reader["CentroCosto"].ToString();


                }

                conexion.CerrarConexion();
            }

            return ls;
        }

        //public Productos MostarInfo(string codigo)
        //{

        //    Productos pro = new Productos();
        //    Conexion conexion = new Conexion();
        //    SqlCommand cmd = conexion.AbrirConexionProduccion();

        //    if (cmd != null)
        //    {
        //        cmd.CommandText = "SP_ListarInf_Pistola";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Codigo", codigo);

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {

        //            //pro.Proceso = reader["NombreProceso"].ToString();
        //            pro.OP = reader["OP"].ToString();
        //            pro.NombreOP = reader["NombreOP"].ToString();
        //            //pro.Terminacion = reader["Terminacion"].ToString();
        //            //pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
        //            //pro.Cantidad = reader["Cantidad"].ToString();
        //            //pro.Ejemplares = reader["Ejemplares"].ToString();
        //            //pro.Total = reader["Total"].ToString();
        //            //pro.Codigo = reader["Codigo"].ToString();
        //            //pro.FechaCreacion = reader["FechaCreacion"].ToString();

        //            //
        //            //
        //            //pro.FechaRecepcion = reader["FechaRecepcion"].ToString();
        //            //pro.RecepcionadoPor = reader["RecepcionadoPor"].ToString();
        //            pro.Ubicacion = reader["Ubicacion"].ToString();
        //            //pro.FechaSalida = reader["FechaSalida"].ToString();

        //        }

        //        conexion.CerrarConexion();
        //    }

        //    return pro;
        //}
        //fin procedimiento mostrarinfo


        //public bool Insert_Ubicacion_Nueva(string codigo, string codigoUbicacion, string ubicacion, string operador)
        //{
        //    Conexion conexion = new Conexion();
        //    SqlDataReader dr;
        //    bool respuesta = false;
        //    SqlCommand cmd = conexion.AbrirConexionProduccion();
        //    try
        //    {

        //        cmd.CommandText = "[SP_Insert_New_Ubicacion]";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        cmd.CommandTimeout = 30;
        //        cmd.Parameters.AddWithValue("@Codigo", codigo);
        //        cmd.Parameters.AddWithValue("@CodigoUbicacion", codigoUbicacion);
        //        cmd.Parameters.AddWithValue("@Ubicacion", ubicacion);
        //        cmd.Parameters.AddWithValue("@Operador", operador);

        //        dr = cmd.ExecuteReader();

        //        if (dr.Read())
        //        {
        //            respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //        conexion.CerrarConexion();

        //    }
        //    return respuesta;
        //}



        //public string ValidaUbicacion(string Codigo)
        //{
        //    string resultado = "";
        //    Conexion con = new Conexion();
        //    SqlCommand cmd = con.AbrirConexionProduccion();
        //    if (cmd != null)
        //    {
        //        cmd.CommandText = "[SP_validaUbicacion]";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Codigo", Codigo);
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            resultado = reader["NombreUbicacion"].ToString();
        //        }
        //        con.CerrarConexion();
        //    }
        //    return resultado;
        //}
    }
}