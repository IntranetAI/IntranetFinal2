using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Despacho
    {
        public string OT { get; set; }
        public int? Folio { get; set; }
        public string NumeroFolio { get; set; }
        public int Rut { get; set; }
        public string Destinatario { get; set; }
        public DateTime? FechaImpresion { get; set; }
        public string Sucursal { get; set; }
        public string Comuna { get; set; }
        public string Despachado { get; set; }
        public string StatusDes { get; set; }

        //modelo utilizado en informeporot
        public DateTime FechaMinima { get; set; }
        public DateTime FechaMaxima { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string TirajeTotal { get; set; }
        
    }
}