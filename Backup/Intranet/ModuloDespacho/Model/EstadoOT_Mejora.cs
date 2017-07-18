using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class EstadoOT_Mejora
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string FechaMinima { get; set; }
        public string FechaMaxima { get; set; }
        public string Tiraje{ get; set; }
        public string Recepcionado { get; set; }
        public string Despachado { get; set; }
      
        public string DevolucionCliente { get; set; }
        public string Especiales { get; set; }
        public string Saldo { get; set; }
        public string Existencia { get; set; }
        public string Estado { get; set; }


        
        public string DevolucionInterna { get; set; }
        public string DevolucionGeneral { get; set; }
    }
}