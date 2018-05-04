using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloProduccion.View
{
    public partial class Informe_MensualSobreProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            string[] spt1 = txtFechaInicio.Text.ToString().Split('/');
            string[] spt2 = txtFechaTermino.Text.ToString().Split('/');
            CargarDatos(spt1[2] + "-" + spt1[1] + "-" + spt1[0], spt2[2] + "-" + spt2[1] + "-" + spt2[0] + " 23:59:59");
        }

        public void CargarDatos(string F1, string F2)
        {
            InformeProduccion_Controller controlinfo = new InformeProduccion_Controller();
            List<InformeProduccionM> lista = new List<InformeProduccionM>();
            List<InformeProduccionM> lista2 = controlinfo.Listar_InformeMensualSobreProd(F1, F2);
            foreach (string Maquina in lista2.Select(o => o.Maquina).Distinct())
            {
                InformeProduccionM infp = new InformeProduccionM();
                
                infp.Maquina = Maquina;
                int CEPlanificado = 0;
                int CEProducido = 0;
                int CEConsumo = 0;
                int SCPlanificado = 0;
                int SCProducido = 0;
                int SCConsumo = 0;
                int BCPlanificado = 0;
                int BCProducido = 0;
                int BCConsumo = 0;
                int algo = 0;
                int ProducidoTotal = 0;
                foreach (InformeProduccionM info in lista2.Where(o => o.Maquina == Maquina))
                {
                    switch (info.CodMaquina)
                    {
                        case "Sobre Consumo":
                            SCProducido += Convert.ToInt32(info.Producido); 
                            SCPlanificado += Convert.ToInt32(info.Planificado);
                            SCConsumo += (Convert.ToInt32(info.Producido)-Convert.ToInt32(info.Planificado));
                            break;
                        case "Bajo Consumo":
                            BCPlanificado += Convert.ToInt32(info.Planificado);
                            BCProducido += Convert.ToInt32(info.Producido); 
                            BCConsumo += (Convert.ToInt32(info.Planificado)-Convert.ToInt32(info.Producido));
                            break;
                        default :
                            CEPlanificado += Convert.ToInt32(info.Planificado);
                            CEProducido += Convert.ToInt32(info.Producido);
                            CEConsumo += (Convert.ToInt32(info.Producido) - Convert.ToInt32(info.Planificado));
                            break;
                    }
                    if(info.Clasificacion=="IMP ROT")
                    {
                        infp.Clasificacion = "Rotativas";
                    }
                    else
                    {
                        infp.Clasificacion = "Planas";
                    }
                    algo += Convert.ToInt32(info.Planificado);
                    ProducidoTotal += Convert.ToInt32(info.Producido); 
                }
                infp.Operador = algo.ToString();
                //Comsumo Esperado
                infp.Planificado = CEPlanificado.ToString("N0");
                infp.Producido = CEProducido.ToString("N0");
                infp.DesperdicioAcerto = CEConsumo.ToString("N0");
                infp.Proceso = (Convert.ToDouble(Convert.ToDouble(CEConsumo) / Convert.ToDouble(CEPlanificado)) * 100).ToString("N2").Replace("NaN", "0") + "%";
                //Sobre Consumo
                infp.NombreOT = SCPlanificado.ToString("N0");
                infp.DesperdicioVirando = SCProducido.ToString("N0");
                infp.CodMaquina = SCConsumo.ToString("N0");
                infp.FechaInicio = (Convert.ToDouble(Convert.ToDouble(SCConsumo) / Convert.ToDouble(SCPlanificado)) * 100).ToString("N2").Replace("NaN", "0") + "%";
                //Bajo Consumo
                infp.DAcerto = BCPlanificado.ToString("N0");
                infp.DVirando = BCProducido.ToString("N0");
                infp.Tipo = BCConsumo.ToString("N0");
                infp.Horas = (Convert.ToDouble(Convert.ToDouble(BCConsumo) / Convert.ToDouble(BCPlanificado))*100).ToString("N2").Replace("NaN","0") + "%";

                infp.FechaTermino = ProducidoTotal.ToString();

                lista.Add(infp);
            }
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();
        }


        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<InformeProduccionM> lista = new List<InformeProduccionM>();
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    InformeProduccionM p = new InformeProduccionM();
                    p.Clasificacion = RadGrid1.Items[i]["Clasificacion"].Text;
                    p.Maquina = RadGrid1.Items[i]["Maquina"].Text;
                    p.Planificado = RadGrid1.Items[i]["Planificado"].Text;
                    p.Producido = RadGrid1.Items[i]["Producido"].Text;
                    p.DesperdicioAcerto = RadGrid1.Items[i]["DesperdicioAcerto"].Text;
                    p.Proceso = RadGrid1.Items[i]["Proceso"].Text;
                    p.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                    p.DesperdicioVirando = RadGrid1.Items[i]["DesperdicioVirando"].Text;
                    p.CodMaquina = RadGrid1.Items[i]["CodMaquina"].Text;
                    p.FechaInicio = RadGrid1.Items[i]["FechaInicio"].Text;
                    p.DAcerto = RadGrid1.Items[i]["DAcerto"].Text;
                    p.DVirando = RadGrid1.Items[i]["DVirando"].Text;
                    p.Tipo = RadGrid1.Items[i]["Tipo"].Text;
                    p.Horas = RadGrid1.Items[i]["Horas"].Text;
                    p.Operador = RadGrid1.Items[i]["Operador"].Text;
                    p.Buenos = RadGrid1.Items[i]["FechaTermino"].Text;

                    lista.Add(p);
                }
                ExportToExcel("Reporte Mensual SobreImpresion " + txtFechaInicio.Text, lista, txtFechaInicio.Text, txtFechaTermino.Text);
            }
            catch
            {
                string popupScript = "<script language='JavaScript'>alert('A ocurrido un error inesperado. Vuelva a intentarlo mas tarde');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        private void ExportToExcel(string nameReport, List<InformeProduccionM> lista, string fInicio, string fTermino)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe Mensual SobreImpresión<br/>";
            if (fInicio != "") { Titulo += " Fecha : " + fInicio; }
            if (fTermino != "") { Titulo += " a  " + fTermino; }
            la.Text = Titulo + "</div><br />";

            form.Controls.Add(la);

            #region ConversionListaGrilla
            int contado = 0;
            
            int TotalCantPlanCE = 0; 
            int TotalCantProdCE = 0; 
            int TotalCantDifCE = 0;

            int TotalCantPlanCS = 0;
            int TotalCantProdCS = 0;
            int TotalCantDifCS = 0;

            int TotalCantPlanCB = 0;
            int TotalCantProdCB = 0;
            int TotalCantDifCB = 0;
            int TotalPlinificadoFinal = 0;
            foreach (string Clasificacion in lista.Select(o => o.Clasificacion).Distinct())
            {
                GridView gv = new GridView();
                gv.DataSource = lista.Where(o => o.Clasificacion == Clasificacion);
                gv.DataBind();
                gv.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

                gv.HeaderRow.Cells[0].Text = "Sector";
                gv.HeaderRow.Cells[1].Text = "Maquina";
                gv.HeaderRow.Cells[2].Text = "Planificado Total";
                gv.HeaderRow.Cells[3].Text = "Planificado Cons. Esperado";
                gv.HeaderRow.Cells[4].Text = "Producido Cons. Esperado";
                gv.HeaderRow.Cells[5].Text = "Diferencia";
                gv.HeaderRow.Cells[6].Text = "%";
                gv.HeaderRow.Cells[7].Text = "Planificado Cons. Sobre";
                gv.HeaderRow.Cells[8].Text = "Producida Cons. Sobre";
                gv.HeaderRow.Cells[9].Text = "Diferencia";
                gv.HeaderRow.Cells[10].Text = "%";
                gv.HeaderRow.Cells[11].Text = "Planificado Cons. Bajo";
                gv.HeaderRow.Cells[12].Text = "Producida Cons. Bajo";
                gv.HeaderRow.Cells[13].Text = "Diferencia";
                gv.HeaderRow.Cells[14].Text = "%";
                gv.HeaderRow.Cells[15].Text = "Giros";
                gv.HeaderRow.Cells[16].Visible = false;
                gv.HeaderRow.Cells[17].Visible = false;
                gv.HeaderRow.Cells[18].Visible = false;
                gv.HeaderRow.Cells[19].Visible = false;
                gv.HeaderRow.Cells[20].Visible = false;

                
                int TotSectorCantPlanCE = 0;
                int TotSectorCantProdCE = 0;
                int TotSectorCantDifeCE = 0;
                string TotSectorProceCE = "";
                int TotSectorCantPlanCS = 0;
                int TotSectorCantProdCS = 0;
                int TotSectorCantDifeCS = 0;
                string TotSectorProceCS = "";
                int TotSectorCantPlanCB = 0;
                int TotSectorCantProdCB = 0;
                int TotSectorCantDifeCB = 0;
                string TotSectorProceCB = "";
                int TotalCantPlan = 0;
                for (int contador = 0; contador < gv.Rows.Count; contador++)
                {
                    GridViewRow row = gv.Rows[contador];
                    row.Cells[0].Text = row.Cells[20].Text;
                    string M = row.Cells[7].Text;
                    row.Cells[7].Text = row.Cells[1].Text;
                    row.Cells[1].Text = M;
                    row.Cells[2].Text = row.Cells[9].Text;
                    row.Cells[10].Text = row.Cells[5].Text;
                    row.Cells[5].Text = row.Cells[14].Text;
                    row.Cells[6].Text = row.Cells[11].Text;
                    row.Cells[9].Text = row.Cells[8].Text;
                    row.Cells[8].Text = row.Cells[15].Text;
                    row.Cells[11].Text = row.Cells[16].Text;
                    row.Cells[12].Text = row.Cells[17].Text;
                    row.Cells[13].Text = row.Cells[18].Text;
                    row.Cells[14].Text = row.Cells[19].Text;

                    string a = row.Cells[20].Text + row.Cells[21].Text + row.Cells[22].Text + row.Cells[23].Text + row.Cells[24].Text + 
                        row.Cells[0].Text + row.Cells[1].Text + row.Cells[2].Text + row.Cells[3].Text + row.Cells[4].Text +
                        row.Cells[5].Text + row.Cells[6].Text + row.Cells[7].Text + row.Cells[8].Text + row.Cells[9].Text;
                    // row.Cells[15].Text = row.Cells[15].Text;
                    row.Cells[16].Visible = false;
                    row.Cells[17].Visible = false;
                    row.Cells[18].Visible = false;
                    row.Cells[19].Visible = false;
                    row.Cells[20].Visible = false;

                    //Consumo Esperado
                    TotSectorCantPlanCE += Convert.ToInt32(row.Cells[3].Text.Replace(",", "").Replace(".", ""));
                    TotalCantPlanCE += Convert.ToInt32(row.Cells[3].Text.Replace(",", "").Replace(".", ""));
                    TotSectorCantProdCE += Convert.ToInt32(row.Cells[4].Text.Replace(",", "").Replace(".", ""));
                    TotalCantProdCE += Convert.ToInt32(row.Cells[4].Text.Replace(",", "").Replace(".", ""));
                    TotSectorCantDifeCE += Convert.ToInt32(row.Cells[5].Text.Replace(",", "").Replace(".", ""));
                    TotalCantDifCE += Convert.ToInt32(row.Cells[5].Text.Replace(",", "").Replace(".", ""));

                    //Consumo Sobre
                    TotSectorCantPlanCS += Convert.ToInt32(row.Cells[7].Text.Replace(",", "").Replace(".", ""));
                    TotalCantPlanCS += Convert.ToInt32(row.Cells[7].Text.Replace(",", "").Replace(".", ""));
                    TotSectorCantProdCS += Convert.ToInt32(row.Cells[8].Text.Replace(",", "").Replace(".", ""));
                    TotalCantProdCS += Convert.ToInt32(row.Cells[8].Text.Replace(",", "").Replace(".", ""));
                    TotSectorCantDifeCS += Convert.ToInt32(row.Cells[9].Text.Replace(",", "").Replace(".", ""));
                    TotalCantDifCS += Convert.ToInt32(row.Cells[9].Text.Replace(",", "").Replace(".", ""));

                    //Consumo Bajo
                    TotSectorCantPlanCB += Convert.ToInt32(row.Cells[11].Text.Replace(",", "").Replace(".", ""));
                    TotalCantPlanCB += Convert.ToInt32(row.Cells[11].Text.Replace(",", "").Replace(".", ""));
                    TotSectorCantProdCB += Convert.ToInt32(row.Cells[12].Text.Replace(",", "").Replace(".", ""));
                    TotalCantProdCB += Convert.ToInt32(row.Cells[12].Text.Replace(",", "").Replace(".", ""));
                    TotSectorCantDifeCB += Convert.ToInt32(row.Cells[13].Text.Replace(",", "").Replace(".", ""));
                    TotalCantDifCB += Convert.ToInt32(row.Cells[13].Text.Replace(",", "").Replace(".", ""));

                    //Total
                    TotalCantPlan += (Convert.ToInt32(row.Cells[3].Text.Replace(",", "").Replace(".", "")) +
                                   Convert.ToInt32(row.Cells[7].Text.Replace(",", "").Replace(".", "")) +
                                   Convert.ToInt32(row.Cells[11].Text.Replace(",", "").Replace(".", "")));
                    
                }

                TotSectorProceCE = (Convert.ToDouble(Convert.ToDouble(TotSectorCantDifeCE) / Convert.ToDouble(TotSectorCantPlanCE)) * 100).ToString("N2") + "%";
                TotSectorProceCS = (Convert.ToDouble(Convert.ToDouble(TotSectorCantDifeCS) / Convert.ToDouble(TotSectorCantPlanCS)) * 100).ToString("N2") + "%";
                TotSectorProceCB = (Convert.ToDouble(Convert.ToDouble(TotSectorCantDifeCB) / Convert.ToDouble(TotSectorCantPlanCB)) * 100).ToString("N2") + "%";
                TotalPlinificadoFinal += TotalCantPlan;
                Label TablaMaquinaTotal = new Label();
                TablaMaquinaTotal.Text = "<table><tr>" +
                                    "<td  style='border:1px solid black;' colspan='2'>Totales " + Clasificacion + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotalCantPlan.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorCantPlanCE.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorCantProdCE.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorCantDifeCE.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorProceCE.Replace("NaN", "0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorCantPlanCS.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorCantProdCS.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorCantDifeCS.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorProceCS.Replace("NaN", "0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorCantPlanCB.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorCantProdCB.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorCantDifeCB.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                    "<td style='border:1px solid black;'>" + TotSectorProceCB.Replace("NaN", "0").Replace(",", "").Replace(".", "") + "</td></tr></table><br />";

                form.Controls.Add(gv);
                form.Controls.Add(TablaMaquinaTotal);

                contado++;
            }
            #endregion

            Label TablaTotal = new Label();
            string PorceDifCE = (Convert.ToDouble(Convert.ToDouble(TotalCantDifCE) / Convert.ToDouble(TotalCantPlanCE)) * 100).ToString("N2") + "%";
            string PorceDifCS = (Convert.ToDouble(Convert.ToDouble(TotalCantDifCS) / Convert.ToDouble(TotalCantPlanCS)) * 100).ToString("N2") + "%";
            string PorceDifCB = (Convert.ToDouble(Convert.ToDouble(TotalCantDifCB) / Convert.ToDouble(TotalCantPlanCB)) * 100).ToString("N2") + "%";
            
            TablaTotal.Text = "<table><tr>" +
                                "<td style='border:1px solid black;' colspan='2'>Total</td>" +
                                "<td style='border:1px solid black;'>" + TotalPlinificadoFinal.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + TotalCantPlanCE.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + TotalCantProdCE.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + TotalCantDifCE.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + PorceDifCE.Replace("NaN", "0") + "</td>" +

                                "<td style='border:1px solid black;'>" + TotalCantPlanCS.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + TotalCantProdCS.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + TotalCantDifCS.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + PorceDifCS.Replace("NaN", "0") + "</td>" +

                                "<td style='border:1px solid black;'>" + TotalCantPlanCB.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + TotalCantProdCB.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + TotalCantDifCB.ToString("N0").Replace(",", "").Replace(".", "") + "</td>" +
                                "<td style='border:1px solid black;'>" + PorceDifCB.Replace("NaN", "0") + "</td></tr></table>";

            form.Controls.Add(TablaTotal);


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