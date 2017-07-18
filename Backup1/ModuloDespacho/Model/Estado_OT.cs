using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Estado_OT
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string TirajeTotal { get; set; }
        public string FechaMinima { get; set; }
        public string TotalDespachado { get; set; }
        public string Devolucion { get; set; }
        public string Saldo { get; set; }
        public string Estado { get; set; }
        public string FechaMaxima { get; set; }
    }
}