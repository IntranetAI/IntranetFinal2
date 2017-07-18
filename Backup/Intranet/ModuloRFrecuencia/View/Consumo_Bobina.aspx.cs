using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Controller;
using Intranet.ModuloRFrecuencia.Model;
using System.Drawing;
using Telerik.Web.UI;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Consumo_Bobina : System.Web.UI.Page
    {
        OrdProduccion_Controller controlOrdPro = new OrdProduccion_Controller();
        Bobina_Controller controlbo = new Bobina_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string OT = Request.QueryString["OT"].ToString();
                    string Pliego = Request.QueryString["Pliego"].ToString();
                    lblUsuario.Text = Session["Usuario"].ToString();

                    try
                    {
                        try
                        {
                            string code = Request.QueryString["cod"].ToString();
                            TabContainer1.ActiveTabIndex = 0;
                            lblOT.Text = OT;
                            lblPliego.Text = Pliego;
                            txtCodigoB.Text = code;
                            List<Bobina> lista = new List<Bobina>();
                            Bobina bobina = controlbo.BuscarBobinaCerrar(Convert.ToInt32(code));
                            lista.Add(bobina);
                            RadGrid1.DataSource = lista;
                            RadGrid1.Visible = true;
                            TabPanel2.Enabled = false;
                            TabPanel1.Enabled = false;
                            ddlMaquina.Enabled = false;
                            txtTapa.Enabled = false;
                            txtEmboltorio.Enabled = false;
                            ddlEstado.Enabled = false;
                            txtTapa.Text = bobina.Peso_Tapa.ToString(); txtTapa.Enabled = false;
                            txtEmboltorio.Text = bobina.Peso_emboltorio.ToString(); txtEmboltorio.Enabled = false;
                            txtEscarpe.Text = bobina.PesoEscarpe.ToString();
                            IDBobina.Text = bobina.ID_Bobina.ToString();
                            btnEditar.Visible = true;
                            btnGrabar.Visible = false;
                            txtCodigoB.Enabled = false;
                            ddlMaquina.Items.FindByText(bobina.Ubicacion).Selected = true;
                        }
                        catch
                        {
                            string CodeBob = Request.QueryString["Code"].ToString();
                            TabContainer1.ActiveTabIndex = 1;
                            lblOT.Text = OT;
                            lblPliego.Text = Pliego;
                            Bobina bobina = controlbo.BuscarBobinaCerrar(Convert.ToInt32(CodeBob));
                            //ddlMaquina.Items.FindByText(bobina.Ubicacion).Selected = true;
                            CargarCieBob(bobina);
                            TabPanel2.Enabled = false;
                            TabPanel0.Enabled = false;
                        }
                    }
                    catch
                    {
                        if (Pliego == "")
                        {
                            ddlPliego.Visible = true;
                            ddlPliego.DataSource = controlOrdPro.listaOrPliegos(OT, "");
                            ddlPliego.DataTextField = "";
                            ddlPliego.DataValueField = "";
                            ddlPliego.DataBind();
                        }
                        else
                        {
                            lblOT.Text = OT;
                            lblPliego.Text = Pliego;
                        }
                        TabContainer1.ActiveTabIndex = 0;
                        TabPanel2.Enabled = false;
                        TabPanel1.Enabled = false;
                    }
                }
                catch
                {
                    int bdg = Convert.ToInt32(Request.QueryString["Bodega"].ToString());
                    txtOT.Visible = true;
                    lblUsuario.Text = Session["Usuario"].ToString();
                    Label15.Visible = true;
                    ddlMaquina.Visible = true;
                    TabPanel2.Enabled = false;
                    TabPanel1.Enabled = false;
                    btnBuscar.Visible = true;
                }
            }
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoB.Text.Length > 0)
            {
                string codigo = "0";
                if (txtCodigoB.Text != "")
                {
                    codigo = txtCodigoB.Text;
                }
                
                Bobina  bob = controlbo.BuscarBobinaCodigo(codigo);
                if (bob.Ubicacion == "Nueva"||bob.Ubicacion == "Saldo")
                {
                    CargarBobina();
                    if (bob.Ubicacion == "Saldo")
                    {
                        txtEmboltorio.Text = "0";
                        txtEscarpe.Text = "0";
                        txtTapa.Text = "0";
                        txtTapa.Enabled = false;
                        txtEmboltorio.Enabled = false;

                        Validacion.Visible = true;
                        Validacion.Attributes.Add("style", "background-color:green");
                        lblvalidacion.ForeColor = Color.White;
                        lblvalidacion.Text = "Bobina Saldo permite tapa, escarpe y envoltorio valores 0";
                        lblEscarpe.Text = "Peso Escarpe";
                    }
                    else
                    {
                        Validacion.Visible = false;
                    }
                }
                else if (bob.Ubicacion != "" && bob.Ubicacion != null)
                {
                    Validacion.Visible = true;
                    Validacion.Attributes.Add("style", "background-color:Red");
                    Image.ImageUrl = "../../Images/cross.png";
                    lblvalidacion.ForeColor = Color.White;
                    lblvalidacion.Text = bob.Ubicacion;
                    RadGrid1.Visible = false;
                }
                else if (bob.Ubicacion == null)
                {
                    Validacion.Visible = true;
                    Validacion.Attributes.Add("style", "background-color:Red");
                    Image.ImageUrl = "../../Images/cross.png";
                    lblvalidacion.ForeColor = Color.White;
                    lblvalidacion.Text = "El Codigo de Bobina debe ser Pxxxxxxxxx";
                    RadGrid1.Visible = false;
                }
            }
        }

        public void CargarBobina()
        {
            string codigo = "0";
            //try
            //{
            if (txtCodigoB.Text != "")
            {
                codigo = txtCodigoB.Text;
            }
            //}
            //catch
            //{
            //    codigo = Convert.ToInt32(txtCodigoB.Text.Substring(1, txtCodigoB.Text.Length - 1));
            //}
            Bobina bob = controlbo.BuscarBobinaCodigo(codigo);
            List<Bobina> lista = new List<Bobina>();
            lista.Add(bob);
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();
            Validacion.Visible = false;
            RadGrid1.Visible = true;
            lblBobina.Text = bob.Ubicacion;
        }

        public void CargarCieBob(Bobina b)
        {
            List<Bobina> lista = new List<Bobina>();
            lista.Add(b);
            RadGrid2.DataSource = lista;
            lbltapa.Text = b.Peso_Tapa.ToString();
            IDBobina.Text = b.ID_Bobina.ToString();
            lblEnvoltura.Text = b.Peso_emboltorio.ToString();
            lblEscarClose.Text = b.PesoEscarpe.ToString();
            ddlMaquina.Enabled = false;
        }

        protected void ddlResponsable_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlResponsable.SelectedValue) != 0)
            {
                ddlCausa.DataSource = controlbo.BuscarEstado_bobi(Convert.ToInt32(ddlResponsable.SelectedValue));
                ddlCausa.DataTextField = "Tipo";
                ddlCausa.DataValueField = "Codigo";
                ddlCausa.DataBind();
                ddlCausa.Visible = true;
                lblcausa.Visible = true;
            }
            else
            {
                ddlCausa.Visible = false;
                lblcausa.Visible = false;
            }
        }

        protected void ddlSaldo_TextChanged(object sender, EventArgs e)
        {
            int seleccion = Convert.ToInt32(ddlSaldo.SelectedValue);
            //if (Maquina == "Dimensionadora")
            //{
            if (seleccion == 2)
            {
                //lblSaldo.Visible = false;
                //txtSaldo.Visible = false;
                lblConoR.Visible = true;
                txtCono.Visible = true;
                lblKilos.Visible = true;
                txtSaldo.Visible = false;
                lblPesoFBobina.Visible = false;
            }
            else
            {
                lblConoR.Visible = false;
                txtCono.Visible = false;
                //lblSaldo.Visible = false;
                //txtSaldo.Visible = false;
                lblPesoFBobina.Visible = true;
                txtSaldo.Visible = true;
                lblKilos.Visible = true;
            }
        }

        protected void ddlEstado_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlEstado.SelectedValue) == 2)
            {
                ddlResponsable.Visible = true;
            }
            else
            {
                ddlResponsable.Visible = false;
                lblcausa.Visible = false;
                ddlCausa.Visible = false;
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Bobina b = new Bobina();
            try
            {
                b.NumeroOp = Request.QueryString["OT"].ToString();
            }
            catch
            {
                b.NumeroOp = txtOT.Text.ToString();
            }
            try
            {
                b.Codigo = txtCodigoB.Text;
            }
            catch
            {
                b.Codigo = txtCodigoB.Text.Substring(1, txtCodigoB.Text.Length - 1);
            }
            try
            {
                b.pliego = Request.QueryString["Pliego"].ToString();
            }
            catch
            {
                b.pliego = ddlPliego.SelectedValue.ToString();
            }
            for(int i= 0; i<RadGrid1.Items.Count;i++)
            {
                GridDataItem item = (GridDataItem)RadGrid1.Items[i];
                b.Proveedor = item["Proveedor"].Text;
                b.Marca = item["Marca"].Text;
                b.Tipo = item["Tipo"].Text;
                string PBruto = item["Peso_Original"].Text;
                if (PBruto.Length >= 4)
                {
                    //b.Peso_Original = Convert.ToInt32(Convert.ToDouble(PBruto.ToString()).ToString().Replace(',','.'));
                    b.Peso_Original = Convert.ToInt32(PBruto.ToString().Replace(",", string.Empty));
                }
                else
                {
                    b.Peso_Original = Convert.ToInt32(PBruto);
                }
                string PGr = item["Gramage"].Text;
                if (PGr.Length >= 4)
                {
                    b.Gramage = Convert.ToInt32(PGr.Replace(",", string.Empty));
                }
                else
                {
                    b.Gramage = Convert.ToInt32(PGr);
                }
                string PAncho = item["Ancho"].Text;
                if (PAncho.Length >= 4)
                {
                    b.Ancho = Convert.ToInt32(PAncho.Replace(",", string.Empty));
                }
                else
                {
                    b.Ancho = Convert.ToInt32(PAncho);
                }
            }
            if (Convert.ToInt32(ddlEstado.SelectedValue) == 1)
            {
                b.Responsable = 1;
                b.Estado_Bobina = 100;
            }
            else
            {
                b.Responsable = Convert.ToInt32(ddlResponsable.SelectedValue);
                b.Estado_Bobina = Convert.ToInt32(ddlCausa.SelectedValue);
            }
            b.Peso_Tapa = Convert.ToDouble(txtTapa.Text);
            b.Peso_emboltorio = Convert.ToDouble(txtEmboltorio.Text);
            b.PesoEscarpe = Convert.ToDouble(txtEscarpe.Text);
            string Fecha = "";
            if(txtFecha.Text!="")
            {
                Fecha = txtFecha.Text +" "+ddlTurno.SelectedValue;
            }
            if (b.Codigo != "")
            {
                if (b.PesoEscarpe <= (30) || txtobs.Visible == true)
                {
                    string Maquina = controlbo.BuscarMaquinaUser(GetDireccionIp(Request));
                    if (Maquina != "")
                    {
                        b.Ubicacion = Maquina;
                    }
                    else if (ddlMaquina.SelectedItem.ToString() != "Selecione...")
                    {
                        b.Ubicacion = ddlMaquina.SelectedItem.ToString();
                        Maquina = b.Ubicacion;
                    }

                    if (Maquina == "Dimensionadora")
                    {
                        b.pliego = "&nbsp;";
                    }
                    if (Maquina != "")
                    {
                        if (controlbo.AgregarBobina(b, lblUsuario.Text, Maquina, Fecha))
                        {
                            if ((b.Peso_Tapa < 15) && (b.Peso_emboltorio < 15))
                            {
                                if (b.PesoEscarpe >= (20))
                                {
                                    EnvioCorreo(b, lblUsuario.Text, txtobs.Text.ToString());
                                }
                                try
                                {
                                    int bdg = Convert.ToInt32(Request.QueryString["Bodega"].ToString());

                                    string popupScript4 = "<script language='JavaScript'>opener.location.reload();window.close();</script>";
                                    Page.RegisterStartupScript("PopupScript", popupScript4);
                                }
                                catch
                                {
                                    string popupScript4 = "<script language='JavaScript'>window.opener.location='Pliego_Bobina_Cons.aspx?id=13&cat=3&OT=" + b.NumeroOp + "&Pliego=" + b.pliego + "';window.close();</script>";
                                    //string popupScript4 = "<script language='JavaScript'>opener.location.reload();window.close();</script>";
                                    Page.RegisterStartupScript("PopupScript", popupScript4);
                                }
                            }
                            else
                            {
                                Validacion.Visible = true;
                                Image.ImageUrl = "../../Images/cross.png";
                                lblvalidacion.Text = "Peso de Tapa y de Envoltura no debe ser mayor a 15KG.";
                                lblvalidacion.ForeColor = Color.White;
                                Validacion.Attributes.Add("style", "background-color:red");
                            }
                        }
                        else
                        {
                            Validacion.Visible = true;
                            Image.ImageUrl = "../../Images/cross.png";
                            lblvalidacion.Text = "Error al Ingresar Registro a Base de Datos.";
                            lblvalidacion.ForeColor = Color.White;
                            Validacion.Attributes.Add("style", "background-color:red");
                        }
                    }
                }
                else
                {
                    Validacion.Visible = true;
                    Image.Visible = false;
                    lblvalidacion.Text = "Obs.";
                    lblvalidacion.ForeColor = Color.White;
                    Validacion.Attributes.Add("style", "background-color:red");
                    txtobs.Visible = true;
                }
            }
            else
            {
                Validacion.Visible = true;
                Image.ImageUrl = "../../Images/cross.png";
                lblvalidacion.Text = "Codigo de Bobina es un campo obligatorio.";
                lblvalidacion.ForeColor = Color.White;
                Validacion.Attributes.Add("style", "background-color:red");
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'>window.close();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void btnCerrarB_Click(object sender, EventArgs e)
        {
            Bobina bob = new Bobina();
            bob.Codigo = lblCodigo.Text;
            bob.Peso_Original = Convert.ToInt32(txtPesoOri.Text.Trim());
            bob.Ancho = Convert.ToInt32(txtAncho.Text.Trim());
            bob.Gramage = Convert.ToInt32(txtLargo.Text.Trim());
            if (controlbo.IngresoCodigo(bob))
            {
                TabPanel0.Enabled = true;
                TabPanel1.Enabled = false;
                TabPanel2.Enabled = false;
                TabContainer1.ActiveTabIndex = 0;
                txtCodigoB.Text = bob.Codigo.ToString();
                CargarBobina();
            }
            else
            {
                Div1.Visible = true;
                Div1.Attributes.Add("style", "background-color:Red");
                Image1.ImageUrl = "../../Images/cross.png";
                Label14.ForeColor = Color.White;
                Label14.Text = "Error al Ingresar Bobina.";
            }
        }
        
        public bool EnvioCorreo(Bobina b,string Usuario,string obs)
        {
            /* Carga de PAra la base de Datos*/
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            
            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add("juan.venegas@aimpresores.cl");
            mmsg.To.Add("info.escarpe@aimpresores.cl");
            //mmsg.To.Add("mariamilagros.paez@aimpresores.cl");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Exceso de escarpe en Bobina";
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
            string Daño = "";
            List<Bobina> list = controlbo.BuscarEstado_bobi(b.Responsable);
            foreach (Bobina bobin in list)
            {
                if (bobin.Codigo == "100")
                {
                    Daño = bobin.Tipo;
                }
                else if (bobin.Codigo == ddlCausa.SelectedValue.ToString())
                {
                    Daño = bobin.Tipo;
                }
            }
            OrdenController orden = new OrdenController();
            Orden OT = orden.BuscarPorOT(b.NumeroOp);
            //Cuerpo del Mensaje
            mmsg.Body =
                        "<table style='width:80%;'>" +
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
                            "<td>" + b.NumeroOp + "</td>" +
                            "<td>Nombre OT : </td>" +
                            "<td>" + OT.NombreOT + "</td>" +
                        "</tr>" +
                       // "<tr>" +
                       //     "<td  style='width:194px;'>" +
                       //       " Fecha:</td>" +
                       //     "<td colspan='3'>" + dia + "/" + mes + "/" + año + "</td>" +
                       //"</tr>" +
                        "<tr>" +
                            "<td  style='width:194px;'>" +
                               "Creador Por:</td>" +

                          "<td colspan='3'>" + Usuario +
                               "</td>" +
                       "</tr>"+
                             "</table>" +
                            "<br />" +
                            "</div>" +
                            "<table style='width:80%;'><tr>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Codigo Bob.</td>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>P. Bruto</td>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>P. Tapa</td>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>P. Env.</td>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>P. Esc.</td>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Marca</td>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Tipo</td>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Ancho</td>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Gr</td>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Maquina</td>"+
                                "</tr>"+
                                "<tr>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.Codigo.ToString()+"</td>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.Peso_Original.ToString("N0").Replace(',','.')+"</td>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.Peso_Tapa.ToString()+"</td>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.Peso_emboltorio.ToString()+"</td>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.PesoEscarpe.ToString()+"</td>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.Marca+"</td>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.Tipo+"</td>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.Ancho.ToString()+"</td>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.Gramage.ToString()+"</td>"+
                                    "<td style='border:1px solid #5D8CC9;'>"+b.Ubicacion+"</td>"+
                                "</tr>"+
                                "<tr>"+
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' colspan='10'>Observación</td>"+
                                "</tr>"+
                                "<tr>"+
                                    "<td style='border:1px solid #5D8CC9;' colspan='10'>Daño: " + Daño +"- Obs.:"+ obs + "</td></tr></table>";

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

        protected void btnConsumir_Click(object sender, EventArgs e)
        {
            Bobina b = new Bobina();
            b.ID_Bobina = Convert.ToInt32(IDBobina.Text);

            if (Convert.ToInt32(ddlSaldo.SelectedValue) == 1)
            {
                b.Saldo = Convert.ToInt32(txtSaldo.Text);
                b.Peso_Cono = 0;
                Validacion.Visible = false;
                if (b.Saldo > 0)
                {
                    if (controlbo.UpdateBobinaClose(b, 1))
                    {
                        string popupScript4 = "<script language='JavaScript'>window.opener.location='Pliego_Bobina_Cons.aspx?id=13&cat=3&OT=" + lblOT.Text + "&Pliego=" + lblPliego.Text + "';window.close();</script>";
                        //string popupScript4 = "<script language='JavaScript'>opener.location.reload();window.close();</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript4);
                    }
                    else
                    {
                        Validacion0.Visible = true;
                        Validacion0.Attributes.Add("style", "background-color:Red");
                        Image0.ImageUrl = "../../Images/cross.png";
                        lblvalidacion0.ForeColor = Color.White;
                        lblvalidacion0.Text = "Error de Conexion, Intente Nuevamente.";
                    }
                }
                else
                {
                    Validacion0.Visible = true;
                    Validacion0.Attributes.Add("style", "background-color:Red");
                    Image0.ImageUrl = "../../Images/cross.png";
                    lblvalidacion0.ForeColor = Color.White;
                    lblvalidacion0.Text = "Ingrese Monto Valido.";
                }
            }
            if (Convert.ToInt32(ddlSaldo.SelectedValue) == 2)
            {
                b.Saldo = 0;
                Validacion.Visible = false;
                b.Peso_Cono = Convert.ToDouble(txtCono.Text);
                if (controlbo.UpdateBobinaClose(b, 2))
                {
                    string popupScript4 = "<script language='JavaScript'>window.opener.location='Pliego_Bobina_Cons.aspx?id=13&cat=3&OT=" + lblOT.Text + "&Pliego=" + lblPliego.Text + "';window.close();</script>";
                    //string popupScript4 = "<script language='JavaScript'>opener.location.reload();window.close();</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
                else
                {
                    Validacion0.Visible = true;
                    Validacion0.Attributes.Add("style", "background-color:Red");
                    Image0.ImageUrl = "../../Images/cross.png";
                    lblvalidacion0.ForeColor = Color.White;
                    lblvalidacion0.Text = "Error de Conexion, Intente Nuevamente.";
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string OT  = lblOT.Text;
            int Code = Convert.ToInt32(IDBobina.Text);
            double PesoTapas = Convert.ToDouble(txtTapa.Text);
            double PesoEsc = Convert.ToDouble(txtEscarpe.Text);
            double PesoEnv = Convert.ToDouble(txtEmboltorio.Text);
            if ((PesoEsc <= 30) || txtobs.Visible == true)
            {
                if (controlbo.ModificarCodigo(Code, OT, PesoTapas, PesoEsc, PesoEnv))
                {
                    if (PesoEsc >= (30))
                    {
                        Bobina bobina = controlbo.BuscarBobinaCerrar(Convert.ToInt32(Code));

                        EnvioCorreo(bobina, lblUsuario.Text, txtobs.Text.ToString());
                    }
                    string popupScript = "<script language='JavaScript'> window.close(); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                else
                {
                    Validacion.Visible = true;
                    Image.ImageUrl = "../../Images/cross.png";
                    lblvalidacion.Text = "Error al Ingresar Registro a Base de Datos.";
                    lblvalidacion.ForeColor = Color.White;
                    Validacion.Attributes.Add("style", "background-color:red");
                }
            }
            else
            {
                Validacion.Visible = true;
                Image.Visible = false;
                lblvalidacion.Text = "Obs.";
                lblvalidacion.ForeColor = Color.White;
                Validacion.Attributes.Add("style", "background-color:red");
                txtobs.Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ddlMaquina.SelectedItem.Text != "Selecione...")
            {
                ddlPliego.DataSource= controlOrdPro.listaOrPliegos(txtOT.Text.Trim(), ddlMaquina.SelectedItem.Text);
                ddlPliego.DataTextField = "Papel_Solicitud";
                ddlPliego.DataValueField = "Papel_Solicitud";
                ddlPliego.DataBind();
                ddlPliego.Visible = true;
                txtFecha.Visible = true;
                lblFecha.Visible = true;
                ddlTurno.Visible = true;
            }
        }

        public static string GetDireccionIp(System.Web.HttpRequest request)
        {
            // Recuperamos la IP de la máquina del cliente
            // Primero comprobamos si se accede desde un proxy
            string ipAddress1 = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            // Acceso desde una máquina particular
            string ipAddress2 = request.ServerVariables["REMOTE_ADDR"];

            string ipAddress = string.IsNullOrEmpty(ipAddress1) ? ipAddress2 : ipAddress1;

            // Devolvemos la ip
            return ipAddress;
        }
    }
}