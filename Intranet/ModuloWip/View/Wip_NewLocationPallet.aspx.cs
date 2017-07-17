using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloWip.Model;
using Intranet.ModuloWip.Controller;

namespace Intranet.ModuloWip.View
{
    public partial class Wip_NewLocationPallet : System.Web.UI.Page
    {
        Controller_WipControl wipControl = new Controller_WipControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarBodegas();
            }
        }

        public void CargarBodegas()
        {
            List<Model_Wip_Control> lista = wipControl.listBodegaWip();
            ddlBodega.DataSource = lista;
            ddlBodega.DataTextField = "Ubicacion";
            ddlBodega.DataValueField = "Ubicacion";
            ddlBodega.DataBind();
            ddlBodega.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));
            Label21.Visible = false;
            ddlNumeroRack.Visible = false;
        }

        public void CargarNuRack(string Bodega)
        {
            List<Model_Wip_Control> lista = wipControl.listNumRack_Bodega(Bodega);
            ddlNumeroRack.DataSource = lista;
            ddlNumeroRack.DataTextField = "Ubicacion";
            ddlNumeroRack.DataValueField = "Ubicacion";
            ddlNumeroRack.DataBind();
            ddlNumeroRack.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoPallet.Text;
            List<Model_Wip_Control> lista = wipControl.BuscarWip_ControlPorCodigo2(codigo);
            if (lista.Count > 0)
            {
                DivMensaje.Visible = false;
                Model_Wip_Control wip2 = new Model_Wip_Control();
                int contador = 0;
                foreach (Model_Wip_Control wip in lista)
                {
                    pnlDatosOT.Visible = true;
                    wip2 = wip;
                    if (contador == 0)
                    {
                        lblOT.Text = wip.OT.ToUpper();
                        lblNombreOT.Text = wip.NombreOT;
                        lblTiraje.Text = wip.TotalTiraje.ToString("N0").Replace(',', '.');
                        lblMaquina.Text = wip.Maquina;
                        Label5.Text = "<table cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:80%;'>" +
                                       "<tbody><tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                       "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Nombre Pliego</td>" +
                                       "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Pliego Impresos</td>" +
                                       "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Peso Pallet</td>" +
                                       "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Destino</td></tr>" +
                                       "<tr style='border-bottom:1px solid blue;background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;'>" +
                                       "<td style='text-align: center;font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + wip.Pliego + "</td>" +
                                       "<td style='text-align: right;font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + wip.Pliegos_Impresos + "</td>" +
                                       "<td style='text-align: right;font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + wip.Peso_pallet + "</td>" +
                                       "<td style='text-align: left;font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + wip.Ubicacion + "</td></tr>";
                    }
                    if (contador != 0)
                    {
                        Label5.Text = Label5.Text + "<tr style='border-bottom:1px solid blue;height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;'>" +
                                       "<td style='text-align: center;font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + wip.Pliego + "</td>" +
                                       "<td style='text-align: right;font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + wip.Pliegos_Impresos + "</td>" +
                                       "<td style='text-align: right;font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + wip.Peso_pallet + "</td>" +
                                       "<td style='text-align: left;font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;'>" + wip.Ubicacion + "</td></tr>";
                    }
                    contador++;
                    if (lista.Count == contador)
                    {
                        Label5.Text = Label5.Text + "</table>";
                    }
                }

                if (wip2.Estado_Pallet != 1)
                {
                    lblBodega1.Text = wip2.Ubicacion;
                    lblNumRack1.Text = wip2.Posicion;
                    lblBodega1.Visible = true;
                    lblNumRack1.Visible = true;
                    Label22.Visible = true;
                    Label23.Visible = true;
                }
                else
                {
                    lblNumRack1.Visible = false;
                    lblBodega1.Visible = false;
                    Label22.Visible = false;
                    Label23.Visible = false;
                }
                ddlNumeroRack.Visible = false;
                RackUbicacion.Visible = false;
                Label10.Visible = false;
                CargarBodegas();
            }
            else
            {
                DivMensaje.Visible = true;
                DivMensaje.Attributes.Add("style", "background-color:Red");
                lblMensaje.Text = "Codigo Pallet no encontrado. Vuelva a intentarlo";
                lblMensaje.ForeColor = System.Drawing.Color.White;
                imgMensaje.ImageUrl = "../../Images/cross.png";
            }
        }

        protected void ddlBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Bodega = ddlBodega.SelectedItem.ToString();
            if (Bodega != "Seleccionar")
            {
                CargarNuRack(Bodega);
                Label21.Visible = true;
                ddlNumeroRack.Visible = true;
            }
            else
            {
                Label21.Visible = false;
                ddlNumeroRack.Visible = false;
            }
            RackUbicacion.Visible = false;
            divGuardar.Visible = false;
        }

        protected void ddlNumeroRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hacer diferencia de pisos posibles
            lblID.Text = txtCodigoPallet.Text;
            string Bodega = ddlBodega.SelectedItem.ToString();
            if (ddlNumeroRack.SelectedItem.ToString() != "Seleccionar")
            {
                string rack = "";
                int Rack = Convert.ToInt32(ddlNumeroRack.SelectedItem.ToString());
                int NNivel = wipControl.CantidadNivelRack(ddlBodega.SelectedItem.ToString());
                for (int i = NNivel; i >= 1; i--)
                {
                    rack = rack + wipControl.UbicacionRack_Libre(Bodega, Rack, txtCodigoPallet.Text, i);
                    divGuardar.Visible = true;
                }
                RackUbicacion.Text = rack;//ubicacion piso 2
                RackUbicacion.Visible = true;
            }
            else
            {
                RackUbicacion.Visible = false;
                divGuardar.Visible = false;
                Label10.Visible = false;
            }
        }

        [WebMethod]
        public static void btnAsignar_Click(string Texto, string Usuario)
        {
            Wip_NewLocationPallet apu = new Wip_NewLocationPallet();
            if (Texto != "")
            {
                apu.cargar(Texto, Usuario);
            }
        }

        public void cargar(string Texto, string Usuario)
        {
            string[] separar = Texto.Split('.');
            string Codigo = separar[0];
            string ubicacion = separar[1];

            if (wipControl.AsignarUbicacionPallet(Codigo, ubicacion, Usuario))
            {
            }
        }
    }
}