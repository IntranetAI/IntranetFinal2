using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloDespacho.Controller;
using Telerik.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;


namespace Intranet.ModuloDespacho.View
{
    public partial class InformePorOT : System.Web.UI.Page
    {

        DespachoController controldes = new DespachoController();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();

                RadGrid2.DataSource = "";
                RadGrid2.DataBind();
            }

 
                imprimirmensaje.Visible = true;
                imprimirmensaje.Attributes.Add("onclick", "window.open('imprimirInformePorOT.aspx?ot=" + txtNumeroOT.Text + "&not=" + txtNombreOT.Text + "&fi=" + txtFechaInicio.Text + "&ft=" + txtFechaTermino.Text + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=1200,height=700,left=50,top=100')");
                //Button1.Attributes.Add("onclick",  "window.open('infOperario.aspx','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=380,height=300,left=340,top=200')");
            //}
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtNumeroOT.Text.Length > 4)
            {
                RadGrid2.Visible = false;
                RadGrid1.Visible = true;
                RadGrid1.DataSource = controldes.ListarDespacho_informePorOT(txtNumeroOT.Text, null, null, null, null, 1);
                RadGrid1.DataBind();
          
                ibPDF.Visible = false;

            }
            else
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string fechaI = txtFechaInicio.Text;
                    string[] str = fechaI.Split('/');
                    string dia = str[0];
                    string mes = str[1];
                    string año = str[2];
                    año = año.Substring(0, 4);

                    string fechaInicio = año + "-"+  mes + "-" + dia;
                    //fechas
                    string fechaT = txtFechaTermino.Text;
                    string[] str2 = fechaT.Split('/');
                    string dia2 = str2[0];
                    string mes2 = str2[1];
                    string año2 = str2[2];
                    año2 = año2.Substring(0, 4);

                    string fechaTermino = año2 + "-" + mes2 + "-" + dia2;
                    RadGrid1.Visible = false;
                    RadGrid2.Visible = true;
                    //carga con fechas
                    if (fechaInicio == fechaTermino)
                    {
                        fechaInicio = fechaInicio + " 00:00:00";
                        fechaTermino = fechaTermino + " 23:59:59";
                    }
                    RadGrid2.DataSource = controldes.ListarDespacho_informePorOTAgrupada(txtNombreOT.Text, txtNumeroOT.Text, fechaInicio, fechaTermino, 2);
                    RadGrid2.DataBind();
                    
                    ibPDF.Visible = false;
                }
                else
                {
                    string fi = "2012-01-01 00:00:00";
                    string ft = "2100-01-01 23:59:59";
                    RadGrid1.Visible = false;
                    RadGrid2.Visible = true;
                    //carga con fechas
                    RadGrid2.DataSource = controldes.ListarDespacho_informePorOTAgrupada(txtNombreOT.Text, txtNumeroOT.Text,fi, ft, 3);
                    RadGrid2.DataBind();

                   
                    ibPDF.Visible = false;
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string FI;
            string FT;
            if (txtFechaInicio.Text == "" || txtFechaTermino.Text == "")
            {
                 FI = "01/01/1900";
                 FT = "01/01/1900";
            }
            else
            {
                FI = txtFechaInicio.Text;
                FT = txtFechaTermino.Text;
                if (FI == FT)
                {
                    FI = FI + " 00:00:00";
                    FT = FT + " 23:59:59";
                }
            }
            if (txtNumeroOT.Text.Length > 4)
            {
                Response.Redirect("../../moduloComercial/view/pdfinformexot.aspx?OT=" + txtNumeroOT.Text + "&NOT=" + txtNombreOT.Text + "&FI=" + FI + "&FT=" + FT + "");
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('Debe ingresar una OT para generar el reporte.');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {

            if (e.CommandName == "RowClick")
            {
               
                GridDataItem item = (GridDataItem)e.Item;

                txtNumeroOT.Text = item["OT"].Text;
                txtNombreOT.Text = "";

                if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
                {
                    string fechaI = txtFechaInicio.Text;
                    string[] str = fechaI.Split('/');
                    string dia = str[0];
                    string mes = str[1];
                    string año = str[2];
                    año = año.Substring(0, 4);

                    string fechaInicio = mes + "/" + dia + "/" + año;
                    //fechas
                    string fechaT = txtFechaTermino.Text;
                    string[] str2 = fechaT.Split('/');
                    string dia2 = str2[0];
                    string mes2 = str2[1];
                    string año2 = str2[2];
                    año2 = año2.Substring(0, 4);

                    string fechaTermino = mes2 + "/" + dia2 + "/" + año2;
                    pnlResultados.Visible = true;
                    RadGrid2.Visible = false;
                    RadGrid1.Visible = true;
                    if (fechaInicio == fechaTermino)
                    {
                        fechaInicio = fechaInicio + " 00:00:00";
                        fechaTermino = fechaTermino + " 23:59:59";
                    }
                    RadGrid1.DataSource = controldes.ListarDespacho_informePorOT(item["OT"].Text, "", txtCliente.Text, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 2);
                    RadGrid1.DataBind();
                  
                    ibPDF.Visible = false;//TRUE;
                    //txtCliente.Text = mes + "/" + dia + "/" + año;
                }
                else
                {
                    string fi = "2012-01-01 00:00:00";
                    string ft = "2100-01-01 23:59:59";

                    pnlResultados.Visible = true;
                    RadGrid2.Visible = false;
                    RadGrid1.Visible = true;
                    RadGrid1.DataSource = controldes.ListarDespacho_informePorOT(item["OT"].Text,"", txtCliente.Text, Convert.ToDateTime(fi), Convert.ToDateTime(ft), 1);
                    RadGrid1.DataBind();
                  
                    ibPDF.Visible = false;//TRUE
                }
            }
        }
        //eliminar por mitivo de que es el anterior excel que generaba por eso no funciona
        protected void Button2_Click(object sender, EventArgs e)
        {
           
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (RadGrid1.Visible == true && RadGrid1.Items.Count > 0)
                {
                    //por ot
                    List<Excel_InformePorOT> lista = new List<Excel_InformePorOT>();
                    for (int i = 0; i < RadGrid1.Items.Count; i++)
                    {
                        Excel_InformePorOT pro = new Excel_InformePorOT();
                        pro.OT = RadGrid1.Items[i]["OT"].Text.Replace("&nbsp;", "");
                        pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text.Replace("&nbsp;", ""); ;
                        if(RadGrid1.Items[i]["TipoMovimiento"].Text == "<div style='Color:Green;'>Despacho</div>")
                        {
                            pro.TipoMovimiento = "Despacho";
                        }
                        else if (RadGrid1.Items[i]["TipoMovimiento"].Text.Contains("&nbsp;"))
                        {
                            pro.TipoMovimiento = "";
                        }
                        else
                        {
                            pro.TipoMovimiento = "Devolucion";
                        }
                        pro.NroGuia = RadGrid1.Items[i]["Folio"].Text.Replace("&nbsp;", ""); 
                        pro.Sucursal = RadGrid1.Items[i]["Cliente"].Text.Replace("&nbsp;", ""); 
                        pro.FechaDespacho = RadGrid1.Items[i]["FechaImpresion"].Text.Replace("&nbsp;", "");
                        pro.TirajeTotal = RadGrid1.Items[i]["TirajeTotal"].Text.Replace(".", "");
                        pro.TotalDespachado = RadGrid1.Items[i]["Despachado"].Text.Replace(".", "");
                        lista.Add(pro);
                    }
                    GridView GridView1 = new GridView();
                    GridView1.DataSource = lista;
                    GridView1.DataBind();
                    GridView1.HeaderStyle.BackColor = System.Drawing.Color.DarkGray;
                    GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    ExportToExcel("InformePorOT", GridView1, "PorOT");
                }
                else if (RadGrid2.Visible == true && RadGrid2.Items.Count > 0)
                {
                    List<Excel_InformePorFecha> lista = new List<Excel_InformePorFecha>();
                    for (int i = 0; i < RadGrid2.Items.Count; i++)
                    {
                        Excel_InformePorFecha pro = new Excel_InformePorFecha();
                        pro.OT = RadGrid2.Items[i]["OT"].Text.Replace("&nbsp;", "");
                        pro.NombreOT = RadGrid2.Items[i]["NombreOT"].Text.Replace("&nbsp;", ""); 
                        pro.Cliente = RadGrid2.Items[i]["Cliente"].Text.Replace("&nbsp;", ""); 
                        pro.FechaInicio = RadGrid2.Items[i]["FechaMinima"].Text;
                        pro.FechaTermino = RadGrid2.Items[i]["FechaMaxima"].Text;
                        pro.TirajeTotal = RadGrid2.Items[i]["TirajeTotal"].Text.Replace(".", "");
                        pro.TotalDespachado = RadGrid2.Items[i]["Despachado"].Text.Replace(".", "");
                        lista.Add(pro);
                    }
                    GridView GridView1 = new GridView();
                    GridView1.DataSource = lista;
                    GridView1.DataBind();
                    GridView1.HeaderStyle.BackColor = System.Drawing.Color.DarkGray;
                    GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    ExportToExcel("InformePorOT", GridView1, "PorOT");
                }
                else
                {

                }
 
                
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('ha Ocurrido un error, vuelva a intentarlo "+ex.Message+"');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }

        private void ExportToExcel(string nameReport, GridView wControl,string TipoDeInforme)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();
            la.Text = "<div align='center'>INFORME POR OT<br/> </div><br/>";
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





        //
        //private void ExportToExcel(string nameReport, GridView wControl, string TotalGuia, string TotalDespacho, int total, string Nombre, string fInicio, string fTermino)
        //{
        //    HttpResponse response = Response;
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    Page pageToRender = new Page();
        //    HtmlForm form = new HtmlForm();
        //    Label la = new Label();
        //    if (fInicio != "")
        //    {
        //        la.Text = "<div align='center'>INFORME POR OT<br/>N° OT : " + txtNumeroOT.Text + " Nombre OT : " + Nombre + "<br/>Desde : " + fInicio + " Hasta : " + fTermino + " </div><br/>";
        //    }
        //    else
        //    {
        //        la.Text = "<div align='center'>INFORME POR OT<br/>N° OT : " + txtNumeroOT.Text + " Nombre OT : " + Nombre + "</div><br/>";
        //    }
        //    form.Controls.Add(la);
        //    form.Controls.Add(wControl);
        //    Label l = new Label(); l.Text = "<div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>" + TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Saldo:</td></tr></table></td><td><table  border='1'><tr><td>" + total.ToString("N0").Replace(",", ".") + "</td></tr></table></td></tr> </table>";//<tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr>
        //    //<br/><div align='right'><table><tr><td></td><td></td><td></td><td></td><td></td><td><table  border='1'><tr><td>Cantidad de Guia</td></tr></table></td><td><table  border='1'><tr><td>" + TotalGuia + "</td></tr></table></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total A Despachar</td></tr></table></td><td><table  border='1'><tr><td>" + total + "</td></tr></table></td></tr> <tr><td></td><td></td><td></td><td></td><td></td><td><table border='1'><tr><td>Total Despachado</td></tr></table></td><td><table border='1'><tr><td>" + TotalDespacho + "</td></tr></table></td></tr></table>
        //    form.Controls.Add(l);
        //    pageToRender.Controls.Add(form);
        //    response.Clear();
        //    response.Buffer = true;
        //    response.ContentType = "application/vnd.ms-excel";
        //    response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport+".xls");
        //    response.Charset = "UTF-8";
        //    response.ContentEncoding = Encoding.Default;
        //    pageToRender.RenderControl(htw);
        //    response.Write(sw.ToString());
        //    response.End();
        //}

        protected void ibPDF_Click(object sender, ImageClickEventArgs e)
        {
            string FI;
            string FT;
            if (txtFechaInicio.Text == "" || txtFechaTermino.Text == "")
            {
                FI = "01/01/1900";
                FT = "01/01/1900";
            }
            else
            {
                FI = txtFechaInicio.Text;
                FT = txtFechaTermino.Text;
                if (FI == FT)
                {
                    FI = FI + " 00:00:00";
                    FT = FT + " 23:59:59";
                }
            }
            if (txtNumeroOT.Text.Length > 4)
            {
                Response.Redirect("PDFInformexOT.aspx?OT=" + txtNumeroOT.Text + "&NOT=" + txtNombreOT.Text + "&FI=" + FI + "&FT=" + FT + "");
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert(' Debe Seleccionar una OT de la lista.');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        //protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        //{
            //int tirajeTt = 0;
            //int tirajeTOtal = 0;
            //int totalDesp = 0;
            //List<DespachoExcel> lista = new List<DespachoExcel>();

            //for (int i = 0; i < RadGrid1.Items.Count; i++)
            //{

            //    DespachoExcel pro = new DespachoExcel();
            //    if (RadGrid1.Items[i]["OT"].Text != "&nbsp;")
            //    {
            //        pro.OT = RadGrid1.Items[i]["OT"].Text;
            //        pro.guia = RadGrid1.Items[i]["Folio"].Text;
            //        pro.NombreOT = RadGrid1.Items[i]["NombreOT"].Text;
            //        if (RadGrid1.Items[i]["TipoMovimiento"].Text == "<div style='Color:Green;'>Despacho</div>")
            //        {
            //            pro.TipoMovimiento = "Despacho";
            //        }
            //        else
            //        {
            //            pro.TipoMovimiento = "Devolucion";
            //        }
            //        if (RadGrid1.Items[i]["Cliente"].Text == "&nbsp;")
            //        {
            //            pro.Cliente = "";
            //        }
            //        else
            //        {
            //            pro.Cliente = RadGrid1.Items[i]["Cliente"].Text;
            //        }
                    
            //        pro.FechaImpresion = RadGrid1.Items[i]["FechaImpresion"].Text;
            //    }
            //    else
            //    {
            //        pro.OT = "";
            //        pro.guia = "";
            //        pro.NombreOT = "";
            //        pro.Cliente = "";
            //        pro.FechaImpresion = "";
            //    }
            //    pro.TirajeTotal = RadGrid1.Items[i]["TirajeTotal"].Text;
            //    pro.Despachado = RadGrid1.Items[i]["Despachado"].Text;
              
            //    totalDesp = Convert.ToInt32(RadGrid1.Items[i]["Despachado"].Text.Replace(".", ""));

            //    if (RadGrid1.Items[i]["TirajeTotal"].Text == "Total Despachado:" || RadGrid1.Items[i]["TirajeTotal"].Text == "Cantidad de Guia" || RadGrid1.Items[i]["TirajeTotal"].Text == "Total A Despachar" || RadGrid1.Items[i]["TirajeTotal"].Text == "Total Despachado")
            //    {
            //    }
            //    else
            //    {
            //        tirajeTt = Convert.ToInt32(RadGrid1.Items[i]["TirajeTotal"].Text.Replace(".", ""));
            //        tirajeTOtal = Convert.ToInt32(RadGrid1.Items[i]["TirajeTotal"].Text.Replace(".", ""));
            //    }
              

            //    lista.Add(pro);
            //}
            //GridView GridView1 = new GridView();
            ////GridView GridView1 = new GridView();
            ////if (txtNumeroOT.Text.Length > 4)
            ////{
            ////    if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
            ////    {
            ////        string fechaI = txtFechaInicio.Text;
            ////        string[] str = fechaI.Split('/');
            ////        string dia = str[0];
            ////        string mes = str[1];
            ////        string año = str[2];
            ////        año = año.Substring(0, 4);

            ////        string fechaInicio = mes + "/" + dia + "/" + año;
            ////        //fechas
            ////        string fechaT = txtFechaTermino.Text;
            ////        string[] str2 = fechaT.Split('/');
            ////        string dia2 = str2[0];
            ////        string mes2 = str2[1];
            ////        string año2 = str2[2];
            ////        año2 = año2.Substring(0, 4);

            ////        string fechaTermino = mes2 + "/" + dia2 + "/" + año2;
            ////        pnlResultados.Visible = true;
            ////        GridView1.Visible = true;
            ////        if (fechaInicio == fechaTermino)
            ////        {
            ////            fechaInicio = fechaInicio + " 00:00:00";
            ////            fechaTermino = fechaTermino + " 23:59:59";
            ////        }
            ////        GridView1.DataSource = controldes.ListarDespacho_informePorOTExcel(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 2);

            ////        //txtCliente.Text = mes + "/" + dia + "/" + año;
            ////    }
            ////    else
            ////    {
            ////        pnlResultados.Visible = true;
            ////        GridView1.Visible = true;
            ////        GridView1.DataSource = controldes.ListarDespacho_informePorOTExcel(txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, null, null, 1);
            ////    }



            //GridView1.DataSource = lista;
            //GridView1.DataBind();
            ////GridView1.HeaderRow.Cells[0].Text = "Nº OT";
            ////GridView1.HeaderRow.Cells[1].Text = "Nº Guia";
            ////GridView1.HeaderRow.Cells[2].Text = "Nombre OT";
            //GridView1.HeaderRow.Cells[5].Text = "Fecha Despacho";
            ////GridView1.HeaderRow.Cells[5].Text = "Tiraje Total";
            ////GridView1.HeaderRow.Cells[6].Text = "Total Despachado";

            //GridView1.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            //GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
            //int contador = 0;
            //int Despachado = 0;
            //int Paradespachar = 0;
            //int saldo = 0;
            //string NombreOT = "";
            //int ttd = 0;
            //for (contador = 0; contador < GridView1.Rows.Count; contador++)
            //{
            //    GridViewRow row = GridView1.Rows[contador];
            //    NombreOT = row.Cells[3].Text;
            //    string numero = row.Cells[7].Text;



            //    ttd = ttd + Convert.ToInt32(row.Cells[7].Text.Replace(".", ""));
            //    //Paradespachar = tirajeTt.ToString("N0");//row.Cells[5].Text;
            //    //string[] str = numero.Split('.');
            //    //string centena = "";
            //    //string unidad = "";
            //    //int Des = 0;
            //    //if (str[0] == numero)
            //    //{
            //    //    centena = str[0];
            //    //    Des = Convert.ToInt32(centena);
            //    //}
            //    //else
            //    //{
            //    //    centena = str[0];
            //    //    unidad = str[1];
            //    //    Des = Convert.ToInt32(centena + unidad);
            //    //}
            //    Despachado = Despachado;//+ Des;

               
            //}
            //saldo = tirajeTOtal - totalDesp;
            //string nombre = "InformePorOT" + DateTime.Now.ToShortDateString();

            //if (txtFechaInicio.Text != "" || txtFechaTermino.Text != "")
            //{
            //    ExportToExcel(nombre, GridView1, (contador - 1).ToString("N0").Replace(",", "."), ttd.ToString("N0").Replace(",", "."), saldo, NombreOT, txtFechaInicio.Text, txtFechaTermino.Text);//GridView1);
            //}
            //else
            //{
            //    ExportToExcel(nombre, GridView1, (contador - 1).ToString("N0").Replace(",", "."), ttd.ToString("N0").Replace(",", "."), saldo, NombreOT, "Sin Fecha", "Sin Fecha");//GridView1);
            //    //                                                        Despachado.ToString("N0")
            //}
            

        //}


    }
}