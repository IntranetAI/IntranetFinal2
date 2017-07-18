using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloBodegaPliegos.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloBodegaPliegos.Controller
{
    public class Controller_OrdenCompra
    {
        public OrdenesCompra BuscaProveedor(string NombreProveedor,string Rut, int Procedimiento)
        {
            OrdenesCompra d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    d = new OrdenesCompra();
                    d.idProveedor = reader["idProveedor"].ToString();
                    d.CodigoProveedor = reader["codCliente"].ToString();
                    d.Rut = reader["cgc"].ToString();
                    d.Proveedor = reader["Proveedor"].ToString();
                    d.Nombre = reader["nome"].ToString();
                    d.Telefono = reader["telefone"].ToString();
                    d.CondicionPago = reader["condpagtopadrao"].ToString();
                    d.Email = reader["email"].ToString();
                }

            }

            conexion.CerrarConexion();

            return d;
        }
        public List<OrdenesCompra> ListaProveedores(string NombreProveedor, string Rut, int Procedimiento)
        {
            List<OrdenesCompra> lista = new List<OrdenesCompra>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenesCompra d = new OrdenesCompra();
                    d.idProveedor = reader["idProveedor"].ToString();
                    d.Proveedor = reader["Proveedor"].ToString();
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public List<OrdenesCompra> CargaCondicionesdePago(string NombreProveedor, string Rut, int Procedimiento)
        {
            List<OrdenesCompra> lista = new List<OrdenesCompra>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_BuscaProveedor";
                cmd.CommandType =  System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenesCompra d = new OrdenesCompra();
                    d.CondicionPago = reader["CondPagtoPadrao"].ToString();

                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public OrdenesCompra BuscaSKU(string NombreProveedor, string Rut, int Procedimiento)
        {
            OrdenesCompra d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    d = new OrdenesCompra();
                    d.CodigoItem = reader["coditem"].ToString();
                    d.Papel = reader["descricao"].ToString();
                    d.StockKG = reader["stock"].ToString();
                    d.Gramaje = reader["Gramatura"].ToString();
                    d.Ancho = reader["Altura"].ToString();
                    d.Largo = reader["Largura"].ToString();
                }

            }

            conexion.CerrarConexion();

            return d;
        }
        
       //string Rut,string CodProveedor,string Proveedor,string NombreProveedor,string Email,string Telefono,string CondicionPago,DateTime FechaEntrega,
            //string Observacion, 
        public bool IngresaEncyDet(string CodigoItem, string Papel, string Moneda, double ValorMoneda, int Pliegos, double Kilos, double ValorUnitario, double Total, string ObservacionItem, string Usuario, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_OC_Ingreso";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@RutProveedor",Rut);
                //cmd.Parameters.AddWithValue("@CodProveedor", CodProveedor);
                //cmd.Parameters.AddWithValue("@Proveedor", Proveedor);
                //cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                //cmd.Parameters.AddWithValue("@Email", Email);
                //cmd.Parameters.AddWithValue("@Telefono",Telefono);
                //cmd.Parameters.AddWithValue("@CondicionPago", CondicionPago);
                //cmd.Parameters.AddWithValue("@FechaEntrega", FechaEntrega);
                //cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@CodigoItem", CodigoItem);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Moneda", Moneda);
                cmd.Parameters.AddWithValue("@ValorMoneda", ValorMoneda);
                cmd.Parameters.AddWithValue("@CantidadPliegos", Pliegos);
                cmd.Parameters.AddWithValue("@CantidadKG", Kilos);
                cmd.Parameters.AddWithValue("@ValorUnitario", ValorUnitario);
                cmd.Parameters.AddWithValue("@ValorTotal", Total);
                cmd.Parameters.AddWithValue("@ObservacionItem", ObservacionItem);
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

        public List<OrdenesCompra> ListaItemsIngresados(string CodigoItem, string Papel, string Moneda, double ValorMoneda, int Pliegos, double Kilos, double ValorUnitario, double Total, string ObservacionItem, string Usuario, int Procedimiento)
        {
            List<OrdenesCompra> lista = new List<OrdenesCompra>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_Ingreso";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoItem", CodigoItem);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Moneda", Moneda);
                cmd.Parameters.AddWithValue("@ValorMoneda", ValorMoneda);
                cmd.Parameters.AddWithValue("@CantidadPliegos", Pliegos);
                cmd.Parameters.AddWithValue("@CantidadKG", Kilos);
                cmd.Parameters.AddWithValue("@ValorUnitario", ValorUnitario);
                cmd.Parameters.AddWithValue("@ValorTotal", Total);
                cmd.Parameters.AddWithValue("@ObservacionItem", ObservacionItem);
                cmd.Parameters.AddWithValue("@CreadoPor", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenesCompra d = new OrdenesCompra();
                    d.CodigoItem = reader["CodigoItem"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.CantidadPliegos = Convert.ToInt32(reader["CantidadPliegos"].ToString()).ToString("N0").Replace(",", ".");
                    d.CantidadKG = Convert.ToDouble(reader["CantidadKilos"].ToString()).ToString("N2");
                    d.ValorUnitario = Convert.ToDouble(reader["ValorUnitario"].ToString()).ToString("N2");
                    d.CostoTotal = Convert.ToDouble(reader["ValorTotal"].ToString()).ToString("N2");
                    d.IVA = Convert.ToDouble(Convert.ToDouble(reader["ValorTotal"].ToString()) * Convert.ToDouble(0.19)).ToString("N2");
                    d.TotalConIVA = Convert.ToDouble(Convert.ToDouble(reader["ValorTotal"].ToString()) * Convert.ToDouble(1.19)).ToString("N2");
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public int IngresaEnabezado(string Rut,string CodProveedor,string Proveedor,string Direccion,string Contacto,string Email,string Telefono,string CondicionPago,DateTime FechaEntrega,
            string Observacion,  string Usuario,string Moneda,double ValorMoneda, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_OC_IgresoEnc";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RutProveedor", Rut);
                cmd.Parameters.AddWithValue("@CodProveedor", CodProveedor);
                cmd.Parameters.AddWithValue("@Proveedor", Proveedor);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Contacto", Contacto);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@CondicionPago", CondicionPago);
                cmd.Parameters.AddWithValue("@FechaEntrega", FechaEntrega);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@CreadoPor", Usuario);
                cmd.Parameters.AddWithValue("@Moneda", Moneda);
                cmd.Parameters.AddWithValue("@ValorMoneda", ValorMoneda);
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
        public List<OrdenesCompra> ListaDireccionesyContacto(string NombreProveedor,string Rut, int Procedimiento)
        {
            List<OrdenesCompra> lista = new List<OrdenesCompra>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenesCompra d = new OrdenesCompra();
                    d.Direccion = reader["Valor"].ToString();

                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public List<OrdenesCompra> BuscaPapel(string NombreProveedor, string Rut, int Procedimiento)
        {
            List<OrdenesCompra> lista = new List<OrdenesCompra>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenesCompra d = new OrdenesCompra();
                    d.CodigoItem = reader["CodItem"].ToString();
                    d.Papel = reader["CodItem"].ToString() + " " + reader["Descricao"].ToString();

                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public bool EliminarAnteriores(string NombreProveedor, string Rut, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_OC_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
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

        public OrdenesCompra GeneraPDF(string NombreProveedor, string Rut, int Procedimiento)
        {
            OrdenesCompra d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    d = new OrdenesCompra();
                    d.NroOC = reader["id_Enc"].ToString();
                    d.Rut = reader["RutProveedor"].ToString();
                    d.Proveedor = reader["Proveedor"].ToString();
                    d.Direccion = reader["Direccion"].ToString();
                    d.Contacto = reader["Contacto"].ToString();
                    d.Email = reader["Email"].ToString();
                    d.Telefono = reader["Telefono"].ToString();
                    d.CondicionPago = reader["CondicionDePago"].ToString();
                    d.FechaEntrega = reader["FechaEntrega"].ToString();
                    d.Observacion = reader["Observacion"].ToString().Replace("nota", "<br />nota");
                    d.ValorTotal = reader["ValorTotal"].ToString();
                    d.ValorIVA = reader["ValorIVA"].ToString();
                    d.ValorTotalConIVA = reader["ValorTotalConIVA"].ToString();
                    d.FechaCreacion = reader["FechaCreacion"].ToString();
                    d.CreadoPor = reader["CreadoPor"].ToString();
                    d.Moneda = reader["Moneda"].ToString();
                    if (reader["Moneda"].ToString() == "Dolar")
                    {
                        d.Unidad = "USD";
                    }
                    else if (reader["Moneda"].ToString() == "Euro")
                    {
                        d.Unidad = "EUR";
                    }
                    else
                    {
                        d.Unidad = "";
                    }

                }

            }

            conexion.CerrarConexion();

            return d;
        }
        public string GeneraItemsPDF(string NombreProveedor, string Rut, int Procedimiento)
        {
            string Encabezado = "<table style='width:100%;' border='1'>" +
                                "<tr>" +
                                "<th ><div align='center' style='font-weight: bold;font-size:9px;'>Código</div></th>" +
                               // "<th ><div align='center' style='font-weight: bold;font-size:9px;'>SKU</div></th>" +
                                "<th colspan='5' align='center'><div align='center' style='font-weight: bold;font-size:9px;'>Descripcion</div></th>" +
                                "<th ><div align='center' style='font-weight: bold;font-size:9px;'>Cantidad</div></th>" +
                                "<th ><div align='center' style='font-weight: bold;font-size:9px;'>P.Unitario</div></th>" +
                                "<th colspan='2'><div align='center' style='font-weight: bold;font-size:9px;'>Total</div></th>" +
                                //"<th style='width:15%'>Total</th>" +
                                   "</tr>";
            string Contenido = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_BuscaProveedor";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Contenido = Contenido + "<tr>" +
                        //"<td ><div align='center' style='font-size:9px;'>" + reader["CodigoItem"].ToString() + "</div></td>" +
                       
                        "<td ><div align='right' style='font-size:9px;'>" + reader["CodigoItem"].ToString() + "</div></td>" +
                        "<td colspan='5'><div align='left' style='font-size:9px;'>" + reader["Papel"].ToString() + "</div></td>" +
                        "<td ><div align='right' style='font-size:9px;'>" + Convert.ToInt32(reader["CantidadPliegos"].ToString()).ToString("N0").Replace(",", ".") + "</div></td>" +
                        "<td ><div align='right' style='font-size:9px;'>" + Convert.ToDouble(reader["ValorUnitario"].ToString()).ToString("N2") + "</div></td>" +
                        "<td colspan='2' ><div align='right' style='font-size:9px;'>" + Convert.ToDouble(reader["ValorTotal"].ToString()).ToString("N2") + "</div></td>" +
                        //"<td ></td>" +
                            "</tr>";
                }
            }
            con.CerrarConexion();
            return Encabezado + Contenido + "</table>";
        }
        public List<OrdenesCompra> ListaOCaRecepcionar(string idItem, int CantidadPliegos,double CantidadKilos,string Observacion,string Usuario, int Procedimiento)
        {
            List<OrdenesCompra> lista = new List<OrdenesCompra>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_RecepcionOC";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idItem", idItem);
                cmd.Parameters.AddWithValue("@CantidadPliegos", CantidadPliegos);
                cmd.Parameters.AddWithValue("@CantidadKilos", CantidadKilos);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenesCompra d = new OrdenesCompra();
                    d.idItem = reader["id_Det"].ToString();
                    d.NroOC = reader["id_Enc"].ToString();
                    d.CodigoItem = reader["CodigoItem"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.CantidadPliegos = Convert.ToInt32(reader["CantidadPliegos"].ToString()).ToString("N0").Replace(",", ".");
                    d.CantidadKG = Convert.ToDouble(reader["CantidadPliegos"].ToString()).ToString("N2");
                    d.Observacion = reader["Observacion"].ToString();
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy");
                    d.Accion = "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:Procesar(\"" + d.idItem + "\");'>Recepcionar</a>";

                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public OrdenesCompra CargaidItem(string idItem, int CantidadPliegos, double CantidadKilos, string Observacion, string Usuario, int Procedimiento)
        {
            OrdenesCompra d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_RecepcionOC";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idItem", idItem);
                cmd.Parameters.AddWithValue("@CantidadPliegos", CantidadPliegos);
                cmd.Parameters.AddWithValue("@CantidadKilos", CantidadKilos);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    d = new OrdenesCompra();
                    //d.idItem = reader["id_Det"].ToString();
                    d.NroOC = reader["id_Enc"].ToString();
                    d.CodigoItem = reader["CodigoItem"].ToString();
                    d.Papel = reader["Papel"].ToString();
                    d.CantidadPliegos = reader["CantidadPliegos"].ToString();
                    d.CantidadKG = reader["CantidadKilos"].ToString();
                    d.Gramaje = reader["Gramaje"].ToString();
                    d.Ancho = reader["Ancho"].ToString();
                    d.Largo = reader["Largo"].ToString();
                    d.Estado = reader["EstadoRecep"].ToString();
                    d.CantidadPliegosRecep = reader["CantidadPliegosRecep"].ToString();
                    d.CantidadKilosRecep = reader["CantidadKilosRecep"].ToString();
                    d.ValorUnitario = reader["ValorUnitario"].ToString();
                    if (reader["Observacion"].ToString() == "")
                    {
                        d.Observacion = "-";
                    }
                    else
                    {
                        d.Observacion = reader["Observacion"].ToString();
                    }
                }

            }

            conexion.CerrarConexion();

            return d;
        }

        public OrdenesCompra CargaFaltante(string idItem, int CantidadPliegos, double CantidadKilos, string Observacion, string Usuario, int Procedimiento)
        {
            OrdenesCompra d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_RecepcionOC";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idItem", idItem);
                cmd.Parameters.AddWithValue("@CantidadPliegos", CantidadPliegos);
                cmd.Parameters.AddWithValue("@CantidadKilos", CantidadKilos);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    d = new OrdenesCompra();
                    d.CantidadPliegos = reader["CantidadAsignada"].ToString();
                    d.CantidadPliegosRecep = reader["CantidadPliegosRecep"].ToString();
                }

            }

            conexion.CerrarConexion();

            return d;
        }
        public string IngresaOCaStock(string OC,string idDetalleOC,string DocumentoLote,string CodigoItem,string Papel,int Gramaje,int Ancho,int Largo,int Cantidad,double Kilos,
            double CostoMedioIngreso,string CreadoPor, int procedimiento)
        {
            string IDUsuario = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BodegaPliegos_OC_IngresoaStock";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OC", OC);
                    cmd.Parameters.AddWithValue("@idDetalleOC", idDetalleOC);
                    cmd.Parameters.AddWithValue("@DocumentoLote", DocumentoLote);
                    cmd.Parameters.AddWithValue("@CodigoItem", CodigoItem);
                    cmd.Parameters.AddWithValue("@Papel", Papel);
                    cmd.Parameters.AddWithValue("@Gramaje", Gramaje);
                    cmd.Parameters.AddWithValue("@Ancho", Ancho);
                    cmd.Parameters.AddWithValue("@Largo", Largo);
                    cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@Peso", Kilos);
                    cmd.Parameters.AddWithValue("@CostoMedioIngreso", CostoMedioIngreso);
                    cmd.Parameters.AddWithValue("@CreadoPor", CreadoPor);
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
        public bool IngresarRecepcion(string OC,string idDetalleOC,string DocumentoLote, string CodigoItem, string Papel, int Gramaje, int Ancho, int Largo, int Cantidad, double Kilos,
            double CostoMedioIngreso, string CreadoPor, int procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_OC_IngresoaStock";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OC", OC);
                cmd.Parameters.AddWithValue("@idDetalleOC", idDetalleOC);
                cmd.Parameters.AddWithValue("@DocumentoLote", DocumentoLote);
                cmd.Parameters.AddWithValue("@CodigoItem", CodigoItem);
                cmd.Parameters.AddWithValue("@Papel", Papel);
                cmd.Parameters.AddWithValue("@Gramaje", Gramaje);
                cmd.Parameters.AddWithValue("@Ancho", Ancho);
                cmd.Parameters.AddWithValue("@Largo", Largo);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Peso", Kilos);
                cmd.Parameters.AddWithValue("@CostoMedioIngreso", CostoMedioIngreso);
                cmd.Parameters.AddWithValue("@CreadoPor", CreadoPor);
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
        public List<OrdenesCompra> ListaFacturasRecepcionadas(string NroOC,string IDItem,string NroFactura,double Catnidad,string Observacion,string Usuario, int Procedimiento)
        {
            List<OrdenesCompra> lista = new List<OrdenesCompra>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_RecepcionFactura";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroOC", NroOC);
                cmd.Parameters.AddWithValue("@IDItem", IDItem);
                cmd.Parameters.AddWithValue("@Documento", "");
                cmd.Parameters.AddWithValue("@NroFactura", NroFactura);
                cmd.Parameters.AddWithValue("@Cantidad", Catnidad);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenesCompra d = new OrdenesCompra();
                    d.NroOC = reader["NroOC"].ToString();
                    d.NroFactura = reader["NroFactura"].ToString();
                    d.Cantidad = reader["Cantidad"].ToString();
                    d.Observacion = reader["Observacion"].ToString();
                    d.FechaCreacion = Convert.ToDateTime(reader["FechaRecepcion"].ToString()).ToString("dd/MM/yyyy");
                    lista.Add(d);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public string IngresaFactura(string NroOC, string IDItem,string Documento, string NroFactura, double Catnidad, string Observacion, string Usuario, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            string respuesta = "";
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_OC_RecepcionFactura";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroOC", NroOC);
                cmd.Parameters.AddWithValue("@IDItem", IDItem);
                cmd.Parameters.AddWithValue("@Documento", Documento);
                cmd.Parameters.AddWithValue("@NroFactura", NroFactura);
                cmd.Parameters.AddWithValue("@Cantidad", Catnidad);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
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
        public string MaximoARepcecionar(string NroOC,string IDItem, string NroFactura, double Catnidad, string Observacion, string Usuario, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            string respuesta = "";
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "BodegaPliegos_OC_RecepcionFactura";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroOC", NroOC);
                cmd.Parameters.AddWithValue("@IDItem", IDItem);
                cmd.Parameters.AddWithValue("@Documento", "");
                cmd.Parameters.AddWithValue("@NroFactura", NroFactura);
                cmd.Parameters.AddWithValue("@Cantidad", Catnidad);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = dr["CantidadMaxima"].ToString();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
        public OrdenesCompra CargaFaltante2(string NroOC, string IDItem, string NroFactura, double Catnidad, string Observacion, string Usuario, int Procedimiento)
        {
            OrdenesCompra d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "BodegaPliegos_OC_RecepcionFactura";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroOC", NroOC);
                cmd.Parameters.AddWithValue("@IDItem", IDItem);
                cmd.Parameters.AddWithValue("@Documento", "");
                cmd.Parameters.AddWithValue("@NroFactura", NroFactura);
                cmd.Parameters.AddWithValue("@Cantidad", Catnidad);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    d = new OrdenesCompra();
                    d.CantidadPliegos = reader["CantidadCreada"].ToString();
                    d.CantidadPliegosRecep = reader["CantidadRecepcionadaFactura"].ToString();
                }

            }

            conexion.CerrarConexion();

            return d;
        }
        public string MuestraProveedores(string NombreProveedor,string Rut, int procedimiento)
        {
            string resultado = "[";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[BodegaPliegos_OC_BuscaProveedor]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                    cmd.Parameters.AddWithValue("@Rut", Rut);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        resultado +=
                            "{_Rut_:_" + reader["cgc"].ToString() + "_,_Proveedor_:_" + reader["Proveedor"].ToString()
                            + "_,_Seleccionar_:_" + "<button type='button' class='btn btn-primary' id='btnselect' data-dismiss='modal' onclick='javascript:cargaDatosProveedor(" + reader["idProveedor"].ToString() + ");'>Seleccionar</button>" + "_},";
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
        public OrdenesCompra TraeDatosProveedor(string NombreProveedor, string Rut, int procedimiento)
        {
            OrdenesCompra d = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_OC_BuscaProveedor]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new OrdenesCompra();
                    d.Rut = reader["cgc"].ToString();
                    d.Proveedor = reader["Proveedor"].ToString();
                    d.Email = reader["email"].ToString();
                    d.Telefono = reader["Telefone"].ToString();
                    d.CondicionPago = reader["CondPagtoPadrao"].ToString();
                    d.Direccion = reader["Direccion"].ToString();

                }
            }
            conexion.CerrarConexion();
            return d;
        }
        public List<OrdenesCompra> CargaDirecciones(string NombreProveedor, string Rut, int procedimiento)
        {
            List<OrdenesCompra> lista = new List<OrdenesCompra>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_OC_BuscaProveedor]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                cmd.Parameters.AddWithValue("@Rut", Rut);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenesCompra d = new OrdenesCompra();
                    d.Direccion = reader["Direccion"].ToString();
                    lista.Add(d);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public string CargaFacturasCargadas(string IDItem,string OC, int procedimiento)
        {
            string Encabezado = "<table id='Table1' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1000px;'>" +
            "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style21'>" +
            "OC</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style21'>" +
            "Nro Factura</td>" +

            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "Observacion</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "FechaRecepcion</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "Recepcion</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "Cantidad</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "Faltante</td>" +
            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
            "</td>" +
            "</tr>";
            string Contenido = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[BodegaPliegos_OC_BuscaProveedor]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProveedor", IDItem);
                cmd.Parameters.AddWithValue("@Rut", OC);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style21'>" +
                    reader["NroOC"].ToString() + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;' class='style21'>" +
                    reader["NroDocumento"].ToString() + "</td>" +

                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                    reader["Observacion"].ToString() + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;'>" +
                    Convert.ToDateTime(reader["FechaRecepcion"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                    reader["Usuario"].ToString() + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                    reader["Cantidad"].ToString() + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                    reader["Faltante"].ToString() + "</td>" +
                    "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                    "Ver Mas</td>" +
                    "</tr>";
                }
            }
            con.CerrarConexion();
            return Encabezado + Contenido + "</tbody></table>";
        }
    }
}