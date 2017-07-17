using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloRFrecuencia.Model
{
    public class Indigo
    {
        public int ID_Indigo { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Maquina { get; set; }
        public string Pliego { get; set; }
        public string Papel { get; set; }
        public int Tiraje { get; set; }
        public string Color { get; set; }
        public int ClickInicio { get; set; }
        public int ClickFinal { get; set; }
        public int CantidadClick { get; set; }
        public int Buenos { get; set; }
        public int Malos { get; set; }
        public string Formato { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
        public string Fecha { get; set; }
    }
}