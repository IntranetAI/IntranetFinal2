using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;
using System.Web.Services;
using Intranet.ModuloBodegaPliegos.Model;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class RecepcionOrdenCompra : System.Web.UI.Page
    {
        Controller_OrdenCompra oc = new Controller_OrdenCompra();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                RadGrid1.DataSource = oc.ListaOCaRecepcionar("", 0, 0, "", "", 0);
                RadGrid1.DataBind();
            }
        }
        [WebMethod]
        public static string[] CargaItemCompra(string idItem)
        {
            Controller_OrdenCompra oc = new Controller_OrdenCompra();
            OrdenesCompra d = oc.CargaidItem(idItem, 0, 0, "", "", 1);

            return new[] { d.NroOC, d.CodigoItem, d.Papel, d.CantidadPliegos, d.CantidadKG, d.Gramaje, d.Ancho, d.Largo, d.Estado, d.CantidadPliegosRecep, d.CantidadKilosRecep, d.Observacion, d.ValorUnitario };

        }
        [WebMethod]
        public static string[] CargarFaltantes(string idItem)
        {
            if (idItem == "0")
            {
                return new[] { "ERROR"};
            }
            else
            {
                Controller_OrdenCompra oc = new Controller_OrdenCompra();
                OrdenesCompra d = oc.CargaFaltante2("", idItem, "", 0, "", "", 2);
                int cantp = Convert.ToInt32(d.CantidadPliegosRecep);
                int cantr = Convert.ToInt32(d.CantidadPliegos);
                return new[] { d.CantidadPliegosRecep,d.CantidadPliegos, (cantp - cantr).ToString() };
            }
        }
        //[WebMethod]
        //public static string[] IngresoaStock(string idDetalleOC, string CodigoItem, string Papel, int Gramaje, int Ancho, int Largo, int Cantidad, double Kilos,
        //    double CostoMedioIngreso, string CreadoPor,int CantidadFaltante)
        //{
        //    string Codigo = "";
        //    Controller_OrdenCompra oc = new Controller_OrdenCompra();
        //    if ((CantidadFaltante - Cantidad) >= 0)
        //    {
        //        Codigo = oc.IngresaOCaStock(idDetalleOC, CodigoItem, Papel, Gramaje, Ancho, Largo, Cantidad, Kilos, CostoMedioIngreso, CreadoPor, 0);
        //    }
        //    else
        //    {
        //        Codigo = "Error";
        //    }
        //    if (CantidadFaltante - Cantidad == 0)
        //    {
        //        string algo = oc.IngresaOCaStock(idDetalleOC, CodigoItem, Papel, Gramaje, Ancho, Largo, Cantidad, Kilos, CostoMedioIngreso, CreadoPor, 1);
        //    }
        //    return new[] { Codigo};

        //}
        [WebMethod]
        public static string CargaFacturas(string IDItem,string OC)
        {
            Controller_OrdenCompra oc = new Controller_OrdenCompra();
            string res =  oc.CargaFacturasCargadas(IDItem, OC, 13);
            return res;
        }
        //[WebMethod]
        //public static string[] RecepcionarOC(string idDetalleOC, int Cantidad, double Kilos,string Observacion,int Restante, string Usuario)
        //{
        //    string Mensaje = "";
        //    Controller_OrdenCompra oc = new Controller_OrdenCompra();
        //    if (Restante == 0)
        //    {
        //        bool r = oc.IngresarRecepcion(idDetalleOC, "", Observacion, 0, 0, 0, Cantidad, Kilos, 0, Usuario, -1);
        //        if (r)
        //        {
        //            Mensaje = "OK";
        //        }
        //        else
        //        {
        //            Mensaje = "ERROR";
        //        }
        //    }
        //    else
        //    {
        //        Mensaje = "ERROR";
        //    }
                     
        //    return new[] { Mensaje };

        //}
    }
}