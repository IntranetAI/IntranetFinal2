using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class PartesDeProduccion
    {
        public string ID_Maquina { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string TirajeOT { get; set; }
        public string Cliente { get; set; }
        public string Forma { get; set; }
        public string Pliegos { get; set; }
        public string Maquina { get; set; }
        public string Giros_Buenos { get; set; }
        public string Buenos { get; set; }
        public string Malos { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string VerMas { get; set; }
        public string Malos_Arranque { get; set; }
        public string ID_SECCION { get; set; }
        public string NOMBRE_SECCION { get; set; }

    }
}