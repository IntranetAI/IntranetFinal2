using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloComercial.Model
{
    public class Valor_TrimestreQ
    {
        public int ID_Trimestre { get; set; }
        public string  NombreTrimestre { get; set; }
        public double ValorTrimestre { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string Estado { get; set; }
        public string UsuarioCreador { get; set; }
    }
}