using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloBodegaPliegos.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloBodegaPliegos.Controller
{
    public class Controller_Devoluciones
    {
        public List<BodegaPliegos> ListaDevoluciones(string ot, string maquina, string nropallet, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_Devoluciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Maquina", maquina);
                cmd.Parameters.AddWithValue("@NroPallet", nropallet);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.NroPallet = reader["FolioPallet"].ToString();
                    d.OT = reader["OT"].ToString();
                    d.Componente = reader["Componente"].ToString();
                    d.CodigoProducto=reader["SKU"].ToString();
                    d.Papel = reader["Papel"].ToString().ToLower();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.SolicitadoFL = reader["CantidadAsignada"].ToString();
                    d.FechaCreacion = Convert.ToDateTime(reader["Fecha"].ToString()).ToString("dd/MM/yyyy");
                    d.Accion = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Procesar(\"" + d.NroPallet + "\",\"" + d.CodigoProducto + "\",\"" + d.Papel + "\",\"" + d.Gramaje + "\",\"" + d.Ancho + "\",\"" + d.Largo + "\");'>Procesar</a>";
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public BodegaPliegos CargaDevoluciones(string ot, string maquina, string nropallet, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            BodegaPliegos d = new BodegaPliegos();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_Devoluciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Maquina", maquina);
                cmd.Parameters.AddWithValue("@NroPallet", nropallet);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    d.NroPallet = reader["FolioPallet"].ToString();
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString();
                    d.Componente = reader["Componente"].ToString();
                    d.CodigoProducto = reader["sku"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.SolicitadoFL = reader["CantidadAsignada"].ToString();
                    d.Procedencia = reader["Procedencia"].ToString();
                }

            }
            con.CerrarConexion();
            return d;
        }
        public BodegaPliegos CargaFaltantes(string ot, string maquina, string nropallet, DateTime fechainicio, DateTime fechatermino, int procedimiento)
        {
            Conexion con = new Conexion();
            BodegaPliegos d = new BodegaPliegos();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_Devoluciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Maquina", maquina);
                cmd.Parameters.AddWithValue("@NroPallet", nropallet);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    d.Pliegos = reader["pliegos"].ToString();

                }

            }
            con.CerrarConexion();
            return d;
        }
        public string InsertarDevolucion(string Folio,string OT,string NombreOT,string Componente,string SKU,string Papel,int Gramaje,int Ancho,int Largo,
            int Pliegos, double Peso, string MotivoDevolucion, string Procedencia, string Usuario,int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            string respuesta = "";
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "BodegaPliegos_IngresaDevolucion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Folio", Folio);
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@SKU", SKU);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", Gramaje);
                cmd.Parameters.AddWithValue("@Ancho", Ancho);
                cmd.Parameters.AddWithValue("@Largo", Largo);
                cmd.Parameters.AddWithValue("@Pliegos", Pliegos);
                cmd.Parameters.AddWithValue("@Peso", Peso);
                cmd.Parameters.AddWithValue("@MotivoDevolucion", MotivoDevolucion);
                cmd.Parameters.AddWithValue("@Procedencia", Procedencia);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = dr["respuesta"].ToString();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return respuesta;
        }

        public List<BodegaPliegos> CargaInformeTrazabilidad(string ot, string Componente,string NroPallet, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_InformeTrazabilidad";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@NroPallet", NroPallet);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.Proceso = reader["Proceso"].ToString();
                    d.NroPallet = reader["Folio"].ToString();
                    d.OT = reader["OT"].ToString();
                    d.Componente = reader["Componente"].ToString();
                    d.CodigoProducto = reader["sku"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.Pliegos = reader["Pliegos"].ToString();
                    d.Kilos = reader["Kilos"].ToString();
                    d.CostoMedio = reader["CostoMedio"].ToString();
                    d.Usuario = reader["CreadoPor"].ToString();
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy");
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
    }

}