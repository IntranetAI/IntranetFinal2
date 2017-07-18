using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using Telerik.Web.UI;
using System.Drawing;

namespace Intranet.ModuloDespacho.View
{
    public partial class ReimpresionFolio : System.Web.UI.Page
    {
        Controller_Devoluciones des = new Controller_Devoluciones();
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
                txtFolio.Visible = true;
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
                txtFolio.Visible = false;
                divResultado.Visible = false;
                divBotones.Visible = false;

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rdFolio.Checked == true)
            {
                RadGrid1.DataSource = des.BusquedaPorFolioyOT(txtFolio.Text, "", 4);
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
                    lblResultado.Text = "El Folio no ha sido encontrado.";
                    lblResultado.ForeColor = Color.White;
                    lblResultado.Attributes.Add("style", "background-color:Red");

                    divBotones.Visible = false;
                }
            }
            else if (rdOT.Checked == true)
            {
                txtFolio.Text = "";

                RadGrid1.DataSource = des.BusquedaPorFolioyOT("", txtOT.Text, 4);
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
            txtFolio.Visible = true;
            divBotones.Visible = true;
            txtFolio.Text = item["Folio"].Text;

            RadGrid1.DataSource = des.BusquedaPorFolioyOT(txtFolio.Text, "", 4);
            RadGrid1.DataBind();
            //txtNumeroOT.Text = item["OT"].Text;
        }

        //protected void btnGenerar_Click(object sender, EventArgs e)
        //{
        //    if (txtFolio.Text != "")
        //    {
                

        //            string popupScript = "<script language='JavaScript'> onload(window.open('DetalleDevolucion.aspx?Cod=" + txtFolio.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
        //            Page.RegisterStartupScript("PopupScript", popupScript);

        //            btnImprimir.Attributes.Add("onclick", "window.open('DetalleDevolucion.aspx?Cod=" + txtFolio.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");
        //            btnImprimir.Visible = true;

        //            divResultado.Visible = true;
        //            imgResultado.ImageUrl = "../../Images/tick.png";
        //            lblResultado.Text = "El Envio se ha Generado Correctamente, Imprimalo.";
        //            lblResultado.ForeColor = Color.White;
        //            lblResultado.Attributes.Add("style", "background-color:Green");

        //            divBotones.Visible = true;
               
        //    }
        //}

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("envioDevolucion.aspx?id=8");
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            btnImprimir.Visible = true;
            string popupScript = "<script language='JavaScript'> onload(window.open('DetalleDevolucion.aspx?Cod=" + txtFolio.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

    }
}