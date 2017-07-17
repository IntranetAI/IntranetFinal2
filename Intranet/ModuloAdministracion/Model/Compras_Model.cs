using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloAdministracion.Model
{
    public class Compras_Model
    {
        public string NroPedido { get; set; }
        public string Fecha_Orden { get; set; }
        public string Termino_Pago { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string Fecha_Entrega { get; set; }
        public string CodItem { get; set; }
        public string Descripcion { get; set; }
        public string CantidadSoli { get; set; }
        public string CantidadRecep { get; set; }
        public string Unidad { get; set; }
        public string Precio_Unit { get; set; }
        public string Total { get; set; }
        public string PrecioTotal { get; set; }
        public string Proveedor { get; set; }
        public string Estado { get; set; }
        public string ValorUnitario { get; set; }
    }
}