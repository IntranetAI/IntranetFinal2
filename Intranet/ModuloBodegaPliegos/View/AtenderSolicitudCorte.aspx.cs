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
    public partial class AtenderSolicitudCorte : System.Web.UI.Page
    {
        Controller_Cortadora cc = new Controller_Cortadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = cc.CargaSolicitudArreglo(txtOT.Text, txtNombreOT.Text, txtPapel.Text, txtCodigo.Text, "", 0, DateTime.Now, DateTime.Now, 4);
                RadGrid1.DataBind();

                txtFolio.Focus();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            DateTime f = Convert.ToDateTime("1900-01-01");
            if (txtFolio.Text != "") 
            {
                RadGrid1.DataSource = cc.CargaSolicitudArreglo("", "", "", "", txtFolio.Text, 0, f, f, 0);
                RadGrid1.DataBind();
            }
            else
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");

                    RadGrid1.DataSource = cc.CargaSolicitudArreglo(txtOT.Text, txtNombreOT.Text, txtPapel.Text, txtCodigo.Text, txtFolio.Text, 0, fi, ft, 2);
                    RadGrid1.DataBind();
                    //2

                }
                else
                {
                    //3                    
                    RadGrid1.DataSource = cc.CargaSolicitudArreglo(txtOT.Text, txtNombreOT.Text, txtPapel.Text, txtCodigo.Text, txtFolio.Text, 0, DateTime.Now, DateTime.Now, 3);
                    RadGrid1.DataBind();
                }
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
                {
                    if (row["Estado"].Text != "<div style='Color:Green;'>Atendido</div>")
                    {
                        contador++;
                        bool r = cc.RecepcionPalletsCortadora(0, row["Folio"].Text, Session["Usuario"].ToString(), 0);
                        // asi.NumeroOT = row["NumeroOT"].Text;
                    }
                }
            }
            if (contador > 0)
            {
                string popupScript = "<script language='JavaScript'> alert(' ¡" + contador.ToString() + " Pallets Recepcionados Correctamente!');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);

                RadGrid1.DataSource = cc.CargaSolicitudArreglo(txtOT.Text, txtNombreOT.Text, txtPapel.Text, txtCodigo.Text, "", 0, DateTime.Now, DateTime.Now, 4);
                RadGrid1.DataBind();

                txtFolio.Focus();
            }
            else
            {
            }
        }
    }
}