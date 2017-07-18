using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloBodegaPliegos.Controller;
using Intranet.ModuloBodegaPliegos.Model;
using System.Web.Script.Serialization;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class CrearOC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string muestraProveedores(string NombreProveedor,string Rut)
        {
            Controller_OrdenCompra c = new Controller_OrdenCompra();
            string arrayInserto = c.MuestraProveedores(NombreProveedor, Rut, 9);

            return arrayInserto;
        }//CargarDatosProveedor

        [WebMethod]
        public static string[] CargarDatosProveedor(string IDProveedor)
        {
            try
            {
                Controller_OrdenCompra c = new Controller_OrdenCompra();
                OrdenesCompra o = c.TraeDatosProveedor(IDProveedor, "", 10);
                return new[] { o.Rut, o.Proveedor, o.Email, o.Telefono, o.CondicionPago, o.Direccion };
            }
            catch
            {
                return new[] { "Error" };
            }
        }
        [WebMethod]
        public static string CargarDirecciones(string IDProveedor)
        {
            Controller_OrdenCompra c = new Controller_OrdenCompra();
            List<OrdenesCompra> lista = c.CargaDirecciones(IDProveedor, "", 11);
            List<OrdenesCompra> lista2 = new List<OrdenesCompra>();
            int contador = 1;
            OrdenesCompra insert1 = new OrdenesCompra();
            insert1.Direccion = "Seleccione...";
            lista2.Insert(0, insert1);
            foreach (OrdenesCompra ps in lista)
            {
                OrdenesCompra objst = new OrdenesCompra();
                //objst.Componente = ps.Componente;
                objst.Direccion = ps.Direccion.ToUpper();
                objst.Direccion = ps.Direccion;
                lista2.Insert(contador, objst);
                contador++;
            }
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string CargarCondicion(string IDProveedor)
        {
            Controller_OrdenCompra c = new Controller_OrdenCompra();
            List<OrdenesCompra> lista = c.CargaDirecciones(IDProveedor, "", 12);
            List<OrdenesCompra> lista2 = new List<OrdenesCompra>();
            int contador = 1;
            OrdenesCompra insert1 = new OrdenesCompra();
            insert1.Direccion = "Seleccione...";
            lista2.Insert(0, insert1);
            foreach (OrdenesCompra ps in lista)
            {
                OrdenesCompra objst = new OrdenesCompra();
                //objst.Componente = ps.Componente;
                objst.Direccion = ps.Direccion.ToUpper();
                objst.Direccion = ps.Direccion;
                lista2.Insert(contador, objst);
                contador++;
            }
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
    }
}