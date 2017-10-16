using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using ServicioWeb.ModuloProduccion.Controller;

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
            string QueryDtEntregas = controlpro.FechaEntregaEnviodeCorreoAutomatico();
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





    }
} 