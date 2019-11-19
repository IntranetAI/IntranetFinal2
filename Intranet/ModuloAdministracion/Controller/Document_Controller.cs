using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloAdministracion.Model;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using Intranet.ModuloFacturacion.Controller;

namespace Intranet.ModuloAdministracion.Controller
{
    public class Document_Controller
    {
        string RutDefecto = "0000000000-0";
        string IDPeriododef = "000000";
        string DocCceNumero = "                         ";

        public List<Documento> ListarDocContable(int IDTipDMercan, string fechaDesde, string fechaHasta, int IDEstadoDoc)
        {
            List<Documento> lista = new List<Documento>();            
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                cmd.CommandText = "getDocumentosProcesados";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_tipo_documento_mercantil", IDTipDMercan);
                cmd.Parameters.AddWithValue("@fecha_desde", fechaDesde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fechaHasta);
                cmd.Parameters.AddWithValue("@id_estado_documento", IDEstadoDoc);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Documento doc = new Documento();
                    doc.IDDocMercantil = Convert.ToInt32(reader["id_documento_mercantil"].ToString());
                    doc.FolioFactura = Convert.ToInt32(reader["folio_factura"].ToString());
                    doc.FechaCreacion = Convert.ToDateTime(reader["fecha_creacion"].ToString());
                    doc.fechaEmision = Convert.ToDateTime(reader["fecha_emision"].ToString());
                    doc.NombreCliente = reader["nombre_cliente"].ToString();
                    doc.NombreTipoDocMer = reader["nombre_tipo_documento_mercantil"].ToString();
                    Double tipoCambio = Convert.ToDouble(reader["valor_tipo_cambio"].ToString());
                    if (tipoCambio > 0)
                    {
                        doc.valorNeto = Convert.ToDouble(reader["valor_neto"].ToString()) * tipoCambio;
                    }
                    else
                    {
                        doc.valorNeto = Convert.ToDouble(reader["valor_neto"].ToString());
                    }
                    doc.IDTipoDocMerca = Convert.ToInt32(reader["id_tipo_documento_mercantil"].ToString());
                    doc.IDTipoCambio = Convert.ToInt32(reader["id_tipo_cambio"].ToString());
                    string IDTipoDocumentoSII = "0";
                    switch (doc.IDTipoDocMerca)
                    {
                        case 1: IDTipoDocumentoSII = "33"; break;
                        case 2: IDTipoDocumentoSII = "33"; break;
                        case 3: IDTipoDocumentoSII = "33"; break;
                        case 4: IDTipoDocumentoSII = "61"; break;
                        case 5: IDTipoDocumentoSII = "61"; break;
                        case 6: IDTipoDocumentoSII = "61"; break;
                        case 7: IDTipoDocumentoSII = "56"; break;
                        case 8: IDTipoDocumentoSII = "56"; break;
                        case 9: IDTipoDocumentoSII = "0"; break;
                        default: IDTipoDocumentoSII = "0"; break;
                    }
                    Controller_Facturacion controlfactura = new Controller_Facturacion();
                    if (doc.NombreTipoDocMer == "Factura Exportación")
                    {
                        doc.NombreCuenta = "Enviado";
                    }
                    else
                    {
                        if (controlfactura.FacturaElectro_enviadaSII(doc.FolioFactura.ToString(), IDTipoDocumentoSII))
                        {
                            doc.NombreCuenta = "Enviado";
                        }
                        else
                        {
                            doc.NombreCuenta = "Pendiente";
                        }
                    }
                    lista.Add(doc);
                }
                
            }
            con.CerrarConexion();
            return lista;
        }

        public Documento ListarDocPopUp(int IDTipDMercan, int IDDoctoMerca)
        {
            Documento doc = new Documento();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                cmd.CommandText = "getDocumentoMercantil";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_tipo_documento", IDTipDMercan);
                cmd.Parameters.AddWithValue("@id_documento", IDDoctoMerca);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doc.FolioFactura = Convert.ToInt32(reader["folio_factura"].ToString());
                    doc.valorNeto = Convert.ToDouble(reader["valor_neto"].ToString());
                    doc.rut_cliente = Convert.ToInt32(reader["rut_cliente"].ToString());
                    doc.IDProducto = Convert.ToInt32(reader["id_producto"].ToString());
                    if (reader["valor_tipo_cambio"].ToString() != "")
                    {
                        doc.TipoCambio = Convert.ToDouble(reader["valor_tipo_cambio"].ToString());
                    }
                }
                
            }
            con.CerrarConexion();
            return doc;
        }

        public Documento ListarClientePopUp(int RutCliente)
        {
            Documento doc = new Documento();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                cmd.CommandText = "getCliente";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rut_cliente", RutCliente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doc.NombreCliente = reader["nombre_cliente"].ToString();
                    doc.NombreTipoDocMer = reader["calle"].ToString();
                    doc.NombreCosto = reader["nombre_pais"].ToString();
                }
                
            }
            con.CerrarConexion();
            return doc;
        }

        public List<Documento> ListarProductoPopUp(int IDDocumentoMer, int IDProducto, double valorcambio)
        {
            string a = IDDocumentoMer.ToString();
            string b = IDProducto.ToString();
            List<Documento> lista = new List<Documento>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                cmd.CommandText = "getProductoDocumentoMercantil";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", IDProducto);
                cmd.Parameters.AddWithValue("@id_documento_mercantil", IDDocumentoMer);
                SqlDataReader reader = cmd.ExecuteReader();
                string conceptocontable = "";
                Double totalNeto = 0;

                while (reader.Read())
                {
                    int exists = 0;
                    Documento doc = new Documento();
                    doc.NombreConceCon = reader["nombre_concepto_contable"].ToString();
                    string Neto = reader["valor_sub_concepto_contable"].ToString();
                    int lenght = Neto.Length;
                    if (valorcambio > 0)
                    {
                        doc.valorNeto = Convert.ToDouble(Neto) * valorcambio;

                    }
                    else
                    {
                        doc.valorNeto = Convert.ToDouble(Neto);
                    }

                    foreach (Documento dc in lista)
                    {
                        if (conceptocontable == doc.NombreConceCon)
                        {
                            dc.valorNeto = doc.valorNeto + dc.valorNeto;
                            exists = exists + 1;
                        }
                    }

                    conceptocontable = doc.NombreConceCon;
                    if (reader["nombre_cuenta_contable"].ToString() == "sin cuenta")
                    {
                        string drop = "<select name='cuentacorriente'>" +
                            "<option value='0' selected='selected'>sin cuenta</option>" +
                            "<option value='510301'>Ingresos Operacionales</option>" +
                            "<option value='510101'>Venta Nacional Externa</option>" +
                            "<option value='510102'>Venta Nacional Relacionada</option>" +
                            "<option value='510103'>Venta Exportaciones Externa</option>" +
                            "<option value='510104'>Ventas Exportaciones Relacionada</option>" +
                            "<option value='510202'>Ventas Papel Desecho</option>" +
                            "<option value='510201'>Ventas Materias Primas </option>" +
                            "<option value='520101'>Venta Activo Fijo </option>" +
                            "</select>";
                        doc.NombreCuenta = drop;
                    }
                    if (reader["nombre_cuenta_contable"].ToString() == "Ingresos Operacionales")
                    {
                        string drop = "<select name='cuentacorriente'>" +
                            "<option value='0'>sin cuenta</option>" +
                            "<option value='510301' selected='selected'>Ingresos Operacionales</option>" +
                            "<option value='510101'>Venta Nacional Externa</option>" +
                            "<option value='510102'>Venta Nacional Relacionada</option>" +
                            "<option value='510103'>Venta Exportaciones Externa</option>" +
                            "<option value='510104'>Ventas Exportaciones Relacionada</option>" +
                            "<option value='510202'>Ventas Papel Desecho</option>" +
                            "<option value='510201'>Ventas Materias Primas </option>" +
                            "<option value='520101'>Venta Activo Fijo </option>" +
                            "</select>";
                        doc.NombreCuenta = drop;
                    }
                    if (reader["nombre_cuenta_contable"].ToString() == "Venta Nacional Externa")
                    {
                        string drop = "<select name='cuentacorriente'>" +
                            "<option value='0' selected='selected'>sin cuenta</option>" +
                            "<option value='510301'>Ingresos Operacionales</option>" +
                            "<option value='510101' selected='selected'>Venta Nacional Externa</option>" +
                            "<option value='510102'>Venta Nacional Relacionada</option>" +
                            "<option value='510103'>Venta Exportaciones Externa</option>" +
                            "<option value='510104'>Ventas Exportaciones Relacionada</option>" +
                            "<option value='510202'>Ventas Papel Desecho</option>" +
                            "<option value='510201'>Ventas Materias Primas </option>" +
                            "<option value='520101'>Venta Activo Fijo </option>" +
                            "</select>";
                        doc.NombreCuenta = drop;
                    }
                    if (reader["nombre_cuenta_contable"].ToString() == "Venta Nacional Relacionada")
                    {
                        string drop = "<select name='cuentacorriente'>" +
                            "<option value='0' selected='selected'>sin cuenta</option>" +
                            "<option value='510301'>Ingresos Operacionales</option>" +
                            "<option value='510101'>Venta Nacional Externa</option>" +
                            "<option value='510102'selected='selected'>Venta Nacional Relacionada</option>" +
                            "<option value='510103'>Venta Exportaciones Externa</option>" +
                            "<option value='510104'>Ventas Exportaciones Relacionada</option>" +
                            "<option value='510202'>Ventas Papel Desecho</option>" +
                            "<option value='510201'>Ventas Materias Primas </option>" +
                            "<option value='520101'>Venta Activo Fijo </option>" +
                            "</select>";
                        doc.NombreCuenta = drop;
                    }
                    if (reader["nombre_cuenta_contable"].ToString() == "Venta Exportaciones Externa")
                    {
                        string drop = "<select name='cuentacorriente'>" +
                            "<option value='0' selected='selected'>sin cuenta</option>" +
                            "<option value='510301'>Ingresos Operacionales</option>" +
                            "<option value='510101'>Venta Nacional Externa</option>" +
                            "<option value='510102'>Venta Nacional Relacionada</option>" +
                            "<option value='510103' selected='selected'>Venta Exportaciones Externa</option>" +
                            "<option value='510104'>Ventas Exportaciones Relacionada</option>" +
                            "<option value='510202'>Ventas Papel Desecho</option>" +
                            "<option value='510201'>Ventas Materias Primas </option>" +
                            "<option value='520101'>Venta Activo Fijo </option>" +
                            "</select>";
                        doc.NombreCuenta = drop;
                    }
                    if (reader["nombre_cuenta_contable"].ToString() == "Ventas Exportaciones Relacionada")
                    {
                        string drop = "<select name='cuentacorriente'>" +
                            "<option value='0' selected='selected'>sin cuenta</option>" +
                            "<option value='510301'>Ingresos Operacionales</option>" +
                            "<option value='510101'>Venta Nacional Externa</option>" +
                            "<option value='510102'>Venta Nacional Relacionada</option>" +
                            "<option value='510103'>Venta Exportaciones Externa</option>" +
                            "<option value='510104' selected='selected'>Ventas Exportaciones Relacionada</option>" +
                            "<option value='510202'>Ventas Papel Desecho</option>" +
                            "<option value='510201'>Ventas Materias Primas </option>" +
                            "<option value='520101'>Venta Activo Fijo </option>" +
                            "</select>";
                        doc.NombreCuenta = drop;
                    }
                    if (reader["nombre_cuenta_contable"].ToString() == "Ventas Papel Desecho")
                    {
                        string drop = "<select name='cuentacorriente'>" +
                            "<option value='0' selected='selected'>sin cuenta</option>" +
                            "<option value='510301'>Ingresos Operacionales</option>" +
                            "<option value='510101'>Venta Nacional Externa</option>" +
                            "<option value='510102'>Venta Nacional Relacionada</option>" +
                            "<option value='510103'>Venta Exportaciones Externa</option>" +
                            "<option value='510104'>Ventas Exportaciones Relacionada</option>" +
                            "<option value='510202' selected='selected'>Ventas Papel Desecho</option>" +
                            "<option value='510201'>Ventas Materias Primas </option>" +
                            "<option value='520101'>Venta Activo Fijo </option>" +
                            "</select>";
                        doc.NombreCuenta = drop;
                    }
                    if (reader["nombre_cuenta_contable"].ToString() == "Ventas Materias Primas ")
                    {
                        string drop = "<select name='cuentacorriente'>" +
                            "<option value='0' selected='selected'>sin cuenta</option>" +
                            "<option value='510301'>Ingresos Operacionales</option>" +
                            "<option value='510101'>Venta Nacional Externa</option>" +
                            "<option value='510102'>Venta Nacional Relacionada</option>" +
                            "<option value='510103'>Venta Exportaciones Externa</option>" +
                            "<option value='510104'>Ventas Exportaciones Relacionada</option>" +
                            "<option value='510202'>Ventas Papel Desecho</option>" +
                            "<option value='510201' selected='selected'>Ventas Materias Primas </option>" +
                            "<option value='520101'>Venta Activo Fijo </option>" +
                            "</select>";
                        doc.NombreCuenta = drop;
                    }
                    if (reader["nombre_cuenta_contable"].ToString() == "Venta Activo Fijo ")
                    {
                        string drop = "<select name='cuentacorriente'>" +
                            "<option value='0' selected='selected'>sin cuenta</option>" +
                            "<option value='510301'>Ingresos Operacionales</option>" +
                            "<option value='510101'>Venta Nacional Externa</option>" +
                            "<option value='510102'>Venta Nacional Relacionada</option>" +
                            "<option value='510103'>Venta Exportaciones Externa</option>" +
                            "<option value='510104'>Ventas Exportaciones Relacionada</option>" +
                            "<option value='510202'>Ventas Papel Desecho</option>" +
                            "<option value='510201'>Ventas Materias Primas </option>" +
                            "<option value='520101' selected='selected'>Venta Activo Fijo </option>" +
                            "</select>";
                        doc.NombreCuenta = drop;
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Peru")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101' selected='selected'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Brasil")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102' selected='selected'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Argentina")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103' selected='selected'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Colombia")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104' selected='selected'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "ventas USA")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105' selected='selected'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas México")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107' selected='selected'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Paraguay")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108' selected='selected'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Uruguay")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109' selected='selected'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Europa")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110' selected='selected'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Chile")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111' selected='selected'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Otros Paises")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112' selected='selected'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Desechos")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113' selected='selected'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Ventas Otros Ingresos")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114' selected='selected'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Maquinarias Varias Encuadernación ")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103' selected='selected'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Sin Centro Costo")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0' selected='selected'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Equipos de Computación")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114' selected='selected'>Equipos de Computación</option>" +
                            "<option value='50201'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    if (reader["nombre_centro_costo"].ToString() == "Speed Master 8P")
                    {
                        string dropCosto = "<select name='centro_costo'>" +
                            "<option value='80101'>Ventas Peru</option>" +
                            "<option value='80102'>Ventas Brasil</option>" +
                            "<option value='80103'>Ventas Argentina</option>" +
                            "<option value='80104'>Ventas Colombia</option>" +
                            "<option value='80105'>ventas USA</option>" +
                            "<option value='80107'>Ventas México</option>" +
                            "<option value='80108'>Ventas Paraguay</option>" +
                            "<option value='80109'>Ventas Uruguay</option>" +
                            "<option value='80110'>Ventas Europa</option>" +
                            "<option value='80111'>Ventas Chile</option>" +
                            "<option value='80112'>Ventas Otros Paises</option>" +
                            "<option value='80113'>Ventas Desechos</option>" +
                            "<option value='80114'>Ventas Otros Ingresos</option>" +
                            "<option value='61103'>Maquinarias Varias Encuadernación </option>" +
                            "<option value='0'>Sin Centro Costo</option>" +
                            "<option value='75114'>Equipos de Computación</option>" +
                            "<option value='50201' selected='selected'>Speed Master 8P</option>" +
                        "</select>";
                        doc.NombreCosto = dropCosto;//reader["nombre_centro_costo"].ToString();
                    }
                    doc.NombreCliente = reader["ot_producto"].ToString();
                    doc.NombreTipoDocMer = reader["nombre_producto"].ToString();
                    if (exists == 0)
                    {
                        lista.Add(doc);
                    }
                }
                
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Cabecera> ExportacionExcel(string FolioFactura, string FechaInicio, string FechaTermino)
        {
            string vacio6ceros = "00000";
            string f = FolioFactura.ToString();
            List<Cabecera> lista = new List<Cabecera>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                 cmd.CommandText =  " SELECT distinct "+
                                    "  dm.id_documento_mercantil, "+
                                    "  dm.id_folio_prefactura AS folio_prefactura, "+
                                    "  dm.id_folio_factura AS folio_factura, "+
                                    " dm.fecha_creacion, "+
                                    " dm.fecha_emision, "+
                                    " dm.referencia_condicion_venta, "+
                                    " nombre_condicion_venta, "+
                                    " CASE "+
                                    " WHEN es_electronico = 1 THEN 9 "+
                                    " ELSE id_tipo_documento_nuevo "+
                                    " END AS Factura_electronico, "+
                                    " ev.rut_entidad AS rut_cliente, "+
                                    " ev.digito_verificador AS digito_verificador, "+
                                    " c.referencia_tipo_cliente AS id_tipo_cliente, "+
                                    " ev.nombre_entidad +' '+ev.apellido_paterno AS nombre_cliente, "+
                                    " 0 as clasificacion, "+
                                    " td.id_tipo_documento AS id_tipo_documento_mercantil, "+
                                    " td.nombre_tipo_documento AS nombre_tipo_documento_mercantil, "+
                                    " ed.nombre_estado_documento, "+
                                    " dm.valor_neto as valor_neto, "+
                                    " dm.valor_iva as valor_iva, "+
                                    " dm.valor_total as valor_total, "+
                                    " dm.valor_flete as valor_flete, "+
                                    " dm.valor_seguro as valor_seguro, "+
                                    " dm.peso_neto as peso_neto, "+
                                    " dm.peso_bruto as peso_bruto, "+
                                    " '' as guias_despacho, "+
                                    " '' as observaciones, "+
                                    " dm.clausula as clausula, "+
                                    " dm.referencia_tipo_cambio as id_tipo_cambio, "+
                                    " tpc.fecha_registro as fecha_tipo_cambio, "+
                                    " tpc.valor_tipo_cambio, "+
                                    " dm.es_electronico AS es_electronico "+
                                    " FROM documentos_mercantil dm, "+
                                    " entidades_view ev, "+
                                    " clientes c, "+
                                    " tipos_cliente tc, "+
                                    " tipos_documento td, "+
                                    " estados_documento ed, "+
                                    " tipos_cambio tpc, "+
                                    " condiciones_venta "+
                                    " WHERE dm.referencia_cliente = ev.rut_entidad "+
                                    " AND c.referencia_entidad = ev.rut_entidad "+
                                    " AND dm.referencia_cliente = ev.rut_entidad "+
                                    " AND c.referencia_tipo_cliente = tc.id_tipo_cliente "+
                                    " AND ev.referencia_sucursal = dm.referencia_sucursal "+
                                    " AND td.id_tipo_documento = dm.referencia_tipo_documento "+
                                    " AND ed.id_estado_documento = dm.referencia_estado_documento "+
                                    " AND dm.fecha_emision BETWEEN '" + FechaInicio + "' AND  '" + FechaTermino + "' " +
                                    " AND dm.referencia_tipo_documento in(1,2,3,5,6,8,9) "+
                                    " AND dm.referencia_estado_documento in(5,7,8) "+
                                    " AND dm.referencia_tipo_cambio*=tpc.id_tipo_cambio "+
                                    " and dm.id_folio_factura in (" + FolioFactura + ") " +
                                    " and id_condicion_venta=dm.referencia_condicion_venta" +
                                    " ORDER BY folio_factura, dm.id_folio_prefactura ";
                    
                SqlDataReader reader = cmd.ExecuteReader();
                int contador = 0;
                while (reader.Read())
                {
                    Cabecera cab = new Cabecera();
                    cab.SisCidOri = 11;
                    cab.Id_Funcionalidad = "LVEDOCTOLEGALCAB";
                    cab.EmpId = "000000002";
                    cab.DivCodigo = "0001";
                    cab.UniCodigo = "0001";
                    DateTime fecha = Convert.ToDateTime(reader["fecha_emision"].ToString());
                    string f3 = fecha.ToString("yyyy/MM/dd");
                    cab.LlgDocFechaIng = f3;
                    //string CargarP = CargarPeriodo(fecha).ToString();
                    string[] fperidoo = f3.Split('/');
                    cab.IntPeriodo = fperidoo[0] + fperidoo[1];//IDPeriododef.Substring(0, IDPeriododef.Length-CargarP.Length) + CargarP;
                    string es_elect = "";
                    if (reader["Factura_electronico"].ToString() == "13")
                    {
                        es_elect = "2";
                    }
                    else
                    {
                        es_elect = reader["Factura_electronico"].ToString();
                    }
                    cab.OpeCod = vacio6ceros.Substring(0, vacio6ceros.Length - es_elect.Length) + es_elect;
                    string caractervacio = "                                                                                ";
                    string fa = "Factura " + reader["folio_factura"].ToString();
                    string glosa = fa + caractervacio.Substring(0, caractervacio.Length - fa.Length);
                    cab.LlgDocGlosa = glosa;
                    string LlgDocNumInt = (contador+1).ToString();
                    string Ceros = "000000000";
                    cab.LlgDocNumInterno = Ceros.Substring(0, Ceros.Length - LlgDocNumInt.Length) + LlgDocNumInt;
                    string Folio_factura = reader["folio_factura"].ToString();
                    string ffactura = "                         ";
                    cab.LlgDocNumDoc = Folio_factura+ffactura.Substring(0, ffactura.Length - Folio_factura.Length);
                    cab.LlgDocNumProvision = Ceros;
                    string rut = reader["rut_cliente"].ToString() + "-" + reader["digito_verificador"].ToString();
                    string b = RutDefecto.Substring(0,12-rut.Length)+rut;
                    cab.EntRut = b;
                    cab.EntSucNumero = "0001";
                    cab.EntRutSec = RutDefecto;
                    cab.EntSucNumeroSec = "0000";
                    cab.EntRutTer = RutDefecto;
                    cab.EntSucNumeroTer = "0000";
                    cab.LlgDocFecha = f3;
                    cab.LlgDocFechaVenc = FechaVencimiento(fecha, Convert.ToInt32(reader["referencia_condicion_venta"].ToString()));
                    if (es_elect == "2")
                    {
                        cab.pMonedaId = "0002";
                    }

                    if (es_elect != "2")
                    {
                        cab.pMonedaId = "0001";
                    }

                    string llgDocMtoT = "000000000000000000";
                    double valor = 0;
                    Double dbl2 = 0;
                    if (es_elect == "2")
                    {
                        valor = (Convert.ToDouble(reader["valor_neto"].ToString()) + Convert.ToDouble(reader["valor_flete"].ToString())) * Convert.ToDouble(reader["valor_tipo_cambio"].ToString());
                        dbl2 = Convert.ToDouble(reader["valor_neto"].ToString()) + Convert.ToDouble(reader["valor_flete"].ToString());
                    }
                    else 
                    {
                        valor = Convert.ToDouble(reader["valor_neto"].ToString());
                    }
                    
                    string[] str = valor.ToString("0.0000").Split('.');
                    string resultado = str[0]+str[1];
                    if (es_elect == "2")
                    {
                        cab.LlgDocMtoImpuAfecto = llgDocMtoT;
                        cab.LlgDocMtoImpuNeto = llgDocMtoT;
                        cab.LlgDocMtoImpuIva = llgDocMtoT;
                        cab.LlgDocMtoLocalAfecto = llgDocMtoT;
                        cab.LlgDocMtoLocalNeto = llgDocMtoT;

                        //cambiar aqui
                        cab.LlgDocMtoLocalIva = llgDocMtoT;
                        

                        str = null; str = Convert.ToInt32(valor).ToString("0.0000").Split('.');
                        string[] str123 = dbl2.ToString("0.0000").Split('.');
                        string resultado123 = str[0] + str[1];
                        string pesosNorm = str123[0]+ str123[1];
                        cab.LlgDocMtoImpuExento = llgDocMtoT.Substring(0, llgDocMtoT.Length - pesosNorm.Length) + pesosNorm;
                        cab.LlgDocMtoLocalExento = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado123.Length) + resultado123 ;
                        //cab.LlgDocMtoImpuTotal = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado123.Length) + resultado123;
                    }
                    else
                    {
                        cab.LlgDocMtoImpuAfecto = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado.Length) + resultado;
                        cab.LlgDocMtoImpuNeto = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado.Length) + resultado;
                        cab.LlgDocMtoLocalAfecto = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado.Length) + resultado;
                        cab.LlgDocMtoLocalNeto = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado.Length) + resultado;
                        cab.LlgDocMtoLocalExento = llgDocMtoT;
                        cab.LlgDocMtoImpuExento = llgDocMtoT;
                    }
                    valor = 0; str = null;
                    
                    if (es_elect != "2")
                    {
                        cab.LlgDocMtoLocalIva = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado.Length) + resultado;
                    }                    
                   
                    valor = Convert.ToDouble(reader["valor_iva"].ToString());
                    str = valor.ToString("0.0000").Split('.');
                    
                    if (es_elect != "2")
                    {
                        string resultado2 = str[0] + str[1];
                        cab.LlgDocMtoImpuIva = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado2.Length) + resultado2;
                        cab.LlgDocMtoLocalIva = cab.LlgDocMtoImpuIva;
                        // = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado2.Length) + resultado2;
                        valor = 0; str = null;
                    }

                    cab.LlgDocMtoImpuOtrosImp = llgDocMtoT;
                    cab.LlgDocMtoImpuDerAdu = llgDocMtoT;
                    cab.LlgDocMtoImpuRete = llgDocMtoT;

                    //incompleto
                    if (es_elect == "2")
                    {
                        valor = (Convert.ToDouble(reader["valor_total"].ToString())+ Convert.ToDouble(reader["valor_flete"].ToString()))*Convert.ToDouble(reader["valor_tipo_cambio"].ToString());
                        dbl2 = (Convert.ToDouble(reader["valor_total"].ToString()) + Convert.ToDouble(reader["valor_flete"].ToString()));
                    }
                    else
                    {
                        valor = Convert.ToDouble(reader["valor_total"].ToString());
                    }
                    str = valor.ToString("0.0000").Split('.');
                    string resultado3 = str[0] + str[1];
                    if (es_elect == "2")
                    {
                        //string[] str123 = dbl2.ToString("0.0000").Split('.');
                        int DolarTotalSinP = Convert.ToInt32(valor);
                        str = null; str = DolarTotalSinP.ToString("0.0000").Split('.');
                        string[] str123 = dbl2.ToString("0.0000").Split('.');
                        string resultado123 = str[0] + str[1];
                        string DolarToString = str123[0] + str123[1];
                        cab.LlgDocMtoImpuTotal = llgDocMtoT.Substring(0, llgDocMtoT.Length - DolarToString.Length) + DolarToString;
                        
                        cab.LlgDocMtoLocalTotal = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado123.Length) + resultado123;
                    }
                    else
                    {
                        cab.LlgDocMtoImpuTotal = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado3.Length) + resultado3;
                        cab.LlgDocMtoLocalTotal = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado3.Length) + resultado3;
                        
                    }
                    
                    valor = 0; str = null;
                                        
                    cab.LlgDocMtoLocalDerAdu = llgDocMtoT;
                    cab.LlgDocMtoLocalRete = llgDocMtoT;
                    cab.LlgDocMtoLocalOtrosImp = llgDocMtoT;
                    cab.DocCceDocRef ="                    ";
                    cab.LlgDocMtoIvaRec100 = cab.LlgDocMtoImpuIva != "000000000000000000" ? cab.LlgDocMtoImpuIva : "000000000000000000";
                    cab.LlgDocMtoIvaRecPro = "000000000000000000";
                    cab.LlgDocMtoIvaNoRec = "000000000000000000";
                    cab.ClaIvaId = "001";

                    lista.Add(cab);
                    contador++;



    }
                
            }
            con.CerrarConexion();
            return lista;
        }

        public string FechaVencimiento(DateTime FechaIni,int ID_Cond_ventas)
        {
            string FechaVen = "";
            if (ID_Cond_ventas == 1 || ID_Cond_ventas == 0 || ID_Cond_ventas == 5)
            {
                FechaVen = FechaIni.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 2 || ID_Cond_ventas == 26)
            {
                FechaVen = FechaIni.AddDays(30).ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 3 || ID_Cond_ventas == 9 || ID_Cond_ventas == 20 || ID_Cond_ventas == 24 || ID_Cond_ventas == 29 || ID_Cond_ventas == 19)
            {
                FechaVen = FechaIni.AddDays(60).ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 4 || ID_Cond_ventas == 13 || ID_Cond_ventas == 8 || ID_Cond_ventas == 10 || ID_Cond_ventas==31)
            {
                FechaVen = FechaIni.AddDays(90).ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 6 || ID_Cond_ventas == 23)
            {
                FechaVen = FechaIni.AddDays(45).ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 7 || ID_Cond_ventas == 18|| ID_Cond_ventas == 17)
            {
                FechaVen = FechaIni.AddDays(65).ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 11 || ID_Cond_ventas == 12 || ID_Cond_ventas == 15 || ID_Cond_ventas == 16 || ID_Cond_ventas == 22)
            {
                FechaVen = FechaIni.AddDays(120).ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 14)
            {
                FechaVen = FechaIni.AddDays(75).ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 28)
            {
                FechaVen = FechaIni.AddDays(150).ToString("yyyy/MM/dd");
            }

            return FechaVen;
        }

        public string Condicion_venta(DateTime fechaInicio, int ID_Cond_ventas)
        {
            DateTime fec30 = fechaInicio.AddDays(30);
            DateTime fec45 = fechaInicio.AddDays(45);
            DateTime fec60 = fechaInicio.AddDays(60);
            DateTime fec65 = fechaInicio.AddDays(65);
            DateTime fec75 = fechaInicio.AddDays(75);
            DateTime fec90 = fechaInicio.AddDays(90);
            DateTime fec120 = fechaInicio.AddDays(120);
            DateTime fec150 = fechaInicio.AddDays(150);
            DateTime fec180 = fechaInicio.AddDays(180);

            string resultado = "";
            if (ID_Cond_ventas == 2||ID_Cond_ventas == 26)
            {
                resultado = "1," + fec30.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 1 || ID_Cond_ventas == 0 || ID_Cond_ventas == 5)
            {
                resultado = "1," + fechaInicio.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 3)
            {
                resultado = "2," + fec30.ToString("yyyy/MM/dd") + "," + fec60.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 4||ID_Cond_ventas == 13)
            {
                resultado = "3," + fec30.ToString("yyyy/MM/dd") + "," + fec60.ToString("yyyy/MM/dd") + "," + fec90.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 6)
            {
                resultado = "1," + fec45.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 7||ID_Cond_ventas == 18)
            {
                resultado = "1," + fec65.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 8 || ID_Cond_ventas == 31)
            {
                resultado = "1," + fec90.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 9||ID_Cond_ventas == 20||ID_Cond_ventas == 24 )
            {
                resultado = "1," + fec60.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 10)
            {
                resultado = "2," + fec60.ToString("yyyy/MM/dd") + "," + fec90.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 11)
            {
                resultado = "3," + fec30.ToString("yyyy/MM/dd") + "," + fec90.ToString("yyyy/MM/dd") + "," + fec120.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 12)
            {
                resultado = "2," + fec90.ToString("yyyy/MM/dd") + "," + fec120.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 14)
            {
                resultado = "1," + fec75.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 15)
            {
                resultado = "1," + fec120.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 16||ID_Cond_ventas == 22)
            {
                resultado = "4," + fec30.ToString("yyyy/MM/dd") + "," + fec60.ToString("yyyy/MM/dd") + "," + fec90.ToString("yyyy/MM/dd") + "," + fec120.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 17)
            {
                resultado = "2," + fec30.ToString("yyyy/MM/dd") + "," + fec65.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 19)
            {
                resultado = "2," + fec45.ToString("yyyy/MM/dd") + "," + fec60.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 23)
            {
                resultado = "2," + fec30.ToString("yyyy/MM/dd") + "," + fec45.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 28)
            {
                resultado = "1," + fec150.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 29)
            {
                resultado = "3," + fec30.ToString("yyyy/MM/dd") + "," + fec45.ToString("yyyy/MM/dd") + "," + fec60.ToString("yyyy/MM/dd");
            }
            if (ID_Cond_ventas == 30)
            {
                resultado = "1," + fec180.ToString("yyyy/MM/dd");
            }

            return resultado;
        }

        public List<Detalle> ListarExpExcelDet(string Factura)
        {
            Detalle detFlete = null;
            string vacio3ceros = "000";
            string vacio4ceros = "0000";
            string vacio5ceros = "00000";
            string vacio9ceros = "000000000";
            string vacio18ceros = "000000000000000000";
            string vacio60space = "                                                            ";

            string id_tipoelectro = "";
            int facturaActual = 0;
            string MovCceGlosa = "";
            string ctacod = "";
            int CodigoC_algo = 0;
            double valor = 0;
            string[] trunk;
            string TdoID = "";
            int Condicion_ventas_values =0;
            List<Detalle> lista = new List<Detalle>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                cmd.CommandText =  "SELECT id_folio_factura as factura, "+
                                        "fecha_emision, "+
                                        " referencia_cliente, "+
                                        " p.digito_verificador, "+
                                        " referencia_condicion_venta, "+
                                        " nombre_condicion_venta, "+
                                        " es_electronico AS es_electronico, "+
                                        " id_tipo_documento, "+
                                        " id_tipo_documento_nuevo, "+
                                        " CASE "+
                                        " WHEN es_electronico = 1 THEN 9 "+
                                        " ELSE id_tipo_documento_nuevo "+
                                        " END AS id_tipo_documento_nuevo_electronico, "+
                                        " ISNULL(pd.valor_seguro_implicito,0) AS valor_seguro_implicito, "+
                                        " ISNULL(pd.valor_flete_implicito,0) AS valor_flete_implicito, "+
                                        " ISNULL(pd.comision_agencia,0) AS comision_agencia, "+
                                        " ISNULL(pd.provision_nota_credito,0) AS provision_nota_credito, "+
                                        " id_concepto_contable, "+
                                        " id_concepto_contable_nuevo, "+
                                        " nombre_concepto_contable, "+
                                        " es_operacional, "+
                                        " sum( pc.valor_sub_concepto_contable) as valor_sub_concepto_contable_exportacion , "+
                                        " round (sum( pc.valor_sub_concepto_contable),0) as valor_sub_concepto_contable , " +
                                        " round (sum( pc.valor_sub_concepto_contable),0) as d, "+
                                        "(sum( pc.valor_sub_concepto_contable)*0.19 ) As Iva, "+
                                        " ISNULL(pc.referencia_cuenta_contable,0) as id_cuenta_contable, "+
                                        " CASE "+
                                        " WHEN pc.referencia_cuenta_contable = 510301 THEN 420105 "+
                                        " WHEN pc.referencia_cuenta_contable = 510101 THEn 420101"+
                                        " WHEN pc.referencia_cuenta_contable = 510102 THEN 420103"+
                                        " WHEN pc.referencia_cuenta_contable = 510103 THEN 420102"+
                                        " WHEN pc.referencia_cuenta_contable = 510104 THEN 420104"+
                                        " WHEN pc.referencia_cuenta_contable = 510202 THEN 420201"+
                                        " WHEN pc.referencia_cuenta_contable = 510201 THEN 420106"+
                                        " WHEN pc.referencia_cuenta_contable = 520101 THEN 420301"+
                                        " ELSE 0"+
                                        " END AS id_cuenta_contable_nueva,"+
                                        " nombre_cuenta_contable,"+
                                        " ISNULL(pc.referencia_centro_costo,0) as id_centro_costo,"+
                                        " nombre_centro_costo,"+
                                        " CASE"+
                                        " WHEN es_electronico = 1 THEN 3"+
                                        " ELSE id_tipo_documento_nuevo"+
                                        " END AS TdoId,"+
                                        " id_tipo_documento AS id_tipo_documento_mercantil,"+
                                        " nombre_tipo_documento AS nombre_tipo_documento_mercantil,"+
                                        " tpc.fecha_registro as fecha_tipo_cambio,"+
                                        " tpc.valor_tipo_cambio, valor_neto as valor_neto , valor_iva as valor_iva , valor_total as valor_total, valor_flete as valor_flete " +
                                        " FROM productos pr,"+
                                        " agencias ag,"+
                                        " personas e2,"+
                                        " documentos_mercantil,"+
                                        " productos_documentos_mercantil pd,"+
                                        " clases_producto,"+
                                        " item_producto,"+
                                        " tipos_producto,"+
                                        " tipos_fabricacion, "+
                                        " conceptos_contable, "+
                                        " sub_concepto_contable, "+
                                        " productos_concepto_contable pc, "+
                                        " cuentas_contable cc, "+
                                        " centros_costo co, "+
                                        " clientes_sergio_view p, "+
                                        " tipos_documento, "+
                                        " condiciones_venta, "+
                                        " tipos_cambio tpc "+
                                        " WHERE pd.referencia_documento_mercantil in (" + Factura + ") and  id_concepto_contable != 27" +
                                        " and referencia_cliente=p.rut_empresa "+
                                        " AND id_documento_mercantil=pd.referencia_documento_mercantil "+
                                        " AND pr.id_producto = pd.referencia_producto "+
                                        " AND id_item_producto = pr.referencia_item_producto "+
                                        " AND id_clase_producto = pr.referencia_clase_producto "+
                                        " AND id_tipo_producto = pr.referencia_tipo_producto "+
                                        " AND pd. referencia_agencia *= ag.rut_agencia "+
                                        " AND pd.referencia_vendedor *= e2.rut_persona "+
                                        " AND id_tipo_fabricacion = pd.referencia_tipo_fabricacion "+
                                        " AND pd.referencia_producto = pc.referencia_producto "+
                                        " AND pc.referencia_concepto_contable = id_concepto_contable "+
                                        " AND pc.referencia_sub_concepto_contable = id_sub_concepto_contable "+
                                        " AND cc.id_cuenta_contable = pc.referencia_cuenta_contable "+
                                        " AND co.id_centro_costo = pc.referencia_centro_costo "+
                                        " and referencia_tipo_documento=id_tipo_documento "+
                                        " and id_condicion_venta=referencia_condicion_venta and pc.valor_sub_concepto_contable <>0 " +
                                        " AND referencia_tipo_cambio =tpc.id_tipo_cambio and pc.valor_sub_concepto_contable!=0" +
                                        " Group by id_folio_factura, referencia_condicion_venta, nombre_condicion_venta, referencia_cliente, fecha_emision, "+
                                        " p.digito_verificador, pd.cantidad, valor_producto, pd.peso_neto, pd.peso_bruto, pd.glosa, pd.valor_seguro_implicito, "+
                                        " pd.valor_flete_implicito, pd.comision_agencia, pd.provision_nota_credito, conceptos_contable.id_concepto_contable, "+
                                        " conceptos_contable.id_concepto_contable_nuevo , conceptos_contable.nombre_concepto_contable, conceptos_contable.es_operacional, "+
                                        " pc.referencia_cuenta_contable, cc.nombre_cuenta_contable, pc.referencia_centro_costo, co.nombre_centro_costo, id_tipo_documento, "+
                                        " id_tipo_documento_nuevo, es_electronico, nombre_tipo_documento, tpc.fecha_registro , tpc.valor_tipo_cambio, valor_neto , "+
                                        " valor_iva , valor_total, valor_flete order by id_folio_factura";
                    
                SqlDataReader reader = cmd.ExecuteReader();
                int contadorregisto = 0;
                int contadorFactura = 1;
                int factura = 0;
                double ivaTotal = 0;
                string rutCliente = "";
                double Total = 0;
                int id_tipoDocumentoMercantil = 0;
                double valorPesDol = 0;

                while (reader.Read())
                {
                    Detalle det = new Detalle();
                    
                    facturaActual = Convert.ToInt32(reader["factura"].ToString());

                    if ((factura != facturaActual) && (factura != 0))
                    {
                        //flete
                        if (detFlete != null)
                        {
                            lista.Add(detFlete);
                            detFlete = null;
                        }
                        //fin flete
                        MovCceGlosa = "Factura " + factura.ToString();
                        string CabOpeFecha = "";
                        string OpeCod = vacio5ceros;
                        string idcodelec = vacio3ceros;
                        int contadregis = 0;
                        foreach (Detalle deta in lista)
                        {
                            if (contadregis == lista.Count - 1)
                            {
                                CabOpeFecha = deta.CabOpeFecha;
                                OpeCod = deta.OpeCod;
                                idcodelec = deta.TdoId;
                                id_tipoDocumentoMercantil = deta.id_tipo_documento_mercantil;
                                valorPesDol = deta.ValorPesDol;
                                
                            }
                            contadregis = contadregis + 1;
                        }

                        Detalle detalles = new Detalle();
                        detalles.SisCodOri = 11;
                        detalles.Id_Funcionalidad = "LVEDOCTOLEGALCAB";
                        detalles.EmpId = "000000002";
                        detalles.DivCodigo = "0001";
                        detalles.UniCodigo = "0001";
                        detalles.CabOpeFecha = CabOpeFecha;
                        DateTime Fecha = Convert.ToDateTime(CabOpeFecha);
                        //string CargarP = CargarPeriodo(Fecha).ToString();
                        string[] fechaPerido = Fecha.ToString("yyyy-MM-dd").Split('-');
                        detalles.IntPeriodo = fechaPerido[0] + fechaPerido[1];
                        detalles.OpeCod = OpeCod;
                        
                        detalles.CabOpeGlosa = MovCceGlosa.ToString()+vacio60space.Substring(0,vacio60space.Length-MovCceGlosa.Length);
                        detalles.CabOpeNumero = vacio9ceros.Substring(0,vacio9ceros.Length-contadorFactura.ToString().Length)+ contadorFactura.ToString();
                        contadorregisto = contadorregisto + 1;
                        detalles.CabOpeLinea = vacio9ceros.Substring(0,vacio9ceros.Length-contadorregisto.ToString().Length)+ contadorregisto.ToString();
                        ctacod = "220301";
                        detalles.CtaCodigo = vacio9ceros.Substring(0,vacio9ceros.Length-ctacod.Length)+ctacod;
                        
                        detalles.MovCceGlosa = MovCceGlosa + vacio60space.Substring(0, vacio60space.Length - MovCceGlosa.Length);
                        detalles.pMonedaId = "01"; 
                        detalles.CreCodigo = vacio9ceros;
                        detalles.CdiCodigo = vacio9ceros;
                        detalles.CfiCodigo = vacio9ceros;
                        detalles.pTprId = vacio3ceros;
                        detalles.PryNumero = "                    ";
                        detalles.LineaProdCodigo = "                    ";

                        //rutCliente = //reader["referencia_cliente"].ToString() + "-" + reader["digito_verificador"].ToString();
                        detalles.EntRut = RutDefecto;
                        detalles.EntSucNumero = "0000";
                        detalles.EntRutSec = RutDefecto;
                        detalles.EntSucNumeroSec = vacio4ceros;
                        detalles.EntRutTer = RutDefecto;
                        detalles.EntSucNumeroTer = vacio4ceros;

                        detalles.TdoId = vacio3ceros;
                        detalles.DocCceNumero = DocCceNumero;
                        detalles.DocCceFecEmi = CabOpeFecha;
                        detalles.MovCceNumCuota = vacio4ceros;
                        detalles.MovCceFecVenc = "1900/01/01";
                        detalles.DocCceFecProyectada = CabOpeFecha;

                        detalles.MovCceMontoImpuDebe = vacio18ceros;

                        valor = ivaTotal;
                        int aproximado554 = Convert.ToInt32(valor);
                        if (id_tipoelectro != "2")
                        {
                            trunk = valor.ToString("0.0000").Split('.');
                        }
                        else
                        {
                            trunk = aproximado554.ToString("0.0000").Split('.');
                        }

                        string resultado = trunk[0] + trunk[1];
                        detalles.MovCceMontoImpuHaber = vacio18ceros.Substring(0, vacio18ceros.Length - resultado.Length) + resultado;
                        detalles.MovCceMontoLocalHaber = vacio18ceros.Substring(0, vacio18ceros.Length - resultado.Length) + resultado;
                        trunk = null; valor = 0;
                    
                        detalles.MovCceMontoLocalDebe = vacio18ceros;
                        
                        detalles.InstCod = vacio5ceros;
                        detalles.PlaCod = vacio5ceros;
                        detalles.RutBeneficiario = RutDefecto;
                        detalles.pFormaPagoId = vacio3ceros;
                        detalles.UniCodigoEmi = vacio4ceros;
                        detalles.MovCceFecPagoPropuesta = CabOpeFecha;
                        detalles.ClcId = "003";
                        detalles.pCabReferenciaId = "000000000";
                        detalles.pDetReferenciaId = "000000000";
                        detalles.MovCcePeriodo = "                    ";
                        detalles.CodCtaCteBco = "               ";
                        if (id_tipoelectro != "2")
                        {
                            lista.Add(detalles);
                        }
                        else
                        {
                            contadorregisto = contadorregisto - 1;
                        }

                        string cuotas = Condicion_venta(Convert.ToDateTime(detalles.CabOpeFecha),Condicion_ventas_values);
                        string[] str = cuotas.Split(',');
                        string vaaaalor = str[0];
                        int val = Convert.ToInt32(str[0]);
                        for (int x = 1; x <= val; x++)
                        {

                            Detalle detalles2 = new Detalle();
                            detalles2.SisCodOri = 11;
                            detalles2.Id_Funcionalidad = "LVEDOCTOLEGALCAB";
                            detalles2.EmpId = "000000002";
                            detalles2.DivCodigo = "0001";
                            detalles2.UniCodigo = "0001";
                            detalles2.CabOpeFecha = CabOpeFecha;
                            DateTime Fecha2 = Convert.ToDateTime(CabOpeFecha);
                            //CargarP = CargarPeriodo(Fecha2).ToString();
                            detalles2.IntPeriodo = fechaPerido[0] + fechaPerido[1];
                            detalles2.OpeCod = OpeCod;
                            detalles2.CabOpeGlosa = detalles.MovCceGlosa;
                            detalles2.CabOpeNumero = vacio9ceros.Substring(0, vacio9ceros.Length - contadorFactura.ToString().Length) + contadorFactura.ToString();
                            contadorregisto = contadorregisto + 1;
                            detalles2.CabOpeLinea = vacio9ceros.Substring(0, vacio9ceros.Length - contadorregisto.ToString().Length) + contadorregisto.ToString();
                            if (id_tipoelectro != "2")
                            {
                                ctacod = "140101";
                            }
                            else
                            {
                                ctacod = "140102";
                            }
                            detalles2.CtaCodigo = vacio9ceros.Substring(0, vacio9ceros.Length - ctacod.Length) + ctacod;
                            detalles2.MovCceGlosa = detalles.MovCceGlosa;
                            if (id_tipoelectro != "2")
                            {
                                detalles2.pMonedaId = "01";
                            }
                            else
                            {
                                detalles2.pMonedaId = "02";
                            }
                            detalles2.CreCodigo = vacio9ceros;
                            detalles2.CdiCodigo = vacio9ceros;
                            detalles2.CfiCodigo = vacio9ceros;
                            detalles2.pTprId = vacio3ceros;
                            detalles2.PryNumero = "                    ";
                            detalles2.LineaProdCodigo = "                    ";

                            detalles2.EntRut = RutDefecto.Substring(0, 12 - rutCliente.Length) + rutCliente;
                            detalles2.EntSucNumero = "0001";
                            detalles2.EntRutSec = RutDefecto;
                            detalles2.EntSucNumeroSec = vacio4ceros;
                            detalles2.EntRutTer = RutDefecto;
                            detalles2.EntSucNumeroTer = vacio4ceros;

                            detalles2.TdoId = vacio3ceros.Substring(0, vacio3ceros.Length - TdoID.Length) + TdoID;
                            detalles2.DocCceNumero = factura.ToString() + DocCceNumero.Substring(factura.ToString().Length, DocCceNumero.Length - factura.ToString().Length);
                            detalles2.DocCceFecEmi = CabOpeFecha;
                            detalles2.MovCceNumCuota = vacio4ceros.Substring(0,vacio4ceros.Length-x.ToString().Length)+x;
                            detalles2.MovCceFecVenc = str[x];
                            detalles2.DocCceFecProyectada = str[x];

                            valor = (Total / val);
                            int aproximado = Convert.ToInt32(valor);
                            if (id_tipoelectro == "2")
                            {
                                trunk = valor.ToString("0.0000").Split('.');
                            }
                            else
                            {
                                trunk = aproximado.ToString("0.0000").Split('.');
                            }

                            string result = trunk[0] + trunk[1];
                            detalles2.MovCceMontoImpuDebe = vacio18ceros.Substring(0, vacio18ceros.Length - result.Length) + result;
                            if (id_tipoelectro != "2")
                            {
                                detalles2.MovCceMontoLocalDebe = vacio18ceros.Substring(0, vacio18ceros.Length - result.Length) + result;
                            }
                            else
                            {
                                int cerodec= Convert.ToInt32(valor* valorPesDol);
                                string resultadoPesos = cerodec.ToString("0.0000");//new
                                string[] split = resultadoPesos.Split('.');
                                resultadoPesos = split[0] + split[1];
                                detalles2.MovCceMontoLocalDebe = vacio18ceros.Substring(0,vacio18ceros.Length-resultadoPesos.Length) + resultadoPesos;//new
                            }
                            trunk = null; valor = 0;


                            detalles2.MovCceMontoImpuHaber = vacio18ceros;
                            detalles2.MovCceMontoLocalHaber = vacio18ceros;
                            detalles2.InstCod = vacio5ceros;//=
                            detalles2.PlaCod = vacio5ceros;//=
                            detalles2.RutBeneficiario = RutDefecto;
                            detalles2.pFormaPagoId = vacio3ceros;//=
                            detalles2.UniCodigoEmi = vacio4ceros;//=
                            detalles2.MovCceFecPagoPropuesta = CabOpeFecha;
                            detalles2.ClcId = "007";
                            detalles2.pCabReferenciaId = "000000000";
                            detalles2.pDetReferenciaId = "000000000";
                            detalles2.MovCcePeriodo = "                    ";
                            detalles2.CodCtaCteBco = "               ";
                            lista.Add(detalles2);
                        }
                        ivaTotal = 0;
                        rutCliente = "";
                        Total = 0;
                        contadorregisto = 0;
                        contadorFactura = contadorFactura + 1;
                    }

                    factura = facturaActual;
                    Condicion_ventas_values = Convert.ToInt32(reader["referencia_condicion_venta"].ToString());
                    MovCceGlosa = "Factura " + factura;
                    det.SisCodOri = 11;
                    det.Id_Funcionalidad = "LVEDOCTOLEGALCAB";
                    det.EmpId = "000000002";
                    det.DivCodigo = "0001";
                    det.UniCodigo = "0001";
                    DateTime d = Convert.ToDateTime(reader["fecha_emision"].ToString());
                    det.CabOpeFecha = d.ToString("yyyy/MM/dd");
                    //string per = CargarPeriodo(d).ToString();
                    string[] fechaPerio = d.ToString("yyyy-MM-dd").Split('-');
                    det.IntPeriodo = fechaPerio[0] + fechaPerio[1];


                    if (Convert.ToInt32(reader["id_tipo_documento_nuevo_electronico"].ToString()) == 1 || Convert.ToInt32(reader["id_tipo_documento_nuevo_electronico"].ToString()) == 9)
                    {
                        id_tipoelectro = reader["id_tipo_documento_nuevo_electronico"].ToString();
                    }
                    else
                    {
                        id_tipoelectro = "2";
                    }
                    det.OpeCod = vacio5ceros.Substring(0, vacio5ceros.Length - id_tipoelectro.Length) + id_tipoelectro;
                    det.CabOpeGlosa = MovCceGlosa+ vacio60space.Substring(0, vacio60space.Length-MovCceGlosa.Length);
                    det.CabOpeNumero = vacio9ceros.Substring(0,vacio9ceros.Length-contadorFactura.ToString().Length)+ contadorFactura.ToString();
                    contadorregisto = contadorregisto + 1;
                    det.CabOpeLinea = vacio9ceros.Substring(0,vacio9ceros.Length-contadorregisto.ToString().Length)+ contadorregisto.ToString();

                    ctacod = reader["id_cuenta_contable_nueva"].ToString();
                    det.CtaCodigo = vacio9ceros.Substring(0,vacio9ceros.Length-ctacod.Length)+ctacod;
                    det.MovCceGlosa = MovCceGlosa + vacio60space.Substring(0, vacio60space.Length - MovCceGlosa.Length);

                    if (id_tipoelectro != "2")
                    {
                        det.pMonedaId = "01";
                    }
                    else
                    {
                        det.pMonedaId = "02";
                    }
                    CodigoC_algo = Convert.ToInt32(reader["id_centro_costo"].ToString());
                    det.CreCodigo = vacio9ceros.Substring(0, vacio9ceros.Length - CodigoC_algo.ToString().Length) + CodigoC_algo.ToString();
                    CodigoC_algo = Convert.ToInt32(reader["id_concepto_contable_nuevo"]);
                    det.CdiCodigo = vacio9ceros.Substring(0, vacio9ceros.Length - CodigoC_algo.ToString().Length) + CodigoC_algo.ToString();
                    det.CfiCodigo = vacio9ceros;
                    det.pTprId = vacio3ceros;
                    det.PryNumero = "                    ";
                    det.LineaProdCodigo = "                    ";

                    rutCliente = reader["referencia_cliente"].ToString() + "-" + reader["digito_verificador"].ToString();

                    det.EntRut = RutDefecto;
                    det.EntSucNumero = vacio4ceros;
                    det.EntRutSec = RutDefecto;
                    det.EntSucNumeroSec = vacio4ceros;
                    det.EntRutTer = RutDefecto;
                    det.EntSucNumeroTer = vacio4ceros;

                    det.TdoId = vacio3ceros;
                    det.DocCceNumero = DocCceNumero;
                    det.DocCceFecEmi = d.ToString("yyyy/MM/dd");
                    det.MovCceNumCuota = vacio4ceros;
                    det.MovCceFecVenc = "1900/01/01";
                    det.DocCceFecProyectada = "1900/01/01";

                    if (id_tipoelectro != "2")
                    {
                        ivaTotal = Convert.ToDouble(reader["valor_iva"].ToString());
                    }
                    det.MovCceMontoImpuDebe = vacio18ceros;
                    if (id_tipoelectro != "2")
                    {
                        valor = Convert.ToDouble(reader["valor_sub_concepto_contable"].ToString());
                    }
                    else
                    {
                        valor = Convert.ToDouble(reader["valor_sub_concepto_contable_exportacion"].ToString());
                    }

                    if (id_tipoelectro != "2")
                    {
                        Total = Convert.ToDouble(reader["valor_total"].ToString());
                    }
                    else
                    {
                        Total = Convert.ToDouble(reader["valor_total"].ToString()) + Convert.ToDouble(reader["valor_flete"].ToString());
                    }
                    trunk = valor.ToString("0.0000").Split('.');
                    
                    string resultado2 = trunk[0] + trunk[1];
                    det.MovCceMontoImpuHaber = vacio18ceros.Substring(0, vacio18ceros.Length - resultado2.Length) + resultado2;
                    if (id_tipoelectro != "2")
                    {
                        det.MovCceMontoLocalHaber = vacio18ceros.Substring(0, vacio18ceros.Length - resultado2.Length) + resultado2;
                    }
                    else
                    {
                        int multipli = Convert.ToInt32(valor * Convert.ToDouble(reader["valor_tipo_cambio"].ToString()));
                        string resulExpo = multipli.ToString("0.0000");
                        string[] split = resulExpo.Split('.');
                        resulExpo = split[0] + split[1];
                        det.MovCceMontoLocalHaber = vacio18ceros.Substring(0, vacio18ceros.Length-resulExpo.Length)+ resulExpo;
                    }
                    trunk = null; valor = 0;
                     
                    det.MovCceMontoLocalDebe = vacio18ceros;
                    det.InstCod = vacio5ceros;
                    det.PlaCod = vacio5ceros;
                    det.RutBeneficiario = RutDefecto;
                    det.pFormaPagoId = vacio3ceros;
                    det.UniCodigoEmi = vacio4ceros;
                    det.MovCceFecPagoPropuesta = d.ToString("yyyy/MM/dd");
                    if (id_tipoelectro != "2")
                    {
                        det.ClcId = "001";
                    }
                    else
                    {
                        det.ClcId = "002";
                    }
                    det.pCabReferenciaId = "000000000";
                    det.pDetReferenciaId = "000000000";
                    det.MovCcePeriodo = "                    ";
                    det.CodCtaCteBco = "               ";
                    TdoID = reader["TdoId"].ToString();
                    det.id_tipo_documento_mercantil = Convert.ToInt32(reader["id_tipo_documento_mercantil"].ToString());
                    det.ValorPesDol = Convert.ToDouble(reader["valor_tipo_cambio"].ToString());
                    lista.Add(det);

                    if (id_tipoelectro == "2" && Convert.ToDouble(reader["valor_flete"].ToString())>0)
                    {
                        detFlete = new Detalle();
                        detFlete.SisCodOri = det.SisCodOri;
                        detFlete.Id_Funcionalidad = det.Id_Funcionalidad;
                        detFlete.EmpId = det.EmpId;
                        detFlete.DivCodigo = det.DivCodigo;
                        detFlete.UniCodigo = det.UniCodigo;
                        detFlete.CabOpeFecha = det.CabOpeFecha;
                        detFlete.IntPeriodo = det.IntPeriodo;
                        detFlete.OpeCod = det.OpeCod;
                        detFlete.CabOpeGlosa = det.CabOpeGlosa;
                        detFlete.CabOpeNumero = det.CabOpeNumero;
                        detFlete.CabOpeLinea = det.CabOpeLinea;
                        detFlete.CtaCodigo = det.CtaCodigo;
                        detFlete.MovCceGlosa = det.MovCceGlosa;
                        detFlete.pMonedaId = det.pMonedaId;
                        detFlete.CreCodigo = det.CreCodigo;
                        detFlete.CfiCodigo = det.CfiCodigo;
                        detFlete.pTprId = det.pTprId;
                        detFlete.PryNumero = det.PryNumero;
                        detFlete.LineaProdCodigo = det.LineaProdCodigo;
                        detFlete.EntRut = det.EntRut;
                        detFlete.EntRutSec = det.EntRutSec;
                        detFlete.EntRutTer = det.EntRutTer;
                        detFlete.EntSucNumero = det.EntSucNumero;
                        detFlete.EntSucNumeroSec = det.EntSucNumeroSec;
                        detFlete.EntSucNumeroTer = det.EntSucNumeroTer;
                        detFlete.TdoId = det.TdoId;
                        detFlete.DocCceNumero = det.DocCceNumero;
                        detFlete.DocCceFecEmi = det.DocCceFecEmi;
                        detFlete.MovCceNumCuota = det.MovCceNumCuota;
                        detFlete.MovCceFecVenc = det.MovCceFecVenc;
                        detFlete.DocCceFecProyectada = det.DocCceFecProyectada;
                        detFlete.MovCceMontoImpuDebe = det.MovCceMontoImpuDebe;
                        detFlete.MovCceMontoLocalDebe = det.MovCceMontoLocalDebe;
                        detFlete.InstCod = det.InstCod;
                        detFlete.PlaCod = det.PlaCod;
                        detFlete.RutBeneficiario = det.RutBeneficiario;
                        detFlete.pFormaPagoId = det.pFormaPagoId;
                        detFlete.UniCodigoEmi = det.UniCodigoEmi;
                        detFlete.MovCceFecPagoPropuesta = det.MovCceFecPagoPropuesta;
                        detFlete.ClcId = det.ClcId;
                        detFlete.pCabReferenciaId = det.pCabReferenciaId;
                        detFlete.pDetReferenciaId = det.pDetReferenciaId;
                        detFlete.MovCcePeriodo = det.MovCcePeriodo;
                        detFlete.CodCtaCteBco = det.CodCtaCteBco;
                        detFlete.ValorPesDol = det.ValorPesDol;

                        detFlete.CdiCodigo = "000000009";
                        double FleteDetalle = Convert.ToDouble(reader["valor_flete"].ToString());
                        double FleteDetallePesos = Convert.ToDouble(reader["valor_flete"].ToString()) * Convert.ToDouble(reader["valor_tipo_cambio"].ToString());
                        string[] splitflete = FleteDetalle.ToString("0.0000").Split('.');
                        string FleteDetalle2 = splitflete[0] + splitflete[1];
                        string[] FleteDetaPesos = FleteDetallePesos.ToString("0.0000").Split('.');
                        detFlete.MovCceMontoImpuHaber = vacio18ceros.Substring(0, vacio18ceros.Length - FleteDetalle2.Length) + FleteDetalle2;
                        FleteDetalle2 = FleteDetaPesos[0] + FleteDetaPesos[1];
                        detFlete.MovCceMontoLocalHaber = vacio18ceros.Substring(0, vacio18ceros.Length - FleteDetalle2.Length) + FleteDetalle2;
                    }
                    else
                    {
                        detFlete = null;
                    }
                }
                if (lista.Count > 0)
                {
                    if (detFlete != null)
                    {
                        lista.Add(detFlete);
                        detFlete = null;
                    }
                    string CabOpeFecha = "";
                    int contadreg = 0;
                    string idcodelec = vacio3ceros;
                    foreach (Detalle det in lista)
                    {
                        contadreg = contadreg + 1;
                        if (contadreg == lista.Count)
                        {
                            CabOpeFecha = det.CabOpeFecha;
                            vacio5ceros = det.OpeCod;
                            idcodelec = det.TdoId;
                            id_tipoDocumentoMercantil = det.id_tipo_documento_mercantil;//new
                            valorPesDol = det.ValorPesDol;
                            
                        }
                    }
                    Detalle detalles = new Detalle();
                    detalles.SisCodOri = 11;
                    detalles.Id_Funcionalidad = "LVEDOCTOLEGALCAB";
                    detalles.EmpId = "000000002";
                    detalles.DivCodigo = "0001";
                    detalles.UniCodigo = "0001";
                    detalles.CabOpeFecha = CabOpeFecha;
                    DateTime Fecha = Convert.ToDateTime(CabOpeFecha);
                    //string per = CargarPeriodo(Fecha).ToString();
                    string[] fperiodo = Fecha.ToString("yyyy-MM-dd").Split('-');
                    detalles.IntPeriodo = fperiodo[0] + fperiodo[1];
                   
                    detalles.OpeCod = vacio5ceros;
                    detalles.CabOpeGlosa = MovCceGlosa+vacio60space.Substring(0, vacio60space.Length-MovCceGlosa.Length);
                    detalles.CabOpeNumero = vacio9ceros.Substring(0,vacio9ceros.Length-contadorFactura.ToString().Length)+ contadorFactura.ToString();//numerosegun cantidad factura
                    contadorregisto = contadorregisto + 1;
                    detalles.CabOpeLinea = vacio9ceros.Substring(0, vacio9ceros.Length-contadorregisto.ToString().Length)+ contadorregisto.ToString();
                    
                    ctacod ="220301";
                    detalles.CtaCodigo = vacio9ceros.Substring(0,vacio9ceros.Length-ctacod.Length)+ctacod ;
                    detalles.MovCceGlosa = detalles.CabOpeGlosa;
                    detalles.pMonedaId = "01";
                    detalles.CreCodigo = vacio9ceros;
                    detalles.CdiCodigo = vacio9ceros;
                    detalles.CfiCodigo = vacio9ceros;
                    detalles.pTprId = vacio3ceros;
                    detalles.PryNumero = "                    ";
                    detalles.LineaProdCodigo = "                    ";

                    detalles.EntRut = RutDefecto;
                    detalles.EntSucNumero = vacio4ceros;
                    detalles.EntRutSec = RutDefecto;
                    detalles.EntSucNumeroSec = vacio4ceros;
                    detalles.EntRutTer = RutDefecto;
                    detalles.EntSucNumeroTer = vacio4ceros;

                    detalles.TdoId = vacio3ceros;
                    detalles.DocCceNumero = DocCceNumero;
                    detalles.DocCceFecEmi = CabOpeFecha;
                    detalles.MovCceNumCuota = vacio4ceros;
                    detalles.MovCceFecVenc = "1900/01/01"; 
                    detalles.DocCceFecProyectada = CabOpeFecha;

                    detalles.MovCceMontoImpuDebe = vacio18ceros;

                    valor = ivaTotal;
                    int aproximado = Convert.ToInt32(valor);
                    if (id_tipoelectro != "2")
                    {
                        trunk = valor.ToString("0.0000").Split('.');
                    }
                    else
                    {
                        trunk = aproximado.ToString("0.0000").Split('.');
                    }
                                        
                    string resultado = trunk[0] + trunk[1];
                    detalles.MovCceMontoImpuHaber = vacio18ceros.Substring(0, vacio18ceros.Length - resultado.Length) + resultado;
                    detalles.MovCceMontoLocalHaber = vacio18ceros.Substring(0, vacio18ceros.Length - resultado.Length) + resultado;
                    trunk = null; valor = 0;
                    
                    detalles.MovCceMontoLocalDebe = vacio18ceros;
                    detalles.InstCod = "00000";
                    detalles.PlaCod = "00000";
                    detalles.RutBeneficiario = RutDefecto;
                    detalles.pFormaPagoId = vacio3ceros;
                    detalles.UniCodigoEmi = vacio4ceros;
                    detalles.MovCceFecPagoPropuesta = CabOpeFecha;
                    detalles.ClcId = "003";
                    detalles.pCabReferenciaId = "000000000";
                    detalles.pDetReferenciaId = "000000000";
                    detalles.MovCcePeriodo = "                    ";
                    detalles.CodCtaCteBco = "               ";
                    if (id_tipoelectro != "2")
                    {
                        lista.Add(detalles);
                    }
                    string aaa = detalles.CabOpeFecha;
                    int aaaadf = Condicion_ventas_values;
                    string cuotas = Condicion_venta(Convert.ToDateTime(detalles.CabOpeFecha),Condicion_ventas_values);
                    string[] str = cuotas.Split(',');
                    int val = Convert.ToInt32(str[0]);
                    for (int x = 1; x <= val; x++)
                    {
                        Detalle detalles2 = new Detalle();
                        detalles2.SisCodOri = 11;
                        detalles2.Id_Funcionalidad = "LVEDOCTOLEGALCAB";
                        detalles2.EmpId = "000000002";
                        detalles2.DivCodigo = "0001";
                        detalles2.UniCodigo = "0001";
                        detalles2.CabOpeFecha = CabOpeFecha;
                        DateTime Fecha2 = Convert.ToDateTime(CabOpeFecha);
                        //per = CargarPeriodo(Fecha2).ToString();
                        detalles2.IntPeriodo = fperiodo[0] + fperiodo[1];

                        detalles2.OpeCod = vacio5ceros;
                        detalles2.CabOpeGlosa = MovCceGlosa + vacio60space.Substring(0, vacio60space.Length - MovCceGlosa.Length);
                        detalles2.CabOpeNumero = vacio9ceros.Substring(0, vacio9ceros.Length - contadorFactura.ToString().Length) + contadorFactura.ToString();
                        contadorregisto = contadorregisto + 1;
                        detalles2.CabOpeLinea = vacio9ceros.Substring(0, vacio9ceros.Length - contadorregisto.ToString().Length) + contadorregisto.ToString();
                        if (id_tipoelectro != "2")
                        {
                            ctacod = "140101";
                        }
                        else
                        {
                            ctacod = "140102";
                        }
                        detalles2.CtaCodigo = vacio9ceros.Substring(0, vacio9ceros.Length - ctacod.Length) + ctacod;
                        detalles2.MovCceGlosa = detalles2.CabOpeGlosa;
                        if (id_tipoelectro != "2")
                        {
                            detalles2.pMonedaId = "01";
                        }
                        else
                        {
                            detalles2.pMonedaId = "02";
                        }
                        detalles2.CreCodigo = vacio9ceros;
                        detalles2.CdiCodigo = vacio9ceros;
                        detalles2.CfiCodigo = vacio9ceros;
                        detalles2.pTprId = vacio3ceros;
                        detalles2.PryNumero = "                    ";
                        detalles2.LineaProdCodigo = "                    ";

                        detalles2.EntRut = RutDefecto.Substring(0, 12 - rutCliente.Length) + rutCliente;// RutDefecto;
                        detalles2.EntSucNumero = "0001";
                        detalles2.EntRutSec = RutDefecto;
                        detalles2.EntSucNumeroSec = vacio4ceros;
                        detalles2.EntRutTer = RutDefecto;
                        detalles2.EntSucNumeroTer = vacio4ceros;

                        detalles2.TdoId = vacio3ceros.Substring(0, vacio3ceros.Length - TdoID.Length) + TdoID;
                        detalles2.DocCceNumero = factura.ToString() + DocCceNumero.Substring(factura.ToString().Length, DocCceNumero.Length - factura.ToString().Length);//en iva "" en 3 va el campo factura
                        detalles2.DocCceFecEmi = CabOpeFecha;
                        detalles2.MovCceNumCuota = vacio4ceros.Substring(0, vacio4ceros.Length - x.ToString().Length) + x;
                        detalles2.MovCceFecVenc = str[x];
                        detalles2.DocCceFecProyectada = str[x];

                        valor = Total / val;
                        int aproximado2 = Convert.ToInt32(valor);
                        if (id_tipoelectro == "2")
                        {
                            trunk = valor.ToString("0.0000").Split('.');
                        }
                        else
                        {
                            trunk = aproximado2.ToString("0.0000").Split('.');
                        }
                        
                        string result = trunk[0] + trunk[1];
                        detalles2.MovCceMontoImpuDebe = vacio18ceros.Substring(0, vacio18ceros.Length - result.Length) + result;
                        if (id_tipoelectro != "2")
                        {
                            detalles2.MovCceMontoLocalDebe = vacio18ceros.Substring(0, vacio18ceros.Length - result.Length) + result;
                        }
                        else
                        {
                            int sindeci = Convert.ToInt32(valor * valorPesDol);
                            string resultDolart = sindeci.ToString("0.0000");
                            string[] split = resultDolart.Split('.');
                            resultDolart = split[0] + split[1];
                            detalles2.MovCceMontoLocalDebe = vacio18ceros.Substring(0,vacio18ceros.Length-resultDolart.Length)+resultDolart;//new
                        }
                        trunk = null; valor = 0;

                        detalles2.MovCceMontoImpuHaber = vacio18ceros;
                        detalles2.MovCceMontoLocalHaber = vacio18ceros;
                        detalles2.InstCod = "00000";
                        detalles2.PlaCod = "00000";
                        detalles2.RutBeneficiario = RutDefecto;
                        detalles2.pFormaPagoId = vacio3ceros;
                        detalles2.UniCodigoEmi = vacio4ceros;
                        detalles2.MovCceFecPagoPropuesta = CabOpeFecha;
                        detalles2.ClcId = "007";
                        detalles2.pCabReferenciaId = "000000000";
                        detalles2.pDetReferenciaId = "000000000";
                        detalles2.MovCcePeriodo = "                    ";
                        detalles2.CodCtaCteBco = "               ";
                        lista.Add(detalles2);
                    }
                }                
            }

            con.CerrarConexion();
            return lista;
        }

        public bool UpdateExport(string idFactura, string FechaInicio, string FechaTermino)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                cmd.CommandText = "update documentos_mercantil set referencia_estado_documento=8 " +
                                  " where fecha_emision between '" + FechaInicio + "' and '" + FechaTermino +"' "+
                                  " and referencia_estado_documento in(7,5)" +
                                   " and id_documento_mercantil  in (" + idFactura + ")";
                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
            con.CerrarConexion();
        }
    }
}