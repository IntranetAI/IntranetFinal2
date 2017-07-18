using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class DespachoPDF
    {
        public string OT { get; set; }
        public int? guia { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string FechaImpresion { get; set; }
        public string TirajeTotal { get; set; }
        public string Despachado { get; set; }
        public int Rut { get; set; }
        //pdf ot agrupada

        public DateTime? FechaMinima { get; set; }
        public DateTime? FechaMaxima { get; set; }

        public string fechaDespacho { get; set; }
    }
}