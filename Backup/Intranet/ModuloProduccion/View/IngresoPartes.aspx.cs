using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using System.Web.Services;

namespace Intranet.ModuloProduccion.View
{ 
    public partial class IngresoPartes : System.Web.UI.Page
    {
        int count = 0;
        Controller_IngresoPartes ip = new Controller_IngresoPartes();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtHora.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtCodigo.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtOT.Attributes.Add("onkeypress", "return solonumeros(event);");
            //txtPliego.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtMinuto.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtBuenos.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtMalos.Attributes.Add("onkeypress", "return solonumeros(event);");
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                try
                {
                    if (Request.QueryString["r"] == "modificar")
                    {
                        string id = Request.QueryString["idP"];
                        string estado = Request.QueryString["Est"];

                        PartesIngreso p = ip.Carga_Modifica(id, Convert.ToInt32(estado));

                        RadGrid1.DataSource = ip.Lista_DetalleModi(Session["Usuario"].ToString(), 2);
                        RadGrid1.DataBind();

                        string popupScript = "<script language='JavaScript'> alert(' modificar ');</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    else if (Request.QueryString["r"] == "eliminar")
                    {
                        string id = Request.QueryString["idP"];
                        string estado = Request.QueryString["Est"];
                        btnFiltro.Visible = true;
                        btnModificar.Visible = false;
                        bool a = ip.Eliminarregistro(id, 1);
                        RadGrid1.DataSource = ip.Lista_DetalleModi(Session["Usuario"].ToString(), 2);
                        RadGrid1.DataBind();
                        string popupScript = "<script language='JavaScript'> alert('Registro Eliminado Correctamente');</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    else
                    {
                        btnFiltro.Visible = true;
                        btnModificar.Visible = false;
                        ip.EliminaPendientes(Session["Usuario"].ToString());
                    }
                }
                catch
                {
                    btnFiltro.Visible = true;
                    btnModificar.Visible = false;
                    ip.EliminaPendientes(Session["Usuario"].ToString());
                }
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (ddlMaquina.SelectedValue.ToString() != "Seleccione..." && txtFechaParte.Text != "" && txtCodigo.Text != "" &&   txtOT.Text != ""
                &&  txtHora.Text != "" && txtMinuto.Text != "" && txtBuenos.Text != "" && txtMalos.Text != "" && txtPliego.Text!="")
            {


                PartesIngreso p = new PartesIngreso();
                string[] str = txtFechaParte.Text.Split('/');
                p.FechaInicio = str[1] + "/" + str[0] + "/" + str[2] + " " + txtHora.Text + ":" + txtMinuto.Text + ":00";
                if (RadGrid1.Items.Count > 0)
                {
                    ip.FechaAnterior(Session["Usuario"].ToString(), Convert.ToDateTime(p.FechaInicio));
                    //  p.FechaTermino = Convert.ToDateTime(ip.FechaAnterior(Session["Usuario"].ToString(), 2)).ToString("MM/dd/yyyy HH:mm:ss");
                }

                p.FechaTermino = "1900-01-01";



                #region Variables inserT
                p.Count = count.ToString();
                p.Maquina = ddlMaquina.SelectedValue.ToString();
                if (rdTurno.Checked == true)
                {
                    p.Turno = rdTurno.Text;
                }
                else if (rdTurno2.Checked == true)
                {
                    p.Turno = rdTurno2.Text;
                }
                else
                {
                    p.Turno = rdTurno3.Text;
                }
                p.Codigo = txtCodigo.Text;
                p.OT = txtOT.Text;
                p.NombreOT = "";

                p.FechaParte = str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00";

                p.Buenos = txtBuenos.Text;
                p.Malos = txtMalos.Text;
                p.Usuario = Session["Usuario"].ToString();
                p.Pliego = txtPliego.Text;
                p.Factor = txtFactor.Text;
                #endregion
                if (ddlMaquina.SelectedValue.ToString() == "C150")
                {
                    if (txtFactor.Text != "")
                    {
                        if (ip.IngresarDetalleParte(p, 0) == 0)
                        {
                            btnFiltro.Text = "ERROR";
                        }
                        else
                        {
                            RadGrid1.DataSource = ip.Lista_Detalle(p, 1);
                            RadGrid1.DataBind();
                        }

                        Limpiar();
                        txtCodigo.Focus();
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert(' Debe ingresar el Factor ');</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                else
                {
                    if (ip.IngresarDetalleParte(p, 0) == 0)
                    {
                        btnFiltro.Text = "ERROR";

                    }
                    else
                    {
                        RadGrid1.DataSource = ip.Lista_Detalle(p, 1);
                        RadGrid1.DataBind();
                    }
                    Limpiar();
                    txtCodigo.Focus();
                    //string popupScript = "<script language='JavaScript'> alert(' Debe ingresar el Factor ');</script>";
                    //Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert(' Debe ingresar todos los campos ');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //lblCodigo.Text = ip.Carga_CodigoParte(txtCodigo.Text);

            //txtOT.Focus();
            //Calcular1raFecha();
        }

        protected void txtOT_TextChanged(object sender, EventArgs e)
        {
            lblNombreOT.Text = ip.Carga_NombreOT(txtOT.Text);

            txtPliego.Focus();
            Calcular1raFecha();
        }
        public void Limpiar()
        {
            txtCodigo.Text = "";
            lblCodigo.Text = "";
           //txtOT.Text = "";
           //lblNombreOT.Text = "";
            txtHora.Text = "";
            txtMinuto.Text = "";
            txtMalos.Text = "";
            txtBuenos.Text = "";
        }

        public void Calcular1raFecha() 
        {
            if (RadGrid1.Items.Count == 0)
            {
                string[] str23 = txtFechaParte.Text.Split('/');
                // str[1] + "/" + str[0] + "/" + str[2] + " " + txtHora.Text + ":" + txtMinuto.Text + ":00";
                if (Convert.ToDateTime(str23[1] + "/" + str23[0] + "/" + str23[2]).DayOfWeek.ToString() == "Monday")
                {
                    if (rdTurno.Checked)
                    {
                        txtHora.Text = "09";
                        txtMinuto.Text = "00";
                    }
                    else if (rdTurno2.Checked)
                    {
                        txtHora.Text = "14";
                        txtMinuto.Text = "00";
                    }
                    else
                    {
                        txtHora.Text = "19";
                        txtMinuto.Text = "00";
                    }
                }
                else
                {
                    if (rdTurno.Checked)
                    {
                        txtHora.Text = "00";
                        txtMinuto.Text = "00";
                    }
                    else if (rdTurno2.Checked)
                    {
                        txtHora.Text = "08";
                        txtMinuto.Text = "00";
                    }
                    else
                    {
                        txtHora.Text = "16";
                        txtMinuto.Text = "00";
                    }
                }
            }
        }

        protected void txtHora_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtHora.Text) > 23)
                {
                    txtHora.Text = "23";
                }
            }
            catch
            {
                txtHora.Text = "00";
            }
            txtMinuto.Focus();
        }
        

        protected void txtMinuto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtMinuto.Text) > 59)
                {
                    txtMinuto.Text = "59";
                }
            }
            catch
            {
                txtMinuto.Text = "0";
            }
            txtBuenos.Focus();
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            string fec = "";
            string fecha = "";
            if (RadGrid1.Items.Count > 0)
            {
                string[] str23 = txtFechaParte.Text.Split('/');
               // str[1] + "/" + str[0] + "/" + str[2] + " " + txtHora.Text + ":" + txtMinuto.Text + ":00";
                if (Convert.ToDateTime(str23[1] + "/" + str23[0] + "/" + str23[2]).DayOfWeek.ToString() == "Monday")
                {
                    if (rdTurno.Checked)
                    {
                        fec = "14:00:00";
                    }
                    else if (rdTurno2.Checked)
                    {
                        fec = "19:00:00";
                    }
                    else
                    {
                        fec = "23:59:59";
                    }
                    string[] str = txtFechaParte.Text.Split('/');
                    fecha = str[1] + "/" + str[0] + "/" + str[2] + " " + fec;

                    ip.FechaAnterior(Session["Usuario"].ToString(), Convert.ToDateTime(fecha));
                    bool a = ip.CambiaEstado(Session["Usuario"].ToString());
                    if (a == true)
                    {
                        string popupScript = "<script language='JavaScript'> alert(' Parte Ingresado Correctamente ');location.href='IngresoPartes.aspx?id=1' </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                else
                {

                    if (rdTurno.Checked)
                    {
                        fec = "08:00:00";
                    }
                    else if (rdTurno2.Checked)
                    {
                        fec = "16:00:00";
                    }
                    else
                    {
                        fec = "23:59:59";
                    }
                    string[] str = txtFechaParte.Text.Split('/');
                    fecha = str[1] + "/" + str[0] + "/" + str[2] + " " + fec;

                    ip.FechaAnterior(Session["Usuario"].ToString(), Convert.ToDateTime(fecha));
                    bool a = ip.CambiaEstado(Session["Usuario"].ToString());
                    if (a == true)
                    {
                        string popupScript = "<script language='JavaScript'> alert(' Parte Ingresado Correctamente ');location.href='IngresoPartes.aspx?id=1' </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
            }
        }

        protected void ddlMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMaquina.SelectedValue.ToString() == "C150" || ddlMaquina.SelectedValue.ToString() == "Lithoman")
            {
                lblFactor.Visible = true;
                txtFactor.Visible = true;
            }
            else
            {
                lblFactor.Visible = false;
                txtFactor.Visible = false;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ddlMaquina.SelectedValue.ToString() != "Seleccione..." && txtFechaParte.Text != "" && txtCodigo.Text != "" && lblCodigo.Text != "" && txtOT.Text != ""
    && lblNombreOT.Text != "" && txtHora.Text != "" && txtMinuto.Text != "" && txtBuenos.Text != "" && txtMalos.Text != "" && txtPliego.Text != "")
            {
                PartesIngreso p = new PartesIngreso();
                string[] str = txtFechaParte.Text.Split('/');
                p.FechaInicio = str[1] + "/" + str[0] + "/" + str[2] + " " + txtHora.Text + ":" + txtMinuto.Text + ":00";
                p.idParte = Request.QueryString["idP"];
                p.Maquina = ddlMaquina.SelectedValue.ToString();
                if (rdTurno.Checked == true)
                {
                    p.Turno = rdTurno.Text;
                }
                else if (rdTurno.Checked == true)
                {
                    p.Turno = rdTurno2.Text;
                }
                else
                {
                    p.Turno = rdTurno3.Text;
                }
                p.Codigo = txtCodigo.Text;
                p.OT = txtOT.Text;


                p.FechaParte = str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00";

                p.Buenos = txtBuenos.Text;
                p.Malos = txtMalos.Text;
                p.Pliego = txtPliego.Text;
                p.Factor = txtFactor.Text;

                bool a = ip.ModificarRegistros(p);
                if (a == true)
                {
                    btnFiltro.Visible = true;
                    btnModificar.Visible = false;
                    RadGrid1.DataSource = ip.Lista_DetalleModi(Session["Usuario"].ToString(), 2);
                    RadGrid1.DataBind();
                    Limpiar();

                }
            }
        }
        [WebMethod]
        public static string[] BuscaCodigo(string Codigo)
        {
            try
            {
                string Resultado = "";
                Controller_IngresoPartes ip = new Controller_IngresoPartes();
                Resultado = ip.Carga_CodigoParte(Codigo);
                if (Resultado == "")
                {
                    return new[] { "Codigo Incorrecto" };
                }
                else
                {
                    return new[] { Resultado };
                }
            }
            catch
            {
                return new[] { "Codigo Incorrecto" };
            }
        }
        [WebMethod]
        public static string[] BuscaOT(string OT)
        {
            try
            {
                string Resultado = "";
                Controller_IngresoPartes ip = new Controller_IngresoPartes();
                Resultado = ip.Carga_NombreOT(OT);
                if (Resultado == "")
                {
                    return new[] { "OT Incorrecta" };
                }
                else
                {
                    return new[] { Resultado };
                }
            }
            catch
            {
                return new[] { "OT Incorrecta" };
            }
        }


    }
}