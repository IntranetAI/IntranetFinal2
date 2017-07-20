using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloFacturacion.Model;

namespace Intranet.ModuloFacturacion.Controller
{
    public class Controller_Facturacion
    {
        public int CorreoFacturacionAutomatica(string Usuario, DateTime Fecha, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Facturacion_CorreoFacturacionAutomatica";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                }
            }
            catch
            {
            }
            conexion.CerrarConexion();
            return respuesta;
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

        #region CargarQueryInsertFacturaAl2012
        public string SincronizadorFacturas(int IDFactura, int TipoDoc, string CodigoRazon, string Usuario, string OC, string FechaOC)
        {
            string Insertquery = "";
            Insertquery = ListInsertFactura(IDFactura, TipoDoc, CodigoRazon, Usuario, OC, FechaOC);
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            string retorno = "";
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = Insertquery;
                    cmd.ExecuteNonQuery();
                    retorno = "OK";
                }
                catch (Exception e)
                {
                    retorno = "--Error" + e.Message.Replace("'", "´");
                }
            }
            con.CerrarConexion();
            return retorno;
        }

        public string ListInsertFactura(int IDFactura, int TipoDoc, string CodigoRazon, string Usuario, string OrdenCompra, string fechaOC)
        {
            string query = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "select referencia_tipo_documento,ID_FOLIO_FACTURA,TIPODOC = 	CASE referencia_tipo_documento  " +
                                        "WHEN 1 THEN 33   " +
                                        "WHEN 2 THEN 33   " +
                                        "WHEN 3 THEN 34  " +
                                        "WHEN 4 THEN 61  " +
                                        "WHEN 5 THEN 61  " +
                                        "WHEN 6 THEN 61  " +
                                        "WHEN 7 THEN 56  " +
                                        "WHEN 8 THEN 56  " +
                                        "WHEN 9 THEN 0  " +
                                        "ELSE 0  " +
                                        "END  " +
                                        ",VALOREXENTA = CASE referencia_tipo_documento  " +
                                        "WHEN 3 THEN VALOR_TOTAL  " +
                                        "ELSE 0  " +
                                        "END  " +
                                        ",TASA_IVA = case referencia_tipo_documento  " +
                                        "when 3 then NULL  " +
                                        "else 19.00 end  " +
                                        ",FECHA_EMISION,' ' as FECHA_VENCIMIENTO ,rut_cliente as RUT_CLIENTE ,x.digito_verificador as DV_CLIENTE ,nombre_cliente as NOMBRE_CLIENTE ,  " +
                                        "giro as GIRO_CLIENTE, CASE " +
                                        "WHEN r.referencia_sucursal =0 THEN y.calle " +
                                        "ELSE (SELECT b.calle " +
                                        "FROM empresas ,sucursales l, " +
                                        "entidades_direccion, direcciones b  " +
                                        "where referencia_empresa = rut_empresa " +
                                        "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                        "and referencia_direccion=id_direccion " +
                                        "and r.referencia_sucursal=id_sucursal " +
                                        "group by b.calle ) " +
                                        "END AS DIR_CLIENTE,CASE " +
                                        "WHEN r.referencia_sucursal =0 THEN p.nombre_comuna " +
                                        "ELSE (SELECT h.nombre_comuna " +
                                        "FROM empresas ,sucursales l, " +
                                        "entidades_direccion, direcciones b,comunas h, " +
                                        "ciudades a,  " +
                                        "paises c  " +
                                        "where referencia_empresa = rut_empresa " +
                                        "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                        "and referencia_direccion=id_direccion " +
                                        "and r.referencia_sucursal=id_sucursal " +
                                        "and referencia_comuna=h.id_comuna " +
                                        "and b.referencia_ciudad=a.id_ciudad " +
                                        "and b.referencia_pais=id_pais " +
                                        "group by h.nombre_comuna) " +
                                        "END AS COMUNA_CLIENTE,  " +
                                        "CASE " +
                                        "WHEN r.referencia_sucursal =0 THEN b.nombre_ciudad " +
                                        "ELSE (SELECT a.nombre_ciudad " +
                                        "FROM empresas ,sucursales l, " +
                                        "entidades_direccion, direcciones b,comunas h, " +
                                        "ciudades a, " +
                                        "paises c  " +
                                        "where referencia_empresa = rut_empresa " +
                                        "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                        "and referencia_direccion=id_direccion " +
                                        "and r.referencia_sucursal=id_sucursal " +
                                        "and referencia_comuna=h.id_comuna " +
                                        "and b.referencia_ciudad=a.id_ciudad " +
                                        "and b.referencia_pais=id_pais " +
                                        "group by a.nombre_ciudad) " +
                                        "END AS CIUDAD_CLIENTE, CASE  " +
                                        "WHEN r.referencia_sucursal =0 THEN w.nombre_pais " +
                                        "ELSE (SELECT c.nombre_pais " +
                                        "FROM empresas ,sucursales l, " +
                                        "entidades_direccion, direcciones b,comunas h, " +
                                        "ciudades a,  " +
                                        "paises c  " +
                                        "where referencia_empresa = rut_empresa " +
                                        "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                        "and referencia_direccion=id_direccion " +
                                        "and r.referencia_sucursal=id_sucursal " +
                                        "and referencia_comuna=h.id_comuna " +
                                        "and b.referencia_ciudad=a.id_ciudad " +
                                        "and b.referencia_pais=id_pais " +
                                        "group by c.nombre_pais) " +
                                        "END AS PAIS_CLIENTE   " +
                                        ", VALOR_NETO = case referencia_tipo_documento    " +
                                        "when 3 then NULL  " +
                                        "else round(Convert(float,VALOR_NETO),0) end   " +
                                        ",VALOR_IVA = case referencia_tipo_documento  " +
                                        "when 3 then NULL  " +
                                        "else round(Convert(float,VALOR_IVA),0) end   " +
                                        ", round(Convert(float,VALOR_TOTAL),0) AS VALOR_TOTAL," + CodigoRazon + " AS CODIGO_RAZON,  " +
                                        "guias_despacho AS GUIAS,CASE  " +
                                        "WHEN r.referencia_sucursal =0 THEN 'Sin Sucursal'" +
                                        "ELSE (SELECT Nombre_sucursal " +
                                        "FROM empresas ,sucursales l, " +
                                        "entidades_direccion, direcciones b  " +
                                        "where referencia_empresa = rut_empresa " +
                                        "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                        "and referencia_direccion=id_direccion " +
                                        "and r.referencia_sucursal=id_sucursal " +
                                        "group by Nombre_sucursal) " +
                                        "END AS SUCURSAL,k.nombre_persona +' '+ k.apellido_paterno AS VENDEDOR,q.nombre_condicion_venta AS COND_VENTA,HES, " +
                                        "CONVERT(VARCHAR(10),FECHA_HES,120) FECHA_HES    from documentos_mercantil r,clientesQW_view x,entidades_direccion m,direcciones y,paises w,comunas p,ciudades b,productos_documentos_mercantil t, " +
                                        "personas k,clientes_sucursal_view h ,condiciones_venta q " +
                                        "WHERE ID_FOLIO_FACTURA= " + IDFactura + " and referencia_tipo_documento = " + TipoDoc +
                                        " and fecha_emision >='20150101' " +
                                        "and rut_cliente=referencia_cliente " +
                                        "and r.referencia_condicion_venta=q.id_condicion_venta " +
                                        "and x.id_entidad_direccion=m.id_entidad_direccion " +
                                        "and referencia_direccion=y.id_direccion " +
                                        "and referencia_comuna=p.id_comuna " +
                                        "and y.referencia_ciudad=b.id_ciudad " +
                                        "and referencia_pais=id_pais " +
                                        "and t.referencia_documento_mercantil=id_documento_mercantil " +
                                        "and referencia_vendedor=k.rut_persona " +
                                        "and h.id_direccion=y.id_direccion " +
                                        "group by referencia_tipo_documento,ID_FOLIO_FACTURA,FECHA_EMISION,rut_cliente ,x.digito_verificador ,nombre_cliente ,giro, y.calle ,p.nombre_comuna, " +
                                        "b.nombre_ciudad , w.nombre_pais , VALOR_NETO , VALOR_IVA , VALOR_TOTAL , " +
                                        "guias_despacho ,h.nombre_sucursal ,k.nombre_persona +' '+ k.apellido_paterno ,q.nombre_condicion_venta ,HES,FECHA_HES,r.referencia_sucursal";
                    SqlDataReader reader = cmd.ExecuteReader();
                    int contadorDocuRefe = 0;
                    while (reader.Read())
                    {
                        string VALOR_NETO = "";
                        if (reader["VALOR_NETO"].ToString() == "") { VALOR_NETO = "null"; }
                        else { VALOR_NETO = reader["VALOR_NETO"].ToString(); }

                        string TASA_IVA = "";
                        if (reader["TASA_IVA"].ToString() == "") { TASA_IVA = "null"; }
                        else { TASA_IVA = reader["TASA_IVA"].ToString(); }

                        string VALOR_IVA = "";
                        if (reader["VALOR_IVA"].ToString() == "") { VALOR_IVA = "null"; }
                        else { VALOR_IVA = reader["VALOR_IVA"].ToString(); }

                        string DIR_CLIENTE = "";
                        if (reader["DIR_CLIENTE"].ToString() == "") { DIR_CLIENTE = "null"; }
                        else { DIR_CLIENTE = reader["DIR_CLIENTE"].ToString().Replace("'", string.Empty); }

                        string FECHA_EMISION = "";
                        if (reader["FECHA_EMISION"].ToString() == "") { FECHA_EMISION = "null"; }
                        else { FECHA_EMISION = Convert.ToDateTime(reader["FECHA_EMISION"].ToString()).ToString("yyyy-MM-dd"); }

                        string FECHA_HES = "";
                        if (reader["FECHA_HES"].ToString() == "") { FECHA_HES = "null"; }
                        else { FECHA_HES = Convert.ToDateTime(reader["FECHA_HES"].ToString()).ToString("yyyy-MM-dd"); }

                        string RUT_Cliente = "";
                        string DVCliente = "";
                        if (reader["RUT_CLIENTE"].ToString().Trim().Count() > 3) { RUT_Cliente = reader["RUT_CLIENTE"].ToString(); DVCliente = reader["DV_CLIENTE"].ToString(); }
                        else { RUT_Cliente = "55555555"; DVCliente = "5"; }

                        string Sucursal = "";
                        if (reader["SUCURSAL"].ToString().Length >= 20)
                        {
                            Sucursal = reader["SUCURSAL"].ToString().Substring(0, 20);
                        }
                        else
                        {
                            Sucursal = reader["SUCURSAL"].ToString();
                        }

                        query += " insert into Factura_Electronica.dbo.DTE_ENCA_DOCU (VERS_ENCA,ESTA_DOCU,CODI_EMPR,TIPO_DOCU,FOLI_DOCU	,FECH_EMIS,FECH_VENC,RUTT_EMIS,DIGI_EMIS,NOMB_EMIS,GIRO_EMIS,DIRE_ORIG,COMU_ORIG,CIUD_ORIG" +
                                        ",RUTT_RECE,DIGI_RECE,NOMB_RECE,GIRO_RECE,DIRE_RECE,COMU_RECE,CIUD_RECE,MONT_NETO,MONT_EXEN,TASA_VAAG,IMPU_VAAG,MONT_TOTA,VAL2,VAL1,NOMB_SUCU,VAL3,VAL4) values ('1.0','INI',1," +
                                        reader["TIPODOC"] + "," + reader["ID_FOLIO_FACTURA"] + ",'" + FECHA_EMISION + "',' ',96830710,'K','A Impresores S.A.','Imprenta Encuadernación y Exportación de Impresos'," +
                                        "'Av. Gladys Marin 6920','Estacion Central','Santiago'," + RUT_Cliente + ",'" + DVCliente + "','" + reader["NOMBRE_CLIENTE"].ToString().Replace("'", "") + "','" + reader["GIRO_CLIENTE"] + "','" + DIR_CLIENTE + "','" +
                                        reader["COMUNA_CLIENTE"] + "','" + reader["CIUDAD_CLIENTE"] + "'," + Convert.ToDouble(VALOR_NETO).ToString("N0").Replace(",", string.Empty) + "," + Convert.ToDouble(reader["VALOREXENTA"]).ToString("N0").Replace(",", string.Empty) + "," + Convert.ToDouble(TASA_IVA).ToString("N0").Replace(",", string.Empty) + "," + Convert.ToDouble(VALOR_IVA).ToString("N0").Replace(",", string.Empty) + "," + Convert.ToDouble(reader["VALOR_TOTAL"]).ToString("N0").Replace(",", string.Empty) + ",'" + reader["GUIAS"] + "','" + reader["PAIS_CLIENTE"] + "','" +
                                        Sucursal + "','" + reader["VENDEDOR"] + "','" + reader["COND_VENTA"] + "');";
                        query += " insert into Factura_Electronica.dbo.DTE_DETA_ACEC (TIPO_DOCU,FOLI_DOCU,CODI_ACEC,CODI_EMPR,CORR_ACEC) values (" + reader["TIPODOC"] + "," + reader["ID_FOLIO_FACTURA"] + ",'222101',1,1);";
                        if ((reader["HES"].ToString().Length > 0) && (reader["referencia_tipo_documento"].ToString() == "1"))
                        {
                            contadorDocuRefe++;
                            query += " INSERT INTO Factura_Electronica.dbo.DTE_DOCU_REFE(CODI_EMPR,TIPO_DOCU,FOLI_DOCU,NUME_REFE,TIPO_REFE,FOLI_REFE,FECH_REFE) VALUES (1," + reader["TIPODOC"] + "," + reader["ID_FOLIO_FACTURA"] +
                                ",1,801,'" + reader["HES"] + "','" + FECHA_HES + "');";
                        }
                        if ((reader["TIPODOC"].ToString() == "61") || (reader["TIPODOC"].ToString() == "56"))
                        {
                            string Mensaje = "Anula";
                            if (reader["CODIGO_RAZON"].ToString() == "1") { Mensaje = "Anula"; }
                            if (reader["CODIGO_RAZON"].ToString() == "2") { Mensaje = "Corrige Texto"; }
                            if (reader["CODIGO_RAZON"].ToString() == "3") { Mensaje = "Corrige Monto"; }

                            query += CursorDTE_DOCU_REFE(reader["TIPODOC"].ToString(), reader["referencia_tipo_documento"].ToString(), reader["ID_FOLIO_FACTURA"].ToString(), reader["CODIGO_RAZON"].ToString(), Mensaje);
                        }
                        query += DetalleFacturaElec(reader["ID_FOLIO_FACTURA"].ToString(), reader["referencia_tipo_documento"].ToString());

                        if (OrdenCompra != "" && fechaOC != "")
                        {
                            string[] str = fechaOC.Split('/');
                            contadorDocuRefe++;
                            int NumOrdenRef = contadorDocuRefe;
                            query += " INSERT INTO Factura_Electronica.dbo.DTE_DOCU_REFE(CODI_EMPR,TIPO_DOCU,FOLI_DOCU,NUME_REFE,TIPO_REFE,FOLI_REFE,FECH_REFE) VALUES (1," + reader["TIPODOC"] + "," + reader["ID_FOLIO_FACTURA"] +
                                    "," + NumOrdenRef.ToString() + ",801,'" + OrdenCompra + "','" + str[2] + "-" + str[1] + "-" + str[0] + "');";
                        }
                        query += "INSERT INTO[Intranet2].dbo.[Factura_Elec_RegSII]([NFactura],[IDTipoDocumento],[TipoDocumento],[CodEmpresa],[FechaEnvio], [Usuario])" +
                                    "VALUES(" + reader["ID_FOLIO_FACTURA"] + "," + reader["TIPODOC"] + ",'',1,GETDATE(),'" + Usuario + "');update Factura_Elec_RegSII set TipoDocumento = " +
                                    " case IDTipoDocumento when 33 then 'Factura Electronica'  when 34 then 'Factura Exenta' when 61 then 'Nota Crédito' when 56 then 'Nota Débito' else 'Sin definir' end ;";

                    }

                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return query;
        }

        public string CursorDTE_DOCU_REFE(string TipodeDocumento, string ID_TIPO_DOCUMENTO, string ID_FOLIO_FACTURA, string CodigoRazon, string Mensaje)
        {
            string query = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "SELECT D2.REFERENCIA_TIPO_DOCUMENTO,D2.ID_FOLIO_FACTURA,CONVERT(VARCHAR(10),D2.FECHA_EMISION,120) FECHA_EMISION, TIPOASOC =  CASE D2.REFERENCIA_TIPO_DOCUMENTO " +
                                                        "WHEN 1 THEN 33 " +
                                                        "WHEN 2 THEN 33 " +
                                                        "WHEN 3 THEN 34 " +
                                                        "WHEN 4 THEN 61 " +
                                                        "WHEN 5 THEN 61 " +
                                                        "WHEN 6 THEN 61 " +
                                                        "WHEN 7 THEN 56 " +
                                                        "WHEN 8 THEN 56 " +
                                                        "WHEN 9 THEN 0 " +
                                                        "ELSE 0 end" +
                                        " FROM DOCUMENTOS_ASOCIADOS DA " +
                                        ",DOCUMENTOS_MERCANTIL D1 ,DOCUMENTOS_MERCANTIL D2 WHERE DA.REFERENCIA_DOCUMENTO_MERCANTIL=D1.ID_DOCUMENTO_MERCANTIL " +
                                        "AND D2.ID_DOCUMENTO_MERCANTIL=DA.REFERENCIA_DOCUMENTO_ASOCIADO AND D1.ID_FOLIO_FACTURA = " + ID_FOLIO_FACTURA +
                                        " AND D1.REFERENCIA_TIPO_DOCUMENTO = " + ID_TIPO_DOCUMENTO + ";";
                    SqlDataReader reader = cmd.ExecuteReader();
                    int contador = 1;

                    while (reader.Read())
                    {

                        string FECHA_EMISION = "";
                        if (reader["FECHA_EMISION"].ToString() == "") { FECHA_EMISION = "null"; }
                        else { FECHA_EMISION = Convert.ToDateTime(reader["FECHA_EMISION"].ToString()).ToString("yyyy-MM-dd"); }

                        query = query + " INSERT INTO Factura_Electronica.dbo.DTE_DOCU_REFE(CODI_EMPR,TIPO_DOCU,FOLI_DOCU,NUME_REFE,TIPO_REFE,FOLI_REFE,FECH_REFE,CODI_REFE,RAZO_REFE)" +
                                        "VALUES (1," + TipodeDocumento + "," + ID_FOLIO_FACTURA
                                        + "," + contador + "," + reader["TIPOASOC"] + "," + reader["ID_FOLIO_FACTURA"] + ",'" +
                                        FECHA_EMISION + "'," + CodigoRazon + ",'" + Mensaje + "');";
                        contador++;
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return query;
        }

        public string DetalleFacturaElec(string id_folio_factura, string TipoDoc)
        {
            string query = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                try
                {
                    string whereCantidadCero = "";
                    if (Convert.ToInt32(TipoDoc) < 4 || Convert.ToInt32(TipoDoc) > 8)
                    {
                        //whereCantidadCero = "and convert (numeric(18,0),( cantidad * valor_producto))>0 ";
                    }
                    cmd.CommandText = "SELECT CASE " +
                                        "WHEN referencia_tipo_documento =1 THEN 33 " +
                                        "WHEN referencia_tipo_documento =2 THEN 33 " +
                                        "WHEN referencia_tipo_documento=3 THEN 34 " +
                                        "WHEN referencia_tipo_documento= 4 THEN 61 " +
                                        "WHEN referencia_tipo_documento= 5 THEN 61 " +
                                        "WHEN referencia_tipo_documento=6 THEN 61 " +
                                        "WHEN referencia_tipo_documento=7 THEN 56 " +
                                        "WHEN referencia_tipo_documento=8 THEN 56 " +
                                        "WHEN referencia_tipo_documento=9 THEN 0 " +
                                        "ELSE 0 " +
                                        "END AS id_tipo_documento " +
                                        ",IndExen = 	CASE referencia_tipo_documento " +
                                        "WHEN 3 THEN 1 " +
                                        "WHEN 6 THEN 1 " +
                                        "ELSE 0 " +
                                        "END " +
                                        ",id_folio_factura, ' ' as Correlativo,nombre_producto,cantidad,valor_producto,convert (numeric(18,0),( cantidad * valor_producto)) neto_Item,glosa,id_folio_prefactura, referencia_ot " +
                                        "FROM documentos_mercantil, productos_documentos_mercantil,productos " +
                                        "where referencia_documento_mercantil=id_documento_mercantil " +
                                        whereCantidadCero +
                                        "and id_folio_factura= " + id_folio_factura + " and referencia_tipo_documento =" + TipoDoc +
                                        " and referencia_producto=id_producto and es_electronico=1";
                    SqlDataReader reader = cmd.ExecuteReader();
                    int contadorEspacios = 0;
                    int contador = 0;
                    string Glosa = "";
                    while (reader.Read())
                    {
                        if (contadorEspacios >= 1)
                        {
                            contador++;
                            query = query + " INSERT INTO Factura_Electronica.dbo.DTE_DETA_PRSE(CODI_EMPR,TIPO_DOCU,FOLI_DOCU,NUME_LINE,INDI_EXEN,NOMB_ITEM,CANT_ITEM,PREC_ITEM,NETO_ITEM,DESC_ITEM)" +
                                        " VALUES(1," + reader["id_tipo_documento"] + "," + id_folio_factura
                                        + "," + contador + ",0,'.',0,0,0,'');";

                        }
                        contador++;
                        query = query + " INSERT INTO Factura_Electronica.dbo.DTE_DETA_PRSE(CODI_EMPR,TIPO_DOCU,FOLI_DOCU,NUME_LINE,INDI_EXEN,NOMB_ITEM,CANT_ITEM,PREC_ITEM,NETO_ITEM,DESC_ITEM)" +
                                        " VALUES(1," + reader["id_tipo_documento"] + "," + id_folio_factura
                                        + "," + contador + ",'" + reader["IndExen"] + "','" + reader["nombre_producto"] + " (N°OT " + reader["referencia_ot"] + ")'," +
                                        reader["cantidad"].ToString().Replace(",",".") + "," + reader["valor_producto"].ToString().Replace(",", ".") + "," + reader["neto_Item"] + ",'');";
                        contadorEspacios++;
                        Glosa = reader["glosa"].ToString();
                        if (Glosa != "")
                        {
                            string[] str = Glosa.Trim().Split('\r');
                            contador++;
                            query = query + " INSERT INTO Factura_Electronica.dbo.DTE_DETA_PRSE(CODI_EMPR,TIPO_DOCU,FOLI_DOCU,NUME_LINE,INDI_EXEN,NOMB_ITEM,CANT_ITEM,PREC_ITEM,NETO_ITEM,DESC_ITEM)" +
                                            " VALUES(1," + reader["id_tipo_documento"] + "," + id_folio_factura + "," + contador + ",0,'.',0,0,0,'');";

                            int contadorGlosa = 0;
                            foreach (string x in str)
                            {
                                if (contadorGlosa >= 1)
                                {
                                    contador++;
                                    query = query + " INSERT INTO Factura_Electronica.dbo.DTE_DETA_PRSE(CODI_EMPR,TIPO_DOCU,FOLI_DOCU,NUME_LINE,INDI_EXEN,NOMB_ITEM,CANT_ITEM,PREC_ITEM,NETO_ITEM,DESC_ITEM)" +
                                                " VALUES(1," + reader["id_tipo_documento"] + "," + id_folio_factura + "," + contador + ",0,'" + x.Substring(1, x.Length - 1) + "',0,0,0,'');";
                                }
                                else
                                {
                                    if (x != "")
                                    {
                                        contador++;
                                        query = query + " INSERT INTO Factura_Electronica.dbo.DTE_DETA_PRSE(CODI_EMPR,TIPO_DOCU,FOLI_DOCU,NUME_LINE,INDI_EXEN,NOMB_ITEM,CANT_ITEM,PREC_ITEM,NETO_ITEM,DESC_ITEM)" +
                                                    " VALUES(1," + reader["id_tipo_documento"] + "," + id_folio_factura + "," + contador + ",0,'" + x + "',0,0,0,'');";
                                    }
                                }
                                contadorGlosa++;
                            }
                        }
                    }
                }
                catch
                {
                    query = query + "";
                }
            }
            con.CerrarConexion();
            return query;
        }

        #endregion

        public List<Facturacion_ElectronicaSII> listarFacturasPendientes()
        {
            List<Facturacion_ElectronicaSII> lista = new List<Facturacion_ElectronicaSII>();
            List<Facturacion_ElectronicaSII> lista2012 = listarFacturasSII();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "select referencia_tipo_documento,ID_FOLIO_FACTURA,TIPODOC = 	CASE referencia_tipo_documento " +
                                       " WHEN 1 THEN 33  " +
                                       " WHEN 2 THEN 33  " +
                                       " WHEN 3 THEN 34  " +
                                       " WHEN 4 THEN 61  " +
                                       " WHEN 5 THEN 61  " +
                                       " WHEN 6 THEN 61  " +
                                       " WHEN 7 THEN 56  " +
                                       " WHEN 8 THEN 56  " +
                                       " WHEN 9 THEN 0  " +
                                       " ELSE 0  " +
                                       " END  " +
                                       " ,TipoDocumento = case referencia_tipo_documento when 1 then 'Factura Electronica' when 2 then 'Factura Electronica' when 3 then 'Factura Exenta' when 4 then 'Nota Crédito' when 5 then 'Nota Crédito' " +
                                       " when 6 then 'Nota Crédito' when 7 then 'Nota Débito' when 8 then 'Nota Débito' when 9 then 'Sin definir' else 'Sin definir' end " +
                                       " ,FECHA_EMISION,rut_cliente as RUT_CLIENTE ,digito_verificador as DV_CLIENTE ,nombre_cliente as NOMBRE_CLIENTE ,  " +
                                       " VALOR_NETO = case referencia_tipo_documento   " +
                                       " when 3 then NULL  " +
                                       " else VALOR_NETO end " +
                                       " ,VALOR_IVA = case referencia_tipo_documento  " +
                                       " when 3 then NULL  " +
                                       " else VALOR_IVA end  " +
                                       " , VALOR_TOTAL AS VALOR_TOTAL,nombre_condicion_venta AS COND_VENTA  " +
                                       " from documentos_mercantil,clientesQW_view x,entidades_direccion m,direcciones y,paises,comunas p,ciudades b  " +
                                       " WHERE   " +
                                       " rut_cliente=referencia_cliente  " +
                                       " and x.id_entidad_direccion=m.id_entidad_direccion  " +
                                       " and referencia_direccion=y.id_direccion  " +
                                       " and referencia_comuna=p.id_comuna " +
                                       " and y.referencia_ciudad=b.id_ciudad  and documentos_mercantil.referencia_estado_documento in (5,7)  " +
                                       " and referencia_pais=id_pais and 26223!=ID_FOLIO_FACTURA  " +
                                       " and es_electronico= 1 and FECHA_EMISION>= '2014-01-01' ";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Facturacion_ElectronicaSII sincro = new Facturacion_ElectronicaSII();

                        sincro.Nfactura = reader["ID_FOLIO_FACTURA"].ToString();//ID_FOLIO_FACTURA
                        sincro.TipoDocumento = reader["TipoDocumento"].ToString();//TipoDocumento
                        sincro.IDTipoDocumento = reader["referencia_tipo_documento"].ToString();
                        if (reader["FECHA_EMISION"].ToString() != "")
                        {
                            sincro.Fecha_Creacion = Convert.ToDateTime(reader["FECHA_EMISION"].ToString()).ToString("dd-MM-yyyy");//FECHA_EMISION
                        }
                        sincro.RutCliente = reader["rut_cliente"].ToString() + "-" + reader["DV_CLIENTE"].ToString();//rut_cliente
                        sincro.Nombre_Cliente = reader["NOMBRE_CLIENTE"].ToString();//NOMBRE_CLIENTE
                        sincro.Valor_Neto = reader["VALOR_NETO"].ToString();
                        sincro.Valor_Iva = reader["VALOR_IVA"].ToString();//VALOR_IVA
                        sincro.Valor_total = reader["VALOR_TOTAL"].ToString();//VALOR_TOTAL
                        sincro.CondicionVenta = reader["COND_VENTA"].ToString();//COND_VENTA
                        sincro.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:OpenFactura(\"" + sincro.Nfactura + "\",\"" + sincro.IDTipoDocumento + "\")'>Ver Más</a>";
                        int contador = 0;
                        foreach (Facturacion_ElectronicaSII fac in lista2012.Where(o => o.Nfactura == sincro.Nfactura && o.IDTipoDocumento == reader["TIPODOC"].ToString() && o.Ciudad == "1"))
                        {
                            contador++;
                        }
                        if (contador == 0)
                        {
                            lista.Add(sincro);
                        }
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Facturacion_ElectronicaSII> listarFacturasSII()
        {
            List<Facturacion_ElectronicaSII> lista = new List<Facturacion_ElectronicaSII>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Factura_Elec_ListRegSII";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Facturacion_ElectronicaSII fac = new Facturacion_ElectronicaSII();
                        fac.Ciudad = reader["CodEmpresa"].ToString();
                        fac.Nfactura = reader["NFactura"].ToString();
                        fac.IDTipoDocumento = reader["IDTipoDocumento"].ToString();
                        lista.Add(fac);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public Facturacion_ElectronicaSII BuscarCabFacturaDetallada(int IDfactura, int TipoDoc)
        {
            Facturacion_ElectronicaSII factura = new Facturacion_ElectronicaSII();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "select referencia_tipo_documento,ID_FOLIO_FACTURA,TIPODOC = 	CASE referencia_tipo_documento  " +
                                            "WHEN 1 THEN 33   " +
                                            "WHEN 2 THEN 33   " +
                                            "WHEN 3 THEN 34  " +
                                            "WHEN 4 THEN 61  " +
                                            "WHEN 5 THEN 61  " +
                                            "WHEN 6 THEN 61  " +
                                            "WHEN 7 THEN 56  " +
                                            "WHEN 8 THEN 56  " +
                                            "WHEN 9 THEN 0  " +
                                            "ELSE 0  " +
                                            "END  " +
                                            ",VALOREXENTA = CASE referencia_tipo_documento  " +
                                            "WHEN 3 THEN VALOR_TOTAL  " +
                                            "ELSE 0  " +
                                            "END  " +
                                            ",TASA_IVA = case referencia_tipo_documento  " +
                                            "when 3 then NULL  " +
                                            "else 19.00 end  " +
                                            ",FECHA_EMISION,' ' as FECHA_VENCIMIENTO ,rut_cliente as RUT_CLIENTE ,x.digito_verificador as DV_CLIENTE ,nombre_cliente as NOMBRE_CLIENTE ,  " +
                                            "giro as GIRO_CLIENTE, CASE " +
                                            "WHEN r.referencia_sucursal =0 THEN y.calle " +
                                            "ELSE (SELECT b.calle " +
                                            "FROM empresas ,sucursales l, " +
                                            "entidades_direccion, direcciones b  " +
                                            "where referencia_empresa = rut_empresa " +
                                            "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                            "and referencia_direccion=id_direccion " +
                                            "and r.referencia_sucursal=id_sucursal " +
                                            "group by b.calle ) " +
                                            "END AS DIR_CLIENTE,CASE " +
                                            "WHEN r.referencia_sucursal =0 THEN p.nombre_comuna " +
                                            "ELSE (SELECT h.nombre_comuna " +
                                            "FROM empresas ,sucursales l, " +
                                            "entidades_direccion, direcciones b,comunas h, " +
                                            "ciudades a,  " +
                                            "paises c  " +
                                            "where referencia_empresa = rut_empresa " +
                                            "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                            "and referencia_direccion=id_direccion " +
                                            "and r.referencia_sucursal=id_sucursal " +
                                            "and referencia_comuna=h.id_comuna " +
                                            "and b.referencia_ciudad=a.id_ciudad " +
                                            "and b.referencia_pais=id_pais " +
                                            "group by h.nombre_comuna) " +
                                            "END AS COMUNA_CLIENTE,  " +
                                            "CASE " +
                                            "WHEN r.referencia_sucursal =0 THEN b.nombre_ciudad " +
                                            "ELSE (SELECT a.nombre_ciudad " +
                                            "FROM empresas ,sucursales l, " +
                                            "entidades_direccion, direcciones b,comunas h, " +
                                            "ciudades a, " +
                                            "paises c  " +
                                            "where referencia_empresa = rut_empresa " +
                                            "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                            "and referencia_direccion=id_direccion " +
                                            "and r.referencia_sucursal=id_sucursal " +
                                            "and referencia_comuna=h.id_comuna " +
                                            "and b.referencia_ciudad=a.id_ciudad " +
                                            "and b.referencia_pais=id_pais " +
                                            "group by a.nombre_ciudad) " +
                                            "END AS CIUDAD_CLIENTE, CASE  " +
                                            "WHEN r.referencia_sucursal =0 THEN w.nombre_pais " +
                                            "ELSE (SELECT c.nombre_pais " +
                                            "FROM empresas ,sucursales l, " +
                                            "entidades_direccion, direcciones b,comunas h, " +
                                            "ciudades a,  " +
                                            "paises c  " +
                                            "where referencia_empresa = rut_empresa " +
                                            "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                            "and referencia_direccion=id_direccion " +
                                            "and r.referencia_sucursal=id_sucursal " +
                                            "and referencia_comuna=h.id_comuna " +
                                            "and b.referencia_ciudad=a.id_ciudad " +
                                            "and b.referencia_pais=id_pais " +
                                            "group by c.nombre_pais) " +
                                            "END AS PAIS_CLIENTE   " +
                                            ", VALOR_NETO = case referencia_tipo_documento    " +
                                            "when 3 then NULL  " +
                                            "else round(Convert(float,VALOR_NETO),0) end   " +
                                            ",VALOR_IVA = case referencia_tipo_documento  " +
                                            "when 3 then NULL  " +
                                            "else round(Convert(float,VALOR_IVA),0) end   " +
                                            ", round(Convert(float,VALOR_TOTAL),0) AS VALOR_TOTAL,' ' AS CODIGO_RAZON,  " +
                                            "guias_despacho AS GUIAS,CASE  " +
                                            "WHEN r.referencia_sucursal =0 THEN 'Sin Sucursal'" +
                                            "ELSE (SELECT Nombre_sucursal " +
                                            "FROM empresas ,sucursales l, " +
                                            "entidades_direccion, direcciones b  " +
                                            "where referencia_empresa = rut_empresa " +
                                            "and l.referencia_entidad_direccion=id_entidad_direccion " +
                                            "and referencia_direccion=id_direccion " +
                                            "and r.referencia_sucursal=id_sucursal " +
                                            "group by Nombre_sucursal) " +
                                            "END AS SUCURSAL,k.nombre_persona +' '+ k.apellido_paterno AS VENDEDOR,q.nombre_condicion_venta AS COND_VENTA,HES, " +
                                            "CONVERT(VARCHAR(10),FECHA_HES,120) FECHA_HES    from documentos_mercantil r,clientesQW_view x,entidades_direccion m,direcciones y,paises w,comunas p,ciudades b,productos_documentos_mercantil t, " +
                                            "personas k,clientes_sucursal_view h ,condiciones_venta q " +
                                            "WHERE ID_FOLIO_FACTURA= " + IDfactura + " and referencia_tipo_documento = " + TipoDoc +
                                            " and fecha_emision >='20140101' " +
                                            "and rut_cliente=referencia_cliente " +
                                            "and r.referencia_condicion_venta=q.id_condicion_venta " +
                                            "and x.id_entidad_direccion=m.id_entidad_direccion " +
                                            "and referencia_direccion=y.id_direccion " +
                                            "and referencia_comuna=p.id_comuna " +
                                            "and y.referencia_ciudad=b.id_ciudad " +
                                            "and referencia_pais=id_pais " +
                                            "and t.referencia_documento_mercantil=id_documento_mercantil " +
                                            "and referencia_vendedor=k.rut_persona " +
                                            "and h.id_direccion=y.id_direccion " +
                                            "group by referencia_tipo_documento,ID_FOLIO_FACTURA,FECHA_EMISION,rut_cliente ,x.digito_verificador ,nombre_cliente ,giro, y.calle ,p.nombre_comuna, " +
                                            "b.nombre_ciudad , w.nombre_pais , VALOR_NETO , VALOR_IVA , VALOR_TOTAL , " +
                                            "guias_despacho ,h.nombre_sucursal ,k.nombre_persona +' '+ k.apellido_paterno ,q.nombre_condicion_venta ,HES,FECHA_HES,r.referencia_sucursal";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["RUT_CLIENTE"].ToString().Trim().Count() > 3)
                        {
                            factura.RutCliente = reader["RUT_CLIENTE"].ToString() + "-" + reader["DV_CLIENTE"].ToString();
                        }
                        else
                        {
                            factura.RutCliente = "55.555.555-5";
                        }
                        factura.Nombre_Cliente = reader["NOMBRE_CLIENTE"].ToString();
                        factura.giro = reader["GIRO_CLIENTE"].ToString();
                        factura.Sucursal = reader["SUCURSAL"].ToString();
                        factura.Direccion = reader["DIR_CLIENTE"].ToString();
                        if (reader["FECHA_EMISION"].ToString() != "")
                        {
                            factura.Fecha_Creacion = Convert.ToDateTime(reader["FECHA_EMISION"].ToString()).ToString("dd-MM-yyyy");//FECHA_EMISION
                        }
                        factura.Comuna = reader["COMUNA_CLIENTE"].ToString();
                        factura.Ciudad = reader["CIUDAD_CLIENTE"].ToString();
                        factura.Pais = reader["PAIS_CLIENTE"].ToString();
                        factura.CondicionVenta = reader["COND_VENTA"].ToString();
                        factura.Vendedor = reader["VENDEDOR"].ToString();
                        factura.Guias = reader["GUIAS"].ToString().Trim();
                        factura.Valor_Neto = Convert.ToDouble(reader["VALOR_NETO"].ToString()).ToString("N0").Replace(",", ".");
                        factura.Valor_Iva = Convert.ToDouble(reader["VALOR_IVA"].ToString()).ToString("N0").Replace(",", ".");
                        factura.Valor_total = Convert.ToDouble(reader["VALOR_TOTAL"].ToString()).ToString("N0").Replace(",", ".");
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return factura;
        }

        public List<Facturacion_ElectronicaSII> BuscarDetFacturaDetallada(int IDFactura, int TipoDoc)
        {
            List<Facturacion_ElectronicaSII> lista = new List<Facturacion_ElectronicaSII>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                try
                {
                    string whereCantidadCero = "";
                    if (Convert.ToInt32(TipoDoc) < 4 || Convert.ToInt32(TipoDoc) > 8)
                    {
                        //whereCantidadCero = " and (cantidad*valor_producto)> 0  ";
                    }
                    cmd.CommandText = "select Convert(int,cantidad) cantidad, nombre_producto, referencia_ot, glosa, valor_producto, round(Convert(float,(cantidad*valor_producto)),0) Valor_TotalDet  " +
                                        "	FROM documentos_mercantil, productos_documentos_mercantil,productos " +
                                        "    where referencia_documento_mercantil=id_documento_mercantil " +
                                        whereCantidadCero +
                                        "    and id_folio_factura= " + IDFactura + " and referencia_tipo_documento =" + TipoDoc +
                                        "    and referencia_producto=id_producto and es_electronico=1;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Facturacion_ElectronicaSII detalle = new Facturacion_ElectronicaSII();
                        detalle.Cantidad = Convert.ToDouble(reader["cantidad"].ToString()).ToString("N0").Replace(",", ".");
                        detalle.Descripcion = reader["nombre_producto"].ToString() + "\r N° OT : " + reader["referencia_ot"] + "\r\r" + reader["glosa"].ToString();
                        detalle.ValorUnit = reader["valor_producto"].ToString();
                        detalle.ValorItemTotal = Convert.ToDouble(reader["Valor_TotalDet"].ToString()).ToString("N0").Replace(",", ".");

                        lista.Add(detalle);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string BuscarDetRefencia(int ID_TIPO_DOCUMENTO, int ID_FOLIO_FACTURA)
        {
            string Referencia = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "SELECT D2.REFERENCIA_TIPO_DOCUMENTO,D2.ID_FOLIO_FACTURA,CONVERT(VARCHAR(10),D2.FECHA_EMISION,120) FECHA_EMISION, TIPOASOC =  CASE D2.REFERENCIA_TIPO_DOCUMENTO " +
                                                        "WHEN 1 THEN 'Factura Electronica' " +
                                                        "WHEN 2 THEN 'Factura Electronica' " +
                                                        "WHEN 3 THEN  'Factura Exenta IVA' " +
                                                        "WHEN 4 THEN 'Nota Credito' " +
                                                        "WHEN 5 THEN 'Nota Credito' " +
                                                        "WHEN 6 THEN 'Nota Credito' " +
                                                        "WHEN 7 THEN 'Nota Debito' " +
                                                        "WHEN 8 THEN 'Nota Debito' " +
                                                        "WHEN 9 THEN '' " +
                                                        "ELSE '' end" +
                                        " FROM DOCUMENTOS_ASOCIADOS DA " +
                                        ",DOCUMENTOS_MERCANTIL D1 ,DOCUMENTOS_MERCANTIL D2 WHERE DA.REFERENCIA_DOCUMENTO_MERCANTIL=D1.ID_DOCUMENTO_MERCANTIL " +
                                        "AND D2.ID_DOCUMENTO_MERCANTIL=DA.REFERENCIA_DOCUMENTO_ASOCIADO AND D1.ID_FOLIO_FACTURA = " + ID_FOLIO_FACTURA +
                                        " AND D1.REFERENCIA_TIPO_DOCUMENTO = " + ID_TIPO_DOCUMENTO + ";";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string FECHA_EMISION = "";
                        if (reader["FECHA_EMISION"].ToString() == "") { FECHA_EMISION = "null"; }
                        else { FECHA_EMISION = Convert.ToDateTime(reader["FECHA_EMISION"].ToString()).ToString("dd-MM-yyyy"); }
                        Referencia += "Tipo de Documento " + reader["TIPOASOC"] + " N° Folio = " + reader["ID_FOLIO_FACTURA"].ToString() + " Creada el " + FECHA_EMISION + "<br />";
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return Referencia;
        }

    }
}