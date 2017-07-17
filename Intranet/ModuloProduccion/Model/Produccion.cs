using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloProduccion.Model
{
    public class Produccion
    {
        public int IDProduccion { get; set; }
        public string ClienteOT { get; set; }
        public string FechaSolicitada { get; set; }
        public DateTime? FechaProduccion { get; set; }
        public int CantEjem { get; set; }

        public string NumeroOT { get; set; }
        public string NombreOT { get; set; }
        public string observacion { get; set; }
        public string FechaCSR { get; set; }
        public string color { get; set; }
        public string Ejemplares { get; set; }

        //Para listar en Listar Produccion en Gestion Despacho
        public string OrdenOT { get; set; }
        public string Tiraje { get; set; }
        public int TirajeProd { get; set; }
        public string cantidadDesp { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime HoraProduccion { get; set; }
        public string Usuario { get; set; }

        //Cantidad despachada segun fecha de entrega y despacho
        public string Cantidadgenerada { get; set; }
    }
}