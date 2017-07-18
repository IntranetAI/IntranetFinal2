using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using Intranet.ModuloAdministracion.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloAdministracion.View
{
    public partial class EnvioFactura : System.Web.UI.Page
    {
        Controller_Factura cf = new Controller_Factura();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {

            if (txtFechaInicioEmision.Text != "" && txtFechaTerminoEmision.Text != "")
            {
                string[] str = txtFechaInicioEmision.Text.Split('/');
                string FechaIni = str[2] + "-" + str[1] + "-" + str[0];

                string[] str2 = txtFechaTerminoEmision.Text.Split('/');
                string FechaTer = str2[2] + "-" + str2[1] + "-" + str2[0];


                RadGrid1.DataSource = cf.Listar_FacturasEnviadas(txtRutEmisor.Text, txtNombreEmisor.Text, "", txtNombreItem.Text, FechaIni, FechaTer, 0);
                RadGrid1.DataBind();
               
            }
            else if (txtFolioDocInicio.Text != "" && txtFolioDocTermino.Text != "")
            {
                RadGrid1.DataSource = cf.Listar_FacturasEnviadas(txtRutEmisor.Text, txtNombreEmisor.Text, "", txtNombreItem.Text, txtFolioDocInicio.Text, txtFolioDocTermino.Text, 1);
                RadGrid1.DataBind();
            }
            else
            {
                RadGrid1.DataSource = cf.Listar_FacturasEnviadas(txtRutEmisor.Text, txtNombreEmisor.Text, "", txtNombreItem.Text, "", "", 2);
                RadGrid1.DataBind();
            }

            btnFiltro.Visible = true;

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            GridView GridView1 = new GridView();
            if(txtFolioDocInicio.Text!="" && txtFolioDocTermino.Text!="")
            {
                GridView1.DataSource = cf.Listar_FacturasEnviadasExcel(txtRutEmisor.Text, txtNombreEmisor.Text, "", txtNombreItem.Text, txtFolioDocInicio.Text, txtFolioDocTermino.Text, 4);
                GridView1.DataBind();
                //GridView1.HeaderRow.Cells[0].Text = "Nº OT";
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

                ExportToExcel("Informe Facturas Cliente", GridView1);

            }
            else if (txtFechaInicioEmision.Text != "" && txtFechaTerminoEmision.Text != "")
            {
                string[] str = txtFechaInicioEmision.Text.Split('/');
                string FechaIni = str[2] + "-" + str[1] + "-" + str[0];

                string[] str2 = txtFechaTerminoEmision.Text.Split('/');
                string FechaTer = str2[2] + "-" + str2[1] + "-" + str2[0];

                GridView1.DataSource = cf.Listar_FacturasEnviadasExcel(txtRutEmisor.Text, txtNombreEmisor.Text, "", txtNombreItem.Text, FechaIni, FechaTer, 5);
                GridView1.DataBind();
                //GridView1.HeaderRow.Cells[0].Text = "Nº OT";
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

                ExportToExcel("Informe Facturas Cliente", GridView1);
            }
            else
            {
                GridView1.DataSource = cf.Listar_FacturasEnviadasExcel(txtRutEmisor.Text, txtNombreEmisor.Text, "", txtNombreItem.Text, "", "", 6);
                GridView1.DataBind();
                //GridView1.HeaderRow.Cells[0].Text = "Nº OT";
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

                ExportToExcel("Informe Facturas Cliente", GridView1);
            }
        }
        private void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            la.Text = "<div align='center'>" + nameReport + "</div>";
           
            form.Controls.Add(la);
            form.Controls.Add(wControl);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport + ".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }

    }
}