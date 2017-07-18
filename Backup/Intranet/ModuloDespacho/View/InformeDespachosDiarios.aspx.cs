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
    public partial class InformeDespachosDiarios : System.Web.UI.Page
    {
        DespachoController dc = new DespachoController();
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
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                string fechaInicio = mes + "/" + dia + "/" + año + " 00:00:00"; 
                //fechaTermino
                string fechaT= txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);

                string fechaTermino = mes2 + "/" + dia2 + "/" + año2 + " 23:59:59";


                if (ddlEstado.SelectedValue.ToString() == "Todos")
                {
                    RadGrid1.DataSource = dc.ListaDespachosLiquidarOT(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 0, 0);
                    RadGrid1.DataBind();
                }
                else
                {
                    RadGrid1.DataSource = dc.ListaDespachosLiquidarOT(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), Convert.ToInt32(ddlEstado.SelectedValue.ToString()), 2);
                    RadGrid1.DataBind();
                }



                ibExcel.Visible = true;
                lblExcel.Visible = true;





            }
            else
            {
                //ERROR
                ibExcel.Visible = false;
                lblExcel.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        private void ExportToExcel(string nameReport, GridView wControl, string Titulo)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

                la.Text = "<div align='center'>INFORME GUIAS DE DESPACHOS</div><br/>";
            
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

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {

            List<DespachoLiquidar> lista = new List<DespachoLiquidar>();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {

                DespachoLiquidar pro = new DespachoLiquidar();

                pro.Guias = RadGrid1.Items[i]["Guias"].Text;
               
                pro.FechaDespacho = RadGrid1.Items[i]["FechaDespacho"].Text;

                if (RadGrid1.Items[i]["Estado"].Text == "<div style='Color:Green;'>Vigente</div>")
                {
                    pro.Estado = "Vigente";
                }
                else
                {
                    pro.Estado = "Anulado";
                }
                if (RadGrid1.Items[i]["OT"].Text == "&nbsp;")
                {
                    pro.OT = "";
                }
                else
                {
                    pro.OT = RadGrid1.Items[i]["OT"].Text;
                }


                if (RadGrid1.Items[i]["NombreOT"].Text == "&nbsp;")
                {
                    pro.NombreOT = "";
                }
                else
                {
                    pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                }

                if (RadGrid1.Items[i]["Cliente"].Text == "&nbsp;")
                {
                    pro.Cliente = "";
                }
                else
                {
                    pro.Cliente = RadGrid1.Items[i]["Cliente"].Text;
                }







                
                

                lista.Add(pro);
            }
            GridView GridView1 = new GridView();

            GridView1.DataSource = lista;
            GridView1.DataBind();
            //GridView1.HeaderRow.Cells[0].Text = "Nº OT";
            //GridView1.HeaderRow.Cells[1].Text = "Nº Guia";
            //GridView1.HeaderRow.Cells[2].Text = "Nombre OT";
            //GridView1.HeaderRow.Cells[5].Text = "Fecha Despacho";
            //GridView1.HeaderRow.Cells[5].Text = "Tiraje Total";
            //GridView1.HeaderRow.Cells[6].Text = "Total Despachado";

            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;

            string nombre = "InformeGuiasdeDespacho";

                ExportToExcel(nombre, GridView1,"");//GridView1);

        }
    }
}