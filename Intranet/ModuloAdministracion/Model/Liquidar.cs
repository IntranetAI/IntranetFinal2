using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloAdministracion.Model
{
    public class Liquidar
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string Tiraje { get; set; }
        public string FechaLiquidacion { get; set; }
        public string FechaFactura { get; set; }
        public string EstadoOT { get; set; }
        public string TotalDesp { get; set; }
        public string numeroFactura { get; set; }
        public string ValorNeto { get; set; }
        public string VerMas { get; set; }
        public string Accion { get; set; }
    }
}