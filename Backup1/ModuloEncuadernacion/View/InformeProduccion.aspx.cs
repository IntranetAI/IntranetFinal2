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
    public partial class InformeProduccion : System.Web.UI.Page
    {
        Controller_ProductosTerminados pt = new Controller_ProductosTerminados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime fec = Convert.ToDateTime("1900-01-01");
                RadGrid1.DataSource = "";// pt.CARGA_INFORMEPRODUCCIONENC("", "", fec, fec, 0);
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string FecI = txtFechaInicio.Text;
                string[] str = FecI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);
                string FechaInicio = mes + "/" + dia + "/" + año + " 00:00:00";

                string FecT = txtFechaTermino.Text;
                string[] str2 = FecT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);
                string FechaTermino = mes2 + "/" + dia2 + "/" + año2 + " 23:59:59";

                RadGrid1.DataSource = pt.CARGA_INFORMEPRODUCCIONENC(txtNumeroOT.Text, "", Convert.ToDateTime(FechaInicio), Convert.ToDateTime(FechaTermino), 1);
                RadGrid1.DataBind();
            }
            else
            {
                DateTime fec = Convert.ToDateTime("1900-01-01");
                RadGrid1.DataSource = pt.CARGA_INFORMEPRODUCCIONENC(txtNumeroOT.Text, "", fec, fec, 2);
                RadGrid1.DataBind();
            }

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (RadGrid1.Items.Count > 0)
            {

                List<PRODUCCIONENC> lista = new List<PRODUCCIONENC>();

                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {

                    PRODUCCIONENC pro = new PRODUCCIONENC();

                    if (RadGrid1.Items[i]["OT"].Text == "&nbsp;")
                    {
                        pro.OT = "";
                    }
                    else
                    {
                        pro.OT = RadGrid1.Items[i]["OT"].Text;
                    }
                    if (RadGrid1.Items[i]["NOMBREOT"].Text == "&nbsp;")
                    {
                        pro.NOMBREOT = "";
                    }
                    else
                    {
                        pro.NOMBREOT = RadGrid1.Items[i]["NOMBREOT"].Text;
                    }
                    pro.PLIEGO = RadGrid1.Items[i]["PLIEGO"].Text;

                    if (RadGrid1.Items[i]["FORMA"].Text == "&nbsp;")
                    {
                        pro.FORMA = "";
                    }
                    else
                    {
                        pro.FORMA = RadGrid1.Items[i]["FORMA"].Text;
                    }



                    pro.MAQUINA = RadGrid1.Items[i]["MAQUINA"].Text;
                    pro.BUENOS = RadGrid1.Items[i]["BUENOS"].Text;
                    pro.FECHAINICIO = RadGrid1.Items[i]["FECHAINICIO"].Text;
                    pro.FECHATERMINO = RadGrid1.Items[i]["FECHATERMINO"].Text;
                    pro.OPERACION = RadGrid1.Items[i]["Operacion"].Text;


                    lista.Add(pro);
                }
                GridView GridView1 = new GridView();


                GridView1.DataSource = lista;
                GridView1.DataBind();
                //GridView1.HeaderRow.Cells[0].Text = "Nº OT";
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                int contador = 0;
                //for (contador = 0; contador < GridView1.Rows.Count; contador++)
                //{
                //    GridViewRow row = GridView1.Rows[contador];
                //    NombreOT = row.Cells[3].Text;
                //    string numero = row.Cells[7].Text;



                //    ttd = ttd + Convert.ToInt32(row.Cells[7].Text.Replace(".", ""));




                //}
                string nombre = "InformeProduccionEncuadernacion_" + DateTime.Now.ToString("dd/MM/yyyy");
                ExportToExcel(nombre, GridView1);
            }
            else
            {
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
            la.Text = "<div align='center'>" + nameReport + "</div><br/>";
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