using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracion.ModuloIntegracion.Model
{
    public class Documento
    {
        public int IDDocMercantil { get; set; }
        //public int FolioPreFactura { get; set; }
        public int FolioFactura { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime fechaEmision { get; set; }
        //public string RutCliente { get; set; }
        //public int IDTipoCliente { get; set; }
        public string NombreCliente { get; set; }
        //public int Clasificacion { get; set; }
        public int IDTipoDocMerca { get; set; }
        public string NombreTipoDocMer { get; set; }
        public Double valorNeto { get; set; }
        public int IDTipoCambio { get; set; }
        public int rut_cliente { get; set; }
        public int IDProducto { get; set; }
        public string NombreConceCon { get; set; }
        public string NombreCuenta { get; set; }
        public string NombreCosto { get; set; }
        public double TipoCambio { get; set; }
    }
}