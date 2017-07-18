using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloComercial.Controller;
using Telerik.Web.UI;
using Intranet.ModuloComercial.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloComercial.View
{
    public partial class Mantenedor_Presupuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"].ToString() == "j.venegas" || Session["Usuario"].ToString() == "aherrera")
                {
                    Presupuesto_Controller controlPresu = new Presupuesto_Controller();
                    RadGridPapeles.DataSource = controlPresu.Listar_Papeles();
                    RadGridPapeles.DataBind();
                    RadGridValorQ.DataSource = controlPresu.Listar_valorTrimestre();
                    RadGridValorQ.DataBind();
                }
                else
                {
                    Response.Redirect("../../ModuloProduccion/view/EstadoOT.aspx?id=1");
                }
            }
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                Presupuesto_Controller controlPres = new Presupuesto_Controller();
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = (GridDataItem)e.Item;
                    Papeles papel = new Papeles();
                    string aaaa = dataItem["ID_Papel"].Text;
                    papel.ID_Papel = Convert.ToInt32(dataItem["ID_Papel"].Text);
                    papel.Marca = dataItem["Marca"].Text; ;
                    papel.NombrePapel = dataItem["NombrePapel"].Text;
                    papel.Origen = dataItem["Origen"].Text;
                    papel.Gramaje = Convert.ToInt32(((TextBox)dataItem.FindControl("txtGramaje")).Text);
                    papel.Presentacion = ((TextBox)dataItem.FindControl("txtPresentacion")).Text;
                    papel.CostoPapelTonelada = Convert.ToInt32(((TextBox)dataItem.FindControl("txtCostoPapelTonelada")).Text);
                    papel.GastoBodega = Convert.ToInt32(((TextBox)dataItem.FindControl("txtGastoBodega")).Text);
                    papel.Componente = ((TextBox)dataItem.FindControl("txtComponente")).Text;
                    papel.TipoPapel = dataItem["TipoPapel"].Text;
                    if (papel.TipoPapel == "Cartulina" || papel.TipoPapel == "Hi Brite")
                    {
                        papel.GastoImportacion = 0;
                    }
                    else
                    {
                        papel.GastoImportacion = Convert.ToDouble(Convert.ToDouble(papel.CostoPapelTonelada) * Convert.ToDouble(0.01));
                    }
                    papel.CostoCIFUS = papel.CostoPapelTonelada + papel.GastoBodega + papel.GastoImportacion;
                    papel.BodegaSeguro = Convert.ToDouble(papel.CostoCIFUS * Convert.ToDouble(0.05));
                    papel.Obsolencia = Convert.ToDouble(papel.CostoCIFUS * Convert.ToDouble(0.12));
                    if (papel.Presentacion == "Bobina")
                    {
                        papel.CortePliego = 0;
                    }
                    else
                    {
                        papel.CortePliego = Convert.ToDouble(papel.CostoCIFUS * Convert.ToDouble(0.07));
                    }
                    papel.ValorBase = papel.CostoCIFUS + papel.BodegaSeguro + papel.Obsolencia + papel.CortePliego;
                    papel.ValorTrimestre = Convert.ToDouble(dataItem["ValorTrimestre"].Text);
                    if (papel.TipoPapel == "Cartulina" || papel.TipoPapel == "Hi Brite")
                    {
                        papel.FacturaCL = Convert.ToDouble(papel.ValorBase / 1000);
                    }
                    else
                    {
                        papel.FacturaCL = Convert.ToDouble(papel.ValorBase / 1000) * papel.ValorTrimestre;
                    }
                    papel.InferiorCL = Convert.ToDouble(papel.FacturaCL * 0.95);
                    papel.SuperiorCL = Convert.ToDouble(papel.FacturaCL * 1.05);
                    papel.Empresas = dataItem["Empresas"].Text;
                    papel.Usuario = Session["Usuario"].ToString();
                    try
                    {
                        if (controlPres.InsertCambioCostoPapeles(papel))
                        {
                            RadGridPapeles.DataSource = controlPres.Listar_Papeles();
                            RadGridPapeles.DataBind();
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error, vuelva a intentarlo');  </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                    }
                    catch
                    {
                        string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error, vuelva a intentarlo');  </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }


                }
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Presupuesto_Controller controlPresu = new Presupuesto_Controller();
                List<Papeles_Export> lista = controlPresu.lista_ExportarExcel();
                GridView GridView1 = new GridView();
                GridView1.DataSource = lista;
                GridView1.DataBind();
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                //System.Drawing.Font font = new System.Drawing.Font("Calibri", 9.0f);
                GridView1.HeaderStyle.Font.Name = "Calibri";
                GridView1.HeaderStyle.Font.Size = 9;
                GridView1.HeaderRow.Cells[0].Text = "Tipo de Papel";
                GridView1.HeaderRow.Cells[2].Text = "Nombre papel";
                GridView1.HeaderRow.Cells[4].Text = "Gramaje (gr/m2)";
                GridView1.HeaderRow.Cells[5].Text = "Presentación";
                GridView1.HeaderRow.Cells[6].Text = "Costo Papel según Factura (Tonelada)";
                GridView1.HeaderRow.Cells[7].Text = "Gastos hasta Bodega";
                GridView1.HeaderRow.Cells[8].Text = "Gastos Importación";
                GridView1.HeaderRow.Cells[9].Text = "Costo CIF Papel";
                GridView1.HeaderRow.Cells[10].Text = "Bodegaje, Seguros y Otros";
                GridView1.HeaderRow.Cells[11].Text = "Obsolecencia & Margen";
                GridView1.HeaderRow.Cells[12].Text = "Corte Pliegos";
                GridView1.HeaderRow.Cells[13].Text = "Valor Base";
                GridView1.HeaderRow.Cells[14].Text = "Banda Valor Factura papel en Ch$ x Kg";
                GridView1.HeaderRow.Cells[14].ColumnSpan = 3;
                GridView1.HeaderRow.Cells[15].Visible = false;
                GridView1.HeaderRow.Cells[16].Visible = false;
                GridView1.HeaderRow.Cells[17].Visible = false;
                GridView1.HeaderRow.Cells[18].Visible = false;
                GridView1.HeaderRow.Cells[19].Visible = false;
                GridView1.HeaderRow.Cells[20].Visible = false;
                GridView1.HeaderRow.Cells[21].Visible = false;
                GridView1.HeaderRow.Cells[22].Visible = false;
                GridView1.HeaderRow.Cells[0].RowSpan = 2;
                GridView1.HeaderRow.Cells[1].RowSpan = 2;
                GridView1.HeaderRow.Cells[2].RowSpan = 2;
                GridView1.HeaderRow.Cells[3].RowSpan = 2;
                GridView1.HeaderRow.Cells[5].RowSpan = 2;
                GridView1.HeaderRow.Cells[13].RowSpan = 2;
                GridView1.HeaderRow.Cells[4].RowSpan = 2;
                GridView1.HeaderRow.Cells[4].Width = 70;
                GridView1.HeaderRow.Cells[6].RowSpan = 2;
                GridView1.HeaderRow.Cells[6].Width = 90;
                GridView1.HeaderRow.Cells[7].RowSpan = 2;
                GridView1.HeaderRow.Cells[7].Width = 90;
                GridView1.HeaderRow.Cells[8].Width = 90;
                GridView1.HeaderRow.Cells[8].Font.Size = 8;
                GridView1.HeaderRow.Cells[9].RowSpan = 2;
                GridView1.HeaderRow.Cells[9].Width = 90;
                GridView1.HeaderRow.Cells[10].Width = 90;
                GridView1.HeaderRow.Cells[10].Font.Size = 8;
                GridView1.HeaderRow.Cells[11].Width = 90;
                GridView1.HeaderRow.Cells[12].Width = 90;
                string ValorTrimestre = "0";
                
                for (int contador = 0; contador < GridView1.Rows.Count; contador++)
                {
                    GridViewRow row = GridView1.Rows[contador];
                    if (contador == 0)
                    {
                        row.Font.Size = 9;
                        row.Font.Bold = true;
                        row.Cells[0].Text = "1.0%";
                        row.Cells[1].Text = "5.0%";
                        row.Cells[2].Text = "12.0%";
                        row.Cells[3].Text = "7.0%";
                        row.Cells[4].Text = "Inferior";
                        row.Cells[5].Text = "Factura";
                        row.Cells[6].Text = "Superior";
                        row.Cells[7].Visible = false;
                        row.Cells[8].Visible = false;
                        row.Cells[9].Visible = false;
                        row.Cells[10].Visible = false;
                        row.Cells[11].Visible = false;
                        row.Cells[12].Visible = false;
                        row.Cells[13].Visible = false;
                        row.Cells[14].Visible = false;
                        row.Cells[15].Visible = false;
                        row.Cells[16].Visible = false;

                    }
                    ValorTrimestre = row.Cells[22].Text;
                    row.Cells[17].Visible = false;
                    row.Cells[18].Visible = false;
                    row.Cells[19].Visible = false;
                    row.Cells[20].Visible = false;
                    row.Cells[21].Visible = false;
                    row.Cells[22].Visible = false;
                }

                ExportToExcel("Informe Papeles", GridView1, ValorTrimestre);

            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('Ha Ocurrido un error al exportar a Excel'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        private void ExportToExcel(string nameReport, GridView wControl, string ValorTrimestre)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();

            HtmlForm form = new HtmlForm();

            Label la = new Label();

            la.Text = "<div align='center'>Precio Papel</div><br />1) Abastecimiento del papel a través de Importación Directa <br /><br />" +
                "El abastecimiento de papel de importacion directa será realizado a partir del Programa Editorial informado por las empresas del grupo Falabella.<br />"+
                "Las especificaciones del papel podrán ser modificadas en cualquier momento de la vigencia del contrato, luego de consumir las existencias de papel importadas para atender el programa editorial informado previamente,<br />"+
                "Para la importación directa del papel se requiere contar con la información con una anticipación mínima de 90 a 120 días, <br />"+
                "El valor del papel será determinado a partir del valor de la factura cancelada al proveedor y se determianará como sigue:<br /><br />";
            form.Controls.Add(la);
            form.Controls.Add(wControl);

            Label valorTriMensaje = new Label();
            Label valorTriValor = new Label();
            Label valorTriVigencia = new Label();
            valorTriMensaje.Text = "<br/><table><tr><td>Dólar Observado:</td><td>" + ValorTrimestre + "</td><td colspan='4'>vigente entre el 01 de Septiembre y el 31 de Diciembre de 2016</td></tr></table>";
            
            form.Controls.Add(valorTriMensaje);
            
            pageToRender.Controls.Add(form);

            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport + ".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            response.Write(style);

            response.End();
        }
    }
}