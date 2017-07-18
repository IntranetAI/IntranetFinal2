using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Controller;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Pliegos_Impreso : System.Web.UI.Page
    {
        Bobina_Controller controlbo = new Bobina_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            RadGrid1.DataSource = "";
            RadGrid1.DataBind();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtOT.Text.Trim() != "")
            {
                RadGrid1.DataSource = controlbo.List_PliegosImp(txtOT.Text);
                RadGrid1.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}