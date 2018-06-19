using ServicioWeb.ModuloProduccion.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        PapelController pc = new PapelController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = pc.StockFL(DateTime.Now, DateTime.Now);
        }
    }
}