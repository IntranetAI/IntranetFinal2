using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using Intranet.ModuloProduccion.Model;

namespace Intranet.ModuloProduccion.View
{
    public partial class Informe_SobreImpresion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                if (Session["Usuario"].ToString().Trim() == "apaillaqueo" || Session["Usuario"].ToString().Trim() == "mandrade")
                {
                    RadGrid1.MasterTableView.GetColumn("Proceso").Display = false;
                    RadGrid1.MasterTableView.GetColumn("Operador").Display = false;
                }
            }
        }//40.76487640472525,-73.97274971008301

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtOT.Text.Trim() != "") 
            {
                InformeProduccion_Controller controlpro = new InformeProduccion_Controller();
                string Maquina = ddlMaquina.SelectedItem.Text.ToString().Replace("Seleccione...", "");
                RadGrid1.DataSource = controlpro.Listar_TeoricoRealComparativoPro(txtOT.Text, "", "", "", 2);//1
                RadGrid1.DataBind();
            }
            else
            {
                InformeProduccion_Controller controlpro = new InformeProduccion_Controller();
                string[] splt = txtFechaInicio.Text.Split('/');
                string Sector = ddlSeccion.SelectedValue.ToString().Replace("Todas", "");
                DateTime fechaAsignada = Convert.ToDateTime(splt[2] + "-" + splt[1] + "-" + splt[0] + " 23:59:59");
                string Maquina = ddlMaquina.SelectedValue.ToString().Replace("Seleccione...", "");
                RadGrid1.DataSource = controlpro.Listar_TeoricoRealComparativoPro(Maquina, Sector, fechaAsignada.ToString("yyyy-MM-dd 00:00:00"), fechaAsignada.ToString("yyyy-MM-dd HH:mm:ss"), 3);
                RadGrid1.DataBind();
            }
        }


        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            List<InformeProduccionM> lista = new List<InformeProduccionM>();
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                InformeProduccionM p = new InformeProduccionM();
                p.Maquina = RadGrid1.Items[i]["Maquina"].Text;
                p.OT = RadGrid1.Items[i]["OT"].Text;
                p.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                p.Pliego = RadGrid1.Items[i]["Pliego"].Text;
                p.Planificado = RadGrid1.Items[i]["Planificado"].Text;
                p.Buenos = RadGrid1.Items[i]["Buenos"].Text;
                p.DVirando = (Convert.ToInt32(p.Buenos) - Convert.ToInt32(p.Planificado)).ToString(); //CantProdsobreImpresion
                p.Producido = (Convert.ToDouble(Convert.ToDouble(p.DVirando) / Convert.ToDouble(p.Planificado)) * 100).ToString("N2");
                p.Proceso = RadGrid1.Items[i]["Proceso"].Text;
                p.Tipo = RadGrid1.Items[i]["Tipo"].Text;
                p.FechaInicio = RadGrid1.Items[i]["FechaInicio"].Text;
                p.Operador = RadGrid1.Items[i]["Operador"].Text;
                if (p.Maquina == "GOSS" || p.Maquina == "M600" || p.Maquina == "WEB 1" || p.Maquina == "WEB 2" || p.Maquina == "LITHOMAN")
                {
                    p.Clasificacion = "Rotativas";
                }
                else
                {
                    p.Clasificacion = "Planas";
                }

                lista.Add(p);
            }
            ExportToExcel("Reporte SobreImpresion " + txtFechaInicio.Text, lista, ddlSeccion.SelectedItem.Text.ToString().Replace("Todas", ""), ddlMaquina.SelectedItem.Text.ToString().Replace("Seleccione...", ""), txtFechaInicio.Text);
        }


        private void ExportToExcel(string nameReport, List<InformeProduccionM> lista, string Area, string Maquina, string fInicio)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe SobreImpresión<br/>";
            if (Area != "") { Titulo += "Area : " + Area; }
            if (Maquina != "") { Titulo += " Maquina : " + Maquina; }
            if (fInicio != "") { Titulo += " Fecha : " + fInicio; }
            la.Text = Titulo + "</div><br />";

            form.Controls.Add(la);

            #region ConversionListaGrilla
            int contado = 0;
            int TotalRotCantPlan = 0; int TotalRotCantPlanSobre = 0; int TotalRotCantProdSobre = 0; int TotalRotCantDifSobre = 0; double RotPorceCantDifSobre = 0; int TotalRotCantPlanBajo = 0; int TotalRotCantProdBajo = 0; int TotalRotCantDifBajo = 0; double RotPorceCantDifBajo = 0;
            int TotalPlaCantPlan = 0; int TotalPlaCantPlanSobre = 0; int TotalPlaCantProdSobre = 0; int TotalPlaCantDifSobre = 0; double PlaPorceCantDifSobre = 0; int TotalPlaCantPlanBajo = 0; int TotalPlaCantProdBajo = 0; int TotalPlaCantDifbajo = 0; double PlaPorceCantDifBajo = 0;
            foreach(string maquinasProd in lista.Select(o=>o.Maquina).Distinct())
            {
                GridView gv = new GridView();
                gv.DataSource = lista.Where(o => o.Maquina == maquinasProd);
                gv.DataBind();
                gv.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

                gv.HeaderRow.Cells[0].Text = "Maquina";
                gv.HeaderRow.Cells[1].Text = "OT";
                gv.HeaderRow.Cells[2].Text = "NombreOT";
                gv.HeaderRow.Cells[3].Text = "Pliego";
                gv.HeaderRow.Cells[4].Text = "Cant. Planificado";
                gv.HeaderRow.Cells[5].Text = "Cant. Producida";
                gv.HeaderRow.Cells[6].Text = "Dif.";
                gv.HeaderRow.Cells[7].Text = "% ";
                if (Session["Usuario"].ToString().Trim() == "apaillaqueo" || Session["Usuario"].ToString().Trim() == "mandrade")
                {
                    gv.HeaderRow.Cells[8].Visible = false;
                    gv.HeaderRow.Cells[10].Visible = false;
                }
                else
                {
                    gv.HeaderRow.Cells[8].Text = "Control Wip";
                    gv.HeaderRow.Cells[10].Text = "Operador";
                }
                //gv.HeaderRow.Cells[8].Text = "Control Wip";
                gv.HeaderRow.Cells[9].Text = "Papeles";
                gv.HeaderRow.Cells[9].Visible = false;
                //gv.HeaderRow.Cells[10].Text = "Operador";
                gv.HeaderRow.Cells[11].Visible = false;
                gv.HeaderRow.Cells[12].Visible = false;
                gv.HeaderRow.Cells[13].Visible = false;
                gv.HeaderRow.Cells[14].Visible = false;
                gv.HeaderRow.Cells[15].Visible = false;
                gv.HeaderRow.Cells[16].Visible = false;
                gv.HeaderRow.Cells[17].Visible = false;
                gv.HeaderRow.Cells[18].Visible = false;
                gv.HeaderRow.Cells[19].Visible = false;
                gv.HeaderRow.Cells[20].Visible = false;
                int CantPlanSobre = 0;
                int CantProdSobre = 0;
                int CantPlanBajo = 0;
                int CantProdBajo = 0;
                int TotalPlanificado = 0;

                for (int contador = 0; contador < gv.Rows.Count; contador++)
                {
                    GridViewRow row = gv.Rows[contador];
                    if (Session["Usuario"].ToString().Trim() == "apaillaqueo" || Session["Usuario"].ToString().Trim() == "mandrade")
                    {
                        row.Cells[8].Visible = false;
                        row.Cells[10].Visible = false;
                    }
                    else
                    {
                        row.Cells[8].Text = row.Cells[11].Text;
                        row.Cells[10].Text = row.Cells[9].Text;
                    }
                    //row.Cells[8].Text = row.Cells[11].Text;
                    //row.Cells[10].Text = row.Cells[9].Text;
                    row.Cells[9].Visible = false;
                    row.Cells[9].Text = row.Cells[18].Text;
                    string Maquinagv = row.Cells[7].Text;
                    row.Cells[7].Text = row.Cells[4].Text + "%";
                    row.Cells[6].Text = row.Cells[17].Text;
                    row.Cells[5].Text = row.Cells[13].Text;
                    row.Cells[4].Text = row.Cells[3].Text;
                    row.Cells[3].Text = row.Cells[2].Text;
                    row.Cells[2].Text = row.Cells[1].Text;
                    row.Cells[1].Text = row.Cells[0].Text;
                    row.Cells[0].Text = Maquinagv;
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
                    TotalPlanificado += Convert.ToInt32(row.Cells[4].Text);
                    if (Convert.ToInt32(row.Cells[5].Text) >= Convert.ToInt32(row.Cells[4].Text))
                    {
                        CantPlanSobre += Convert.ToInt32(row.Cells[4].Text);
                        CantProdSobre += Convert.ToInt32(row.Cells[5].Text);
                        if (row.Cells[20].Text == "Rotativas")
                        {
                            TotalRotCantPlan += Convert.ToInt32(row.Cells[4].Text);
                            TotalRotCantPlanSobre += Convert.ToInt32(row.Cells[4].Text);
                            TotalRotCantProdSobre += Convert.ToInt32(row.Cells[5].Text);
                        }
                        else
                        {
                            TotalPlaCantPlan += Convert.ToInt32(row.Cells[4].Text);
                            TotalPlaCantPlanSobre += Convert.ToInt32(row.Cells[4].Text);
                            TotalPlaCantProdSobre += Convert.ToInt32(row.Cells[5].Text);
                        }
                    }
                    else
                    {
                        if (row.Cells[20].Text == "Rotativas")
                        {
                            TotalRotCantPlan += Convert.ToInt32(row.Cells[4].Text);
                            CantPlanBajo += Convert.ToInt32(row.Cells[4].Text);
                            TotalRotCantPlanBajo += Convert.ToInt32(row.Cells[4].Text);
                            CantProdBajo += Convert.ToInt32(row.Cells[5].Text);
                            TotalRotCantProdBajo += Convert.ToInt32(row.Cells[5].Text);
                        } 
                        else
                        {
                            TotalPlaCantPlan += Convert.ToInt32(row.Cells[4].Text);
                            CantPlanBajo += Convert.ToInt32(row.Cells[4].Text);
                            TotalPlaCantPlanBajo += Convert.ToInt32(row.Cells[4].Text);
                            CantProdBajo += Convert.ToInt32(row.Cells[5].Text);
                            TotalPlaCantProdBajo += Convert.ToInt32(row.Cells[5].Text);
                        }
                    }
                }
                string CantidadDif = (CantProdSobre - CantPlanSobre).ToString();
                string PorcenProd = (Convert.ToDouble(Convert.ToDouble(CantidadDif) / Convert.ToDouble(CantPlanSobre)) * 100).ToString("N2") + "%";

                Label TablaMaquinaTotal = new Label();
                string Negativo = "";
                if (CantPlanBajo > 0)
                {
                    string CantidadDifNeg = (CantProdBajo - CantPlanBajo).ToString();
                    string PorcenProdNeg = (Convert.ToDouble(Convert.ToDouble(CantidadDifNeg) / Convert.ToDouble(CantPlanBajo)) * 100).ToString("N2") + "%";
                    Negativo = "<tr><td colspan ='6'></td><td style='border:1px solid black;'>Cant. Plan. Bajo</td>" +
                                        "<td style='border:1px solid black;'>" + CantPlanBajo.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;'>Cant. Prod. Bajo</td>" +
                                        "<td style='border:1px solid black;'>" + CantProdBajo.ToString() + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;'>Diferencia Bajo</td>" +
                                        "<td style='border:1px solid black;'>" + CantidadDifNeg + "</td></tr><tr>" +
                                        "<td colspan ='6'></td><td style='border:1px solid black;'>% Bajo</td>" +
                                        "<td style='border:1px solid black;'>" + PorcenProdNeg + "</td></tr>";
                }
                TablaMaquinaTotal.Text = "<br/><div align='right'><table><tr>" +
                                    "<td colspan ='6'></td><td  style='border:1px solid black;'>Total Cant. Plan.</td>" +
                                    "<td style='border:1px solid black;'>" + TotalPlanificado.ToString() + "</div></td></tr><tr>" +
                                    "<td colspan ='6'></td><td  style='border:1px solid black;'>Cant. Plan. Sobre</td>" +
                                    "<td style='border:1px solid black;'>" + CantPlanSobre.ToString() + "</div></td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;'>Cant. Prod. Sobre</td>" +
                                    "<td style='border:1px solid black;'>" + CantProdSobre.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;'>Diferencia Sobre</td>" +
                                    "<td style='border:1px solid black;'>" + CantidadDif+ "</td></tr><tr>" +
                                    "<td colspan ='6'></td><td style='border:1px solid black;'>% Sobre</td>" +
                                    "<td style='border:1px solid black;'>" + PorcenProd.Replace("NaN", "0") + "</td></tr>" + Negativo + "</table></div>";

                Label Maquina1 = new Label();
                if (contado == 0)
                {
                    Maquina1.Text = "<div align='left'>" + maquinasProd + " </div><br/>";
                }
                else
                {
                    Maquina1.Text = "<br/><div align='left'>" + maquinasProd + " </div><br/>";
                }
                form.Controls.Add(Maquina1);
                form.Controls.Add(gv);
                form.Controls.Add(TablaMaquinaTotal);
                contado++;
            }
            #endregion

            Label TablaMaquinaRot = new Label();
            TotalRotCantDifSobre = (TotalRotCantProdSobre - TotalRotCantPlanSobre);
            RotPorceCantDifSobre = Convert.ToDouble(Convert.ToDouble(TotalRotCantDifSobre) / Convert.ToDouble(TotalRotCantPlanSobre)) * 100;
            TotalRotCantDifBajo = (TotalRotCantPlanBajo - TotalRotCantProdBajo);
            
            string RotNegativoBajo = "";
            if (TotalRotCantDifBajo > 0)
            {
                RotPorceCantDifBajo = Convert.ToDouble(Convert.ToDouble(TotalRotCantDifBajo) / Convert.ToDouble(TotalRotCantPlanBajo)) * 100;
                RotNegativoBajo = "<tr><td colspan ='6'></td><td  style='border:1px solid black;'>Cant. Plan. Bajo</td>" +
                                    "<td style='border:1px solid black;'>" + TotalRotCantPlanBajo.ToString() + "</td></tr><tr>"+
                                  "<td colspan ='6'></td><td  style='border:1px solid black;'>Cant. Prod. Bajo</td>" +
                                    "<td style='border:1px solid black;'>" + TotalRotCantProdBajo.ToString() + "</td></tr><tr>"+
                                  "<td colspan ='6'></td><td  style='border:1px solid black;'>Diferencia Bajo</td>" +
                                    "<td style='border:1px solid black;'>" + TotalRotCantDifBajo.ToString() + "</td></tr><tr>" +
                                  "<td colspan ='6'></td><td  style='border:1px solid black;'>% Bajo</td>" +
                                    "<td style='border:1px solid black;'>" + RotPorceCantDifBajo.ToString() + "%</td></tr>";
            }
            TablaMaquinaRot.Text = "<br/><br/><br/><div align='right'><table><tr>" +
                                "<td colspan ='6'></td><td  style='border:1px solid black;'colspan ='2'>Rotativa</td></tr><tr>" +
                                "<td colspan ='6'></td><td  style='border:1px solid black;'>Total Cant. Plan.</td>" +
                                "<td style='border:1px solid black;'>" + TotalRotCantPlan.ToString() + "</td></tr><tr>" +
                                "<td colspan ='6'></td><td  style='border:1px solid black;'>Cant. Plan. Sobre</td>" +
                                "<td style='border:1px solid black;'>" + TotalRotCantPlanSobre.ToString() + "</td></tr><tr>" +
                                "<td colspan ='6'></td><td style='border:1px solid black;'>Cant. Prod. Sobre</td>" +
                                "<td style='border:1px solid black;'>" + TotalRotCantProdSobre.ToString() + "</td></tr><tr>" +
                                "<td colspan ='6'></td><td style='border:1px solid black;'>Diferencia Sobre</td>" +
                                "<td style='border:1px solid black;'>" + TotalRotCantDifSobre + "</td></tr><tr>" +
                                "<td colspan ='6'></td><td style='border:1px solid black;'>% Sobre</td>" +
                                "<td style='border:1px solid black;'>" + RotPorceCantDifSobre.ToString("N2").Replace("NaN", "0") + "%</td></tr>" +
                                RotNegativoBajo+"</table></div>";

            form.Controls.Add(TablaMaquinaRot);

            Label TablaMaquinaPla = new Label();
            TotalPlaCantDifSobre = (TotalPlaCantProdSobre - TotalPlaCantPlanSobre);
            TotalPlaCantDifbajo = (TotalPlaCantPlanBajo - TotalPlaCantProdBajo);
            PlaPorceCantDifSobre =Convert.ToDouble(Convert.ToDouble(TotalPlaCantDifSobre) /Convert.ToDouble(TotalPlaCantPlanSobre)) * 100;

            string PlaNegativoBajo = "";
            if (TotalPlaCantDifbajo > 0)
            {
                PlaPorceCantDifBajo = Convert.ToDouble(Convert.ToDouble(TotalPlaCantDifbajo) / Convert.ToDouble(TotalPlaCantPlanBajo)) * 100;
                PlaNegativoBajo = "<tr><td colspan ='6'></td><td  style='border:1px solid black;'>Cant. Plan. Bajo</td>" +
                                    "<td style='border:1px solid black;'>" + TotalPlaCantPlanBajo.ToString() + "</td></tr><tr>" +
                                  "<td colspan ='6'></td><td  style='border:1px solid black;'>Cant. Prod. Bajo</td>" +
                                    "<td style='border:1px solid black;'>" + TotalPlaCantProdBajo.ToString() + "</td></tr><tr>" +
                                  "<td colspan ='6'></td><td  style='border:1px solid black;'>Diferencia Bajo</td>" +
                                    "<td style='border:1px solid black;'>" + TotalPlaCantDifbajo.ToString() + "</td></tr><tr>" +
                                  "<td colspan ='6'></td><td  style='border:1px solid black;'>% Bajo</td>" +
                                    "<td style='border:1px solid black;'>" + PlaPorceCantDifBajo.ToString() + "%</td></tr>";
            }
            TablaMaquinaPla.Text = "<br/><div align='right'><table><tr>" +
                                "<td colspan ='6'></td><td  style='border:1px solid black;' colspan ='2'>Plana</td></tr><tr>" +
                                "<td colspan ='6'></td><td  style='border:1px solid black;'>Total Cant. Plan.</td>" +// colspan ='2'
                                "<td style='border:1px solid black;'>" + TotalPlaCantPlan.ToString() + "</td></tr><tr>" +
                                "<td colspan ='6'></td><td  style='border:1px solid black;'>Cant. Plan. Sobre</td>" +// colspan ='2'
                                "<td style='border:1px solid black;'>" + TotalPlaCantPlanSobre.ToString() + "</div></td></tr><tr>" +
                                "<td colspan ='6'></td><td style='border:1px solid black;'>Cant. Prod. Sobre</td>" +
                                "<td style='border:1px solid black;'>" + TotalPlaCantProdSobre.ToString() + "</td></tr><tr>" +
                                "<td colspan ='6'></td><td style='border:1px solid black;'>Diferencia Sobre</td>" +
                                "<td style='border:1px solid black;'>" + TotalPlaCantDifSobre + "</td></tr><tr>" +
                                "<td colspan ='6'></td><td style='border:1px solid black;'>% Sobre</td>" +
                                "<td style='border:1px solid black;'>" + PlaPorceCantDifSobre.ToString("N2") + "%</td></tr>"+
                                PlaNegativoBajo + "</table></div>";

            form.Controls.Add(TablaMaquinaPla);

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

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SeguimientoController sc = new SeguimientoController();
                ddlMaquina.DataSource = sc.ListMaquinasMetrics(ddlSeccion.SelectedValue.ToString().ToString(), "", 0);
                ddlMaquina.DataTextField = "Name";
                ddlMaquina.DataValueField = "ID";
                ddlMaquina.DataBind();
                ddlMaquina.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
            }
            catch
            {
            }
        }
    }
}