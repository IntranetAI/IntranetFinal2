using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloAdministracion.Model;
using System.Drawing;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Ingreso_Solic_insumo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMaquinas();
                CargarDatos(Request.QueryString["Id"], Request.QueryString["Des"], Request.QueryString["Sto"], Request.QueryString["Gr"]);
            }
        }
        public void CargarDatos(string CodItem, string Descripcion, string Stock, string Grupo)
        {
            lblCodigo.Text = CodItem.ToString();
            lblDescripcion.Text = Descripcion.ToString();
            lblGrupo.Text = Grupo.ToString();
            lblStock.Text = Stock.ToString();
        }

        public void CargarMaquinas()
        {
            Controller_Consumo controlconsumo = new Controller_Consumo();
            ddlMaquina.DataSource = controlconsumo.ListarStockInsumoMaquina();
            ddlMaquina.DataTextField = "Gramage";
            ddlMaquina.DataValueField = "CodItem";
            ddlMaquina.DataBind();
            ddlMaquina.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            OrdenController oc = new OrdenController();
            lblNombreOT.Text = oc.Seguimiento_BuscarNM(txtOT.Text);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Validacion.Visible = false;
            if (ddlMaquina.SelectedItem.ToString() != "-- Seleccione --")
            {
                string[] stk = lblStock.Text.ToString().Replace(",", string.Empty).Split(' ');
                double Stock = Convert.ToDouble(stk[0]);
                if (txtCantidad.Text.ToString() != "")
                {
                    double Solicitado = Convert.ToDouble(txtCantidad.Text.ToString());
                    if (Stock >= Solicitado)
                    {
                        if ((lblNombreOT.Text != "") || (txtOT.Text != ""))
                        {
                            Consumo consumo = new Consumo();
                            consumo.CodItem = lblCodigo.Text;
                            consumo.NombrePapel = lblDescripcion.Text;
                            string[] stock = lblStock.Text.ToString().Replace(",", string.Empty).Split(' ');
                            consumo.Lote = stock[0];
                            consumo.Costtot = txtOT.Text;
                            consumo.Tipo = lblNombreOT.Text;
                            consumo.Cons_Pliego = txtCantidad.Text;
                            consumo.Cons_Otros = ddlMaquina.SelectedItem.ToString();
                            consumo.Cons_Plancha = Session["Usuario"].ToString();

                            Controller_Consumo controlconsumo = new Controller_Consumo();
                            if (controlconsumo.AgregarSolicStock(consumo))
                            {
                                string popupScript4 = "<script language='JavaScript'>opener.location.reload();window.close();</script>";
                                Page.RegisterStartupScript("PopupScript", popupScript4);
                            }
                            else
                            {
                                Validacion.Visible = true;
                                Image1.ImageUrl = "../../Images/cross.png";
                                Label1.Text = "Error al Ingresar";
                                Label1.ForeColor = Color.White;
                                Validacion.Attributes.Add("style", "background-color:red");
                                Label1.Text = "Error al Ingresar";
                            }
                        }
                        else
                        {
                            Validacion.Visible = true;
                            Image1.ImageUrl = "../../Images/cross.png";
                            Label1.Text = "Error al Ingresar";
                            Label1.ForeColor = Color.White;
                            Validacion.Attributes.Add("style", "background-color:red");
                            Label1.Text = "Debe seleccionar una OT";
                        }
                    }

                    else
                    {
                        Validacion.Visible = true;
                        Image1.ImageUrl = "../../Images/cross.png";
                        Label1.Text = "Error al Ingresar";
                        Label1.ForeColor = Color.White;
                        Validacion.Attributes.Add("style", "background-color:red");
                        Label1.Text = "El Stock no es suficiente para la Solicitud";
                    }
                }
                else
                {
                    Validacion.Visible = true;
                    Image1.ImageUrl = "../../Images/cross.png";
                    Label1.Text = "Error al Ingresar";
                    Label1.ForeColor = Color.White;
                    Validacion.Attributes.Add("style", "background-color:red");
                    Label1.Text = "Debe indicar Cantidad de la Solicitud";
                }
            }
            else
            {
                Validacion.Visible = true;
                Image1.ImageUrl = "../../Images/cross.png";
                Label1.Text = "Error al Ingresar";
                Label1.ForeColor = Color.White;
                Validacion.Attributes.Add("style", "background-color:red");
                Label1.Text = "Debe seleccionar una Maquina";
            }
        }
    }
}