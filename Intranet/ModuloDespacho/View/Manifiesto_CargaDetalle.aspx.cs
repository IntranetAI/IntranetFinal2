using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloDespacho.View
{
    public partial class Manifiesto_CargaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OT = Request.QueryString["OT"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string OT = Request.QueryString["OT"].ToString();
            string popupScript4 = "<script language='JavaScript'>window.opener.location='Manifiesto_Carga.aspx?id=8&Cat=6&idc=" + OT + "';window.close();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript4);
        }
    }
}