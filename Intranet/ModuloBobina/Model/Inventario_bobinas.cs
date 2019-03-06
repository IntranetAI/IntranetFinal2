using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloBobina.Model
{
    public class Inventario_bobinas
    {
        public string Codigo { get; set; }
        public string SKU { get; set; }
        public string Papel { get; set; }
        public string Fecha { get; set; }
        public string Kilos { get; set; }
        public string Bodega { get; set; }
        public string Ubicacion { get; set; }
    }
}