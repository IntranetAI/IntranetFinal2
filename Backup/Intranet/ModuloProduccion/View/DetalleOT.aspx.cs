using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloUsuario.Controller;
using System.Data.SqlClient;
using System.Data;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloUsuario.Model;
using System.Web.Services;
using System.IO;
using System.Drawing;
using Intranet.ModuloEncuadernacion.Controller;
using System.Web.Script.Serialization;

namespace Intranet.ModuloProduccion.View
{
    public partial class DetalleOT : System.Web.UI.Page
    {
        public static List<Archivo> arch = new List<Archivo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string OT = "";
            if (!IsPostBack)
            {
                OT = Request.QueryString["ot"];
                txtVarOT.Text = OT;
                OrdenController oc = new OrdenController();
                Label2.Text = "OT: " + OT + " -  " + oc.Seguimiento_BuscarNM(OT);
                Cargar_Mensajeria(OT);
                Cargar_FechaEntrega(OT);
                Cargar_ProgramaProduccion(OT);
                Cargar_PliegosImpresos(OT);
                Cargar_Encuadernacion(0, OT);
                Cargar_EntregaEnc(OT);
                Cargar_Despacho(OT);
                CargarCatMensaje();
                txtVarUsuario.Text = Session["Usuario"].ToString();
            }
            try
            {
                string IDRespuesta = Request.QueryString["IDRespuesta"].ToString();
                if (IDRespuesta != "")
                {
                    TabContainer2.ActiveTabIndex = 0;
                    string IDMensajeR = Request.QueryString["IDMensaje"].ToString();
                    txtRespuesta.Text = Request.QueryString["Co"].ToString();
                    lblidAdjuntoM.Text = IDMensajeR;
                    txtIDRespuesta.Text = IDRespuesta.ToString();
                    document_attachment_GetAll2(Convert.ToInt32(IDRespuesta));
                    string popupScript4 = "<script language='JavaScript'>newRespuesta(" + IDMensajeR + ");AdjuntoArchivos2();</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
            }
            catch
            { }
            try
            {
                if (Request.QueryString["IDMensaje"].ToString() != "")
                {
                    TabContainer2.ActiveTabIndex = 0;
                    string ADJ = Request.QueryString["MensajeAdj"].ToString();
                    string IDMensaje = Request.QueryString["IDMensaje"].ToString();
                    if (ADJ == "Si" && IDMensaje != "")
                    {
                        Mail_Controller controlm = new Mail_Controller();
                        Mail m = controlm.BuscarIDMensaje(Convert.ToInt32(IDMensaje));
                        lblidAdjuntoM.Text = IDMensaje;
                        txtNOT.Text = OT;
                        txtMensaje.Text = Request.QueryString["Co"].ToString();
                        ddlTipoMensaje.SelectedValue = m.nombre;
                        ddlCategoria.Attributes.Remove("disabled");
                        ddlCategoria.SelectedItem.Text = m.numeroOT;
                        ddlAsunto.Attributes.Remove("disabled");
                        Cargar_Asunto(Convert.ToInt32(m.Comentario));
                        ddlAsunto.SelectedItem.Text = m.Asunto;
                        chkImportancia.Checked = Convert.ToBoolean(Request.QueryString["rgn"].ToString());
                        document_attachment_GetAll(Convert.ToInt32(IDMensaje));
                        string popupScript4 = "<script language='JavaScript'>AdjuntoArchivos();</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript4);
                    }
                }
            }
            catch
            {
            }
            try
            {
                string Mensajeria = Request.QueryString["Mensajeria"].ToString();
                if (Mensajeria != "")
                {
                    TabContainer2.ActiveTabIndex = 0;
                }
            }
            catch
            {
            }
        }
        
        public void Cargar_Mensajeria(string OT)
        {
            Mail_Controller controlm = new Mail_Controller();
            lblmensajeria.Text = controlm.listarMensajes(OT, Session["Usuario"].ToString(), 1);//forma asc
            ddlAsunto.Attributes.Add("disabled", "disabled");
            ddlCategoria.Attributes.Add("disabled", "disabled");
            OrdenController oc = new OrdenController();
            lblNombreOT.Text = oc.Seguimiento_BuscarNM(OT);
        }

        public void Cargar_FechaEntrega(string OT)
        {
            DespachoController controldes = new DespachoController();
            RadGrid4.DataSource = controldes.sp_ListarFuturos_Mostrar(OT,"","",DateTime.Now.ToString("yyyy-MM-dd"),DateTime.Now.AddYears(+1).ToString("yyyy-MM-dd HH:mm:ss"),0);
            RadGrid4.DataBind();
        }

        public void Cargar_ProgramaProduccion(string OT)
        {
            ProduccionController pc = new ProduccionController();
            RadGrid12.DataSource = pc.Lista_Pliegos_Impresos2(OT).OrderBy(o => o.Pliego);
            RadGrid12.DataBind();
        }

        public void Cargar_PliegosImpresos(string OT)
        {
            ProduccionController pc = new ProduccionController();
            RadGrid22.DataSource = pc.Lista_Pliegos_Impresos(OT).OrderBy(o => o.Pliego);
            RadGrid22.DataBind();
        }

        public void Cargar_Encuadernacion(int Procedimiento, string OT)
        {
            if (Procedimiento == 0)
            {
                RadGrid7.DataSource = "";
                RadGrid7.DataBind();
            }
            else
            {
                Controller_ProductosTerminados pt = new Controller_ProductosTerminados();
                DateTime fec = Convert.ToDateTime("01-01-1900");
                RadGrid7.DataSource = pt.CARGA_INFORMEPRODUCCIONENC(OT, "", fec, fec, 2);
                RadGrid7.DataBind();
            }
        }

        public void Cargar_EntregaEnc(string OT)
        {
            OrdenController oc = new OrdenController();
            RadGrid3.DataSource = oc.CargarAprobadosPT(OT, 2);
            RadGrid3.DataBind();
        }

        public void Cargar_Despacho(string OT)
        {
            DespachoController controldes = new DespachoController();
            RadGrid5.DataSource = controldes.ListarDespacho(OT);
            RadGrid5.DataBind();
        }

        protected void ibAsc_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibDesc_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnCargarEncuadernacion_Click(object sender, EventArgs e)
        {
            Cargar_Encuadernacion(1, Request.QueryString["ot"]);
        }

        public void CargarCatMensaje()
        {
            Mail_Controller controlm = new Mail_Controller();
            ddlCategoria.DataSource = controlm.ListarCategoriasAsunto(0);
            ddlCategoria.DataTextField = "Asunto";
            ddlCategoria.DataValueField = "IDMail";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        [WebMethod]
        public static string CargarAsuntosMensajes(int ID)
        {
            Mail_Controller controlm = new Mail_Controller();
            List<Mail> lista = controlm.ListarCategoriasAsunto(ID);
            List<Mail> lista2 = new List<Mail>();

            int contador = 1;
            Mail insert1 = new Mail();
            insert1.Asunto = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Mail ps in lista)
            {
                Mail objst = new Mail();
                objst.Asunto = ps.Asunto;
                objst.IDMail = ps.IDMail;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }

        [WebMethod]
        public static string[] CrearMensaje(string OT, string NombreOT, string TipoMensaje, string Categoria, string Asunto, string Comentario, string Usuario, bool urgente, string idcategoria)
        {
            int IDMensaje = 0;
            string Mensaje = "";
            Mail_Controller controlm = new Mail_Controller();
            if ((Asunto != "Seleccionar") && (Comentario.Count() > 4) && (Categoria != "Seleccionar") && (TipoMensaje != "Seleccionar"))
            {
                IDMensaje = controlm.NuevoMensaje(OT, NombreOT, Asunto, Comentario, Usuario, Convert.ToInt32(idcategoria), Categoria, TipoMensaje);
                Mensaje = "OK";
                if (IDMensaje != 0)
                {
                    if (urgente)
                    {
                        controlm.EnviarCorreo(OT, NombreOT, Asunto, Comentario, Usuario);
                    }
                }
                else
                {
                    Mensaje = "Ha ocurrido un error, vuelva a intentarlo";
                }
            }
            else
            {

                Mensaje = "El Mensaje debe tener Asunto y Comentario, estos deben ser mayor a 4 caracteres.";
            }

            return new[] { IDMensaje.ToString(), Mensaje };
        }

        protected void btnAdjuntarMensaje_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileguid = Guid.NewGuid().ToString();
                string FileName = FileUpload1.FileName;
                try
                {
                    FileUpload1.SaveAs(Server.MapPath("../../ModuloUsuario/View/Uploads/") + fileguid);

                }
                catch
                {
                    //error....
                    return;
                }

                int i = 0;
                if (lblidAdjuntoM.Text == "")
                {
                    i = document_attachment_Insert(FileName, fileguid, null, null, 1);
                }
                else
                {

                    i = document_attachment_Insert(FileName, fileguid, Convert.ToInt32(lblidAdjuntoM.Text), null, 1);
                }
                if (i == 0)
                {
                    //error....
                }
                else
                {
                    Archivo a = new Archivo();
                    a.IDArchivo = i;

                    arch.Add(a);

                    Response.Redirect("DetalleOT.aspx?ot=" + Request.QueryString["ot"] + "&MensajeAdj=Si&IDMensaje=" + lblidAdjuntoM.Text + "&Co=" + txtMensaje.Text + "&rgn=" + chkImportancia.Checked);
                }
            }
        }

        public void document_attachment_GetAll(int idmensaje)
        {
            OrdenController oc = new OrdenController();
            RadGrid1.DataSource = oc.Seguimiento_MostrarArchivos(idmensaje, 0, 1);
            RadGrid1.DataBind();
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

        public void Cargar_Asunto(int ID)
        {
            Mail_Controller controlm = new Mail_Controller();
            ddlAsunto.DataSource = controlm.ListarCategoriasAsunto(ID);
            ddlAsunto.DataValueField = "IDMail";
            ddlAsunto.DataTextField = "Asunto";
            ddlAsunto.DataBind();
        }

        [WebMethod]
        public static string[] Cargar_referenciaMensaje(string ID, string Usuario)
        {
            Mail_Controller controlm = new Mail_Controller();
            Mail m = controlm.BuscarIDMensaje(Convert.ToInt32(ID));
            string referencia = controlm.listarMensaje_referencia(ID, Usuario, 3);//forma asc

            return new[] { referencia, m.Asunto, m.OT, m.NM, m.numeroOT, m.nombre };
        }

        [WebMethod]
        public static string[] CrearRespuesta(string ID, string Usuario, string Respuesta)
        {
            int r = 0;
            string Resultado = "";
            if (Respuesta.Count() > 4)
            {
                Mail_Controller controlm = new Mail_Controller();
                r = controlm.RespuestaMail(Convert.ToInt32(ID), Respuesta, Usuario);
                //lblidRespuesta.Text = r.ToString();

                if (r != 0)
                {
                    Resultado = "OK";
                }
                else
                {
                    Resultado = "Ha ocurrido un error, vuelva a intentarlo";
                }
            }
            else
            {
                Resultado = "La respuesta debe ser mayor a 4 caracteres.";
            }
            return new[] { Resultado, r.ToString() };
        }

        protected void btnAdjuntarRespuesta_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                string fileguid = Guid.NewGuid().ToString();
                string FileName = FileUpload2.FileName;
                try
                {
                    FileUpload2.SaveAs(Server.MapPath("../../ModuloUsuario/View/Uploads/") + fileguid);

                }
                catch
                {
                    //error....
                    return;
                }

                int i = document_attachment_Insert(FileName, fileguid, null, Convert.ToInt32(txtIDRespuesta.Text), 1);
                if (i == 0)
                {
                    //error....
                }
                else
                {
                    Archivo a = new Archivo();
                    a.IDArchivo = i;

                    arch.Add(a);

                    Response.Redirect("DetalleOT.aspx?ot=" + Request.QueryString["ot"] + "&IDMensaje=" + txtIDMensaje.Text + "&Co=" + txtRespuesta.Text + "&IDRespuesta=" + txtIDRespuesta.Text);
                }
            }
        }

        public void document_attachment_GetAll2(int idRespuesta)
        {
            OrdenController oc = new OrdenController();
            RadGrid2.DataSource = oc.Seguimiento_MostrarArchivos(0, idRespuesta, 2);
            RadGrid2.DataBind();
        }

        [WebMethod]
        public static string cargarListMensaje(string OT, string Usuario)
        {
            Mail_Controller controlm = new Mail_Controller();
            string mensajeria = controlm.listarMensajes(OT, Usuario, 1);//forma asc
            return mensajeria;
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            string popupScript4 = "<script language='JavaScript'>window.close();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript4);
        }

        [WebMethod]
        public static void NoLeido(bool estado, string idmensaje, string usuario)
        {
            if (estado == true)
            {

                bool respuesta;
                OrdenController controlOT = new OrdenController();

                respuesta = controlOT.mensajesNoLeidos(Convert.ToInt32(idmensaje), usuario);
            }
        }
    }
} 