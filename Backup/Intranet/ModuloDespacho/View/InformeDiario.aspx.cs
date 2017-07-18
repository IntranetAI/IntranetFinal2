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
    public partial class InformeDiario : System.Web.UI.Page
    {
        DespachoController controldes = new DespachoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrillaFecha_Filtro();
            }
        }
        public void CargarGrillaFecha_Filtro()
        {
            string fechaI = DateTime.Now.ToString("dd/MM/yyyy");
            string[] str = fechaI.Split('/');
            string dia = str[0];
            string mes = str[1];
            string año = str[2];
            año = año.Substring(0, 4);

            string fechaInicio = año + "-" + mes + "-" + dia;
            //fechas
            string fechaT = DateTime.Now.ToString("dd/MM/yyyy");
            string[] str2 = fechaT.Split('/');
            string dia2 = str2[0];
            string mes2 = str2[1];
            string año2 = str2[2];
            año2 = año2.Substring(0, 4);

            string fechaTermino = año2 + "-" + mes2 + "-" + dia2 +" 23:59:59";

            RadGrid1.DataSource = controldes.ListarDespacho_informePorOTAgrupada("","", fechaInicio, fechaTermino, 2);
            RadGrid1.DataBind();

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

                string fechaInicio = año + "-" + mes + "-" + dia;
                //fechas
                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);

                string fechaTermino = año2 + "-" + mes2 + "-" + dia2 +" 23:59:59";

                RadGrid1.DataSource = controldes.ListarDespacho_informePorOTAgrupada("", "",fechaInicio, fechaTermino, 2);
                RadGrid1.DataBind();

            }
            else
            {
                CargarGrillaFecha_Filtro();
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (chkDetalle.Checked == false)
            {
                List<Inf_Diario> lista = new List<Inf_Diario>();

                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {

                    Inf_Diario pro = new Inf_Diario();

                    pro.OT = RadGrid1.Items[i]["OT"].Text.ToUpper();
                    pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text.ToLower();
                    pro.Cliente = RadGrid1.Items[i]["Cliente"].Text.ToLower();
                    pro.FechaDespacho = RadGrid1.Items[i]["FechaMaxima"].Text;
                    pro.TirajeTotal = RadGrid1.Items[i]["TirajeTotal"].Text;
                    pro.TotalDespachado = RadGrid1.Items[i]["Despachado"].Text;




                    lista.Add(pro);
                }
                GridView GridView1 = new GridView();

                GridView1.DataSource = lista;
                GridView1.DataBind();

                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;




                string nombre = "InformePorOT" + DateTime.Now.ToShortDateString();


                ExportToExcel(nombre, GridView1);//GridView1);
            }
            else
            {
                //procedimiento detallado
                if (txtFechaInicio.Text != "")
                {
                    GridView GridView1 = new GridView();
                    string fechaI = txtFechaInicio.Text;
                    string[] str = fechaI.Split('/');
                    string dia = str[0];
                    string mes = str[1];
                    string año = str[2];
                    año = año.Substring(0, 4);

                    string fechaInicio = mes + "/" + dia + "/" + año + " 00:00:00";
                    //fechas
                    string fechaT = txtFechaTermino.Text;
                    string[] str2 = fechaT.Split('/');
                    string dia2 = str2[0];
                    string mes2 = str2[1];
                    string año2 = str2[2];
                    año2 = año2.Substring(0, 4);

                    string fechaTermino = mes2 + "/" + dia2 + "/" + año2 + " 23:59:59";

                    GridView1.DataSource = controldes.Listar_informeDiario_Detallado("", "", "", Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 0);
                    GridView1.DataBind();

                    GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                    GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;




                    string nombre = "InformePorOT" + DateTime.Now.ToShortDateString();


                    ExportToExcel(nombre, GridView1);//GridView1);

                }
                else
                {
                    string fechaI = DateTime.Now.ToString("dd/MM/yyyy");
                    string[] str = fechaI.Split('/');
                    string dia = str[0];
                    string mes = str[1];
                    string año = str[2];
                    año = año.Substring(0, 4);

                    string fechaInicio = mes + "/" + dia + "/" + año + " 00:00:00";
                    //fechas
                    string fechaT = DateTime.Now.ToString("dd/MM/yyyy");
                    string[] str2 = fechaT.Split('/');
                    string dia2 = str2[0];
                    string mes2 = str2[1];
                    string año2 = str2[2];
                    año2 = año2.Substring(0, 4);

                    string fechaTermino = mes2 + "/" + dia2 + "/" + año2 + " 23:59:59";
                    GridView GridView1 = new GridView();

                    GridView1.DataSource = controldes.Listar_informeDiario_Detallado("", "", "", Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 0);
                    GridView1.DataBind();

                    GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                    GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;




                    string nombre = "InformePorOT" + DateTime.Now.ToShortDateString();


                    ExportToExcel(nombre, GridView1);//GridView1);
                }
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

                la.Text = "<div align='center'>INFORME DIARIO</div>";
            
            form.Controls.Add(la);
            form.Controls.Add(wControl);
            //Label l = new Label(); l.Text = "<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>" + TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>";
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

        protected void ibPDF_Click(object sender, ImageClickEventArgs e)
        {
          
            if (chkDetalle.Checked == true)//detallado
            {
                
                string FI;
                string FT;
                if (txtFechaInicio.Text == "" || txtFechaTermino.Text == "")
                {
                    FI = "01/01/1900";
                    FT = "01/01/1900";
                }
                else
                {
                    FI = txtFechaInicio.Text + " 00:00:00";
                    FT = txtFechaTermino.Text + " 23:59:59";

                }

                Response.Redirect("PDFInformeDiario.aspx?OT=" + "" + "&NOT=" + "" + "&FI=" + FI + "&FT=" + FT + "");
            }
            else
            {
              
                string FI;
                string FT;
                if (txtFechaInicio.Text == "" || txtFechaTermino.Text == "")
                {
                    FI = "01/01/1900";
                    FT = "01/01/1900";
                }
                else
                {
                    FI = txtFechaInicio.Text + " 00:00:00";
                    FT = txtFechaTermino.Text + " 23:59:59";

                }

                Response.Redirect("PDFInformeDiarioAgrupado.aspx?OT=" + "" + "&NOT=" + "" + "&FI=" + FI + "&FT=" + FT + "");
            }
        }
        
    }
}