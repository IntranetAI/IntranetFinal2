using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Model
{
    public class FechaDistribuccion
    {
        public int ID { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string FechaPrevista { get; set; }
        public double Cantidad { get; set; }
        public string TipoReparto { get; set; }
        public string Destinatario { get; set; }
        public string Direccion { get; set; }
        public string Observacion { get; set; }
        public string MedioTransporte { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Correo { get; set; }
        public string Proceso { get; set; }
        public DateTime FechaGV { get; set; }
        public DateTime FechaGVFinal { get; set; }
    }
}