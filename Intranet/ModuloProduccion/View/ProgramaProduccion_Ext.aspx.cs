
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloProduccion.View
{
    public partial class ProgramaProduccion_Ext : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstFruits.Items.Add(new ListItem("LITHOMAN", "MR408"));
                lstFruits.Items.Add(new ListItem("M-600", "M6001"));
                lstFruits.Items.Add(new ListItem("WEB 1", "M1016"));
                lstFruits.Items.Add(new ListItem("WEB 2", "M2016"));
                lstFruits.Items.Add(new ListItem("KBA", "KBA"));
                lstFruits.Items.Add(new ListItem("10P", "SH102"));
                lstFruits.Items.Add(new ListItem("XL", "SHXL2"));
                lstFruits.Items.Add(new ListItem("Indigo", "HPIndigo"));
                lstFruits.Items.Add(new ListItem("Dimensionadora", "DIMENSIONA"));
                lstFruits.Items.Add(new ListItem("Guillotina Polar 115-1", "FC58"));
                lstFruits.Items.Add(new ListItem("Guillotina Polar 115-2", "FC59"));
                lstFruits.Items.Add(new ListItem("Guillotina Polar ED", "FC60"));
                lstFruits.Items.Add(new ListItem("Dobladora Stahl 2", "FM85"));
                lstFruits.Items.Add(new ListItem("Dobladora Stahl 3", "FM86"));
                lstFruits.Items.Add(new ListItem("Dobladora Stahl 4", "FM87"));
                lstFruits.Items.Add(new ListItem("Dobladora Stahl 5", "FM88"));
                lstFruits.Items.Add(new ListItem("Dobladora MBO", "FM89"));
                lstFruits.Items.Add(new ListItem("Cosedora 321_1", "HT248"));
                lstFruits.Items.Add(new ListItem("Cosedora 321_2", "HT249"));
                lstFruits.Items.Add(new ListItem("Cosedora Prima", "HT250"));
                lstFruits.Items.Add(new ListItem("Inventa Plus I", "SL001"));
                lstFruits.Items.Add(new ListItem("Ventura", "SL001"));
                lstFruits.Items.Add(new ListItem("Wohlemberg", "TT4"));
                lstFruits.Items.Add(new ListItem("Nordbinder", "UB110"));
                lstFruits.Items.Add(new ListItem("Horizon", "UB111"));
                lstFruits.Items.Add(new ListItem("Trendbinder", "UB112"));
                lstFruits.Items.Add(new ListItem("Corona C-18", "UB117"));
                lstFruits.Items.Add(new ListItem("Case in Line", "CI45"));
                lstFruits.Items.Add(new ListItem("Case Maker", "MA3"));
                lstFruits.Items.Add(new ListItem("Alzadora Tapa Dura", "RB5-ALZ_TDUR"));
                lstFruits.Items.Add(new ListItem("Espiral Womako", "SP001"));
                lstFruits.Items.Add(new ListItem("Embolsadora", "PW80"));
                lstFruits.Items.Add(new ListItem("Embolsadora SITMA", "SITMA"));
                lstFruits.Items.Add(new ListItem("Manualidades", "MANUAL"));
                lstFruits.Items.Add(new ListItem("Manualidades Tapa Dura", "MANUAL_TD"));
                lstFruits.Items.Add(new ListItem("Sunipac", "Sonipac"));
                lstFruits.Items.Add(new ListItem("Barniz UV Parejo", "TER_BAR_UV_P"));
                lstFruits.Items.Add(new ListItem("Folia", "TER_FOLIA"));
                lstFruits.Items.Add(new ListItem("Troquel - Plisado", "TER_TROQ_PLI"));
                lstFruits.Items.Add(new ListItem("UV Selectivo", "TER_UV_SELEC"));
                lstFruits.Items.Add(new ListItem("Tercero", "TERCERO"));
                lstFruits.Items.Add(new ListItem("Troqueladora SBB", "DC9"));
                lstFruits.Items.Add(new ListItem("Pegadora de Guarda", "TP59"));

            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            ProgramaProduccion_Controller sc = new ProgramaProduccion_Controller();
            string Maquinas = "";int count = 0;
            foreach (ListItem item in lstFruits.Items)
            {
                if (item.Selected)
                {
                    Maquinas += item.Value + ",";
                    count++;
                }
            }
            if (count > 0)
            {
                Maquinas = Maquinas.Substring(0, Maquinas.Length - 1);
                string EncDias = "<tr><td style = 'width:15%;height:19px;font-size: 12px;border: 1px solid black;' align = 'center' ><b> Lunes </b></td>" +
                                    "<td style = 'width:14%;height:19px;font-size: 12px;border: 1px solid black;' align = 'center' ><b> Martes </b></td>" +
                                    "<td style = 'width:14%;height:19px;font-size: 12px;border: 1px solid black;' align = 'center' ><b> Miércoles </b></td>" +
                                    "<td style = 'width:14%;height:19px;font-size: 12px;border: 1px solid black;' align = 'center' ><b> Jueves </b></td>" +
                                    "<td style = 'width:14%;height:19px;font-size: 12px;border: 1px solid black;' align = 'center' ><b> Viernes </b></td>" +
                                    "<td style = 'width:14%;height:19px;font-size: 12px;border: 1px solid black;' align = 'center' ><b> Sábado </b></td>" +
                                    "<td style = 'width:15%;height:19px;font-size: 12px;border: 1px solid black;' align = 'center' ><b> Domingo </b></td>" +
                                "</tr>";
                int Mes = DateTime.Now.Month; int MesRecorrido = DateTime.Now.Month;
                int Año = DateTime.Now.Year; int AñoRecorrido = DateTime.Now.Year;
                int MesesBusqueda = Convert.ToInt32(ddlMeses.SelectedValue.ToString());

                List<ProgramaProduccion_Extendido> lista = new List<ProgramaProduccion_Extendido>();
                if (Mes + MesesBusqueda > 12)
                {
                    DateTime FechaInicio = new DateTime(Año, Mes, 1);
                    int ddm = DateTime.DaysInMonth(Año, FechaInicio.AddMonths(MesesBusqueda).Month);
                    DateTime FechaTermino = new DateTime((Año + 1), FechaInicio.AddMonths(MesesBusqueda).Month, ddm);
                    lista = sc.Programa_Extendido(FechaInicio, FechaTermino, Maquinas);
                }
                else
                {
                    DateTime FechaInicio = new DateTime(Año, Mes, 1);
                    int ddm = DateTime.DaysInMonth(Año, FechaInicio.AddMonths(MesesBusqueda).Month);
                    DateTime FechaTermino = new DateTime(Año, FechaInicio.AddMonths(MesesBusqueda).Month, ddm);
                    lista = sc.Programa_Extendido(FechaInicio, FechaTermino, Maquinas);
                }




                string Semanas = ""; string diavacio = "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> - </b></td>";
                string diasvacios = "<td style='width:14%;overflow: hidden;max-height: 175px;vertical-align:top;border: 1px solid black;'><div style='font-size: 8px;'></div></td>"; string Dias = "";
                string tabla = "<table style='width:100%;height 665px;border-collapse: collapse;'><tbody>" + EncDias;
                string contenido = ""; string tablacompleta = ""; string detalleDia = "";
                //Recorrer segun maquina
                foreach (string MaquinaFor in lista.Select(o => o.Maquina).Distinct())
                {
                    //Recorrer Meses de la maquina
                    for (int m = MesesBusqueda; m >= 0; m--)
                    {

                        // TimeSpan tspan2 = (new DateTime(AñoRecorrido, MesRecorrido, 1)) - (new DateTime(AñoRecorrido, (MesRecorrido + 1), 1).AddDays(-1));
                        int diasdelmes = DateTime.DaysInMonth(AñoRecorrido, MesRecorrido);
                        for (int i = 1; i <= diasdelmes; i++)
                        {
                            if (i == 4)
                            {

                            }
                            //recorrer registros por dia
                            detalleDia = "";
                            foreach (ProgramaProduccion_Extendido info in lista.Where(o => o.Año == AñoRecorrido && o.Mes == MesRecorrido && o.Dia == i && o.Maquina == MaquinaFor))
                            {
                                detalleDia += "<div style='font-size: 8px;'><span style='float:right'>" + info.TiempoDif + "</span><b>" + info.OT + "</b> " + info.NombreOT + "(" + info.NumPliego + ")</div>";

                            }

                            string Fec = new DateTime(AñoRecorrido, MesRecorrido, i).ToString("dddd", new CultureInfo("es-ES"));
                            if (i == 1)
                            {

                                switch (Fec)
                                {
                                    case "lunes":
                                        Semanas += "<tr>" +
                                           "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                        Dias += "<tr>" + "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                        break;
                                    case "martes":
                                        Semanas += "<tr>" + diavacio +
                                           "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                        Dias += "<tr>" + diasvacios + "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                        break;
                                    case "miércoles":
                                        Semanas += "<tr>" + diavacio + diavacio +
                                          "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                        Dias += "<tr>" + diasvacios + diasvacios +
                                            "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                        break;
                                    case "jueves":
                                        Semanas += "<tr>" + diavacio + diavacio + diavacio +
                                           "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                        Dias += "<tr>" + diasvacios + diasvacios + diasvacios +
                                            "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                        break;
                                    case "viernes":
                                        Semanas += "<tr>" + diavacio + diavacio + diavacio + diavacio +
                                           "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                        Dias += "<tr>" + diasvacios + diasvacios + diasvacios + diasvacios +
                                            "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                        break;
                                    case "sábado":
                                        Semanas += "<tr>" + diavacio + diavacio + diavacio + diavacio + diavacio +
                                           "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                        Dias += "<tr>" + diasvacios + diasvacios + diasvacios + diasvacios + diasvacios +
                                            "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                        break;
                                    case "domingo":
                                        Semanas += "<tr>" + diavacio + diavacio + diavacio + diavacio + diavacio + diavacio +
                                           "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td></tr>";
                                        Dias += "<tr>" + diasvacios + diasvacios + diasvacios + diasvacios + diasvacios + diasvacios +
                                            "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                        break;

                                    default: break;

                                }
                            }
                            else
                            {

                                if (Fec == "lunes")
                                {
                                    Semanas += "<tr>" +
                                             "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                    Dias += "<tr>" +
                                           "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                }
                                else if (Fec == "domingo")
                                {
                                    Semanas += "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>" +
                                        "</tr>";
                                    Dias += "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>" +
                                        "</tr>";
                                    //borrar valor semanas y dias
                                    contenido += Semanas + Dias;
                                    Semanas = ""; Dias = "";
                                }
                                else //martes,miercoles,jueves,viernes y sabado
                                {
                                    Semanas += "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                    Dias += "<td style='width:14%;overflow: hidden;max-height: 175px;height: 50px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                    //"<td style='width:14%;overflow: hidden;max-height: 175px;vertical-align:top;'><div style='font-size: 8px;'><span style='float:right'>horas</span><b>ot</b> nombreot-pliegos</div></td>";
                                }
                            }
                        }
                        //sumar mes y si es necesario el año
                        //agregar ultima semana antes de terminar el recorrido si no termina en domingo
                        tablacompleta += "<div style='width:100%;text-align:center'><b>" + MaquinaFor + " - " + new DateTime(AñoRecorrido, MesRecorrido, 1).ToString("MMMM", new CultureInfo("es-ES")).ToUpperInvariant() + " " + AñoRecorrido + "</b></div>" + "<table style='width:100%;height 665px;border-collapse: collapse;'><tbody>" + EncDias + contenido + Semanas + Dias + "</tbody></table><div style='page-break-before: always;'></div><br/>";
                        //set varialbes
                        contenido = ""; Semanas = ""; Dias = "";
                        if (MesRecorrido == 12)
                        {
                            MesRecorrido = 1; AñoRecorrido = AñoRecorrido + 1;
                        }
                        else
                        {
                            MesRecorrido = MesRecorrido + 1;
                        }
                    }
                    //Igualar mes inicial al recorrido para la siguiente maquina
                    MesRecorrido = Mes; AñoRecorrido = Año;
                }


                Label1.Text = tablacompleta;
            }
            else
            {
            }
         



        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int n = lstFruits.Items.Count - 1; n >= 0; --n)
            {
                    lstFruits.Items.RemoveAt(n);
            }

            switch (DropDownList2.SelectedValue.ToString())
            {
                case "Rotativas":
                    lstFruits.Items.Add(new ListItem("LITHOMAN", "MR408"));
                    lstFruits.Items.Add(new ListItem("M-600", "M6001"));
                    lstFruits.Items.Add(new ListItem("WEB 1", "M1016"));
                    lstFruits.Items.Add(new ListItem("WEB 2", "M2016"));
                    break;
                case "Planas":
                    lstFruits.Items.Add(new ListItem("KBA", "KBA"));
                    lstFruits.Items.Add(new ListItem("10P", "SH102"));
                    lstFruits.Items.Add(new ListItem("XL", "SHXL2"));
                    break;
                case "Digital":
                    lstFruits.Items.Add(new ListItem("Indigo", "HPIndigo"));
                    break;
                case "Dimensionado":
                    lstFruits.Items.Add(new ListItem("Dimensionadora", "DIMENSIONA"));
                    break;
                case "Guillotinas":
                    lstFruits.Items.Add(new ListItem("Guillotina Polar 115-1", "FC58"));
                    lstFruits.Items.Add(new ListItem("Guillotina Polar 115-2", "FC59"));
                    lstFruits.Items.Add(new ListItem("Guillotina Polar ED", "FC60"));
                    break;
                case "Dobladoras":
                    lstFruits.Items.Add(new ListItem("Dobladora Stahl 2", "FM85"));
                    lstFruits.Items.Add(new ListItem("Dobladora Stahl 3", "FM86"));
                    lstFruits.Items.Add(new ListItem("Dobladora Stahl 4", "FM87"));
                    lstFruits.Items.Add(new ListItem("Dobladora Stahl 5", "FM88"));
                    lstFruits.Items.Add(new ListItem("Dobladora MBO", "FM89"));
                    break;
                case "Costura Alambre":
                    lstFruits.Items.Add(new ListItem("Cosedora 321_1", "HT248"));
                    lstFruits.Items.Add(new ListItem("Cosedora 321_2", "HT249"));
                    lstFruits.Items.Add(new ListItem("Cosedora Prima", "HT250"));
                    break;
                case "Costura Hilo":
                    lstFruits.Items.Add(new ListItem("Inventa Plus I", "SL001"));
                    lstFruits.Items.Add(new ListItem("Ventura", "SL001"));
                    break;
                case "Entape":
                    lstFruits.Items.Add(new ListItem("Wohlemberg", "TT4"));
                    lstFruits.Items.Add(new ListItem("Nordbinder", "UB110"));
                    lstFruits.Items.Add(new ListItem("Horizon", "UB111"));
                    lstFruits.Items.Add(new ListItem("Trendbinder", "UB112"));
                    lstFruits.Items.Add(new ListItem("Corona C-18", "UB117"));
                    break;
                case "Tapa Dura":
                    lstFruits.Items.Add(new ListItem("Case in Line", "CI45"));
                    lstFruits.Items.Add(new ListItem("Case Maker", "MA3"));
                    lstFruits.Items.Add(new ListItem("Alzadora Tapa Dura", "RB5-ALZ_TDUR"));
                    break;
                case "Espiral":
                    lstFruits.Items.Add(new ListItem("Espiral Womako", "SP001"));
                    break;
                case "Embolsado":
                    lstFruits.Items.Add(new ListItem("Embolsadora", "PW80"));
                    lstFruits.Items.Add(new ListItem("Embolsadora SITMA", "SITMA"));
                    break;
                case "Manualidades":
                    lstFruits.Items.Add(new ListItem("Manualidades", "MANUAL"));
                    lstFruits.Items.Add(new ListItem("Manualidades Tapa Dura", "MANUAL_TD"));
                    break;
                case "Externos":
                    lstFruits.Items.Add(new ListItem("Sunipac", "Sonipac"));
                    lstFruits.Items.Add(new ListItem("Barniz UV Parejo", "TER_BAR_UV_P"));
                    lstFruits.Items.Add(new ListItem("Folia", "TER_FOLIA"));
                    lstFruits.Items.Add(new ListItem("Troquel - Plisado", "TER_TROQ_PLI"));
                    lstFruits.Items.Add(new ListItem("UV Selectivo", "TER_UV_SELEC"));
                    lstFruits.Items.Add(new ListItem("Tercero", "TERCERO"));
                    break;
                case "Encuadernacion":
                    lstFruits.Items.Add(new ListItem("Troqueladora SBB", "DC9"));
                    lstFruits.Items.Add(new ListItem("Pegadora de Guarda", "TP59"));
                    break;

                default:
                    lstFruits.Items.Add(new ListItem("LITHOMAN", "MR408"));
                    lstFruits.Items.Add(new ListItem("M-600", "M6001"));
                    lstFruits.Items.Add(new ListItem("WEB 1", "M1016"));
                    lstFruits.Items.Add(new ListItem("WEB 2", "M2016"));
                    lstFruits.Items.Add(new ListItem("KBA", "KBA"));
                    lstFruits.Items.Add(new ListItem("10P", "SH102"));
                    lstFruits.Items.Add(new ListItem("XL", "SHXL2"));
                    lstFruits.Items.Add(new ListItem("Indigo", "HPIndigo"));
                    lstFruits.Items.Add(new ListItem("Dimensionadora", "DIMENSIONA"));
                    lstFruits.Items.Add(new ListItem("Guillotina Polar 115-1", "FC58"));
                    lstFruits.Items.Add(new ListItem("Guillotina Polar 115-2", "FC59"));
                    lstFruits.Items.Add(new ListItem("Guillotina Polar ED", "FC60"));
                    lstFruits.Items.Add(new ListItem("Dobladora Stahl 2", "FM85"));
                    lstFruits.Items.Add(new ListItem("Dobladora Stahl 3", "FM86"));
                    lstFruits.Items.Add(new ListItem("Dobladora Stahl 4", "FM87"));
                    lstFruits.Items.Add(new ListItem("Dobladora Stahl 5", "FM88"));
                    lstFruits.Items.Add(new ListItem("Dobladora MBO", "FM89"));
                    lstFruits.Items.Add(new ListItem("Cosedora 321_1", "HT248"));
                    lstFruits.Items.Add(new ListItem("Cosedora 321_2", "HT249"));
                    lstFruits.Items.Add(new ListItem("Cosedora Prima", "HT250"));
                    lstFruits.Items.Add(new ListItem("Inventa Plus I", "SL001"));
                    lstFruits.Items.Add(new ListItem("Ventura", "SL001"));
                    lstFruits.Items.Add(new ListItem("Wohlemberg", "TT4"));
                    lstFruits.Items.Add(new ListItem("Nordbinder", "UB110"));
                    lstFruits.Items.Add(new ListItem("Horizon", "UB111"));
                    lstFruits.Items.Add(new ListItem("Trendbinder", "UB112"));
                    lstFruits.Items.Add(new ListItem("Corona C-18", "UB117"));
                    lstFruits.Items.Add(new ListItem("Case in Line", "CI45"));
                    lstFruits.Items.Add(new ListItem("Case Maker", "MA3"));
                    lstFruits.Items.Add(new ListItem("Alzadora Tapa Dura", "RB5-ALZ_TDUR"));
                    lstFruits.Items.Add(new ListItem("Espiral Womako", "SP001"));
                    lstFruits.Items.Add(new ListItem("Embolsadora", "PW80"));
                    lstFruits.Items.Add(new ListItem("Embolsadora SITMA", "SITMA"));
                    lstFruits.Items.Add(new ListItem("Manualidades", "MANUAL"));
                    lstFruits.Items.Add(new ListItem("Manualidades Tapa Dura", "MANUAL_TD"));
                    lstFruits.Items.Add(new ListItem("Sunipac", "Sonipac"));
                    lstFruits.Items.Add(new ListItem("Barniz UV Parejo", "TER_BAR_UV_P"));
                    lstFruits.Items.Add(new ListItem("Folia", "TER_FOLIA"));
                    lstFruits.Items.Add(new ListItem("Troquel - Plisado", "TER_TROQ_PLI"));
                    lstFruits.Items.Add(new ListItem("UV Selectivo", "TER_UV_SELEC"));
                    lstFruits.Items.Add(new ListItem("Tercero", "TERCERO"));
                    lstFruits.Items.Add(new ListItem("Troqueladora SBB", "DC9"));
                    lstFruits.Items.Add(new ListItem("Pegadora de Guarda", "TP59"));
                    break;
            }

        }

        protected void lbImprimir_Click(object sender, EventArgs e)
        {
            ProgramaProduccion_Controller sc = new ProgramaProduccion_Controller();
            string Maquinas = ""; int count = 0;
            foreach (ListItem item in lstFruits.Items)
            {
                if (item.Selected)
                {
                    Maquinas += item.Value + ",";
                    count++;
                }
            }
            if (count > 0)
            {
                Maquinas = Maquinas.Substring(0, Maquinas.Length - 1);
                int Mes = DateTime.Now.Month; int MesRecorrido = DateTime.Now.Month;
                int Año = DateTime.Now.Year; int AñoRecorrido = DateTime.Now.Year;
                int MesesBusqueda = Convert.ToInt32(ddlMeses.SelectedValue.ToString());
                DateTime FechaInicio;int ddm;DateTime FechaTermino;
                List<ProgramaProduccion_Extendido> lista = new List<ProgramaProduccion_Extendido>();
                if (Mes + MesesBusqueda > 12)
                {
                    FechaInicio = new DateTime(Año, Mes, 1);
                    ddm = DateTime.DaysInMonth(Año, FechaInicio.AddMonths(MesesBusqueda).Month);
                    FechaTermino = new DateTime((Año + 1), FechaInicio.AddMonths(MesesBusqueda).Month, ddm);
                }
                else
                {
                    FechaInicio = new DateTime(Año, Mes, 1);
                    ddm = DateTime.DaysInMonth(Año, FechaInicio.AddMonths(MesesBusqueda).Month);
                    FechaTermino = new DateTime(Año, FechaInicio.AddMonths(MesesBusqueda).Month, ddm);
                }


                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('_ProgramaProduccion_Ext.aspx?fi=" + FechaInicio.ToString() + "&ft=" + FechaTermino.ToString() + "&maq=" + Maquinas + "&meses=" + ddlMeses.SelectedValue.ToString() + "');", true);
            }
        }
    }
}
