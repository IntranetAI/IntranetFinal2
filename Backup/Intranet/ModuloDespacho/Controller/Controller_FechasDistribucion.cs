using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.Controller
{
    public class Controller_FechasDistribucion
    {
        public List<FechasDistribucion> ListarDespachosaEntregar(string Ot,string NombreOT,string Cliente, string fechaInicio, string fechaFin)
        {
            List<FechasDistribucion> lista = new List<FechasDistribucion>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Desp_InfomeDespFuturo2";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", Ot);
                    cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                    cmd.Parameters.AddWithValue("@Cliente", Cliente);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", fechaFin);
                    SqlDataReader read = cmd.ExecuteReader();

                    string OT = "";
                    int Solicitada = 0;
                    int CantidadTotal = 0;
                    while (read.Read())
                    {
                        FechasDistribucion des = new FechasDistribucion();
                        des.OT = read["OT"].ToString();
                        des.NombreOT = read["NombreOT"].ToString();
                        des.Cliente = read["Cliente"].ToString();
                        des.Tiraje = read["tirajeOT"].ToString();//tiraje
                        des.TotalDespachado = Convert.ToInt32(read["TotalDespachado"].ToString()).ToString("N0").Replace(",", ".");//total despachado

                        if (OT != des.OT)
                        {
                            OT = des.OT;
                            CantidadTotal = Convert.ToInt32(read["TotalDespachado"].ToString());
                        }

                        Solicitada = Convert.ToInt32(read["TirajeSolicitado"].ToString());
                        des.TirajeGenerado = Solicitada.ToString("N0").Replace(",", ".");
                        int result = CantidadTotal - Solicitada;
                        if (result >= 0)
                        {
                            des.tirajeAcumulado = Solicitada.ToString("N0").Replace(",", ".");
                            CantidadTotal = result;
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif' />100%";
                        }
                        if (result < 0)
                        {
                            des.tirajeAcumulado = CantidadTotal.ToString("N0").Replace(",", ".");
                            try
                            {
                                int porcentaje = ((CantidadTotal * 100) / Solicitada);
                                if (porcentaje < 10)
                                {
                                    des.Despachado = porcentaje.ToString() + "%";
                                }
                                if (porcentaje >= 10 && porcentaje < 20)
                                {
                                    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' />" + porcentaje.ToString() + "%";
                                }
                                if (porcentaje >= 20 && porcentaje < 30)
                                {
                                    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' />" + porcentaje.ToString() + "%";
                                }
                                if (porcentaje >= 30 && porcentaje < 40)
                                {
                                    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' />" + porcentaje.ToString() + "%";
                                }
                                if (porcentaje >= 40 && porcentaje < 50)
                                {
                                    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' />" + porcentaje.ToString() + "%";
                                }
                                if (porcentaje >= 50 && porcentaje < 60)
                                {
                                    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' />" + porcentaje.ToString() + "%";
                                }
                                if (porcentaje >= 60 && porcentaje < 70)
                                {
                                    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' />" + porcentaje.ToString() + "%";
                                }
                                if (porcentaje >= 70 && porcentaje < 80)
                                {
                                    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' />" + porcentaje.ToString() + "%";
                                }
                                if (porcentaje >= 80 && porcentaje < 90)
                                {
                                    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' />" + porcentaje.ToString() + "%";
                                }
                                if (porcentaje >= 90 && porcentaje < 100)
                                {
                                    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' />" + porcentaje.ToString() + "%";
                                }
                                CantidadTotal = 0;
                            }
                            catch
                            {
                                des.Despachado = "ERROR";
                            }
                        }

                        DateTime fi = Convert.ToDateTime(fechaInicio);
                        DateTime ft = Convert.ToDateTime(fechaFin);
                        DateTime fp = Convert.ToDateTime(read["FechaProduccion"].ToString());
                        des.FechaDes = fp.ToString("dd-MM-yyyy HH:mm:ss");
                        if (fi <= fp & ft >= fp)
                        {
                            lista.Add(des);
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
    }
}