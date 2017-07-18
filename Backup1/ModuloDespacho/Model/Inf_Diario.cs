using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Inf_Diario
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string FechaDespacho { get; set; }
        public string TirajeTotal { get; set; }
        public string TotalDespachado { get; set; }
    }
}