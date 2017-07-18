using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloComercial.Model
{
    public class Papeles_Export
    {
        public string TipoPapel { get; set; }
        public string Marca { get; set; }
        public string NombrePapel { get; set; }
        public string Origen { get; set; }
        public string Gramaje { get; set; }
        public string Presentacion { get; set; }
        public string CostoPapelTonelada { get; set; }
        public string GastoBodega { get; set; }
        public string GastoImportacion { get; set; }
        public string CostoCIFUS { get; set; }
        public string BodegaSeguro { get; set; }
        public string Obsolencia { get; set; }
        public string CortePliego { get; set; }
        public string ValorBase { get; set; }
        public string InferiorCL { get; set; }
        public string FacturaCL { get; set; }
        public string SuperiorCL { get; set; }
        public string Empresas { get; set; }
        public string Componente { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string FechaModificacion { get; set; }
        public string ValorTrimestre { get; set; }
    }
}