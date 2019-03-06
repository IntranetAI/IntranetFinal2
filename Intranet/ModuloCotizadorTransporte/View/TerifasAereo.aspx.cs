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
    public partial class TerifasAereo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string[] UpdateTarifa_V1(string IdAereo, string Ciudad, string de01a03, string de04a150, string de151a500, string de501aInf)
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
    }
}