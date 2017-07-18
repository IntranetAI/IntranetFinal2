using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloDespacho.View
{
    public partial class Informe_Serv_Exter : System.Web.UI.Page
    {
        public static List<WipSerExt> lista = new List<WipSerExt>();
        Controller_SerExt controlext = new Controller_SerExt();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar();
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        public void Cargar()
        {
            string OT = txtOT.Text;
            string NombreOT = txtNombreOT.Text;
            string FechaInicio = txtFechaInicio.Text;
            string FechaTermino = txtFechaTermino.Text;
            lista  = controlext.Listar(OT,NombreOT,FechaInicio,FechaTermino).OrderBy(o=>o.FechImp).ToList();
            RadGridOT.DataSource = lista;
            RadGridOT.DataBind();
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (lista.Count > 0)
            {
                GridView gv = new GridView();
                gv.DataSource = lista;
                gv.DataBind();
                gv.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;


                gv.HeaderRow.Cells[0].Text = "OT";
                gv.HeaderRow.Cells[1].Text = "Nombre OT";
                gv.HeaderRow.Cells[2].Text = "Pliegos Impresos";
                gv.HeaderRow.Cells[3].Text = "Cantidad Enviada";
                gv.HeaderRow.Cells[4].Text = "Fecha Impresion";
                gv.HeaderRow.Cells[5].Text = "Proceso Externo";
                gv.HeaderRow.Cells[6].Text = "Cantidad Recepcionada";
                gv.HeaderRow.Cells[7].Text = "Fecha Devolución";

                for (int contador = 0; contador < gv.Rows.Count; contador++)
                {
                    GridViewRow row = gv.Rows[contador];

                    string numero = row.Cells[2].Text;
                    if (numero.Length >= 4)
                    {
                        row.Cells[2].Text = numero.Replace(".",String.Empty);
                    }
                    string numer2 = row.Cells[3].Text;
                    if (numer2.Length >= 4)
                    {
                        row.Cells[3].Text = numer2.Replace(".", String.Empty);
                    }
                    string numer3 = row.Cells[6].Text;
                    if (numer3.Length >= 4)
                    {
                        row.Cells[6].Text = numer3.Replace(".", String.Empty);
                    }
                }
                ExportToExcel("Informe Wip Servicio Ext. " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), gv, txtOT.Text, txtFechaInicio.Text, txtFechaTermino.Text);
            }
        }

        private void ExportToExcel(string nameReport, GridView wControl, string OT, string fInicio, string fTermino)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe Control Wip<br/>";
            if (OT != "") { Titulo = Titulo + "OT : " + OT; }
            if (fInicio != "") { Titulo = Titulo + " Fecha Inicio : " + fInicio; }
            if (fTermino != "") { Titulo = Titulo + " Fecha Termino : " + fTermino; }
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