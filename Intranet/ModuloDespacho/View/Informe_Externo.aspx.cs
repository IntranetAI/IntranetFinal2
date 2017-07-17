using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloDespacho.Controller;
using Telerik.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloDespacho.View
{
    public partial class Informe_Externo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos("comienzo");
            }
        }

        public void CargarDatos(string inicio)
        {
            Factura f = new Factura();
            f.OT = txtOT.Text;
            f.Nombre = txtproveedor.Text;
            if (txtnroFactura.Text.Trim() != "")
            {
                f.NFactura = Convert.ToInt32(txtnroFactura.Text);
            }
            if (txtFechaInicio.Text.Trim() != "")
            {
                string[] feInicio = txtFechaInicio.Text.Split('-');
                f.Ciudad = feInicio[2] + "-" + feInicio[1] + "-" + feInicio[0];
            }
            if (txtFechaTermino.Text.Trim() != "")
            {
                string[] feTermino = txtFechaTermino.Text.Split('-');
                f.Comuna = feTermino[2] + "-" + feTermino[1] + "-" + feTermino[0];
            }
            if (inicio == "comienzo")
            {
                f.Ciudad = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                f.Comuna = DateTime.Now.ToString("yyyy-MM-dd");
            }
            Controller_Factura controlf = new Controller_Factura();
            RadGridOT.DataSource = controlf.listarInfExterno(f);
            RadGridOT.DataBind();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            CargarDatos("filtro");
        }

        private void ExportarExcelMes()
        {
            string inicio = "comienzo";
            Factura f = new Factura();
            f.OT = txtOT.Text;
            f.Nombre = txtproveedor.Text;
            if (txtnroFactura.Text.Trim() != "")
            {
                f.NFactura = Convert.ToInt32(txtnroFactura.Text);
            }
            if (txtFechaTermino.Text.Trim() != "")
            {
                string[] feTermino = txtFechaTermino.Text.Split('-');
                f.Comuna = feTermino[2] + "-" + feTermino[1] + "-" + feTermino[0];
            }
            if (txtFechaInicio.Text.Trim() != "")
            {
                string[] feInicio = txtFechaInicio.Text.Split('-');
                f.Ciudad = feInicio[2] + "-" + feInicio[1] + "-" + feInicio[0];
            }
            else if (inicio == "comienzo")
            {

                f.Ciudad = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-01";
                DateTime messiguente = Convert.ToDateTime(DateTime.Now.AddMonths(+1).ToString("MM") + "-" + "01" + "-" + DateTime.Now.ToString("yyyy"));
                f.Comuna = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + messiguente.AddDays(-1).ToString("dd");
            }
            Controller_Factura controlf = new Controller_Factura();

            List<Factura> lista = controlf.listarInfExterno(f);

            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Range chartRange;
            //add data 
            #region Grilla Principal
            int ContadorRows = 1;
            int ContadorCells = 5;
            int Contado = 0;
            Microsoft.Office.Interop.Excel.Range rangoInicial = null;
            Microsoft.Office.Interop.Excel.Range rangoFinal = null;
            Microsoft.Office.Interop.Excel.Range rango1 = null;
            Microsoft.Office.Interop.Excel.Range rangoGridIni = null;
            Microsoft.Office.Interop.Excel.Range rangoGridFin = null;
            foreach (Factura fac in lista)
            {
                if (Contado == 0)
                {
                    rango1 = xlWorkSheet.Cells[ContadorCells - 1, ContadorRows];
                    Microsoft.Office.Interop.Excel.Range rango2 = xlWorkSheet.Cells[ContadorCells - 1, ContadorRows + 7];

                    xlWorkSheet.Cells[ContadorCells - 1, ContadorRows] = "Fecha";
                    xlWorkSheet.Cells[ContadorCells - 1, ContadorRows + 1] = "O.T.";
                    xlWorkSheet.Cells[ContadorCells - 1, ContadorRows + 2] = "Producto";
                    xlWorkSheet.Cells[ContadorCells - 1, ContadorRows + 3] = "Proveedor";
                    xlWorkSheet.Cells[ContadorCells - 1, ContadorRows + 4] = "Nº Factura";
                    xlWorkSheet.Cells[ContadorCells - 1, ContadorRows + 5] = "Valor Neto";
                    xlWorkSheet.Cells[ContadorCells - 1, ContadorRows + 6] = "I.V.A 19%";
                    xlWorkSheet.Cells[ContadorCells - 1, ContadorRows + 7] = "TOTAL";
                    chartRange = xlWorkSheet.get_Range(rango1, rango2);
                    chartRange.Font.Bold = true;
                    chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    rangoInicial = xlWorkSheet.Cells[ContadorCells - 3, ContadorRows];
                    rangoFinal = xlWorkSheet.Cells[ContadorCells - 3, ContadorRows + 7];
                }
                xlWorkSheet.Cells[ContadorCells, ContadorRows] = fac.Ciudad;
                xlWorkSheet.Cells[ContadorCells, ContadorRows + 1] = fac.OT;
                xlWorkSheet.Cells[ContadorCells, ContadorRows + 2] = fac.NombreOT;
                xlWorkSheet.Cells[ContadorCells, ContadorRows + 3] = fac.Nombre;
                xlWorkSheet.Cells[ContadorCells, ContadorRows + 4] = fac.NFactura;
                xlWorkSheet.Cells[ContadorCells, ContadorRows + 5] = fac.Sucursal;
                xlWorkSheet.Cells[ContadorCells, ContadorRows + 6] = fac.Rut;
                xlWorkSheet.Cells[ContadorCells, ContadorRows + 7] = fac.Tipo;
                rangoGridIni = xlWorkSheet.Cells[ContadorCells - 1, ContadorRows];
                rangoGridFin = xlWorkSheet.Cells[ContadorCells, ContadorRows + 7];
                Contado++;
                ContadorCells++;
            }

            xlWorkSheet.get_Range(rangoInicial, rangoFinal).Merge(false);
            chartRange = xlWorkSheet.get_Range(rango1, rangoGridFin);
            chartRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            chartRange = xlWorkSheet.get_Range(rangoInicial, rangoFinal);
            chartRange.FormulaR1C1 = "Factura Mes de Noviembre 2014";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            chartRange.Font.Size = 11;
            chartRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
            #endregion
            #region Grilla OT
            int ContadorRowsOT = 2;
            int ContadorCellsOT = Contado + 10;
            int ContadoOT = 0;
            List<Factura> lista1 = controlf.listarExternoMensual(f.Ciudad, 1);
            Microsoft.Office.Interop.Excel.Range rangoInicialOT = null;
            Microsoft.Office.Interop.Excel.Range rangoFinalOT = null;
            Microsoft.Office.Interop.Excel.Range rango1OT = null;
            Microsoft.Office.Interop.Excel.Range rangoGridFinOT = null;
            foreach (Factura fac in lista1)
            {
                if (ContadoOT == 0)
                {
                    rango1OT = xlWorkSheet.Cells[ContadorCellsOT - 1, ContadorRowsOT];
                    Microsoft.Office.Interop.Excel.Range rango2 = xlWorkSheet.Cells[ContadorCellsOT - 1, ContadorRowsOT + 6];

                    xlWorkSheet.Cells[ContadorCellsOT - 1, ContadorRowsOT] = "O.T.";
                    xlWorkSheet.Cells[ContadorCellsOT - 1, ContadorRowsOT + 1] = "Producto";
                    xlWorkSheet.Cells[ContadorCellsOT - 1, ContadorRowsOT + 2] = "Proceso";
                    xlWorkSheet.Cells[ContadorCellsOT - 1, ContadorRowsOT + 3] = "Valor M2";
                    xlWorkSheet.Cells[ContadorCellsOT - 1, ContadorRowsOT + 4] = "Cantidad";
                    xlWorkSheet.Cells[ContadorCellsOT - 1, ContadorRowsOT + 5] = "Costo";
                    xlWorkSheet.Cells[ContadorCellsOT - 1, ContadorRowsOT + 6] = "TOTAL";
                    chartRange = xlWorkSheet.get_Range(rango1OT, rango2);
                    chartRange.Font.Bold = true;
                    chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    rangoInicialOT = xlWorkSheet.Cells[ContadorCellsOT - 3, ContadorRowsOT];
                    rangoFinalOT = xlWorkSheet.Cells[ContadorCellsOT - 3, ContadorRowsOT + 6];
                }
                xlWorkSheet.Cells[ContadorCellsOT, ContadorRowsOT] = fac.OT;
                xlWorkSheet.Cells[ContadorCellsOT, ContadorRowsOT + 1] = fac.NombreOT;
                xlWorkSheet.Cells[ContadorCellsOT, ContadorRowsOT + 2] = fac.Proceso;
                xlWorkSheet.Cells[ContadorCellsOT, ContadorRowsOT + 3] = fac.M2;
                xlWorkSheet.Cells[ContadorCellsOT, ContadorRowsOT + 4] = Convert.ToInt32(fac.Cant).ToString("N0").Replace(",", ".");
                string[] split = fac.Costo.Split('.');
                if (split.Count() == 2)
                {
                    xlWorkSheet.Cells[ContadorCellsOT, ContadorRowsOT + 5] = Convert.ToInt32(split[0]).ToString("N0").Replace(",", ".") + "," + split[1];
                }
                else
                {
                    xlWorkSheet.Cells[ContadorCellsOT, ContadorRowsOT + 5] = Convert.ToInt32(split[0]).ToString("N0").Replace(",", ".");
                }
                xlWorkSheet.Cells[ContadorCellsOT, ContadorRowsOT + 6] = Convert.ToInt32(fac.Total).ToString("N0").Replace(",", ".");
                rangoGridFinOT = xlWorkSheet.Cells[ContadorCellsOT, ContadorRowsOT + 6];
                ContadoOT++;
                ContadorCellsOT++;
            }

            xlWorkSheet.get_Range(rangoInicialOT, rangoFinalOT).Merge(false);
            chartRange = xlWorkSheet.get_Range(rango1OT, rangoGridFinOT);
            chartRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            chartRange = xlWorkSheet.get_Range(rangoInicialOT, rangoFinalOT);
            chartRange.FormulaR1C1 = "Factura Mes por OT";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            chartRange.Font.Size = 11;
            chartRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
            #endregion
            #region Grilla Proveedor
            int ContadorRowsPro = 3;
            int ContadorCellsPro = ContadorCellsOT + 5;
            int ContadoPro = 0;
            List<Factura> lista2 = controlf.listarExternoMensual(f.Ciudad, 2);
            Microsoft.Office.Interop.Excel.Range rangoInicialPro = null;
            Microsoft.Office.Interop.Excel.Range rangoFinalPro = null;
            Microsoft.Office.Interop.Excel.Range rango1Pro = null;
            Microsoft.Office.Interop.Excel.Range rangoGridFinPro = null;
            foreach (Factura fac in lista2)
            {
                if (ContadoPro == 0)
                {
                    rango1Pro = xlWorkSheet.Cells[ContadorCellsPro - 1, ContadorRowsPro];
                    Microsoft.Office.Interop.Excel.Range rango2 = xlWorkSheet.Cells[ContadorCellsPro - 1, ContadorRowsPro + 2];

                    xlWorkSheet.Cells[ContadorCellsPro - 1, ContadorRowsPro] = "Proveedor";
                    xlWorkSheet.Cells[ContadorCellsPro - 1, ContadorRowsPro + 1] = "Proceso";
                    xlWorkSheet.Cells[ContadorCellsPro - 1, ContadorRowsPro + 2] = "Total";
                    chartRange = xlWorkSheet.get_Range(rango1Pro, rango2);
                    chartRange.Font.Bold = true;
                    chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    rangoInicialPro = xlWorkSheet.Cells[ContadorCellsPro - 3, ContadorRowsPro];
                    rangoFinalPro = xlWorkSheet.Cells[ContadorCellsPro - 3, ContadorRowsPro + 2];
                }
                xlWorkSheet.Cells[ContadorCellsPro, ContadorRowsPro] = fac.Nombre;
                xlWorkSheet.Cells[ContadorCellsPro, ContadorRowsPro + 1] = fac.Proceso;
                xlWorkSheet.Cells[ContadorCellsPro, ContadorRowsPro + 2] = Convert.ToInt32(fac.Total).ToString("N0").Replace(",", ".");
                rangoGridFinPro = xlWorkSheet.Cells[ContadorCellsPro, ContadorRowsPro + 2];
                ContadoPro++;
                ContadorCellsPro++;
            }

            xlWorkSheet.get_Range(rangoInicialPro, rangoFinalPro).Merge(false);
            chartRange = xlWorkSheet.get_Range(rango1Pro, rangoGridFinPro);
            chartRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            chartRange = xlWorkSheet.get_Range(rangoInicialPro, rangoFinalPro);
            chartRange.FormulaR1C1 = "Factura Mes por Proveedor";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            chartRange.Font.Size = 11;
            chartRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
            #endregion
            #region Grilla Proceso
            int ContadorRowsPcs = 3;
            int ContadorCellsPcs = ContadorCellsPro + 5;
            int ContadoPcs = 0;
            List<Factura> lista3 = controlf.listarExternoMensual(f.Ciudad, 3);
            Microsoft.Office.Interop.Excel.Range rangoInicialPcs = null;
            Microsoft.Office.Interop.Excel.Range rangoFinalPcs = null;
            Microsoft.Office.Interop.Excel.Range rango1Pcs = null;
            Microsoft.Office.Interop.Excel.Range rangoGridFinPcs = null;
            foreach (Factura fac in lista3)
            {
                if (ContadoPcs == 0)
                {
                    rango1Pcs = xlWorkSheet.Cells[ContadorCellsPcs - 1, ContadorRowsPcs];
                    Microsoft.Office.Interop.Excel.Range rango2 = xlWorkSheet.Cells[ContadorCellsPcs - 1, ContadorRowsPcs + 1];

                    xlWorkSheet.Cells[ContadorCellsPcs - 1, ContadorRowsPcs] = "Proceso";
                    xlWorkSheet.Cells[ContadorCellsPcs - 1, ContadorRowsPcs + 1] = "Total";
                    chartRange = xlWorkSheet.get_Range(rango1Pcs, rango2);
                    chartRange.Font.Bold = true;
                    chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    rangoInicialPcs = xlWorkSheet.Cells[ContadorCellsPcs - 3, ContadorRowsPcs];
                    rangoFinalPcs = xlWorkSheet.Cells[ContadorCellsPcs - 3, ContadorRowsPcs + 1];
                }
                xlWorkSheet.Cells[ContadorCellsPcs, ContadorRowsPcs] = fac.Proceso;
                xlWorkSheet.Cells[ContadorCellsPcs, ContadorRowsPcs + 1] = Convert.ToInt32(fac.Total).ToString("N0").Replace(",", ".");
                rangoGridFinPcs = xlWorkSheet.Cells[ContadorCellsPcs, ContadorRowsPcs + 1];
                ContadoPcs++;
                ContadorCellsPcs++;
            }

            xlWorkSheet.get_Range(rangoInicialPcs, rangoFinalPcs).Merge(false);
            chartRange = xlWorkSheet.get_Range(rango1Pcs, rangoGridFinPcs);
            chartRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            chartRange = xlWorkSheet.get_Range(rangoInicialPcs, rangoFinalPcs);
            chartRange.FormulaR1C1 = "Factura Mes por Proceso";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            chartRange.Font.Size = 11;
            chartRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
            #endregion
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (RadGridOT.Items.Count > 0)
            {
                Controller_Factura controlf = new Controller_Factura();
                List<Factura> lista = new List<Factura>();
                for (int i = 0; i < RadGridOT.Items.Count; i++)
                {
                    Factura f = new Factura();
                    GridDataItem row = RadGridOT.Items[i];
                    f.Ciudad = row["Ciudad"].Text;
                    f.OT = row["OT"].Text;
                    f.NombreOT = row["NombreOT"].Text;
                    f.Proceso = row["Nombre"].Text;
                    f.NFactura = Convert.ToInt32(row["NFactura"].Text);
                    f.Sucursal = row["Sucursal"].Text;
                    f.Rut = row["Rut"].Text;
                    f.Tipo = row["Tipo"].Text;
                    lista.Add(f);
                }
                GridView gv1 = new GridView();

                gv1.DataSource = lista;
                gv1.DataBind();
                gv1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv1.HeaderStyle.ForeColor = System.Drawing.Color.White;


                gv1.HeaderRow.Cells[0].Text = "Fecha";
                gv1.HeaderRow.Cells[1].Text = "O.T.";
                gv1.HeaderRow.Cells[2].Text = "Producto";
                gv1.HeaderRow.Cells[3].Text = "Proveedor";
                gv1.HeaderRow.Cells[4].Text = "Nº Factura";
                gv1.HeaderRow.Cells[5].Text = "Valor Neto";
                gv1.HeaderRow.Cells[6].Text = "I.V.A  19%";
                gv1.HeaderRow.Cells[7].Text = "TOTAL";
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
                //gv1.ControlStyle.AddAttributesToRender();

                for (int contador = 0; contador < gv1.Rows.Count; contador++)
                {
                    GridViewRow row = gv1.Rows[contador];
                    row.Cells[0].Text = row.Cells[20].Text;
                    row.Cells[4].Text = row.Cells[1].Text;
                    row.Cells[1].Text = row.Cells[2].Text;
                    row.Cells[2].Text = row.Cells[3].Text;
                    row.Cells[3].Text = row.Cells[5].Text;
                    row.Cells[5].Text = row.Cells[18].Text;
                    row.Cells[6].Text = row.Cells[15].Text;
                    row.Cells[7].Text = row.Cells[8].Text;
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

                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string mes = "";
                    string[] feInicio = txtFechaInicio.Text.Split('-');
                    switch (Convert.ToInt32(feInicio[1]))
                    {
                        case 1: mes = "Enero"; break;
                        case 2: mes = "Febrero"; break;
                        case 3: mes = "Marzo"; break;
                        case 4: mes = "Abril"; break;
                        case 5: mes = "Mayo"; break;
                        case 6: mes = "Junio"; break;
                        case 7: mes = "Julio"; break;
                        case 8: mes = "Agosto"; break;
                        case 9: mes = "Septiembre"; break;
                        case 10: mes = "Octubre"; break;
                        case 11: mes = "Noviembre"; break;
                        case 12: mes = "Diciembre"; break;
                    }
                    string Fecha = feInicio[2] + "-" + feInicio[1] + "-" + feInicio[0];

                    ExportToExcel(mes + " " + feInicio[2], gv1, mes + " " + feInicio[2]);
                }
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

            la.Text = "<div align='center'>Factura Mes de " + Fecha + "</div><br />";
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

        private void ExportToExcel2(string nameReport, GridView wControl, GridView gvProceso, GridView gvProveedor, GridView gvOT, string Fecha)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            StringWriter sw2 = new StringWriter();
            StringWriter sw3 = new StringWriter();
            StringWriter sw4 = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlTextWriter htw2 = new HtmlTextWriter(sw2);
            HtmlTextWriter htw3 = new HtmlTextWriter(sw3);
            HtmlTextWriter htw4 = new HtmlTextWriter(sw4);
            Page pageToRender = new Page();
            Page pageToRender2 = new Page();
            Page pageToRender3 = new Page();
            Page pageToRender4 = new Page();

            HtmlForm form = new HtmlForm();
            HtmlForm form2 = new HtmlForm();
            HtmlForm form3 = new HtmlForm();
            HtmlForm form4 = new HtmlForm();

            Label la = new Label(); Label lblTituto2 = new Label(); Label lblTituto3 = new Label(); Label lblTituto4 = new Label();

            la.Text = "<div align='center'>Factura Mes de " + Fecha + "</div><br />";
            lblTituto2.Text = "<div align='center'>Informe Servicio Externo  " + Fecha + "</div><br /><div aling='center'>";
            lblTituto3.Text = lblTituto2.Text;
            lblTituto4.Text = lblTituto2.Text;
            Label lblCierre = new Label(); lblCierre.Text = "</div>";
            form.Controls.Add(la);
            form.Controls.Add(wControl);
            pageToRender.Controls.Add(form);

            form2.Controls.Add(lblTituto2);
            form2.Controls.Add(gvProceso);
            form2.Controls.Add(lblCierre);
            pageToRender2.Controls.Add(form2);

            form3.Controls.Add(lblTituto3);
            form3.Controls.Add(gvProveedor);
            pageToRender3.Controls.Add(form3);

            form4.Controls.Add(lblTituto4);
            form4.Controls.Add(gvOT);
            pageToRender4.Controls.Add(form4);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport + ".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            pageToRender2.RenderControl(htw);
            pageToRender3.RenderControl(htw);
            pageToRender4.RenderControl(htw);
            response.Write(sw.ToString());
            response.Write(sw2.ToString());
            response.Write(sw3.ToString());
            response.Write(sw4.ToString());
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            response.Write(style);

            response.End();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (RadGridOT.Items.Count > 0)
            {
                Controller_Factura controlf = new Controller_Factura();
                List<Factura> lista = new List<Factura>();
                for (int i = 0; i < RadGridOT.Items.Count; i++)
                {
                    Factura f = new Factura();
                    GridDataItem row = RadGridOT.Items[i];
                    f.Ciudad = row["Ciudad"].Text;
                    f.OT = row["OT"].Text;
                    f.NombreOT = row["NombreOT"].Text;
                    f.Proceso = row["Nombre"].Text;
                    f.NFactura = Convert.ToInt32(row["NFactura"].Text);
                    f.Sucursal = row["Sucursal"].Text;
                    f.Rut = row["Rut"].Text;
                    f.Tipo = row["Tipo"].Text;
                    lista.Add(f);
                }
                GridView gv1 = new GridView();

                gv1.DataSource = lista;
                gv1.DataBind();
                gv1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv1.HeaderStyle.ForeColor = System.Drawing.Color.White;


                gv1.HeaderRow.Cells[0].Text = "Fecha";
                gv1.HeaderRow.Cells[1].Text = "O.T.";
                gv1.HeaderRow.Cells[2].Text = "Producto";
                gv1.HeaderRow.Cells[3].Text = "Proveedor";
                gv1.HeaderRow.Cells[4].Text = "Nº Factura";
                gv1.HeaderRow.Cells[5].Text = "Valor Neto";
                gv1.HeaderRow.Cells[6].Text = "I.V.A  19%";
                gv1.HeaderRow.Cells[7].Text = "TOTAL";
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
                //gv1.ControlStyle.AddAttributesToRender();

                for (int contador = 0; contador < gv1.Rows.Count; contador++)
                {
                    GridViewRow row = gv1.Rows[contador];
                    row.Cells[0].Text = row.Cells[20].Text;
                    row.Cells[4].Text = row.Cells[1].Text;
                    row.Cells[1].Text = row.Cells[2].Text;
                    row.Cells[2].Text = row.Cells[3].Text;
                    row.Cells[3].Text = row.Cells[5].Text;
                    row.Cells[5].Text = row.Cells[18].Text;
                    row.Cells[6].Text = row.Cells[15].Text;
                    row.Cells[7].Text = row.Cells[8].Text;
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

                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string mes = "";
                    string[] feInicio = txtFechaInicio.Text.Split('-');
                    switch (Convert.ToInt32(feInicio[1]))
                    {
                        case 1: mes = "Enero"; break;
                        case 2: mes = "Febrero"; break;
                        case 3: mes = "Marzo"; break;
                        case 4: mes = "Abril"; break;
                        case 5: mes = "Mayo"; break;
                        case 6: mes = "Junio"; break;
                        case 7: mes = "Julio"; break;
                        case 8: mes = "Agosto"; break;
                        case 9: mes = "Septiembre"; break;
                        case 10: mes = "Octubre"; break;
                        case 11: mes = "Noviembre"; break;
                        case 12: mes = "Diciembre"; break;
                    }
                    string Fecha = feInicio[2] + "-" + feInicio[1] + "-" + feInicio[0];

                    #region Proceso
                    GridView GrillaProceso = new GridView();
                    GrillaProceso.DataSource = controlf.listarExternoMensual(Fecha, 3);
                    GrillaProceso.DataBind();
                    GrillaProceso.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                    GrillaProceso.HeaderStyle.ForeColor = System.Drawing.Color.White;
                    GrillaProceso.HeaderRow.Cells[0].Text = "";
                    GrillaProceso.HeaderRow.Cells[0].Style.Add("BORDER", "0px");
                    GrillaProceso.HeaderRow.Cells[0].BackColor = System.Drawing.Color.White;
                    GrillaProceso.HeaderRow.Cells[1].Text = "";
                    GrillaProceso.HeaderRow.Cells[1].Style.Add("BORDER", "0px");
                    GrillaProceso.HeaderRow.Cells[1].BackColor = System.Drawing.Color.White;
                    GrillaProceso.HeaderRow.Cells[2].Text = "Proceso";
                    GrillaProceso.HeaderRow.Cells[3].Text = "Valor";
                    GrillaProceso.HeaderRow.Cells[4].Visible = false;
                    GrillaProceso.HeaderRow.Cells[5].Visible = false;
                    GrillaProceso.HeaderRow.Cells[6].Visible = false;
                    GrillaProceso.HeaderRow.Cells[7].Visible = false;
                    GrillaProceso.HeaderRow.Cells[8].Visible = false;
                    GrillaProceso.HeaderRow.Cells[9].Visible = false;
                    GrillaProceso.HeaderRow.Cells[10].Visible = false;
                    GrillaProceso.HeaderRow.Cells[11].Visible = false;
                    GrillaProceso.HeaderRow.Cells[12].Visible = false;
                    GrillaProceso.HeaderRow.Cells[13].Visible = false;
                    GrillaProceso.HeaderRow.Cells[14].Visible = false;
                    GrillaProceso.HeaderRow.Cells[15].Visible = false;
                    GrillaProceso.HeaderRow.Cells[16].Visible = false;
                    GrillaProceso.HeaderRow.Cells[17].Visible = false;
                    GrillaProceso.HeaderRow.Cells[18].Visible = false;
                    GrillaProceso.HeaderRow.Cells[19].Visible = false;
                    GrillaProceso.HeaderRow.Cells[20].Visible = false;
                    GrillaProceso.HeaderRow.Cells[21].Visible = false;
                    GrillaProceso.HeaderRow.Cells[22].Visible = false;
                    for (int contador = 0; contador < GrillaProceso.Rows.Count; contador++)
                    {
                        GridViewRow row = GrillaProceso.Rows[contador];
                        row.Cells[0].Text = "";
                        row.Cells[0].Style.Add("BORDER", "0");
                        row.Cells[1].Text = "";
                        row.Cells[1].Style.Add("BORDER", "0");

                        row.Cells[2].Text = row.Cells[5].Text;
                        row.Cells[3].Text = row.Cells[22].Text;
                        row.Cells[4].Visible = false;
                        row.Cells[5].Visible = false;
                        row.Cells[6].Visible = false;
                        row.Cells[7].Visible = false;
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
                    #endregion
                    #region Proveedor
                    GridView GrillaProveedor = new GridView();
                    GrillaProveedor.DataSource = controlf.listarExternoMensual(Fecha, 2);
                    GrillaProveedor.DataBind();
                    GrillaProveedor.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                    GrillaProveedor.HeaderStyle.ForeColor = System.Drawing.Color.White;
                    GrillaProveedor.HeaderRow.Cells[0].Text = "";
                    GrillaProveedor.HeaderRow.Cells[0].Style.Add("BORDER", "0px");
                    GrillaProveedor.HeaderRow.Cells[0].BackColor = System.Drawing.Color.White;
                    GrillaProveedor.HeaderRow.Cells[1].Text = "";
                    GrillaProveedor.HeaderRow.Cells[1].Style.Add("BORDER", "0px");
                    GrillaProveedor.HeaderRow.Cells[1].BackColor = System.Drawing.Color.White;
                    GrillaProveedor.HeaderRow.Cells[2].Text = "Nombre";
                    GrillaProveedor.HeaderRow.Cells[3].Text = "Proceso";
                    GrillaProveedor.HeaderRow.Cells[4].Text = "Valor";
                    GrillaProveedor.HeaderRow.Cells[5].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[6].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[7].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[8].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[9].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[10].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[11].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[12].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[13].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[14].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[15].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[16].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[17].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[18].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[19].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[20].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[21].Visible = false;
                    GrillaProveedor.HeaderRow.Cells[22].Visible = false;
                    for (int contador = 0; contador < GrillaProveedor.Rows.Count; contador++)
                    {
                        GridViewRow row = GrillaProveedor.Rows[contador];
                        row.Cells[0].Text = "";
                        row.Cells[0].Style.Add("BORDER", "0");
                        row.Cells[1].Text = "";
                        row.Cells[1].Style.Add("BORDER", "0");
                        row.Cells[2].Text = row.Cells[17].Text;
                        row.Cells[3].Text = row.Cells[5].Text;
                        row.Cells[4].Text = row.Cells[22].Text;
                        row.Cells[5].Visible = false;
                        row.Cells[6].Visible = false;
                        row.Cells[7].Visible = false;
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
                    #endregion
                    #region OT
                    GridView GrillaOT = new GridView();
                    GrillaOT.DataSource = controlf.listarExternoMensual(Fecha, 1);
                    GrillaOT.DataBind();
                    GrillaOT.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                    GrillaOT.HeaderStyle.ForeColor = System.Drawing.Color.White;

                    GrillaOT.HeaderRow.Cells[0].Text = "";
                    GrillaOT.HeaderRow.Cells[0].Style.Add("BORDER", "0px");
                    GrillaOT.HeaderRow.Cells[0].BackColor = System.Drawing.Color.White;


                    GrillaOT.HeaderRow.Cells[1].Text = "OT";
                    GrillaOT.HeaderRow.Cells[2].Text = "Nombre OT";
                    GrillaOT.HeaderRow.Cells[3].Text = "Proceso";
                    GrillaOT.HeaderRow.Cells[4].Text = "Valor M2";
                    GrillaOT.HeaderRow.Cells[5].Text = "Cantidad";
                    GrillaOT.HeaderRow.Cells[6].Text = "Costo";
                    GrillaOT.HeaderRow.Cells[7].Text = "Total";

                    GrillaOT.HeaderRow.Cells[8].Visible = false;
                    GrillaOT.HeaderRow.Cells[9].Visible = false;
                    GrillaOT.HeaderRow.Cells[10].Visible = false;
                    GrillaOT.HeaderRow.Cells[11].Visible = false;
                    GrillaOT.HeaderRow.Cells[12].Visible = false;
                    GrillaOT.HeaderRow.Cells[13].Visible = false;
                    GrillaOT.HeaderRow.Cells[14].Visible = false;
                    GrillaOT.HeaderRow.Cells[15].Visible = false;
                    GrillaOT.HeaderRow.Cells[16].Visible = false;
                    GrillaOT.HeaderRow.Cells[17].Visible = false;
                    GrillaOT.HeaderRow.Cells[18].Visible = false;
                    GrillaOT.HeaderRow.Cells[19].Visible = false;
                    GrillaOT.HeaderRow.Cells[20].Visible = false;
                    GrillaOT.HeaderRow.Cells[21].Visible = false;
                    GrillaOT.HeaderRow.Cells[22].Visible = false;
                    for (int contador = 0; contador < GrillaOT.Rows.Count; contador++)
                    {
                        GridViewRow row = GrillaOT.Rows[contador];
                        row.Cells[0].Text = "";
                        row.Cells[0].Style.Add("BORDER", "0");
                        row.Cells[1].Text = row.Cells[2].Text;
                        row.Cells[2].Text = row.Cells[3].Text;
                        row.Cells[3].Text = row.Cells[5].Text;
                        row.Cells[4].Text = row.Cells[12].Text;
                        row.Cells[5].Text = row.Cells[16].Text;
                        row.Cells[6].Text = row.Cells[6].Text;
                        row.Cells[7].Text = row.Cells[22].Text;
                        //row.Cells[7].Visible = false;
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
                    #endregion
                    ExportToExcel2(mes + " " + feInicio[2], gv1, GrillaProceso, GrillaProveedor, GrillaOT, mes + " " + feInicio[2]);
                }
            }
        }
    }
}