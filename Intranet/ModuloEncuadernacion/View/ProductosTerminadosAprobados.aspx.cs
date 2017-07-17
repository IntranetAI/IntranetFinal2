using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class ProductosTerminadosAprobados : System.Web.UI.Page
    {
        Controller_Enc Enc = new Controller_Enc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarAprobadas();
            }
        }

        public void cargarAprobadas()
        {
            DateTime vaa = DateTime.Now.AddDays(0);
            string fecha1 = vaa.ToString("MM-dd-yyyy");
            string fecha2 = fecha1;
            DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
            DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");

            RadGrid3.DataSource = Enc.CargarAprobadosPT("", "", FI, FT, 0);
            RadGrid3.DataBind();

            RadGrid1.DataSource = Enc.CargarAprobadosProTerminadosPT("", "", FI, FT, 0);
            RadGrid1.DataBind();


        }
        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtOP.Text != "" || txtNombreOP.Text != "")
            {


                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    DateTime a = Convert.ToDateTime(txtFechaInicio.Text);
                    string b = a.ToString("MM/dd/yyyy");
                    DateTime c = Convert.ToDateTime(txtFechaTermino.Text);
                    string d = c.ToString("MM/dd/yyyy");

                    DateTime FI = Convert.ToDateTime(b + " 00:00:00");
                    DateTime FT = Convert.ToDateTime(d + " 23:59:59");

                    RadGrid3.DataSource = Enc.CargarAprobadosPT(txtOP.Text, txtNombreOP.Text, FI, FT, 1);
                    RadGrid3.DataBind();

                    RadGrid1.DataSource = Enc.CargarAprobadosProTerminadosPT(txtOP.Text, txtNombreOP.Text, FI, FT, 1);
                    RadGrid1.DataBind();
                }
                else
                {
                    DateTime fec = Convert.ToDateTime("01-01-1900");

                    RadGrid3.DataSource = Enc.CargarAprobadosPT(txtOP.Text, txtNombreOP.Text, fec, fec, 2);
                    RadGrid3.DataBind();

                    RadGrid1.DataSource = Enc.CargarAprobadosProTerminadosPT(txtOP.Text, txtNombreOP.Text, fec, fec, 2);
                    RadGrid1.DataBind();
                }

            }
            else
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    DateTime a = Convert.ToDateTime(txtFechaInicio.Text);
                    string b = a.ToString("MM/dd/yyyy");
                    DateTime c = Convert.ToDateTime(txtFechaTermino.Text);
                    string d = c.ToString("MM/dd/yyyy");

                    DateTime FI = Convert.ToDateTime(b + " 00:00:00");
                    DateTime FT = Convert.ToDateTime(d + " 23:59:59");

                    RadGrid3.DataSource = Enc.CargarAprobadosPT(txtOP.Text, txtNombreOP.Text, FI, FT, 0);
                    RadGrid3.DataBind();

                    RadGrid1.DataSource = Enc.CargarAprobadosProTerminadosPT(txtOP.Text, txtNombreOP.Text, FI, FT, 0);
                    RadGrid1.DataBind();
                }
                else
                {
                    btnFiltro.Text = "ERROR";
                }

            }


        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (TabContainer1.ActiveTabIndex == 0)
            {
                btnFiltro.Text = "primero";
                GridView GridView1 = new GridView();
                if (txtOP.Text != "" || txtNombreOP.Text != "")
                {


                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        DateTime a = Convert.ToDateTime(txtFechaInicio.Text);
                        string b = a.ToString("MM/dd/yyyy");
                        DateTime c = Convert.ToDateTime(txtFechaTermino.Text);
                        string d = c.ToString("MM/dd/yyyy");

                        DateTime FI = Convert.ToDateTime(b + " 00:00:00");
                        DateTime FT = Convert.ToDateTime(d + " 23:59:59");

                        GridView1.DataSource = Enc.CargarAprobadosProTerminadosPT(txtOP.Text, txtNombreOP.Text, FI, FT, 1);

                    }
                    else
                    {
                        DateTime fec = Convert.ToDateTime("01-01-1900");

                        GridView1.DataSource = Enc.CargarAprobadosProTerminadosPT(txtOP.Text, txtNombreOP.Text, fec, fec, 2);

                    }

                }
                else
                {
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        DateTime a = Convert.ToDateTime(txtFechaInicio.Text);
                        string b = a.ToString("MM/dd/yyyy");
                        DateTime c = Convert.ToDateTime(txtFechaTermino.Text);
                        string d = c.ToString("MM/dd/yyyy");

                        DateTime FI = Convert.ToDateTime(b + " 00:00:00");
                        DateTime FT = Convert.ToDateTime(d + " 23:59:59");

                        GridView1.DataSource = Enc.CargarAprobadosProTerminadosPT(txtOP.Text, txtNombreOP.Text, FI, FT, 0);

                    }
                    else
                    {
                        DateTime vaa = DateTime.Now.AddDays(0);
                        string fecha1 = vaa.ToString("MM-dd-yyyy");
                        string fecha2 = fecha1;
                        DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
                        DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");

                        GridView1.DataSource = Enc.CargarAprobadosProTerminadosPT("", "", FI, FT, 0);
                    }

                }

                GridView1.DataBind();
                GridView1.HeaderRow.Cells[0].Visible = false;
                GridView1.HeaderRow.Cells[1].Text = "N° Pallet";
                //GridView1.HeaderRow.Cells[10].Visible = false;
                //GridView1.HeaderRow.Cells[11].Visible = false;
                //GridView1.HeaderRow.Cells[12].Visible = false;
                //GridView1.HeaderRow.Cells[13].Visible = false;
                //GridView1.HeaderRow.Cells[14].Visible = false;
                //GridView1.HeaderRow.Cells[15].Visible = false;
                //GridView1.HeaderRow.Cells[16].Visible = false;
                //GridView1.HeaderRow.Cells[17].Visible = false;
                //GridView1.HeaderRow.Cells[18].Visible = false;
                //GridView1.HeaderRow.Cells[19].Visible = false;
                //GridView1.HeaderRow.Cells[20].Visible = false;
                //GridView1.HeaderRow.Cells[21].Visible = false;
                //GridView1.HeaderRow.Cells[22].Visible = false;
                //GridView1.HeaderRow.Cells[23].Visible = false;
                //GridView1.HeaderRow.Cells[24].Visible = false;



                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                int contador = 0;
                int Despachado = 0;
                string Paradespachar = "0";
                string NombreOT = "";

                for (contador = 0; contador < GridView1.Rows.Count; contador++)
                {
                    GridViewRow row = GridView1.Rows[contador];
                    NombreOT = row.Cells[2].Text;
                    string numero = row.Cells[6].Text;
                    Paradespachar = row.Cells[5].Text;
                    string[] str = numero.Split(',');


                    row.Cells[0].Visible = false;
                    //row.Cells[10].Visible = false;
                    //row.Cells[11].Visible = false;
                    //row.Cells[12].Visible = false;
                    //row.Cells[13].Visible = false;
                    //row.Cells[14].Visible = false;
                    //row.Cells[15].Visible = false;
                    //row.Cells[16].Visible = false;
                    //row.Cells[17].Visible = false;
                    //row.Cells[18].Visible = false;
                    //row.Cells[19].Visible = false;
                    //row.Cells[20].Visible = false;
                    //row.Cells[21].Visible = false;
                    //row.Cells[22].Visible = false;
                    //row.Cells[23].Visible = false;
                    //row.Cells[24].Visible = false;

                    Despachado = 100;
                }
                string nombre = "Pendientes_" + DateTime.Now.ToShortDateString();

                if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                {
                    ExportToExcel(nombre, GridView1, contador.ToString("N0"), Despachado.ToString("N0"), Paradespachar, NombreOT, txtFechaInicio.Text, txtFechaTermino.Text);//GridView1);
                }
                else
                {
                    ExportToExcel(nombre, GridView1, contador.ToString("N0"), Despachado.ToString("N0"), Paradespachar, NombreOT, "Sin Fecha", "Sin Fecha");//GridView1);
                }

            }
            else //segundo tab gridview exportacion
            {
                GridView GridView2 = new GridView();
                if (txtOP.Text != "" || txtNombreOP.Text != "")
                {


                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        DateTime a = Convert.ToDateTime(txtFechaInicio.Text);
                        string b = a.ToString("MM/dd/yyyy");
                        DateTime c = Convert.ToDateTime(txtFechaTermino.Text);
                        string d = c.ToString("MM/dd/yyyy");

                        DateTime FI = Convert.ToDateTime(b + " 00:00:00");
                        DateTime FT = Convert.ToDateTime(d + " 23:59:59");

                        GridView2.DataSource = Enc.CargarAprobadosPT_Excel(txtOP.Text, txtNombreOP.Text, FI, FT, 1);

                    }
                    else
                    {
                        DateTime fec = Convert.ToDateTime("01-01-1900");

                        GridView2.DataSource = Enc.CargarAprobadosPT_Excel(txtOP.Text, txtNombreOP.Text, fec, fec, 2);

                    }

                }
                else
                {
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        DateTime a = Convert.ToDateTime(txtFechaInicio.Text);
                        string b = a.ToString("MM/dd/yyyy");
                        DateTime c = Convert.ToDateTime(txtFechaTermino.Text);
                        string d = c.ToString("MM/dd/yyyy");

                        DateTime FI = Convert.ToDateTime(b + " 00:00:00");
                        DateTime FT = Convert.ToDateTime(d + " 23:59:59");

                        GridView2.DataSource = Enc.CargarAprobadosPT_Excel(txtOP.Text, txtNombreOP.Text, FI, FT, 0);

                    }
                    else
                    {
                        DateTime vaa = DateTime.Now.AddDays(0);
                        string fecha1 = vaa.ToString("MM-dd-yyyy");
                        string fecha2 = fecha1;
                        DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
                        DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");

                        GridView2.DataSource = Enc.CargarAprobadosPT_Excel("", "", FI, FT, 0);
                    }

                }

                GridView2.DataBind();

                GridView2.HeaderRow.Cells[0].Visible = false;
                GridView2.HeaderRow.Cells[1].Text = "N° Pallet";
                //GridView2.HeaderRow.Cells[10].Visible = false;
                //GridView2.HeaderRow.Cells[11].Visible = false;
                //GridView2.HeaderRow.Cells[12].Visible = false;
                //GridView2.HeaderRow.Cells[13].Visible = false;
                //GridView2.HeaderRow.Cells[14].Visible = false;
                //GridView2.HeaderRow.Cells[15].Visible = false;
                //GridView2.HeaderRow.Cells[16].Visible = false;
                //GridView2.HeaderRow.Cells[17].Visible = false;
                //GridView2.HeaderRow.Cells[18].Visible = false;
                //GridView2.HeaderRow.Cells[19].Visible = false;
                //GridView2.HeaderRow.Cells[20].Visible = false;
                //GridView2.HeaderRow.Cells[21].Visible = false;
                //GridView2.HeaderRow.Cells[22].Visible = false;
                //GridView2.HeaderRow.Cells[23].Visible = false;
                //GridView2.HeaderRow.Cells[24].Visible = false;



                GridView2.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView2.HeaderStyle.ForeColor = System.Drawing.Color.White;
                int contador = 0;
                int Despachado = 0;
                string Paradespachar = "0";
                string NombreOT = "";

                for (contador = 0; contador < GridView2.Rows.Count; contador++)
                {
                    GridViewRow row = GridView2.Rows[contador];
                    NombreOT = row.Cells[2].Text;
                    string numero = row.Cells[6].Text;
                    Paradespachar = row.Cells[5].Text;
                    string[] str = numero.Split(',');

                   
                    row.Cells[0].Visible = false;
                    //row.Cells[10].Visible = false;
                    //row.Cells[11].Visible = false;
                    //row.Cells[12].Visible = false;
                    //row.Cells[13].Visible = false;
                    //row.Cells[14].Visible = false;
                    //row.Cells[15].Visible = false;
                    //row.Cells[16].Visible = false;
                    //row.Cells[17].Visible = false;
                    //row.Cells[18].Visible = false;
                    //row.Cells[19].Visible = false;
                    //row.Cells[20].Visible = false;
                    //row.Cells[21].Visible = false;
                    //row.Cells[22].Visible = false;
                    //row.Cells[23].Visible = false;
                    //row.Cells[24].Visible = false;

                    Despachado = 100;
                }
                string nombre = "InformeAprobados_" + DateTime.Now.ToShortDateString();

                if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                {
                    ExportToExcel2(nombre, GridView2, contador.ToString("N0"), Despachado.ToString("N0"), Paradespachar, NombreOT, txtFechaInicio.Text, txtFechaTermino.Text);//GridView1);
                }
                else
                {
                    ExportToExcel2(nombre, GridView2, contador.ToString("N0"), Despachado.ToString("N0"), Paradespachar, NombreOT, "Sin Fecha", "Sin Fecha");//GridView1);
                }
            }
        }
        private void ExportToExcel(string nameReport, GridView wControl, string TotalGuia, string TotalDespacho, string total, string Nombre, string fInicio, string fTermino)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();
            if (fInicio != "")
            {
                la.Text = "<div align='center'>INFORME PRODUCTOS SIN APROBAR<br/> </div><br/>";
            }
            else
            {
                la.Text = "<div align='center'>INFORME PRODUCTOS SIN APROBAR<br/> </div><br/>";
            }
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

        private void ExportToExcel2(string nameReport, GridView wControl, string TotalGuia, string TotalDespacho, string total, string Nombre, string fInicio, string fTermino)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();
            if (fInicio != "")
            {
                la.Text = "<div align='center'>INFORME PRODUCTOS APROBADOS<br/> </div><br/>";
            }
            else
            {
                la.Text = "<div align='center'>INFORME PRODUCTOS APROBADOS<br/> </div><br/>";
            }
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