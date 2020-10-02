using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Model
{
    public class XMLMetrics
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string EstadoCliente { get; set; }
        public int EnvioCorreo { get; set; }
        public string CSR { get; set; }
        public string CorreoCSR { get; set; }
        public string ClienteNuevo { get; set; }
    }
    public class XMLMetrics_Detalle
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string Proceso { get; set; }
        public string Papel { get; set; }
        public int Paginas { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string ModeloTracado { get; set; }
        public int Xnota { get; set; }
        public int Ynota { get; set; }
        public string ColorFlow { get; set; }
        public bool MultiplePapel { get; set; }
    }
    public class Homologacion
    {
        public string ClienteMetrics { get; set; }
        public string ClientePrinergy { get; set; }
        public string Keyword { get; set; }
    }
    public class PaginasInicio
    {
        public string Cliente { get; set; }
        public string Keyword { get; set; }
        public int Pagina { get; set; }

    }
    public class APA_Clientes
    {
        public string Cliente { get; set; }
        public string Keyword { get; set; }
        public string APA { get; set; }
    }
 
}