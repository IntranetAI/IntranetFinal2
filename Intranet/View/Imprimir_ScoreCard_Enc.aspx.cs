using Intranet.View.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.View
{
    public partial class Imprimir_ScoreCard_Enc : System.Web.UI.Page
    {
        Controller_ScoreCard_ENC sc = new Controller_ScoreCard_ENC();
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

                    Contenido = sc.Produccion_CorreoScoreCard_ENC("Diario",fi, ft, 0) +
                            "<br/>" +
                            sc.Produccion_CorreoScoreCard_ENC("Mensual", fi2, ft, 1);
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
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");

                    Label1.Text = sc.Produccion_CorreoScoreCard_ENC("Rango", fi, ft, 1);
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('Debe poner un rango de fechas');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('ha ocurrido un error, vuelva a intentarlo');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}