using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProyectos.Model
{
    public class ProyectosOT
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string TirajeTotal { get; set; }
        public string EnviadoEnc { get; set; }
        public string TotalRecepcionado { get; set; }
        public string TotalDespachado { get; set; }
        public string Devolucion { get; set; }      
        public string Saldo { get; set; }
        public string Avance { get; set; }
        public string Estado { get; set; }
        public string VerMas { get; set; }
    }
}