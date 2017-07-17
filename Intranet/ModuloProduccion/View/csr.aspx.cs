using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using Telerik.Web.UI;

namespace Intranet.ModuloProduccion.View
{
    public partial class csr : System.Web.UI.Page
    {
        ProduccionController control = new ProduccionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
                CargarGrillaFecha();
            }
        }
        public void CargarGrilla()
        {
            
            List<Intranet.ModuloProduccion.Model.Produccion> lista = control.ListOT_Creadas_CSR(Session["Usuario"].ToString(), "", "", "", null, null, 1);
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();
        }

         public void CargarGrillaFecha()
        {
            
            List<Intranet.ModuloProduccion.Model.Produccion> lista = control.List_CSR(Session["Usuario"].ToString(),"","",null,null,1);
            RadGrid2.DataSource = lista;
            RadGrid2.DataBind();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibMostrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            pnlFiltro.Visible = true;
        }

        protected void ibMultiCheck_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibEliminarSuscrita_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {

            string fi;
            string ft;
            if (txtFechaInicio.Text == "")
            {
                fi = "01/01/1900";
                ft = "01/01/1900";
                List<Intranet.ModuloProduccion.Model.Produccion> list = control.List_CSR(Session["Usuario"].ToString(), txtNumeroOT.Text, txtNombreOT.Text, Convert.ToDateTime(fi), Convert.ToDateTime(ft), 1);
                //{
                RadGrid2.DataSource = list;
                RadGrid2.DataBind();

                List<Intranet.ModuloProduccion.Model.Produccion> lista = control.ListOT_Creadas_CSR(Session["Usuario"].ToString(),txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text,Convert.ToDateTime(fi), Convert.ToDateTime(ft), 1);
                RadGrid1.DataSource = lista;
                RadGrid1.DataBind();
            }
            else
            {
                //Fecha inicio
                string fechaIni = txtFechaInicio.Text;
                string[] str = fechaIni.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);
                string fechaInicio = mes + "/" + dia + "/" + año;

                //fecha termino
                string fechat = txtFechaTermino.Text;
                string[] str2 = fechat.Split('/');
                string dia2 = str2[0];
                string mes2 = str2[1];
                string año2 = str2[2];
                año2 = año2.Substring(0, 4);

                string fechaTermino = mes2 + "/" + dia2 + "/" + año2;

                List<Intranet.ModuloProduccion.Model.Produccion> list = control.List_CSR(Session["Usuario"].ToString(), txtNumeroOT.Text, txtNombreOT.Text, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 2);
                //{
                RadGrid2.DataSource = list;
                RadGrid2.DataBind();


                //List<Intranet.ModuloProduccion.Model.Produccion> lista = control.ListOT_Creadas_CSR(Session["Usuario"].ToString(), txtNumeroOT.Text, txtNombreOT.Text, txtCliente.Text, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaTermino), 2);
                //RadGrid1.DataSource = lista;
                //RadGrid1.DataBind();
            }

           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        protected void contactsGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "CustomEdit")
            {
                GridDataItem item = (GridDataItem)e.Item;

                Session["nOT"] = item["NumeroOT"].Text;
                //string emp = item["NombreOT"].Text;
                
                Session["FechaSolicitada"] = item["fechasolicitada"].Text;
                Session["variable"] = 1;
                Response.Redirect("ingresoCSR.aspx");
            }
        }
        protected void contactsGrid_ItemCommand2(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                GridDataItem item = (GridDataItem)e.Item;
                string fechaa = item["FechaCSR"].Text;
                string fecc = fechaa.Substring(25, 10);

                Session["nOT"] = item["NumeroOT"].Text;
                string f = item["FechaCSR"].Text;
                Session["FechaSolicitada"] = fecc;
                Session["variable"] = 2;
                Session["observacion"] = item["observacion"].Text;
                Response.Redirect("ingresoCSR.aspx");
            }

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            pnlFiltro.Visible = false;
        }
    }
}