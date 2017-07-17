using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;
using Telerik.Web.UI;
using Intranet.ModuloWip.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Data;

namespace Intranet.ModuloWip.View
{
    public partial class Wip_BuscarPallet_OT : System.Web.UI.Page
    {
        public static List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
        Controller_WipControl wipControl = new Controller_WipControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarBodegas();
                ddlPliegos.Items.Insert(0, new ListItem("Todos Pliegos", "Todos Pliegos"));
                CargarEstadosPallet();
                RadGridOT.DataSource = "";
                RadGridOT.DataBind();
            }
        }

        protected void txtOT_TextChanged(object sender, EventArgs e)
        {
            ddlPliegos.DataSource = wipControl.listPliegosWip(txtOT.Text.ToString().Trim());
            ddlPliegos.DataTextField = "Ubicacion";
            ddlPliegos.DataValueField = "Ubicacion";
            ddlPliegos.DataBind();
            ddlPliegos.Items.Insert(0, new ListItem("Todos Pliegos", "Todos Pliegos"));
            ddlPliegos.Focus();
        }

        public void CargarBodegas()
        {
            ddlBodegas.DataSource = wipControl.listBodegaWip();
            ddlBodegas.DataTextField = "Ubicacion";
            ddlBodegas.DataValueField = "Ubicacion";
            ddlBodegas.DataBind();
            ddlBodegas.Items.Insert(0, new ListItem("Todas Ubicaciones", "Todas Ubicaciones"));
        }

        public void CargarEstadosPallet()
        {
            ddlEstado.DataSource = wipControl.listEstadoPalletWip();
            ddlEstado.DataTextField = "Ubicacion";
            ddlEstado.DataValueField = "Estado_Pallet";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new ListItem("Todos Estados", "Todos Estados"));
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {

                Model_Wip_Control wip = new Model_Wip_Control();
                wip.OT = txtOT.Text.ToString().Trim();
                wip.IDTipoPallet = 1;
                if (ddlPliegos.SelectedValue != "Todos Pliegos")
                {
                    wip.Pliego = ddlPliegos.SelectedItem.ToString();
                    wip.IDTipoPallet = 2;
                }
                else
                {
                    wip.Pliego = "";
                }
                if (ddlEstado.SelectedValue.ToString() != "Todos Estados")
                {
                    wip.Estado_Pallet = Convert.ToInt32(ddlEstado.SelectedValue.ToString());
                    wip.IDTipoPallet = 3;
                }
                if (ddlBodegas.SelectedItem.ToString().Trim() != "Todas Ubicaciones")
                {
                    wip.Ubicacion = ddlBodegas.SelectedItem.ToString().Trim();
                    wip.IDTipoPallet = 4;
                }
                else
                {
                    wip.Ubicacion = "";
                }
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('-');
                    wip.Forma = str[2] + "-" + str[1] + "-" + str[0];
                    string[] str2 = txtFechaTermino.Text.Split('-');
                    wip.Tarea = str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59";

                }
                else
                {
                    wip.Forma = ""; wip.Tarea = "";
                }
                lista = wipControl.ListOTUbi_Buscar(wip);
                lblTotal.Text = "";
                string Total = "<table align='right' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px;width:400px;'><tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                                "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Total Pliegos</td>" +
                                "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Total SerExtDesp</td>" +
                                "<td style='font-size: medium;  padding: 4px 0 0 5px; border-right: 1px solid #ccc;'>Total SerExt</td></tr>"+
                                "<tr style='border-bottom:1px solid blue;height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; text-align: left; vertical-align: text-top;'>";

                if (lista.Count > 0)
                {
                    int SerExtDes = 0;
                    int SerExt = 0;
                    int TotalImp = 0;
                    foreach (Model_Wip_Control wp in lista.Where(o => o.Estado_Pallet2 == "Consumido en Ser. Ext. Desp"))
                    {
                        SerExtDes += wp.Pliegos_Impresos;
                    }
                    foreach (Model_Wip_Control wp in lista.Where(o => o.Estado_Pallet2 == "Consumido en Ser. Externos"))
                    {
                        SerExt += wp.Pliegos_Impresos;
                    }
                    foreach (Model_Wip_Control wp in lista.Where(o => o.Estado_Pallet2 != "Consumido en Ser. Ext. Desp" && o.Estado_Pallet2 != "Consumido en Ser. Externos"))
                    {
                        TotalImp += wp.Pliegos_Impresos;

                    }
                    Total += "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + TotalImp.ToString("N0").Replace(',', '.') + "</td>";
                    Total += "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + SerExtDes.ToString("N0").Replace(',', '.') + "</td>";
                    Total += "<td style='font-size: 15px; padding: 4px 0 5px 5px; border-right: 1px solid #ccc; text-align: right;'>" + SerExt.ToString("N0").Replace(',', '.') + "</td>";
                }
                Total += "</tr></table>";
                lblTotal.Text = Total;
                RadGridOT.DataSource = lista;
                RadGridOT.DataBind();
            }
            catch
            {
                string popupScript4 = "<script language='JavaScript'>alert('A ocurrido un error inesperado. Intentelo nuevamente');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript4);
            }

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (lista.Count > 0)
            {
                GridView gv = new GridView();
                gv.DataSource = lista;
                gv.DataBind();
                gv.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;


                gv.HeaderRow.Cells[0].Text = "OT";
                gv.HeaderRow.Cells[1].Text = "Nombre OT";
                gv.HeaderRow.Cells[2].Text = "Ubicaciones";
                gv.HeaderRow.Cells[3].Text = "Posiciones";
                gv.HeaderRow.Cells[4].Text = "Pallet";
                gv.HeaderRow.Cells[5].Text = "Pliegos";
                gv.HeaderRow.Cells[6].Text = "Cant. Pliegos";
                gv.HeaderRow.Cells[7].Text = "Peso Pallet";
                gv.HeaderRow.Cells[8].Text = "Pallets";
                gv.HeaderRow.Cells[9].Text = "Estado";
                gv.HeaderRow.Cells[10].Text = "Fecha";
                gv.HeaderRow.Cells[11].Text = "Usuarios";
                gv.HeaderRow.Cells[12].Visible = false;
                gv.HeaderRow.Cells[13].Visible = false;
                gv.HeaderRow.Cells[14].Visible = false;
                gv.HeaderRow.Cells[15].Visible = false;
                gv.HeaderRow.Cells[16].Visible = false;
                gv.HeaderRow.Cells[17].Visible = false;
                gv.HeaderRow.Cells[18].Visible = false;
                gv.HeaderRow.Cells[19].Visible = false;
                gv.HeaderRow.Cells[20].Visible = false;
                gv.HeaderRow.Cells[21].Visible = false;
                gv.HeaderRow.Cells[22].Visible = false;

                for (int contador = 0; contador < gv.Rows.Count; contador++)
                {
                    GridViewRow row = gv.Rows[contador];

                    row.Cells[4].Text = row.Cells[0].Text;
                    row.Cells[0].Text = row.Cells[1].Text;
                    row.Cells[1].Text = row.Cells[2].Text;
                    row.Cells[2].Text = row.Cells[18].Text;
                    row.Cells[5].Text = row.Cells[3].Text;
                    row.Cells[3].Text = row.Cells[19].Text;
                    row.Cells[8].Text = row.Cells[7].Text.Replace("/", " de ");
                    row.Cells[6].Text = row.Cells[9].Text;
                    row.Cells[7].Text = row.Cells[10].Text;
                    row.Cells[9].Text = row.Cells[17].Text;
                    DateTime fecha = Convert.ToDateTime(row.Cells[12].Text);
                    string fecha2 = fecha.ToString("dd-MM-yyyy HH:mm:ss");
                    row.Cells[10].Text = fecha2;
                    row.Cells[11].Text = row.Cells[13].Text;
                    row.Cells[10].CssClass = "textmode";
                    row.Cells[12].Visible = false;
                    row.Cells[13].Visible = false;
                    row.Cells[14].Visible = false;
                    row.Cells[15].Visible = false;
                    row.Cells[16].Visible = false;
                    row.Cells[17].Visible = false;
                    row.Cells[18].Visible = false;
                    row.Cells[19].Visible = false;
                    row.Cells[20].Visible = false;
                    row.Cells[21].Visible = false;
                    row.Cells[22].Visible = false;
                }
                ExportToExcel("Informe Control Wip" + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), gv, txtOT.Text, ddlPliegos.SelectedItem.Text, txtFechaInicio.Text, txtFechaTermino.Text, ddlBodegas.SelectedItem.Text);
            }
        }

        private void ExportToExcel(string nameReport, GridView wControl, string OT, string Pliego, string fInicio, string fTermino,string Bodega)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe Control Wip<br/>";
            if (OT != "") { Titulo = Titulo + "OT : " + OT; }
            if (Pliego  != "") { Titulo = Titulo + " Pliego : " + Pliego; }
            if (Bodega != "") { Titulo = Titulo + " Bodega :" + Bodega; }
            if (fInicio != "") { Titulo = Titulo + " Fecha Inicio : " + fInicio; }
            if (fTermino != "") { Titulo = Titulo + " Fecha Termino : " + fTermino; }
            la.Text = Titulo + "</div><br />";

            form.Controls.Add(la);
            form.Controls.Add(wControl);


            //Label formula = new Label();
            //formula.Text = "=3600/(24*60*60)";
            //formula.CssClass = "textmode";
            //form.Controls.Add(formula);
            

            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport + ".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);


            //response.Write("<head><style type='text/css'>.textmode{mso-number-format:\\@;}</style></head>");
            response.Write(sw.ToString());
            response.End();
        }

    }
}