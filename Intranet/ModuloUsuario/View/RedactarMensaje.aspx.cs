using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloUsuario.Controller;
using Intranet.ModuloUsuario.Model;
using System.Data.SqlClient;
using System.Data;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloUsuario.View
{
    public partial class RedactarMensaje : System.Web.UI.Page
    {
        OrdenController controlOT = new OrdenController();
        Mail_Controller controlm = new Mail_Controller();
        public static List<Archivo> arch = new List<Archivo>();
        public static string nomUsuario = "";
        public static int volver = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            griddocument_attachment.DataSource = "";
            griddocument_attachment.DataBind();
            nomUsuario = Session["Usu"].ToString();

            try
            {
                if (Request.QueryString["var"].ToString() == "1")
                {
                   // Response.Redirect("http://www.google.cl");
                    txtNOT.Enabled = false;
                    txtNOT.Text = Session["OT"].ToString();
                    txtMensaje.Enabled = true;
                    txtAsunto.Enabled = true;
                    btnBuscar.Visible = false;

                    //cargamos dato ot
                    OrdenController controlOT = new OrdenController();
                    Orden DatosOrden = controlOT.BuscarPorOT(Session["OT"].ToString());

                    if (DatosOrden.NombreOT != "")
                    {
                        txtAsunto.Enabled = true;
                        txtMensaje.Enabled = true;
                        lblNombreOT.Text = DatosOrden.NombreOT;
                    }
                    else
                    {
                        
                    }
                }
            }
            catch
            {
            }
            volver = 2;
        }
        //metodo Autocompletar El N° de OT
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText)
        {
            //  
            // return (from m in nombres where m.StartsWith(prefixText,StringComparison.CurrentCultureIgnoreCase) select m).Take(count).ToArray();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionData_P2B();
            cmd.CommandText = "Select TOP 15 QG_RMS_JOB_NBR from QGPressJob pj inner join Produccion.dbo.OTAsignada oa " +
            "on pj.QG_RMS_JOB_NBR collate SQL_Latin1_General_CP1_CI_AS=oa.NumeroOT collate SQL_Latin1_General_CP1_CI_AS " +
            "inner join intranet2.dbo.usuarios usu on usu.idUsuario=oa.IDUsuario where oa.Estado=1 and pj.job_sts=1 " +
            "and usu.usuario=@NomUsu and QG_RMS_JOB_NBR like @prefixText";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
            da.SelectCommand.Parameters.Add("@NomUsu", SqlDbType.VarChar, 50).Value = nomUsuario;
            DataTable dt = new DataTable();
            da.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["QG_RMS_JOB_NBR"].ToString(), i);
                i++;
            }
            return items;
        }

        protected void btnAdjuntar_Click(object sender, EventArgs e)
        {
            volver = volver + 1;
            if (FileUpload1.HasFile)
            {
                string fileguid = Guid.NewGuid().ToString();
                string FileName = FileUpload1.FileName;
                try
                {
                    FileUpload1.SaveAs(Server.MapPath("./Uploads/") + fileguid);

                }
                catch
                {
                    //error....
                    return;
                }

                int i = document_attachment_Insert(FileName, fileguid, null, null, 1);
                if (i == 0)
                {
                    //error....
                }
                else
                {
                    Archivo a = new Archivo();
                    a.IDArchivo = i;

                    arch.Add(a);

                    document_attachment_GetAll();
                }
            }
        }
        public void document_attachment_GetAll()
        {
            try
            {
                string conexMostarAdj = @"Data Source=192.168.1.228;Initial Catalog=Intranet2;User ID=cons_intranet;Password=cons_qgchile13;";
                SqlConnection connection = new SqlConnection(conexMostarAdj);
                SqlDataAdapter command = new SqlDataAdapter("document_attachment_GetAllNull", connection);
                command.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                command.Fill(dt);

                griddocument_attachment.DataSource = dt;
                griddocument_attachment.DataBind();
            }
            catch
            {
            }

        }
        public int document_attachment_Insert(string FileName = null, string fileguid = null, int? ID_Mensaje = null, int? ID_Respuesta = null, int? Estado = null)
        {
            //int IDUsuario = 0;
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = "document_attachment_Insert";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter p_attachmentid = new SqlParameter("@attachmentid", SqlDbType.Int);
                    p_attachmentid.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p_attachmentid);
                    cmd.Parameters.AddWithValue("@ID_Mensaje", ID_Mensaje);
                    cmd.Parameters.AddWithValue("@ID_Respuesta", ID_Respuesta);
                    cmd.Parameters.AddWithValue("@filename", FileName);
                    cmd.Parameters.AddWithValue("@fileguid", fileguid);
                    cmd.Parameters.AddWithValue("@Estado", Estado);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (p_attachmentid.Value != null)
                    {
                        return Convert.ToInt32(p_attachmentid.Value);
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
            con.CerrarConexion();
        }

        protected void btnRedactar_Click(object sender, EventArgs e)
        {
            int IDMensaje = 0;
            if (txtNOT.Text != "" && txtAsunto.Text != "" && lblNombreOT.Text != "")
            {

                IDMensaje = controlm.NuevoMensaje(txtNOT.Text, txtAsunto.Text, txtMensaje.Text, Session["Usuario"].ToString());
                if (IDMensaje != 0)
                {
                    bool respuesta = true;
                    int contador = arch.Count;
                    if (contador != 0)
                    {
                        foreach (Archivo i in arch)
                        {
                            respuesta = controlm.UpdateMailArchivo(i.IDArchivo, IDMensaje);
                        }
                        if (respuesta != true)
                        {
                            string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error al Adjuntar Archivo'); </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                        else
                        {
                            if (chkImportancia.Checked == true)
                            {
                                string popupScript = "<script language='JavaScript'> alert(' Mensaje Enviado Correctamente'); location.href='javascript:history.go(-" + volver + ")';  </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);
                            }
                            else
                            {
                                string popupScript = "<script language='JavaScript'> alert(' Mensaje Enviado Correctamente'); location.href='javascript:history.go(-" + volver + ")';  </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);
                            }

                        }
                    }
                    else
                    {
                        if (chkImportancia.Checked == true)
                        {
                            EnviarCorreo();
                            string popupScript = "<script language='JavaScript'> alert(' Mensaje Enviado Correctamente'); location.href='javascript:history.go(-" + volver + ")';  </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert(' Mensaje Enviado Correctamente'); location.href='javascript:history.go(-" + volver + ")';  </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error, vuelva a intentarlo');location.href='Mensajeria.aspx' </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('¡Debe buscar una OT para crear mensaje!');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            bool resp = true;

            int cont = arch.Count;

            if (cont != 0)
            {
                foreach (Archivo i in arch)
                {
                    resp = controlm.DeleteArchivo(i.IDArchivo);
                }
                if (resp != true)
                {
                    string popupScript4 = "<script language='JavaScript'> location.href='javascript:history.go(-" + volver + ")'; </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
                else
                {
                    string popupScript4 = "<script language='JavaScript'> location.href='javascript:history.go(-" + volver + ")'; </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);

                }
            }
            else
            {
                string popupScript4 = "<script language='JavaScript'> location.href='javascript:history.go(-" + volver + ")'; </script>";
                Page.RegisterStartupScript("PopupScript", popupScript4);
            }
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            OrdenController controlOT = new OrdenController();
            Orden DatosOrden = controlOT.BuscarPorOT(txtNOT.Text);

            if (DatosOrden.NombreOT != "")
            {
                txtAsunto.Enabled = true;
                txtMensaje.Enabled = true;
                lblNombreOT.Text = DatosOrden.NombreOT;
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('La OT no ha sido encontrada, vuelva a encontrarla');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
           
        }

        //Metodo enviar Correo
        public bool EnviarCorreo()
        {
            /* Carga de PAra la base de Datos*/
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            Mail_Controller mc = new Mail_Controller();
            List<Mail> lista = mc.EnviarMailImportancia(txtNOT.Text);
            //string destinatario = "";
            foreach (Mail a in lista)
            {
               mmsg.To.Add(a.correo);
            }
            //mmsg.To.Add("sistema.intranet@qgchile.cl");
            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add("juan.venegas@qgchile.cl");
            //mmsg.To.Add("sistema.intranet@qgchile.cl");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            DateTime fe = DateTime.Now;
            string f = fe.ToString("dd-MM-yyyy HH:mm:ss");
            //Asunto
            mmsg.Subject = "Mensaje Urgente para OT: "+txtNOT.Text+" - "+lblNombreOT.Text;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Body = "<table style='width:100%;'>" +
                    "<tr>" +
                    "<td>" +
                    "<img src='http://www.qg.com/images/qg_logocrop.gif' />" +
                    "<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
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
                    "Se ha generado un mensaje Urgente para la OT:<label style='font-weight:bold;'> " + txtNOT.Text + " - " + lblNombreOT.Text +"</label>"+
                    "<br />" +
                    "<br />" +
                    "" +
                    "<label style='font-weight: bold;margin-left:15px;'>Generado por: </label>" + Session["Nombre"].ToString() +
                    "<br />" +
                    "<br />" +
                    "<label style='font-weight: bold;margin-left:15px;'> Fecha:</label> " + f +
                    "<br />" +
                    "<br />" +
                    "<label style='font-weight: bold;margin-left:15px;'>Asunto:</label> " + txtAsunto.Text +
                    "<br />" +
                    "<br />" +
                    "<div style='border:1px solid;width:100px;margin-top:-5px;'>" +
                    "<label style='font-weight: bold;margin-left:15px;'>Mensaje:</label> " + 
                    "</div>"+
                    "<div style='border:1px solid;'>" +
                    txtMensaje.Text +
                    "</div>"+
                    "<br />" +
                    "<br />" +
                    "Antes de Acceder al Link, debe estar previamente autentificado en el sistema."+
                    "<br />" +
                    "http://intranet.qgchile.cl/ModuloProduccion/view/Suscripcion.aspx?id=1" +
                    "<br />" +
                    "<br />" +
                    "Atentamente," +
                    "<br />" +
                    "Equipo de desarrollo Quad/Graphics Chile S.A" +
                    "</td>" +
                    "</tr>" +
                    "</table>";

            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@qgchile.cl");//"fecha.produccion@qgchile.cl");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("sistema.intranet@qgchile.cl", "SI2013.");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            /*
            cliente.Port = 587;
            cliente.EnableSsl = true;
            */

            cliente.Host = "mail.qgchile.cl";


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