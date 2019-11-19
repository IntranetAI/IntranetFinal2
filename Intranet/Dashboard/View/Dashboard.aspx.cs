using Intranet.Dashboard.Controller;
using Intranet.Dashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Dashboard.View
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DashboardController dc = new DashboardController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DropDownList1.DataSource = dc.ListarRecursos();
                DropDownList1.DataTextField = "Maquina";
                DropDownList1.DataValueField = "CodMaquina";
                DropDownList1.DataBind();
                //DropDownList1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                try
                {
                    string id = Request.QueryString["id"];
                    if (id == null)
                    {
                        Response.Redirect("http://intranet.qgchile.cl/");
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("http://intranet.qgchile.cl/");
                }

            }
        }
        public string FuncionCalcula(string item, DashboardProd lo)
        {
            int countDias = 1; double TotalMermasPreparacionPA = 0; double TotalMermasTiraje = 0; double HorasDirectas = 0; double ImprodIndirectos = 0; double OtrasIndirectas = 0; double HorasIndirectas = 0;

                string ValorFormula = "";
            int ValorMaquina = dc.ListarRecursos().Where(x => x.CodMaquina == DropDownList1.SelectedValue.ToString()).Select(p => p.Valor).FirstOrDefault();
            TotalMermasPreparacionPA = (lo.Buenos > 0) ? (((double)lo.MalosPreparacion) / (double)lo.Buenos) * 100 : 0;
                TotalMermasTiraje = (lo.Buenos > 0) ? (((double)lo.MalosTiraje) / (double)lo.Buenos) * 100 : 0;
                HorasDirectas = lo.HorasTiraje + lo.HorasPreparacion + lo.HorasDelay + lo.HorasImprod_Prep;//[20190619_horas imp.Preperacion agregadas]
                OtrasIndirectas = lo.TotalHoras - lo.HorasPreparacion - lo.HorasTiraje - lo.HorasDelay - (lo.HorasSinPersonal + lo.HorasColacion + lo.HorasAseo + lo.HorasSinTrabajo + lo.HorasMantencion);
                ImprodIndirectos = lo.HorasColacion + lo.HorasAseo + OtrasIndirectas;
                HorasIndirectas = lo.HorasSinPersonal + lo.HorasColacion + lo.HorasAseo + lo.HorasSinTrabajo + lo.HorasMantencion + OtrasIndirectas;
                switch (item)
                {
                    case "Disponibilidad":
                        ValorFormula = (lo.TotalHoras - lo.HorasColacion - lo.HorasSinPersonal) > 0 ? (((lo.HorasTiraje + lo.HorasPreparacion) / (lo.TotalHoras - lo.HorasColacion - lo.HorasSinPersonal)) * 100).ToString("N2") + "%" : "0";//; ((lo.HorasTiraje + lo.HorasPreparacion) / (lo.TotalHoras - lo.HorasColacion - lo.HorasSinPersonal)).ToString();
                        break;
                    case "Rendimiento":
                        ValorFormula = ((lo.HorasTiraje + lo.HorasPreparacion) * (int)ValorMaquina) > 0 ? ((lo.Buenos / ((lo.HorasTiraje + lo.HorasPreparacion) * (int)ValorMaquina)) * 100).ToString("N2") + "%" : "0";
                        break;
                    case "Calidad":
                        ValorFormula = (TotalMermasPreparacionPA + TotalMermasTiraje) > 0 ? (100 - (TotalMermasPreparacionPA + TotalMermasTiraje)).ToString("N2") + "%" : "100%";
                        break;
                    case "Uptime":
                        ValorFormula = (lo.HorasTiraje + lo.HorasDelay) > 0 ? ((lo.HorasTiraje / (lo.HorasTiraje + lo.HorasDelay)) * 100).ToString("N2") + "%" : "0%";
                        break;
                    case "R":
                        ValorFormula = (lo.HorasTiraje > 0) ? Convert.ToInt32(((double)lo.Buenos / lo.HorasTiraje)).ToString("N0").Replace(",", ".") : "0";
                        break;
                    case "RD":
                        ValorFormula = ((lo.HorasTiraje + lo.HorasDelay) > 0) ? Convert.ToInt32(((double)lo.Buenos / (lo.HorasTiraje + lo.HorasDelay))).ToString("N0").Replace(",", ".") : "0";
                        break;
                    case "MRD":
                        ValorFormula = ((HorasDirectas) > 0) ? Convert.ToInt32(((double)lo.Buenos / HorasDirectas)).ToString("N0").Replace(",", ".") : "0";
                        break;
                    case "LOR":
                        ValorFormula = ((lo.Preparaciones2 + lo.Arranques2) > 0) ? Convert.ToInt32(((double)lo.Buenos / (lo.Preparaciones2 + lo.Arranques2))).ToString("N0").Replace(",", ".") : "0";
                        break;
                    case "Tasa Falla Area Logistica":
                        ValorFormula = ((HorasDirectas) > 0) ? (((lo.Logistica) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                        break;
                    case "Tasa Falla Area Mantencion":
                        ValorFormula = ((HorasDirectas) > 0) ? (((lo.Mantencion) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                        break;
                    case "Mantencion Mecanica":
                        ValorFormula = ((HorasDirectas) > 0) ? (((lo.Mecanico) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                        break;
                    case "Mantencion Electrica":
                        ValorFormula = ((HorasDirectas) > 0) ? (((lo.Electrico) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                        break;
                    case "Gestion":
                        ValorFormula = ((HorasDirectas) > 0) ? (((lo.Gestion) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                        break;
                    case "Horas Totales":
                        ValorFormula = lo.TotalHoras.ToString("N0");
                        break;
                    case "Horas Directas":
                        ValorFormula = HorasDirectas.ToString("N2");
                        break;
                    case "Horas Tripuladas (Hrs Directas + Indirectas)":
                        ValorFormula = (HorasDirectas + ImprodIndirectos + lo.HorasMantencion + lo.HorasSinTrabajo).ToString("N0").Replace(",",".");
                        break;
                    case "Preparación":
                        ValorFormula = lo.HorasPreparacion.ToString("N2");
                        break;
                    case "Tiraje":
                        ValorFormula = lo.HorasTiraje.ToString("N2");
                        break;
                    case "Delay":
                        ValorFormula = lo.HorasDelay.ToString("N2");
                        break;
                    //"Horas Indirectas","Improd. Indirectos" ,"Mantencion Planificada","Sin Trabajo","Sin Personal"
                    case "Horas Indirectas":
                        ValorFormula = HorasIndirectas.ToString("N2");
                        break;
                    case "Improd. Indirectos":
                        ValorFormula = ImprodIndirectos.ToString("N2");
                        break;


                    //"Sin Personal","Colacion","Aseo / Limpieza de Equipos","Sin OT","Mantencion Planificada","Otras Indirectas"
                    case "Sin Personal":
                        ValorFormula = lo.HorasSinPersonal.ToString("N2");
                        break;
                    case "Aseo / Limpieza de Equipos":
                        ValorFormula = lo.HorasAseo.ToString("N2");
                        break;
                    case "Mantencion Planificada":
                        ValorFormula = lo.HorasMantencion.ToString("N2");
                        break;
                    case "Colacion":
                        ValorFormula = lo.HorasColacion.ToString("N2");
                        break;
                    case "Sin Trabajo":
                        ValorFormula = lo.HorasSinTrabajo.ToString("N2");
                        break;
                    case "Otras Indirectas":
                        ValorFormula = OtrasIndirectas.ToString("N2");
                        break;

                    //"Impresiones Totales","Impresiones Netas","Merma Total"
                    case "Impresiones Totales":
                        ValorFormula = (lo.Buenos + lo.MalosPreparacion + lo.MalosTiraje).ToString("N0").Replace(",", ".");
                        break;
                    case "Impresiones Netas":
                        ValorFormula = lo.Buenos.ToString("N0").Replace(",", ".");
                        break;
                    case "Merma Total":
                        ValorFormula = (lo.MalosPreparacion + lo.MalosTiraje).ToString("N0").Replace(",", ".");
                        break;
                    //
                    case "Malos Preparacion":
                        ValorFormula = lo.MalosPreparacion.ToString("N0").Replace(",", ".");
                        break;
                    case "Malos Tiraje":
                        ValorFormula = lo.MalosTiraje.ToString("N0").Replace(",", ".");
                        break;
                    //"N° Preparaciones","N° Arranques"
                    case "N° Preparaciones":
                        ValorFormula = lo.Preparaciones.ToString("N0").Replace(",", ".");
                        break;
                    case "N° Arranques":
                        ValorFormula = lo.Arranques.ToString("N0").Replace(",", ".");
                        break;
                    //,"PREPARACIONES","Minutos x Preparacion","Minutos x Arranque","Minutos Promedio Preparacion o Arranque"

                    case "Minutos x Preparacion":
                        ValorFormula = (lo.Preparaciones2 > 0) ? (lo.Preparaciones / lo.Preparaciones2).ToString() : "0";
                        break;
                    case "Minutos x Arranque":
                        ValorFormula = (lo.Arranques2 > 0) ? (lo.Arranques / lo.Arranques2).ToString() : "0";
                        break;
                    case "Minutos Promedio Preparacion o Arranque":
                        ValorFormula = ((lo.Preparaciones2 + lo.Arranques2) > 0) ? ((lo.Preparaciones + lo.Arranques) / (lo.Preparaciones2 + lo.Arranques2)).ToString() : "0";
                        break;
                    //,"MERMAS PROMEDIO","Preparacion.","Arranques.","Tiraje."
                    case "Preparacion.":
                        ValorFormula = ((lo.Preparaciones2) > 0) ? (lo.MalosPreparacion / (lo.Preparaciones2)).ToString() : "0";
                        break;
                    case "Arranques.":
                        ValorFormula = "0";
                        break;
                    case "Tiraje.":
                        ValorFormula = ((lo.Preparaciones2 + lo.Arranques2) > 0) ? (lo.MalosTiraje / (lo.Preparaciones2 + lo.Arranques2)).ToString() : "0";
                        break;
                    //

                    case "(%) Total Mermas Preparacion (P+A)":
                        ValorFormula = TotalMermasPreparacionPA.ToString("N2") + "%";
                        break;
                    case "(%) Mermas Tiraje":
                        ValorFormula = TotalMermasTiraje.ToString("N2") + "%";
                        break;
                    //"(%) Mermas Preparacion","(%) Total Mermas"
                    case "(%) Mermas Preparacion":
                        ValorFormula = (lo.Buenos > 0) ? (((double)lo.MalosPreparacion / (double)lo.Buenos) * 100).ToString("N2") + "%" : "0%";
                        break;
                    case "(%) Total Mermas":
                        ValorFormula = (lo.Buenos > 0) ? ((((double)lo.MalosPreparacion + (double)lo.MalosTiraje) / (double)lo.Buenos) * 100).ToString("N2") + "%" : "0%";
                        break;




                    //,"Logistica","Encuadernacion","Impresion","Mantencion","Mecanica" ,"Electrica","Gestión","Material","Atascos","Espera Cambio de Turno","Espera o Parada por Jefatura"
                    //,"Operacional","Planchas","Planificacion","Servicio al Cliente","Limpieza - Regulacion y Lavados"

                    case "Logistica":
                        ValorFormula = lo.Logistica.ToString("N2");
                        break;
                    case "Encuadernacion":
                        ValorFormula = lo.Encuadernacion.ToString("N2");
                        break;
                    case "Impresion":
                        ValorFormula = lo.Impresion.ToString("N2");
                        break;
                    case "Mantencion":
                        ValorFormula = lo.Mantencion.ToString("N2");
                        break;

                    case "Mecanica":
                        ValorFormula = lo.Mecanico.ToString("N2");
                        break;
                    case "Electrica":
                        ValorFormula = lo.Electrico.ToString("N2");
                        break;
                    case "Gestión":
                        ValorFormula = lo.Gestion.ToString("N2");
                        break;
                    case "Material":
                        ValorFormula = lo.Material.ToString("N2");
                        break;
                    case "Atascos":
                        ValorFormula = lo.Atascos.ToString("N2");
                        break;
                    case "Espera Cambio de Turno":
                        ValorFormula = lo.EsperaCambioTurno.ToString("N2");
                        break;
                    case "Espera o Parada por Jefatura":
                        ValorFormula = lo.ParadaPorJefatura.ToString("N2");
                        break;
                    case "Operacional":
                        ValorFormula = lo.Operacional.ToString("N2");
                        break;
                    case "Planchas":
                        ValorFormula = lo.Planchas.ToString("N2");
                        break;
                    case "Planificacion":
                        ValorFormula = lo.Planificacion.ToString("N2");
                        break;
                    case "Servicio al Cliente":
                        ValorFormula = lo.ServicioCliente.ToString("N2");
                        break;
                    case "Limpieza - Regulacion y Lavados":
                        ValorFormula = lo.RegulacionyLavados.ToString("N2");
                        break;

                }
            return ValorFormula;
            
        }

        public string GeneraTabla(List<DashBoardVisual> lista, List<DashboardProd> Dias, List<DashboardProd> Semanas, List<DashboardProd> Año)
        {
            string encab = "";string contenido = ""; 
            try
            {
                // encab = "<table class='table table-hover table-bordered' style='width:80%'><thead>" +
                //"<tr>" +
                //    "<th rowspan = '2' ><h3>"+DropDownList1.SelectedItem.ToString().ToUpper()+"</h3></th>" +
                //    "<th rowspan = '2' class='text-center'> Año " + Año[0].FechaProduccion + "</th>" +
                //    "<th colspan = '3' class='text-center'> Semanas </th>" +
                //    "<th colspan = '7' class='text-center'> Diario </th> " +
                //    "</tr><tr>" +
                //        "<th class='text-center'> Semana " + Semanas[0].FechaProduccion + "</th>" +
                //        "<th class='text-center'> Semana " + Semanas[1].FechaProduccion + "</th>" +
                //        "<th class='text-center'> Semana " + Semanas[2].FechaProduccion + "</th>" +
                //        "<th class='text-center'>" + (Dias.Count() >= 1 ? Convert.ToDateTime(Dias[0].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                //         "<th class='text-center'>" + (Dias.Count() >= 2 ? Convert.ToDateTime(Dias[1].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                //         "<th class='text-center'>" + (Dias.Count() >= 3 ? Convert.ToDateTime(Dias[2].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                //         "<th class='text-center'>" + (Dias.Count() >= 4 ? Convert.ToDateTime(Dias[3].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                //         "<th class='text-center'>" + (Dias.Count() >= 5 ? Convert.ToDateTime(Dias[4].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                //         "<th class='text-center'>" + (Dias.Count() >= 6 ? Convert.ToDateTime(Dias[5].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                //         "<th class='text-center'>" + (Dias.Count() >= 7 ? Convert.ToDateTime(Dias[6].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                //        "</tr></thead><tbody>";

                encab = "<table class='table table-hover table-bordered header_fijo' style='width:80%'><thead>" +
                        "<tr>" +
                           "<th rowspan = '2' ><h3>" + DropDownList1.SelectedItem.ToString().ToUpper() + "</h3></th>" +
                           "<th rowspan = '2' class='text-center'> Año <br/> <p><font size='1'>(Últimos 365 días)</font></p></th>" +
                           "<th rowspan = '2' class='text-center'> Mes <br/> <p><font size='1'>(Últimos 30 días)</font></p></th>" +
                           "<th colspan = '2' class='text-center'> Semanas </th>" +
                           "<th colspan = '7' class='text-center'> Diario </th> " +
                           "</tr><tr>" +
                               //"<th class='text-center'> Semana " + Semanas[0].FechaProduccion + "</th>" +
                               "<th class='text-center'> Semana " + Semanas[1].FechaProduccion + "</th>" +
                               "<th class='text-center'> Semana " + Semanas[2].FechaProduccion + "</th>" +
                               "<th class='text-center'>" + (Dias.Count() >= 1 ? Convert.ToDateTime(Dias[0].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                                "<th class='text-center'>" + (Dias.Count() >= 2 ? Convert.ToDateTime(Dias[1].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                                "<th class='text-center'>" + (Dias.Count() >= 3 ? Convert.ToDateTime(Dias[2].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                                "<th class='text-center'>" + (Dias.Count() >= 4 ? Convert.ToDateTime(Dias[3].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                                "<th class='text-center'>" + (Dias.Count() >= 5 ? Convert.ToDateTime(Dias[4].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                                "<th class='text-center'>" + (Dias.Count() >= 6 ? Convert.ToDateTime(Dias[5].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                                "<th class='text-center'>" + (Dias.Count() >= 7 ? Convert.ToDateTime(Dias[6].FechaProduccion).ToString("dd-MM") : "-") + "</th>" +
                               "</tr></thead><tbody>";
                foreach (var item in lista)
                {
                    string styleMaquina = ( item.Maquina == "PREPARACIONES" || item.Maquina == "IMPRODUCTIVOS" || item.Maquina == "KPI" || item.Maquina == "HORAS" || item.Maquina == "MERMAS PROMEDIO" || item.Maquina == "PRODUCCION" || item.Maquina == "Detalle Improd_Ind" ? "class='text-left'" : "class='text-right'");
                    contenido += "<tr>" +
                            "<td " + styleMaquina + ">" + (item.Maquina == "PREPARACIONES" || item.Maquina == "IMPRODUCTIVOS" || item.Maquina == "KPI" || item.Maquina == "HORAS" || item.Maquina == "MERMAS PROMEDIO" || item.Maquina == "PRODUCCION" || item.Maquina == "Detalle Improd_Ind" ? "<b>" + item.Maquina + "</b>" : item.Maquina) + "</td>" +
                            "<td class='text-right'>" + item.Año + "</td>" +
                            "<td class='text-right'>" + item.Semana1 + "</td>" +
                            "<td class='text-right'>" + item.Semana2 + "</td>" +
                            "<td class='text-right'>" + item.Semana3 + "</td>" +
                            "<td class='text-right'>" + item.Dia1 + "</td>" +
                            "<td class='text-right'>" + item.Dia2 + "</td>" +
                            "<td class='text-right'>" + item.Dia3 + "</td>" +
                            "<td class='text-right'>" + item.Dia4 + "</td>" +
                            "<td class='text-right'>" + item.Dia5 + "</td>" +
                            "<td class='text-right'>" + item.Dia6 + "</td>" +
                            "<td class='text-right'>" + item.Dia7 + "</td>" +
                        "</tr>";
                }
            }
            catch (Exception ex)
            {
            }
            return encab + contenido + "</tbody></table>";
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            Label1.Text = "";
            try
            {
                string[] str = txtFechaTermino.Text.Split('/');
                DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] );

                string[] a = { "Disponibilidad","Rendimiento","Calidad",
                "KPI","Uptime","R","RD","MRD","LOR","Tasa Falla Area Logistica", "Tasa Falla Area Mantencion","Mantencion Mecanica","Mantencion Electrica","Gestion",
                "HORAS","Horas Totales","Horas Tripuladas (Hrs Directas + Indirectas)" ,"Horas Directas","Preparación" ,"Tiraje","Delay","Horas Indirectas","Improd. Indirectos"
                ,"Detalle Improd_Ind","Sin Personal","Colacion","Aseo / Limpieza de Equipos","Sin Trabajo","Mantencion Planificada","Otras Indirectas"
                ,"PRODUCCION","Impresiones Totales","Impresiones Netas","Merma Total","Malos Preparacion","Malos Tiraje","N° Preparaciones","N° Arranques"
                ,"PREPARACIONES","Minutos x Preparacion","Minutos x Arranque","Minutos Promedio Preparacion o Arranque"
                ,"MERMAS PROMEDIO","Preparacion.","Arranques.","Tiraje."
                ,"(%) Total Mermas Preparacion (P+A)", "(%) Mermas Tiraje","(%) Mermas Preparacion","(%) Total Mermas"

                ,"IMPRODUCTIVOS","Logistica","Encuadernacion","Impresion","Mantencion","Mecanica" ,"Electrica","Gestión","Material","Atascos","Espera Cambio de Turno","Espera o Parada por Jefatura"
                ,"Operacional","Planchas","Planificacion","Servicio al Cliente","Limpieza - Regulacion y Lavados" };
                string algo = "";
                List<DashboardProd> listaDias = dc.ListarRegistros(fi, DropDownList1.SelectedValue.ToString(), 0);
                List<DashboardProd> listaSemanas = dc.ListarRegistros(fi, DropDownList1.SelectedValue.ToString(), 1);
                List<DashboardProd> listaAño = dc.ListarRegistros(fi, DropDownList1.SelectedValue.ToString(), 2);
                List<DashboardProd> listaMes= dc.ListarRegistros(fi, DropDownList1.SelectedValue.ToString(), 4);
                int ValorMaquina = dc.ListarRecursos().Where(x => x.CodMaquina == DropDownList1.SelectedValue.ToString()).Select(p => p.Valor).FirstOrDefault();
                List<DashBoardVisual> listaFinal = new List<DashBoardVisual>();

                foreach (var item in a)
                {
                    DashBoardVisual dv = new DashBoardVisual();
                    dv.Maquina = item;
                    dv.Año = FuncionCalcula(item, listaAño[0]);
                    dv.Semana1 = FuncionCalcula(item,listaMes[0]);
                    // dv.Semana1 = FuncionCalcula(item, listaSemanas[0]);COMENTADA PARA REEMPLAZAR POR MES MOVIL
                    dv.Semana2 = FuncionCalcula(item, listaSemanas[1]);
                    dv.Semana3 = FuncionCalcula(item, listaSemanas[2]); 
                    //calcular disponibilidad dias
                    int countDias = 1; double TotalMermasPreparacionPA = 0; double TotalMermasTiraje = 0; double HorasDirectas = 0; double ImprodIndirectos = 0; double OtrasIndirectas = 0; double HorasIndirectas = 0;
                    foreach (var lo in listaDias)
                    {
                        string ValorFormula = "";
                        TotalMermasPreparacionPA = (lo.Buenos > 0) ? (((double)lo.MalosPreparacion) / (double)lo.Buenos) * 100 : 0;
                        TotalMermasTiraje = (lo.Buenos > 0) ? (((double)lo.MalosTiraje) / (double)lo.Buenos) * 100 : 0;
                        HorasDirectas = lo.HorasTiraje + lo.HorasPreparacion + lo.HorasDelay+lo.HorasImprod_Prep;//[20190619_horas imp.Preperacion agregadas]
                        //improd prep

                        //horas directas + improd prep
                        OtrasIndirectas = lo.TotalHoras - lo.HorasPreparacion - lo.HorasTiraje - lo.HorasDelay - (lo.HorasSinPersonal + lo.HorasColacion + lo.HorasAseo + lo.HorasSinTrabajo + lo.HorasMantencion);
                        ImprodIndirectos = lo.HorasColacion + lo.HorasAseo + OtrasIndirectas;
                        HorasIndirectas = lo.HorasSinPersonal + lo.HorasColacion + lo.HorasAseo + lo.HorasSinTrabajo + lo.HorasMantencion + OtrasIndirectas;
                        switch (item)
                        {
                            case "Disponibilidad":
                                ValorFormula = (lo.TotalHoras - lo.HorasColacion - lo.HorasSinPersonal) > 0 ? (((lo.HorasTiraje + lo.HorasPreparacion) / (lo.TotalHoras - lo.HorasColacion - lo.HorasSinPersonal)) * 100).ToString("N2") + "%" : "0";//; ((lo.HorasTiraje + lo.HorasPreparacion) / (lo.TotalHoras - lo.HorasColacion - lo.HorasSinPersonal)).ToString();
                                break;
                            case "Rendimiento":
                                ValorFormula = ((lo.HorasTiraje + lo.HorasPreparacion) * (double)ValorMaquina) > 0 ? (((double)lo.Buenos / ((lo.HorasTiraje + lo.HorasPreparacion) * (double)ValorMaquina)) * 100).ToString("N2") + "%" : "0";
                                break;
                            case "Calidad":
                                ValorFormula = (TotalMermasPreparacionPA + TotalMermasTiraje) > 0 ? (100 - (TotalMermasPreparacionPA + TotalMermasTiraje)).ToString("N2") + "%" : "100%";
                                break;
                            case "Uptime":
                                ValorFormula = (lo.HorasTiraje + lo.HorasDelay) > 0 ? ((lo.HorasTiraje / (lo.HorasTiraje + lo.HorasDelay)) * 100).ToString("N2") + "%" : "0%";
                                break;
                            case "R":
                                ValorFormula = (lo.HorasTiraje > 0) ? Convert.ToInt32(((double)lo.Buenos / lo.HorasTiraje)).ToString("N0").Replace(",", ".") : "0";
                                break;
                            case "RD":
                                ValorFormula = ((lo.HorasTiraje + lo.HorasDelay) > 0) ? Convert.ToInt32(((double)lo.Buenos / (lo.HorasTiraje + lo.HorasDelay))).ToString("N0").Replace(",", ".") : "0";
                                break;
                            case "MRD":
                                ValorFormula = ((HorasDirectas) > 0) ? Convert.ToInt32(((double)lo.Buenos / HorasDirectas)).ToString("N0").Replace(",", ".") : "0";
                                break;
                            case "LOR":
                                ValorFormula = ((lo.Preparaciones2 + lo.Arranques2) > 0) ? Convert.ToInt32(((double)lo.Buenos / (lo.Preparaciones2 + lo.Arranques2))).ToString("N0").Replace(",", ".") : "0";
                                break;
                            case "Tasa Falla Area Logistica":
                                ValorFormula = ((HorasDirectas) > 0) ? (((lo.Logistica) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                                break;
                            case "Tasa Falla Area Mantencion":
                                ValorFormula = ((HorasDirectas) > 0) ? (((lo.Mantencion) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                                break;
                            case "Mantencion Mecanica":
                                ValorFormula = ((HorasDirectas) > 0) ? (((lo.Mecanico) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                                break;
                            case "Mantencion Electrica":
                                ValorFormula = ((HorasDirectas) > 0) ? (((lo.Electrico) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                                break;
                            case "Gestion":
                                ValorFormula = ((HorasDirectas) > 0) ? (((lo.Gestion) / HorasDirectas) * 100).ToString("N2") + "%" : "0";
                                break;
                            case "Horas Totales":
                                ValorFormula = lo.TotalHoras.ToString("N0");
                                break;
                            case "Horas Directas":
                                ValorFormula = HorasDirectas.ToString("N2");
                                break;
                            case "Horas Tripuladas (Hrs Directas + Indirectas)":
                                ValorFormula = (HorasDirectas + ImprodIndirectos + lo.HorasMantencion + lo.HorasSinTrabajo).ToString("N2");
                                break;
                            case "Preparación":
                                ValorFormula = lo.HorasPreparacion.ToString("N2");
                                break;
                            case "Tiraje":
                                ValorFormula = lo.HorasTiraje.ToString("N2");
                                break;
                            case "Delay":
                                ValorFormula = lo.HorasDelay.ToString("N2");
                                break;
                            case "Horas Indirectas":
                                ValorFormula = HorasIndirectas.ToString("N2");
                                break;
                            case "Improd. Indirectos":
                                ValorFormula = ImprodIndirectos.ToString("N2");
                                break;
                            case "Sin Personal":
                                ValorFormula = lo.HorasSinPersonal.ToString("N2");
                                break;
                            case "Aseo / Limpieza de Equipos":
                                ValorFormula = lo.HorasAseo.ToString("N2");
                                break;
                            case "Mantencion Planificada":
                                ValorFormula = lo.HorasMantencion.ToString("N2");
                                break;
                            case "Colacion":
                                ValorFormula = lo.HorasColacion.ToString("N2");
                                break;
                            case "Sin Trabajo":
                                ValorFormula = lo.HorasSinTrabajo.ToString("N2");
                                break;
                            case "Otras Indirectas":
                                ValorFormula = OtrasIndirectas.ToString("N2");
                                break;
                            case "Impresiones Totales":
                                ValorFormula = (lo.Buenos + lo.MalosPreparacion + lo.MalosTiraje).ToString("N0").Replace(",", ".");
                                break;
                            case "Impresiones Netas":
                                ValorFormula = lo.Buenos.ToString("N0").Replace(",", ".");
                                break;
                            case "Merma Total":
                                ValorFormula = (lo.MalosPreparacion + lo.MalosTiraje).ToString("N0").Replace(",", ".");
                                break;
                            //
                            case "Malos Preparacion":
                                ValorFormula = lo.MalosPreparacion.ToString("N0").Replace(",", ".");
                                break;
                            case "Malos Tiraje":
                                ValorFormula = lo.MalosTiraje.ToString("N0").Replace(",", ".");
                                break;
                            //"N° Preparaciones","N° Arranques"
                            case "N° Preparaciones":
                                ValorFormula = lo.Preparaciones.ToString("N0").Replace(",", ".");
                                break;
                            case "N° Arranques":
                                ValorFormula = lo.Arranques.ToString("N0").Replace(",", ".");
                                break;
                            //,"PREPARACIONES","Minutos x Preparacion","Minutos x Arranque","Minutos Promedio Preparacion o Arranque"

                            case "Minutos x Preparacion":
                                ValorFormula = (lo.Preparaciones2 > 0) ? (lo.Preparaciones / lo.Preparaciones2).ToString() : "0";
                                break;
                            case "Minutos x Arranque":
                                ValorFormula = (lo.Arranques2 > 0) ? (lo.Arranques / lo.Arranques2).ToString() : "0";
                                break;
                            case "Minutos Promedio Preparacion o Arranque":
                                ValorFormula = ((lo.Preparaciones2 + lo.Arranques2) > 0) ? ((lo.Preparaciones + lo.Arranques) / (lo.Preparaciones2 + lo.Arranques2)).ToString() : "0";
                                break;
                            //,"MERMAS PROMEDIO","Preparacion.","Arranques.","Tiraje."
                            case "Preparacion.":
                                ValorFormula = ((lo.Preparaciones2) > 0) ? (lo.MalosPreparacion / (lo.Preparaciones2)).ToString() : "0";
                                break;
                            case "Arranques.":
                                ValorFormula = "0";
                                break;
                            case "Tiraje.":
                                ValorFormula = ((lo.Preparaciones2 + lo.Arranques2) > 0) ? (lo.MalosTiraje / (lo.Preparaciones2 + lo.Arranques2)).ToString() : "0";
                                break;
                            //

                            case "(%) Total Mermas Preparacion (P+A)":
                                ValorFormula = TotalMermasPreparacionPA.ToString("N2") + "%";
                                break;
                            case "(%) Mermas Tiraje":
                                ValorFormula = TotalMermasTiraje.ToString("N2") + "%";
                                break;
                            //"(%) Mermas Preparacion","(%) Total Mermas"
                            case "(%) Mermas Preparacion":
                                ValorFormula = (lo.Buenos > 0) ? (((double)lo.MalosPreparacion / (double)lo.Buenos) * 100).ToString("N2") + "%" : "0%";
                                break;
                            case "(%) Total Mermas":
                                ValorFormula = (lo.Buenos > 0) ? ((((double)lo.MalosPreparacion + (double)lo.MalosTiraje) / (double)lo.Buenos) * 100).ToString("N2") + "%" : "0%";
                                break;




                            //,"Logistica","Encuadernacion","Impresion","Mantencion","Mecanica" ,"Electrica","Gestión","Material","Atascos","Espera Cambio de Turno","Espera o Parada por Jefatura"
                            //,"Operacional","Planchas","Planificacion","Servicio al Cliente","Limpieza - Regulacion y Lavados"

                            case "Logistica":
                                ValorFormula = lo.Logistica.ToString("N2");
                                break;
                            case "Encuadernacion":
                                ValorFormula = lo.Encuadernacion.ToString("N2");
                                break;
                            case "Impresion":
                                ValorFormula = lo.Impresion.ToString("N2");
                                break;
                            case "Mantencion":
                                ValorFormula = lo.Mantencion.ToString("N2");
                                break;

                            case "Mecanica":
                                ValorFormula = lo.Mecanico.ToString("N2");
                                break;
                            case "Electrica":
                                ValorFormula = lo.Electrico.ToString("N2");
                                break;
                            case "Gestión":
                                ValorFormula = lo.Gestion.ToString("N2");
                                break;
                            case "Material":
                                ValorFormula = lo.Material.ToString("N2");
                                break;
                            case "Atascos":
                                ValorFormula = lo.Atascos.ToString("N2");
                                break;
                            case "Espera Cambio de Turno":
                                ValorFormula = lo.EsperaCambioTurno.ToString("N2");
                                break;
                            case "Espera o Parada por Jefatura":
                                ValorFormula = lo.ParadaPorJefatura.ToString("N2");
                                break;
                            case "Operacional":
                                ValorFormula = lo.Operacional.ToString("N2");
                                break;
                            case "Planchas":
                                ValorFormula = lo.Planchas.ToString("N2");
                                break;
                            case "Planificacion":
                                ValorFormula = lo.Planificacion.ToString("N2");
                                break;
                            case "Servicio al Cliente":
                                ValorFormula = lo.ServicioCliente.ToString("N2");
                                break;
                            case "Limpieza - Regulacion y Lavados":
                                ValorFormula = lo.RegulacionyLavados.ToString("N2");
                                break;

                        }

                        switch (countDias)
                        {
                            case 1:
                                dv.Dia1 = ValorFormula;
                                countDias++;
                                break;
                            case 2:
                                dv.Dia2 = ValorFormula;
                                countDias++;
                                break;
                            case 3:
                                dv.Dia3 = ValorFormula;
                                countDias++;
                                break;
                            case 4:
                                dv.Dia4 = ValorFormula;
                                countDias++;
                                break;
                            case 5:
                                dv.Dia5 = ValorFormula;
                                countDias++;
                                break;
                            case 6:
                                dv.Dia6 = ValorFormula;
                                countDias++;
                                break;
                            case 7:
                                dv.Dia7 = ValorFormula;
                                countDias++;
                                break;
                        }
                    }
                    listaFinal.Add(dv);
                }

               // GridView1.DataSource = listaFinal;
               // GridView1.DataBind();
                Label1.Text = GeneraTabla(listaFinal, listaDias, listaSemanas, listaAño);
            }
            catch (Exception ex)
            {

            }
        }
    }
}