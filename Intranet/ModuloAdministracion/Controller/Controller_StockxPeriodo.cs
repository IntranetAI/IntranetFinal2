using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloAdministracion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloAdministracion.Controller
{
    public class Controller_StockxPeriodo
    {
        public List<StockxPeriodo> ListarStock(int Mes, int Año, string Informe)
        {
            List<StockxPeriodo> lista = new List<StockxPeriodo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Adm_StockxPeriodo";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Mes", Mes);
                    cmd.Parameters.AddWithValue("@Año", Año);
                    cmd.Parameters.AddWithValue("@Informe", Informe);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StockxPeriodo stock = new StockxPeriodo();
                        stock.CodItem = reader["CodItem"].ToString();
                        stock.Descricao = reader["Descricao"].ToString();
                        stock.Familia = reader["Familia"].ToString();
                        if (Informe != "Insumos")
                        {
                            stock.SubFamilia = reader["Sub_Familia"].ToString();
                            stock.Altura = reader["Altura"].ToString();
                            stock.Largura = reader["Largura"].ToString();
                            stock.gramatura = reader["gramatura"].ToString();
                        }
                        stock.CostoMedio = reader["CostoMedio"].ToString();
                        stock.SaldoInicial = reader["SaldoInicial"].ToString();
                        stock.Compra = reader["Compra"].ToString();
                        stock.PrecioCompra = reader["PrecioCompra"].ToString();
                        if (Informe != "Pliegos")
                        {
                            stock.SaldoTotalIngreso = reader["SaldoTotalIngreso"].ToString();
                        }
                        if(Informe != "Tintas")
                        {
                            stock.EgresoProceso = reader["EgresoProceso"].ToString();
                            stock.ValorEgresoProceso = reader["ValorEgresoProceso"].ToString();
                        }
                        stock.ConsumoOT = reader["ConsumoOT"].ToString();
                        stock.DevoluProceso = reader["DevoluProceso"].ToString();
                        stock.SaldoFinal = reader["SaldoFinal"].ToString();
                        stock.Inventarioinicial = reader["Inventarioinicial"].ToString();
                        stock.ValorCompra = reader["ValorCompra"].ToString();
                        stock.valorIngresoTotal = reader["valorIngresoTotal"].ToString();
                        stock.ValorDevoluProceso = reader["ValorDevoluProceso"].ToString();
                        stock.ValorConsumoOT = reader["ValorConsumoOT"].ToString();
                        stock.ValorFinalPesos = reader["SaldoFinalPesos"].ToString();
                        if (Informe == "Bobinas")
                        {
                            stock.Egreso = reader["Egreso"].ToString();
                            stock.Transformacion = reader["Transformacion"].ToString();
                            stock.Valor_Ajuste_Entrada_Egresos = reader["Valor_Ajuste_Entrada_Egresos"].ToString();
                            stock.Valor_Ajuste_Salida_Egresos = reader["Valor_Ajuste_Salida_Egresos"].ToString();
                            stock.Valor_Financiero_Negativo = reader["Ajuste_Financiero_Negativo"].ToString();
                            stock.Valor_financiero_Positivo = reader["Ajuste_financiero_Positivo"].ToString();
                            stock.valorTransformacion = reader["valorTransformacion"].ToString();
                        }
                        else if (Informe == "Pliegos")
                        {
                            stock.SaldoInicial_Kilos = reader["SaldoInicial_Kilos"].ToString();
                            stock.Compra_En_Kilos = reader["Compra_En_Kilos"].ToString();
                            stock.EgresoProceso_En_Kilos = reader["EgresoProceso_En_Kilos"].ToString();
                            stock.ConsumoOT_En_Kilos = reader["ConsumoOT_En_Kilos"].ToString();
                            stock.DevoluProcesoKilos = reader["DevoluProcesoKilos"].ToString();
                            stock.SaldoFinalKilos = reader["SaldoFinalKilos"].ToString();
                        }
                        else if (Informe == "Insumos")
                        {
                            stock.Unidad = reader["UnidadeEst"].ToString();
                            stock.Mermas_Por_Conversion = reader["Mermas_Por_Conversion"].ToString();
                            stock.Mermas_Por_Conversion_Pesos = reader["Mermas_Por_Conversion_Pesos"].ToString();
                        }

                        lista.Add(stock);
                    }
                }
                catch
                {
                }
            }
            return lista;
        }
    }
}