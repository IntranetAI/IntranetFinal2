using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;
using Intranet.ModuloAdministracion.Model;

namespace Intranet.ModuloProduccion.Controller
{
    public class SincroController
    {
        public List<SincronizarOT> listaOTSincroOT()
        {
            //string OT = "";
            List<SincronizarOT> lista = new List<SincronizarOT>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_DataP2B();
            if (cmd != null)
            {
                cmd.CommandText = "select QG_RMS_JOB_NBR QG_RMS_JOB_NBR,NM,CTD_TMSTMP,CUST_RUT,CUST_NM,PRN_ORD_QTY,JOB_STS,Fecha_Liquidacion from Data_P2B.dbo.QGPressJob where QG_RMS_JOB_NBR not like 'b%'";// like 9/
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SincronizarOT sincroOT = new SincronizarOT();
                    sincroOT.QG_RMS_JOB_NBR = reader["QG_RMS_JOB_NBR"].ToString().Trim();
                    sincroOT.NM = reader["NM"].ToString();
                    sincroOT.CTD_TMSTMP = reader["CTD_TMSTMP"].ToString();
                    sincroOT.CUST_RUT = reader["CUST_RUT"].ToString();
                    sincroOT.CUST_NM = reader["CUST_NM"].ToString();
                    sincroOT.PRN_ORD_QTY = reader["PRN_ORD_QTY"].ToString();
                    sincroOT.JOB_STS = reader["JOB_STS"].ToString();
                    sincroOT.Fecha_Liquidacion = reader["Fecha_Liquidacion"].ToString();
                    lista.Add(sincroOT);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<SincronizarOT> listaOTSincroMetrics()
        {
            List<SincronizarOT> lista = new List<SincronizarOT>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Sincro_ListOTMetrics";
                                    
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SincronizarOT sincroOT = new SincronizarOT();
                    sincroOT.QG_RMS_JOB_NBR = reader["QG_RMS_JOB_NBR"].ToString().Trim();
                    sincroOT.NM = reader["NM"].ToString().Replace("'","");
                    sincroOT.CTD_TMSTMP = reader["CTD_TMSTMP"].ToString();
                    if (reader["Status_OP"].ToString() == "A")
                    {
                        sincroOT.JOB_STS = "1";
                    }
                    else
                    {
                        sincroOT.JOB_STS = "2";
                    }
                    sincroOT.CUST_RUT = reader["RUT_Cliente"].ToString();
                    sincroOT.CUST_NM = reader["Nome_Cliente"].ToString();
                    sincroOT.QG_RMS_TITLE_CD = "Metric";
                    sincroOT.PRN_ORD_QTY = reader["Tiraje"].ToString();
                    sincroOT.Fecha_Liquidacion = reader["Fecha_Liquidacion"].ToString();
                    lista.Add(sincroOT);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        //NO SE OCUPA EN EL SINCRONIZADOR
        public string OTSincroMetrics(string OT)
        {
            //List<SincronizarOT> lista = new List<SincronizarOT>();
            string query = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "select distinct cast(a.numordem as varchar(7)) QG_RMS_JOB_NBR, cast(a.Descricao as varchar(40)) NM, cast( b.CGC as varchar(24)) RUT_Cliente,cast( b.RazaoSocial as varchar(50)) Nome_Cliente, max(C.DataTermino) CTD_TMSTMP," +
                                    "a.Situacao Status_OP, sum(c.Quantidade) Tiraje from MetricsPROD.dbo.OrdensProducao a join MetricsPROD.dbo.crm_clientes b on (a.CodCliente = b.CodCliente) " +
                                    "join MetricsPROD.dbo.OrdLotesProducao C on (a.NumOrdem = c.NumOrdem)  where a.dtemissao>='2016-01-01' and a.numordem > '"+OT+"' group by a.numordem, a.NumOrcamento, a.Descricao, b.CGC, b.RazaoSocial, a.Situacao";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string JOB_STS = "1";
                    if (reader["Status_OP"].ToString() == "A")
                    {
                        JOB_STS = "1";
                    }
                    else
                    {
                        JOB_STS = "2";
                    }

                    query = query + "INSERT INTO Data_P2B.dbo.QGPressJob (QG_RMS_JOB_NBR ,NM ,CTD_TMSTMP ,DUE_DT ,JOB_STS ,CUST_RUT ,CUST_NM, QG_RMS_TITLE_CD ," +
                                        " PRN_ORD_QTY,IMPZ_PROD_HGT,IMPZ_PROD_WDT,OPN_WDTH,OPN_HGT,AccountAddress1,AccountAddress2,AccountNeighborhood," +
                                        " AccountRegion,AccountCountry,AccountCity ,FullIssueName,FECHA_LIQUIDACION) VALUES" +
                                        "('" + reader["QG_RMS_JOB_NBR"].ToString().Trim() + "','" + reader["NM"].ToString().Replace("'", "").Replace('"', ' ') + "','" + reader["CTD_TMSTMP"].ToString() + "',NULL," + JOB_STS + ",'" + reader["RUT_Cliente"].ToString() + "','" +
                                        reader["Nome_Cliente"].ToString().Replace("'", "").Replace('"', ' ') + "','" + "Metric" + "'," + reader["Tiraje"].ToString() + ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);";
                }
            }
            con.CerrarConexion();
            return query;
        }

        public bool SincronizarOT(string query)
        {
            Boolean respuesta = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000_DataP2B();
            if (cmd != null)
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            con.CerrarConexion();
            return respuesta;
        }

        public int SincronizarOTAutomatica(string Usuario, DateTime Fecha, int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            int respuesta = 0;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Adm_SincroOTAutomatica";
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
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return respuesta;
        }

        public bool generarCorreoErrorSuscripcion(string Error)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
            //mmsg.To.Add("juan.venegas@aimpresores.cl");
            mmsg.Subject = "ERROR Sincronizacion";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Body = "<table style='width:100%;'>" +
            "<tr>" +
                "<td>" +
                    "<img src='http://intranet.qgchile.cl/images/Logo color lateral.jpg' width='267px'  height='67px' />" +
                    //"<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
                "</td>" +
            "</tr>" +
            "<tr>" +
                "<td>" +
                    "&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>" +
                    "Estimado(a) :" +
                    "<br />" +
                      "<br />" +
                        "<br />" +
                    "Se ha generado el siguiente error" +
                    "<br/>" +
                    "<br/>" +
                    Error +
                    "<br/>" +
                    "<br />" +
                    "Atentamente," +
                     "<br />" +
                  "Equipo de desarrollo A Impresores S.A" +
                "</td>" +
            "</tr>" +
            "</table>";

            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials =
                new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");

            cliente.Host = "mail.aimpresores.cl";
            try
            {
                cliente.Send(mmsg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }
        
        #region AcrMetrics
        public string List_insertDataACR(string Año, string Mes, string Dia)
        {
            string query = "";
            query += List_insertDataACR_Encuadernacion(Año,Mes,Dia);
            query += List_insertDataACR_RadioTaxi(Año, Mes, Dia);
            query += List_insertDataACR_Flete(Año, Mes, Dia);
            return query;
        }

        public string List_insertDataACR_Encuadernacion(string Año, string Mes, string Dia)
        {
            string query = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionSV2000_Addax();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = " SELECT DDC_ID,DDC_OT_IADE,DOCC_FECHA, DDC_CANT, DDC_VU,PRD_NOMBRE ,'Encuadernación' as Data " +
                                        " FROM Addax..DOCCOMPRA,Addax..DETDOCC,Addax..PRODUCTOS,Addax..PERSONAS " +
                                        " WHERE DDC_ID_DOC=DOCC_ID " +
                                        " AND DOCC_FECHA = '"+Año+Mes+Dia+"' " +
                                        " AND PRD_CODIGO LIKE '%se-%' " +
                                        " AND DDC_PROD=PRD_CODIGO " +
                                        " and PER_RUT=DOCC_RUTPRV " +
                                        " and DOCC_TIPO='f' " +
                                        " AND PRD_UMCONS='UNIDAD' " +
                                        " and DDC_OT_IADE is not null";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        query += "insert into ACR_Encuadernacion (ID_Registro,OT,Proceso,Fecha_Proceso,Cantidad,CostoUnitario,Costo_Total,Estado,Fecha_Envio) " +
                                    "values(" + reader["DDC_ID"].ToString() + ",'" + reader["DDC_OT_IADE"].ToString() + "','" + reader["PRD_NOMBRE"].ToString() + "','" +
                                    Convert.ToDateTime(reader["DOCC_FECHA"].ToString()).ToString("yyyy-MM-dd") + "'," + reader["DDC_CANT"].ToString() + "," + reader["DDC_VU"].ToString() +
                                    "," + Convert.ToInt32(Convert.ToInt32(reader["DDC_CANT"].ToString()) * Convert.ToInt32(reader["DDC_VU"].ToString())).ToString() + ",0,'1900-01-01');";

                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return query;
        }

        public string List_insertDataACR_RadioTaxi(string Año, string Mes, string Dia)
        {
            string query = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionSV2000_Addax();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "SELECT DDC_ID,DDC_OT_IADE,DOCC_FECHA,DDC_CANT, DDC_VU,'' PRD_NOMBRE,'RadioTaxi' as Data " +
                                            " FROM Addax..DOCCOMPRA, Addax..DETDOCC " +
                                            " WHERE DOCC_ID=DDC_ID_DOC " +
                                            " AND DDC_PROD='RT-01-0001' " +
                                            " AND DOCC_FECHA ='"+Año+Mes+Dia+"';";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        query += "insert into ACR_RadioTaxi (ID_Registro,OT,Fecha_Proceso,Cantidad,CostoUnitario,Costo_Total,Estado,Fecha_Envio) " +
                                        "values(" + reader["DDC_ID"].ToString() + ",'" + reader["DDC_OT_IADE"].ToString() + "','" +
                                        Convert.ToDateTime(reader["DOCC_FECHA"].ToString()).ToString("yyyy-MM-dd") + "'," + reader["DDC_CANT"].ToString() + "," + reader["DDC_VU"].ToString() +
                                        "," + Convert.ToInt32(Convert.ToInt32(reader["DDC_CANT"].ToString()) * Convert.ToInt32(reader["DDC_VU"].ToString())).ToString() + ",0,'1900-01-01');";
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return query;
        }

        public string List_insertDataACR_Flete(string Año, string Mes, string Dia)
        {
            string query = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionSV2000_Addax();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = " SELECT DDC_ID,DDC_OT_IADE, DOCC_FECHA, DDC_CANT,DDC_VU,'' PRD_NOMBRE,'Fletes' as Data " +
                                        " FROM Addax..DOCCOMPRA, Addax..DETDOCC " +
                                        " WHERE DOCC_ID=DDC_ID_DOC " +
                                        " AND DDC_PROD='FL-01-0001' " +
                                        " AND DOCC_FECHA ='"+Año+Mes+Dia+"';";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        query += "insert into ACR_Flete (ID_Registro,OT,Fecha_Proceso,Cantidad,CostoUnitario,CostoTotal,Estado,Fecha_Envio) " +
                                        "values(" + reader["DDC_ID"].ToString() + ",'" + reader["DDC_OT_IADE"].ToString() + "','" +
                                        Convert.ToDateTime(reader["DOCC_FECHA"].ToString()).ToString("yyyy-MM-dd") + "'," + reader["DDC_CANT"].ToString() + "," + reader["DDC_VU"].ToString() +
                                        "," + Convert.ToInt32(Convert.ToInt32(reader["DDC_CANT"].ToString()) * Convert.ToInt32(reader["DDC_VU"].ToString())).ToString() + ",0,'1900-01-01');";
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return query;
        }

        public string SincronizadorACR(string Año, string Mes, string Dia)
        {
            string Insertquery = "";
            Insertquery = List_insertDataACR(Año,Mes,Dia);
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

#endregion
    }
}