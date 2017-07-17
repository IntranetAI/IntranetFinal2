using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloAdministracion.View
{
    public partial class RecepcionFactura : System.Web.UI.Page
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
          //  año.mes.dia
            string Rut = txtRutEmisor.Text;
            string NombreEmisor = txtNombreEmisor.Text;
            string Folio = txtFolioDoc.Text;
            string NombreItem = txtNombreItem.Text;

            if (txtFechaInicioEmision.Text != "" && txtFechaTerminoEmision.Text != "")
            {
                string[] str = txtFechaInicioEmision.Text.Split('/');
                string FechaInicioEmision = str[2] + "-" + str[1] + "-" + str[0];

                string[] str2 = txtFechaTerminoEmision.Text.Split('/');
                string FechaTerminoEmision = str2[2] + "-" + str2[1] + "-" + str2[0];


                RadGrid1.DataSource = cf.Listar_Facturas(Rut, NombreEmisor, Folio, NombreItem, FechaInicioEmision, FechaTerminoEmision, "", "", 0);
                RadGrid1.DataBind();
            }
            else if (txtFechaInicioVen.Text != "" && txtFechaTerminoVen.Text != "")
            {
                string[] str3 = txtFechaInicioVen.Text.Split('/');
                string FechaInicioVen = str3[2] + "-" + str3[1] + "-" + str3[0];

                string[] str4 = txtFechaTerminoVen.Text.Split('/');
                string FechaTerminoVen = str4[2] + "-" + str4[1] + "-" + str4[0];
                RadGrid1.DataSource = cf.Listar_Facturas(Rut, NombreEmisor, Folio, NombreItem, "", "", FechaInicioVen, FechaTerminoVen, 1);
                RadGrid1.DataBind();
            }
            else 
            {
                RadGrid1.DataSource = cf.Listar_Facturas(Rut, NombreEmisor, Folio, NombreItem, "", "", "", "", 2); 
                RadGrid1.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            GridView GridView1 = new GridView();
            string Rut = txtRutEmisor.Text;
            string NombreEmisor = txtNombreEmisor.Text;
            string Folio = txtFolioDoc.Text;
            string NombreItem = txtNombreItem.Text;

            if (txtFechaInicioEmision.Text != "" && txtFechaTerminoEmision.Text != "")
            {
                string[] str = txtFechaInicioEmision.Text.Split('/');
                string FechaInicioEmision = str[2] + "-" + str[1] + "-" + str[0];

                string[] str2 = txtFechaTerminoEmision.Text.Split('/');
                string FechaTerminoEmision = str2[2] + "-" + str2[1] + "-" + str2[0];


                GridView1.DataSource = cf.Listar_FacturasExcel(Rut, NombreEmisor, Folio, NombreItem, FechaInicioEmision, FechaTerminoEmision, "", "", 4);
                GridView1.DataBind();
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                ExportToExcel("Informe Facturas Proveedor", GridView1);
            }
            else if (txtFechaInicioVen.Text != "" && txtFechaTerminoVen.Text != "")
            {
                string[] str3 = txtFechaInicioVen.Text.Split('/');
                string FechaInicioVen = str3[2] + "-" + str3[1] + "-" + str3[0];

                string[] str4 = txtFechaTerminoVen.Text.Split('/');
                string FechaTerminoVen = str4[2] + "-" + str4[1] + "-" + str4[0];
                GridView1.DataSource = cf.Listar_FacturasExcel(Rut, NombreEmisor, Folio, NombreItem, "", "", FechaInicioVen, FechaTerminoVen, 5);
                GridView1.DataBind();
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                ExportToExcel("Informe Facturas Proveedor", GridView1);
            }
            else
            {
                GridView1.DataSource = cf.Listar_FacturasExcel(Rut, NombreEmisor, Folio, NombreItem, "", "", "", "", 6);
                GridView1.DataBind();
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                ExportToExcel("Informe Facturas Proveedor", GridView1);
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