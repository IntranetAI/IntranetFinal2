using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloAdministracion.Model
{
    public class Detalle
    {
        //public int factura { get; set; }
        public int SisCodOri { get; set; }
        public string Id_Funcionalidad { get; set; }
        public string EmpId { get; set; }
        public string DivCodigo { get; set; }
        public string UniCodigo { get; set; }
        public string CabOpeFecha { get; set; }
        public string IntPeriodo { get; set; }
        public string OpeCod { get; set; }
        public string CabOpeGlosa { get; set; }
        public string CabOpeNumero { get; set; }
        public string CabOpeLinea { get; set; }
        public string CtaCodigo { get; set; }
        public string MovCceGlosa { get; set; }
        public string pMonedaId { get; set; }
        public string CreCodigo { get; set; }
        public string CdiCodigo { get; set; }
        public string CfiCodigo { get; set; }
        public string pTprId { get; set; }
        public string PryNumero { get; set; }
        public string LineaProdCodigo { get; set; }
        public string EntRut { get; set; }
        public string EntSucNumero { get; set; }
        public string EntRutSec { get; set; }
        public string EntSucNumeroSec { get; set; }
        public string EntRutTer { get; set; }
        public string EntSucNumeroTer { get; set; }
        public string TdoId { get; set; }
        public string DocCceNumero { get; set; }
        public string DocCceFecEmi { get; set; }
        public string MovCceNumCuota { get; set; }
        public string MovCceFecVenc { get; set; }
        public string DocCceFecProyectada { get; set; }
        public string MovCceMontoImpuDebe { get; set; }
        public string MovCceMontoImpuHaber { get; set; }
        public string MovCceMontoLocalDebe { get; set; }
        public string MovCceMontoLocalHaber { get; set; }
        public string InstCod { get; set; }
        public string PlaCod { get; set; }
        public string RutBeneficiario { get; set; }
        public string pFormaPagoId { get; set; }
        public string UniCodigoEmi { get; set; }
        public string MovCceFecPagoPropuesta { get; set; }
        public string ClcId { get; set; }
        public string pCabReferenciaId { get; set; }
        public string  pDetReferenciaId { get; set; }
        public string MovCcePeriodo { get; set; }
        public string CodCtaCteBco { get; set; }
        public int id_tipo_documento_mercantil { get; set; }//new
        public double ValorPesDol { get; set; }
    }
}