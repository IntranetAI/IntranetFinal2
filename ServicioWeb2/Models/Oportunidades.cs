using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb2.Models
{
    public class Oportunidades
    {
        public string NombreOportunidad { get; set; }
        public string NombreCliente { get; set; }
        public Int64 Monto { get; set; }
        public string EtapaVentas { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaProduccion { get; set; }
        public string Asignado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
    public class Reuniones
    {
        public string Asunto { get; set; }
        public string Estado { get; set; }
        public string Relacion { get; set; }
        public string relacionado { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Asignado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
    public class Cuentas
    {
        public string NombreCuenta { get; set; }
        public string RUT { get; set; }
        public string TipoCuenta { get; set; }
        public string Vertical { get; set; }
        public string Segmento { get; set; }
        public string Asignado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
    public class Ejecutivos
    {
        public string UsuarioEjecutivo { get; set; }
        public string NombreEjecutivo { get; set; }
    }     
}