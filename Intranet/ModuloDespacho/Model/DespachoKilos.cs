using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class DespachoKilos
    {
        public string Transportista { get; set; }
        public string Patente { get; set; }
        public int Guias { get; set; }
        public string FechaDespacho { get; set; }
        public string  OT { get; set; }
        public string  NumeroOT { get; set; }
        public string  PesoUnitario { get; set; }
        public int Cant { get; set; }
        public float TotalKilos { get; set; }
    }
}