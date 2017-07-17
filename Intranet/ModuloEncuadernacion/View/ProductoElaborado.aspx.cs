using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Model;
using Intranet.ModuloEncuadernacion.Controller;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class ProductoElaborado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigoBarra.Focus();
        }

        protected void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoBarra.Text != "")
            {
                string Usuario = Request.QueryString["u"].ToString();
                Controller_Distribucion controldis = new Controller_Distribucion();
                Distribucion dis = controldis.InsertarCodigoBarra(txtCodigoBarra.Text, Usuario);
                if (dis.Gerencia != "")
                {
                    lblCodigo.Text = txtCodigoBarra.Text;
                    lblMarca.Text = dis.Gerencia;
                    lblValidado.Text = dis.Sector;
                    lblFalta.Text = dis.Destinatario;
                    txtCodigoBarra.Text = String.Empty;
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            string popupScript4 = "<script language='JavaScript'>window.opener.location='DistribucionNaturaCiclo17.aspx?id=6&Cat=2';window.close();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript4);
        }
    }
}