using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloEncuadernacion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloEncuadernacion.Controller
{
    public class Controller_Distribucion
    {
        public List<Distribucion> ListarRegistro(string Gerencia, string Marca, string Estado)
        {
            List<Distribucion> lista = new List<Distribucion>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Encua_DistribucionListar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Gerencia", Gerencia);
                    cmd.Parameters.AddWithValue("@Marca", Marca);
                    cmd.Parameters.AddWithValue("@Estado", Estado);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Distribucion dis = new Distribucion();
                        dis.Gerencia = reader["Nombre_gerencia"].ToString();
                        dis.Sector = reader["Sector_Nombre"].ToString();
                        dis.Destinatario = reader["Destinatario"].ToString();
                        dis.Domicilio = reader["Domicilio"].ToString();
                        dis.Localidad = reader["Localidad"].ToString();
                        dis.Retiro = Convert.ToDateTime(reader["Retiro"].ToString());
                        if (reader["Cajas_Revista"].ToString() != "")
                        {
                            dis.Caja_Revista = reader["Cajas_Revista"].ToString();
                        }
                        else
                        {
                            dis.Caja_Revista = reader["Cajas_ensobrados"].ToString();
                        }
                        dis.caja_ensobrado = (Convert.ToInt32(reader["falta"].ToString())*-1).ToString();
                        dis.CodigoBarra = reader["CodigoBarra"].ToString();
                        dis.Marca = reader["Marca"].ToString();
                        dis.Estado = reader["NombreEstado"].ToString();
                        lista.Add(dis);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public Distribucion InsertarCodigoBarra(string CodigoBarra, string Usuario)
        {
            Distribucion dis = new Distribucion();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Encua_Distibucion_insertproducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", CodigoBarra);
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        dis.Gerencia = reader["Marca"].ToString();
                        dis.Sector = reader["cTotal"].ToString();
                        dis.Destinatario = (Convert.ToInt32(reader["cfalta"].ToString())*-1).ToString();
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return dis;
        }

        public List<Distribucion> ListarDistribucionNatura(string Gerencia, string Marca, string Ciclo, string Estado)
        {
            List<Distribucion> lista = new List<Distribucion>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Enc_Distribucion_ListarNatura";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Gerencia", Gerencia);
                    cmd.Parameters.AddWithValue("@Marca", Marca);
                    cmd.Parameters.AddWithValue("@Estado", Estado);
                    cmd.Parameters.AddWithValue("@Ciclo", Ciclo);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Distribucion dis = new Distribucion();
                        dis.Gerencia = reader["Gerencia"].ToString();
                        dis.Sector = reader["Sector"].ToString();
                        dis.Destinatario = reader["Destinatario"].ToString();
                        dis.Domicilio = reader["Domicilio"].ToString();
                        dis.Localidad = reader["Localidad"].ToString();
                        dis.Retiro = Convert.ToDateTime(reader["Fecha_Retiro"].ToString());
                        if (reader["Cajas_Revista"].ToString() != "")
                        {
                            dis.Caja_Revista = reader["Cajas_Revista"].ToString();
                        }
                        else
                        {
                            dis.Caja_Revista = reader["Cajas_Ensobrados"].ToString();
                        }
                        dis.caja_ensobrado = (Convert.ToInt32(reader["falta"].ToString()) * -1).ToString();
                        dis.CodigoBarra = reader["CodigoBarra"].ToString();
                        dis.Marca = reader["Material"].ToString();
                        dis.Estado = reader["Estado"].ToString();
                        dis.Nombre_Cajas = reader["CajasOT"].ToString();
                        lista.Add(dis);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

    }
}