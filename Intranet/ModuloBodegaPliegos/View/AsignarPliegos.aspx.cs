using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class AsignarPliegos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RadGrid1.DataSource = "";
            RadGrid1.DataBind();

            RadGrid2.DataSource = "";
            RadGrid2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> javascript:window.close();  </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> javascript:window.close();  </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> javascript:window.close();  </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }
    }
}