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
using System.Globalization;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class InformeFinishENC : System.Web.UI.Page
    {
        Controller_EstadisticaProduccion ep = new Controller_EstadisticaProduccion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = Convert.ToInt32(DateTime.Now.ToString("yyyy")); i >= 2015; i--)
                {
                    ddlAño.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ddlAño.SelectedIndex = 0;

                ddlSector.DataSource = ep.ListaMaquina(3);
                ddlSector.DataTextField = "OTS";
                ddlSector.DataValueField = "OTS";
                ddlSector.DataBind();
                ddlSector.Items.Insert(0, new ListItem("TODOS"));

                ddlMes.SelectedIndex = Convert.ToInt32(DateTime.Now.Month) - 1;
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                if (ddlSector.SelectedValue.ToString() == "TODOS")
                {
                    Label1.Text = ep.ListarInformeFinish(Convert.ToInt32(ddlMes.SelectedValue.ToString()), Convert.ToInt32(ddlAño.SelectedValue.ToString()), "TODOS", 0);
                }
                else
                {
                    Label1.Text = ep.ListarInformeFinish(Convert.ToInt32(ddlMes.SelectedValue.ToString()), Convert.ToInt32(ddlAño.SelectedValue.ToString()), ddlSector.SelectedValue.ToString(), 1);
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
                ExportToExcel("InformeFinish_" + ddlMes.SelectedValue.ToString() + "-" + ddlAño.SelectedValue.ToString(), "", Label1.Text);
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

            la.Text = "<div align='center'>Informe Finish</div><div align='center'>" + Contenido.Replace("<espacio>", "<div>&nbsp;</div>");
            form.Controls.Add(la);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "inline;filename=" + nameReport + ".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }
    }
}