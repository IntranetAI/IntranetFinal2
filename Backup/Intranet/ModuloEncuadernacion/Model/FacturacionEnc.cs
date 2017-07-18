using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEncuadernacion.Model
{
    public class FacturacionEnc
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Tiraje { get; set; }
        public string DespachadoEnc { get; set; }
        public string RecepcionadoDespacho { get; set; }
        public string Devolucion { get; set; }
        public string FechaEntrega { get; set; }
        public string Saldo { get; set; }
        public string Estado { get; set; }
        public string VerMas { get; set; }


        public string Cod_Pallet { get; set; }
        public string Terminacion { get; set; }
        public string TipoEmbalaje { get; set; }
        public string Cantidad { get; set; }
        public string Ejemplares { get; set; }
        public string Total { get; set; }
        public string Modelo { get; set; }
        public string Observacion { get; set; }
        public string FechaCreacion { get; set; }
        public string Proceso { get; set; }
        public string ValorUnitario { get; set; }
        public DateTime Fecha { get; set; }
        public string Maquina { get; set; }
        public string idMaquina { get; set; }
        public string ProcesoReal { get; set; }
        public string Material { get; set; }
        public string CantidadDesp { get; set; }
        public string CantidadDespOriginal { get; set; }
        public string Ejemplar { get; set; }
        public string Usuario { get; set; }
        public string NroPreFactura { get; set; }
        public string Facturado { get; set; }
    }
}