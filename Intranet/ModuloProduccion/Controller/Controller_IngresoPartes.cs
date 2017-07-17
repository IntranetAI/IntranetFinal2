using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloProduccion.Controller
{
    public class Controller_IngresoPartes
    {
        public string Carga_CodigoParte(string Codigo)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionDataP2B2000_PARTES();

            if (cmd != null)
            {
                cmd.CommandText = "[IngresoPartes_Codigos]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idParte", Codigo);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["Nombre_Operacion"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;
        }

        public PartesIngreso Carga_CodigoParte_V2(string idParte)
        {
            PartesIngreso pp = new PartesIngreso();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "IngresoPartes_BuscaPliegos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", idParte);
                cmd.Parameters.AddWithValue("@Procedimiento", 1);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pp.Codigo = reader["Codigo"].ToString();
                    pp.Malos = reader["ingresoCantidad"].ToString();
                }
            }
            conexion.CerrarConexion();

            return pp;
        }

        public string Carga_NombreOT(string OT)
        {
            string res = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[IngresoPartes_BuscaOT]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader["NombreOT"].ToString();
                }
            }
            conexion.CerrarConexion();
            return res;   
        }

        public int IngresarDetalleParte(PartesIngreso p, int procedimiento)
        {
            SqlDataReader dr;
            int respuesta = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "IngresoPartes_Agregar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maquina", p.Maquina);
                cmd.Parameters.AddWithValue("@FechaParte", p.FechaParte);
                cmd.Parameters.AddWithValue("@Turno", p.Turno);
                cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@OT", p.OT);
                cmd.Parameters.AddWithValue("@Pliego", p.Pliego);
                cmd.Parameters.AddWithValue("@NombreOT", p.NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", p.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", p.FechaTermino);
                cmd.Parameters.AddWithValue("@Buenos", p.Buenos);
                cmd.Parameters.AddWithValue("@Malos", p.Malos);
                cmd.Parameters.AddWithValue("@Usuario", p.Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                cmd.Parameters.AddWithValue("@Factor", p.Factor);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;

            }
            con.CerrarConexion();
            return respuesta;
        }

        public int IngresarDetalleParte_V2(PartesIngreso p, int procedimiento)
        {
            SqlDataReader dr;
            int respuesta = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "[IngresoPartes_Agregar_V2]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maquina", p.Maquina);
                cmd.Parameters.AddWithValue("@FechaParte", p.FechaParte);
                cmd.Parameters.AddWithValue("@Turno", p.Turno);
                cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@OT", p.OT);
                cmd.Parameters.AddWithValue("@Pliego", p.Pliego);
                cmd.Parameters.AddWithValue("@NombreOT", p.NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", p.FechaInicio);
                cmd.Parameters.AddWithValue("@Buenos", p.Buenos);
                cmd.Parameters.AddWithValue("@Malos", p.Malos);
                cmd.Parameters.AddWithValue("@Usuario", p.Usuario);
                cmd.Parameters.AddWithValue("@Factor", p.Factor);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;

            }
            con.CerrarConexion();
            return respuesta;
        }


        public List<PartesIngreso> Lista_Detalle(PartesIngreso p, int Procedimiento)
        {
            List<PartesIngreso> lista = new List<PartesIngreso>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "IngresoPartes_Agregar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maquina", p.Maquina);
                cmd.Parameters.AddWithValue("@FechaParte", p.FechaParte);
                cmd.Parameters.AddWithValue("@Turno", p.Turno);
                cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@OT", p.OT);
                cmd.Parameters.AddWithValue("@Pliego", p.Pliego);
                cmd.Parameters.AddWithValue("@NombreOT", p.NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", p.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", p.FechaTermino);
                cmd.Parameters.AddWithValue("@Buenos", p.Buenos);
                cmd.Parameters.AddWithValue("@Malos", p.Malos);
                cmd.Parameters.AddWithValue("@Usuario", p.Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.Parameters.AddWithValue("@Factor", p.Factor);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PartesIngreso pp = new PartesIngreso();
                    pp.idParte = reader["id_Parte"].ToString();
                    pp.Maquina = reader["Maquina"].ToString();
                    pp.FechaParte = Convert.ToDateTime(reader["FechaParte"].ToString()).ToString("dd/MM/yyyy");
                    pp.Turno = reader["Turno"].ToString();
                    pp.Codigo = reader["Codigo"].ToString();
                    pp.Factor = reader["User1"].ToString();
                    pp.OT = reader["OT"].ToString();
                    pp.Pliego = reader["Pliego"].ToString();
                    pp.NombreOT = reader["NombreOT"].ToString().ToLower();
                    pp.FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    pp.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    pp.Buenos = reader["Buenos"].ToString();
                    pp.Malos = reader["Malos"].ToString();
                    pp.VerMas = //"<a style='Color:Black;text-decoration:none;cursor:pointer;' href='javascript:Modificar(\"" + pp.idParte + "\")'><img border='0' src='../../images/write-message.png' alt='Editar Registro' title='Editar Registro' width='25' ></a>" +
                    "&nbsp;<a style='Color:Black;text-decoration:none;cursor:pointer;' href='javascript:Eliminar(\"" + pp.idParte + "\")'><img border='0' src='../../images/delete_icon.PNG' alt='Eliminar Registro' title='Eliminar Registro' width='20' ></a>";
                    lista.Add(pp);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }
        public PartesIngreso Carga_Modifica(string idParte, int Procedimiento)
        {
            PartesIngreso pp = new PartesIngreso();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "IngresoPartes_CargaModificar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idParte", idParte);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pp.idParte = reader["id_Parte"].ToString();
                    pp.Maquina = reader["Maquina"].ToString();
                    pp.FechaParte = reader["FechaParte"].ToString();
                    pp.Turno = reader["Turno"].ToString();
                    pp.Codigo = reader["Codigo"].ToString();
                    pp.OT = reader["OT"].ToString();
                    pp.Pliego = reader["Pliego"].ToString();
                    pp.NombreOT = reader["NombreOT"].ToString().ToLower();
                    pp.FechaInicio = reader["FechaInicio"].ToString();
                    pp.Buenos = reader["Buenos"].ToString();
                    pp.Malos = reader["Malos"].ToString();
                    pp.Factor = reader["user1"].ToString();
                }

            }
            conexion.CerrarConexion();

            return pp;
        }
        public bool Eliminarregistro(string idParte, int Procedimiento)
        {
            SqlDataReader dr;
            bool respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "IngresoPartes_CargaModificar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idParte", idParte);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;

            }
            con.CerrarConexion();
            return respuesta;
        }
        public bool FechaAnterior(string usuario, DateTime fecha)
        {
            SqlDataReader dr;
            bool respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "IngresoPartes_Anterior";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;

            }
            con.CerrarConexion();
            return respuesta;
        }
        public bool CambiaEstado(string usuario)
        {
            SqlDataReader dr;
            bool respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "IngresoPartes_CambiaEstado";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;

            }
            con.CerrarConexion();
            return respuesta;
        }
        public bool EliminaPendientes(string usuario)
        {
            SqlDataReader dr;
            bool respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "IngresoPartes_EliminarPendientes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;

            }
            con.CerrarConexion();
            return respuesta;
        }


        public List<PartesIngreso> Lista_DetalleModi(string usuario, int Procedimiento)
        {
            List<PartesIngreso> lista = new List<PartesIngreso>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "IngresoPartes_CargaModificar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idParte", usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PartesIngreso pp = new PartesIngreso();
                    pp.idParte = reader["id_Parte"].ToString();
                    pp.Maquina = reader["Maquina"].ToString();
                    pp.FechaParte = Convert.ToDateTime(reader["FechaParte"].ToString()).ToString("dd/MM/yyyy");
                    pp.Turno = reader["Turno"].ToString();
                    pp.Codigo = reader["Codigo"].ToString();
                    pp.Factor = reader["User1"].ToString();
                    pp.OT = reader["OT"].ToString();
                    pp.Pliego = reader["Pliego"].ToString();
                    pp.NombreOT = reader["NombreOT"].ToString().ToLower();
                    pp.FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    pp.FechaTermino = Convert.ToDateTime(reader["FechaTermino"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    pp.Buenos = reader["Buenos"].ToString();
                    pp.Malos = reader["Malos"].ToString();
                    pp.VerMas = //"<a style='Color:Black;text-decoration:none;cursor:pointer;' href='javascript:Modificar(\"" + pp.idParte + "\")'><img border='0' src='../../images/write-message.png' alt='Editar Registro' title='Editar Registro' width='25' ></a>" +
                    "&nbsp;&nbsp;&nbsp;<a style='Color:Black;text-decoration:none;cursor:pointer;' href='javascript:Eliminar(\"" + pp.idParte + "\")'><img border='0' src='../../images/delete_icon.PNG' alt='Eliminar Registro' title='Eliminar Registro' width='20' ></a>";
                    lista.Add(pp);
                }

            }
            conexion.CerrarConexion();

            return lista;
        }


        public bool ModificarRegistros(PartesIngreso p)
        {
            SqlDataReader dr;
            bool respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "[IngresoPartes_Modificar]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idParte", p.idParte);
                cmd.Parameters.AddWithValue("@Maquina", p.Maquina);
                cmd.Parameters.AddWithValue("@FechaParte", p.FechaParte);
                cmd.Parameters.AddWithValue("@Turno", p.Turno);
                cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@OT", p.OT);
                cmd.Parameters.AddWithValue("@Pliego", p.Pliego);
                cmd.Parameters.AddWithValue("@FechaInicio", p.FechaInicio);
                cmd.Parameters.AddWithValue("@Buenos", p.Buenos);
                cmd.Parameters.AddWithValue("@Malos", p.Malos);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;

            }
            con.CerrarConexion();
            return respuesta;
        }


        public List<PartesIngreso> CargaPliegos(string ot, int procedimiento)
        {
            List<PartesIngreso> lista = new List<PartesIngreso>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "IngresoPartes_BuscaPliegos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartesIngreso d = new PartesIngreso();
                    d.Pliego = reader["Pliego"].ToString();
                    lista.Add(d);
                }
            }
            con.CerrarConexion();
            return lista;
        }

    }
}