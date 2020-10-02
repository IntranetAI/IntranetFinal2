using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Model
{
    public class PliegosFinalizados
    {
        public string Maquina { get; set; }
        public string Sector { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Pliego { get; set; }
        public int Buenos { get; set; }
        public int Planficado { get; set; }

    }
}