using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class DespachoFuturosExcel
    {
        public string  OT { get; set; }
        public string NombreOT { get; set; }
        public string  Cliente { get; set; }
        public string Cant { get; set; }
        public string TirajeGenerado { get; set; }
        public string tirajeAcumulado { get; set; }
        public string FechaDes { get; set; }
        public string Fechafalsa { get; set; }
        public string Despachado { get; set; }
        

    }
}