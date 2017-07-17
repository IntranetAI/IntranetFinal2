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
    public partial class Update_Bob : System.Web.UI.Page
    {
        public static List<Bobina> lista;
        Bobina_Controller control_Bob = new Bobina_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarBob(0);
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            CargarBob(1);
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            string f1 = "";
            string f2 = "";
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                string fechaInicio = mes + "/" + dia + "/" + año;

                f1 = fechaInicio;//Convert.ToDateTime(fechaInicio);

                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año = año.Substring(0, 4);

                string fechaTermino = mes2 + "/" + dia2 + "/" + año2;

                f2 = fechaTermino;// Convert.ToDateTime(txtFechaTermino.Text);//fechaTermino);
            }
            else
            {
                f1 = DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy");
                f2 = DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy");

            }

            GridView GridView1 = new GridView();
            GridView1.DataSource = lista;
            GridView1.DataBind();
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

            GridView1.HeaderRow.Cells[0].Text = "Maquina";
            GridView1.HeaderRow.Cells[1].Text = "OTs";
            GridView1.HeaderRow.Cells[2].Text = "N° Bob.";
            GridView1.HeaderRow.Cells[3].Text = "Pliegos";
            GridView1.HeaderRow.Cells[4].Text = "Marca";
            GridView1.HeaderRow.Cells[5].Text = "Ancho";
            GridView1.HeaderRow.Cells[6].Text = "Gr";
            GridView1.HeaderRow.Cells[7].Text = "P. Bruto";
            GridView1.HeaderRow.Cells[8].Text = "P. Tapa";
            GridView1.HeaderRow.Cells[9].Text = "P. Envoltura";
            GridView1.HeaderRow.Cells[10].Text = "P. Escarpe";
            GridView1.HeaderRow.Cells[11].Text = "P. Cono";
            GridView1.HeaderRow.Cells[12].Text = "Saldo";
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
                row.Cells[12].Text = row.Cells[2].Text;
                row.Cells[2].Text = row.Cells[7].Text;
                row.Cells[7].Text = row.Cells[1].Text;
                row.Cells[1].Text = row.Cells[11].Text;
                row.Cells[10].Text = row.Cells[6].Text;
                row.Cells[6].Text = row.Cells[3].Text;
                if (row.Cells[22].Text != "&amp;nbsp;")
                {
                    row.Cells[3].Text = row.Cells[22].Text;
                }
                else
                {
                    row.Cells[3].Text = "";
                }
                string cuatro = row.Cells[4].Text;
                row.Cells[4].Text = row.Cells[5].Text;
                row.Cells[5].Text = cuatro;
                row.Cells[8].Text = row.Cells[25].Text;
                row.Cells[9].Text = row.Cells[23].Text;
                row.Cells[11].Text = row.Cells[27].Text;
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

            ExportToExcel("Control Consumo" + f1, GridView1);
        }

        private void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe Control Consumo <br/>";
            if (txtNumeroOT.Text != "")
            {
                Titulo = Titulo + " OT = " + txtNumeroOT.Text;
            }
            if (txtCodigoBob.Text != "")
            {
                Titulo = Titulo + " Codigo Bob. = " + txtCodigoBob.Text;
            }
            if (txtTipPapel.Text != "")
            {
                Titulo = Titulo + " Tipo = " + txtTipPapel.Text;
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

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            PanelFiltro.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        public void CargarBob(int Procedimiento)
        {
            string FeInicio = "";
            string FeTermino = "";
            if ((txtFechaInicio.Text != "") && (txtFechaTermino.Text != ""))
            {
                string[] str1 = txtFechaInicio.Text.Split('/');
                FeInicio = str1[2] + "-" + str1[1] + "-" + str1[0];

                string[] str2 = txtFechaTermino.Text.Split('/');
                FeTermino = str2[2] + "-" + str2[1] + "-" + str2[0];
            }
            lista = control_Bob.List_ConsPapel(txtNumeroOT.Text.Trim(), txtCodigoBob.Text.Trim(), ddlMaquina.SelectedItem.Text.Trim(), txtTipPapel.Text, FeInicio, FeTermino, Procedimiento);
            RadGridBob.DataSource = lista;
            RadGridBob.DataBind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            PanelFiltro.Visible = false;
        }

    }
}