using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class InfDevolucion
    {
        public string Folio { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string TirajeOT { get; set; }
        public string CausaDevolucion { get; set; }
        public string Total_Dev { get; set; }
        public string CreadaPor { get; set; }
        public string FechaCreacion { get; set; }
        public string TipoDevolucion { get; set; }
        public string Estado { get; set; }
    }
}