using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class Prod_Terminados
    {
        public string id_ProductosTerminados { get; set; }
        public string id_Operario { get; set; }
        public string cod_pallet { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Terminacion { get; set; }
        public string TipoEmbalaje { get; set; }
        public string Cantidad { get; set; }
        public string Ejemplares { get; set; }
        public string Total { get; set; }
        public string FechaCreacion { get; set; }
        public string ValidadoPor { get; set; }
        public string FechaValidacion { get; set; }
        public string Modificado { get; set; }
        public string MotivoDevolucion { get; set; }
        public string RecepcionadoPor { get; set; }
        public string FechaRecepcion { get; set; }
        public string Ubicacion { get; set; }
        public string MotivoDevolucionRecepcion { get; set; }
        public string Estado { get; set; }

        public string NombreOperario { get; set; }
        public string Maquina { get; set; }
        public string Proceso { get; set; }

        public string Modelo { get; set; }
        public string Observacion { get; set; }
    }
}