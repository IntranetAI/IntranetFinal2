using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class InformeProduccionM
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Pliego { get; set; }
        public string Planificado { get; set; }
        public string Producido { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string Maquina { get; set; }
        public string CodMaquina { get; set; }
        public string Operador { get; set; }
        public string VerMas { get; set; }
        public string Proceso { get; set; }
        public string Observacion { get; set; }
        public string Buenos { get; set; }
        public string DesperdicioAcerto { get; set; }
        public string DesperdicioVirando { get; set; }
        public string DAcerto { get; set; }
        public string DVirando { get; set; }
        public string Tipo { get; set; }
        public string Horas { get; set; }
        public string Clasificacion { get; set; }
        
    }
}