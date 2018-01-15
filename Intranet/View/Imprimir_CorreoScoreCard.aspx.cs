using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.View
{
    public partial class Imprimir_CorreoScoreCard : System.Web.UI.Page
    {
        InformeProduccion_Controller inf = new InformeProduccion_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string Contenido = ""; DateTime fi; DateTime ft; DateTime fi2;
                    if (Request.QueryString["fi"].Contains("-"))
                    {
                        string[] str = Request.QueryString["fi"].Split('-');
                        fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                        fi2 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + "01 00:00:00");

                        ft = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 23:59:59");

                    }
                    else
                    {
                        string[] str = Request.QueryString["fi"].Split('/');
                        fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                        fi2 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + "01 00:00:00");
                        ft = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 23:59:59");
                    }

                    Contenido = //inf.Produccion_CorreoScoreCard_V2("Diario", fi, ft, 0) + //fi, ft, 0
                    inf.Produccion_CorreoScoreCard_V2("Mensual", fi2, ft, 1) +
                   // "<div style='page-break-before: always;'>" + inf.Produccion_CorreoScoreCard_TiempoProduccion_V2("Diario", fi, ft, 3) + "</div>" +
                   // "<div>" + inf.Produccion_CorreoScoreCard_TiempoProduccion_V2("Mensual", fi2, ft, 3) + "</div>";
                   "";
                    Label1.Text = Contenido.ToString();
                }
                catch (Exception ex)
                {
                    string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error.\\n" + ex.Message + "');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                string Contenido = ""; DateTime fi; DateTime ft; DateTime fi2;
                if (txtFechaInicio.Text.Contains("-"))
                {
                    string[] str = txtFechaInicio.Text.Split('-');
                    fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    fi2 = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + "01 00:00:00");

                    ft = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 23:59:59");

                }
                else
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    ft = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
                }
                if (txtFechaInicio.Text == txtFechaTermino.Text)
                {
                    Contenido = inf.Produccion_CorreoScoreCard_V2("Diario", fi, ft, 0) + //fi, ft, 0
                        inf.Produccion_CorreoScoreCard_V2("Mensual", fi, ft, 1) +
                        "<div style='page-break-before: always;'>" + inf.Produccion_CorreoScoreCard_TiempoProduccion_V2("Diario", fi, ft, 3) + "</div>" +
                        "<div>" + inf.Produccion_CorreoScoreCard_TiempoProduccion_V2("Mensual", fi, ft, 3) + "</div>";
                    //PONER DE NUEVO EL FI2
                }
                else
                {
                    Contenido = //inf.Produccion_CorreoScoreCard_V2("Diario", fi, ft, 0) + //fi, ft, 0
                        inf.Produccion_CorreoScoreCard_V2("Mensual", fi, ft, 1) +
                        //"<div style='page-break-before: always;'>" + inf.Produccion_CorreoScoreCard_TiempoProduccion_V2("Diario", fi, ft, 3) + "</div>" +
                        "<div>" + inf.Produccion_CorreoScoreCard_TiempoProduccion_V2("Mensual", fi, ft, 3) + "</div>";
                }


                Label1.Text = Contenido.ToString();
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error.\\n" + ex.Message + "');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}