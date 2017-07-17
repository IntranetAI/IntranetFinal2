using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloWip.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloWip.Controller
{
    public class Controller_Wip
    {
        public Wip BuscarWip_ControlPorCodigo(string Codigo, string TipoMaquina ="", string Usuario = "")
        {
            Wip wip = new Wip();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Buscar_ControlPorCodigo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@TipoMovil", TipoMaquina);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    wip.ID_Control = reader["ID_Control"].ToString();
                    wip.Fecha_Creacion = Convert.ToDateTime(reader["Fecha_Creacion"].ToString());
                    wip.NombreOT = reader["NombreOT"].ToString();
                    wip.OT = reader["OT"].ToString();
                    wip.Usuario = reader["Usuario_Creador"].ToString();
                    wip.Ubicacion = reader["Ubicacion"].ToString();
                    wip.Posicion = reader["Posicion"].ToString();
                    wip.ProxProceso = reader["Prox_Proceso"].ToString();
                    
                }
            }
            return wip;
        }

        public Wip BuscarPallet_Wip(string Codigo)
        {
            Wip wip = new Wip();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_BuscarPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    wip.ID_Control = reader["ID_Control"].ToString();
                    wip.NombreOT = reader["NombreOT"].ToString();
                    wip.OT = reader["OT"].ToString();
                    wip.Ubicacion = reader["Ubicacion"].ToString();
                    wip.Posicion = reader["Posicion"].ToString();
                    wip.PesoPallet = Convert.ToDouble(reader["Peso_Pallet"].ToString());
                    wip.PliegosImpresos = Convert.ToInt32(reader["Pliegos_Impresos"].ToString());
                    wip.EstadoPallet = Convert.ToInt32(reader["Estado_Pallet"].ToString());
                    wip.Tiraje = Convert.ToInt32(reader["Total_Tiraje"].ToString());
                    wip.Pliego = reader["Pliego"].ToString();
                    wip.Maquina = reader["Maquina_Origen"].ToString();
                    wip.ProxProceso = reader["Prox_Proceso"].ToString();
                }
            }
            return wip;
        }

        public string UbicacionSugLibre(string OT)
        {
            string result = "";
            string Recondacion = "Sin Recomendacion";
            string UbiRecom = "Sin Recomendacion";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Sug_InserPlis";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);

                SqlDataReader reader = cmd.ExecuteReader();

                int contador = 0;
                while (reader.Read())
                {
                    UbiRecom = reader["Ubicacion"].ToString();
                    if (contador < 4)
                    {
                        if (contador == 0)
                        {
                            Recondacion = "";
                        }
                        Recondacion = Recondacion + " " + reader["Nombre_Rack"].ToString();
                        contador++;
                    }
                }
                result = UbiRecom + ","+Recondacion;
            }

            return result;
        }

        public bool AsignarUbicacionPallet(string Codigo, string Ubicacion, string Usuario)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Update_AsignarPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Posicion", Ubicacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);

                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            return respuesta;
        }
        
        public List<Wip> ListaMaquinaProceso(int proceso)
        {
            List<Wip> lista = new List<Wip>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_ListMaquina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Area", "Encuadernacion");
                cmd.Parameters.AddWithValue("@proceso", proceso);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Wip wp = new Wip();
                    wp.Maquina = reader["Maquina"].ToString();
                    wp.ID_Control = reader["CodigoMaquina"].ToString();
                    lista.Add(wp);
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public bool ConsumirPorEnc(string Codigo, string Maquina, string Usuario)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Consum_Pallet2";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.ExecuteNonQuery();
                return true;
            }

            return respuesta;
        }

        public bool ConsumirPorServicioExterno(string Codigo, string Maquina, string Usuario, string Proceso)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Consum_PalletSerExt";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Proceso", Proceso);
                cmd.ExecuteNonQuery();
                return true;
            }

            return respuesta;
        }

        public bool UpdatePallet(string Codigo, int Cantidad, double Peso, string Usuario)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_UpdatePallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Peso", Peso);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.ExecuteNonQuery();
                return true;
            }

            return respuesta;
        }

        public bool EliminarPallet(string Codigo, string Observacion, string Usuario)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Wip_Pistola_EliminarPallet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = Convert.ToBoolean(reader["respuesta"].ToString());
                }
            }
            con.CerrarConexion();
            return respuesta;

        }
    }
}