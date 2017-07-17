using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloProduccion.Model;
using System.Data.SqlClient;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloEncuadernacion.Model;
using Intranet.ModuloUsuario.Model;
using System.Threading;
using System.Globalization;

namespace Intranet.ModuloProduccion.Controller
{
    public class OrdenController
    {
        List<Orden> lista = new List<Orden>();
        public Orden BuscarPorOT(string ot)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            Orden ord = new Orden();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "BuscarPorOT";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", ot);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ord.NumeroOT = reader["QG_RMS_JOB_NBR"].ToString();
                        ord.NombreOT = reader["NM"].ToString();
                        string numero = reader["PRN_ORD_QTY"].ToString();
                        if (numero != "")
                        {
                            ord.Ejemplares = reader["PRN_ORD_QTY"].ToString();
                        }
                        ord.NombreCliente = reader["CUST_NM"].ToString();

                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return ord;
        }
        // fin buscar x ot

        public List<Orden> ListarOrdenes(string OT, string Nombre, string Cliente, string FechaInicio, string FechaTermino, string Usuario, int Tipo)
        {
            List<Orden> lista = new List<Orden>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Prod_ListSuscripcion";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumeroOT", OT);
                    cmd.Parameters.AddWithValue("@NombreOT", Nombre);
                    cmd.Parameters.AddWithValue("@ClienteOT", Cliente);
                    cmd.Parameters.AddWithValue("@Usuario",Usuario);
                    cmd.Parameters.AddWithValue("@FechaInicio",FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaTermino",FechaTermino);
                    cmd.Parameters.AddWithValue("@Procedimiento", Tipo);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        Orden orden = new Orden();
                        orden.NumeroOT = read["NumeroOT"].ToString();
                        orden.NombreOT = read["NombreOT"].ToString();
                        orden.FechaOT = Convert.ToDateTime(read["FechaOT"].ToString());
                        int ejem = Convert.ToInt32(read["ejemplaresOT"].ToString());
                        orden.Ejemplares = ejem.ToString("N0");
                        orden.ejem = ejem;
                        orden.NombreCliente = read["NombreClienteOT"].ToString();

                        lista.Add(orden);
                    }
                }
                catch
                {
                }
                
            }
            return lista;
        }

        //public List<Orden> ListarOrdenes(string ot = "", string nombre = "", string cliente = "", DateTime? fechainicio = null, DateTime? fechatermino = null, string Rut = "", int Tipo = 0)
        //{
        //    List<Orden> lista = new List<Orden>();
        //    Conexion con = new Conexion();
        //    SqlCommand cmd = con.AbrirConexionIntranet();
        //    if (cmd != null)
        //    {
        //        try
        //        {
        //            cmd.CommandText = "ListSuscripcion";
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            if (ot != "" || cliente != "" || nombre != "" || (fechainicio != null && fechatermino != null))
        //            {
        //                cmd.Parameters.AddWithValue("@NumeroOT", ot);
        //                cmd.Parameters.AddWithValue("@NombreOT", nombre);
        //                cmd.Parameters.AddWithValue("@ClienteOT", cliente);
        //                cmd.Parameters.AddWithValue("@Usuario", Rut);

        //                string año = null;
        //                string mes = null;
        //                string dia = null;
        //                if (fechainicio == null)
        //                {
        //                    DateTime fechaini = Convert.ToDateTime("01-01-1900");
        //                    cmd.Parameters.AddWithValue("@FechaInicio", fechaini);
        //                }
        //                else if (fechainicio != null)
        //                {
        //                    string fec = (String.Format("{0:dd/MM/yyyy}", fechainicio));
        //                    if (String.Format("{0:dd/MM/yyyy}", fec).Length == 10)
        //                    {
        //                        año = (fec.Substring(6, 4));
        //                        mes = (fec.Substring(3, 2));
        //                        dia = (fec.Substring(0, 2));
        //                    }
        //                    string fecha2 = año + mes + dia;
        //                    cmd.Parameters.AddWithValue("@FechaInicio", fecha2);
        //                }
        //                if (fechatermino == null)
        //                {
        //                    DateTime fechater = Convert.ToDateTime("01-01-1900");
        //                    cmd.Parameters.AddWithValue("FechaTermino", fechater);
        //                }
        //                else if (fechatermino != null)
        //                {
        //                    string fec = (String.Format("{0:dd/MM/yyyy}", fechatermino));
        //                    if (String.Format("{0:dd/MM/yyyy}", fec).Length == 10)
        //                    {
        //                        año = (fec.Substring(6, 4));
        //                        mes = (fec.Substring(3, 2));
        //                        dia = (fec.Substring(0, 2));
        //                    }
        //                    string fecha1 = año + mes + dia;
        //                    cmd.Parameters.AddWithValue("@FechaTermino", fecha1);
        //                }
        //            }
        //            else if ((ot == "") && (fechainicio == null) && (fechatermino == null))
        //            {
        //                cmd.Parameters.AddWithValue("@Procedimiento", Tipo);
        //            }
        //            SqlDataReader read = cmd.ExecuteReader();
        //            while (read.Read())
        //            {
        //                Orden orden = new Orden();
        //                orden.NumeroOT = read["NumeroOT"].ToString();
        //                orden.NombreOT = read["NombreOT"].ToString();
        //                orden.FechaOT = Convert.ToDateTime(read["FechaOT"].ToString());
        //                int ejem = Convert.ToInt32(read["ejemplaresOT"].ToString());
        //                orden.Ejemplares = ejem.ToString("N0");
        //                orden.ejem = ejem;
        //                orden.NombreCliente = read["NombreClienteOT"].ToString();

        //                lista.Add(orden);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //    }
        //    con.CerrarConexion();
        //    return lista;
        //}
        //fin listar ordenes
        public bool AsignarOT(List<Asignar> list, int IDUsuario)
        {
            string insert = "";
            foreach (Asignar asi in list)
            {
                insert = insert + "insert into Produccion.dbo.OTAsignada values('" + asi.NumeroOT + "'," + IDUsuario + "," + asi.Estado + ");";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionProduccion();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }
        
        public bool AsignarLeidas(List<Asignar> list, int IDUsuario)
        {
            string insert = "";
            foreach (Asignar asi in list)
            {
                insert = insert + "Update Produccion.dbo.OTAsignada set Estado=1 where NumeroOT='" + asi.NumeroOT + "' and IDUsuario=" + IDUsuario + ";";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionProduccion();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }

        public bool AsignarNoLeidas(List<Asignar> list, int IDUsuario)
        {
            string insert = "";
            foreach (Asignar asi in list)
            {
                insert = insert + "Update Produccion.dbo.OTAsignada set Estado=2 where NumeroOT='" + asi.NumeroOT + "' and IDUsuario=" + IDUsuario + ";";
            }
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionProduccion();
                if (cmd != null)
                {
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
                con.CerrarConexion();
            }
            catch
            {
                return false;
            }
        }

        public List<Orden> ListarOT_Mail(string ot = "", string nombre = "", string cliente = "", DateTime? fechainicio = null, DateTime? fechatermino = null, int Procedimiento = 0, string username = "")
        {
            List<Orden> lista = new List<Orden>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ListarMensajes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombre);
                cmd.Parameters.AddWithValue("@Cliente", cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Orden orden = new Orden();
                    orden.NumeroOT = reader["OT"].ToString();
                    orden.NombreOT = reader["NombreOT"].ToString();
                    orden.NombreCliente = reader["Cliente"].ToString();
                    orden.FechaPro = Convert.ToDateTime(reader["FechaEntrega"].ToString());
                    orden.CantidadMensaje = reader["Mensaje"].ToString();
                    orden.ejem = Convert.ToInt32(reader["Noleido"].ToString());
                    if (orden.ejem == 0)
                    {
                        orden.FechaSoli = "";
                    }
                    else
                    {
                        orden.FechaSoli = "<img src='../../Images/mensajeria-intento.png' height='20' width='20' />";
                    }
                    int adjunto = Convert.ToInt32(reader["adjunto"].ToString());
                    if (adjunto > 0)
                    {   orden.NivelCumpli = "<img src='../../Images/PaperClip3_Black.png' height='20' width='20' />";}
                    else
                    {   orden.NivelCumpli = "";}
                    int Tiraje = Convert.ToInt32(reader["Tiraje"].ToString());
                    orden.Ejemplares = Tiraje.ToString("N0");
                    lista.Add(orden);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        //listar Ordenes para filtros
        //listar Ordenes para filtros
        //public List<Orden> ListarOrdenesOT(string ot, string nombre, string cliente, DateTime? fechainicio, DateTime? fechatermino, int estadoOT, int Procedimiento, string Rut)
        //{
        //    Conexion con = new Conexion();
        //    SqlCommand cmd = con.AbrirConexionProduccion();
        //    if (cmd != null)
        //    {
        //        try
        //        {
        //            cmd.CommandText = "ListarOT_Listar";
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@user", Rut);
        //            cmd.Parameters.AddWithValue("@Orden", ot);
        //            cmd.Parameters.AddWithValue("@Nombre", nombre);
        //            cmd.Parameters.AddWithValue("@Cliente", cliente);
        //            cmd.Parameters.AddWithValue("@EstadoOT", estadoOT);
        //            cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
        //            if (fechainicio != null)
        //            {
        //                DateTime fecha = Convert.ToDateTime(fechainicio);
        //                cmd.Parameters.AddWithValue("@FechaInicio", fecha);

        //                DateTime fecha2 = Convert.ToDateTime(fechatermino);
        //                cmd.Parameters.AddWithValue("@FechaTermino", fecha2);
        //            }
        //            if (Procedimiento == 3 || Procedimiento == 4)
        //            {
        //                if (fechainicio == null && fechatermino == null)
        //                {
        //                    cmd.Parameters.AddWithValue("@FechaInicio", DBNull.Value);
        //                    cmd.Parameters.AddWithValue("@FechaTermino", DBNull.Value);
        //                }
        //            }
        //            SqlDataReader read = cmd.ExecuteReader();
        //            while (read.Read())
        //            {
        //                Orden orden = new Orden();
        //                orden.NumeroOT = read["QG_RMS_JOB_NBR"].ToString();
        //                orden.NombreOT = read["NM"].ToString();
        //                orden.ejem = Convert.ToInt32(read["PRN_ORD_QTY"].ToString());//nuevo
        //                int cantidad = Convert.ToInt32(read["PRN_ORD_QTY"].ToString());
        //                orden.Ejemplares = cantidad.ToString();
        //                orden.NombreCliente = read["CUST_NM"].ToString();
        //                try
        //                {
        //                    if (Convert.ToInt32(read["EstadoOT"].ToString()) == 1)
        //                    {
        //                        orden.StatusOV = "En Proceso";
        //                    }
        //                    else
        //                    {
        //                        orden.StatusOV = "Liquidada";
        //                    }
        //                }
        //                catch
        //                {
        //                    if (read["EstadoOT"].ToString() == "L")
        //                    {
        //                        orden.StatusOV = "En Proceso";
        //                    }
        //                    else
        //                    {
        //                        orden.StatusOV = "Liquidada";
        //                    }
        //                }
        //                string Fechapro = read["FechaProduccion"].ToString();
        //                if (Fechapro != "")
        //                {
        //                    orden.FechaPro = Convert.ToDateTime(read["FechaProduccion"].ToString());
        //                }
        //                int result = 0;
        //                if (orden.ejem > 0)
        //                {
        //                    result = (Convert.ToInt32(read["Total"].ToString()) * 100) / orden.ejem;
        //                }

        //                orden.Ejemplares = result.ToString();
        //                if (result >= 100)
        //                {
        //                    orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif'/>100%";
        //                }
        //                else
        //                {
        //                    if (result < 10)
        //                    {
        //                        orden.Despacho = "<a> " + result.ToString() + "%</a>";
        //                    }
        //                    if (result >= 10 && result < 20)
        //                    {
        //                        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' /> " + result.ToString() + "%";
        //                    }
        //                    if (result >= 20 && result < 30)
        //                    {
        //                        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' /> " + result.ToString() + "%";
        //                    }
        //                    if (result >= 30 && result < 40)
        //                    {
        //                        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' /> " + result.ToString() + "%";
        //                    }
        //                    if (result >= 40 && result < 50)
        //                    {
        //                        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' /> " + result.ToString() + "%";
        //                    }
        //                    if (result >= 50 && result < 60)
        //                    {
        //                        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' /> " + result.ToString() + "%";
        //                    }
        //                    if (result >= 60 && result < 70)
        //                    {
        //                        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' /> " + result.ToString() + "%";
        //                    }
        //                    if (result >= 70 && result < 80)
        //                    {
        //                        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' /> " + result.ToString() + "%";
        //                    }
        //                    if (result >= 80 && result < 90)
        //                    {
        //                        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' /> " + result.ToString() + "%";
        //                    }
        //                    if (result >= 90 && result < 100)
        //                    {
        //                        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' /> " + result.ToString() + "%";
        //                    }
        //                }
        //                //orden.FechaHoy = Convert.ToDateTime(read["hoy"].ToString());
        //                //if (Fechapro != "")
        //                //{
        //                //    TimeSpan Tiempo = (TimeSpan)(orden.FechaHoy - orden.FechaPro);
        //                //    int tiempo = Tiempo.Days;
        //                //    orden.proalinear = tiempo;
        //                //    if (tiempo > 0)
        //                //    {
        //                //        orden.NivelCumpli = "<div style='color:Red'>Retraso " + Convert.ToInt32(tiempo).ToString() + " días</div>";
        //                //    }
        //                //    if (tiempo < 0)
        //                //    {
        //                //        Tiempo = (TimeSpan)(orden.FechaPro - orden.FechaHoy);
        //                //        tiempo = Tiempo.Days;
        //                //        orden.NivelCumpli = "<div style='color:green'>Quedan " + Convert.ToInt32(tiempo).ToString() + " días</div> ";
        //                //    }
        //                //    else if (tiempo == 0)
        //                //    {
        //                //        orden.NivelCumpli = "Hoy";
        //                //    }
        //                //}
        //                //else
        //                //{
        //                //    orden.NivelCumpli = "Sin Fecha Entrega";
        //                //    orden.proalinear = null;
        //                //}

        //                //enlace con mensajeria
        //                if (read["Adjunto"].ToString() != "0")
        //                { orden.mensajeAdjunto = "<img src='../../Images/PaperClip3_Black.png' height='20' width='20' />"; }
        //                else
        //                { orden.mensajeAdjunto = ""; }

        //                if (read["mensaje"].ToString() == "0")
        //                {
        //                    orden.mensajeNuevos = "";
        //                }
        //                else
        //                {

        //                    orden.mensajeNuevos = read["mensaje"].ToString();
        //                }

        //                if (read["Noleido"].ToString() != "0")
        //                {
        //                    orden.mensajeLeido = "<img src='../../Images/mensajeria-intento.png' height='20' width='20' />";
        //                }
        //                else
        //                {
        //                    orden.mensajeLeido = "";
        //                }
        //                if (Procedimiento == 3 || Procedimiento == 4)
        //                {
        //                    orden.proalinear = Convert.ToInt32(read["despacho_ejem"].ToString());
        //                }
        //                lista.Add(orden);
        //            }
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //    con.CerrarConexion();
        //    return lista;
        //}
        public string CargarDatos2000()
        {
            string registro = "delete from Data_P2B.dbo.QGPressJob where CTD_TMSTMP between GETDATE()-32 and GETDATE()";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionDataP2B2000();
            if (cmd != null)
            {
                cmd.CommandText = "select * from Data_P2B.dbo.QGPressJob where CTD_TMSTMP between GETDATE()-32 and GETDATE()";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    registro = registro +"INSERT INTO QGPressJob VALUES(";
                    if(reader["QG_RMS_JOB_NBR"].ToString()!= ""){
                        registro = registro+"'"+reader["QG_RMS_JOB_NBR"].ToString()+"',";}
                    if (reader["QG_RMS_JOB_NBR"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["NM"].ToString()!= ""){
                        string d = reader["NM"].ToString();
                        if (d.IndexOf("'") >= 0)
                        {
                            string a = d.Replace("'", "");
                            registro = registro + "'" + a + "',";
                        }
                        else { registro = registro + "'" + reader["NM"].ToString()+"',";}
                        }
                        
                    if (reader["NM"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["CTD_TMSTMP"].ToString()!= ""){
                        DateTime f = Convert.ToDateTime(reader["CTD_TMSTMP"].ToString());
                        registro= registro+"'"+ f.ToString("yyyy-MM-dd HH:mm:ss")+"',";}
                    if (reader["CTD_TMSTMP"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["DUE_DT"].ToString()!= ""){
                        DateTime f2 = Convert.ToDateTime(reader["DUE_DT"].ToString());
                        registro = registro+"'" +f2.ToString("yyyy-MM-dd HH:mm:ss")+"',";}
                    if (reader["DUE_DT"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["JOB_STS"].ToString()!= ""){
                        registro = registro+ Convert.ToInt32(reader["JOB_STS"].ToString())+",";}
                    if (reader["JOB_STS"].ToString() == ""){
                        registro = registro+ "null,";}
                    
                    if(reader["CUST_RUT"].ToString()!=""){
                        registro = registro+"'"+ reader["CUST_RUT"].ToString()+"',";}
                    if(reader["CUST_RUT"].ToString()==""){
                        registro = registro + "null,";}
                    
                    if(reader["CUST_NM"].ToString()!=""){
                        registro = registro+"'"+ reader["CUST_NM"].ToString()+"',";}
                    if(reader["CUST_NM"].ToString()==""){
                        registro = registro+"null,";}
                    
                    if(reader["QG_RMS_TITLE_CD"].ToString()!=""){
                        registro =registro+"'"+ reader["QG_RMS_TITLE_CD"].ToString()+"',";}
                    if (reader["QG_RMS_TITLE_CD"].ToString() == ""){
                        registro = registro+"null,";}

                    if(reader["PRN_ORD_QTY"].ToString()!=""){
                        registro =registro+ Convert.ToInt32(reader["PRN_ORD_QTY"].ToString())+",";}
                    if (reader["PRN_ORD_QTY"].ToString() == ""){
                        registro = registro+"null,";}
                    
                    if(reader["IMPZ_PROD_HGT"].ToString()!=""){
                        registro=registro+ Convert.ToInt32(reader["IMPZ_PROD_HGT"].ToString())+",";}
                    if (reader["IMPZ_PROD_HGT"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["IMPZ_PROD_WDT"].ToString()!=""){
                        registro=registro+ Convert.ToInt32(reader["IMPZ_PROD_WDT"].ToString())+",";}
                    if (reader["IMPZ_PROD_WDT"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["OPN_WDTH"].ToString()!=""){
                        registro=registro+ Convert.ToInt32(reader["OPN_WDTH"].ToString())+",";}
                    if (reader["OPN_WDTH"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["OPN_HGT"].ToString()!=""){
                        registro =registro+ Convert.ToInt32(reader["OPN_HGT"].ToString())+",";}
                    if (reader["OPN_HGT"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["AccountAddress1"].ToString()!=""){
                        string d = reader["AccountAddress1"].ToString();
                        if (d.IndexOf("'") >= 0)
                        {
                            string a = d.Replace("'", "");
                            registro = registro + "'" + a + "',";
                        }
                        else { registro = registro + "'" + reader["AccountAddress1"].ToString() + "',"; }
                        }
                    if (reader["AccountAddress1"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["AccountAddress2"].ToString()!=""){
                        registro=registro+"'"+ reader["AccountAddress2"].ToString()+"',";}
                    if (reader["AccountAddress2"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["AccountNeighborhood"].ToString()!=""){
                        registro=registro+"'"+ reader["AccountNeighborhood"].ToString()+"',";}
                    if (reader["AccountNeighborhood"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["AccountRegion"].ToString()!=""){
                        registro =registro+"'"+ reader["AccountRegion"].ToString()+"',";}
                    if (reader["AccountRegion"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["AccountCountry"].ToString()!=""){
                        registro =registro+"'"+ reader["AccountCountry"].ToString()+"',";}
                    if (reader["AccountCountry"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if(reader["AccountCity"].ToString()!=""){
                        registro =registro+"'"+ reader["AccountCity"].ToString()+"',";}
                    if (reader["AccountCity"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if (reader["FullIssueName"].ToString() != ""){
                        string a="";
                        string d = reader["FullIssueName"].ToString();
                        if (d.IndexOf("'") >= 0)
                        {
                            a = d.Replace("'", "");
                            registro = registro + "'" + a + "',";
                        }
                        else { registro=registro+"'"+ reader["FullIssueName"].ToString()+"',"; }
                        }
                    if (reader["FullIssueName"].ToString() == ""){
                        registro = registro + "null,";}
                    
                    if (reader["FECHA_LIQUIDACION"].ToString() != ""){
                        DateTime f3 = Convert.ToDateTime(reader["FECHA_LIQUIDACION"].ToString());
                        registro =registro+"'"+ f3.ToString("yyyy-MM-dd HH:mm:ss")+"'";}
                    if (reader["FECHA_LIQUIDACION"].ToString() == ""){
                        registro = registro + "null";}
                    
                    registro = registro + ");";
                }
            }
            con.CerrarConexion();
            return registro;
        }

        //ingresar exportacion en el 2012
        public Boolean IngresarExporta(string query)
        {
            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.AbrirConexionData_P2B();
                if (cmd != null)
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                con.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //////////////mensajes NO leidos


        public bool mensajesNoLeidos(int idMensaje, string usuario)
        {
            SqlDataReader dr;
            bool respuesta = true;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            try
            {
                cmd.CommandText = "Mensajeria_MensajeLeido";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMensaje", idMensaje);
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
            con.CerrarConexion();
            return respuesta;
        }
        //Nueva query para gestion (Estado OT en Seguimiento)
        public List<Orden> ListarEstadoOT(string ot, string nombre, string cliente, DateTime fechainicio, DateTime fechatermino, int estadoOT, string Usuario, int Procedimiento)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[EstadoOT]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user", Usuario);
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@NombreOT", nombre);
                    cmd.Parameters.AddWithValue("@Cliente", cliente);
                    cmd.Parameters.AddWithValue("@EstadoOT", estadoOT);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    cmd.CommandTimeout = 30000000;
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        Orden orden = new Orden();
                        orden.NumeroOT = read["QG_RMS_JOB_NBR"].ToString().ToUpper();
                        orden.NombreOT = read["NM"].ToString().ToLower();
                        orden.ejem = Convert.ToInt32(read["PRN_ORD_QTY"].ToString());//nuevo
                        int cantidad = Convert.ToInt32(read["PRN_ORD_QTY"].ToString());
                        orden.Ejemplares = cantidad.ToString();
                        orden.NombreCliente = read["CUST_NM"].ToString();

                        if (read["EstadoOT"].ToString() == "1")
                        {
                            orden.StatusOV = "<div style='Color:Blue;'>En Proceso</div>";
                        }
                        else if (read["EstadoOT"].ToString() == "2")
                        {
                            orden.StatusOV = "<div style='Color:Green;'>Liquidada</div>";
                        }

                        else if (read["EstadoOT"].ToString() == "A")
                        {
                            orden.StatusOV = "<div style='Color:Blue;'>En Proceso</div>";
                        }
                        else
                        {
                            orden.StatusOV = "<div style='Color:Green;'>Liquidada</div>";
                        }

                        string Fechapro = read["FechaProduccion"].ToString();
                        if (Fechapro != "")
                        {
                            orden.FechaPro = Convert.ToDateTime(read["FechaProduccion"].ToString());
                        }
                        int result = 0;
                        if (orden.ejem > 0)
                        {
                            result = (Convert.ToInt32(read["Total"].ToString()) * 100) / orden.ejem;
                        }

                        orden.Ejemplares = result.ToString();
                        if (result >= 100)
                        {
                            orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif'/>100%";
                        }
                        else
                        {
                            if (result < 10)
                            {
                                orden.Despacho = "<a> " + result.ToString() + "%</a>";
                            }
                            if (result >= 10 && result < 20)
                            {
                                orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' /> " + result.ToString() + "%";
                            }
                            if (result >= 20 && result < 30)
                            {
                                orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' /> " + result.ToString() + "%";
                            }
                            if (result >= 30 && result < 40)
                            {
                                orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' /> " + result.ToString() + "%";
                            }
                            if (result >= 40 && result < 50)
                            {
                                orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' /> " + result.ToString() + "%";
                            }
                            if (result >= 50 && result < 60)
                            {
                                orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' /> " + result.ToString() + "%";
                            }
                            if (result >= 60 && result < 70)
                            {
                                orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' /> " + result.ToString() + "%";
                            }
                            if (result >= 70 && result < 80)
                            {
                                orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' /> " + result.ToString() + "%";
                            }
                            if (result >= 80 && result < 90)
                            {
                                orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' /> " + result.ToString() + "%";
                            }
                            if (result >= 90 && result < 100)
                            {
                                orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' /> " + result.ToString() + "%";
                            }
                        }
                        if (read["Adjunto"].ToString() != "0")
                        { orden.mensajeAdjunto = "<img src='../../Images/PaperClip3_Black.png' height='20' width='20' />"; }
                        else
                        { orden.mensajeAdjunto = ""; }

                        if (read["mensaje"].ToString() == "0")
                        {
                            orden.mensajeNuevos = "";
                        }
                        else
                        {

                            orden.mensajeNuevos = read["mensaje"].ToString();
                        }

                        if (read["Noleido"].ToString() != "0")
                        {
                            orden.mensajeLeido = "<img src='../../Images/mensajeria-intento.png' height='20' width='20' />";
                        }
                        else
                        {
                            orden.mensajeLeido = "";
                        }
                        //if (Procedimiento == 3 || Procedimiento == 4)
                        //{
                        //    orden.proalinear = Convert.ToInt32(read["despacho_ejem"].ToString());
                        //}
                        lista.Add(orden);
                    }
                }
                catch
                {
                    return null;
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<Orden> ListarEstadoOT_Mejora(string ot, string nombre, string cliente, DateTime fechainicio, DateTime fechatermino, int estadoOT, string Usuario, int Procedimiento)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "[Seguimiento_EstadoOT]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user", Usuario);
                    cmd.Parameters.AddWithValue("@OT", ot);
                    cmd.Parameters.AddWithValue("@NombreOT", nombre);
                    cmd.Parameters.AddWithValue("@Cliente", cliente);
                    cmd.Parameters.AddWithValue("@EstadoOT", estadoOT);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                    cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                    cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                    cmd.CommandTimeout = 30000000;
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        Orden orden = new Orden();
                        orden.NumeroOT = read["QG_RMS_JOB_NBR"].ToString().ToUpper();
                        orden.NombreOT = read["NM"].ToString().ToLower();
                        orden.ejem = Convert.ToInt32(read["PRN_ORD_QTY"].ToString());//nuevo
                        int cantidad = Convert.ToInt32(read["PRN_ORD_QTY"].ToString());
                        orden.Ejemplares = cantidad.ToString();
                        orden.NombreCliente = read["CUST_NM"].ToString();
                        orden.Despacho = read["usr_jfcliberada"].ToString();
                        if (read["EstadoOT"].ToString() == "1")
                        {
                            orden.StatusOV = "<div style='Color:Blue;'>En Proceso</div>";
                        }
                        else if (read["EstadoOT"].ToString() == "2")
                        {
                            orden.StatusOV = "<div style='Color:Green;'>Liquidada</div>";
                        }

                        else if (read["EstadoOT"].ToString() == "A")
                        {
                            orden.StatusOV = "<div style='Color:Blue;'>En Proceso</div>";
                        }
                        else
                        {
                            orden.StatusOV = "<div style='Color:Green;'>Liquidada</div>";
                        }

                        string Fechapro = read["FechaProduccion"].ToString();
                        if (Fechapro != "")
                        {
                            orden.FechaPro = Convert.ToDateTime(read["FechaProduccion"].ToString());
                        }
                        orden.NivelCumpli = read["usr_jfc_OkFechaEntrega"].ToString();
                        //int result = 0;
                        //if (orden.ejem > 0)
                        //{
                        //    result = (Convert.ToInt32(read["Total"].ToString()) * 100) / orden.ejem;
                        //}

                        //orden.Ejemplares = result.ToString();
                        //if (result >= 100)
                        //{
                        //    orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif'/>100%";
                        //}
                        //else
                        //{
                        //    if (result < 10)
                        //    {
                        //        orden.Despacho = "<a> " + result.ToString() + "%</a>";
                        //    }
                        //    if (result >= 10 && result < 20)
                        //    {
                        //        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' /> " + result.ToString() + "%";
                        //    }
                        //    if (result >= 20 && result < 30)
                        //    {
                        //        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' /> " + result.ToString() + "%";
                        //    }
                        //    if (result >= 30 && result < 40)
                        //    {
                        //        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' /> " + result.ToString() + "%";
                        //    }
                        //    if (result >= 40 && result < 50)
                        //    {
                        //        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' /> " + result.ToString() + "%";
                        //    }
                        //    if (result >= 50 && result < 60)
                        //    {
                        //        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' /> " + result.ToString() + "%";
                        //    }
                        //    if (result >= 60 && result < 70)
                        //    {
                        //        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' /> " + result.ToString() + "%";
                        //    }
                        //    if (result >= 70 && result < 80)
                        //    {
                        //        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' /> " + result.ToString() + "%";
                        //    }
                        //    if (result >= 80 && result < 90)
                        //    {
                        //        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' /> " + result.ToString() + "%";
                        //    }
                        //    if (result >= 90 && result < 100)
                        //    {
                        //        orden.Despacho = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' /> " + result.ToString() + "%";
                        //    }
                        //}
                        if (read["Adjunto"].ToString() != "0")
                        { orden.mensajeAdjunto = "<img src='../../Images/PaperClip3_Black.png' height='20' width='20' />"; }
                        else
                        { orden.mensajeAdjunto = ""; }

                        if (read["mensaje"].ToString() == "0")
                        {
                            orden.mensajeNuevos = "";
                        }
                        else
                        {

                            orden.mensajeNuevos = read["mensaje"].ToString();
                        }

                        if (read["Noleido"].ToString() != "0")
                        {
                            orden.mensajeLeido = "<img src='../../Images/mensajeria-intento.png' height='20' width='20' />";
                        }
                        else
                        {
                            orden.mensajeLeido = "";
                        }
                        orden.Usuario = "<a style='Color:Blue;text-decoration:none;' href='javascript:openGame(\"" + orden.NumeroOT + "\")'>Ver Más</a>";

                        lista.Add(orden);
                    }
                }
                catch
                {
                    return null;
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public List<ContArchivos> Seguimiento_ListarArchivos()
        {
            List<ContArchivos> lista = new List<ContArchivos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Seguimiento_Listar_Archivos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ContArchivos c = new ContArchivos();

                    c.IDArchivo = reader["ID_Archivo"].ToString();
                    c.Archivo = reader["Archivo"].ToString();
                    lista.Add(c);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        public List<ContArchivos> Seguimiento_MostrarArchivos(int IDMensaje, int IDRespuesta, int Procedimiento)
        {
            List<ContArchivos> lista = new List<ContArchivos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_Mostrar_Archivos]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Mensaje", IDMensaje);
                cmd.Parameters.AddWithValue("@ID_Respuesta", IDRespuesta);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ContArchivos c = new ContArchivos();

                    //  c.IDArchivo = reader["ID_Archivo"].ToString();
                    c.Archivo = reader["NombreArchivo"].ToString();
                    lista.Add(c);
                }
            }
            con.CerrarConexion();
            return lista;
        }


        public string Seguimiento_BuscarNM(string OT)
        {
            string registro = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_OT]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    registro = reader["NM"].ToString();
                }

            }
            con.CerrarConexion();
            return registro;
        }
        public List<PTerminadosPaso2_Excel> CargarAprobadosPT(string OP, int Procedimiento)
        {
            List<PTerminadosPaso2_Excel> lista = new List<PTerminadosPaso2_Excel>();
            int totalEjemplares = 0;
            int totalTiraje = 0;
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionIntranet();

            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_Encuadernacion]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OP);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PTerminadosPaso2_Excel pro = new PTerminadosPaso2_Excel();
                    //pro.id_ProductosTerminados = reader["id_ProductosTerminados"].ToString();
                    //pro.cod_Pallet = reader["cod_Pallet"].ToString();
                    pro.OT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString().ToLower();
                    pro.Terminacion = reader["Terminacion"].ToString();
                    pro.TipoEmbalaje = reader["TipoEmbalaje"].ToString();
                    int tt = Convert.ToInt32(reader["Total"].ToString());

                    pro.Observacion = reader["Observacion"].ToString().ToLower();
                    totalEjemplares = totalEjemplares + Convert.ToInt32(reader["Total"].ToString());

                    string a = tt.ToString("N0");
                    string b = a.Replace(",", ".");
                    pro.Total = b;

                    DateTime FV = Convert.ToDateTime(reader["FechaValidacion"].ToString());
                    pro.FechaValidacion = FV.ToString("dd/MM/yyyy");
                    string var = reader["Estado"].ToString();
                    if (var == "4")
                    {
                        pro.Modificado = "<div style='Color:Red;'>NO Recepcionado D.I</div>";
                    }
                    else if (var == "10")
                    {
                        pro.Modificado = "<div style='Color:Red;'>DEVOLUCION</div>";
                    }
                    else
                    {
                        pro.Modificado = "<div style='Color:Green;'>Recepcionado D.I</div>";
                    }
                    totalTiraje = Convert.ToInt32(reader["PRN_ORD_QTY"].ToString());
                    lista.Add(pro);
                }
                if (Procedimiento != 0)
                {

                    if (reader.Read() == false)
                    {
                        PTerminadosPaso2_Excel pro2 = new PTerminadosPaso2_Excel();
                        pro2.id_ProductosTerminados = null;
                        pro2.cod_Pallet = null;
                        pro2.OT = null;
                        pro2.NombreOT = null;
                        pro2.Terminacion = null;
                        pro2.TipoEmbalaje = null;
                        pro2.Total = null;
                        pro2.Validado = null;
                        pro2.FechaValidacion = "<div style='font-weight: bold'>Total Ejemplares:</div>";
                        pro2.Modificado = totalEjemplares.ToString("N0").Replace(",", ".");
                        lista.Add(pro2);

                        PTerminadosPaso2_Excel pro3 = new PTerminadosPaso2_Excel();
                        pro3.id_ProductosTerminados = null;
                        pro3.cod_Pallet = null;
                        pro3.OT = null;
                        pro3.NombreOT = null;
                        pro3.Terminacion = null;
                        pro3.TipoEmbalaje = null;
                        pro3.Total = null;
                        pro3.Validado = null;
                        pro3.FechaValidacion = "<div style='font-weight: bold'>Tiraje OT:</div>";
                        pro3.Modificado = totalTiraje.ToString("N0").Replace(",", ".");
                        lista.Add(pro3);

                    }
                }
            }
            conexion.CerrarConexion();
            return lista;
        }





        // controller impresion de mensajes
        public string listarMensajesintento(string OT, string username, int procedimiento,string NM)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            string nombreCreador = "";
            string fecha = "";
            int contador = 0;
            if (cmd != null)
            {
                cmd.CommandText = "ListarMensajesOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@Procedimiento", procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    contador++;
                    Mail m = new Mail();
                    m.IDMail = Convert.ToInt32(reader["IDMail"].ToString());
                    Boolean nuevo = MarcarNew(m.IDMail, username);
                    //MarcarLeido(m.IDMail, username);
                    m.Asunto = reader["Asunto"].ToString();
                    m.Fecha_Creacion = Convert.ToDateTime(reader["Fecha_Creacion"].ToString());
                    string nombc = reader["creadoPor"].ToString();
                    string[] str = nombc.Split(' ');
                    nombreCreador = str[0] + " " + str[2];

                    //DateTime fech = Convert.ToDateTime(reader["Fecha_Creacion"].ToString());


                    DateTime thedate = DateTime.Parse(reader["Fecha_Creacion"].ToString());
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                    fecha = string.Format("{0:f}", thedate);
                    try
                    {
                        m.Asunto = m.Asunto.Substring(0, 106) + "...";
                    }
                    catch
                    {
                    }
                    string newm = "";
                    if (nuevo)
                    {

                        newm = "<td><label style='margin-left:-15px;font-size: 14px;margin-top:-5px;'>" + contador.ToString() + "</label>&nbsp;&nbsp;<img src='../../Images/icononew.jpg' width='25px' height='25px' style='padding-top:-4px;border-radius: 45px 45px 45px 45px;' /></td>";
                    }
                    else
                    {

                        newm = "<td><label style='margin-left:-15px;font-size: 14px;margin-top:-5px;'>" + contador.ToString() + "</label>&nbsp;&nbsp;<img src='../../Images/iconopersona.png' width='25px' height='25px' style='padding-top:-4px;' /></td>";
                    }
                    List<Archivo> lista = CargarClip(m.IDMail);
                    string clip = "";
                    string visible = "hidden";
                    foreach (Archivo a in lista)
                    {
                        clip = clip + "<p><div style='border-top: 1px solid #d0d0d0;width:40%;'></div><img src='../../Images/iconoDescarga.png' width='20px' height='20px' />  " + a.Nombre + " <a style='color:Blue; text-decoration: underline;' href='../../ModuloUsuario/View/Downloader.aspx?guid=" + a.Archivos + "'>Descargar</a></p>";
                        visible = "visible";
                    }
                    resultado = resultado + " <div class='mailRevisido' id='acco' style='padding-top:5px;' >" +

                    "<h3 style='width:925px;height:35px;' class='ui-helper-reset ui-state-default ui-corner-top ui-state-hover ui-accordion-icons ui-widget-content'>" +
                    "<table style='margin-left:20px;'>" +
                    "<tr>" +
                    "<td>" +
                    "" + newm + "" +
                        //"<img src='../../Images/iconopersona.png' width='25px' height='25px' style='padding-top:-4px;' /></td>" +

                    "<td style='width: 580px;'>&nbsp;&nbsp;<label style='font-weight:bold;color:blue;'>Asunto: " + reader["Asunto"].ToString() + "</label><br />&nbsp;&nbsp;Creado por:<label style='font-weight:bold;'> " + nombreCreador + "</label>. &nbsp;&nbsp;&nbsp;&nbsp;" + fecha + " </td>" +
                    "<td><a title='Existen Documentos Adjuntos'>" +
                    "<img width='25px' height='25px' src='../../Images/PaperClip3_Black.png' style='visibility:" + visible + "'/></a></td>" +
                    "<td></td>" +
                    "</tr>" +
                    "</table>" +
                    "</h3>" +
                    "<div id='ui-accordion-acco-panel-0' class='ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom'  style='width:925px;'>" +
                    "<p><label style='padding-left:5px;padding-right:5px;'>" + reader["Comentario"].ToString() + "</label></p>" +
                        //"<p>Esta autorizado por cliente para reimprimir tapas de guia san pedro con nuevos archivos, mismo tiraje. Urgente, modificar OT. Servicio con cargo a cliente. asdasd asdasdasdasd asdasda asdas as </p>" +
                    "<p>" + clip + "</p>" +
                    "</div></div>" +
                    "" + CargarRespuestaIntento(Convert.ToInt32(reader["IDMail"].ToString()), contador) + "";

                    //"<div style='width:819px;'><p> Creado por : " + reader["Creado"].ToString() + "</p>" +
                    //"<p>" + reader["Comentario"].ToString() + "</p>" +
                    //"<p></p>" +
                    //"<p><div style='border-top: 1px solid #d0d0d0;width:40%;'>" + clip + "</div></p>" +
                    //"<div style='overflow:auto;width:800;height:200px;'>" + CargarRespuesta(Convert.ToInt32(reader["IDMail"].ToString())) + "</div></div>";
                }
                //resultado = resultado + "</div>";
            }
            con.CerrarConexion();
            return "<div style='height: 1300px;overflow:auto;width:1000px'></br><div align='center'><label style='font-size: 30px;font-weight:bold;'>OT: " + OT + "  -  " + NM + "</label></div></br> " + resultado + "</div>";
        }



        public string CargarRespuestaIntento(int IdMail, int numero)
        {
            string respuesta = "";
            string nombreCreador = "";
            string fecha = "";
            int contadorResp = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ListarRespuesta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDMail", IdMail);
                SqlDataReader reader = cmd.ExecuteReader();
                int contador = 0;
                while (reader.Read())
                {
                    contadorResp++;
                    List<Archivo> list = CargarRespAdjunta(Convert.ToInt32(reader["IDRespuesta"].ToString()));
                    string sentencia = "";
                    string nombc = reader["creadoPor"].ToString();
                    string[] str = nombc.Split(' ');
                    nombreCreador = str[0] + " " + str[2];

                    DateTime fech = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    fecha = string.Format("{0:f}", fech);

                    foreach (Archivo ar in list)
                    {
                        sentencia = sentencia + "<p><div style='border-top: 1px solid #d0d0d0;width:50%;'>" + "<p><img src='../../Images/iconoDescarga.png' width='20px' height='20px' />  " + ar.Nombre + " <a style='color:Blue; text-decoration: underline;' href='../../ModuloUsuario/View/Downloader.aspx?guid=" + ar.Archivos + "'>Descargar</a></p>" + "</div></p>";
                    }

                    respuesta = respuesta +


                   "<div class='mailRevisido' style='width:400px;padding-left:50px;padding-top:5px;'>" +
            "<h3 style='width:810px;' class='ui-helper-reset ui-state-default ui-corner-top ui-state-hover ui-accordion-icons ui-widget-content'>" +
           " <table style='margin-left:20px;'>" +
                "<tr>" +
                    "<td>" +
                    "<label style='margin-left:-15px;font-size: 14px;'>" + numero + "." + contadorResp + "</label>&nbsp;&nbsp;<img src='../../Images/iconopersona.png' width='25px' height='25px' style='padding-top:-4px;' /></td>" +
            "<td style='width: 600px;'>&nbsp;&nbsp;<label style='font-weight:bold;color:blue;'>" + reader["Asunto"].ToString() + "</label><br />&nbsp;&nbsp;<label style='font-weight:bold;'>Creado por: " + nombreCreador + ".</label> &nbsp;&nbsp;&nbsp;&nbsp;" + fecha + " </td>" +
            "<td></td>" +
            "<td></td>" +

                "</tr>" +
            "</table>" +
            "</h3>" +
            "<div id='ui-accordion-acco-panel-0' class='ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom'  style='width:810px;'>" +

                "<p><label style='padding-left:5px;padding-right:5px;'>" + reader["Comentario"].ToString() + "</label></p>" +

                "<p>" + sentencia + "</p>" +

                "</div>" +
           " </div> ";


                    contador = contador++;
                }

            }
            con.CerrarConexion();
            return respuesta;

        }


        public string ListaOTMensajes(string ot, string nombre, string cliente, DateTime fechainicio, DateTime fechatermino, int estadoOT, string Usuario, int Procedimiento)
        {
            string respuesta = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_EstadoOT]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", Usuario);
                cmd.Parameters.AddWithValue("@OT", ot);
                cmd.Parameters.AddWithValue("@NombreOT", nombre);
                cmd.Parameters.AddWithValue("@Cliente", cliente);
                cmd.Parameters.AddWithValue("@EstadoOT", estadoOT);
                cmd.Parameters.AddWithValue("@FechaInicio", fechainicio);
                cmd.Parameters.AddWithValue("@FechaTermino", fechatermino);
                cmd.Parameters.AddWithValue("@Procedimiento", Procedimiento);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    respuesta = respuesta + listarMensajesintento(reader["QG_RMS_JOB_NBR"].ToString(), Usuario, 1, reader["NM"].ToString());

                }

            }
            con.CerrarConexion();
            return respuesta;

        }





        public List<Archivo> CargarClip(int IDMail)
        {
            List<Archivo> lista = new List<Archivo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "document_attachment_GetAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDMail", IDMail);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Archivo a = new Archivo();
                    a.Nombre = reader["NombreArchivo"].ToString();
                    a.Archivos = reader["Archivo"].ToString();
                    lista.Add(a);
                }

            }
            con.CerrarConexion();
            return lista;

        }

        public Boolean MarcarNew(int idMail, string username)
        {
            Boolean resp = false;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mail_New";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMail", idMail);
                    cmd.Parameters.AddWithValue("@Usuario", username);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        resp = Convert.ToBoolean(reader["respuesta"].ToString());
                    }
                }
                catch (Exception e)
                {
                    resp = false;
                }
            }
            con.CerrarConexion();
            return resp;
        }



        public List<Archivo> CargarRespAdjunta(int IDRespuesta)
        {
            List<Archivo> lista = new List<Archivo>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "document_attachment_GetAllResp";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDRespuesta", IDRespuesta);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Archivo a = new Archivo();
                    a.Nombre = reader["NombreArchivo"].ToString();
                    a.Archivos = reader["Archivo"].ToString();
                    lista.Add(a);
                }

            }
            con.CerrarConexion();
            return lista;

        }
    }
}