using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Desp_PreGuia
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Estado { get; set; }
        public string NroPreGuia { get; set; }
        public string NroGuia { get; set; }
        public string Sucursal { get; set; }
        public string FechaDespacho { get; set; }
        public string TirajeOT { get; set; }
        public string CantidadGuia { get; set; }

    }
}