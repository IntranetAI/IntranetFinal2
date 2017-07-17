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
    public partial class InformeProductosTerminados : System.Web.UI.Page
    {
        Controller_InformeDespachos id = new Controller_InformeDespachos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DateTime fec = DateTime.Now.AddDays(-1);
                txtFechaInicio.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                txtFechaTermino.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");

                string[] str = txtFechaInicio.Text.Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                RadGrid1.DataSource = id.ListaDespachosEnc("", fi, ft, 2);
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtOT.Text != "")
            {
                DateTime fec = DateTime.Now.AddDays(-1);
                RadGrid1.DataSource = id.ListaDespachosEnc(txtOT.Text, fec, fec, 1);
                RadGrid1.DataBind();
                txtFechaInicio.Text = "";
                txtFechaTermino.Text = "";

            }
            else if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                RadGrid1.DataSource = id.ListaDespachosEnc("", fi, ft, 2);
                RadGrid1.DataBind();
            }
        }

        private void ExportToExcel(string nameReport, GridView wControl, string fechaInicio,string FechaTermino,string OT)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            if (txtFechaInicio.Text == "")
            {
                la.Text = "<div align='center'>INFORME DESPACHOS</div><div align='center'>OT :" + OT + " </div>";
            }
            else
            {
                la.Text = "<div align='center'>INFORME DESPACHOS</div><div align='center'>Desde " + fechaInicio + " hasta " + FechaTermino + "</div>";
            }
            form.Controls.Add(la);
            form.Controls.Add(wControl);
            //Label l = new Label(); l.Text = "<div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>" + TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Saldo:</td></tr></table></td><td><table  border='1'><tr><td>" + total.ToString("N0").Replace(",", ".") + "</td></tr></table></td></tr> </table>";//<tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr>
            ////<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>" + TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>
            //form.Controls.Add(l);
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

        protected void ibExcel_Click1(object sender, ImageClickEventArgs e)
        {
            if (RadGrid1.Items.Count > 0)
            {

                List<MProductosTerminados_Excel> lista = new List<MProductosTerminados_Excel>();

                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    MProductosTerminados_Excel pro = new MProductosTerminados_Excel();
                    pro.OT = RadGrid1.Items[i]["OT"].Text;
                    pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                    pro.Tiraje = RadGrid1.Items[i]["Tiraje"].Text.Replace(".", "");
                    pro.Despachado = RadGrid1.Items[i]["Despachado"].Text.Replace(".", "");
                    pro.Devolucion = RadGrid1.Items[i]["Devolucion"].Text.Replace("<div style='color:Red;'>", "").Replace("</div>","");
                    //pro.Saldo = RadGrid1.Items[i]["Saldo"].Text;
                    if (RadGrid1.Items[i]["Saldo"].Text.Contains("<div style='color:Green;'>"))//<div style='color:Green;'>
                    {
                        pro.Saldo = RadGrid1.Items[i]["Saldo"].Text.Replace("<div style='color:Green;'>", "").Replace("</div>", "");
                    }
                    else
                    {
                        int s = Convert.ToInt32(RadGrid1.Items[i]["Saldo"].Text.Replace("<div style='color:Red;'>", "").Replace("</div>", "").Replace(".", "")) * -1;
                        pro.Saldo = s.ToString();
                    }
                    pro.CantCajas = RadGrid1.Items[i]["CantCajas"].Text.Replace(".", "");

                    lista.Add(pro);
                }
                GridView GridView1 = new GridView();
                GridView1.DataSource = lista;
                GridView1.DataBind();
                //GridView1.HeaderRow.Cells[0].Text = "Nº OT";
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

                string nombre = "InformeDespachos" + DateTime.Now.ToShortDateString();


                ExportToExcel(nombre, GridView1, txtFechaInicio.Text, txtFechaTermino.Text, txtOT.Text);

            }

        }

    }
}