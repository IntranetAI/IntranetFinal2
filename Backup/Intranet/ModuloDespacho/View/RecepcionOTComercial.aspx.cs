using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using System.Text;
using Telerik.Web.UI;
using System.Drawing;

namespace Intranet.ModuloDespacho.View
{
    public partial class RecepcionOTComercial : System.Web.UI.Page
    {
        Controller_OTComercial oc = new Controller_OTComercial();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            RadGrid1.DataSource = oc.Cargar_OTComercial_Grilla(txtOT.Text, "", "", 0, 0, 0, "", "", "", 3);
            RadGrid1.DataBind();

            if (RadGrid1.Items.Count == 0)
            {
                divMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "No se han encontrado Registros.";
                lblMensaje.ForeColor = Color.White;
                lblMensaje.Attributes.Add("style", "background-color:Red");
            }
        }

        protected void ibAprobar_Click1(object sender, ImageClickEventArgs e)
        {
            int contadorInsert = 0;

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem row = RadGrid1.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {

                    bool resp = oc.AprobaroRechazarOTComercial(row["Folio"].Text, "", "", 0, 0, 0, "", "", Session["Usuario"].ToString(), 4);
                    if (resp == true)
                    {
                        contadorInsert++;
                    }
                }
            }
            if (contadorInsert != 0)
            {
                divMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/tick.png";
                lblMensaje.Text = "Se ha recepcionado correctamente.";
                lblMensaje.ForeColor = Color.White;
                lblMensaje.Attributes.Add("style", "background-color:Green");
            }

            RadGrid1.DataSource = oc.Cargar_OTComercial_Grilla(txtOT.Text, "", "", 0, 0, 0, "", "", "", 3);
            RadGrid1.DataBind();
        }

        protected void ibRechazar_Click(object sender, ImageClickEventArgs e)
        {
            int contadorInsert = 0;

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem row = RadGrid1.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {

                    bool resp = oc.AprobaroRechazarOTComercial(row["Folio"].Text, "", "", 0, 0, 0, "", "", Session["Usuario"].ToString(), 5);
                    if (resp == true)
                    {
                        contadorInsert++;
                    }
                }
            }
            if (contadorInsert != 0)
            {
                divMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/tick.png";
                lblMensaje.Text = "Se ha Rechazado correctamente.";
                lblMensaje.ForeColor = Color.White;
                lblMensaje.Attributes.Add("style", "background-color:Green");
            }

            RadGrid1.DataSource = oc.Cargar_OTComercial_Grilla(txtOT.Text, "", "", 0, 0, 0, "", "", "", 3);
            RadGrid1.DataBind();
        }
    }
}