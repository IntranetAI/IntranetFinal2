using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloBodegaPliegos.Model
{
    public class OrdenesCompra
    {
        public string Rut { get; set; }
        public string Proveedor { get; set; }
        public string CodigoProveedor { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string CondicionPago { get; set; }
        public string FechaEntrega { get; set; }
        public string NroOC { get; set; }
        public string CodigoItem { get; set; }
        public string Papel { get; set; }
        public string Cantidad { get; set; }
        public string Moneda { get; set; }
        public string ValorMoneda { get; set; }
        public string ValorUnitario { get; set; }
        public string CostoTotal { get; set; }
        public string ComentarioItem { get; set; }
        public string ComentarioOrden { get; set; }


        public string StockKG { get; set; }
        public string Observacion { get; set; }
        public string ObservacionItem { get; set; }
        public string CantidadPliegos { get; set; }
        public string CantidadKG { get; set; }
        public string IVA { get; set; }
        public string TotalConIVA { get; set; }
        public string Direccion { get; set; }
        public string idProveedor { get; set; }
        public string Gramaje { get; set; }
        public string Ancho { get; set; }
        public string Largo { get; set; }
        public string ValorTotal { get; set; }
        public string ValorIVA { get; set; }
        public string ValorTotalConIVA { get; set; }
        public string FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public string idItem { get; set; }
        public string Accion { get; set; }
        public string Estado { get; set; }
        public string CantidadPliegosRecep { get; set; }
        public string CantidadKilosRecep { get; set; }
        public string NroFactura { get; set; }
        public string Unidad { get; set; }
    }
}