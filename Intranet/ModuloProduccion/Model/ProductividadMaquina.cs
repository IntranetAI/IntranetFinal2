using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class ProductividadMaquina
    {
        public string NombreMaquina { get; set; }
        public string DiasSemana { get; set; }
        public double TotalHoras { get; set; }
        public double HorasPreparacion { get; set; }
        public double HorasTiraje { get; set; }
        public double HorasImproductivo { get; set; }
        public int GirosImpresion { get; set; }
        public int GirosImpresionSemana { get; set; }
        public int Pliegos_Impresos { get; set; }
        public int Entradas { get; set; }
        public int EntrdasSemana { get; set; }
        public double MinporPreparacion { get; set; }
        public int ImpresionporPreparacion { get; set; }
        public string Utilizacion { get; set; }
        public string Uptime { get; set; }
        public int ImpresionTiraje { get; set; }
        public int GirosporHorasTotales { get; set; }
        public double Imp_Almuerzo { get; set; }
        public double Imp_Operacion { get; set; }
        public double Imp_Preprensa { get; set; }
        public double Imp_Papel { get; set; }
        public double Imp_Mantenimiento { get; set; }
        public double Imp_SinTrabajo { get; set; }
    }
}