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
using Telerik.Web.UI;

namespace Intranet.ModuloDespacho.View
{
    public partial class EstadosOT : System.Web.UI.Page
    {
        Controller_EstadoOT des = new Controller_EstadoOT();
        bool resp = true;
        bool re = true;
        bool respuesta = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
            
        }
        public void CargarGrilla()
        {
            DateTime fec = DateTime.Now;
            RadGrid1.DataSource = des.ListarEstadoOT("", "", "", fec, fec, "A", 1);
            RadGrid1.DataBind();
        }
        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            RefrescarGrilla();

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<EstadoOT_Mejora> lista = new List<EstadoOT_Mejora>();

                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    EstadoOT_Mejora pro = new EstadoOT_Mejora();
                    pro.OT = RadGrid1.Items[i]["OT"].Text;
                    pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
                    pro.Tiraje = RadGrid1.Items[i]["Tiraje"].Text.Replace(".","");
                    pro.FechaMinima = RadGrid1.Items[i]["FechaMinima"].Text.Replace("<div align='center'>", "").Replace("</div>", "");
                    pro.FechaMaxima = RadGrid1.Items[i]["FechaMaxima"].Text.Replace("<div align='center'>", "").Replace("</div>", "");
                    pro.Recepcionado = RadGrid1.Items[i]["Recepcionado"].Text.Replace(".", "");
                    pro.Despachado = RadGrid1.Items[i]["Despachado"].Text.Replace(".", "");
                    pro.Especiales = RadGrid1.Items[i]["Especiales"].Text.Replace(".", "");
                    pro.Existencia = RadGrid1.Items[i]["Existencia"].Text.Replace("<div style='color:Red;'>", "").Replace("</div>", "").Replace(".", "");
                    pro.DevolucionCliente = RadGrid1.Items[i]["DevolucionCliente"].Text.Replace(".", "");
                    pro.Saldo = RadGrid1.Items[i]["Saldo"].Text.Replace("<div style='color:Red;'>", "").Replace("</div>", "").Replace(".", "");

                    if (RadGrid1.Items[i]["Estado"].Text == "<div style='Color:Red;'><a style='Color:Red;text-decoration:none;' href='LiquidarOT.aspx?id=8&Cat=6&va=" + pro.OT + "'>Por Liquidar</a></div>")
                    {
                        pro.Estado = "Por Liquidar";
                    }
                    else if (RadGrid1.Items[i]["Estado"].Text == "<div style='Color:Green;'><a style='Color:Green;text-decoration:none;' href='LiquidarOT.aspx?id=8&Cat=6&va=" + pro.OT + "'>Liquidada</a></div>")
                    {
                        pro.Estado = "Liquidada";
                    }
                    else if (RadGrid1.Items[i]["Estado"].Text == "<div style='Color:Blue;'><a style='Color:Blue;text-decoration:none;' href='LiquidarOT.aspx?id=8&Cat=6&va=" + pro.OT + "'>En Proceso</a></div>")
                    {
                        pro.Estado = "En Proceso";
                    }
                    lista.Add(pro);
                }
                GridView GridView1 = new GridView();
                GridView1.DataSource = lista;
                GridView1.DataBind();
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.DarkGray;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                GridView1.HeaderRow.Cells[1].Text = "Nombre OT";
                GridView1.HeaderRow.Cells[2].Text = "Primer Despacho";
                GridView1.HeaderRow.Cells[3].Text = "Ultimo Despacho";
                GridView1.HeaderRow.Cells[4].Text = "Tiraje OT";
                GridView1.HeaderRow.Cells[5].Text = "Total Recepcionado";
                GridView1.HeaderRow.Cells[6].Text = "Total Despachado";
                GridView1.HeaderRow.Cells[7].Text = "Devoluciones";
                GridView1.HeaderRow.Cells[8].Text = "Especiales";
                GridView1.HeaderRow.Cells[9].Text = "SaldoEnc";

                GridView1.HeaderRow.Cells[12].Visible = false;
                GridView1.HeaderRow.Cells[13].Visible = false;


                int contador = 0;
                for (contador = 0; contador < GridView1.Rows.Count; contador++)
                {
                    GridViewRow row = GridView1.Rows[contador];
                    //row.Cells[10].Visible = false;
                    row.Cells[12].Visible = false;
                    row.Cells[13].Visible = false;
                }


                string nombre = "Estados_OT_" + DateTime.Now.ToShortDateString();

                if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                {
                    ExportToExcel(nombre, GridView1, "");//GridView1);
                }
                else
                {
                    ExportToExcel(nombre, GridView1, "");//GridView1);
                }
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('ha Ocurrido un error, vuelva a intentarlo');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }

        private void ExportToExcel(string nameReport, GridView wControl, string Titulo)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();
                la.Text = "<div align='center'>INFORME ESTADO OT DESPACHO<br/> </div><br/>";
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

        protected void btnLiquidar_Click(object sender, ImageClickEventArgs e)
        {
            int contadorLiquidar = 0;
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem row = RadGrid1.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {
                    if (row["Estado"].Text == "<div style='Color:Red;'><a style='Color:Red;text-decoration:none;' href='LiquidarOT.aspx?id=8&va=" + row["OT"].Text + "'>Por Liquidar</a></div>")
                    { 
                        contadorLiquidar++;
                        respuesta = des.CambiarEstadoOT(row["OT"].Text, 2);
                        resp = des.CambiarEstadoOT_Local(row["OT"].Text, 2);
                        re = des.Historial_Liquidadas(row["OT"].Text.ToUpper(), row["NombreOT"].Text, row["Cliente"].Text, Convert.ToInt32(row["TirajeTotal"].Text.Replace(".", "")), 2, "", Session["Usuario"].ToString());//no lleva observacion
                    }
                }
            }
            Label7.Text = "Se han Liquidado " + contadorLiquidar.ToString() + " OTs.";
            RefrescarGrilla();
        }

        public void RefrescarGrilla()
        {
            DateTime fec = DateTime.Now;


            if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
            {
                string fechaI = txtFechaInicio.Text;
                string[] str = fechaI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);

                string fechaIni = mes + "/" + dia + "/" + año + " 00:00:00";

                string fechaT = txtFechaTermino.Text;
                string[] str2 = fechaT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año = año.Substring(0, 4);

                string fechaTer = mes2 + "/" + dia2 + "/" + año2 + " 23:59:59";


                DateTime fechaInicio = Convert.ToDateTime(fechaIni);
                DateTime fechaTermino = Convert.ToDateTime(fechaTer);
                //filtro con fecha
                if (ddlEstado.SelectedValue.ToString() != "Seleccione...")
                {
                    if (ddlEstado.SelectedValue.ToString() == "Por Liquidar")
                    {
                        RadGrid1.DataSource = des.ListarEstadoOT(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, fechaInicio, fechaTermino, "", 4);
                        RadGrid1.DataBind();
                    }
                    else
                    {//estado 1 y 2 con fecha
                        RadGrid1.DataSource = des.ListarEstadoOT(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, fechaInicio, fechaTermino, ddlEstado.SelectedValue.ToString(), 6);
                        RadGrid1.DataBind();
                    }
                    //RadGrid1.DataSource = des.ListarEstadoOT("","","",);

                }
                else
                {
                    //carga normal con fecha sine stado
                    RadGrid1.DataSource = des.ListarEstadoOT(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, fechaInicio, fechaTermino, "", 2);
                    RadGrid1.DataBind();
                }
            }
            else
            {
                if (ddlEstado.SelectedValue.ToString() != "Seleccione...")
                {
                    if (ddlEstado.SelectedValue.ToString() == "Por Liquidar")
                    {
                        RadGrid1.DataSource = des.ListarEstadoOT(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, fec, fec, "", 3);
                        RadGrid1.DataBind();
                    }
                    else
                    {
                        RadGrid1.DataSource = des.ListarEstadoOT(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, fec, fec, ddlEstado.SelectedValue.ToString(), 5);
                        RadGrid1.DataBind();
                    }
                }
                else
                {
                    if (txtNumeroOT.Text != "" || txtNombreOT.Text != "" || txtCliente.Text != "")
                    {
                        RadGrid1.DataSource = des.ListarEstadoOT(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, fec, fec, "", 0);
                        RadGrid1.DataBind();
                    }
                    else
                    {
                        RadGrid1.DataSource = des.ListarEstadoOT("", "", "", fec, fec, "A", 1);
                        RadGrid1.DataBind();
                    }
                }
            }
        }
    }
}