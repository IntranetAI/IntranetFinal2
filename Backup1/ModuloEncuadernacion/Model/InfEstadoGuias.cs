using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class InfEstadoGuias
    {
        public string NroPallet { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Terminacion { get; set; }
        public string TipoEmbalaje { get; set; }
        public string Cantidad { get; set; }
        public string Ejemplares { get; set; }
        public string Total { get; set; }
        public string Modelo { get; set; }
        public string Observacion { get; set; }
        public string FechaCreacion { get; set; }
        public string Estado { get; set; }
    }
}