using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using System.Drawing;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class Reimpresion_Guias : System.Web.UI.Page
    {
        bool respuesta = true;
        Controller_InfDespacho inD = new Controller_InfDespacho();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            if (!IsPostBack)
            {
                DivMensaje.Visible = false;
            }
        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                respuesta = inD.Reimpresion_Guias(txtCodigo.Text);

                if (respuesta == true)
                {
                    DivMensaje.Visible = true;
                    pnlResultado.Visible = true;
                    //poner error qe no existe o fue cerrada

                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.Text = "El Pallet Encontrado.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Green");
                }
                else
                {
                    DivMensaje.Visible = true;
                    pnlResultado.Visible = false;

                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                    //poner error qe no existe o fue cerrada

                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "El Pallet no ha sido Encontrado, vuelva a intentarlo.";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Red");
                }
            }
            else
            {
                //vacio
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reimpresion_Guias.aspx?id=1");
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = Session["Usuario"].ToString();
            string popupScript = "<script language='JavaScript'> onload(window.open('EtiquetaAprobadaPT.aspx?Cod=" + txtCodigo.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200'));</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }
    }
}