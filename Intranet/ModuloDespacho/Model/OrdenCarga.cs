using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class OrdenCarga
    {
        public int ID { get; set; }
        public string FechaEntrega { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string Sucursal { get; set; }
        public string Region { get; set; }
        public string Comuna { get; set; }
        public string Estado { get; set; }
        public string Accion { get; set; }
    }
}