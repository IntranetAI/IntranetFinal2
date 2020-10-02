using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Model
{
    public class JsonHistorial_Salida
    {
        public string Usuario { get; set; }
        public string Fecha { get; set; }
        public string Json { get; set; }
        public int IDError { get; set; }
        public string OT { get; set; }
    }
}