using Intranet.ModuloBodegaPliegos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Intranet.ModuloBodegaPliegos.Controller
{
    public class Controller_BodegaPliegos
    {
        public List<BodegaPliegos> OPSCreadas(string ot,string nombreot,string nombrepapel,string codigopapel,DateTime fechainicio,DateTime fechatermino,int estado,string usuario,int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OPSCreadas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                cmd.Parameters.AddWithValue("@NombrePapel",nombrepapel);
                cmd.Parameters.AddWithValue("@CodigoPapel",codigopapel);
                cmd.Parameters.AddWithValue("@FechaInicio",fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino",fechatermino);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy");
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString().ToLower();
                    d.Componente = reader["Componente"].ToString();
                    d.Papel = reader["NombrePapel"].ToString();
                    //d.FormatoPapel = reader["FormatoPapel"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.SolicitadoFL = Convert.ToInt32(reader["ConsumoPL"].ToString()).ToString("N0").Replace(",", ".");
                    d.SolicitadoKG = Convert.ToInt32(reader["ConsumoKG"].ToString()).ToString("N0").Replace(",", ".");
                    
                    d.Accion = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Solicitud(\"" + d.OT + "\",\"" + d.Componente + "\",\"" + reader["ConsumoPL"].ToString() + "\",\"" + reader["ConsumoKG"].ToString() + "\",\"" + usuario + "\");'>Procesar</a>";

                    d.Procesado = Convert.ToInt32(reader["AsignadoPL"].ToString()).ToString("N0").Replace(",", ".");
                    int soliFL = Convert.ToInt32(reader["ConsumoPL"].ToString());
                    int asigFL = Convert.ToInt32(reader["AsignadoPL"].ToString());
                    if (asigFL > 0)
                    {
                        if (soliFL > asigFL)
                        {
                            d.Estado = "<div style='color:DarkOrange;'>Parcialmente Atendida</div>";
                        }
                        else
                        {
                            d.Estado = "<div style='color:Green;'>Atendida</div>";
                        }
                    }
                    else
                    {
                        d.Estado = "<div style='color:red;'>Sin Atender</div>";
                    }

                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public BodegaPliegos BuscaOTComponente(string ot, string nombreot, string nombrepapel, string codigopapel, DateTime fechainicio, DateTime fechatermino, int estado, int procedimiento)
        {
            BodegaPliegos d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OPSCreadas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                cmd.Parameters.AddWithValue("@NombrePapel", nombrepapel);
                cmd.Parameters.AddWithValue("@CodigoPapel", codigopapel);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new BodegaPliegos();
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy");
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString().ToLower();
                    d.Componente = reader["Componente"].ToString();
                    d.Papel = reader["NombrePapel"].ToString();
                    d.FormatoPapel = reader["FormatoPapel"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.SolicitadoFL = Convert.ToInt32(reader["ConsumoPL"].ToString()).ToString("N0").Replace(",", ".");
                    d.SolicitadoKG = Convert.ToInt32(reader["ConsumoKG"].ToString()).ToString("N0").Replace(",", ".");
                    if (reader["CodigoPapel"].ToString() == "0")
                    {
                        d.CodigoProducto = "Sin Código";
                    }
                    else
                    {
                        d.CodigoProducto = reader["CodigoPapel"].ToString();
                    }
                    d.Cliente = reader["Cliente"].ToString();
                }
            }
            conexion.CerrarConexion();
            return d;
        }
        public List<BodegaPliegos> BobinasMetrics(string ot,string componente,string codigoproducto, string Papel,int gramaje, int ancho, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_BobinasMetrics";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoProducto", codigoproducto);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@SolFL", 0);
                cmd.Parameters.AddWithValue("@SolGK", 0);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read() )
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = reader["ExtRef"].ToString();
                    d.Marca = reader["MakerName"].ToString().ToLower();
                    d.Papel = reader["Name"].ToString().ToLower();
                    d.Gramaje = Convert.ToInt32(reader["Weight"].ToString()).ToString();
                    d.Ancho = Convert.ToInt32(reader["Width"].ToString()).ToString();
                    d.Largo = "0";
                    if (d.Papel.Contains("pefc"))
                    {
                        d.Certificacion = "PEFC";
                    }
                    else
                    {
                        d.Certificacion = "-";
                    }
                    d.StockFL = Convert.ToInt32(reader["Cantidad"].ToString()).ToString();
                    d.Antiguedad = Convert.ToDateTime(reader["ManufactureDt"].ToString()).ToString("dd/MM/yyyy");
                    d.Seleccionar = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Solicitud(\"" + ot + "\",\"" + componente + "\",\"" + reader["ExtRef"].ToString() + "\");'>Solicitar</a>";
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        } 

        public List<BodegaPliegos> StockBodegaPliegos(string ot, string componente, string codigoproducto, string Papel, int gramaje, int ancho,int solFL,int solKG,string PREID,string usuario, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_BobinasMetrics";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoProducto", codigoproducto);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@SolFL", solFL);
                cmd.Parameters.AddWithValue("@SolGK", solKG);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = reader["CodigoItem"].ToString();
                   // d.Marca = reader["Familia"].ToString().ToLower();
                    d.Papel = reader["Papel"].ToString().ToLower();
                    d.Gramaje = Convert.ToInt32(reader["Gramaje"].ToString()).ToString();
                    d.Ancho = Convert.ToInt32(reader["Ancho"].ToString()).ToString();
                    d.Largo = Convert.ToInt32(reader["Largo"].ToString()).ToString();
                    d.Certificacion = "-";
                    d.StockFL = Convert.ToInt32(reader["SaldoStock"].ToString()).ToString();
                    d.Asignar = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Asignar(\"" + reader["id_Saldo"].ToString() + "\",\"" + ot + "\",\"" + componente + "\",\"" + solFL + "\",\"" + solKG + "\",\"" + PREID + "\",\"" + usuario + "\");'>Asignar</a>";
                    d.Inventario = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Consultar(\"" + ot + "\",\"" + componente + "\",\"" + Papel + "\",\"" + gramaje + "\",\"" + ancho + "\",\"" + PREID + "\",\"" + usuario + "\");'>Inventario</a>";
                    d.Antiguedad = "???";
                    lista.Add(d);
                }
                if (reader.Read() == false)
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = "";
                    // d.Marca = reader["Familia"].ToString().ToLower();
                    d.Papel = "";
                    d.Gramaje = "";
                    d.Ancho = "";
                    d.Largo = "";
                    d.Certificacion = "-";
                    d.StockFL = "";
                    d.Asignar = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Asignar(\"" + "" +"\",\"" + ot + "\",\"" + componente + "\",\"" + solFL + "\",\"" + solKG + "\",\"" + PREID + "\",\"" + usuario + "\");'>Asignar</a>";
                    d.Inventario = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Consultar(\"" + ot + "\",\"" + componente + "\",\"" + Papel + "\",\"" + gramaje + "\",\"" + ancho + "\",\"" + PREID + "\",\"" + usuario + "\");'>Inventario</a>";
                    d.Antiguedad = "???";
                    lista.Add(d);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public BodegaPliegos AsignarPapelStock(string ot, string componente, string codigoproducto, string Papel, int gramaje, int ancho, int solFL, int solKG, int procedimiento)
        {
            BodegaPliegos d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_BobinasMetrics";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoProducto", codigoproducto);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    d = new BodegaPliegos();
                    d.CodigoProducto = reader["CodigoItem"].ToString();
                   // d.Familia = reader["Familia"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.Gramaje = Convert.ToInt32(reader["Gramaje"].ToString()).ToString();
                    d.Ancho = Convert.ToInt32(reader["Ancho"].ToString()).ToString();
                    d.Largo = Convert.ToInt32(reader["Largo"].ToString()).ToString();
                    d.Certificacion = "-";
                    d.Antiguedad = "???";
                    d.StockFL = Convert.ToInt32(reader["SaldoStock"].ToString()).ToString();
                    d.SolicitadoFL = solFL.ToString();
                    d.Ubicacion =  reader["UbicacionStock"].ToString();
                    

                }

            }
            conexion.CerrarConexion();

            return d;
        }
        public int InsertAsignarPapelCorte(string ot,string componente,string idpapel,int cantidadasignada,string usuario,int procedimiento)
        {
            int IDUsuario = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BodegaPliegos_AsignarPapelCorte";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@Componente", componente);
                    cmd.Parameters.AddWithValue("@idPapel", idpapel);
                    cmd.Parameters.AddWithValue("@CantidadAsignada", cantidadasignada);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDUsuario = Convert.ToInt32(reader["id"].ToString());
                        return IDUsuario;
                    }
                    else
                    {
                        return IDUsuario = 0;
                    }
                }
                catch
                {
                    return IDUsuario = 0;
                }
            }
            else
            {
                return IDUsuario = 0;
            }
            con.CerrarConexion();
        }

        public int InsertAsignarPapel(string ot,string componente,string preid,int idpapel,string codigo,string papel,int gramaje,int ancho,int largo,string certificacion,int cantidadasignada,string antiguedad,string usuario,int procedimiento,int factor)
        {
            int IDUsuario = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BodegaPliegos_AsignarPapel";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@Componente", componente);
                    cmd.Parameters.AddWithValue("@Preid",preid);
                    cmd.Parameters.AddWithValue("@idPapel", idpapel);
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    cmd.Parameters.AddWithValue("@Papel", papel);
                    cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                    cmd.Parameters.AddWithValue("@Ancho", ancho);
                    cmd.Parameters.AddWithValue("@Largo", largo);
                    cmd.Parameters.AddWithValue("@Certificacion", certificacion);
                    cmd.Parameters.AddWithValue("@CantidadAsignada", cantidadasignada);
                    cmd.Parameters.AddWithValue("@Factor",factor);
                    cmd.Parameters.AddWithValue("@Antiguedad", antiguedad);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDUsuario = Convert.ToInt32(reader["id"].ToString());
                        return IDUsuario;
                    }
                    else
                    {
                        return IDUsuario = 0;
                    }
                }
                catch
                {
                    return IDUsuario = 0;
                }
            }
            else
            {
                return IDUsuario = 0;
            }
            con.CerrarConexion();
        }

        public List<BodegaPliegos> ListadoPapelAsignado(string ot, string componente, string codigo, string papel, int gramaje, int ancho, int largo, string certificacion, int cantidadasignada, string antiguedad, string usuario, string PREID,int idpapel,int procedimiento,int factor)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_AsignarPapel";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Componente", componente);
                cmd.Parameters.AddWithValue("@Preid", PREID);
                cmd.Parameters.AddWithValue("@idPapel", idpapel);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Papel", papel);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@Largo", largo);
                cmd.Parameters.AddWithValue("@Certificacion", certificacion);
                cmd.Parameters.AddWithValue("@CantidadAsignada", cantidadasignada);
                cmd.Parameters.AddWithValue("@Factor", factor);
                cmd.Parameters.AddWithValue("@Antiguedad", antiguedad);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.ID = reader["id_asignacion"].ToString();
                    d.CodigoProducto = reader["Codigo"].ToString();
                    // d.Marca = reader["Familia"].ToString().ToLower();
                    d.Ubicacion = "-";
                    d.Papel = reader["Papel"].ToString().ToLower();
                    d.Gramaje = Convert.ToInt32(reader["Gramaje"].ToString()).ToString();
                    d.Ancho = Convert.ToInt32(reader["Ancho"].ToString()).ToString();
                    d.Largo = Convert.ToInt32(reader["Largo"].ToString()).ToString();
                    d.Certificacion = "-";
                    d.StockFL = Convert.ToInt32(reader["CantidadAsignada"].ToString()).ToString();
                    d.Accion = "&nbsp;&nbsp;<a style='Color:Black;text-decoration:none;cursor:pointer;' href='javascript:openGame(\"" + d.ID + "\")'><img border='0' src='../../images/delete_icon.png' alt='Eliminar Pre-Asignacion' title='Eliminar Pre-Asignacion' width='15' ></a>";
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public List<BodegaPliegos> ListadoDetalleSKU(string ot, string componente,string preid,int idpapel, string codigo, string papel, int gramaje, int ancho, int largo, string certificacion, int cantidadasignada, string antiguedad, string usuario, int procedimiento,int factor)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_AsignarPapel";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Componente", componente);
                cmd.Parameters.AddWithValue("@Preid", preid);
                cmd.Parameters.AddWithValue("@idPapel", idpapel);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Papel", papel);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@Largo", largo);
                cmd.Parameters.AddWithValue("@Certificacion", certificacion);
                cmd.Parameters.AddWithValue("@CantidadAsignada", cantidadasignada);
                cmd.Parameters.AddWithValue("@Factor", factor);
                cmd.Parameters.AddWithValue("@Antiguedad", antiguedad);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.ID = reader["id_Detalle"].ToString();
                    d.CodigoProducto = reader["CodigoItem"].ToString();
                    d.NroPallet = reader["NroPallet"].ToString();
                    d.Papel = reader["Papel"].ToString().ToLower();
                    d.Sector = reader["Sector"].ToString();
                    d.Ubicacion = reader["Ubicacion"].ToString();
                    d.Cliente = reader["Cliente"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.StockFL = reader["StockPliegos"].ToString();
                    d.Antiguedad = Convert.ToDateTime(reader["FechaAlmacenamiento"].ToString()).ToString("dd/MM/yyyy");
                    d.Usuario = usuario;
                    d.Asignar = "NO";
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public int PREID(string ot, string componente,string preid,int idpapel, string codigo, string papel, int gramaje, int ancho, int largo, string certificacion, int cantidadasignada, string antiguedad, string usuario, int procedimiento,int factor)
        {
            int IDUsuario = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BodegaPliegos_AsignarPapel";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@Componente", componente);
                    cmd.Parameters.AddWithValue("@Preid", preid);
                    cmd.Parameters.AddWithValue("@idPapel", idpapel);
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    cmd.Parameters.AddWithValue("@Papel", papel);
                    cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                    cmd.Parameters.AddWithValue("@Ancho", ancho);
                    cmd.Parameters.AddWithValue("@Largo", largo);
                    cmd.Parameters.AddWithValue("@Certificacion", certificacion);
                    cmd.Parameters.AddWithValue("@CantidadAsignada", cantidadasignada);
                    cmd.Parameters.AddWithValue("@Factor", factor);
                    cmd.Parameters.AddWithValue("@Antiguedad", antiguedad);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDUsuario = Convert.ToInt32(reader["PREID"].ToString());
                        return IDUsuario;
                    }
                    else
                    {
                        return IDUsuario = 0;
                    }
                }
                catch
                {
                    return IDUsuario = 0;
                }
            }
            else
            {
                return IDUsuario = 0;
            }
            con.CerrarConexion();
        }

        public bool ElimanarAsignacion(int idAsignado,string usuario,int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "BodegaPliegos_EliminarPreAsignacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@idAsignado", idAsignado);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
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

        public string BuscaUltimoCodigoBarra(int idAsignacion,string codigobarra,int FCAncho,int FCLargo,int procedimiento)
        {
            string IDUsuario = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BodegaPliegos_FormatoCorte";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAsignacion", idAsignacion);
                    cmd.Parameters.AddWithValue("@CodigoBarra", codigobarra);
                    cmd.Parameters.AddWithValue("@FormatoCorteAncho", FCAncho);
                    cmd.Parameters.AddWithValue("@FormatoCorteLargo", FCLargo);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDUsuario = reader["CodigoBarra"].ToString();
                        return IDUsuario;
                    }
                    else
                    {
                        return IDUsuario = "";
                    }
                }
                catch
                {
                    return IDUsuario = "";
                }
            }
            else
            {
                return IDUsuario = "";
            }
            con.CerrarConexion();
        }

        public bool InsertaFormatoCorte(int idAsignacion, string codigobarra, int FCAncho, int FCLargo, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = false;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_FormatoCorte";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAsignacion", idAsignacion);
                cmd.Parameters.AddWithValue("@CodigoBarra", codigobarra);
                cmd.Parameters.AddWithValue("@FormatoCorteAncho", FCAncho);
                cmd.Parameters.AddWithValue("@FormatoCorteLargo", FCLargo);
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


        public List<BodegaPliegos> ListadoDetalleCodigoBarra(int idAsignacion, string codigobarra, int FCAncho, int FCLargo, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_FormatoCorte";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAsignacion", idAsignacion);
                cmd.Parameters.AddWithValue("@CodigoBarra", codigobarra);
                cmd.Parameters.AddWithValue("@FormatoCorteAncho", FCAncho);
                cmd.Parameters.AddWithValue("@FormatoCorteLargo", FCLargo);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.ID = reader["id_Detalle"].ToString();
                    d.CodigoProducto = reader["CodigoItem"].ToString();
                    d.NroPallet = reader["NroPallet"].ToString();
                    d.Papel = reader["Papel"].ToString().ToLower();
                   // d.Sector = reader["Sector"].ToString();
                    d.Ubicacion = reader["Sector"].ToString()+" - "+reader["Ubicacion"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.StockFL = reader["CantidadAsignada"].ToString();
                    d.FormatoCorte = reader["FCAncho"].ToString() + "x" + reader["FCLargo"].ToString();
                    
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public int totalAsignado(string ot, string componente, int procedimiento)
        {
            int IDUsuario = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BodegaPliegos_CargaFaltante";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@Componente", componente);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDUsuario = Convert.ToInt32(reader["CantidadAsignada"].ToString());
                        return IDUsuario;
                    }
                    else
                    {
                        return IDUsuario = 0;
                    }
                }
                catch
                {
                    return IDUsuario = 0;
                }
            }
            else
            {
                return IDUsuario = 0;
            }
            con.CerrarConexion();
        }

        public List<BodegaPliegos> CargaPapelSolicitud(string codigo,int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_CargaSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = reader["Codigo"].ToString();
                    d.Papel = reader["Papel"].ToString().ToLower();
                    d.Marca = "";
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.FCAncho = reader["FCAncho"].ToString();
                    d.FCLargo = reader["FCLargo"].ToString();
                    d.Certificacion = reader["Certificacion"].ToString();
                    d.Antiguedad = reader["Antiguedad"].ToString();
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public List<BodegaPliegos> CargaPapelSolicitudDetalle(string codigo, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_CargaSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = reader["Codigo"].ToString();
                    d.NroPallet = reader["NroPallet"].ToString();
                    d.Sector = reader["Sector"].ToString();
                    d.Ubicacion = reader["Ubicacion"].ToString();
                    d.Cliente = reader["Cliente"].ToString();
                    d.Ancho = reader["FCAncho"].ToString();
                    d.Largo = reader["FCLargo"].ToString();
                    d.StockFL = reader["CantidadAsignada"].ToString();
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }


        public List<BodegaPliegos> BuscaStockBodegaPliegos(string ot, string componente,string certificacion,string Marca, string codigoproducto, string Papel, int gramaje, int ancho,int largo, int solFL, int solKG, string PREID, string usuario, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_BuscaStockBP]";//"[BodegaPliegos_BuscaStockMetrics]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@Largo", largo);
                cmd.Parameters.AddWithValue("@Marca", Marca);
                cmd.Parameters.AddWithValue("@Certificacion", certificacion);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.CodigoProducto = reader["CodigoItem"].ToString();
                    d.Papel = reader["Papel"].ToString().ToLower();
                    d.Marca = reader["Marca"].ToString().ToLower();
                    d.Certificacion = reader["Certificacion"].ToString();
                    d.Gramaje = Convert.ToInt32(reader["Gramaje"].ToString()).ToString();
                    d.Ancho = Convert.ToInt32(reader["Ancho"].ToString()).ToString();
                    d.Largo = Convert.ToInt32(reader["Largo"].ToString()).ToString();
                    
                    d.StockFL = Convert.ToInt32(reader["StockPliegos"].ToString()).ToString();
                    d.Asignar = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Asignar(\"" + reader["id_Saldo"].ToString() + "\",\"" + ot + "\",\"" + componente + "\",\"" + solFL + "\",\"" + solKG + "\",\"" + PREID + "\",\"" + usuario + "\");'>Asignar</a>";
                    d.Antiguedad = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy");
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public List<BodegaPliegos> BuscaCertificaciones(string ot, string componente, string certificacion, string Marca, string codigoproducto, string Papel, int gramaje, int ancho, int largo, int solFL, int solKG, string PREID, string usuario, int procedimiento)
        {
            List<BodegaPliegos> lista = new List<BodegaPliegos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_BuscaStockBP]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", gramaje);
                cmd.Parameters.AddWithValue("@Ancho", ancho);
                cmd.Parameters.AddWithValue("@Largo", largo);
                cmd.Parameters.AddWithValue("@Marca", Marca);
                cmd.Parameters.AddWithValue("@Certificacion", certificacion);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BodegaPliegos d = new BodegaPliegos();
                    d.Certificacion = reader["certificacion"].ToString();
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public BodegaPliegos CargaPapelSolicitado(string codigo, int procedimiento)
        {
            BodegaPliegos d = new BodegaPliegos();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_CargaSolicitud";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    d.CodigoProducto = reader["CodigoItem"].ToString();
                    d.Papel = reader["Papel"].ToString().ToLower();
                    d.Marca = reader["Marca"].ToString().ToLower();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.Certificacion = reader["Certificacion"].ToString();
                    d.Antiguedad = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy");
                    
                }

            }
            con.CerrarConexion();
            return d;
        }
        public int CargaFormatoCorte(string ot, string componente, int procedimiento)
        {
            int IDUsuario = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BodegaPliegos_CargaFaltante";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@Componente", componente);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDUsuario = Convert.ToInt32(reader["FormatoCorte"].ToString());
                        return IDUsuario;
                    }
                    else
                    {
                        return IDUsuario = 0;
                    }
                }
                catch
                {
                    return IDUsuario = 0;
                }
            }
            else
            {
                return IDUsuario = 0;
            }
            con.CerrarConexion();
        }
    }

}