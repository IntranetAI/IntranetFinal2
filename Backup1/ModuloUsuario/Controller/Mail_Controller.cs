using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.ModuloUsuario.Model;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace Intranet.ModuloUsuario.Controller
{
    public class Mail_Controller
    {
        
        public string CargarRespuesta(int IdMail)
        {
            string respuesta = "";
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
                    List<Archivo> list = CargarRespAdjunta(Convert.ToInt32(reader["IDRespuesta"].ToString()));
                    string sentencia = "";
                    foreach (Archivo ar in list)
                    {
                        sentencia = sentencia + "<p><div style='border-top: 1px solid #d0d0d0;width:50%;'>" + "<p><img src='../../Images/iconoDescarga.png' width='20px' height='20px' />  " + ar.Nombre + " <a style='color:Blue; text-decoration: underline;' href='Downloader.aspx?guid=" + ar.Archivos + "'>Descargar</a></p>" + "</div></p>";
                    }

                    respuesta = respuesta + "<div style='border-top: 1px solid #d0d0d0;margin-left:40px;background-color:#F8F8F8;'>";
                    DateTime f = Convert.ToDateTime(reader["FechaCreacion"].ToString());
                    respuesta = respuesta + "<p>Asunto : " + reader["Asunto"].ToString() + "</p><p>Respondido por : " + reader["CreadoPor"].ToString() + " " + f.ToString("dd-MM--yyyy HH:mm:ss") + "</p>" +
                                    "<p>" + reader["Comentario"].ToString() + "</p>";
                    respuesta = respuesta +
                    sentencia +//cambiar esta sentencia arriba
                    "</div>";
                    contador = contador++;
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
                cmd.Parameters.AddWithValue("@IDMail",IDMail);
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
        
        public Boolean CantidadMailSinLeer(string username)
        {
            int contador = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if(cmd!= null)
            {
                cmd.CommandText = "ContadorMensajes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username",username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    contador = Convert.ToInt32(reader["Contador"].ToString());
                }
            }
            con.CerrarConexion();
            return contador==0;
        }

        public void MarcarLeido(int idMail, string username)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "MailLeido_Insert";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMail", idMail);
                    cmd.Parameters.AddWithValue("@Usuario", username);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    
                }
            }
            con.CerrarConexion();
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
                    cmd.CommandText = "Mensajeria_NewMensaje";
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
        
        public int NuevoMensaje(string OT,string NombreOT, string Asunto, string Comentario, string creado, int IDCat, string NombreCat, string TipoMensaje)
        {
            int IDMensaje = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mensajeria_AgregarMens";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OT", OT);
                    cmd.Parameters.AddWithValue("@NombreOT", NombreOT);
                    cmd.Parameters.AddWithValue("@Asunto", Asunto);
                    cmd.Parameters.AddWithValue("@Comentario", Comentario);
                    cmd.Parameters.AddWithValue("@Creado", creado);
                    cmd.Parameters.AddWithValue("@IDCat", IDCat);
                    cmd.Parameters.AddWithValue("@NombreCat",NombreCat);
                    cmd.Parameters.AddWithValue("@TipoMensaje",TipoMensaje);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDMensaje = Convert.ToInt32(reader["IDMensajeria"].ToString());
                        return IDMensaje;
                    }
                    else
                    {
                        return IDMensaje = 0;
                    }
                }
                catch
                {
                    return IDMensaje = 0;
                }
            }
            else
            {
                return IDMensaje = 0;
            }
            con.CerrarConexion();
        }
        
        public bool UpdateMailArchivo(int ID_Archivo, int IDMensaje)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "sp_UpdateMailArchivo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@IDMensaje", IDMensaje);
                cmd.Parameters.AddWithValue("@ID_Archivo", ID_Archivo);

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
        
        public bool DeleteArchivo(int ID_Archivo)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "sp_DeleteArchivos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@ID_Archivo", ID_Archivo);

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

        public int RespuestaMail(int id_mensaje, string comentario, string creado)
        {
            int IDMensaje = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mensajeria_newRespuesta";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Mensaje", id_mensaje);
                    cmd.Parameters.AddWithValue("@Comentario", comentario);
                    cmd.Parameters.AddWithValue("@Creado", creado);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IDMensaje = Convert.ToInt32(reader["IDRespuesta"].ToString());
                        return IDMensaje;
                    }
                    else
                    {
                        return IDMensaje = 0;
                    }
                }
                catch
                {
                    return IDMensaje = 0;
                }
            }
            else
            {
                return IDMensaje = 0;
            }
            con.CerrarConexion();
        }

        public Mail BuscarIDMensaje(int idMensaje)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            Mail ord = new Mail();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mensajeria_BuscarMensajeID";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idMensaje", idMensaje);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ord.IDMail = idMensaje;
                        ord.OT = reader["ot"].ToString();
                        ord.NM = reader["NombreOT"].ToString();//NombreOT
                        ord.Asunto = reader["asunto"].ToString();
                        ord.nombre = reader["TipoMensaje"].ToString();//TipoMensaje
                        ord.numeroOT = reader["NombreCat"].ToString();//NombreCat
                        ord.Comentario = reader["ID_CatAsunto"].ToString();//IDTipoCat
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return ord;
        }

        public bool UpdateRespuestaArchivo(int ID_Archivo, int IDRespuesta)
        {
            Conexion conexion = new Conexion();
            SqlDataReader dr;
            bool respuesta = true;
            SqlCommand cmd = conexion.AbrirConexionIntranet();
            try
            {

                cmd.CommandText = "sp_UpdateRespuestaArchivo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandTimeout = 30;
                cmd.Parameters.AddWithValue("@IDRespuesta", IDRespuesta);
                cmd.Parameters.AddWithValue("@ID_Archivo", ID_Archivo);

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

        public List<Mail> EnviarMailImportancia(string ot = "")
        {
            List<Mail> lista = new List<Mail>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                cmd.CommandText = "sp_ListarMailImportante";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OT", ot);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mail m = new Mail();
                    m.numeroOT = reader["numeroOT"].ToString();
                    m.nombre = reader["nombre"].ToString();
                    m.correo = reader["correo"].ToString();
                    lista.Add(m);
                }
            }
            con.CerrarConexion();
            return lista;
        }
           
        public string listarMensajes(string OT, string username,int procedimiento)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            string nombreCreador = "";
            string fecha = "";
            int contador = 0;
            if (cmd != null)
            {
                cmd.CommandText = "Mensajeria_ListarMensaje";
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
                    m.Asunto = reader["Asunto"].ToString();
                    m.Fecha_Creacion = Convert.ToDateTime(reader["Fecha_Creacion"].ToString());
                    string nombc = reader["creadoPor"].ToString();
                    string[] str = nombc.Split(' ');
                    nombreCreador = str[0] + " " + str[2];

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
                    string colorFondoTitulo = "";
                    if (nuevo)
                    {
                        if (reader["tipoMensaje"].ToString() == "Requerir Información")
                        {
                            colorFondoTitulo = "background:#E4D10E;";
                        }
                        else
                        {
                            colorFondoTitulo = "background:#A3DA87;";
                        }
                    }
                    else
                    {
                        colorFondoTitulo = "background:#dadada;";
                    }
                    resultado = resultado + " <div class='mailRevisido' id='acco' style='padding-top:5px;' >" +

                    "<h3 style='width:1060px;height:35px;"+colorFondoTitulo+"' class='ui-helper-reset ui-state-default ui-corner-top ui-state-hover ui-accordion-icons ui-widget-content'>" +
                    "<table style='margin-left:20px;'>" +
                    "<tr><td>" +
                    "" + newm + "" +
                    "<td style='width: 760px;'>&nbsp;&nbsp;<label style='font-weight:bold;color:black;'>Asunto:</label><label style='font-weight:bold;color:blue;'>" + reader["NombreCat"].ToString() + " - " + reader["Asunto"].ToString() + 
                    "</label><br />&nbsp;&nbsp;Creado por:<label style='font-weight:bold;'> " + nombreCreador + " - " + reader["CentroCosto"].ToString() + "</label>. &nbsp;&nbsp;&nbsp;&nbsp;" + fecha + " </td>" +
                    "<td><a title='Existen Documentos Adjuntos'>" +
                    "<img width='25px' height='25px' src='../../Images/PaperClip3_Black.png' style='visibility:"+visible+"'/></a></td>" +
                    "<td><a onclick='javascript:newRespuesta(" + reader["IDMail"].ToString() + ")'><img src='../../Images/responder-icon.png' /> </a><input type='checkbox' name='checkintento' value='"+reader["IDMail"].ToString()+"'>Marcar Leido</td>" +
                    "</tr></table></h3>" +
                    "<div id='ui-accordion-acco-panel-0' class='ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom'  style='width:1060px;'>" +
                    "<p><label style='padding-left:5px;padding-right:5px;font-weight:bold;'>" + reader["Comentario"].ToString() + "</label></p>" +
                    "<p>" + clip + "</p>" +
                    "</div></div>" +
                    "" + CargarRespuestaIntento(Convert.ToInt32(reader["IDMail"].ToString()),contador) + "";
                }
            }
            con.CerrarConexion();
            return resultado;
        }

        public string CargarRespuestaIntento(int IdMail,int numero)
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
                        

                   "<div class='mailRevisido' style='width:400px;padding-left:50px;padding-top:5px;'>"+
            "<h3 style='width:1010px;' class='ui-helper-reset ui-state-default ui-corner-top ui-state-hover ui-accordion-icons ui-widget-content'>"+
           " <table style='margin-left:20px;'>"+
                "<tr>"+
                    "<td>"+
                    "<label style='margin-left:-15px;font-size: 14px;'>" + numero + "." + contadorResp + "</label>&nbsp;&nbsp;<img src='../../Images/iconopersona.png' width='25px' height='25px' style='padding-top:-4px;' /></td>" +
            "<td style='width: 600px;'>&nbsp;&nbsp;<label style='font-weight:bold;color:blue;'>" + reader["Asunto"].ToString() + "</label><br />&nbsp;&nbsp;<label style='font-weight:bold;'>Creado por: " + nombreCreador + ".</label> &nbsp;&nbsp;&nbsp;&nbsp;" + fecha + " </td>" +
            "<td></td>"+
            "<td></td>"+
                  
                "</tr>"+
            "</table>"+
            "</h3>"+
            "<div id='ui-accordion-acco-panel-0' class='ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom'  style='width:1010px;'>"+

                "<p><label style='padding-left:5px;padding-right:5px;'>" + reader["Comentario"].ToString() + "</label></p>" +
           
                "<p>"+sentencia+"</p>"+
                   
                "</div>"+
           " </div> ";


                    contador = contador++;
                }

            }
            con.CerrarConexion();
            return respuesta;

        }

        public string listarMensajesintentoImprimir(string OT, string username, int procedimiento)
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
                    MarcarLeido(m.IDMail, username);
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

                      //  newm = "<td><label style=''>" + contador.ToString() + "</label>&nbsp;<img src='../../Images/icononew.jpg' width='25px' height='25px' style='padding-top:-4px;border-radius: 45px 45px 45px 45px;' /></td>";
                        newm = "<td><label style='margin-left:-15px;font-size: 16px;'>" + contador.ToString() + "</label>&nbsp;&nbsp;<img src='../../Images/iconopersona.png' width='25px' height='25px' style='padding-top:-4px;' /></td>";
                    }
                    else
                    {

                        newm = "<td><label style='margin-left:-15px;font-size: 16px;'>" + contador.ToString() + "</label>&nbsp;&nbsp;<img src='../../Images/iconopersona.png' width='25px' height='25px' style='padding-top:-4px;' /></td>";
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

                    "<h3 style='width:861px;height:35px;' class='ui-helper-reset ui-state-default ui-corner-top ui-state-hover ui-accordion-icons ui-widget-content'>" +
                    "<table style='margin-left:20px;'>" +
                    "<tr>" +
                    "<td>" +
                    "" + newm + "" +
                        //"<img src='../../Images/iconopersona.png' width='25px' height='25px' style='padding-top:-4px;' /></td>" +

                    "<td style='width: 650px;'>&nbsp;&nbsp;<label style='font-weight:bold;color:blue;'>Asunto: " + reader["Asunto"].ToString() + "</label><br />&nbsp;&nbsp;Creado por:<label style='font-weight:bold;'> " + nombreCreador + "</label>. &nbsp;&nbsp;&nbsp;&nbsp;" + fecha + " </td>" +
                    "<td><a title='Existen Documentos Adjuntos'>" +
                    "<img width='25px' height='25px' src='../../Images/PaperClip3_Black.png' style='visibility:" + visible + "'/></a></td>" +
                    "<td></td>" +//<a onclick='javascript:newRespuesta(" + reader["IDMail"].ToString() + ")'><img src='../../Images/responder-icon.png' /> </a>
                    "</tr>" +
                    "</table>" +
                    "</h3>" +
                    "<div id='ui-accordion-acco-panel-0' class='ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom'  style='width:861px;'>" +
                    "<p><label style='padding-left:5px;padding-right:5px;'>" + reader["Comentario"].ToString() + "</label></p>" +
                        //"<p>Esta autorizado por cliente para reimprimir tapas de guia san pedro con nuevos archivos, mismo tiraje. Urgente, modificar OT. Servicio con cargo a cliente. asdasd asdasdasdasd asdasda asdas as </p>" +
                    "<p>" + clip + "</p>" +
                    "</div></div>" +
                    "" + CargarRespuestaIntentoImprimir(Convert.ToInt32(reader["IDMail"].ToString()),Convert.ToInt32( contador.ToString())) + "";

                    //"<div style='width:819px;'><p> Creado por : " + reader["Creado"].ToString() + "</p>" +
                    //"<p>" + reader["Comentario"].ToString() + "</p>" +
                    //"<p></p>" +
                    //"<p><div style='border-top: 1px solid #d0d0d0;width:40%;'>" + clip + "</div></p>" +
                    //"<div style='overflow:auto;width:800;height:200px;'>" + CargarRespuesta(Convert.ToInt32(reader["IDMail"].ToString())) + "</div></div>";
                }
                //resultado = resultado + "</div>";
                con.CerrarConexion();
            }
            return resultado;
        }

        public string CargarRespuestaIntentoImprimir(int IdMail,int numero)
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
                 "<label style='margin-left:-15px;font-size: 16px;'>" + numero + "." + contadorResp + "</label>&nbsp;&nbsp;<img src='../../Images/iconopersona.png' width='25px' height='25px' style='padding-top:-4px;' /></td>" +
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

                con.CerrarConexion();
            }
            return respuesta;

        }

        public string listarMensaje_referencia(string OT, string username, int procedimiento)
        {
            string resultado = "";
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            string nombreCreador = "";
            string fecha = "";
            int contador = 0;
            if (cmd != null)
            {
                cmd.CommandText = "Mensajeria_ListarMensaje";
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
                    m.Asunto = reader["Asunto"].ToString();
                    m.Fecha_Creacion = Convert.ToDateTime(reader["Fecha_Creacion"].ToString());
                    string nombc = reader["creadoPor"].ToString();
                    string[] str = nombc.Split(' ');
                    nombreCreador = str[0] + " " + str[2];

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
                    string colorFondoTitulo = "";
                    if (reader["tipoMensaje"].ToString() == "Requerir Información")
                    {
                        colorFondoTitulo = "background:#E4D10E;";
                    }
                    else
                    {
                        colorFondoTitulo = "background:#A3DA87;";
                    }
                    resultado = resultado + " <div class='mailRevisido' id='acco' style='padding-top:5px;' >" +

                    "<h3 style='width:1060px;height:35px;" + colorFondoTitulo + "' class='ui-helper-reset ui-state-default ui-corner-top ui-state-hover ui-accordion-icons ui-widget-content'>" +
                    "<table style='margin-left:20px;'>" +
                    "<tr><td>" +
                    "" + newm + "" +
                    "<td style='width: 760px;'>&nbsp;&nbsp;<label style='font-weight:bold;color:black;'>Asunto:</label><label style='font-weight:bold;color:blue;'>" + reader["NombreCat"].ToString() + " - " + reader["Asunto"].ToString() +
                    "</label><br />&nbsp;&nbsp;Creado por:<label style='font-weight:bold;'> " + nombreCreador + " - " + reader["CentroCosto"].ToString() + "</label>. &nbsp;&nbsp;&nbsp;&nbsp;" + fecha + " </td>" +
                    "<td><a title='Existen Documentos Adjuntos'>" +
                    "<img width='25px' height='25px' src='../../Images/PaperClip3_Black.png' style='visibility:" + visible + "'/></a></td>" +
                    "<td></td>" +
                    "</tr></table></h3>" +
                    "<div id='ui-accordion-acco-panel-0' class='ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom'  style='width:1060px;'>" +
                    "<p><label style='padding-left:5px;padding-right:5px;font-weight:bold;'>" + reader["Comentario"].ToString() + "</label></p>" +
                    "<p>" + clip + "</p>" +
                    "</div></div>";
                }
            } 
            con.CerrarConexion();
            return resultado;
        }

        public List<Mail> ListarCategoriasAsunto(int ID)
        {
            List<Mail> lista = new List<Mail>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "Mensajeria_Asunto_List";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Catmensaje", ID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Mail mensaje = new Mail();
                        mensaje.IDMail = Convert.ToInt32(reader["ID_CatMensajeria"].ToString());
                        mensaje.Asunto = reader["Nombre_Cat"].ToString();
                        lista.Add(mensaje);
                    }
                }
                catch
                {
                }
            }
            con.CerrarConexion();
            return lista;
        }

        public bool EnviarCorreo(string OT,string NombreOT, string Asunto, string Comentario, string Usuario)
        {
            /* Carga de PAra la base de Datos*/
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            Mail_Controller mc = new Mail_Controller();
            List<Mail> lista = mc.EnviarMailImportancia(OT);
            //string destinatario = "";
            foreach (Mail a in lista)
            {
                mmsg.To.Add(a.correo);
            }
            //mmsg.To.Add("sistema.intranet@aimpresores.cl");
            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add("juan.venegas@aimpresores.cl");
            //mmsg.To.Add("sistema.intranet@aimpresores.cl");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            DateTime fe = DateTime.Now;
            string f = fe.ToString("dd-MM-yyyy HH:mm:ss");
            //Asunto
            mmsg.Subject = "Mensaje Urgente para OT: " + OT + " - " + NombreOT;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Body = "<table style='width:100%;'>" +
                    "<tr>" +
                    "<td>" +
                    "<img src='http://intranet.qgchile.cl/images/Logo color lateral.jpg' width='267px'  height='67px' />" +
                    //"<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
                    "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>" +
                    "&nbsp;</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>" +
                    "Estimado(a) Usuario:" +
                    "<br />" +
                    "<br />" +
                    "<br />" +
                    "Se ha generado un mensaje Urgente para la OT:<label style='font-weight:bold;'> " + OT + " - " + NombreOT + "</label>" +
                    "<br />" +
                    "<br />" +
                    "" +
                    "<label style='font-weight: bold;margin-left:15px;'>Generado por: </label>" + Usuario +
                    "<br />" +
                    "<br />" +
                    "<label style='font-weight: bold;margin-left:15px;'> Fecha:</label> " + f +
                    "<br />" +
                    "<br />" +
                    "<label style='font-weight: bold;margin-left:15px;'>Asunto:</label> " + Asunto +
                    "<br />" +
                    "<br />" +
                    "<div style='border:1px solid;width:100px;margin-top:-5px;'>" +
                    "<label style='font-weight: bold;margin-left:15px;'>Mensaje:</label> " +
                    "</div>" +
                    "<div style='border:1px solid;'>" + Comentario +
                    "</div>" +
                    "<br />" +
                    "<br />" +
                    "Antes de Acceder al Link, debe estar previamente autentificado en el sistema." +
                    "<br />" +
                    "http://intranet.qgchile.cl/ModuloProduccion/view/Suscripcion.aspx?id=1" +
                    "<br />" +
                    "<br />" +
                    "Atentamente," +
                    "<br />" +
                    "Equipo de desarrollo A Impresores S.A" +
                    "</td>" +
                    "</tr>" +
                    "</table>";

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

    }
}