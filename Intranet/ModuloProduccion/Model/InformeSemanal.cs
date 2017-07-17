using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class InformeSemanal
    {
        public string Semana { get; set; }
        public string Maquina { get; set; }
        public string Entradas { get; set; }
        public string HorasPreparacion { get; set; }
        public string PromedioPreparacion { get; set; }
        public string HorasTiraje { get; set; }
        public string HorasImproductivas { get; set; }
        public string Buenos { get; set; }
        public string Productividad { get; set; }
        public string Velocidad { get; set; }

        public string Noche { get; set; }
        public string PorcNoche { get; set; }
        public string Mañana { get; set; }
        public string PorcMañana { get; set; }
        public string Tarde { get; set; }
        public string PorcTarde { get; set; }
        public string Generales { get; set; }

        public string Dia { get; set; }
        public string Corona { get; set; }
        public string PorcCorona { get; set; }
        public string Nordbinder { get; set; }
        public string PorcNordbinder { get; set; }
        public string Muller1 { get; set; }
        public string PorcMuller1 { get; set; }
        public string Muller2 { get; set; }
        public string PorcMuller2 { get; set; }
        public string MullerPrima { get; set; }
        public string PorcMullerPrima { get; set; }
        public string TotalProducido { get; set; }
        public string PorcTotalProducido { get; set; }

    }
}