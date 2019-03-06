using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloCotizadorTransporte.Model
{
    public class Terrestres
    {
        public int IdTerrestre { get; set; }
        public string Ciudad { get; set; }
        public int De01a05 { get; set; }
        public int De06a10 { get; set; }
        public int De11a20 { get; set; }
        public int De21a30 { get; set; }
        public int De31a40 { get; set; }
        public int De41a50 { get; set; }
        public int De51a60 { get; set; }
        public int De61a70 { get; set; }
        public int De71a80 { get; set; }
        public int De81a90 { get; set; }
        public int De91a100 { get; set; }
        public int De101a1000 { get; set; }
        public int De1001a4000 { get; set; }
        public int De4001a7000 { get; set; }
        public int De7001aInfinito { get; set; }
        public string MT3 { get; set; }
        public string Salidas { get; set; }
        public string Opciones { get; set; }
    }
}