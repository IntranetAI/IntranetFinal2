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
    public partial class InformeDevoluciones : System.Web.UI.Page
    {
        Controller_Devoluciones cd = new Controller_Devoluciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime f = Convert.ToDateTime("1900-01-01");
                RadGrid3.DataSource = cd.CargaInformeDevoluciones("", "", f, f, 0);
                RadGrid3.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('/');
                DateTime f1 = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");

                string[] str2 = txtFechaTermino.Text.Split('/');
                DateTime f2 = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                RadGrid3.DataSource = cd.CargaInformeDevoluciones(txtOP.Text, txtNombreOP.Text, f1, f2, 2);
                RadGrid3.DataBind();
            }
            else
            {
                DateTime fec = Convert.ToDateTime("1900-01-01");
                RadGrid3.DataSource = cd.CargaInformeDevoluciones(txtOP.Text, txtNombreOP.Text, fec, fec, 1);
                RadGrid3.DataBind();
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (RadGrid3.Items.Count != 0)
            {

                List<InfDevolucion> lista = new List<InfDevolucion>();

                for (int i = 0; i < RadGrid3.Items.Count; i++)
                {

                    InfDevolucion pro = new InfDevolucion();
                    if (RadGrid3.Items[i]["OT"].Text != "&nbsp;")
                    {
                    }
                    pro.Folio = RadGrid3.Items[i]["Folio"].Text;
                    pro.OT = RadGrid3.Items[i]["OT"].Text;
                    pro.NombreOT = RadGrid3.Items[i]["Producto"].Text;
                    pro.TirajeOT = RadGrid3.Items[i]["TirajeOT"].Text;
                    pro.CausaDevolucion = RadGrid3.Items[i]["CausaDevolucion"].Text;
                    pro.Total_Dev = RadGrid3.Items[i]["Total_Dev"].Text;
                    pro.CreadaPor = RadGrid3.Items[i]["CreadaPor"].Text;
                    pro.FechaCreacion = RadGrid3.Items[i]["FechaCreacion"].Text;
                    pro.TipoDevolucion = RadGrid3.Items[i]["id_TipoDev"].Text;
                    pro.Estado = RadGrid3.Items[i]["guia"].Text;

                    if (RadGrid3.Items[i]["guia"].Text == "<div style='Color:Red'>Creada</div>")
                    {
                        pro.Estado = "Creada";

                    }
                    else if (RadGrid3.Items[i]["guia"].Text == "<div style='Color:Green'>Recepcionada</div>")
                    {
                        pro.Estado = "Recepcionada";
                    }
                    else
                    {
                        pro.Estado = "Generada";
                    }

                    lista.Add(pro);
                }
                GridView GridView1 = new GridView();

                GridView1.DataSource = lista;
                GridView1.DataBind();

                GridView1.HeaderRow.Cells[5].Text = "Fecha Despacho";


                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;


                string nombre = "InformeDevoluciones" + DateTime.Now.ToShortDateString();


                ExportToExcel(nombre, GridView1);//GridView1);
                //                                                        Despachado.ToString("N0")


            }
        }
        private void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

                la.Text = "<div align='center'>INFORME DEVOLUCIONES</div><br/>";
            
            form.Controls.Add(la);
            form.Controls.Add(wControl);
          //  Label l = new Label(); l.Text = "<div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>" + TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Saldo:</td></tr></table></td><td><table  border='1'><tr><td>" + total.ToString("N0").Replace(",", ".") + "</td></tr></table></td></tr> </table>";//<tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr>
            //<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>" + TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>
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
    }
}