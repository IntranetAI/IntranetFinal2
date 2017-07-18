using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class Orden
    {
        public string NumeroOT { get; set; }
        public string NombreOT { get; set; }
        public DateTime? FechaOT { get; set; }
        public string NombreCliente { get; set; }
        public int ejem { get; set; }
        public string Ejemplares { get; set; }
        public DateTime? FechaLiqui { get; set; }
        public string NombreVendedor { get; set; }
        public string NombreCSRot { get; set; }
        public DateTime? FechaOV { get; set; }
        public string FechaSoli { get; set; }
        public string StatusOV { get; set; }
        public int EstadoOT { get; set; }
        public DateTime? FechaPro { get; set; }
        public string CantidadMensaje { get; set; }
        public string Usuario { get; set; }
        public string Observacion { get; set; }
        public string NivelCumpli { get; set; }
        public string Despacho { get; set; }
        public DateTime FechaHoy { get; set; }
        public Boolean Porc_Depacho { get; set; }
        public DateTime? Fecha_Des { get; set; }
        public int? proalinear { get; set; }

        //enlace con mensajeria
        public string mensajeLeido { get; set; }
        public string mensajeNuevos { get; set; }
        public string mensajeAdjunto { get; set; }
    }
}