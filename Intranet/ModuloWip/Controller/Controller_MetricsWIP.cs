using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloWip.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloWip.Controller
{
    public class Controller_MetricsWIP
    {
        public List<Model_MetricsWIP> Lista_InformeMetricsWIP(string OT,string Pliego,string Bodega,DateTime FechaInicio,DateTime FechaTermino,string Estado, int Procedimiento)
        {
            List<Model_MetricsWIP> lista = new List<Model_MetricsWIP>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Metrics_InformeWIP";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliegos", Pliego);
                cmd.Parameters.AddWithValue("@Bodega", Bodega);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_MetricsWIP w = new Model_MetricsWIP();
                    w.OT = reader["OT"].ToString().Trim();
                    w.NombreOT = reader["NombreOT"].ToString().Trim().ToLower();
                    w.Ubicacion = reader["Local"].ToString().ToString().ToLower();
                    w.Posicion = reader["Ubicacion"].ToString();
                    w.Pallet = reader["idpalletlabel"].ToString();
                    w.Pallets = reader["Pallet"].ToString();

                    if (reader["Componente"].ToString().ToLower().Trim() == "enc")
                    {
                        w.Pliego = "<a title='" + reader["Processo"].ToString() + "'>" + reader["Processo"].ToString().Replace(reader["Componente"].ToString(), "").ToLower() + "</a>";
                    }
                    else
                    {
                        //    w.Pliego = "";// "<a title='" + reader["Processo"].ToString() + "'>" + reader["Processo"].ToString().Replace(reader["Componente"].ToString(), "") + "</a>";
                        //}
                        //else
                        //{
                        //    w.Pliego = "<a title='" + reader["Processo"].ToString() + "'>" + reader["Componente3"].ToString().Replace(reader["Componente"].ToString(), "") + "</a>";

                        //}
                        w.Pliego = "<a title='" + reader["Processo"].ToString() + "'>" + reader["Componente3"].ToString()+ "</a>";
                    }
                    w.CantidadPliegos = Convert.ToDouble(reader["Quantity"].ToString()).ToString("N0").Replace(",", ".");
                    w.CantidadKG = Convert.ToDouble(reader["QuantityKG"].ToString()).ToString("N2");
                    w.Estado = reader["Estado"].ToString();
                    w.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    w.Detalle = "<a style='Color:Blue;text-decoration:none;' href='javascript:OpenPopUP(\"" + w.Pallet + "\")'>Ver Más</a>";
                    lista.Add(w); 
                }
            }
            con.CerrarConexion();
            return lista;
        }


        public List<Model_MetricsWIP> listar_BodegasWip(string OT, string Pliego, string Bodega, DateTime FechaInicio, DateTime FechaTermino, string Estado, int Procedimiento)
        {
            List<Model_MetricsWIP> lista = new List<Model_MetricsWIP>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Metrics_InformeWIP";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliegos", Pliego);
                cmd.Parameters.AddWithValue("@Bodega", Bodega);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_MetricsWIP wip = new Model_MetricsWIP();
                    wip.Ubicacion = reader["IdStockPlace"].ToString();
                    wip.Posicion = reader["Name"].ToString();
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Model_MetricsWIP> listar_PliegosOT(string OT, string Pliego, string Bodega, DateTime FechaInicio, DateTime FechaTermino, string Estado, int Procedimiento)
        {
            List<Model_MetricsWIP> lista = new List<Model_MetricsWIP>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Metrics_InformeWIP";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliegos", Pliego);
                cmd.Parameters.AddWithValue("@Bodega", Bodega);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_MetricsWIP wip = new Model_MetricsWIP();
                    wip.Pliego = reader["Pliegos"].ToString();
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public Model_MetricsWIP Lista_Encabezado_HistorialPallet(string OT, string Pliego, string Bodega, DateTime FechaInicio, DateTime FechaTermino, string Estado, int Procedimiento)
        {
            Model_MetricsWIP w = new Model_MetricsWIP();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Metrics_InformeWIP";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliegos", "");
                cmd.Parameters.AddWithValue("@Bodega", "");
                cmd.Parameters.AddWithValue("@FechaInicio", DateTime.Now);
                cmd.Parameters.AddWithValue("@FechaTermino", DateTime.Now);
                cmd.Parameters.AddWithValue("@Estado", "0");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    w.OT = reader["NumOrdem"].ToString();
                    w.NombreOT = reader["Descricao"].ToString();
                    w.Pliego = reader["Processo"].ToString();
                    w.CantidadPliegos = Convert.ToInt32(reader["Quantity"].ToString()).ToString("N0").Replace(",", ".");
                    w.CantidadKG = Convert.ToDouble(reader["QuantityKG"].ToString()).ToString("N2");
                }
            }
            con.CerrarConexion();
            return w;
        }

        public List<Model_MetricsWIP> listar_HistorialPallet(string OT, string Pliego, string Bodega, DateTime FechaInicio, DateTime FechaTermino, string Estado, int Procedimiento)
        {
            List<Model_MetricsWIP> lista = new List<Model_MetricsWIP>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Metrics_InformeWIP";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Pliegos", "");
                cmd.Parameters.AddWithValue("@Bodega", "");
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Estado", "0");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_MetricsWIP wip = new Model_MetricsWIP();
                    wip.FechaCreacion = reader["FechaCreacion"].ToString();
                    wip.Usuario = reader["Usuario"].ToString();
                    wip.Ubicacion = reader["Local"].ToString().ToLower();
                    wip.Posicion = reader["Ubicacion"].ToString();
                    wip.Movimiento = reader["Movimiento"].ToString();
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }




        //MANTENEDOR ETIQUETAS
        public List<Model_MetricsWIP> listaBodegasMetrics(int Procedimiento)
        {
            List<Model_MetricsWIP> lista = new List<Model_MetricsWIP>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Wip_Metrics_Bodegas]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bodega", "");
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_MetricsWIP wip = new Model_MetricsWIP();
                    wip.Ubicacion = reader["Name"].ToString();
                    wip.idUbicacion = reader["IdStockPlace"].ToString();
                    lista.Add(wip);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Model_MetricsWIP> ListUbicaciones_Metrics(string idBodega, int Procedimiento)
        {
            List<Model_MetricsWIP> lista = new List<Model_MetricsWIP>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Wip_Metrics_Bodegas]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bodega", idBodega);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model_MetricsWIP w = new Model_MetricsWIP();
                    w.NombreUbicacion = reader["Address"].ToString();
                    w.Barcode = reader["Barcode"].ToString();
                    lista.Add(w);
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}