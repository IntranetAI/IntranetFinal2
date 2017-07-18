using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Model;
using Intranet.ModuloAdministracion.Controller;
namespace Intranet.ModuloAdministracion.View
{
    public partial class ControlOTEmitidas : System.Web.UI.Page
    {
        Controller_OTEmitidas ot = new Controller_OTEmitidas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtOT.Focus();
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtOT.Text != "")
            {
                try
                {
                    BodegaPliegos b = ot.BuscaDatosOT(txtOT.Text, "", "", 0, "", DateTime.Now, DateTime.Now, "", "", 0);
                    lblNombreOT.Text = b.NombreOT;
                    lblCliente.Text = b.Cliente;
                    lblTiraje.Text = b.Pliegos;
                    txtFechaEmision.Text = b.FechaCreacion;
                    lblUltimaMod.Text = b.Accion;
                    ddlEstado.SelectedValue = b.Estado;
                    txtObservacion.Focus();
                }
                catch
                {
                    string popupScript = "<script language='JavaScript'> alert('¡ OT no encontrada, vuelva a intentarlo !'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('¡ Debe ingresar el numero de ot a buscar !'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtOT.Text != "" && lblNombreOT.Text != "" && lblCliente.Text != "" && ddlEstado.SelectedValue.ToString()!="Seleccione...")
            {
                try
                {
                    string[] str = txtFechaEmision.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");

                    string[] str2 = lblUltimaMod.Text.Split('/');
                    DateTime f2 = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2]);

                    bool ingre = ot.ingresaOTEmitida(txtOT.Text, lblNombreOT.Text, lblCliente.Text, Convert.ToInt32(lblTiraje.Text.Replace(".", "")), ddlEstado.SelectedValue.ToString(), fi, f2, txtObservacion.Text, Session["Usuario"].ToString(), 1);

                    if (ingre == true)
                    {
                        //Response.Redirect("controlotemitidas.aspx?id=6");
                        string popupScript = "<script language='JavaScript'> alert('¡ OT Agregada Correctamente !');location.href='controlotemitidas.aspx?id=6' </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('¡ Esta OT ya ha sido ingresada. !'); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                catch
                {
                    string popupScript = "<script language='JavaScript'> alert('¡ Ha ocurrido un error, vuelva a intentarlo !'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('¡ Error, campos vacios !'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}