using Intranet.ModuloBobina.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet
{
    public partial class Inventario : System.Web.UI.Page
    {
        InventarioController ic = new InventarioController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnVolver.Visible = false;
                txtCodigo.Enabled = false;
                pnlNuevo.Visible = false;
                pnlExistente.Visible = false;
                Label7.Visible = false;
                Label10.Visible = false;
                Label9.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (ic.insertInventario(txtCodigo.Text.Replace("-",""), Convert.ToInt32(Label7.Text)) > 0)
                {
                    lblTabla.Text = ic.tablaInventario(Convert.ToInt32(Label7.Text));
                }
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
            //Label7.Text
        }

        protected void btnExistente_Click(object sender, EventArgs e)
        {
            pnlExistente.Visible = true;
            pnlNuevo.Visible = false;
            pnlDetalle.Visible = true;
            pnlInicio.Visible = false;
            btnVolver.Visible = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlExistente.Visible = false;
            pnlNuevo.Visible = true;
            pnlDetalle.Visible = true;
            pnlInicio.Visible = false;
            btnVolver.Visible = true;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                int res = ic.BuscarInventario(txtBuscar.Text);
                if (res > 0)
                {
                    Label10.Text = res.ToString();
                    lblTabla.Text = ic.tablaInventario(res);
                    txtCodigo0.Enabled = true;
                    txtCodigo0.Focus();
                }
                else
                {
                    lblTabla.Text = "";
                    txtCodigo0.Enabled = false;
                }
            }
        }

        protected void txtCodigo0_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo0.Text != "" && txtCodigo0.Text !=null  && Label10.Text != "" && Label10.Text != "0")
            {
                if (ic.insertInventario(txtCodigo0.Text.Replace("-", ""), Convert.ToInt32(Label10.Text)) > 0)
                {
                    lblTabla.Text = ic.tablaInventario(Convert.ToInt32(Label10.Text));
                }
                txtCodigo0.Focus();
                txtCodigo0.Text = "";
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                int listado = ic.NuevoInventario(txtNombre.Text);
                if (listado > 0)
                {
                    Label7.Text = listado.ToString();
                    lblTabla.Text = "";
                    txtCodigo.Enabled = true;
                    txtCodigo.Focus();
                }
            }
        }
    }
}