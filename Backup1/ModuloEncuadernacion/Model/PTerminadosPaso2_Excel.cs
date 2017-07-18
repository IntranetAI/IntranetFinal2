using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class PTerminadosPaso2_Excel
    {
        public string id_ProductosTerminados { get; set; }
        public string cod_Pallet { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Terminacion { get; set; }
        public string TipoEmbalaje { get; set; }
        public string Total { get; set; }
        public string Observacion { get; set; }
        public string Validado { get; set; }
        public string FechaValidacion { get; set; }
        public string Modificado { get; set; }
    }
}