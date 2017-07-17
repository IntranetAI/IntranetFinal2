using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class InformeDiarioEncuadernacion : System.Web.UI.Page
    {
        Controller_InformeSemanal inf = new Controller_InformeSemanal();
        InformeProduccion_Controller ip = new InformeProduccion_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();

                //ddlMaquina.DataSource = ip.ListaMaquina("ENCADERN", 3);
                //ddlMaquina.DataTextField = "Maquina";
                //ddlMaquina.DataValueField = "CodMaquina";
                //ddlMaquina.DataBind();

                //ddlMaquina.Items.Insert(0, new ListItem("Seleccione..."));
            }
        }
        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
               
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                    if (ft > fi)
                    {
                        //if (ddlMaquina.SelectedValue.ToString() != "Seleccione...")
                        //{
                            RadGrid1.DataSource = inf.ListaInformeDiarioEncuadernacion("", "", fi, ft, 4);
                            RadGrid1.DataBind();
                            //lblGrid1.Text = ddlMaquina.SelectedItem.ToString();
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('¡La Fecha de termino debe ser mayor a la fecha de inicio!'); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Debe ingresar fecha de inicio y fin!'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('¡A ocurrido un error, vuelva a intentarlo!'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }
    }
}