using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloPresupuesto.Controller;
using System.Web.Script.Serialization;
using Intranet.ModuloPresupuesto.Model;

namespace Intranet.ModuloPresupuesto.View
{
    public partial class Sol_PPTO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPapeles();
            }
        }

        public void CargarPapeles()
        {
            Controller_PPTO controltarifa = new Controller_PPTO();
            ddlPapelInterior.DataSource = controltarifa.ListarTarifaPapel("Interior");
            ddlPapelInterior.DataTextField = "NombrePapel";
            ddlPapelInterior.DataValueField = "NombrePapel";
            ddlPapelInterior.DataBind();
            ddlPapelInterior.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlPapelTapa.DataSource = controltarifa.ListarTarifaPapel("Tapa");
            ddlPapelTapa.DataTextField = "NombrePapel";
            ddlPapelTapa.DataValueField = "NombrePapel";
            ddlPapelTapa.DataBind();
            ddlPapelTapa.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        [WebMethod]
        public static string CargarGramaje(string TipoPapel, string Componente)
        {
            Controller_PPTO controltarifa = new Controller_PPTO();
            List<Presupuesto> lista = controltarifa.ListarTarifaGramajePapel(Componente, TipoPapel);
            List<Presupuesto> lista2 = new List<Presupuesto>();
            int contador = 1;
            Presupuesto insert1 = new Presupuesto();
            insert1.Gramaje = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Presupuesto ps in lista)
            {
                Presupuesto objst = new Presupuesto();
                objst.Gramaje = ps.Gramaje;
                objst.ValorPapel = ps.ValorPapel;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }

        [WebMethod]
        public static string[] PrePrensa(int Doblez, int PagInterior, string ColorInterior, string MaquinaInterior, string Tiraje, string PapelInterior, string PapelTapa, string GramajeInterior, string Desarrollo,
                        string Anchobanda, int PagTapas, string ColorTapas, string MaquinaTapas, string Gramagetapas, string LargoTapas, string anchoTapas, string BarnizUV, string Laminado, string DripOFF,
                        string Encuadernacion, string BarnizInterior, string BarnizTapa, string Empresa)
        {
            Controller_PPTO controltarifa = new Controller_PPTO();
            #region EntradasMaquina
            double Sobrante = 0;
            int pag32 = 0; int pag24 = 0; int pag16 = 0; int pag12 = 0; int pag8 = 0; int pag4 = 0; int TotalEntradas = 0; double npliegos = 0;
            if (Doblez == 32)
            {
                pag32 = PagInterior / 32;
                npliegos = Convert.ToDouble(Convert.ToDouble(PagInterior) / Convert.ToDouble(32));
                Sobrante = (PagInterior % 32);
                switch (Convert.ToInt32(Sobrante))
                {
                    case 28: pag16 = 1; pag8 = 1; pag4 = 1; break;
                    case 24: pag24 = 1;break;
                    case 20: pag16 = 1; pag4 = 1; break;
                    case 16: pag16 = 1; break;
                    case 12: pag8 = 1; pag4 = 1; break;
                    case 8: pag8 = 1; break;
                    case 4: pag4 = 1; break;
                }
            }
            else if (Doblez == 24)
            {
                pag24 = PagInterior / 24;
                npliegos = Convert.ToDouble(Convert.ToDouble(PagInterior) / Convert.ToDouble(24));
                Sobrante = (PagInterior % 24);
                switch (Convert.ToInt32(Sobrante))
                {
                    case 20: pag12 = 1; pag8 = 1; break;
                    case 16: pag12 = 1; pag4 = 1; break;
                    case 12: pag8 = 1; pag4 = 1; break;
                    case 8: pag8 = 1; break;
                    case 4: pag4 = 1; break;
                }
            }
            else if (Doblez == 16)
            {
                pag16 = PagInterior / 16;
                npliegos = Convert.ToDouble(Convert.ToDouble(PagInterior) / Convert.ToDouble(16));
                Sobrante = (PagInterior % 16);
                switch (Convert.ToInt32(Sobrante))
                {
                    case 12: pag8 = 1; pag4 = 1; break;
                    case 8: pag8 = 1; break;
                    case 4: pag4 = 1; break;
                }
            }
            else if (Doblez == 12)
            {
                pag12 = PagInterior / 12;
                npliegos = Convert.ToDouble(Convert.ToDouble(PagInterior) / Convert.ToDouble(12));
                Sobrante = (PagInterior % 12);
                switch (Convert.ToInt32(Sobrante))
                {
                    case 8: pag4 = 2; break;
                    case 4: pag4 = 1; break;
                }
            }
            else if (Doblez == 8)
            {
                pag8 = PagInterior / 8;
                npliegos = Convert.ToDouble(Convert.ToDouble(PagInterior) / Convert.ToDouble(8));
                Sobrante = (PagInterior % 8);
                switch (Convert.ToInt32(Sobrante))
                {
                    case 4: pag4 = 1; break;
                }
            }
            TotalEntradas = pag32 + pag24 + pag16 +pag12+ pag8 + pag4;

            #endregion
            #region Prepensa
            string Preprensa32 = (pag32 * controltarifa.TarifaPreprensa(ColorInterior) * 32).ToString("N0").Replace(",", ".");
            string Preprensa24 = (pag24 * controltarifa.TarifaPreprensa(ColorInterior) * 24).ToString("N0").Replace(",", ".");
            string Preprensa16 = (pag16 * controltarifa.TarifaPreprensa(ColorInterior) * 16).ToString("N0").Replace(",", ".");
            string Preprensa12 = (pag12 * controltarifa.TarifaPreprensa(ColorInterior) * 12).ToString("N0").Replace(",", ".");
            string Preprensa08 = (pag8 * controltarifa.TarifaPreprensa(ColorInterior) * 8).ToString("N0").Replace(",", ".");
            string Preprensa04 = (pag4 * controltarifa.TarifaPreprensa(ColorInterior) * 4).ToString("N0").Replace(",", ".");
            string PreprensaTapas = "0";
            if(PagTapas>0){
                PreprensaTapas = (controltarifa.TarifaPreprensa("Tapas")).ToString("N0").Replace(",", ".");
            }
            #endregion
            #region Impresion
            int ImpresionIntFijo =  Convert.ToInt32(pag32 * controltarifa.TarifaImpresion(ColorInterior,"Interior","Fijo",MaquinaInterior))+
                                    Convert.ToInt32(pag24 * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Fijo", MaquinaInterior))+
                                    Convert.ToInt32(pag16 * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Fijo", MaquinaInterior))+
                                    Convert.ToInt32(pag12 * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Fijo", MaquinaInterior))+
                                    Convert.ToInt32(pag8 * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Fijo", MaquinaInterior))+
                                    Convert.ToInt32(pag4 * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Fijo", MaquinaInterior));
            double CostPlgEntrada32 = 0; double CostPlgEntrada24 = 0; double CostPlgEntrada16 = 0; double CostPlgEntrada12 = 0; double CostPlgEntrada08 = 0; double CostPlgEntrada04 = 0;
            #region algo
            if (Doblez == 32)
            {
                if (pag32 > 0)
                {
                    CostPlgEntrada32 = (Convert.ToDouble(32) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                }
                if (MaquinaInterior == "Rotativas")
                {
                    if (pag24 > 0)
                    {
                        CostPlgEntrada24 = (Convert.ToDouble(24) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                    if (pag16 > 0)
                    {
                        CostPlgEntrada16 = (Convert.ToDouble(16) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                    if (pag12 > 0)
                    {
                        CostPlgEntrada12 = (Convert.ToDouble(12) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                    if (pag8 > 0)
                    {
                        CostPlgEntrada08 = (Convert.ToDouble(8) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                }
                else
                {
                    if (pag24 > 0)
                    {
                        CostPlgEntrada24 = (Convert.ToDouble(24) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag16 > 0)
                    {
                        CostPlgEntrada16 = (Convert.ToDouble(16) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag12 > 0)
                    {
                        CostPlgEntrada12 = (Convert.ToDouble(12) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag8 > 0)
                    {
                        CostPlgEntrada08 = (Convert.ToDouble(8) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(32)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                }
            }
            else if (Doblez == 24)
            {
                if (pag24 > 0)
                {
                    CostPlgEntrada24 = (Convert.ToDouble(24) / Convert.ToDouble(24)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                }
                if (MaquinaInterior == "Rotativas")
                {
                    if (pag16 > 0)
                    {
                        CostPlgEntrada16 = (Convert.ToDouble(16) / Convert.ToDouble(24)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                    if (pag12 > 0)
                    {
                        CostPlgEntrada12 = (Convert.ToDouble(12) / Convert.ToDouble(24)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                    if (pag8 > 0)
                    {
                        CostPlgEntrada08 = (Convert.ToDouble(8) / Convert.ToDouble(24)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(24)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                }
                else
                {
                    if (pag16 > 0)
                    {
                        CostPlgEntrada16 = (Convert.ToDouble(16) / Convert.ToDouble(24)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag12 > 0)
                    {
                        CostPlgEntrada12 = (Convert.ToDouble(12) / Convert.ToDouble(24)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag8 > 0)
                    {
                        CostPlgEntrada08 = (Convert.ToDouble(8) / Convert.ToDouble(24)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(24)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                }
            }
            else if (Doblez == 16)
            {
                if (pag16 > 0)
                {
                    CostPlgEntrada16 = (Convert.ToDouble(16) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                }
                if (MaquinaInterior == "Rotativas")
                {
                    if (pag12 > 0)
                    {
                        CostPlgEntrada12 = (Convert.ToDouble(12) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior)+ 1.5;
                    }
                    if (pag8 > 0)
                    {
                        CostPlgEntrada08 = (Convert.ToDouble(8) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                }
                else
                {
                    if (pag12 > 0)
                    {
                        CostPlgEntrada12 = (Convert.ToDouble(12) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag8 > 0)
                    {
                        CostPlgEntrada08 = (Convert.ToDouble(8) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                }
            }
            else if (Doblez == 12)
            {
                if (pag12 > 0)
                {
                    CostPlgEntrada12 = (Convert.ToDouble(12) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                }
                if (MaquinaInterior == "Rotativas")
                {
                    if (pag8 > 0)
                    {
                        CostPlgEntrada08 = (Convert.ToDouble(8) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                }
                else
                {
                    if (pag8 > 0)
                    {
                        CostPlgEntrada08 = (Convert.ToDouble(8) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                }
            }
            else if (Doblez == 8)
            {
                if (pag8 > 0)
                {
                    CostPlgEntrada08 = (Convert.ToDouble(8) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                }
                if (MaquinaInterior == "Rotativas")
                {
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior) + 1.5;
                    }
                }
                else
                {
                    if (pag4 > 0)
                    {
                        CostPlgEntrada04 = (Convert.ToDouble(4) / Convert.ToDouble(16)) * controltarifa.TarifaImpresion(ColorInterior, "Interior", "Variable", MaquinaInterior);
                    }
                }


            }
            #endregion

            double ImpresionIntVari = Convert.ToDouble(CostPlgEntrada32 * pag32) +
                                    Convert.ToDouble(CostPlgEntrada24 * pag24) +
                                    Convert.ToDouble(CostPlgEntrada16 * pag16) +
                                    Convert.ToDouble(CostPlgEntrada12 * pag12) +
                                    Convert.ToDouble(CostPlgEntrada08 * pag8) +
                                    Convert.ToDouble(CostPlgEntrada04 * pag4);

            string ImpresionTapFijo = "0";
            string ImpresionTapVari = "0";
            string ImpresionTapPlisFijo = "0";
            string ImpresionTapPlisVari = "0";
            if (PagTapas > 0)
            {
                ImpresionTapFijo = controltarifa.TarifaImpresion(ColorTapas, "Tapa", "Fijo", MaquinaTapas).ToString("N0").Replace(",", ".");
                ImpresionTapVari = ((controltarifa.TarifaImpresion(ColorTapas, "Tapa", "Variable", MaquinaTapas) * 4) / PagTapas).ToString("N0").Replace(",", ".");
                if (Gramagetapas != "")
                {
                    if (Convert.ToInt32(Gramagetapas) >= 170)
                    {
                        ImpresionTapPlisVari = controltarifa.TarifaTerminaciones("Plisado Tapa", "Variable").ToString("N2");
                        ImpresionTapPlisFijo = controltarifa.TarifaTerminaciones("Plisado Tapa", "Fijo").ToString("N0").Replace(",", ".");
                    }
                }
            }
            

            #endregion
            #region Papel
            int CostoPapelKilosInt = Convert.ToInt32(PapelInterior);
            int CostoPapelKilosTap = 0;
            if (PapelTapa != "Seleccionar")
            {
                CostoPapelKilosTap = Convert.ToInt32(PapelTapa);
            }
            double margenpapel = 1.15;

            double valorKilosInterior = Math.Ceiling(CostoPapelKilosInt * margenpapel);
            double valorKilostapas = Math.Ceiling(CostoPapelKilosTap * margenpapel);
            

            double EntradasInterior = Math.Ceiling(TotalEntradas * controltarifa.TarifaMerma(ColorInterior, "Interior", "Fijo", MaquinaInterior) * ((Convert.ToDouble(GramajeInterior) * Convert.ToDouble(Desarrollo) * Convert.ToDouble(Anchobanda)) / Convert.ToDouble(10000000)));//puede ser int
            string CostoFijoPapelInterior = Convert.ToDouble(EntradasInterior * valorKilosInterior).ToString("N0").Replace(",", ".");

            double EntradasTapas = 0;
            if (PapelTapa != "Seleccionar")
            {
                EntradasTapas = Math.Ceiling(controltarifa.TarifaMerma(ColorTapas, "Tapa", "Fijo", MaquinaTapas) * ((Convert.ToDouble(Gramagetapas) * Convert.ToDouble(LargoTapas) * Convert.ToDouble(anchoTapas)) / Convert.ToDouble(10000000)));//puede ser int
            }
            string CostoFijoPapelTapas = Convert.ToDouble(EntradasTapas * valorKilostapas).ToString("N0").Replace(",", ".");

            double TiradaInterior = Math.Ceiling(((Convert.ToDouble(GramajeInterior) * Convert.ToDouble(Desarrollo) * Convert.ToDouble(Anchobanda)) / Convert.ToDouble(10000000)) * npliegos * controltarifa.TarifaMerma(ColorInterior, "Interior", "Variable", MaquinaInterior)*Convert.ToDouble(Tiraje));
            string CostoVariPapelInterior = Convert.ToDouble((TiradaInterior * valorKilosInterior)/Convert.ToDouble(Tiraje)).ToString("N2").Replace(",", ".");

            double Tiradatapas = 0;
            if (PapelTapa != "Seleccionar")
            {
                Tiradatapas = Math.Ceiling(((Convert.ToDouble(Gramagetapas) * Convert.ToDouble(LargoTapas) * Convert.ToDouble(anchoTapas)) / Convert.ToDouble(10000000)) * controltarifa.TarifaMerma(ColorTapas, "Tapa", "Variable", MaquinaTapas) * (Convert.ToDouble(Tiraje) / Convert.ToDouble(PagTapas)));
            }
            string CostoVariPapeltapas = Convert.ToDouble((Tiradatapas * valorKilostapas) / Convert.ToDouble(Tiraje)).ToString("N2").Replace(",", ".");

            #endregion
            #region Terminaciones
            string CostoFijoTerminacionBarnizUV = "0";
            string CostoVariTerminacionBarnizUV = "0";
            string CostoVariTerminacionLaminado = "0";
            string CostoFijoTerminacionDripOFF = "0";
            string CostoVariTerminacionDripOFF = "0";
            string CostoFijoBarnizInt = "0";
            string CostoVariBarnizInt = "0";
            string CostoFijoBarnizTap = "0";
            string CostoVariBarnizTap = "0";

            double MetrosCuadradosInter = ((Convert.ToDouble(Desarrollo) * Convert.ToDouble(Anchobanda)) / 10000);

            double MetrosCuadradosTapas = 0;
            if (PapelTapa != "Seleccionar")
            {
                MetrosCuadradosTapas = ((Convert.ToDouble(LargoTapas) * Convert.ToDouble(anchoTapas)) / 10000);
            }
            if (BarnizUV != "Sin Barniz")
            {
                CostoFijoTerminacionBarnizUV = controltarifa.TarifaTerminaciones(BarnizUV,"Fijo").ToString("N0").Replace(",",".");
                double CostoBarnizUV = Math.Ceiling(((controltarifa.TarifaTerminaciones(BarnizUV, "Variable") * MetrosCuadradosTapas) / PagTapas) * 100);
                CostoVariTerminacionBarnizUV = (CostoBarnizUV/100).ToString("N2");
            }

            if (Laminado != "Sin Laminado")
            {
                double CostoLaminado = Math.Ceiling(((controltarifa.TarifaTerminaciones(Laminado, "Variable") * MetrosCuadradosTapas) / PagTapas)*100);
                CostoVariTerminacionLaminado = (CostoLaminado/100).ToString("N2");
            }
            if (DripOFF != "Sin Drip Off")
            {
                CostoFijoTerminacionDripOFF = controltarifa.TarifaTerminaciones("Drip Off", "Fijo").ToString("N0").Replace(",", ".");
                double CostoDripOFF = Math.Ceiling(((controltarifa.TarifaTerminaciones("Drip Off", "Variable") * MetrosCuadradosTapas) / PagTapas) * 100);
                CostoVariTerminacionDripOFF = (CostoDripOFF/100).ToString("N2");
            }
            if (BarnizInterior != "Sin Barniz")
            {
                CostoFijoBarnizInt = controltarifa.TarifaTerminaciones("Barniz Acuoso", "Fijo").ToString("N0").Replace(",", ".");
                double Barniz32 = 0;
                double Barniz24 = 0;
                double Barniz16 = 0;
                double Barniz12 = 0;
                double Barniz08 = 0;
                double Barniz04 = 0;

                if (pag32 > 0)
                {
                    Barniz32 = (((MetrosCuadradosInter * controltarifa.TarifaTerminaciones("Barniz Acuoso", "Variable")) / Math.Round(Convert.ToDouble(Doblez / 32))) * 2) * pag32;
                }
                if (pag24 > 0)
                {
                    Barniz24 = (((MetrosCuadradosInter * controltarifa.TarifaTerminaciones("Barniz Acuoso", "Variable")) / Math.Round(Convert.ToDouble(Doblez / 24))) * 2) * pag24;
                }
                if (pag16 > 0)
                {
                    Barniz16 = Convert.ToDouble((Math.Round((MetrosCuadradosInter * controltarifa.TarifaTerminaciones("Barniz Acuoso", "Variable"))/ Math.Round(Convert.ToDouble(Doblez / 16)),3) * 2) * pag16);
                }
                if (pag12 > 0)
                {
                    Barniz12 = (((MetrosCuadradosInter * controltarifa.TarifaTerminaciones("Barniz Acuoso", "Variable")) / Math.Round(Convert.ToDouble(Doblez / 12))) * 2) * pag12;
                }
                if (pag8 > 0)
                {
                    Barniz08 = (((MetrosCuadradosInter * controltarifa.TarifaTerminaciones("Barniz Acuoso", "Variable")) / Math.Round(Convert.ToDouble(Doblez / 8))) * 2) * pag8;
                }
                if (pag4 > 0)
                {
                    Barniz04 = (((MetrosCuadradosInter * controltarifa.TarifaTerminaciones("Barniz Acuoso", "Variable")) / Math.Round(Convert.ToDouble(Doblez / 4))) * 2) * pag4;
                }

                CostoVariBarnizInt = ((Barniz32 + Barniz24 + Barniz16 + Barniz12 + Barniz08 + Barniz04)).ToString("N2");
            }
            if (BarnizTapa != "Sin Barniz")
            {
                CostoFijoBarnizTap = controltarifa.TarifaTerminaciones("Barniz Acuoso", "Fijo").ToString("N0").Replace(",", ".");
                if (BarnizTapa == "Tiro"|| BarnizTapa=="Retiro")
                {
                    CostoVariBarnizTap = (Math.Round((MetrosCuadradosTapas * controltarifa.TarifaTerminaciones("Barniz Acuoso", "Variable")))/Convert.ToDouble(PagTapas)).ToString("N2");
                }
                else
                {
                    CostoVariBarnizTap = ((Math.Round((MetrosCuadradosTapas * controltarifa.TarifaTerminaciones("Barniz Acuoso", "Variable"))) / Convert.ToDouble(PagTapas))*2).ToString("N2");
                }
            }

            #endregion
            #region Encuadernacion
            string CostoFijoEncuadernacion = "";
            string CostoVariEncuadernacion = "";
            string CosturaHilo32Pag = "0";
            string CosturaHilo24Pag = "0";
            string CosturaHilo16Pag = "0";
            string CosturaHilo12Pag = "0";
            string CosturaHilo08Pag = "0";
            string CosturaHilo04Pag = "0";
            if (Encuadernacion != "Costura Hilo y Entapado Hot Melt")
            {
                CostoFijoEncuadernacion = controltarifa.TarifaEncuadernacion(Encuadernacion, "Fijo", TotalEntradas, Empresa).ToString("N0").Replace(",",".");
                CostoVariEncuadernacion = controltarifa.TarifaEncuadernacion(Encuadernacion, "Variable", TotalEntradas, Empresa).ToString("N2").Replace(",", ".");
            }
            else
            {
                switch (Doblez)
                {
                    case 32: CosturaHilo32Pag = (pag32 * 12).ToString("N0").Replace(",", ".");
                        CosturaHilo24Pag = (pag24 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo16Pag = (pag16 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo12Pag = (pag12 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo08Pag = (pag8 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo04Pag = (pag4 * 6).ToString("N0").Replace(",", "."); break;
                    case 24: CosturaHilo24Pag = (pag24 * 12).ToString("N0").Replace(",", ".");
                        CosturaHilo16Pag = (pag16 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo12Pag = (pag12 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo08Pag = (pag8 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo04Pag = (pag4 * 6).ToString("N0").Replace(",", "."); break;
                    case 16: CosturaHilo16Pag = (pag16 * 12).ToString("N0").Replace(",", ".");
                        CosturaHilo12Pag = (pag12 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo08Pag = (pag8 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo04Pag = (pag4 * 6).ToString("N0").Replace(",", "."); break;
                    case 12: CosturaHilo12Pag = (pag12 * 12).ToString("N0").Replace(",", ".");
                        CosturaHilo08Pag = (pag8 * 6).ToString("N0").Replace(",", ".");
                        CosturaHilo04Pag = (pag4 * 6).ToString("N0").Replace(",", "."); break;
                    default: CosturaHilo08Pag = (pag8 * 12).ToString("N0").Replace(",", ".");
                        CosturaHilo04Pag = (pag4 * 6).ToString("N0").Replace(",", "."); break;
                }
                CostoFijoEncuadernacion = controltarifa.TarifaEncuadernacion("Entapado Hot Melt", "Fijo", TotalEntradas, Empresa).ToString("N0").Replace(",", ".");
                CostoVariEncuadernacion = controltarifa.TarifaEncuadernacion("Entapado Hot Melt", "Variable", TotalEntradas, Empresa).ToString("N2").Replace(",", ".");
            }
            #endregion
            #region Despacho
            string Embalaje = controltarifa.TarifaDespacho("Fijo", Empresa, "Embalaje y Despacho").ToString("N0").Replace(",", ".");
            string Suministro = controltarifa.TarifaDespacho("Variable", Empresa, "Suministro Caja").ToString("N2").Replace(",", ".");
            string Encajado = controltarifa.TarifaDespacho("Variable", Empresa, "Encajado").ToString("N2").Replace(",", ".");
            #endregion
            #region Totales

            string CTPreprensa = (Convert.ToInt32(Preprensa32.Replace(".", string.Empty)) +
                                   Convert.ToInt32(Preprensa24.Replace(".", string.Empty)) +
                                   Convert.ToInt32(Preprensa16.Replace(".", string.Empty)) +
                                   Convert.ToInt32(Preprensa12.Replace(".", string.Empty)) +
                                   Convert.ToInt32(Preprensa08.Replace(".", string.Empty)) +
                                   Convert.ToInt32(Preprensa04.Replace(".", string.Empty)) +
                                   Convert.ToInt32(PreprensaTapas.Replace(".", string.Empty))).ToString("N0").Replace(",", ".");
       
            string CTImpresion = (ImpresionIntFijo + (ImpresionIntVari * Convert.ToInt32(Tiraje)) +
                                    Convert.ToInt32(ImpresionTapFijo.Replace(".", string.Empty)) +
                                    (Convert.ToInt32(ImpresionTapVari.Replace(".", string.Empty)) * Convert.ToInt32(Tiraje))+
                                    (Convert.ToInt32(CostoFijoBarnizInt.Replace(".", string.Empty)) + (Convert.ToDouble(CostoVariBarnizInt)* Convert.ToInt32(Tiraje)))+
                                    (Convert.ToInt32(CostoFijoBarnizTap.Replace(".", string.Empty)) + (Convert.ToDouble(CostoVariBarnizTap) * Convert.ToInt32(Tiraje))) +
                                    (Convert.ToInt32(ImpresionTapPlisFijo.Replace(".", string.Empty)) + (Convert.ToDouble(ImpresionTapPlisVari) * Convert.ToInt32(Tiraje)))
                                    ).ToString("N0").Replace(",", ".");

            string CTCosturaHilo = ((Convert.ToInt32(CosturaHilo32Pag.Replace(".", string.Empty)) +
                                   Convert.ToInt32(CosturaHilo24Pag.Replace(".", string.Empty)) +
                                   Convert.ToInt32(CosturaHilo16Pag.Replace(".", string.Empty)) +
                                   Convert.ToInt32(CosturaHilo12Pag.Replace(".", string.Empty)) +
                                   Convert.ToInt32(CosturaHilo08Pag.Replace(".", string.Empty)) +
                                   Convert.ToInt32(CosturaHilo04Pag.Replace(".", string.Empty))) * Convert.ToInt32(Tiraje)).ToString("N0").Replace(",", ".");

            string CTEncuadernacion = (Convert.ToInt32(CostoFijoEncuadernacion.Replace(".", string.Empty)) + (Convert.ToDouble(CostoVariEncuadernacion) * Convert.ToInt32(Tiraje))).ToString("N0").Replace(",", ".");

            string CTPapel = ((Convert.ToInt32(CostoFijoPapelInterior.Replace(".", string.Empty)) + (Convert.ToDouble(CostoVariPapelInterior) * Convert.ToInt32(Tiraje)))+
                             (Convert.ToInt32(CostoFijoPapelTapas.Replace(".", string.Empty)) + (Convert.ToDouble(CostoVariPapeltapas) * Convert.ToInt32(Tiraje)))).ToString("N0").Replace(",", ".");

            string CTTerminacion = ((Convert.ToInt32(CostoFijoTerminacionBarnizUV.Replace(".", string.Empty)) + (Convert.ToDouble(CostoVariTerminacionBarnizUV) * Convert.ToInt32(Tiraje)))+
                                    (Convert.ToInt32(CostoFijoTerminacionDripOFF.Replace(".", string.Empty)) + (Convert.ToDouble(CostoVariTerminacionDripOFF) * Convert.ToInt32(Tiraje)))+
                                    (Convert.ToDouble(CostoVariTerminacionLaminado) * Convert.ToInt32(Tiraje))
                                   ).ToString("N0").Replace(",", ".");

            string CTDespacho = (Convert.ToInt32(Embalaje.Replace(".", string.Empty)) + (Convert.ToInt32(Tiraje) * Convert.ToDouble(Suministro)) + (Convert.ToInt32(Tiraje) * Convert.ToDouble(Encajado))).ToString("N0").Replace(",", ".");

            string CTFSubTotal = (Convert.ToInt32(CTPreprensa.Replace(".", string.Empty)) + ImpresionIntFijo + Convert.ToInt32(CostoFijoEncuadernacion.Replace(".", string.Empty))+
                                  Convert.ToInt32(CostoFijoPapelInterior.Replace(".", string.Empty))+ Convert.ToInt32(CostoFijoPapelTapas.Replace(".", string.Empty))+ 
                                  Convert.ToInt32(ImpresionTapPlisFijo.Replace(".", string.Empty))+ Convert.ToInt32(CostoFijoBarnizTap.Replace(".", string.Empty))+
                                  Convert.ToInt32(CostoFijoBarnizInt.Replace(".", string.Empty)) + Convert.ToInt32(ImpresionTapFijo.Replace(".", string.Empty)) +
                                  Convert.ToInt32(CostoFijoTerminacionBarnizUV.Replace(".", string.Empty)) + Convert.ToInt32(CostoFijoTerminacionDripOFF.Replace(".", string.Empty))+
                                  Convert.ToInt32(Embalaje.Replace(".", string.Empty))).ToString("N0").Replace(",", ".");

            string CTVSubTotal = (Math.Ceiling(((ImpresionIntVari) + Convert.ToDouble(CostoVariBarnizInt) + Convert.ToDouble(CostoVariBarnizTap) + Convert.ToDouble(ImpresionTapPlisVari) +
                                 Convert.ToInt32(CTCosturaHilo.Replace(".", string.Empty)) + Convert.ToDouble(CostoVariEncuadernacion) + Convert.ToDouble(CostoVariPapelInterior) +
                                 Convert.ToDouble(CostoVariPapeltapas) + Convert.ToDouble(CostoVariTerminacionBarnizUV) + Convert.ToDouble(CostoVariTerminacionDripOFF) +
                                 Convert.ToInt32(ImpresionTapVari.Replace(".", string.Empty)) + 
                                 Convert.ToDouble(CostoVariTerminacionLaminado) + Convert.ToDouble(Suministro) + Convert.ToDouble(Encajado))*10)/10).ToString("N2");

            string CTTSubTotal = (Convert.ToInt32(CTFSubTotal.Replace(".", string.Empty)) + (Convert.ToDouble(CTVSubTotal) * Convert.ToInt32(Tiraje))).ToString("N0").Replace(",", ".");

            double Total = 1;
            double Comision = 001;
            if (MaquinaInterior == "Planas")
            {
                Comision = 0.04;
            }
            Total = Total - Comision;

            string CTFNeto = Math.Ceiling(Convert.ToInt32(CTFSubTotal.Replace(".", string.Empty)) / Total).ToString("N0").Replace(",", ".");
            string CTVNeto = (Math.Ceiling((Convert.ToDouble(CTVSubTotal)/ Total)*10)/10).ToString("N2");
            string CTTNeto = (Convert.ToInt32(CTFNeto.Replace(".", string.Empty)) + (Convert.ToDouble(CTVNeto) * Convert.ToInt32(Tiraje))).ToString("N0").Replace(",", ".");

            string CTFComision = Math.Ceiling(Convert.ToInt32(CTFNeto.Replace(".", string.Empty)) * Comision).ToString("N0").Replace(",", ".");
            string CTVComision = (Math.Ceiling((Convert.ToDouble(CTVNeto) * Comision) * 100) / 100).ToString("N2");
            string CTTComision = (Convert.ToInt32(CTFComision.Replace(".", string.Empty)) + (Convert.ToDouble(CTVComision) * Convert.ToInt32(Tiraje))).ToString("N0").Replace(",", ".");

            

            string PrecioUnitario = (Math.Ceiling((Convert.ToDouble(CTTNeto.Replace(".", string.Empty)) / Convert.ToDouble(Tiraje))*100)/100).ToString("N2");


            #endregion
            return new[] { Preprensa32, Preprensa24, Preprensa16, Preprensa12, Preprensa08, Preprensa04, ImpresionIntFijo.ToString("N0").Replace(",", "."), 
                            ImpresionIntVari.ToString("N0").Replace(",", "."), CostoFijoPapelInterior, CostoVariPapelInterior, PreprensaTapas, ImpresionTapFijo, ImpresionTapVari, CostoFijoPapelTapas, 
                            CostoVariPapeltapas, CostoFijoTerminacionBarnizUV, CostoVariTerminacionBarnizUV, CostoVariTerminacionLaminado, CostoFijoTerminacionDripOFF, CostoVariTerminacionDripOFF, CostoFijoEncuadernacion,
                            CostoVariEncuadernacion, CosturaHilo32Pag, CosturaHilo24Pag, CosturaHilo16Pag, CosturaHilo12Pag, CosturaHilo08Pag, CosturaHilo04Pag, CostoFijoBarnizInt,CostoVariBarnizInt,
                            CostoFijoBarnizTap, CostoVariBarnizTap, ImpresionTapPlisFijo, ImpresionTapPlisVari, Embalaje, Suministro, Encajado, CTPreprensa, CTImpresion, CTCosturaHilo, CTEncuadernacion,
                            CTPapel, CTTerminacion, CTDespacho, CTFSubTotal, CTVSubTotal, CTTSubTotal, CTFComision, CTVComision, CTTComision, CTFNeto, CTVNeto, CTTNeto, PrecioUnitario};
        }
    }
}