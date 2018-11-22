using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBobina.Controller;
using Intranet.ModuloBobina.Model;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Intranet.ModuloBobina.View
{
    public partial class Informe_MensualBobina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel("Reporte Mensual",lblTabla.Text, txtFechaInicio.Text, txtFechaTermino.Text);
            string popupScript = "<script language='JavaScript'>divPiePagina();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        private void ExportToExcel(string nameReport, string Tabla, string fInicio, string fTermino)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.UserLanguages[0]);
            }
            catch
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            }
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            Label la = new Label();

            string Titulo = "<div align='center'>Informe Mensual<br/>";
            if (fInicio != "") { Titulo += " Fecha : " + fInicio + " a " + fTermino; }
            la.Text = Titulo + "</div><br />";

            form.Controls.Add(la);

            Label TablaTotal = new Label();
            TablaTotal.Text = Tabla;
            form.Controls.Add(TablaTotal);


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

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "")
            {
                try
                {
                    string HoraInicio = "00:00:00";string HoraTermino = "23:59:59";
                    if (txtFechaInicio.Text == txtFechaTermino.Text)
                    {
                        switch (DropDownList1.SelectedValue.ToString())
                        {
                            case "0":
                                HoraInicio = "00:00:00";
                                HoraTermino = "23:59:59";
                                break;
                            case "1":
                                HoraInicio = "00:00:00";
                                HoraTermino = "07:59:59";
                                break;
                            case "2":
                                HoraInicio = "08:00:00";
                                HoraTermino = "15:59:59";
                                break;
                            case "3":
                                HoraInicio = "16:00:00";
                                HoraTermino = "23:59:59";
                                break;
                            default:
                                break;
                        }
                    }else
                    {
                        DropDownList1.SelectedIndex = 0;
                    }
                    string[] splitInicio = txtFechaInicio.Text.Split('/');
                    string[] splitTermino = txtFechaTermino.Text.Split('/');
                    Controller_ConsumoBobina controlbobina = new Controller_ConsumoBobina();
                    List<Bobina_ConsumoLinea_V2> lista = controlbobina.List_BobinasInformeMensual_V3(Convert.ToDateTime(splitInicio[2] + "-" + splitInicio[1] + "-" + splitInicio[0] + " " + HoraInicio), Convert.ToDateTime(splitTermino[2] + "-" + splitTermino[1] + "-" + splitTermino[0] + " " + HoraTermino));


                    lblTabla.Text = TablaInforme_V2(lista);

                    string popupScript = "<script language='JavaScript'>divPiePagina();</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                catch
                {
                }
            }
        }

        public string TablaInforme(List<Bobina_ConsumoLinea> lista)
        {
            string Tabla = "<table style='width: 100%;' class='table table-hover table-bordered table-striped'>" +
                            "<thead><tr class='filters'>"+
                        "<th>#</th>"+
                        "<th>Lithoman</th>" +
                        "<th>M600</th>" +
                        "<th>Web 1</th>" +
                        "<th>Web 2</th>" +
                        "<th>Goss</th>" +
                        "<th>Dimensionadora</th>" +
                        "<th>Total</th>" +
                    "</tr>"+
                "</thead>";
            string stgTotalBobinasConsumidas = "";
            string stgTotalkilosConsumidos = "";
            string stgTotalkilosEscarpe = "";
            string stgPromedioEscarpexbobina = "";
            string stgPorcentajeescarpe = "";
            string stgBobinasBuenas = "";
            string stgBobinasMalas = "";
            string stgKGEscarpeAlmacen = "";
            string stgKGEscarpeRollero = "";
            string stgKGEscarpeProveedor = "";
            int CantidadTotalBobinasConsumidaLithoman = 0;
            int CantidadTotalBobinasConsumidaM600 = 0;
            int CantidadTotalBobinasConsumidaWeb1 = 0;
            int CantidadTotalBobinasConsumidaWeb2 = 0;
            int CantidadTotalBobinasConsumidaGoss = 0;
            int CantidadTotalBobinasConsumidaDimensionadora = 0;
            int CantidadTotalBobinasConsumida = 0;

            int TotalkilosConsumidosLithoman = 0;
            int TotalkilosConsumidosM600 = 0;
            int TotalkilosConsumidosWeb1 = 0;
            int TotalkilosConsumidosWeb2 = 0;
            int TotalkilosConsumidosGoss = 0;
            int TotalkilosConsumidosDimensionadora = 0;
            int TotalkilosConsumidos = 0;

            int TotalEscarpeLithoman = 0;
            int TotalEscarpeM600 = 0;
            int TotalEscarpeWeb1 = 0;
            int TotalEscarpeWeb2 = 0;
            int TotalEscarpeGoss = 0;
            int TotalEscarpeDimensionadora = 0;
            int TotalEscarpe = 0;

            int CantidadBobBuenaLithoman = 0;
            int CantidadBobMalaLithoman = 0;
            int KGEscarpeAlmacenLithoman = 0;
            int KGEscarpeRolleroLithoman = 0;
            int KGEscarpeProveedorLithoman = 0;

            int CantidadBobBuenaM600 = 0;
            int CantidadBobMalaM600 = 0;
            int KGEscarpeAlmacenM600 = 0;
            int KGEscarpeRolleroM600 = 0;
            int KGEscarpeProveedorM600 = 0;

            int CantidadBobBuenaWeb1 = 0;
            int CantidadBobMalaWeb1 = 0;
            int KGEscarpeAlmacenWeb1 = 0;
            int KGEscarpeRolleroWeb1 = 0;
            int KGEscarpeProveedorWeb1 = 0;

            int CantidadBobBuenaWeb2 = 0;
            int CantidadBobMalaWeb2 = 0;
            int KGEscarpeAlmacenWeb2 = 0;
            int KGEscarpeRolleroWeb2 = 0;
            int KGEscarpeProveedorWeb2 = 0;

            int CantidadBobBuenaGoss = 0;
            int CantidadBobMalaGoss = 0;
            int KGEscarpeAlmacenGoss = 0;
            int KGEscarpeRolleroGoss = 0;
            int KGEscarpeProveedorGoss = 0;

            int CantidadBobBuenaDimensionadora = 0;
            int CantidadBobMalaDimensionadora = 0;
            int KGEscarpeAlmacenDimensionadora = 0;
            int KGEscarpeRolleroDimensionadora = 0;
            int KGEscarpeProveedorDimensionadora = 0;

            int CantidadBobBuena = 0;
            int CantidadBobMala = 0;
            int KGEscarpeAlmacen = 0;
            int KGEscarpeRollero = 0;
            int KGEscarpeProveedor = 0;

            int BobConProyectoLithoman = 0;
            int BobKGConProyectoLithoman = 0;
            int BobSinProyectoLithoman = 0;
            int BobKGSinProyectoLithoman = 0;

            int BobConProyectoM600 = 0;
            int BobKGConProyectoM600 = 0;
            int BobSinProyectoM600 = 0;
            int BobKGSinProyectoM600 = 0;

            int BobConProyectoWeb1 = 0;
            int BobKGConProyectoWeb1 = 0;
            int BobSinProyectoWeb1 = 0;
            int BobKGSinProyectoWeb1 = 0;

            int BobConProyectoWeb2 = 0;
            int BobKGConProyectoWeb2 = 0;
            int BobSinProyectoWeb2 = 0;
            int BobKGSinProyectoWeb2 = 0;

            int BobConProyectoGoss = 0;
            int BobKGConProyectoGoss = 0;
            int BobSinProyectoGoss = 0;
            int BobKGSinProyectoGoss = 0;

            int BobConProyectoDimensionadora = 0;
            int BobKGConProyectoDimensionadora = 0;
            int BobSinProyectoDimensionadora = 0;
            int BobKGSinProyectoDimensionadora = 0;

            int BobConProyecto = 0;
            int BobKGConProyecto = 0;
            int BobSinProyecto = 0;
            int BobKGSinProyecto = 0;
            foreach (string Maquina in lista.Select(o => o.Maquina).Distinct())
            {
                foreach (Bobina_ConsumoLinea bob in lista.Where(o => o.Maquina == Maquina))
                {
                    TotalkilosConsumidos += Convert.ToInt32(bob.ConsumoBobina);
                    TotalEscarpe += Convert.ToInt32(bob.Escarpe);
                    CantidadTotalBobinasConsumida++;
                    #region TipoPerdida
                    switch (bob.OrigenPerdida)
                    {
                        case "":
                            CantidadBobBuena++;
                            break;
                        case "PROVEEDOR":
                            CantidadBobMala++;
                            KGEscarpeProveedor += Convert.ToInt32(bob.Escarpe);
                            break;
                        case "ROLLERO":
                            CantidadBobMala++;
                            KGEscarpeRollero += Convert.ToInt32(bob.Escarpe);
                            break;
                        case "ALMACÉN":
                            CantidadBobMala++;
                            KGEscarpeAlmacen += Convert.ToInt32(bob.Escarpe);
                            break;
                        default:
                            CantidadBobBuena++;
                            break;
                    }
                    #endregion
                    #region BobinaProyecto
                    if (Convert.ToInt32(bob.Codigo_Bobina) >= 41469)
                    {
                        BobConProyecto++;
                        BobKGConProyecto += Convert.ToInt32(bob.ConsumoBobina);
                    }
                    else
                    {
                        BobSinProyecto++;
                        BobKGSinProyecto += Convert.ToInt32(bob.ConsumoBobina);
                    }
                    #endregion
                    switch(Maquina)
                    {
                        case "LITHOMAN":
                            TotalkilosConsumidosLithoman += Convert.ToInt32(bob.ConsumoBobina);
                            TotalEscarpeLithoman += Convert.ToInt32(bob.Escarpe);
                            CantidadTotalBobinasConsumidaLithoman++;
                            #region TipoPerdidaLithoman
                            switch (bob.OrigenPerdida)
                            {
                                case "":
                                    CantidadBobBuenaLithoman++;
                                    break;
                                case "PROVEEDOR":
                                    CantidadBobMalaLithoman++;
                                    KGEscarpeProveedorLithoman += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ROLLERO":
                                    CantidadBobMalaLithoman++;
                                    KGEscarpeRolleroLithoman += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ALMACÉN":
                                    CantidadBobMalaLithoman++;
                                    KGEscarpeAlmacenLithoman += Convert.ToInt32(bob.Escarpe);
                                    break;
                                default:
                                    CantidadBobBuenaLithoman++;
                                    break;
                            }
                            #endregion
                            #region BobinaConProyectoLithoman
                            if (Convert.ToInt32(bob.Codigo_Bobina) >= 41469)
                            {
                                BobConProyectoLithoman++;
                                BobKGConProyectoLithoman += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            else
                            {
                                BobSinProyectoLithoman++;
                                BobKGSinProyectoLithoman += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            #endregion
                            break;
                        case "M600":
                            TotalkilosConsumidosM600 += Convert.ToInt32(bob.ConsumoBobina);
                            TotalEscarpeM600 += Convert.ToInt32(bob.Escarpe);
                            CantidadTotalBobinasConsumidaM600++;
                            #region TipoPerdidaM600
                            switch (bob.OrigenPerdida)
                            {
                                case "":
                                    CantidadBobBuenaM600++;
                                    break;
                                case "PROVEEDOR":
                                    CantidadBobMalaM600++;
                                    KGEscarpeProveedorM600 += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ROLLERO":
                                    CantidadBobMalaM600++;
                                    KGEscarpeRolleroM600 += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ALMACÉN":
                                    CantidadBobMalaM600++;
                                    KGEscarpeAlmacenM600 += Convert.ToInt32(bob.Escarpe);
                                    break;
                                default:
                                    CantidadBobBuenaM600++;
                                    break;
                            }
                            #endregion
                            #region BobinaConProyectoM600
                            if (Convert.ToInt32(bob.Codigo_Bobina) >= 41469)
                            {
                                BobConProyectoM600++;
                                BobKGConProyectoM600 += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            else
                            {
                                BobSinProyectoM600++;
                                BobKGSinProyectoM600 += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            #endregion
                            break;
                        case "WEB 1":
                            TotalkilosConsumidosWeb1 += Convert.ToInt32(bob.ConsumoBobina);
                            TotalEscarpeWeb1 += Convert.ToInt32(bob.Escarpe);
                            CantidadTotalBobinasConsumidaWeb1++;
                            #region TipoPerdidaWeb1
                            switch (bob.OrigenPerdida)
                            {
                                case "":
                                    CantidadBobBuenaWeb1++;
                                    break;
                                case "PROVEEDOR":
                                    CantidadBobMalaWeb1++;
                                    KGEscarpeProveedorWeb1 += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ROLLERO":
                                    CantidadBobMalaWeb1++;
                                    KGEscarpeRolleroWeb1 += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ALMACÉN":
                                    CantidadBobMalaWeb1++;
                                    KGEscarpeAlmacenWeb1 += Convert.ToInt32(bob.Escarpe);
                                    break;
                                default:
                                    CantidadBobBuenaWeb1++;
                                    break;
                            }
                            #endregion
                            #region BobinaConProyectoWeb1
                            if (Convert.ToInt32(bob.Codigo_Bobina) >= 41469)
                            {
                                BobConProyectoWeb1++;
                                BobKGConProyectoWeb1 += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            else
                            {
                                BobSinProyectoWeb1++;
                                BobKGSinProyectoWeb1 += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            #endregion
                            break;
                        case "WEB 2":
                            TotalkilosConsumidosWeb2 += Convert.ToInt32(bob.ConsumoBobina);
                            TotalEscarpeWeb2 += Convert.ToInt32(bob.Escarpe);
                            CantidadTotalBobinasConsumidaWeb2++;
                            #region TipoPerdidaWeb2
                            switch (bob.OrigenPerdida)
                            {
                                case "":
                                    CantidadBobBuenaWeb2++;
                                    break;
                                case "PROVEEDOR":
                                    CantidadBobMalaWeb2++;
                                    KGEscarpeProveedorWeb2 += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ROLLERO":
                                    CantidadBobMalaWeb2++;
                                    KGEscarpeRolleroWeb2 += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ALMACÉN":
                                    CantidadBobMalaWeb2++;
                                    KGEscarpeAlmacenWeb2 += Convert.ToInt32(bob.Escarpe);
                                    break;
                                default:
                                    CantidadBobBuenaWeb2++;
                                    break;
                            }
                            #endregion
                            #region BobinaConProyectoWeb2
                            if (Convert.ToInt32(bob.Codigo_Bobina) >= 41469)
                            {
                                BobConProyectoWeb2++;
                                BobKGConProyectoWeb2 += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            else
                            {
                                BobSinProyectoWeb2++;
                                BobKGSinProyectoWeb2 += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            #endregion
                            break;
                        case "GOSS":
                            TotalkilosConsumidosGoss += Convert.ToInt32(bob.ConsumoBobina);
                            TotalEscarpeGoss += Convert.ToInt32(bob.Escarpe);
                            CantidadTotalBobinasConsumidaGoss++;
                            #region TipoPerdidaGoss
                            switch (bob.OrigenPerdida)
                            {
                                case "":
                                    CantidadBobBuenaGoss++;
                                    break;
                                case "PROVEEDOR":
                                    CantidadBobMalaGoss++;
                                    KGEscarpeProveedorGoss += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ROLLERO":
                                    CantidadBobMalaGoss++;
                                    KGEscarpeRolleroGoss += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ALMACÉN":
                                    CantidadBobMalaGoss++;
                                    KGEscarpeAlmacenGoss += Convert.ToInt32(bob.Escarpe);
                                    break;
                                default:
                                    CantidadBobBuenaGoss++;
                                    break;
                            }
                            #endregion
                            #region BobinaConProyectoGoss
                            if (Convert.ToInt32(bob.Codigo_Bobina) >= 41469)
                            {
                                BobConProyectoGoss++;
                                BobKGConProyectoGoss += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            else
                            {
                                BobSinProyectoGoss++;
                                BobKGSinProyectoGoss += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            #endregion
                            break;
                        case "DIMENSIONADORA":
                            TotalkilosConsumidosDimensionadora += Convert.ToInt32(bob.ConsumoBobina);
                            TotalEscarpeDimensionadora += Convert.ToInt32(bob.Escarpe);
                            CantidadTotalBobinasConsumidaDimensionadora++;
                            #region TipoPerdidaDimensionadora
                            switch (bob.OrigenPerdida)
                            {
                                case "":
                                    CantidadBobBuenaDimensionadora++;
                                    break;
                                case "PROVEEDOR":
                                    CantidadBobMalaDimensionadora++;
                                    KGEscarpeProveedorDimensionadora += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ROLLERO":
                                    CantidadBobMalaDimensionadora++;
                                    KGEscarpeRolleroDimensionadora += Convert.ToInt32(bob.Escarpe);
                                    break;
                                case "ALMACÉN":
                                    CantidadBobMalaDimensionadora++;
                                    KGEscarpeAlmacenDimensionadora += Convert.ToInt32(bob.Escarpe);
                                    break;
                                default:
                                    CantidadBobBuenaDimensionadora++;
                                    break;
                            }
                            #endregion
                            #region BobinaConProyectoDimensionadora
                            if (Convert.ToInt32(bob.Codigo_Bobina) >= 41469)
                            {
                                BobConProyectoDimensionadora++;
                                BobKGConProyectoDimensionadora += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            else
                            {
                                BobSinProyectoDimensionadora++;
                                BobKGSinProyectoDimensionadora += Convert.ToInt32(bob.ConsumoBobina);
                            }
                            #endregion
                            break;
                    }
                }

            }
            #region Promedio Escarpe por bobina - kg
            string PromedioEscLithoman = "0.00";
            if (CantidadTotalBobinasConsumidaLithoman > 0)
            {
                PromedioEscLithoman = (Convert.ToDouble(TotalEscarpeLithoman) / Convert.ToDouble(CantidadTotalBobinasConsumidaLithoman)).ToString("N2");
            }
            string PromedioEscM600 = "0.00";
            if (CantidadTotalBobinasConsumidaM600 > 0)
            {
                PromedioEscM600 = (Convert.ToDouble(TotalEscarpeM600) / Convert.ToDouble(CantidadTotalBobinasConsumidaM600)).ToString("N2");
            }
            string PromedioEscWeb1 = "0.00";
            if (CantidadTotalBobinasConsumidaWeb1 > 0)
            {
                PromedioEscWeb1 = (Convert.ToDouble(TotalEscarpeWeb1) / Convert.ToDouble(CantidadTotalBobinasConsumidaWeb1)).ToString("N2");
            }
            string PromedioEscWeb2 = "0.00";
            if (CantidadTotalBobinasConsumidaWeb2 > 0)
            {
                PromedioEscWeb2 = (Convert.ToDouble(TotalEscarpeWeb2) / Convert.ToDouble(CantidadTotalBobinasConsumidaWeb2)).ToString("N2");
            }
            string PromedioEscGoss = "0.00";
            if (CantidadTotalBobinasConsumidaGoss > 0)
            {
                PromedioEscGoss = (Convert.ToDouble(TotalEscarpeGoss) / Convert.ToDouble(CantidadTotalBobinasConsumidaGoss)).ToString("N2");
            }
            string PromedioEscDimensionadora = "0.00";
            if (CantidadTotalBobinasConsumidaDimensionadora > 0)
            {
                PromedioEscDimensionadora = (Convert.ToDouble(TotalEscarpeDimensionadora) / Convert.ToDouble(CantidadTotalBobinasConsumidaDimensionadora)).ToString("N2");
            }
            string PromedioEsc = "0.00";
            if (CantidadTotalBobinasConsumida> 0)
            {
                PromedioEsc = (Convert.ToDouble(TotalEscarpe) / Convert.ToDouble(CantidadTotalBobinasConsumida)).ToString("N2");
            }
            #endregion

            #region % Total Porcentaje  Escarpe
            string PorcentajeEscLithoman = "0.00%";
            if (CantidadTotalBobinasConsumidaLithoman > 0)
            {
                PorcentajeEscLithoman = ((Convert.ToDouble(TotalEscarpeLithoman) / Convert.ToDouble(TotalkilosConsumidosLithoman))*100).ToString("N2") + "%";
            }
            string PorcentajeEscM600 = "0.00%";
            if (CantidadTotalBobinasConsumidaM600 > 0)
            {
                PorcentajeEscM600 = ((Convert.ToDouble(TotalEscarpeM600) / Convert.ToDouble(TotalkilosConsumidosM600))*100).ToString("N2") + "%";
            }
            string PorcentajeEscWeb1 = "0.00%";
            if (CantidadTotalBobinasConsumidaWeb1 > 0)
            {
                PorcentajeEscWeb1 = ((Convert.ToDouble(TotalEscarpeWeb1) / Convert.ToDouble(TotalkilosConsumidosWeb1))*100).ToString("N2") + "%";
            }
            string PorcentajeEscWeb2 = "0.00%";
            if (CantidadTotalBobinasConsumidaWeb2 > 0)
            {
                PorcentajeEscWeb2 = ((Convert.ToDouble(TotalEscarpeWeb2) / Convert.ToDouble(TotalkilosConsumidosWeb2))*100).ToString("N2") + "%";
            }
            string PorcentajeEscGoss = "0.00%";
            if (CantidadTotalBobinasConsumidaGoss > 0)
            {
                PorcentajeEscGoss = ((Convert.ToDouble(TotalEscarpeGoss) / Convert.ToDouble(TotalkilosConsumidosGoss))*100).ToString("N2") + "%";
            }
            string PorcentajeEscDimensionadora = "0.00%";
            if (CantidadTotalBobinasConsumidaDimensionadora > 0)
            {
                PorcentajeEscDimensionadora = ((Convert.ToDouble(TotalEscarpeDimensionadora) / Convert.ToDouble(TotalkilosConsumidosDimensionadora))*100).ToString("N2") + "%";
            }
            string PorcentajeEsc = "0.00%";
            if (CantidadTotalBobinasConsumida > 0)
            {
                PorcentajeEsc = ((Convert.ToDouble(TotalEscarpe) / Convert.ToDouble(TotalkilosConsumidos))*100).ToString("N2") + "%";
            }
            #endregion

            #region %Escarpe Daño Almacen
            string Porce_DañoAlmacenLithoman = "0.00%";
            if (KGEscarpeAlmacenLithoman > 0)
            {
                Porce_DañoAlmacenLithoman = ((Convert.ToDouble(KGEscarpeAlmacenLithoman) / Convert.ToDouble(TotalEscarpeLithoman))*100).ToString("N2") + "%";
            }
            string Porce_DañoAlmacenM600 = "0.00%";
            if (KGEscarpeAlmacenM600 > 0)
            {
                Porce_DañoAlmacenM600 = ((Convert.ToDouble(KGEscarpeAlmacenM600) / Convert.ToDouble(TotalEscarpeM600))*100).ToString("N2") + "%";
            } 
            string Porce_DañoAlmacenWeb1 = "0.00%";
            if (KGEscarpeAlmacenWeb1 > 0)
            {
                Porce_DañoAlmacenWeb1 = ((Convert.ToDouble(KGEscarpeAlmacenWeb1) / Convert.ToDouble(TotalEscarpeWeb1))*100).ToString("N2") + "%";
            }
            string Porce_DañoAlmacenWeb2 = "0.00%";
            if (KGEscarpeAlmacenWeb2 > 0)
            {
                Porce_DañoAlmacenWeb2 = ((Convert.ToDouble(KGEscarpeAlmacenWeb2) / Convert.ToDouble(TotalEscarpeWeb2))*100).ToString("N2") + "%";
            }
            string Porce_DañoAlmacenGoss = "0.00%";
            if (KGEscarpeAlmacenGoss > 0)
            {
                Porce_DañoAlmacenGoss = ((Convert.ToDouble(KGEscarpeAlmacenGoss) / Convert.ToDouble(TotalEscarpeGoss))*100).ToString("N2") + "%";
            }
            string Porce_DañoAlmacenDimensionadora = "0.00%";
            if (KGEscarpeAlmacenDimensionadora > 0)
            {
                Porce_DañoAlmacenDimensionadora = ((Convert.ToDouble(KGEscarpeAlmacenDimensionadora) / Convert.ToDouble(TotalEscarpeDimensionadora))*100).ToString("N2") + "%";
            }
            string Porce_DañoAlmacen = "0.00%";
            if (KGEscarpeAlmacen > 0)
            {
                Porce_DañoAlmacen = ((Convert.ToDouble(KGEscarpeAlmacen) / Convert.ToDouble(TotalEscarpe))*100).ToString("N2") + "%";
            }
            #endregion

            #region %Escarpe Daño Rollero
            string Porce_DañoRolleroLithoman = "0.00%";
            if (KGEscarpeRolleroLithoman > 0)
            {
                Porce_DañoRolleroLithoman = ((Convert.ToDouble(KGEscarpeRolleroLithoman) / Convert.ToDouble(TotalEscarpeLithoman))*100).ToString("N2") + "%";
            }
            string Porce_DañoRolleroM600 = "0.00%";
            if (KGEscarpeRolleroM600 > 0)
            {
                Porce_DañoRolleroM600 = ((Convert.ToDouble(KGEscarpeRolleroM600) / Convert.ToDouble(TotalEscarpeM600))*100).ToString("N2") + "%";
            }
            string Porce_DañoRolleroWeb1 = "0.00%";
            if (KGEscarpeRolleroWeb1 > 0)
            {
                Porce_DañoRolleroWeb1 = ((Convert.ToDouble(KGEscarpeRolleroWeb1) / Convert.ToDouble(TotalEscarpeWeb1))*100).ToString("N2") + "%";
            }
            string Porce_DañoRolleroWeb2 = "0.00%";
            if (KGEscarpeRolleroWeb2 > 0)
            {
                Porce_DañoRolleroWeb2 = ((Convert.ToDouble(KGEscarpeRolleroWeb2) / Convert.ToDouble(TotalEscarpeWeb2))*100).ToString("N2") + "%";
            }
            string Porce_DañoRolleroGoss = "0.00%";
            if (KGEscarpeRolleroGoss > 0)
            {
                Porce_DañoRolleroGoss = ((Convert.ToDouble(KGEscarpeRolleroGoss) / Convert.ToDouble(TotalEscarpeGoss))*100).ToString("N2") + "%";
            }
            string Porce_DañoRolleroDimensionadora = "0.00%";
            if (KGEscarpeRolleroDimensionadora > 0)
            {
                Porce_DañoRolleroDimensionadora = ((Convert.ToDouble(KGEscarpeRolleroDimensionadora) / Convert.ToDouble(TotalEscarpeDimensionadora))*100).ToString("N2") + "%";
            }
            string Porce_DañoRollero = "0.00%";
            if (KGEscarpeRollero > 0)
            {
                Porce_DañoRollero = ((Convert.ToDouble(KGEscarpeRollero) / Convert.ToDouble(TotalEscarpe))*100).ToString("N2") + "%";
            }
            #endregion

            #region %Escarpe Daño Proveedor
            string Porce_DañoProveedorLithoman = "0.00%";
            if (KGEscarpeProveedorLithoman > 0)
            {
                Porce_DañoProveedorLithoman = ((Convert.ToDouble(KGEscarpeProveedorLithoman) / Convert.ToDouble(TotalEscarpeLithoman))*100).ToString("N2") + "%";
            }
            string Porce_DañoProveedorM600 = "0.00%";
            if (KGEscarpeProveedorM600 > 0)
            {
                Porce_DañoProveedorM600 = ((Convert.ToDouble(KGEscarpeProveedorM600) / Convert.ToDouble(TotalEscarpeM600))*100).ToString("N2") + "%";
            }
            string Porce_DañoProveedorWeb1 = "0.00%";
            if (KGEscarpeProveedorWeb1 > 0)
            {
                Porce_DañoProveedorWeb1 = ((Convert.ToDouble(KGEscarpeProveedorWeb1) / Convert.ToDouble(TotalEscarpeWeb1))*100).ToString("N2") + "%";
            }
            string Porce_DañoProveedorWeb2 = "0.00%";
            if (KGEscarpeProveedorWeb2 > 0)
            {
                Porce_DañoProveedorWeb2 = ((Convert.ToDouble(KGEscarpeProveedorWeb2) / Convert.ToDouble(TotalEscarpeWeb2))*100).ToString("N2") + "%";
            }
            string Porce_DañoProveedorGoss = "0.00%";
            if (KGEscarpeProveedorGoss > 0)
            {
                Porce_DañoProveedorGoss = ((Convert.ToDouble(KGEscarpeProveedorGoss) / Convert.ToDouble(TotalEscarpeGoss))*100).ToString("N2") + "%";
            }
            string Porce_DañoProveedorDimensionadora = "0.00%";
            if (KGEscarpeProveedorDimensionadora > 0)
            {
                Porce_DañoProveedorDimensionadora = ((Convert.ToDouble(KGEscarpeProveedorDimensionadora) / Convert.ToDouble(TotalEscarpeDimensionadora))*100).ToString("N2") + "%";
            }
            string Porce_DañoProveedor = "0.00%";
            if (KGEscarpeProveedor > 0)
            {
                Porce_DañoProveedor = ((Convert.ToDouble(KGEscarpeProveedor) / Convert.ToDouble(TotalEscarpe))*100).ToString("N2") + "%";
            }
            #endregion

            stgTotalBobinasConsumidas = "<tr><th>Total Bobinas Consumidas</th>" +
                                          "<td style='text-align:right;'>" + CantidadTotalBobinasConsumidaLithoman + "</td>" +
                                          "<td style='text-align:right;'>" + CantidadTotalBobinasConsumidaM600 + "</td>" +
                                          "<td style='text-align:right;'>" + CantidadTotalBobinasConsumidaWeb1 + "</td>" +
                                          "<td style='text-align:right;'>" + CantidadTotalBobinasConsumidaWeb2 + "</td>" +
                                          "<td style='text-align:right;'>" + CantidadTotalBobinasConsumidaGoss + "</td>" +
                                          "<td style='text-align:right;'>" + CantidadTotalBobinasConsumidaDimensionadora + "</td>" +
                                          "<td style='text-align:right;'>" + CantidadTotalBobinasConsumida + "</td>" +
                                          "</tr>";
            stgTotalkilosConsumidos = "<tr><th>Total KG Consumido</th>" +
                                          "<td style='text-align:right;'>" + TotalkilosConsumidosLithoman + "</td>" +
                                          "<td style='text-align:right;'>" + TotalkilosConsumidosM600 + "</td>" +
                                          "<td style='text-align:right;'>" + TotalkilosConsumidosWeb1 + "</td>" +
                                          "<td style='text-align:right;'>" + TotalkilosConsumidosWeb2 + "</td>" +
                                          "<td style='text-align:right;'>" + TotalkilosConsumidosGoss + "</td>" +
                                          "<td style='text-align:right;'>" + TotalkilosConsumidosDimensionadora + "</td>" +
                                          "<td style='text-align:right;'>" + TotalkilosConsumidos + "</td>" +
                                          "</tr>";
            stgTotalkilosEscarpe = "<tr><th>Total KG Escarpe </th>" +
                                          "<td style='text-align:right;'>" + TotalEscarpeLithoman + "</td>" +
                                          "<td style='text-align:right;'>" + TotalEscarpeM600 + "</td>" +
                                          "<td style='text-align:right;'>" + TotalEscarpeWeb1 + "</td>" +
                                          "<td style='text-align:right;'>" + TotalEscarpeWeb2 + "</td>" +
                                          "<td style='text-align:right;'>" + TotalEscarpeGoss + "</td>" +
                                          "<td style='text-align:right;'>" + TotalEscarpeDimensionadora + "</td>" +
                                          "<td style='text-align:right;'>" + TotalEscarpe + "</td>" +
                                          "</tr>";
            stgPromedioEscarpexbobina = "<tr><th>Promedio Escarpe por bobina - kg </th>" +
                                          "<td style='text-align:right;'>" + PromedioEscLithoman + "</td>" +
                                          "<td style='text-align:right;'>" + PromedioEscM600 + "</td>" +
                                          "<td style='text-align:right;'>" + PromedioEscWeb1 + "</td>" +
                                          "<td style='text-align:right;'>" + PromedioEscWeb2 + "</td>" +
                                          "<td style='text-align:right;'>" + PromedioEscGoss + "</td>" +
                                          "<td style='text-align:right;'>" + PromedioEscDimensionadora + "</td>" +
                                          "<td style='text-align:right;'>" + PromedioEsc + "</td>" +
                                          "</tr>";
            stgPorcentajeescarpe = "<tr><th> % Total Porcentaje  Escarpe</th>" +
                                          "<td style='text-align:right;'>" + PorcentajeEscLithoman + "</td>" +
                                          "<td style='text-align:right;'>" + PorcentajeEscM600 + "</td>" +
                                          "<td style='text-align:right;'>" + PorcentajeEscWeb1+ "</td>" +
                                          "<td style='text-align:right;'>" + PorcentajeEscWeb2 + "</td>" +
                                          "<td style='text-align:right;'>" + PorcentajeEscGoss + "</td>" +
                                          "<td style='text-align:right;'>" + PorcentajeEscDimensionadora + "</td>" +
                                          "<td style='text-align:right;'>" + PorcentajeEsc + "</td></tr>";

            stgBobinasBuenas = "<tr><th>Bobinas Buenas</th>" +
                                        "<td style='text-align:right;'>" + CantidadBobBuenaLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobBuenaM600 + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobBuenaWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobBuenaWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobBuenaGoss + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobBuenaDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobBuena + "</td>" +
                                        "</tr>";
            stgBobinasMalas = "<tr><th>Bobinas Malas</th>" +
                                        "<td style='text-align:right;'>" + CantidadBobMalaLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobMalaM600 + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobMalaWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobMalaWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobMalaGoss + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobMalaDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + CantidadBobMala + "</td>" +
                                        "</tr>";
            string stgBobinasConProyecto = "<tr><th>Bobinas Con Proyecto</th>" +
                                        "<td style='text-align:right;'>" + BobConProyectoLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + BobConProyectoM600 + "</td>" +
                                        "<td style='text-align:right;'>" + BobConProyectoWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + BobConProyectoWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + BobConProyectoGoss + "</td>" +
                                        "<td style='text-align:right;'>" + BobConProyectoDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + BobConProyecto + "</td>" +
                                        "</tr>" +
                                        "<tr><th>KG Con Proyecto</th>" +
                                        "<td style='text-align:right;'>" + BobKGConProyectoLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGConProyectoM600 + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGConProyectoWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGConProyectoWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGConProyectoGoss + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGConProyectoDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGConProyecto + "</td>" +
                                        "</tr>";
            string stgBobinasSinProyecto = "<tr><th>Bobinas Sin Proyecto</th>" +
                                        "<td style='text-align:right;'>" + BobSinProyectoLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + BobSinProyectoM600 + "</td>" +
                                        "<td style='text-align:right;'>" + BobSinProyectoWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + BobSinProyectoWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + BobSinProyectoGoss + "</td>" +
                                        "<td style='text-align:right;'>" + BobSinProyectoDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + BobSinProyecto + "</td>" +
                                        "</tr>" +
                                        "<tr><th>KG Sin Proyecto</th>" +
                                        "<td style='text-align:right;'>" + BobKGSinProyectoLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGSinProyectoM600 + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGSinProyectoWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGSinProyectoWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGSinProyectoGoss + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGSinProyectoDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + BobKGSinProyecto + "</td>" +
                                        "</tr>";
            stgKGEscarpeAlmacen = "<tr><th>Kg Escarpe Daño Almacen</th>" +
                                        "<td style='text-align:right;'>" + KGEscarpeAlmacenLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeAlmacenM600 + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeAlmacenWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeAlmacenWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeAlmacenGoss + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeAlmacenDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeAlmacen + "</td>" +
                                        "</tr>" +
                                        "<tr><th>% Escarpe Daño Almacen</th>" +
                                        "<td style='text-align:right;'>" + Porce_DañoAlmacenLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoAlmacenM600 + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoAlmacenWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoAlmacenWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoAlmacenGoss + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoAlmacenDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoAlmacen + "</td>" +
                                        "</tr>";

            stgKGEscarpeRollero = "<tr><th>Kg Escarpe Daño Rollero</th>" +
                                        "<td style='text-align:right;'>" + KGEscarpeRolleroLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeRolleroM600 + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeRolleroWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeRolleroWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeRolleroGoss + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeRolleroDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeRollero + "</td>" +
                                        "</tr>" +
                                        "<tr><th>% Escarpe Daño Rollero</th>" +
                                        "<td style='text-align:right;'>" + Porce_DañoRolleroLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoRolleroM600 + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoRolleroWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoRolleroWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoRolleroGoss + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoRolleroDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoRollero + "</td>" +
                                        "</tr>";

            stgKGEscarpeProveedor = "<tr><th>Kg Escarpe Daño Proveedor</th>" +
                                        "<td style='text-align:right;'>" + KGEscarpeProveedorLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeProveedorM600 + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeProveedorWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeProveedorWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeProveedorGoss + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeProveedorDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + KGEscarpeProveedor + "</td>" +
                                        "</tr>" +
                                        "<tr><th>% Escarpe Daño Proveedor</th>" +
                                        "<td style='text-align:right;'>" + Porce_DañoProveedorLithoman + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoProveedorM600 + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoProveedorWeb1 + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoProveedorWeb2 + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoProveedorGoss + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoProveedorDimensionadora + "</td>" +
                                        "<td style='text-align:right;'>" + Porce_DañoProveedor + "</td>" +
                                        "</tr>";
            Tabla += stgTotalBobinasConsumidas + stgTotalkilosConsumidos + stgTotalkilosEscarpe + stgPromedioEscarpexbobina + stgPorcentajeescarpe + stgBobinasBuenas + stgBobinasMalas + stgBobinasConProyecto +
                     stgBobinasSinProyecto + stgKGEscarpeAlmacen + stgKGEscarpeRollero + stgKGEscarpeProveedor;
            return Tabla;
        }
        public string TablaInforme_V2(List<Bobina_ConsumoLinea_V2> lista)
        {
            #region EncabezadoyVariables
            string Tabla = "<table style='width: 100%;' class='table table-hover table-bordered table-striped'>" +
                            "<thead><tr class='filters'>" +
                        "<th>#</th>" +
                        "<th>Lithoman</th>" +
                        "<th>M600</th>" +
                        "<th>Web 1</th>" +
                        "<th>Web 2</th>" +
                        "<th>Goss</th>" +
                        "<th>Dimensionadora</th>" +
                        "<th>Total</th>" +
                    "</tr>" +
                "</thead>";
            string stgTotalBobinasConsumidas = "";  string stgTotalkilosConsumidos = "";   string stgTotalkilosEscarpe = ""; string stgPromedioEscarpexbobina = ""; string stgPorcentajeescarpe = "";
            string stgBobinasBuenas = ""; string stgBobinasMalas = ""; string stgKGEscarpeAlmacen = ""; string stgKGEscarpeRollero = "";string stgKGEscarpeProveedor = "";
            double TotalBobinasLithoman = 0; double TotalBobinasM600 = 0; double TotalBobinasWeb1 = 0; double TotalBobinasWeb2 = 0; double TotalBobinasGoss = 0;double TotalBobinasDimensionadora=0; double TotalBobinas = 0;
            double KGConsumidoLithoman = 0; double KGConsumidoM600 = 0; double KGConsumidoWeb1 = 0; double KGConsumidoWeb2 = 0; double KGConsumidoGoss = 0; double KGConsumidoDimensionadora = 0; double KGConsumidoTOTAL = 0;
            double EscarpeLithoman = 0; double EscarpeM600 = 0; double EscarpeWeb1 = 0; double EscarpeWeb2 = 0; double EscarpeGoss = 0; double EscarpeDimensionadora = 0; double EscarpeTotal = 0;
            double PromEscarpeLithoman = 0; double PromEscarpeM600 = 0; double PromEscarpeWeb1 = 0; double PromEscarpeWeb2 = 0; double PromEscarpeGoss = 0; double PromEscarpeDimensionadora = 0; double PromEscarpeTotal = 0;
            double PorcsEscarpeLithoman = 0; double PorcsEscarpeM600 = 0; double PorcsEscarpeWeb1 = 0; double PorcsEscarpeWeb2 = 0; double PorcsEscarpeGoss = 0; double PorcsEscarpeDimensionadora = 0; double PorcsEscarpeTotal = 0;
            double BobinasBuenasLithoman = 0; double BobinasBuenasM600 = 0; double BobinasBuenasWeb1 = 0; double BobinasBuenasWeb2 = 0; double BobinasBuenasGoss = 0; double BobinasBuenasDimensionadora = 0; double BobinasBuenasTotal = 0;
            double BobinasMalasLithoman = 0; double BobinasMalasM600 = 0; double BobinasMalasWeb1 = 0; double BobinasMalasWeb2 = 0; double BobinasMalasGoss = 0; double BobinasMalasDimensionadora = 0; double BobinasMalasTotal = 0;
            double ConProyectoLithoman = 0; double ConProyectoM600 = 0; double ConProyectoWeb1 = 0; double ConProyectoWeb2 = 0; double ConProyectoGoss = 0; double ConProyectoDimensionadora = 0; double ConProyectoTotal = 0;
            double KGConProyectoLithoman = 0; double KGConProyectoM600 = 0; double KGConProyectoWeb1 = 0; double KGConProyectoWeb2 = 0; double KGConProyectoGoss = 0; double KGConProyectoDimensionadora = 0; double KGConProyectoTotal = 0;
            double SinProyectoLithoman = 0; double SinProyectoM600 = 0; double SinProyectoWeb1 = 0; double SinProyectoWeb2 = 0; double SinProyectoGoss = 0; double SinProyectoDimensionadora = 0; double SinProyectoTotal = 0;
            double KGSinProyectoLithoman = 0; double KGSinProyectoM600 = 0; double KGSinProyectoWeb1 = 0; double KGSinProyectoWeb2 = 0; double KGSinProyectoGoss = 0; double KGSinProyectoDimensionadora = 0; double KGSinProyectoTotal = 0;
            double KGAlmacenLithoman = 0; double KGAlmacenM600 = 0; double KGAlmacenWeb1 = 0; double KGAlmacenWeb2 = 0; double KGAlmacenGoss = 0; double KGAlmacenDimensionadora = 0; double KGAlmacenTotal = 0;
            double PorcAlmacenLithoman = 0; double PorcAlmacenM600 = 0; double PorcAlmacenWeb1 = 0; double PorcAlmacenWeb2 = 0; double PorcAlmacenGoss = 0; double PorcAlmacenDimensionadora = 0; double PorcAlmacenTotal = 0;
            double KGRolleroLithoman = 0; double KGRolleroM600 = 0; double KGRolleroWeb1 = 0; double KGRolleroWeb2 = 0; double KGRolleroGoss = 0; double KGRolleroDimensionadora = 0; double KGRolleroTotal = 0;
            double PorcRolleroLithoman = 0; double PorcRolleroM600 = 0; double PorcRolleroWeb1 = 0; double PorcRolleroWeb2 = 0; double PorcRolleroGoss = 0; double PorcRolleroDimensionadora = 0; double PorcRolleroTotal = 0;
            double KGProveedorLithoman = 0; double KGProveedorM600 = 0; double KGProveedorWeb1 = 0; double KGProveedorWeb2 = 0; double KGProveedorGoss = 0; double KGProveedorDimensionadora = 0; double KGProveedorTotal = 0;
            double PorcProveedorLithoman = 0; double PorcProveedorM600 = 0; double PorcProveedorWeb1 = 0; double PorcProveedorWeb2 = 0; double PorcProveedorGoss = 0; double PorcProveedorDimensionadora = 0; double PorcProveedorTotal = 0;
            foreach (string Maquina in lista.Select(o => o.Maquina).Distinct())
            {
                foreach (Bobina_ConsumoLinea_V2 bob in lista.Where(o => o.Maquina == Maquina))
                {
                    switch (bob.Maquina)
                    {
                        case "DIMENSIONADORA":
                            TotalBobinasDimensionadora = bob.TotalBobinasConsumidas;
                            KGConsumidoDimensionadora = bob.TotalKGConsumido;
                            EscarpeDimensionadora = bob.TotalKGEscarpe;
                            PromEscarpeDimensionadora = bob.PromedioEscarpe;
                            PorcsEscarpeDimensionadora = bob.PorcentajeEscarpe;
                            BobinasBuenasDimensionadora = bob.BobinasBuenas;
                            BobinasMalasDimensionadora = bob.BobinasMalas;
                            ConProyectoDimensionadora = bob.BobinasConProyecto;
                            KGConProyectoDimensionadora = bob.KGConProyecto;
                            SinProyectoDimensionadora = bob.BobinasSinProyecto;
                            KGSinProyectoDimensionadora = bob.KGSinProyecto;
                            KGAlmacenDimensionadora = bob.DanoAlmacen;
                            PorcAlmacenDimensionadora = bob.PorcDanoAlmacen;
                            KGRolleroDimensionadora = bob.DanoRollero;
                            PorcRolleroDimensionadora = bob.PorcDanoRollero;
                            KGProveedorDimensionadora = bob.DanoProveedor;
                            PorcProveedorDimensionadora = bob.PorcDanoProveedor;
                            break;
                        case "GOSS C150":
                            TotalBobinasGoss = bob.TotalBobinasConsumidas;
                            KGConsumidoGoss = bob.TotalKGConsumido;
                            EscarpeGoss = bob.TotalKGEscarpe;
                            PromEscarpeGoss = bob.PromedioEscarpe;
                            PorcsEscarpeGoss = bob.PorcentajeEscarpe;
                            BobinasBuenasGoss = bob.BobinasBuenas;
                            BobinasMalasGoss = bob.BobinasMalas;
                            ConProyectoGoss = bob.BobinasConProyecto;
                            KGConProyectoGoss = bob.KGConProyecto;
                            SinProyectoGoss = bob.BobinasSinProyecto;
                            KGSinProyectoGoss = bob.KGSinProyecto;
                            KGAlmacenGoss = bob.DanoAlmacen;
                            PorcAlmacenGoss = bob.PorcDanoAlmacen;
                            KGRolleroGoss = bob.DanoRollero;
                            PorcRolleroGoss = bob.PorcDanoRollero;
                            KGProveedorGoss = bob.DanoProveedor;
                            PorcProveedorGoss = bob.PorcDanoProveedor;
                            break;
                        case "M600":
                            TotalBobinasM600 = bob.TotalBobinasConsumidas;
                            KGConsumidoM600 = bob.TotalKGConsumido;
                            EscarpeM600 = bob.TotalKGEscarpe;
                            PromEscarpeM600 = bob.PromedioEscarpe;
                            PorcsEscarpeM600 = bob.PorcentajeEscarpe;
                            BobinasBuenasM600 = bob.BobinasBuenas;
                            BobinasMalasM600 = bob.BobinasMalas;
                            ConProyectoM600 = bob.BobinasConProyecto;
                            KGConProyectoM600 = bob.KGConProyecto;
                            SinProyectoM600 = bob.BobinasSinProyecto;
                            KGSinProyectoM600 = bob.KGSinProyecto;
                            KGAlmacenM600 = bob.DanoAlmacen;
                            PorcAlmacenM600 = bob.PorcDanoAlmacen;
                            KGRolleroM600 = bob.DanoRollero;
                            PorcRolleroM600 = bob.PorcDanoRollero;
                            KGProveedorM600 = bob.DanoProveedor;
                            PorcProveedorM600 = bob.PorcDanoProveedor;
                            break;
                        case "LITHOMAN":
                            TotalBobinasLithoman = bob.TotalBobinasConsumidas;
                            KGConsumidoLithoman = bob.TotalKGConsumido;
                            EscarpeLithoman = bob.TotalKGEscarpe;
                            PromEscarpeLithoman = bob.PromedioEscarpe;
                            PorcsEscarpeLithoman = bob.PorcentajeEscarpe;
                            BobinasBuenasLithoman = bob.BobinasBuenas;
                            BobinasMalasLithoman = bob.BobinasMalas;
                            ConProyectoLithoman = bob.BobinasConProyecto;
                            KGConProyectoLithoman = bob.KGConProyecto;
                            SinProyectoLithoman = bob.BobinasSinProyecto;
                            KGSinProyectoLithoman = bob.KGSinProyecto;
                            KGAlmacenLithoman = bob.DanoAlmacen;
                            PorcAlmacenLithoman = bob.PorcDanoAlmacen;
                            KGRolleroLithoman = bob.DanoRollero;
                            PorcRolleroLithoman = bob.PorcDanoRollero;
                            KGProveedorLithoman = bob.DanoProveedor;
                            PorcProveedorLithoman = bob.PorcDanoProveedor;
                            break;
                        case "WEB 1":
                            TotalBobinasWeb1 = bob.TotalBobinasConsumidas;
                            KGConsumidoWeb1 = bob.TotalKGConsumido;
                            EscarpeWeb1 = bob.TotalKGEscarpe;
                            PromEscarpeWeb1 = bob.PromedioEscarpe;
                            PorcsEscarpeWeb1 = bob.PorcentajeEscarpe;
                            BobinasBuenasWeb1 = bob.BobinasBuenas;
                            BobinasMalasWeb1 = bob.BobinasMalas;
                            ConProyectoWeb1 = bob.BobinasConProyecto;
                            KGConProyectoWeb1 = bob.KGConProyecto;
                            SinProyectoWeb1 = bob.BobinasSinProyecto;
                            KGSinProyectoWeb1 = bob.KGSinProyecto;
                            KGAlmacenWeb1 = bob.DanoAlmacen;
                            PorcAlmacenWeb1 = bob.PorcDanoAlmacen;
                            KGRolleroWeb1 = bob.DanoRollero;
                            PorcRolleroWeb1 = bob.PorcDanoRollero;
                            KGProveedorWeb1 = bob.DanoProveedor;
                            PorcProveedorWeb1 = bob.PorcDanoProveedor;
                            break;
                        case "WEB 2":
                            TotalBobinasWeb2 = bob.TotalBobinasConsumidas;
                            KGConsumidoWeb2 = bob.TotalKGConsumido;
                            EscarpeWeb2 = bob.TotalKGEscarpe;
                            PromEscarpeWeb2 = bob.PromedioEscarpe;
                            PorcsEscarpeWeb2 = bob.PorcentajeEscarpe;
                            BobinasBuenasWeb2 = bob.BobinasBuenas;
                            BobinasMalasWeb2 = bob.BobinasMalas;
                            ConProyectoWeb2 = bob.BobinasConProyecto;
                            KGConProyectoWeb2 = bob.KGConProyecto;
                            SinProyectoWeb2 = bob.BobinasSinProyecto;
                            KGSinProyectoWeb2 = bob.KGSinProyecto;
                            KGAlmacenWeb2 = bob.DanoAlmacen;
                            PorcAlmacenWeb2 = bob.PorcDanoAlmacen;
                            KGRolleroWeb2 = bob.DanoRollero;
                            PorcRolleroWeb2 = bob.PorcDanoRollero;
                            KGProveedorWeb2 = bob.DanoProveedor;
                            PorcProveedorWeb2 = bob.PorcDanoProveedor;
                            break;
                        default:
                            break;
                    }
                }

            }
            #endregion
            TotalBobinas = (TotalBobinasLithoman + TotalBobinasM600 + TotalBobinasWeb1 + TotalBobinasWeb2 + TotalBobinasGoss + TotalBobinasDimensionadora);
            KGConsumidoTOTAL = (KGConsumidoLithoman + KGConsumidoM600 + KGConsumidoWeb1 + KGConsumidoWeb2 + KGConsumidoGoss + KGConsumidoDimensionadora);
            EscarpeTotal = (EscarpeLithoman + EscarpeM600 + EscarpeWeb1 + EscarpeWeb2 + EscarpeGoss + EscarpeDimensionadora);
            PromEscarpeTotal = (EscarpeTotal / TotalBobinas);
            PorcsEscarpeTotal = ((EscarpeTotal * 100) / KGConsumidoTOTAL);
            BobinasBuenasTotal = (BobinasBuenasLithoman + BobinasBuenasM600 + BobinasBuenasWeb1 + BobinasBuenasWeb2 + BobinasBuenasGoss + BobinasBuenasDimensionadora);
            BobinasMalasTotal = (BobinasMalasLithoman + BobinasMalasM600 + BobinasMalasWeb1 + BobinasMalasWeb2 + BobinasMalasGoss + BobinasMalasDimensionadora);
            ConProyectoTotal = (ConProyectoLithoman + ConProyectoM600 + ConProyectoWeb1 + ConProyectoWeb2 + ConProyectoGoss + ConProyectoDimensionadora);
            KGConProyectoTotal = (KGConProyectoLithoman + KGConProyectoM600 + KGConProyectoWeb1 + KGConProyectoWeb2 + KGConProyectoGoss + KGConProyectoDimensionadora);
            SinProyectoTotal = (SinProyectoLithoman + SinProyectoM600 + SinProyectoWeb1 + SinProyectoWeb2 + SinProyectoGoss + SinProyectoDimensionadora);
            KGSinProyectoTotal = (KGSinProyectoLithoman + KGSinProyectoM600 + KGSinProyectoWeb1 + KGSinProyectoWeb2 + KGSinProyectoGoss + KGSinProyectoDimensionadora);
            KGAlmacenTotal = (KGAlmacenLithoman + KGAlmacenM600 + KGAlmacenWeb1 + KGAlmacenWeb2 + KGAlmacenGoss + KGAlmacenDimensionadora);
            PorcAlmacenTotal = ((KGAlmacenTotal * 100) / EscarpeTotal);
            KGRolleroTotal = (KGRolleroLithoman + KGRolleroM600 + KGRolleroWeb1 + KGRolleroWeb2 + KGRolleroGoss + KGRolleroDimensionadora);
            PorcRolleroTotal = ((KGRolleroTotal * 100) / EscarpeTotal);
            KGProveedorTotal = (KGProveedorLithoman + KGProveedorM600 + KGProveedorWeb1 + KGProveedorWeb2 + KGProveedorGoss + KGProveedorDimensionadora);
            PorcProveedorTotal = ((KGProveedorTotal * 100) / EscarpeTotal);



            stgTotalBobinasConsumidas = "<tr><th>Total Bobinas Consumidas</th>" +
                                          "<td style='text-align:right;'>" + TotalBobinasLithoman.ToString("N0").Replace(",",".") +"</td>" +
                                          "<td style='text-align:right;'>" + TotalBobinasM600.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + TotalBobinasWeb1.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + TotalBobinasWeb2.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + TotalBobinasGoss.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + TotalBobinasDimensionadora.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + TotalBobinas.ToString("N0").Replace(",", ".") + "</td>" +
                                          "</tr>";
            stgTotalkilosConsumidos = "<tr><th>Total KG Consumido</th>" +
                                          "<td style='text-align:right;'>" + KGConsumidoLithoman.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + KGConsumidoM600.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + KGConsumidoWeb1.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + KGConsumidoWeb2.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + KGConsumidoGoss.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + KGConsumidoDimensionadora.ToString("N0").Replace(",", ".") + "</td>" +
                                          "<td style='text-align:right;'>" + KGConsumidoTOTAL.ToString("N0").Replace(",",".") + "</td>" +
                                          "</tr>";
            stgTotalkilosEscarpe = "<tr><th>Total KG Escarpe </th>" +
                                          "<td style='text-align:right;'>" + EscarpeLithoman.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + EscarpeM600.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + EscarpeWeb1.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + EscarpeWeb2.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + EscarpeGoss.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + EscarpeDimensionadora.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + EscarpeTotal.ToString("N2") + "</td>" +
                                          "</tr>";
            stgPromedioEscarpexbobina = "<tr><th>Promedio Escarpe por bobina - kg </th>" +
                                          "<td style='text-align:right;'>" + PromEscarpeLithoman.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + PromEscarpeM600.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + PromEscarpeWeb1.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + PromEscarpeWeb2.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + PromEscarpeGoss.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + PromEscarpeDimensionadora.ToString("N2") + "</td>" +
                                          "<td style='text-align:right;'>" + PromEscarpeTotal.ToString("N2") + "</td>" +
                                          "</tr>";
            stgPorcentajeescarpe = "<tr><th> % Total Porcentaje  Escarpe</th>" +
                                          "<td style='text-align:right;'>" + PorcsEscarpeLithoman.ToString("N2") + "%</td>" +
                                          "<td style='text-align:right;'>" + PorcsEscarpeM600.ToString("N2") + "%</td>" +
                                          "<td style='text-align:right;'>" + PorcsEscarpeWeb1.ToString("N2") + "%</td>" +
                                          "<td style='text-align:right;'>" + PorcsEscarpeWeb2.ToString("N2") + "%</td>" +
                                          "<td style='text-align:right;'>" + PorcsEscarpeGoss.ToString("N2") + "%</td>" +
                                          "<td style='text-align:right;'>" + PorcsEscarpeDimensionadora.ToString("N2") + "%</td>" +
                                          "<td style='text-align:right;'>" + PorcsEscarpeTotal.ToString("N2") + "%</td></tr>";

            stgBobinasBuenas = "<tr><th>Bobinas Buenas</th>" +
                                        "<td style='text-align:right;'>" + BobinasBuenasLithoman.ToString("N0").Replace(",",".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasBuenasM600.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasBuenasWeb1.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasBuenasWeb2.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasBuenasM600.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasBuenasDimensionadora.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasBuenasTotal.ToString("N0").Replace(",", ".") + "</td>" +
                                        "</tr>";
            stgBobinasMalas = "<tr><th>Bobinas Malas</th>" +
                                        "<td style='text-align:right;'>" + BobinasMalasLithoman.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasMalasM600.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasMalasWeb1.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasMalasWeb2.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasMalasGoss.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasMalasDimensionadora.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + BobinasMalasTotal.ToString("N0").Replace(",", ".") + "</td>" +
                                        "</tr>";
            string stgBobinasConProyecto = "<tr><th>Bobinas Con Proyecto</th>" +
                                        "<td style='text-align:right;'>" + ConProyectoLithoman.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + ConProyectoM600.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + ConProyectoWeb1.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + ConProyectoWeb2.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + ConProyectoGoss.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + ConProyectoDimensionadora.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + ConProyectoTotal.ToString("N0").Replace(",", ".") + "</td>" +
                                        "</tr>" +
                                        "<tr><th>KG Con Proyecto</th>" +
                                        "<td style='text-align:right;'>" + KGConProyectoLithoman.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGConProyectoM600.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGConProyectoWeb1.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGConProyectoWeb2.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGConProyectoGoss.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGConProyectoDimensionadora.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGConProyectoTotal.ToString("N2") + "</td>" +
                                        "</tr>";
            string stgBobinasSinProyecto = "<tr><th>Bobinas Sin Proyecto</th>" +
                                        "<td style='text-align:right;'>" + SinProyectoLithoman.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + SinProyectoM600.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + SinProyectoWeb1.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + SinProyectoWeb2.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + SinProyectoGoss.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + SinProyectoDimensionadora.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + SinProyectoTotal.ToString("N0").Replace(",", ".") + "</td>" +
                                        "</tr>" +
                                        "<tr><th>KG Sin Proyecto</th>" +
                                        "<td style='text-align:right;'>" + KGSinProyectoLithoman.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGSinProyectoM600.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGSinProyectoWeb1.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGSinProyectoWeb2.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGSinProyectoGoss.ToString("N0").Replace(",", ".") + "</td>" +
                                        "<td style='text-align:right;'>" + KGSinProyectoDimensionadora.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGSinProyectoTotal.ToString("N2") + "</td>" +
                                        "</tr>";
            stgKGEscarpeAlmacen = "<tr><th>Kg Escarpe Daño Almacen</th>" +
                                        "<td style='text-align:right;'>" + KGAlmacenLithoman.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGAlmacenM600.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGAlmacenWeb1.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGAlmacenWeb2.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGAlmacenGoss.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGAlmacenDimensionadora.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGAlmacenTotal.ToString("N2") + "</td>" +
                                        "</tr>" +
                                        "<tr><th>% Escarpe Daño Almacen</th>" +
                                        "<td style='text-align:right;'>" + PorcAlmacenLithoman.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcAlmacenM600.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcAlmacenWeb1.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcAlmacenWeb2.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcAlmacenGoss.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcAlmacenDimensionadora.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcAlmacenTotal.ToString("N2") + "%</td>" +
                                        "</tr>";

            stgKGEscarpeRollero = "<tr><th>Kg Escarpe Daño Rollero</th>" +
                                        "<td style='text-align:right;'>" + KGRolleroLithoman.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGRolleroM600.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGRolleroWeb1.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGRolleroWeb2.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGRolleroGoss.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGRolleroDimensionadora.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGRolleroTotal.ToString("N2") + "</td>" +
                                        "</tr>" +
                                        "<tr><th>% Escarpe Daño Rollero</th>" +
                                        "<td style='text-align:right;'>" + PorcRolleroLithoman.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcRolleroM600.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcRolleroWeb1.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcRolleroWeb2.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcRolleroGoss.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcRolleroDimensionadora.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcRolleroTotal.ToString("N2") + "%</td>" +
                                        "</tr>";

            stgKGEscarpeProveedor = "<tr><th>Kg Escarpe Daño Proveedor</th>" +
                                        "<td style='text-align:right;'>" + KGProveedorLithoman.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGProveedorM600.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGProveedorWeb1.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGProveedorWeb2.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGProveedorGoss.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGProveedorDimensionadora.ToString("N2") + "</td>" +
                                        "<td style='text-align:right;'>" + KGProveedorTotal.ToString("N2") + "</td>" +
                                        "</tr>" +
                                        "<tr><th>% Escarpe Daño Proveedor</th>" +
                                        "<td style='text-align:right;'>" + PorcProveedorLithoman.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcProveedorM600.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcProveedorWeb1.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcProveedorWeb2.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcProveedorGoss.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcProveedorDimensionadora.ToString("N2") + "%</td>" +
                                        "<td style='text-align:right;'>" + PorcProveedorTotal.ToString("N2") + "%</td>" +
                                        "</tr>";
            Tabla += stgTotalBobinasConsumidas + stgTotalkilosConsumidos + stgTotalkilosEscarpe + stgPromedioEscarpexbobina + stgPorcentajeescarpe + stgBobinasBuenas + stgBobinasMalas + stgBobinasConProyecto +
                     stgBobinasSinProyecto + stgKGEscarpeAlmacen + stgKGEscarpeRollero + stgKGEscarpeProveedor;
            return Tabla;
        }
    }
}