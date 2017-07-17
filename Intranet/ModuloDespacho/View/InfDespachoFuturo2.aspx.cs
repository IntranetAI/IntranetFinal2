using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;

namespace Intranet.ModuloDespacho.View
{
    public partial class InfDespachoFuturo2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnFiltro_Click1(this,e);
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            Controller_FechasDistribucion controlFechas = new Controller_FechasDistribucion();
            string OT = txtOT.Text.Trim();
            string NombreOT = txtNombreOT.Text.Trim();
            string Cliente = txtCliente.Text.Trim();
            List<FechasDistribucion> lista = new List<FechasDistribucion>();
            if ((txtFechaInicio.Text != "") && (txtFechaTermino.Text != "") && ((txtOT.Text != "") || (txtNombreOT.Text != "") || (txtCliente.Text != "")))
            {

                
                try
                {
                    string[] splitInicio = txtFechaInicio.Text.Split('/');
                    string[] splitTermino = txtFechaTermino.Text.Split('/');
                    lista = controlFechas.ListarDespachosaEntregar(OT, NombreOT, Cliente, splitInicio[2] + "-" + splitInicio[1] + "-" + splitInicio[0], splitTermino[2] + "-" + splitTermino[1] + "-" + splitTermino[0]);


                    
                }
                catch
                {

                    lista = controlFechas.ListarDespachosaEntregar(OT,NombreOT,Cliente, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(50).ToString("yyyy-MM-dd") + " 23:59:59");
                }
            }
            else if ((txtFechaInicio.Text == "") && (txtFechaTermino.Text == "") && ((txtOT.Text != "") || (txtNombreOT.Text != "") || (txtCliente.Text != "")))
            {
                lista = controlFechas.ListarDespachosaEntregar(OT, NombreOT, Cliente, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(200).ToString("yyyy-MM-dd") + " 23:59:59");
            }
            else
            {
                lista = controlFechas.ListarDespachosaEntregar("", "", "", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");

                txtFechaInicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtFechaTermino.Text = DateTime.Now.ToString("dd/MM/yyyy");
                
            }
            lblTabla.Text = TablaInforme_V2(lista);

            string popupScript = "<script language='JavaScript'>divPiePagina();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel("Reporte Fechas Distribucion", lblTabla.Text, txtFechaInicio.Text, txtFechaTermino.Text);
            string popupScript = "<script language='JavaScript'>divPiePagina();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        private void ExportToExcel(string nameReport, string Tabla, string fInicio, string fTermino)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>INFORME DESPACHO DISTRIBUCIÓN<br/>";
            if (fInicio != "") { Titulo += " Fecha : " + fInicio + " a " + fTermino; }
            la.Text = Titulo + "</div><br />";

            form.Controls.Add(la);

            Label TablaTotal = new Label();
            TablaTotal.Text = Tabla;
            form.Controls.Add(TablaTotal);


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

        public string TablaInforme_V2(List<FechasDistribucion> lista)
        {
            #region EncabezadoyVariables
            string Tabla = "<table style='width: 100%;' class='table table-hover table-bordered table-striped'>" +
                            "<thead><tr class='filters'>" +
                        "<th>OT</th>" +
                        "<th>Nombre OT</th>" +
                        "<th>Cliente</th>" +
                        "<th>Tiraje</th>" +
                        "<th>Cant. a Despachar</th>" +
                        "<th>Cant. Desp.</th>" +
                        "<th>Total Desp.</th>" +
                        "<th>Fecha Entrega</th>" +
                        "<th>Despachada</th>" +
                    "</tr>" +
                "</thead>";
          
          
            #endregion
            #region Datos
            foreach (FechasDistribucion dtDis in lista)
            {
                Tabla += "<tr><td><a href='javascript:DetalleOT(\"" + dtDis.OT +"\")'>" + dtDis.OT + "</a></td><td>" + dtDis.NombreOT + "</td><td>" + dtDis.Cliente + "</td><td style='text-align:right;'>" + dtDis.Tiraje + "</td>" +
                         "<td style='text-align:right;'>" + dtDis.TirajeGenerado + "</td><td style='text-align:right;'>" + dtDis.tirajeAcumulado + "</td><td style='text-align:right;'>" + dtDis.TotalDespachado + "</td>" +
                         "<td>"+dtDis.FechaDes+"</td><td>"+dtDis.Despachado+"</td></tr>";
            }
            #endregion
            return Tabla;
        }
    }
}