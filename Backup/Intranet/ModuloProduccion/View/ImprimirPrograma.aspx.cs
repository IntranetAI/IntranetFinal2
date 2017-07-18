using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloProduccion.Controller;
using System.Globalization;

namespace Intranet.ModuloProduccion.View
{
    public partial class ImprimirPrograma : System.Web.UI.Page
    {
        //List<InformeProgramacion> lista = new List<InformeProgramacion>();
        SeguimientoController sc = new SeguimientoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
                #region datosBasura
                //string Seccion = Request.QueryString["Sec"].ToString();
                //string Maquina = Request.QueryString["Maquinas"].ToString();
                //string FechaInicio = Request.QueryString["Fci"].ToString();
                //string FechaTermino = Request.QueryString["Fct"].ToString();
                //string[] ArraysMaquina = {"" };
                //if (Seccion == "Todas")
                //{
                //     //ArraysMaquina = { "Lithoman", "WEB 1", "Web 2", "M600", "goss", "10p", "8p", "4p", "CD", "XL","KBA" };
                //}
                //string Resultado = "";
                //string[] algo = { "Lithoman", "WEB 1", "Web 2", "M600", "goss", "10p", "8p", "4p", "CD", "XL", "KBA Rapida 106" };

                //string Titulo = "";
                //string Semana1 = "";
                //string Semana2 = "";
                //string Semana3 = "";
                //string Semana4 = "";
                //string Semana5 = "";
                //string Area = "";
                //CultureInfo espanol = new CultureInfo("es-ES");

                //string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
                //DateTime fecha = Convert.ToDateTime(fechaHoy);
                //int diasMes = 30;
                ////lista = sc.Lista_ProgramaProduccion_Imprimir(Convert.ToDateTime(fechaHoy), Convert.ToDateTime(fechaHoy).AddDays(+30));

                //foreach (string algo2 in algo)//&& o.Maquina.ToLower() == "LITHOMAN"
                //{
                //    int CountSemana = 1;
                //    bool completaSemana = false;
                //    for (int i = 0; i <= diasMes; i++)
                //    {
                //        fecha = Convert.ToDateTime(fechaHoy).AddDays(+i);
                //        int dia2 = (int)fecha.DayOfWeek;

                //        #region ENCABEZADO SEMANAS
                //        if (CountSemana == 1)
                //        {
                //            if (dia2 == 1)//lunes
                //            {
                //                if (completaSemana != false)
                //                {
                //                    Semana1 = Semana1 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                        Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                }
                //                else
                //                {
                //                    Semana1 = Semana1 + "<table style='width:100%;'>" +
                //                             "<tr>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                      "<b>Lunes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Martes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                     "<b>Miércoles</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Jueves</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Viernes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Sábado</b></td>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                    "<b>Domingo</b></td>" +
                //                               "</tr>" +

                //                               "<tr>" +
                //                               "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                    completaSemana = true;
                //                }
                //            }
                //            else if (dia2 == 2)//martes
                //            {
                //                if (completaSemana != false)
                //                {
                //                    Semana1 = Semana1 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                        Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                }
                //                else
                //                {
                //                    Semana1 = Semana1 + "<table style='width:100%;'>" +
                //                             "<tr>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                      "<b>Lunes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Martes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                     "<b>Miércoles</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Jueves</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Viernes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Sábado</b></td>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                    "<b>Domingo</b></td>" +
                //                               "</tr>" +

                //                               "<tr>" +
                //                               "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-1).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                    completaSemana = true;
                //                }
                //            }
                //            else if (dia2 == 3)//miercoles
                //            {
                //                if (completaSemana != false)
                //                {
                //                    Semana1 = Semana1 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                       Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                }
                //                else
                //                {
                //                    Semana1 = Semana1 + "<table style='width:100%;'>" +
                //                             "<tr>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                      "<b>Lunes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Martes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                     "<b>Miércoles</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Jueves</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Viernes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Sábado</b></td>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                    "<b>Domingo</b></td>" +
                //                               "</tr>" +

                //                               "<tr>" +
                //                               "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-2).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-1).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                    completaSemana = true;
                //                }
                //            }
                //            else if (dia2 == 4)//jueves
                //            {
                //                if (completaSemana != false)
                //                {
                //                    Semana1 = Semana1 + "<td  bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                         Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                }
                //                else
                //                {
                //                    Semana1 = Semana1 + "<table style='width:100%;'>" +
                //                             "<tr>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                      "<b>Lunes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Martes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                     "<b>Miércoles</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Jueves</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Viernes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Sábado</b></td>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                    "<b>Domingo</b></td>" +
                //                               "</tr>" +

                //                               "<tr>" +
                //                               "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-3).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#D3D3D3' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-2).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-1).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                    completaSemana = true;
                //                }
                //            }
                //            else if (dia2 == 5)//viernes
                //            {
                //                if (completaSemana != false)
                //                {
                //                    Semana1 = Semana1 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                        Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                }
                //                else
                //                {
                //                    Semana1 = Semana1 + "<table style='width:100%;'>" +
                //                             "<tr>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                      "<b>Lunes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Martes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                     "<b>Miércoles</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Jueves</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Viernes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Sábado</b></td>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                    "<b>Domingo</b></td>" +
                //                               "</tr>" +

                //                               "<tr>" +
                //                               "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-4).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-3).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-2).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-1).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                    completaSemana = true;
                //                }
                //            }
                //            else if (dia2 == 6)//sabado
                //            {
                //                if (completaSemana != false)
                //                {
                //                    Semana1 = Semana1 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                        Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                }
                //                else
                //                {
                //                    Semana1 = Semana1 + "<table style='width:100%;'>" +
                //                             "<tr>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                      "<b>Lunes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Martes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                     "<b>Miércoles</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Jueves</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Viernes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Sábado</b></td>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                    "<b>Domingo</b></td>" +
                //                               "</tr>" +

                //                               "<tr>" +
                //                               "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-5).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-4).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-3).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-2).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-1).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //                    completaSemana = true;
                //                }
                //            }
                //            else if (dia2 == 0)//domingo
                //            {
                //                if (completaSemana != false)
                //                {
                //                    Semana1 = Semana1 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                                        Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>" +
                //                                        "</tr>";
                //                    CountSemana = CountSemana + 1;
                //                }
                //                else
                //                {
                //                    Semana1 = Semana1 + "<table style='width:100%;'>" +
                //                             "<tr>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                      "<b>Lunes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Martes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                     "<b>Miércoles</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Jueves</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Viernes</b></td>" +
                //                                   "<td style='width:14%;font-size: 14px;' align='center' >" +
                //                                    "<b>Sábado</b></td>" +
                //                                   "<td style='width:15%;font-size: 14px;' align='center' >" +
                //                                    "<b>Domingo</b></td>" +
                //                               "</tr>" +

                //                               "<tr>" +
                //                               "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-6).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-5).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-4).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-3).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-2).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                               Convert.ToDateTime(fechaHoy).AddDays(-1).ToString("d MMMM", espanol) + "</b></td>" +
                //                               "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                              Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>" +
                //                           "</tr>";
                //                    completaSemana = true;
                //                    CountSemana = CountSemana + 1;
                //                }
                //            }
                //        }
                //        else if (CountSemana == 2)
                //        {
                //            if (dia2 == 1)
                //            {
                //                Semana2 = Semana2 + "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                    Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //            }
                //            else if (dia2 != 0 && dia2 != 1)
                //            {
                //                Semana2 = Semana2 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //            }
                //            else
                //            {
                //                Semana2 = Semana2 + "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>" +
                //                "</tr>";
                //                CountSemana = CountSemana + 1;
                //            }

                //        }
                //        else if (CountSemana == 3)
                //        {
                //            if (dia2 == 1)
                //            {
                //                Semana3 = Semana3 + "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                    Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //            }
                //            else if (dia2 != 0 && dia2 != 1)
                //            {
                //                Semana3 = Semana3 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //            }
                //            else
                //            {
                //                Semana3 = Semana3 + "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>" +
                //                "</tr>";
                //                CountSemana = CountSemana + 1;
                //            }
                //        }
                //        else if (CountSemana == 4)
                //        {
                //            if (dia2 == 1)
                //            {
                //                Semana4 = Semana4 + "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                    Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //            }
                //            else if (dia2 != 0 && dia2 != 1)
                //            {
                //                Semana4 = Semana4 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //            }
                //            else
                //            {
                //                Semana4 = Semana4 + "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>" +
                //                "</tr>";
                //                CountSemana = CountSemana + 1;
                //            }
                //        }
                //        else if (CountSemana == 5)
                //        {
                //            if (dia2 == 1)
                //            {
                //                Semana5 = Semana5 + "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                    Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //            }
                //            else if (dia2 != 0 && dia2 != 1)
                //            {
                //                Semana5 = Semana5 + "<td bgcolor='#DCDCDC' style='width:14%;font-size: 12px;' align='center' ><b>" +
                //                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>";
                //            }
                //            else
                //            {
                //                Semana5 = Semana5 + "<td bgcolor='#DCDCDC' style='width:15%;font-size: 12px;' align='center' ><b>" +
                //                Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("d MMMM", espanol) + "</b></td>" +
                //                "</tr>";
                //                CountSemana = CountSemana + 1;
                //            }
                //        }
                //        #endregion
                //    }

                //    if (algo2.ToLower() == "lithoman" || algo2.ToLower() == "web 1" || algo2.ToLower() == "web 2" || algo2.ToLower() == "m600" || algo2.ToLower() == "goss")
                //    {
                //        Area = "Rotativas";
                //    }
                //    else
                //    {
                //        Area = "Planas";
                //    }

                //    Titulo = "<div style='height:680px'><div align='center'><h1 style='font-size: 12pt;'>" + algo2.ToUpper() + "</h1></div>" +
                //        "<div style='font-size: 7pt;'><span style='float:right;'> " +
                //        "<b> <asp:Label ID='lblCreacion' runat='server' Text='Label'>" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</asp:Label></b></span><b>" + Area + "</b></div>";
                //    //  lblCreacion.Text = "cjerias - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                //    int dia = (int)fecha.DayOfWeek;

                //    int ContadorSemana = 1;
                //    bool CompletarSemana1 = false;

                //    for (int i = 0; i <= diasMes; i++)
                //    {
                //        fecha = Convert.ToDateTime(fechaHoy).AddDays(+i);
                //        int dia2 = (int)fecha.DayOfWeek;

                //        #region SEMANA1
                //        if (ContadorSemana == 1)
                //        {
                //            if (dia2 == 1)//lunes
                //            {
                //                if (CompletarSemana1 != false)
                //                {
                //                    string dia4 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia4 = dia4 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }
                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }
                //                    string TotalHoras = "";
                //                    string Hora = "";
                //                    string Minuto = "";
                //                    if (Horas != 0 && minutos != 0)
                //                    {
                //                        if (Horas.ToString().Count() == 1)
                //                        {
                //                            Hora = "0" + Horas.ToString();
                //                        }
                //                        else
                //                        {
                //                            Hora = Horas.ToString();
                //                        }
                //                        if (minutos.ToString().Count() == 1)
                //                        {
                //                            Minuto = "0" + minutos.ToString();
                //                        }
                //                        else
                //                        {
                //                            Minuto = minutos.ToString();
                //                        }
                //                        TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                    }
                //                    Semana1 = Semana1 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                        "<div style='overflow: hidden;max-height: 155px;'>" +
                //                        dia4 +
                //                        Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //                }
                //                else
                //                {
                //                    string dia6 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower().ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia6 = dia6 + "<div><span style='float:right;line-height:100%;'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }

                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }

                //                    Relleno = Relleno + "";
                //                    Semana1 = Semana1 + "<tr style='height:100px;'>" +
                //                     "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "<div style='overflow: hidden;max-height: 155px;'>" +
                //                     dia6 +
                //                     Relleno +
                //                     "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Horas.ToString() + ":" + minutos.ToString() + "</span></div>" +
                //                     "</div>" +
                //                     "</td>";
                //                    CompletarSemana1 = true;
                //                }
                //            }
                //            else if (dia2 == 2)//martes
                //            {
                //                if (CompletarSemana1 != false)
                //                {
                //                    string dia4 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia4 = dia4 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }
                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }
                //                    string TotalHoras = "";
                //                    string Hora = "";
                //                    string Minuto = "";
                //                    if (Horas != 0 && minutos != 0)
                //                    {
                //                        if (Horas.ToString().Count() == 1)
                //                        {
                //                            Hora = "0" + Horas.ToString();
                //                        }
                //                        else
                //                        {
                //                            Hora = Horas.ToString();
                //                        }
                //                        if (minutos.ToString().Count() == 1)
                //                        {
                //                            Minuto = "0" + minutos.ToString();
                //                        }
                //                        else
                //                        {
                //                            Minuto = minutos.ToString();
                //                        }
                //                        TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                    }
                //                    Semana1 = Semana1 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                        "<div style='overflow: hidden;max-height: 155px;'>" +
                //                        dia4 +
                //                        Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //                }
                //                else
                //                {
                //                    string dia6 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia6 = dia6 + "<div><span style='float:right;line-height:100%;'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }

                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }

                //                    Relleno = Relleno + "";
                //                    Semana1 = Semana1 + "<tr style='height:100px;'>" +
                //                     "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "<div style='overflow: hidden;max-height: 155px;'>" +
                //                     dia6 +
                //                     Relleno +
                //                     "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Horas.ToString() + ":" + minutos.ToString() + "</span></div>" +
                //                     "</div>" +
                //                     "</td>";
                //                    CompletarSemana1 = true;
                //                }
                //            }
                //            else if (dia2 == 3)//miercoles
                //            {
                //                if (CompletarSemana1 != false)
                //                {
                //                    string dia4 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia4 = dia4 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }
                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }
                //                    string TotalHoras = "";
                //                    string Hora = "";
                //                    string Minuto = "";
                //                    if (Horas != 0 && minutos != 0)
                //                    {
                //                        if (Horas.ToString().Count() == 1)
                //                        {
                //                            Hora = "0" + Horas.ToString();
                //                        }
                //                        else
                //                        {
                //                            Hora = Horas.ToString();
                //                        }
                //                        if (minutos.ToString().Count() == 1)
                //                        {
                //                            Minuto = "0" + minutos.ToString();
                //                        }
                //                        else
                //                        {
                //                            Minuto = minutos.ToString();
                //                        }
                //                        TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                    }
                //                    Semana1 = Semana1 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                        "<div style='overflow: hidden;max-height: 155px;'>" +
                //                        dia4 +
                //                        Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //                }
                //                else
                //                {
                //                    string dia6 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia6 = dia6 + "<div><span style='float:right;line-height:100%;'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }

                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }

                //                    Relleno = Relleno + "";
                //                    Semana1 = Semana1 + "<tr style='height:100px;'>" +
                //                     "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 125px;vertical-align:top;' >" +
                //                     "<div style='overflow: hidden;max-height: 155px;'>" +
                //                     dia6 +
                //                     Relleno +
                //                     "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Horas.ToString() + ":" + minutos.ToString() + "</span></div>" +
                //                     "</div>" +
                //                     "</td>";
                //                    CompletarSemana1 = true;
                //                }
                //            }
                //            else if (dia2 == 4)//jueves
                //            {
                //                if (CompletarSemana1 != false)
                //                {
                //                    string dia4 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia4 = dia4 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }
                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }
                //                    string TotalHoras = "";
                //                    string Hora = "";
                //                    string Minuto = "";
                //                    if (Horas != 0 && minutos != 0)
                //                    {
                //                        if (Horas.ToString().Count() == 1)
                //                        {
                //                            Hora = "0" + Horas.ToString();
                //                        }
                //                        else
                //                        {
                //                            Hora = Horas.ToString();
                //                        }
                //                        if (minutos.ToString().Count() == 1)
                //                        {
                //                            Minuto = "0" + minutos.ToString();
                //                        }
                //                        else
                //                        {
                //                            Minuto = minutos.ToString();
                //                        }
                //                        TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                    }
                //                    Semana1 = Semana1 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                        "<div style='overflow: hidden;max-height: 155px;'>" +
                //                        dia4 +
                //                        Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //                }
                //                else
                //                {
                //                    string dia6 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia6 = dia6 + "<div><span style='float:right;line-height:100%;'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }

                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }

                //                    Relleno = Relleno + "";
                //                    Semana1 = Semana1 + "<tr style='height:100px;'>" +
                //                     "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "<div style='overflow: hidden;max-height: 155px;'>" +
                //                     dia6 +
                //                     Relleno +
                //                     "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Horas.ToString() + ":" + minutos.ToString() + "</span></div>" +
                //                     "</div>" +
                //                     "</td>";
                //                    CompletarSemana1 = true;
                //                }
                //            }
                //            else if (dia2 == 5)//viernes
                //            {
                //                if (CompletarSemana1 != false)
                //                {
                //                    string dia4 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia4 = dia4 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }
                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }
                //                    string TotalHoras = "";
                //                    string Hora = "";
                //                    string Minuto = "";
                //                    if (Horas != 0 && minutos != 0)
                //                    {
                //                        if (Horas.ToString().Count() == 1)
                //                        {
                //                            Hora = "0" + Horas.ToString();
                //                        }
                //                        else
                //                        {
                //                            Hora = Horas.ToString();
                //                        }
                //                        if (minutos.ToString().Count() == 1)
                //                        {
                //                            Minuto = "0" + minutos.ToString();
                //                        }
                //                        else
                //                        {
                //                            Minuto = minutos.ToString();
                //                        }
                //                        TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                    }
                //                    Semana1 = Semana1 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                        "<div style='overflow: hidden;max-height: 155px;'>" +
                //                        dia4 +
                //                        Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //                }
                //                else
                //                {
                //                    string dia6 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia6 = dia6 + "<div><span style='float:right;line-height:100%;'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }

                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }

                //                    Relleno = Relleno + "";
                //                    Semana1 = Semana1 + "<tr style='height:100px;'>" +
                //                     "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "<div style='overflow: hidden;max-height: 155px;'>" +
                //                     dia6 +
                //                     Relleno +
                //                     "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Horas.ToString() + ":" + minutos.ToString() + "</span></div>" +
                //                     "</div>" +
                //                     "</td>";
                //                    CompletarSemana1 = true;
                //                }
                //            }
                //            else if (dia2 == 6)//sabado
                //            {
                //                if (CompletarSemana1 != false)
                //                {
                //                    string dia4 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia4 = dia4 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }
                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }
                //                    string TotalHoras = "";
                //                    string Hora = "";
                //                    string Minuto = "";
                //                    if (Horas != 0 && minutos != 0)
                //                    {
                //                        if (Horas.ToString().Count() == 1)
                //                        {
                //                            Hora = "0" + Horas.ToString();
                //                        }
                //                        else
                //                        {
                //                            Hora = Horas.ToString();
                //                        }
                //                        if (minutos.ToString().Count() == 1)
                //                        {
                //                            Minuto = "0" + minutos.ToString();
                //                        }
                //                        else
                //                        {
                //                            Minuto = minutos.ToString();
                //                        }
                //                        TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                    }
                //                    Semana1 = Semana1 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                        "<div style='overflow: hidden;max-height: 155px;'>" +
                //                        dia4 +
                //                        Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //                }
                //                else
                //                {
                //                    string dia6 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia6 = dia6 + "<div><span style='float:right;line-height:100%;'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }

                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }

                //                    Relleno = Relleno + "";
                //                    Semana1 = Semana1 + "<tr style='height:100px;'>" +
                //                     "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "<div style='overflow: hidden;max-height: 125px;'>" +
                //                     dia6 +
                //                     Relleno +
                //                     "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Horas.ToString() + ":" + minutos.ToString() + "</span></div>" +
                //                     "</div>" +
                //                     "</td>";
                //                    CompletarSemana1 = true;
                //                }
                //            }
                //            else if (dia2 == 0)//domingo
                //            {
                //                if (CompletarSemana1 != false)
                //                {
                //                    string dia4 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia4 = dia4 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }
                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }
                //                    string TotalHoras = "";
                //                    string Hora = "";
                //                    string Minuto = "";
                //                    if (Horas != 0 && minutos != 0)
                //                    {
                //                        if (Horas.ToString().Count() == 1)
                //                        {
                //                            Hora = "0" + Horas.ToString();
                //                        }
                //                        else
                //                        {
                //                            Hora = Horas.ToString();
                //                        }
                //                        if (minutos.ToString().Count() == 1)
                //                        {
                //                            Minuto = "0" + minutos.ToString();
                //                        }
                //                        else
                //                        {
                //                            Minuto = minutos.ToString();
                //                        }
                //                        TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                    }
                //                    Semana1 = Semana1 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                        "<div style='overflow: hidden;max-height: 155px;'>" +
                //                        dia4 +
                //                        Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>" +
                //                        "</tr>";
                //                    ContadorSemana = ContadorSemana + 1;

                //                }
                //                else
                //                {
                //                    string dia6 = "";
                //                    string Relleno = "";
                //                    int countRelleno = 0;
                //                    DateTime total;
                //                    int Horas = 0;
                //                    int minutos = 0;
                //                    string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                    foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                    {
                //                        countRelleno = countRelleno + 1;
                //                        total = Convert.ToDateTime(ip.Horas);
                //                        Horas = Horas + total.Hour;
                //                        minutos = minutos + total.Minute;
                //                        if (minutos >= 60)
                //                        {
                //                            Horas = Horas + 1;
                //                            minutos = minutos - 60;
                //                        }
                //                        dia6 = dia6 + "<div><span style='float:right;line-height:100%;'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                    }

                //                    int cc = (9 - countRelleno);
                //                    for (int j = 0; j <= cc; j++)
                //                    {
                //                        Relleno = Relleno + "</br>";
                //                    }

                //                    Relleno = Relleno + "";
                //                    Semana1 = Semana1 + "<tr style='height:100px;'>" +
                //                     "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                         "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "</td>" +
                //                     "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "</td>" +
                //                     "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                     "<div style='overflow: hidden;max-height: 155px;'>" +
                //                     dia6 +
                //                     Relleno +
                //                     "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Horas.ToString() + ":" + minutos.ToString() + "</span></div>" +
                //                     "</div>" +
                //                     "</td>";
                //                    CompletarSemana1 = true;
                //                }

                //            }
                //        }

                //        #endregion

                //        #region SEMANA2
                //        else if (ContadorSemana == 2)
                //        {
                //            if (dia2 == 1)//lunes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana2 = Semana2 + "<tr style='height:100px;max-width: 100px;'>" +
                //                    "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //            }
                //            else if (dia2 == 2)//martes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana2 = Semana2 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 3)//miercoles
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana2 = Semana2 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 4)//jueves
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana2 = Semana2 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 5)//viernes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana2 = Semana2 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 6)//sabado
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana2 = Semana2 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //            }
                //            else if (dia2 == 0)//domingo
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana2 = Semana2 + "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>" +
                //                    "</tr>";
                //                //    "</table>";
                //                ContadorSemana = ContadorSemana + 1;
                //            }

                //        }
                //        #endregion

                //        #region SEMANA3
                //        else if (ContadorSemana == 3)
                //        {
                //            if (dia2 == 1)//lunes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana3 = Semana3 + "<tr style='height:100px;max-width: 100px;'>" +
                //                    "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //            }
                //            else if (dia2 == 2)//martes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana3 = Semana3 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 3)//miercoles
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana3 = Semana3 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 4)//jueves
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana3 = Semana3 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 5)//viernes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana3 = Semana3 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 6)//sabado
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana3 = Semana3 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //            }
                //            else if (dia2 == 0)//domingo
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana3 = Semana3 + "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>" +
                //                    "</tr>";
                //                //"</table>";
                //                ContadorSemana = ContadorSemana + 1;
                //            }

                //        }
                //        #endregion

                //        #region SEMANA4
                //        else if (ContadorSemana == 4)
                //        {
                //            if (dia2 == 1)//lunes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana4 = Semana4 + "<tr style='height:100px;max-width: 100px;'>" +
                //                    "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //            }
                //            else if (dia2 == 2)//martes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana4 = Semana4 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 3)//miercoles
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana4 = Semana4 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 4)//jueves
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana4 = Semana4 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 5)//viernes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana4 = Semana4 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 6)//sabado
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana4 = Semana4 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //            }
                //            else if (dia2 == 0)//domingo
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana4 = Semana4 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>" +
                //                    "</tr>" +
                //                 "</table>";
                //                ContadorSemana = ContadorSemana + 1;
                //            }

                //        }
                //        #endregion

                //        #region SEMANA5
                //        else if (ContadorSemana == 5)
                //        {
                //            if (dia2 == 1)//lunes
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana5 = Semana5 + "<tr style='height:100px;max-width: 100px;'>" +
                //                    "<td style='width:15%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //            }
                //            else if (dia2 == 2)//martes
                //            {

                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana5 = Semana5 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 3)//miercoles
                //            {

                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana5 = Semana5 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 4)//jueves
                //            {

                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana5 = Semana5 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 5)//viernes
                //            {

                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana5 = Semana5 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";

                //            }
                //            else if (dia2 == 6)//sabado
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana5 = Semana5 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>";
                //            }
                //            else if (dia2 == 0)//domingo
                //            {
                //                string dia1 = "";
                //                string Relleno = "";
                //                int countRelleno = 0;
                //                DateTime total;
                //                int Horas = 0;
                //                int minutos = 0;
                //                string ab = Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy");
                //                foreach (InformeProgramacion ip in lista.Where(o => o.VB == Convert.ToDateTime(fechaHoy).AddDays(+i).ToString("dd/MM/yyyy") && o.Maquina.ToLower() == algo2.ToLower()))//&& o.Maquina.ToLower() == "LITHOMAN"
                //                {
                //                    countRelleno = countRelleno + 1;
                //                    total = Convert.ToDateTime(ip.Horas);
                //                    Horas = Horas + total.Hour;
                //                    minutos = minutos + total.Minute;
                //                    if (minutos >= 60)
                //                    {
                //                        Horas = Horas + 1;
                //                        minutos = minutos - 60;
                //                    }
                //                    dia1 = dia1 + "<div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>";
                //                }
                //                int cc = (9 - countRelleno);
                //                for (int j = 0; j <= cc; j++)
                //                {
                //                    Relleno = Relleno + "</br>";
                //                }
                //                string TotalHoras = "";
                //                string Hora = "";
                //                string Minuto = "";
                //                if (Horas != 0 && minutos != 0)
                //                {
                //                    if (Horas.ToString().Count() == 1)
                //                    {
                //                        Hora = "0" + Horas.ToString();
                //                    }
                //                    else
                //                    {
                //                        Hora = Horas.ToString();
                //                    }
                //                    if (minutos.ToString().Count() == 1)
                //                    {
                //                        Minuto = "0" + minutos.ToString();
                //                    }
                //                    else
                //                    {
                //                        Minuto = minutos.ToString();
                //                    }
                //                    TotalHoras = "<div  style='vertical-align:bottom;'><span style='float:right;line-height:100%;'>" + Hora.ToString() + ":" + Minuto.ToString() + "</span></div>";
                //                }
                //                Semana5 = Semana5 + "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                //                    "<div style='overflow: hidden;max-height: 155px;'>" +
                //                    dia1 +
                //                     Relleno +
                //                        TotalHoras +
                //                        "</div>" +
                //                        "</td>" +
                //                    "</tr>" +
                //                    "</table>";
                //                ContadorSemana = ContadorSemana + 1;
                //            }

                //        }
                //        #endregion
                //    }


                //    Resultado = Resultado + Titulo + Semana1 + Semana2 + Semana3 + Semana4 + "</div><div style='page-break-before: always;'></div>";
                //    Titulo = "";
                //    Semana1 = "";
                //    Semana2 = "";
                //    Semana3 = "";
                //    Semana4 = "";
                //    Semana5 = "";
                //}
                //Label2.Text = Resultado.Substring(0, Resultado.Length - 97);
                #endregion
            }
        }

        public void CargarDatos()
        {
            try
            {
                string Seccion = Request.QueryString["Sec"].ToString();
                string Maquina = Request.QueryString["Maquinas"].ToString().Replace("Speed Master","");
                string Sector = Request.QueryString["strid"].ToString();
                string[] str = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
                DateTime f1 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                List<InformeProgramacion> lista = new List<InformeProgramacion>();
                if (Convert.ToInt32(Sector) == 1)
                {
                    lista = sc.Lista_ProgramaProduccion_Imprimir2(f1, Convert.ToDateTime(DateTime.Now).AddDays(+21), Seccion, Maquina).Where(x => (x.VBdet != "Encuadernación" && x.VBdet != "Manualidades")).ToList();
                }
                else
                {
                    lista = sc.Lista_ProgramaProduccion_Imprimir2(f1, Convert.ToDateTime(DateTime.Now).AddDays(+21), Seccion, Maquina).Where(x => (x.VBdet != "Terceros" && x.VBdet != "Digital" && x.VBdet != "Rotativa" && x.VBdet != "Planas")).ToList();
                }
                string Titulo = "";
                foreach (string MaquinaFor in lista.Select(o => o.Maquina).Distinct())
                {
                    string Area = "";
                    switch (MaquinaFor.ToUpper())
                    {
                        case "LITHOMAN": Area = "Rotativas";break;
                        case "WEB 1": Area = "Rotativas";break;
                        case "WEB 2": Area = "Rotativas";break;
                        case "M600": Area = "Rotativas";break;
                        case "GOSS": Area = "Rotativas";break;
                        case "INDIGO": Area = "Digital";break;
                        case "Terceros": Area = "TERCEROS";break;
                        case "XL": Area = "Planas";break;
                        case "KBA Rapida 106": Area = "Planas";break;
                        case "10P": Area = "Planas";break;
                        default: Area ="Ecuadernación"; break;
                    }
                    
                    Titulo += "<div style='height:680px'><div align='center'><h1 style='font-size: 12pt;'>" + MaquinaFor.ToUpper() + "</h1></div>" +
                            "<div style='font-size: 7pt;'><span style='float:right;'> " +
                            "<b>" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</b></span><b>" + Area + "</b></div>";

                    #region TablaDetalleMaquina
                    string tabla = "<table style='width:100%;height:665px;'>" +//
                                                 "<tr>" +
                                                       "<td style='width:15%;height:19px;font-size: 12px;' align='center' >" +
                                                          "<b>Lunes</b></td>" +
                                                       "<td style='width:14%;height:19px;font-size: 12px;' align='center' >" +
                                                        "<b>Martes</b></td>" +
                                                       "<td style='width:14%;height:19px;font-size: 12px;' align='center' >" +
                                                         "<b>Miércoles</b></td>" +
                                                       "<td style='width:14%;height:19px;font-size: 12px;' align='center' >" +
                                                        "<b>Jueves</b></td>" +
                                                       "<td style='width:14%;height:19px;font-size: 12px;' align='center' >" +
                                                        "<b>Viernes</b></td>" +
                                                       "<td style='width:14%;height:19px;font-size: 12px;' align='center' >" +
                                                        "<b>Sábado</b></td>" +
                                                       "<td style='width:15%;height:19px;font-size: 12px;' align='center' >" +
                                                        "<b>Domingo</b></td>" +
                                                   "</tr>";
                    DateTime fechaHoy = DateTime.Now;
                    string Relleno = "<td style='width:14%;overflow: hidden;max-height: 155px;vertical-align:top;' >" +
                                            "<div style='overflow: hidden;max-height: 155px;'></div></td>";
                    int ContadorDomingos = 0;
                    for (int i = 0; i <= 20; i++)
                    {
                        DateTime fecha = fechaHoy.AddDays(+i);
                        int dia2 = (int)fecha.DayOfWeek;

                        CultureInfo espanol = new CultureInfo("es-ES");
                        if (i == 0)
                        {
                            tabla += "<tr>";
                            switch (dia2)
                            {
                                case 1:
                                    for (int y = 0; y <= 6; y++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+y).ToString("d MMMM", espanol) + "</b></td>";
                                    } break;
                                case 2:
                                    tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(-1).ToString("d MMMM", espanol) + "</b></td>";
                                    for (int y = 0; y <= 5; y++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+y).ToString("d MMMM", espanol) + "</b></td>";
                                    } break;
                                case 3:
                                    for (int z = -2; z <= 0; z++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+z).ToString("d MMMM", espanol) + "</b></td>";
                                    }
                                    for (int y = 1; y <= 4; y++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+y).ToString("d MMMM", espanol) + "</b></td>";
                                    } break;
                                case 4:
                                    for (int z = -3; z <= 0; z++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+z).ToString("d MMMM", espanol) + "</b></td>";
                                    }
                                    for (int y = 1; y <= 3; y++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+y).ToString("d MMMM", espanol) + "</b></td>";
                                    } break;
                                case 5:
                                    for (int z = -4; z <= 0; z++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+z).ToString("d MMMM", espanol) + "</b></td>";
                                    }
                                    for (int y = 1; y <= 2; y++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+y).ToString("d MMMM", espanol) + "</b></td>";
                                    } break;
                                case 6:
                                    for (int z = -5; z <= 0; z++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+z).ToString("d MMMM", espanol) + "</b></td>";
                                    }
                                    for (int y = 1; y <= 1; y++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+y).ToString("d MMMM", espanol) + "</b></td>";
                                    } break;
                                default:
                                    for (int z = -6; z <= 0; z++)
                                    {
                                        tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 10px;' align='center' ><b>" +
                                            Convert.ToDateTime(fecha).AddDays(+z).ToString("d MMMM", espanol) + "</b></td>";
                                    }
                                    break;
                            }

                            tabla += "</tr>";
                        }
                        if (dia2 == 1 && i != 0)
                        {
                            tabla += "<tr>";
                            for (int y = 0; y <= 6; y++)
                            {
                                tabla += "<td bgcolor='#DCDCDC' style='width:14%;height:17px;font-size: 8px;' align='center' ><b>" +
                                    Convert.ToDateTime(fecha).AddDays(+y).ToString("d MMMM", espanol) + "</b></td>";
                            }
                            tabla += "</tr>";


                        }

                        int HoraTotalesDia = 0;
                        string Ceros = "00";
                        switch (dia2)
                        {
                            case 1:
                                string det = "<tr><td style='width:14%;overflow: hidden;max-height: 175px;vertical-align:top;' >" +
                                         "<div style='overflow: hidden;min-height: 150px;max-height: 175px;'>";

                                foreach (InformeProgramacion info in lista.Where(o => o.FechaInicio == fecha.ToString("dd-MM-yyyy") && o.Maquina == MaquinaFor))
                                {
                                    det += "<div style='font-size: 8px;'><span style='float:right'>" + info.Horas + "</span><b>" + info.OT + "</b> " + info.NombreOT + " " + info.Pliegos + "</div>";
                                    HoraTotalesDia += Convert.ToInt32(info.NroForma);
                                }

                                TimeSpan t1 = TimeSpan.FromSeconds(Convert.ToDouble(HoraTotalesDia));
                                int Dias1 = t1.Days * 24;
                                tabla += det + "<div style='font-size: 8px;'><span style='float:right'>" + (t1.Hours + Dias1).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t1.Minutes.ToString().Length) + t1.Minutes.ToString()
                                        + "</span></div></div></td>";
                                HoraTotalesDia = 0;
                                break;
                            case 2:
                                string det2 = "<td style='width:14%;overflow: hidden;max-height: 175px;vertical-align:top;' >" +
                                         "<div style='overflow: hidden;min-height: 150px;max-height: 175px;'>";
                                foreach (InformeProgramacion info in lista.Where(o => o.FechaInicio == fecha.ToString("dd-MM-yyyy") && o.Maquina == MaquinaFor))
                                {
                                    det2 += "<div style='font-size: 8px;'><span style='float:right'>" + info.Horas + "</span><b>" + info.OT + "</b> " + info.NombreOT + " " + info.Pliegos + "</div>";
                                    HoraTotalesDia += Convert.ToInt32(info.NroForma);
                                }
                                TimeSpan t2 = TimeSpan.FromSeconds(Convert.ToDouble(HoraTotalesDia));
                                int Dias2 = t2.Days * 24;
                                if (i == 0)
                                {
                                    tabla += "<tr>" + Relleno + det2 + "<div><span style='float:right'>" + (t2.Hours + Dias2).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + "</div></td>";
                                }
                                else
                                {
                                    tabla += det2 + "<div><span style='float:right'>" + (t2.Hours + Dias2).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t2.Minutes.ToString().Length) + t2.Minutes.ToString() + "</div></td>";
                                }
                                HoraTotalesDia = 0;
                                break;
                            case 3:
                                string det3 = "<td style='width:14%;overflow: hidden;max-height: 175px;vertical-align:top;' >" +
                                         "<div style='overflow: hidden;min-height: 150px;max-height: 175px;'>";
                                foreach (InformeProgramacion info in lista.Where(o => o.FechaInicio == fecha.ToString("dd-MM-yyyy") && o.Maquina == MaquinaFor))
                                {
                                    det3 += "<div style='font-size: 8px;'><span style='float:right'>" + info.Horas + "</span><b>" + info.OT + "</b> " + info.NombreOT + " " + info.Pliegos + "</div>";
                                    HoraTotalesDia += Convert.ToInt32(info.NroForma);
                                }
                                TimeSpan t3 = TimeSpan.FromSeconds(Convert.ToDouble(HoraTotalesDia));
                                int Dias3 = t3.Days * 24;
                                if (i == 0)
                                {
                                    tabla += "<tr>" + Relleno + Relleno + det3 + "<div><span style='float:right'>" + (t3.Hours + Dias3).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + "</div></td>";
                                }
                                else
                                {
                                    tabla += det3 + "<div><span style='float:right'>" + (t3.Hours + Dias3).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t3.Minutes.ToString().Length) + t3.Minutes.ToString() + "</div></td>";
                                }
                                HoraTotalesDia = 0;
                                break;
                            case 4:
                                string det4 = "<td style='width:14%;overflow: hidden;max-height: 175px;vertical-align:top;' >" +
                                         "<div style='overflow: hidden;min-height: 150px;max-height: 175px;'>";
                                foreach (InformeProgramacion info in lista.Where(o => o.FechaInicio == fecha.ToString("dd-MM-yyyy") && o.Maquina == MaquinaFor))
                                {
                                    det4 += "<div style='font-size: 8px;'><span style='float:right'>" + info.Horas + "</span><b>" + info.OT + "</b> " + info.NombreOT + " " + info.Pliegos + "</div>";
                                    HoraTotalesDia += Convert.ToInt32(info.NroForma);
                                }
                                TimeSpan t4 = TimeSpan.FromSeconds(Convert.ToDouble(HoraTotalesDia));
                                int Dias4 = t4.Days * 24;
                                if (i == 0)
                                {
                                    tabla += "<tr>" + Relleno + Relleno + Relleno + det4 + "<div><span style='float:right'>" + (t4.Hours + Dias4).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + "</div></td>";
                                }
                                else
                                {
                                    tabla += det4 + "<div><span style='float:right'>" + (t4.Hours + Dias4).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t4.Minutes.ToString().Length) + t4.Minutes.ToString() + "</div></td>";
                                }
                                HoraTotalesDia = 0;
                                break;
                            case 5:
                                string det5 = "<td style='width:14%;overflow: hidden;max-height: 175px;vertical-align:top;' >" +
                                         "<div style='overflow: hidden;min-height: 150px;max-height: 175px;'>";
                                foreach (InformeProgramacion info in lista.Where(o => o.FechaInicio == fecha.ToString("dd-MM-yyyy") && o.Maquina == MaquinaFor))
                                {
                                    det5 += "<div style='font-size: 8px;'><span style='float:right'>" + info.Horas + "</span><b>" + info.OT + "</b> " + info.NombreOT + " " + info.Pliegos + "</div>";
                                    HoraTotalesDia += Convert.ToInt32(info.NroForma);
                                }
                                TimeSpan t5 = TimeSpan.FromSeconds(Convert.ToDouble(HoraTotalesDia));
                                int Dias5 = t5.Days * 24;
                                if (i == 0)
                                {
                                    tabla += "<tr>" + Relleno + Relleno + Relleno + Relleno + det5 + "<div><span style='float:right'>" + (t5.Hours + Dias5).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + "</div></td>";
                                }
                                else
                                {
                                    tabla += det5 + "<div><span style='float:right'>" + (t5.Hours + Dias5).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t5.Minutes.ToString().Length) + t5.Minutes.ToString() + "</div></td>";
                                }
                                HoraTotalesDia = 0;
                                break;
                            case 6:
                                string det6 = "<td style='width:14%;overflow: hidden;max-height: 175px;vertical-align:top;' >" +
                                         "<div style='overflow: hidden;min-height: 150px;max-height: 175px;'>";
                                foreach (InformeProgramacion info in lista.Where(o => o.FechaInicio == fecha.ToString("dd-MM-yyyy") && o.Maquina == MaquinaFor))
                                {
                                    det6 += "<div style='font-size: 8px;'><span style='float:right'>" + info.Horas + "</span><b>" + info.OT + "</b> " + info.NombreOT + " " + info.Pliegos + "</div>";
                                    HoraTotalesDia += Convert.ToInt32(info.NroForma);
                                }
                                TimeSpan t6 = TimeSpan.FromSeconds(Convert.ToDouble(HoraTotalesDia));
                                int Dias6 = t6.Days * 24;
                                if (i == 0)
                                {
                                    tabla += "<tr>" + Relleno + Relleno + Relleno + Relleno + Relleno + det6 + "<div><span style='float:right'>" + (t6.Hours + Dias6).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + "</div></td>";
                                }
                                else
                                {
                                    tabla += det6 + "<div><span style='float:right'>" + (t6.Hours + Dias6).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t6.Minutes.ToString().Length) + t6.Minutes.ToString() + "</div></td>";
                                }
                                HoraTotalesDia = 0;
                                break;
                            default:
                                string det7 = "<td style='width:14%;overflow: hidden;max-height: 175px;vertical-align:top;' >" +
                                         "<div style='overflow: hidden;min-height: 150px;max-height: 175px;'>";
                                foreach (InformeProgramacion info in lista.Where(o => o.FechaInicio == fecha.ToString("dd-MM-yyyy") && o.Maquina == MaquinaFor))
                                {
                                    det7 += "<div style='font-size: 8px;'><span style='float:right'>" + info.Horas + "</span><b>" + info.OT + "</b> " + info.NombreOT + " " + info.Pliegos + "</div>";
                                    HoraTotalesDia += Convert.ToInt32(info.NroForma);
                                }
                                TimeSpan t7 = TimeSpan.FromSeconds(Convert.ToDouble(HoraTotalesDia));
                                int Dias7 = t7.Days * 24;
                                if (i == 0)
                                {
                                    tabla += "<tr>" + Relleno + Relleno + Relleno + Relleno + Relleno + Relleno + det7 + "<div><span style='float:right'>" + (t7.Hours + Dias7).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + "</div></td></tr>";
                                }
                                else
                                {
                                    tabla += det7 + "<div><span style='float:right'>" + (t7.Hours + Dias7).ToString() + ":" + Ceros.Substring(0, Ceros.Length - t7.Minutes.ToString().Length) + t7.Minutes.ToString() + "</div></td></tr>";
                                }
                                ContadorDomingos++;
                                if (ContadorDomingos == 3)
                                {
                                    i = 21;
                                }
                                HoraTotalesDia = 0;
                                break;


                        }
                    }
                    if (tabla.Substring(tabla.Length - 3, 3) == "td>")
                    {
                        tabla += "</tr></table>";
                    }
                    else
                    {

                        tabla += "</table>";
                    }
                    #endregion

                    Titulo += tabla + "</div><div style='page-break-before: always;'></div>";


                    //contador de Domingo

                }

                Label2.Text = Titulo.Substring(0, Titulo.Length - 46);
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'>alert('No se a encontrado registro. intentelo más tarde\\n" + ex.Message + "');window.close();</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

    }
}