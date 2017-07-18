using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Controller;
using Telerik.Web.UI;

namespace Intranet.ModuloDespacho.View
{
    public partial class RecepcionProveedor : System.Web.UI.Page
    {
        Controller_Proveedor cp = new Controller_Proveedor();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            RadGrid1.DataSource = cp.lista_EnviosProveedor(txtOT.Text, 0, 4);
            RadGrid1.DataBind();
        }
        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {

            //if (e.CommandName == "RowClick")
            //{

            GridDataItem item = (GridDataItem)e.Item;
            //lblOT.Visible = false;
            //txtOT.Visible = false;
            //lblFolio.Visible = true;
            //txtFolio.Visible = true;
            //divBotones.Visible = true;
            //txtFolio.Text = item["Folio"].Text;

            //RadGrid1.DataSource = des.BusquedaPorFolioyOT(txtFolio.Text, "", 4);
            //RadGrid1.DataBind();
            //txtNumeroOT.Text = item["OT"].Text;
        }

    }
}