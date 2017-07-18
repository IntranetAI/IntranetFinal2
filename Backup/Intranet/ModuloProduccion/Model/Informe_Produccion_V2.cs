using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class Informe_Produccion_V2
    {
        public string Semana { get; set; }
        public string Maquina { get; set; }
        public string Giros { get; set; }
        public string Buenos { get; set; }
        public string Entradas { get; set; }
        public string HorasTiraje { get; set; }
        public string HorasImproductivas { get; set; }
        public string HorasPreparacion { get; set; }
        public string HorasSinTrabajo { get; set; }
        public string HorasSinPersonal { get; set; }
        public string HorasMantencion { get; set; }
        public string HorasPruebaImpresion { get; set; }
        public string GirosMalosPreparacion { get; set; }
        public string PliegosMalosPreparacion { get; set; }
        public string GirosMalosTiraje { get; set; }
        public string PliegosMalosTiraje { get; set; }
    }
}