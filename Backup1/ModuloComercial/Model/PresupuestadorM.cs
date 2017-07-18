using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloComercial.Model
{
    public class PresupuestadorM
    {
        public string Producto { get; set; }
        public string FormatoAbierto { get; set; }
        public string FormatoCerrado { get; set; }
        public string FormatoPagina { get; set; }
        public string PaginasxPliego { get; set; }
        public string CantidadPaginas { get; set; }
    }
}