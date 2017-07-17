using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;
using System.Web.Script.Serialization;
using System.Drawing;
using System.Drawing.Printing;

namespace Intranet.ModuloWip.View
{
    public partial class Ingreso_PalletWip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //foreach (string strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            //{
            //    lblNombreOT.Text += strPrinter.ToString();
            //}
            //Print();
        }

        public void Print()
        {
            var doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = "\\\\ADMIN-PC\\Ingieneria";
            doc.PrintPage += new PrintPageEventHandler(ProvideContent);
            doc.Print();
        }

        public void ProvideContent(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(
              "Hello world",
              new Font("Arial", 12),
              Brushes.Black,
              e.MarginBounds.Left,
              e.MarginBounds.Top);
        }

        [WebMethod]
        public static string[] BuscarOT(string OT)
        {
            OrdenController orderControl = new OrdenController();
            Orden ot = orderControl.BuscarPorOT(OT);
            string TirajeOT = Convert.ToInt32(ot.Ejemplares).ToString("N0").Replace(',', '.');
            return new[] { ot.NombreOT, ot.NombreCliente, TirajeOT };
        }

        [WebMethod]
        public static string CargarMaquina(string Maquina)
        {
            Controller_WipControl wipControl = new Controller_WipControl();
            List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
            if (Maquina == "Digital")
            {
                lista.Add(new Model_Wip_Control { OT="Indigo"});
                lista.Add(new Model_Wip_Control { OT = "Scodix" });
                lista.Add(new Model_Wip_Control { OT = "Escko" });
            }
            else if (Maquina == "Servicio Externo")
            {
                lista.Add(new Model_Wip_Control { OT = "Servicio Externo" });
                lista.Add(new Model_Wip_Control { OT = "PLISADO" });
                lista.Add(new Model_Wip_Control { OT = "TERMOLAMINADO" });
                lista.Add(new Model_Wip_Control { OT = "POLITERMOLAMINADO" });
                lista.Add(new Model_Wip_Control { OT = "UV" });
            }
            else
            {
                lista = wipControl.ListMaquinas(Maquina);
            }
            List<Model_Wip_Control> lista2 = new List<Model_Wip_Control>();

            int contador = 1;
            Model_Wip_Control insert1 = new Model_Wip_Control();
            insert1.OT = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Model_Wip_Control ps in lista)
            {
                Model_Wip_Control objst = new Model_Wip_Control();
                objst.OT = ps.OT;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }

        [WebMethod]
        public static string CargarPliegosProgramado(string OT)
        {
            Controller_WipControl wipControl = new Controller_WipControl();
            List<Model_Wip_Control> lista = wipControl.ListPliegosOT2(OT);
            List<Model_Wip_Control> lista2 = new List<Model_Wip_Control>();

            int contador = 1;
            Model_Wip_Control insert1 = new Model_Wip_Control();
            insert1.Prox_Proceso = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Model_Wip_Control ps in lista)
            {
                Model_Wip_Control objst = new Model_Wip_Control();
                objst.Prox_Proceso = ps.Prox_Proceso;
                objst.Forma = ps.Forma;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }

        [WebMethod]
        public static string CargarPliegosSinProgr(string OT)
        {
            Controller_WipControl wipControl = new Controller_WipControl();
            List<Model_Wip_Control> lista = wipControl.ListPliegosOT(OT);
            List<Model_Wip_Control> lista2 = new List<Model_Wip_Control>();

            int contador = 1;
            Model_Wip_Control insert1 = new Model_Wip_Control();
            insert1.Pliego = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Model_Wip_Control ps in lista)
            {
                Model_Wip_Control objst = new Model_Wip_Control();
                objst.Pliego = ps.Pliego;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }

        [WebMethod]
        public static string CargarPliegosDigital(string OT, string Tiraje)
        {
            List<Model_Wip_Control> lista2 = new List<Model_Wip_Control>();
            lista2.Add(new Model_Wip_Control { Prox_Proceso = "Seleccionar" });
            lista2.Add(new Model_Wip_Control { Prox_Proceso = "Pliego" });
            lista2.Add(new Model_Wip_Control { Prox_Proceso = "Tapa" });
            lista2.Add(new Model_Wip_Control { Prox_Proceso = "Pleigo + Tapa" });
            
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }

        [WebMethod]
        public static string[] CantidadPliegos(string OT, string Pliego)
        {
            Controller_WipControl wipControl = new Controller_WipControl();
            string TirajePliego = Convert.ToInt32(wipControl.BuscaPliegos(OT, Pliego, 1)).ToString("N0").Replace(",", ".");
            string Restantes = Convert.ToInt32(wipControl.BuscaPliegos(OT, Pliego, 2)).ToString("N0").Replace(",", ".");
            return new[] { TirajePliego, Restantes };
        }

        [WebMethod]
        public static string[] GrabarPallet(string OT, string NombreOT, string Pliego, string TirajeOT, string Maquina, string Destino, string IDTipoPallet, string TipoPallet,
                                          string Pliegos_Impresos, string Peso_pallet, string Usuario, string PliegoMetrics)
        {
            string Error = "Error al Ingresar Pallet, Faltan campos:\n";
            Controller_WipControl wipControl = new Controller_WipControl();
            Model_Wip_Control wip = new Model_Wip_Control();
            int numero = wipControl.MaxRegistroWip() + 1;
            string Codigo = "";
            if (Destino == "Almacenamiento Wip")
            {
                Codigo = "WP-00000000";
            }
            else if (Destino == "Servicio Externo")
            {
                Codigo = "SE-00000000";
            }
            else if (Destino == "Directo a Encuadernacion")
            {
                Codigo = "DE-00000000";
            }
            else if (Destino == "Taller Digital")
            {
                Codigo = "TD-00000000";
            }

            wip.ID_Control = Codigo.Substring(0, Codigo.Length - numero.ToString().Length) + numero.ToString();
            wip.OT = OT;
            wip.NombreOT = NombreOT;
            if (Maquina != "Seleccionar")
            {
                wip.Maquina = Maquina;
            }
            else
            {
                Error += "-Seleccionar Maquina \n";
            }
            if((Pliego!="Seleccionar")&& (Pliego!=""))
            {
                wip.Pliego = Pliego;
            }
            else
            {
                Error += "-Seleccionar Pliego\n";
            }
            if(TirajeOT!="")
            {
                Double Ejemplares = Convert.ToDouble(TirajeOT.ToString().Replace('.', ','));
                wip.TotalTiraje = Convert.ToInt32(Ejemplares);
            }
            if (Peso_pallet != "")
            {
                wip.Peso_pallet = Convert.ToDouble(Peso_pallet);
            }
            else
            {
                Error += "-Indicar Peso Pallet\n";
            }
            if ((Pliegos_Impresos != "")&& (Pliegos_Impresos!="0"))
            {
                wip.Pliegos_Impresos = Convert.ToInt32(Pliegos_Impresos);
            }
            else
            {
                Error += "-Indicar Pliegos Impresos\n";
            }
            wip.Usuario = Usuario;
            wip.Ubicacion = Destino;
            if(IDTipoPallet!="")
            {
                wip.IDTipoPallet = Convert.ToInt32(IDTipoPallet);
                wip.TipoPallet = TipoPallet;
            }
            if ((wip.OT != "") && (wip.NombreOT != "") && (wip.Maquina != "") && (wip.Pliego != "") && (wip.TotalTiraje != 0)  && (wip.Pliegos_Impresos != 0) && (wip.IDTipoPallet != 0))
            {
                if (wipControl.Agregar_Pallet_Wip(wip, PliegoMetrics))
                {
                    return new[] { "OK", wip.ID_Control };
                }
                else
                {
                    return new[] { "Error al Ingresar Pallet, Conexion Erronea" };
                }
            }
            else
            {
                return new [] {Error};
            }
        }

        [WebMethod]
        public static string[] GrabarPalletMultiple(string OT, string NombreOT, string Pliego, string TirajeOT, string Maquina, string Destino, string IDTipoPallet, string TipoPallet,
                                          string Pliegos_Impresos, string Peso_pallet, string Usuario, string CodigoPallet, string IsMultiple, string PliegoMetrics)
        {
            Controller_WipControl wipControl = new Controller_WipControl();
            Model_Wip_Control wip = new Model_Wip_Control();
            int numero = 0;
            string Codigo = "";
            if (IsMultiple != "1")
            {
                numero = wipControl.MaxRegistroWip() + 1;
            }
            
            if (Destino == "Almacenamiento Wip")
            {
                Codigo = "WP-00000000";
            }
            else if (Destino == "Servicio Externo")
            {
                Codigo = "SE-00000000";
            }
            else if (Destino == "Directo a Encuadernacion")
            {
                Codigo = "DE-00000000";
            }
            else if (Destino == "Taller Digital")
            {
                Codigo = "TD-00000000";
            }
            if (IsMultiple == "1")
            {
                wip.ID_Control = CodigoPallet;
            }
            else
            {
                wip.ID_Control = Codigo.Substring(0, Codigo.Length - numero.ToString().Length) + numero.ToString();
            }
            wip.OT = OT;
            wip.NombreOT = NombreOT;
            if (Maquina != "Seleccionar")
            {
                wip.Maquina = Maquina;
            }
            if ((Pliego != "Seleccionar") && (Pliego != ""))
            {
                wip.Pliego = Pliego;
            }

            if (TirajeOT != "")
            {
                Double Ejemplares = Convert.ToDouble(TirajeOT.ToString().Replace('.', ','));
                wip.TotalTiraje = Convert.ToInt32(Ejemplares);
            }
            if (Peso_pallet != "")
            {
                wip.Peso_pallet = Convert.ToDouble(Peso_pallet);
            }
            if (Pliegos_Impresos != "")
            {
                wip.Pliegos_Impresos = Convert.ToInt32(Pliegos_Impresos);
            }
            wip.Usuario = Usuario;
            wip.Ubicacion = Destino;
            if (IDTipoPallet != "")
            {
                wip.IDTipoPallet = Convert.ToInt32(IDTipoPallet);
                wip.TipoPallet = TipoPallet;
            }
            if ((wip.OT != "") && (wip.NombreOT != "") && (wip.Maquina != "") && (wip.Pliego != "") && (wip.TotalTiraje != 0) && (wip.Peso_pallet != 0) && (wip.Pliegos_Impresos != 0) && (wip.IDTipoPallet != 0))
            {
                string tabla = "<div class='divTitulo'>Datos Pallet Multiple</div><div class='divSeccion'><table style='width: 100%;'>";
                if (wipControl.Agregar_Pallet_Wip(wip, PliegoMetrics))
                {
                    List<Model_Wip_Control> lista = wipControl.List_PliegosMultiples(wip.ID_Control);
                    int contador = 0;
                    foreach (Model_Wip_Control wp in lista)
                    {
                        if (contador == 0)
                        {
                            tabla += "<tr><td>OT</td><td>Pliego</td><td>Total Tiraje</td><td>Pliegos Impresos</td><td>Peso pallet</td><td>Tipo Pallet</td></tr>";
                        }
                        tabla += "<tr><td>" + wp.OT + "</td><td>" + wp.Pliego + "</td><td>" + wp.TotalTiraje + "</td><td>" + wp.Pliegos_Impresos + "</td><td>" + wp.Peso_pallet + "</td><td>" + wp.TipoPallet + "</td></tr>";
                        contador++;
                    }
                    tabla += "</table></div>";
                    return new[] { "OK", wip.ID_Control, "1", tabla };
                }
                else
                {
                    return new[] { "Error al Ingresar Pallet, Conexion erronea" };
                }
            }
            else
            {
                return new[] { "Error al Ingresar Pallet, Faltan campos obligatorios" };
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ingreso_PalletWip.aspx?id=8&Cat=5");
        }
    }
}