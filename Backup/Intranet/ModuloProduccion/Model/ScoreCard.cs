using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class ScoreCard
    {
        public string Maquina { get; set; }
        public string OT { get; set; }
        public string Pliego { get; set; }
        public string Planchas { get; set; }     
        public string Colores { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string Entradas { get; set; }
        public string Planificado { get; set; }
        public string Giros { get; set; }
        public string Buenos { get; set; }
        public string HorasPreparacion { get; set; }
        public string HorasTiraje { get; set; }
        public string HorasImproductivas { get; set; }
        //public string HorasSinTrabajo { get; set; }
        //public string HorasSinPersonal { get; set; }
        //public string HorasMantencion { get; set; }
        public string MermaArranque { get; set; }
        public string MermaTiraje { get; set; }
        //public string CantidadOperadores { get; set; }

        //public string Preparaciones { get; set; }
        //public string HorasDisponibles { get; set; }
        public string VPromedio { get; set; }
        public string Uptime { get; set; }

        public string HorasDirectas { get; set; }
        public string CodRecurso { get; set; }
        //public string Escarpe { get; set; }
        //public string Cono { get; set; }
        //public string ConsumoPapel { get; set; }
       
    }
}