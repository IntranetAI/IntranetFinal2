using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Intranet.ModuloAdministracion.Controller;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Inf_Mens_StockPeriodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMesyAño();
                RadGridInsumo.DataSource = "";
                RadGridInsumo.DataBind();
            }
        }

        public void CargarMesyAño()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.UserLanguages[0]);
            }
            catch { System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL"); }
            #region Mes
            ddlMes.Items.Add("Seleccione Mes");

            List<string> nombreMes = DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToList();
            var listaMesesSeleccionados = nombreMes.Select(m => new
            {
                Id = nombreMes.IndexOf(m) + 1,
                Name = m
            });

            foreach (var mes in listaMesesSeleccionados)
            {
                this.ddlMes.Items.Add(new ListItem(mes.Name, mes.Id.ToString()));
            }
            #endregion
            #region Año
            ddlAnos.Items.Add("Seleccione Año");
            for (int i = 2013; i <= Convert.ToInt32(DateTime.Now.ToString("yyyy")); i++)
            {
                ddlAnos.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            #endregion
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if ((ddlMes.SelectedItem.Text.ToString() != "Seleccione Mes") && (ddlAnos.SelectedItem.Text.ToString() != "Seleccione Año") && (ddlInforme.SelectedItem.Text.ToString() != "Seleccionar Informe"))
            {
                string mes = ddlMes.SelectedValue.ToString();
                string Año = ddlAnos.SelectedItem.Text.ToString();
                string Informe = ddlInforme.SelectedValue.ToString();
                Controller_StockxPeriodo control = new Controller_StockxPeriodo();
                RadGridInsumo.DataSource = control.ListarStock(Convert.ToInt32(mes), Convert.ToInt32(Año), Informe);
                RadGridInsumo.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            GridView gv = new GridView();
            if ((ddlMes.SelectedItem.Text.ToString() != "Seleccione Mes") && (ddlAnos.SelectedItem.Text.ToString() != "Seleccione Año") && (ddlInforme.SelectedItem.Text.ToString() != "Seleccionar Informe"))
            {
                string mes = ddlMes.SelectedValue.ToString();
                string Año = ddlAnos.SelectedItem.Text.ToString();
                string Informe = ddlInforme.SelectedValue.ToString();
                Controller_StockxPeriodo control = new Controller_StockxPeriodo();
                gv.DataSource = control.ListarStock(Convert.ToInt32(mes), Convert.ToInt32(Año), Informe);
                gv.DataBind();
                gv.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;
                gv.HeaderRow.Cells[0].Text = "Cod. Item";
                gv.HeaderRow.Cells[1].Text = "Descripción";

                if (Informe == "Tintas")
                {
                    gv.HeaderRow.Cells[4].Visible = false;
                    gv.HeaderRow.Cells[5].Visible = false;
                    gv.HeaderRow.Cells[6].Visible = false;
                    gv.HeaderRow.Cells[11].Visible = false;
                    gv.HeaderRow.Cells[13].Visible = false;
                    gv.HeaderRow.Cells[14].Visible = false;
                    gv.HeaderRow.Cells[21].Visible = false;
                    gv.HeaderRow.Cells[22].Visible = false;
                    gv.HeaderRow.Cells[23].Visible = false;
                    gv.HeaderRow.Cells[24].Visible = false;
                    gv.HeaderRow.Cells[25].Visible = false;
                    gv.HeaderRow.Cells[28].Visible = false;
                    gv.HeaderRow.Cells[30].Visible = false;
                    gv.HeaderRow.Cells[31].Visible = false;
                    gv.HeaderRow.Cells[32].Visible = false;
                    gv.HeaderRow.Cells[33].Visible = false;
                    gv.HeaderRow.Cells[34].Visible = false;
                    gv.HeaderRow.Cells[35].Visible = false;
                    gv.HeaderRow.Cells[36].Visible = false;
                    gv.HeaderRow.Cells[37].Visible = false;
                    gv.HeaderRow.Cells[38].Visible = false;

                    for (int contador = 0; contador < gv.Rows.Count; contador++)
                    {
                        GridViewRow row = gv.Rows[contador];
                        row.Cells[4].Visible = false;
                        row.Cells[5].Visible = false;
                        row.Cells[6].Visible = false;
                        row.Cells[11].Visible = false;
                        row.Cells[13].Visible = false;
                        row.Cells[14].Visible = false;
                        row.Cells[21].Visible = false;
                        row.Cells[22].Visible = false;
                        row.Cells[23].Visible = false;
                        row.Cells[24].Visible = false;
                        row.Cells[25].Visible = false;
                        row.Cells[28].Visible = false;
                        row.Cells[30].Visible = false;
                        row.Cells[31].Visible = false;
                        row.Cells[32].Visible = false;
                        row.Cells[33].Visible = false;
                        row.Cells[34].Visible = false;
                        row.Cells[35].Visible = false;
                        row.Cells[36].Visible = false;
                        row.Cells[37].Visible = false;
                        row.Cells[38].Visible = false;

                    }
                }
                else if (Informe == "Insumos")
                {
                    gv.HeaderRow.Cells[3].Visible = false;
                    gv.HeaderRow.Cells[4].Visible = false;
                    gv.HeaderRow.Cells[5].Visible = false;
                    gv.HeaderRow.Cells[6].Visible = false;
                    gv.HeaderRow.Cells[11].Visible = false;
                    gv.HeaderRow.Cells[13].Visible = false;
                    gv.HeaderRow.Cells[21].Visible = false;
                    gv.HeaderRow.Cells[22].Visible = false;
                    gv.HeaderRow.Cells[23].Visible = false;
                    gv.HeaderRow.Cells[24].Visible = false;
                    gv.HeaderRow.Cells[28].Visible = false;
                    gv.HeaderRow.Cells[30].Visible = false;
                    gv.HeaderRow.Cells[31].Visible = false;
                    gv.HeaderRow.Cells[32].Visible = false;
                    gv.HeaderRow.Cells[33].Visible = false;
                    gv.HeaderRow.Cells[34].Visible = false;
                    gv.HeaderRow.Cells[35].Visible = false;

                    for (int contador = 0; contador < gv.Rows.Count; contador++)
                    {
                        GridViewRow row = gv.Rows[contador];
                        row.Cells[3].Visible = false;
                        row.Cells[4].Visible = false;
                        row.Cells[5].Visible = false;
                        row.Cells[6].Visible = false;
                        row.Cells[11].Visible = false;
                        row.Cells[13].Visible = false;
                        row.Cells[21].Visible = false;
                        row.Cells[22].Visible = false;
                        row.Cells[23].Visible = false;
                        row.Cells[24].Visible = false;
                        row.Cells[28].Visible = false;
                        row.Cells[30].Visible = false;
                        row.Cells[31].Visible = false;
                        row.Cells[32].Visible = false;
                        row.Cells[33].Visible = false;
                        row.Cells[34].Visible = false;
                        row.Cells[35].Visible = false;

                    }
                }
                else if (Informe == "Pliegos")
                {
                    gv.HeaderRow.Cells[11].Visible = false;
                    gv.HeaderRow.Cells[12].Visible = false;
                    gv.HeaderRow.Cells[13].Visible = false;
                    gv.HeaderRow.Cells[21].Visible = false;
                    gv.HeaderRow.Cells[22].Visible = false;
                    gv.HeaderRow.Cells[23].Visible = false;
                    gv.HeaderRow.Cells[24].Visible = false;
                    gv.HeaderRow.Cells[28].Visible = false;
                    gv.HeaderRow.Cells[36].Visible = false;
                    gv.HeaderRow.Cells[37].Visible = false;
                    gv.HeaderRow.Cells[38].Visible = false;

                    for (int contador = 0; contador < gv.Rows.Count; contador++)
                    {
                        GridViewRow row = gv.Rows[contador];
                        row.Cells[11].Visible = false;
                        row.Cells[12].Visible = false;
                        row.Cells[13].Visible = false;
                        row.Cells[21].Visible = false;
                        row.Cells[22].Visible = false;
                        row.Cells[23].Visible = false;
                        row.Cells[24].Visible = false;
                        row.Cells[28].Visible = false;
                        row.Cells[36].Visible = false;
                        row.Cells[37].Visible = false;
                        row.Cells[38].Visible = false;

                    }
                }
                else if (Informe == "Bobinas")
                {
                    gv.HeaderRow.Cells[23].Visible = false;
                    gv.HeaderRow.Cells[24].Visible = false;
                    gv.HeaderRow.Cells[30].Visible = false;
                    gv.HeaderRow.Cells[31].Visible = false;
                    gv.HeaderRow.Cells[32].Visible = false;
                    gv.HeaderRow.Cells[33].Visible = false;
                    gv.HeaderRow.Cells[34].Visible = false;
                    gv.HeaderRow.Cells[35].Visible = false;
                    gv.HeaderRow.Cells[36].Visible = false;
                    gv.HeaderRow.Cells[37].Visible = false;
                    gv.HeaderRow.Cells[38].Visible = false;

                    for (int contador = 0; contador < gv.Rows.Count; contador++)
                    {
                        GridViewRow row = gv.Rows[contador];
                        row.Cells[23].Visible = false;
                        row.Cells[24].Visible = false;
                        row.Cells[30].Visible = false;
                        row.Cells[31].Visible = false;
                        row.Cells[32].Visible = false;
                        row.Cells[33].Visible = false;
                        row.Cells[34].Visible = false;
                        row.Cells[35].Visible = false;
                        row.Cells[36].Visible = false;
                        row.Cells[37].Visible = false;
                        row.Cells[38].Visible = false;
                    }
                }
                else if (Informe == "Planchas")
                {
                    gv.HeaderRow.Cells[4].Visible = false;
                    gv.HeaderRow.Cells[5].Visible = false;
                    gv.HeaderRow.Cells[6].Visible = false;
                    gv.HeaderRow.Cells[11].Visible = false;
                    gv.HeaderRow.Cells[13].Visible = false;
                    gv.HeaderRow.Cells[21].Visible = false;
                    gv.HeaderRow.Cells[22].Visible = false;
                    gv.HeaderRow.Cells[23].Visible = false;
                    gv.HeaderRow.Cells[24].Visible = false;
                    gv.HeaderRow.Cells[28].Visible = false;
                    gv.HeaderRow.Cells[30].Visible = false;
                    gv.HeaderRow.Cells[31].Visible = false;
                    gv.HeaderRow.Cells[32].Visible = false;
                    gv.HeaderRow.Cells[33].Visible = false;
                    gv.HeaderRow.Cells[34].Visible = false;
                    gv.HeaderRow.Cells[35].Visible = false;
                    gv.HeaderRow.Cells[36].Visible = false;
                    gv.HeaderRow.Cells[37].Visible = false;
                    gv.HeaderRow.Cells[38].Visible = false;

                    for (int contador = 0; contador < gv.Rows.Count; contador++)
                    {
                        GridViewRow row = gv.Rows[contador];
                        row.Cells[4].Visible = false;
                        row.Cells[5].Visible = false;
                        row.Cells[6].Visible = false;
                        row.Cells[11].Visible = false;
                        row.Cells[13].Visible = false;
                        row.Cells[21].Visible = false;
                        row.Cells[22].Visible = false;
                        row.Cells[23].Visible = false;
                        row.Cells[24].Visible = false;
                        row.Cells[28].Visible = false;
                        row.Cells[30].Visible = false;
                        row.Cells[31].Visible = false;
                        row.Cells[32].Visible = false;
                        row.Cells[33].Visible = false;
                        row.Cells[34].Visible = false;
                        row.Cells[35].Visible = false;
                        row.Cells[36].Visible = false;
                        row.Cells[37].Visible = false;
                        row.Cells[38].Visible = false;
                    }
                }
                ExportToExcel("Informe Stock de " + Informe +" "+ DateTime.Now.ToString("dd-MM-yyyy HH:mm"), gv, ddlMes.SelectedItem.Text.ToString(), Año, ddlInforme.SelectedItem.Text.ToString());
            }
            
        }

        private void ExportToExcel(string nameReport, GridView wControl, string Mes, string Año, string Informe)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe "+Informe+" Stock por Periodo<br/>De : "+Mes+" del "+Año;
            la.Text = Titulo + "</div><br />";

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