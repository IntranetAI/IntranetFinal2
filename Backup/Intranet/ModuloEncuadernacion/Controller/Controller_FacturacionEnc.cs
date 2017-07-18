using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloEncuadernacion.Model;
using System.Data.SqlClient;

namespace Intranet.ModuloEncuadernacion.Controller
{
    public class Controller_FacturacionEnc
    {
        public List<FacturacionEnc> ListaFacturacionEnc(string OT,string NombreOT,DateTime FechaInicio,DateTime FechaTermino,int Procedimiento)
        {
            List<FacturacionEnc> lista = new List<FacturacionEnc>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "FacturacionEnc_Listar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FacturacionEnc f = new FacturacionEnc();
                    f.OT = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame2(\"" + reader["OT"].ToString() + "\")'>" + reader["OT"].ToString() + "</a>";
                    if (reader["NombreOT"].ToString().Length > 35)
                    {
                        f.NombreOT = reader["NombreOT"].ToString().Substring(0, 35) + "...";
                    }
                    else
                    {
                        f.NombreOT = reader["NombreOT"].ToString();
                    }
                    
                    f.Tiraje = Convert.ToInt32(reader["Tiraje"].ToString()).ToString("N0").Replace(",", ".");
                    f.DespachadoEnc = Convert.ToInt32(reader["DespEnc"].ToString()).ToString("N0").Replace(",", ".");
                    f.RecepcionadoDespacho = Convert.ToInt32(reader["RecepDesp"].ToString()).ToString("N0").Replace(",", ".");
                    f.Devolucion = Convert.ToInt32(reader["Devolucion"].ToString()).ToString("N0").Replace(",", ".");
                    int s = (Convert.ToInt32(reader["Tiraje"].ToString()) - (Convert.ToInt32(reader["RecepDesp"].ToString()) - Convert.ToInt32(reader["Devolucion"].ToString())));
                    if (s > 0) 
                    {
                        f.Saldo = "<div style='color:Red;'>" + s.ToString("N0").Replace(",",".") + "</div>";
                    }
                    else if (s < 0)
                    {
                        f.Saldo = "<div style='color:Green;'>" + s.ToString("N0").Replace(",", ".").Replace("-", "") + "</div>";
                    }
                    else
                    {
                        f.Saldo = s.ToString();
                    }
                    
                    f.FechaEntrega = Convert.ToDateTime(reader["FechaEntrega"].ToString()).ToString("dd/MM/yyyy");
                    f.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + reader["OT"].ToString() + "\")'>Ver Más</a>";
                    lista.Add(f);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }



        public List<FacturacionEnc> DespachoEncuadernacion(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            List<FacturacionEnc> lista = new List<FacturacionEnc>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "FacturacionEnc_Listar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FacturacionEnc f = new FacturacionEnc();
                    f.OT = reader["OT"].ToString();
                    f.Cod_Pallet = reader["Cod_Pallet"].ToString();
                    f.Terminacion = reader["Terminacion"].ToString();
                    f.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    f.Cantidad = Convert.ToInt32(reader["Cantidad"].ToString()).ToString("N0").Replace(",", ".");
                    f.Ejemplares = Convert.ToInt32(reader["Ejemplares"].ToString()).ToString("N0").Replace(",", ".");;
                    f.Total = Convert.ToInt32(reader["Total"].ToString()).ToString("N0").Replace(",", "."); ;
                    f.Modelo = reader["Modelo"].ToString();
                    f.Observacion = reader["Observacion"].ToString();
                    f.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    lista.Add(f);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        public int PliegosProcesos(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            int p = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "FacturacionEnc_Listar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    p = Convert.ToInt32(reader["Pliegos"].ToString());
                }
            }
            con.CerrarConexion();
            return p;
        }
        public int PliegosProcesos2(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            int p = 0;
            string a="";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "FacturacionEnc_Listar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    a = reader["Pliegos"].ToString();
                    if (reader["Pliegos"].ToString().Contains("-"))
                    {
                        p = p + 2;
                    }
                    else if (reader["Pliegos"].ToString() == "999")
                    {
                        p = p - 1;
                    }
                    else if (reader["Pliegos"].ToString() == "998")
                    {

                    }
                    else
                    {
                        p = p + 1;
                    }


                }
            }
            con.CerrarConexion();
            return p;
        }
        public int Despachado(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            int p = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "FacturacionEnc_Listar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    p = Convert.ToInt32(reader["Pliegos"].ToString());
                }
            }
            con.CerrarConexion();
            return p;
        }



        public List<FacturacionEnc> ValorizacionProcesos(string OT, int Pliegos)
        {
            List<FacturacionEnc> lista = new List<FacturacionEnc>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionINFORMEENC();
            DateTime fe = Convert.ToDateTime("1900-01-01");
            int desp = Despachado(OT, "", fe, fe, 7);
            string proceso = "";
            if (cmd != null)
            {
                cmd.CommandText = "Enc_Facturacion_ProcesosOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (proceso != reader["nombre_Proceso"].ToString().Trim())
                    {
                        proceso = reader["nombre_Proceso"].ToString().Trim();
                        if (reader["nombre_Proceso"].ToString().Trim() == "EMBOLSADO")
                        {
                            FacturacionEnc f = new FacturacionEnc();
                            f.OT = reader["OT"].ToString();
                            f.Maquina = reader["Maquina"].ToString();
                            f.idMaquina = reader["idMaquina"].ToString();
                            f.ProcesoReal = reader["nombre_Proceso"].ToString();
                            f.Proceso = "Embolsado Solo";
                            f.Cantidad = Convert.ToInt32(reader["CANTIDAD"].ToString()).ToString("N0").Replace(",", ".");
                            f.ValorUnitario = "$ 12";
                           // f.Total = "$ " + ((Convert.ToInt32(f.Cantidad.Replace(".", "").Replace("$", "").Trim()) * (Convert.ToInt32(f.ValorUnitario.Replace(".", "").Replace("$", "").Trim()))) +
                            f.Total = "$ " + ((Convert.ToInt32(desp.ToString().Replace(".", "").Replace("$", "").Trim()) * (Convert.ToInt32(f.ValorUnitario.Replace(".", "").Replace("$", "").Trim()))) +
                            Convert.ToInt32(PrecioUnitario(f.ProcesoReal.ToString().Trim(), Pliegos.ToString(), fe, fe, 4)) ).ToString("N0").Replace(",", ".");
                            f.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                            f.CantidadDesp = desp.ToString("N0").Replace(",", ".");
                            f.CantidadDespOriginal = desp.ToString("N0").Replace(",", ".");
                            f.Ejemplar = "1";
                            lista.Add(f);
                        }
                        else
                        {

                            FacturacionEnc f = new FacturacionEnc();
                            f.OT = reader["OT"].ToString();
                            f.Maquina = reader["Maquina"].ToString();
                            f.idMaquina = reader["idMaquina"].ToString();
                            f.ProcesoReal = reader["nombre_Proceso"].ToString();
                            if (f.ProcesoReal == "ENTAPE")
                            {
                                if (f.idMaquina != "100020" && f.idMaquina != "100021" && f.idMaquina != "100019")
                                {
                                    f.Proceso = PrecioUnitario("Alzado + (pretaco) hotmelt", "", fe, fe, 5);
                                    f.ProcesoReal = "Alzado + (pretaco) hotmelt";
                                }
                                else
                                {
                                    f.Proceso = PrecioUnitario(reader["nombre_Proceso"].ToString().Trim(), "", fe, fe, 5);
                                }
                            }
                            else
                            {
                                f.Proceso = PrecioUnitario(reader["nombre_Proceso"].ToString().Trim(), "", fe, fe, 5);

                            }
                            f.Cantidad = Convert.ToInt32(reader["CANTIDAD"].ToString()).ToString("N0").Replace(",", ".");
                            if (reader["Material"].ToString().Trim() == "4")
                            {
                                f.ValorUnitario = "0";
                                f.Total = "0";
                            }
                            else
                            {
                                if (f.idMaquina != "100471" && f.idMaquina != "100121" && f.idMaquina != "100451")
                                {
                                    f.ValorUnitario = "$ " + PrecioUnitario(f.ProcesoReal.Trim(), Pliegos.ToString(), fe, fe, 3);
                                    f.Total = "$ " + ((Convert.ToInt32(desp.ToString().Replace(".", "").Replace("$", "").Trim()) * (Convert.ToInt32(f.ValorUnitario.Replace(".", "").Replace("$", "").Trim()))) +
                                Convert.ToInt32(PrecioUnitario(f.ProcesoReal.ToString().Trim(), Pliegos.ToString(), fe, fe, 4)) ).ToString("N0").Replace(",", ".");
                                }
                                else
                                {
                                    f.ValorUnitario = "0";
                                    f.Total = "0";
                                }
                            }

                            f.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                            f.CantidadDesp = desp.ToString("N0").Replace(",", ".");
                            f.CantidadDespOriginal = desp.ToString("N0").Replace(",", ".");
                            f.Ejemplar = "1";
                            lista.Add(f);
                        }
                    }
                }
                if (reader.Read() == false)
                {
                    

                    if (PrecioUnitario(OT, "", fe, fe, 6) != "0")
                    {
                        FacturacionEnc f = new FacturacionEnc();
                        f.OT = OT;
                        f.Maquina = "";
                        f.idMaquina = "";
                        f.ProcesoReal = "";
                        f.Proceso = "Manualidades Encajado Simple";
                        f.Cantidad = PrecioUnitario(OT, "", fe, fe, 6);
                        f.ValorUnitario = "$ 121";
                        f.Total = "$ " + (Convert.ToInt32(f.Cantidad) * 121).ToString("N0").Replace(",", ".");
                        f.Fecha = DateTime.Now;
                        f.DespachadoEnc = f.Cantidad;
                        f.CantidadDesp = f.Cantidad;
                        f.CantidadDespOriginal = f.Cantidad;
                        f.Ejemplar = "1";
                        lista.Add(f);
                    }

                    if (PrecioUnitario(OT, "", fe, fe, 14) != "0")
                    {
                        FacturacionEnc f = new FacturacionEnc();
                        f.OT = OT;
                        f.Maquina = "";
                        f.idMaquina = "";
                        f.ProcesoReal = "";
                        f.Proceso = "Manualidades CMC";
                        f.Cantidad = PrecioUnitario(OT, "", fe, fe, 14);
                        f.ValorUnitario = "$ 76";
                        f.Total = "$ " + (Convert.ToInt32(f.Cantidad) * 76).ToString("N0").Replace(",", ".");
                        f.Fecha = DateTime.Now;
                        f.DespachadoEnc = f.Cantidad;
                        f.CantidadDesp = f.Cantidad;
                        f.CantidadDespOriginal = f.Cantidad;
                        f.Ejemplar = "1";
                        lista.Add(f);
                    }
                    if (PrecioUnitario(OT, "", fe, fe, 15) != "0")
                    {
                        FacturacionEnc f = new FacturacionEnc();
                        f.OT = OT;
                        f.Maquina = "";
                        f.idMaquina = "";
                        f.ProcesoReal = "";
                        f.Proceso = "Manualidades Empaquetado";
                        f.Cantidad = PrecioUnitario(OT, "", fe, fe, 15);
                        f.ValorUnitario = "$ 73";
                        f.Total = "$ " + (Convert.ToInt32(f.Cantidad) * 73).ToString("N0").Replace(",", ".");
                        f.Fecha = DateTime.Now;
                        f.DespachadoEnc = f.Cantidad;
                        f.CantidadDesp = f.Cantidad;
                        f.CantidadDespOriginal = f.Cantidad;
                        f.Ejemplar = "1";
                        lista.Add(f);
                    }
                }
            }
            conexion.CerrarConexion();
            return lista;
        }
                    
                    
        public string PrecioUnitario(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "FacturacionEnc_Listar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        resultado = reader["PrecioUnitario"].ToString();
                    }
                    if (resultado == "")
                    {
                        resultado = "0";
                    }

            }
            con.CerrarConexion();
            return resultado;
        }




        public int IngresoPreFactura(FacturacionEnc f, int Procedimiento)
        {
            int p = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "FacturacionEnc_CrearPreFactura";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroPreFactura", f.NroPreFactura);
                cmd.Parameters.AddWithValue("@OT", f.OT);
                cmd.Parameters.AddWithValue("@Proceso", f.Proceso);
                cmd.Parameters.AddWithValue("@Maquina", f.Maquina);
                cmd.Parameters.AddWithValue("@Producido", f.Cantidad);
                cmd.Parameters.AddWithValue("@DespachoReal", f.CantidadDespOriginal);
                cmd.Parameters.AddWithValue("@Despachado", f.DespachadoEnc);
                cmd.Parameters.AddWithValue("@Ejemplar", f.Ejemplar);
                cmd.Parameters.AddWithValue("@PrecioUnitario", f.ValorUnitario);
                cmd.Parameters.AddWithValue("@Total", f.Total);
                cmd.Parameters.AddWithValue("@Usuario", f.Usuario);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    p = Convert.ToInt32(reader["respuesta"].ToString());
                }
            }
            con.CerrarConexion();
            return p;
        }

        public bool verificarPreFactura(string OT, string NombreOT, DateTime FechaInicio, DateTime FechaTermino, int Procedimiento)
        {
             bool respuesta = true;
            SqlDataReader dr;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                    cmd.CommandText = "FacturacionEnc_Listar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
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
            con.CerrarConexion();
            return respuesta;
        }


        public List<FacturacionEnc> FacturacionParcial(string OT,string NombreOT,DateTime FI,DateTime FT, int Procedimiento)
        {
            List<FacturacionEnc> lista = new List<FacturacionEnc>();
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            DateTime fe = Convert.ToDateTime("1900-01-01");
            if (cmd != null)
            {
                cmd.CommandText = "[FacturacionEnc_Listar]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@FechaInicio", FI);
                cmd.Parameters.AddWithValue("@FechaTermino", FT);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FacturacionEnc f = new FacturacionEnc();
                    int despachadoReal = Convert.ToInt32(reader["DespachadoReal"].ToString());
                    int despachado = Convert.ToInt32(reader["Despachado"].ToString());
                    int restante = despachadoReal - despachado;
                    if (restante == 0)
                    {
                        f.OT = reader["OT"].ToString();
                        f.Proceso = reader["Proceso"].ToString();
                        f.Maquina = reader["Maquina"].ToString();
                        f.Cantidad = Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".");
                        f.ValorUnitario = "$ " + reader["PrecioUnitario"].ToString();
                        f.CantidadDespOriginal = Convert.ToInt32(despachadoReal).ToString("N0").Replace(",", ".");
                        f.CantidadDesp = "0";
                        f.DespachadoEnc = "0";
                        f.Total = "$ 0";
                        f.Ejemplar = "0";
                    }
                    else
                    {
                        double despachadoReald = Convert.ToDouble(reader["DespachadoReal"].ToString());
                        double despachadod = Convert.ToDouble(reader["Despachado"].ToString());

                        f.OT = reader["OT"].ToString();
                        f.Proceso = reader["Proceso"].ToString();
                        f.Maquina = reader["Maquina"].ToString();
                        f.Cantidad = Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",", ".");
                        f.ValorUnitario ="$ "+ reader["PrecioUnitario"].ToString();
                        f.CantidadDespOriginal = Convert.ToInt32(despachadoReal.ToString()).ToString("N0").Replace(",", ".");
                        f.CantidadDesp = Convert.ToInt32(restante.ToString()).ToString("N0").Replace(",", ".");
                        f.DespachadoEnc = Convert.ToInt32(restante.ToString()).ToString("N0").Replace(",", ".");
                        f.Total = "$ " + (Convert.ToInt32(f.CantidadDesp.Replace(".", "")) * Convert.ToInt32(f.ValorUnitario.Replace("$", ""))).ToString("N0").Replace(",", ".");
                        f.Ejemplar = (despachadod / despachadoReald).ToString();
                    }

                    
                    lista.Add(f);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }


        public FacturacionEnc BuscaOT(string OT)
        {
            FacturacionEnc ls = null;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "FacturacionEnc_BuscaOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ls = new FacturacionEnc();

                    ls.OT = reader["OT"].ToString();
                    ls.NombreOT = reader["NombreOT"].ToString();
                    ls.Tiraje = reader["Tiraje"].ToString();
                    ls.DespachadoEnc = reader["Despachado"].ToString();
                }

            }
            conexion.CerrarConexion();

            return ls;
        }



        public List<FacturacionEnc> ListaPrefacturas(string OT)
        {
            List<FacturacionEnc> lista = new List<FacturacionEnc>();

            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            int total = 0;
            if (cmd != null)
            {
                cmd.CommandText = "FacturacionEnc_ListaPreFacturas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FacturacionEnc f = new FacturacionEnc();
                    f.NroPreFactura = reader["NroPreFactura"].ToString();
                    f.Proceso = reader["Proceso"].ToString();
                    f.Maquina = reader["Maquina"].ToString();
                    f.Cantidad = Convert.ToInt32(reader["Producido"].ToString()).ToString("N0").Replace(",",".");
                    f.DespachadoEnc = Convert.ToInt32(reader["DespachadoReal"].ToString()).ToString("N0").Replace(",", ".");
                    f.Facturado = Convert.ToInt32(reader["Facturado"].ToString()).ToString("N0").Replace(",", ".");
                    f.Total = "$ " + Convert.ToInt32(reader["Total"].ToString()).ToString("N0").Replace(",", ".");
                    f.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:ss");
                    total = total + Convert.ToInt32(reader["Total"].ToString());
                    lista.Add(f);
                }
                if (reader.Read() == false)
                {
                    FacturacionEnc f = new FacturacionEnc();
                    f.NroPreFactura = "";
                    f.Proceso = "";
                    f.Maquina = "";
                    f.Cantidad = "";
                    f.DespachadoEnc = "";
                    f.Facturado = "";
                    f.Total = "Total:";
                    f.FechaCreacion = "$" + Convert.ToInt32(total).ToString("N0").Replace(",", ".");
                    lista.Add(f);
                }
            }
            conexion.CerrarConexion();
            return lista;
        }
    }
}