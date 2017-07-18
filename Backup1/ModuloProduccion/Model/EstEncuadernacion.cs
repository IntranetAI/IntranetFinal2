using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class EstEncuadernacion
    {
        public string Mes { get; set; }
        public string Maquina { get; set; }
        public string OTS { get; set; }
        public string Entradas { get; set; }
        public string HorasPreparacion { get; set; }
        public string HorasPreparacionPromedio { get; set; }
        public string HorasImproductivas { get; set; }
        public string HorasSinTrabajo { get; set; }
        public string HorasSinPersonal { get; set; }
        public string HorasMantencion { get; set; }
        public string EsperaMaterial { get; set; }
        public string TotalHoras { get; set; }
        public string PorcProduciendo { get; set; }
        public string PorcSinCarga { get; set; }
        public string PorcSinProducir { get; set; }
        public string PorcEsperaMaterial { get; set; }
        public string HorasTiraje { get; set; }
        public string Buenos { get; set; }
        public string BuenosPromedio { get; set; }
        public string PorcBuenosMalos { get; set; }
        public string Velocidad { get; set; }
        public string RendPP { get; set; }
        public string RendImp { get; set; }
        public string PliegosMalosPreparacion { get; set; }
        public string PliegosMalosTiraje { get; set; }

    }
}