using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Fill_Rate
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Tiraje { get; set; }
        public string Solitada { get; set; }
        public DateTime? FechaEntregar { get; set; }
        public DateTime? FechaEntregada { get; set; }
        public int? PuntoEntrega { get; set; }
        public string PorcTiraje { get; set; }
        public string PorcSolicitado { get; set; }
        //
        public string CantidadGenerada { get; set; }
        public string DespachoTotal { get; set; }
    }
}