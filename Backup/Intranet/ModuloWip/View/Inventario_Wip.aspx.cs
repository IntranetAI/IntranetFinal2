using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;
using Telerik.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloWip.View
{
    public partial class Inventario_Wip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGridInforme.DataSource = "";
                RadGridInforme.DataBind();
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = "";
                if (txtFechaTermino.Text != "")
                {
                    string[] split = txtFechaTermino.Text.Split('-');
                    fecha = split[2] + "-" + split[1] + "-" + split[0] + " 23:59:59";
                    Controller_WipControl wipControl = new Controller_WipControl();
                    RadGridInforme.DataSource = wipControl.ListInventarioWip(fecha);
                    RadGridInforme.DataBind();
                }

            }
            catch
            {

            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (RadGridInforme.Items.Count > 0)
            {
                List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
                for (int i = 0; i < RadGridInforme.Items.Count; i++)
                {
                    Model_Wip_Control w = new Model_Wip_Control();
                    GridDataItem row = RadGridInforme.Items[i];
                    w.ID_Control = row["ID_Control"].Text;
                    w.OT = row["OT"].Text;
                    w.NombreOT = row["NombreOT"].Text;
                    w.Pliego = row["Pliego"].Text;
                    w.Maquina = row["Maquina"].Text;
                    w.Pliegos_Impresos = Convert.ToInt32(row["Pliegos_Impresos"].Text);
                    w.Posicion = row["Posicion"].Text;
                    w.Ubicacion = row["Ubicacion"].Text;
                    lista.Add(w);
                }
                GridView gv1 = new GridView();

                gv1.DataSource = lista;
                gv1.DataBind();
                gv1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv1.HeaderStyle.ForeColor = System.Drawing.Color.White;


                gv1.HeaderRow.Cells[0].Text = "Cod. Pallet";
                gv1.HeaderRow.Cells[2].Text = "Nombre OT";
                gv1.HeaderRow.Cells[3].Text = "Pliegos";
                gv1.HeaderRow.Cells[4].Text = "Maquina";
                gv1.HeaderRow.Cells[5].Text = "Cant. Pliegos";
                gv1.HeaderRow.Cells[6].Text = "Posicion";
                gv1.HeaderRow.Cells[7].Text = "Ubicacion";
                gv1.HeaderRow.Cells[8].Visible = false;
                gv1.HeaderRow.Cells[9].Visible = false;
                gv1.HeaderRow.Cells[10].Visible = false;
                gv1.HeaderRow.Cells[11].Visible = false;
                gv1.HeaderRow.Cells[12].Visible = false;
                gv1.HeaderRow.Cells[13].Visible = false;
                gv1.HeaderRow.Cells[14].Visible = false;
                gv1.HeaderRow.Cells[15].Visible = false;
                gv1.HeaderRow.Cells[16].Visible = false;
                gv1.HeaderRow.Cells[17].Visible = false;
                gv1.HeaderRow.Cells[18].Visible = false;
                gv1.HeaderRow.Cells[19].Visible = false;
                gv1.HeaderRow.Cells[20].Visible = false;
                gv1.HeaderRow.Cells[21].Visible = false;
                gv1.HeaderRow.Cells[22].Visible = false;

                for (int contador = 0; contador < gv1.Rows.Count; contador++)
                {
                    GridViewRow row = gv1.Rows[contador];
                    row.Cells[3].Text = row.Cells[3].Text.Replace("-", ",");
                    row.Cells[4].Text = row.Cells[6].Text;
                    row.Cells[5].Text = row.Cells[9].Text;
                    row.Cells[6].Text = row.Cells[19].Text.Replace("&amp;nbsp;", "");
                    if (row.Cells[18].Text != "")
                    {
                        row.Cells[7].Text = row.Cells[18].Text.Replace("&amp;nbsp;", "");
                    }
                    else
                    {
                        row.Cells[7].Text = "";
                    }
                    row.Cells[8].Visible = false;
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
                }

                ExportToExcel("Inventario WIP "+ txtFechaTermino.Text,gv1, txtFechaTermino.Text);
            }
        }

        private void ExportToExcel(string nameReport, GridView wControl, string Fecha)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();

            HtmlForm form = new HtmlForm();

            Label la = new Label();

            la.Text = "<div align='center'>Inventario hasta " + Fecha + "</div><br />";
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
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            response.Write(style);

            response.End();
        }
    }
}