using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloDespacho.View
{
    public partial class Ruta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'></script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }
    }
}