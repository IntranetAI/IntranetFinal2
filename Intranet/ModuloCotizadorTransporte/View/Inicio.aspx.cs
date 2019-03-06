using Intranet.ModuloCotizadorTransporte.Controller;
using Intranet.ModuloCotizadorTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloCotizadorTransporte.View
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static object getRamal()
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            List<Ramales> lista = tc.ListRamales();

            object json = new { data = lista };
            return json;
        }
        [WebMethod]
        public static string[] saveRamal(string NombreRamal, string Ciudad, string Valor)
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            try
            {
                int respuesta = tc.GuardarRamal(NombreRamal, Ciudad, Convert.ToInt32(Valor), "cjerias", 0);
                if (respuesta > 0)
                {
                    return new[] { "OK" };
                }
                else
                {
                    return new[] { "Error", "Ha ocurrido un error, vuelve a intentarlo." };
                }

            }
            catch (Exception ex)
            {
                return new[] { "Error", ex.Message.ToString() };

            }

        }
        [WebMethod]
        public static string[] UpdateRamal(string idRamal,string NombreRamal, string Ciudad, string Valor)
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            try
            {
                int respuesta = tc.UpdateRamal(Convert.ToInt32(idRamal),NombreRamal, Ciudad, Convert.ToInt32(Valor), "cjerias", 1);
                if (respuesta > 0)
                {
                    return new[] { "OK" };
                }
                else
                {
                    return new[] { "Error", "Ha ocurrido un error, vuelve a intentarlo." };
                }
            }
            catch (Exception ex)
            {
                return new[] { "Error", ex.Message.ToString() };

            }

        }
        [WebMethod]
        public static string[] DeleteRamal(string idRamal)
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            try
            {
                int respuesta = tc.DeleteRamal(Convert.ToInt32(idRamal), 2);
                if (respuesta > 0)
                {
                    return new[] { "OK" };
                }
                else
                {
                    return new[] { "Error", "Ha ocurrido un error, vuelve a intentarlo." };
                }
            }
            catch (Exception ex)
            {
                return new[] { "Error", ex.Message.ToString() };

            }

        }



        /* TARIFAS AEREAS*/
        [WebMethod]
        public static object getTarifas()
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            List<Aereos> lista = tc.ListTarifasAeras();

            object json = new { data = lista };
            return json;
        }
        [WebMethod]
        public static string[] saveTarifa(string Ciudad, string de01a03, string de04a150, string de151a500, string de501aInf)
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            try
            {
                int respuesta = tc.GuardarTarifa(Ciudad, Convert.ToInt32(de01a03), Convert.ToInt32(de04a150), Convert.ToInt32(de151a500), Convert.ToInt32(de501aInf), "cjerias", 0);
                if (respuesta > 0)
                {
                    return new[] { "OK" };
                }
                else
                {
                    return new[] { "Error", "Ha ocurrido un error, vuelve a intentarlo." };
                }

            }
            catch (Exception ex)
            {
                return new[] { "Error", ex.Message.ToString() };

            }

        }

        [WebMethod]
        public static string[] UpdateTarifa(string IdAereo,string Ciudad, string de01a03, string de04a150, string de151a500, string de501aInf)
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            try
            {
                int respuesta = tc.UpdateTarifa(Convert.ToInt32(IdAereo), Ciudad, Convert.ToInt32(de01a03), Convert.ToInt32(de04a150), Convert.ToInt32(de151a500), Convert.ToInt32(de501aInf), "cjerias", 1);
                if (respuesta > 0)
                {
                    return new[] { "OK" };
                }
                else
                {
                    return new[] { "Error", "Ha ocurrido un error, vuelve a intentarlo." };
                }
            }
            catch (Exception ex)
            {
                return new[] { "Error", ex.Message.ToString() };

            }

        }

        [WebMethod]
        public static string[] DeleteTarifa(string IdAereo)
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            try
            {
                int respuesta = tc.DeleteTarifa(Convert.ToInt32(IdAereo), 2);
                if (respuesta > 0)
                {
                    return new[] { "OK" };
                }
                else
                {
                    return new[] { "Error", "Ha ocurrido un error, vuelve a intentarlo." };
                }
            }
            catch (Exception ex)
            {
                return new[] { "Error", ex.Message.ToString() };

            }

        }




        /* TARIFAS TERRESTRES*/
        [WebMethod]
        public static object getTerrestres()
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            List<Terrestres> lista = tc.ListTerrestres();

            object json = new { data = lista };
            return json;
        }

        [WebMethod]
        public static object addFlete(string Destino, string Via, int PesoUN, int Cantidad, double KilosTotales, string Ramal, int Costo, string Salidas)
        {
            CotizadorTransporteController tc = new CotizadorTransporteController();
            List<Ramales> lista = tc.ListRamales();

            object json = new { data = lista };
            return json;
        }
    }
}