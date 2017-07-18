using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using Intranet.ModuloAdministracion.Model;
using Telerik.Web.UI;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Liquidar_OT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarOTs(0);
            }
        }

        public void CargarOTs(int procedimiento)
        {
            string OT = txtNumeroOT.Text;
            string NombreOT = txtNombreOT.Text;
            string Cliente = txtCliente.Text;
            string FeInicio = "";
            string FeTermino = "";
            if (txtFechaInicio.Text.Trim() != "" && txtFechaTermino.Text.Trim() != "")
            {
                string[] split = txtFechaInicio.Text.Split('/');
                FeInicio = split[2] + "-" + split[1] + "-" + split[0];
                string[] split2 = txtFechaTermino.Text.Split('/');
                FeTermino = split2[2] + "-" + split2[1] + "-" + split2[0]+ " 23:59:59";
            }
            if (procedimiento == 1 && txtFechaInicio.Text.Trim() == "" && txtFechaTermino.Text.Trim() == "" && OT == "" && NombreOT == "" && Cliente == "")
            {
                procedimiento = 0;
            }
            Controller_Consumo controlconsum = new Controller_Consumo();
            RadGridLiq.DataSource = controlconsum.ListarLiquidarOTs(OT,NombreOT,Cliente,FeInicio,FeTermino,procedimiento);
            RadGridLiq.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            PanelFiltro.Visible = true;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            PanelFiltro.Visible = false;
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            CargarOTs(1);
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            string OTs = "";
            int contador = 0;
            for (int i = 0; i < RadGridLiq.Items.Count; i++)
            {
                GridDataItem row = RadGridLiq.Items[i];
                if (contador == 0)
                {
                    OTs = row["Ancho"].Text + ",";
                }
                else
                {
                    OTs = OTs + row["Ancho"].Text + ",";
                }
                contador++;
            }
            string popupScript = "<script language='JavaScript'>imprSelec('" + OTs.Substring(0, OTs.Length - 1) + "'); </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }
    }
}