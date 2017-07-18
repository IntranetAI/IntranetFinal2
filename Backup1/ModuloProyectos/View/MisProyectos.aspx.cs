using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProyectos.Controller;

namespace Intranet.ModuloProyectos.View
{
    public partial class MisProyectos : System.Web.UI.Page
    {
        Controller_Proyectos cp = new Controller_Proyectos();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMisProyectos.Text = cp.Carga_MisProyectos(Request.QueryString["u"], "", "", 4);

            try
            {
                lblProyecto.Text = "Proyecto "+Request.QueryString["n"].ToUpper();
                divProyecto.Visible = true;
                RadGrid1.DataSource = cp.CargarGrillaProyecto(Request.QueryString["u"], Request.QueryString["n"], "", "", "", 0, 4);
                RadGrid1.DataBind(); 

               



            }
            catch
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                divProyecto.Visible = false;
            }
        }
    }
}