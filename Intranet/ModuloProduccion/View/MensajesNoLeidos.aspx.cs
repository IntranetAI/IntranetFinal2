using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class MensajesNoLeidos : System.Web.UI.Page
    {
        OrdenController c = new OrdenController();
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Request.QueryString["id"];
            string fi = Request.QueryString["fi"];
            string ft = Request.QueryString["ft"];
            DateTime f=Convert.ToDateTime("1900-01-01");

            if (fi != "SinFecha" && ft != "SinFecha")
            {
                Label1.Text = c.ListaOTMensajes("", "", "", Convert.ToDateTime(fi), Convert.ToDateTime(ft), 1, a, 12);
            }
            else
            {
                Label1.Text = c.ListaOTMensajes("", "", "", f, f, 1, Request.QueryString["id"], 10);
            }

           

        }
    }
}