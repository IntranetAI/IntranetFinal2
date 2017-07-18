using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloAdministracion.Model;
using System.Data.SqlClient;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloAdministracion.Controller
{
    public class Controller_Liquidacion
    {
        public List<Liquidar> ListarOTLiquidadas(string OT, string NombreOT, string Cliente, string FechaInicio, string FechaTermino, int EstadoOT, int Procedimiento)
        {
            List<Liquidar> lista = new List<Liquidar>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Adm_OTLiquidadas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                    cmd.Parameters.AddWithValue("@Cliente", Cliente);
                    cmd.Parameters.AddWithValue("@FeInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FeTermino", FechaTermino);
                    cmd.Parameters.AddWithValue("@EstadoOT", EstadoOT);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    cmd.CommandTimeout = 45;
                    SqlDataReader reader = cmd.ExecuteReader();
                    int contador = 0;
                    while (reader.Read())
                    {
                        Liquidar liqui = new Liquidar();
                        contador++;
                        liqui.numeroFactura = contador.ToString();
                        liqui.OT = reader["numordem"].ToString();
                        liqui.NombreOT = reader["Descricao"].ToString().ToLower();
                        liqui.Cliente = reader["Cliente"].ToString().ToLower();
                        liqui.Tiraje = reader["Tiraje"].ToString();
                        liqui.EstadoOT = reader["JOB_STS"].ToString();
                        if (reader["FECHA_LIQUIDACION"].ToString() != "")
                        {
                            liqui.FechaLiquidacion = Convert.ToDateTime(reader["FECHA_LIQUIDACION"].ToString()).ToString("dd-MM-yyyy");
                        }
                        liqui.TotalDesp = reader["TotalDespachado"].ToString();
                        if (reader["FechaFactura"].ToString() != "")
                        {
                            liqui.FechaFactura = Convert.ToDateTime(reader["FechaFactura"].ToString()).ToString("dd-MM-yyyy");
                        }
                        liqui.ValorNeto = "$ " + Convert.ToInt32(reader["Totalfacturado"].ToString()).ToString("N0").Replace(",", ".");
                        liqui.VerMas = "<a style='Color:Blue;text-decoration:none;' href='javascript:Solicitud(\"" + liqui.OT + "\")'>Ver Más</a>";
                        liqui.Accion = "<a style='Color:Blue;text-decoration:none;' href='javascript:agregarNota(\"" + liqui.OT + "\")'><img alt='edit' src='../../Images/write-message.png' width='20px' height='20px'/></a>";
                        lista.Add(liqui);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }
        
        public List<Liquidar> ListarHistorialLiquidacion(string OT)
        {
            List<Liquidar> lista = new List<Liquidar>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_OTLiquidadas_ListHistorial";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT",OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Liquidar liqui = new Liquidar();
                    liqui.OT = reader["OT"].ToString();
                    liqui.NombreOT = reader["NombreOT"].ToString();
                    liqui.EstadoOT = reader["EstadoOT"].ToString();
                    liqui.FechaLiquidacion = Convert.ToDateTime(reader["FechaModificacion"].ToString()).ToString("dd-MM-yyyy");
                    liqui.Cliente = reader["ModificadaPor"].ToString();//modificadopor
                    liqui.numeroFactura = reader["Observacion"].ToString();//observacion
                    lista.Add(liqui);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Liquidar> ListarHistorialNotas(string OT)
        {
            List<Liquidar> lista = new List<Liquidar>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_Nota_listHistorial";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT",OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Liquidar liquidar = new Liquidar();
                    liquidar.OT = reader["OT"].ToString();
                    liquidar.NombreOT = reader["NombreOT"].ToString();
                    liquidar.Cliente = reader["Cliente"].ToString();
                    liquidar.VerMas = reader["CorreosResponsable"].ToString();//vendedor
                    liquidar.Accion = reader["Clasificacion"].ToString();//Clasificacion
                    liquidar.Tiraje = reader["TipoNota"].ToString();//TipoNota
                    liquidar.numeroFactura = reader["Observacion"].ToString();//Observacion
                    liquidar.FechaFactura = Convert.ToDateTime(reader["FechaCreacion"].ToString()).ToString("dd-MM-yyyy");//FechaCreacion
                    lista.Add(liquidar);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Liquidar> ListarDetalle()
        {
            List<Liquidar> lista = new List<Liquidar>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_ListarTipoNotas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Liquidar li = new Liquidar();
                    li.TotalDesp = reader["ID_TipoNota"].ToString();
                    li.OT = reader["Nombre_tipoNota"].ToString();
                    lista.Add(li);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public int AgregarNota(Liquidar liqui)
        {
            int respuesta = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_controlFacturacionAgregar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT",liqui.OT);
                cmd.Parameters.AddWithValue("@NombreOT", liqui.NombreOT);
                cmd.Parameters.AddWithValue("@cliente", liqui.Cliente);
                cmd.Parameters.AddWithValue("@Responsable", liqui.Tiraje);
                cmd.Parameters.AddWithValue("@Clasificacion", liqui.Accion);
                cmd.Parameters.AddWithValue("@TipoNota", liqui.FechaFactura);
                cmd.Parameters.AddWithValue("@Usuario", liqui.EstadoOT);
                cmd.Parameters.AddWithValue("@Observacion", liqui.VerMas);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = Convert.ToInt32(reader["respuesta"].ToString());
                }
            }
            con.CerrarConexion();
            return respuesta;
        }

        public List<Liquidar> ListarDetalleFacturacion(string OT)
        {
            List<Liquidar> lista = new List<Liquidar>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_OTLiquidadas_detalle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OTs", OT);
                cmd.Parameters.AddWithValue("@mes","1");
                cmd.Parameters.AddWithValue("@año", "2013");
                cmd.Parameters.AddWithValue("@dia", "30");
                cmd.Parameters.AddWithValue("@procedimiento",2);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Liquidar li = new Liquidar();
                    li.numeroFactura = reader["Foli_docu"].ToString();
                    li.FechaLiquidacion = reader["fech_emis"].ToString();
                    li.OT = reader["detalle"].ToString();//Detalle
                    li.Tiraje = Convert.ToInt32(reader["cant_item"].ToString()).ToString("N0").Replace(",",".");
                    li.ValorNeto = Convert.ToInt32(reader["neto_item"].ToString()).ToString("N0").Replace(",", ".");
                    li.TotalDesp = reader["prec_item"].ToString();//precio de los item
                    li.VerMas = "Ver Más";
                    lista.Add(li);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Liquidar> CorreosResposable(string CentroCosto, string OT)
        {
            List<Liquidar> lista = new List<Liquidar>();
            string Correos = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ControlFacturacion_ListCorreo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Asunto", CentroCosto);
                cmd.Parameters.AddWithValue("@OT", OT);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Liquidar li = new Liquidar();
                    li.Accion = reader["Correo"].ToString();
                    li.NombreOT = reader["Nombre"].ToString();
                    lista.Add(li);
                }
                con.CerrarConexion();
            }
            return lista;
        }

        public List<Desp_InfPorOT> ListarDespachos(string OT, int Procedimiento)
        {
            List<Desp_InfPorOT> lista = new List<Desp_InfPorOT>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "adm_CargaDespachos";//cambio era el 1 pero esta qgguiadespacho y se duplico
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Desp_InfPorOT des = new Desp_InfPorOT();
                    des.FechaImpresion = Convert.ToDateTime(reader["FECHAIMPRESIONGUIACAB"].ToString()).ToString("dd/MM/yyy HH:mm");
                    string TipoMovimiento = reader["TipoMovimiento"].ToString();
                    if (TipoMovimiento == "Despacho")
                    {
                        des.TipoMovimiento = "<div style='Color:Green;'>Despacho</div>";
                    }
                    else if (TipoMovimiento == "Egreso Ejemplares")
                    {
                        des.TipoMovimiento = "<div style='Color:Green;'>Egreso Ejemplares</div>";
                    }
                    else
                    {
                        des.TipoMovimiento = "<div style='Color:Red;'>Devolucion</div>";
                    }

                    des.Folio = reader["NOFOLIOGUIACAB"].ToString();
                    if (TipoMovimiento == "Egreso Ejemplares")
                    {
                        des.Sucursal = reader["NM"].ToString() + ": " + reader["CUST_NM"].ToString() + "<br/>" + reader["CALLESUCURSAL"].ToString();
                    }
                    else
                    {
                        des.Sucursal = reader["CALLESUCURSAL"].ToString().ToLower();
                    }
                    des.Despachado = Convert.ToInt32(reader["total"].ToString()).ToString("N0").Replace(",", ".");
                    lista.Add(des);
                }

            }
            con.CerrarConexion();
            return lista;
        }

        public string ListaDetalleDespachos(string OT, int Procedimiento)
        {
            string Encabezado = "<table align='right' id='tblRegistro' runat='server' cellpadding='0' cellspacing='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:560px;margin-left:3px;'>" +
                    "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style1'>" +
                            "Total Recepcionado</td>" +
                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style1'>" +
                            "Tiraje OT</td>" +

                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style1'>" +
                            "Despachado Cliente</td>   " +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style1'>" +
                            "Muestras</td> " +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style1'>" +
                            "Rezago</td> " +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;' class='style1'>" +
                            "Existencia</td>" +
                        "</tr>";
            string Contenido = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "adm_CargaDespachos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int Tiraje = Convert.ToInt32(reader["Tiraje"].ToString());
                    int Despachado = Convert.ToInt32(reader["TotalDespachado"].ToString());
                    int Recepcionado = Convert.ToInt32(reader["Recepcionado"].ToString());
                    int Especiales = Convert.ToInt32(reader["Especiales"].ToString());
                    int DevolucionInterna = Convert.ToInt32(reader["DevolucionInterna"].ToString());
                    int DevolucionCliente = Convert.ToInt32(reader["DevolucionCliente"].ToString());
                    int DevolucionGeneral = Convert.ToInt32(reader["DevolucionGeneral"].ToString());
                    int EgresoSobrantes = Convert.ToInt32(reader["EgresoSobrantes"].ToString());
                    int EgresoEspeciales = Convert.ToInt32(reader["EgresoEspeciales"].ToString());
                    int TDesp = (Despachado - DevolucionCliente - DevolucionGeneral);
                    int TRecep = (Recepcionado - DevolucionInterna - DevolucionGeneral);
                    int Existencia = (Tiraje - (Recepcionado - DevolucionInterna - DevolucionGeneral - EgresoEspeciales - EgresoSobrantes)) * -1;
                    int exi = 0;
                    int DescEspeciales = Especiales - EgresoEspeciales;
                    if (Existencia > 0)
                    {
                        exi = Existencia;
                    }
                    else
                    {
                        exi = 0;
                    }

                    int Rezago = Convert.ToInt32(reader["Rezago"].ToString());
                    Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;'>" +
                         "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            TRecep.ToString("N0").Replace(",", ".") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Tiraje.ToString("N0").Replace(",", ".") + "</td>" +

                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            TDesp.ToString("N0").Replace(",", ".") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            DescEspeciales.ToString("N0").Replace(",", ".") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Rezago.ToString("N0").Replace(",", ".") + "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            Existencia.ToString("N0").Replace(",", ".") + "</td>" +
                    "</tr>";
                }
            }
            con.CerrarConexion();
            return Encabezado + Contenido + "</table>";
        }

        public string TotalNetoFacturamesActual(string MesInicio, string AñoInicio, string TextoMes)
        {
            string Resultado = "<table align='left' id='tblRegistro' runat='server' cellpadding='0' cellspacing='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 10px; margin-bottom: 0px;margin-left:0px;'>" +
                    "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                            "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            "Total Facturado " + TextoMes + "</td>";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Adm_OTLiquidadas_detalle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OTs","sin OT");
                cmd.Parameters.AddWithValue("@mes", MesInicio);
                cmd.Parameters.AddWithValue("@año", AñoInicio);
                cmd.Parameters.AddWithValue("@dia", DateTime.DaysInMonth(Convert.ToInt32(AñoInicio), Convert.ToInt32(MesInicio)));
                cmd.Parameters.AddWithValue("@procedimiento", 1);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Resultado +=
                         "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;'>" + Convert.ToDouble(reader["Valor"]).ToString("N0").Replace(",", ".") + "</td></tr>";
                }
                Resultado += "</table>";
            }
            con.CerrarConexion();
            return Resultado;
        }

    }
}