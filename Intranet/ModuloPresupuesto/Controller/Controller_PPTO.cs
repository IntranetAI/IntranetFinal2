using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloPresupuesto.Model;

namespace Intranet.ModuloPresupuesto.Controller
{
    public class Controller_PPTO
    {
        public double TarifaPreprensa(string Color)
        {
            double resultado = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "PPTO_CostoPreprensa";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Color", Color);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resultado = Convert.ToDouble(reader["CostoFijo"].ToString());
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public double TarifaImpresion(string Color, string TipoImpresion, string TipoCosto, string Maquina)
        {
            double resultado = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "PPTO_CostoImpresion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@TipoComponente", TipoImpresion);
                cmd.Parameters.AddWithValue("@TipoCosto", TipoCosto);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (TipoCosto == "Fijo")
                    {
                        resultado = Convert.ToDouble(reader["CostoFijo"].ToString());
                    }
                    else
                    {
                        resultado = Convert.ToDouble(reader["CostoVariable"].ToString());
                    }
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public double TarifaMerma(string Color, string TipoImpresion, string TipoCosto, string Maquina)
        {
            double resultado = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "PPTO_CostoMerma";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@TipoComponente", TipoImpresion);
                cmd.Parameters.AddWithValue("@TipoCosto", TipoCosto);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (TipoCosto == "Fijo")
                    {
                        resultado = Convert.ToDouble(reader["CostoFijoMerma"].ToString());
                    }
                    else
                    {
                        resultado = Convert.ToDouble(reader["CostoVariableMerma"].ToString());
                    }
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public double TarifaTerminaciones(string TipoTerminacion, string TipoCosto)
        {
            double resultado = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "PPTO_CostoTerminaciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoTerminacion", TipoTerminacion);
                cmd.Parameters.AddWithValue("@TipoCosto", TipoCosto);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (TipoCosto == "Fijo")
                    {
                        resultado = Convert.ToDouble(reader["CostoFijo"].ToString());
                    }
                    else
                    {
                        resultado = Convert.ToDouble(reader["CostoVariable"].ToString());
                    }
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public double TarifaEncuadernacion(string TipoEncuadernacion, string TipoCosto, int CantidadEntradas, string Empresa)
        {
            double resultado = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "PPTO_CostoEncuadernacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoEncuadernacion", TipoEncuadernacion);
                cmd.Parameters.AddWithValue("@CantidadEntradas", CantidadEntradas);
                cmd.Parameters.AddWithValue("@TipoCosto", TipoCosto);
                cmd.Parameters.AddWithValue("@Empresa", Empresa);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (TipoCosto == "Fijo")
                    {
                        resultado = Convert.ToDouble(reader["CostoFijo"].ToString());
                    }
                    else
                    {
                        resultado = Convert.ToDouble(reader["CostoVariable"].ToString());
                    }
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public double TarifaDespacho(string TipoCosto, string Empresa, string TipoDespacho)
        {
            double resultado = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "PPTO_CostoDespacho";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoDespacho", TipoDespacho);
                cmd.Parameters.AddWithValue("@TipoCosto", TipoCosto);
                cmd.Parameters.AddWithValue("@Empresa", Empresa);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (TipoCosto == "Fijo")
                    {
                        resultado = Convert.ToDouble(reader["CostoFijo"].ToString());
                    }
                    else
                    {
                        resultado = Convert.ToDouble(reader["CostoVariable"].ToString());
                    }
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public List<Presupuesto> ListarTarifaPapel(string Componente)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "PPTO_ListarPapeles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Componente", Componente);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Presupuesto ppto = new Presupuesto();
                    ppto.NombrePapel = reader["TipoPapel"].ToString();
                    lista.Add(ppto);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        
        public List<Presupuesto> ListarTarifaGramajePapel(string Componente, string TipoPapel)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "PPTO_ListarGramajePapeles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Componente", Componente);
                cmd.Parameters.AddWithValue("@TipoPapel", TipoPapel);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Presupuesto ppto = new Presupuesto();
                    ppto.Gramaje = reader["Gramaje"].ToString();
                    ppto.ValorPapel = reader["FacturaCL"].ToString();
                    lista.Add(ppto);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        
    }
}