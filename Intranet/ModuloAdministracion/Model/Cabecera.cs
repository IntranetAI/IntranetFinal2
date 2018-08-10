using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloAdministracion.Model
{
    public class Cabecera
    {
        public int SisCidOri { get; set; }
        public string Id_Funcionalidad { get; set; }
        public string EmpId{ get; set; }
        public string DivCodigo { get; set; }
        public string UniCodigo { get; set; }
        public string LlgDocFechaIng { get; set; }
        public string IntPeriodo { get; set; }
        public string OpeCod { get; set; }
        public string LlgDocGlosa { get; set; }
        public string LlgDocNumInterno { get; set; }
        public string LlgDocNumDoc { get; set; }
        public string LlgDocNumProvision { get; set; }
        public string EntRut { get; set; }
        public string EntSucNumero { get; set; }
        public string EntRutSec { get; set; }
        public string EntSucNumeroSec { get; set; }
        public string EntRutTer { get; set; }
        public string EntSucNumeroTer { get; set; }
        public string LlgDocFecha { get; set; }
        public string LlgDocFechaVenc { get; set; }
        public string pMonedaId { get; set; }
        public string LlgDocMtoImpuAfecto { get; set; }
        public string LlgDocMtoImpuNeto { get; set; }
        public string LlgDocMtoImpuExento { get; set; }
        public string LlgDocMtoImpuIva { get; set; }
        public string LlgDocMtoImpuOtrosImp { get; set; }
        public string LlgDocMtoImpuDerAdu { get; set; }
        public string LlgDocMtoImpuRete { get; set; }
        public string LlgDocMtoImpuTotal { get; set; }
        public string LlgDocMtoLocalAfecto { get; set; }
        public string LlgDocMtoLocalNeto { get; set; }
        public string LlgDocMtoLocalExento { get; set; }
        public string LlgDocMtoLocalIva { get; set; }
        public string LlgDocMtoLocalOtrosImp { get; set; }
        public string LlgDocMtoLocalDerAdu { get; set; }
        public string LlgDocMtoLocalRete { get; set; }
        public string LlgDocMtoLocalTotal { get; set; }
        public string DocCceDocRef { get; set; }
        public string LlgDocMtoIvaRec100 { get; set; }
        public string LlgDocMtoIvaRecPro { get; set; }
        public string LlgDocMtoIvaNoRec { get; set; }
        public string ClaIvaId { get; set; }

    }
}