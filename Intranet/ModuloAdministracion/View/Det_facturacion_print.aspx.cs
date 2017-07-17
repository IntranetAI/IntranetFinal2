using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Model;
using Intranet.ModuloAdministracion.Controller;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloAdministracion.View
{
    public partial class Det_facturacion_print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OrdenController oc = new OrdenController();
                List<Consumo> lista = new List<Consumo>();
                Controller_Consumo controlCons = new Controller_Consumo();
                string Facturacion = "";
                int Pag = 0;
                string[] OTs = Request.QueryString["id"].Split(',');
              
                for (int i = 0; i < OTs.Count(); i++)
                {
                    lista = new List<Consumo>();
                    lista = controlCons.Listar(OTs[i]);
                    string ConsumoPapel = "";
                    string ConsumoPlancha = "";
                    string ConsumoOtros = "";
                    string ConsumoSerExt = "";
                    int contadorPapel = 0;
                    int contadorPlancha = 0;
                    int contadorOtros = 0;
                    int contadorSerExt = 0;
                    Consumo Papel = new Consumo();
                    foreach (Consumo c in lista.Where(o => o.Tipo == "Bobina" || o.Tipo == "Pliego").ToList())
                    {
                        if (contadorPapel == 0)
                        {
                            ConsumoPapel = "<div style='width:1000px;' align='center'>Consumos de Papel</div><table id='tblPapel' runat='server' cellspacing='0' cellpadding='0' >" +
                                                "<thead><tr>" +
                                                "<td style='text-align:center;'>Lote</td>" +
                                                "<td style='text-align:center;'>Cod Item</td>" +
                                                "<td style='text-align:center;'>Nombre Papel</td>" +
                                                "<td style='text-align:center;'>Gr.</td>" +
                                                "<td style='text-align:center;'>Ancho</td>" +
                                                "<td style='text-align:center;'>Largo</td>" +
                                                "<td style='text-align:center;'>Cons. Pliego</td>" +
                                                "<td style='text-align:center;'>Cons. Bobina</td>" +
                                                "<td style='text-align:center;'>Certificación</td>" +
                                                "<td style='text-align:center;'>Costo Unitario</td>" +
                                                "<td style='text-align:center;'>Costo Total</td>" +
                                                "</tr></thead><tbody>";
                            contadorPapel++;
                        }
                        ConsumoPapel = ConsumoPapel + "<tr>" +
                            "<td style='text-align:right;'>" + c.Lote + "</td>" +
                            "<td style='text-align:right;'>" + c.CodItem + "</td>" +
                            "<td style='text-align:center;'>" + c.NombrePapel + "</td>" +
                            "<td style='text-align:right;'>" + c.Gramage + "</td>" +
                            "<td style='text-align:right;'>" + c.Ancho + "</td>" +
                            "<td style='text-align:right;'>" + c.Largo + "</td>" +
                            "<td style='text-align:right;'>" + c.Cons_Pliego + "</td>" +
                            "<td style='text-align:right;'>" + c.Cons_Bobina + "</td>" +
                            "<td style='text-align:center;'>" + c.Certif + "</td>" +
                            "<td style='text-align:right;'>" + c.CostUni + "</td>" +
                            "<td style='text-align:right;'>" + c.Costtot + "</td>" +
                            "</tr>";
                        if (c.Tipo == "Bobina")
                        {
                            Papel.Cons_Bobina = (Convert.ToInt32(c.Cons_Bobina.Substring(0, c.Cons_Bobina.Length - 2).Replace(".", string.Empty)) + Convert.ToInt32(Papel.Cons_Bobina)).ToString();
                        }
                        else
                        {
                            Papel.Cons_Pliego = (Convert.ToInt32(c.Cons_Pliego.Substring(0, c.Cons_Pliego.Length - 2).Replace(".", string.Empty)) + Convert.ToInt32(Papel.Cons_Pliego)).ToString();
                        }
                        string algo = c.Costtot.Replace(".", string.Empty);
                        Papel.Costtot = (Convert.ToDouble(Papel.Costtot) + Convert.ToDouble(algo)).ToString();
                    }
                    foreach (Consumo c in lista.Where(o => o.Tipo == "Plancha"))
                    {
                        if (contadorPlancha == 0)
                        {
                            ConsumoPlancha = "<div style='width:1000px;' align='center'>Consumos de Planchas</div><table id='tblPapel' runat='server' cellspacing='0' cellpadding='0' >" +
                                                "<thead><tr>" +
                                                "<td style='text-align:center;'>Lote</td>" +
                                                "<td style='text-align:center;'>Cod Item</td>" +
                                                "<td style='text-align:center;'>Descripción</td>" +
                                                "<td style='text-align:center;'>Cantidad</td>" +
                                                "<td style='text-align:center;'>Costo Unitario</td>" +
                                                "<td style='text-align:center;'>Costo Total</td>" +
                                                "</tr></thead><tbody>";
                            contadorPlancha++;
                        }
                        ConsumoPlancha = ConsumoPlancha + "<tr>" +
                            "<td style='text-align:right;'>" + c.Lote + "</td>" +
                            "<td style='text-align:right;'>" + c.CodItem + "</td>" +
                            "<td style='text-align:center;'>" + c.NombrePapel + "</td>" +
                            "<td style='text-align:right;'>" + c.Cons_Plancha + "</td>" +
                            "<td style='text-align:right;'>" + c.CostUni + "</td>" +
                            "<td style='text-align:right;'>" + c.Costtot + "</td>" +
                            "</tr>";
                        Papel.Cons_Plancha = (Convert.ToInt32(c.Cons_Plancha.Substring(0, c.Cons_Plancha.Length - 2).Replace(",", string.Empty)) + Convert.ToInt32(Papel.Cons_Plancha)).ToString();

                        Papel.Ancho = (Convert.ToDouble(Papel.Ancho) + Convert.ToDouble(c.Costtot.Replace(".", string.Empty))).ToString();
                    }
                    foreach (Consumo c in lista.Where(o => o.Tipo == "Otro"))
                    {
                        if (contadorOtros == 0)
                        {
                            ConsumoOtros = "<div style='width:1000px;' align='center'>Otros Consumos</div><table id='tblPapel' runat='server' cellspacing='0' cellpadding='0'>" +
                                                "<thead><tr>" +
                                                "<td style='text-align:center;'>Lote</td>" +
                                                "<td style='text-align:center;'>Cod Item</td>" +
                                                "<td style='text-align:center;'>Nombre Material</td>" +
                                                "<td style='text-align:center;'>Cons. Otros</td>" +
                                                "<td style='text-align:center;'>Costo Unitario</td>" +
                                                "<td style='text-align:center;'>Costo Total</td>" +
                                                "</tr></thead><tbody>";
                            contadorOtros++;
                        }
                        ConsumoOtros = ConsumoOtros + "<tr>" +
                            "<td style='text-align:right;'>" + c.Lote + "</td>" +
                            "<td style='text-align:right;'>" + c.CodItem + "</td>" +
                            "<td style='text-align:center;'>" + c.NombrePapel + "</td>" +
                            "<td style='text-align:right;'>" + c.Cons_Otros + "</td>" +
                            "<td style='text-align:right;'>" + c.CostUni + "</td>" +
                            "<td style='text-align:right;'>" + c.Costtot + "</td>" +
                            "</tr>";
                        Papel.Cons_Otros = (Convert.ToInt32(c.Cons_Otros.Substring(0, c.Cons_Otros.Length - 2).Replace(".", string.Empty)) + Convert.ToInt32(Papel.Cons_Otros)).ToString();

                        Papel.Certif = (Convert.ToDouble(Papel.Certif) + Convert.ToDouble(c.Costtot.Replace(".", string.Empty))).ToString();
                    }
                    List<Consumo> lista2 = controlCons.ListarSerExterno(OTs[i]);
                    foreach (Consumo c in lista2)
                    {
                        if (contadorSerExt == 0)
                        {
                            ConsumoSerExt = "<div style='width:1000px;' align='center'>Servicios Externos</div><table id='tblPapel' runat='server' cellspacing='0' cellpadding='0' >" +
                                                "<thead><tr>" +
                                                "<td style='text-align:center;'>Descripción Proceso</td>" +
                                                "<td style='text-align:center;'>Componente</td>" +
                                                "<td style='text-align:center;'>Aplicación</td>" +
                                                "<td style='text-align:center;'>Formato (A x L)</td>" +
                                                "<td style='text-align:center;'>Cantidad</td>" +
                                                "<td style='text-align:center;'>Costo Unitario</td>" +
                                                "<td style='text-align:center;'>Costo Total</td>" +
                                                "</tr></thead><tbody>";
                            contadorSerExt++;
                        }
                        ConsumoSerExt = ConsumoSerExt + "<tr>" +
                            "<td style='text-align:center;'>" + c.Lote + "</td>" +
                            "<td style='text-align:center;'>" + c.Cons_Plancha + "</td>" +
                            "<td style='text-align:center;'>" + c.CodItem + "</td>" +
                            "<td style='text-align:right;'>" + c.NombrePapel + "</td>" +
                            "<td style='text-align:right;'>" + c.Certif + "</td>" +
                            "<td style='text-align:right;'>" + c.CostUni + "</td>" +
                            "<td style='text-align:right;'>" + c.Costtot + "</td>" +
                            "</tr>";
                        Papel.CostUni = (Convert.ToDouble(Papel.CostUni) + Convert.ToDouble(c.Costtot.Replace(".", string.Empty))).ToString();
                    }
                    if (contadorPapel > 0)
                    {
                        ConsumoPapel = ConsumoPapel + "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td style='text-align:center;'>Cons. Pliego</td>" +
                            "<td style='text-align:center;'>Cons. Bobina </td><td style='text-align:center;'>Costo Total </td></tr><tr>" +
                            "<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td style='text-align:center;'>Total</td>" +
                            "<td style='text-align:right;'>" + Convert.ToInt32(Papel.Cons_Pliego).ToString("N0").Replace(",", ".") + " FL" + "</td>" +
                            "<td style='text-align:right;'>" + Convert.ToInt32(Papel.Cons_Bobina).ToString("N0").Replace(",", ".") + " KG" + "</td>" +
                            "<td style='text-align:right;'>" + Convert.ToDouble(Papel.Costtot).ToString("N2") + "</td>" +
                            "</tr></tbody></table>"; 
                    }
                    if (contadorPlancha > 0)
                    {
                        ConsumoPlancha = ConsumoPlancha + "<tr><td></td><td></td><td></td><td></td>" +
                            "<td style='text-align:center;'>Cantidad de Planchas </td><td style='text-align:center;'>Costo Total </td>" +
                            "</tr><tr><td></td><td></td><td></td><td style='text-align:center;'>Total</td>" +
                            "<td style='text-align:right;'>" + Convert.ToInt32(Papel.Cons_Plancha).ToString("N0") + " UN" + "</td><td style='text-align:right;'>" + Convert.ToDouble(Papel.Ancho).ToString("N2") + "</td>" +
                            "</tr></tbody></table>";
                    }
                    if (contadorOtros > 0)
                    {
                        ConsumoOtros = ConsumoOtros + "<tr><td></td><td></td><td></td><td></td>" +
                            "<td style='text-align:center;'>Cons. Otros</td><td style='text-align:center;'>Costo Total</td></tr><tr>" +
                            "<td></td><td></td><td></td><td style='text-align:center;'>Total</td>" +
                            "<td style='text-align:right;'>" + Convert.ToInt32(Papel.Cons_Otros).ToString("N0") + " UN" + "</td>" +
                            "<td style='text-align:right;'>" + Convert.ToDouble(Papel.Certif).ToString("N2") + "</td>" +
                            "</tr></tbody></table>";
                    }
                    if (contadorSerExt > 0)
                    {
                        ConsumoSerExt = ConsumoSerExt + "<tr><td style='text-align:center;'></td><td style='text-align:center;'></td>" +
                            "<td style='text-align:center;'></td><td style='text-align:right;'></td><td style='text-align:right;'></td>" +
                            "<td style='text-align:right;'></td><td style='text-align:right;'>Costo Total </td></tr>"+
                            "<tr><td style='text-align:center;'></td><td style='text-align:center;'></td>" +
                            "<td style='text-align:center;'></td><td style='text-align:right;'></td><td style='text-align:right;'></td>" +
                            "<td style='text-align:right;'>Total</td><td style='text-align:right;'>" + Convert.ToDouble(Papel.CostUni).ToString("N2") + "</td></tr></tbody></table>";
                    }
                    if (Pag == 0 && OTs.Count()>1)
                    {
                        Facturacion = Facturacion + "<div style='page-break-after:always;'><h1 style='text-align:center;'>" + OTs[i] + " -  " + oc.Seguimiento_BuscarNM(OTs[i]) + "</h1>" + ConsumoPapel + "<br/>" + ConsumoPlancha + "<br/>" + ConsumoSerExt + "<br/>" + ConsumoOtros + "</div>";
                        Pag++;
                    }
                    else if (Pag == 0 && OTs.Count() == 1)
                    {
                        Facturacion = Facturacion + "<div><h1 style='text-align:center;'>" + OTs[i] + " -  " + oc.Seguimiento_BuscarNM(OTs[i]) + "</h1>" + ConsumoPapel + "<br/>" + ConsumoPlancha + "<br/>" + ConsumoSerExt + "<br/>" + ConsumoOtros + "</div>";
                        Pag++;
                    }
                    else if (Pag == 1)
                    {
                        Facturacion = Facturacion + "<div><h1 style='text-align:center;'>" + OTs[i] + " -  " + oc.Seguimiento_BuscarNM(OTs[i]) + "</h1>" + ConsumoPapel + "<br/>" + ConsumoPlancha + "<br/>" + ConsumoSerExt + "<br/>" + ConsumoOtros + "</div>";
                        Pag++;
                    }
                    else
                    {
                        Facturacion = Facturacion + "<div style='page-break-before:always;'><h1 style='text-align:center;'>" + OTs[i] + " -  " + oc.Seguimiento_BuscarNM(OTs[i]) + "</h1>" + ConsumoPapel + "<br/>" + ConsumoPlancha + "<br/>" + ConsumoSerExt + "<br/>" + ConsumoOtros + "</div>";
                    }
                }
                lblImprimir.Text =  Facturacion;
            }
        }
    }
}