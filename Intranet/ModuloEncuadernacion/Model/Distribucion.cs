using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class Distribucion
    {
        public string Gerencia { get; set; }
        public string Sector { get; set; }
        public string Destinatario { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public DateTime Retiro { get; set; }
        public string Fecha_Retiro { get; set; }
        public string Nombre_Cajas { get; set; }
        public string Caja_Revista { get; set; }
        public string Caja_EnsobradoCantidad { get; set; }
        public string caja_ensobrado { get; set; }
        public string CodigoBarra { get; set; }
        public string Marca { get; set; }
        public string Estado { get; set; }
    }
}