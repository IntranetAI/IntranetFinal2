using Intranet.ModuloCotizadorTransporte.Controller;
using Intranet.ModuloCotizadorTransporte.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloCotizadorTransporte.View
{
    public partial class CalculoFlete : System.Web.UI.Page
    {
        CotizadorTransporteController ct = new CotizadorTransporteController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlDestino.DataSource = ct.ListTerrestres();
                ddlDestino.DataTextField = "Ciudad";
                ddlDestino.DataValueField = "IdTerrestre";
                ddlDestino.DataBind();
                ddlDestino.Items.Insert(0, new ListItem("Seleccione...", "0"));
            }
        }
        [WebMethod]
        public static object CalcularFlete(int IdDestino, string Destino, string Via, double PesoUN, int Cantidad)
        {
            CotizadorTransporteController ct = new CotizadorTransporteController();
            if (IdDestino == 0)
            {
                return new[] { "Error", "Debe seleccionar un Destino." };
            }
            if (PesoUN <= 0)
            {
                return new[] { "Error", "Debe ingresar PesoUN" };
            }
            if (Cantidad <= 0)
            {
                return new[] { "Error", "Debe ingresar Catnidad" };
            }
            double KilosTotales = PesoUN * Convert.ToDouble(Cantidad);
            List<Aereos> listAereos = ct.ListTarifasAeras();
            List<Terrestres> listTerrestre = ct.ListTerrestres();
            List<Ramales> listRamal = ct.ListRamales();
            string Salidas = listTerrestre.Where(x => x.IdTerrestre == IdDestino).Select(x => x.Salidas).FirstOrDefault();
            int Ramal = listRamal.Where(x => x.Ramal == Destino).Select(x => x.Valor).FirstOrDefault();
            string ciudadRamal = listRamal.Where(x => x.Ciudad == Destino).Select(x => x.Ciudad).FirstOrDefault();
            double SegundoValor = 0;double PrimerValor = 0;

            int TarifaAerea = 0;int TarifaTerrestre = 0; double CostoAereoMayorA100KG = 0; double CostoAereoMenorA100KG = 0; double CostoTerrMayorA100KG = 0; double CostoTerrMenorA100KG = 0;

            /*CALCULO PARA TARIFA AERA SEGUN KILOS*/
            if (KilosTotales > 0 && KilosTotales <= 3)
            {
                TarifaAerea = listAereos.Where(x => x.Ciudad == Destino).Select(x => x.de01a03).FirstOrDefault();
            }
            else if (KilosTotales >= 4 && KilosTotales <= 150)
            {
                TarifaAerea = listAereos.Where(x => x.Ciudad == Destino).Select(x => x.de04a150).FirstOrDefault();
            }
            else if (KilosTotales >= 151 && KilosTotales <= 500)
            {
                TarifaAerea = listAereos.Where(x => x.Ciudad == Destino).Select(x => x.de151a500).FirstOrDefault();
            }
            else
            {
                TarifaAerea = listAereos.Where(x => x.Ciudad == Destino).Select(x => x.de501aInfinito).FirstOrDefault();
            }
            /*CALCULO PARA TARIFA TERRESTRE SEGUN KILOS*/
            string algo = "";
            if (KilosTotales > 0 && KilosTotales <= 5)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De01a05).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De01a05).FirstOrDefault();
            }
            else if (KilosTotales >= 6 && KilosTotales <= 10)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De06a10).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De06a10).FirstOrDefault();
            }
            else if (KilosTotales >= 11 && KilosTotales <= 20)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De11a20).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De11a20).FirstOrDefault();
            }
            else if (KilosTotales >= 21 && KilosTotales <= 30)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De21a30).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De21a30).FirstOrDefault();
            }
            else if (KilosTotales >= 31 && KilosTotales <= 40)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De31a40).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De31a40).FirstOrDefault();
            }
            else if (KilosTotales >= 41 && KilosTotales <= 50)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De41a50).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De41a50).FirstOrDefault();
            }
            else if (KilosTotales >= 51 && KilosTotales <= 60)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De51a60).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De51a60).FirstOrDefault();
            }
            else if (KilosTotales >= 61 && KilosTotales <= 70)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De61a70).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De61a70).FirstOrDefault();
            }
            else if (KilosTotales >= 71 && KilosTotales <= 80)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De71a80).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De71a80).FirstOrDefault();
            }
            else if (KilosTotales >= 81 && KilosTotales <= 90)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De81a90).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De81a90).FirstOrDefault();
            }
            else if (KilosTotales >= 91 && KilosTotales <= 100)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De91a100).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De91a100).FirstOrDefault();
            }
            else if (KilosTotales >= 101 && KilosTotales <= 1000)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De101a1000).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De101a1000).FirstOrDefault();
            }
            else if (KilosTotales >= 1001 && KilosTotales <= 4000)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De1001a4000).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De1001a4000).FirstOrDefault();
            }
            else if (KilosTotales >= 4001 && KilosTotales <= 7000)
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De4001a7000).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De4001a7000).FirstOrDefault();
            }
            else //7000+
            {
                TarifaTerrestre = listTerrestre.Where(x => x.Ciudad == Destino).Select(x => x.De7001aInfinito).FirstOrDefault();
                algo = listRamal.Where(x => x.Ciudad == Destino || x.Ramal == Destino).Select(x => x.Ciudad).FirstOrDefault();
                SegundoValor = listTerrestre.Where(x => x.Ciudad == algo).Select(x => x.De7001aInfinito).FirstOrDefault();
            }



            double CostoTotal = 0;

            if (KilosTotales > 100)
            {
                if (Via == "Aereo")
                {
                    PrimerValor = ((Ramal != 0) ? 0 : (TarifaAerea * KilosTotales));
                }
                else
                {
                    PrimerValor = ((Ramal != 0) ? 0 : (TarifaAerea * KilosTotales));
                }
                //costo aereo o terrestre + 
                CostoTotal = CostoTotal + (SegundoValor * KilosTotales) + Ramal;
            }
            else
            {
                if (Via == "Aereo")
                {
                    PrimerValor = ((Ramal != 0) ? 0 : (TarifaAerea * KilosTotales));                    
                }
                else
                {
                    PrimerValor = ((Ramal != 0) ? 0 : TarifaTerrestre);
                }
                //costo aereo o terrestre + 
                CostoTotal = PrimerValor + (SegundoValor) + Ramal;
            }
            var json = "";
            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            /*              Kilos Totales,Ramal Costo Total, Salidas*/
            return new[] { "OK", KilosTotales.ToString(), Ramal.ToString(), CostoTotal.ToString(), Salidas };
        }


        [WebMethod]
        public static object addFletes(string Destino, string Via, double PesoUN, int Cantidad, double KilosTotales, string Ramal, int Costo, string Salidas, string lblJson)
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();

            List<Fletes> fl = new List<Fletes>();
            if (lblJson != "")
            {
                //  string jsons = "[{\"Destino\":\"LEBU\",\"Via\":\"Terrestre\",\"PesoUN\":0.085,\"Cantidad\":100,\"KilosTotales\":8.5,\"Ramal\":\"40000\",\"Costo\":45134,\"Salidas\":\"Lunes y Miercoles\"}]";
                fl = JsonConvert.DeserializeObject<List<Fletes>>(lblJson);
            }
            Fletes f = new Fletes();
            f.Destino = Destino;
            f.Via = Via;
            f.PesoUN = PesoUN;
            f.Cantidad = Cantidad;
            f.KilosTotales = KilosTotales;
            f.Ramal = Ramal;
            f.Costo = Costo;
            f.Salidas = Salidas;
            fl.Add(f);

            //object json = new { data = fl };
            int TotalFletes = 0;
            foreach(Fletes elemento in fl)
            {
                TotalFletes += elemento.Costo;
            }

            return new[] { JsonConvert.SerializeObject(fl), TotalFletes.ToString() };
        }


        public class Fletes
        {
            public string Destino { get; set; }
            public string Via { get; set; }
            public double PesoUN { get; set; }
            public int Cantidad { get; set; }
            public double KilosTotales { get; set; }
            public string Ramal { get; set; }
            public int Costo { get; set; }
            public string Salidas { get; set; }

        }
    }
}