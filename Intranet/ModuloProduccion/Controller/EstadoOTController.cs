using Intranet.ModuloProduccion.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Controller
{
    public class EstadoOTController
    {
        public List<Informe_EstadosOT> Listado_EstadoOT(string Ot, string nombreOT, string Cliente, DateTime FechaInicio, DateTime FechaTermino,string Estado, int Procedimiento)
        {
            List<Informe_EstadosOT> lista = new List<Informe_EstadosOT>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            string not = "";
            try
            {
                if (cmd != null)
                {
                    cmd.CommandText = "Logistica_InformeEstadoOT";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", Ot);
                    cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                    cmd.Parameters.AddWithValue("@Cliente", Cliente);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    cmd.Parameters.AddWithValue("@Estado", Estado);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    cmd.CommandTimeout = 99999999;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Informe_EstadosOT p = new Informe_EstadosOT();
                        p.OT = reader["NumOrdem"].ToString();
                        not = p.OT;
                        p.NombreOT = reader["descricao"].ToString().ToLower();
                        p.Cliente = reader["nomeCliente"].ToString().ToLower();
                        p.FechaEmision = Convert.ToDateTime(reader["dtEmissao"].ToString()).ToString("dd/MM/yyyy");
                        p.FechaEntrega = ((reader["FechaEntrega"].ToString() == null || reader["FechaEntrega"].ToString() == "") ? "" : Convert.ToDateTime(reader["FechaEntrega"].ToString()).ToString("dd/MM/yyyy HH:mm"));
                        p.Tiraje = Convert.ToInt32(reader["Tiraje"].ToString()).ToString("N0").Replace(",", ".");
                        p.Estado = reader["Estado"].ToString();
                        lista.Add(p);
                    }

                }
            }catch(Exception ex)
            {
                string a = not;
            }
            conexion.CerrarConexion();
            return lista;
        }

    }
}