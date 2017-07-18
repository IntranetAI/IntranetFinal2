using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class FechasDistribucion
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string Tiraje { get; set; }
        public string TotalDespachado { get; set; }
        public string TirajeGenerado { get; set; }
        public string tirajeAcumulado { get; set; }
        public string Despachado { get; set; }
        public string FechaDes { get; set; }
    }
}