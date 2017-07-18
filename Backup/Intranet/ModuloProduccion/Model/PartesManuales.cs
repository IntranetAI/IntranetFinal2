using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class PartesManuales
    {
        public string IDParte { get; set; }
        public string Maquina { get; set; }
        public string Codigo { get; set; }
        public string Pliego { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string Buenos { get; set; }
        public string Malos { get; set; }
        public string Factor { get; set; }
        public string Maloss { get; set; }
        public string FechaParte { get; set; }
    }
}