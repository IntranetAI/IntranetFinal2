using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloBobina.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloBobina.Controller
{
    public class Controller_ConsumoBobina
    {
        public List<Bobina_ConsumoLinea> List_BobinasWarRom(string Fecha)
        {
            List<Bobina_ConsumoLinea> lista = new List<Bobina_ConsumoLinea>();
            List<Bobina_ConsumoLinea> queryTotal = new List<Bobina_ConsumoLinea>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bobina_ConsumoLineaMetrics_WarRom";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bobina_ConsumoLinea bobina = new Bobina_ConsumoLinea();
                        bobina.Codigo_Bobina = reader["IdVolume"].ToString();
                        bobina.Maquina = reader["Maquina"].ToString();
                        bobina.Ancho = Convert.ToDouble(reader["Width"].ToString()).ToString();
                        bobina.Gramaje = Convert.ToDouble(reader["Gramaje"].ToString()).ToString();
                        bobina.TipoPapel = reader["DescPapel"].ToString();
                        bobina.PesoInicial = Convert.ToDouble(reader["AvailableBeforeQtd"].ToString()).ToString();
                        bobina.Saldo = Convert.ToDouble(reader["AvailableAfterQtd"].ToString()).ToString();
                        bobina.TipoPerdida = reader["TipoPerdida"].ToString();
                        bobina.Cantidad = Convert.ToDouble(reader["Cantidad"].ToString()).ToString();
                        bobina.OrigenPerdida = reader["ORIGEN"].ToString();
                        bobina.MotivoPerdida = reader["MOTIVO"].ToString();
                        bobina.TipoTransaccion = reader["TipoTrans"].ToString();
                        bobina.OT = reader["NumOrdem"].ToString();
                        queryTotal.Add(bobina);
                    }
                    if (queryTotal.Count > 0)
                    {
                        List<Bobina_ConsumoLinea> ll = queryTotal;
                        foreach (string maquina in queryTotal.Select(o => o.Maquina).Distinct())
                        {
                            foreach (string CodigoBobina in queryTotal.Where(o => o.Maquina == maquina).Select(o => o.Codigo_Bobina).Distinct())
                            {
                                int PesoInicial = 0; int PesoPerdidas = 0; int Escarpe = 0; int Consumo = 0;
                                Bobina_ConsumoLinea bobina = new Bobina_ConsumoLinea();

                                foreach (Bobina_ConsumoLinea bob in queryTotal.Where(o => o.Maquina == maquina).Where(o => o.Codigo_Bobina == CodigoBobina))
                                {
                                    bobina.Codigo_Bobina = bob.Codigo_Bobina;
                                    bobina.Maquina = bob.Maquina;
                                    bobina.Gramaje = bob.Gramaje;
                                    bobina.Ancho = bob.Ancho;
                                    bobina.TipoPapel = bob.TipoPapel;
                                    bobina.OT = bob.OT;
                                    if (PesoInicial == 0)
                                    {
                                        PesoInicial = Convert.ToInt32(bob.PesoInicial);
                                        bobina.PesoInicial = PesoInicial.ToString();
                                    }
                                    if (bob.TipoPerdida != "")
                                    {
                                        PesoPerdidas += Convert.ToInt32(bob.Cantidad);
                                        if (bob.TipoPerdida == "ESCALPE")
                                        {
                                            Escarpe += Convert.ToInt32(bob.Cantidad);
                                        }
                                    }
                                    else
                                    {
                                        if (bob.TipoTransaccion == "DEVOLUCIÓN DE BOBINAS (VOL)")
                                        {
                                            Consumo -= Convert.ToInt32(bob.Cantidad);
                                        }
                                        else
                                        {
                                            Consumo += Convert.ToInt32(bob.Cantidad);
                                        }
                                    }
                                    if (bob.OrigenPerdida != "")
                                    {
                                        bobina.OrigenPerdida = bob.OrigenPerdida;
                                        bobina.MotivoPerdida = bob.MotivoPerdida;
                                    }
                                    bobina.Escarpe = Escarpe.ToString();
                                    bobina.ConsumoBobina = (Consumo + PesoPerdidas).ToString();
                                    bobina.PorcentajePerdidas = Convert.ToDouble(Convert.ToDouble(Escarpe * 100) / PesoInicial).ToString("N2") + " %";
                                    lista.Add(bobina);
                                }
                              
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Bobina_ConsumoLinea> List_BobinasWarRom_V2(string Fecha)
        {
            List<Bobina_ConsumoLinea> lista = new List<Bobina_ConsumoLinea>();
            List<Bobina_ConsumoLinea> queryTotal = new List<Bobina_ConsumoLinea>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bobina_ConsumoLineaMetrics_WarRom_V2";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bobina_ConsumoLinea b = new Bobina_ConsumoLinea();
                        b.Codigo_Bobina = reader["IdBobina"].ToString();
                        b.Maquina = reader["Maquina"].ToString();
                        b.Ancho = Convert.ToDouble(reader["Width"].ToString()).ToString();
                        b.Gramaje = Convert.ToDouble(reader["Gramaje"].ToString()).ToString();
                        b.TipoPapel = reader["DescPapel"].ToString().ToLower();
                        b.PesoInicial = Convert.ToDouble(reader["PesoInicial"].ToString()).ToString();
                        b.OT = reader["NumOrdem"].ToString();
                        b.ConsumoBobina = Convert.ToDouble(reader["Consumo"].ToString()).ToString();
                        b.Escarpe = Convert.ToDouble(reader["Escalpe"].ToString()).ToString();
                        b.PorcentajePerdidas = Convert.ToDouble(reader["PorcPerdida"].ToString()).ToString("N2") + "%";
                        b.MotivoPerdida = "";
                        lista.Add(b);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Bobina_ConsumoLinea> List_BobinasInformeMensual(string FechaInicio, string FechaTermino)
        {
            List<Bobina_ConsumoLinea> lista = new List<Bobina_ConsumoLinea>();
            List<Bobina_ConsumoLinea> queryTotal = new List<Bobina_ConsumoLinea>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bobina_ConsumoLineaMetrics_Mensual";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bobina_ConsumoLinea bobina = new Bobina_ConsumoLinea();
                        bobina.Codigo_Bobina = reader["IdVolume"].ToString();
                        bobina.Maquina = reader["Maquina"].ToString();
                        bobina.PesoInicial = Convert.ToDouble(reader["AvailableBeforeQtd"].ToString()).ToString();
                        bobina.Saldo = Convert.ToDouble(reader["AvailableAfterQtd"].ToString()).ToString();
                        bobina.TipoPerdida = reader["TipoPerdida"].ToString();
                        bobina.Cantidad = Convert.ToDouble(reader["Cantidad"].ToString()).ToString();
                        bobina.OrigenPerdida = reader["ORIGEN"].ToString();
                        bobina.MotivoPerdida = reader["MOTIVO"].ToString();
                        bobina.TipoTransaccion = reader["TipoTrans"].ToString();
                        bobina.OT = reader["NumOrdem"].ToString();
                        queryTotal.Add(bobina);
                    }
                    if (queryTotal.Count > 0)
                    {
                        foreach (string maquina in queryTotal.Select(o => o.Maquina).Distinct())
                        {
                            foreach (string CodigoBobina in queryTotal.Where(o => o.Maquina == maquina).Select(o => o.Codigo_Bobina).Distinct())
                            {
                                int PesoInicial = 0;
                                int PesoPerdidas = 0;
                                int Escarpe = 0;
                                int Consumo = 0;
                                Bobina_ConsumoLinea bobina = new Bobina_ConsumoLinea();

                                foreach (Bobina_ConsumoLinea bob in queryTotal.Where(o => o.Maquina == maquina).Where(o => o.Codigo_Bobina == CodigoBobina))
                                {
                                    bobina.Codigo_Bobina = bob.Codigo_Bobina;
                                    bobina.Maquina = bob.Maquina;
                                    bobina.Gramaje = bob.Gramaje;
                                    bobina.Ancho = bob.Ancho;
                                    bobina.TipoPapel = bob.TipoPapel;
                                    bobina.OT = bob.OT;
                                    if (PesoInicial == 0)
                                    {
                                        PesoInicial = Convert.ToInt32(bob.PesoInicial);
                                        bobina.PesoInicial = PesoInicial.ToString();
                                    }
                                    if (bob.TipoPerdida != "")
                                    {
                                        PesoPerdidas += Convert.ToInt32(bob.Cantidad);
                                        if (bob.TipoPerdida == "ESCALPE")
                                        {
                                            Escarpe += Convert.ToInt32(bob.Cantidad);
                                        }
                                    }
                                    else
                                    {
                                        if (bob.TipoTransaccion == "DEVOLUCIÓN DE BOBINAS (VOL)")
                                        {
                                            Consumo -= Convert.ToInt32(bob.Cantidad);
                                        }
                                        else
                                        {
                                            Consumo += Convert.ToInt32(bob.Cantidad);
                                        }
                                    }
                                    if (bob.OrigenPerdida != "")
                                    {
                                        bobina.OrigenPerdida = bob.OrigenPerdida;
                                        bobina.MotivoPerdida = bob.MotivoPerdida;
                                    }
                                    bobina.Escarpe = Escarpe.ToString();
                                    bobina.ConsumoBobina = (Consumo + PesoPerdidas).ToString();
                                    bobina.PorcentajePerdidas = Convert.ToDouble(Convert.ToDouble(Escarpe * 100) / PesoInicial).ToString("N2") + " %";
                                }
                                lista.Add(bobina);
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Bobina_ConsumoLinea_V2> List_BobinasInformeMensual_V2(string FechaInicio, string FechaTermino)
        {
            List<Bobina_ConsumoLinea_V2> lista = new List<Bobina_ConsumoLinea_V2>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            double TotalBobinas = 0; double TotalConsumo = 0; double TotalEscarpe = 0; double BobinasConProyecto = 0; double KGConProyecto = 0; double DanoProveedor;
            double DanoRollero = 0; double DanoAlmacen = 0;
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Bobina_ConsumoLineaMetrics_Mensual_V2";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bobina_ConsumoLinea_V2 b = new Bobina_ConsumoLinea_V2();
                        b.Maquina = reader["Maquina"].ToString();
                        TotalBobinas = Convert.ToDouble(reader["TotalBobinas"].ToString());
                        TotalConsumo = Convert.ToDouble(reader["Consumo"].ToString());
                        TotalEscarpe = Convert.ToDouble(reader["Escalpe"].ToString());
                        BobinasConProyecto = Convert.ToDouble(reader["BobinasConProyecto"].ToString());
                        KGConProyecto = Convert.ToDouble(reader["KGBobinasConProyecto"].ToString());
                        DanoProveedor = Convert.ToDouble(reader["DanoProveedor"].ToString());
                        DanoRollero = Convert.ToDouble(reader["DanoRollero"].ToString());
                        DanoAlmacen = Convert.ToDouble(reader["DanoAlmacen"].ToString());
                        b.TotalBobinasConsumidas = TotalBobinas;
                        b.TotalKGConsumido = TotalConsumo;
                        b.TotalKGEscarpe = TotalEscarpe;
                        if (TotalBobinas > 0)
                        {
                            b.PromedioEscarpe = (TotalEscarpe / TotalBobinas);
                        }
                        else
                        {
                            b.PromedioEscarpe = 0;
                        }
                        if (TotalConsumo > 0)
                        {
                            b.PorcentajeEscarpe = ((TotalEscarpe * 100) / TotalConsumo);
                        }
                        else
                        {
                            b.PorcentajeEscarpe = 0;
                        }
                        b.BobinasBuenas = Convert.ToDouble(reader["BobinasBuenas"].ToString());
                        b.BobinasMalas = Convert.ToDouble(reader["BobinasMalas"].ToString());
                        b.BobinasConProyecto = BobinasConProyecto;
                        b.KGConProyecto = KGConProyecto;
                        b.BobinasSinProyecto = (TotalBobinas - BobinasConProyecto);
                        b.KGSinProyecto = (TotalConsumo - KGConProyecto);
                        b.DanoAlmacen = DanoAlmacen;
                        b.DanoRollero = DanoRollero;
                        b.DanoProveedor = DanoProveedor;
                        if (TotalEscarpe > 0)
                        {
                            b.PorcDanoAlmacen = ((DanoAlmacen * 100) / TotalEscarpe);
                            b.PorcDanoRollero = ((DanoRollero * 100) / TotalEscarpe);
                            b.PorcDanoProveedor = ((DanoProveedor * 100) / TotalEscarpe);
                        }
                        else
                        {
                            b.PorcDanoAlmacen = 0; b.PorcDanoRollero = 0; b.PorcDanoProveedor = 0;
                        }
                        lista.Add(b);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}