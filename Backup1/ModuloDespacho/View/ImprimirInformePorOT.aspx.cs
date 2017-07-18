using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;

namespace Intranet.ModuloDespacho.View
{
    public partial class ImprimirInformePorOT : System.Web.UI.Page
    {
        DespachoController controldes = new DespachoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            string ot = Request.QueryString["ot"];
            string nombreot = Request.QueryString["not"];
            string fi = Request.QueryString["fi"];
            string ft = Request.QueryString["ft"];


            if (ot != "")
            {
                lblTitulo2.Text = "OT: " + ot.ToUpper();
            }
            else if (fi != "" && ft != "")
            {
                lblTitulo2.Text = "DESDE " + fi + "  HASTA " + ft;
            }



            if (ot.Length > 4)
            {
                RadGrid2.Visible = false;
                RadGrid1.Visible = true;
                RadGrid1.DataSource = controldes.ListarDespacho_informePorOT(ot, null, null, null, null, 1);
                RadGrid1.DataBind();

            }
            else
            {
                if (Request.QueryString["fi"] != "" && Request.QueryString["ft"] != "")
                {
                    string fechaI = fi;
                    string[] str = fechaI.Split('/');
                    string dia = str[0];
                    string mes = str[1];
                    string año = str[2];
                    año = año.Substring(0, 4);

                    string fechaInicio = año + "-" +mes + "-" + dia;
                    //fechas
                    string fechaT = ft;
                    string[] str2 = fechaT.Split('/');
                    string dia2 = str2[0];
                    string mes2 = str2[1];
                    string año2 = str2[2];
                    año2 = año2.Substring(0, 4);

                    string fechaTermino = año2 + "-" + mes2 + "-" + dia2;
                    RadGrid1.Visible = false;
                    RadGrid2.Visible = true;
                    //carga con fechas
                    if (fechaInicio == fechaTermino)
                    {
                        fechaInicio = fechaInicio + " 00:00:00";
                        fechaTermino = fechaTermino + " 23:59:59";
                    }
                    RadGrid2.DataSource = controldes.ListarDespacho_informePorOTAgrupada(ot, nombreot, fechaInicio, fechaTermino, 2);
                    RadGrid2.DataBind();

                }
                else
                {
                    string fi2 = "2012-01-01 00:00:00";
                    string ft2 = "2100-01-01 23:59:59";
                    RadGrid1.Visible = false;
                    RadGrid2.Visible = true;
                    //carga con fechas
                    RadGrid2.DataSource = controldes.ListarDespacho_informePorOTAgrupada(ot, nombreot, fi2, ft2, 3);
                    RadGrid2.DataBind();

                }

            }

        }
    }
}