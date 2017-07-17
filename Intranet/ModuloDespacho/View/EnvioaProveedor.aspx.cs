using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.View
{
    public partial class EnvioaProveedor : System.Web.UI.Page
    {
        Controller_Proveedor cp = new Controller_Proveedor();
        bool respuesta = true;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtNumeroOT.Text != "")
            {
                ProveedorMod pm = cp.cargarPliegosOT(txtNumeroOT.Text,0, 1);

                lblNombreOT.Text = pm.NombreOT;
                lblTirajeOT.Text = pm.TirajeOT;



                ddlPliegos.DataSource = cp.CargaPliegos(txtNumeroOT.Text,0,2);
                ddlPliegos.DataTextField = "NombrePliego";
                ddlPliegos.DataValueField = "CantidadPliego";
                ddlPliegos.DataBind();
                ddlPliegos.Items.Insert(0, new ListItem("Seleccione...", "Seleccione..."));

              
                //cargar pliegos
            }
            else
            {
                //error
            }

        }


        protected void ddlPliegos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ProveedorMod pm = cp.cargarDatosPliegos("",Convert.ToInt32( ddlPliegos.SelectedValue.ToString()), 3);
            lblForma.Text = pm.Forma;
            lblProcesoExterno.Text = pm.ProcesoExterno;

            lblidProcesoExterno.Text = pm.id_ProcesoExterno;
            int tirajep = Convert.ToInt32(pm.CantidadPliego);
            int restante = Convert.ToInt32(pm.Total);

            lblTirajePliego.Text = tirajep.ToString("N0").Replace(",", ".");
            lblRestantes.Text = (tirajep - restante).ToString("N0").Replace(",", ".");
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtCantidadAEnviar.Text != "" && ddlPliegos.SelectedItem.Text != "Seleccione...")
            {
                respuesta = cp.InsertarEnvioProveedor(Convert.ToInt32(lblidProcesoExterno.Text), Convert.ToInt32(ddlPliegos.SelectedValue.ToString()), txtNumeroOT.Text, lblNombreOT.Text, ddlPliegos.SelectedItem.Text, lblForma.Text, Convert.ToInt32(lblTirajePliego.Text.Replace(".", "")), lblProcesoExterno.Text, Convert.ToInt32(txtCantidadAEnviar.Text), Session["Usuario"].ToString());

                if (respuesta == true)
                {
                    //mensaje
                }
                else
                {
                    //error
                }
            }
        }
    }
}