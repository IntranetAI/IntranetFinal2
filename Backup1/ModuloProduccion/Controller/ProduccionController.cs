using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Intranet.ModuloProduccion.Model;
using Intranet.View.Model;
using System.Text.RegularExpressions;

namespace Intranet.ModuloProduccion.Controller
{
    public class ProduccionController
    {
        public List<Produccion> ListOT_Creadas_CSR(string user = "", string OT = "", string Nombre = "", string Cliente = "", DateTime? feInicio = null, DateTime? feTermino = null, int Tipo = 0)
        {
            Conexion con = new Conexion();
            List<Produccion> lista = new List<Produccion>();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "ListOT_Creadas_CSR";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@NumeroOT", OT);//OT);
                cmd.Parameters.AddWithValue("@NombreOT", Nombre);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", feInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", feTermino);
                
                cmd.Parameters.AddWithValue("@TipoFiltro", Tipo);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Produccion pro = new Produccion();
                    pro.NumeroOT = read["NumeroOT"].ToString();
                    pro.NombreOT = read["NombreOT"].ToString();
                    pro.ClienteOT = read["NombreClienteOT"].ToString();
                    string numero = read["EjemplaresOT"].ToString();
                    if (numero != "")
                    {
                        int numero2 = Convert.ToInt32(numero);
                        pro.Ejemplares = numero2.ToString("N0");
                    }
                    string fecha = read["FechaProduccion"].ToString();
                    if (fecha.Trim() != String.Empty)
                    {
                        pro.FechaProduccion = Convert.ToDateTime(read["FechaProduccion"].ToString());
                    }
                    string fecha2 = read["Fecha_Solicitada"].ToString();
                    if (fecha2.Trim() != String.Empty)
                    {
                        pro.FechaSolicitada = read["Fecha_Solicitada"].ToString();

                    }
                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }
      
        public List<Produccion> List_CSR(string user =null,string ot=null,string nomot=null,DateTime? fi=null,DateTime? ft=null, int? filt=null)
        {
            Conexion con = new Conexion();
            List<Produccion> lista = new List<Produccion>();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "List_CSR";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@ot",ot);
                cmd.Parameters.AddWithValue("@nombreot", nomot);
                cmd.Parameters.AddWithValue("@fechaInicio", fi);
                cmd.Parameters.AddWithValue("@fechaTermino", ft);
                cmd.Parameters.AddWithValue("@filt", filt);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Produccion pro = new Produccion();
                    pro.NumeroOT = read["csr_OT"].ToString();
                    pro.NombreOT = read["NM"].ToString();
                    pro.observacion = read["csr_observacion"].ToString();
                    string fe = read["csr_fecha"].ToString();
                    
                    string[] str = fe.Split('/');
                    string mes = str[0];
                    string dia = str[1];
                    string año = str[2];
                    año = año.Substring(0, 4);
                    pro.FechaCSR = "<div style='color:" + read["csr_color"].ToString() + "'>"+dia+ "/"+ mes +"/"+año+"</div>";
                    //pro.color = read["csr_color"].ToString();
                    int tirajea = Convert.ToInt32(read["PRN_ORD_QTY"].ToString());
                    pro.Ejemplares = tirajea.ToString("N0");
                    //pro.Ejemplares = read["PRN_ORD_QTY"].ToString();

                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }
        
        public bool ingresarCSR(string OT, string observacion, DateTime fecha, string color)
        {
            SqlDataReader dr;
            bool respuesta = true;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "SP_CSR";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@color", color);
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

        public bool ModificarCSR(string OT, string observacion, DateTime fecha)
        {
            SqlDataReader dr;
            bool respuesta = true;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            try
            {
                cmd.CommandText = "Modifica_CSR";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@fechaCSR", fecha);
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

        public List<Produccion> ListarProduccion(string OT, string Nombre, string Cliente, int Tipo, string FechaInicio, string FechaTermino)
        {
            Conexion con = new Conexion();
            List<Produccion> lista = new List<Produccion>();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Prod_ListFecha";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.Parameters.AddWithValue("@NombreOT", Nombre);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaTermino", FechaTermino);
                cmd.Parameters.AddWithValue("@TipoFiltro", Tipo);
                SqlDataReader read = cmd.ExecuteReader();
                
                while (read.Read())
                {
                    Produccion pro = new Produccion();
                    pro.NumeroOT = read["NumeroOT"].ToString();
                    pro.NombreOT = read["NombreOT"].ToString();
                    pro.ClienteOT = read["NombreClienteOT"].ToString();
                    
                    if (read["EjemplaresOT"].ToString() != "")
                    {
                        pro.Ejemplares = Convert.ToInt32(read["EjemplaresOT"].ToString()).ToString("N0").Replace(",",".");
                    }
                    if (read["FechaProduccion"].ToString() != "")
                    {
                        pro.FechaProduccion = Convert.ToDateTime(read["FechaProduccion"].ToString());
                    }
                    if (Tipo == 2 || Tipo == 4)
                    {
                        pro.Tiraje = Convert.ToInt32(read["Tiraje"].ToString()).ToString("N0").Replace(",",".");
                    }
                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public string InsertarFecha(Produccion pro, string usuario, DateTime Fehora)
        {
            Conexion conexion = new Conexion();
            SqlCommand cmd = conexion.AbrirConexionProduccion();
            DateTime? fechaProduccion = null;
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "InsertFechasPro";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumeroOT", pro.NumeroOT);
                    cmd.Parameters.AddWithValue("@NombreOT", pro.NombreOT);
                    cmd.Parameters.AddWithValue("@FechaPro", Fehora);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Ejemplares", pro.Ejemplares);
                    cmd.Parameters.AddWithValue("@Cliente", pro.ClienteOT);
                    cmd.Parameters.AddWithValue("@Observacion", pro.observacion);
                    cmd.Parameters.AddWithValue("@Tipo", 1);
                    object idProduccion = cmd.ExecuteScalar();
                    return "ok";
                }
                catch (Exception ex)
                {
                    return ex.Message + pro.FechaProduccion + "" + fechaProduccion;
                }
                conexion.CerrarConexion();
            }
                
            else {conexion.CerrarConexion(); return null; }
            
        }

        public bool EliminarFe(int IDProduccion)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "InsertFechasPro";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProduccion", IDProduccion);
                cmd.Parameters.AddWithValue("@Tipo", 2);
                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
            con.CerrarConexion();
        }
    

        //procedimientos para informe despachos futuros

        public bool ProcedimientoTrigger(string OT)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "sp_trigger";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
            con.CerrarConexion();
        }



        public List<Produccion> ListarProduccionOT_tablaTemporal(string OT)
        {
            Conexion con = new Conexion();
            List<Produccion> lista = new List<Produccion>();
            //SqlCommand cmd = con.AbrirConexionProduccion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
              //  cmd.CommandText = "Produccion_Listar";
                cmd.CommandText = "lista_Tabla_Temporal";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeroOT", OT);
                SqlDataReader read = cmd.ExecuteReader();
                int porcentaje = 0;
                int Tiraje = 0;//CANTIDAD que debe cumplir
                while (read.Read())
                {
                    Produccion pro = new Produccion();
                    pro.IDProduccion = Convert.ToInt32(read["IDProduccion"].ToString());
                    pro.OrdenOT = read["OT"].ToString();
                    pro.NombreOT = read["NombreOT"].ToString();
                    pro.FechaProduccion = Convert.ToDateTime(read["FechaProduccion"].ToString());
                    Tiraje = Convert.ToInt32(read["Tiraje"].ToString());
                    pro.Tiraje = Tiraje.ToString("N0");
                    pro.FechaModificacion = Convert.ToDateTime(read["FechaModificacion"].ToString());
                    //pro.Usuario = read["Encargado"].ToString();
                    porcentaje = Convert.ToInt32(read["Porcentaje"].ToString());
                    string p = porcentaje.ToString();
                    if (porcentaje == 0)
                    {
                        pro.cantidadDesp = "<a>0%</a>";
                    }else{
                        if (porcentaje < 10)
                        {
                            pro.cantidadDesp = porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 9 && porcentaje < 20)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 19 && porcentaje < 30)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 29 && porcentaje < 40)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 39 && porcentaje < 50)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 49 && porcentaje < 60)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 59 && porcentaje < 70)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 69 && porcentaje < 80)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 79 && porcentaje < 90)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 89 && porcentaje < 100)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje >= 100)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif'/>" + porcentaje.ToString() + "%";
                        }
                    }
                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista.ToList();
        }

        public List<Produccion> ListarProduccionOT(string OT)
        {
            Conexion con = new Conexion();
            List<Produccion> lista = new List<Produccion>();
            SqlCommand cmd = con.AbrirConexionProduccion();
            //SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Produccion_Listar";
                //cmd.CommandText = "lista_Tabla_Temporal";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeroOT", OT);
                SqlDataReader read = cmd.ExecuteReader();
                int porcentaje = 0;
                int Tiraje = 0;//CANTIDAD que debe cumplir
                while (read.Read())
                {
                    Produccion pro = new Produccion();
                    pro.IDProduccion = Convert.ToInt32(read["IDProduccion"].ToString());
                    pro.OrdenOT = read["OT"].ToString();
                    pro.NombreOT = read["NombreOT"].ToString();
                    pro.FechaProduccion = Convert.ToDateTime(read["FechaProduccion"].ToString());
                    Tiraje = Convert.ToInt32(read["Tiraje"].ToString());
                    pro.Tiraje = Tiraje.ToString("N0");
                    pro.FechaModificacion = Convert.ToDateTime(read["FechaModificacion"].ToString());
                    pro.Usuario = read["Encargado"].ToString();
                    porcentaje = Convert.ToInt32(read["Porcentaje"].ToString());
                    string p = porcentaje.ToString();
                    if (porcentaje > 0)
                    {
                        if (porcentaje < 10)
                        {
                            pro.cantidadDesp = "<a>"+porcentaje.ToString() + "%</a>";
                        }
                        if (porcentaje > 9 && porcentaje < 20)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar00.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 19 && porcentaje < 30)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar10.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 29 && porcentaje < 40)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar20.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 39 && porcentaje < 50)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar30.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 49 && porcentaje < 60)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar40.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 59 && porcentaje < 70)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar50.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 69 && porcentaje < 80)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar60.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 79 && porcentaje < 90)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar70.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje > 89 && porcentaje < 100)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar80.gif' />" + porcentaje.ToString() + "%";
                        }
                        if (porcentaje >= 100)
                        {
                            pro.cantidadDesp = "<img src='../../Content/images/Barra%20Valoracion/bar90.gif'/>" + porcentaje.ToString() + "%";
                        }
                    }
                    else
                    {
                        pro.cantidadDesp = "<a>0%</a>";
                    }
                    lista.Add(pro);
                }
            }
            con.CerrarConexion();
            return lista.ToList();
        }


        public List<Produccion> listarFechaProd(string OT)
        {
            List<Produccion> LIst = new List<Produccion>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "Produccion_Listar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeroOT", OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Produccion pro = new Produccion();
                    pro.IDProduccion = Convert.ToInt32(reader["IDProduccion"].ToString());
                    pro.NumeroOT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    pro.ClienteOT = reader["Cliente"].ToString();
                    pro.TirajeProd = Convert.ToInt32(reader["Tiraje"].ToString());
                    pro.Tiraje = pro.TirajeProd.ToString("N0");
                    pro.FechaProduccion = Convert.ToDateTime(reader["FechaProduccion"].ToString());
                    pro.FechaModificacion = Convert.ToDateTime(reader["FechaProduccion"].ToString());
                    pro.observacion = reader["comentario"].ToString();
                    LIst.Add(pro);
                }
            }
            con.CerrarConexion();
            return LIst;
        }

        public List<Produccion> listarFechaProdAgregar(string OT)
        {
            List<Produccion> LIst = new List<Produccion>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionProduccion();
            if (cmd != null)
            {
                cmd.CommandText = "ProduccionAgregar_Listar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeroOT", OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Produccion pro = new Produccion();
                    pro.IDProduccion = Convert.ToInt32(reader["IDProduccion"].ToString());
                    pro.NumeroOT = reader["OT"].ToString();
                    pro.NombreOT = reader["NombreOT"].ToString();
                    pro.ClienteOT = reader["Cliente"].ToString();
                    pro.TirajeProd = Convert.ToInt32(reader["Tiraje"].ToString());
                    pro.Tiraje = pro.TirajeProd.ToString("N0");
                    pro.FechaProduccion = Convert.ToDateTime(reader["FechaProduccion"].ToString());
                    pro.FechaModificacion = Convert.ToDateTime(reader["FechaProduccion"].ToString());
                    pro.observacion = reader["Observacion"].ToString();
                    LIst.Add(pro);
                }
            }
            con.CerrarConexion();
            return LIst;
        }

        public List<LoginSistema> ListarCorreo(string OT)
        {
            List<LoginSistema> lista = new List<LoginSistema>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "ListarCorreoOT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LoginSistema lo = new LoginSistema();
                    lo.Correo = reader["correo"].ToString();
                    lista.Add(lo);
                }
            }
            con.CerrarConexion();
            return lista;
        }

        //Metodo enviar Correo
        public bool EnviarCorreo(string orden, string rut)
        {
            OrdenController controlOT = new OrdenController();
            Orden DatosOrden = controlOT.BuscarPorOT(orden);
            List<Produccion> list = listarFechaProdAgregar(orden);
            /* Carga de PAra la base de Datos*/
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            List<LoginSistema> lista = ListarCorreo(DatosOrden.NumeroOT);
            //string destinatario = "";
            foreach (LoginSistema a in lista)
            {
                mmsg.To.Add(a.Correo);
            }
            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add("juan.venegas@aimpresores.cl");
            //mmsg.To.Add("sistema.intranet@aimpresores.cl");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Cambio de Fecha Producción Numero OT: " + DatosOrden.NumeroOT + " Nombre OT: " + DatosOrden.NombreOT;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("juan.venegas@aimpresores.cl"); //Opcional
            DateTime hoy = DateTime.Now;
            string fecha = hoy.ToString("dd/MM/yyyy HH:mm");
            string[] str = fecha.Split('/');
            string dia = str[0];
            string mes = str[1];
            string año = str[2];
            //año = año.Substring(0, 4);
            //string hora = hoy.ToLongTimeString();

            //Cuerpo del Mensaje
            mmsg.Body =
 "<table style='width:100%;'>" +
            "<tr>" +
                "<td>" +
                    "<img src='http://intranet.qgchile.cl/images/Logo color lateral.jpg' width='267px'  height='67px' />" +
                    //"<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
                    "&nbsp;</td>" +
            "</tr>" +
            "</table>" +
                //termino cargar logo
                "<div style='border-color:Black;border-width:3px;border-style:solid;'>" +
        "<table style='width:100%;'>" +
           "<tr>" +
                "<td style='width:194px;'>" +
                    "&nbsp;</td>" +
                "<td colspan='3'>" +
                    "&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td  style='width:194px;'>" +
                    "OT Nro.: </td>" +
                "<td colspan='3'>" + DatosOrden.NumeroOT + "</td>" +
            "</tr>" +
            "<tr>" +
                "<td style='width:194px;'>" +
                    "Nombre OT:</td>" +
                "<td   colspan='3'>" + DatosOrden.NombreOT + " </td>" +
            "</tr>" +
            "<tr>" +
                "<td  style='width:194px;'>" +
                  " Fecha Modificación:</td>" +
                "<td colspan='3'>" + dia + "/" + mes + "/" + año + "</td>" +
           "</tr>" +
            "<tr>" +
                "<td  style='width:194px;'>" +
                   "Modificado Por:</td>" +

              "<td colspan='3'>" + rut +
                   "</td>" +
           "</tr>";
            int contador = 0;
            foreach (Produccion pro in list)
            {
                DateTime FechaPro = pro.FechaModificacion;
                string fechpro = FechaPro.ToString("dd/MM/yyyy HH:mm");
                string[] stri = fechpro.Split('/');
                string dias = stri[0];
                string mess = stri[1];
                string años = stri[2];
                if (pro.observacion == "")
                {
                    pro.observacion = "&nbsp;";
                }
                if (contador == 0)
                {
                    mmsg.Body = mmsg.Body +
                        //        "<tr>" +
                        //"<td  style='width:194px;' >" +
                        //   "Observación entregada por Servicio al Cliente:</td>" +
                        //"<td colspan='3'>  " + pro.observacion + " </td>" +
                        //    "</tr>" +
                 "</table>" +
                "<br />" +
                "</div>" +
                "<br />" +
                "<div align='left' style='font-variant:small-caps; font-size: medium; font-family: Arial, Helvetica, sans-serif;'>Fechas de Producción </div>" +

                "<div style='border:1px solid #5D8CC9;width:392px; margin-left:2px;margin-top:2px;'>" +
                "<div style='border:1px solid #5D8CC9; width:194px;background:#5D8CC9;'>Fecha</div><div style='border:1px solid #5D8CC9; width:194px;margin-top:-18px; margin-left:196px;background:#5D8CC9;'>Cantidad a Despachar</div><div style='border:1px solid #5D8CC9; width:250px;margin-top:-18px; margin-left:393px;background:#5D8CC9;'>Observación</div>" +
                "<div style='border:1px solid #5D8CC9; width:194px;'>" + dias + "/" + mess + "/" + años + "</div><div style='border:1px solid #5D8CC9; width:194px;margin-top:-18px; margin-left:196px;' align='right'>" + pro.Tiraje + "</div><div style='border:1px solid #5D8CC9; width:250px;margin-top:-19px; margin-left:393px;' >" + pro.observacion.ToString() + "</div>";

                    //"<div style='border:1px solid #5D8CC9;width:392px; margin-left:2px;margin-top:2px;'>" +
                    //"<div style='border:1px solid #5D8CC9; width:194px;background:#5D8CC9;'>Fecha</div><div style='border:1px solid #5D8CC9; width:194px;margin-top:-22px; margin-left:196px;background:#5D8CC9;'>Cantidad a Despachar</div><div style='border:1px solid #5D8CC9; width:194px;margin-top:-22px; margin-left:600px;background:#5D8CC9;'>Observación</div>" +
                    //"<div style='border:1px solid #5D8CC9; width:194px;'>" + dias + "/" + mess + "/" + años + "</div><div style='border:1px solid #5D8CC9; width:194px;margin-top:-22px; margin-left:196px;' align='right'>" + pro.Tiraje + "</div><div style='border:1px solid #5D8CC9; width:194px;margin-top:-22px; margin-left:300px;' align='right'>" + pro.observacion + "</div>";
                }
                else
                {
                    if (pro.observacion == "")
                    {
                        pro.observacion = "&nbsp;";
                    }
                    mmsg.Body = mmsg.Body +
                        "<div style='border:1px solid #5D8CC9; width:194px;'>" + dias + "/" + mess + "/" + años + "</div><div style='border:1px solid #5D8CC9; width:194px;margin-top:-18px; margin-left:196px;' align='right'>" + pro.Tiraje + "</div><div style='border:1px solid #5D8CC9; width:250px;margin-top:-19px; margin-left:393px;' >" + pro.observacion.ToString() + "</div>";
                }
                contador++;
            }
            mmsg.Body = mmsg.Body +
         "</div>" +
        "<br />";// +"</div>";//<td style='width: 168px;border-bottom:1px solid black;'> &nbsp;</td>

            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");//"fecha.produccion@aimpresores.cl");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            /*
            cliente.Port = 587;
            cliente.EnableSsl = true;
            */

            cliente.Host = "mail.aimpresores.cl";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
                return true;
                //Label1.Text = "enviado correctamente";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
                //Aquí gestionamos los errores al intentar enviar el correo
                //Label1.Text = "error al enviar el correo";
            }
        }


        public List<ProgramacionProduccion> Lista_Programacion_Produccion(string OT)
        {
            List<ProgramacionProduccion> lista = new List<ProgramacionProduccion>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Seguimiento_Programacion_Produccion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProgramacionProduccion p = new ProgramacionProduccion();

                    int re = 0;
                    int buenos = Convert.ToInt32(reader["QtdProduzida"].ToString());
                    int planeado = Convert.ToInt32(reader["TotalPlanificado"].ToString());

                    re = planeado - buenos;
                    // p.Actividad = reader["atividade"].ToString();
                    p.Maquina = reader["Maquina"].ToString();
                    //  p.Proceso = reader["Proceso"].ToString().Replace("[^0-9]", "");
                    string pro = Regex.Replace(reader["Proceso"].ToString(), @"[0-9]", string.Empty);
                    p.Proceso = pro.ToString();

                    p.Obs = reader["Obs"].ToString().Replace("IMP", "").Replace("PLANA", "").Replace("ROTATIVA", "");




                    p.Pliego = reader["Pliego"].ToString().Replace(".", "");

                    p.TirajePlaneado = Convert.ToInt32(reader["TotalPlanificado"].ToString()).ToString("N0").Replace(",", ".");
                    p.PliegosImpresos = Convert.ToInt32(reader["QtdProduzida"].ToString()).ToString("N0").Replace(",", ".");
                    p.HoraInicio = Convert.ToDateTime(reader["DtIniPlan"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    p.HoraFin = Convert.ToDateTime(reader["DtFimPlan"].ToString()).ToString("dd/MM/yyyy HH:mm");

                    // TimeSpan estimado = Convert.ToDateTime(reader["HoraFim"].ToString()) - Convert.ToDateTime(reader["HoraInicio"].ToString());

                    p.Tiempo = reader["TerminoPrevisto"].ToString();


                    if (buenos == 0)
                    {
                        p.Estado = "<div style='Color:DarkRed'>Pendiente Impresión</div>";
                    }
                    else if (re <= 0)
                    {
                        p.Estado = "<div style='Color:DarkGreen'>Pliego Impreso</div>";
                    }
                    else
                    {
                        p.Estado = "<div style='Color:DarkOrange'>En Máquina</div>";
                    }



                    lista.Add(p);
                }
            }
            con.CerrarConexion();
            return lista;
        }



        public List<PliegosImpresos> Lista_Pliegos_Impresos(string OT)
        {
            List<PliegosImpresos> lista = new List<PliegosImpresos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "Seguimiento_Pliegos_Impresos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PliegosImpresos p = new PliegosImpresos();


                    p.Nombre = reader["Maquina"].ToString();
                    p.Description = reader["Processo"].ToString().Replace("IMP", "").Replace("PLANA", "").Replace("ROTATIVA", "");

                    p.CantSolicitada = Convert.ToInt32(reader["QtdPlanejado"].ToString()).ToString("N0").Replace(",", ".");
                    p.CantProducida = Convert.ToInt32(reader["bons"].ToString()).ToString("N0").Replace(",", ".");

                    if (reader["HoraInicio"].ToString() == "01/01/1900 0:00:00" || reader["HoraFin"].ToString() == "01/01/1900 0:00:00")
                    {
                        p.HoraInicio = "";
                        p.HoraFin = "";
                    }
                    else
                    {
                        p.HoraInicio = Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm");

                        p.HoraFin = Convert.ToDateTime(reader["HoraFin"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    }
                    string pro = Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty);
                    p.Pliego = pro.ToString();



                    lista.Add(p);

                }
            }
            con.CerrarConexion();
            return lista;
        }




        public List<PliegosImpresos> Lista_Pliegos_Impresos2(string OT)
        {
            List<PliegosImpresos> lista = new List<PliegosImpresos>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "[Seguimiento_Programacion_Produccion]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", OT);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PliegosImpresos p = new PliegosImpresos();


                    p.Nombre = reader["CodRecurso"].ToString().Replace("IMP", "").Replace("PLANA", "").Replace("ROTATIVA", "");
                    p.Description = reader["obs"].ToString();

                    p.CantSolicitada = Convert.ToInt32(reader["CantSolicitada"].ToString()).ToString("N0").Replace(",", ".");
                    // p.CantProducida = Convert.ToInt32(reader["CantProducida"].ToString()).ToString("N0").Replace(",", ".");

                    if (reader["HoraInicio"].ToString() == "01/01/1900 0:00:00" || reader["HoraFin"].ToString() == "01/01/1900 0:00:00")
                    {
                        p.HoraInicio = "";
                        p.HoraFin = "";
                    }
                    else
                    {
                        p.HoraInicio = Convert.ToDateTime(reader["HoraInicio"].ToString()).ToString("dd/MM/yyyy HH:mm");

                        p.HoraFin = Convert.ToDateTime(reader["HoraFin"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    }
                    string pro = Regex.Replace(reader["Pliego"].ToString(), @"[^0-9]", string.Empty);
                    p.Pliego = pro.ToString();



                    lista.Add(p);

                }
            }
            con.CerrarConexion();
            return lista;
        }
    }
}