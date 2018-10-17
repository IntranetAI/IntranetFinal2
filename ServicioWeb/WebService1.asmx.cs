using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using ServicioWeb.ModuloProduccion.Model;

namespace ServicioWeb
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public WSMetrics[] GetEmployessXML()
        {
            WSMetrics[] emps = new WSMetrics[] {
            new WSMetrics()
            {
                OT="111111",
                NombreOt="aaaaaa",
                Pliego="A_INTERIOR 1",
                Tiraje=10,
                Buenos=11,
                FechaInicio=DateTime.Now.AddDays(-1),
                FechaTermino=DateTime.Now.AddDays(-1)
            },
            new WSMetrics()
            {
                OT="222222",
                NombreOt="bbbbbb",
                Pliego="A_INTERIOR 2",
                Tiraje=1000,
                Buenos=1100,
                FechaInicio=DateTime.Now.AddDays(-1),
                FechaTermino=DateTime.Now.AddDays(-1)
            }
        };
            return emps;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetEmployessJSON(string OT)
        {
            WSMetrics[] emps = new WSMetrics[] {
            new WSMetrics()
            {
                OT= OT+"-1",
                NombreOt="aaaaaa",
                Pliego="A_INTERIOR 1",
                Tiraje=10,
                Buenos=11,
                FechaInicio=DateTime.Now.AddDays(-1),
                FechaTermino=DateTime.Now.AddDays(-1)
            },
            new WSMetrics()
            {
                OT=OT+"-2",
                NombreOt="bbbbbb",
                Pliego="A_INTERIOR 2",
                Tiraje=1000,
                Buenos=1100,
                FechaInicio=DateTime.Now.AddDays(-1),
                FechaTermino=DateTime.Now.AddDays(-1)
            }
        };
            return new JavaScriptSerializer().Serialize(emps);
        }
    }
}
