using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class ProveedorMod
    {
        public string id_Proveedor { get; set; }
        public string id_ProcesoExterno { get; set; }
        public string Folio { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string NombrePliego { get; set; }
        public string Forma { get; set; }
        public string CantidadPliego { get; set; }
        public string TirajeOT { get; set; }
        public string ProcesoExterno { get; set; }       
        public string Total { get; set; }//cantidad enviada
        public string CantRecibida { get; set; }
        public string GeneradaPor { get; set; }
        public string FechaGeneracion { get; set; }
        public string RecepcionadaPor { get; set; }
        public string Estado { get; set; }

    }
}