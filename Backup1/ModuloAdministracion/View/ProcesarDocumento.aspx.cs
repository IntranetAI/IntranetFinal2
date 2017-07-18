using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloAdministracion.Controller;
using Intranet.ModuloAdministracion.Model;
using Telerik.Web.UI;
using System.Web.Services;
namespace Intranet.ModuloAdministracion.View
{
    public partial class ProcesarDocumento : System.Web.UI.Page
    {
        Document_Controller controldoc = new Document_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            int IDDoctMe = Convert.ToInt32(Request["IDDocMercantil"].ToString());
            int IDTipoCambio = Convert.ToInt32(Request["IDTipoCam"].ToString());
            int IDTipoMercan = Convert.ToInt32(Request["IDTipoDocMer"].ToString());
            if (!IsPostBack)
            {
                CargarDatos(IDDoctMe, IDTipoCambio, IDTipoMercan);
            }
        }

        public void CargarDatos(int IDDoctoMerca, int IDTipoCambio, int IDtipoDocto)
        {
            Documento doc = controldoc.ListarDocPopUp(IDtipoDocto, IDDoctoMerca);
            lblNumDoct.Text = doc.FolioFactura.ToString();
            Documento dc = controldoc.ListarClientePopUp(doc.rut_cliente);
            lblRazonSocial.Text = dc.NombreCliente;
            lblDireccion.Text = dc.NombreTipoDocMer;
            lblPais.Text = dc.NombreCosto;
            Session["IDProducto"] = doc.IDProducto;
            Session["IDDocMercantil"] = IDDoctoMerca;
            List<Documento> lista = controldoc.ListarProductoPopUp(IDDoctoMerca, doc.IDProducto, doc.TipoCambio);
            foreach (Documento d in lista)
            {
                lblOT.Text = d.NombreCliente;
                lblProducto.Text = d.NombreTipoDocMer;
            }
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();
            
        }
        [WebMethod]
        public static void ActualizarDatos(string cortar)
        {
            //string[] a = cortar.Split('-');
            ////a.
            //try
            //{
            //    int cuenta = Convert.ToInt32(a[0].ToString());
            //    int cuenta2 = Convert.ToInt32(a[1].ToString());
            //    int cuneta3 = Convert.ToInt32(a[2].ToString());
            //}
            //catch
            //{
            //}
        }
        //protected void btnActualizar_Click(object sender, EventArgs e)
        //{
        //    GridItemCollection gridRows = RadGrid1.Items;
        //    foreach (GridDataItem data in gridRows)
        //    {
        //        try
        //        {
        //            //DropDownList obj = (DropDownList)data.DataItem;
        //            string aaoj = data.Cells[4].Text.ToString();
        //            string osj = data.Cells[3].Text.ToString();
        //            //valor del drop ventas 
        //            string oj = data.Cells[5]..Text.ToString();
        //            int rstr = oj.LastIndexOf("d'>");//"selected='selected'>Ventas Chile</"
        //            string res = oj.Substring(rstr,oj.Length-rstr);
        //            int rst = res.IndexOf("option");
        //            string rest = oj.Substring(rstr+3,rst-2);
        //        }
        //        catch
        //        {
        //        }
        //    }
            
        //}
    }
}