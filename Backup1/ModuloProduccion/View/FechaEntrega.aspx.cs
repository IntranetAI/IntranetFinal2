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
    public partial class FechaEntrega : System.Web.UI.Page
    {
        ProduccionController control = new ProduccionController();
        OrdenController controlot = new OrdenController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrillas();
            }
        }

        public void CargarGrillas()
        {
            string FechaInicio = "";
            string FechaTermino = "";
            if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
            {
                string FecI = txtFechaInicio.Text;
                string[] str = FecI.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);
                FechaInicio = mes + "/" + dia + "/" + año;

                string FecT = txtFechaTermino.Text;
                string[] str2 = FecT.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);
                FechaTermino = mes2 + "/" + dia2 + "/" + año2;

            }
            List<Intranet.ModuloProduccion.Model.Produccion> lista = control.ListarProduccion(txtNumeroOT.Text.ToString().Trim(), txtNombreOT.Text.ToString().Trim(), txtCliente.Text.ToString().Trim(), 1, FechaInicio.Trim(), FechaTermino.Trim());
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();
            List<Intranet.ModuloProduccion.Model.Produccion> lista2 = control.ListarProduccion(txtNumeroOT.Text.ToString().Trim(), txtNombreOT.Text.ToString().Trim(), txtCliente.Text.ToString().Trim(), 2, FechaInicio.Trim(), FechaTermino.Trim());
            RadGrid2.DataSource = lista2;
            RadGrid2.DataBind();

        }
        
        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "CustomEdit")
            {
                GridDataItem item = (GridDataItem)e.Item;
                
                string popupScript = "<script language='JavaScript'> onload(window.open('Prod_Agregar_Fecha.aspx?cd=" + item["NumeroOT"].Text.ToString() + "','Agregar Fecha Producción','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=750,height=600,left=340,top=100'));</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            CargarGrillas();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            pnlFiltro.Visible = false;
        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            pnlFiltro.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
        }

    }
}