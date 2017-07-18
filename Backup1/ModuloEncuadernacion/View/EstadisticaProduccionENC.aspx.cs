using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Reflection;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class EstadisticaProduccionENC : System.Web.UI.Page
    {
        Controller_EstadisticaProduccion ep= new Controller_EstadisticaProduccion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlAño.Items.Add("Seleccione...");
                for (int i = Convert.ToInt32(DateTime.Now.ToString("yyyy")); i >= 2015; i--)
                {
                    ddlAño.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ddlAño.SelectedIndex = 1;

                ddlSector.DataSource = ep.ListaMaquina(3);
                ddlSector.DataTextField = "OTS";
                ddlSector.DataValueField = "OTS";
                ddlSector.DataBind();
                ddlSector.Items.Insert(0, new ListItem("Seleccione..."));

                ddlMes.SelectedIndex = Convert.ToInt32(DateTime.Now.Month) - 1;
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                int Mesinicial = 0; int mesactual = 0;int año=0;
                if (ddlSector.SelectedValue.ToString() != "Seleccione..." && ddlAño.SelectedValue.ToString() != "Seleccione...")
                {
                    if (Convert.ToInt32(ddlMes.SelectedValue.ToString()) >= 4)
                    {
                        Mesinicial = Convert.ToInt32(ddlMes.SelectedValue.ToString()) - 2;
                        mesactual = Convert.ToInt32(ddlMes.SelectedValue.ToString());
                        año=Convert.ToInt32(ddlAño.SelectedValue.ToString());
                    }
                    else
                    {
                        Mesinicial = 1;
                        mesactual = Convert.ToInt32(ddlMes.SelectedValue.ToString());
                        año=Convert.ToInt32(ddlAño.SelectedValue.ToString());
                    }
                    Label1.Text = ep.ListarRegistro(Mesinicial, mesactual, año, ddlSector.SelectedValue.ToString(), 0).Replace("<espacio>", "<div>&nbsp;</div>");

                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡ debe ingresar sector y año valido!'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch(Exception ex)
            {
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int Mesinicial = 0; int mesactual = 0; int año = 0;
                if (ddlSector.SelectedItem.ToString() != "Seleccione..." || ddlAño.SelectedValue.ToString() != "Seleccione...")
                {
                    if (Convert.ToInt32(ddlMes.SelectedValue.ToString()) >= 4)
                    {
                        Mesinicial = Convert.ToInt32(ddlMes.SelectedValue.ToString()) - 3;
                        mesactual = Convert.ToInt32(ddlMes.SelectedValue.ToString());
                        año = Convert.ToInt32(ddlAño.SelectedValue.ToString());
                    }
                    else
                    {
                        Mesinicial = 1;
                        mesactual = Convert.ToInt32(ddlMes.SelectedValue.ToString());
                        año = Convert.ToInt32(ddlAño.SelectedValue.ToString());
                    }
                    ExportToExcel("EstadisticaProduccion", "", Label1.Text + "<div>&nbsp;</div><div align='center'>DETALLE IMPRODUCTIVOS<table><tr style='vertical-align: top;'>" + ep.ListarImproductivosMaquina(Mesinicial, mesactual, año, ddlSector.SelectedValue.ToString(), 2) + "</tr></table></div>");

                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡ debe ingresar sector y año valido!'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                
            }
            catch
            {
            }
        }
        private void ExportToExcel(string nameReport, string Titulo, string Contenido)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            la.Text = "<div align='center'>Estadistica Producción Diaria</div><div align='center'>" + Contenido.Replace("<espacio>", "<div>&nbsp;</div>");
            form.Controls.Add(la);
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