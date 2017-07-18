using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdmin.Controller;
using Intranet.ModuloAdmin.Model;

namespace Intranet.ModuloAdmin.View
{
    public partial class Help_DeskFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
            Help_Desk_Controller controlhelp = new Help_Desk_Controller();
            ddlTipo.DataSource = controlhelp.ListarTipoIncidencia();
            ddlTipo.DataTextField = "Incidencia";
            ddlTipo.DataValueField = "IDIncidencia";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));

            //ddlIncidencia.DataSource = controlhelp.ListarIncidencia();
            //ddlIncidencia.DataTextField = "Incidencia";
            //ddlIncidencia.DataValueField = "IDIncidencia";
            //ddlIncidencia.DataBind();
            ddlIncidencia.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));

            ddlAreas.DataSource = controlhelp.ListarAreas();
            ddlAreas.DataTextField = "Incidencia";
            ddlAreas.DataValueField = "Incidencia";
            ddlAreas.DataBind();
            ddlAreas.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddlIncidencia.SelectedItem.Text.ToString() != "Seleccionar")
            {
                Help_Desk_Controller controlhelp = new Help_Desk_Controller();
                ModelHelpDesk help = new ModelHelpDesk();
                help.IDIncidencia = Convert.ToInt32(ddlIncidencia.SelectedValue.ToString());
                help.Incidencia = ddlIncidencia.SelectedItem.Text.ToString();
                help.Area = ddlAreas.SelectedItem.Text.ToString();
                help.Depto = txtDepto.Text.ToString();
                help.Estado = 0;
                string[] str = txtFechaInicio.Text.Split('-');
                help.FeIncidencia = str[2] + "-" + str[1] + "-" + str[0];
                help.Observacion = txtObs.Text.ToString();
                help.Usuario = Session["Usuario"].ToString();

                if (controlhelp.AgregarIncidencia(help))
                {
                    string popupScript4 = "<script language='JavaScript'>alert('Se a generado la solicitud correctamente.');opener.location.reload();window.close();</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
                else
                {
                    string popupScript4 = "<script language='JavaScript'>alert('A ocurrido un problema, intentelo mas tarde');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript4);
                }
            }
        }

        protected void ddlTipo_TextChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedItem.Text != "Seleccionar")
            {
                Help_Desk_Controller controlhelp = new Help_Desk_Controller();
                ddlIncidencia.DataSource = controlhelp.ListarIncidencia(ddlTipo.SelectedValue.ToString());
                ddlIncidencia.DataTextField = "Incidencia";
                ddlIncidencia.DataValueField = "IDIncidencia";
                ddlIncidencia.DataBind();
            }
            else
            {
                ddlIncidencia.DataSource = "";
                ddlIncidencia.DataBind();
            }
            ddlIncidencia.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));
        }
    }
}