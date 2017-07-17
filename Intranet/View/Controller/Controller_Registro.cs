using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.View.Model;

namespace Intranet.View.Controller
{
    public class Controller_Registro
    {
        public bool RegistroUsuario(string nombre,string rut,string usuario, string passw,string correo ,int pin,string cargo,string centrocosto)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "RegistroUsuario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Rut", rut);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Password", passw);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Pin", pin);
                cmd.Parameters.AddWithValue("@Cargo", cargo);
                cmd.Parameters.AddWithValue("@CentroCosto", centrocosto);

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

        public LoginSistema verificarRUT(int rut)
        {
            LoginSistema ls = new LoginSistema();
      
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionSV2008();
            if (cmd != null)
            {
                //cmd.CommandText = "Select  [rut_trabajador],[nombre],[ape_paterno_trabaj],[ape_materno_trabaj] FROM [winper].[dbo].[personal] where [rut_trabajador]=" + rut;
                cmd.CommandText = "Select  p.[rut_trabajador],p.[nombre],p.[ape_paterno_trabaj],p.[ape_materno_trabaj],ct.cargo_trabajador,cc.centro_costo" +
                                  " FROM [winper].[dbo].[personal] p"+
                                  " inner join cargo_trabajador ct on p.cod_cargo=ct.cod_cargo"+
                                  " inner join centro_costo cc on p.cod_centro_costo=cc.cod_centro_costo"+
                                  " where p.rut_trabajador=" + rut;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ls.Nombre = reader["nombre"].ToString() + " " + reader["ape_paterno_trabaj"].ToString() + " " + reader["ape_materno_trabaj"].ToString();
                    ls.cargo = reader["cargo_trabajador"].ToString();
                    ls.CentroCosto = reader["centro_costo"].ToString();
                }
            }
            con.CerrarConexion();
            return ls;
        }
        public  LoginSistema ActivarUsuariosCorreo(string CentroCosto)
        {
            LoginSistema ls = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "SP_ActivarUsuario";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CentroCosto", CentroCosto);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ls = new LoginSistema();

                    ls.Nombre = reader["Nombre"].ToString();
                    ls.Correo = reader["Correo"].ToString();


                }

            }
            conexion.CerrarConexion();

            return ls;
        }


    }
}