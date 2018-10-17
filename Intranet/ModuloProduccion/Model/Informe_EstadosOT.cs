using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class Informe_EstadosOT
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string Tiraje { get; set; }
        public string FechaEmision { get; set; }
        public string FechaEntrega { get; set; }
        public string Estado { get; set; }
    }
}