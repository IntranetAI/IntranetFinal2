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
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.View
{
    public partial class FillRate : System.Web.UI.Page
    {
        FillRate_Controller controlFill = new FillRate_Controller();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        public void CargarDatos()
        {

            DateTime vaa = DateTime.Now.AddDays(-1);
            string fecha1 = vaa.ToString("MM-dd-yyyy");
            string fecha2 = fecha1;
            DateTime f = Convert.ToDateTime(fecha1 + " 00:00:00");
            DateTime f2 = Convert.ToDateTime(fecha2 + " 23:59:59");
            //tabla temporal 2

          //  bool r = controlFill.ProcedimientoTrigger_FillRate("", "", "", f, f2, 0);

            //fin tabla temporal2

            RadGrid1.DataSource = controlFill.CargarFillRate("", "", "", f, f2, 1);
            RadGrid1.DataBind();
        }
    


        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                string f1 = str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00";

                string[] str2 = txtFechaTermino.Text.Split('/');
                string f2 = str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59";

                RadGrid1.DataSource = controlFill.CargarFillRate("", "", "", Convert.ToDateTime(f1), Convert.ToDateTime(f2), 2);
                RadGrid1.DataBind();
            }
            else
            {

            }
            
            //string OT = txtNumeroOT.Text;
            //string nombre = txtNombreOT.Text;
            //string Cliente = txtCliente.Text;
            //string fechaInicio = txtFechaInicio.Text;
            //string fechatermino = txtFechaTermino.Text;
            //if (fechaInicio != "" && fechatermino != "")
            //{
            //    string[] str = fechaInicio.Split('/');
            //    string f1 = str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00";

            //    string[] str2 = fechatermino.Split('/');
            //    string f2 = str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59";

            //    bool r = controlFill.ProcedimientoTrigger_FillRate(OT,nombre,Cliente, Convert.ToDateTime(f1), Convert.ToDateTime(f2),2);
            //    RadGrid1.DataSource = controlFill.ListarFillRate(Convert.ToDateTime(f1), Convert.ToDateTime(f2), OT, nombre, Cliente);
            //        //RadGrid1.DataSource = controlFill.ListarFillRate(Convert.ToDateTime(f1),Convert.ToDateTime(f2),OT,nombre,Cliente);
            //}
            //else
            //{
            //    //if (OT != "" || nombre != "" || Cliente != "")
            //    //{
            //        string fecha1 = DateTime.Now.ToString("MM-dd-yyyy");
            //        string fecha2 = fecha1;
            //        DateTime f = Convert.ToDateTime("01-01-1900 00:00:00");
            //        DateTime f2 = Convert.ToDateTime("01-01-1900 23:59:59");

            //        //  RadGrid1.DataSource = controlFill.ListarFillRate(f, f2, OT, nombre, Cliente);
            //        bool r = controlFill.ProcedimientoTrigger_FillRate(OT, nombre, Cliente, Convert.ToDateTime(f), Convert.ToDateTime(f2), 1);
            //        RadGrid1.DataSource = controlFill.ListarFillRate(Convert.ToDateTime(f), Convert.ToDateTime(f2), OT, nombre, Cliente);
            //    //}
               
            //}
            
            //RadGrid1.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            //Panel1.Visible = true;
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
        
            //for (contador = 0; contador < GridView1.Rows.Count; contador++)
            //{
            //    GridViewRow row = GridView1.Rows[contador];
            //    if (row.Cells[2].Text != "&nbsp;")
            //    {

            //        double TirajeOT = Convert.ToDouble(row.Cells[2].Text);
            //        if (row.Cells[2].Text.Length > 3)
            //        {
            //            string to = TirajeOT.ToString("N0").Replace(",", ".");
            //            row.Cells[2].Text = to;
            //        }
            //        else
            //        {
            //            string to = TirajeOT.ToString("N0");
            //            row.Cells[2].Text = to;
            //        }
            //    }
            //    else
            //    {
            //        row.Cells[2].Text = "";
            //    }
            //    //cantidad  solicitada

            List<FillRate_Excel> lista = new List<FillRate_Excel>();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {

                FillRate_Excel pro = new FillRate_Excel();

                if (RadGrid1.Items[i]["OT"].Text.ToUpper() == "&NBSP;")
                {
                    pro.OT = "";
                }
                else
                {
                    pro.OT = RadGrid1.Items[i]["OT"].Text.ToUpper();
                }
                if (RadGrid1.Items[i]["NombreOT"].Text.ToLower() == "&nbsp;")
                {
                    pro.NombreOT = "";
                }
                else
                {
                    pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text.ToLower();
                }
                if (RadGrid1.Items[i]["Tiraje"].Text == "&nbsp;")
                {
                    pro.Tiraje = "";
                }
                else
                {
                    pro.Tiraje = RadGrid1.Items[i]["Tiraje"].Text;
                }
                if (RadGrid1.Items[i]["Solitada"].Text == "&nbsp;")
                {
                    pro.Solitada = "";
                }
                else
                {
                    pro.Solitada = RadGrid1.Items[i]["Solitada"].Text;
                }
                if (RadGrid1.Items[i]["CantidadGenerada"].Text == "&nbsp;")
                {
                    pro.CantidadGenerada = "";
                }
                else
                {
                    pro.CantidadGenerada = RadGrid1.Items[i]["CantidadGenerada"].Text;
                }
                if (RadGrid1.Items[i]["FechaEntregada"].Text == "&nbsp;")
                {
                    pro.FechaEntregar = "";
                }
                else
                {

                    pro.FechaEntregar = RadGrid1.Items[i]["FechaEntregada"].Text;
                }
                if (RadGrid1.Items[i]["PuntoEntrega"].Text == "&nbsp;")
                {
                    pro.PuntoEntrega = "";
                }
                else
                {
                    pro.PuntoEntrega = RadGrid1.Items[i]["PuntoEntrega"].Text;
                }


                pro.PorcSobreTiraje = RadGrid1.Items[i]["DespachoTotal"].Text;
                pro.PorcSolicitado = RadGrid1.Items[i]["PorcSolicitado"].Text;




                lista.Add(pro);
            }
            GridView GridView1 = new GridView();

            GridView1.DataSource = lista;
            GridView1.DataBind();


            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;




            string nombre = "InformeFillRate" + DateTime.Now.ToShortDateString();


            ExportToExcel(nombre, GridView1);//GridView1);
                
        }

        private void ExportToExcel(string nameReport, GridView wControl)
        {
        HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

                la.Text = "<div align='center'>Informe Despachos Fill Rate</div><br/>";
            
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

        protected void ibPDF_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //Panel1.Visible = false;
        }
    }
}