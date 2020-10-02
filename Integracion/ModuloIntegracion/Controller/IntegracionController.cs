using Integracion.ModuloIntegracion.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Integracion.ModuloIntegracion.Controller
{
    public class IntegracionController
    {
        public bool Login_sistema(string usuario, string passw, int pin)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "LoginSistema";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Password", passw);
                cmd.Parameters.AddWithValue("@Pin", pin);

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

        public List<TipDocumento> listaTipDoc()
        {
            List<TipDocumento> lista = new List<TipDocumento>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                cmd.CommandText = "getTiposDocumento";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TipDocumento tip = new TipDocumento();
                    tip.IDTipDoc = Convert.ToInt32(reader["id_tipo_documento_mercantil"].ToString());
                    tip.TipDoc = reader["nombre_tipo_documento_mercantil"].ToString();
                    lista.Add(tip);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        public List<Documento> ListarDocContable(int IDTipDMercan, string fechaDesde, string fechaHasta, int IDEstadoDoc, int Procedimiento)
        {
            List<Documento> lista = new List<Documento>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Integracion_ListarDocumentos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.Parameters.AddWithValue("@Folios", "");
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
                    if (doc.NombreTipoDocMer == "Factura Exportación")
                    {
                        doc.NombreCuenta = "Enviado";
                    }
                    else
                    {
                        //if ( FacturaElectro_enviadaSII(doc.FolioFactura.ToString(), ID|TipoDocumentoSII))
                        //{
                        //    doc.NombreCuenta = "Enviado";
                        //}
                        //else
                        //{
                        //    doc.NombreCuenta = "Pendiente";
                        //}
                        doc.NombreCuenta = "Pendiente";
                    }
                    lista.Add(doc);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public bool FacturaElectro_enviadaSII(string Nrofactura, string TipoDocumento)
        {
            Boolean Respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Factura_Elec_ListRegSII_NroFactura";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NroFactura", Nrofactura);
                    cmd.Parameters.AddWithValue("@TipoDocumento", TipoDocumento);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Respuesta = Convert.ToBoolean(reader["Respuesta"].ToString());
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return Respuesta;
        }


        public List<Cabecera> ExportacionExcel(string FolioFactura, string FechaInicio, string FechaTermino, int Procedimiento)
        {
            string RutDefecto = "0000000000-0";
            string IDPeriododef = "000000";
            string DocCceNumero = "                         ";
            string vacio6ceros = "00000";
            string f = FolioFactura.ToString();
            List<Cabecera> lista = new List<Cabecera>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Integracion_ListarDocumentos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.Parameters.AddWithValue("@Folios", FolioFactura);
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
                    string LlgDocNumInt = (contador + 1).ToString();
                    string Ceros = "000000000";
                    cab.LlgDocNumInterno = Ceros.Substring(0, Ceros.Length - LlgDocNumInt.Length) + LlgDocNumInt;
                    string Folio_factura = reader["folio_factura"].ToString();
                    string ffactura = "                         ";
                    cab.LlgDocNumDoc = Folio_factura + ffactura.Substring(0, ffactura.Length - Folio_factura.Length);
                    cab.LlgDocNumProvision = Ceros;
                    string rut = reader["rut_cliente"].ToString();//reader["rut_cliente"].ToString() + "-" + reader["digito_verificador"].ToString();
                    string b = RutDefecto.Substring(0, 12 - rut.Length) + rut;
                    cab.EntRut = b;
                    cab.EntSucNumero = "0001";
                    cab.EntRutSec = RutDefecto;
                    cab.EntSucNumeroSec = "0000";
                    cab.EntRutTer = RutDefecto;
                    cab.EntSucNumeroTer = "0000";
                    cab.LlgDocFecha = f3;
                    cab.LlgDocFechaVenc = fecha.ToString("yyyy/MM/dd");//MODIFICAR SEGUN PAGO
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
                    string resultado = str[0] + str[1];
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
                        string pesosNorm = str123[0] + str123[1];
                        cab.LlgDocMtoImpuExento = llgDocMtoT.Substring(0, llgDocMtoT.Length - pesosNorm.Length) + pesosNorm;
                        cab.LlgDocMtoLocalExento = llgDocMtoT.Substring(0, llgDocMtoT.Length - resultado123.Length) + resultado123;
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
                        valor = (Convert.ToDouble(reader["valor_total"].ToString()) + Convert.ToDouble(reader["valor_flete"].ToString())) * Convert.ToDouble(reader["valor_tipo_cambio"].ToString());
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
                    cab.DocCceDocRef = "                    ";
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


        public List<Detalle> ListarExpExcelDet(string Factura)
        {
            string RutDefecto = "0000000000-0";
            string IDPeriododef = "000000";
            string DocCceNumero = "                         ";
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
            int Condicion_ventas_values = 0;
            List<Detalle> lista = new List<Detalle>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {

                cmd.CommandText = "Integracion_ListarDocumentos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Procedimiento", 2);
                cmd.Parameters.AddWithValue("@Folios", Factura);
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

                        detalles.CabOpeGlosa = MovCceGlosa.ToString() + vacio60space.Substring(0, vacio60space.Length - MovCceGlosa.Length);
                        detalles.CabOpeNumero = vacio9ceros.Substring(0, vacio9ceros.Length - contadorFactura.ToString().Length) + contadorFactura.ToString();
                        contadorregisto = contadorregisto + 1;
                        detalles.CabOpeLinea = vacio9ceros.Substring(0, vacio9ceros.Length - contadorregisto.ToString().Length) + contadorregisto.ToString();
                        ctacod = "220301";
                        detalles.CtaCodigo = vacio9ceros.Substring(0, vacio9ceros.Length - ctacod.Length) + ctacod;

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

                        string cuotas = "1," + Fecha.ToString("yyyy/MM/dd"); // CAMBIAR POR FECHA DE PAGO Condicion_venta(Convert.ToDateTime(detalles.CabOpeFecha), Condicion_ventas_values);
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
                            detalles2.MovCceNumCuota = vacio4ceros.Substring(0, vacio4ceros.Length - x.ToString().Length) + x;
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
                                int cerodec = Convert.ToInt32(valor * valorPesDol);
                                string resultadoPesos = cerodec.ToString("0.0000");//new
                                string[] split = resultadoPesos.Split('.');
                                resultadoPesos = split[0] + split[1];
                                detalles2.MovCceMontoLocalDebe = vacio18ceros.Substring(0, vacio18ceros.Length - resultadoPesos.Length) + resultadoPesos;//new
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
                    det.CabOpeGlosa = MovCceGlosa + vacio60space.Substring(0, vacio60space.Length - MovCceGlosa.Length);
                    det.CabOpeNumero = vacio9ceros.Substring(0, vacio9ceros.Length - contadorFactura.ToString().Length) + contadorFactura.ToString();
                    contadorregisto = contadorregisto + 1;
                    det.CabOpeLinea = vacio9ceros.Substring(0, vacio9ceros.Length - contadorregisto.ToString().Length) + contadorregisto.ToString();

                    ctacod = reader["id_cuenta_contable_nueva"].ToString();
                    det.CtaCodigo = vacio9ceros.Substring(0, vacio9ceros.Length - ctacod.Length) + ctacod;
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

                    rutCliente = reader["rut_cliente"].ToString();//reader["referencia_cliente"].ToString() + "-" + reader["digito_verificador"].ToString();

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
                        det.MovCceMontoLocalHaber = vacio18ceros.Substring(0, vacio18ceros.Length - resulExpo.Length) + resulExpo;
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

                    if (id_tipoelectro == "2" && Convert.ToDouble(reader["valor_flete"].ToString()) > 0)
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
                    detalles.CabOpeGlosa = MovCceGlosa + vacio60space.Substring(0, vacio60space.Length - MovCceGlosa.Length);
                    detalles.CabOpeNumero = vacio9ceros.Substring(0, vacio9ceros.Length - contadorFactura.ToString().Length) + contadorFactura.ToString();//numerosegun cantidad factura
                    contadorregisto = contadorregisto + 1;
                    detalles.CabOpeLinea = vacio9ceros.Substring(0, vacio9ceros.Length - contadorregisto.ToString().Length) + contadorregisto.ToString();

                    ctacod = "220301";
                    detalles.CtaCodigo = vacio9ceros.Substring(0, vacio9ceros.Length - ctacod.Length) + ctacod;
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
                    string cuotas ="1,"+ Fecha.ToString("yyyy/MM/dd"); //*cambio aquiiiii*Condicion_venta(Convert.ToDateTime(detalles.CabOpeFecha), Condicion_ventas_values);
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
                            detalles2.MovCceMontoLocalDebe = vacio18ceros.Substring(0, vacio18ceros.Length - resultDolart.Length) + resultDolart;//new
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

            /*DESCOMENTAR AL MOMENTO DE SALIR A PRODUCCION*/

            //Conexion con = new Conexion();
            //SqlCommand cmd = con.AbrirConexionDataP2B2000();
            //if (cmd != null)
            //{
            //    cmd.CommandText = "update documentos_mercantil set referencia_estado_documento=8 " +
            //                      " where fecha_emision between '" + FechaInicio + "' and '" + FechaTermino + "' " +
            //                      " and referencia_estado_documento in(7,5)" +
            //                       " and id_documento_mercantil  in (" + idFactura + ")";
            //    cmd.ExecuteNonQuery();
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            //con.CerrarConexion();
            return false;
        }
    }
}