using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;

namespace Intranet.ModuloWip.View
{
    public partial class Menu : System.Web.UI.Page
    {
        Controller_Conexion Ccon = new Controller_Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != "")
            {
                lblNombre.Text = Request.QueryString["id"];
                lblTipo.Text = Request.QueryString["Tipo"];

                if (Request.QueryString["Tipo"] == "WIP")
                {
                    pnlWip.Visible = true;
                    pnlBP.Visible = false;
                }
                else
                {
                    pnlWip.Visible = false;
                    pnlBP.Visible = true;
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Ccon.CerrarConexion(lblNombre.Text);


            Session.RemoveAll();
            Response.Redirect("http://Mobile.qgchile.cl");
        }

        protected void btnConsumo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ajustar_Pallet.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Eliminar_Pallet.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../ModuloBodegaPliegos/View/Asignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../ModuloBodegaPliegos/View/reasignar_Ubicacion.aspx?id=" + lblNombre.Text + "&tipo=" + lblTipo.Text);
        }
    }
}