using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Intranet.ModuloProduccion.View
{
    public partial class Informe_EstadoOT : System.Web.UI.Page
    {
        EstadoOTController eot = new EstadoOTController();
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
            string Estado = ((ddlEstado.SelectedValue.ToString() == "0") ? "" : ddlEstado.SelectedValue.ToString());
            try
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fIni = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime fTer = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                    RadGrid1.DataSource = eot.Listado_EstadoOT(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, fIni, fTer, Estado, 1);
                    RadGrid1.DataBind();
                }
                else
                {
                    RadGrid1.DataSource = eot.Listado_EstadoOT(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, DateTime.Now, DateTime.Now, Estado, 0);
                    RadGrid1.DataBind();
                }
            }
            catch(Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert("+ex.Message+"); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            string oot = "";
            try
            {
                List<Informe_EstadosOT> lista = new List<Informe_EstadosOT>();
                if (RadGrid1.Items.Count > 0)
                {
                    for (int i = 0; i < RadGrid1.Items.Count; i++)
                    {
                        Informe_EstadosOT p = new Informe_EstadosOT();
                        p.OT = RadGrid1.Items[i]["OT"].Text;
                        oot = p.OT;
                        p.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                        p.Cliente = RadGrid1.Items[i]["Cliente"].Text;
                        p.FechaEmision = RadGrid1.Items[i]["FechaEmision"].Text;
                        p.FechaEntrega = RadGrid1.Items[i]["FechaEntrega"].Text.Replace("&nbsp;", "");
                        p.Tiraje = RadGrid1.Items[i]["Tiraje"].Text.Replace(".", "");
                        p.Estado = RadGrid1.Items[i]["Estado"].Text;
                        lista.Add(p);
                    }
                    GridView GridView1 = new GridView();
                    GridView1.DataSource = lista;
                    GridView1.DataBind();
                    GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                    GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

                    ExportToExcel("Estados_OT", "", GridView1);
                }
            }
            catch(Exception ex)
            {
                string a = oot;
            }
        }
        private void ExportToExcel(string nameReport, string Titulo, GridView wControl)
        {
            try
            {
                HttpResponse response = Response;
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                Page pageToRender = new Page();
                HtmlForm form = new HtmlForm();
                Label la = new Label();

                la.Text = "<div align='center'>Informe Estado OT</div><div align='center'>";
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
            }catch(Exception exx)
            {

            }
        }
    }
}