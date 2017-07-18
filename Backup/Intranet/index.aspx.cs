using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.View.Controller;

namespace Intranet
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Controller_Conexion cCon = new Controller_Conexion();
                cCon.CerrarConexion(Session["Usuario"].ToString());
                Session.RemoveAll();
                Response.Redirect("/View/Login.aspx");
            }
            catch
            {
                Response.Redirect("/View/Login.aspx");
            }
            
        }
    }
}