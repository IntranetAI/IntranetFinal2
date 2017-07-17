using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Intranet.ModuloDespacho.Model
{
    public class Devoluciones
    {

        public string guia { get; set; }
        public string sucursal { get; set; }
        public string despachado { get; set; }
        public string FechaDespacho { get; set; }
        //
        public string TirajeOT { get; set; }
        public string id_Devolucion { get; set; }
        public string id_Guias { get; set; }
        public string id_TipoDev { get; set; }
        public string Folio { get; set; }
        public string OT { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public string CausaDevolucion { get; set; }
        public string Observacion { get; set; }
        public string Total_Dev { get; set; }

        public string TipoEmbalaje { get; set; }
        public string Cantidad { get; set; }
        //

        public string CreadaPor { get; set; }
        public string FechaCreacion { get; set; }
        public string GeneradaPor { get; set; }
        public string FechaGeneracion { get; set; }
        public string RecepcionadaPor { get; set; }
        public string FechaRecepcion { get; set; }
    }
}