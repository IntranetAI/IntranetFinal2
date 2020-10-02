using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService_v2.ModuloProduccion.Model
{
    public class Factura
    {

        public string RutEmisor { get; set; }
        public string NombreEmisor { get; set; }
        public string Folio { get; set; }
        public string Linea { get; set; }
        public string NombreItem { get; set; }
        public string PrecioItem { get; set; }
        public string FechaEmision { get; set; }
        public string FechaVencimiento { get; set; }
        public string MontoNeto { get; set; }
        public string Impuesto { get; set; }
        public string MontoTotal { get; set; }
        public string Estado { get; set; }
        public string VerMas { get; set; }
        public string CantItem { get; set; }
        public string Mensaje { get; set; }
        public string CreadaPor { get; set; }

    }
}