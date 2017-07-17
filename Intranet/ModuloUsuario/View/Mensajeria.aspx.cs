using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloUsuario.Controller;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using Intranet.ModuloUsuario.Model;
using System.IO;

namespace Intranet.ModuloUsuario.View
{
    public partial class Mensajeria : System.Web.UI.Page
    {
        OrdenController controlOT = new OrdenController();
        Mail_Controller controlm = new Mail_Controller();
        public static List<Archivo> arch = new List<Archivo>();
        public static string nomUsuario = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Usu"] = Session["Usuario"].ToString();
            Session["Nomb"] = Session["Nombre"].ToString();
            nomUsuario = Session["Usuario"].ToString();
            if (!IsPostBack)
            {
                CargarUsuarioMail();
                lblOTClick.Visible = true;
                //pnlTitulo.Visible = false;c  
            }
            Master.boton1.Text = "<ul id='accordion'><li><a href='RedactarMensaje.aspx'>Redactar</a></li></ul>";
        }

        public void CargarUsuarioMail()
        {
            RadGrid1.DataSource = controlOT.ListarOT_Mail("", "", "", null, null, 0, Session["Usuario"].ToString());
            RadGrid1.DataBind();
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "RowClick")
            {
                Panel2.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string OT = item["NumeroOT"].Text;
                Panel3.Visible = true;

                lblOTClick.Visible = true;
                lblOTClick.Text = "<b> " + item["NumeroOT"].Text + " - " + item["NombreOT"].Text + "</b>";

                Label1.Text = controlm.listarMensajes(OT, Session["Usuario"].ToString());
                //Image1.Visible = true;
                Master.boton1.Text = "<ul><li><a href='RedactarMensaje.aspx'>Redactar</a></li>"+
                    "<li><a title='Volver' href='javascript:history.go(-1)'>Volver</a></li></ul>";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (FileUpload1.HasFile)
            //{
            //    string fileguid = Guid.NewGuid().ToString();
            //    string FileName = FileUpload1.FileName;
            //    try
            //    {
            //        FileUpload1.SaveAs(Server.MapPath("./Uploads/") + fileguid);

            //    }
            //    catch
            //    {
            //        //error....
            //        return;g
            //    }

            //    int i = document_attachment_Insert(FileName, fileguid, null, null, 1);
            //    if (i == 0)
            //    {
            //        //error....
            //    }
            //    else
            //    {
            //        Archivo a = new Archivo();
            //        a.IDArchivo = i;

            //        arch.Add(a);

            //        document_attachment_GetAll();
            //    }
            //}
        }
        //public void document_attachment_GetAll()
        //{
        //    try
        //    {
        //        string conexMostarAdj = @"Data Source=192.168.1.228;Initial Catalog=Intranet2;User ID=cons_intranet;Password=cons_qgchile13;";
        //        SqlConnection connection = new SqlConnection(conexMostarAdj);
        //        SqlDataAdapter command = new SqlDataAdapter("document_attachment_GetAllNull", connection);
        //        command.SelectCommand.CommandType = CommandType.StoredProcedure;

        //        DataTable dt = new DataTable();
        //        command.Fill(dt);

        //        griddocument_attachment.DataSource = dt;
        //        griddocument_attachment.DataBind();
        //    }
        //    catch
        //    {
        //    }

        //}
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
            //new_Mensaje1.Visible = true;
            //pnlTitulo.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
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
                    Response.Redirect("Mensajeria.aspx?id=0");
                }
                else
                {
                    Response.Redirect("Mensajeria.aspx?id=0");

                }
            }
            else
            {
                Response.Redirect("Mensajeria.aspx?id=0");
            }

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //int IDMensaje = 0;
            //if (txtOT.Text != "" && txtAsunto.Text != "")
            //{

            //    IDMensaje = controlm.NuevoMensaje(txtOT.Text, txtAsunto.Text, txtMensaje.Text, Session["Usuario"].ToString());
            //    if (IDMensaje != 0)
            //    {
            //        bool respuesta = true;
            //        int contador = arch.Count;
            //        if (contador != 0)
            //        {
            //            foreach (Archivo i in arch)
            //            {
            //                respuesta = controlm.UpdateMailArchivo(i.IDArchivo, IDMensaje);
            //            }
            //            if (respuesta != true)
            //            {
            //                string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error al Adjuntar Archivo'); </script>";
            //                Page.RegisterStartupScript("PopupScript", popupScript);
            //            }
            //            else
            //            {
            //                string popupScript = "<script language='JavaScript'> alert(' Mensaje Enviado Correctamente'); </script>";
            //                Page.RegisterStartupScript("PopupScript", popupScript);
            //            }
            //        }
            //        else
            //        {
            //            string popupScript = "<script language='JavaScript'> alert(' Mensaje enviado Correctamente'); </script>";
            //            Page.RegisterStartupScript("PopupScript", popupScript);
            //        }
            //    }
            //    else
            //    {
            //    }
            //}
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

        protected void Button4_Click(object sender, EventArgs e)
        {
        //    bool r = true;
        //    if (txtRespuesta.Text != "")
        //    {
        //        r = controlm.RespuestaMail(Convert.ToInt32(txtID.Text), txtRespuesta.Text, Session["usuario"].ToString());
        //        if (r != false)
        //        {
        //            string popupScript = "<script language='JavaScript'> alert(' Respuesta ingresada correctamente'); </script>";
        //            Page.RegisterStartupScript("PopupScript", popupScript);
                    
        //        }
        //        else
        //        {
        //            string popupScript = "<script language='JavaScript'> alert(' Ha ocurrido un error, vuelva a intentarlo'); </script>";
        //            Page.RegisterStartupScript("PopupScript", popupScript);
        //        }
        //    }
        //    else
        //    {
        //        string popupScript = "<script language='JavaScript'> alert(' El campo Respuesta es obligatorio '); </script>";
        //        Page.RegisterStartupScript("PopupScript", popupScript);
        //    }
        }
    }
}