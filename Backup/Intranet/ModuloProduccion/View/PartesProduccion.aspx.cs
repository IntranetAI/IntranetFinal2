using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class PartesProduccion : System.Web.UI.Page
    {
        Partes par = new Partes();
        DateTime f = Convert.ToDateTime("1900-01-01");
        protected void Page_Load(object sender, EventArgs e)
        {
            RadGrid1.DataSource = "";
            RadGrid1.DataBind();
            if (!IsPostBack)
            {
                ddlMaquina.DataSource = par.Listar_Maquinas("", "", "", "", f, f, 2);
                ddlMaquina.DataTextField = "Maquina";
                ddlMaquina.DataValueField = "ID_Maquina";
                ddlMaquina.DataBind();

                ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtNumeroOT.Text != "")
            {
                if (ddlPliegos.SelectedValue != "TODOS LOS PLIEGOS")
                {
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        string[] str = txtFechaInicio.Text.Split('/');
                        DateTime f1 = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");


                        string[] str2 = txtFechaTermino.Text.Split('/');
                        DateTime f2 = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 00:00:00");

                        RadGrid1.DataSource = par.Resultado_Listar(txtNumeroOT.Text, ddlPliegos.SelectedValue.ToString(), "", "", f1, f2, 4);
                        RadGrid1.DataBind();
                    }
                    else
                    {   
                        RadGrid1.DataSource = par.Resultado_Listar(txtNumeroOT.Text, ddlPliegos.SelectedValue.ToString(), "", "", f,f, 3);
                        RadGrid1.DataBind();
                    }

                }
                else
                {
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        string[] str = txtFechaInicio.Text.Split('/');
                        DateTime f1 = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");


                        string[] str2 = txtFechaTermino.Text.Split('/');
                        DateTime f2 = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 00:00:00");
                        RadGrid1.DataSource = par.Resultado_Listar(txtNumeroOT.Text, "", "", "", f1, f2, 4);
                        RadGrid1.DataBind();
                    }
                    else
                    {
                        RadGrid1.DataSource = par.Resultado_Listar(txtNumeroOT.Text, "", "", "", f, f, 3);
                        RadGrid1.DataBind();
                    }
                }
            }
            else
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime f1 = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");


                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime f2 = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 00:00:00");

                    if (ddlMaquina.SelectedValue.ToString() == "Seleccione...")
                    {
                        RadGrid1.DataSource = par.Resultado_Listar("", "", txtCliente.Text,"", f1, f2, 4);
                        RadGrid1.DataBind();
                    }
                    else
                    {
                        RadGrid1.DataSource = par.Resultado_Listar("", "", txtCliente.Text, ddlMaquina.SelectedItem.ToString(), f1, f2, 4);
                        RadGrid1.DataBind();
                    }
                }
                else
                {
                    RadGrid1.DataSource = par.Resultado_Listar("", ddlPliegos.SelectedValue.ToString(), txtCliente.Text, ddlMaquina.SelectedItem.ToString(), f, f, 3);
                    RadGrid1.DataBind();
                }
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtNumeroOT_TextChanged(object sender, EventArgs e)
        {
            if (txtNumeroOT.Text != "")
            {
                ddlPliegos.DataSource = par.Listar_Pliegos_Partes(txtNumeroOT.Text, "", "", "", f, f, 0);
                ddlPliegos.DataTextField = "Pliegos";
                ddlPliegos.DataValueField = "Pliegos";
                ddlPliegos.DataBind();

                ddlPliegos.Items.Insert(0, new ListItem("TODOS LOS PLIEGOS"));

                txtCliente.Text = par.Carga_Cliente(txtNumeroOT.Text, "", "", "", f, f, 0);
                txtCliente.Enabled = false;
            }
            else
            {
                txtCliente.Text = "";
                txtCliente.Enabled = true;
            }
        }

        protected void ddlPliegos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPliegos.SelectedValue.ToString() != "TODOS LOS PLIEGOS")
            {
                ddlMaquina.SelectedValue = par.Carga_Maquina(txtNumeroOT.Text, ddlPliegos.SelectedValue.ToString(), "","",f, f, 1);
                ddlMaquina.Enabled = false;
            }
            else
            {
                ddlMaquina.Enabled = true;
                ddlMaquina.SelectedValue = "Seleccione...";
            }
        }
    }
}