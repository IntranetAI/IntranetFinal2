using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloUsuario.Controller;

namespace Intranet.ModuloUsuario.View
{
    public partial class ImprimirMensajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = Request.QueryString["OT"];
            
            string OT=Request.QueryString["s"];

            Mail_Controller controlm = new Mail_Controller();
            lblCargaMensaje.Text = controlm.listarMensajesintentoImprimir(OT, "", 1);//forma asc
        }
    }
}