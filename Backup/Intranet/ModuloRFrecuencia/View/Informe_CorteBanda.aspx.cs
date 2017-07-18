using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Model;
using Intranet.ModuloRFrecuencia.Controller;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Informe_CorteBanda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                Bobina bob = new Bobina();
                cargardatos(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), bob);
            }
        }

        public void cargardatos(string FechaRangoMin, string FechaRangoMax, Bobina bobina)
        {
            Bobina_Controller controlbob = new Bobina_Controller();
            RadGrid1.DataSource = controlbob.Listar_Informe_fallaCorte(bobina, FechaRangoMin, FechaRangoMax);
            RadGrid1.DataBind();
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            Bobina bob = new Bobina();
            string FechaInicio = "";
            string FechaTermino = "";
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('-');
                FechaInicio = str[2] + "-" + str[1] + "-" + str[0];
                string[] str2 = txtFechaTermino.Text.Split('-');
                FechaTermino = str2[2] + "-" + str2[1] + "-" + str2[0];
            }
            bob.NumeroOp = txtNumeroOT.Text.ToString().Trim();
            bob.Codigo = txtCodigoBob.Text.ToString().Trim();

            if (ddlCategoria.SelectedItem.Text != "Todas")
            {
                bob.Marca = ddlCategoria.SelectedItem.Text.ToString();
            }
            else
            {
                bob.Marca = "";
            }
            if (ddlMaquina.SelectedItem.Text != "Todas")
            {
                bob.Lote = ddlMaquina.SelectedItem.Text.ToString();
            }
            else
            {
                bob.Lote = "";
            }
            cargardatos(FechaInicio, FechaTermino, bob);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            PanelFiltro.Visible = false;
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            PanelFiltro.Visible = true;
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            Bobina_Controller controlbob = new Bobina_Controller();
            Bobina bob = new Bobina();
            string FechaInicio = "";
            string FechaTermino = "";
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('-');
                FechaInicio = str[2] + "-" + str[1] + "-" + str[0];
                string[] str2 = txtFechaTermino.Text.Split('-');
                FechaTermino = str2[2] + "-" + str2[1] + "-" + str2[0];
            }
            bob.NumeroOp = txtNumeroOT.Text.ToString().Trim();
            bob.Codigo = txtCodigoBob.Text.ToString().Trim();

            if (ddlCategoria.SelectedItem.Text != "Todas")
            {
                bob.Marca = ddlCategoria.SelectedItem.Text.ToString();
            }
            else
            {
                bob.Marca = "";
            }
            if (ddlMaquina.SelectedItem.Text != "Todas")
            {
                bob.Lote = ddlMaquina.SelectedItem.Text.ToString();
            }
            else
            {
                bob.Lote = "";
            }
            List<Bobina> lista = controlbob.Listar_Informe_fallaCorte(bob, FechaInicio, FechaTermino);
            GridView GridView1 = new GridView();
            GridView1.DataSource = lista;
            GridView1.DataBind();
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

            GridView1.HeaderRow.Cells[0].Text = "Maquina";
            GridView1.HeaderRow.Cells[1].Text = "OTs";
            GridView1.HeaderRow.Cells[2].Text = "Pliegos";
            GridView1.HeaderRow.Cells[3].Text = "Categoria";
            GridView1.HeaderRow.Cells[4].Text = "Motivo";
            GridView1.HeaderRow.Cells[5].Text = "Cod. Bob. ";
            GridView1.HeaderRow.Cells[6].Text = "Tipo Bob.";
            GridView1.HeaderRow.Cells[7].Text = "Marca";
            GridView1.HeaderRow.Cells[8].Text = "Proveedor";
            GridView1.HeaderRow.Cells[9].Text = "Gr.";
            GridView1.HeaderRow.Cells[10].Text = "Ancho";
            GridView1.HeaderRow.Cells[11].Text = "Fecha";
            GridView1.HeaderRow.Cells[12].Visible = false;
            GridView1.HeaderRow.Cells[13].Visible = false;
            GridView1.HeaderRow.Cells[14].Visible = false;
            GridView1.HeaderRow.Cells[15].Visible = false;
            GridView1.HeaderRow.Cells[16].Visible = false;
            GridView1.HeaderRow.Cells[17].Visible = false;
            GridView1.HeaderRow.Cells[18].Visible = false;
            GridView1.HeaderRow.Cells[19].Visible = false;
            GridView1.HeaderRow.Cells[20].Visible = false;
            GridView1.HeaderRow.Cells[21].Visible = false;
            GridView1.HeaderRow.Cells[22].Visible = false;
            GridView1.HeaderRow.Cells[23].Visible = false;
            GridView1.HeaderRow.Cells[24].Visible = false;
            GridView1.HeaderRow.Cells[25].Visible = false;
            GridView1.HeaderRow.Cells[26].Visible = false;
            GridView1.HeaderRow.Cells[27].Visible = false;

            for (int contador = 0; contador < GridView1.Rows.Count; contador++)
            {
                GridViewRow row = GridView1.Rows[contador];
                string once = row.Cells[11].Text;
                row.Cells[11].Text = row.Cells[0].Text;
                row.Cells[0].Text = row.Cells[26].Text;
                row.Cells[10].Text = row.Cells[4].Text;
                row.Cells[4].Text = row.Cells[1].Text;
                row.Cells[1].Text = once;
                row.Cells[2].Text = row.Cells[22].Text;
                row.Cells[9].Text = row.Cells[3].Text;
                row.Cells[3].Text = row.Cells[24].Text;
                string cinco = row.Cells[7].Text;
                row.Cells[7].Text = row.Cells[5].Text;
                row.Cells[5].Text = cinco;
                row.Cells[8].Text = row.Cells[25].Text;
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
            }

            ExportToExcel("Falla Corte Banda" + FechaInicio, GridView1);
        }

        private void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe Falla Corte<br/>";
            if (txtNumeroOT.Text != "")
            {
                Titulo = Titulo + " OT = " + txtNumeroOT.Text;
            }
            if (txtCodigoBob.Text != "")
            {
                Titulo = Titulo + " Codigo Bob. = " + txtCodigoBob.Text;
            }
            if (ddlCategoria.SelectedItem.Text != "Todas")
            {
                Titulo = Titulo + " Categoria = " + ddlCategoria.SelectedItem.Text;
            }
            if (ddlMaquina.SelectedValue != "Todas")
            {
                Titulo = Titulo + " Maquina = " + ddlMaquina.SelectedValue;
            }
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                Titulo = Titulo + " Rango de Fechas: Desde: " + txtFechaInicio.Text + " Hasta " + txtFechaTermino.Text;
            }
            Titulo = Titulo + " </div><br />";
            la.Text = Titulo;

            form.Controls.Add(la);
            form.Controls.Add(wControl);
            pageToRender.Controls.Add(form);
            pageToRender.EnableEventValidation = false;//Solo cuando Tienes un Boolean
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

        public void CargarCategorias()
        {
            Bobina_Controller controlBob = new Bobina_Controller();
            ddlCategoria.DataSource = controlBob.ListarOrigenesCorte();
            ddlCategoria.DataTextField = "Lote";
            ddlCategoria.DataValueField = "Lote";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Todas", "Todas"));
        }
    }
}