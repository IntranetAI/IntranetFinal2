using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloJefatura.Model;

namespace Intranet.ModuloAdmin.Controller
{
    public class Controller_Usuarios
    {
        public List<Usuarios> ListarUsuarios(int filt,string Usuario)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Conexion con = new Conexion();
            
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "SP_Administrador";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filt", filt);
                cmd.Parameters.AddWithValue("@jefatura",Usuario);
                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuarios task = new Usuarios();
                    task.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                    task.passw = reader["Passw"].ToString();
                    task.nombre = reader["Nombre"].ToString();
                    task.Usuario = reader["Usuario"].ToString();
                    task.correo = reader["Correo"].ToString();

                    lista.Add(task);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<Usuarios> ListarUsuariosFiltro(int filt, string Usuario, string Username, string nombre, string correo)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Conexion con = new Conexion();

            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "SP_Administrador";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filt", filt);
                cmd.Parameters.AddWithValue("@jefatura", Usuario);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("Nombre", nombre);
                cmd.Parameters.AddWithValue("Correo", correo);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuarios task = new Usuarios();
                    task.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                    task.passw = reader["Passw"].ToString();
                    task.nombre = reader["Nombre"].ToString();
                    task.Usuario = reader["Usuario"].ToString();
                    task.correo = reader["Correo"].ToString();

                    lista.Add(task);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool usuarioInactivos(List<Activar> list)
        {
            string insert = "";
            foreach (Activar asi in list)
            {
                insert = insert + "Update Intranet2.dbo.Usuarios set Estado=1 where Usuario='" + asi.Usuario + "';";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }

        public List<Usuarios> ListarDeshabilitados(int filt)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Conexion con = new Conexion();

            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "SP_Administrador";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filt", filt);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuarios task = new Usuarios();
                    task.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                    task.passw = reader["Passw"].ToString();
                    task.nombre = reader["Nombre"].ToString();
                    task.Usuario = reader["Usuario"].ToString();
                    task.correo = reader["Correo"].ToString();

                    lista.Add(task);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool usuarioDeshabilitados(List<Activar> list)
        {
            string insert = "";
            foreach (Activar asi in list)
            {
                insert = insert + "Update Intranet2.dbo.Usuarios set Estado=1 where Usuario='" + asi.Usuario + "';";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }

        public List<Usuarios> ListarAllUsuarios(int filt)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Conexion con = new Conexion();

            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "SP_Administrador";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filt", filt);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuarios task = new Usuarios();
                    task.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                    task.passw = reader["Passw"].ToString();
                    task.nombre = reader["Nombre"].ToString();
                    task.Usuario = reader["Usuario"].ToString();
                    task.correo = reader["Correo"].ToString();

                    lista.Add(task);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool DeshabilitarUsuarios(List<Activar> list)
        {
            string insert = "";
            foreach (Activar asi in list)
            {
                insert = insert + "Update Intranet2.dbo.Usuarios set Estado=2 where Usuario='" + asi.Usuario + "';";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }


        public List<Modulos> ListarModulosUsuario(int filt, int IDUsuario,string jefatura)
        {
            List<Modulos> lista = new List<Modulos>();
            Conexion con = new Conexion();

            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "SP_Asignacion_Usuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filt", filt);
                cmd.Parameters.AddWithValue("@idUsuario", IDUsuario);
                cmd.Parameters.AddWithValue("@nombrejefatura", jefatura);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Modulos task = new Modulos();
                    task.IDModulo = Convert.ToInt32(reader["idModulo"].ToString());
                    task.Nombre_modulo = reader["Nombre_Mod"].ToString();
                    task.desc_modulo = reader["Url_Modulo"].ToString();

                    lista.Add(task);
                }
            }
            con.CerrarConexion();
            return lista;
        }


        public bool AsignarModulos(List<Modulos> list, int IDUsuario)
        {
            string insert = "";
            foreach (Modulos asi in list)
            {
                insert = insert + "insert into Intranet2.dbo.usuario_modulos values(" + IDUsuario + "," + asi.IDModulo + ");";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }
        public bool DesasignarModulos(List<Modulos> list, int IDUsuario)
        {
            string insert = "";
            foreach (Modulos asi in list)
            {
                insert = insert + "delete from Intranet2.dbo.usuario_modulos where idUsuario="+IDUsuario+" and idModulo="+asi.IDModulo+";";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }
        public bool CambiarInactivoCorreo(int? IDUsuario)
        {
            string insert = "";

                insert = insert + "update intranet2.dbo.usuarios set Estado=1 where idUsuario=" + IDUsuario + ";";
            
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarSolicitud(int? IDUsuario)
        {
            string insert = "";

            insert = insert + "delete from intranet2.dbo.usuarios where idUsuario=" + IDUsuario + ";";

            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionIntranet();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }
    }
}