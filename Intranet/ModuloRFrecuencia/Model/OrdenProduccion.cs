using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloRFrecuencia.Model
{
    public class OrdenProduccion
    {
        public string OrdenP { get; set; }
        public int Tiraje { get; set; }
        public string Cliente { get; set; }
        public string Nombre_OT { get; set; }
        public int TirajePliego { get; set; }
        public string Papel_Solicitud { get; set; }
        public int Saldo { get; set; }
        public string Status { get; set; }
    }
}