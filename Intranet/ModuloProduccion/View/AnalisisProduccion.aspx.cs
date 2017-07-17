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
    public partial class AnalisisProduccion : System.Web.UI.Page
    {
        InformeProduccion_Controller ip = new InformeProduccion_Controller();
        Controller_InformeProduccion_V2 ci = new Controller_InformeProduccion_V2();
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
            List<Analisis_Produccion_V2> lista = new List<Analisis_Produccion_V2>();
            List<Analisis_Produccion_V2> lista2 = new List<Analisis_Produccion_V2>();
            string Maquina = "";
            if (txtOT.Text != "")
            {
                lista = ci.AnalisisProduccion_V2(txtOT.Text.Trim(), "", "", "", "", 1);
                lista2 = ci.AnalisisProduccion_V2(txtOT.Text.Trim(), "", "", "", "", 2);
                RadGrid1.DataSource = lista.Concat(lista2).ToList();
                ddlArea.SelectedIndex = 0;
                ddlMaquina.SelectedIndex = 0;
                txtFechaInicio.Text = "";
                txtFechaTermino.Text = "";
            }
            else
            {
                if (ddlMaquina.SelectedItem.Text != "Seleccione...")
                {
                    Maquina = ddlMaquina.SelectedValue.ToString();

                    if ((txtFechaInicio.Text == "") && (txtFechaTermino.Text == ""))
                    {
                        string popupScript = "<script language='JavaScript'> alert('Debe ingresar un rango de fechas'); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    else
                    {
                        string[] array = txtFechaInicio.Text.Split('/');
                        string FInicio = array[2] + "/" + array[1] + "/" + array[0];
                        string[] array2 = txtFechaTermino.Text.Split('/');
                        string FTermino = array2[2] + "/" + array2[1] + "/" + array2[0] + " 23:59:59";
                        RadGrid1.DataSource = ci.AnalisisProduccion_V2(txtOT.Text.Trim(), txtNombreOT.Text.Trim(), Maquina, FInicio, FTermino, 0);//Area
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Seleccione una maquina!'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            RadGrid1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlArea.SelectedValue.ToString() != "Todas")
                {

                    ddlMaquina.DataSource = ip.ListaMaquina(ddlArea.SelectedValue.ToString(), 3);
                    ddlMaquina.DataTextField = "Maquina";
                    ddlMaquina.DataValueField = "CodMaquina";
                    ddlMaquina.DataBind();

                    ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));

                }
            }
            catch
            {
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<Analisis_Produccion_V2> lista = new List<Analisis_Produccion_V2>();
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    Analisis_Produccion_V2 p = new Analisis_Produccion_V2();
                    p.Maquina = RadGrid1.Items[i]["Maquina"].Text;
                    p.OT = RadGrid1.Items[i]["OT"].Text;
                    p.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                    p.Entradas = RadGrid1.Items[i]["Entradas"].Text;
                    p.Giros = RadGrid1.Items[i]["Giros"].Text.Replace(".", "");
                    p.HorasPreparacion = RadGrid1.Items[i]["HorasPreparacion"].Text;
                    p.HorasTiraje = RadGrid1.Items[i]["HorasTiraje"].Text;
                    p.HorasImproductivas = RadGrid1.Items[i]["HorasImproductivas"].Text;
                    p.Buenos = RadGrid1.Items[i]["Buenos"].Text.Replace(".", "");
                    p.MalosPreparacion = RadGrid1.Items[i]["MalosPreparacion"].Text.Replace(".", "");
                    p.MalosTiraje = RadGrid1.Items[i]["MalosTiraje"].Text.Replace(".", "");
                    lista.Add(p);
                }
                GridView GridView1 = new GridView();
                GridView1.DataSource = lista;
                GridView1.DataBind();
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

                //GridView1.HeaderRow.Cells[19].Visible = false;

                //for (int contador = 0; contador < GridView1.Rows.Count; contador++)
                //{
                //    GridViewRow row = GridView1.Rows[contador];
                //    row.Cells[19].Visible = false;
                //}
                ExportToExcel("Analisis_Produccion", "", GridView1);
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('Ha Ocurrido un error al exportar a Excel'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }
        private void ExportToExcel(string nameReport, string Titulo, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            la.Text = "<div align='center'>Análisis de Produccion</div><div align='center'>";
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
            response.End();
        }
    }
}