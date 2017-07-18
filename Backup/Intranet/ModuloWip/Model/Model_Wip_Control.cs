using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloWip.Model
{
    public class Model_Wip_Control
    {
        public string ID_Control { get; set; }
        public string OT { get; set; }
        public string NombreOT { get; set; }
        public string Pliego { get; set; }
        public string Forma { get; set; }
        public string Tarea { get; set; }
        public string Maquina { get; set; }
        public string Maquina_Proceso { get; set; }
        public int TotalTiraje { get; set; }
        public int Pliegos_Impresos { get; set; }
        public Double Peso_pallet { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public string Usuario { get; set; }
        public string Ant_Proceso { get; set; }
        public string Prox_Proceso { get; set; }
        public int Estado_Pallet { get; set; }
        public string Estado_Pallet2 { get; set; }
        public string Ubicacion { get; set; }
        public string Posicion { get; set; }
        public int IDTipoPallet { get; set; }
        public string TipoPallet { get; set; }
        public string VerMas { get; set; }
    }
}