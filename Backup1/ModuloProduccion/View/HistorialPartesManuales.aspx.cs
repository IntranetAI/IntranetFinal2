using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Telerik.Web.UI;

namespace Intranet.ModuloProduccion.View
{
    public partial class HistorialPartesManuales : System.Web.UI.Page
    {
        Controller_PartesManuales pm = new Controller_PartesManuales();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();

                divModificar.Visible = false;
                divGrilla.Visible = true;
                try
                {
                    if (Request.QueryString["Maquina"] != "" || Request.QueryString["fi"] != "" || Request.QueryString["ft"] != "" || Request.QueryString["fechaparte"] != "")
                    {
                        string[] str = Request.QueryString["fechaparte"].Split('/');
                        DateTime pri = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");

                        RadGrid2.DataSource = pm.HistorialCargaParte(Request.QueryString["Maquina"], pri, DateTime.Now, 1);
                        RadGrid2.DataBind();
                        divModificar.Visible = true;
                        divGrilla.Visible = false;

                        string result = pm.CargaErrores(Request.QueryString["Maquina"], pri, DateTime.Now, 2);
                        if (result != "")
                        {
                            lblErrores.Text = result;
                        }
                        else
                        {
                            lblErrores.Text = "¡No se han encontrado Errores!";
                        }

                    }
                }
                catch
                {
                }
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                if (ddlMaquina.SelectedValue.ToString() != "" || ddlMes.SelectedValue.ToString() != "" || ddlAño.SelectedValue.ToString() != "")
                {
                    int ultimodia = DateTime.DaysInMonth(Convert.ToInt32(ddlAño.SelectedValue.ToString()), Convert.ToInt32(ddlMes.SelectedValue.ToString()));
                    DateTime pri = Convert.ToDateTime(ddlAño.SelectedValue.ToString() + "-" + ddlMes.SelectedValue.ToString() + "-01 00:00:00");//AM;
                    DateTime seg = Convert.ToDateTime(ddlAño.SelectedValue.ToString() + "-" + ddlMes.SelectedValue.ToString() + "-" + ultimodia.ToString() + " 00:00:00");//AMD

                    RadGrid1.DataSource = pm.HistorialPorDia(ddlMaquina.SelectedValue.ToString(), pri, seg, 0);
                    RadGrid1.DataBind();

                    divModificar.Visible = false;

                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('Debe seleccionar maquina, mes y año');  </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error al buscar'\\n Error: " + ex.Message + ");  </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = (GridDataItem)e.Item;
                    string aa = dataItem["IDParte"].Text;
                    TextBox txtPli = ((TextBox)dataItem.FindControl("txtPliego"));
                    TextBox txtCodi = ((TextBox)dataItem.FindControl("txtCodigo"));
                    TextBox txtO = ((TextBox)dataItem.FindControl("txtOT"));
                    TextBox txtFI = ((TextBox)dataItem.FindControl("txtFI"));
                    TextBox txtFT = ((TextBox)dataItem.FindControl("txtFT"));
                    TextBox txtBuen = ((TextBox)dataItem.FindControl("txtBuenos"));
                    TextBox txtMal = ((TextBox)dataItem.FindControl("txtMalos"));
                    TextBox txtFac = ((TextBox)dataItem.FindControl("txtFactor"));
                    TextBox txtPar = ((TextBox)dataItem.FindControl("txtFechaParte"));
                    string[] str = txtFI.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2]);
                    string[] str2 = txtFT.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2]);
                    string[] str3 = txtPar.Text.Split('/');
                    DateTime fp = Convert.ToDateTime(str3[1] + "/" + str3[0] + "/" + str3[2] + " 00:00:00");
                    int factor = 1;
                    if (txtFac.Text != "")
                    {
                        factor = Convert.ToInt32(txtFac.Text);
                    }


                    try
                    {
                        bool r = pm.ModificaParte(dataItem["IDParte"].Text,txtCodi.Text, txtPli.Text, txtO.Text, fi, ft, Convert.ToInt32(txtBuen.Text), Convert.ToInt32(txtMal.Text), factor, fp, 0);
                        if (r == true)
                        {
                            string[] str4 = Request.QueryString["fechaparte"].Split('/');
                            DateTime pri = Convert.ToDateTime(str4[1] + "/" + str4[0] + "/" + str4[2] + " 00:00:00");

                            RadGrid2.DataSource = pm.HistorialCargaParte(Request.QueryString["Maquina"], pri, DateTime.Now, 1);
                            RadGrid2.DataBind();
                            divModificar.Visible = true;
                            divGrilla.Visible = false;

                            string result = pm.CargaErrores(Request.QueryString["Maquina"], pri, DateTime.Now, 2);
                            if (result != "")
                            {
                                lblErrores.Text = result;
                            }
                            else
                            {
                                lblErrores.Text = "¡No se han encontrado Errores!";
                            }
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error, vuelva a intentarlo');  </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                    }
                    catch
                    {
                        string popupScript = "<script language='JavaScript'> alert('Ha ocurrido un error, vuelva a intentarlo');  </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }

                }
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'> javascript:window.close();  </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
            
        }


    }
}