using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using System.Drawing;

namespace Intranet.ModuloDespacho.View
{
    public partial class RecepcionarDevolucion : System.Web.UI.Page
    {
        Controller_Devoluciones des = new Controller_Devoluciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
            txtFolio.Focus();
        }

        protected void txtFolio_TextChanged(object sender, EventArgs e)
        {
            if (txtFolio.Text != "")
            {
                RadGrid1.DataSource = des.BusquedaPorFolioyOT(txtFolio.Text, "", 3);
                RadGrid1.DataBind();
            }
            else
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }

            if (RadGrid1.Items.Count == 0)
            {
                btnRecepcionar.Visible = false;
                btnRechazar.Visible = false;
                btnFiltro.Visible = false;
            }
            else
            {
                btnRecepcionar.Visible = true;
                btnRechazar.Visible = true;
                btnFiltro.Visible = true;
            }
            btnRechazar.Attributes.Add("onclick", "window.open('RechazarRecepcion.aspx?Cod=" + txtFolio.Text + "&usu="+Session["Usuario"].ToString()+"','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=830,height=800,left=210,top=80')");
            
        }

        protected void btnRecepcionar_Click(object sender, EventArgs e)
        {
            if (txtFolio.Text != "")
            {
                bool r = des.RecepcionEnc(txtFolio.Text, Session["Usuario"].ToString(), "", 1);
                if (r == true)
                {
                    divMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.Text = "Devolución Recepcionada Correctamente.";
                    lblMensaje.ForeColor = Color.White;
                    divMensaje.Attributes.Add("style", "background-color:Green");

                    btnRechazar.Visible = false;
                    btnRecepcionar.Enabled = false;
                }
            }
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecepcionarDevolucion.aspx?id=6&Cat=2");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecepcionarDevolucion.aspx?id=6&Cat=2");
        }



    }
}