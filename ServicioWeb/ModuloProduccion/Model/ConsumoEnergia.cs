using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.ModuloProduccion.Model
{
    public class ConsumoEnergia
    {
        public int Id { get; set; }
        public string IdApontamento { get; set; }
        public string Ot { get; set; }
        public string Pliego { get; set; }
        public double Consumo { get; set; }
    }
}