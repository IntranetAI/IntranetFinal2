using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloAdministracion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloAdministracion.Controller
{
    public class Controller_Consumo
    {
        public List<Consumo> Listar(string OT)
        {
            List<Consumo> lista = new List<Consumo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_List_Consumo2";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumOrdem", OT);
                cmd.Parameters.AddWithValue("@Procedimiento", 0);
                SqlDataReader reader = cmd.ExecuteReader();
                int TotalBob = 0;
                int TotalPlg = 0;
                int TotalPlancha = 0;
                int TotalOtros = 0;
                double TotalCst = 0;
                while (reader.Read())
                {
                    Consumo cons = new Consumo();
                    cons.Lote = reader["Lote"].ToString();
                    cons.CodItem = reader["CodItem"].ToString();
                    cons.NombrePapel = reader["Material"].ToString();
                    cons.Gramage = reader["Gramage"].ToString();
                    cons.Ancho = reader["Ancho"].ToString();
                    cons.Largo = reader["Largo"].ToString();
                    cons.Certif = reader["Certificacion"].ToString() + " " + reader["Perc_Certificacion"].ToString() + " %";
                    //cons.Costtot = Convert.ToDouble(reader["valor"].ToString());
                    double unitario = Convert.ToDouble(reader["valorunitario"].ToString());
                    cons.CostUni = unitario.ToString("N2").Replace('.', ',');
                    double Total = Convert.ToDouble(reader["valor"].ToString());
                    try
                    {
                        string[] str = Total.ToString("N2").Split('.');
                        cons.Costtot = Total.ToString("N2");//str[0].ToString().Replace(',', '.') + "," + str[1];
                    }
                    catch
                    {
                        cons.Costtot = "0,00";
                    }
                    TotalCst = TotalCst + Convert.ToDouble(reader["valor"].ToString());
                    cons.Tipo = reader["Tipo"].ToString();
                    if (cons.Tipo == "Bobina")
                    {
                        cons.Cons_Bobina = Convert.ToInt32(reader["Cantidad"]).ToString("N0").Replace(",", ".") + " " + reader["Unidad"].ToString();
                        cons.Cons_Pliego = "0 FL";
                        TotalBob = TotalBob + Convert.ToInt32(reader["Cantidad"]);
                    }
                    else if (cons.Tipo == "Pliego")
                    {
                        cons.Cons_Pliego = Convert.ToInt32(reader["Cantidad"]).ToString("N0").Replace(",", ".") + " " + reader["Unidad"].ToString();
                        cons.Cons_Bobina = "0 KG";
                        TotalPlg = TotalPlg + Convert.ToInt32(reader["Cantidad"]);
                    }
                    else if (cons.Tipo == "Otro")
                    {
                        if (cons.CodItem.Contains("10.10"))
                        {
                            cons.Tipo = "Plancha";
                            cons.Cons_Plancha = Convert.ToInt32(reader["Cantidad"]).ToString("N0").Replace(",", ".") + " " + reader["Unidad"].ToString();
                            cons.Cons_Pliego = "0 FL";
                            cons.Cons_Bobina = "0 KG";
                            cons.Cons_Otros = "0 UN";
                            TotalPlancha = TotalPlancha + +Convert.ToInt32(reader["Cantidad"]);
                        }
                        else
                        {
                            cons.Tipo = "Otro";
                            cons.Cons_Otros = Convert.ToInt32(reader["Cantidad"]).ToString("N0").Replace(",", ".") + " " + reader["Unidad"].ToString();
                            cons.Cons_Pliego = "0 FL";
                            cons.Cons_Bobina = "0 KG";
                            cons.Cons_Plancha = "0 UN";
                            TotalOtros = TotalOtros + +Convert.ToInt32(reader["Cantidad"]);
                        }
                    }

                    lista.Add(cons);
                }
                //if (lista.Count > 0)
                //{
                //    if (!reader.Read())
                //    {
                //        Consumo cons = new Consumo();
                //        cons.Largo = "TOTAL";
                //        cons.Cons_Pliego = TotalPlg.ToString("N0").Replace(',','.') +" FL";
                //        cons.Cons_Bobina = TotalBob.ToString("N0").Replace(',', '.') +" KG";
                //        string[] str =TotalCst.ToString("N2").Split('.');
                //        cons.Costtot = str[0].ToString().Replace(',', '.') + "," + str[1];
                //        lista.Add(cons);
                //    }
                //}
                con.CerrarConexion();
            }
            return lista;
        }

        public List<Consumo> ListarReal(string OT)
        {
            List<Consumo> lista = new List<Consumo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_List_ConsReal";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumOrdem", OT);
                SqlDataReader reader = cmd.ExecuteReader();
                int TotalBob = 0;
                int TotalPlg = 0;
                double TotalCst = 0;
                while (reader.Read())
                {
                    Consumo cons = new Consumo();
                    cons.Lote = reader["Lote"].ToString();
                    cons.CodItem = "";//reader["CodItem"].ToString();
                    cons.NombrePapel = reader["Material"].ToString();
                    cons.Gramage = reader["Gramage"].ToString();
                    cons.Ancho = reader["Ancho"].ToString();
                    cons.Largo = reader["Largo"].ToString();
                    cons.Certif = "";//reader["Certificacion"].ToString() + " " + reader["Perc_Certificacion"].ToString() + " %";
                    //cons.Costtot = Convert.ToDouble(reader["valor"].ToString());
                    double unitario = Convert.ToDouble(reader["valorunitario"].ToString());
                    cons.CostUni = unitario.ToString("N2").Replace('.', ',');
                    double Total = Convert.ToDouble(reader["valor"].ToString());
                    string[] str = Total.ToString("N2").Split('.');
                    cons.Costtot = str[0].ToString().Replace(',', '.') + "," + str[1];
                    TotalCst = TotalCst + Convert.ToDouble(reader["valor"].ToString());

                    if (reader["Tipo"].ToString() == "Bobina")
                    {
                        cons.Cons_Bobina = Convert.ToInt32(Convert.ToDouble(reader["Cantidad"])).ToString("N0").Replace(",", ".") + " " + reader["Unidad"].ToString();
                        cons.Cons_Pliego = "0 FL";
                        TotalBob = TotalBob + Convert.ToInt32(reader["Cantidad"]);
                    }
                    else
                    {
                        cons.Cons_Pliego = Convert.ToInt32(reader["Cantidad"]).ToString("N0").Replace(",", ".") + " " + reader["Unidad"].ToString();
                        cons.Cons_Bobina = "0 KG";
                        TotalPlg = TotalPlg + Convert.ToInt32(reader["Cantidad"]);
                    }

                    lista.Add(cons);
                }
                if (lista.Count > 0)
                {
                    if (!reader.Read())
                    {
                        Consumo cons = new Consumo();
                        cons.Largo = "TOTAL";
                        cons.Cons_Pliego = TotalPlg.ToString("N0").Replace(',', '.') + " FL";
                        cons.Cons_Bobina = TotalBob.ToString("N0").Replace(',', '.') + " KG";
                        string[] str = TotalCst.ToString("N2").Split('.');
                        cons.Costtot = str[0].ToString().Replace(',', '.') + "," + str[1];
                        lista.Add(cons);
                    }
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public List<Cabecera> ListarConsumoMes(string Mes, string Año,int proce)
        {
            List<Cabecera> lista = new List<Cabecera>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if(cmd!= null)
            {
                cmd.CommandText = "Adm_List_ConsumoMes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mes",Mes);
                cmd.Parameters.AddWithValue("@Año", Año);
                cmd.Parameters.AddWithValue("@Procedimiento",proce);
                SqlDataReader reader = cmd.ExecuteReader();

                double Pliego = 0;
                double Hoja = 0;
                double Bobina = 0;
                double Precio_Hoja = 0;
                double Precio_Bobina = 0;
                double KGTotal = 0;
                double PrecioTl = 0;
                while(reader.Read())
                {
                    Cabecera consumo = new Cabecera();
                    consumo.Id_Funcionalidad = reader["NumOrdem"].ToString();
                    consumo.EmpId = reader["TituloTrabalho"].ToString();
                    consumo.UniCodigo = reader["Unidade"].ToString();
                    if (consumo.Id_Funcionalidad == "104615")
                    {

                    }
                    if(consumo.UniCodigo!="KG")
                    {
                        consumo.LlgDocNumDoc = Convert.ToDouble(reader["QtdeConsumidaUnidadeCust"].ToString()).ToString("N2");
                        Pliego = Pliego + Convert.ToDouble(reader["QtdeConsumidaUnidadeCust"].ToString());
                        consumo.DivCodigo = Convert.ToDouble(reader["Cantidad"].ToString()).ToString("N2");
                        consumo.LlgDocFechaIng = "0.00";
                        consumo.LlgDocGlosa = Convert.ToDouble(reader["CostoTotal"].ToString()).ToString("N2");
                        consumo.LlgDocNumInterno = "0.00";
                        Hoja = Hoja + Convert.ToDouble(reader["Cantidad"].ToString());
                        Precio_Hoja = Precio_Hoja + Convert.ToDouble(reader["CostoTotal"].ToString());
                        consumo.IntPeriodo = Convert.ToDouble(reader["QtdeConsumidaUnidadeCust"].ToString()).ToString("N2");
                    }
                    else
                    {
                        consumo.LlgDocNumDoc = "0.00";
                        consumo.LlgDocFechaIng = Convert.ToDouble(reader["Cantidad"].ToString()).ToString("N2");
                        consumo.DivCodigo = "0.00";
                        consumo.LlgDocNumInterno = Convert.ToDouble(reader["CostoTotal"].ToString()).ToString("N2");
                        consumo.LlgDocGlosa = "0.00";
                        Bobina = Bobina + Convert.ToDouble(reader["Cantidad"].ToString());
                        Precio_Bobina = Precio_Bobina + Convert.ToDouble(reader["CostoTotal"].ToString());
                        consumo.IntPeriodo = Convert.ToDouble(reader["QtdeConsumidaUnidadeCust"].ToString()).ToString("N2");
                    }
                    
                    consumo.OpeCod = Convert.ToDouble(reader["CostoTotal"].ToString()).ToString("N2");
                    KGTotal = KGTotal + Convert.ToDouble(reader["QtdeConsumidaUnidadeCust"].ToString());
                    PrecioTl = PrecioTl + Convert.ToDouble(reader["CostoTotal"].ToString());
                    lista.Add(consumo);
                }
                if (reader.Read() == false)
                {
                    Cabecera consumo = new Cabecera();
                    consumo.Id_Funcionalidad = "";
                    if (proce == 1)
                    {
                        consumo.EmpId = "Total Operacional";
                    }
                    else
                    {
                        consumo.EmpId = "Total Otros";
                    }
                    consumo.LlgDocNumDoc = Pliego.ToString("N2");
                    consumo.DivCodigo = Hoja.ToString("N2");
                    consumo.LlgDocGlosa = Precio_Hoja.ToString("N2");
                    consumo.LlgDocFechaIng = Bobina.ToString("N2");
                    consumo.LlgDocNumInterno = Precio_Bobina.ToString("N2");
                    consumo.IntPeriodo = KGTotal.ToString("N2");
                    consumo.OpeCod = PrecioTl.ToString("N2");
                    lista.Add(consumo);
                }
                con.CerrarConexion();
            }
            return lista;

        }

        public List<Consumo> ListarSerExterno(string OT)
        {
            List<Consumo> lista = new List<Consumo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Adm_List_Consumo2]"; 
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumOrdem", OT);
                cmd.Parameters.AddWithValue("@Procedimiento",1);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Consumo cons = new Consumo();
                    cons.Lote = reader["Proceso"].ToString();
                    cons.CodItem = reader["Barniz"].ToString();
                    cons.NombrePapel = reader["Formato"].ToString();
                    cons.Cons_Plancha = reader["Tipo"].ToString();
                    cons.Certif = Convert.ToInt32(reader["Cantidad_Pliegos"].ToString()).ToString("N0").Replace(",", ".");
                    cons.CostUni = Convert.ToDouble(reader["ValorPl"].ToString()).ToString("N2");
                    cons.Costtot = Convert.ToDouble(reader["CostoTotal"].ToString()).ToString("N2");
                    lista.Add(cons);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Consumo> ListarLiquidarOTs(string OT, string NombreOT, string Cliente, string FeInicio, string FeTermino, int procedimiento)
        {
            List<Consumo> lista = new List<Consumo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_List_LiquidarOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FeInicio", FeInicio);
                cmd.Parameters.AddWithValue("@FeTermino", FeTermino);
                cmd.Parameters.AddWithValue("@Procedimiento",procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Consumo liquidar = new Consumo();
                    liquidar.Ancho = reader["QG_RMS_JOB_NBR"].ToString();//OT
                    liquidar.Certif = reader["NM"].ToString();//Nombre OT
                    liquidar.CodItem = reader["CUST_NM"].ToString();//Cliente
                    liquidar.Cons_Bobina = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString()).ToString("N0").Replace(",",".");//Tiraje
                    if (reader["FECHA_LIQUIDACION"].ToString() != "")
                    {
                        liquidar.Cons_Plancha = Convert.ToDateTime(reader["FECHA_LIQUIDACION"].ToString()).ToString("dd-MM-yyyy");
                    }
                    liquidar.Cons_Otros = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + liquidar.Ancho + "\",\"" + liquidar.Ancho + "\")'>Ver Más</a>";
                    lista.Add(liquidar);
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public List<Consumo> ListarStockInsumo(string Codigo, string Descripcion, string Grupo)
        {
            List<Consumo> lista = new List<Consumo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_ListarStockInsumo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo",Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Grupo", Grupo);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Consumo cons = new Consumo();
                    cons.CodItem = reader["CodItem"].ToString();
                    cons.NombrePapel = reader["Descricao"].ToString();
                    cons.Gramage = Convert.ToDouble(reader["SaldoFinal"].ToString()).ToString("N2") + " " + reader["Unidad"].ToString();
                    cons.Lote = reader["grupo"].ToString();
                    cons.Certif = Convert.ToInt32(reader["Solicitado"].ToString()).ToString("N2").Replace(",",".");
                    cons.Tipo = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + cons.CodItem + "\",\"" + cons.NombrePapel + "\",\"" + cons.Gramage + "\",\"" + cons.Lote + "\")'>Solicitar</a>";
                    lista.Add(cons);
                }
            }
            return lista;
        }

        public List<Consumo> ListarStockInsumoMaquina()
        {
            List<Consumo> lista = new List<Consumo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Adm_Stock_InsumoMaqMetrics";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Consumo consumo = new Consumo();
                        consumo.CodItem = reader["CodRecurso"].ToString();
                        consumo.Gramage = reader["Descricao"].ToString();
                        lista.Add(consumo);
                    }
                }
                catch
                {
                }
            }
            return lista;
        } 

        public Boolean AgregarSolicStock(Consumo consumo)
        {
            bool respuesta= false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_Stock_Insumo_ingreso";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo",consumo.CodItem);
                cmd.Parameters.AddWithValue("@Descrip",consumo.NombrePapel);
                cmd.Parameters.AddWithValue("@Stock",consumo.Lote);
                cmd.Parameters.AddWithValue("@Cantidad",consumo.Cons_Pliego);
                cmd.Parameters.AddWithValue("@OT",consumo.Costtot);
                cmd.Parameters.AddWithValue("@NombreOT",consumo.Tipo);
                cmd.Parameters.AddWithValue("@Maquinas",consumo.Cons_Otros);
                cmd.Parameters.AddWithValue("@Estado", 1);
                cmd.Parameters.AddWithValue("@Usuario", consumo.Cons_Plancha);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            else{
                respuesta = false;
            }

            return respuesta;
        }

    }
}