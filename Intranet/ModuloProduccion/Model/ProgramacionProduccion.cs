using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class ProgramacionProduccion
    {
        public string Actividad { get; set; }
        public string Maquina { get; set; }
        public string Proceso { get; set; }

        public string Obs { get; set; }
        public string Pliego { get; set; }
        public string TirajePlaneado { get; set; }
        public string PliegosImpresos { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Tiempo { get; set; }
        public string Estado { get; set; }
    }
}