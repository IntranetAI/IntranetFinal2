using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Desp_InfPorOT
    {
        public string TipoMovimiento { get; set; }
        public string OT { get; set; }
        public string Folio { get; set; }
        public string NumeroFolio { get; set; }
        public string Rut { get; set; }
        public string Destinatario { get; set; }
        public string FechaImpresion { get; set; }
        public string Sucursal { get; set; }
        public string Comuna { get; set; }
        public string Despachado { get; set; }
        public string StatusDes { get; set; }

        //modelo utilizado en informeporot
        public string FechaMinima { get; set; }
        public string FechaMaxima { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string TirajeTotal { get; set; }
        
    }
}