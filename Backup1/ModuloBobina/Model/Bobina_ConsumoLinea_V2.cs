using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloBobina.Model
{
    public class Bobina_ConsumoLinea_V2
    {
        public string Maquina { get; set; }
        public double TotalBobinasConsumidas { get; set; }
        public double TotalKGConsumido { get; set; }
        public double TotalKGEscarpe { get; set; }
        public double PromedioEscarpe { get; set; }
        public double PorcentajeEscarpe { get; set; }
        public double BobinasBuenas { get; set; }
        public double BobinasMalas { get; set; }
        public double BobinasConProyecto { get; set; }
        public double KGConProyecto { get; set; }
        public double BobinasSinProyecto { get; set; }
        public double KGSinProyecto { get; set; }
        public double DanoAlmacen { get; set; }
        public double PorcDanoAlmacen { get; set; }
        public double DanoRollero { get; set; }
        public double PorcDanoRollero { get; set; }
        public double DanoProveedor { get; set; }
        public double PorcDanoProveedor { get; set; }
    }
}