using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloAdmin.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloAdmin.Controller
{
    public class Help_Desk_Controller
    {
        public List<ModelHelpDesk> ListarMesaAyuda()
        {
            List<ModelHelpDesk> lista = new List<ModelHelpDesk>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "HelpDesk_ListarHelpDesk";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ModelHelpDesk help = new ModelHelpDesk();
                        help.Incidencia = reader["Nombre_Incidencia"].ToString();
                        help.NivelIncidencia = reader["Nivel_Incidencia"].ToString();
                        string[] str = reader["Nombre"].ToString().Split(' ');
                        try
                        {
                            help.Usuario = str[0] + " " + str[2];
                        }
                        catch
                        {
                            help.Usuario = reader["Nombre"].ToString();
                        }
                        help.Area = reader["Area"].ToString();
                        help.FeIncidencia = Convert.ToDateTime(reader["Fecha_Incidencia"].ToString()).ToString("dd-MM-yyyy");
                        help.FeSolucion = Convert.ToDateTime(reader["Fecha_Solucion"].ToString()).ToString("dd-MM-yyyy");
                        help.Solucion = "Ver Más";
                        lista.Add(help);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<ModelHelpDesk> ListarTipoIncidencia()
        {
            List<ModelHelpDesk> lista = new List<ModelHelpDesk>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "HelpDesk_ListarTipoIncidencia";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ModelHelpDesk help = new ModelHelpDesk();
                        help.IDIncidencia = Convert.ToInt32(reader["ID_HelpDesk_TipoIncidencia"].ToString());
                        help.Incidencia = reader["Nombre_TipoIncidencia"].ToString();
                        lista.Add(help);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<ModelHelpDesk> ListarIncidencia(string IDTipoIncidencia)
        {
            List<ModelHelpDesk> lista = new List<ModelHelpDesk>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "HelpDesk_ListarIncidencia";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTipo", IDTipoIncidencia);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        ModelHelpDesk help = new ModelHelpDesk();
                        help.IDIncidencia = Convert.ToInt32(reader["ID_HelpDesk_Incidencia"].ToString());
                        help.Incidencia = reader["Nombre_Incidencia"].ToString();
                        lista.Add(help);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<ModelHelpDesk> ListarAreas()
        {
            List<ModelHelpDesk> lista = new List<ModelHelpDesk>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "HelpDesk_ListarAreas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ModelHelpDesk help = new ModelHelpDesk();
                        help.Incidencia = reader["Nombre_Area"].ToString();
                        lista.Add(help);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public Boolean AgregarIncidencia(ModelHelpDesk helpDesk)
        {
            bool resultado = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "HelpDesk_Agregar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Area",helpDesk.Area);
                    cmd.Parameters.AddWithValue("@Depto", helpDesk.Depto);
                    cmd.Parameters.AddWithValue("@Estado", helpDesk.Estado);
                    cmd.Parameters.AddWithValue("@FeIncidencia", helpDesk.FeIncidencia);
                    cmd.Parameters.AddWithValue("@IDIncidencia", helpDesk.IDIncidencia);
                    cmd.Parameters.AddWithValue("@Incidencia", helpDesk.Incidencia);
                    cmd.Parameters.AddWithValue("@Observacion", helpDesk.Observacion);
                    cmd.Parameters.AddWithValue("@Usuario",helpDesk.Usuario);
                    cmd.ExecuteNonQuery();
                    resultado = true;
                }
                catch
                {
                    resultado = false;
                }
            }
            return resultado;
        }
    }
}