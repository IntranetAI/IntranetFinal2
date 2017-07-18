using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloJefatura.View
{
    public partial class masterJefatura : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string nombre = Session["Nombre"].ToString();
                string[] str = nombre.Split(' ');
                string nom = str[0] + " " + str[2];
                lblNombreUsuario.Text = "Bienvenido Sr(a): " + nom;
                lblTitulo.Text = "Jefatura";
            }
        }

        protected void ibCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear();
            Response.Redirect("http://Intranet.qgchile.cl");
        }
    }
}