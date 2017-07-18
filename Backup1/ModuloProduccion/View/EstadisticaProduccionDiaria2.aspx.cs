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
    public partial class EstadisticaProduccionDiaria2 : System.Web.UI.Page
    {
        InformeProduccion_Controller ipp = new InformeProduccion_Controller();
        Controller_InformeProduccion_V2 ip = new Controller_InformeProduccion_V2();
        Partes pp = new Partes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.Visible = true;
                RadGrid2.Visible = false;
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }

        } 
        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                if (ddlSeccion.SelectedValue.ToString() != "Seleccione..." && txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                    if (ft > fi)
                    {
                        if (ddlMaquina.SelectedValue.ToString() != "" || ddlMaquina.SelectedValue.ToString() != "Seleccione...")
                        {
                            if (ddlMaquina.SelectedValue.ToString() == "MR408")
                            {
                                RadGrid1.Visible = true;
                                RadGrid2.Visible = false;
                                RadGrid1.DataSource = ip.EstadisticaProduccion_Diaria_V2("MR408", fi, ft, 0);
                                RadGrid1.DataBind();
                            }
                            else if (ddlMaquina.SelectedValue.ToString() == "C150")
                            {
                                RadGrid1.Visible = true;
                                RadGrid2.Visible = false;
                                RadGrid1.DataSource = ip.EstadisticaProduccion_Diaria_V2("C150", fi, ft, 0);
                                RadGrid1.DataBind();
                            }
                            else if (ddlMaquina.SelectedValue.ToString() == "KBA" || ddlMaquina.SelectedValue.ToString() == "M2016")
                            {
                                RadGrid1.Visible = false;
                                RadGrid2.Visible = true;
                                RadGrid2.DataSource = ip.EstadisticaProduccion_Diaria_V2(ddlMaquina.SelectedValue.ToString(), fi, ft, 1);
                                RadGrid2.DataBind();
                            }
                            else
                            {
                                RadGrid1.Visible = false;
                                RadGrid2.Visible = true;
                                RadGrid2.DataSource = ip.EstadisticaProduccion_Diaria_V2(ddlMaquina.SelectedValue.ToString(), fi, ft, 0);
                                RadGrid2.DataBind();
                            }
                            lblGrid1.Text = ddlMaquina.SelectedItem.ToString();

                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('¡Debe seleccionar una Máquina!');</script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('¡La fecha de termino no puede ser mayor a la de inicio.!');</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Debe ingresar fecha de inicio y termino!');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('¡Ha ocurrido un error, vuelva a intentarlo!\\n Error:" + ex.Message + "');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Area = "";
                if (ddlSeccion.SelectedValue.ToString() == "Todas")
                {
                    Area = "";
                }
                else
                {
                    Area = ddlSeccion.SelectedValue.ToString();
                }
                ddlMaquina.DataSource = ipp.ListaMaquina(Area, 3);
                ddlMaquina.DataTextField = "Maquina";
                ddlMaquina.DataValueField = "CodMaquina";
                ddlMaquina.DataBind();

                ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('¡Ha ocurrido un error al cargar las maquinas!\\n Error:" + ex.Message + "');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (RadGrid1.Visible == true)
                {
                    if (RadGrid1.Items.Count > 0)
                    {
                        List<Informe_Produccion_V2> lista = new List<Informe_Produccion_V2>();
                        for (int i = 0; i < RadGrid1.Items.Count; i++)
                        {
                            Informe_Produccion_V2 p = new Informe_Produccion_V2();
                            p.Semana = RadGrid1.Items[i]["Semana"].Text;
                            p.Maquina = RadGrid1.Items[i]["Maquina"].Text;
                            p.Giros = RadGrid1.Items[i]["Giros"].Text.Replace(".", "");
                            p.Entradas = RadGrid1.Items[i]["Entradas"].Text;
                            p.HorasTiraje = RadGrid1.Items[i]["HorasTiraje"].Text;
                            p.HorasImproductivas = RadGrid1.Items[i]["HorasImproductivas"].Text;
                            p.HorasPreparacion = RadGrid1.Items[i]["HorasPreparacion"].Text;
                            p.HorasSinTrabajo = RadGrid1.Items[i]["HorasSinTrabajo"].Text;
                            p.HorasSinPersonal = RadGrid1.Items[i]["HorasSinPersonal"].Text;
                            p.HorasMantencion = RadGrid1.Items[i]["HorasMantencion"].Text;
                            p.HorasPruebaImpresion = RadGrid1.Items[i]["HorasPruebaImpresion"].Text;
                            p.GirosMalosPreparacion = RadGrid1.Items[i]["GirosMalosPreparacion"].Text.Replace(".", "");
                            p.PliegosMalosPreparacion = RadGrid1.Items[i]["PliegosMalosPreparacion"].Text.Replace(".", "");
                            p.GirosMalosTiraje = RadGrid1.Items[i]["GirosMalosTiraje"].Text.Replace(".", "");
                            p.PliegosMalosTiraje = RadGrid1.Items[i]["PliegosMalosTiraje"].Text.Replace(".", "");
                            p.Buenos = RadGrid1.Items[i]["Buenos"].Text.Replace(".", "");
                            lista.Add(p);
                        }
                        GridView GridView1 = new GridView();
                        GridView1.DataSource = lista;
                        GridView1.DataBind();
                        GridView1.HeaderRow.Cells[0].Text = "Dia";
                        GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                        GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        ExportToExcel("Estadistica_ProduccionDiaria", "", GridView1);
                    }
                }
                else
                {
                    if (RadGrid2.Items.Count > 0)
                    {
                        List<Informe_Produccion_V2> lista = new List<Informe_Produccion_V2>();
                        for (int i = 0; i < RadGrid2.Items.Count; i++)
                        {
                            Informe_Produccion_V2 p = new Informe_Produccion_V2();
                            p.Semana = RadGrid2.Items[i]["Semana"].Text;
                            p.Maquina = RadGrid2.Items[i]["Maquina"].Text;

                            p.Entradas = RadGrid2.Items[i]["Entradas"].Text;
                            p.HorasTiraje = RadGrid2.Items[i]["HorasTiraje"].Text;
                            p.HorasImproductivas = RadGrid2.Items[i]["HorasImproductivas"].Text;
                            p.HorasPreparacion = RadGrid2.Items[i]["HorasPreparacion"].Text;
                            p.HorasSinTrabajo = RadGrid2.Items[i]["HorasSinTrabajo"].Text;
                            p.HorasSinPersonal = RadGrid2.Items[i]["HorasSinPersonal"].Text;
                            p.HorasMantencion = RadGrid2.Items[i]["HorasMantencion"].Text;
                            p.HorasPruebaImpresion = RadGrid2.Items[i]["HorasPruebaImpresion"].Text;

                            p.PliegosMalosPreparacion = RadGrid2.Items[i]["PliegosMalosPreparacion"].Text.Replace(".", "");
                            p.GirosMalosPreparacion = p.PliegosMalosPreparacion;

                            p.PliegosMalosTiraje = RadGrid2.Items[i]["PliegosMalosTiraje"].Text.Replace(".", "");
                            p.GirosMalosTiraje = p.PliegosMalosTiraje;
                            p.Buenos = RadGrid2.Items[i]["Buenos"].Text.Replace(".", "");
                            p.Giros = p.Buenos;
                            lista.Add(p);
                        }
                        GridView GridView1 = new GridView();
                        GridView1.DataSource = lista;
                        GridView1.DataBind();
                        GridView1.HeaderRow.Cells[0].Text = "Dia";
                        GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                        GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        ExportToExcel("Estadistica_ProduccionDiaria", "", GridView1);
                    }
                }
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('Ha Ocurrido un error al exportar a Excel\\n Error:" + ex.Message + "'); </script>";
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

            la.Text = "<div align='center'>Estadistica Producción Diaria</div><div align='center'>";
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