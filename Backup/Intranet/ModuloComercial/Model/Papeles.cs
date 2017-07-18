using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloComercial.Model
{
    public class Papeles
    {
        public int ID_Papel { get; set; }
        public int ID_Trimestre { get; set; }
        public string TipoPapel { get; set; }
        public string Marca { get; set; }
        public string NombrePapel { get; set; }
        public string Origen { get; set; }
        public int Gramaje { get; set; }
        public string Presentacion { get; set; }
        public double CostoPapelTonelada { get; set; }
        public double GastoBodega { get; set; }
        public double GastoImportacion { get; set; }
        public double CostoCIFUS { get; set; }
        public double BodegaSeguro { get; set; }
        public double Obsolencia { get; set; }
        public double CortePliego { get; set; }
        public double ValorBase { get; set; }
        public double InferiorCL { get; set; }
        public double FacturaCL { get; set; }
        public double SuperiorCL { get; set; }
        public string Empresas { get; set; }
        public string Componente { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string FechaModificacion { get; set; }
        public double ValorTrimestre { get; set; }
    }
}