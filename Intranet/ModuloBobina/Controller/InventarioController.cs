using Intranet.ModuloBobina.Model;
using Intranet.ModuloRFrecuencia.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Intranet.ModuloBobina.Controller
{
    public class InventarioController
    {
        public int NuevoInventario(string Codigo)
        {
            Conexion con = new Conexion();int res = 0;
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Bodega_InventarioBobinas]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", Codigo);
                    cmd.Parameters.AddWithValue("@Inventario", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 0);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        res = Convert.ToInt32(reader["respuesta"].ToString());
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return res;
        }
        public int insertInventario(string Codigo, int Inventario)
        {
            Conexion con = new Conexion(); int res = 0;
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Bodega_InventarioBobinas]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", Codigo);
                    cmd.Parameters.AddWithValue("@Inventario", Inventario);
                    cmd.Parameters.AddWithValue("@Procedimiento", 1);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        res = Convert.ToInt32(reader["respuesta"].ToString());
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return res;
        }
        public string tablaInventario(int Inventario)
        {
            Conexion con = new Conexion(); string res = "";string encabezado = "<table id = 'tblRegistro' cellspacing = '0' cellpadding = '0' style = 'border: 1px solid rgb(204, 204, 204); width: 233px;' >" +
                    "<tbody><tr style = 'height: 22px; background: rgb(243, 244, 249); font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; font-stretch: normal; font-size: 11px; line-height: normal; font-family: arial, helvetica, sans-serif; color: rgb(0, 62, 126); text-align: left;' >" +
                    "<td style = 'font-weight: bold; padding: 4px 0px 0px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: center; width: 50px;' > Codigo </td >" +
               "</ tr >";
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Bodega_InventarioBobinas]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", "");
                    cmd.Parameters.AddWithValue("@Inventario", Inventario);
                    cmd.Parameters.AddWithValue("@Procedimiento", 2);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        res += "<tr style='height: 22px; background: rgb(255, 255, 255); font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; font-stretch: normal; font-size: 11px; line-height: normal; font-family: arial, helvetica, sans-serif; color: rgb(51, 51, 51); vertical-align: text-top;'>"+
                                "<td style = 'font-weight: normal; padding: 4px 0px 5px 5px; border-right: 1px solid rgb(204, 204, 204); text-align: right; width: 50px;' >"+reader["Codigo"].ToString()+"</td >"+
                                "</ tr > ";
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return ((res == "") ? "" : encabezado + res + "</tbody></table>");
        }
        public int BuscarInventario(string Inventario)
        {
            Conexion con = new Conexion(); int res = 0;
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Bodega_InventarioBobinas]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", Inventario);
                    cmd.Parameters.AddWithValue("@Inventario", 0);
                    cmd.Parameters.AddWithValue("@Procedimiento", 3);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        res = Convert.ToInt32(reader["Inventario"].ToString());
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return res;
        }

        public List<Inventario_bobinas> Listado_Codigos(string codigoInv)
        {
            List<Inventario_bobinas> lista = new List<Inventario_bobinas>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bodega_InventarioBobinas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", codigoInv);
                    cmd.Parameters.AddWithValue("@Inventario", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 4);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Inventario_bobinas b = new Inventario_bobinas();
                        b.Codigo = reader["Codigo"].ToString();
                        b.SKU = reader["SKU"].ToString();
                        b.Papel = reader["Papel"].ToString();
                        b.Fecha = Convert.ToDateTime(reader["Fecha"].ToString()).ToString("dd/MM/yyyy HH:mm");
                        b.Kilos = Convert.ToDouble(reader["Kilos"].ToString()).ToString("N2");
                        b.Bodega = reader["Bodega"].ToString();
                        b.Ubicacion = reader["Ubicacion"].ToString();
                        lista.Add(b);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<Inventario_Listado> Listado_Inventarios()
        {
            List<Inventario_Listado> lista = new List<Inventario_Listado>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bodega_InventarioBobinas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", "");
                    cmd.Parameters.AddWithValue("@Inventario", "");
                    cmd.Parameters.AddWithValue("@Procedimiento", 5);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Inventario_Listado b = new Inventario_Listado();
                        b.idInventario = reader["idInventario"].ToString();
                        b.NombreInventario = reader["NombreInventario"].ToString();
                        b.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm");
                        b.Accion = "<a style='Color:Blue;text-decoration:none;' href='javascript:CopiarId(\"" + b.idInventario + "\")'>Copiar ID</a>";
                        lista.Add(b);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public string EliminaInventario(int Inventario)
        {
            Conexion con = new Conexion(); string res = "Error";
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Bodega_InventarioBobinas]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", "");
                    cmd.Parameters.AddWithValue("@Inventario", Inventario);
                    cmd.Parameters.AddWithValue("@Procedimiento", 6);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        res = reader["respuesta"].ToString();
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return res;
        }
    }
}