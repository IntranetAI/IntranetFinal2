using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class ProgramaProduccion_Extendido
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Maquina { get; set; }
        public string NumPliego { get; set; }
        public string TiempoDif { get; set; }
        public string CantPliegos { get; set; }
        public string FechaInicio { get; set; }
        public string Sector { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
    }
}