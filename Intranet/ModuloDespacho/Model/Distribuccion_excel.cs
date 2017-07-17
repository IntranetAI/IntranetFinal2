using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Distribuccion_excel
    {
        public string OT { get; set; }
        public string Rut { get; set; }
        public string Sucursal { get; set; }
        public string Comuna { get; set; }
        public string Pais { get; set; }
        public string Embalaje { get; set; }
        public int Cant_Bultos { get; set; }
        public int Cant_porbult { get; set; }
    }
}