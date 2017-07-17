using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;

namespace Intranet.ModuloWip.View
{
    public partial class Wip_EtiquetaMult : System.Web.UI.Page
    {
        public static string CodigoBarra = "";
        OrdenController orderControl = new OrdenController();
        Controller_WipControl wipControl = new Controller_WipControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CodigoBarra = "";
                ddlMaquina.DataSource = wipControl.ListMaquinas("Rotativa");
                ddlMaquina.DataTextField = "OT";
                ddlMaquina.DataValueField = "OT";
                ddlMaquina.DataBind();
                ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtNumeroOT.Text != "")
            {
                string NumeroOT = txtNumeroOT.Text;
                Orden ot = orderControl.BuscarPorOT(NumeroOT);
                if (ot.NombreCliente != null)
                {
                    LimpForm();
                    lblCliente.Text = ot.NombreCliente;
                    txtNombreOT.Text = ot.NombreOT;
                    int ejem = Convert.ToInt32(ot.Ejemplares);
                    txtTotal.Text = ejem.ToString("N0").Replace(',', '.');
                    pnlDatosOT.Visible = true;
                    pnlDatosMaquina.Visible = true;

                    ddlPliego.DataSource = wipControl.ListPliegosOT(NumeroOT);
                    ddlPliego.DataTextField = "Pliego";
                    ddlPliego.DataValueField = "Pliego";
                    ddlPliego.DataBind();
                    ddlPliego.Items.Insert(0, new ListItem("Seleccione..."));
                    ddlMaquina.SelectedIndex = 0;
                    pnlError.Visible = false;
                    pnlDatosPallet.Visible = false;
                }
                else
                {
                    pnlError.Visible = true;
                    pnlDatosMaquina.Visible = false;
                    pnlDatosOT.Visible = false;
                    pnlDatosPallet.Visible = false;
                    DivError.Attributes.Add("style", "background-color:Red");
                    lblError.Text = "OT no encontrada. Vuelva a intentarlo";
                    lblError.ForeColor = Color.White;
                    imgError.ImageUrl = "../../Images/cross.png";
                }
            }
            else
            {
                pnlError.Visible = true;
                pnlDatosMaquina.Visible = false;
                pnlDatosOT.Visible = false;
                pnlDatosPallet.Visible = false;
                DivError.Attributes.Add("style", "background-color:Red");
                lblError.Text = "Debe ingresar una OT. Vuelva a intentarlo";
                lblError.ForeColor = Color.White;
                imgError.ImageUrl = "../../Images/cross.png";
            }
        }

        protected void ddlMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMaquina.SelectedValue.ToString() != "Seleccione...")
            {
                pnlDatosPallet.Visible = true;
            }
            else
            {
                pnlDatosPallet.Visible = false;
                LimpForm(); ddlPliego.SelectedIndex = 0; btnCerrarPallet.Visible = false; Button1.Visible = false;
            }
        }

        protected void ddlPliego_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpForm();
            if (ddlPliego.SelectedValue.ToString() != "Seleccione...")
            {
                int tp = Convert.ToInt32(wipControl.BuscaPliegos(txtNumeroOT.Text, ddlPliego.SelectedValue.ToString(), 1));
                txtTirajeFinal.Text = tp.ToString();

                string selected = ddlPliego.SelectedItem.ToString().Trim();
                string NumeroOT = txtNumeroOT.Text;
                List<Model_Wip_Control> lista = wipControl.ListPliegosOT(NumeroOT).Where(o => o.Pliego == selected).ToList();
                int count = 0;
                if (NumeroOT.Substring(0, 1).ToUpper() == "B")
                {
                    foreach (Model_Wip_Control x in lista)
                    {
                        if (count == 0)
                        {
                            lblForma.Text = x.Forma;
                            lblTarea.Text = x.Tarea;
                            count++;
                        }
                    }
                }
            }
            else
            {
                btnCerrarPallet.Visible = false; Button1.Visible = false;
            }
        }

        protected void txtAltura_TextChanged(object sender, EventArgs e)
        {
            if (ddlPliego.SelectedValue.ToString() != "Seleccione...")
            {
                CalcularEti(2);
                btnCerrarPallet.Visible = true;
                Button1.Visible = true;
            }
        }

        protected void btnCerrarPallet_Click(object sender, EventArgs e)
        {
            double CanEtiqueta = (Convert.ToDouble(txtTirajeFinal.Text) / (Convert.ToDouble(txtPaquete.Text) * Convert.ToDouble(txtBase.Text) * Convert.ToDouble(txtAltura.Text)));
            string NumEti = CanEtiqueta.ToString().Substring(0, CanEtiqueta.ToString().IndexOf("."));
            int contador = 0;
            for (int i = 0; i < Convert.ToDouble(lblCantidadEti.Text); i++)
            {
                contador++;
                if (Convert.ToInt32(NumEti) >= contador)
                {
                    if (txtPesoIni.Text.Trim() != "")
                    {
                        CodigoBarra = CodigoBarra + CreaEtiqueta(Convert.ToInt32(lblTirajeEti.Text), Convert.ToDouble(txtPesoIni.Text)) + ",";
                    }
                    else
                    {
                        CodigoBarra = CodigoBarra + CreaEtiqueta(Convert.ToInt32(lblTirajeEti.Text), Convert.ToDouble(0)) + ",";
                    }
                }
                else
                {
                    if (txtPesoFin.Text.Trim() != "")
                    {
                        CodigoBarra = CodigoBarra + CreaEtiqueta(Convert.ToInt32(lblTirajeEtiF.Text), Convert.ToDouble(txtPesoFin.Text)) + ",";
                    }
                    else
                    {
                        CodigoBarra = CodigoBarra + CreaEtiqueta(Convert.ToInt32(lblTirajeEtiF.Text), Convert.ToDouble(0)) + ",";
                    }
                }
            }
            CodigoBarra = CodigoBarra.Substring(0,CodigoBarra.Length-1);
            btnCerrarPallet.Visible = false;
            btnImprimir.Visible = true;
        }

        public string CreaEtiqueta(int PliegosImpresos, double peso)
        {
            Model_Wip_Control wip = new Model_Wip_Control();
            int numero = wipControl.MaxRegistroWip() + 1;
            string Codigo = "";
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
            wip.Pliego = ddlPliego.SelectedItem.ToString().Trim();
            wip.Pliegos_Impresos = Convert.ToInt32(PliegosImpresos);
            Double Ejemplares = Convert.ToDouble(txtTotal.Text.ToString().Replace('.', ','));
            wip.TotalTiraje = Convert.ToInt32(Ejemplares);
            wip.Peso_pallet = Convert.ToDouble(peso);
            //if (txtPesoIni.Text.Trim() != "" && txtPesoFin.Text.Trim() != "")
            //{
            //    wip.Peso_pallet = Convert.ToDouble(txtPesoIni.Text);
            //}
            if (wip.OT.Substring(0, 1).ToUpper() == "B")
            {
                wip.Tarea = lblTarea.Text.Trim();
                wip.Forma = lblForma.Text.Trim();
            }
            wip.Usuario = Session["Usuario"].ToString();
            wip.Ubicacion = ddlDestino.SelectedItem.ToString();
            wip.IDTipoPallet = 1;
            wip.TipoPallet = "Pliego Normal";
            if (wipControl.Agregar_Pallet_Wip(wip,""))
            {
                return wip.ID_Control;
            }
            else
            {
                return "";
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> onload(window.open('EtiquetaMasiva.aspx?cbw=" + CodigoBarra + "','Imprimir Etiqueta Wip','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=750,height=700,left=340,top=200'));</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
            LimpForm(); ddlPliego.SelectedIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Wip_EtiquetaMult.aspx?id=8&Cat=5");
        }

        public void CalcularEti(int Tipo)
        {
            if (lblCantidadEti.Text.Trim() != ""||Tipo ==2)
            {
                double CanEtiqueta = 0;
                int CanTiraje = 0;
                int CanTiraje1 = 0;
                if (txtTirajeFinal.Text != "")
                {
                    CanEtiqueta = (Convert.ToDouble(txtTirajeFinal.Text) / (Convert.ToDouble(txtPaquete.Text) * Convert.ToDouble(txtBase.Text) * Convert.ToDouble(txtAltura.Text)));
                    CanTiraje = (Convert.ToInt32(txtPaquete.Text) * Convert.ToInt32(txtBase.Text) * Convert.ToInt32(txtAltura.Text));
                    if (CanEtiqueta <= 1)
                    {
                        CanEtiqueta = 1;
                        CanTiraje = Convert.ToInt32(txtTirajeFinal.Text);
                    }
                    else if (CanEtiqueta > 1)
                    {
                        string NumEti = CanEtiqueta.ToString().Substring(0, CanEtiqueta.ToString().IndexOf("."));
                        int Result = Convert.ToInt32(txtTirajeFinal.Text) - (Convert.ToInt32(NumEti) * CanTiraje);
                        CanTiraje1 = Result;
                    }
                }
                lblCantidadEti.Text = CanEtiqueta.ToString();
                lblTirajeEti.Text = CanTiraje.ToString();
                lblTirajeEtiF.Text = CanTiraje1.ToString();
            }
        }

        protected void txtTirajeFinal_TextChanged(object sender, EventArgs e)
        {
            CalcularEti(1);
        }

        public void LimpForm()
        {
            txtTirajeFinal.Text = ""; lblForma.Text = ""; lblTarea.Text = ""; txtPaquete.Text = "";
            txtBase.Text = ""; txtAltura.Text = ""; txtPesoIni.Text = ""; txtPesoFin.Text = "";
            lblCantidadEti.Text = "";
        }
    }
}