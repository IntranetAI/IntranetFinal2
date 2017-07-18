using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class HistorialDespacho_Excel
    {

        public string Folio { get; set; }
        public string FechaImpresion { get; set; }
        public string Destinatario { get; set; }
        public string Sucursal { get; set; }
        public string Comuna { get; set; }
        public string Cantidad { get; set; }
    }
}