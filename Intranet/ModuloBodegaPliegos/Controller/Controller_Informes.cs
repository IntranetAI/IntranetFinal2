using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloBodegaPliegos.Model;

namespace Intranet.ModuloBodegaPliegos.Controller
{
    public class Controller_Informes
    {
        public List<BodegaPliegos> InformeStock(string SKU,string Papel,int Gramaje,int Ancho,int Largo,string Marca,string Certificacion, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_InformeStock";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SKU", SKU);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", Gramaje);
                cmd.Parameters.AddWithValue("@Ancho", Ancho);
                cmd.Parameters.AddWithValue("@Largo", Largo);
                cmd.Parameters.AddWithValue("@Marca", Marca);
                cmd.Parameters.AddWithValue("@Certificacion", Certificacion);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = reader["CodigoItem"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.Marca = reader["Marca"].ToString().ToLower();
                    d.Certificacion = reader["Certificacion"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.Pliegos = reader["Pliegos"].ToString();
                    d.Kilos = reader["SaldoStock"].ToString();
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
    }
}