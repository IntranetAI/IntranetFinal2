using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class PliegosImpresos
    {
        public string Nombre { get; set; }
        public string Description { get; set; }
        public string Pliego { get; set; }
        public string CantSolicitada { get; set; }
        public string CantProducida { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
    }
}