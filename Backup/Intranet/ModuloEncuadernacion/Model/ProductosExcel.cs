using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class ProductosExcel
    {
        public string id_DespProducto { get; set; }
        public string OP { get; set; }
        public string NombreOP { get; set; }
        public string Terminacion { get; set; }
        public string TipoEmbalaje { get; set; }
        public string Total { get; set; }
        public string FechaCreacion { get; set; }
        public string validado { get; set; }
        public string fechavalidacion { get; set; }
        public string Modificado { get; set; }
    }
}