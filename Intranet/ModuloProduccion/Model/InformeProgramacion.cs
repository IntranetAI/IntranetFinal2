using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class InformeProgramacion
    {

        public string Maquina { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Pliegos { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string Horas { get; set; }
        public string NroForma { get; set; }
        public string VB { get; set; }
        public string VBdet { get; set; }
    }
}