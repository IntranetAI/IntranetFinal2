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
    public partial class _ProgramaProduccion_Ext : System.Web.UI.Page
    {
        ProgramaProduccion_Controller sc = new ProgramaProduccion_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                try
                {
                    Label1.Text = Request.QueryString["fi"] + "   " + Request.QueryString["ft"] + "     " + Request.QueryString["maq"];

                    DateTime FechaInicio = Convert.ToDateTime(Request.QueryString["fi"]);
                    DateTime FechaTermino = Convert.ToDateTime(Request.QueryString["ft"]);

                    string Maquinas = Request.QueryString["maq"]; int meses = Convert.ToInt32(Request.QueryString["meses"]);
                    
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
                    int MesesBusqueda = meses;

                    List<ProgramaProduccion_Extendido> lista = new List<ProgramaProduccion_Extendido>();

                    lista = sc.Programa_Extendido(FechaInicio, FechaTermino, Maquinas);





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
                                            Dias += "<tr>" + "<td style='width:14%;overflow: hidden;max-height: 175px;height: 70px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                            break;
                                        case "martes":
                                            Semanas += "<tr>" + diavacio +
                                               "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                            Dias += "<tr>" + diasvacios + "<td style='width:14%;overflow: hidden;max-height: 175px;height: 70px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                            break;
                                        case "miércoles":
                                            Semanas += "<tr>" + diavacio + diavacio +
                                              "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                            Dias += "<tr>" + diasvacios + diasvacios +
                                                "<td style='width:14%;overflow: hidden;max-height: 175px;height: 70px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                            break;
                                        case "jueves":
                                            Semanas += "<tr>" + diavacio + diavacio + diavacio +
                                               "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                            Dias += "<tr>" + diasvacios + diasvacios + diasvacios +
                                                "<td style='width:14%;overflow: hidden;max-height: 175px;height: 70px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                            break;
                                        case "viernes":
                                            Semanas += "<tr>" + diavacio + diavacio + diavacio + diavacio +
                                               "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                            Dias += "<tr>" + diasvacios + diasvacios + diasvacios + diasvacios +
                                                "<td style='width:14%;overflow: hidden;max-height: 175px;height: 70px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                            break;
                                        case "sábado":
                                            Semanas += "<tr>" + diavacio + diavacio + diavacio + diavacio + diavacio +
                                               "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td>";
                                            Dias += "<tr>" + diasvacios + diasvacios + diasvacios + diasvacios + diasvacios +
                                                "<td style='width:14%;overflow: hidden;max-height: 175px;height: 70px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
                                            break;
                                        case "domingo":
                                            Semanas += "<tr>" + diavacio + diavacio + diavacio + diavacio + diavacio + diavacio +
                                               "<td bgcolor = '#DCDCDC' style = 'width:14%;height:17px;font-size: 10px;border: 1px solid black;' align = 'center'><b> " + new DateTime(AñoRecorrido, MesRecorrido, i).ToString("d MMMM", new CultureInfo("es-ES")) + " </b></td></tr>";
                                            Dias += "<tr>" + diasvacios + diasvacios + diasvacios + diasvacios + diasvacios + diasvacios +
                                                "<td style='width:14%;overflow: hidden;max-height: 175px;height: 70px;vertical-align:top;border: 1px solid black;'>" + detalleDia + "</td>";
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
                }catch(Exception ex)
                {
                    Label1.Text = ex.Message;
                }


            }

        }

   
    }
}