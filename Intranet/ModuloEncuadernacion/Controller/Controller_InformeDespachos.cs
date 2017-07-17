using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloEncuadernacion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloEncuadernacion.Controller
{
    public class Controller_InformeDespachos
    {
        public List<MProductosTerminados> ListaDespachosEnc(string OT,DateTime FechaInicio,DateTime FechaTermino,int Procedimiento)
        {
            List<MProductosTerminados> lista = new List<MProductosTerminados>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "Encuadernacion_InformeDespachos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                { 
                    MProductosTerminados p = new MProductosTerminados();
                    p.OT = reader["OT"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString().ToLower();
                    p.Tiraje = Convert.ToInt32(reader["Tiraje"].ToString()).ToString("N0").Replace(",", ".");
                    p.Despachado = Convert.ToInt32(reader["Despachado"].ToString()).ToString("N0").Replace(",", ".");
                    p.Devolucion = "<div style='color:Red;'>" + Convert.ToInt32(reader["Devolucion"].ToString()).ToString("N0").Replace(",", ".") + "</div>";

                    int tiraje = Convert.ToInt32(reader["Tiraje"].ToString());
                    int despachado = Convert.ToInt32(reader["Despachado"].ToString());
                    int devolucion = Convert.ToInt32(reader["Devolucion"].ToString());
                    int resultado = Convert.ToInt32(tiraje - despachado - devolucion);
                    p.CantCajas = Convert.ToInt32(reader["CantCajas"].ToString()).ToString("N0").Replace(",", ".");

                    if (resultado < 0)
                    {
                        p.Saldo = "<div style='color:Green;'>" + (resultado * -1).ToString("N0").Replace(",", ".") + "</div>";
                    }
                    else
                    {
                        p.Saldo = "<div style='color:Red;'>" + (resultado).ToString("N0").Replace(",", ".") + "</div>";
                    }




                    p.VerDetalle = "<a style='Color:Blue;text-decoration:none;' href='javascript:openPopUp(\"" + p.OT.Trim() + "\",\"" + p.NombreOT.Trim() + "\")'>Ver Detalle</a>";
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }
    }
}