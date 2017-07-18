using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloDespacho.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloDespacho.Controller
{
    public class Controller_GuiaDespacho
    {
        public List<Distribuccion_excel> ListarDistribuccion(string OT)
        {
            List<Distribuccion_excel> lista = new List<Distribuccion_excel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Guia_ListarDistribuccion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT",OT);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Distribuccion_excel dist = new Distribuccion_excel();
                    dist.Sucursal = reader["Sucursal"].ToString();
                    dist.Rut = reader["Rut"].ToString();
                    dist.Embalaje = reader["Embalaje"].ToString();
                    dist.Comuna = reader["comuna"].ToString();
                    //dist.Cant_Bultos = Convert.ToInt32(reader["Bulto"].ToString());
                    dist.Cant_porbult = Convert.ToInt32(reader["Cantidad"].ToString());
                    dist.OT = reader["OT"].ToString();
                    lista.Add(dist);
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public bool AgregarGuiaDesp(GuiaDespacho_Detalle guia)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_AgregarGuiaDesp";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut",guia.Rut);
                cmd.Parameters.AddWithValue("@Sucursal", guia.Sucursal);
                cmd.Parameters.AddWithValue("@Comuna", guia.Comuna);
                cmd.Parameters.AddWithValue("@Usuario",guia.Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento",0);
                cmd.Parameters.AddWithValue("@OT",guia.OT);
                cmd.Parameters.AddWithValue("@NombreOT","");
                cmd.Parameters.AddWithValue("@Cantidad", guia.CantXBulto);
                cmd.Parameters.AddWithValue("@Tip_Embalaje",guia.Embalaje);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    respuesta = Convert.ToBoolean(reader["respuesta"].ToString());
                }
                con.CerrarConexion();

            }
            return respuesta;
        }

        public bool InsertDistribuccion(string query)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.CerrarConexion();
                return true;
            }
            else
            {
                con.CerrarConexion();
                return false;
            }
        }
    }
}       