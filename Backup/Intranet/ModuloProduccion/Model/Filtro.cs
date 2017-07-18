using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class Filtro
    {
        public String numeroOT { get; set; }
        public String nombreOT { get; set; }
        public String nombreCliente { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public int filtro { get; set; }

        public String folio { get; set; }
        public String Solicitor { get; set; }
        public String Empresa { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime horaCreacion { get; set; }

        public String aprobador1 { get; set; }
        public DateTime fechaAprob1 { get; set; }

        public int IDEstado { get; set; }
        public string NombreEstado { get; set; }
             

        
    }
}