using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using Telerik.Web.UI;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloDespacho.Controller;

namespace Intranet.ModuloDespacho.View
{
    public partial class Manifiesto_Carga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string IDOrdenCarga = Request.QueryString["idc"].ToString();
                    TabContainer1.ActiveTabIndex = 1;
                    RadGridSucursales.DataSource = "";
                    RadGridSucursales.DataBind();
                    RadGridOrdenCarga.DataSource = "";
                    RadGridOrdenCarga.DataBind();

                }
                catch
                {
                    RadGridOrdenCarga.DataSource = "";
                    RadGridOrdenCarga.DataBind();
                    RadGridSucursales.DataSource = "";
                    RadGridSucursales.DataBind();
                    RadGridProducto_Terminado.DataSource = "";
                    RadGridProducto_Terminado.DataBind();
                    TabContainer1.ActiveTabIndex = 0;
                }
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCargaPallet_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSucursales_Click(object sender, EventArgs e)
        {
            if (TabContainer1.ActiveTabIndex == 0)
            {
                List<OrdenCarga> lista = new List<OrdenCarga>();
                for (int i = 0; i < RadGridSucursales.Items.Count; i++)
                {
                    GridDataItem row = RadGridSucursales.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        OrdenCarga orden = new OrdenCarga();
                        orden.NombreOT = row["NombreOT"].Text;
                        orden.OT = row["OT"].Text;
                        orden.Cliente = row["Cliente"].Text;
                        orden.Sucursal = row["Sucursal"].Text;
                        orden.Comuna = row["Comuna"].Text;
                        orden.Region = row["Region"].Text;
                        orden.FechaEntrega = row["FechaEntrega"].Text;
                        orden.Estado = "Pendiente";
                        orden.Accion = "<a style='Color:Blue;text-decoration:none;' href='javascript:openPopup(\"" + orden.OT + "\")'>Ver Más</a>";
                        lista.Add(orden);

                    }
                }
                //Label1.Text = "Balmaceda 3398, Calama, Cl-BALMACEDA 2355, ANTOFAGASTA, CL-AVDA.LOS HEROES DE LA CONCEPCION 2311, iquique, CL-";
                RadGridProducto_Terminado.DataSource = lista;
                RadGridProducto_Terminado.DataBind();
                RadGridSucursales.DataSource = "";
                RadGridSucursales.DataBind();
                txtOT.Text = "";
                TabContainer1.ActiveTabIndex = 1;
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert(' ¡Solo se puede Remover las OTs Suscritas! ');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);

            }
            //Controller_Enc Enc = new Controller_Enc();
            //DateTime fec = Convert.ToDateTime("01-01-1900");
            //RadGridProducto_Terminado.DataSource = Enc.CargarAprobadosPT("105084", "", fec, fec, 2);
            //RadGridProducto_Terminado.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string OT = txtOT.Text.Trim();
            string Region = ddlRegion.SelectedValue.ToString().Trim();
            Controller_ManifiestoCarga controlcarga = new Controller_ManifiestoCarga();
            RadGridSucursales.DataSource = controlcarga.Listarsucursales(OT,Region);
            RadGridSucursales.DataBind();
        }
    }
}