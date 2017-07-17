using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.View.Model;

namespace Intranet.View.Controller
{
    public class Controller_Login
    {
        public static bool Login_sistema(string usuario, string passw, int pin)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "LoginSistema";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Password", passw);
                cmd.Parameters.AddWithValue("@Pin", pin);

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

        public int BuscarIDUsuario(string login)
        {
            int IDUsuario = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "LoginSistema_Buscar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", login);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDUsuario = Convert.ToInt32(reader["idusuario"].ToString());
                        return IDUsuario;
                    }
                    else
                    {
                        return IDUsuario = 0;
                    }
                }
                catch
                {
                    return IDUsuario = 0;
                }
            }
            else
            {
                return IDUsuario = 0;
            }
            con.CerrarConexion();
        }
     
        public LoginSistema buscarPorID(string Usuario)
        {
            LoginSistema ls = null;
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
                     ls = new LoginSistema();

                     ls.IDLogin = Convert.ToInt32(reader["idUsuario"].ToString());
                     ls.Nombre = reader["Nombre"].ToString();
                     ls.Usuario = reader["Usuario"].ToString();
                     ls.Password = reader["Passw"].ToString();
                     ls.Correo = reader["Correo"].ToString();
                     ls.estado = Convert.ToInt32(reader["Estado"].ToString());
                     ls.CentroCosto = reader["CentroCosto"].ToString();
                     ls.user = reader["Perfil"].ToString();
                   
                }

            }
            conexion.CerrarConexion();

            return ls;
        }
        public bool ActivarEnvioMensaje(string Usuario)
        {
            Boolean respuesta = true;

            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if(cmd!= null)
            {
                cmd.CommandText = "User_ActivMensaje";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = false;
                }
            }
            con.CerrarConexion();
            return respuesta;
        }
    }
}