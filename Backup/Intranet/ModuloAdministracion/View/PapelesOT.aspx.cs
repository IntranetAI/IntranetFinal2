using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using Intranet.ModuloAdministracion.Model;

namespace Intranet.ModuloAdministracion.View
{
    public partial class PapelesOT : System.Web.UI.Page
    {
        Controller_Papeles cp = new Controller_Papeles();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime f1 = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime f2 = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 00:00:00");
                Label4.Text = cp.Carga_PapelesOT(txtNumeroOT.Text.Trim(), f1, f2, 1);
            }
            else
            {
                DateTime Fec = Convert.ToDateTime("1900-01-01");
                Label4.Text = cp.Carga_PapelesOT(txtNumeroOT.Text.Trim(), Fec, Fec, 0);
            }

            if (Label4.Text != "")
            {
                lkExportar.Visible = true;
                Image4.Visible = true;
            }
            else
            {
                lkExportar.Visible = false;
                Image4.Visible = false;
            }
        }

        protected void lkExportar_Click(object sender, EventArgs e)
        {
            List<Papeles> lista = new List<Papeles>();
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime f1 = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime f2 = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 00:00:00");
                lista = cp.Lista_ExcelPapelesOT(txtNumeroOT.Text.Trim(), f1, f2, 1);
            }
            else
            {
                DateTime Fec = Convert.ToDateTime("1900-01-01");
                lista = cp.Lista_ExcelPapelesOT(txtNumeroOT.Text.Trim(), Fec, Fec, 0);
            }



            GridView GridView1 = new GridView();


            GridView1.DataSource = lista;
            GridView1.DataBind();
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.DarkGray;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            GridView1.HeaderRow.Cells[1].Text = "Nombre OT";
            GridView1.HeaderRow.Cells[2].Text = "Nombre Componente";
            GridView1.HeaderRow.Cells[3].Text = "Nombre Papel";
            GridView1.HeaderRow.Cells[4].Text = "Ancho(Bobina)";
            GridView1.HeaderRow.Cells[5].Text = "Alto";



            string nombre = "PapelesOT_" + DateTime.Now.ToString("dd/MM/yyyy");
            string titulo = "";
            if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
            {
                titulo = "<div align='center'>INFORME DETALLE PAPEL</div><div  align='center'>" + txtNumeroOT.Text + "  Desde " + txtFechaInicio.Text + "  Hasta  " + txtFechaTermino.Text + "</div><br/>";
                ExportToExcel(nombre, GridView1, titulo);
            }
            else
            {
                titulo = "<div align='center'>INFORME DETALLE PAPEL</div><div  align='center'>" + txtNumeroOT.Text + "</div><br/>";
               ExportToExcel(nombre, GridView1, titulo);
            }


        }

        private void ExportToExcel(string nameReport, GridView wControl, string Titulo)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();
            la.Text = Titulo;

            form.Controls.Add(la);
            form.Controls.Add(wControl);
            //Label l = new Label(); l.Text = "<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>" + TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>";
            //form.Controls.Add(l);
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