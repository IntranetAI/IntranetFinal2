using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using Telerik.Web.UI;
using Intranet.ModuloAdministracion.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Threading;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Proceso_Contable : System.Web.UI.Page
    {
        TipDocument_Controller controlTip = new TipDocument_Controller();
        Document_Controller controlDoc = new Document_Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipDoc();
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }

        public void CargarTipDoc()
        {
            ddlTipDoc.DataSource = controlTip.listaTipDoc();
            ddlTipDoc.DataTextField = "TipDoc";
            ddlTipDoc.DataValueField = "IDTipDoc";
            ddlTipDoc.DataBind();
            ddlTipDoc.Items.Insert(0, new ListItem("-Seleccione Tipo Documento-","-1"));
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            int IDTipoDocMercantil = Convert.ToInt32(ddlTipDoc.SelectedValue.ToString());
            RadGrid1.DataSource = controlDoc.ListarDocContable(IDTipoDocMercantil, txtFechaInicio.Text, txtFechaTermino.Text, 7);
            RadGrid1.DataBind();
            btnDetalle.Visible = true;
            btnEncabezado.Visible = true;
        }

        protected void Button1_Click()
        {
            Response.Write("<script>window.open('DetalleSolicitud.aspx','popup','width=800,height=500') </script>");
        }

        protected void btnEncabezado_Click(object sender, EventArgs e)
        {
            Boolean check = false;
            Document_Controller docControl = new Document_Controller();
            string listFolio = "";
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem row = RadGrid1.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {
                    int  Foli =Convert.ToInt32(row["FolioFactura"].Text);
                    listFolio = listFolio + Foli + ",";
                    check= true;
                }
            }
            if (check != false)
            {
                listFolio = listFolio.Substring(0, listFolio.Length - 1);
                List<Cabecera> lista = docControl.ExportacionExcel(listFolio, txtFechaInicio.Text, txtFechaTermino.Text);


                //GridView gv = new GridView();
                //gv.DataSource = lista;
                //gv.DataBind();
                //ExportToExcel("LcoCab", gv);
                btnExportCSV_Click(lista);
            }
            else
            {

            }
        }

        //private void ExportToExcel(string nameReport, GridView wControl)
        //{
        //    string style = @"<style> TD { mso-number-format:\@; } </style>";
        //    //string styl = @"<style> .text { mso-number-format:\@; } </style> ";
        //    HttpResponse response = Response;
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    Page pageToRender = new Page();
        //    HtmlForm form = new HtmlForm();

        //    form.Controls.Add(wControl);

        //    pageToRender.Controls.Add(form);
        //    response.Clear();
        //    response.Buffer = true;
        //    response.ContentType = "application/vnd.ms-excel";
        //    response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport + ".xls");
        //    Response.Write(style);
        //    response.Charset = "UTF-8";
        //    response.ContentEncoding = Encoding.Default;
        //    pageToRender.RenderControl(htw);
        //    response.Write(sw.ToString());
        //    response.End();

        //}

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            
            string factura = "";
            try
            {
                Boolean check = false;
                Document_Controller docControl = new Document_Controller();
                string listFolio = "";
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    GridDataItem row = RadGrid1.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        int Foli = Convert.ToInt32(row["IDDocMercantil"].Text);
                        factura = Foli.ToString();
                        listFolio = listFolio + Foli + ",";
                        check = true;
                    }
                }
                if (check != false)
                {
                    listFolio = listFolio.Substring(0, listFolio.Length - 1);
                    List<Detalle> lista = docControl.ListarExpExcelDet(listFolio);
                    //ExportToExcel("LcoDet", view);
                    btnExportCSV2_Click(lista, listFolio, txtFechaInicio.Text, txtFechaTermino.Text);
                    //GridView gv = new GridView();
                    //gv.DataSource = lista;
                    //gv.DataBind();
                    //ExportToExcel("LcoDet", gv);
                }
                else
                {

                }
            }catch(ThreadAbortException ex)
            {
                string a = factura;

            }
        }

        protected void btnExportCSV_Click(List<Cabecera> lista)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=LcoCab.txt");
            Response.Charset = "";
            Response.ContentType = "application/text";
            
            GridView1.DataSource = lista;
            GridView1.DataBind();

            StringBuilder sb = new StringBuilder();
            //for (int k = 0; k < GridView1.Columns.Count; k++)
            //{
            //    //add separator
            //    sb.Append(GridView1.Columns[k].HeaderText + ',');
            //}
            //append new line
            //sb.Append("\r\n");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                for (int k = 0; k < GridView1.Columns.Count; k++)//GridView1.Columns.Count
                {
                    //add separator
                    //try 
                    //{
                    //    DateTime fecha = Convert.ToDateTime(GridView1.Rows[i].Cells[k].Text);
                    //    string f = fecha.ToString("yyyy/MM/dd");
                    //    string[] str = f.Split('/');
                    //    sb.Append(str[0] + "/" + str[1] + "/" + str[2]);
                    //}
                    //catch
                    //{ agregar perido al ingresar si no existe
                    string a = GridView1.Rows[i].Cells[38].Text;
                    sb.Append(GridView1.Rows[i].Cells[k].Text);
                    //}
                }
                //append new line
                sb.Append("\r\n");
            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
            
        }

        protected void btnExportCSV2_Click(List<Detalle> lista, string lista2, string FechaInicio, string FechaTermino)
        {
            controlDoc.UpdateExport(lista2, FechaInicio, FechaTermino);
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=LcoDet.txt");
            Response.Charset = "";
            Response.ContentType = "application/text";

            GridView2.DataSource = lista;
            GridView2.DataBind();

            StringBuilder sb = new StringBuilder();
            //for (int k = 0; k < GridView2.Columns.Count; k++)
            //{
            //    //add separator
            //    sb.Append(GridView2.Columns[k].HeaderText + ',');
            //}
            ////append new line
            //sb.Append("\r\n");
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                for (int k = 0; k < GridView2.Columns.Count; k++)
                {
                    //add separator
                    //try
                    //{
                    //    DateTime fecha = Convert.ToDateTime(GridView2.Rows[i].Cells[k].Text);
                    //    string f = fecha.ToString("yyyy/MM/dd");
                    //    string[] str = f.Split('/');
                    //    sb.Append(str[0] + "/" + str[1] + "/" + str[2] + " ,");
                    //}
                    //catch
                    //{
                        sb.Append(GridView2.Rows[i].Cells[k].Text);
                    //}
                }
                //append new line
                sb.Append("\r\n");
            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
            
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;

                //Habilitar textbox segun el Checkbox
                CheckBox cbAccionado = (CheckBox)item.FindControl("chkSelect");

                if (item["NombreCuenta"].Text == "Pendiente")
                {
                    cbAccionado.Enabled = false;
                }
                else
                {
                    cbAccionado.Enabled = true;
                }

            }
        }
    }
}