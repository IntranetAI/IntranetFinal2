using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class EstadisticaProduccionSemanal : System.Web.UI.Page
    {
        InformeProduccion_Controller ip = new InformeProduccion_Controller();
        Controller_InformeSemanal inf = new Controller_InformeSemanal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid2.DataSource = "";
                RadGrid2.DataBind();
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }
        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Area = "";
                if (ddlSeccion.SelectedValue.ToString() == "Todas")
                {
                    Area = "";
                }
                else
                {
                    Area = ddlSeccion.SelectedValue.ToString();
                }
                ddlMaquina.DataSource = ip.ListaMaquina(Area, 3);
                ddlMaquina.DataTextField = "Maquina";
                ddlMaquina.DataValueField = "CodMaquina";
                ddlMaquina.DataBind();

                ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
            }
            catch
            {
            }
        }
        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                if (ddlSeccion.SelectedValue.ToString() != "Seleccione...")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                    try
                    {
                        RadGrid2.DataSource = inf.ListaInformeMaquina("", "", fi, ft, 0);
                        RadGrid2.DataBind();
                    }
                    catch
                    {
                    }
                    try
                    {
                        RadGrid1.DataSource = inf.ListaInformeMaquinaPorTurno("", "", fi, ft, 3);
                        RadGrid1.DataBind();
                    }
                    catch
                    {
                    }
                    try
                    {
                        RadGrid3.DataSource = inf.ListaInformeMaquinaAcumuladoMes("", "", fi, ft, 5);
                        RadGrid3.DataBind();
                    }
                    catch
                    {
                    }
                    try
                    {
                        RadGrid4.DataSource = inf.ListaInformeMaquinaAcumuladoMes("", "", fi, ft, 6);
                        RadGrid4.DataBind();
                    }
                    catch
                    {
                    }
                    #region MES
                    string Mes = "";
                    switch (fi.Month)
                    {
                        case 1:
                            Mes = "Enero";
                            break;
                        case 2:
                            Mes = "Febrero";
                            break;
                        case 3:
                            Mes = "Marzo";
                            break;
                        case 4:
                            Mes = "Abril";
                            break;
                        case 5:
                            Mes = "Mayo";
                            break;
                        case 6:
                            Mes = "Junio";
                            break;
                        case 7:
                            Mes = "Julio";
                            break;
                        case 8:
                            Mes = "Agosto";
                            break;
                        case 9:
                            Mes = "Septiembre";
                            break;
                        case 10:
                            Mes = "Octubre";
                            break;
                        case 11:
                            Mes = "Noviembre";
                            break;
                        case 12:
                            Mes = "Diciembre";
                            break;
                    }
                    #endregion

                    lblMes.Text = Mes;
                    lblAño.Text = fi.Year.ToString();
                }
            }
        }

 


    }
}