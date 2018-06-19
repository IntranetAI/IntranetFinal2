using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloMateriaPrima.Controller;

namespace Intranet.ModuloMateriaPrima.View
{
    public partial class Control_ConsumoMetrics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            Controller_Consumo cc = new Controller_Consumo();
            try
            {
                if (txtOT.Text != "")
                {
                    if (txtOT.Text == "108")
                    {
                        if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                        {
                            //PARA OT 108
                            Label11.Text = cc.CargaConsumoMetricsV2(txtOT.Text,DateTime.Now, DateTime.Now,  -1);
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('¡ La OT 108 debe tener Fecha de inicio y termino!'); </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                    }
                    else
                    {
                        //OTS NORMALES
                        Label11.Text = cc.CargaConsumoMetricsV2(txtOT.Text,DateTime.Now, DateTime.Now,  1);
                    }
                }
                else if(txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    //OTS POR FECHAS
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[2] + "-" + str[1] + "-" + str[0] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[2] + "-" + str2[1] + "-" + str2[0] + " 23:59:59");
                    //OTS CON CONSUMO EN RANGO DE FECHAS
                    string ot = cc.CargaOTSV2("", fi, ft, 2);
                    //BUSCA TODAS LAS OTS DEL RANGO Y TRAE SU CONSUMO INDEPENDIENTE DE SUS FECHAS DE CONSUMOS
                    Label11.Text = cc.CargaConsumoMetricsV2(ot, DateTime.Now, DateTime.Now, 0);
                }
            }
            catch
            {
                Label11.Text = "<div align='center'>¡No se han Encontrado Registros!</div>";
            }
        }
    }
}