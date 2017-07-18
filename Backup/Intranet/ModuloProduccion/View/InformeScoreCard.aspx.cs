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
    public partial class InformeScoreCard : System.Web.UI.Page
    {
        Controller_EstadisticasProduccion ep = new Controller_EstadisticasProduccion();
        InformeProduccion_Controller ip = new InformeProduccion_Controller();
        Controller_InfScoreCard i = new Controller_InfScoreCard();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                divGrilla.Attributes.Add("style", "width:1100px;height:550px;overflow:auto;");
                divErrores.Visible = false;
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    List<ScoreCard> list = new List<ScoreCard>();
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                    if (ddlArea.SelectedValue.ToString() == "Todas" && (ddlMaquina.SelectedValue.ToString() == "" || ddlMaquina.SelectedValue.ToString() == "Seleccione..."))
                    {
                        //TODAS
                        list = i.Lista_Detalle("", "", ddlArea.SelectedValue.ToString(), ddlMaquina.SelectedValue.ToString(), fi, ft, 0);
                        RadGrid1.DataSource = list;
                    }
                    else
                    {
                        if (ddlMaquina.SelectedValue.ToString() == "" || ddlMaquina.SelectedValue.ToString() == "Seleccione...")
                        {
                            //Area
                            list=i.Lista_Detalle("", "", ddlArea.SelectedValue.ToString(), ddlMaquina.SelectedValue.ToString(), fi, ft, 1);
                            RadGrid1.DataSource = list;
                        }
                        else
                        {
                            //Maquina
                            list=i.Lista_Detalle("", "", ddlArea.SelectedValue.ToString(), ddlMaquina.SelectedValue.ToString(), fi, ft, 2);
                            RadGrid1.DataSource = list;
                        }
                    }

                    RadGrid1.DataBind();
                    ibExcel.Visible = true;

                    foreach (ScoreCard ps in list.GroupBy(b => b.CodRecurso).Select(grp => grp.FirstOrDefault()).ToList())
                    {
                        if (ps.CodRecurso != "KBA")
                        {
                            lblErrores.Text += ep.CargaErrores(ps.CodRecurso, fi, ft, 4);
                        }
                    }
                    if (lblErrores.Text != "")
                    {
                        divErrores.Visible = true;
                        divGrilla.Attributes.Add("style", "width:1100px;height:400px;overflow:auto;");
                    }
                    else
                    {
                        divErrores.Visible = false;
                        divGrilla.Attributes.Add("style", "width:1100px;height:550px;overflow:auto;");
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡La fecha de inicio y termino es Obligatoria!'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                
            }
            catch 
            {
                string popupScript = "<script language='JavaScript'> alert('Ha Ocurrido un error\\n - Verificar Cierre de Fechas metrics'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Area = "";
                if (ddlArea.SelectedValue.ToString() == "Todas")
                {
                    Area = "";
                }
                else
                {
                    Area = ddlArea.SelectedValue.ToString();
                }
                ddlMaquina.DataSource = ip.ListaMaquina(Area, 3);
                ddlMaquina.DataTextField = "Maquina";
                ddlMaquina.DataValueField = "CodMaquina";
                ddlMaquina.DataBind();

                ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
            }
            catch
            {
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<ScoreCard> lista = new List<ScoreCard>();
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    ScoreCard p = new ScoreCard();
                    p.Maquina = RadGrid1.Items[i]["Maquina"].Text;
                    //p.Entradas = RadGrid1.Items[i]["Entradas"].Text.Replace(".", "");
                    p.OT = RadGrid1.Items[i]["OT"].Text;
                    p.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                    p.Cliente = RadGrid1.Items[i]["Cliente"].Text;
                    p.Planificado = RadGrid1.Items[i]["Planificado"].Text.Replace(".", "");
                    p.Giros = RadGrid1.Items[i]["Giros"].Text.Replace(".", "");
                    p.Pliego = RadGrid1.Items[i]["Pliego"].Text.Replace(".", "");
                    p.Buenos = RadGrid1.Items[i]["Buenos"].Text.Replace(".", "");
                    p.HorasPreparacion = RadGrid1.Items[i]["HorasPreparacion"].Text;
                    p.HorasTiraje = RadGrid1.Items[i]["HorasTiraje"].Text;
                    p.HorasImproductivas = RadGrid1.Items[i]["HorasImproductivas"].Text;
                    //p.HorasSinTrabajo = RadGrid1.Items[i]["HorasSinTrabajo"].Text;
                    //p.HorasSinPersonal = RadGrid1.Items[i]["HorasSinPersonal"].Text;
                    //p.HorasMantencion = RadGrid1.Items[i]["HorasMantencion"].Text;
                    p.MermaArranque = RadGrid1.Items[i]["MermaArranque"].Text.Replace(".", "");
                    p.MermaTiraje = RadGrid1.Items[i]["MermaTiraje"].Text.Replace(".", "");
                    //p.CantidadOperadores = RadGrid1.Items[i]["CantidadOperadores"].Text;
                    p.Planchas = RadGrid1.Items[i]["Planchas"].Text.Replace(".", "");
                    p.Colores = RadGrid1.Items[i]["Colores"].Text.Replace(".", "");
                    //p.Preparaciones = RadGrid1.Items[i]["Preparaciones"].Text.Replace(".", "");
                    //p.HorasDisponibles = RadGrid1.Items[i]["HorasDisponibles"].Text;
                    p.HorasDirectas = RadGrid1.Items[i]["HorasDirectas"].Text;

                    p.VPromedio = RadGrid1.Items[i]["VPromedio"].Text.Replace(".", "").Replace("/Hr", "");
                    p.Uptime = RadGrid1.Items[i]["Uptime"].Text;
                    //p.Escarpe = RadGrid1.Items[i]["Escarpe"].Text;
                    //p.Cono = RadGrid1.Items[i]["Cono"].Text;
                    //p.ConsumoPapel = RadGrid1.Items[i]["ConsumoPapel"].Text;
                    lista.Add(p);
                }
                GridView GridView1 = new GridView();
                GridView1.DataSource = lista;
                GridView1.DataBind();
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
               
                GridView1.HeaderRow.Cells[19].Visible = false;

                for (int contador = 0; contador < GridView1.Rows.Count; contador++)
                {
                    GridViewRow row = GridView1.Rows[contador];
                    row.Cells[19].Visible = false;
                }

                string Resultado = "";
                string NMRep = "";
                if (ddlMaquina.SelectedValue.ToString() == "" || ddlMaquina.SelectedValue.ToString() == "Seleccione...")
                {
                    Resultado = "Area " + ddlArea.SelectedItem.ToString();
                    NMRep = "InformeProduccion_" + ddlArea.SelectedItem.ToString() + "_" + txtFechaInicio.Text + " al " + txtFechaTermino.Text;
                }
                else
                {
                    Resultado = "Maquina " + ddlMaquina.SelectedItem.ToString();
                    NMRep = "InformeProduccion_" + ddlMaquina.SelectedItem.ToString() + "_" + txtFechaInicio.Text + " al " + txtFechaTermino.Text;
                }
                string Titulo = "Desde " + txtFechaInicio.Text + " al " + txtFechaTermino.Text + "</div><div align='center'>" + Resultado + "</div>";
                ExportToExcel(NMRep, Titulo, GridView1);
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('Ha Ocurrido un error al exportar a Excel'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }
        private void ExportToExcel(string nameReport,string Titulo, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            la.Text = "<div align='center'>Informe Produccion</div><div align='center'>" + Titulo;

            form.Controls.Add(la);
            form.Controls.Add(wControl);
            //Label l = new Label(); l.Text = "<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>";// +TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>";
            //form.Controls.Add(l);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename="+nameReport+".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }
    }
}