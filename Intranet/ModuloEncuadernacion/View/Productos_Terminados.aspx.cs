using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using Telerik.Web.UI;
using System.Drawing;
using Intranet.ModuloEncuadernacion.Model;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class Productos_Terminados : System.Web.UI.Page
    {
        Controller_ProductosTerminados cPT = new Controller_ProductosTerminados();
        Controller_Enc enc = new Controller_Enc();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtCantidad.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtEjemplares.Attributes.Add("onkeypress", "return solonumeros(event);");
            Button1.Attributes.Add("onclick", "window.open('infOperario.aspx','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=380,height=300,left=340,top=200')");
            if (!IsPostBack)
            {
                btnImprimir.Attributes.Add("onclick", "window.open('EtiquetaProductosTerminados.aspx?Cod=" + txtCodigo.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }

            //programacion usuario 
            Session["Usuario"] = Session["Usuario"].ToString();

            //string r = enc.infMaquinaBobina(Session["Usuario"].ToString());

            /*[cjerias_11/12/2018]  Comentado Unificacion despacho Impresion y ENC 
            string r = enc.infMaquinaBobina(Session["Usuario"].ToString());

            //valor = valor.AddDays(+1);
            DateTime hoy = DateTime.Now;
            if (r != "0")
            {
                DateTime valor = Convert.ToDateTime(r);
                TimeSpan a = hoy - valor;
                int b = a.Days;
                if (b > 0)
                {

                    string popupScript = "<script language='JavaScript'> onload(window.open('infOperario.aspx','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=380,height=300,left=340,top=200'));</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }

            }
            else
            {

                string popupScript = "<script language='JavaScript'> onload(window.open('infOperario.aspx','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=380,height=300,left=340,top=200'));</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            */
        }

        protected void btnBuscarPallet_Click(object sender, EventArgs e)
        {
            btnImprimir.Visible = false;

            List<Prod_Terminados> lisPT = new List<Prod_Terminados>();
            lisPT = cPT.BuscaPallet(txtCodigo.Text);
            RadGrid1.DataSource = cPT.BuscaPallet(txtCodigo.Text);
            RadGrid1.DataBind();

            if (lisPT.Count != 0)
            {
                pnlError.Visible = false;
                DivMensaje.Visible = false;
                lblCodigoGrid.Text = txtCodigo.Text;
            }
            else
            {
                DivMensaje.Visible = false;
                pnlError.Visible = true;
                //poner error qe no existe o fue cerrada
                DivError.Visible = true;
                imgError.ImageUrl = "../../Images/cross.png";
                lblError.Text = "El Pallet no ha sido encontrado o ya ha sido Cerrado.";
                lblError.ForeColor = Color.White;
                DivError.Attributes.Add("style", "background-color:Red");
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnImprimir.Visible = false;

            int var = cPT.CapturaCodigo2(Session["Usuario"].ToString(),0);

            if (var != null)
            {
                int nuevo = var;
                txtCodigo.Text = nuevo.ToString();
                lblCodigoGrid.Text = nuevo.ToString();
                DivError.Visible = false;
                CargarGrilla();
            }
        }

        protected void ddlTipoEmbalaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = ddlTipoEmbalaje.SelectedItem.Text;
            lblEjemplares.Text = "Ejemplares por " + tipo + ":";

            if (tipo == "Caja")
            {
                tipo = "Cajas";
            }
            lblCantidad.Text = "Cantidad " + tipo + ":";
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            calculo();
            txtEjemplares.Focus();
        }
        public void calculo()
        {
            int suma;
            int numero1;
            int numero2;
            if (txtCantidad.Text != "")
            {
                numero1 = Convert.ToInt32(txtCantidad.Text);
            }
            else
            {
                numero1 = 0;
            }

            if (txtEjemplares.Text != "")
            {

                numero2 = Convert.ToInt32(txtEjemplares.Text);
            }
            else
            {
                numero2 = 0;
            }
            suma = numero1 * numero2;

            txtTotal.Text = suma.ToString();
        }

        protected void txtEjemplares_TextChanged(object sender, EventArgs e)
        {
            calculo();
        }

        protected void txtOT_TextChanged(object sender, EventArgs e)
        {
            OrdenController controlOT = new OrdenController();
            Orden DatosOrden = controlOT.BuscarPorOT(txtOT.Text);

            if (DatosOrden.NombreOT != null)
            {

                txtNombreOT.Text = DatosOrden.NombreOT;
                pnlError.Visible = false;
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('La OT no ha sido encontrada, vuelva a Buscarla');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
               
               
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {



            if (txtCodigo.Text != "" && txtOT.Text != "" && ddlTipoEmbalaje.SelectedItem.Text != "Seleccione..." && txtCantidad.Text != "" && txtEjemplares.Text != "")
            {
                 int result = enc.busqIDOperario(Session["Usuario"].ToString());
                 if (result != 0)
                 {
                     bool resp = cPT.IngresarProTerminados(result, txtCodigo.Text, txtOT.Text, txtNombreOT.Text, ddlTerminacion.SelectedItem.Text, ddlTipoEmbalaje.SelectedItem.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtEjemplares.Text), Convert.ToInt32(txtTotal.Text),ddlModelo.SelectedItem.Text,txtObservacion.Text);

                     if (resp == true)
                     {
                         CargarGrilla();
                         DivMensaje.Visible = true;
                         imgMensaje.ImageUrl = "../../Images/tick.png";
                         lblMensaje.Text = "Producto Terminado Ingresado Correctamente al Pallet "+txtCodigo.Text+".";
                         lblMensaje.ForeColor = Color.White;
                         DivMensaje.Attributes.Add("style", "background-color:Green");
                         //mostrar mensaje correcto

                         lblcodigo.Text = txtCodigo.Text;
                             
                     }
                     else
                     {
                         DivMensaje.Visible = true;
                         imgMensaje.ImageUrl = "../../Images/cross.png";
                         lblMensaje.Text = "Ha Ocurrido un Error, vuelva a intentarlo.";
                         lblMensaje.ForeColor = Color.White;
                         DivMensaje.Attributes.Add("style", "background-color:Red");
                     }
                 }
                 else
                 {
                     string popupScript = "<script language='JavaScript'>alert('Debe Ingresar informacion de Operario.'); window.open('infOperario.aspx','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=380,height=300,left=340,top=200');</script>";
                     Page.RegisterStartupScript("PopupScript", popupScript);
                 }
            }
            else
            {
                lblCodigoGrid.Text = "ERROR campos vacios";
            }
        }
        public void CargarGrilla()
        {
            RadGrid1.DataSource = cPT.BuscaPallet(txtCodigo.Text);
            RadGrid1.DataBind();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtOT.Text = "";
            txtNombreOT.Text = "";
            ddlTerminacion.SelectedIndex = 0;
            ddlTipoEmbalaje.SelectedIndex = 0;
            txtCantidad.Text = "";
            txtEjemplares.Text = "";
            txtTotal.Text = "";
            DivMensaje.Visible = false;

            txtOT.Focus();
        }

        protected void btnCerrarPallet_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                List<Prod_Terminados> lisPT = new List<Prod_Terminados>();
                lisPT = cPT.BuscaPallet(txtCodigo.Text);
  
                if (lisPT.Count != 0)
                {
                    bool respuesta = cPT.CerrarPallet(txtCodigo.Text, Session["Usuario"].ToString());
                    if (respuesta == true)
                    {
                        DivMensaje.Visible = true;
                        imgMensaje.ImageUrl = "../../Images/tick.png";
                        lblCodAnterior.Text = txtCodigo.Text;
                        lblMensaje.Text = "El Pallet " + txtCodigo.Text + " ha sido Cerrado Correctamente.";
                        lblMensaje.ForeColor = Color.White;
                        DivMensaje.Attributes.Add("style", "background-color:Green");


                        if (cPT.CorreoPrimerDespacho(txtOT.Text, "cjerias", 0) == false)
                        {
                            bool rrr = cPT.CorreoPrimerDespacho(txtOT.Text.Trim(), "cjerias", 1);
                            generarCorreo(txtOT.Text, cPT.CargarPalletsCorreo(lblCodAnterior.Text.Trim(), txtOT.Text.Trim(), 2), txtNombreOT.Text);
                        }
                        //habilita impresion
                        btnImprimir.Attributes.Add("onclick", "window.open('EtiquetaProductosTerminados.aspx?Cod=" + txtCodigo.Text + ",'Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");
                        btnImprimir.Visible = true;

                        Recarga();
                    }
                    else
                    {
                        DivMensaje.Visible = true;
                        imgMensaje.ImageUrl = "../../Images/cross.png";
                        lblMensaje.Text = "Ha ocurrido un Error, vuelva a intentarlo.";
                        lblMensaje.ForeColor = Color.White;
                        DivMensaje.Attributes.Add("style", "background-color:Red");
                    }
                }
                else
                {
                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "Pallet Vacio, debe ingresar productos para cerrar un pallet.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Red");
                }
            }
        }
        public void Recarga()
        {
            txtCodigo.Text = "";
            txtOT.Text = "";
            txtNombreOT.Text = "";
            ddlTerminacion.SelectedIndex = 0;
            ddlTipoEmbalaje.SelectedIndex = 0;
            txtCantidad.Text = "";
            txtEjemplares.Text = "";
            txtTotal.Text = "";
            ddlModelo.SelectedIndex = 0;
            txtObservacion.Text = "";

            lblCodigoGrid.Text = "";

            RadGrid1.DataSource = "";
            RadGrid1.DataBind();
            }

        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "CustomEdit")
            {
                GridDataItem item = (GridDataItem)e.Item;

                string id = item["id_ProductosTerminados"].Text;

                bool r = cPT.EliminarPT(Convert.ToInt32(id));

                if (r == true)
                {
                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.Text = "Producto Terminado Eliminado Correctamente.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Green");

                    //cargamos grilla
                    CargarGrilla();
                }
                else
                {
                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "Ha ocurrido un error, vuelva a intentarlo.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Red");
                }


                //Response.Redirect("http://www.google.cl?id="+id);
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
           // Button1.Attributes.Add("onclick", "window.open('EtiquetaProductosTerminados.aspx?Cod=" + txtCodigo.Text + ",'Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");

           /* [cjerias_12/11/2018]
            * 
            * string popupScript = "<script language='JavaScript'> onload(window.open('EtiquetaProductosTerminados.aspx?Cod=" + lblcodigo.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);*/


            Session["Usuario"] = Session["Usuario"].ToString();
            string popupScript = "<script language='JavaScript'> onload(window.open('EtiquetaAprobadaPT.aspx?Cod=" + lblCodAnterior.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }
        /*[cjerias_14/11/2018 1129] Asignacion correo primeros ejemplares a despacho */

        public bool generarCorreo(string ot, string detalle, string nombreOT)
        {


            DetalleDespachos_Excel de = cPT.CorreosCSRVendedor(ot, "", 3);

            string CSR = de.NombreOT;
            string Vendedor = de.OT;
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje


               if (CSR != "")
               {
                   mmsg.To.Add(CSR);
               }
               if (Vendedor != "")
               {
                   mmsg.To.Add(Vendedor);
               }
            //mmsg.To.Add("carlos.jerias.r@aimpresores.cl");
            mmsg.Subject = ot.ToUpper() + " - Entrega primeros ejemplares a Despacho.";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("juan.venegas@aimpresores.cl"); //Opcional
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
                      "<br />Se ha generado la primera entrega de ejemplares a Despacho. OT: " + ot.ToUpper() + " - " + nombreOT +
                        "<br /><br />" +
                           detalle +
                           "<br /><br />" +
                    "Atentamente," +
                     "<br />" +
                    "Equipo de desarrollo A Impresores S.A" +
                "</td>" +
            "</tr>" +
            "</table>";

            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML
                                    //Correo electronico desde la que enviamos el menaje
            mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials =
                new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");
            cliente.Host = "mail.aimpresores.cl";
            try
            {

                cliente.Send(mmsg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }

        }



    }
    
}