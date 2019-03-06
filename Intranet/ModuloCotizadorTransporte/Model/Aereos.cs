using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloCotizadorTransporte.Model
{
    public class Aereos
    {
        public string IdAereos { get; set; }
        public string Ciudad { get; set; }
        public int de01a03 { get; set; }
        public int de04a150 { get; set; }
        public int de151a500 { get; set; }
        public int de501aInfinito { get; set; }
        public string Opciones { get; set; }
    }
}