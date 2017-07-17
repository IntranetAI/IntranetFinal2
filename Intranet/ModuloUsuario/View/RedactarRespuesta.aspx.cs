using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloUsuario.Controller;
using Intranet.ModuloUsuario.Model;
using Intranet.ModuloProduccion.Controller;
using System.Data.SqlClient;
using System.Data;

namespace Intranet.ModuloUsuario.View
{
    public partial class RedactarRespuesta : System.Web.UI.Page
    {
        string idM = "";
        Mail_Controller controlm = new Mail_Controller();
        OrdenController controlOT = new OrdenController();
        public static List<Archivo> arch = new List<Archivo>();
        public static string nomUsuario = "";
        public static int volver = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            idM = Request.QueryString["id"];

            Mail m = controlm.BuscarIDMensaje(Convert.ToInt32(idM));

            if (m.Asunto != "")
            {
                lblRespuesta.Text = m.Asunto;
                lblOT.Text = m.OT;
                lblNombreOT.Text = m.NM;
                lblAsunto.Text = m.Asunto;
            }
            
        }

        protected void btnResponder_Click(object sender, EventArgs e)
        {
            int r = 0;
            if (txtRespuesta.Text != "")
            {
                r = controlm.RespuestaMail(Convert.ToInt32(Request.QueryString["id"]), txtRespuesta.Text, Session["usuario"].ToString());
                if (r != 0)
                {
                    bool respuesta = true;
                    int contador = arch.Count;
                    if (contador != 0)
                    {
                        foreach (Archivo i in arch)
                        {
                            respuesta = controlm.UpdateRespuestaArchivo(i.IDArchivo, r);
                        }
                        if (respuesta != true)
                        {

                            string popupScript2 = "<script language='JavaScript'> alert('Ha ocurrido un error al Adjuntar Archivo'); </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript2);
                        }
                        else
                        {
                            string popupScript4 = "<script language='JavaScript'> alert(' Respuesta Enviada Correctamente');location.href='javascript:history.go(-" + volver + ")'; </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript4);
                        }
                    }
                    else
                    {
                        string popupScript4 = "<script language='JavaScript'> alert(' Respuesta Enviada Correctamente');location.href='javascript:history.go(-" + volver + ")'; </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript4);
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert(' Ha ocurrido un error, vuelva a intentarlo'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert(' El campo Respuesta es obligatorio '); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            arch = null;
            arch = new List<Archivo>();
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
                    //Response.Redirect("Mensajeria.aspx?id=0");
                    string popupScript4 = "<script language='JavaScript'> location.href='javascript:history.go(-"+ volver+")'; </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
                else
                {
                    //Response.Redirect("Mensajeria.aspx?id=0");
                    string popupScript4 = "<script language='JavaScript'> location.href='javascript:history.go(-" + volver + ")'; </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
            }
            else
            {
                //Response.Redirect("Mensajeria.aspx?id=0");
                string popupScript4 = "<script language='JavaScript'> location.href='javascript:history.go(-" + volver + ")'; </script>";
                Page.RegisterStartupScript("PopupScript", popupScript4);
            }
            volver = 2;
        }
    }
}