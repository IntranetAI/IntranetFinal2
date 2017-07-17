using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class DiarioDetallado
    {
        public string OT { get; set; }
        public string Folio { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string Sucursal { get; set; }
        public string Despacho { get; set; }
        public string Tiraje { get; set; }
        public string Cantidad { get; set; }
    }
}