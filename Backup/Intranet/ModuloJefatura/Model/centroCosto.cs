using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloJefatura.Model
{
    public class centroCosto
    {
        public int IDArea { get; set; }
        public string NombreArea { get; set; }

        public int cod_CentroCosto { get; set; }
        public string CentroCosto { get; set; }

        public int IDArea_Centro { get; set; }
    }
}