using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCompras(0);
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            CargarCompras(1);
        }

        public void CargarCompras(int procedimiento)
        {
            Controller_Compras controlCompra = new Controller_Compras();
            string NroPedido = txtPedido.Text.Trim();
            string CodItem = txtCodItem.Text.Trim();
            string Proveedor = txtProveedor.Text.Trim();
            string Estado = ddlEstado.SelectedValue;
            string FechaInicio = "";
            string FechaTermino = "";
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('-');
                FechaInicio = str[2] +"-"+ str[1] + "-" + str[0];
                string[] str2 = txtFechaTermino.Text.Split('-');
                FechaTermino = str2[2] + "/" + str2[1] + "/" + str2[0];
                procedimiento = 2;
            }
            RadGridCompras.DataSource = controlCompra.ListarCompras(procedimiento, NroPedido, CodItem, Proveedor, FechaInicio, FechaTermino, Estado);
            RadGridCompras.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Controller_Compras controlCompra = new Controller_Compras();
            string NroPedido = txtPedido.Text.Trim();
            string CodItem = txtCodItem.Text.Trim();
            string Proveedor = txtProveedor.Text.Trim();
            string Estado = ddlEstado.SelectedValue;
            string FechaInicio = "";
            string FechaTermino = "";
            int procedimiento= 1;
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string[] str = txtFechaInicio.Text.Split('-');
                FechaInicio = str[2] + "-" + str[1] + "-" + str[0];
                string[] str2 = txtFechaTermino.Text.Split('-');
                FechaTermino = str2[2] + "/" + str2[1] + "/" + str2[0];
                procedimiento = 2;
            }
            else
            {
                procedimiento = 1;
            }
            #region Grilla
            GridView Grilla = new GridView();
            Grilla.DataSource = controlCompra.ListarCompras(procedimiento, NroPedido, CodItem, Proveedor, FechaInicio, FechaTermino, Estado);
            Grilla.DataBind();
            Grilla.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            Grilla.HeaderStyle.ForeColor = System.Drawing.Color.White;

            Grilla.HeaderRow.Cells[0].Text = "Cod Item";
            Grilla.HeaderRow.Cells[1].Text = "Descripción";
            Grilla.HeaderRow.Cells[2].Text = "Proveedor";
            Grilla.HeaderRow.Cells[3].Text = "Cantidad Solicitada";
            Grilla.HeaderRow.Cells[4].Text = "Cantidad Recepcionada";
            Grilla.HeaderRow.Cells[5].Text = "Valor Unitario";
            Grilla.HeaderRow.Cells[6].Text = "Total";
            Grilla.HeaderRow.Cells[7].Text = "Fecha Entrega";
            Grilla.HeaderRow.Cells[8].Text = "Estado";
            Grilla.HeaderRow.Cells[9].Text = "Nro. Pedido";
            Grilla.HeaderRow.Cells[10].Text = "Termino Pago";
            Grilla.HeaderRow.Cells[11].Visible = false;
            Grilla.HeaderRow.Cells[12].Visible = false;
            Grilla.HeaderRow.Cells[13].Visible = false;
            Grilla.HeaderRow.Cells[14].Visible = false;
            Grilla.HeaderRow.Cells[15].Visible = false;
            Grilla.HeaderRow.Cells[16].Visible = false;

            for (int contador = 0; contador < Grilla.Rows.Count; contador++)
            {
                GridViewRow row = Grilla.Rows[contador];

                row.Cells[4].Text = row.Cells[9].Text;
                row.Cells[9].Text = row.Cells[0].Text;
                row.Cells[0].Text = row.Cells[6].Text;
                row.Cells[1].Text = row.Cells[7].Text;
                row.Cells[10].Text = row.Cells[2].Text;
                row.Cells[2].Text = row.Cells[14].Text;
                row.Cells[3].Text = row.Cells[8].Text;
                row.Cells[7].Text = row.Cells[5].Text;
                row.Cells[5].Text = row.Cells[16].Text;
                row.Cells[6].Text = row.Cells[12].Text;
                row.Cells[8].Text = row.Cells[15].Text;
                
                row.Cells[11].Visible = false;
                row.Cells[12].Visible = false;
                row.Cells[13].Visible = false;
                row.Cells[14].Visible = false;
                row.Cells[15].Visible = false;
                row.Cells[16].Visible = false;
            }
            #endregion
            ExportToExcel("Informe Compra " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), Grilla, NroPedido, CodItem, Proveedor, Estado, FechaInicio, FechaTermino);
        }

        private void ExportToExcel(string nameReport, GridView wControl, string NroPedido, string CodItem, string Proveedor, string Estado, string FechaInicio, string FechaTermino)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe Compra<br/>";
            if (NroPedido != "") { Titulo = Titulo + "Nro. Pedido : " + NroPedido; }
            if (CodItem != "") { Titulo = Titulo + " Cod Item : " + CodItem; }
            if (Proveedor != "") { Titulo = Titulo + " Proveedor :" + Proveedor; }
            if (Estado != "") { Titulo = Titulo + " Estado : " + Estado; }
            if (FechaInicio != "") { Titulo = Titulo + " Fecha Inicio : " + FechaInicio; }
            if (FechaTermino != "") { Titulo = Titulo + " Fecha Termino : " + FechaTermino; }
            la.Text = Titulo + "</div><br />";

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