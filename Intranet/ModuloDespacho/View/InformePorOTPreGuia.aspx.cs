using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.View
{
    public partial class InformePorOTPreID : System.Web.UI.Page
    {
        Controller_EstadoOT o = new Controller_EstadoOT();
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
            if (txtNumeroOT.Text != "")
            {
                try
                {
                    if (ddlEstado.SelectedValue.ToString() == "Todos")
                    {
                        RadGrid1.DataSource = o.ListaPreGuiasDespacho(txtNumeroOT.Text, 1, 0);
                        RadGrid1.DataBind();
                    }
                    else
                    {
                        RadGrid1.DataSource = o.ListaPreGuiasDespacho(txtNumeroOT.Text, Convert.ToInt32(ddlEstado.SelectedValue.ToString()), 1);
                        RadGrid1.DataBind();
                    }
                }
                catch
                {
                    string popupScript = "<script language='JavaScript'> alert('ha Ocurrido un error vuelva a intentarlo');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('Debe ingresar una OT para realizar la busqueda');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
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
            la.Text = "<div align='center'>INFORME ESTADO GUIAS DESPACHO<br/> </div><br/>";
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
        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (RadGrid1.Items.Count > 0)
            {
                try
                {
                    List<Desp_PreGuia> lista = new List<Desp_PreGuia>();
                    for (int i = 0; i < RadGrid1.Items.Count; i++)
                    {
                        Desp_PreGuia p = new Desp_PreGuia();
                        p.OT = RadGrid1.Items[i]["OT"].Text;
                        p.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                        p.Estado = RadGrid1.Items[i]["Estado"].Text;
                        p.NroPreGuia = RadGrid1.Items[i]["NroPreGuia"].Text;
                        p.NroGuia = RadGrid1.Items[i]["NroGuia"].Text;
                        p.Sucursal = RadGrid1.Items[i]["Sucursal"].Text;
                        p.FechaDespacho = RadGrid1.Items[i]["FechaDespacho"].Text.Replace("&nbsp;", "");
                        p.TirajeOT = RadGrid1.Items[i]["TirajeOT"].Text.Replace(".", "");
                        p.CantidadGuia = RadGrid1.Items[i]["CantidadGuia"].Text.Replace(".", "");
                        lista.Add(p);
                    }
                    GridView GridView1 = new GridView();
                    GridView1.DataSource = lista;
                    GridView1.DataBind();
                    GridView1.HeaderStyle.BackColor = System.Drawing.Color.DarkGray;
                    GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    string nombre = "EstadoGuias_" + txtNumeroOT.Text;
                    ExportToExcel(nombre, GridView1, "");
                }
                catch
                {
                    string popupScript = "<script language='JavaScript'> alert('ha Ocurrido un error, vuelva a intentarlo');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('¡No hay registros para exportar!');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}