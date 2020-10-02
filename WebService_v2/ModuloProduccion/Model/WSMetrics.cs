using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService_v2.ModuloProduccion.Model
{
    public class WSMetrics
    {
        public string OT { get; set; }
        public string NombreOt { get; set; }
        public int Tiraje { get; set; }
        public string Pliego { get; set; }
        public int Buenos { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
    }
}