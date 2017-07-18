using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;

namespace Intranet.ModuloWip.View
{
    public partial class Historial_Pallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller_WipControl ControlWip = new Controller_WipControl();
            string Codigo = Request.QueryString["not"];
            Label1.Text = ControlWip.Historial_Pallet(Codigo);
            Label2.Text = ControlWip.Historial_PalletDetalle(Codigo);
        }
    }
}