using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.View.Controller;
using System.Text.RegularExpressions;

namespace Intranet.View
{
    public partial class CambioClave : System.Web.UI.Page
    {
        Controller_ResetPassword RP = new Controller_ResetPassword();
        bool respuesta;
        bool verifica;
        string id;
        string cod;
        string cod2;
        bool cambiaPass;
        bool cancel;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["i"].ToString();
            cod = Request.QueryString["c"].ToString();
            cod2 = Request.QueryString["co"].ToString();



            if (Request.QueryString["i"] == "")
            {
                Response.Redirect("Login.aspx");
            }
            else if (Request.QueryString["co"] == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                verifica = RP.verificaEstado(Convert.ToInt32(Request.QueryString["i"]), Request.QueryString["co"]);
                if (verifica == false)
                {
                    string popupScript = "<script language='JavaScript'> alert('¡ La Solicitud de cambio de clave ya fue utilizada ! ');location.href='Login.aspx'</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }

                if (Request.QueryString["e"] == "1")
                {
                    cancel = RP.registroCambioPassword(Convert.ToInt32(Request.QueryString["i"]), Request.QueryString["co"]);
                    if (cancel == true)
                    {
                        string popupScript = "<script language='JavaScript'> alert('¡ La Solicitud de Cambio de clave ha sido cancelada correctamente ! ');location.href='Login.aspx'</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('¡ Ha ocurrido un error, vuelva a intentarlo ! ');</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }

            }
        }
        public bool isValidPass(string Passw)
        {
            //return Regex.IsMatch(Passw, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)|(-_!@#~*.€¬}?¿)^([a-zA-Z0-9]{6,50})$");
            return Regex.IsMatch(Passw, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{0,10})|(-_!@#~*.€¬}?¿)$");
        }

        protected void ibCambiarClave_Click(object sender, ImageClickEventArgs e)
        {
            if (txtClave.Text != "" && txtClave2.Text != "")
            {
                if (txtClave.Text == txtClave2.Text)
                {
                    if (isValidPass(txtClave.Text) == true)
                    {
                        respuesta = RP.registroCambioPassword(Convert.ToInt32(Request.QueryString["i"]), Request.QueryString["co"]);

                        if (respuesta != false)
                        {
                            string popupScript = "<script language='JavaScript'> alert('La Clave ha sido Modificada Correctamente ');location.href='Login.aspx'</script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);

                            cambiaPass = RP.cambiarClave(Convert.ToInt32(Request.QueryString["i"]), txtClave.Text);
                        }
                        else
                        {
                            string popupScript = "<script language='JavaScript'> alert('Ha Ocurrido un error, vuelva a intentarlo');location.href='Login.aspx'</script>";
                            Page.RegisterStartupScript("PopupScript", popupScript);
                        }
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('Estimado Usuario: \\n\\nPor motivos de seguridad su clave debe ser alfanúmerica.');</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert(' Las Claves no Coinciden');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert(' El Campo Clave es Obligatorio.');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}