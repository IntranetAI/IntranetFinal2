using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;
using Telerik.Web.UI;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class ProcesarSolicitudCorte : System.Web.UI.Page
    {
        Controller_Cortadora cc = new Controller_Cortadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFolio.Focus();
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();

                try
                {
                    string codigo = Request.QueryString["cod"];
                    txtFolio.Text = codigo;
                    RadGrid1.DataSource = cc.CargaSolicitud("", "", "", "", codigo, 0, DateTime.Now, DateTime.Now, 1);
                    RadGrid1.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                RadGrid1.DataSource = cc.CargaSolicitud("", "", "", "", txtFolio.Text, 0, DateTime.Now, DateTime.Now, 1);
                RadGrid1.DataBind();
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert(' ¡Codigo de Solicitud no Valido!');location.href='ProcesarSolicitudCorte.aspx?id=3&Cat=10&cod=" + txtFolio.Text + "' </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void txtFolio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadGrid1.DataSource = cc.CargaSolicitud("", "", "", "", txtFolio.Text, 0, DateTime.Now, DateTime.Now, 1);
                RadGrid1.DataBind();
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert(' ¡Codigo de Solicitud no Valido!');location.href='ProcesarSolicitudCorte.aspx?id=3&Cat=10&cod=" + txtFolio.Text + "' </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void btnRecepcionar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                GridDataItem row = RadGrid1.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {//
                    if (row["Estado"].Text != "<div style='Color:Green;'>Atendido</div>" || row["Estado"].Text != "<a style='Color:Red;text-decoration:none;cursor:pointer;'>Ubicar</a>")
                    {
                        contador++;
                        bool r = cc.RecepcionPalletsCortadora(Convert.ToInt32(row["ID"].Text), row["Folio"].Text, Session["Usuario"].ToString(), 0);
                    }
                }
            }
            if (contador > 0)
            {
                string popupScript = "<script language='JavaScript'> alert(' ¡"+contador.ToString()+" Pallets Recepcionados Correctamente!')</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
            }
        }
    }
}