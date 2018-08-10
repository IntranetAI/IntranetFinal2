using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloMateriaPrima.Controller;
using Intranet.ModuloMateriaPrima.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloMateriaPrima.View
{
    public partial class Control_ConsumoMetrics : System.Web.UI.Page
    {
        Controller_Consumo cc = new Controller_Consumo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                if (txtOT.Text != "")
                {
                    if (txtOT.Text == "108")
                    {
                        if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                        {
                            //PARA OT 108
                            Label11.Text = cc.CargaConsumoMetricsV2(txtOT.Text,DateTime.Now, DateTime.Now,  -1);
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('¡ La OT 108 debe tener Fecha de inicio y termino!'); </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                    }
                    else
                    {
                        //OTS NORMALES
                        Label11.Text = cc.CargaConsumoMetricsV2(txtOT.Text,DateTime.Now, DateTime.Now,  1);
                    }
                }
                else if(txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    //OTS POR FECHAS
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
                    //OTS CON CONSUMO EN RANGO DE FECHAS
                    string ot = cc.CargaOTSV2("", fi, ft, 2);
                    //BUSCA TODAS LAS OTS DEL RANGO Y TRAE SU CONSUMO INDEPENDIENTE DE SUS FECHAS DE CONSUMOS
                    Label11.Text = cc.CargaConsumoMetricsV2(ot, DateTime.Now, DateTime.Now, 0);
                }
            }
            catch
            {
                Label11.Text = "<div align='center'>¡No se han Encontrado Registros!</div>";
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            List<ConsumoBobinasExcel> lista = new List<ConsumoBobinasExcel>();
            try
            {
                if (txtOT.Text != "")
                {
                    if (txtOT.Text == "108")
                    {
                        if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                        {
                            //PARA OT 108
                            lista = cc.ListaConsumos(txtOT.Text, DateTime.Now, DateTime.Now, -1);
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('¡ La OT 108 debe tener Fecha de inicio y termino!'); </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                    }
                    else
                    {
                        //OTS NORMALES
                        lista = cc.ListaConsumos(txtOT.Text, DateTime.Now, DateTime.Now, 1);
                    }
                }
                else if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    //OTS POR FECHAS
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
                    //OTS CON CONSUMO EN RANGO DE FECHAS
                    string ot = cc.CargaOTSV2("", fi, ft, 2);
                    //BUSCA TODAS LAS OTS DEL RANGO Y TRAE SU CONSUMO INDEPENDIENTE DE SUS FECHAS DE CONSUMOS
                    lista = cc.ListaConsumos(ot, DateTime.Now, DateTime.Now, 0);
                }

            }
            catch
            {
                Label11.Text = "<div align='center'>¡No se han Encontrado Registros!</div>";
            }

            if (txtOT.Text != "" || (txtFechaInicio.Text != "" && txtFechaTermino.Text != ""))
            {
                GridView GridView1 = new GridView();
                GridView1.DataSource = lista;
                GridView1.DataBind();
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                ExportToExcel("", GridView1);
            }

        }

        private void ExportToExcel(string nameReport, GridView wControl)
        {
            try
            {
                HttpResponse response = Response;
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                Page pageToRender = new Page();
                HtmlForm form = new HtmlForm();
                Label la = new Label();

                la.Text = "<div align='center'>Informe Consumo Bobinas</div><br/>";

                form.Controls.Add(la);
                form.Controls.Add(wControl);
                //Label l = new Label(); l.Text = "<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>";// +TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>";
                //form.Controls.Add(l);
                pageToRender.Controls.Add(form);
                response.Clear();
                response.Buffer = true;
                response.ContentType = "application/vnd.ms-excel";
                response.AddHeader("Content-Disposition", "attachment;filename=ConsumoBobinas.xls");
                response.Charset = "UTF-8";
                response.ContentEncoding = Encoding.Default;
                pageToRender.RenderControl(htw);
                response.Write(sw.ToString());
                response.End();
            }catch(Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('¡Ha ocurrido un error al exporta!"+ex.Message+"'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}