using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet.ModuloAdministracion.Model
{
    public class StockxPeriodo
    {
        public string CodItem { get; set; }
        public string Descricao { get; set; }
        public string Familia { get; set; }
        public string SubFamilia { get; set; }
        public string Altura { get; set; }
        public string Largura { get; set; }
        public string gramatura { get; set; }
        public string CostoMedio { get; set; }
        public string SaldoInicial { get; set; }
        public string Compra { get; set; }
        public string PrecioCompra { get; set; }
        public string Egreso { get; set; }//Solo en Bobinas
        public string SaldoTotalIngreso { get; set; }
        public string Transformacion { get; set; }//Solo en Bobinas
        public string EgresoProceso { get; set; }
        public string ConsumoOT { get; set; }
        public string DevoluProceso { get; set; }
        public string SaldoFinal { get; set; }
        public string Inventarioinicial { get; set; }
        public string ValorCompra { get; set; }
        public string valorIngresoTotal { get; set; }
        public string Valor_Ajuste_Entrada_Egresos { get; set; }//Solo en Bobinas
        public string Valor_Ajuste_Salida_Egresos { get; set; }//Solo en Bobinas
        public string Valor_Financiero_Negativo { get; set; }//Solo en Bobinas
        public string Valor_financiero_Positivo { get; set; }//Solo en Bobinas
        public string ValorEgresoProceso { get; set; }
        public string ValorDevoluProceso { get; set; }
        public string ValorConsumoOT { get; set; }
        public string valorTransformacion { get; set; }//Solo en Bobinas
        public string ValorFinalPesos { get; set; }

        public string SaldoInicial_Kilos { get; set; }//Solo en Pliegos
        public string Compra_En_Kilos { get; set; }//Solo en Pliegos
        public string EgresoProceso_En_Kilos { get; set; }//Solo en Pliegos
        public string ConsumoOT_En_Kilos { get; set; }//Solo en Pliegos
        public string DevoluProcesoKilos { get; set; }//Solo en Pliegos
        public string SaldoFinalKilos { get; set; }//Solo en Pliegos

        public string Unidad { get; set; }//Solo en Insumo
        public string Mermas_Por_Conversion { get; set; }//Solo en Insumo
        public string Mermas_Por_Conversion_Pesos { get; set; }//solo en Insumo

    }
}