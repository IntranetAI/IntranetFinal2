using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;
using System.Drawing;

namespace Intranet.Wip.View
{
    public partial class Control_Wip : System.Web.UI.Page
    {
        OrdenController orderControl = new OrdenController();
        Controller_WipControl wipControl = new Controller_WipControl();
        public static string IDControlPallet = "";
        public static int numero = 0;
        public static int ContadorPliegoMult = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IDControlPallet = "";
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            if (txtNumeroOT.Text != "")
            {
                string NumeroOT = txtNumeroOT.Text;
                Orden ot = orderControl.BuscarPorOT(NumeroOT);
                if (ot.NombreCliente != null)
                {
                    DivMensaje.Visible = false;
                    try
                    {
                        int metrics = Convert.ToInt32(NumeroOT.ToString().Trim());
                        Label24.Text = "* (Nombre Componente + n° pliego)";
                        Label25.Text = "* (Nombre Componente + n° pliego)";
                    }
                    catch
                    {
                        Label24.Text = "";
                        Label25.Text = "";
                    }
                    lblCliente.Text = ot.NombreCliente;
                    txtNombreOT.Text = ot.NombreOT;
                    int ejem = Convert.ToInt32(ot.Ejemplares);
                    txtTotal.Text = ejem.ToString("N0").Replace(',', '.');

                    List<Model_Wip_Control> lista = wipControl.ListPliegosOT(NumeroOT);
                    ddlPliego.DataSource = lista;
                    ddlPliego.DataTextField = "Pliego";
                    ddlPliego.DataValueField = "Pliego";
                    ddlPliego.DataBind();
                    ddlPliego.Items.Insert(0, new ListItem("Seleccione..."));

                    ddlPliego2.DataSource = lista;
                    ddlPliego2.DataTextField = "Pliego";
                    ddlPliego2.DataValueField = "Pliego";
                    ddlPliego2.DataBind();
                    ddlPliego2.Items.Insert(0, new ListItem("Seleccione..."));

                    List<Model_Wip_Control> lista2 = wipControl.ListPliegosOT2(NumeroOT);
                    ddlPlProg.DataSource = lista2;
                    ddlPlProg.DataTextField = "Prox_Proceso";
                    ddlPlProg.DataValueField = "Prox_Proceso";
                    ddlPlProg.DataBind();
                    ddlPlProg.Items.Insert(0, new ListItem("Seleccione..."));

                    ddlProgramado.DataSource = lista2;
                    ddlProgramado.DataTextField = "Prox_Proceso";
                    ddlProgramado.DataValueField = "Prox_Proceso";
                    ddlProgramado.DataBind();
                    ddlProgramado.Items.Insert(0, new ListItem("Seleccione..."));

                    pnlDatosOT.Visible = true;
                    pnlDatosMaquina.Visible = true;
                    pnlDatosPallet.Visible = false;
                    pnlDatosPallet2.Visible = false;
                }
                else
                {
                    DivMensaje.Visible = true;
                    DivMensaje.Attributes.Add("style", "background-color:Red");
                    lblMensaje.Text = "OT no encontrada. Vuelva a intentarlo";
                    lblMensaje.ForeColor = Color.White;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                }
            }
            else
            {
                DivMensaje.Visible = true;
                DivMensaje.Attributes.Add("style", "background-color:Red");
                lblMensaje.Text = "Debe ingresar una OT. Vuelva a intentarlo";
                lblMensaje.ForeColor = Color.White;
                imgMensaje.ImageUrl = "../../Images/cross.png";
            }

        }

        protected void Si_CheckedChanged(object sender, EventArgs e)
        {
            ddlMaquina.DataSource = wipControl.ListMaquinas("Rotativa");
            ddlMaquina.DataTextField = "OT";
            ddlMaquina.DataValueField = "OT";
            ddlMaquina.DataBind();
            ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));

            pnlDatosPallet.Visible = false;
            pnlDatosPallet2.Visible = false;
        }

        protected void rbNO_CheckedChanged(object sender, EventArgs e)
        {
            ddlMaquina.DataSource = wipControl.ListMaquinas("Planas");
            ddlMaquina.DataTextField = "OT";
            ddlMaquina.DataValueField = "OT";
            ddlMaquina.DataBind();
            ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
            
            pnlDatosPallet.Visible = false;
            pnlDatosPallet2.Visible = false;
            
        }

        protected void ddlPliego_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(pnlDatosPallet.Visible)
            {
                if ((ddlPliego.SelectedValue.ToString() != "Seleccione...")||(ddlProgramado.SelectedValue.ToString() != "Seleccione..."))
                {
                    lblCantidad.Visible = true;
                    txtCantidad.Visible = true;
                    ddlTipoPallet.Visible = true;
                    lblTirajePliego.Visible = true;
                    txtEjemplares.Visible = true;
                    lblRestantes.Visible = true;
                    Label17.Visible = true;
                    Label12.Visible = true;
                    lblEjemplares.Visible = true;
                    lblRes.Visible = true;
                    btnCerrarPallet.Visible = true;
                    string selected = "";
                    if (ddlProgramado.SelectedValue.ToString() != "Seleccione...")
                    {
                        selected = ddlProgramado.SelectedItem.ToString().Trim();
                    }
                    else
                    {
                        selected = ddlPliego.SelectedItem.ToString().Trim();
                    }
                    string NumeroOT = txtNumeroOT.Text;
                    List<Model_Wip_Control> lista = wipControl.ListPliegosOT(NumeroOT).Where(o => o.Pliego == selected).ToList();
                    int count = 0;
                    if (NumeroOT.Substring(0, 1).ToUpper() == "B")
                    {
                        foreach (Model_Wip_Control x in lista)
                        {
                            if (count == 0)
                            {
                                Label10.Visible = true;
                                Label11.Visible = true;
                                txtForma.Text = x.Forma;
                                txtTarea.Text = x.Tarea;
                                txtForma.Visible = true;
                                txtTarea.Visible = true;
                                count++;
                            }
                        }
                    }
                    else
                    {
                        Label10.Visible = false;
                        Label11.Visible = false;
                        txtForma.Visible = false;
                        txtTarea.Visible = false;
                    }
                    int tp = Convert.ToInt32(wipControl.BuscaPliegos(txtNumeroOT.Text, selected, 1));
                    int rs = Convert.ToInt32(wipControl.BuscaPliegos(txtNumeroOT.Text, selected, 2));
                    lblTirajePliego.Text = tp.ToString("N0").Replace(",", ".");
                    lblRestantes.Text = rs.ToString("N0").Replace(",", ".");


                    lblRestantes.Text = (tp - rs).ToString("N0").Replace(",", ".");
                    //calculo restante
                }
                else
                {
                    //Seleccione...
                    btnCerrarPallet.Visible = false;
                    Label17.Visible = false;
                    ddlTipoPallet.Visible = false;
                    Label12.Visible = false;
                    lblTirajePliego.Visible = false;
                    Label10.Visible = false;
                    Label11.Visible = false;
                    txtForma.Text = "";
                    txtTarea.Text = "";
                }
            }
            if (pnlDatosPallet2.Visible)
            {
                if ((ddlPliego2.SelectedValue.ToString() != "Seleccione...") || (ddlPlProg.SelectedValue.ToString() != "Seleccione..."))
                {
                    Label23.Visible = true;
                    txtCantidad2.Visible = true;
                    Label15.Visible = true;
                    Label14.Visible = true;
                    Label16.Visible = true;
                    Label18.Visible = true;
                    Label20.Visible = true;
                    ddlTipoPallet2.Visible = true;
                    txtEjemplares2.Visible = true;
                    Label21.Visible = true;
                    btnAgregar0.Visible = true;
                    btnCerrarPallet.Visible = true;
                    string selected = "";
                    if (ddlPlProg.SelectedValue.ToString() != "Seleccione...")
                    {
                        selected = ddlPlProg.SelectedItem.ToString().Trim();
                    }
                    else
                    {
                        selected = ddlPliego2.SelectedItem.ToString().Trim();
                    }
                    string NumeroOT = txtNumeroOT.Text;
                    List<Model_Wip_Control> lista = wipControl.ListPliegosOT(NumeroOT).Where(o => o.Pliego == selected).ToList();
                    int count = 0;
                    if (NumeroOT.Substring(0, 1).ToUpper() == "B")
                    {
                        foreach (Model_Wip_Control x in lista)
                        {
                            if (count == 0)
                            {
                                Label16.Visible = true;
                                Label18.Visible = true;
                                txtForma2.Text = x.Forma;
                                txtTarea2.Text = x.Tarea;
                                txtTarea2.Visible = true;
                                txtForma2.Visible = true;
                                count++;
                            }
                        }
                    }
                    else
                    {
                        Label16.Visible = false;
                        Label18.Visible = false;
                        txtForma2.Visible = false;
                        txtTarea2.Visible = false;
                    }

                    lblTirajePliego2.Text = wipControl.BuscaPliegos(txtNumeroOT.Text, selected, 1);
                    lblTirajePliego2.Visible = true;
                    lblRestantes2.Text = wipControl.BuscaPliegos(txtNumeroOT.Text, selected, 2);
                    lblRestantes2.Visible = true;

                    int tp = Convert.ToInt32(lblTirajePliego2.Text);
                    int rs = Convert.ToInt32(lblRestantes2.Text);

                    lblRestantes2.Text = (tp - rs).ToString("N0").Replace(",", ".");
                    //calculo restante
                }
                else
                {
                    //Seleccione...
                    Label15.Visible = false;
                    Label14.Visible = false;
                    Label16.Visible = false;
                    Label18.Visible = false;
                    Label20.Visible = false;
                    btnAgregar0.Visible = false;
                    btnCerrarPallet.Visible = false;
                    lblRestantes2.Visible = false;
                    lblTirajePliego2.Visible = false;
                    txtForma2.Text = "";
                    txtTarea2.Text = "";
                }
            }
        }

        protected void btnCerrarPallet_Click(object sender, EventArgs e)
        {
            if (pnlDatosPallet.Visible)
            {
                int tt = Convert.ToInt32(lblTirajePliego.Text.Replace(".", ""));
                int rst = Convert.ToInt32(lblRestantes.Text.Replace(".", ""));

                double max = tt * 1.5;

                if ((Convert.ToInt32(txtEjemplares.Text) > max) && lblTirajePliego.Text!="0")
                {
                    //error

                    DivMensaje.Visible = true;
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Los Pliegos Impresos no pueden ser superior al 50% de los Pliegos Restante.";
                }
                else
                {
                    DivMensaje.Visible = false;
                    Model_Wip_Control wip = new Model_Wip_Control();
                    int numero = wipControl.MaxRegistroWip() + 1;
                    string Codigo = "";
                    if (numero > 1)
                    {
                        if (ddlDestino.SelectedItem.Text == "Almacenamiento Wip")
                        {
                            Codigo = "WP-00000000";
                        }
                        if (ddlDestino.SelectedItem.Text == "Servicio Externo")
                        {
                            Codigo = "SE-00000000";
                        }
                        if (ddlDestino.SelectedItem.Text == "Directo a Encuadernacion")
                        {
                            Codigo = "DE-00000000";
                        }

                        wip.ID_Control = Codigo.Substring(0, Codigo.Length - numero.ToString().Length) + numero.ToString();
                        wip.OT = txtNumeroOT.Text.Trim();
                        wip.NombreOT = txtNombreOT.Text.Trim();
                        wip.Maquina = ddlMaquina.SelectedItem.ToString().Trim();
                        if (!cbxNPliegNew.Checked)
                        {
                            if (ddlProgramado.SelectedValue.ToString() != "Seleccione...")
                            {
                                wip.Pliego = ddlProgramado.SelectedItem.ToString().Trim();
                            }
                            else
                            {
                                wip.Pliego = ddlPliego.SelectedItem.ToString().Trim();
                            }
                        }
                        else
                        {
                            wip.Pliego = txtPliego_new.Text.Trim();
                        }
                        Double Ejemplares = Convert.ToDouble(txtTotal.Text.ToString().Replace('.', ','));

                        wip.TotalTiraje = Convert.ToInt32(Ejemplares);
                        if (txtCantidad.Text.Trim() != "")
                        {
                            wip.Peso_pallet = Convert.ToDouble(txtCantidad.Text);
                        }
                        if (txtEjemplares.Text.Trim() != "")
                        {
                            wip.Pliegos_Impresos = Convert.ToInt32(txtEjemplares.Text);
                        }
                        if (wip.OT.Substring(0, 1).ToUpper() == "B")
                        {
                            wip.Tarea = txtTarea.Text.Trim();
                            wip.Forma = txtForma.Text.Trim();
                        }
                        wip.Usuario = Session["Usuario"].ToString();
                        wip.Ubicacion = ddlDestino.SelectedItem.ToString();
                        wip.IDTipoPallet = Convert.ToInt32(ddlTipoPallet.SelectedValue);
                        wip.TipoPallet = ddlTipoPallet.SelectedItem.ToString();
                        if (wipControl.Agregar_Pallet_Wip(wip, ""))
                        {
                            if (ddlProgramado.SelectedValue.ToString() == "Seleccione...")
                            {
                                //EnvioCorreo(wip);
                            }
                            lblError.Visible = false;
                            lblError.Text = wip.ID_Control;
                            btnImprimir.Visible = true;
                            btnCerrarPallet.Visible = false;
                        }
                    }
                }
            }
            if (pnlDatosPallet2.Visible)
            {
                DivMensaje.Visible = false;
                ContadorPliegoMult = 0;
                lblError.Visible = false;
                lblError.Text = IDControlPallet;
                btnImprimir.Visible = true;
                btnCerrarPallet.Visible = false;
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            ContadorPliegoMult = 0;
            Button1.Visible = true;
            if (pnlDatosPallet.Visible)
            {
                ddlProgramado.SelectedIndex = 0;
                ddlPliego.SelectedIndex = 0;
                ddlTipoPallet.Visible = false;
                lblTirajePliego.Visible = false;
                txtForma.Visible = false;
                txtTarea.Visible = false;
                txtEjemplares.Visible = false;
                lblRestantes.Visible = false;
                Label17.Visible = false;
                Label12.Visible = false;
                Label11.Visible = false;
                Label10.Visible = false;
                lblEjemplares.Visible = false;
                lblRes.Visible = false;
                lblCantidad.Visible = false;
                txtCantidad.Visible = false;

                string popupScript = "<script language='JavaScript'> onload(window.open('Etiqueta_Wip.aspx?cd=" + lblError.Text + "','Imprimir Etiqueta Wip','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=750,height=700,left=340,top=200'));</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            if (pnlDatosPallet2.Visible)
            {
                string popupScript = "<script language='JavaScript'> onload(window.open('Etiqueta_Wip2.aspx?cd=" + lblError.Text + "','Imprimir Etiqueta Wip','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=750,height=700,left=340,top=200'));</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Control_Wip.aspx?id=8&cat=5");
        }

        protected void ddlMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMaquina.SelectedValue.ToString() != "Seleccione...")
            {
                if (cbxPliegoMult.Checked)
                {
                    pnlDatosPallet2.Visible = true;
                    pnlDatosPallet.Visible = false;
                }
                else
                {
                    pnlDatosPallet.Visible = true;
                    pnlDatosPallet2.Visible = false;
                }
            }
            else
            {
                pnlDatosPallet.Visible = false;
                pnlDatosPallet2.Visible = false;
            }
        }

        protected void cbxPliegoMult_CheckedChanged(object sender, EventArgs e)
        {
            if (ddlMaquina.SelectedValue.ToString() != "Seleccione..." && ddlMaquina.SelectedValue.ToString() != "")
            {
                if (cbxPliegoMult.Checked)
                {
                    pnlDatosPallet.Visible = true;
                    pnlDatosPallet2.Visible = false;
                }
                else
                {
                    pnlDatosPallet2.Visible = true;
                    pnlDatosPallet.Visible = false;
                }
            }
        }

        protected void btnAgregar0_Click(object sender, EventArgs e)
        {
            if (pnlDatosPallet2.Visible)
            {
                int tt = Convert.ToInt32(lblTirajePliego2.Text.Replace(".", ""));
                int rst = Convert.ToInt32(lblRestantes2.Text.Replace(".", ""));

                double max = tt * 1.5;

                if ((Convert.ToInt32(txtEjemplares2.Text) > max)&&(lblTirajePliego2.Text!="0"))
                {
                    //error

                    DivMensaje.Visible = true;
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Los Pliegos Impresos no pueden ser superior al 50% de los Pliegos Restante.";
                }
                else
                {
                    Model_Wip_Control wip = new Model_Wip_Control();

                    string Codigo = "";
                    if (ContadorPliegoMult == 0)
                    {
                        numero = wipControl.MaxRegistroWip();
                        numero = numero + 1;
                        ContadorPliegoMult++;
                    }
                    if (ddlDestino.SelectedItem.Text == "Almacenamiento Wip")
                    {
                        Codigo = "WP-00000000";
                    }
                    if (ddlDestino.SelectedItem.Text == "Servicio Externo")
                    {
                        Codigo = "SE-00000000";
                    }
                    if (ddlDestino.SelectedItem.Text == "Directo a Encuadernacion")
                    {
                        Codigo = "DE-00000000";
                    }


                    wip.ID_Control = Codigo.Substring(0, Codigo.Length - numero.ToString().Length) + numero.ToString();
                    IDControlPallet = wip.ID_Control;
                    wip.OT = txtNumeroOT.Text.Trim();
                    wip.NombreOT = txtNombreOT.Text.Trim();
                    if (!cbxNPliegNew1.Checked)
                    {
                        if (ddlPlProg.SelectedValue.ToString() != "Seleccione...")
                        {
                            wip.Pliego = ddlPlProg.SelectedItem.Text.Trim();
                        }
                        else
                        {
                            wip.Pliego = ddlPliego2.SelectedItem.Text.Trim();
                        }
                    }
                    else
                    {
                        wip.Pliego = txtPliego_new1.Text.Trim();
                    }
                    wip.Tarea = txtTarea2.Text.Trim();
                    wip.Forma = txtForma2.Text.Trim();
                    wip.Pliegos_Impresos = Convert.ToInt32(txtEjemplares2.Text.Trim());
                    wip.Maquina = ddlMaquina.SelectedItem.Text.Trim();
                    wip.TotalTiraje = Convert.ToInt32(lblTirajePliego2.Text.Trim());
                    wip.Usuario = Session["Usuario"].ToString().Trim();
                    wip.Ubicacion = ddlDestino.SelectedItem.Text.Trim();
                    wip.Peso_pallet = Convert.ToDouble(txtCantidad2.Text);
                    wip.IDTipoPallet = Convert.ToInt32(ddlTipoPallet2.SelectedValue.ToString());
                    wip.TipoPallet = ddlTipoPallet2.SelectedItem.ToString();
                    if (wipControl.Agregar_Pallet_Wip(wip,""))
                    {
                        Label23.Visible = false;
                        txtCantidad2.Visible = false;
                        lblError.Visible = false;
                        lblError.Text = wip.ID_Control;
                        btnImprimir.Visible = false;
                        btnCerrarPallet.Visible = true;
                        ddlPliego2.SelectedIndex = 0;
                        Label15.Visible = false;
                        Label14.Visible = false;
                        Label16.Visible = false;
                        Label18.Visible = false;
                        Label20.Visible = false;
                        Label16.Visible = false;
                        Label18.Visible = false;
                        txtForma2.Visible = false;
                        txtTarea2.Visible = false;
                        ddlTipoPallet2.Visible = false;
                        txtEjemplares2.Visible = false;
                        lblRestantes2.Visible = false;
                        lblTirajePliego2.Visible = false;
                        Label21.Visible = false;
                        btnAgregar0.Visible = false;
                        DivMensaje.Visible = false;
                    }
                    RadGridOT.DataSource = wipControl.List_PliegosMultiples(wip.ID_Control);
                    RadGridOT.DataBind();
                }
            }
        }

        protected void cbxNPliegNew1_CheckedChanged(object sender, EventArgs e)
        {
            if ((ddlPliego2.SelectedItem.ToString() != "Seleccione...") || (ddlPlProg.SelectedItem.ToString() != "Seleccione..."))
            {
                if (cbxNPliegNew1.Checked)
                {
                    lblNew_Pliego1.Visible = true;
                    txtPliego_new1.Visible = true;
                }
                else
                {
                    lblNew_Pliego1.Visible = false;
                    txtPliego_new1.Visible = false;
                }
            }
        }

        protected void cbxNPliegNew_CheckedChanged(object sender, EventArgs e)
        {
            if ((ddlPliego.SelectedItem.ToString() != "Seleccione...") || (ddlProgramado.SelectedItem.ToString() != "Seleccione..."))
            {
                if (cbxNPliegNew.Checked)
                {
                    lblNew_Pliego.Visible = true;
                    txtPliego_new.Visible = true;
                }
                else
                {
                    lblNew_Pliego.Visible = false;
                    txtPliego_new.Visible = false;
                }
            }
        }

        public void LimpiarForm()
        {
            cbxPliegoMult.Checked = false;
            rbNO.Checked = false;
            rbSi.Checked = false;
            if (ddlDestino.Items.Count > 0)
            {
                ddlDestino.SelectedValue = "1";
                ddlDestino.DataBind();
            }
            if (ddlMaquina.Items.Count > 0)
            {
                ddlMaquina.DataSource = "";
                ddlMaquina.DataBind();
            }
            if (ddlPliego.Items.Count > 0)
            {
                ddlPliego.DataSource = "";
                ddlPliego.DataBind();
            }
            if (ddlPliego2.Items.Count > 0)
            {
                ddlPliego2.DataSource = "";
                ddlPliego2.DataBind();
            }
            if (ddlProgramado.Items.Count > 0)
            {
                ddlProgramado.DataSource = "";
                ddlProgramado.DataBind();
            }
            if (ddlPlProg.Items.Count > 0)
            {
                ddlPlProg.DataSource = "";
                ddlPlProg.DataBind();
            }
            lblNew_Pliego.Visible = false;
            txtPliego_new.Text = "";
            txtPliego_new.Visible = false;
            cbxNPliegNew.Checked = false;
            lblNew_Pliego1.Visible = false;
            txtPliego_new1.Text = "";
            txtPliego_new1.Visible = false;
            cbxNPliegNew1.Checked = false;
            txtEjemplares.Text = "";
            txtEjemplares2.Text = "";

        }

        //public bool EnvioCorreo(Model_Wip_Control wip)
        //{
        //    /* Carga de PAra la base de Datos*/
        //    /*-------------------------MENSAJE DE CORREO----------------------*/

        //    //Creamos un nuevo Objeto de mensaje
        //    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

        //    //Direccion de correo electronico a la que queremos enviar el mensaje
        //    //mmsg.To.Add("juan.venegas@aimpresores.cl");
        //    mmsg.To.Add("luis.rojas@aimpresores.cl");
        //    mmsg.To.Add("telye.yurisch@aimpresores.cl");
        //    //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

        //    //Asunto
        //    mmsg.Subject = "Pliego no Programado";
        //    mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

        //    //Direccion de correo electronico que queremos que reciba una copia del mensaje
        //    //mmsg.Bcc.Add("juan.venegas@aimpresores.cl"); //Opcional
        //    DateTime hoy = DateTime.Now;
        //    string fecha = hoy.ToString("dd/MM/yyyy HH:mm");
        //    string[] str = fecha.Split('/');
        //    string dia = str[0];
        //    string mes = str[1];
        //    string año = str[2];
        //    //año = año.Substring(0, 4);
        //    //string hora = hoy.ToLongTimeString();

        //    //Cuerpo del Mensaje
        //    mmsg.Body =
        //                "<table style='width:80%;'>" +
        //                "<tr>" +
        //                    "<td>" +
        //                        "<img src='http://intranet.qgchile.cl/images/Logo color lateral.jpg' width='267px'  height='67px' />" +
        //                        //"<img src='http://www.qg.com/la/es/images/QG_Tagline_sp.jpg' />" +
        //                        "&nbsp;</td>" +
        //                "</tr>" +
        //                "</table>" +
        //        //termino cargar logo
        //                    "<div style='border-color:Black;border-width:3px;border-style:solid;'>" +
        //            "<table>" +
        //               "<tr>" +
        //                    "<td style='width:194px;'>" +
        //                        "&nbsp;</td>" +
        //                    "<td colspan='7'>" +
        //                        "&nbsp;</td>" +
        //                "</tr>" +
        //                "<tr>" +
        //                    "<td  style='width:194px;'>OT Nro.: </td>" +
        //                    "<td>" + wip.OT + "</td>" +
        //                    "<td style='width:194px;'>Nombre OT : </td>" +
        //                    "<td>"+ wip.NombreOT +"</td>"+
        //                    "<td style='width:194px;'>Pliego : </td>" +
        //                    "<td>"+wip.Pliego+"</td>"+
        //                    "<td style='width:194px;'>" +
        //                      " Fecha:</td>" +
        //                    "<td colspan='3'>" + dia + "/" + mes + "/" + año + "</td>" +
        //                "</tr>" +
        //                     "</table>" +
        //                    "<br />" +
        //                    "</div>Atentamente Sistema Intranet";

        //    mmsg.BodyEncoding = System.Text.Encoding.UTF8;
        //    mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

        //    //Correo electronico desde la que enviamos el mensaje
        //    mmsg.From = new System.Net.Mail.MailAddress("sistema.intranet@aimpresores.cl");//"fecha.produccion@aimpresores.cl");


        //    /*-------------------------CLIENTE DE CORREO----------------------*/

        //    //Creamos un objeto de cliente de correo
        //    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

        //    //Hay que crear las credenciales del correo emisor
        //    cliente.Credentials =
        //        new System.Net.NetworkCredential("sistema.intranet@aimpresores.cl", "SI2013.");

        //    //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
        //    /*
        //    cliente.Port = 587;
        //    cliente.EnableSsl = true;
        //    */
        //    cliente.Host = "mail.aimpresores.cl";
        //    /*-------------------------ENVIO DE CORREO----------------------*/

        //    try
        //    {
        //        //Enviamos el mensaje      
        //        cliente.Send(mmsg);
        //        return true;
        //        //Label1.Text = "enviado correctamente";
        //    }
        //    catch (System.Net.Mail.SmtpException ex)
        //    {
        //        return false;
        //        //Aquí gestionamos los errores al intentar enviar el correo
        //        //Label1.Text = "error al enviar el correo";
        //    }
        //}
    }
}