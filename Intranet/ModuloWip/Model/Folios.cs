using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloWip.Model
{
    public class Folios
    {
        public string Pallet { get; set; }
        public int Caja { get; set; }
        public int Desde { get; set; }
        public int Hasta { get; set; }
        public string Asignatura { get; set; }
        public string Forma { get; set; }
    }
}