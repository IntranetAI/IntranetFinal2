using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloDespacho.View
{
    public partial class KilosTransportados : System.Web.UI.Page
    {
        DespachoController controldes = new DespachoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar();
            }
        }
        public void Cargar()
        {
            RadGrid1.DataSource = controldes.ListarDespacho_kilos(null,null,null,null,null,null,1);
            RadGrid1.DataBind();
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            //Panel1.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Recargar
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            DateTime Fte = Convert.ToDateTime("1900-01-01");
            if (txtFechaInicio.Text == "" && txtFechaTermino.Text == "")
            {
                RadGrid1.DataSource = controldes.ListarDespacho_kilos(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, txtTransporta.Text, Fte, Fte, 3);//null,null,1
                RadGrid1.DataBind();
            }
            else
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                string fechaInicio = mes + "/" + dia + "/" + año;
                //fechas
                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);

                string fechaTermino = mes2 + "/" + dia2 + "/" + año2;
                if (fechaInicio == fechaTermino)
                {
                    fechaInicio = fechaInicio + " 00:00:00";
                    fechaTermino = fechaTermino + " 23:59:59";
                }
                RadGrid1.DataSource = controldes.ListarDespacho_kilos(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text,txtTransporta.Text, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 2);
                RadGrid1.DataBind();
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //Panel1.Visible = false;
        }

        protected void ibPDF_Click(object sender, ImageClickEventArgs e)
        {
            //Exportar a PDF
            string OT = txtNumeroOT.Text.Trim();
            string NombreOT = txtNombreOT.Text.Trim();
            string Cliente = txtCliente.Text.Trim();
            string Transportista = txtTransporta.Text.Trim();
            string FeInicio = txtFechaInicio.Text.Trim();
            string FeTermino = txtFechaTermino.Text.Trim();

            Response.Redirect("PDFKilosTrans.aspx?OT=" + OT + "&NombreOT=" + NombreOT + "&Cliente=" + Cliente + "&Transportista=" + Transportista + "&FeInicio=" + FeInicio + "&FeTermino=" + FeTermino);
        
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridView GridView1 = new GridView();
                if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                {
                    string fechaI = txtFechaInicio.Text;
                    string[] str = fechaI.Split('/');
                    string dia = str[0];
                    string mes = str[1];
                    string año = str[2];
                    año = año.Substring(0, 4);

                    string fechaInicio = mes + "/" + dia + "/" + año;
                    //fechas
                    string fechaT = txtFechaTermino.Text;
                    string[] str2 = fechaT.Split('/');
                    string dia2 = str2[0];
                    string mes2 = str2[1];
                    string año2 = str2[2];
                    año2 = año2.Substring(0, 4);

                    string fechaTermino = mes2 + "/" + dia2 + "/" + año2;

                    if (fechaInicio == fechaTermino)
                    {
                        fechaInicio = fechaInicio + " 00:00:00";
                        fechaTermino = fechaTermino + " 23:59:59";
                    }
                    GridView1.DataSource = controldes.ListarDespacho_KilosExcel(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, txtTransporta.Text, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 2);

                    //txtCliente.Text = mes + "/" + dia + "/" + año;
                }
                else
                {
                    GridView1.DataSource = controldes.ListarDespacho_KilosExcel(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, txtTransporta.Text, null, null, 1);//1
                }
                GridView1.DataBind();
                GridView1.Visible = true;
                GridView1.HeaderRow.Cells[0].Text = "Transportista";
                GridView1.HeaderRow.Cells[1].Text = "Patente";
                GridView1.HeaderRow.Cells[2].Text = "Guias";
                GridView1.HeaderRow.Cells[3].Text = "Fecha Despacho";
                GridView1.HeaderRow.Cells[4].Text = "N° OT";
                GridView1.HeaderRow.Cells[5].Text = "Nombre OT";
                GridView1.HeaderRow.Cells[6].Text = "Peso Unitario";
                GridView1.HeaderRow.Cells[7].Text = "Cant. Despachada";
                GridView1.HeaderRow.Cells[8].Text = "Total Kilos";

                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

                string nombre = "Informe de Despacho Futuros" + DateTime.Now.ToShortDateString();

                if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                {
                    ExportToExcel(nombre, GridView1, txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, txtTransporta.Text, txtFechaInicio.Text, txtFechaTermino.Text);//GridView1);
                }
                else
                {
                    ExportToExcel(nombre, GridView1, txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, txtTransporta.Text, "", "");//GridView1);
                }
            }
            catch
            {
            }
            
        }

        private void ExportToExcel(string nameReport, GridView wControl, string OT, string Nombre, string Cliente,string Transp, string fInicio, string fTermino)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();
            
            string Titulo = "<div align='center'>Informe Despacho Kilos Transportados<br/>";
            //la.Text = "<div align='center'>Informe Despacho Kilos Transportados<br/>";
            if (OT != ""){  Titulo = Titulo + "OT : " + OT; }
            if (Nombre != ""){  Titulo = Titulo + " Nombre OT : " + Nombre; }
            if (Cliente != ""){ Titulo = Titulo + " Cliente :" + Cliente; }
            if (fInicio != ""){ Titulo = Titulo+ " Fecha Inicio : " + fInicio; }
            if (fTermino != ""){ Titulo = Titulo+ " Fecha Termino : " + fTermino; }
            if (Transp != "") { Titulo = Titulo + "Transportista : " + Transp; }
            la.Text = Titulo + "</div><br />";
            
            form.Controls.Add(la);
            form.Controls.Add(wControl);
            //Label l = new Label(); l.Text = "<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>";// +TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>";
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

        protected void ibFiltro_Click(object sender, ImageClickEventArgs e)
        {
            //Panel1.Visible = true;
        }
    }
}