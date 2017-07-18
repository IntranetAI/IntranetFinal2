using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using Intranet.ModuloAdministracion.Model;
using System.Web.Services;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Control_facturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaInicio.Text = DateTime.Now.AddDays(-2).ToString("dd-MM-yyyy");
                txtFechaTermino.Text = DateTime.Now.ToString("dd-MM-yyyy");
                cargarDatos(0);
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    cargarDatos(2);
                }
                else if (txtCliente.Text.Trim() != "" || txtNombreOT.Text.Trim() != "" || txtOT.Text.Trim() != "")
                {
                    cargarDatos(1);
                }
                else
                {
                    cargarDatos(1);
                }
            }
            else
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    cargarDatos(2);
                }
                else if (txtCliente.Text.Trim() != "" || txtNombreOT.Text.Trim() != "" || txtOT.Text.Trim() != "")
                {
                    cargarDatos(1);
                }
                else
                {
                    cargarDatos(0);
                }
            }
        }

        public void cargarDatos(int procedimiento)
        {
            Controller_Liquidacion controlliqui = new Controller_Liquidacion();
            string OT = txtOT.Text.ToString();
            string NombreOT = txtNombreOT.Text.ToString();
            string Cliente = txtCliente.Text.ToString();
            string FechaInicio = "";
            string FechaTermino = "";
            if (txtFechaInicio.Text.Trim() != "" && txtFechaTermino.Text.Trim() != "")
            {
                string[] str = txtFechaInicio.Text.Split('-');
                FechaInicio = str[2] + str[1] + str[0];

                string[] str2 = txtFechaTermino.Text.Split('-');
                FechaTermino = str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59";
                string MesInicio = "";
                if(str[1].Length==1)
                {
                    MesInicio = "0"+str[1];
                }
                else
                {
                    MesInicio = str[1];
                }
                string NombreMes = "";
                try { System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.UserLanguages[0]); }
                catch { System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL"); }
                NombreMes = Convert.ToDateTime(txtFechaInicio.Text).ToString("MMMM"); ;


                lblTotal.Text = controlliqui.TotalNetoFacturamesActual(MesInicio, str[2], NombreMes);
            }
            int EstadoOT = 2;
            if (CheckBox1.Checked)
            {
                EstadoOT-=1;
                procedimiento += 2;
            }
            RadGrid1.DataSource = controlliqui.ListarOTLiquidadas(OT, NombreOT, Cliente, FechaInicio, FechaTermino, EstadoOT, procedimiento);
            RadGrid1.DataBind();
        }

       
    }
}