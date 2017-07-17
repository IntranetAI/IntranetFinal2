using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class DespachoExcel
    {
        public string OT { get; set; }
        public string TipoMovimiento { get; set; }
        public string guia { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string FechaImpresion { get; set; }
        public string TirajeTotal { get; set; }
        public string Despachado { get; set; }

    }
}