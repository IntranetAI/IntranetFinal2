using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloAdministracion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloAdministracion.Controller
{
    public class TipDocument_Controller
    {
        public List<TipDocumento> listaTipDoc()
        {
            List<TipDocumento> lista = new List<TipDocumento>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                cmd.CommandText = "getTiposDocumento";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    TipDocumento tip = new TipDocumento();
                    tip.IDTipDoc = Convert.ToInt32(reader["id_tipo_documento_mercantil"].ToString());
                    tip.TipDoc = reader["nombre_tipo_documento_mercantil"].ToString();
                    lista.Add(tip);
                }
                
            }
            con.CerrarConexion();
            return lista;
        }
    }
}