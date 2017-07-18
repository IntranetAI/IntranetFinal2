using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;
using System.Web.Services;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class RecepcionOrdenCompraFactura : System.Web.UI.Page
    {
        Controller_OrdenCompra oc = new Controller_OrdenCompra();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMaxRecep.Text = oc.MaximoARepcecionar(Request.QueryString["oc"], Request.QueryString["item"], "", 0, "", "", 1);
                lblNroOC.Text = Request.QueryString["oc"];
                lblItem.Text = Request.QueryString["item"];
                lblUsuario.Text = Request.QueryString["usu"];
                lblSKU.Text = Request.QueryString["Sku"];
                lblPapel.Text = Request.QueryString["Papel"].ToUpper();
                lblGramaje.Text = Request.QueryString["Gramaje"];
                lblAncho.Text = Request.QueryString["Ancho"];
                lblLargo.Text = Request.QueryString["Largo"];
                //RadGrid1.DataSource = oc.ListaFacturasRecepcionadas(Request.QueryString["oc"], Request.QueryString["item"], "", 0, "", "", -1);
                //RadGrid1.DataBind();
            }
        }
        [WebMethod]
        public static string[] CreaFactura(string OC,string IDItem,string Documento,string Factura,double Cantidad,string Observacion,string Usuario,int MaxCantidad)
        {
            if ((MaxCantidad - Cantidad) >= 0)
            {
                Controller_OrdenCompra oc = new Controller_OrdenCompra();
                string val=oc.IngresaFactura(OC, IDItem,Documento, Factura, Cantidad, Observacion, Usuario, 3);
                if (val != "0")
                {
                    return new[] { val, "OK" };
                }
                else
                {
                    return new[] { "0", "¡Ha ocurrido un error, vuelva a intentarlo!" };
                }
            }
            else
            {
                return new[] { "0", "¡La cantidad de la factura no puede ser mayor al maximo a recepcionar!" };
            }
        }
        [WebMethod]
        public static string[] IngresoaStock(string OC,string idDetalleOC,string DocumentoLote, string CodigoItem, string Papel, int Gramaje, int Ancho, int Largo, int Cantidad, double Kilos,
            double CostoMedioIngreso, string CreadoPor, int CantidadFaltante)
        {
            string Codigo = "";
            Controller_OrdenCompra oc = new Controller_OrdenCompra();
            //if ((CantidadFaltante - Cantidad) >= 0)
            //{
                Codigo = oc.IngresaOCaStock(OC,idDetalleOC,DocumentoLote, CodigoItem, Papel, Gramaje, Ancho, Largo, Cantidad, Kilos, 0, CreadoPor, 0);
            //}
            //else
            //{
            //    Codigo = "Error";
            //}
            if (CantidadFaltante - Cantidad == 0)
            {
                string algo = oc.IngresaOCaStock(OC,idDetalleOC,DocumentoLote, CodigoItem, Papel, Gramaje, Ancho, Largo, Cantidad, Kilos, 0, CreadoPor, 1);
            }
            return new[] { Codigo };
        }
        //protected void btnAgregarFactura_Click(object sender, EventArgs e)
        //{
        //    //if (txtCantidad.Text != "" && txtNroFactura.Text != "")
        //    //{
        //    //    if (Convert.ToDouble(txtCantidad.Text) <= Convert.ToDouble(lblMaxRecep.Text))
        //    //    {
        //    //        try
        //    //        {
        //    //            RadGrid1.DataSource = oc.ListaFacturasRecepcionadas(Request.QueryString["oc"],Request.QueryString["item"], txtNroFactura.Text, Convert.ToDouble(txtCantidad.Text), txtObservacion.Text, Request.QueryString["usu"], 0);
        //    //            RadGrid1.DataBind();
        //    //            lblMaxRecep.Text = oc.MaximoARepcecionar(Request.QueryString["oc"], Request.QueryString["item"], "", 0, "", "", 1);

        //    //            txtNroFactura.Text = ""; txtNroFactura.Focus();
        //    //            txtObservacion.Text = ""; txtCantidad.Text = "";
        //    //        }
        //    //        catch
        //    //        {
        //    //            Response.Redirect("http://www.google.cl");
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        Response.Redirect("http://www.google.cl");
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    Response.Redirect("http://www.google.cl");
        //    //}
        //}
    }
}