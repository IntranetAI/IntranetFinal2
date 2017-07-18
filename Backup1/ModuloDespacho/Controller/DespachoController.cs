using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloDespacho.Controller
{
    public class DespachoController
    {
        public static string info = "";

        //Listar Despachos
        public List<Despacho> ListarDespacho(string ot)
        {
            List<Despacho> lista = new List<Despacho>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            if (cmd != null)
            {
                cmd.CommandText = "Listar_Despacho";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                SqlDataReader reader = cmd.ExecuteReader();
                int totalDespachado = 0;
                while (reader.Read())
                {
                    Despacho des = new Despacho();
                    des.OT = reader["IDGUIACAB"].ToString();
                    des.Folio = Convert.ToInt32(reader["NOFOLIOGUIACAB"].ToString());
                    des.Destinatario = reader["NOMBREDESTINATARIOGUIACAB"].ToString();
                    des.FechaImpresion = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    des.Sucursal = reader["CALLESUCURSAL"].ToString();
                    des.Comuna = reader["NOMBRECOMUNA"].ToString();
                    //des.Despachado = Convert.ToInt32(reader["cantidad"].ToString());
                    int CANTIDAD = Convert.ToInt32(reader["cantidad"].ToString());
                    des.Despachado = CANTIDAD.ToString("N0");
                    //des.StatusDes = reader["status"].ToString();
                    //if (des.StatusDes == "IMPRESO")
                    //{
                    //}
                    //des.StatusDes = "<div style='text-align:left'>" + reader["status"].ToString() + "</div>";
                    totalDespachado = totalDespachado + CANTIDAD;
                    lista.Add(des);
                }
                if (reader.Read() == false)
                {
                    Despacho de = new Despacho();
                    de.Comuna = "Total Despachado";
                    de.Despachado = totalDespachado.ToString("N0");
                    lista.Add(de);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        //agregar registro al llegar al maximo
        public void AgregarDespacho(Orden OT)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "AgregarDespa_Comp";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT.NumeroOT);
                    cmd.Parameters.AddWithValue("@FechaDes", OT.Fecha_Des);
                    cmd.ExecuteNonQuery();
                    con.CerrarConexion();
                }
                catch
                {
                }
            }
            con.CerrarConexion();
        }

        public List<Despacho> ListarPDF(string ot)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            List<Despacho> lista = new List<Despacho>();
            if (cmd != null)
            {
                cmd.CommandText = "Listar_Despacho";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                SqlDataReader reader = cmd.ExecuteReader();
                int totalDespachado = 0;
                while (reader.Read())
                {
                    Despacho des = new Despacho();
                    des.OT = reader["IDGUIACAB"].ToString();
                    des.NumeroFolio = reader["NOFOLIOGUIACAB"].ToString();
                    des.Destinatario = reader["NOMBREDESTINATARIOGUIACAB"].ToString();
                    des.FechaImpresion = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    des.Sucursal = reader["CALLESUCURSAL"].ToString();
                    des.Comuna = reader["NOMBRECOMUNA"].ToString();
                    int CANTIDAD = Convert.ToInt32(reader["cantidad"].ToString());
                    des.Despachado = CANTIDAD.ToString("N0");
                    des.StatusDes = reader["status"].ToString();
                    if (des.StatusDes == "IMPRESO")
                    {
                        totalDespachado = totalDespachado + CANTIDAD;
                    }
                    des.StatusDes = reader["status"].ToString();
                    lista.Add(des);
                }
                if (reader.Read() == false)
                {
                    Despacho de = new Despacho();
                    de.StatusDes = "Total :";
                    de.Despachado = totalDespachado.ToString("N0");
                    lista.Add(de);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        //Procediemtos para PAgina INfDepsachoFuturos
        public List<DespachoFuturosExcel> ListarFuturos(string Ot = "", string NombreOT = "", string Cliente = "", DateTime? fechaInicio = null, DateTime? fechaFin = null, int Procedimiento = 0)
        {
            List<DespachoFuturosExcel> list = new List<DespachoFuturosExcel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            if (cmd != null)
            {
                cmd.CommandText = "DespachosFuturos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", Ot);
                cmd.Parameters.AddWithValue("@NOmbreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                //cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                //if (fechaInicio != null)
                //{
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechaFin);
                //}
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DespachoFuturosExcel des = new DespachoFuturosExcel();
                    des.OT = read["NumeroOT"].ToString();
                    des.NombreOT = read["NombreOT"].ToString();
                    des.Cliente = read["Cliente"].ToString();
                    DateTime fechaD = Convert.ToDateTime(read["FechaDespacho"].ToString());
                    des.FechaDes = fechaD.ToString("dd/MM/yyyy HH:mm"); //Convert.ToDateTime(read["FechaDespacho"].ToString());
                    int cantidad = Convert.ToInt32(read["Tiraje"].ToString());
                    des.Cant = cantidad.ToString("N0");
                    //cantidad = Convert.ToInt32(read["Cantidad"].ToString());
                    //des.Sucursal = cantidad.ToString("N0");//por la cantidad despachada
                    Boolean nivel = Convert.ToBoolean(read["Nivel"].ToString());
                    if (!nivel)
                    {
                        int result = Convert.ToInt32(read["Porcentaje"].ToString());//(cantidad2 * 100) / cantidad;
                        if (result >= 100)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif'/>100%";
                        }
                        else
                        {
                            if (result < 10)
                            {
                                des.Despachado = result.ToString() + "%";
                            }
                            if (result >= 10 && result < 20)
                            {
                                des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' />" + result.ToString() + "%";
                            }
                            if (result >= 20 && result < 30)
                            {
                                des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' />" + result.ToString() + "%";
                            }
                            if (result >= 30 && result < 40)
                            {
                                des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' />" + result.ToString() + "%";
                            }
                            if (result >= 40 && result < 50)
                            {
                                des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' />" + result.ToString() + "%";
                            }
                            if (result >= 50 && result < 60)
                            {
                                des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' />" + result.ToString() + "%";
                            }
                            if (result >= 60 && result < 70)
                            {
                                des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' />" + result.ToString() + "%";
                            }
                            if (result >= 70 && result < 80)
                            {
                                des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' />" + result.ToString() + "%";
                            }
                            if (result >= 80 && result < 90)
                            {
                                des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' />" + result.ToString() + "%";
                            }
                            if (result >= 90 && result < 100)
                            {
                                des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' />" + result.ToString() + "%";
                            }
                        }
                    }
                    else
                    {
                        des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif' />100%";
                    }

                    list.Add(des);
                }

            }
            con.CerrarConexion();
            return list;
        }


        //inicio prc informe por ot
        public List<Desp_InfPorOT> ListarDespacho_informePorOT(string ot = null, string nombreOT = null, string Cliente = null, DateTime? FechaInicio = null, DateTime? FechaTermino = null, int? procedimiento = null)
        {
            List<Desp_InfPorOT> lista = new List<Desp_InfPorOT>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            int count = 0;
            int totalDespachado = 0;
            if (cmd != null)
            {
                cmd.CommandText = "Lista_Despacho_Filtro2";//cambio era el 1 pero esta qgguiadespacho y se duplico
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Desp_InfPorOT des = new Desp_InfPorOT();
                    des.OT = reader["qg_rms_job_nbr"].ToString();
                    des.Folio = reader["NOFOLIOGUIACAB"].ToString();
                    des.NombreOT = reader["NM"].ToString();
                    des.Cliente = reader["CALLESUCURSAL"].ToString().ToLower();
                    des.FechaImpresion = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString()).ToString("dd/MM/yyy HH:mm");
                    //cantidad total
                    int total = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    des.TirajeTotal = total.ToString("N0").Replace(",", ".");




                    int CANTIDAD = 0;



                    string algo = reader["TipoMovimiento"].ToString();
                    if (algo == "Devolucion")
                    {
                        CANTIDAD = Convert.ToInt32(reader["cantidad"].ToString()) * -1;
                    }
                    else
                    {
                        CANTIDAD = Convert.ToInt32(reader["cantidad"].ToString());
                    }


                    des.Despachado = CANTIDAD.ToString("N0").Replace(",", ".");
                    des.Rut = CANTIDAD.ToString().Replace(",", ".");

                    string TipoMovimiento = reader["TipoMovimiento"].ToString();
                    if (TipoMovimiento == "Despacho")
                    {
                        des.TipoMovimiento = "<div style='Color:Green;'>Despacho</div>";
                    }
                    else
                    {
                        des.TipoMovimiento = "<div style='Color:Red;'><a style='Color:Red;text-decoration:none;' href='javascript:openGame(\"" + des.Folio + "\")'>Devolucion</a></div>";
                    }
                    //
                    //pro.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + pro.OT + "\",\"" + pro.NombreOT + "\")'>Más</a>";


                    totalDespachado = totalDespachado + CANTIDAD;
                    count++;

                    lista.Add(des);

                }
                if (reader.Read() == false)
                {
                    Desp_InfPorOT de = new Desp_InfPorOT();
                    //de.TirajeTotal = "Total Guias:";
                    //de.Despachado = count.ToString("N0");
                    de.TirajeTotal = "Total Despachado:";
                    de.Despachado = totalDespachado.ToString("N0").Replace(",", ".");
                    lista.Add(de);
                }

            }
            con.CerrarConexion();
            return lista;
        }
        //sentencia select agrupada

        public List<Despacho> ListarDespacho_informePorOTAgrupada(string nombreOT, string numeroOT, string FechaInicio, string FechaTermino, int procedimiento)
        {
            List<Despacho> lista = new List<Despacho>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();

            if (cmd != null)
            {
                cmd.CommandText = "spListaOTAgrupadas2";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                cmd.Parameters.AddWithValue("@NumeroOT", numeroOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                cmd.CommandTimeout = 5000;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Despacho des = new Despacho();
                    des.OT = reader["QG_RMS_JOB_NBR"].ToString();
                    des.NombreOT = reader["NM"].ToString();
                    des.Cliente = reader["CUST_NM"].ToString();

                    string algo = reader["PRN_ORD_QTY"].ToString();
                    int tt = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    des.TirajeTotal = tt.ToString("N0").Replace(",", ".");

                    des.FechaMinima = Convert.ToDateTime(reader["FecMinima"].ToString());



                    des.FechaMaxima = Convert.ToDateTime(reader["FecMaxima"].ToString());

                    int td = Convert.ToInt32(reader["TotalDespachado"].ToString());
                    des.Despachado = td.ToString("N0").Replace(",", ".");


                    lista.Add(des);

                }

            }
            con.CerrarConexion();
            return lista;
        }



        //fin sentencia agrupada

        //fin de los procedimientos

        public List<DespachoExcel> ListarDespacho_informePorOTExcel(string ot = null, string nombreOT = null, string Cliente = null, DateTime? FechaInicio = null, DateTime? FechaTermino = null, int? procedimiento = null)
        {
            List<DespachoExcel> lista = new List<DespachoExcel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            int totalDespachado = 0;
            if (cmd != null)
            {
                cmd.CommandText = "Lista_Despacho_Filtro2";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DespachoExcel des = new DespachoExcel();
                    des.OT = reader["qg_rms_job_nbr"].ToString();
                    des.guia = reader["NOFOLIOGUIACAB"].ToString();//Convert.ToInt32(reader["NOFOLIOGUIACAB"].ToString());
                    des.NombreOT = reader["NM"].ToString();
                    des.Cliente = reader["CALLESUCURSAL"].ToString();

                    DateTime algo = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    string fe = algo.ToString("dd/MM/yyyy HH:mm:ss");
                    des.FechaImpresion = fe;

                    int total = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    des.TirajeTotal = total.ToString("N0");

                    //cantidad despachada
                    //des.Despachado = Convert.ToInt32(reader["cantidad"].ToString());
                    int CANTIDAD = Convert.ToInt32(reader["cantidad"].ToString());
                    des.Despachado = CANTIDAD.ToString("N0");

                    lista.Add(des);

                }
                //if (reader.Read() == false)
                //{
                //    Despacho de = new Despacho();
                //    de.TirajeTotal = "Total Despachado";
                //    de.Despachado = totalDespachado.ToString("N0");
                //    lista.Add(de);
                //}

            }
            con.CerrarConexion();
            return lista;
        }
        public List<DespachoPDF> ListarDespacho_informePorOT_PDF(string ot = null, string nombreOT = null, string Cliente = null, DateTime? FechaInicio = null, DateTime? FechaTermino = null, int? procedimiento = null)
        {
            List<DespachoPDF> lista = new List<DespachoPDF>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            int totalDespachado = 0;
            if (cmd != null)
            {
                cmd.CommandText = "Lista_Despacho_Filtro";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DespachoPDF des = new DespachoPDF();
                    des.OT = reader["qg_rms_job_nbr"].ToString();
                    des.guia = Convert.ToInt32(reader["NOFOLIOGUIACAB"].ToString());
                    des.NombreOT = reader["NM"].ToString();
                    des.Cliente = reader["CUST_NM"].ToString();

                    //des.FechaImpresion =
                    DateTime fecI = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    string algo = fecI.ToString("dd/MM/yyyy HH:mm:ss");
                    des.FechaImpresion = algo;

                    //cantidad total
                    int total = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    des.TirajeTotal = total.ToString("N0");

                    //cantidad despachada
                    //des.Despachado = Convert.ToInt32(reader["cantidad"].ToString());
                    int CANTIDAD = Convert.ToInt32(reader["cantidad"].ToString());
                    des.Despachado = CANTIDAD.ToString("N0");
                    des.Rut = CANTIDAD;
                    totalDespachado = totalDespachado + CANTIDAD;


                    lista.Add(des);

                }
                //if (reader.Read() == false)
                //{
                //    Despacho de = new Despacho();
                //    de.TirajeTotal = "Total Despachado";
                //    de.Despachado = totalDespachado.ToString("N0");
                //    lista.Add(de);
                //}

            }
            con.CerrarConexion();
            return lista;
        }

        //fin de los procedimientos
        //fin de los procedimientos
        public List<Despacho> ListarDespacho_kilos(string ot = null, string nombreot = null, string Cliente = null, string Transportista = null, DateTime? Feinicio = null, DateTime? Fetermino = null, int? procedimiento = null)
        {
            List<Despacho> lista = new List<Despacho>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();

            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "ListarKilosTrans";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                    cmd.Parameters.AddWithValue("@Cliente", Cliente);
                    cmd.Parameters.AddWithValue("@Transportista", Transportista);
                    cmd.Parameters.AddWithValue("@Feinicio", Feinicio);
                    cmd.Parameters.AddWithValue("@Fetermino", Fetermino);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Despacho d = new Despacho();
                        d.Cliente = reader["RAZONSOCIALPROVEEDOR"].ToString();
                        int cantidad = Convert.ToInt32(reader["CANTIDADTIPOELEMENTO"].ToString());
                        d.Despachado = cantidad.ToString("N0");
                        d.FechaImpresion = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                        d.Folio = Convert.ToInt32(reader["CantidadGuia"].ToString());
                        d.NombreOT = reader["NombreOT"].ToString();
                        d.OT = reader["OT"].ToString();
                        d.Destinatario = reader["PATENTEVEHICULO"].ToString();
                        d.TirajeTotal = reader["PESOGUIADET"].ToString() + " " + reader["NombreUnidadMedida"].ToString();

                        lista.Add(d);
                    }


                }
                catch (Exception e)
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<DespachoKilos> ListarDespacho_KilosExcel(string ot = null, string nombreot = null, string Cliente = null, string Transportista = null, DateTime? Feinicio = null, DateTime? Fetermino = null, int? procedimiento = null)
        {
            List<DespachoKilos> lista = new List<DespachoKilos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            if (cmd != null)
            {
                cmd.CommandText = "ListarKilosTrans";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Transportista", Transportista);
                cmd.Parameters.AddWithValue("@Feinicio", Feinicio);
                cmd.Parameters.AddWithValue("@Fetermino", Fetermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                cmd.CommandTimeout = 9000000;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DespachoKilos d = new DespachoKilos();
                    d.OT = reader["OT"].ToString();
                    d.Cant = Convert.ToInt32(reader["CANTIDADTIPOELEMENTO"].ToString());
                    DateTime fe = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    d.FechaDespacho = fe.ToString("dd/MM/yyyy HH:mm:ss");
                    d.Guias = Convert.ToInt32(reader["CantidadGuia"].ToString());
                    d.NumeroOT = reader["NombreOT"].ToString();
                    d.Transportista = reader["RAZONSOCIALPROVEEDOR"].ToString();
                    d.Patente = reader["PATENTEVEHICULO"].ToString();
                    float peso = float.Parse(reader["PESOGUIADET"].ToString());
                    d.PesoUnitario = reader["PESOGUIADET"].ToString() + " " + reader["NombreUnidadMedida"].ToString();
                    string unidad = reader["NombreUnidadMedida"].ToString();
                    if (unidad == "Grs")
                    {
                        float TKilos = peso * d.Cant / 1000;
                        string kilos = TKilos.ToString("n2");
                        d.TotalKilos = float.Parse(kilos);
                    }
                    else
                    {
                        d.TotalKilos = peso * d.Cant;
                    }
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }


        //inicio pdf y excel informe diario
        public List<DespachoPDF> ListarDespacho_informeDiario_DetalladoPDF(string ot = null, string nombreOT = null, string Cliente = null, DateTime? FechaInicio = null, DateTime? FechaTermino = null, int? procedimiento = null)
        {
            List<DespachoPDF> lista = new List<DespachoPDF>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            int totalDespachado = 0;
            if (cmd != null)
            {
                cmd.CommandText = "Lista_Despacho_InformeDiarioDetalle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DespachoPDF des = new DespachoPDF();
                    des.OT = reader["qg_rms_job_nbr"].ToString();
                    des.guia = Convert.ToInt32(reader["NOFOLIOGUIACAB"].ToString());
                    des.NombreOT = reader["NM"].ToString();
                    des.Cliente = reader["CALLESUCURSAL"].ToString();

                    //des.FechaImpresion =
                    DateTime fecI = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    string algo = fecI.ToString("dd/MM/yyyy HH:mm:ss");
                    des.FechaImpresion = algo;

                    //cantidad total
                    int total = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    des.TirajeTotal = total.ToString("N0");

                    //cantidad despachada
                    //des.Despachado = Convert.ToInt32(reader["cantidad"].ToString());
                    int CANTIDAD = Convert.ToInt32(reader["cantidad"].ToString());
                    des.Despachado = CANTIDAD.ToString("N0");
                    des.Rut = CANTIDAD;
                    totalDespachado = totalDespachado + CANTIDAD;


                    lista.Add(des);

                }
                //if (reader.Read() == false)
                //{
                //    Despacho de = new Despacho();
                //    de.TirajeTotal = "Total Despachado";
                //    de.Despachado = totalDespachado.ToString("N0");
                //    lista.Add(de);
                //}

            }
            con.CerrarConexion();
            return lista;
        }



        public List<DespachoPDF> ListarDespacho_informeDiarioAgrupada(string nombreOT = null, string numeroOT = null, DateTime? FechaInicio = null, DateTime? FechaTermino = null, int? procedimiento = null)
        {

            List<DespachoPDF> lista = new List<DespachoPDF>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            try
            {
                if (cmd != null)
                {
                    cmd.CommandText = "spListaOTAgrupadas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                    cmd.Parameters.AddWithValue("@NumeroOT", numeroOT);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DespachoPDF des = new DespachoPDF();
                        des.OT = reader["QG_RMS_JOB_NBR"].ToString();
                        des.NombreOT = reader["NM"].ToString();
                        des.Cliente = reader["CUST_NM"].ToString();

                        int tt = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                        des.TirajeTotal = tt.ToString("N0");

                        des.FechaMinima = Convert.ToDateTime(reader["FecMinima"].ToString());
                        des.FechaMaxima = Convert.ToDateTime(reader["FecMaxima"].ToString());

                        int td = Convert.ToInt32(reader["TotalDespachado"].ToString());
                        des.Despachado = td.ToString("N0");

                        DateTime algo = Convert.ToDateTime(reader["FecMaxima"].ToString());

                        des.fechaDespacho = algo.ToString("dd/MM/yyyy HH:mm:ss");

                        lista.Add(des);

                    }


                }
            }
            catch
            {

            }
            con.CerrarConexion();
            return lista;


        }










        //procedimientos para informe despacho futuros
        public bool ProcedimientoTrigger(string OT = null, string nombreOT = null, string Cliente = null, DateTime? FechaInicio = null, DateTime? FechaTermino = null)
        {
            Conexion con = new Conexion();
            string I = "";
            string T = "";
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "sp_trigger";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                if (FechaInicio == null)
                {
                    I = "1900-01-01";
                }
                else
                {
                    DateTime algo = Convert.ToDateTime(FechaInicio.ToString());
                    I = algo.ToString("MM/dd/yyyy HH:mm:ss");
                }
                cmd.Parameters.AddWithValue("@FechaInicio", I);
                if (FechaTermino == null)
                {
                    T = "1900-01-01";
                }
                else
                {
                    DateTime algo = Convert.ToDateTime(FechaTermino.ToString());
                    T = algo.ToString("MM/dd/yyyy HH:mm:ss");
                }
                cmd.Parameters.AddWithValue("@FechaTermino", T);
                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
            con.CerrarConexion();
        }


        public List<DespachoFuturosExcel> sp_ListarFuturos_Mostrar(string Ot, string NombreOT, string Cliente, string fechaInicio, string fechaFin, int Procedimiento)
        {
            List<DespachoFuturosExcel> list = new List<DespachoFuturosExcel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Desp_InfomeDespFuturo";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", Ot);
                    cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                    cmd.Parameters.AddWithValue("@Cliente", Cliente);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", fechaFin);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    cmd.CommandTimeout = 5000;
                    SqlDataReader read = cmd.ExecuteReader();

                    string OT = "";
                    int Solicitada = 0;
                    int CantidadTotal = 0;
                    while (read.Read())
                    {
                        DespachoFuturosExcel des = new DespachoFuturosExcel();
                        des.OT = read["OT"].ToString();
                        des.NombreOT = read["NombreOT"].ToString();
                        des.Cliente = read["Cliente"].ToString();
                        des.Cant = read["tirajeOT"].ToString();//tiraje
                        des.Fechafalsa = Convert.ToInt32(read["TotalDespachado"].ToString()).ToString("N0").Replace(",", ".");//total despachado

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
                        des.FechaDes = fp.ToString("dd/MM/yyyy HH:mm:ss");
                        if (fi <= fp & ft >= fp)
                        {
                            list.Add(des);
                        }
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return list;
        }

        public List<DespachoFuturosExcel> ListarProduccionOT_tablaTemporal(string Ot)
        {
            List<DespachoFuturosExcel> list = new List<DespachoFuturosExcel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[lista_Tabla_Temporal]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeroOT", Ot);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DespachoFuturosExcel des = new DespachoFuturosExcel();

                    des.OT = read["OT"].ToString();
                    des.NombreOT = read["NombreOT"].ToString();
                    des.Cliente = read["Cliente"].ToString();
                    DateTime fechaD = Convert.ToDateTime(read["FechaProduccion"].ToString());
                    des.FechaDes = fechaD.ToString("dd/MM/yyyy HH:mm");//read["FechaProduccion"].ToString();//Convert.ToDateTime(read["FechaProduccion"].ToString());
                    int cantidad = Convert.ToInt32(read["Tiraje"].ToString());
                    des.Cant = cantidad.ToString("N0");

                    int TirajeGe = Convert.ToInt32(read["TirajeGenerado"].ToString());
                    des.TirajeGenerado = TirajeGe.ToString("N0");
                    //cantidad = Convert.ToInt32(read["Cantidad"].ToString());
                    //des.Sucursal = cantidad.ToString("N0");//por la cantidad despachada
                    //int nivel = Convert.ToInt32(read["Estado"].ToString());
                    //if (nivel!=1)
                    //{
                    int result = Convert.ToInt32(read["Porcentaje"].ToString());//(cantidad2 * 100) / cantidad;
                    if (result > 100)
                    {
                        des.Despachado = "ERROR";
                    }
                    else
                    {
                        if (result < 10)
                        {
                            des.Despachado = result.ToString() + "%";
                        }
                        if (result >= 10 && result < 20)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 20 && result < 30)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 30 && result < 40)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 40 && result < 50)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 50 && result < 60)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 60 && result < 70)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 70 && result < 80)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 80 && result < 90)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 90 && result < 100)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' />" + result.ToString() + "%";
                        }
                        if (result == 100)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif' />100%";
                        }
                    }
                    //}
                    //else
                    //{
                    //    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar100.gif' />100%";
                    //}

                    list.Add(des);
                }
            }
            con.CerrarConexion();
            return list.ToList();
        }

        public List<DespachoFuturosExcel> ListarProduccionOT_tablaTemporal_Detalle(string Ot)
        {
            List<DespachoFuturosExcel> list = new List<DespachoFuturosExcel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[sp_triggerDetalle]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", Ot);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DespachoFuturosExcel des = new DespachoFuturosExcel();

                    des.OT = read["OT"].ToString();
                    des.NombreOT = read["NombreOT"].ToString();
                    des.Cliente = read["Cliente"].ToString();

                    DateTime fechaD = Convert.ToDateTime(read["FechaProduccion"].ToString());
                    des.FechaDes = fechaD.ToString("dd/MM/yyyy HH:mm");//read["FechaProduccion"].ToString();// Convert.ToDateTime(read["FechaProduccion"].ToString());
                    int cantidad = Convert.ToInt32(read["Tiraje"].ToString());
                    des.Cant = cantidad.ToString("N0");

                    int TirajeGe = Convert.ToInt32(read["TirajeGenerado"].ToString());
                    des.TirajeGenerado = TirajeGe.ToString("N0");
                    //cantidad = Convert.ToInt32(read["Cantidad"].ToString());
                    //des.Sucursal = cantidad.ToString("N0");//por la cantidad despachada
                    //int nivel = Convert.ToInt32(read["Estado"].ToString());
                    //if (nivel!=1)
                    //{
                    int result = Convert.ToInt32(read["Porcentaje"].ToString());//(cantidad2 * 100) / cantidad;
                    if (result > 100)
                    {
                        des.Despachado = "ERROR";
                    }
                    else
                    {
                        if (result < 10)
                        {
                            des.Despachado = result.ToString() + "%";
                        }
                        if (result >= 10 && result < 20)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 20 && result < 30)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 30 && result < 40)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 40 && result < 50)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 50 && result < 60)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 60 && result < 70)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 70 && result < 80)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 80 && result < 90)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 90 && result < 100)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' />" + result.ToString() + "%";
                        }
                        if (result == 100)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif' />100%";
                        }
                    }
                    //}
                    //else
                    //{
                    //    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar100.gif' />100%";
                    //}

                    list.Add(des);
                }
            }
            con.CerrarConexion();
            return list.ToList();
        }








        //procedimientos de intentoo--------------------------------------------------------------
        public List<DespachoFuturosExcel> sp_ListarFuturos_Mostrar2(string Ot = "", string NombreOT = "", string Cliente = "", DateTime? fechaInicio = null, DateTime? fechaFin = null, int Procedimiento = 0)
        {
            string I = "";
            string T = "";
            List<DespachoFuturosExcel> list = new List<DespachoFuturosExcel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "sp_trigger_mostrar";//"sp_trigger_mostrar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechaFin);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);


                cmd.ExecuteNonQuery();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DespachoFuturosExcel des = new DespachoFuturosExcel();
                    des.OT = read["OT"].ToString();
                    des.NombreOT = read["NombreOT"].ToString();
                    des.Cliente = read["Cliente"].ToString();

                    DateTime fechaD = Convert.ToDateTime(read["FechaProduccion"].ToString());
                    des.FechaDes = fechaD.ToString("dd/MM/yyyy HH:mm");//read["FechaProduccion"].ToString();// Convert.ToDateTime(read["FechaProduccion"].ToString());
                    int cantidad = Convert.ToInt32(read["Tiraje"].ToString());
                    des.Cant = cantidad.ToString("N0");

                    int TirajeGe = Convert.ToInt32(read["TirajeGenerado"].ToString());
                    des.TirajeGenerado = TirajeGe.ToString("N0");
                    //cantidad = Convert.ToInt32(read["Cantidad"].ToString());
                    //des.Sucursal = cantidad.ToString("N0");//por la cantidad despachada
                    //int nivel = Convert.ToInt32(read["Estado"].ToString());
                    //if (nivel!=1)
                    //{
                    int result = Convert.ToInt32(read["Porcentaje"].ToString());//(cantidad2 * 100) / cantidad;
                    if (result > 100)
                    {
                        des.Despachado = "ERROR";
                    }
                    else
                    {
                        if (result < 10)
                        {
                            des.Despachado = result.ToString() + "%";
                        }
                        if (result >= 10 && result < 20)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 20 && result < 30)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 30 && result < 40)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 40 && result < 50)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 50 && result < 60)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 60 && result < 70)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 70 && result < 80)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 80 && result < 90)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 90 && result < 100)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' />" + result.ToString() + "%";
                        }
                        if (result == 100)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif' />100%";
                        }
                    }
                    //}
                    //else
                    //{
                    //    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar100.gif' />100%";
                    //}

                    list.Add(des);
                }
            }
            con.CerrarConexion();
            return list;
        }



        public List<DespachoFuturosExcel> sp_ListarFiltro_trigger(string Ot, string NombreOT, string Cliente, DateTime? fechaInicio = null, DateTime? fechaFin = null, int Procedimiento = 0)
        {
            string I = "";
            string T = "";
            List<DespachoFuturosExcel> list = new List<DespachoFuturosExcel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "sp_MostrarFiltro_Trigger";//"sp_trigger_mostrar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", Ot);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechaFin);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);


                cmd.ExecuteNonQuery();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DespachoFuturosExcel des = new DespachoFuturosExcel();
                    des.OT = read["OT"].ToString();
                    des.NombreOT = read["NombreOT"].ToString();
                    des.Cliente = read["Cliente"].ToString();

                    DateTime fechaD = Convert.ToDateTime(read["FechaProduccion"].ToString());

                    des.FechaDes = fechaD.ToString("dd/MM/yyyy HH:mm");// read["FechaProduccion"].ToString();// Convert.ToDateTime(read["FechaProduccion"].ToString());
                    int cantidad = Convert.ToInt32(read["Tiraje"].ToString());
                    des.Cant = cantidad.ToString("N0");

                    int TirajeGe = Convert.ToInt32(read["TirajeGenerado"].ToString());
                    des.TirajeGenerado = TirajeGe.ToString("N0");
                    //cantidad = Convert.ToInt32(read["Cantidad"].ToString());
                    //des.Sucursal = cantidad.ToString("N0");//por la cantidad despachada
                    //int nivel = Convert.ToInt32(read["Estado"].ToString());
                    //if (nivel!=1)
                    //{
                    int result = Convert.ToInt32(read["Porcentaje"].ToString());//(cantidad2 * 100) / cantidad;
                    if (result > 100)
                    {
                        des.Despachado = "ERROR";
                    }
                    else
                    {
                        if (result < 10)
                        {
                            des.Despachado = result.ToString() + "%";
                        }
                        if (result >= 10 && result < 20)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 20 && result < 30)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 30 && result < 40)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 40 && result < 50)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 50 && result < 60)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 60 && result < 70)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 70 && result < 80)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 80 && result < 90)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' />" + result.ToString() + "%";
                        }
                        if (result >= 90 && result < 100)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' />" + result.ToString() + "%";
                        }
                        if (result == 100)
                        {
                            des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif' />100%";
                        }
                    }
                    //}
                    //else
                    //{
                    //    des.Despachado = "<img src='../../Content/images/Barra%20Valoracion/bar100.gif' />100%";
                    //}

                    list.Add(des);
                }
            }
            con.CerrarConexion();
            return list;
        }




        //procedimiento excel historial de despacho

        public List<HistorialDespacho_Excel> ListarHistorialDespacho(string ot)
        {
            List<HistorialDespacho_Excel> lista = new List<HistorialDespacho_Excel>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDespacho();
            if (cmd != null)
            {
                cmd.CommandText = "Listar_Despacho";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                SqlDataReader reader = cmd.ExecuteReader();
                int totalDespachado = 0;
                while (reader.Read())
                {
                    HistorialDespacho_Excel des = new HistorialDespacho_Excel();
                    //des.OT = reader["IDGUIACAB"].ToString();
                    des.Folio = reader["NOFOLIOGUIACAB"].ToString();
                    DateTime fechaimp = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    des.FechaImpresion = fechaimp.ToString("dd/MM/yyyy HH:mm");
                    des.Destinatario = reader["NOMBREDESTINATARIOGUIACAB"].ToString();
                    des.Sucursal = reader["CALLESUCURSAL"].ToString();
                    des.Comuna = reader["NOMBRECOMUNA"].ToString();
                    int CANTIDAD = Convert.ToInt32(reader["cantidad"].ToString());
                    des.Cantidad = CANTIDAD.ToString("N0");
                    //des.StatusDes = reader["status"].ToString();
                    //if (des.StatusDes == "IMPRESO")
                    //{
                    //}
                    //des.StatusDes = "<div style='text-align:left'>" + reader["status"].ToString() + "</div>";
                    totalDespachado = totalDespachado + CANTIDAD;
                    lista.Add(des);
                }
                if (reader.Read() == false)
                {
                    HistorialDespacho_Excel de = new HistorialDespacho_Excel();
                    de.Comuna = "Total Despachado";
                    de.Cantidad = totalDespachado.ToString("N0");
                    lista.Add(de);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<DespachoLiquidar> ListaDespachosLiquidarOT(DateTime FechaInicio, DateTime FechaTermino, int Estado, int Procedimiento)
        {
            List<DespachoLiquidar> lista = new List<DespachoLiquidar>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Informe_DespachosOTLiquidacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DespachoLiquidar des = new DespachoLiquidar();
                    des.OT = reader["QG_RMS_JOB_NBR"].ToString();
                    des.Guias = reader["NOFOLIOGUIACAB"].ToString();
                    des.NombreOT = reader["NM"].ToString().ToLower();
                    des.Cliente = reader["CUST_NM"].ToString().ToLower();

                    DateTime FD = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    des.FechaDespacho = FD.ToString("dd/MM/yyyy HH:mm:ss");

                    // des.Estado = reader["IDESTADOGUIA"].ToString();
                    if (reader["IDESTADOGUIA"].ToString() == "2")
                    {
                        des.Estado = "<div style='Color:Green;'>Vigente</div>";
                    }
                    else
                    {
                        des.Estado = "<div style='Color:Red;'>Anulado</div>";
                    }


                    lista.Add(des);
                }

            }

            con.CerrarConexion();
            SqlCommand cmd2 = con.AbrirConexionIntranet();
            //abrimos por segunda vez
            if (cmd2 != null)
            {
                cmd2.CommandText = "Desp_Informe_DespachosOTLiquidacion_sinOT";
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd2.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd2.Parameters.AddWithValue("@Estado", Estado);
                cmd2.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    DespachoLiquidar des2 = new DespachoLiquidar();
                    des2.OT = reader2["QG_RMS_JOB_NBR"].ToString();
                    des2.Guias = reader2["NOFOLIOGUIACAB"].ToString();
                    des2.NombreOT = reader2["NM"].ToString();
                    des2.Cliente = reader2["CUST_NM"].ToString().Replace("<br>", "").ToLower();

                    DateTime FD = Convert.ToDateTime(reader2["FECHAIMPRESIONGUIACAB"].ToString());
                    des2.FechaDespacho = FD.ToString("dd/MM/yyyy HH:mm:ss");

                    // des.Estado = reader["IDESTADOGUIA"].ToString();
                    if (reader2["IDESTADOGUIA"].ToString() == "2")
                    {
                        des2.Estado = "<div style='Color:Green;'>Vigente</div>";
                    }
                    else
                    {
                        des2.Estado = "<div style='Color:Red;'>Anulado</div>";
                    }


                    lista.Add(des2);
                }

            }

            con.CerrarConexion();

            return lista.OrderBy(p => p.Guias).ToList();
        }



































        //*******************************************************************************************//
        public List<DiarioDetallado> Listar_informeDiario_Detallado(string ot, string nombreOT, string Cliente, DateTime FechaInicio, DateTime FechaTermino, int procedimiento)
        {
            List<DiarioDetallado> lista = new List<DiarioDetallado>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            int totalDespachado = 0;
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Lista_DetalleDespachos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DiarioDetallado des = new DiarioDetallado();
                    des.OT = reader["qg_rms_job_nbr"].ToString();
                    des.Folio = reader["NOFOLIOGUIACAB"].ToString();
                    des.NombreOT = reader["NM"].ToString().ToLower();
                    des.Cliente = reader["CALLESUCURSAL"].ToString().ToLower();

                    //des.FechaImpresion =
                    DateTime fecI = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString());
                    string algo = fecI.ToString("dd/MM/yyyy HH:mm:ss");
                    des.Despacho = algo;

                    //cantidad total
                    int total = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    des.Tiraje = total.ToString("N0");

                    //cantidad despachada
                    //des.Despachado = Convert.ToInt32(reader["cantidad"].ToString());
                    int CANTIDAD = Convert.ToInt32(reader["cantidad"].ToString());
                    des.Cantidad = CANTIDAD.ToString("N0");
                    des.Cantidad = CANTIDAD.ToString("N0");
                    totalDespachado = totalDespachado + CANTIDAD;


                    lista.Add(des);

                }


            }
            con.CerrarConexion();
            return lista;
        }

        public List<GuiaDespacho_Detalle> ListarInformeOTxRegion(string OT, string FechaInicio, string FechaTermino)
        {
            List<GuiaDespacho_Detalle> lista = new List<GuiaDespacho_Detalle>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Desp_GuiaDespacho_InfOTRegion";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    cmd.Parameters.AddWithValue("@OT", OT);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GuiaDespacho_Detalle det = new GuiaDespacho_Detalle();
                        det.OT = reader["OT"].ToString();
                        det.NombreOT = reader["NOMBREOT"].ToString();
                        det.Proveedor = Convert.ToInt32(reader["CantidadEjem"].ToString()).ToString();
                        det.Comuna = Convert.ToInt32(reader["GuiaRM"].ToString()).ToString();
                        det.Embalaje = Convert.ToInt32(reader["GuiaRegion"].ToString()).ToString();
                        lista.Add(det);
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