using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;
using Telerik.Web.UI;
using Intranet.ModuloEncuadernacion.Controller;
using Intranet.ModuloEncuadernacion.Model;

namespace Intranet.ModuloDespacho.View
{
    public partial class GuiaDespacho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGridDist.DataSource = "";
                RadGridDist.DataBind();
                RadGridDetalleD.DataSource = "";
                RadGridDetalleD.DataBind();
            }//initialize();
            string popupScript = "<script language='JavaScript'>initMap();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            string OT = txtOT.Text;
            Controller_GuiaDespacho controlDes = new Controller_GuiaDespacho();
            RadGridDist.DataSource = controlDes.ListarDistribuccion(OT);
            RadGridDist.DataBind();
            if (RadGridDist.Items.Count > 0)
            {
                btnCrearDistribuccion.Visible = false;
            }
            else
            {
                btnCrearDistribuccion.Visible = true;
            }
            Controller_Enc Enc = new Controller_Enc();
            DateTime fec = Convert.ToDateTime("01-01-1900");
            RadGridDetalleD.DataSource = Enc.CargarAprobadosPT(OT, "", fec, fec, 2).Where(o => o.FechaValidacion.Substring(0,1).ToUpper()!="T" );
            RadGridDetalleD.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Controller_GuiaDespacho controlDes = new Controller_GuiaDespacho();

            int respuesta = 0;
            //List<GuiaDespacho_Detalle> lista = new List<GuiaDespacho_Detalle>();
            for (int i = 0; i < RadGridDist.Items.Count; i++)
            {
                GridDataItem row = RadGridDist.Items[i];
                GuiaDespacho_Detalle guia = new GuiaDespacho_Detalle();
                //guia.Nfactura = controlDes.MaxGuiaDespacho()+1;
                guia.OT = row["OT"].Text.ToString();
                guia.Rut = row["Rut"].Text.ToString();
                guia.Sucursal = row["Sucursal"].Text.ToString();
                guia.Comuna = row["Comuna"].Text.ToString();
                guia.CantXBulto = Convert.ToInt32(row["Cant_porbult"].Text.ToString());
                guia.Embalaje = row["Embalaje"].Text.ToString();
                guia.Usuario = Session["Usuario"].ToString();
                if (controlDes.AgregarGuiaDesp(guia))
                {
                    respuesta = respuesta + 1;
                }

            }
            if (respuesta != 0 && respuesta > 0)
            {
                string popupScript = "<script language='JavaScript'>alert('Guias Creadas Correctamente');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                TabContainer1.ActiveTabIndex = 1;
                TabPanel3.Enabled = false;
                TabPanel1.Enabled = false;
            }

        }

        protected void btnCrearDistribuccion_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'>window.open('Distribuccion.aspx?ot="+txtOT.Text.Trim()+"', 'Nueva Distribuccion', 'left=300,top=100,width=870 ,height=500,scrollbars=yes,dependent=yes,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void btnDireccion_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 3;
        }

    }
}