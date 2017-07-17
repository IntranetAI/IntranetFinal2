using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class ControlRecepcion : System.Web.UI.Page
    {
        Controller_InfDespacho cID = new Controller_InfDespacho();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar();
            }
        }
        public void Cargar()
        {
            DateTime vaa = DateTime.Now.AddDays(0);
            string fecha1 = vaa.ToString("MM-dd-yyyy");
            string fecha2 = fecha1;
            DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
            DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");


            RadGrid1.DataSource = cID.controlRecepcionPendientes("", "", FI, FT, 0);
            RadGrid1.DataBind();

            RadGrid2.DataSource = cID.controlRecepcionPendientes("", "", FI, FT, 2);
            RadGrid2.DataBind();
        }
        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
            {
                DateTime a = Convert.ToDateTime(txtFechaInicio.Text);
                string b = a.ToString("MM/dd/yyyy");
                DateTime c = Convert.ToDateTime(txtFechaTermino.Text);
                string d = c.ToString("MM/dd/yyyy");

                DateTime FI = Convert.ToDateTime(b + " 00:00:00");
                DateTime FT = Convert.ToDateTime(d + " 23:59:59");

                RadGrid1.DataSource = cID.controlRecepcionPendientes(txtOP.Text, txtNombreOP.Text, FI, FT, 0);

                RadGrid2.DataSource = cID.controlRecepcionPendientes(txtOP.Text, txtNombreOP.Text, FI, FT, 2);
            }
            else
            {
                DateTime FI = Convert.ToDateTime("1900-01-01 00:00:00");
                DateTime FT = Convert.ToDateTime("1900-01-01 23:59:59");

                RadGrid1.DataSource = cID.controlRecepcionPendientes(txtOP.Text, txtNombreOP.Text, FI, FT, 1);

                RadGrid2.DataSource = cID.controlRecepcionPendientes(txtOP.Text, txtNombreOP.Text, FI, FT, 3);

            }
            RadGrid1.DataBind();
            RadGrid2.DataBind();

        }

        protected void ibPDF_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}