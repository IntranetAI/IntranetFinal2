using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService_v2.ModuloProduccion.Model
{
    public class SincronizarOT
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string FechaCreacion { get; set; }
        public string Estado { get; set; }
        public string ClienteRut { get; set; }
        public string Cliente { get; set; }
        public string Tiraje { get; set; }
        public string FechaLiquidacion { get; set; }
    }
}