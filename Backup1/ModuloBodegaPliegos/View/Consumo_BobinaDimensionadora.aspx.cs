using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Model;
using Intranet.ModuloRFrecuencia.Controller;
using System.Drawing;
using Telerik.Web.UI;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class Consumo_BobinaDimensionadora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                string OT = Request.QueryString["o"].ToString();
                string Pliego = Request.QueryString["c"].ToString();
                string folio = Request.QueryString["f"].ToString();
                string Cantidad = Request.QueryString["t"].ToString();
                string NombreOT = Request.QueryString["n"].ToString();
                lblOT.Text = OT;
                lblPliego.Text = Pliego;
                lblFolio.Text = folio;
                lblCantidad.Text = Cantidad;
                lblUsuario.Text = Session["Usuario"].ToString();
                lblNombreOt.Text = NombreOT;
                try
                {
                    string codigo = Request.QueryString["code"].ToString();
                    TabContainer1.ActiveTabIndex = 1;
                    TabPanel0.Enabled = false;
                    Bobina_Controller controlbo = new Bobina_Controller();
                    Bobina bobina = controlbo.BuscarBobinaCerrar(Convert.ToInt32(codigo));
                    CargarCieBob(bobina);
                    TabPanel0.Enabled = false;

                }
                catch
                {
                    TabContainer1.ActiveTabIndex = 0;
                    TabPanel1.Enabled = false;
                }
            }
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            Bobina_Controller controlbo = new Bobina_Controller();
            lblSKU.Text = controlbo.Bobina_Dimensionadora_SKU(lblFolio.Text);
            if (txtCodigoB.Text.Length > 0)
            {
                string codigo = "0";
                if (txtCodigoB.Text != "")
                {
                    codigo = txtCodigoB.Text;
                }

                Bobina bob = controlbo.BuscarBobinaCodigo(codigo);
                if (bob.Ubicacion == "Nueva" || bob.Ubicacion == "Saldo")
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
                        string coincide = "";
                        if (bob.Cono != lblSKU.Text)
                        {
                            coincide = "Esta Bobina no coincide con la solicitud";
                        }
                        lblvalidacion.Text = "Bobina Saldo permite tapa, escarpe y envoltorio valores 0 " + coincide;
                        lblEscarpe.Text = "Peso Escarpe";
                    }
                    else
                    {
                        Validacion.Visible = false;
                        if (bob.Cono != lblSKU.Text)
                        {
                            Validacion.Visible = true;
                            Validacion.Attributes.Add("style", "background-color:green");
                            lblvalidacion.ForeColor = Color.White;
                            lblvalidacion.Text = "Esta Bobina no coincide con la solicitud";
                        }
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
                    lblvalidacion.Text = "Bobina no encotrada en el Stock de Metrics";
                    RadGrid1.Visible = false;
                }
            }
        }

        public void CargarBobina()
        {
            Bobina_Controller controlbo = new Bobina_Controller();
            string codigo = "0";
            if (txtCodigoB.Text != "")
            {
                codigo = txtCodigoB.Text;
            }
            Bobina bob = controlbo.BuscarBobinaCodigo(codigo);
            List<Bobina> lista = new List<Bobina>();
            lista.Add(bob);
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();
            Validacion.Visible = false;
            RadGrid1.Visible = true;
            lblBobina.Text = bob.Ubicacion;
        }

        protected void ddlEstado_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlEstado.SelectedValue) == 2)
            {
                ddlResponsable.Visible = true;
                ddlResponsable.SelectedIndex = 0;
            }
            else
            {
                ddlResponsable.Visible = false;
                ddlResponsable.SelectedIndex = 0;
                lblcausa.Visible = false;
                ddlCausa.Visible = false;
            }
        }

        protected void ddlResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlResponsable.SelectedValue) != 0)
            {
                Bobina_Controller controlbo = new Bobina_Controller();
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

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Bobina b = new Bobina();
            Bobina_Controller controlbo = new Bobina_Controller();
            b.NumeroOp = Request.QueryString["o"].ToString();
            b.Codigo = txtCodigoB.Text;
            b.pliego = Request.QueryString["c"].ToString();
            
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem item = (GridDataItem)RadGrid1.Items[i];
                b.Proveedor = item["Proveedor"].Text;
                b.Marca = item["Marca"].Text;
                b.Tipo = item["Tipo"].Text;
                string PBruto = item["Peso_Original"].Text;
                if (PBruto.Length >= 4)
                {
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
            if (b.Codigo != "")
            {
                if (b.PesoEscarpe <= (30) || txtobs.Visible == true)
                {
                    string Maquina = controlbo.BuscarMaquinaUser(GetDireccionIp(Request));
                    b.Ubicacion = Maquina;
                    if (Maquina != "")
                    {
                        if (controlbo.AgregarBobinaDimen(b, lblUsuario.Text, Maquina, lblSKU.Text,lblFolio.Text))
                        {
                            if ((b.Peso_Tapa < 15) && (b.Peso_emboltorio < 15))
                            {
                                if (b.PesoEscarpe >= (20))
                                {
                                    EnvioCorreo(b, lblUsuario.Text, txtobs.Text.ToString());
                                }

                                string popupScript4 = "<script language='JavaScript'>window.opener.location='Consumo_Dimensionadora.aspx?id=3&Cat=10&o=" + b.NumeroOp + "&c=" + b.pliego + "&f="+ lblFolio.Text+"&t="+lblCantidad.Text+"&n="+lblNombreOt.Text+"';window.close();</script>";
                                Page.RegisterStartupScript("PopupScript", popupScript4);
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

        public bool EnvioCorreo(Bobina b, string Usuario, string obs)
        {
            Bobina_Controller controlbo = new Bobina_Controller();
            /* Carga de PAra la base de Datos*/
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add("juan.venegas@qgchile.cl");
            mmsg.To.Add("info.escarpe@qgchile.cl");
            //mmsg.To.Add("mariamilagros.paez@qgchile.cl");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Exceso de escarpe en Bobina";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("juan.venegas@qgchile.cl"); //Opcional
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
                                "<img src='http://www.qg.com/images/qg_logocrop.gif' />" +
                                "<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
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
                       "</tr>" +
                             "</table>" +
                            "<br />" +
                            "</div>" +
                            "<table style='width:80%;'><tr>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Codigo Bob.</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>P. Bruto</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>P. Tapa</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>P. Env.</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>P. Esc.</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Marca</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Tipo</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Ancho</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Gr</td>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;'>Maquina</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.Codigo.ToString() + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.Peso_Original.ToString("N0").Replace(',', '.') + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.Peso_Tapa.ToString() + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.Peso_emboltorio.ToString() + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.PesoEscarpe.ToString() + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.Marca + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.Tipo + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.Ancho.ToString() + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.Gramage.ToString() + "</td>" +
                                    "<td style='border:1px solid #5D8CC9;'>" + b.Ubicacion + "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='border:1px solid #5D8CC9;background:#5D8CC9;' colspan='10'>Observación</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='border:1px solid #5D8CC9;' colspan='10'>Daño: " + Daño + "- Obs.:" + obs + "</td></tr></table>";

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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'>window.close();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void ddlSaldo_TextChanged(object sender, EventArgs e)
        {
            int seleccion = Convert.ToInt32(ddlSaldo.SelectedValue);
            if (seleccion == 2)
            {
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
                lblPesoFBobina.Visible = true;
                txtSaldo.Visible = true;
                lblKilos.Visible = true;
            }
        }

        protected void btnConsumir_Click(object sender, EventArgs e)
        {
            Bobina b = new Bobina();
            Bobina_Controller controlbo = new Bobina_Controller();
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
                        string popupScript4 = "<script language='JavaScript'>window.opener.location='Consumo_Dimensionadora.aspx?id=3&Cat=10&o=" + lblOT.Text + "&c=" + lblPliego.Text + "&f=" + lblFolio.Text + "&t=" + lblCantidad.Text + "&n=" + lblNombreOt.Text + "';window.close();</script>";
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
                    string popupScript4 = "<script language='JavaScript'>window.opener.location='Consumo_Dimensionadora.aspx?id=3&Cat=10&o=" + lblOT.Text + "&c=" + lblPliego.Text + "&f=" + lblFolio.Text + "&t=" + lblCantidad.Text + "&n=" + lblNombreOt.Text + "';window.close();</script>";
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

        public void CargarCieBob(Bobina b)
        {
            List<Bobina> lista = new List<Bobina>();
            lista.Add(b);
            RadGrid2.DataSource = lista;
            lbltapa.Text = b.Peso_Tapa.ToString();
            IDBobina.Text = b.ID_Bobina.ToString();
            lblEnvoltura.Text = b.Peso_emboltorio.ToString();
            lblEscarClose.Text = b.PesoEscarpe.ToString();
        }


        
    }
}