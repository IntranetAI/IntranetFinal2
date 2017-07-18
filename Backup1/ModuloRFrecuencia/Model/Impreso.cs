using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloRFrecuencia.Model
{
    public class Impreso
    {
        public string OT { get; set; }
        public string Maquina { get; set; }
        public string Operacion { get; set; }
        public string valocMaquina { get; set; }
        public string Desarrollo { get; set; }
        public string Malas { get; set; }
        public string Horas { get; set; }
        public string velocTiraje { get; set; }
        //IdAtiv,Description
        public int IdAtiv { get; set; }
        public string Description { get; set; }
    }
}