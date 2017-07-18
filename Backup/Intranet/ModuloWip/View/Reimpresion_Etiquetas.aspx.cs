using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Intranet.ModuloWip.Controller;
using Telerik.Web.UI;

namespace Intranet.ModuloWip.View
{
    public partial class Reimpresion_Etiquetas : System.Web.UI.Page
    {
        Controller_WipControl controlWP = new Controller_WipControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
            if (rdFolio.Checked == true)
            {
                lblFolio.Visible = true;
                txtCodigo.Visible = true;
                lblOT.Visible = false;
                txtOT.Visible = false;

                divResultado.Visible = false;
                //   divBotones.Visible = false;

            }
            else
            {
                lblOT.Visible = true;
                txtOT.Visible = true;
                lblFolio.Visible = false;
                txtCodigo.Visible = false;
                divResultado.Visible = false;
                divBotones.Visible = false;

            }
        }
        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rdFolio.Checked == true)
            {
                RadGrid1.DataSource = controlWP.BusquedaPorFolioyOT(txtCodigo.Text, "");
                RadGrid1.DataBind();
                if (RadGrid1.Items.Count > 0)
                {
                    divResultado.Visible = false;
                    divBotones.Visible = true;
                }
                else
                {
                    divResultado.Visible = true;
                    imgResultado.ImageUrl = "../../Images/cross.png";
                    lblResultado.Text = "El Codigo del Pallet no ha sido encontrado.";
                    lblResultado.ForeColor = Color.White;
                    lblResultado.Attributes.Add("style", "background-color:Red");

                    divBotones.Visible = false;
                }
            }
            else if (rdOT.Checked == true)
            {
                txtCodigo.Text = "";

                RadGrid1.DataSource = controlWP.BusquedaPorFolioyOT("", txtOT.Text);
                RadGrid1.DataBind();
                divBotones.Visible = false;

                if (RadGrid1.Items.Count > 0)
                {
                    divResultado.Visible = false;
                    divBotones.Visible = false;
                }
                else
                {
                    divResultado.Visible = true;
                    imgResultado.ImageUrl = "../../Images/cross.png";
                    lblResultado.Text = "La OT no ha sido encontrado.";
                    lblResultado.ForeColor = Color.White;
                    lblResultado.Attributes.Add("style", "background-color:Red");
                    divBotones.Visible = false;
                }
            }
        }
        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {

            //if (e.CommandName == "RowClick")
            //{

            GridDataItem item = (GridDataItem)e.Item;
            lblOT.Visible = false;
            txtOT.Visible = false;
            lblFolio.Visible = true;
            txtCodigo.Visible = true;
            divBotones.Visible = true;
            txtCodigo.Text = item["ID_Control"].Text;
            RadGrid1.DataSource = controlWP.BusquedaPorFolioyOT(txtCodigo.Text, "");
            RadGrid1.DataBind();
            rdFolio.Checked = true;
            //txtNumeroOT.Text = item["OT"].Text;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reimpresion_Etiquetas.aspx?id=8&Cat=5");
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            int respuesta = controlWP.TipodePallet(txtCodigo.Text);
            if (respuesta == 1)
            {
                string popupScript = "<script language='JavaScript'> onload(window.open('Etiqueta_Wip.aspx?cd=" + txtCodigo.Text + "','Imprimir Etiqueta Wip','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=750,height=700,left=340,top=200'));</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            if (respuesta > 1)
            {
                string popupScript = "<script language='JavaScript'> onload(window.open('Etiqueta_Wip2.aspx?cd=" + txtCodigo.Text + "','Imprimir Etiqueta Wip','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=750,height=700,left=340,top=200'));</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

    }
}