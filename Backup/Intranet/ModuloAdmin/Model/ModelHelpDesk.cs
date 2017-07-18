using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloAdmin.Model
{
    public class ModelHelpDesk
    {
        public int IDHelpDesk { get; set; }
        public int IDTipoIncidencia { get; set; }
        public int IDIncidencia { get; set; }
        public string Incidencia { get; set; }
        public string FeInicio { get; set; }
        public string FeIncidencia { get; set; }
        public string FeProceso { get; set; }
        public string FeSolucion { get; set; }
        public string NivelIncidencia { get; set; }
        public string Usuario { get; set; }
        public string Area { get; set; }
        public string Depto { get; set; }
        public string Encargado { get; set; }
        public string CorreoEncargado { get; set; }
        public string Observacion { get; set; }
        public string Solucion { get; set; }
        public string NombreArchivo { get; set; }
        public int Estado { get; set; }
    }
}