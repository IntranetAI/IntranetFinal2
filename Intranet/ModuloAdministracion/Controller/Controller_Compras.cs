using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloAdministracion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloAdministracion.Controller
{
    public class Controller_Compras
    {
        public List<Compras_Model> ListarCompras(int Procedimiento, string NroPedido, string CodItem, string Proveedor, string FechaInicio, string FechaTermino, string Estado)
        {
            List<Compras_Model> lista = new List<Compras_Model>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            
            if (cmd != null)
            {
                cmd.CommandText = "Adquisicion_ListarCompras";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Procedimiento",Procedimiento);
                cmd.Parameters.AddWithValue("@NroPedido",NroPedido);
                cmd.Parameters.AddWithValue("@CodItem",CodItem);
                cmd.Parameters.AddWithValue("@Proveedor",Proveedor);
                cmd.Parameters.AddWithValue("@FechaInicio",FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino",FechaTermino);
                cmd.Parameters.AddWithValue("@Estado",Estado);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Compras_Model compra = new Compras_Model();
                    compra.NroPedido = reader["NroPedido"].ToString();
                    compra.Fecha_Orden = Convert.ToDateTime(reader["DtPedido"].ToString()).ToString("dd-MM-yyyy");
                    compra.Termino_Pago = reader["CondPagto"].ToString();
                    compra.Contacto = reader["Contato"].ToString();
                    compra.Proveedor = reader["Nome"].ToString();
                    compra.Email = reader["eMailContato"].ToString();
                    compra.Fecha_Entrega = Convert.ToDateTime(reader["DtEntrega"].ToString()).ToString("dd-MM-yyyy");
                    compra.CodItem = reader["CodItem"].ToString();
                    compra.Descripcion = reader["Descricao"].ToString();
                    compra.CantidadSoli = reader["QuantidadeFolha"].ToString() + " " + reader["Unidade"].ToString();
                    compra.CantidadRecep = reader["QuantidadeAtendidaFolha"].ToString() + " " + reader["UnidadeFolha"].ToString();
                    compra.ValorUnitario = reader["ValorUnitario"].ToString();
                    compra.Total = reader["ValorTotal"].ToString();
                    compra.Estado = reader["Estado"].ToString();
                    lista.Add(compra);
                }
                con.CerrarConexion();
            }
            return lista;
        }
    }
}