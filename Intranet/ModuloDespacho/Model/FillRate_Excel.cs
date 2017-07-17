using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class FillRate_Excel
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Tiraje { get; set; }
        public string Solitada { get; set; }
        public string CantidadGenerada { get; set; }
        public string FechaEntregar { get; set; }
       // public string FechaEntregada { get; set; }
        public string PuntoEntrega { get; set; }
        //public string PorcTiraje { get; set; } 
        //public string DespachoTotal { get; set; }
        public string PorcSobreTiraje { get; set; }
        public string PorcSolicitado { get; set; }
        //
      
    }
}