using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloDespacho.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloDespacho.Controller
{
    public class FillRate_Controller
    {


        public bool ProcedimientoTrigger_FillRate(string OT = null, string nombreOT = null, string Cliente = null, DateTime? FechaInicio = null, DateTime? FechaTermino = null, int Procedimiento =0)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "[sp_trigger_FillRate]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 500000;
                cmd.ExecuteNonQuery();
                con.CerrarConexion();
                return true;
            }
            else
            {
                con.CerrarConexion();
                return false;
            }
           
        }



        public List<Fill_Rate> ListarFillRate(DateTime  fechaInicio, DateTime fechaTermino, string OT = "", string NombreOT= "", string Cliente ="")
        {
            List<Fill_Rate> lista = new List<Fill_Rate>();
            Conexion con = new Conexion();
            SqlCommand  cmd = con.AbrirConexionProduccion();
            if(cmd != null)
            {
                cmd.CommandText = "ListarFillRate";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaInicio",fechaInicio);
                cmd.Parameters.AddWithValue("@fechaTermino",fechaTermino);
                cmd.Parameters.AddWithValue("@Ot",OT);
                cmd.Parameters.AddWithValue("@NumeroOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente",Cliente);
                cmd.CommandTimeout = 500000;
                SqlDataReader reader = cmd.ExecuteReader();

                int totalOt = 0;
                int totalPuntos = 0;
                int porcrate = 0;

                string ot = "";
                while (reader.Read())
                {
                    Fill_Rate fill = new Fill_Rate();
                    
                    fill.OT = reader["QG_RMS_JOB_NBR"].ToString();
                    
                    fill.NombreOT = reader["NM"].ToString();
                    string algo12321321123 = reader["PRN_ORD_QTY"].ToString();
                    int tiraje = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    fill.Tiraje = tiraje.ToString("N0").Replace(",", ".");
                    int solicitada = Convert.ToInt32(reader["CantidadSolicitada"].ToString());
                    fill.Solitada = solicitada.ToString("N0").Replace(",", ".");

                    int CantSol = Convert.ToInt32(reader["TirajeGenerado"].ToString());
                    fill.CantidadGenerada = CantSol.ToString("N0").Replace(",", ".");

                    fill.FechaEntregar = Convert.ToDateTime(reader["FechaModificacion"].ToString());
                    fill.FechaEntregada = Convert.ToDateTime(reader["FechaProduccion"].ToString());


                    //% total
                    bool algo = false;
                    int TotalDespachado = Convert.ToInt32(reader["DespachoTotal"].ToString());
                    if (tiraje == 0)
                    {
                        // TotalDespachado = 1;
                        TotalDespachado = 0;
                        algo = true;
                    }
                    else
                    {
                        TotalDespachado = ((TotalDespachado * 100) / tiraje);
                    }
                  //  TotalDespachado = ((TotalDespachado * 100) / tiraje);

                    if (algo)
                    {
                        fill.DespachoTotal = "Error";
                    }
                    else
                    {
                        fill.DespachoTotal = TotalDespachado.ToString() + "%";
                    }
                    //fin
                    if (ot == fill.OT)
                    {
                        fill.PuntoEntrega = 0;
                    }
                    else
                    {
                        fill.PuntoEntrega = Convert.ToInt32(reader["contadorSucursal"].ToString());
                    }


                    fill.PorcTiraje = reader["Porcentaje"].ToString();

                    int valor = Convert.ToInt32(reader["TirajeGenerado"].ToString());
                    if (solicitada > 0)
                    {
                        valor = ((valor * 100) / solicitada);
                    }
                    else
                    {
                        valor = 0;
                    }
                    fill.PorcSolicitado = valor.ToString()+"%";
                    if (fill.PorcSolicitado == "100%")
                    {
                        porcrate = porcrate + 1;
                    }
                    totalOt = totalOt + 1;
                    totalPuntos = totalPuntos + Convert.ToInt32(fill.PuntoEntrega);
                    lista.Add(fill);
                    ot = fill.OT;
                }
                if (reader.Read() == false)
                {
                    Fill_Rate fill = new Fill_Rate();
                    fill.FechaEntregada = null;
                    fill.FechaEntregar = null;
                    fill.PuntoEntrega = null;
                    fill.DespachoTotal = "Total OTs :";
                    fill.PorcSolicitado = totalOt.ToString("N0").Replace(",", "."); ;
                    lista.Add(fill);
                    Fill_Rate fill2 = new Fill_Rate();
                    fill2.FechaEntregada = null;
                    fill2.FechaEntregar = null;
                    fill2.PuntoEntrega = null;
                    fill2.DespachoTotal = "Punt. Entrega:";
                    fill2.PorcSolicitado = totalPuntos.ToString("N0").Replace(",", "."); ;
                    lista.Add(fill2);
                    Fill_Rate fill3 = new Fill_Rate();
                    fill3.FechaEntregada = null;
                    fill3.FechaEntregar = null;
                    fill3.PuntoEntrega = null;
                    fill3.DespachoTotal = "Fill Rate OT";
                    try
                    {
                        double a = Convert.ToDouble(porcrate);
                        double b = Convert.ToDouble(totalOt);
                        double c = ((a / b) * 100);
                        int alo = Convert.ToInt32(c);
                        fill3.PorcSolicitado = alo.ToString() + "%";// 
                    }
                    catch
                    {
                        fill3.PorcSolicitado =  "%";// alo.ToString()
                    }
                    lista.Add(fill3);
                    Fill_Rate fill4 = new Fill_Rate();
                    fill4.FechaEntregada = null;
                    fill4.FechaEntregar = null;
                    fill4.PuntoEntrega = null;
                    fill4.DespachoTotal = "Fill Rate Pto. Entrega";
                    fill4.PorcSolicitado = "100%";
                    lista.Add(fill4);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        


        //fillRate exportacion excel
        public List<FillRate_Excel> ListarFillRate_Excel(DateTime fechaInicio, DateTime fechaTermino, string OT = "", string NombreOT = "", string Cliente = "")
        {
            List<FillRate_Excel> lista = new List<FillRate_Excel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "ListarFillRate";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaTermino", fechaTermino);
                cmd.Parameters.AddWithValue("@Ot", OT);
                cmd.Parameters.AddWithValue("@NumeroOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                SqlDataReader reader = cmd.ExecuteReader();

                int totalOt = 0;
                int totalPuntos = 0;
                int porcrate = 0;

                string ot = "";
                while (reader.Read())
                {
                    FillRate_Excel fill = new FillRate_Excel();

                    fill.OT = reader["QG_RMS_JOB_NBR"].ToString();

                    fill.NombreOT = reader["NM"].ToString();
                    int tiraje = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    fill.Tiraje = reader["PRN_ORD_QTY"].ToString();//tiraje.ToString("N0");
                    int solicitada = Convert.ToInt32(reader["CantidadSolicitada"].ToString());
                    fill.Solitada = reader["CantidadSolicitada"].ToString();//solicitada.ToString("N0");

                    int CantSol = Convert.ToInt32(reader["TirajeGenerado"].ToString());
                    fill.CantidadGenerada = reader["TirajeGenerado"].ToString();//CantSol.ToString("N0");

                    DateTime fe = Convert.ToDateTime(reader["FechaModificacion"].ToString());
                    fill.FechaEntregar = fe.ToString("dd/MM/yyyy HH:mm");// Convert.ToDateTime(reader["FechaModificacion"].ToString());

                    DateTime fp = Convert.ToDateTime(reader["FechaProduccion"].ToString());
                    //fill.FechaEntregada = fp.ToString("dd/MM/yyyy HH:mm"); //Convert.ToDateTime(reader["FechaProduccion"].ToString());


                    //% total
                    //% total
                    bool algo = false;
                    int TotalDespachado = Convert.ToInt32(reader["DespachoTotal"].ToString());
                    if (tiraje == 0)
                    {
                        // TotalDespachado = 1;
                        TotalDespachado = 0;
                        algo = true;
                    }
                    else
                    {
                        TotalDespachado = ((TotalDespachado * 100) / tiraje);
                    }
                    //  TotalDespachado = ((TotalDespachado * 100) / tiraje);

                    if (algo)
                    {
                        //fill.DespachoTotal = "Error";
                    }
                    else
                    {
                       // fill.DespachoTotal = TotalDespachado.ToString() + "%";
                    }
                  //  int TotalDespachado = Convert.ToInt32(reader["DespachoTotal"].ToString());
                   // if (tiraje == 0)
                    //{
                    //}
                    //else
                    //{
                    //    TotalDespachado = ((TotalDespachado * 100) / tiraje);
                    //}
                  
                    //fill.DespachoTotal = TotalDespachado.ToString() + "%";

                    //fin
                    if (ot == fill.OT)
                    {
                        fill.PuntoEntrega = "0";
                    }
                    else
                    {
                        fill.PuntoEntrega = reader["contadorSucursal"].ToString(); //Convert.ToInt32(reader["contadorSucursal"].ToString());
                    }


                    //fill.PorcTiraje = reader["Porcentaje"].ToString();
                    /*******/
                    //cambios realizados el 13/11 error ot tiraje 0
                    int valor = Convert.ToInt32(reader["TirajeGenerado"].ToString());
                    if (solicitada > 0)
                    {
                        valor = ((valor * 100) / solicitada);
                    }
                    else
                    {
                        valor = 0;
                    }
                    fill.PorcSolicitado = valor.ToString() + "%";
                    if (fill.PorcSolicitado == "100%")
                    {
                        porcrate = porcrate + 1;
                    }
                    totalOt = totalOt + 1;
                    totalPuntos = totalPuntos + Convert.ToInt32(fill.PuntoEntrega);
                    lista.Add(fill);
                    ot = fill.OT;
                }
                if (reader.Read() == false)
                {
                    FillRate_Excel fill = new FillRate_Excel();
                  //  fill.FechaEntregada = "";
                    fill.FechaEntregar = "";
                    fill.PuntoEntrega = "";
                    //fill.DespachoTotal = "Total OTs :";
                    fill.PorcSolicitado = totalOt.ToString("N0").Replace(",", ".");
                    lista.Add(fill);
                    FillRate_Excel fill2 = new FillRate_Excel();
                   // fill2.FechaEntregada = null;
                    fill2.FechaEntregar = null;
                    fill2.PuntoEntrega = null;
                    //fill2.DespachoTotal = "Punt. Entrega:";
                    fill2.PorcSolicitado = totalPuntos.ToString("N0").Replace(",", ".");
                    lista.Add(fill2);
                    FillRate_Excel fill3 = new FillRate_Excel();
                   // fill3.FechaEntregada = null;
                    fill3.FechaEntregar = null;
                    fill3.PuntoEntrega = null;
                   // fill3.DespachoTotal = "Fill Rate OT";
                    try
                    {
                        double a = Convert.ToDouble(porcrate);
                        double b = Convert.ToDouble(totalOt);
                        double c = ((a / b) * 100);
                        int alo = Convert.ToInt32(c);
                        fill3.PorcSolicitado = alo.ToString() + "%";// 
                    }
                    catch
                    {
                        fill3.PorcSolicitado = "%";// alo.ToString()
                    }
                    lista.Add(fill3);
                    FillRate_Excel fill4 = new FillRate_Excel();
                    //fill4.FechaEntregada = null;
                    fill4.FechaEntregar = null;
                    fill4.PuntoEntrega = null;
                    //fill4.DespachoTotal = "Fill Rate Pto. Entrega";
                    fill4.PorcSolicitado = "100%";
                    lista.Add(fill4);
                }
            }
            con.CerrarConexion();
            return lista;
        }


        public List<Fill_Rate> CargarFillRate(string OT, string NombreOT,string Cliente,DateTime fechaInicio, DateTime fechaTermino, int Procedimiento)
        {
            List<Fill_Rate> lista = new List<Fill_Rate>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            string OTCom = "";
            string SolicitadaAnterior = "";
            if (cmd != null)
            {
                cmd.CommandText = "Desp_CargarFillRate";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
       
                cmd.CommandTimeout = 500000;
                SqlDataReader reader = cmd.ExecuteReader();

                int totalOt = 0;
                int totalPuntos = 0;
                int porcrate = 0;

                string ot = "";
                while (reader.Read())
                {
                    Fill_Rate fill = new Fill_Rate();


                    string fi = Convert.ToDateTime(fechaInicio).ToShortDateString();
                    string fp = Convert.ToDateTime(reader["FechaProduccion"].ToString()).ToShortDateString();
                    if (fi == fp)
                    {
                        if (OTCom == reader["OT"].ToString())
                        {
                           

                            int solAnt = Convert.ToInt32(SolicitadaAnterior);

                            int restante = Convert.ToInt32(reader["CantDespachada"].ToString()) - solAnt;

                            int cantGen = restante - Convert.ToInt32(reader["TirajeSolicitado"].ToString());


                            fill.OT = reader["OT"].ToString();
                            fill.NombreOT = reader["NombreOT"].ToString().ToLower();
                            int tiraje = Convert.ToInt32(reader["TirajeOT"].ToString());
                            fill.Tiraje = tiraje.ToString("N0").Replace(",", ".");
                            int solicitada = Convert.ToInt32(reader["TirajeSolicitado"].ToString());
                            fill.Solitada = solicitada.ToString("N0").Replace(",", ".");
                            //int CantSol = Convert.ToInt32(reader["CantDespachada"].ToString());

                            if (cantGen >= 0)
                            {
                                fill.CantidadGenerada = solicitada.ToString("N0").Replace(",", ".");
                            }
                            else
                            {
                                fill.CantidadGenerada = cantGen.ToString("N0").Replace(",", "."); //CantSol.ToString("N0").Replace(",", ".");
                            }
                            string asda2 = reader["FechaProduccion"].ToString();
                            fill.FechaEntregada = Convert.ToDateTime(reader["FechaProduccion"].ToString());
                            int TotalDespachado = Convert.ToInt32(reader["TotalDespachado"].ToString());
                            if (tiraje == 0)
                            {
                                TotalDespachado = 0;
                                fill.DespachoTotal = "Error";
                            }
                            else
                            {
                                TotalDespachado = ((TotalDespachado * 100) / tiraje);

                                if (TotalDespachado > 100)
                                {
                                    fill.DespachoTotal = "100%";
                                }
                                else
                                {
                                    fill.DespachoTotal = TotalDespachado.ToString() + "%";
                                }
                            }
                            fill.PuntoEntrega = 0;
                            int valor = Convert.ToInt32(reader["CantDespachada"].ToString());
                            if (solicitada > 0)
                            {
                                valor = ((valor * 100) / solicitada);
                            }
                            else
                            {
                                valor = 0;
                            }

                            if (valor > 100)
                            {
                                fill.PorcSolicitado = "100%";
                            }
                            else
                            {
                                fill.PorcSolicitado = valor.ToString() + "%";
                            }

                            if (fill.PorcSolicitado == "100%")
                            {
                                porcrate = porcrate + 1;
                            }
                            totalOt = totalOt + 1;
                            totalPuntos = totalPuntos + Convert.ToInt32(fill.PuntoEntrega);
                            OTCom = reader["OT"].ToString();
                            SolicitadaAnterior = reader["TirajeSolicitado"].ToString();
                        }
                        else
                        {
                            
                            fill.OT = reader["OT"].ToString();
                            fill.NombreOT = reader["NombreOT"].ToString().ToLower();
                            int tiraje = Convert.ToInt32(reader["TirajeOT"].ToString());
                            fill.Tiraje = tiraje.ToString("N0").Replace(",", ".");
                            int solicitada = Convert.ToInt32(reader["TirajeSolicitado"].ToString());
                            fill.Solitada = solicitada.ToString("N0").Replace(",", ".");


                            string aaa = reader["CantDespachada"].ToString();

                            int CantSol = Convert.ToInt32(reader["CantDespachada"].ToString());

                            if (CantSol>=solicitada)
                            {
                                fill.CantidadGenerada = solicitada.ToString("N0").Replace(",", ".");
                            }
                            else
                            {
                                fill.CantidadGenerada = CantSol.ToString("N0").Replace(",", ".");
                            }



                            string asda2 = reader["FechaProduccion"].ToString();
                            fill.FechaEntregada = Convert.ToDateTime(reader["FechaProduccion"].ToString());
                            int TotalDespachado = Convert.ToInt32(reader["TotalDespachado"].ToString());
                            if (tiraje == 0)
                            {

                                TotalDespachado = 0;
                                fill.DespachoTotal = "Error";

                            }
                            else
                            {
                                TotalDespachado = ((TotalDespachado * 100) / tiraje);

                                if (TotalDespachado > 100)
                                {
                                    fill.DespachoTotal = "100%";

                                }
                                else
                                {
                                    fill.DespachoTotal = TotalDespachado.ToString() + "%";
                                }
                            }
                            fill.PuntoEntrega = Convert.ToInt32(reader["ptsEntrega"].ToString());
                            int valor = Convert.ToInt32(reader["CantDespachada"].ToString());
                            if (solicitada > 0)
                            {
                                valor = ((valor * 100) / solicitada);
                            }
                            else
                            {
                                valor = 0;
                            }

                            if (valor > 100)
                            {
                                fill.PorcSolicitado = "100%";
                            }
                            else
                            {
                                fill.PorcSolicitado = valor.ToString() + "%";
                            }

                            if (fill.PorcSolicitado == "100%")
                            {
                                porcrate = porcrate + 1;
                            }                       
                        totalOt = totalOt + 1;
                        totalPuntos = totalPuntos + Convert.ToInt32(fill.PuntoEntrega);
                        OTCom = reader["OT"].ToString();
                        SolicitadaAnterior = reader["TirajeSolicitado"].ToString();
                        }
                        lista.Add(fill);
                    }

                    
                    ot = fill.OT;
                }
                if (reader.Read() == false)
                {
                    Fill_Rate fill = new Fill_Rate();
                    fill.FechaEntregada = null;
                    fill.FechaEntregar = null;
                    fill.PuntoEntrega = null;
                    fill.DespachoTotal = "Total OTs :";
                    fill.PorcSolicitado = totalOt.ToString("N0").Replace(",", "."); ;
                    lista.Add(fill);
                    Fill_Rate fill2 = new Fill_Rate();
                    fill2.FechaEntregada = null;
                    fill2.FechaEntregar = null;
                    fill2.PuntoEntrega = null;
                    fill2.DespachoTotal = "Punt. Entrega:";
                    fill2.PorcSolicitado = totalPuntos.ToString("N0").Replace(",", "."); ;
                    lista.Add(fill2);
                    Fill_Rate fill3 = new Fill_Rate();
                    fill3.FechaEntregada = null;
                    fill3.FechaEntregar = null;
                    fill3.PuntoEntrega = null;
                    fill3.DespachoTotal = "Fill Rate OT";
                    try
                    {
                        double a = Convert.ToDouble(porcrate);
                        double b = Convert.ToDouble(totalOt);
                        double c = ((a / b) * 100);
                        int alo = Convert.ToInt32(c);
                        fill3.PorcSolicitado = alo.ToString() + "%";// 
                    }
                    catch
                    {
                        fill3.PorcSolicitado = "%";// alo.ToString()
                    }
                    lista.Add(fill3);
                    Fill_Rate fill4 = new Fill_Rate();
                    fill4.FechaEntregada = null;
                    fill4.FechaEntregar = null;
                    fill4.PuntoEntrega = null;
                    fill4.DespachoTotal = "Fill Rate Pto. Entrega";
                    fill4.PorcSolicitado = "100%";
                    lista.Add(fill4);
                }
            }
            con.CerrarConexion();
            return lista;
        }

    }
}