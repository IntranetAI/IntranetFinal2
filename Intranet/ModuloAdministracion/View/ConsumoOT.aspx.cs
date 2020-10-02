using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using Intranet.ModuloAdministracion.Model;

namespace Intranet.ModuloAdministracion.View
{
    public partial class ConsumoOT : System.Web.UI.Page
    {
        Controller_Consumo controlCons = new Controller_Consumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try {   System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.UserLanguages[0]);  }
                catch { //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");

                }
                RadGridRF.DataSource = "";
                RadGridRF.DataBind();
                RadGridPlanchas.DataSource = "";
                RadGridPlanchas.DataBind();
                RadGridOtros.DataSource = "";
                RadGridOtros.DataBind();
                RadGridSerExterno.DataSource = "";
                RadGridSerExterno.DataBind();
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            Controller_EstadoOT controlstatus = new Controller_EstadoOT();
            Estado_OT status = controlstatus.BuscarOTLiquidar(txtOT.Text, 1);
            lblOT.Text = status.NombreOT;
            if (status.FechaMaxima != "")
            {
                lblFeliqui.Text = Convert.ToDateTime(status.FechaMaxima).ToString("dd-MM-yyyy");
                lblFeliqui.Visible = true;
                Label2.Visible = true;
            }
            lblOT.Visible = true;
            Label1.Visible = true;
            List<Consumo> lista = controlCons.Listar(txtOT.Text);

            Consumo Papel = new Consumo();
            RadGridRF.DataSource = lista.Where(o => o.Tipo == "Bobina" || o.Tipo == "Pliego").ToList();
            RadGridRF.DataBind();
            foreach (Consumo c in lista.Where(o => o.Tipo == "Bobina" || o.Tipo == "Pliego"))
            {
                if (c.Tipo == "Bobina")
                {
                    Papel.Cons_Bobina = (Convert.ToInt32(c.Cons_Bobina.Substring(0, c.Cons_Bobina.Length - 2).Replace(".", string.Empty)) + Convert.ToInt32(Papel.Cons_Bobina)).ToString();
                }
                else
                {
                    Papel.Cons_Pliego = (Convert.ToInt32(c.Cons_Pliego.Substring(0, c.Cons_Pliego.Length - 2).Replace(".", string.Empty)) + Convert.ToInt32(Papel.Cons_Pliego)).ToString();
                }
                Papel.Costtot = (Convert.ToDouble(Papel.Costtot) + Convert.ToDouble(c.Costtot.Replace(",",string.Empty))).ToString();
            }
            lblPliego.Text = Convert.ToInt32(Papel.Cons_Pliego).ToString("N0").Replace(",", ".") + " FL";
            lblBobina.Text = Convert.ToInt32(Papel.Cons_Bobina).ToString("N0").Replace(",", ".") + " KG";
            lblTotal.Text = Convert.ToDouble(Papel.Costtot).ToString("N2");
            
            if (lista.Where(o => o.Tipo == "Plancha").ToList().Count > 0)
            {
                RadGridPlanchas.DataSource = lista.Where(o => o.Tipo == "Plancha").ToList();
                RadGridPlanchas.DataBind();
                RadGridPlanchadiv.Visible = true;
                RadGridPlanchaTit.Visible = true;
                tablaPlancha.Visible = true;
                foreach (Consumo c in lista.Where(o => o.Tipo == "Plancha"))
                {
                    Papel.Cons_Plancha = (Convert.ToInt32(c.Cons_Plancha.Substring(0, c.Cons_Plancha.Length - 2).Replace(",", string.Empty)) + Convert.ToInt32(Papel.Cons_Plancha)).ToString();

                    Papel.Ancho = (Convert.ToDouble(Papel.Ancho) + Convert.ToDouble(c.Costtot.Replace(",", string.Empty))).ToString();
                }
                
                lblPlancha.Text = Convert.ToInt32(Papel.Cons_Plancha).ToString("N0") + " UN";
                lblTotalplc.Text = Convert.ToDouble(Papel.Ancho).ToString("N2");
            }
            else
            {
                RadGridPlanchadiv.Visible = false;
                RadGridPlanchaTit.Visible = false;
                tablaPlancha.Visible = false;
            }
            if (lista.Where(o => o.Tipo == "Otro").ToList().Count > 0)
            {
                RadGridOtros.DataSource = lista.Where(o => o.Tipo == "Otro").ToList();
                RadGridOtros.DataBind();
                RadGridOtrosdiv.Visible = true;
                RadGridOtrosTit.Visible = true;
                TableOtros.Visible = true;
                foreach (Consumo c in lista.Where(o => o.Tipo == "Otro"))
                {

                    if (c.Cons_Otros.Contains("ROLO"))
                    {
                        Papel.Cons_Otros ="0";
                        Papel.Certif = "0";
                       // Papel.Cons_Otros = (Convert.ToInt32(c.Cons_Otros.Substring(0, c.Cons_Otros.Length - 2).Replace(".", string.Empty)) + Convert.ToInt32(Papel.Cons_Otros)).ToString();
                    }
                    else
                    {
                        Papel.Cons_Otros = (Convert.ToInt32(c.Cons_Otros.Substring(0, c.Cons_Otros.Length - 2).Replace(".", string.Empty)) + Convert.ToInt32(Papel.Cons_Otros)).ToString();
                        Papel.Certif = (Convert.ToDouble(Papel.Certif) + Convert.ToDouble(c.Costtot.Replace(",", string.Empty))).ToString();
                    }

                    
                }
                
                lblOtros.Text = Convert.ToInt32(Papel.Cons_Otros).ToString("N0") + " UN";
                lblTotalOtros.Text = Convert.ToDouble(Papel.Certif).ToString("N2");
            }
            else
            {
                RadGridOtrosdiv.Visible = false;
                RadGridOtrosTit.Visible = false;
                TableOtros.Visible = false;
            }
            List<Consumo> lista2 = controlCons.ListarSerExterno(txtOT.Text);
            if (lista2.Count > 0)
            {
                DivTitServExt.Visible = true;
                DivSerExterno.Visible = true;
                TablaSerExter.Visible = true;
                RadGridSerExterno.DataSource = lista2;
                RadGridSerExterno.DataBind();
                foreach (Consumo c in lista2)
                {
                    Papel.CostUni = (Convert.ToDouble(Papel.CostUni) + Convert.ToDouble(c.Costtot.Replace(",", string.Empty))).ToString();
                    //aaaa = aaaa + "+" + Convert.ToDouble(c.Costtot.Replace(".", string.Empty).Replace(",", ".")).ToString();
                }
                lblTotalSerExt.Text = Convert.ToDouble(Papel.CostUni).ToString("N2");
                //string b = aaaa;
            }
            else
            {
                DivTitServExt.Visible = false;
                DivSerExterno.Visible = false;
                TablaSerExter.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string OT = txtOT.Text;

            Controller_Consumo controlcons = new Controller_Consumo();

            if (OT.Trim() != "")
            {

                GridView gv = new GridView();
                gv.DataSource = controlCons.Listar(txtOT.Text);
                gv.DataBind();
                gv.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;


                gv.HeaderRow.Cells[1].Text = "Cod Item";
                gv.HeaderRow.Cells[2].Text = "Nombre Papel";
                gv.HeaderRow.Cells[3].Text = "Gr.";
                gv.HeaderRow.Cells[6].Text = "Consumo Pliego";
                gv.HeaderRow.Cells[7].Text = "Consumo Bobina";
                gv.HeaderRow.Cells[8].Text = "Certificación";
                gv.HeaderRow.Cells[9].Text = "Costo Unitario";
                gv.HeaderRow.Cells[10].Text = "Costo Total";
               
                if (lblOT.Text != "")
                {
                    string NombreOT = "OT : " + txtOT.Text + " - " + lblOT.Text;
                    ExportToExcel("Consumo por OT " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), gv, NombreOT, Label2.Text + lblFeliqui.Text);
                }
            }
        }

        private void ExportToExcel(string nameReport, GridView wControl, string OT, string Fecha)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Consumo por OT<br/>" + OT + " " + Fecha;
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