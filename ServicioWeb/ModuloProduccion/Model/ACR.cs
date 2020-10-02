using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Model
{
    public class ACR
    {
        public string OT { get; set; }
        public string Centro { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public DateTime Fecha { get; set; }
    }
    public class ValorACR
    {
        public string Proceso { get; set; }
        public int Valor { get; set; }
    }
}