using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class Analisis_Produccion_V2
    {
        public string Maquina { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Entradas { get; set; }
        public string Giros { get; set; }
        public string HorasPreparacion { get; set; }
        public string HorasTiraje { get; set; }
        public string HorasImproductivas { get; set; }
        public string Buenos { get; set; }
        public string MalosPreparacion { get; set; }
        public string MalosTiraje { get; set; }
    }
}