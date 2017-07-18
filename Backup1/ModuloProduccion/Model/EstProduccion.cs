using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class EstProduccion
    {
        public string Maquina { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Pliego { get; set; }
        public string Planificado { get; set; }
        public string Producido { get; set; }
        public string HorasPreparacion { get; set; }
        public string MermaPreparacion { get; set; }
        public string HorasTiraje { get; set; }
        public string MermaTiraje { get; set; }
        public string Velocidad { get; set; }
        public string Uptime { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string Operador { get; set; }
        public string VerMas { get; set; }
        public string CodRecurso { get; set; }
    }
}