using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Model;
using Intranet.ModuloBodegaPliegos.Controller;
using System.Web.Services;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class OrdenCompra : System.Web.UI.Page
    {
        Controller_OrdenCompra oc = new Controller_OrdenCompra();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
                CargarCondicionPago();

                bool ae = oc.EliminarAnteriores(Session["Usuario"].ToString(), "", 6);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<OrdenesCompra> list = oc.ListaProveedores(txtNombreProveedor.Text, txtRut.Text, 0);
                if (list.Count > 0)
                {
                    ddlProveedor.DataSource = list;
                    ddlProveedor.DataTextField = "Proveedor";
                    ddlProveedor.DataValueField = "idProveedor";
                    ddlProveedor.DataBind();

                    ddlProveedor.Items.Insert(0, new ListItem("Seleccione..."));
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Proveedor no encontrado!');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }

            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('¡Ha Ocurrido un error al buscar un proveedor, vuelva a intentarlo!');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            
        }
        public void CargarCondicionPago()
        {
            ddlCondicionPago.DataSource = oc.CargaCondicionesdePago("", "", 1);
            ddlCondicionPago.DataTextField = "CondicionPago";
            ddlCondicionPago.DataValueField = "CondicionPago";
            ddlCondicionPago.DataBind();

            ddlCondicionPago.Items.Insert(0, new ListItem("Seleccione..."));
        }


        protected void btnBuscarSKU_Click(object sender, EventArgs e)
        {
            try
            {
                List<OrdenesCompra> list = oc.BuscaPapel(txtPapel.Text, "", 5);
                if (list.Count > 0)
                {
                    ddlPapel.DataSource = list;
                    ddlPapel.DataTextField = "Papel";
                    ddlPapel.DataValueField = "CodigoItem";
                    ddlPapel.DataBind();

                    ddlCondicionPago.Items.Insert(0, new ListItem("Seleccione..."));

                    string popupScript = "<script language='JavaScript'>Habilitar();</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Papel NO encontrado, vuelva a intentarlo!');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('¡Ha Ocurrido un error al buscar papel, vuelva a intentarlo!');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (lblSKU.Text != "" && lblPapel.Text != "" && ddlMoneda.SelectedValue.ToString() != "Seleccione..." && txtPliegos.Text != "" && lblKilos.Text != "" && txtValorUnitario.Text != "" && lblTotal.Text != "")
            {
                bool r = oc.IngresaEncyDet(lblSKU.Text, lblPapel.Text, ddlMoneda.SelectedValue.ToString(), Convert.ToDouble(0), Convert.ToInt32(txtPliegos.Text), Convert.ToDouble(lblKilos.Text.Replace(".", "")), Convert.ToDouble(txtValorUnitario.Text.Replace(".", ",")), Convert.ToDouble(lblTotal.Text.Replace(".", "")), "", Session["Usuario"].ToString(), 0);
                if (r)
                {
                    RadGrid1.DataSource = oc.ListaItemsIngresados("", "", "", 0, 0, 0, 0, 0, "", Session["Usuario"].ToString(), 1);
                    RadGrid1.DataBind();
                    //limpíar formulariol
                    lblSKU.Text = "";
                    lblPapel.Text = "";
                    txtPliegos.Text = "";
                    lblStock.Text = "";
                    lblKilos.Text = "";
                    txtValorUnitario.Text = "";
                    lblTotal.Text = "";

                    txtNombreProveedor.Enabled = false;
                    txtRut.Enabled = false;
                    btnBuscar.Enabled = false;
                    ddlProveedor.Enabled = false;
                    ddlDireccion.Enabled = false;
                    ddlMoneda.Enabled = false;
                    txtContacto.Enabled = false;
                    txtCorreo.Enabled = false;
                    txtTelefono.Enabled = false;
                    ddlCondicionPago.Enabled = false;
                    txtFechaEntrega.Enabled = false;
                    txtObservacion.Enabled = false;

                    int conta = Convert.ToInt32(lblContador.Text);
                    lblContador.Text = (conta + 1).ToString();
                    
                    string popupScript = "<script language='JavaScript'>Habilitar();</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);


                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Ha Ocurrido al agregar Item, vuelva a intentarlo!');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                    if (RadGrid1.Items.Count > 0)
                    {
                        string popupScript3 = "<script language='JavaScript'>Habilitar();</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript3);
                    }
                }

            }
            else
            {
                if (RadGrid1.Items.Count > 0)
                {
                    string popupScript = "<script language='JavaScript'>Habilitar();</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                string popupScript2 = "<script language='JavaScript'> alert('¡Debe ingresar todos los campos!');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript2);
            }
        }
        [WebMethod]
        public static string[] CrearOrden(string Rut,string CodCliente,string Proveedor,string Direccion,string Contacto,string Correo,string Telefono,string CondicionPago,string FechaEntrega,string Observacion,string Usuario,double ValorMoneda,string Moneda)//string Folio,
        {
            Controller_OrdenCompra oc = new Controller_OrdenCompra();
            string Respuesta = "";
            int resp = 0;
            if (Rut != "" && CodCliente != "" && Proveedor != "" && Proveedor!="Seleccione..." && CondicionPago != "Seleccione..." && FechaEntrega != "")
            {

                string[] str = FechaEntrega.Split('/');
                DateTime fe = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");

                resp = oc.IngresaEnabezado(Rut, CodCliente, Proveedor, Direccion, Contacto, Correo, Telefono, CondicionPago, fe, Observacion, Usuario, Moneda, Convert.ToDouble(ValorMoneda), 0);
                if (resp>0)
                {
                    //generar PDF
                }
                else
                {
                    //error al ingresar
                }
            }
            else
            {
                if (Rut == "")
                {
                    Respuesta += "¡ Debe ingresar el rut de proveedor!<br/>";
                }
                if (Proveedor != "Seleccione...")
                {
                    Respuesta += "¡ Debe seleccionar un proveedor!<br/>";
                }
                if (Direccion != "Seleccione...")
                {
                    Respuesta += "¡ Debe seleccionar una direccion!<br/>";
                }
                if (CondicionPago != "Seleccione...")
                {
                    Respuesta += "¡ Debe seleccionar una condicion de pago!<br/>";
                }
                if (FechaEntrega != "")
                {
                    Respuesta += "¡ Debe ingresar una fecha de entrega!<br/>";
                }
            }
            return new[] { resp.ToString(), Respuesta };
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProveedor.SelectedValue.ToString() != "Seleccione...")
            {
                try
                {
                    OrdenesCompra o = oc.BuscaProveedor(ddlProveedor.SelectedValue.ToString(), "", -1);
                    if (o.CodigoProveedor != "" && o.Rut != "")
                    {
                        txtCorreo.Text = o.Email;
                        txtTelefono.Text = o.Telefono;
                        //lblCorreo.Text = o.Email;
                        //lblTelefono.Text = o.Telefono;
                        txtRut.Text = o.Rut;
                        lblCodProveedor.Text = o.CodigoProveedor;
                        try
                        {
                            ddlCondicionPago.SelectedValue = o.CondicionPago;
                        }
                        catch
                        {
                        }
                        ddlDireccion.DataSource = oc.ListaDireccionesyContacto(o.idProveedor, "", 3);
                        ddlDireccion.DataTextField = "Direccion";
                        ddlDireccion.DataValueField = "Direccion";
                        ddlDireccion.DataBind();
                        ddlDireccion.Items.Insert(0, new ListItem("Seleccione..."));

                        //ddlContacto.DataSource = oc.ListaDireccionesyContacto(o.idProveedor, "", 4);
                        //ddlContacto.DataTextField = "Direccion";
                        //ddlContacto.DataValueField = "Direccion";
                        //ddlContacto.DataBind();
                        //ddlContacto.Items.Insert(0, new ListItem("Seleccione..."));
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'> alert('¡Ha Ocurrido un error al seleccionar el proveedor, vuelva a intentarlo!');</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                catch
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Ha Ocurrido un error al buscar el proveedor, vuelva a intentarlo!');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }

            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('¡Debe Seleccionar un proveedor de la lista!');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ddlPapel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OrdenesCompra o = oc.BuscaSKU(ddlPapel.SelectedValue.ToString(), "", 2);
                if (o.CodigoItem != "" && o.Gramaje != "" && o.Ancho != "" && o.Largo != "")
                {
                    lblSKU.Text = o.CodigoItem;
                    lblStock.Text = o.StockKG;
                    lblGramaje.Text = o.Gramaje;
                    lblAncho.Text = o.Ancho;
                    lblLargo.Text = o.Largo;
                    lblPapel.Text = o.Papel.ToLower();
                    if (RadGrid1.Items.Count > 0)
                    {
                        string popupScript = "<script language='JavaScript'>Habilitar();</script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    
                }
                else
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Ha Ocurrido un error al seleccionar el papel, vuelva a intentarlo!');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch
            {
                string popupScript = "<script language='JavaScript'> alert('¡Ha Ocurrido un error al seleccionar el papel, vuelva a intentarlo!');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void txtPliegos_TextChanged(object sender, EventArgs e)
        {
            if (txtPliegos.Text != "")
            {
                try
                {
                    double Gramaje = Convert.ToDouble(lblGramaje.Text);
                    double Ancho = Convert.ToDouble(lblAncho.Text);
                    double Largo = Convert.ToDouble(lblLargo.Text);
                    double Pliegos = Convert.ToDouble(txtPliegos.Text);

                    double resultado = ((Gramaje * Ancho * Largo) / 1000000000) * Pliegos;
                    lblKilos.Text = resultado.ToString("N2");
                    txtValorUnitario.Focus();
                }
                catch
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Ha Ocurrido con la cantidad de pliegos, vuelva a intentarlo!');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('¡Debe ingresar una cantidad de pliegos!);</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void txtValorUnitario_TextChanged(object sender, EventArgs e)
        {
            if (txtValorUnitario.Text != "")
            {
                try
                {
                    double valorunitario = Convert.ToDouble(txtValorUnitario.Text.Replace(".",","));
                    double pliegos = Convert.ToDouble(txtPliegos.Text);
                    double resultado = (valorunitario * pliegos);

                    lblTotal.Text = resultado.ToString("N2");
                  //  txtObservacionItem.Focus();
                }
                catch
                {
                    string popupScript = "<script language='JavaScript'> alert('¡Ha Ocurrido con el valor unitario, Vuelva a intentarlo!');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('¡Debe ingresar el valor unitario!);</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }


    }
}