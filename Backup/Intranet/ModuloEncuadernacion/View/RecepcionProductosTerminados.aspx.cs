using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using System.Drawing;
using Telerik.Web.UI;
using Intranet.ModuloEncuadernacion.Model;
using System.Text;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class RecepcionProductosTerminados : System.Web.UI.Page
    {
        Controller_ProductosTerminados cPT = new Controller_ProductosTerminados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                txtCodigo.Focus();
            }
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            List<Prod_Terminados> lisPT = new List<Prod_Terminados>();
            lisPT = cPT.BuscaPalletRecepcion(txtCodigo.Text);

            RadGrid1.DataSource = cPT.BuscaPalletRecepcion(txtCodigo.Text);
            RadGrid1.DataBind();

            if (lisPT.Count != 0)
            {

                DivMensaje.Visible = false;

            }
            else
            {
                //poner error qe no existe o fue cerrada
                DivMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "El Pallet no ha sido encontrado.";
                lblMensaje.ForeColor = Color.White;
                DivMensaje.Attributes.Add("style", "background-color:Red");
            }
        }

        protected void ibAprobar_Click1(object sender, ImageClickEventArgs e)
        {
            int contadorInsert = 0;
            List<Prod_Terminados> list = new List<Prod_Terminados>();
            StringBuilder str = new StringBuilder();
            bool resp=false;
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem row = RadGrid1.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {
                    contadorInsert++;
                    //Prod_Terminados asi = new Prod_Terminados();
                    //asi.id_ProductosTerminados = row["id_ProductosTerminados"].Text;
                    //asi.Estado = "7";
                    //bool resp = cPT.CambiarEstado(Convert.ToInt32(asi.id_ProductosTerminados), asi.Estado);
                    //list.Add(asi);
                    if (cPT.CorreoPrimerDespacho(row["OT"].Text.Trim(), "cjerias", 0) == false)
                    {   //generar correo
                        bool rrr = cPT.CorreoPrimerDespacho(row["OT"].Text.Trim(), "cjerias", 1);
                        generarCorreo(row["OT"].Text.Trim(), cPT.CargarPalletsCorreo(txtCodigo.Text.Trim(), row["OT"].Text.Trim(), 2), row["NombreOT"].Text);
                    }
                    resp = cPT.CerrarPaso3(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 8);
                }
            }
            //contador
            //string contadorIns = contadorInsert.ToString();
            ////llamada procedimiento

            ////carga de gridviews

            //RadGrid1.DataSource = cPT.BuscaPalletRecepcion(txtCodigo.Text);
            //RadGrid1.DataBind();
            ////mensaje 
            string popupScript = "<script language='JavaScript'>location.href='RecepcionProductosTerminados.aspx?id=8&Cat=6' </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void ibRechazar_Click(object sender, ImageClickEventArgs e)
        {
            int contadorInsert = 0;
            List<Prod_Terminados> list = new List<Prod_Terminados>();
            StringBuilder str = new StringBuilder();
            bool resp = true;
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem row = RadGrid1.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {
                    contadorInsert++;
                    //Prod_Terminados asi = new Prod_Terminados();
                    //asi.id_ProductosTerminados = row["id_ProductosTerminados"].Text;
                    //asi.Estado = "6";
                    //bool resp = cPT.CambiarEstado(Convert.ToInt32(asi.id_ProductosTerminados), asi.Estado);
                    //list.Add(asi);
                    if (cPT.CorreoPrimerDespacho(row["OT"].Text.Trim(), "cjerias", 0) == false)
                    {   //generar correo
                        bool rrr = cPT.CorreoPrimerDespacho(row["OT"].Text.Trim(), "cjerias", 1);
                        generarCorreo(row["OT"].Text.Trim(), cPT.CargarPalletsCorreo(txtCodigo.Text.Trim(), row["OT"].Text.Trim(), 2), row["NombreOT"].Text);
                    }
                    resp = cPT.CerrarPaso3(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 7);
                }
            }
            //contador
            //string contadorIns = contadorInsert.ToString();
            ////llamada procedimiento

            ////carga de gridviews

            //RadGrid1.DataSource = cPT.BuscaPalletRecepcion(txtCodigo.Text);
            //RadGrid1.DataBind();
            string popupScript = "<script language='JavaScript'>location.href='RecepcionProductosTerminados.aspx?id=8&Cat=6' </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            //if (e.CommandName == "CustomEdit")
            //{
            //    GridDataItem item = (GridDataItem)e.Item;

            //    //Session["nOT"] = item["NumeroOT"].Text;
            //    //string emp = item["NombreOT"].Text;

            //    string popupScript = "<script language='JavaScript'> onload(window.open('ModificarProductosTerminados.aspx?Cod=" + txtCodigo.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
            //    Page.RegisterStartupScript("PopupScript", popupScript);
            //}
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            List<Prod_Terminados> list = new List<Prod_Terminados>();
            Prod_Terminados asi = new Prod_Terminados();

            int contadorMala = 0;
            if (txtCodigo.Text != "")
            {
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    GridDataItem row = RadGrid1.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    //if (isChecked)
                    //{

                    bool resp;
                    string id = row["id_ProductosTerminados"].Text;

                    string estado = row["Estado"].Text;

                    if (estado == "<div style='Color:Green;'>Aprobado</div>")
                    {

                        //cambiar a estado 4
                        // resp = cPT.CerrarPaso3(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 8);



                        //hacer la diferencia y generar correo

                        if (cPT.CorreoPrimerDespacho(row["OT"].Text.Trim(), "cjerias", 0) == false)
                        {
                            //generar correo

                            bool rrr = cPT.CorreoPrimerDespacho(row["OT"].Text.Trim(), "cjerias", 1);

                            generarCorreo(row["OT"].Text.Trim(), cPT.CargarPalletsCorreo(txtCodigo.Text.Trim(), row["OT"].Text.Trim(), 2), row["NombreOT"].Text);
                        }
                          






                    }
                    else if (estado == "<div style='Color:Blue;'>Pendiente</div>")
                    {

                        contadorMala = contadorMala + 1;

                        //cambia a estado 5
                        // resp = cPT.CerrarPaso3(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 6);
                    }
                    else if (estado == "<div style='Color:Red;'>Rechazado</div>")
                    {
                        // contadorMala = contadorMala + 1;
                        //cambia a estado 5
                        // resp = cPT.CerrarPaso3(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 6);
                    }


                    //}

                }

                if (contadorMala == 0)
                {
                    for (int i = 0; i < RadGrid1.Items.Count; i++)
                    {
                        GridDataItem row = RadGrid1.Items[i];
                        bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                        //if (isChecked)
                        //{

                        bool resp;
                        string id = row["id_ProductosTerminados"].Text;

                        string estado = row["Estado"].Text;

                        if (estado == "<div style='Color:Green;'>Aprobado</div>")
                        {

                            //cambiar a estado 4
                            resp = cPT.CerrarPaso3(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 8);
                        }
                        else if (estado == "<div style='Color:Blue;'>Pendiente</div>")
                        {

                            contadorMala = contadorMala + 1;

                            //cambia a estado 5
                            resp = cPT.CerrarPaso3(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 6);
                        }
                        else if (estado == "<div style='Color:Red;'>Rechazado</div>")
                        {
                            // contadorMala = contadorMala + 1;
                            //cambia a estado 5
                            resp = cPT.CerrarPaso3(Convert.ToInt32(row["id_ProductosTerminados"].Text), Session["Usuario"].ToString(), 6);
                        }


                        //}

                    }

                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.Text = "Registros Guardados Correctamente.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Green");
                    //cg
                    RadGrid1.DataSource = cPT.BuscaPalletCerrado(txtCodigo.Text);
                    RadGrid1.DataBind();

                    txtCodigo.Text = "";
                }
                else
                {

                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "Debe Asignar Estado a las Guias!";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Red");
                    //cg
                    RadGrid1.DataSource = cPT.BuscaPalletRecepcion(txtCodigo.Text);
                    RadGrid1.DataBind();
                }

            }
            else
            {
                //mal
            }
        }


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




                //mmsg.To.Add("claudio.valle@aimpresores.cl");
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
        protected void btnImprimir_Click(object sender, EventArgs e)
        {


        }
    }
}