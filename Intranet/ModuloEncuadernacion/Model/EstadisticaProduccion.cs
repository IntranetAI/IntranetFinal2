using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class EstadisticaProduccion
    {
        public string Mes { get; set; }
        public string OTS { get; set; }
        public string Entradas { get; set; }
        public string Preparacion { get; set; }
        public string PromPreparacion { get; set; }
        public string HorasTiraje { get; set; }
        public string ImprodOT { get; set; }
        public string Improd { get; set; }
        public string SinCarga { get; set; }
        public string EsperaMaterial { get; set; }
        public string TotalHoras { get; set; }
        public string PorcTiraje { get; set; }
        public string PorcSinCarga { get; set; }
        public string PorcSinProducir { get; set; }
        public string PorcEsperaMaterial { get; set; }
        public string Buenos { get; set; }
        public string TirajePromedio { get; set; }
        public string PorcBuenos { get; set; }
        public string MalosPreparacion { get; set; }
        public string MalosTiraje { get; set; }
        public string PorcMalosBuenos { get; set; }
        public string PromPersonal { get; set; }
        public string Velocidad { get; set; }
        public string RendPP { get; set; }
        public string RendImpro { get; set; }
    }
}