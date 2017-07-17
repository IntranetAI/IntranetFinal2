using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloPreprensa.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloPreprensa.Controller
{
    public class Controller_Preprensa
    {
        public Preprensa CargaSolicitud(string ot,int procedimiento)
        {
            Preprensa d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Preprensa_CargaSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new Preprensa();
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString();
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy");
                    d.Cliente = reader["Cliente"].ToString();
                    d.CSR = reader["CSR"].ToString();
                    d.FormatoCerrado = reader["FormatoCerrado"].ToString();
                    d.Tiraje = Convert.ToInt32(reader["TirajeOT"].ToString()).ToString("N0").Replace(",", ".");
                    d.RutCliente = reader["RutCliente"].ToString().Replace("-", "");

                }
            }
            conexion.CerrarConexion();
            return d;
        }
        public List<Preprensa> CargaDirecciones(string ot, int procedimiento)
        {
            List<Preprensa> lista = new List<Preprensa>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Preprensa_CargaSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Preprensa d = new Preprensa();
                    d.Direccion = reader["CALLESUCURSAL"].ToString();
                    d.IDDireccion = reader["IDSucursal"].ToString();
                    lista.Add(d);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public Preprensa CargaDetalleDireccion(string IDDireccion,string Direccion, int procedimiento)
        {
            Preprensa d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Preprensa_CargaDetalleDirecciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDDireccion", IDDireccion);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new Preprensa();
                    d.Pais = reader["NombrePais"].ToString();
                    d.Ciudad = reader["NombreCiudad"].ToString();
                    d.Comuna = reader["NombreComuna"].ToString();
                    d.Region = reader["NombreRegion"].ToString();
                    d.Tipo = reader["Tipo"].ToString();
                    d.NroTipo = reader["nrotipo"].ToString();
                    d.Piso = reader["Piso"].ToString();
                    d.Contacto = reader["contacto"].ToString();
                    d.CodTelefono = reader["CodTelefono"].ToString();
                    d.AreaTelefono = reader["AreaTelefono"].ToString();
                    d.Telefono = reader["Telefono"].ToString();
                    d.AreaCelular = reader["AreaCelular"].ToString();
                    d.Celular = reader["Celular"].ToString();
                    d.Correo = reader["Correo"].ToString();

                }
            }
            conexion.CerrarConexion();
            return d;
        }
        public bool EliminaDireccionesPendientes(string IDDireccion, string Direccion, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = false;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Preprensa_CargaDetalleDirecciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDDireccion", IDDireccion);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
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
            conexion.CerrarConexion();
            return respuesta;
        }
        public List<Preprensa> CargaTipos(string ot, int procedimiento)
        {
            List<Preprensa> lista = new List<Preprensa>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Preprensa_CargaSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Preprensa d = new Preprensa();
                    d.Direccion = reader["CALLESUCURSAL"].ToString();
                    d.IDDireccion = reader["IDSucursal"].ToString();
                    lista.Add(d);
                }
            }
            con.CerrarConexion();
            return lista;
        }


        public bool AgregaDireccion(string IDDireccion,string RutCliente,string Cliente, string Direccion, string Pais, string Region, string Ciudad, string Comuna, string Tipo, string NroTipo, string Piso, string Contacto,string CodTelefono,string AreaTelefono, string Telefono,string AreaCelular, string Celular, string Correo, string Observacion,string Usuario,int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Preprensa_AddDirecciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@IDDireccion", IDDireccion);
                cmd.Parameters.AddWithValue("@RutCliente", RutCliente);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Pais", Pais);
                cmd.Parameters.AddWithValue("@Region", Region);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@Comuna", Comuna);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@NroTipo", NroTipo);
                cmd.Parameters.AddWithValue("@Piso", Piso);
                cmd.Parameters.AddWithValue("@Contacto", Contacto);
                cmd.Parameters.AddWithValue("@CodTelefono", CodTelefono);
                cmd.Parameters.AddWithValue("@AreaTelefono", AreaTelefono);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@AreaCelular", AreaCelular);
                cmd.Parameters.AddWithValue("@Celular", Celular);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@CreadoPor", Usuario);
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
            conexion.CerrarConexion();
            return respuesta;
        }
        public string muestrDirecciones(string ot, int procedimiento)
        {
            string resultado = "[";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Preprensa_CargaSolicitud";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        resultado +=
                            "{_Cliente_:_" + reader["cliente"].ToString() + "_,_Direccion_:_" + reader["Direccion"].ToString() + "_,_Comuna_:_" + reader["Comuna"].ToString() +
                                    "_,_Tipo_:_" + reader["Tipo"].ToString() + "_,_NroTipo_:_" + reader["NroTipo"].ToString() + "_,_Piso_:_" + reader["piso"].ToString() + "_,_Contacto_:_" +
                                    reader["contacto"].ToString() + "_,_Observacion_:_" + reader["observacion"].ToString() + "_,_Editar_:_Editars_},";
                            //"{*Cliente*:*" + reader["cliente"].ToString() + "*,*Direccion*:*" + reader["Direccion"].ToString() + "*,*Comuna*:*" + reader["Comuna"].ToString() +
                            //        "*,*Tipo*:*" + reader["Tipo"].ToString() + "*,*NroTipo*:*" + reader["NroTipo"].ToString() + "*,*Piso*:*" + reader["piso"].ToString() + "*,*Contacto*:*" +
                            //        reader["contacto"].ToString() + "*,*Observacion*:*" + reader["observacion"].ToString() + "*},";
                    }
                    resultado = resultado.Substring(0, resultado.Length - 1) + "]";
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return resultado;
        }
        //
        public int AgregaRequerimiento(string OT, string NombreOT, string Cliente, string RutCliente, DateTime FechaVB, int HoraVB, int MinutoVB, int PagColor, int PagImproof, int PagArmado, string TipoArchivo, string RevisaCSR, string Observacion, string Usuario, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "[Preprensa_AddRequerimiento]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@RutCliente", RutCliente);
                cmd.Parameters.AddWithValue("@FechaVB", FechaVB);
                cmd.Parameters.AddWithValue("@HoraVB", HoraVB);
                cmd.Parameters.AddWithValue("@MinutoVB", MinutoVB);
                cmd.Parameters.AddWithValue("@PagColor", PagColor);
                cmd.Parameters.AddWithValue("@PagImproof", PagImproof);
                cmd.Parameters.AddWithValue("@PagArmado", PagArmado);
                cmd.Parameters.AddWithValue("@TipoArchivo", TipoArchivo);
                cmd.Parameters.AddWithValue("@RevisaCSR", RevisaCSR);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@CreadoPor", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

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
            conexion.CerrarConexion();
            return respuesta;
        }
        public string cargaRequerimientos(string ot, int procedimiento)
        {
            string resultado = "[";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Preprensa_CargaSolicitud";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        resultado +=
                            "{_NroRequerimiento_:_" + reader["id_Requerimiento"].ToString() + "_,_FechaVB_:_" + Convert.ToDateTime(reader["FechaVB"].ToString()).ToString("dd/MM/yyyy HH:mm") + "_,_PagColor_:_" + reader["PagColor"].ToString() +
                                    "_,_PagImproof_:_" + reader["PagImproof"].ToString() + "_,_PagArmado_:_" + reader["PagArmado"].ToString() + "_,_TipoArchivo_:_" + reader["TipoArchivo"].ToString() + "_,_RevisaCSR_:_" +
                                    reader["RevisaCSR"].ToString() + "_,_Observacion_:_" + reader["observacion"].ToString() + "_,_CreadoPor_:_" + reader["CreadoPor"].ToString() + "_,_FechaCreacion_:_" + Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm") + "_,_Direcciones_:_" + "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:VerSolicitud("+reader["id_Requerimiento"].ToString()+");'>Ver</a>" + "_},";//\"" + reader["id_Requerimiento"].ToString() + "\"
                    }
                    resultado = resultado.Substring(0, resultado.Length - 1) + "]";
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return resultado;
        }
        //Preprensa_CargaModificar
        public Preprensa CargaParaModificar(string IDRequerimiento, int procedimiento)
        {
            Preprensa d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Preprensa_CargaModificar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDRequerimiento", IDRequerimiento);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new Preprensa();
                    d.FechaVB = Convert.ToDateTime(reader["FechaVB"].ToString()).ToString("dd/MM/yyyy");
                    d.HoraVB = reader["HoraVB"].ToString();
                    d.MinutoVB = reader["MinutoVB"].ToString();
                    d.PagColor = reader["PagColor"].ToString();
                    d.PagImproof = reader["PagImproof"].ToString();
                    d.PagArmado = reader["PagArmado"].ToString();
                    d.TipoArchivo = reader["TipoArchivo"].ToString();
                    d.RevisaCSR = reader["RevisaCSR"].ToString();
                    d.Observacion = reader["Observacion"].ToString();
                    d.Estado = reader["Estado"].ToString();
                }
            }
            conexion.CerrarConexion();
            return d;
        }
        public string cargaDireccionesaEditar(string idRequerimiento, int procedimiento)
        {
            string resultado = "[";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Preprensa_CargaModificar]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDRequerimiento", idRequerimiento);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        resultado +=
                            "{_Cliente_:_" + reader["cliente"].ToString() + "_,_Direccion_:_" + reader["Direccion"].ToString() + "_,_Comuna_:_" + reader["Comuna"].ToString() +
                                    "_,_Tipo_:_" + reader["Tipo"].ToString() + "_,_NroTipo_:_" + reader["NroTipo"].ToString() + "_,_Piso_:_" + reader["piso"].ToString() + "_,_Contacto_:_" +
                                    reader["contacto"].ToString() + "_,_Observacion_:_" + reader["observacion"].ToString() + "_,_Editar_:_" + "<button type='button'   data-toggle='modal' data-target='#InsertoModal' onclick='javascript:VerDireccionEdit(" + reader["id_Direccion"].ToString() + ");' ><span></span>Modificar</button>" + "_},";
                    }
                    resultado = resultado.Substring(0, resultado.Length - 1) + "]";
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public Preprensa cargaDireccionesaEdit(string idDireccion, int procedimiento)
        {
            Preprensa d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Preprensa_CargaModificar]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDRequerimiento", idDireccion);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new Preprensa();
                    d.IDDireccion = reader["id_Direccion"].ToString();
                    d.Direccion = reader["Direccion"].ToString();
                    d.Pais = reader["Pais"].ToString();
                    d.Region = reader["Region"].ToString();
                    d.Comuna = reader["Comuna"].ToString();
                    d.Ciudad = reader["Ciudad"].ToString();
                    d.Tipo = reader["Tipo"].ToString();
                    d.NroTipo = reader["NroTipo"].ToString();
                    d.Piso = reader["Piso"].ToString();
                    d.Contacto = reader["Contacto"].ToString();
                    d.CodTelefono = reader["CodTelefono"].ToString();
                    d.AreaTelefono = reader["AreaTelefono"].ToString();
                    d.Telefono = reader["Telefono"].ToString();
                    d.AreaCelular = reader["AreaCelular"].ToString();
                    d.Celular = reader["Celular"].ToString();
                    d.Correo = reader["Correo"].ToString();
                    d.Observacion = reader["Observacion"].ToString();
                }
            }
            conexion.CerrarConexion();
            return d;
        }

        public bool ModificaDireccion(string IDDireccion, string Direccion, string Tipo, string NroTipo, string Piso, string Contacto, string CodTelefono, string AreaTelefono, string Telefono, string AreaCelular, string Celular, string Correo, string Observacion, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = false;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Preprensa_AddDirecciones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@IDDireccion", IDDireccion);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@NroTipo", NroTipo);
                cmd.Parameters.AddWithValue("@Piso", Piso);
                cmd.Parameters.AddWithValue("@Contacto", Contacto);
                cmd.Parameters.AddWithValue("@CodTelefono", CodTelefono);
                cmd.Parameters.AddWithValue("@AreaTelefono", AreaTelefono);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@AreaCelular", AreaCelular);
                cmd.Parameters.AddWithValue("@Celular", Celular);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
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
            conexion.CerrarConexion();
            return respuesta;
        }
    }
}