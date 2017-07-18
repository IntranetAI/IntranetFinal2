using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloRFrecuencia.Model
{
    public class Inf_Regional
    {
        public string Maquina { get; set; }

        public string BobBueCant { get; set; }
        public string BobBueEsc { get; set; }
        public string BobBueProm { get; set; }
        public string BobBueProG { get; set; }

        public string BobRotCant { get; set; }
        public string BobRotEsc { get; set; }
        public string BobRotProm { get; set; }
        public string BobRotProG { get; set; }

        public string BobDetCant { get; set; }
        public string BobDetEsc { get; set; }
        public string BobDetProm { get; set; }
        public string BobDetProG { get; set; }

        public string BobOtrCant { get; set; }
        public string BobOtrEsc { get; set; }
        public string BobOtrProm { get; set; }
        public string BobOtrProG { get; set; }

        public string Turno { get; set; }
    }
}