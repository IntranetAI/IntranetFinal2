using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloCotizadorTransporte.Model
{
    public class Ramales
    {
        public string IdRamal { get; set; }
        public string Ramal { get; set; }
        public string Ciudad { get; set; }
        public int Valor { get; set; }
        public string CreadoPor { get; set; }
        public string FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public string Opciones { get; set; }
    }
}