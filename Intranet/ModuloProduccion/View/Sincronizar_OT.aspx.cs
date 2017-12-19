using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloProduccion.Controller;
using System.Drawing;

namespace Intranet.ModuloProduccion.View
{
    public partial class Sincronizar_OT : System.Web.UI.Page
    {
        SincroController controlSin = new SincroController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblOTSusc.Text = "";
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            List<SincronizarOT> lista = controlSin.listaOTSincroOT();
            List<SincronizarOT> listaSincro = controlSin.listaOTSincroMetrics();
            string query = "";
            int contador = 0;
            
            foreach (SincronizarOT sinOT in listaSincro)
            {
                string Fec_Liquidacion = "NULL";
                if (sinOT.Fecha_Liquidacion != "1900-01-01 00:00:00.000")
                {
                    Fec_Liquidacion = Convert.ToDateTime(sinOT.Fecha_Liquidacion).ToString("yyyy-dd-MM HH:mm:ss");
                }
                int count = lista.Where(o => o.QG_RMS_JOB_NBR.Trim() == sinOT.QG_RMS_JOB_NBR.Trim()).Count();
                DateTime fecha = Convert.ToDateTime(sinOT.CTD_TMSTMP);
                if (count == 0)
                {
                    

                    query = query + "INSERT INTO Data_P2B.dbo.QGPressJob (QG_RMS_JOB_NBR ,NM ,CTD_TMSTMP ,DUE_DT ,JOB_STS ,CUST_RUT ,CUST_NM, QG_RMS_TITLE_CD ," +
                                        " PRN_ORD_QTY,IMPZ_PROD_HGT,IMPZ_PROD_WDT,OPN_WDTH,OPN_HGT,AccountAddress1,AccountAddress2,AccountNeighborhood," +
                                        " AccountRegion,AccountCountry,AccountCity ,FullIssueName,FECHA_LIQUIDACION) VALUES" +
                                        "('" + sinOT.QG_RMS_JOB_NBR.Trim() + "','" + sinOT.NM.Replace("'", "").Replace('"', ' ') + "','" + fecha.ToString("yyyy-dd-MM HH:mm:ss") + "',NULL," + sinOT.JOB_STS + ",'" + sinOT.CUST_RUT + "','" +
                                        sinOT.CUST_NM.Replace("'", "").Replace('"', ' ') + "','" + sinOT.QG_RMS_TITLE_CD + "'," + sinOT.PRN_ORD_QTY + ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" + Fec_Liquidacion + "');";
                    contador++;
                }
                else
                {
                    int count2  = lista.Where(o=>(o.QG_RMS_JOB_NBR.Trim() == sinOT.QG_RMS_JOB_NBR.Trim())
                                                     && (o.PRN_ORD_QTY == sinOT.PRN_ORD_QTY)
                                                     && (o.JOB_STS == sinOT.JOB_STS)
                                                     && (o.CTD_TMSTMP == sinOT.CTD_TMSTMP)
                                                     && (o.Fecha_Liquidacion == sinOT.Fecha_Liquidacion)).Count();
                    if (count2 == 0)
                    {
                        query = query + "UPDATE Data_P2B.dbo.QGPressJob SET NM = '" + sinOT.NM.Replace("'", "").Replace('"', ' ') + "',CUST_RUT = '" + sinOT.CUST_RUT + "',CTD_TMSTMP = '" + fecha.ToString("yyyy-dd-MM HH:mm:ss") +
                                        "',CUST_NM = '" + sinOT.CUST_NM.Replace("'", "").Replace('"', ' ') + "',PRN_ORD_QTY = " + sinOT.PRN_ORD_QTY + ", JOB_STS= " + sinOT.JOB_STS + ", Fecha_Liquidacion='" + Fec_Liquidacion + "' WHERE QG_RMS_JOB_NBR = '" + sinOT.QG_RMS_JOB_NBR.Trim() + "';";
                        contador++;
                    }
                }
                
            }
            //string query = controlSin.OTSincroMetrics(OT);
            if (contador > 0)
            {
                if (controlSin.SincronizarOT(query))
                {
                    Image4.ImageUrl = "../../Images/tick.png";
                    lblOTSusc.Text = contador.ToString() + " OT Sincronizadas Correctamente.";
                    lblOTSusc.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Green;");
                }
                else
                {
                    Image4.ImageUrl = "../../Images/cross.png";
                    lblOTSusc.Text = "Error con el Servidor. Intentelo nuevamente";
                    lblOTSusc.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:red;");
                }
            } 
            else
            {
                Image4.Visible = false;
                lblOTSusc.Text = "OT ya Sincronizada.";
                lblOTSusc.ForeColor = Color.White;
                DivMensaje.Attributes.Add("style", "background-color:Green;");
            }
        }
           
    }
}