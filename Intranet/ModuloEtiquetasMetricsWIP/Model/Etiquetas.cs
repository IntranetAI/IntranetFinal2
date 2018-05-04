using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloEtiquetasMetricsWIP.Model
{
    public class Etiquetas
    {
        public string ObjId { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public int Tiraje { get; set; }
        public int Buenos { get; set; }
        public int CantidadPallets { get; set; }
        public string Maquina { get; set; }
        public string Accion { get; set; }
        public string FechaInicio { get; set; }
        public string Pliego { get; set; }
        public string FechaCreacion { get; set; }
        public string Cliente { get; set; }
        public string Tiraje2 { get; set; }
        public string Elemento { get; set; }
        public string Actividad { get; set; }
        public string ProximaActividad { get; set; }
        public string Observacion { get; set; }
        public string Operador { get; set; }
        public string Peso { get; set; }
        public string Cantidad { get; set; }
        public string IdPallet { get; set; }

    }
}