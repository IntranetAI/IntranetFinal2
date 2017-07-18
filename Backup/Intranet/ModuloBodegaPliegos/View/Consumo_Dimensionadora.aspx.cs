using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;
using Intranet.ModuloRFrecuencia.Controller;
using Telerik.Web.UI;
using Intranet.ModuloRFrecuencia.Model;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class Consumo_Dimensionadora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Controller_Dimensionadora dd = new Controller_Dimensionadora();
                
                try
                {
                    lblOT.Text = Request.QueryString["o"].ToString();
                    lblNombreOT.Text = Request.QueryString["n"].ToString();
                    lblComponente.Text = Request.QueryString["c"].ToString();
                    lblCantidad.Text = Request.QueryString["t"].ToString();
                    lblFolio.Text = Request.QueryString["f"].ToString();
                    Bobina_Controller controlBo = new Bobina_Controller();
                    List<Bobina> listaPendiente1 = controlBo.listarBobinaPend(Request.QueryString["o"].ToString(), "&nbsp;", 1);
                    List<Bobina> listaPendiente2 = controlBo.listarBobinaPend(Request.QueryString["o"].ToString(), Request.QueryString["c"].ToString(), 1);
                    List<Bobina> listaConsumoda1 = controlBo.listarBobinaPend(Request.QueryString["o"].ToString(), "&nbsp;", 2);
                    List<Bobina> listaConsumoda2 = controlBo.listarBobinaPend(Request.QueryString["o"].ToString(), Request.QueryString["c"].ToString(), 2);


                    RadGrid4.DataSource = listaPendiente1.Union(listaPendiente2);
                    RadGrid5.DataSource = listaConsumoda1.Union(listaConsumoda2);
                    RadGrid4.DataBind();
                    RadGrid5.DataBind();
                    divPliego.Visible = true;
                    divDimensionadora.Visible = false;
                }
                catch
                {
                    RadGrid2.DataSource = dd.CargaPendientesDimensionadoraConsumo(0, "", "");
                    RadGrid2.DataBind();
                    divPliego.Visible = false;
                    divDimensionadora.Visible = true;
                }
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            Controller_Dimensionadora dd = new Controller_Dimensionadora();
            RadGrid2.DataSource = dd.CargaPendientesDimensionadoraConsumo(1, txtOT.Text.ToString().Trim(), txtFolio.Text.ToString().Trim());
            RadGrid2.DataBind();
            divPliego.Visible = false;
            divDimensionadora.Visible = true ;
        }

        protected void RadGrid4_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "RowClick")
            {
                GridDataItem item = (GridDataItem)e.Item;
                string popupScript = "<script language='JavaScript'> onload(window.open('Consumo_BobinaDimensionadora.aspx?o=" + lblOT.Text + "&c=" + lblComponente.Text + "&f="+lblFolio.Text+"&t="+lblCantidad.Text+"&n="+lblNombreOT.Text+"&code=" + item["ID_Bobina"].Text + "','Consumo Bobina', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=500,left=340,top=200'));</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }


        protected void RadGrid2_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "RowClick")
            {
                GridDataItem item = (GridDataItem)e.Item;
                lblOT.Text = item["OT"].Text;
                lblNombreOT.Text = item["NombreOT"].Text;
                lblComponente.Text = item["Componente"].Text;
                lblCantidad.Text = item["StockFL"].Text;
                lblFolio.Text = item["FechaCreacion"].Text;
                Bobina_Controller controlBo = new Bobina_Controller();
                List<Bobina> listaPendiente1 = controlBo.listarBobinaPend(item["OT"].Text, "&nbsp;", 1);
                List<Bobina> listaPendiente2 = controlBo.listarBobinaPend(item["OT"].Text, item["Componente"].Text, 1);
                List<Bobina> listaConsumoda1 = controlBo.listarBobinaPend(item["OT"].Text, "&nbsp;", 2);
                List<Bobina> listaConsumoda2 = controlBo.listarBobinaPend(item["OT"].Text, item["Componente"].Text, 2);


                RadGrid4.DataSource = listaPendiente1.Union(listaPendiente2);
                RadGrid5.DataSource = listaConsumoda1.Union(listaConsumoda2);
                RadGrid4.DataBind();
                RadGrid5.DataBind();
                divPliego.Visible = true;
                divDimensionadora.Visible = false;
            }
        }
    }
}