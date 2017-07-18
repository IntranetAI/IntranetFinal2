using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;

namespace Intranet.ModuloWip.View
{
    public partial class Informe_Bodegas : System.Web.UI.Page
    {
        Controller_WipControl wipControl = new Controller_WipControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarBodegas();
                ddlNumeroRack.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));
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
        }

        protected void ddlBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Bodega = ddlBodega.SelectedItem.ToString();
            if (Bodega != "Seleccionar")
            {
                CargarNuRack(Bodega);
            }
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
            //hacer diferencia de pisos posibles
            //lblID.Text = txtCodigoPallet.Text;
            string Bodega = ddlBodega.SelectedItem.ToString();
            if (ddlNumeroRack.SelectedItem.ToString() != "Seleccionar")
            {
                string rack = "";
                int Rack = Convert.ToInt32(ddlNumeroRack.SelectedItem.ToString());
                int NNivel = wipControl.CantidadNivelRack(ddlBodega.SelectedItem.ToString());
                for (int i = NNivel; i >= 1; i--)
                {
                    rack = rack + wipControl.UbicacionRack_Libre2(Bodega, Rack, "", i);
                    //divGuardar.Visible = true;
                }
                RackUbicacion.Text = rack;//ubicacion piso 2
                RackUbicacion.Visible = true;
            }
            else
            {
                RackUbicacion.Visible = false;
                //divGuardar.Visible = false;
                Label10.Visible = false;
            }
        }
    }
}