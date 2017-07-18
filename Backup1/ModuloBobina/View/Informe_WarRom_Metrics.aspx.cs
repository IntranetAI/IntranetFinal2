using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBobina.Controller;
using Intranet.ModuloBobina.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloBobina.View
{
    public partial class Informe_WarRom_Metrics : System.Web.UI.Page
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
            if (txtFechaInicio.Text != "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];

                string fechaInicio = año + "-" + mes + "-" + dia;

                CargarRegistros(fechaInicio);
                Label1.Text = "";
            }

        }

        public void CargarRegistros(string Dia)
        {
            try
            {
                Controller_ConsumoBobina controlbob = new Controller_ConsumoBobina();
                RadGrid1.DataSource = controlbob.List_BobinasWarRom_V2(Dia);
                RadGrid1.DataBind();
            }
            catch (Exception e)
            {
                string popupScript = "<script language='JavaScript'>alert('" + e.Message + "');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<Bobina_ConsumoLinea> lista = new List<Bobina_ConsumoLinea>();
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    Bobina_ConsumoLinea p = new Bobina_ConsumoLinea();
                    p.Maquina = RadGrid1.Items[i]["Maquina"].Text;
                    p.Codigo_Bobina = RadGrid1.Items[i]["Codigo_Bobina"].Text;
                    p.TipoPapel = RadGrid1.Items[i]["TipoPapel"].Text;
                    p.Gramaje = RadGrid1.Items[i]["Gramaje"].Text;
                    p.Ancho = RadGrid1.Items[i]["Ancho"].Text;
                    p.PesoInicial = RadGrid1.Items[i]["PesoInicial"].Text;
                    p.ConsumoBobina = RadGrid1.Items[i]["ConsumoBobina"].Text;
                    p.OrigenPerdida = RadGrid1.Items[i]["OrigenPerdida"].Text;
                    p.MotivoPerdida = RadGrid1.Items[i]["MotivoPerdida"].Text;
                    p.Escarpe = RadGrid1.Items[i]["Escarpe"].Text;
                    p.PorcentajePerdidas = RadGrid1.Items[i]["PorcentajePerdidas"].Text;
                    p.OT = RadGrid1.Items[i]["OT"].Text;
                    p.Cantidad = "";
                    p.Saldo = "";
                    p.TipoPerdida = "";
                    lista.Add(p);
                }
                ExportToExcel("Informe War-Rom " + txtFechaInicio.Text, lista, txtFechaInicio.Text);
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'>alert('A ocurrido un error inesperado. Vuelva a intentarlo mas tarde\\n" + ex.Message + "');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        private void ExportToExcel(string nameReport, List<Bobina_ConsumoLinea> lista, string fInicio)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.UserLanguages[0]);
            }
            catch
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            }
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe War-Rom<br/>";
            if (fInicio != "") { Titulo += " Fecha : " + fInicio; }
            la.Text = Titulo + "</div><br />";

            form.Controls.Add(la);
            #region ConversionListaGrilla

            int TotalBobinaBuenEstado = 0;
            int TotalBobinaMalEstado = 0;
            int TotalPesoConsumo = 0;
            double TotalEscarpe = 0;
            int CantidadBobinaProyecto = 0;
            int CantidadBobinaSinProyecto = 0;
            int PesoBobinaConProyect = 0;
            int PesoBobinaSinProyect = 0;
            double EscarpeConProyect = 0;
            double EscarpeSinProyect = 0;

            foreach (string Maquina in lista.Select(o => o.Maquina).Distinct())
            {
                GridView gv = new GridView();
                gv.DataSource = lista.Where(o => o.Maquina == Maquina);
                gv.DataBind();
                gv.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

                gv.HeaderRow.Cells[0].Text = "Código Bobina";
                gv.HeaderRow.Cells[1].Text = "Papel";
                gv.HeaderRow.Cells[2].Text = "Gramaje";
                gv.HeaderRow.Cells[3].Text = "Ancho";
                gv.HeaderRow.Cells[4].Text = "Peso Inicial";
                gv.HeaderRow.Cells[5].Text = "Consumo";
                gv.HeaderRow.Cells[6].Text = "Origen Perdida";
                gv.HeaderRow.Cells[7].Text = "Motivo Perdida";
                gv.HeaderRow.Cells[8].Text = "Escarpe";
                gv.HeaderRow.Cells[9].Text = "% Perdida";
                gv.HeaderRow.Cells[10].Visible = false;
                gv.HeaderRow.Cells[11].Visible = false;
                gv.HeaderRow.Cells[12].Visible = false;
                gv.HeaderRow.Cells[13].Visible = false;
                gv.HeaderRow.Cells[14].Visible = false;

                int BobinaBuenEstado = 0;
                int BobinaMalEstado = 0;
                int PesoConsumo = 0;
                double Escarpe = 0;
                for (int contador = 0; contador < gv.Rows.Count; contador++)
                {
                    GridViewRow row = gv.Rows[contador];
                    row.Cells[1].Text = row.Cells[4].Text;
                    row.Cells[4].Text = row.Cells[2].Text;
                    row.Cells[2].Text = row.Cells[3].Text;
                    row.Cells[3].Text = row.Cells[4].Text;
                    row.Cells[4].Text = row.Cells[5].Text;
                    row.Cells[5].Text = row.Cells[9].Text.Replace(".", ",");
                    PesoConsumo += Convert.ToInt32(row.Cells[5].Text);
                    TotalPesoConsumo += Convert.ToInt32(row.Cells[5].Text);

                    row.Cells[6].Text = row.Cells[10].Text;
                    row.Cells[7].Text = row.Cells[11].Text.Replace("&nbsp;", "");
                    
 
                    if (row.Cells[6].Text != "&amp;nbsp;")
                    {
                        BobinaMalEstado++;
                        TotalBobinaMalEstado++;
                    }
                    else
                    {
                        row.Cells[6].Text = "";
                        row.Cells[7].Text = "";
                        BobinaBuenEstado++;
                        TotalBobinaBuenEstado++;
                    }
                    row.Cells[8].Text = row.Cells[12].Text;
                    Escarpe += Convert.ToDouble(row.Cells[12].Text.Replace(".",","));
                    TotalEscarpe += Convert.ToDouble(row.Cells[12].Text.Replace(".", ","));
                  
                    row.Cells[9].Text = row.Cells[13].Text;
                    row.Cells[10].Visible = false;
                    row.Cells[11].Visible = false;
                    row.Cells[12].Visible = false;
                    row.Cells[13].Visible = false;
                    row.Cells[14].Visible = false;

                    if (Convert.ToInt32(row.Cells[0].Text) >= 41469)
                    {
                        CantidadBobinaProyecto++;
                        PesoBobinaConProyect += Convert.ToInt32(row.Cells[5].Text);
                        EscarpeConProyect += Convert.ToDouble(row.Cells[12].Text);
                    }
                    else
                    {
                        CantidadBobinaSinProyecto++;
                        PesoBobinaSinProyect += Convert.ToInt32(row.Cells[5].Text);
                        EscarpeSinProyect += Convert.ToDouble(row.Cells[12].Text);
                    }

                }
                double promedioBobinasBuenaTotal = Convert.ToDouble(Convert.ToDouble(BobinaBuenEstado * 100) / (BobinaBuenEstado + BobinaMalEstado));
                double promedioBobinasMalasTotal = Convert.ToDouble(Convert.ToDouble(BobinaMalEstado * 100) / (BobinaBuenEstado + BobinaMalEstado));
                double promedioEscarpeCantidadBobinas = (Escarpe) / (BobinaBuenEstado + BobinaMalEstado);
                double porcentajeEscarpePesoInicial = Convert.ToDouble(Convert.ToDouble(Escarpe * 100) / (PesoConsumo));

                Label TablaMaquinaTotal = new Label();
                TablaMaquinaTotal.Text = "<br/><table><tr>" +
                                    "<td colspan ='7'></td><td  style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + (BobinaBuenEstado + BobinaMalEstado).ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + BobinaBuenEstado.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + BobinaMalEstado.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Total Peso Consumido</td>" +
                                    "<td style='border:1px solid black;'>" + PesoConsumo.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Total Escarpe Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + Escarpe.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + promedioBobinasBuenaTotal.ToString("N2") + "%</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Malas</td>" +
                                    "<td style='border:1px solid black;'>" + promedioBobinasMalasTotal.ToString("N2") + "%</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Promedio escalpe por bobina - kg</td>" +
                                    "<td style='border:1px solid black;'>" + promedioEscarpeCantidadBobinas.ToString("N2") + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe</td>" +
                                    "<td style='border:1px solid black;'>" + porcentajeEscarpePesoInicial.ToString("N2") + "%</td></tr></table>";

                Label Maquina1 = new Label();
                Maquina1.Text = "<div>" + Maquina + " </div><br/>";
                form.Controls.Add(Maquina1);

                form.Controls.Add(gv);

                form.Controls.Add(TablaMaquinaTotal);

            }
            #endregion

            Label TablaTotal = new Label();

            double TotalpromedioBobinasBuenaTotal = Convert.ToDouble(Convert.ToDouble(TotalBobinaBuenEstado * 100) / (TotalBobinaBuenEstado + TotalBobinaMalEstado));
            double TotalpromedioBobinasMalasTotal = Convert.ToDouble(Convert.ToDouble(TotalBobinaMalEstado * 100) / (TotalBobinaBuenEstado + TotalBobinaMalEstado));
            double TotalpromedioEscarpeCantidadBobinas = (TotalEscarpe) / (TotalBobinaBuenEstado + TotalBobinaMalEstado);
            double TotalporcentajeEscarpePesoInicial = Convert.ToDouble(Convert.ToDouble(TotalEscarpe * 100) / (TotalPesoConsumo));
            double PorcentajeConProyecto = Convert.ToDouble(Convert.ToDouble(EscarpeConProyect * 100) / PesoBobinaConProyect);
            double PorcentajeSinProyecto = Convert.ToDouble(Convert.ToDouble(EscarpeSinProyect * 100) / PesoBobinaSinProyect);

            TablaTotal.Text = "<br/><table><tr>" +
                                    "<td colspan ='7'></td><td  style='border:1px solid black;' colspan ='3' align='center'>General</td></tr><tr>" +
                                    "<td colspan ='7'></td><td  style='border:1px solid black;' colspan ='2'>Total Bobinas Consumidas</td>" +
                                    "<td style='border:1px solid black;'>" + (TotalBobinaBuenEstado + TotalBobinaMalEstado).ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + TotalBobinaBuenEstado.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Total Bobinas Malas</td>" +
                                    "<td style='border:1px solid black;'>" + TotalBobinaMalEstado.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Total Peso Consumido</td>" +
                                    "<td style='border:1px solid black;'>" + TotalPesoConsumo.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Total Escarpe Bobina</td>" +
                                    "<td style='border:1px solid black;'>" + TotalEscarpe.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Buenas</td>" +
                                    "<td style='border:1px solid black;'>" + TotalpromedioBobinasBuenaTotal.ToString("N2") + "%</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Promedio Bobina Malas</td>" +
                                    "<td style='border:1px solid black;'>" + TotalpromedioBobinasMalasTotal.ToString("N2") + "%</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Promedio escalpe por bobina - kg</td>" +
                                    "<td style='border:1px solid black;'>" + TotalpromedioEscarpeCantidadBobinas.ToString("N2") + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Promedio Escarpe</td>" +
                                    "<td style='border:1px solid black;'>" + TotalporcentajeEscarpePesoInicial.ToString("N2") + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Bobinas Con Proyecto</td>" +
                                    "<td style='border:1px solid black;'>" + CantidadBobinaProyecto.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Bobinas Sin Proyecto</td>" +
                                    "<td style='border:1px solid black;'>" + CantidadBobinaSinProyecto.ToString() + "</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>% Con Proyecto</td>" +
                                    "<td style='border:1px solid black;'>" + PorcentajeConProyecto.ToString("N2") + "%</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>% Sin Proyecto</td>" +
                                    "<td style='border:1px solid black;'>" + PorcentajeSinProyecto.ToString("N2") + "%</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Escarpe Almacen</td>" +
                                    "<td style='border:1px solid black;'>" + "0" + "%</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Escarpe Rollero</td>" +
                                    "<td style='border:1px solid black;'>" + "0" + "%</td></tr><tr>" +
                                    "<td colspan ='7'></td><td style='border:1px solid black;' colspan ='2'>Escarpe Proveedor</td>" +
                                    "<td style='border:1px solid black;'>" + "0" + "%</td></tr></table>";

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