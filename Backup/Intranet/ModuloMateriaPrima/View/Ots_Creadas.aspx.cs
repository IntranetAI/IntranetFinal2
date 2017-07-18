using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloMateriaPrima.View
{
    public partial class Ots_Creadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();

                RadGrid2.DataSource = "";
                RadGrid2.DataBind();

            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> Solicitud()</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
        }
    }
}