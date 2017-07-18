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
using System.Globalization;


namespace Intranet.ModuloAdministracion.View
{
    public partial class Consumo_MesOT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try { System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.UserLanguages[0]); }
                catch { System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL"); }
                CargarMesyAño();
                CargarDatos();

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
            ddlAño.Items.Add("Seleccione Año");
            for (int i = Convert.ToInt32(DateTime.Now.ToString("yyyy")); i >= 2013; i--)
            {
                ddlAño.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlAño.SelectedIndex = 1;
            #endregion
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
            string Mes = ddlMes.SelectedValue.ToString();
            string Año = ddlAño.SelectedValue.ToString();

            Controller_Consumo controlcons = new Controller_Consumo();
            
            if (Mes != "Seleccione Mes")
            {
                List<Cabecera> lista1 = controlcons.ListarConsumoMes(Mes, Año, 1);
                List<Cabecera> lista2 = controlcons.ListarConsumoMes(Mes, Año, 2);
                RadGridInforme.DataSource = lista1.Where(o => o.Id_Funcionalidad != "");
                RadGridInforme.DataBind();
                RadGridOtros.DataSource = lista2.Where(o => o.Id_Funcionalidad != "");
                RadGridOtros.DataBind();
                foreach (Cabecera cab in lista1.Where(o => o.Id_Funcionalidad == ""))
                {
                    lblOperacion.Text = cab.EmpId;
                    lblHoja.Text = cab.LlgDocNumDoc; 
                    lblPrecioHoja.Text = cab.LlgDocGlosa;
                    lblBobina.Text = cab.LlgDocFechaIng;
                    lblPrecioBob.Text = cab.LlgDocNumInterno;
                    lblKgTotal.Text = cab.IntPeriodo;
                    lblPrecioTotal.Text = cab.OpeCod;
                    lblFlPliego.Text = cab.DivCodigo;
                }

                foreach (Cabecera cab in lista2.Where(o => o.Id_Funcionalidad == ""))
                {
                    lblOperacion2.Text = cab.EmpId;
                    lblHoja2.Text = cab.LlgDocNumDoc; 
                    lblPrecioHoja2.Text = cab.LlgDocGlosa;
                    lblBobina2.Text = cab.LlgDocFechaIng;
                    lblPrecioBob2.Text = cab.LlgDocNumInterno;
                    lblKgTotal2.Text = cab.IntPeriodo;
                    lblPrecioTotal2.Text = cab.OpeCod;
                    lblFlPliego2.Text = cab.DivCodigo;
                }
            }
            else
            {
                RadGridInforme.DataSource = "";
                RadGridInforme.DataBind();
                RadGridOtros.DataSource = "";
                RadGridOtros.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string Mes = ddlMes.SelectedValue.ToString();
            string Año = ddlAño.SelectedValue.ToString();//"2014";

            Controller_Consumo controlcons = new Controller_Consumo();

            if (Mes != "Seleccionar")
            {
                List<Cabecera> lista1 = controlcons.ListarConsumoMes(Mes, Año, 1);
                List<Cabecera> lista2 = controlcons.ListarConsumoMes(Mes, Año, 2);
                List<Cabecera> listaFinal = lista1.Concat(lista2).ToList();

                GridView gv = new GridView();
                gv.DataSource = listaFinal;
                gv.DataBind();
                gv.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;


                gv.HeaderRow.Cells[0].Text = "OT";
                gv.HeaderRow.Cells[1].Text = "Nombre OT";
                gv.HeaderRow.Cells[2].Text = "Fl Pliego";
                gv.HeaderRow.Cells[3].Text = "Kg Hoja";
                gv.HeaderRow.Cells[4].Text = "$ Hoja";
                gv.HeaderRow.Cells[5].Text = "Kg Bobina";
                gv.HeaderRow.Cells[6].Text = "$ Bobina";
                gv.HeaderRow.Cells[7].Text = "Kg total";
                gv.HeaderRow.Cells[8].Text = "$ Total";
                gv.HeaderRow.Cells[9].Visible = false;
                gv.HeaderRow.Cells[10].Visible = false;
                gv.HeaderRow.Cells[11].Visible = false;
                gv.HeaderRow.Cells[12].Visible = false;
                gv.HeaderRow.Cells[13].Visible = false;
                gv.HeaderRow.Cells[14].Visible = false;
                gv.HeaderRow.Cells[15].Visible = false;
                gv.HeaderRow.Cells[16].Visible = false;
                gv.HeaderRow.Cells[17].Visible = false;
                gv.HeaderRow.Cells[18].Visible = false;
                gv.HeaderRow.Cells[19].Visible = false;
                gv.HeaderRow.Cells[20].Visible = false;
                gv.HeaderRow.Cells[21].Visible = false;
                gv.HeaderRow.Cells[22].Visible = false;
                gv.HeaderRow.Cells[23].Visible = false;
                gv.HeaderRow.Cells[24].Visible = false;
                gv.HeaderRow.Cells[25].Visible = false;
                gv.HeaderRow.Cells[26].Visible = false;
                gv.HeaderRow.Cells[27].Visible = false;
                gv.HeaderRow.Cells[28].Visible = false;
                gv.HeaderRow.Cells[29].Visible = false;
                gv.HeaderRow.Cells[30].Visible = false;
                gv.HeaderRow.Cells[31].Visible = false;
                gv.HeaderRow.Cells[32].Visible = false;
                gv.HeaderRow.Cells[33].Visible = false;
                gv.HeaderRow.Cells[34].Visible = false;
                gv.HeaderRow.Cells[35].Visible = false;
                gv.HeaderRow.Cells[36].Visible = false;
                gv.HeaderRow.Cells[37].Visible = false;

                for (int contador = 0; contador < gv.Rows.Count; contador++)
                {
                    GridViewRow row = gv.Rows[contador];
                    row.Cells[0].Text = row.Cells[1].Text;
                    if (row.Cells[2].Text != "Total Operacional" && row.Cells[2].Text != "Total Otros")
                    {
                        row.Cells[1].Text = row.Cells[2].Text;
                        row.Cells[2].Text = row.Cells[3].Text;
                        row.Cells[3].Text = row.Cells[10].Text;
                        row.Cells[4].Text = row.Cells[8].Text;
                        row.Cells[8].Text = row.Cells[7].Text;
                        row.Cells[7].Text = row.Cells[6].Text;
                        row.Cells[6].Text = row.Cells[9].Text;
                        
                    }
                    else
                    {
                        row.Cells[1].Text = "<div style='font-weight: bold;font-size:medium;'>" + row.Cells[2].Text + "</div>";
                        row.Cells[2].Text = "<div style='font-weight: bold;font-size:medium;'>" + row.Cells[3].Text + "</div>";
                        row.Cells[3].Text = "<div style='font-weight: bold;font-size:medium;'>" + row.Cells[10].Text + "</div>";
                        row.Cells[4].Text = "<div style='font-weight: bold;font-size:medium;'>" + row.Cells[8].Text + "</div>";
                        row.Cells[5].Text = "<div style='font-weight: bold;font-size:medium;'>" + row.Cells[5].Text + "</div>";
                        row.Cells[8].Text = "<div style='font-weight: bold;font-size:medium;'>" + row.Cells[7].Text + "</div>";
                        row.Cells[7].Text = "<div style='font-weight: bold;font-size:medium;'>" + row.Cells[6].Text + "</div>";
                        row.Cells[6].Text = "<div style='font-weight: bold;font-size:medium;'>" + row.Cells[9].Text + "</div>";
                        
                    }

                    //row.Cells[8].Visible = false;
                    row.Cells[9].Visible = false;
                    row.Cells[10].Visible = false;
                    row.Cells[11].Visible = false;
                    row.Cells[12].Visible = false;
                    row.Cells[13].Visible = false;
                    row.Cells[14].Visible = false;
                    row.Cells[15].Visible = false;
                    row.Cells[16].Visible = false;
                    row.Cells[17].Visible = false;
                    row.Cells[18].Visible = false;
                    row.Cells[19].Visible = false;
                    row.Cells[20].Visible = false;
                    row.Cells[21].Visible = false;
                    row.Cells[22].Visible = false;
                    row.Cells[23].Visible = false;
                    row.Cells[24].Visible = false;
                    row.Cells[25].Visible = false;
                    row.Cells[26].Visible = false;
                    row.Cells[27].Visible = false;
                    row.Cells[28].Visible = false;
                    row.Cells[29].Visible = false;
                    row.Cells[30].Visible = false;
                    row.Cells[31].Visible = false;
                    row.Cells[32].Visible = false;
                    row.Cells[33].Visible = false;
                    row.Cells[34].Visible = false;
                    row.Cells[35].Visible = false;
                    row.Cells[36].Visible = false;
                    row.Cells[37].Visible = false;
                }
                ExportToExcel("Consumo Mensual por OT " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), gv);
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

            string Titulo = "<div align='center'>Consumo Mensual por OT<br/>";
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