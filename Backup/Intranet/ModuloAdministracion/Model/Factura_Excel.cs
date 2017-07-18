using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloAdministracion.Model
{
    public class Factura_Excel
    {
        public string Folio { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string FechaEmision { get; set; }
        public string FechaVencimiento { get; set; }
        public string ValorNeto { get; set; }
        public string IVA { get; set; }
        public string Total { get; set; }
        public string Estado { get; set; }
    }
}