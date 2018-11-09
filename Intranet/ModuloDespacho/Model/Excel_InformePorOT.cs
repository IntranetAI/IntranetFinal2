using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Excel_InformePorOT
    {
        public string OT { get; set; }
        public string TipoMovimiento { get; set; }
        public string NroGuia { get; set; }
        public string NombreOT { get; set; }
        public string Sucursal { get; set; }
        public string FechaDespacho { get; set; }
        public string TirajeTotal { get; set; }
        public string TotalDespachado { get; set; }
    }
    public class Excel_InformePorFecha
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string TirajeTotal { get; set; }
        public string TotalDespachado { get; set; }
    }
}