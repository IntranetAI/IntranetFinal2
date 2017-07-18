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

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class InformeDespachos : System.Web.UI.Page
    {
        Controller_InfDespacho cin = new Controller_InfDespacho();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargar();
                DivDetalle.Visible = false;
            }
        }
        public void cargar()
        {
            DateTime vaa = DateTime.Now.AddDays(0);
            string fecha1 = vaa.ToString("MM-dd-yyyy");
            DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
            DateTime FT = Convert.ToDateTime(fecha1 + " 23:59:59");

            RadGrid1.DataSource = cin.cargainfDespacho("", "", FI, FT, 0);
            RadGrid1.DataBind();
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedItem.Text == "Todos")
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    //********************* hacer test cuando hay nombre producto **********************************

                    //if (txtOP.Text == "" && txtNombreOP.Text == "")
                    //{
                        DateTime va1 = Convert.ToDateTime(txtFechaInicio.Text);
                        DateTime va2 = Convert.ToDateTime(txtFechaTermino.Text);
                        string fecha1 = va1.ToString("MM-dd-yyyy");
                        string fecha2 = va2.ToString("MM-dd-yyyy");
                        DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
                        DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");

                        RadGrid1.DataSource = cin.cargainfDespacho(txtOP.Text, txtNombreOP.Text, FI, FT, 0);
                        RadGrid1.DataBind();

                }
                else
                {
                    DateTime FI = Convert.ToDateTime("1900-01-01 00:00:00");
                    DateTime FT = Convert.ToDateTime("1900-01-01 23:59:59");
                    RadGrid1.DataSource = cin.cargainfDespacho(txtOP.Text, txtNombreOP.Text, FI, FT, 4);
                    RadGrid1.DataBind();
                }
            }
            else
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    DateTime va1 = Convert.ToDateTime(txtFechaInicio.Text);
                    DateTime va2 = Convert.ToDateTime(txtFechaTermino.Text);
                    string fecha1 = va1.ToString("MM-dd-yyyy");
                    string fecha2 = va2.ToString("MM-dd-yyyy");
                    DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
                    DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");

                    RadGrid1.DataSource = cin.cargainfDespacho(txtOP.Text, txtNombreOP.Text, FI, FT, 2);//procedimiento con fechas
                    RadGrid1.DataBind();
                    DivAgrupado.Visible = true;
                    DivDetalle.Visible = false;
                }
                else
                {

                    DateTime FI = Convert.ToDateTime("1900-01-01 00:00:00");
                    DateTime FT = Convert.ToDateTime("1900-01-01 23:59:59");
                    //filtro solo por fechas, cargar agrupada
                    RadGrid1.DataSource = cin.cargainfDespacho(txtOP.Text, txtNombreOP.Text, FI, FT, 3);//procedimiento sin fechas
                    RadGrid1.DataBind();
                    DivAgrupado.Visible = true;
                    DivDetalle.Visible = false;
                    //ejecuta procedimiento busca de liquidadas
                }
            }

        }
        //*************************************************************************************************************//

        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {

            GridDataItem item = (GridDataItem)e.Item;

            string OT = item["OT"].Text;
            lblOTDetalle.Text = OT;

            DateTime FI = Convert.ToDateTime("1900-01-01 00:00:00");
            DateTime FT = Convert.ToDateTime("1900-01-01 23:59:59");

            RadGrid2.DataSource = cin.cargainfDespacho_Detalle(OT, "", FI, FT, 1);
            RadGrid2.DataBind();

            DivAgrupado.Visible = false;
            DivDetalle.Visible = true;
        
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            GridView GridView1 = new GridView();

            if (DivAgrupado.Visible == true)
            {
                if (ddlEstado.SelectedItem.Text == "Liquidadas")
                {
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        DateTime va1 = Convert.ToDateTime(txtFechaInicio.Text);
                        DateTime va2 = Convert.ToDateTime(txtFechaTermino.Text);
                        string fecha1 = va1.ToString("MM-dd-yyyy");
                        string fecha2 = va2.ToString("MM-dd-yyyy");
                        DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
                        DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");

                        GridView1.DataSource = cin.Excel_OTLiquidada(txtOP.Text, txtNombreOP.Text, FI, FT, 2);
                        //con fecha
                        GridView1.DataBind();
                        GridView1.HeaderRow.Cells[4].Text = "Cliente";


                        string nombre = "OT Liquidada Despacho " + DateTime.Now.ToShortDateString();

                        if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                        {
                            ExportToExcel(nombre, GridView1, "");//GridView1);
                        }
                        else
                        {
                            ExportToExcel(nombre, GridView1, "");//GridView1);
                        }
                    }
                    else
                    {
                        DateTime FI = Convert.ToDateTime("1900-01-01 00:00:00");
                        DateTime FT = Convert.ToDateTime("1900-01-01 23:59:59");

                        GridView1.DataSource = cin.Excel_OTLiquidada(txtOP.Text, txtNombreOP.Text, FI, FT, 1);
                        //sin fecha
                        GridView1.DataBind();
                        GridView1.HeaderRow.Cells[4].Text = "Cliente";

                        //GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                        //GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

                        string nombre = "OT Liquidada Despacho " + DateTime.Now.ToShortDateString();

                        if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                        {
                            ExportToExcel(nombre, GridView1, "");//GridView1);
                        }
                        else
                        {
                            ExportToExcel(nombre, GridView1, "");//GridView1);
                        }
                    }

                }
                else
                {
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {
                        DateTime va1 = Convert.ToDateTime(txtFechaInicio.Text);
                        DateTime va2 = Convert.ToDateTime(txtFechaTermino.Text);
                        string fecha1 = va1.ToString("MM-dd-yyyy");
                        string fecha2 = va2.ToString("MM-dd-yyyy");
                        DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
                        DateTime FT = Convert.ToDateTime(fecha2 + " 23:59:59");

                        GridView1.DataSource = cin.infDespacho_Excel(txtOP.Text, txtNombreOP.Text, FI, FT, 0);
                        GridView1.DataBind();
                        //Recorrer
                        GridView1.HeaderRow.Cells[1].Text = "Nombre OT";
                        GridView1.HeaderRow.Cells[3].Text = "Despacho Enc.";
                        GridView1.HeaderRow.Cells[4].Text = "Recibido QGChile";


                        int contador = 0;
                        for (contador = 0; contador < GridView1.Rows.Count; contador++)
                        {
                            GridViewRow row = GridView1.Rows[contador];
                            // Tiraje OT
                            double TirajeOT = Convert.ToDouble(row.Cells[2].Text);
                            if (row.Cells[2].Text.Length > 3)
                            {
                                string to = TirajeOT.ToString("N0").Replace(",", ".");
                                row.Cells[2].Text = to;
                            }
                            else
                            {
                                string to = TirajeOT.ToString("N0");
                                row.Cells[2].Text = to;
                            }
                            //despacho ENC
                            double DespachoEnc = Convert.ToDouble(row.Cells[3].Text);
                            if (row.Cells[3].Text.Length > 3)
                            {
                                string to = DespachoEnc.ToString("N0").Replace(",", ".");
                                row.Cells[3].Text = to;
                            }
                            else
                            {
                                string to = DespachoEnc.ToString("N0");
                                row.Cells[3].Text = to;
                            }
                            //Recibido QGchile
                            double RecibidoQG = Convert.ToDouble(row.Cells[4].Text);
                            if (row.Cells[4].Text.Length > 3)
                            {
                                string to = RecibidoQG.ToString("N0").Replace(",", ".");
                                row.Cells[4].Text = to;
                            }
                            else
                            {
                                string to = RecibidoQG.ToString("N0");
                                row.Cells[4].Text = to;
                            }

                            //Saldo
                            double Saldo = Convert.ToDouble(row.Cells[5].Text);
                            if (row.Cells[5].Text.Length > 3)
                            {
                                string to = Saldo.ToString("N0").Replace(",", ".");
                                row.Cells[5].Text = to;
                            }
                            else
                            {
                                string to = Saldo.ToString("N0");
                                row.Cells[5].Text = to;
                            }
                        }


                        string nombre = " Informe Despachos " + DateTime.Now.ToShortDateString();

                        if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                        {
                            ExportToExcel(nombre, GridView1, "");//GridView1);
                        }
                        else
                        {
                            ExportToExcel(nombre, GridView1, "");//GridView1);
                        }
                    }
                    else
                    {
                        //excepcion si es por defecto sin variables
                        if (txtOP.Text == "" && txtNombreOP.Text == "")
                        {
                            //cargar por defecto
                            DateTime vaa = DateTime.Now.AddDays(0);
                            string fecha1 = vaa.ToString("MM-dd-yyyy");
                            DateTime FI = Convert.ToDateTime(fecha1 + " 00:00:00");
                            DateTime FT = Convert.ToDateTime(fecha1 + " 23:59:59");


                            GridView1.DataSource = cin.infDespacho_Excel(txtOP.Text, txtNombreOP.Text, FI, FT, 0);
                        }
                        else
                        {
                            DateTime FI = Convert.ToDateTime("1900-01-01 00:00:00");
                            DateTime FT = Convert.ToDateTime("1900-01-01 23:59:59");

                            GridView1.DataSource = cin.infDespacho_Excel(txtOP.Text, txtNombreOP.Text, FI, FT, 4);


                        }
                        GridView1.DataBind();
                        GridView1.HeaderRow.Cells[1].Text = "Nombre OT";
                        GridView1.HeaderRow.Cells[3].Text = "Despacho Enc.";
                        GridView1.HeaderRow.Cells[4].Text = "Recibido QGChile";


                        int contador = 0;
                        for (contador = 0; contador < GridView1.Rows.Count; contador++)
                        {
                            GridViewRow row = GridView1.Rows[contador];
                            // Tiraje OT
                            double TirajeOT = Convert.ToDouble(row.Cells[2].Text);
                            if (row.Cells[2].Text.Length > 3)
                            {
                                string to = TirajeOT.ToString("N0").Replace(",", ".");
                                row.Cells[2].Text = to;
                            }
                            else
                            {
                                string to = TirajeOT.ToString("N0");
                                row.Cells[2].Text = to;
                            }
                            //despacho ENC
                            double DespachoEnc = Convert.ToDouble(row.Cells[3].Text);
                            if (row.Cells[3].Text.Length > 3)
                            {
                                string to = DespachoEnc.ToString("N0").Replace(",", ".");
                                row.Cells[3].Text = to;
                            }
                            else
                            {
                                string to = DespachoEnc.ToString("N0");
                                row.Cells[3].Text = to;
                            }
                            //Recibido QGchile
                            double RecibidoQG = Convert.ToDouble(row.Cells[4].Text);
                            if (row.Cells[4].Text.Length > 3)
                            {
                                string to = RecibidoQG.ToString("N0").Replace(",", ".");
                                row.Cells[4].Text = to;
                            }
                            else
                            {
                                string to = RecibidoQG.ToString("N0");
                                row.Cells[4].Text = to;
                            }

                            //Saldo
                            double Saldo = Convert.ToDouble(row.Cells[5].Text);
                            if (row.Cells[5].Text.Length > 3)
                            {
                                string to = Saldo.ToString("N0").Replace(",", ".");
                                row.Cells[5].Text = to;
                            }
                            else
                            {
                                string to = Saldo.ToString("N0");
                                row.Cells[5].Text = to;
                            }
                        }


                        string nombre = " Informe Despachos " + DateTime.Now.ToShortDateString();

                        if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                        {
                            ExportToExcel(nombre, GridView1, "");//GridView1);
                        }
                        else
                        {
                            ExportToExcel(nombre, GridView1, "");//GridView1);
                        }
                    }
                }





            }
            else//detalle de la OT
            { 
                DateTime FI = Convert.ToDateTime("1900-01-01 00:00:00");
                DateTime FT = Convert.ToDateTime("1900-01-01 23:59:59");
                GridView1.DataSource = cin.cargainfDespacho_Detalle_Excel(lblOTDetalle.Text, "", FI, FT, 1);
                GridView1.DataBind();

                GridView1.HeaderRow.Cells[2].Text = "Nombre OT";
                GridView1.HeaderRow.Cells[4].Text = "Cantidad Bultos";
                GridView1.HeaderRow.Cells[5].Text = "Ejem. por Bulto";
                GridView1.HeaderRow.Cells[6].Text = "Total Ejemplares";
                GridView1.HeaderRow.Cells[8].Text = "Fecha/Hora";
                GridView1.HeaderRow.Cells[9].Visible = false;


                int contador = 0;
                for (contador = 0; contador < GridView1.Rows.Count; contador++)
                {
                    GridViewRow row = GridView1.Rows[contador];
                    // Tiraje OT
                    if (row.Cells[4].Text != "&nbsp;")
                    {
                        double cantBultos = Convert.ToDouble(row.Cells[4].Text);
                        if (row.Cells[4].Text.Length > 3)
                        {
                            string to = cantBultos.ToString("N0").Replace(",", ".");
                            row.Cells[4].Text = to;
                        }
                        else
                        {
                            string to = cantBultos.ToString("N0");
                            row.Cells[4].Text = to;
                        }
                    }
                    else
                    {
                        row.Cells[4].Text = "";
                    }
                    //despacho ENC
                    if (row.Cells[5].Text != "&nbsp;")
                    {
                        double EjemxBultos = Convert.ToDouble(row.Cells[5].Text);
                        if (row.Cells[5].Text.Length > 3)
                        {
                            string to = EjemxBultos.ToString("N0").Replace(",", ".");
                            row.Cells[5].Text = to;
                        }
                        else
                        {
                            string to = EjemxBultos.ToString("N0");
                            row.Cells[5].Text = to;
                        }
                    }
                    else
                    {
                        row.Cells[5].Text = "";
                    }
                    //Recibido QGchile
                    if (row.Cells[6].Text != "&nbsp;")
                    {
                        double Total = Convert.ToDouble(row.Cells[6].Text);
                        if (row.Cells[6].Text.Length > 3)
                        {
                            string to = Total.ToString("N0").Replace(",", ".");
                            row.Cells[6].Text = to;
                        }
                        else
                        {
                            string to = Total.ToString("N0");
                            row.Cells[6].Text = to;
                        }
                    }
                    else
                    {
                        row.Cells[6].Text = "";
                    }

                    row.Cells[9].Visible = false;

                }


                string nombre = " Informe Despachos Detallado " + DateTime.Now.ToShortDateString();

                if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                {
                    ExportToExcel(nombre, GridView1, "");//GridView1);
                }
                else
                {
                    ExportToExcel(nombre, GridView1, "");//GridView1);
                }
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