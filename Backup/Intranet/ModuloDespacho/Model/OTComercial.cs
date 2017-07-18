using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class OTComercial
    {
        public string id_Envio { get; set; }
        public string Folio { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string TirajeOT { get; set; }
        public string CantidadEnviada { get; set; }
        public string Peso { get; set; }
        public string Descripcion { get; set; }
        public string EnviadaPor { get; set; }
        public string FechaEnvio { get; set; }
        public string RecepcionadoPor { get; set; }
        public string FechaRecepcion { get; set; }
        public string Estado { get; set; }
    }
}