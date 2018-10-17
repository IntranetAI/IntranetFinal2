using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    [Serializable]
    public class SimpliRoute
    {
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string Carga { get; set; }
        public string Notas { get; set; }
        public string Folio { get; set; }
        public string OT { get; set; }
        public string PersonaContacto { get; set; }
        public string NombreOT { get; set; }
        public string Total { get; set; }
        public string Correo { get; set; }
    }
}