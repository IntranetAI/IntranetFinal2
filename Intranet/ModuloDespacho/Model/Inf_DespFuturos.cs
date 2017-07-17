using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Inf_DespFuturos
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string Tiraje { get; set; }
        public string CantADespachar { get; set; }
        public string CantDespachada { get; set; }
        public string TotalDespachado { get; set; }
        public string FechaEntrega { get; set; }
        public string Despachada { get; set; }
        
    }
}