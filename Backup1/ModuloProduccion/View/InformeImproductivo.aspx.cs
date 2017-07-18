using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class InformeImproductivo : System.Web.UI.Page
    {
        InformeProduccion_Controller ip = new InformeProduccion_Controller();
        InformeImproductivo_Controller ii = new InformeImproductivo_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlClasificacion.DataSource = ip.ListaMaquina("", 10);
                ddlClasificacion.DataTextField = "CodMaquina";
                ddlClasificacion.DataValueField = "CodMaquina";
                ddlClasificacion.DataBind();
                ddlClasificacion.Items.Insert(0, new ListItem("Seleccione..."));

                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                RadGrid2.Visible = false;
                
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                string Area = "";
                string Maquina = "";
                string Clasificacion = "";
                string Tipo = "";
                if (txtOT.Text != "")
                {
                    RadGrid1.Visible = true;
                    RadGrid2.Visible = false;


                    if (ddlClasificacion.SelectedValue.ToString() != "Seleccione...")
                    {
                        Clasificacion = ddlClasificacion.SelectedValue.ToString();
                    }
                    else
                    {
                        Clasificacion = "";
                    }
                    if (ddlTipo.SelectedValue.ToString() != "Seleccione...")
                    {
                        Tipo = ddlTipo.SelectedValue.ToString();
                    }
                    else
                    {
                        Tipo = "";
                    }



                    RadGrid1.DataSource = ii.InformeImproductivo(txtOT.Text, ddlArea.SelectedValue.ToString(), ddlMaquina.SelectedValue.ToString(), "", Clasificacion, Tipo, Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("1900-01-01"), 0);
                    RadGrid1.DataBind();
                }
                else
                {
                    if (chkInforme.Checked)
                    {   //con detalle de la OT
                        //sin detalle de la OT
                        if (ddlArea.SelectedValue.ToString() == "Todas")
                        {
                            Area = "";
                        }
                        else
                        {
                            Area = ddlArea.SelectedValue.ToString();
                        }
                        if (ddlMaquina.SelectedValue.ToString() == "Seleccione...")
                        {
                            Maquina = "";
                        }
                        else
                        {
                            Maquina = ddlMaquina.SelectedValue.ToString();
                        }
                        if (ddlClasificacion.SelectedValue.ToString() == "Seleccione...")
                        {
                            Clasificacion = "";
                        }
                        else
                        {
                            Clasificacion = ddlClasificacion.SelectedValue.ToString();
                        }
                        if (ddlTipo.SelectedValue.ToString() == "Seleccione...")
                        {
                            Tipo = "";
                        }
                        else
                        {
                            Tipo = ddlTipo.SelectedValue.ToString();
                        }
                        if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                        {


                            string[] str = txtFechaInicio.Text.Split('/');
                            DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                            string[] str2 = txtFechaTermino.Text.Split('/');
                            DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                            RadGrid1.Visible = true;
                            RadGrid2.Visible = false;
                            RadGrid1.DataSource = ii.InformeImproductivo("", Area, Maquina, "", Clasificacion, Tipo, fi, ft, 1);
                            RadGrid1.DataBind();

                        }
                        else
                        {
                            RadGrid1.Visible = true;
                            RadGrid2.Visible = false;
                            RadGrid1.DataSource = ii.InformeImproductivo("", Area, Maquina, "", Clasificacion, Tipo, Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("1900-01-01"), 2);
                            RadGrid1.DataBind();
                        }


                    }
                    else
                    {   //sin detalle de la OT

                        if (ddlArea.SelectedValue.ToString() == "Todas")
                        {
                            Area = "";
                        }
                        else
                        {
                            Area = ddlArea.SelectedValue.ToString();
                        }
                        if (ddlMaquina.SelectedValue.ToString() == "Seleccione...")
                        {
                            Maquina = "";
                        }
                        else
                        {
                            Maquina = ddlMaquina.SelectedValue.ToString();
                        }
                        if (ddlClasificacion.SelectedValue.ToString() == "Seleccione...")
                        {
                            Clasificacion = "";
                        }
                        else
                        {
                            Clasificacion = ddlClasificacion.SelectedValue.ToString();
                        }
                        if (ddlTipo.SelectedValue.ToString() == "Seleccione...")
                        {
                            Tipo = "";
                        }
                        else
                        {
                            Tipo = ddlTipo.SelectedValue.ToString();
                        }
                        if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                        {

                            string[] str = txtFechaInicio.Text.Split('/');
                            DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                            string[] str2 = txtFechaTermino.Text.Split('/');
                            DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                            RadGrid2.Visible = true;
                            RadGrid1.Visible = false;
                            RadGrid2.DataSource = ii.InformeImproductivo("", Area, Maquina, "", Clasificacion, Tipo, fi, ft, 1);
                            RadGrid2.DataBind();
                        }
                        else
                        {
                            RadGrid2.Visible = true;
                            RadGrid1.Visible = false;
                            RadGrid2.DataSource = ii.InformeImproductivo("", Area, Maquina, "", Clasificacion, Tipo, Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("1900-01-01"), 2);
                            RadGrid2.DataBind();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string popupScript = "<script language='JavaScript'> alert('¡ ha ocurrido un error, vuelva a intentarlo !\n\nError: " + ex.ToString() + "'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }


        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Area = "";
            if (ddlArea.SelectedValue.ToString() == "Todas")
            {
                Area = "";
            }
            else
            {
                Area = ddlArea.SelectedValue.ToString();
            }
            ddlMaquina.DataSource = ip.ListaMaquina(Area, 3);
            ddlMaquina.DataTextField = "Maquina";
            ddlMaquina.DataValueField = "CodMaquina";
            ddlMaquina.DataBind();

            ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
        }

        protected void ddlClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlTipo.DataSource = ip.ListaMaquina(ddlClasificacion.SelectedValue.ToString(), 11);
            ddlTipo.DataTextField = "Maquina";
            ddlTipo.DataValueField = "CodMaquina";
            ddlTipo.DataBind();

            ddlTipo.Items.Insert(0, new ListItem("Seleccione..."));
        }
    }
}