using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.Controller
{
    public class Controller_Factura
    {
        public bool InsertDetFactura(Factura fact)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Servicioexterno_InsertDet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", fact.NFactura);
                cmd.Parameters.AddWithValue("@OT",fact.OT);
                cmd.Parameters.AddWithValue("@Proceso",fact.Proceso);
                cmd.Parameters.AddWithValue("@Observacion",fact.Observacion);
                cmd.Parameters.AddWithValue("@Barniz",fact.Barniz);
                cmd.Parameters.AddWithValue("@Tipo",fact.Tipo);
                cmd.Parameters.AddWithValue("@Formato",fact.Formato);
                cmd.Parameters.AddWithValue("@Costo",fact.Costo);
                cmd.Parameters.AddWithValue("@Usuario",fact.Usuario);

                cmd.Parameters.AddWithValue("@ValorM2", fact.M2);
                cmd.Parameters.AddWithValue("@Valor_Pl",fact.PrecioUnit);
                cmd.Parameters.AddWithValue("@Cantidad_M2", fact.Cant);//Costo para M2 de los pliegos
                cmd.Parameters.AddWithValue("@Cantidad_Pliegos", fact.Cantidad);
                cmd.Parameters.AddWithValue("@CostoTotal", fact.Total);
                if (fact.OT.Substring(0, 1).ToUpper() == "B")
                {
                    cmd.Parameters.AddWithValue("@TipoOT", "Antigua");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TipoOT", "Metrics");
                }
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            con.CerrarConexion();

            return respuesta;
        }

        //Modificado el 22/10/2014
         public bool UpdateDetFactura(Factura fact)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Servicioexterno_UpdateDet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_DetFact", fact.ID_Factura);
                cmd.Parameters.AddWithValue("@OT", fact.OT);
                cmd.Parameters.AddWithValue("@Proceso", fact.Proceso);
                cmd.Parameters.AddWithValue("@Observacion", fact.Observacion);
                cmd.Parameters.AddWithValue("@Barniz", fact.Barniz);
                cmd.Parameters.AddWithValue("@Tipo", fact.Tipo);
                cmd.Parameters.AddWithValue("@Formato", fact.Formato);
                cmd.Parameters.AddWithValue("@Costo", fact.Costo);
                cmd.Parameters.AddWithValue("@Usuario", fact.Usuario);

                cmd.Parameters.AddWithValue("@ValorM2", fact.M2);
                cmd.Parameters.AddWithValue("@Valor_Pl", fact.PrecioUnit);
                cmd.Parameters.AddWithValue("@Cantidad_M2", fact.Cant);//Costo para M2 de los pliegos
                cmd.Parameters.AddWithValue("@Cantidad_Pliegos", fact.Cantidad);
                cmd.Parameters.AddWithValue("@CostoTotal", fact.Total);
                if (fact.OT.Substring(0, 1).ToUpper() == "B")
                {
                    cmd.Parameters.AddWithValue("@TipoOT", "Antigua");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TipoOT", "Metrics");
                }
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            con.CerrarConexion();

            return respuesta;
        }

         public bool UpdateDetalle(string ID_Factura, int proceso, string usuario, double total, int iva, int totalfinal)
         {
             Boolean respuesta = false;
             Conexion con = new Conexion();
             SqlCommand cmd = con.AbrirConexionIntranet();
             if (cmd != null)
             {
                 cmd.CommandText = "ServicioExterno_UpdateDetalleFact";
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@ID_Factura", ID_Factura);
                 cmd.Parameters.AddWithValue("@Proceso", proceso);
                 cmd.Parameters.AddWithValue("@Usuario", usuario);
                 cmd.Parameters.AddWithValue("@Total", Convert.ToInt32(total));
                 cmd.Parameters.AddWithValue("@iva", iva);
                 cmd.Parameters.AddWithValue("@totalf", totalfinal);

                 cmd.ExecuteNonQuery();
                 respuesta = true;
             }
             con.CerrarConexion();
             return respuesta;
         }

        //Modificado el 22/10/2014
        public List<Factura> Listar_Detfactura(int id, string Usuario)
        {
            List<Factura> lista = new List<Factura>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ServicioExterno_ListarDetFactura";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Factura f = new Factura();
                    f.NFactura = Convert.ToInt32(reader["ID_DetFactura"].ToString());
                    f.OT = reader["OT"].ToString();
                    f.Cantidad = Convert.ToInt32(reader["Cantidad"].ToString());
                    f.Proceso = reader["Proceso"].ToString();
                    f.PrecioUnit = Convert.ToDouble(reader["Unidad"].ToString());
                    f.Total = reader["CostoTotal"].ToString();
                    f.Action = "<a style='Color:Black;text-decoration:none;cursor:pointer;' href='javascript:Editar(\"" + f.NFactura + "\",\"" + id + "\")'><img border='0' src='../../Images/editar-icono-9796-128.png' alt='Editar Detalle' title='Eliminar Detalle' width='15' ></a>&nbsp;<a style='Color:Black;text-decoration:none;cursor:pointer;' href='javascript:Delete(\"" + f.NFactura + "\",\"" + id + "\")'><img border='0' src='../../Images/delete_icon.png' alt='Eliminar Detalle' title='Eliminar Detalle' width='15' ></a>";
                    lista.Add(f);
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public Factura BuscarProveedor(string Rut, string Nombre, string Direccion, string Comuna, string Ciudad, string nroFactura, string Usuario, DateTime FechaFactura, int Procedimiento)
        {
            Factura sv = new Factura();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ServicioExterno_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Comuna", Comuna);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@NroFactura", nroFactura);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@FechaFactura", FechaFactura);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sv.Rut = reader["RUTPROVEEDOR"].ToString();
                    sv.Nombre = reader["RAZONSOCIALPROVEEDOR"].ToString();
                    sv.Sucursal = reader["CALLESUCURSAL"].ToString();
                    sv.Comuna = reader["NOMBRECOMUNA"].ToString();
                    sv.Ciudad = reader["NOMBRECIUDAD"].ToString();
                }
            }
            con.CerrarConexion();
            return sv;
        }

        public bool ValidacionFactura(string Rut, string Nombre, string Direccion, string Comuna, string Ciudad, string nroFactura, string Usuario,  DateTime FechaFactura,int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "ServicioExterno_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Comuna", Comuna);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@NroFactura", nroFactura);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@FechaFactura", FechaFactura);
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

        public int IngresoFactura(string Rut, string Nombre, string Direccion, string Comuna, string Ciudad, string nroFactura, string Usuario, DateTime FechaFactura, int Procedimiento)
        {
            int ID = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "ServicioExterno_BuscaProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rut", Rut);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Comuna", Comuna);
                    cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                    cmd.Parameters.AddWithValue("@NroFactura", nroFactura);
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@FechaFactura", FechaFactura);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ID = Convert.ToInt32(reader["ID"].ToString());
                        return ID;
                    }
                    else
                    {
                        return ID = 0;
                    }
                }
                catch
                {
                    return ID = 0;
                }
            }
            else
            {
                return ID = 0;
            }
            con.CerrarConexion();
        }

        public List<Factura> Listar_DetalleFactura(string Rut, string Nombre, string Direccion, string Comuna, string Ciudad, string nroFactura, string Usuario,  DateTime FechaFactura,int Procedimiento)
        {
            List<Factura> lista = new List<Factura>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ServicioExterno_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Comuna", Comuna);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@NroFactura", nroFactura);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@FechaFactura", FechaFactura);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Factura sv = new Factura();
                    sv.OT = reader["ot"].ToString();
                    sv.Cant = Convert.ToInt32(reader["Cantidad_pliegos"].ToString()).ToString("N0").Replace(",",".");
                    sv.Proceso = reader["Proceso"].ToString();
                    sv.Formato = reader["Formato"].ToString();
                    sv.Unidad = reader["ValorPL"].ToString();
                    sv.Barniz = reader["Barniz"].ToString();
                    sv.Tipo = reader["Tipo"].ToString();
                    sv.Total = (Convert.ToInt32(reader["CostoTotal"].ToString())).ToString("N0").Replace(",", ".");
                    lista.Add(sv);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public Factura CargaEncabezado(string Rut, string Nombre, string Direccion, string Comuna, string Ciudad, string nroFactura, string Usuario, DateTime FechaFactura, int Procedimiento)
        {
            Factura sv = new Factura();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ServicioExterno_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Comuna", Comuna);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@NroFactura", nroFactura);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@FechaFactura", FechaFactura);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sv.Rut = reader["Rut"].ToString();
                    sv.Nombre = reader["Nombre"].ToString();
                    sv.Sucursal = reader["Direccion"].ToString();
                    sv.Comuna = reader["Comuna"].ToString();
                    sv.Ciudad = reader["Ciudad"].ToString();
                    sv.NFactura = Convert.ToInt32(reader["NroFactura"].ToString());
                    sv.OT = Convert.ToDateTime(reader["FechaFactura"].ToString()).ToString("dd/MM/yyyy");
                    
                }
            }
            con.CerrarConexion();
            return sv;
        }
        public bool EliminarRegistrosPendientes(string Rut, string Nombre, string Direccion, string Comuna, string Ciudad, string nroFactura, string Usuario, DateTime FechaFactura, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "ServicioExterno_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Comuna", Comuna);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@NroFactura", nroFactura);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@FechaFactura", FechaFactura);
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

        //Modificado el 22/10/2014
        public Factura BuscarIDDetalle(int idDet)
        {
            Factura factu = new Factura();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ServicioExterno_BuscarID_Det";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_DET", idDet);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    factu.OT = reader["OT"].ToString();
                    factu.NombreOT = reader["NombreOT"].ToString();
                    factu.Proceso = reader["Proceso"].ToString();
                    factu.Costo = reader["CostoTipo"].ToString();
                    factu.Cantidad = Convert.ToInt32(reader["Cantidad_Pliegos"].ToString());
                    factu.PrecioUnit = Convert.ToDouble(reader["ValorPl"].ToString());
                    factu.Cant = reader["Cantidad_M2"].ToString();
                    factu.Formato = reader["Formato"].ToString();
                    factu.Barniz = reader["Barniz"].ToString();
                    factu.Tipo = reader["Tipo"].ToString();
                    factu.Observacion = reader["Observacion"].ToString();
                    factu.M2 = reader["valorM2"].ToString();
                    factu.Total = reader["CostoTotal"].ToString();
                }
                con.CerrarConexion();
            }
            return factu;
        }

        public bool DeleteDetFactura(string ID_detFact)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Servicioexterno_DeleteDet";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_detFactura", ID_detFact);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            con.CerrarConexion();
            return respuesta;
        }

        public List<Factura> listarProexterno()
        {
            List<Factura> lista = new List<Factura>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ServicioExterno_Proceso_ext";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Factura f = new Factura();
                    f.Proceso = reader["NombreProcesoExterno"].ToString();
                    lista.Add(f);
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public List<Factura> listarTipoProexterno()
        {
            List<Factura> lista = new List<Factura>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Servicioexterno_List_TipoEjemplar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Factura f = new Factura();
                    f.Proceso = reader["Tipo_Ejemplar"].ToString();
                    lista.Add(f);
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public string BuscarIDFactura(int idFactura)
        {
            string Respuesta = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ServicioExterno_BuscarNroFactura";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDFactura", idFactura);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Respuesta = reader["NroFactura"].ToString();
                }
                con.CerrarConexion();
            }
            return Respuesta;
        }


        public int BuscaID(string Rut, string Nombre, string Direccion, string Comuna, string Ciudad, string nroFactura, string Usuario, DateTime FechaFactura, int Procedimiento)
        {
            int ID = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "ServicioExterno_BuscaProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rut", Rut);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Comuna", Comuna);
                    cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                    cmd.Parameters.AddWithValue("@NroFactura", nroFactura);
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@FechaFactura", FechaFactura);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ID = Convert.ToInt32(reader["ID"].ToString());
                        return ID;
                    }
                    else
                    {
                        return ID = 0;
                    }
                }
                catch
                {
                    return ID = 0;
                }
            }
            else
            {
                return ID = 0;
            }
            con.CerrarConexion();
        }

        public List<Factura> listarInfExterno(Factura fact)
        {
            List<Factura> lista = new List<Factura>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ServicioExterno_ListinformeExterno";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", fact.OT);
                cmd.Parameters.AddWithValue("@NombreOT", fact.NombreOT);
                cmd.Parameters.AddWithValue("@Proveedor", fact.Nombre);
                cmd.Parameters.AddWithValue("@FechaInicio", fact.Ciudad);
                cmd.Parameters.AddWithValue("@FechaTermino", fact.Comuna);
                if (fact.NFactura != 0)
                {
                    cmd.Parameters.AddWithValue("@Nrofactura", fact.NFactura);
                }
                if (fact.Ciudad != "" && fact.Comuna != "" && fact.Ciudad != null && fact.Comuna != null)
                {
                    if (fact.OT == "")
                    {
                        cmd.Parameters.AddWithValue("@procedimiento", 2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@procedimiento", 4);
                    }
                }
                else if (fact.Ciudad == "" || fact.Comuna == "" || fact.Ciudad == null || fact.Comuna == null)
                {
                    if (fact.OT == "")
                    {
                        cmd.Parameters.AddWithValue("@procedimiento", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@procedimiento", 3);
                    }
                }

                SqlDataReader reader = cmd.ExecuteReader();
                int contador = 0;
                while (reader.Read())
                {
                    Factura f = new Factura();
                    DateTime fecha = Convert.ToDateTime(reader["FechaFactura"].ToString());
                    f.Ciudad = fecha.ToString("dd-MM-yyyy");
                    f.OT = reader["OT"].ToString();
                    f.NombreOT = reader["NombreOT"].ToString();
                    f.Nombre = reader["Nombre"].ToString();
                    f.NFactura = Convert.ToInt32(reader["NroFactura"].ToString());
                    int valorNeto = Convert.ToInt32(reader["ValorNeto"].ToString());//valor neto
                    f.Sucursal = valorNeto.ToString("N0").Replace(",", ".");
                    int valoriva = Convert.ToInt32(reader["ValorIVA"].ToString());//valor iva
                    f.Rut = valoriva.ToString("N0").Replace(",", ".");
                    int Costofinal = Convert.ToInt32(reader["CostoTotal"].ToString());//costo final
                    f.Tipo = Costofinal.ToString("N0").Replace(",", ".");
                    f.Proceso = "<a>Ver Más</a>";
                    contador = contador + 1;
                    f.M2 = contador.ToString("N0").Replace(",", ".");
                    lista.Add(f);
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public List<Factura> listarExternoMensual(string Fecha, int procedimiento)
        {
            List<Factura> lista = new List<Factura>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[ServicioExterno_ListinformeExt_Det]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Factura f = new Factura();
                    f.Proceso = reader["Proceso"].ToString();
                    f.Total = reader["CostoTotal"].ToString();
                    if (procedimiento != 3)
                    {
                        if (procedimiento != 1)
                        {
                            f.Nombre = reader["Proveedor"].ToString();
                        }
                        if (procedimiento != 2)
                        {
                            f.OT = reader["OT"].ToString();
                            f.NombreOT = reader["NombreOT"].ToString();
                            f.M2 = reader["ValorM2"].ToString();//valor M2
                            f.Cant = reader["Cantidad_Pliegos"].ToString();//Cantidad Pliegos
                            f.Costo = reader["ValorPl"].ToString();//valor Pliegos
                            if (procedimiento != 1)
                            {
                                f.Formato = reader["Formato"].ToString();
                                f.Tipo = reader["Tipo"].ToString();
                                f.Barniz = reader["Barniz"].ToString();
                                f.Observacion = reader["Observacion"].ToString();
                                f.Cantidad = Convert.ToInt32(reader["Cantidad_M2"].ToString());//Cantidad M2
                            }
                        }
                    }
                    lista.Add(f);
                }
                con.CerrarConexion();
            }
            return lista;
        }
    }
}