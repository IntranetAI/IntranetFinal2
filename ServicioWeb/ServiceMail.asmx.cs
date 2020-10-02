using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using ServicioWeb.ModuloProduccion.Controller;
using System.Xml;
using System.Xml.Linq;
using ServicioWeb.ModuloProduccion.Model;
using Newtonsoft.Json;
using System.Net.Mail;

namespace ServicioWeb
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoProduccion_SobreImpresion(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            string Resultado = controlpro.GenerarCorreoComparativo("", DateTime.Now.AddDays(-1), DateTime.Now, 0);//0
            if (Resultado == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_SobreImpresion", "General", "", "", "No se envió el correo");
            }
            string Resultado2 = controlpro.GenerarCorreoComparativo("", DateTime.Now.AddDays(-1), DateTime.Now, 1);//1
            if (Resultado2 == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_SobreImpresion", "General", "", "", "No se envió el correo");
            }
            
            
            return "OK";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoProduccion_ScoreCardImpresion(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();

            //string algo = controlpro.correo_nuevo();

            string[] str = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");

            DateTime primerdia = Convert.ToDateTime(str[1] + "/01/" + str[2] + " 00:00:00");
            string[] str2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

            string[] str3 = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
            DateTime diaactual = Convert.ToDateTime(str3[1] + "/" + str3[0] + "/" + str3[2] + " 23:59:59");
            string Resultado = controlpro.GenerarCorreoScoreCard(fi, ft, primerdia, diaactual);
            if (Resultado == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_ScoreCardImpresion", "General", "", "", "No se envió el correo");
            }
            //string Resultado2 = controlpro.GenerarCorreoScoreCard_ENC(fi, ft, primerdia, diaactual);
            //if (Resultado2 == "Error")
            //{
            //    controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_ScoreCardImpresion", "General", "", "", "No se envió el correo");
            //}
            return "OK";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoProduccion_ScoreCardImpresion_ENC(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            string[] str = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");

            DateTime primerdia = Convert.ToDateTime(str[1] + "/01/" + str[2] + " 00:00:00");
            string[] str2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

            string[] str3 = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
            DateTime diaactual = Convert.ToDateTime(str3[1] + "/" + str3[0] + "/" + str3[2] + " 23:59:59");

            string Resultado2 = controlpro.GenerarCorreoScoreCard_ENC(fi, ft, primerdia, diaactual);
            if (Resultado2 == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_ScoreCardImpresion", "General", "", "", "No se envió el correo");
            }
            return "OK";
        }

        //se envia los jueves. rango de informacion de 7 dias.
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoProduccion_ScoreCardImpresion_Semanal(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            string[] str = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy").Split('/');
            DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");

            string[] str2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

            string Resultado = controlpro.GenerarCorreoScoreCard_Semanal(fi, ft);
            if (Resultado == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_ScoreCardImpresion", "General", "", "", "No se envió el correo");
            }
            //string Resultado2 = controlpro.GenerarCorreoScoreCard_ENC(fi, ft, primerdia, diaactual);
            //if (Resultado2 == "Error")
            //{
            //    controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_ScoreCardImpresion", "General", "", "", "No se envió el correo");
            //}
            return "OK";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoProduccion_DesperdicioPapel(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            string[] str = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");

            string[] str2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

            string Resultado = controlpro.GenerarCorreoDesperdicioPapel(fi, ft);
            if (Resultado == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_DesperdicioPapel", "General", "", "", "No se envió el correo");
            }
            return "OK";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoProduccion_CorreoMerma(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            string[] str = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            //DateTime fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
            string fi = str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00";
            string[] str2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            //DateTime ft = Convert.ToDateTime(str2[2] + "-" + str2[1] + "/" + str2[0] + " 23:59:59");
            string ft = str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59";
            if (controlpro.GenerarCorreoMermas("Rotativas", fi, ft) == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("v", "General", "", "", "No se envió el correo Rotativa");
            }
            if (controlpro.GenerarCorreoMermas("Planas", fi, ft) == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("v", "General", "", "", "No se envió el correo Planas");
            }
            if (controlpro.GenerarCorreoMermas("ENC", fi, ft) == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("v", "General", "", "", "No se envió el correo ENC");
            }
            if (controlpro.GenerarCorreoMermas("Todo", fi, ft) == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("v", "General", "", "", "No se envió el correo Todo");
            }
            return "OK";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoFacturacion_CorreoNotas(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            if (controlpro.GenerarCorreoInformeNotasPendientes()== "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("GenerarCorreoInformeNotasPendientes", "General", "", "", "No se envió el correo");
            }
            return "OK";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoEncuadernacion_CorreoSemanal(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            string[] str = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy").Split('/');
             DateTime fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
   

            string[] str2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime ft = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
            string Resultado = controlpro.GenerarCorreoSemanal_ENC(fi, ft);
            if (Resultado == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("CorreoEncuadernacion_CorreoSemanal", "General", "", "", "No se envió el correo");
            }
            return "OK";
        }

        //Se envia todos los dias a las 08:00 y solo los ultimos dias a las 18:00
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoFacturacion_CorreoFacturacionMensual(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            string[] Hoy = DateTime.Now.AddDays(-9).ToString("dd-MM-yyyy").Split('-');
            string Resultado = controlpro.GenerarCorreoInformeFacturacion(Hoy[2].ToString(), Hoy[1].ToString(), DateTime.DaysInMonth(Convert.ToInt32(Hoy[2].ToString()), Convert.ToInt32(Hoy[1].ToString())).ToString());
            if (Resultado == "Error")
            {
                controlpro.GenerarCorreoErrordeEnvio("CorreoFacturacion_CorreoFacturacionMensual", "General", "", "", "No se envió el correo");
            }
            
            return "OK";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoFechaDistribucionxOT(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            string QueryDtEntregas = controlpro.FechaEntregaPedidosCorreoAutomatico();
            if (QueryDtEntregas != "")
            {
                if (QueryDtEntregas == "0")
                {
                    return "NO SE ENVIO";
                }
                else if (controlpro.SincronizadorFechaEntragas(QueryDtEntregas))
                {
                    return "OK";
                }
                else
                {
                    controlpro.GenerarCorreoErrordeEnvio("FechaEntregaEnviodeCorreoAutomatico", "Sincronizador", "", "", "se envió el correo, pero no ingreso a Intranet2");
                    return "Error";
                }
            }
            else
            {
                controlpro.GenerarCorreoErrordeEnvio("FechaEntregaEnviodeCorreoAutomatico", "General", "", "", "No se envió el correo");
                return "Error";
            }
            /*[cjerias 20190128_1514] Original antes de cambio, fechas sacadas de pedidos (tab 1)*/
            
            //ProduccionController controlpro = new ProduccionController();
            //string QueryDtEntregas = controlpro.FechaEntregaEnviodeCorreoAutomatico();
            //if (QueryDtEntregas != "")
            //{
            //    if (QueryDtEntregas == "0")
            //    {
            //        return "NO SE ENVIO";
            //    }
            //    else if (controlpro.SincronizadorFechaEntragas(QueryDtEntregas))
            //    {
            //        return "OK";
            //    }
            //    else
            //    {
            //        controlpro.GenerarCorreoErrordeEnvio("FechaEntregaEnviodeCorreoAutomatico", "Sincronizador", "", "", "se envió el correo, pero no ingreso a Intranet2");
            //        return "Error";
            //    }
            //}
            //else
            //{
            //    controlpro.GenerarCorreoErrordeEnvio("FechaEntregaEnviodeCorreoAutomatico", "General", "", "", "No se envió el correo");
            //    return "Error";
            //}

        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoOTLiberadas(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            string QueryOTLiberada = controlpro.Produccion_CorreoAutomatico_OTLiberas();
            if (QueryOTLiberada != "")
            {
                if (controlpro.SincronizadorFechaEntragas(QueryOTLiberada))
                {
                    return "OK";
                }
                else
                {
                    controlpro.GenerarCorreoErrordeEnvio("SincronizadorOTLiberadas", "Sincronizador", "", "", "se envió el correo, pero no ingreso a Intranet2");
                    return "Error";
                }
            }
            else
            {
                controlpro.GenerarCorreoErrordeEnvio("CorreoOTLiberadas", "General", "", "", "No se envió el correo");
                return "Error";
            }

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string SincronizadorOTs(string Usuario)
        {
            ProduccionController controlpro = new ProduccionController();
            return (controlpro.SincronizadorOT()) ? "OK": "Error";
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string CorreoErrorGuiasDespacho(string IDIntegracion)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
            mmsg.Body = "<img src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='267px'  height='67px' />" +
                        "<br/><br/>Estimado(a):" +
                        "<br/><br/>Ha ocurrido un error al integrar la guia de despacho" +
                "<br/>testtt<br/>" +

                        "IdIntr: " + IDIntegracion.ToString() + "<br/>" +
                        "<br />" +
                        "Atentamente," +
                        "<br />" +
                        "<b>Equipo de desarrollo A Impresores S.A.</b>";

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            mmsg.Subject = "ERROR Integracion con Guias de Despacho";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("sobreimpresiones@aimpresores.cl");
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials =
                new System.Net.NetworkCredential("sobreimpresiones@aimpresores.cl", "info_sobreimpresiones");

            cliente.Host = "mail.aimpresores.cl";
            try
            {
                cliente.Send(mmsg);
                return "OK";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return "Error";
            }
        
        }




        // TRANSACCIONES PAPEL
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string Correo_ConsumoPapel(string Usuario)
        {
            PapelController pc = new PapelController();bool otro = false;
            string Resultado = pc.GenerarCorreoConsumoPapel(Usuario);
            if(Resultado == "Error")
            {
                // controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_SobreImpresion", "General", "", "", "No se envió el correo");
            }
            return "OK";
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string Correo_ConsumoPapelFL(string Usuario)
        {
            PapelController pc = new PapelController();
            bool Resultado = pc.GenerarCorreoConsumoPapelFL(Usuario);
            if (Resultado == false)
            {
                // controlpro.GenerarCorreoErrordeEnvio("CorreoProduccion_SobreImpresion", "General", "", "", "No se envió el correo");
            }


            return "OK";
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string Prinergy_Carga_ACR(string Usuario)
        {
            XMLController xc = new XMLController();

            string[] str = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");


            string[] str2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime ft = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
            List<ACR> Lista = xc.consultaMysql_ACR(fi, ft);

            foreach (var item in Lista)
            {
                if (xc.InsertACRMentrics(item.OT, item.Centro, item.Cantidad,item.Total, item.Fecha, 0) > 0)
                {
                    int myvar = xc.InsertACRMentrics(item.OT, item.Centro, item.Cantidad,item.Total, item.Fecha, 1);
                }
            }


            return "OK";
        }
        [WebMethod] 
      //  [ScriptMethod(UseHttpGet = true)]
        public string Lithoman_OTPliego()
        {
            try
            {
                LithoController lc = new LithoController();
                JsonLitho jl = lc.ListarRegistro();

                // Session["ot"] = "agoasd";
                //HttpContext.Current.Response.Redirect("http://www.google.cl");
                //Session["OT"] = jl.OT;
                // Context.Response.AddHeader("Location","http://www.google.cl");
                return JsonConvert.SerializeObject(jl);
            }catch(Exception ex)
            {
                return "Error";
            }
            //return "OK";
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet =true)]
        public string Prinergy_OTAutomatica(string Usuario)
        {
            XMLController xc = new XMLController();
            List<XMLMetrics> ListadoOTs = xc.OTSEmitidas();
            List<XMLMetrics_Detalle> ListadoEstructuras = xc.EstructurasEmitidas();
            List<XMLMetrics_Detalle> ListadoEstructurasEmitidas = xc.EstructurasEmitidasPreviamente();
            /*LISTA PAGINAS DE INICIO Y APA ESPECIAL*/
            List<PaginasInicio> listadoPaginasInicio = xc.CleintesPaginaInicio3();
            List<APA_Clientes> listadoAPAClientes = xc.ClientesAPA();
            string miXML = "";string miXMLenc = ""; string Notas = "";  string PrimerColorFlow = "";string UltimoColorFlow = "";bool MultiplePapel = false;string NotasAnidadas = "";

            foreach (var item in ListadoOTs)
            {
                if (ListadoEstructuras.Where(x => x.OT == item.OT).Count() > 0)
                {
                    List<XMLMetrics_Detalle> fil1 =  ListadoEstructuras.Where(x => x.OT == item.OT).ToList();
                    List<XMLMetrics_Detalle> fil2 = ListadoEstructurasEmitidas.Where(x => x.OT == item.OT).ToList();
                    string Cambios = "";
                    if (fil2.Count > 0)
                    {
                        foreach (var cons in fil1)
                        {
                            if (fil2.Where(x => x.Proceso == cons.Proceso).Where(p => p.Paginas == cons.Paginas).Where(p => p.X == cons.X).Where(p => p.Y == cons.Y).Where(p => p.Papel == cons.Papel).Count() == 0)
                            {
                                Cambios = "Si";
                            }
                        }
                    }else
                    {
                        Cambios = "Si";
                    }

                    if (Cambios == "Si")
                    {
                        #region RECORREROTS;
                        //Recorrer numero de paginas
                        string arregloPrefijo = "p,q,r,s,t,u,v,w,x,y,z,a,b,c,d,e,f,g,h,j,k,p,q,r,s,t,u,v,w,x,y,z,a,b,c,d,e,f,g,h,j,k,p,q,r,s,t,u,v,w,x,y,z,a,b,c,d,e,f,g,h,j,k"; string APA = "";
                        int largo = 0;
                        foreach (var it in fil1)
                        {
                            #region CrearXML;
                            if (it.MultiplePapel == true)
                            {
                                MultiplePapel = true;
                            }
                            if (it.Proceso.ToLower().Contains("pagina"))
                            {
                                PrimerColorFlow = it.ColorFlow;
                            }
                            if (UltimoColorFlow == "")
                            {
                                UltimoColorFlow = it.ColorFlow;
                            }
                            string Papel = ((item.Cliente.ToLower().Contains("copesa")) ? "" : it.Papel);
                            string Inicio = "1";
                            if (it.Proceso.ToLower() == "paginas")
                            {
                                int pagina = listadoPaginasInicio.Where(x => x.Cliente == item.Cliente && item.NombreOT.Trim().ToLower().Contains(x.Keyword.ToLower())).Select(p => p.Pagina).FirstOrDefault();
                                if (pagina > 0)
                                {
                                    Inicio = pagina.ToString();
                                }
                                //if(item.Cliente.ToLower().Contains("copesa")|| item.Cliente.ToLower().Contains("avon"))
                                //{
                                //    Inicio = "3";
                                //}else
                                //{
                                //    Inicio = "1";
                                //}
                            }
                            string Prefijo = (it.Proceso.ToLower().Contains("paginas") ? "p" : it.Proceso + "");
                            string Prefijoxml = "";
                            Prefijoxml = arregloPrefijo.Substring(0, 2);
 
 
                            miXML += "<GrupoPaginas>" +
                                                    "<NombreGrupoPaginas>" + it.Proceso + "</NombreGrupoPaginas>" +
                                                    "<CantidadPaginas>" + it.Paginas.ToString() + "</CantidadPaginas>" +
                                                    "<InicioGrupo>" + Inicio + "</InicioGrupo>" +
                                                    "<X>" + it.X + "</X>" +
                                                    "<Y>" + it.Y + "</Y>" +
                                                    "<Prefijo>" + Prefijoxml.Replace(",", "") + "</Prefijo>" +
                                                    "<ColorPapel>" + Papel + "</ColorPapel>" +
                                                    "<ColorFlow>" + it.ColorFlow + "</ColorFlow>" +
                                              "</GrupoPaginas>";

                            Notas += "Para " + it.Proceso + ":<br/>" +
                                       it.OT + Prefijo + "1.pdf<br/>" +
                                       "Donde " + it.OT + " Corresponde al numero de OT, " + Prefijo + " indica que forma parte de las " + it.Proceso + " y " + Inicio + " indica la posicion dentro de estas.<br/>" +
                                       it.Proceso + " mide " + it.Xnota + " mm de ancho y " + it.Ynota + " mm de alto, con una cantidad de " + it.Paginas + ".<br/><br/>";
                            NotasAnidadas += "Para " +it.Proceso+": El PDF anidado debe llamarse "+it.Proceso+ ".pdf<br/>";

                            if (it.Proceso.ToLower().Contains("pagina") && listadoAPAClientes.Where(x => x.Cliente == item.Cliente).Count() > 0)
                            {
                                string miApa = listadoAPAClientes.Where(x => x.Cliente == item.Cliente && item.NombreOT.Trim().ToLower().Contains(x.Keyword.ToLower())).Select(p => p.APA).FirstOrDefault();
                                APA += "ASSIGN= &quot;" + miApa + "&quot; &quot;" + it.Proceso + "&quot; [#PgPosition] 1<br/>";
                            }
                            APA += "ASSIGN= &quot;" + item.OT + Prefijo + "[#PgPosition].p1.pdf&quot; &quot;" + it.Proceso + "&quot; [#PgPosition] 1<br/>";
                            /*APA PARA CARGA DE ARCHIVOS ANIDADOS*/
                            APA += "ASSIGN= &quot;"+it.Proceso+"[%].p[#PgPosition].p1.pdf&quot; &quot;" + it.Proceso + "&quot; [#PgPosition] 1<br/>";
                            APA += "ASSIGN= &quot;" + it.Proceso + "[%].p[#PgPosition].pdf&quot; &quot;" + it.Proceso + "&quot; [#PgPosition]" + ((Inicio == "3") ? "+2" : "") + " 1<br/>";
                            //APA Especial para NATURA
                            //if(item.Cliente.ToLower().Contains("natura") && item.NombreOT.ToLower().Contains("catal") && it.Proceso.ToLower().Contains("pagina"))
                            //{
                            //    APA += "ASSIGN= &quot;[%]_[$]_[#PgPosition].p1.pdf&quot; &quot;" + it.Proceso + "&quot; [#PgPosition] 1<br/>";
                            //}
                            //string mivar = arregloPrefijo.Substring(2, largo-2);
                            arregloPrefijo = arregloPrefijo.Substring(2, arregloPrefijo.Length-2);  // arregloPrefijo.Replace(Prefijoxml, "");
                            #endregion
                        }
                        try
                        {
                            if (miXML != "")
                            {
                                string NotaCompleta = Notas + "SI CARGA PAGINAS ANIDADAS(1 solo PDF con todas las paginas)<br/>" + NotasAnidadas;
                                miXMLenc = "<ConfiguracionTrabajo NOTA='Estimado Cliente: <br/><br/><br/>La nomenclatura a utilizar en sus archivos es la siguiente:<br/><br/>" + NotaCompleta.Replace("<br/>", "&#xA;\n") + "<br/><br/>En caso de dudas contacese con su reprentante de servicio al cliente.' Cliente='" + item.Cliente.Trim() + "' ColorFlow='" + (PrimerColorFlow != "" ? PrimerColorFlow : UltimoColorFlow) + "' APA='!APA 1.0 <br/>" +
                                                //"ASSIGN= &quot;000001p[#PgPosition].p1.pdf&quot; &quot;Paginas&quot; [#PgPosition] 1<br/>" +
                                                //"ASSIGN= &quot;000001Tapa[#PgPosition].p1.pdf&quot; &quot;Tapa&quot; [#PgPosition] 1<br/>" +
                                                APA +
                                                "' Username='cjerias' NombreTrabajo='" + item.NombreOT.Trim() + "' CSR='" + item.CSR + "' CorreoCSR='" + item.CorreoCSR + "' ClienteNuevo='" + item.EstadoCliente + "'>";

                                miXML += "</ConfiguracionTrabajo>";
                                XElement xml = XElement.Parse(miXMLenc.Replace("<br/>", "&#xA;\n") + miXML);

                                XDocument pruebaXml = new XDocument(xml);
                                if (MultiplePapel == false)
                                {
                                    string a = HttpContext.Current.Server.MapPath("~/Prueba/" + item.OT.Trim() + "_" + item.NombreOT.Trim() + "_ConfiguracionTrabajo.xml");
                                    pruebaXml.Save(a);
                                }
                                else
                                {
                                    string a = HttpContext.Current.Server.MapPath("~/PruebaPapeles/" + item.OT.Trim() + "_" + item.NombreOT.Trim() + "_ConfiguracionTrabajo.xml");
                                    pruebaXml.Save(a);
                                }

                                XMLController xm = new XMLController();
                                string ale = xm.InsertSincronizacion(item.OT.Trim(), item.NombreOT.Trim(), item.Cliente.Trim(), "Creada", 1, "Automatica", 0);
                                int ultimavs = xm.InsertUltimaVersion(item.OT, "", 0, 0, 0, 0, "", 2);
                                foreach (var est in fil1)
                                {
                                    int algo = xm.InsertEstructura(est.OT.Trim(), est.Proceso, est.Paginas, 1, Convert.ToInt32(est.Xnota), Convert.ToInt32(est.Ynota), est.Papel, ultimavs.ToString(), 1);
                                }


                                miXML = "";
                                Notas = "";
                                NotasAnidadas = "";
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            string errorrr = ex.Message.ToString();
                        }
                        miXML = "";
                        Notas = "";
                        NotasAnidadas = "";
                        MultiplePapel = false;
                        #endregion
                    }


                }
            }

            return "";
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string Correo_Preprensa_PliegosFinalizados(string Usuario)
        {
            LithoController lc = new LithoController();

            string[] str = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
            string[] strd = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Split('/');
            DateTime FI=DateTime.Now;DateTime FT = DateTime.Now; string dia = "";

            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                FI = Convert.ToDateTime(strd[2] + "-" + strd[1] + "-" + strd[0] + " 16:00:00");
                FT = Convert.ToDateTime(strd[2] + "-" + strd[1] + "-" + strd[0] + " 23:59:59");
                dia = strd[0] + "-" + strd[1] + "-" + strd[2] + " desde las 16:00 a las 23:59 hrs.";
            }
            else if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 15)
            {
                FI = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                FT = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 08:00:00");
                dia = str[0] + "-" + str[1] + "-" + str[2] + " desde las 00:00 a las 08:00 hrs.";
            }
            else if(DateTime.Now.Hour >= 16 && DateTime.Now.Hour <= 23)
            {
                FI = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 08:00:00");
                FT = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 16:00:00");
                dia = str[0] + "-" + str[1] + "-" + str[2] + " desde las 08:00 a las 16:00 hrs.";
            }
            

            List<PliegosFinalizados> pf = lc.PliegosFinalizados(FI, FT, 0);

            if (pf.Count >= 1)
            {
                string Contenido = ""; string Color = ""; int Contador = 0;
                string Encabezado = "<table runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1000px;margin-left:3px;'>" +
                      "<tbody><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>Sector</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>Maquina</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>OT</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:300px;'>Nombre OT</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:300px;'>Pliego</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Planificado</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:60px;'>Buenos</td>" +

                      "</tr>";
                try
                {
                    foreach (PliegosFinalizados pl in pf)
                    {
                        if (pl.Buenos >= pl.Planficado)
                        {
                            Color = ((Contador % 2) == 0 ?  "#fff": "#f3f4f9");

                            Contenido = Contenido + "<tr style='height: 22px; background: " + Color + "; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;'>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>" +
                           pl.Sector + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                           pl.Maquina + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:88px;'>" +
                           pl.OT + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:300px;'>" +
                           pl.NombreOT.ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:300px;'>" +
                           pl.Pliego.ToLower() + "</td>" +
                           "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                            pl.Planficado.ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:60px;'>" +
                            pl.Buenos.ToString("N0").Replace(",", ".") + "</td>" +

                            "</tr>";
                            Contador = Contador + 1;
                        }
                    }
                }catch(Exception exx)
                {

                }


                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
                mmsg.To.Add("copia@aimpresores.cl");
                mmsg.To.Add("preprensa@aimpresores.cl");
                
                mmsg.Body = "Estimado(a):" +
                            "<br/><br/>Este informe se obtiene de forma automática desde el control de producción (Metrics Jobtrack), siendo esta informacion correspondiente " + dia+
                    "<br/>" +
                            Encabezado + Contenido + "</body></table>"+

                            "<br />" +
                            "Atentamente," +
                            "<br />" +
                            "<b>Equipo de desarrollo A Impresores S.A.</b>";

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
                mmsg.Subject = "Produccion - Pliegos finalizados";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");


                SmtpClient _smtpClient = new SmtpClient();
                _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                _smtpClient.Host = "smtp.office365.com";
                _smtpClient.Port = 587;
                _smtpClient.EnableSsl = true;
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "Octubre2019");
                try
                {
                    _smtpClient.Send(mmsg);
                    return "OK";
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    return "Error";
                }

            }
            return "Error";
        }
    }
} 