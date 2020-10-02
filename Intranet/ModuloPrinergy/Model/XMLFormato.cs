using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloPrinergy.Model
{
    public class XMLFormato
    {
        public int Id { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Cliente { get; set; }
        public string NombreGrupo { get; set; }
        public int Paginas { get; set; }
        public int Inicio { get; set; }
        public int FormatoX { get; set; }
        public int FormatoY { get; set; }
        public string Formato { get; set; }
        public string Papel { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string XNota { get; set; }
        public string YNota { get; set; }
        public string ColorFlow { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string CSR { get; set; }
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