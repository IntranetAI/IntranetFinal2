using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloEncuadernacion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloEncuadernacion.Controller
{
    public class Controller_InfDespacho
    {
        public List<Inf_Enc> cargainfDespacho(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Inf_Enc> lista = new List<Inf_Enc>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_informeDespacho]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Inf_Enc pro = new Inf_Enc();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    int ti = Convert.ToInt32(reader["Tiraje"].ToString());
                    pro.Tiraje = ti.ToString("N0").Replace(",",".");

                    int desp = Convert.ToInt32(reader["DespachoEnc"].ToString());
                    pro.DespachoEnc = desp.ToString("N0").Replace(",", ".");

                    int reci = Convert.ToInt32(reader["RecibidoQG"].ToString());
                    pro.RecibidoQGChile = reci.ToString("N0").Replace(",",".");

                    int sald = Convert.ToInt32( reader["saldo"].ToString());
                    if (sald <= 0)
                    {
                        pro.Saldo = "0";
                    }
                    else
                    {
                        pro.Saldo = sald.ToString("N0").Replace(",", ".");
                    }
                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }
        //////////////////////////////


        public List<Inf_Enc> cargainfDespacho_Detalle(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Inf_Enc> lista = new List<Inf_Enc>();
            int fajo = 0;
            int zuncho = 0;
            int cmc = 0;
            int caja = 0;
            int embolsado = 0;
            int paquete = 0;
            int tirajeTotal = 0;
            int totalEjemplares = 0;

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_informeDespacho]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Inf_Enc pro = new Inf_Enc();
                    pro.cod_Pallet = reader["cod_Pallet"].ToString();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.Embalaje = reader["TipoEmbalaje"].ToString();

                    //count embalaje
                    if (reader["TipoEmbalaje"].ToString() == "Fajo")
                    {
                        fajo = fajo + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "Zuncho")
                    {
                        zuncho = zuncho + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "CMC")
                    {
                        cmc = cmc + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "Caja")
                    {
                        caja = caja + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "Embolsado")
                    {
                        embolsado = embolsado + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "Paquete")
                    {
                        paquete = paquete + 1;
                    }

                    //
                    int cant = Convert.ToInt32(reader["Cantidad"].ToString());
                    pro.Cantidad = cant.ToString("N0").Replace(",", ".");

                    int ejem = Convert.ToInt32(reader["Ejemplares"].ToString());
                    pro.Ejemplares = ejem.ToString("N0").Replace(",", ".");

                    int total = Convert.ToInt32(reader["Total"].ToString());
                    totalEjemplares = totalEjemplares + total;

                    pro.Total = total.ToString("N0").Replace(",", ".");

                    pro.RecepcionadoPor = reader["RecepcionadoPor"].ToString();

                    DateTime fech = Convert.ToDateTime(reader["FechaRecepcion"].ToString());
                    pro.FechaRecepcion = fech.ToString("dd/MM/yyyy HH:mm");

                    pro.Tiraje = reader["PRN_ORD_QTY"].ToString();

                    tirajeTotal = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());

                    lista.Add(pro);
                } 
                if (reader.Read() == false)
                {
                    Inf_Enc pro1 = new Inf_Enc();
                    //primero vacio
                    pro1.cod_Pallet = "";
                    pro1.OT = "";
                    pro1.NombreOT = "";
                    pro1.Terminacion = "";
                    pro1.Embalaje = "";
                    pro1.Cantidad = "";
                    pro1.Ejemplares = "";
                    pro1.Total = "";
                    pro1.RecepcionadoPor = "";
                    pro1.FechaRecepcion = "";
                    lista.Add(pro1);


                    if (fajo != 0)
                    {
                        Inf_Enc pro4 = new Inf_Enc();
                        pro4.cod_Pallet = null;
                        pro4.OT = null;
                        pro4.NombreOT = null;
                        pro4.Terminacion = null;
                        pro4.Embalaje = null;
                        pro4.Cantidad = null;
                        pro4.Ejemplares = null;
                        pro4.Total = null;
                        pro4.RecepcionadoPor = " <div style='font-weight: bold'>Cant. Fajos:</div>";
                        pro4.FechaRecepcion = fajo.ToString("N0").Replace(",", ".");
                        lista.Add(pro4);
                    }
                    if (zuncho != 0)
                    {
                        Inf_Enc pro5 = new Inf_Enc();
                        pro5.cod_Pallet = null;
                        pro5.OT = null;
                        pro5.NombreOT = null;
                        pro5.Terminacion = null;
                        pro5.Embalaje = null;
                        pro5.Cantidad = null;
                        pro5.Ejemplares = null;
                        pro5.Total = null;
                        pro5.RecepcionadoPor = " <div style='font-weight: bold'>Cant. Zuncho:</div>";
                        pro5.FechaRecepcion = zuncho.ToString("N0").Replace(",", ".");
                        lista.Add(pro5);
                    }
                    if (cmc != 0)
                    {
                        Inf_Enc pro6 = new Inf_Enc();
                        pro6.cod_Pallet = null;
                        pro6.OT = null;
                        pro6.NombreOT = null;
                        pro6.Terminacion = null;
                        pro6.Embalaje = null;
                        pro6.Cantidad = null;
                        pro6.Ejemplares = null;
                        pro6.Total = null;
                        pro6.RecepcionadoPor = " <div style='font-weight: bold'>Cant. CMC:</div>";
                        pro6.FechaRecepcion = cmc.ToString("N0").Replace(",", ".");
                        lista.Add(pro6);
                    }
                    if (caja != 0)
                    {
                        Inf_Enc pro7 = new Inf_Enc();
                        pro7.cod_Pallet = null;
                        pro7.OT = null;
                        pro7.NombreOT = null;
                        pro7.Terminacion = null;
                        pro7.Embalaje = null;
                        pro7.Cantidad = null;
                        pro7.Ejemplares = null;
                        pro7.Total = null;
                        pro7.RecepcionadoPor = " <div style='font-weight: bold'>Cant. Cajas:</div>";
                        pro7.FechaRecepcion = caja.ToString("N0").Replace(",", ".");
                        lista.Add(pro7);
                    }
                    if (embolsado != 0)
                    {
                        Inf_Enc pro8 = new Inf_Enc();
                        pro8.cod_Pallet = null;
                        pro8.OT = null;
                        pro8.NombreOT = null;
                        pro8.Terminacion = null;
                        pro8.Embalaje = null;
                        pro8.Cantidad = null;
                        pro8.Ejemplares = null;
                        pro8.Total = null;
                        pro8.RecepcionadoPor = " <div style='font-weight: bold'>Cant. Embolsado:</div>";
                        pro8.FechaRecepcion = embolsado.ToString("N0").Replace(",", ".");
                        lista.Add(pro8);
                    }
                    if (paquete != 0)
                    {
                        Inf_Enc pro9 = new Inf_Enc();
                        pro9.cod_Pallet = null;
                        pro9.OT = null;
                        pro9.NombreOT = null;
                        pro9.Terminacion = null;
                        pro9.Embalaje = null;
                        pro9.Cantidad = null;
                        pro9.Ejemplares = null;
                        pro9.Total = null;
                        pro9.RecepcionadoPor = " <div style='font-weight: bold'>Cant. Paquetes:</div>";
                        pro9.FechaRecepcion = paquete.ToString("N0").Replace(",", ".");
                        lista.Add(pro9);
                    }
                    //segundo Total Cajas
                    Inf_Enc pro2 = new Inf_Enc();
                    pro2.cod_Pallet = null;
                    pro2.OT = null;
                    pro2.NombreOT = null;
                    pro2.Terminacion = null;
                    pro2.Embalaje = null;
                    pro2.Cantidad = null;
                    pro2.Ejemplares = null;
                    pro2.Total = null;
                    pro2.RecepcionadoPor = "<div style='font-weight: bold'>Total Ejemp.:</div>";
                    pro2.FechaRecepcion = totalEjemplares.ToString("N0").Replace(",", ".");
                    lista.Add(pro2);
                    //Tercero
                    Inf_Enc pro3 = new Inf_Enc();
                    pro3.cod_Pallet = null;
                    pro3.OT = null;
                    pro3.NombreOT = null;
                    pro3.Terminacion = null;
                    pro3.Embalaje = null;
                    pro3.Cantidad = null;
                    pro3.Ejemplares = null;
                    pro3.Total = null;
                    pro3.RecepcionadoPor = " <div style='font-weight: bold'>Tiraje Total:</div>";
                    pro3.FechaRecepcion = tirajeTotal.ToString("N0").Replace(",", ".");
                    lista.Add(pro3);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }



        public bool Reimpresion_Guias(string cod_Pallet)
        {
            SqlDataReader dr;
            bool respuesta = true;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "PT_ReimpresionGuia";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Pallet", cod_Pallet);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
        /****************************  EXCEL OTS LIQUIDADAS ************************/
        public List<Excel_Liquidadas> Excel_OTLiquidada(string OT,string NombreOT,DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Excel_Liquidadas> lista = new List<Excel_Liquidadas>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_ExcelLiquidadas]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Excel_Liquidadas pro = new Excel_Liquidadas();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    pro.Tiraje = reader["Tiraje"].ToString();
                    pro.Despachado = reader["Despachado"].ToString();
                    pro.CUST_NM = reader["CUST_NM"].ToString();
                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        /**************************** Anular Guias **************************/


        public List<Prod_Terminados> BuscaPalletAnularGuia(string cod_pallet)
        {
            List<Prod_Terminados> lista = new List<Prod_Terminados>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_BuscarGuiaAnular]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Pallet", cod_pallet);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prod_Terminados p = new Prod_Terminados();
                    // p.Proceso = reader["NombreProceso"].ToString();
                    p.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    p.OT = reader["OT"].ToString();
                    p.NombreOT = reader["NombreOT"].ToString();
                    p.Terminacion = reader["Terminacion"].ToString();
                    p.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    p.Cantidad = reader["Cantidad"].ToString();
                    p.Ejemplares = reader["Ejemplares"].ToString();
                    p.Total = reader["Total"].ToString();

                    //p.NombreOperario = reader["NombreOperario"].ToString();
                    //p.Maquina = reader["Maquina"].ToString();
                   // p.Proceso = reader["Proceso"].ToString();
                    if (reader["Estado"].ToString() == "4")
                    {
                        p.Estado = "<div style='Color:Red;'>Despachada</div>";
                    }
                    else if (reader["Estado"].ToString() == "8")
                    {
                        p.Estado = "<div style='Color:Green;'>Recepcionada</div>";
                    }
                    else
                    {
                        p.Estado = "<div style='Color:Blue;'>Pendiente</div>";
                    }
                    //p.Estado = reader["Estado"].ToString();
                    lista.Add(p);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }

        public bool Anular_Guias(int id_ProductosTerminados,string motivo,string usuario)
        {
            SqlDataReader dr;
            bool respuesta = true;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "PT_AnularGuias";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ProductosTerminados", id_ProductosTerminados);
                cmd.Parameters.AddWithValue("@Motivo", motivo);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
              
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return respuesta;
        }
















        /**************************** Control Recepcion **********************/

        public List<Prod_Terminados> controlRecepcionPendientes(string OT, string NombreOT, DateTime FechaInicio,DateTime FechaTermino,int Procedimiento)
        {
            List<Prod_Terminados> lista = new List<Prod_Terminados>();
            int totalDesp = 0;
            string Recep = "";
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_ControlRecepcion]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prod_Terminados p = new Prod_Terminados();
                    // p.Proceso = reader["NombreProceso"].ToString();
                    p.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    p.cod_pallet = reader["cod_Pallet"].ToString();
                    p.OT = reader["OT"].ToString().ToUpper();
                    p.NombreOT = reader["NombreOT"].ToString().ToLower();
                    p.Terminacion = reader["Terminacion"].ToString();
                    p.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    p.Cantidad = reader["Cantidad"].ToString();
                    p.Ejemplares = reader["Ejemplares"].ToString();

                    int tt = Convert.ToInt32(reader["Total"].ToString());
                    p.Total = tt.ToString("N0").Replace(",", ".");




                    totalDesp = totalDesp + Convert.ToInt32(reader["Total"].ToString());
                    DateTime fec = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    p.FechaCreacion = fec.ToString("dd/MM/yyyy HH:mm");
                        
                    p.Modelo = reader["Modelo"].ToString();
                    p.Observacion = reader["Observacion"].ToString();

                    p.ValidadoPor = reader["ValidadoPor"].ToString().ToLower();
                    p.RecepcionadoPor = reader["RecepcionadoPor"].ToString().ToLower();
                    DateTime FecVal = Convert.ToDateTime(reader["FechaValidacion"].ToString());
                    p.FechaValidacion = FecVal.ToString("dd/MM/yyyy HH:mm");

                    if (reader["FechaRecepcion"].ToString() == "")
                    {
                        p.FechaRecepcion = "01-01-1900";
                    }
                    else
                    {
                        DateTime fecRec = Convert.ToDateTime(reader["FechaRecepcion"].ToString());
                        p.FechaRecepcion = fecRec.ToString("dd/MM/yyyy HH:mm");
                    }


                    p.RecepcionadoPor = reader["RecepcionadoPor"].ToString();

                    Recep = p.RecepcionadoPor;
                    if (reader["Estado"].ToString() == "4")
                    {
                        p.Estado = "<div style='Color:Red;'>Despachada</div>";
                    }
                    else if (reader["Estado"].ToString() == "8")
                    {
                        p.Estado = "<div style='Color:Green;'>Recepcionada</div>";
                    }
                    else
                    {
                        p.Estado = "<div style='Color:Blue;'>Pendiente</div>";
                    }
                    //p.Estado = reader["Estado"].ToString();
                    lista.Add(p);
                }
                if (OT != "" || NombreOT != "")
                {
                    if (reader.Read() == false)
                    {
                        if (lista.Count > 0)
                        {

                            if (Recep == "")
                            {

                                Prod_Terminados pt = new Prod_Terminados();
                                pt.cod_pallet = null;
                                pt.OT = null;
                                pt.NombreOT = null;
                                pt.Terminacion = null;
                                pt.TipoEmbalaje = null;
                                pt.Total = null;
                                pt.FechaCreacion = null;
                                pt.Modelo = "<div style='font-weight: bold'>Total Pendiente: </div>";
                                pt.Observacion = "<div align='right'>" + totalDesp.ToString("N0").Replace(",", ".") + "</div>";
                                lista.Add(pt);
                            }
                            else
                            {

                                Prod_Terminados pt = new Prod_Terminados();
                                pt.cod_pallet = null;
                                pt.OT = null;
                                pt.NombreOT = null;
                                pt.Terminacion = null;
                                pt.TipoEmbalaje = null;
                                pt.Total = null;
                                pt.FechaCreacion = null;
                                pt.FechaValidacion = "<div style='font-weight: bold'>Total Despachado: </div>";
                                pt.Modelo = "<div align='right'>" + totalDesp.ToString("N0").Replace(",", ".") + "</div>";
                                lista.Add(pt);
                            }
                        }
                    }
                    else
                    {
                        //no imprimir nada
                    }
                }
            }
            conexion.CerrarConexion();
            return lista;
        }





        /****************************** EXISTENCIA **********************************/
        public bool Existencia()
        {
            SqlDataReader dr;
            bool respuesta = true;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "TMP_Existencia";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000000;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr["respuesta"].ToString());
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            conexion.CerrarConexion();
            return respuesta;
        }



        //cargar datos Existencia
        public List<Inf_Enc> CargarExistencia(string OT, string NombreOT,string Cliente ,DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Inf_Enc> lista = new List<Inf_Enc>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Desp_Existencia]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.CommandTimeout = 30000000;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Inf_Enc pro = new Inf_Enc();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();

                    int ti = Convert.ToInt32(reader["TirajeTotal"].ToString());
                    pro.Tiraje = ti.ToString("N0").Replace(",", ".");


                    int reci = Convert.ToInt32(reader["TotalRecepcionado"].ToString()) - Convert.ToInt32(reader["Devolucion4"].ToString());
                    pro.RecibidoQGChile = reci.ToString("N0").Replace(",", ".");



                    int desp = Convert.ToInt32(reader["TotalDespachado"].ToString());// - Convert.ToInt32(reader["Devolucion4"].ToString()
                    pro.DespachoEnc = desp.ToString("N0").Replace(",", ".");

                    int dev = Convert.ToInt32(reader["Devolucion"].ToString());
                    pro.id_ProductosTerminados = dev.ToString("N0").Replace(",", ".");

                    //neuvos
                    int mues = Convert.ToInt32(reader["Muestras"].ToString());
                    pro.Muestras = mues.ToString("N0").Replace(",", "."); //reader["Muestras"].ToString();

                    int sobr = Convert.ToInt32(reader["Sobrantes"].ToString());
                    pro.Sobrante = sobr.ToString("N0").Replace(",", ".");  //reader["Sobrantes"].ToString();
                    //nuevos
                    int sald = reci - desp; //Convert.ToInt32(reader["Existencia"].ToString());
                    pro.Saldo = sald.ToString("N0").Replace(",", ".");



                    int restante = (ti - (desp - dev));

                    if (reader["Estado"].ToString() == "1")
                    {
                        if (restante <= 0)//(tirajeot - (despachado - devuelto)
                        {
                            pro.Terminacion = "<div style='Color:Red;'>Por Liquidar</div>";
                        }
                        else
                        {
                            pro.Terminacion = "<div style='Color:Blue;'>En Proceso</div>";
                        }
                    }
                    else
                    {
                        pro.Terminacion = "<div style='Color:Green;'>Liquidada</div>";
                    }

                    //if (ti <= desp)//Convert.ToInt32(reader["TirajeTotal"].ToString())-Convert.ToInt32(reader["TotalDespachado"].ToString())
                    //{
                    //    pro.Terminacion = "<div style='Color:Red;'>Por Liquidar</div>";

                    //}
                    //else
                    //{
                    //    pro.Terminacion = "<div style='Color:Blue;'>En Proceso</div>";
                    //}
                    lista.Add(pro);

                }
            }
            conexion.CerrarConexion();
            return lista;
        }





        public List<Existencia_Excel> CargarExistencia_Excel(string OT, string NombreOT, string Cliente, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Existencia_Excel> lista = new List<Existencia_Excel>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[SP_PT_Existencia]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Existencia_Excel pro = new Existencia_Excel();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                  //  pro.Cliente = reader["Cliente"].ToString();

                    //int ti = Convert.ToInt32(reader["TirajeOT"].ToString());
                    pro.TirajeOT = reader["TirajeOT"].ToString();// ti.ToString("N0").Replace(",", ".");

                    //int desp = Convert.ToInt32(reader["TotalDespachado"].ToString());
                    pro.TotalDespachado = reader["TotalDespachado"].ToString();// desp.ToString("N0").Replace(",", ".");

                    //int reci = Convert.ToInt32(reader["TotalRecepcionado"].ToString());
                    pro.TotalRecepcionado = reader["TotalRecepcionado"].ToString();// reci.ToString("N0").Replace(",", ".");

                    //int sald =
                    pro.Existencia = reader["Existencia"].ToString();// sald.ToString("N0").Replace(",", ".");

                    if (Convert.ToInt32(reader["TirajeOT"].ToString()) <= Convert.ToInt32(reader["TotalDespachado"].ToString()))
                    {
                        pro.Estado = "Liquidada";

                    }
                    else
                    {
                        pro.Estado = "En Proceso";
                    }
                    lista.Add(pro);

                }
            }
            conexion.CerrarConexion();
            return lista;
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    //*************************************** EXCEL INFORME_DESPACHOS********************************************//

        public List<Excel_InformeDespacho> infDespacho_Excel(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<Excel_InformeDespacho> lista = new List<Excel_InformeDespacho>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_informeDespacho]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Excel_InformeDespacho pro = new Excel_InformeDespacho();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    //int ti = Convert.ToInt32(reader["Tiraje"].ToString());
                    pro.Tiraje = reader["Tiraje"].ToString();// ti.ToString("N0").Replace(",", ".");

                    //int desp = Convert.ToInt32(reader["DespachoEnc"].ToString());
                    pro.DespachoEnc = reader["DespachoEnc"].ToString();// desp.ToString("N0").Replace(",", ".");

                    //int reci = Convert.ToInt32(reader["RecibidoQG"].ToString());
                    pro.RecibidoQG = reader["RecibidoQG"].ToString();// reci.ToString("N0").Replace(",", ".");

                    int sald = Convert.ToInt32(reader["saldo"].ToString());
                    if (sald <= 0)
                    {
                        pro.saldo = "0";
                    }
                    else
                    {
                        pro.saldo = reader["saldo"].ToString();//sald.ToString("N0").Replace(",", ".");
                    }
                    lista.Add(pro);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }



        public List<DetalleDespachos_Excel> cargainfDespacho_Detalle_Excel(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<DetalleDespachos_Excel> lista = new List<DetalleDespachos_Excel>();
            int fajo = 0;
            int zuncho = 0;
            int cmc = 0;
            int caja = 0;
            int embolsado = 0;
            int paquete = 0;
            string tirajeTotal = "";
            int totalEjemplares = 0;

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();

            if (cmd != null)
            {
                cmd.CommandText = "[PT_informeDespacho]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DetalleDespachos_Excel pro = new DetalleDespachos_Excel();
                    pro.Pallet = reader["cod_Pallet"].ToString();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                   // pro.Terminacion = reader["Terminacion"].ToString();
                    pro.Embalaje = reader["TipoEmbalaje"].ToString();

                    //count embalaje
                    if (reader["TipoEmbalaje"].ToString() == "Fajo")
                    {
                        fajo = fajo + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "Zuncho")
                    {
                        zuncho = zuncho + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "CMC")
                    {
                        cmc = cmc + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "Caja")
                    {
                        caja = caja + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "Embolsado")
                    {
                        embolsado = embolsado + 1;
                    }
                    if (reader["TipoEmbalaje"].ToString() == "Paquete")
                    {
                        paquete = paquete + 1;
                    }

                    //
                    //int cant = Convert.ToInt32(reader["Cantidad"].ToString());
                    pro.CantBultos = reader["Cantidad"].ToString();//cant.ToString("N0").Replace(",", ".");

                    int ejem = Convert.ToInt32(reader["Ejemplares"].ToString());
                    pro.EjemplaresxBulto = ejem.ToString("N0").Replace(",", ".");

                    int total = Convert.ToInt32(reader["Total"].ToString());
                    totalEjemplares =  totalEjemplares + total;

                    pro.TotalEjemplares = reader["Total"].ToString();// total.ToString("N0").Replace(",", ".");

                    pro.Responsable = reader["RecepcionadoPor"].ToString();

                    DateTime fech = Convert.ToDateTime(reader["FechaRecepcion"].ToString());
                    pro.Fecha = fech.ToString("dd/MM/yyyy HH:mm");

                    pro.Tiraje = reader["PRN_ORD_QTY"].ToString();

                    tirajeTotal = reader["PRN_ORD_QTY"].ToString();

                    lista.Add(pro);
                }
                if (reader.Read() == false)
                {
                    DetalleDespachos_Excel pro1 = new DetalleDespachos_Excel();
                    //primero vacio
                    pro1.Pallet = "";
                    pro1.OT = "";
                    pro1.NombreOT = "";
                   // pro1.Terminacion = "";
                    pro1.Embalaje = "";
                    pro1.CantBultos= "";
                    pro1.EjemplaresxBulto = "";
                    pro1.TotalEjemplares = "";
                    pro1.Responsable = "";
                    pro1.Fecha = "";
                    lista.Add(pro1);


                    if (fajo != 0)
                    {
                        DetalleDespachos_Excel pro4 = new DetalleDespachos_Excel();
                        pro1.Pallet = "";
                        pro1.OT = "";
                        pro1.NombreOT = "";
                        // pro1.Terminacion = "";
                        pro1.Embalaje = "";
                        pro1.CantBultos = "";
                        pro1.EjemplaresxBulto = "";
                        pro1.TotalEjemplares = "";
                        pro4.Responsable = " Cant. Fajos:";
                        pro4.Fecha = fajo.ToString("N0").Replace(",", ".");
                        lista.Add(pro4);
                    }
                    if (zuncho != 0)
                    {
                        DetalleDespachos_Excel pro5 = new DetalleDespachos_Excel();
                        pro1.Pallet = "";
                        pro1.OT = "";
                        pro1.NombreOT = "";
                        // pro1.Terminacion = "";
                        pro1.Embalaje = "";
                        pro1.CantBultos = "";
                        pro1.EjemplaresxBulto = "";
                        pro1.TotalEjemplares = "";
                        pro5.Responsable = " Cant. Zuncho:";
                        pro5.Fecha = zuncho.ToString("N0").Replace(",", ".");
                        lista.Add(pro5);
                    }
                    if (cmc != 0)
                    {
                        DetalleDespachos_Excel pro6 = new DetalleDespachos_Excel();
                        pro1.Pallet = "";
                        pro1.OT = "";
                        pro1.NombreOT = "";
                        // pro1.Terminacion = "";
                        pro1.Embalaje = "";
                        pro1.CantBultos = "";
                        pro1.EjemplaresxBulto = "";
                        pro1.TotalEjemplares = "";
                        pro6.Responsable = " Cant. CMC:";
                        pro6.Fecha = cmc.ToString("N0").Replace(",", ".");
                        lista.Add(pro6);
                    }
                    if (caja != 0)
                    {
                        DetalleDespachos_Excel pro7 = new DetalleDespachos_Excel();
                        pro1.Pallet = "";
                        pro1.OT = "";
                        pro1.NombreOT = "";
                        // pro1.Terminacion = "";
                        pro1.Embalaje = "";
                        pro1.CantBultos = "";
                        pro1.EjemplaresxBulto = "";
                        pro1.TotalEjemplares = "";
                        pro7.Responsable = "Cant. Cajas:";
                        pro7.Fecha = caja.ToString("N0").Replace(",", ".");
                        lista.Add(pro7);
                    }
                    if (embolsado != 0)
                    {
                        DetalleDespachos_Excel pro8 = new DetalleDespachos_Excel();
                        pro1.Pallet = "";
                        pro1.OT = "";
                        pro1.NombreOT = "";
                        // pro1.Terminacion = "";
                        pro1.Embalaje = "";
                        pro1.CantBultos = "";
                        pro1.EjemplaresxBulto = "";
                        pro1.TotalEjemplares = "";
                        pro8.Responsable = "Cant. Embolsado:";
                        pro8.Fecha = embolsado.ToString("N0").Replace(",", ".");
                        lista.Add(pro8);
                    }
                    if (paquete != 0)
                    {
                        DetalleDespachos_Excel pro9 = new DetalleDespachos_Excel();
                        pro1.Pallet = "";
                        pro1.OT = "";
                        pro1.NombreOT = "";
                        // pro1.Terminacion = "";
                        pro1.Embalaje = "";
                        pro1.CantBultos = "";
                        pro1.EjemplaresxBulto = "";
                        pro1.TotalEjemplares = "";
                        pro9.Responsable = "Cant. Paquetes:";
                        pro9.Fecha = paquete.ToString("N0").Replace(",", ".");
                        lista.Add(pro9);
                    }
                    //segundo Total Cajas
                    DetalleDespachos_Excel pro2 = new DetalleDespachos_Excel();
                    pro1.Pallet = "";
                    pro1.OT = "";
                    pro1.NombreOT = "";
                    // pro1.Terminacion = "";
                    pro1.Embalaje = "";
                    pro1.CantBultos = "";
                    pro1.EjemplaresxBulto = "";
                    pro1.TotalEjemplares = "";
                    pro2.Responsable = "Total Ejemp.:";
                    pro2.Fecha  = totalEjemplares.ToString("N0").Replace(",", ".");
                    lista.Add(pro2);
                    //Tercero
                    DetalleDespachos_Excel pro3 = new DetalleDespachos_Excel();
                    pro1.Pallet = "";
                    pro1.OT = "";
                    pro1.NombreOT = "";
                    // pro1.Terminacion = "";
                    pro1.Embalaje = "";
                    pro1.CantBultos = "";
                    pro1.EjemplaresxBulto = "";
                    pro1.TotalEjemplares = "";
                    pro3.Responsable = "Tiraje Total:";
                    pro3.Fecha = Convert.ToInt32(tirajeTotal).ToString("N0").Replace(",", ".");
                    lista.Add(pro3);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }
    }


}