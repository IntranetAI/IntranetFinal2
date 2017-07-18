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
    public partial class InformeProduccion : System.Web.UI.Page
    {
        Controller_EstadisticasProduccion ep = new Controller_EstadisticasProduccion();
        InformeProduccion_Controller ip = new InformeProduccion_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                divErrores.Visible = false;
                divGrilla.Attributes.Add("style", "height:550px;overflow:auto;");
            }
        }
        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                lblErrores.Text = "";
                List<EstProduccion> list = new List<EstProduccion>();
                RadGrid1.Columns[14].Visible = false;
                if (txtOT.Text != "" || txtNombreOT.Text != "")
                {
                    RadGrid1.DataSource = ep.Produccion_InformeProduccion(txtOT.Text, txtNombreOT.Text, "", "", "", DateTime.Now, DateTime.Now, 0);
                    RadGrid1.DataBind();
                    ddlArea.SelectedIndex = 0;
                    ddlMaquina.SelectedIndex = 0;
                    ddlOperador.SelectedIndex = 0;
                    txtFechaInicio.Text = "";
                    txtFechaTermino.Text = "";
                }
                else
                {
                    if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                    {            //            
                        string[] str = txtFechaInicio.Text.Split('/');
                        DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                        string[] str2 = txtFechaTermino.Text.Split('/');
                        DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                        if (ft > fi)
                        {
                            if (ddlArea.SelectedValue.ToString() != "Seleccione...")
                            {
                                if (ddlMaquina.SelectedValue.ToString() != "Seleccione...")
                                {
                                    if (ddlOperador.SelectedValue.ToString() != "" && ddlOperador.SelectedValue.ToString() != "Seleccione...")
                                    {
                                        RadGrid1.Columns[14].Visible = true;
                                        list = ep.Produccion_InformeProduccion(txtOT.Text, txtNombreOT.Text, ddlArea.SelectedValue.ToString(), ddlMaquina.SelectedValue.ToString(), ddlOperador.SelectedValue.ToString(), fi, ft, 3);
                                        RadGrid1.DataSource = list;
                                        RadGrid1.DataBind();
                                    }
                                    else
                                    {
                                        list = ep.Produccion_InformeProduccion(txtOT.Text, txtNombreOT.Text, ddlArea.SelectedValue.ToString(), ddlMaquina.SelectedValue.ToString(), "", fi, ft, 2);
                                        RadGrid1.DataSource = list;
                                        RadGrid1.DataBind();
                                    }
                                }
                                else
                                {
                                    list = ep.Produccion_InformeProduccion(txtOT.Text, txtNombreOT.Text, ddlArea.SelectedValue.ToString(), "", "", fi, ft, 1);
                                    RadGrid1.DataSource = list;
                                    RadGrid1.DataBind();
                                }
                            }
                            else
                            {
                                string popupScript = "<script language='JavaScript'> alert('¡ Debe seleccionar un Área !'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);
                            }


                            foreach (EstProduccion ps in list.GroupBy(b => b.CodRecurso).Select(grp => grp.FirstOrDefault()).ToList())
                            {
                                if (ps.CodRecurso != "KBA")
                                {
                                    lblErrores.Text += ep.CargaErrores(ps.CodRecurso, fi, ft, 4);
                                }
                            }
                            if (lblErrores.Text != "")
                            {
                                divErrores.Visible = true;
                                divGrilla.Attributes.Add("style", "height:400px;overflow:auto;");
                            }
                            else
                            {
                                divErrores.Visible = false;
                                divGrilla.Attributes.Add("style", "height:550px;overflow:auto;");
                            }
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('¡ La fecha de termino debe ser mayor a la fecha de inicio !'); </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('¡ Debe seleccionar un rango de fechas !'); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('¡ Ha ocurrido un error, vuelva a intentarlo !\\n Error:" + ex.Message + "'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
                try
                {
                    if (RadGrid1.Items.Count > 0)
                    {
                        ibExcel.Visible = true;
                    }
                    else
                    {
                        ibExcel.Visible = false;
                    }
                }
                catch (Exception ex2)
                {
                    string popupScript = "<script language='JavaScript'> alert('¡ Ha ocurrido un error, vuelva a intentarlo !\\n Error: " + ex2.Message + "'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Area = "";
                if (ddlArea.SelectedValue.ToString() != "Todas")
                {

                    ddlMaquina.DataSource = ip.ListaMaquina(ddlArea.SelectedValue.ToString(), 3);
                    ddlMaquina.DataTextField = "Maquina";
                    ddlMaquina.DataValueField = "CodMaquina";
                    ddlMaquina.DataBind();

                    ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));


                    if (ddlArea.SelectedValue.ToString() == "IMP PLANA")
                    {
                        ddlOperador.DataSource = ip.ListaOperador(Area, 16);
                        ddlOperador.DataTextField = "Operador";
                        ddlOperador.DataValueField = "CodMaquina";
                        ddlOperador.DataBind();

                        ddlOperador.Items.Insert(0, new ListItem("Seleccione..."));
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('¡ Error al carga Maquina !\\n Error: " + ex.Message + "'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
        protected void ddlMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMaquina.SelectedValue.ToString() != "Seleccione....")
                {
                    ddlOperador.DataSource = ip.ListaOperador(ddlMaquina.SelectedValue.ToString(), 17);
                    ddlOperador.DataTextField = "Operador";
                    ddlOperador.DataValueField = "Operador";
                    ddlOperador.DataBind();

                    ddlOperador.Items.Insert(0, new ListItem("Seleccione..."));
                }
                
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('¡ Error al carga Operador !\\n Error: " + ex.Message + "'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (RadGrid1.Items.Count > 0)
                {
                    List<EstProduccion> lista = new List<EstProduccion>();
                    for (int i = 0; i < RadGrid1.Items.Count; i++)
                    {
                        EstProduccion p = new EstProduccion();
                        p.Maquina = RadGrid1.Items[i]["Maquina"].Text;
                        p.OT = RadGrid1.Items[i]["OT"].Text.ToUpper();
                        p.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                        p.Pliego = RadGrid1.Items[i]["Pliego"].Text;
                        p.Planificado = RadGrid1.Items[i]["Planificado"].Text.Replace(".", "");
                        p.Producido = RadGrid1.Items[i]["Producido"].Text.Replace(".", "");
                        p.HorasTiraje = RadGrid1.Items[i]["HorasTiraje"].Text;
                        p.MermaTiraje = RadGrid1.Items[i]["MermaTiraje"].Text.Replace(".", "");
                        p.MermaPreparacion = RadGrid1.Items[i]["MermaPreparacion"].Text.Replace(".", "");
                        p.HorasPreparacion = RadGrid1.Items[i]["HorasPreparacion"].Text;
                        p.Velocidad = RadGrid1.Items[i]["Velocidad"].Text.Replace(".", "").Replace("/Hr","");
                        p.Uptime = RadGrid1.Items[i]["Uptime"].Text;
                        p.FechaInicio = RadGrid1.Items[i]["FechaInicio"].Text;
                        p.FechaTermino = RadGrid1.Items[i]["FechaTermino"].Text;
                        p.Operador = RadGrid1.Items[i]["Operador"].Text;
                        lista.Add(p);
                    }
                    GridView GridView1 = new GridView();
                    GridView1.DataSource = lista;
                    GridView1.DataBind();
                    GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                    GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                    if (RadGrid1.Columns[14].Visible == false)
                    {
                        GridView1.HeaderRow.Cells[14].Visible = false;
                    }                    
                    GridView1.HeaderRow.Cells[15].Visible = false;
                    GridView1.HeaderRow.Cells[16].Visible = false;

                    for (int contador = 0; contador < GridView1.Rows.Count; contador++)
                    {
                        GridViewRow row = GridView1.Rows[contador];
                        if (RadGrid1.Columns[14].Visible == false)
                        {
                            row.Cells[14].Visible = false;
                        }
                        row.Cells[15].Visible = false;
                        row.Cells[16].Visible = false;
                    }
                    string NombreInforme = "";
                    if (txtOT.Text != "")
                    {
                        NombreInforme = "OT: " + txtOT.Text;
                    }
                    else
                    {
                        if (ddlMaquina.SelectedValue.ToString() != "Seleccione...")
                        {
                            NombreInforme = "Máquina " + ddlMaquina.SelectedItem.ToString() + " Desde " + txtFechaInicio.Text + " Hasta " + txtFechaTermino.Text;
                        }
                        else
                        {
                            NombreInforme = "Área " + ddlArea.SelectedItem.ToString() + " Desde " + txtFechaInicio.Text + " Hasta " + txtFechaTermino.Text;
                        }
                    }
                    ExportToExcel(NombreInforme, GridView1);
                }
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error al generar el archivo excel! \\n Error: " + ex.Message + "'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
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

                la.Text = "<div align='center'><b>Informe Produccion</b><br/>" + nameReport + "</div><br/>";

                form.Controls.Add(la);
                form.Controls.Add(wControl);
                pageToRender.Controls.Add(form);
                response.Clear();
                response.Buffer = true;
                response.ContentType = "application/vnd.ms-excel";
                response.AddHeader("Content-Disposition", "attachment;filename=ÏnformeProduccion.xls");
                response.Charset = "UTF-8";
                response.ContentEncoding = Encoding.Default;
                pageToRender.RenderControl(htw);
                response.Write(sw.ToString());
                response.End();
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('Error ExportToExcel function() \\n Error: " + ex.Message + "'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

    }
}