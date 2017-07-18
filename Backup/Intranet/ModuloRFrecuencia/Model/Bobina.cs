using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloRFrecuencia.Model
{
    public class Bobina
    {
        public string Ubicacion { get; set; }
        public string Lote { get; set; }
        public string Proveedor { get; set; }
        public int Gramage { get; set; }
        public int Ancho { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public int Inicial { get; set; }
        public int Final { get; set; }

        // Para Completar Bobina
        public int ID_Bobina { get; set; }
        public string NumeroOp { get; set; }
        public DateTime Fecha_Consumo { get; set; }
        public int Peso_Original { get; set; }
        public double Peso_Tapa { get; set; }
        public double Peso_emboltorio { get; set; }
        public double PesoEscarpe { get; set; }
        public double Peso_Cono { get; set; }
        public int Saldo { get; set; }
        public int Estado_Bobina { get; set; }
        public int Responsable { get; set; }
        public Boolean Cierre { get; set; }
        public string pliego { get; set; }
        public string Porc_Perdida { get; set; }
        public string Porc_Buenas { get; set; }
        public string Porc_Malas { get; set; }
        public string VerMas { get; set; }
        public string Cono { get; set; }

    }
}