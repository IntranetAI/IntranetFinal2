using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class Factura
    {
        public int ID_Factura { get; set; }
        public int NFactura { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public int Cantidad { get; set; }
        public string Proceso { get; set; }
        public string Costo { get; set; }
        public string Observacion { get; set; }
        public string Tipo { get; set; }
        public string Formato { get; set; }
        public double PrecioUnit { get; set; }
        public string Barniz { get; set; }
        public string M2 { get; set; }
        public string Usuario { get; set; }
        public string Action { get; set; }

        public string Rut { get; set; }
        public string Cant { get; set; }
        public string Nombre { get; set; }
        public string Sucursal { get; set; }
        public string Comuna { get; set; }
        public string Ciudad { get; set; }
        public string Unidad { get; set; }
        public string Total { get; set; }
    }
}