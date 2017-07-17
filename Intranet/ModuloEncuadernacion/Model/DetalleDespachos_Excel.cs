using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class DetalleDespachos_Excel
    {
        public string Pallet { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Embalaje { get; set; }
        public string CantBultos { get; set; }
        public string EjemplaresxBulto { get; set; }
        public string TotalEjemplares { get; set; }
        public string Responsable { get; set; }
        public string Fecha { get; set; }
        public string Tiraje { get; set; }
    }
}