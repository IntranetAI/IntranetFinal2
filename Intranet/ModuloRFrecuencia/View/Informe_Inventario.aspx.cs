using Intranet.ModuloBobina.Controller;
using Intranet.ModuloBobina.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Informe_Inventario : System.Web.UI.Page
    {
        InventarioController ic = new InventarioController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();

                //ddlInventarios.DataSource = ic.Listado_Inventarios();
                //ddlInventarios.DataTextField = "Codigo";
                //ddlInventarios.DataValueField = "Codigo";
                //ddlInventarios.DataBind();

                //ddlInventarios.Items.Insert(0, new ListItem("Seleccione...", "0"));
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            //if (ddlInventarios.SelectedValue.ToString() != "0")
            //{
            //    RadGrid1.DataSource = ic.Listado_Codigos(Convert.ToInt32(ddlInventarios.SelectedValue.ToString()));
            //    RadGrid1.DataBind();
            //}
            if (txtNombreLista.Text != "")
            {
                RadGrid1.DataSource = ic.Listado_Codigos(txtNombreLista.Text);
                RadGrid1.DataBind();
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

            la.Text = "<div align='center'>Informe Inventario</div><div align='center'>";

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

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            List<Inventario_bobinas> lista = new List<Inventario_bobinas>();
            if (RadGrid1.Items.Count > 0 && txtNombreLista.Text!="")
            {
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    Inventario_bobinas p = new Inventario_bobinas();
                    p.Codigo = RadGrid1.Items[i]["Codigo"].Text;
                    p.SKU = RadGrid1.Items[i]["SKU"].Text;
                    p.Papel = RadGrid1.Items[i]["Papel"].Text;
                    p.Fecha = RadGrid1.Items[i]["Fecha"].Text;
                    p.Kilos= RadGrid1.Items[i]["Kilos"].Text;
                    p.Bodega= RadGrid1.Items[i]["Bodega"].Text;
                    p.Ubicacion= RadGrid1.Items[i]["Ubicacion"].Text;
                    lista.Add(p);
                }
                GridView GridView1 = new GridView();
                GridView1.DataSource = lista;
                GridView1.DataBind();
                ExportToExcel("Inventario_" + txtNombreLista.Text, GridView1);
            }
        }
    }
}