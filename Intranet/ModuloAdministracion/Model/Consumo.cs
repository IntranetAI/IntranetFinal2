using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloAdministracion.Model
{
    public class Consumo
    {
        public string Lote { get; set; }
        public string CodItem { get; set; }
        public string NombrePapel { get; set; }
        public string Gramage { get; set; }
        public string Ancho { get; set; }
        public string Largo { get; set; }
        public string Cons_Pliego { get; set; }
        public string Cons_Bobina { get; set; }
        public string Cons_Plancha { get; set; }
        public string Cons_Otros { get; set; }
        public string Certif { get; set; }
        public string CostUni { get; set; }
        public string Costtot { get; set; }
        public string Tipo { get; set; }
    }
}