using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using System.Web.Services;

namespace Intranet.View
{
    public partial class Imprimir_CorreoMerma : System.Web.UI.Page
    {
        InformeProduccion_Controller inf = new InformeProduccion_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string Contenido = "";
                    string Tipo = Request.QueryString["t"];
                    DateTime fi; DateTime ft;
                    if (Request.QueryString["fi"].Contains("-"))
                    {
                        string[] str = Request.QueryString["fi"].Split('-');
                        fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");//1 0 2
                        string[] str2 = Request.QueryString["ft"].Split('-');
                        ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                    }
                    else
                    {
                        string[] str = Request.QueryString["fi"].Split('/');
                        fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                        string[] str2 = Request.QueryString["ft"].Split('/');
                        ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                    }


                    if (Tipo == "Rotativas")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                            inf.Produccion_CorreoMermas_V2("",fi, ft, -1);
                    }
                    else if (Tipo == "Planas")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                        inf.Produccion_CorreoMermas_V2("", fi, ft, 0);
                    }
                    else if (Tipo == "Rotativas-Planas")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                        inf.Produccion_CorreoMermas_V2("", fi, ft, -1) +
                        "<br/>" +
                        "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                        inf.Produccion_CorreoMermas_V2("", fi, ft, 0);
                    }
                    else if (Tipo == "ENC")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Encuadernación</div></b>" +
                      inf.Produccion_CorreoMermas_ENC_V2(fi, ft, 1);
                    }
                    else
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                         inf.Produccion_CorreoMermas_V2("", fi, ft, -1) +
                         "<br/>" +
                         "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                         inf.Produccion_CorreoMermas_V2("", fi, ft, 0) +
                         "<br/>" +
                         "<b><div style='font-size: 20px;'>Producción Encuadernación</div></b>" +
                         inf.Produccion_CorreoMermas_ENC_V2(fi, ft, 1);
                    }
                    lblContenido.Text = Contenido.ToString();
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
                if (txtOT.Text != "")
                {
                    string Contenido = "";
                    string Tipo = Request.QueryString["t"];
                    if (Tipo == "Rotativas")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                            inf.Produccion_CorreoMermas_V2(txtOT.Text, DateTime.Now, DateTime.Now, 4);
                    }
                    else if (Tipo == "Planas")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                        inf.Produccion_CorreoMermas_V2(txtOT.Text, DateTime.Now, DateTime.Now, 5);
                    }
                    else if (Tipo == "Rotativas-Planas")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                        inf.Produccion_CorreoMermas_V2(txtOT.Text, DateTime.Now, DateTime.Now, 6) +
                        "<br/>" +
                        "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                        inf.Produccion_CorreoMermas_V2(txtOT.Text, DateTime.Now, DateTime.Now, 5);
                    }
                    else if (Tipo == "ENC")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Encuadernación</div></b>" +
                      inf.Produccion_CorreoMermas_ENC_V2(DateTime.Now, DateTime.Now, 1);
                    }
                    else
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                         inf.Produccion_CorreoMermas_V2(txtOT.Text, DateTime.Now, DateTime.Now, 4) +
                         "<br/>" +
                         "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                         inf.Produccion_CorreoMermas_V2(txtOT.Text, DateTime.Now, DateTime.Now, 5) +
                         "<br/>";
                         //"<b><div style='font-size: 20px;'>Producción Encuadernación</div></b>" +
                         //inf.Produccion_CorreoMermas_ENC_V2(DateTime.Now, DateTime.Now, 6);
                    }
                    lblContenido.Text = Contenido.ToString();
                    lblContador.Text = "1";
                }
                else
                {
                    string Contenido = "";
                    string Tipo = Request.QueryString["t"];
                    DateTime fi; DateTime ft;
                    if (txtFechaInicio.Text.Contains("-"))
                    {
                        string[] str = txtFechaInicio.Text.Split('-');
                        fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                        string[] str2 = txtFechaTermino.Text.Split('-');
                        ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                    }
                    else
                    {
                        string[] str = txtFechaInicio.Text.Split('/');
                        fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                        string[] str2 = txtFechaTermino.Text.Split('/');
                        ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                    }


                    if (Tipo == "Rotativas")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                            inf.Produccion_CorreoMermas_V2("", fi, ft, -1);
                    }
                    else if (Tipo == "Planas")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                        inf.Produccion_CorreoMermas_V2("", fi, ft, 0);
                    }
                    else if (Tipo == "Rotativas-Planas")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                        inf.Produccion_CorreoMermas_V2("", fi, ft, -1) +
                        "<br/>" +
                        "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                        inf.Produccion_CorreoMermas_V2("", fi, ft, 0);
                    }
                    else if (Tipo == "ENC")
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Encuadernación</div></b>" +
                      inf.Produccion_CorreoMermas_ENC_V2(fi, ft, 1);
                    }
                    else
                    {
                        Contenido = "<b><div style='font-size: 20px;'>Producción Prensas Rotativas</div></b>" +
                         inf.Produccion_CorreoMermas_V2("", fi, ft, -1) +
                         "<br/>" +
                         "<b><div style='font-size: 20px;'>Producción Prensas Planas</div></b>" +
                         inf.Produccion_CorreoMermas_V2("", fi, ft, 0) +
                         "<br/>" +
                         "<b><div style='font-size: 20px;'>Producción Encuadernación</div></b>" +
                         inf.Produccion_CorreoMermas_ENC_V2(fi, ft, 1);
                    }
                    lblContenido.Text = Contenido.ToString();
                }
                lblContador.Text = "1";
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error.\\n" + ex.Message + "');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
        
        
    }
}