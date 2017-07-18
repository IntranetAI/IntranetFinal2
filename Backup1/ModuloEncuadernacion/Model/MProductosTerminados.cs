using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class MProductosTerminados
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Tiraje { get; set; }
        public string Despachado { get; set; }
        public string Saldo { get; set; }
        public string CantPallet { get; set; }
        public string CantCajas { get; set; }
        public string VerDetalle { get; set; }
        public string Devolucion { get; set; }
    }
}