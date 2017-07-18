using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.View.Model
{
    public class LoginSistema
    {
        public int idLogin { get; set; }
        public String user { get; set; }
        public String paswoord { get; set; }
        public int pin { get; set; }
        public int estado { get; set; }

        //
        public int? IDLogin { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int? Privilegios { get; set; }
        public string Correo { get; set; }
        //
        public string cargo { get; set; }
        public string CentroCosto { get; set; }
    }
}