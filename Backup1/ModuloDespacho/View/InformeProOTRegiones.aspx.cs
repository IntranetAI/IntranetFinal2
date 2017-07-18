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
    public partial class InformeProOTRegiones : System.Web.UI.Page
    {
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
            DespachoController controldes = new DespachoController();
            string FechaInicio = "";
            string FechaTermino = "";
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] strn = txtFechaInicio.Text.Split('/');
                FechaInicio = strn[2] + "-" + strn[1] + "-" + strn[0];
                string[] strn1 = txtFechaTermino.Text.Split('/');
                FechaTermino = strn1[2] + "-" + strn1[1] + "-" + strn1[0];

            }
            RadGrid1.DataSource = controldes.ListarInformeOTxRegion(txtNumeroOT.Text, FechaInicio, FechaTermino);
            RadGrid1.DataBind();
            ibExcel.Visible = true;
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            List<GuiaDespacho_Detalle> lista = new List<GuiaDespacho_Detalle>();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {

                GuiaDespacho_Detalle pro = new GuiaDespacho_Detalle();

                pro.OT = RadGrid1.Items[i]["OT"].Text.ToUpper();
                pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text.ToLower();
                pro.Proveedor = RadGrid1.Items[i]["Proveedor"].Text;
                pro.Comuna = RadGrid1.Items[i]["Comuna"].Text;
                pro.Embalaje = RadGrid1.Items[i]["Embalaje"].Text;




                lista.Add(pro);
            }
            GridView GridView1 = new GridView();

            GridView1.DataSource = lista;
            GridView1.DataBind();

            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
            GridView1.HeaderRow.Cells[3].Text = "Nombre OT";
            GridView1.HeaderRow.Cells[4].Text = "Despachado";
            GridView1.HeaderRow.Cells[5].Text = "Guias RM";
            GridView1.HeaderRow.Cells[6].Text = "Guias Regiones";
            GridView1.HeaderRow.Cells[0].Visible = false;
            GridView1.HeaderRow.Cells[1].Visible = false;
            GridView1.HeaderRow.Cells[7].Visible = false;
            GridView1.HeaderRow.Cells[8].Visible = false;
            GridView1.HeaderRow.Cells[9].Visible = false;
            GridView1.HeaderRow.Cells[10].Visible = false;
            GridView1.HeaderRow.Cells[11].Visible = false;
            for (int contador = 0; contador < GridView1.Rows.Count; contador++)
            {
                GridViewRow row = GridView1.Rows[contador];
                row.Cells[0].Visible = false;
                row.Cells[1].Visible = false;
                row.Cells[7].Visible = false;
                row.Cells[8].Visible = false;
                row.Cells[9].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[11].Visible = false;
                row.Cells[5].Text = row.Cells[10].Text;
                row.Cells[6].Text = row.Cells[7].Text;
            }


            string nombre = "InformePorOT" + DateTime.Now.ToShortDateString();


            ExportToExcel(nombre, GridView1);
        }


        private void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            la.Text = "<div align='center'>INFORME OT - Region</div>";

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