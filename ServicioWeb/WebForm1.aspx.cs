using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioWeb.ModuloProduccion.Controller;

namespace ServicioWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ProduccionController pc = new ProduccionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = DateTime.Now.AddDays(-8).ToString() + "<BR/><BR/><BR/>" + DateTime.Now.AddDays(-14); //pc.Produccion_CorreoComparativo_ConsumoBobinas(DateTime.Now, DateTime.Now, 0);
          //  Label1.Text = (Convert.ToInt32(12)).ToString("00");
        }
    }
}