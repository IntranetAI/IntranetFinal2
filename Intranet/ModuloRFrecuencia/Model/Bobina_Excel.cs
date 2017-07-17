using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloRFrecuencia.Model
{
    public class Bobina_Excel
    {
        public string OT { get; set; }
        public string Maquina { get; set; }
        public string NombreOT { get; set; }
        public string Total_B { get; set; }
        public string BBuenas { get; set; }
        public string BMalas_QG { get; set; }
        public string BMalas { get; set; }
        public string Peso_Original { get; set; }
        public string Pesos_Tapas { get; set; }
        // Para Completar Bobina
        public string Pesos_Conos { get; set; }
        public string Pesos_Escarpe { get; set; }
        public string Pesos_Envoltura { get; set; }

        public string Porc_Buenas { get; set; }
        public string Porc_Malas { get; set; }
        public string Porc_Perdida { get; set; }
        public string CProyecto { get; set; }
        public string SProyecto { get; set; }
        public string ProCProyec { get; set; }
        public string ProSProyec { get; set; }
        public string ConsumoMaquina { get; set; }
        public string Ancho { get; set; }
    }
}