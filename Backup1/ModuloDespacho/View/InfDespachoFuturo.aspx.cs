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
using Intranet.ModuloProduccion.Controller;
using Telerik.Web.UI;
using Intranet.ModuloUsuario.Controller;
using System.Web.Services;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloUsuario.Model;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;

namespace Intranet.ModuloDespacho.View
{
    public partial class InfDespachoFuturo : System.Web.UI.Page
    {
        DespachoController controlDes = new DespachoController();
        ProduccionController controlpro = new ProduccionController();
        public static List<Archivo> arch = new List<Archivo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime v1 = DateTime.Now;
                txtFechaInicio.Text = v1.ToString("dd/MM/yyyy");
                txtFechaTermino.Text = v1.ToString("dd/MM/yyyy");
                CargarDatos();
            }
        }
        public void CargarDatos()
        {
            string fechaI = txtFechaInicio.Text;
            string[] str = fechaI.Split('/');
            string dia = str[0];
            string mes = str[1];
            string año = str[2];
            año = año.Substring(0, 4);

            string fechaInicio = año + "-" + mes + "-" + dia;
            string fechaT = txtFechaTermino.Text;
            string[] str2 = fechaT.Split('/');
            string dia2 = str2[0];
            string mes2 = str2[1];
            string año2 = str2[2];
            año2 = año2.Substring(0, 4);

            string fechaTermino = año2 + "-" + mes2 + "-" + dia2;

            if (fechaInicio == fechaTermino)
            {
                fechaInicio = fechaInicio + " 00:00:00";
                fechaTermino = fechaTermino + " 23:59:59";
            }
            RadGrid1.DataSource = controlDes.sp_ListarFuturos_Mostrar("", "", "", fechaInicio, fechaTermino, 0);
            RadGrid1.DataBind();

        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text== "" && txtFechaTermino.Text== "")
            {
                CargarDatos();
            }
            else
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                string fechaInicio = año + "-" + mes + "-" + dia;
                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);

                string fechaTermino = año2 + "-" + mes2 + "-" + dia2;

                if (fechaInicio == fechaTermino)
                {
                    fechaInicio = fechaInicio + " 00:00:00";
                    fechaTermino = fechaTermino + " 23:59:59";
                }

                RadGrid1.DataSource = controlDes.sp_ListarFuturos_Mostrar(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, fechaInicio, fechaTermino, 1);
                RadGrid1.DataBind();
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            txtFechaInicio.Text = "";
            txtFechaTermino.Text = "";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibExportacionExcel_Click(object sender, ImageClickEventArgs e)
        {

            List<Inf_DespFuturos> lista = new List<Inf_DespFuturos>();

            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {

                Inf_DespFuturos pro = new Inf_DespFuturos();

                pro.OT = RadGrid1.Items[i]["OT"].Text.ToUpper();
                pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text.ToLower();
                pro.Cliente = RadGrid1.Items[i]["Cliente"].Text.ToLower();
                pro.Tiraje = RadGrid1.Items[i]["Cant"].Text.Replace(",", ".");
                pro.CantADespachar = RadGrid1.Items[i]["TirajeGenerado"].Text.Replace(",", ".");
                pro.CantDespachada = RadGrid1.Items[i]["TirajeAcumulado"].Text.Replace(",", ".");
                pro.TotalDespachado = RadGrid1.Items[i]["Fechafalsa"].Text.Replace(",", ".");
                pro.FechaEntrega = RadGrid1.Items[i]["FechaDes"].Text;

                if (RadGrid1.Items[i]["Cant"].Text.Replace(".", "") != "0")
                {

                    int td = Convert.ToInt32(RadGrid1.Items[i]["TirajeAcumulado"].Text.Replace(".", ""));
                    int cd = Convert.ToInt32(RadGrid1.Items[i]["TirajeGenerado"].Text.Replace(".", ""));
                    int total = ((td * 100) / cd);

                    if (total > 100)
                    {
                        pro.Despachada = "100%";
                    }
                    else
                    {
                        pro.Despachada = total.ToString() + "%";
                    }
                }
                else
                {
                    pro.Despachada = "0%";
                }



                lista.Add(pro);
            }
            GridView GridView1 = new GridView();

            GridView1.DataSource = lista;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "N°OT";
            GridView1.HeaderRow.Cells[1].Text = "Nombre OT";
            GridView1.HeaderRow.Cells[2].Text = "Cliente";
            GridView1.HeaderRow.Cells[3].Text = "Tiraje";
            GridView1.HeaderRow.Cells[4].Text = "Cant. a Despachar";
            GridView1.HeaderRow.Cells[5].Text = "Cant. Desp.";
            GridView1.HeaderRow.Cells[6].Text = "Total Desp.";
            GridView1.HeaderRow.Cells[7].Text = "Fecha Entrega";
            GridView1.HeaderRow.Cells[8].Text = "Despachada";
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;


            string nombre = "Informe de Despacho Futuros" + DateTime.Now.ToShortDateString();

            ExportToExcel(nombre, GridView1);//GridView1);
            
            
        }

        private void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

                la.Text = "<div align='center'>INFORME DESPACHOS FUTUROS</div><br/>";
            
            form.Controls.Add(la);
            form.Controls.Add(wControl);
            //Label l = new Label(); l.Text = "<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>";// +TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>";
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

        protected void ibExportacionPDF_Click(object sender, ImageClickEventArgs e)
        {
            string OT = txtNumeroOT.Text.Trim();
            string NombreOT = txtNombreOT.Text.Trim();
            string Cliente = txtCliente.Text.Trim();
            string FeInicio = txtFechaInicio.Text.Trim();
            string FeTermino = txtFechaTermino.Text.Trim();

            Response.Redirect("PDFDespachoFuturos.aspx?OT=" + OT + "&NombreOT=" + NombreOT + "&Cliente=" + Cliente + "&FeInicio=" + FeInicio + "&FeTermino="+FeTermino);
        }

        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "RowClick")
            {
                GridDataItem item = (GridDataItem)e.Item;
                string OT = item["OT"].Text;
                string popupScript = "<script language='JavaScript'>DetalleOT(" + OT + ");</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);

            }
        }

    }
}