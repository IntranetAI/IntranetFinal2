using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Model
{
    public class Pedidos
    {
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string CodProducto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int Total { get; set; }
        public int Tipo { get; set; }
        public string CSR { get; set; }
        public string Vendedor { get; set; }
        public string Suscritos { get; set; }
        public DateTime FechaGV { get; set; }
    }
}