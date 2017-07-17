using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloWip.Model
{
    public class Wip
    {
        public string ID_Control { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario { get; set; }
        public string Ubicacion { get; set; }
        public string Posicion { get; set; }
        public string ProxProceso { get; set; }
        public string Maquina { get; set; }
        public double PesoPallet { get; set; }
        public int PliegosImpresos { get; set; }
        public int EstadoPallet { get; set; }
        public int Tiraje { get; set; }
        public string Pliego { get; set; }
    }
}