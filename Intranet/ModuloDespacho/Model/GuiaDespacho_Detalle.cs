using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloDespacho.Model
{
    public class GuiaDespacho_Detalle
    {
        public int ID_Guia { get; set; }
        public string Rut { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Proveedor { get; set; }
        public int  Nfactura { get; set; }
        public string Sucursal { get; set; }
        public string Embalaje { get; set; }
        public int Cant_Bulto { get; set; }
        public int CantXBulto { get; set; }
        public string Comuna { get; set; }
        public string Usuario { get; set; }
    }
}