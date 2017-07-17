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
using Intranet.ModuloEncuadernacion.Model;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class InformeEstadoGuias : System.Web.UI.Page
    {
        Controller_ProductosTerminados p = new Controller_ProductosTerminados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = p.InformeEstadoGuias("", "", DateTime.Now, DateTime.Now, 0);
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                RadGrid1.DataSource = p.InformeEstadoGuias(txtOT.Text, txtNombreOT.Text, fi, ft, 1);
                RadGrid1.DataBind();
            }
            else
            {
                RadGrid1.DataSource = p.InformeEstadoGuias(txtOT.Text, txtNombreOT.Text, DateTime.Now, DateTime.Now, 2);
                RadGrid1.DataBind();
            }
        }
        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            List<InfEstadoGuias> lista = new List<InfEstadoGuias>();
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                InfEstadoGuias p = new InfEstadoGuias();
                p.NroPallet = RadGrid1.Items[i]["NroPallet"].Text;
                p.OT = RadGrid1.Items[i]["OT"].Text;
                p.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                p.Terminacion = RadGrid1.Items[i]["Terminacion"].Text;
                p.TipoEmbalaje = RadGrid1.Items[i]["TipoEmbalaje"].Text;
                p.Cantidad = RadGrid1.Items[i]["Cantidad"].Text.Replace(".", "");
                p.Ejemplares = RadGrid1.Items[i]["Ejemplares"].Text.Replace(".", "");
                p.Total = RadGrid1.Items[i]["Total"].Text.Replace(".", "");
                p.Modelo = RadGrid1.Items[i]["Modelo"].Text;
                p.Observacion = RadGrid1.Items[i]["Observacion"].Text.Replace("&nbsp;", "");
                p.FechaCreacion = RadGrid1.Items[i]["FechaCreacion"].Text;
                if(RadGrid1.Items[i]["Estado"].Text=="<div style='Color:red;'>Rechazado</div>")
                {
                    p.Estado = "Rechazada";
                }
                else if (RadGrid1.Items[i]["Estado"].Text == "<div style='Color:Blue;'>Creado</div>")
                {
                    p.Estado = "Creado";
                }
                else
                {
                    p.Estado = "Recepcionado";
                }
                lista.Add(p);
            }
            GridView GridView1 = new GridView();
            GridView1.DataSource = lista;
            GridView1.DataBind();
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
            ExportToExcel("", GridView1);

        }

        private void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            la.Text = "<div align='center'>Informe Estado Guias</div><br/>";

            form.Controls.Add(la);
            form.Controls.Add(wControl);
            //Label l = new Label(); l.Text = "<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>";// +TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>";
            //form.Controls.Add(l);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=EstadoGuias.xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }
 
    }
}