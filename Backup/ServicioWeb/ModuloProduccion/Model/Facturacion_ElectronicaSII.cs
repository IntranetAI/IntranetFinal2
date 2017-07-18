using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Model
{
    public class Facturacion_ElectronicaSII
    {
        public string Nfactura { get; set; }
        public string giro { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Vendedor { get; set; }
        public string Guias { get; set; }
        public string IDTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Fecha_Creacion { get; set; }
        public string RutCliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Valor_Neto { get; set; }
        public string Valor_total { get; set; }
        public string Valor_Iva { get; set; }
        public string CondicionVenta { get; set; }
        public string VerMas { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string ValorUnit { get; set; }
        public string ValorItemTotal { get; set; }
    }
}