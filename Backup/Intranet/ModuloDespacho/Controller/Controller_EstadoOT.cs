using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.Controller
{
    public class Controller_EstadoOT
    {
        public List<EstadoOT_Mejora> ListarEstadoOT(string ot,string nombreot,string cliente,DateTime fechai,DateTime fechat,string estado,int procedimiento)
        {
            List<EstadoOT_Mejora> lista = new List<EstadoOT_Mejora>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_EstadoOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombreot);
                cmd.Parameters.AddWithValue("@Cliente", cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", fechai);
                cmd.Parameters.AddWithValue("@FechaTermino", fechat);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                cmd.CommandTimeout = 99999999;
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    EstadoOT_Mejora d = new EstadoOT_Mejora();
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString().ToLower();
  
                    int tiraje = Convert.ToInt32(reader["Tiraje"].ToString());
                    int despachado = Convert.ToInt32(reader["TotalDespachado"].ToString());
                    int devueltoInt = Convert.ToInt32(reader["DevolucionInterna"].ToString());
                    int devueltoCli = Convert.ToInt32(reader["DevolucionCliente"].ToString());
                    int devueltoGen = Convert.ToInt32(reader["DevolucionGeneral"].ToString());
                    int recepcionado = Convert.ToInt32(reader["Recepcionado"].ToString());
                    int EgresoSob = Convert.ToInt32(reader["EgresoSobrantes"].ToString());
                    int EgresoEsp = Convert.ToInt32(reader["EgresoEspeciales"].ToString());

                    d.Tiraje = tiraje.ToString("N0").Replace(",", ".");
                    d.Despachado = (despachado - devueltoCli - devueltoGen).ToString("N0").Replace(",", ".");
                    d.Recepcionado = (recepcionado - devueltoInt - devueltoGen).ToString("N0").Replace(",", ".");
                    d.DevolucionCliente = (devueltoCli + devueltoGen + devueltoInt).ToString("N0").Replace(",", ".");
                    d.Especiales = Convert.ToInt32(reader["Especiales"].ToString()).ToString("N0").Replace(",", ".");

                    int existencia = (tiraje - (recepcionado - devueltoInt - devueltoGen - EgresoSob));
                    d.Saldo = existencia.ToString("N0").Replace(",", ".");
                    int exists = ((recepcionado - devueltoInt - devueltoGen) - (despachado - devueltoCli - devueltoGen));
                    d.Existencia = exists.ToString("N0").Replace(",", ".");


                    if (exists < 0)
                    {
                        d.Existencia = "<div style='color:Red;'>" + (exists).ToString("N0").Replace(",", ".") + "</div>";
                    }
                    else
                    {
                        d.Existencia = (exists).ToString("N0").Replace(",", ".");
                    }





                    int DespOT = tiraje - despachado;

                    if (reader["FechaMinima"].ToString() == "1/1/1900 12:00:00 AM")
                    {
                        d.FechaMinima = "<div align='center'>-</div>";
                    }
                    else
                    {
                        d.FechaMinima = Convert.ToDateTime(reader["FechaMinima"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    }
                    if (reader["FechaMaxima"].ToString() == "1/1/1900 12:00:00 AM")
                    {
                        d.FechaMaxima = "<div align='center'>-</div>";
                    }
                    else
                    {
                        d.FechaMaxima = Convert.ToDateTime(reader["FechaMaxima"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    }




                    if (existencia > 0)
                    {
                        d.Saldo = "<div style='color:Red;'>" + (existencia * -1).ToString("N0").Replace(",", ".") + "</div>";
                    }
                    else
                    {
                        d.Saldo = (existencia * -1).ToString("N0").Replace(",", ".");
                    }
                    if (reader["Estado"].ToString() == "A")
                    {
                        if (DespOT <= 0)
                        {
                            d.Estado = "<div style='Color:Red;'><a style='Color:Red;text-decoration:none;' href='LiquidarOT.aspx?id=8&Cat=6&va=" + d.OT + "'>Por Liquidar</a></div>";
                        }
                        else
                        {
                            d.Estado = "<div style='Color:Blue;'><a style='Color:Blue;text-decoration:none;' href='LiquidarOT.aspx?id=8&Cat=6&va=" + d.OT + "'>En Proceso</a></div>";
                        }
                    }
                    else
                    {
                        d.Estado = "<div style='Color:Green;'><a style='Color:Green;text-decoration:none;' href='LiquidarOT.aspx?id=8&Cat=6&va=" + d.OT + "'>Liquidada</a></div>";
                    }
                   
                    lista.Add(d);
                }
               
            }
            con.CerrarConexion();
            return lista;
        }

        public Estado_OT BuscarOTLiquidar(string ot, int procedimiento)
        {
            Conexion con = new Conexion();
            Estado_OT des = new Estado_OT();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_LiquidarOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Estado", 1);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    //des.OT = reader["QG_RMS_JOB_NBR"].ToString();
                    des.NombreOT = reader["NM"].ToString();
                    des.TirajeTotal = reader["PRN_ORD_QTY"].ToString();
                    des.Estado = reader["JOB_STS"].ToString();
                    des.FechaMaxima = reader["FECHA_LIQUIDACION"].ToString();
                    des.Cliente = reader["CUST_NM"].ToString();
                    
                    //datos adicionales
                    des.Devolucion = reader["Devolucion"].ToString();
                    des.OT = reader["FechaMinima"].ToString();
                    des.Saldo = reader["FechaMaxima"].ToString();
                    des.TotalDespachado = reader["TotalDespachado"].ToString();

                }
            }
            con.CerrarConexion();
            return des;
        }

        public bool CambiarEstadoOT( string OT, int Estado)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionDataP2B2000_DataP2B();
            try
            {

                cmd.CommandText = "Desp_CambiarEstadoOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Estado", Estado);

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

        public bool CambiarEstadoOT_Local(string OT, int Estado)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_CambiarEstadoOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Estado", Estado);

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

        public bool CambiarEstadoOT_Metrics(string OT, int Estado)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_CambiarEstadoOT_Metrics";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Estado", Estado);

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


        public bool Historial_Liquidadas(string OT,string NombreOT,string Cliente,int Tiraje, int Estado,string Observacion,string ModificadaPor)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_Insert_HistorialLiquidadas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@Tiraje", Tiraje);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@ModificadaPor", ModificadaPor);
                
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

        public Estado_OT BuscarOT(string ot, int procedimiento)
        {
            Estado_OT des = new Estado_OT();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Egresos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    des.NombreOT = reader["NombreOT"].ToString();
                    des.Cliente = reader["Cliente"].ToString();
                    
                }

            }
            con.CerrarConexion();
            return des;
        }



        public string BuscaExistencia(string ot, int procedimiento)
        {
            string Encabezado = "<table id='tblRegistro' runat='server' cellpadding='0' cellspacing='0' " +
                    "style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:940px;margin-left:45px;'>" +
                    "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                    "       OT </td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:500px;'>" +
                            "Nombre OT</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:200px;'>" +
                            "Tipo Ejemplar</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                            "Saldo en Existencia</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                            "</td>" +

                    "</tr>";
            string Contenido = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                int cantidad = 0;
                int egresos = 0;
                int nuevaC = 0;
                cmd.CommandText = "Desp_Egresos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cantidad = Convert.ToInt32(reader["Cantidad"].ToString());
                    egresos = Convert.ToInt32(reader["Egresos"].ToString());
                    nuevaC = cantidad - egresos;
                    if (nuevaC > 0)
                    {
                        Contenido = Contenido + "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;'>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["OT"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                            reader["NombreOT"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            reader["Tipo"].ToString() + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            nuevaC.ToString("N0").Replace(",", ".") + "</td>" +
                            "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                            "<a style='Color:Blue;text-decoration:none;cursor:pointer;' href='javascript:CargaTipo(\"" + reader["Tipo"].ToString() + "\",\"" + nuevaC.ToString() + "\");'>Seleccionar</a>" + "</td>" +
                        "<tr>";
                    }
                }

            }
            con.CerrarConexion();
            return Encabezado + Contenido + "</table>";
        }



        public List<Estado_OT> ListarArea(string ot, int procedimiento)
        {
            List<Estado_OT> lista = new List<Estado_OT>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_Egresos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Estado_OT des = new Estado_OT();
                    if (procedimiento == 2 || procedimiento == 4 || procedimiento == 5 || procedimiento == 6 || procedimiento == 7 || procedimiento == 8 || procedimiento == 9 || procedimiento==10 || procedimiento==11)
                    {
                        des.Cliente = reader["Usuario"].ToString().ToLower();
                    }
                    else if (procedimiento == 3)
                    {
                        string[] a = reader["Usuario"].ToString().ToLower().Split(' ');
                        try
                        {
                            if (a.Count() == 3)
                            {
                                des.Cliente = a[0] + " " + a[1];
                            }
                            else
                            {
                                des.Cliente = a[0] + " " + a[2];
                            }
                        }
                        catch
                        {
                            des.Cliente = reader["Usuario"].ToString().ToLower();
                        }

                    }
                    lista.Add(des);
                }

            }
            con.CerrarConexion();
            return lista;
        }


        public bool IngresaEgreso(string OT, string NombreOT, string Tipo,int Cantidad,string AreaEntrega,string Usuario,string Motivo,string Observacion,string CreadoPor,int Procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = false;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "Desp_EgresosEjemplares";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@AreaEntrega", AreaEntrega);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Motivo", Motivo);
                cmd.Parameters.AddWithValue("@Observacion", Observacion);
                cmd.Parameters.AddWithValue("@CreadoPor", CreadoPor);
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
            conexion.CerrarConexion();
            return respuesta;
        }


        //Desp_PreGuias
        public List<Desp_PreGuia> ListaPreGuiasDespacho(string ot, int Estado ,int procedimiento)
        {
            List<Desp_PreGuia> lista = new List<Desp_PreGuia>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Desp_PreGuias";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Desp_PreGuia d = new Desp_PreGuia();
                    d.OT = reader["OT"].ToString();
                    d.NombreOT = reader["NombreOT"].ToString().ToLower();
                    switch (Convert.ToInt32(reader["Estado"]))
                    {
                        case 1:
                            d.Estado = "En Proceso";
                            break;
                        case 2:
                            d.Estado = "Impreso";
                            break;
                        case 3:
                            d.Estado = "Anulado";
                            break;
                        case 4:
                            d.Estado = "En Creación";
                            break;
                    }
                    d.NroPreGuia = reader["NroPreGuia"].ToString();
                    d.NroGuia = reader["NroGuia"].ToString();
                    d.Sucursal = reader["CALLESUCURSAL"].ToString().ToLower();
                    string a = reader["FECHAIMPRESION"].ToString();
                    if (reader["FECHAIMPRESION"].ToString() == "1/1/1900 12:00:00 AM")
                    {
                        d.FechaDespacho = "";
                    }
                    else
                    {
                        d.FechaDespacho = Convert.ToDateTime(reader["FECHAIMPRESION"].ToString()).ToString("dd/MM/yyyy HH:mm");

                    }
                    d.TirajeOT = Convert.ToInt32(reader["Tiraje"].ToString()).ToString("N0").Replace(",", ".");
                    d.CantidadGuia = Convert.ToInt32(reader["total"].ToString()).ToString("N0").Replace(",", ".");
                    lista.Add(d);
                }

            }
            con.CerrarConexion();
            return lista;
        }

    }
}