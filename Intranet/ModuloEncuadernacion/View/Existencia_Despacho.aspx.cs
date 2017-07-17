using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using Telerik.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using Intranet.ModuloEncuadernacion.Model;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class Existencia_Despacho : System.Web.UI.Page
    {
        Controller_InfDespacho inf = new Controller_InfDespacho();
        bool respuesta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               CargarGrilla();
            }
        }
        //public void CargaGrilla()
        //{ 
        //    DateTime vaa = DateTime.Now.AddDays(0);
        //    DateTime va2 = DateTime.Now.AddDays(-7);
        //    string fecha1 = vaa.ToString("MM-dd-yyyy");
        //    string fecha2 = va2.ToString("MM-dd-yyyy");
        //    DateTime FI = Convert.ToDateTime(fecha2 + " 00:00:00");
        //    DateTime FT = Convert.ToDateTime(fecha1 + " 23:59:59");
        //    respuesta = inf.Existencia();

        //    if (respuesta == true)
        //    {
        //        RadGrid2.DataSource = inf.CargarExistencia("", "", "", FI, FT, 0);
        //        RadGrid2.DataBind();
        //    }
        //}
        public void CargarGrilla()
        {
            DateTime vaa = DateTime.Now.AddDays(0);
            DateTime va2 = DateTime.Now.AddDays(-7);
            string fecha1 = vaa.ToString("MM-dd-yyyy");
            string fecha2 = va2.ToString("MM-dd-yyyy");
            DateTime FI = Convert.ToDateTime(fecha2 + " 00:00:00");
            DateTime FT = Convert.ToDateTime(fecha1 + " 23:59:59");
            RadGrid2.DataSource = inf.CargarExistencia("", "", "", FI, FT, 0);
            RadGrid2.DataBind();
        }

        protected void ibPDF_Click(object sender, ImageClickEventArgs e)
        {

        }


        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                DateTime vaa = Convert.ToDateTime(txtFechaInicio.Text);
                DateTime va2 = Convert.ToDateTime(txtFechaTermino.Text);
                string fecha1 = vaa.ToString("MM-dd-yyyy");
                string fecha2 = va2.ToString("MM-dd-yyyy");
                DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
                DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");

                RadGrid2.DataSource = inf.CargarExistencia(txtOP.Text, txtNombreOP.Text, txtCliente.Text, FI, FT, 0);

            }
            else 
            {
                DateTime FI = Convert.ToDateTime("1900-01-01 00:00:00");
                DateTime FT = Convert.ToDateTime("1900-01-01 23:59:59");

                RadGrid2.DataSource = inf.CargarExistencia(txtOP.Text, txtNombreOP.Text, txtCliente.Text, FI, FT, 1);

            }
            RadGrid2.DataBind();
        }
        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {

            //GridDataItem item = (GridDataItem)e.Item;

            //string OT = item["OT"].Text;

        }
        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            //GridView GridView1 = new GridView();
            //if (txtFechaInicio.Text == "" && txtFechaTermino.Text == "" && txtOP.Text == "" && txtNombreOP.Text == "" && txtCliente.Text == "")
            //{
            //    DateTime vaa = DateTime.Now.AddDays(0);
            //    DateTime va2 = DateTime.Now.AddDays(-7);
            //    string fecha1 = vaa.ToString("MM-dd-yyyy");
            //    string fecha2 = va2.ToString("MM-dd-yyyy");
            //    DateTime FI = Convert.ToDateTime(fecha2 + " 00:00:00");
            //    DateTime FT = Convert.ToDateTime(fecha1 + " 23:59:59");
               

               
            //    GridView1.DataSource = inf.CargarExistencia_Excel("", "", "", FI, FT, 0);
               
            //}
            //else
            //{
            //    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            //    {
            //        DateTime vaa = Convert.ToDateTime(txtFechaInicio.Text);
            //        DateTime va2 = Convert.ToDateTime(txtFechaTermino.Text);
            //        string fecha1 = vaa.ToString("MM-dd-yyyy");
            //        string fecha2 = va2.ToString("MM-dd-yyyy");
            //        DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
            //        DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");

            //        GridView1.DataSource = inf.CargarExistencia_Excel(txtOP.Text, txtNombreOP.Text, txtCliente.Text, FI, FT, 0);

            //    }
            //    else
            //    {
            //        DateTime FI = Convert.ToDateTime("1900-01-01 00:00:00");
            //        DateTime FT = Convert.ToDateTime("1900-01-01 23:59:59");

            //        GridView1.DataSource = inf.CargarExistencia_Excel(txtOP.Text, txtNombreOP.Text, txtCliente.Text, FI, FT, 1);

            //    }
            //}
            //GridView1.DataBind();


            //GridView1.HeaderStyle.BackColor = System.Drawing.Color.DarkGray;
            //GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;

            //GridView1.HeaderRow.Cells[1].Text = "Nombre OT";
            //GridView1.HeaderRow.Cells[3].Text = "Tiraje";
            //GridView1.HeaderRow.Cells[4].Text = "Total Recepcionado";
            //GridView1.HeaderRow.Cells[5].Text = "Total Despachado";

            List<Existencia_Excel> lista = new List<Existencia_Excel>();
          
            for (int i = 0; i < RadGrid2.Items.Count; i++)
            {
                            
                Existencia_Excel pro = new Existencia_Excel();
                pro.OT = RadGrid2.Items[i]["OT"].Text;
                pro.NombreOT = RadGrid2.Items[i]["NombreOT"].Text;
                pro.TirajeOT = RadGrid2.Items[i]["Tiraje"].Text;
                pro.TotalRecepcionado = RadGrid2.Items[i]["RecibidoQGChile"].Text;
                pro.TotalDespachado = RadGrid2.Items[i]["DespachoEnc"].Text;
                pro.Devolucion = RadGrid2.Items[i]["id_ProductosTerminados"].Text;//cliente
                pro.Existencia = RadGrid2.Items[i]["Saldo"].Text;
                string tiraje = RadGrid2.Items[i]["Tiraje"].Text;
                string totaldesp = RadGrid2.Items[i]["DespachoEnc"].Text;

                if(RadGrid2.Items[i]["Terminacion"].Text=="<div style='Color:Red;'>Por Liquidar</div>")
                {
                pro.Estado = "Por Liquidar";
                }
                else if (RadGrid2.Items[i]["Terminacion"].Text == "<div style='Color:Green;'>Liquidada</div>")
                {
                    pro.Estado = "Liquidada";
                }
                else
                {
                    pro.Estado = "En Proceso";
                }
               

                lista.Add(pro);
            }
            GridView GridView1 = new GridView();

           
            GridView1.DataSource = lista;
            GridView1.DataBind();
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.DarkGray;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            GridView1.HeaderRow.Cells[1].Text = "Nombre OT";
            GridView1.HeaderRow.Cells[2].Text = "Tiraje";
            GridView1.HeaderRow.Cells[3].Text = "Total Recepcionado";
            GridView1.HeaderRow.Cells[4].Text = "Total Despachado";
            //GridView1.HeaderRow.Cells[9].Text = "asdasdsda";

            ////int contador = 0;
            //for (contador = 0; contador < GridView1.Rows.Count; contador++)
            //{
            //    GridViewRow row = GridView1.Rows[contador];
            //    row.Cells[9].Visible = false;
            //}
            //    // Tiraje OT
            //    double TirajeOT = Convert.ToDouble(row.Cells[3].Text);
            //    if (row.Cells[3].Text.Length > 3)
            //    {|
            //        string to = TirajeOT.ToString("N0").Replace(",", ".");
            //        row.Cells[3].Text = to;
            //    }
            //    else
            //    {
            //        string to = TirajeOT.ToString("N0");
            //        row.Cells[3].Text = to;
            //    }
            //    //*********************** Total Recepcionado
            //    double TotalRecepcionado = Convert.ToDouble(row.Cells[4].Text);
            //    if (row.Cells[4].Text.Length > 3)
            //    {
            //        string to = TotalRecepcionado.ToString("N0").Replace(",", ".");
            //        row.Cells[4].Text = to;
            //    }
            //    else
            //    {
            //        string to = TotalRecepcionado.ToString("N0");
            //        row.Cells[4].Text = to;
            //    }
            //    //********************** Total Despachado

            //    double TotalDespachado = Convert.ToDouble(row.Cells[5].Text);
            //    if (row.Cells[5].Text.Length > 3)
            //    {
            //        string to = TotalDespachado.ToString("N0").Replace(",", ".");
            //        row.Cells[5].Text = to;
            //    }
            //    else
            //    {
            //        string to = TotalDespachado.ToString("N0");
            //        row.Cells[5].Text = to;
            //    }
            //    //********************** Existencia

            //    double Existencia = Convert.ToDouble(row.Cells[6].Text);
            //    if (row.Cells[6].Text.Length > 3)
            //    {
            //        string to = Existencia.ToString("N0").Replace(",", ".");
            //        row.Cells[6].Text = to;
            //    }
            //    else
            //    {
            //        string to = Existencia.ToString("N0");
            //        row.Cells[6].Text = to;
            //    }
            //}







            string nombre = "Existencia_" + DateTime.Now.ToShortDateString();

            if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
            {
                ExportToExcel(nombre, GridView1, "");//GridView1);
            }
            else
            {
                ExportToExcel(nombre, GridView1, "");//GridView1);
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
            //if (fInicio != "")
            //{
            //    //la.Text = "<div align='center'>INFORME PRODUCTOS RECEPCIONADOS<br/> </div><br/>";
            //}
            //else
            //{
            //   // la.Text = "<div align='center'>INFORME PRODUCTOS RECEPCIONADOS<br/> </div><br/>";
            //}
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