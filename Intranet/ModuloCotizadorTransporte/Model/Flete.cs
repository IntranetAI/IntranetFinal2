using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloCotizadorTransporte.Model
{
    public class Flete
    {
        public string Destino { get; set; }
        public string Via { get; set; }
        public double PesoUN { get; set; }
        public int Cantidad { get; set; }
        public double KGTotales { get; set; }
        public int Ramal { get; set; }
        public int Costo { get; set; }
        public string Salidas { get; set; }


    }
}