using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloDespacho.Controller;
using System.Web.Services;

namespace Intranet.ModuloDespacho.View
{
    public partial class Ingre_DetFact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Controller_Factura controlFac = new Controller_Factura();
                lblUsuario.Text = Request.QueryString["u"].ToString();
                lblNFactura.Text = " " + controlFac.BuscarIDFactura(Convert.ToInt32(Request.QueryString["id"]));
                CargarGrilla(Convert.ToInt32(Request.QueryString["id"]), lblUsuario.Text);
                //txtPrecioUniFijo.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
                txtM2.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
                txtCantidadFijo.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
                txtCantidadVari.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
                txtCantidadM2.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
                txtTotalVari.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
                txtTotalFijo.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
                try
                {
                    if (Request.QueryString["modi"] != null)
                    {
                        Factura f = controlFac.BuscarIDDetalle(Convert.ToInt32(Request.QueryString["modi"]));
                        if (f.Costo == "Fijo")
                        {
                            TabContainer1.ActiveTabIndex = 0;
                            txtOTFijo.Text = f.OT;
                            lblNombreOtFijo.Text = f.NombreOT;
                            ddlProceso.Items.FindByText(f.Proceso).Selected = true;
                            txtCantidadFijo.Text = f.Cantidad.ToString("N0").Replace(",", ".");
                            txtPrecioUniFijo.Text = f.PrecioUnit.ToString();
                            btnAgregarFijo.Visible = false;
                            btnModifiFijo.Visible = true;
                            txtTotalFijo.Text = Convert.ToInt32(f.Total).ToString("N0").Replace(",", ".");
                            txtObservacionFijo.Text = f.Observacion;
                        }
                        else
                        {
                            TabContainer1.ActiveTabIndex = 1;
                            txtOTVari.Text = f.OT;
                            lblNombreOTVari.Text = f.NombreOT;
                            ddlBarniz.Items.FindByText(f.Barniz).Selected = true;
                            ddlTipo.Items.FindByText(f.Tipo).Selected = true;
                            ddlExterno.Items.FindByText(f.Proceso).Selected = true;
                            txtCantidadVari.Text = f.Cantidad.ToString("N0").Replace(",", ".");
                            txtPreUnitVari.Text = f.PrecioUnit.ToString();
                            txtObservVari.Text = f.Observacion;
                            txtCantidadM2.Text = Convert.ToInt32(f.Cant).ToString("N0").Replace(",", ".");
                            txtTotalVari.Text = Convert.ToInt32(f.Total).ToString("N0").Replace(",", ".");

                            if (f.Formato != "")
                            {
                                string[] split = f.Formato.Split('x');
                                txtAncho.Text = split[0].Trim();
                                txtLargo.Text = split[1].Trim();
                            }
                            txtM2.Text = f.M2;
                            btnagregarvari.Visible = false;
                            btnModificarvari.Visible = true;
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public void CargarGrilla(int id, string Usuario)
        {
            Controller_Factura controlFac = new Controller_Factura();
            RgTemporal.DataSource = controlFac.Listar_Detfactura(id, Usuario);
            RgTemporal.DataBind();
            Cargar_ProcesoExterno();
            Cargar_TipoProExterno();
        }

        public void Cargar_ProcesoExterno()
        {
            Controller_Factura controlFac = new Controller_Factura();
            ddlExterno.DataSource = controlFac.listarProexterno();
            ddlExterno.DataTextField = "Proceso";
            ddlExterno.DataValueField = "Proceso";
            ddlExterno.DataBind();
            ddlExterno.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));
        }

        public void Cargar_TipoProExterno()
        {
            Controller_Factura controlFac = new Controller_Factura();
            ddlTipo.DataSource = controlFac.listarTipoProexterno();
            ddlTipo.DataTextField = "Proceso";
            ddlTipo.DataValueField = "Proceso";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, new ListItem("Seleccionar", "Seleccionar"));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validador(1))
                {
                    Factura fact = new Factura();
                    fact.NFactura = Convert.ToInt32(Request.QueryString["id"]);
                    fact.OT = txtOTFijo.Text;
                    fact.Proceso = ddlProceso.SelectedItem.Text;
                    fact.Cant = "0";
                    fact.Cantidad = Convert.ToInt32(txtCantidadFijo.Text.Replace(".", string.Empty));
                    fact.Observacion = txtObservacionFijo.Text;
                    fact.Tipo = "";
                    fact.Formato = "";
                    fact.PrecioUnit = Convert.ToDouble(txtPrecioUniFijo.Text);
                    fact.Barniz = "";
                    fact.Costo = "Fijo";
                    fact.Total = txtTotalFijo.Text.Replace(".", string.Empty);
                    fact.Usuario = lblUsuario.Text;
                    Controller_Factura controlFac = new Controller_Factura();
                    if (controlFac.InsertDetFactura(fact))
                    {
                        CargarGrilla(fact.NFactura, fact.Usuario);
                        ClearForm();
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'>Validador('Fijo');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch (Exception excep)
            {
                string popupScript = "<script language='JavaScript'>alert('A Ocurrido el Siguente Error <br/>" + excep.Message + "');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void btnagregarvari_Click(object sender, EventArgs e)
        {
            try
            {
                if (validador(2))
                {
                    Factura fact = new Factura();
                    fact.NFactura = Convert.ToInt32(Request.QueryString["id"]);
                    fact.OT = txtOTVari.Text;
                    fact.Proceso = ddlExterno.SelectedValue.ToString();
                    fact.Cantidad = Convert.ToInt32(txtCantidadVari.Text.Replace(".", string.Empty));
                    fact.Observacion = txtObservVari.Text;
                    fact.Tipo = ddlTipo.SelectedItem.ToString();
                    fact.Formato = txtAncho.Text + " x " + txtLargo.Text;
                    fact.PrecioUnit = Convert.ToDouble(txtPreUnitVari.Text);
                    fact.Barniz = ddlBarniz.SelectedItem.ToString();
                    fact.Costo = "Variable";
                    fact.Usuario = lblUsuario.Text;
                    fact.M2 = txtM2.Text;
                    fact.Cant = txtCantidadM2.Text.Replace(".", string.Empty);
                    fact.Total = txtTotalVari.Text.Replace(".", string.Empty);
                    Controller_Factura controlFac = new Controller_Factura();

                    if (controlFac.InsertDetFactura(fact))
                    {
                        CargarGrilla(fact.NFactura, fact.Usuario);
                        ClearForm();
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'>Validador('Variable');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch (Exception excep)
            {
                string popupScript = "<script language='JavaScript'>alert('A Ocurrido el Siguente Error <br/>" + excep.Message + "');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void txtOTVari_TextChanged(object sender, EventArgs e)
        {
            OrdenController controlOT = new OrdenController();
            Orden ot = controlOT.BuscarPorOT(txtOTVari.Text);
            string Dato = ot.NombreOT;
            if (Dato != null)
            {
                if (Dato.Length > 27)
                {
                    lblNombreOTVari.Text = Dato.Substring(0, 23) + "...";
                }
                else
                {
                    lblNombreOTVari.Text = Dato;
                }
            }
        }

        protected void txtOTFijo_TextChanged(object sender, EventArgs e)
        {
            OrdenController controlOT = new OrdenController();
            Orden ot = controlOT.BuscarPorOT(txtOTFijo.Text);
            string Dato = ot.NombreOT;
            if (Dato != null)
            {
                if (Dato.Length > 31)
                {
                    lblNombreOtFijo.Text = Dato.Substring(0, 31) + "...";
                }
                else
                {
                    lblNombreOtFijo.Text = Dato;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                double total = 0;
                for (int i = 0; i < RgTemporal.Items.Count; i++)
                {

                    total = total + Convert.ToInt32(RgTemporal.Items[i]["Total"].Text);
                }
                int iva = Convert.ToInt32(total * 0.19);
                int TotalFinal = (Convert.ToInt32(total) + Convert.ToInt32(iva));

                Controller_Factura controlFac = new Controller_Factura();
                controlFac.UpdateDetalle(Request.QueryString["id"], 1, lblUsuario.Text, total, iva, TotalFinal);
                string popupScript = "<script language='JavaScript'>window.opener.location='ServiciosExternos.aspx?id=8&Cat=6';window.close();</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            catch (Exception excep)
            {
                string popupScript = "<script language='JavaScript'>alert('A Ocurrido el Siguente Error <br/>"+excep.Message+"');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
        //Modificado el 22/10/2014
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Controller_Factura controlFac = new Controller_Factura();
                controlFac.UpdateDetalle(Request.QueryString["id"], 2, lblUsuario.Text, 0, 0, 0);
                string popupScript = "<script language='JavaScript'>window.opener.location='ServiciosExternos.aspx?id=8&Cat=6';window.close();</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            catch (Exception excep)
            {
                string popupScript = "<script language='JavaScript'>alert('A Ocurrido el Siguente Error <br/>"+excep.Message+"');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        public void ClearForm()
        {
            txtOTFijo.Text = "";
            lblNombreOtFijo.Text = "";
            txtObservacionFijo.Text = "";
            txtCantidadFijo.Text = "";
            txtPrecioUniFijo.Text = "";
            ddlProceso.ClearSelection();

            txtOTVari.Text = "";
            lblNombreOTVari.Text = "";
            txtObservVari.Text = "";
            txtCantidadVari.Text = "";
            txtPreUnitVari.Text = "";

            ddlBarniz.ClearSelection();
            ddlTipo.ClearSelection();
            ddlExterno.ClearSelection();
            txtAncho.Text = "";
            txtLargo.Text = "";
            txtM2.Text = "";

            txtCantidadFijo.Text = "";
            txtCantidadVari.Text = "";
            txtTotalFijo.Text = "";
            txtTotalVari.Text = "";
            txtCantidadM2.Text = "";

        }

        //Modificado el 22/10/2014
        protected void btnModifiFijo_Click(object sender, EventArgs e)
        {
            try
            {
                if (validador(1))
                {
                    Factura fact = new Factura();
                    fact.ID_Factura = Convert.ToInt32(Request.QueryString["modi"]);
                    fact.NFactura = Convert.ToInt32(Request.QueryString["id"]);
                    fact.OT = txtOTFijo.Text;
                    fact.Proceso = ddlProceso.SelectedItem.Text;
                    fact.Cant = "0";
                    fact.Cantidad = Convert.ToInt32(txtCantidadFijo.Text.Replace(".", string.Empty));
                    fact.Observacion = txtObservacionFijo.Text;
                    fact.Tipo = "";
                    fact.Formato = "";
                    fact.PrecioUnit = Convert.ToDouble(txtPrecioUniFijo.Text);
                    fact.Barniz = "";
                    fact.Costo = "Fijo";
                    fact.Total = txtTotalFijo.Text.Replace(".", string.Empty);
                    fact.Usuario = lblUsuario.Text;
                    Controller_Factura controlFac = new Controller_Factura();

                    if (controlFac.UpdateDetFactura(fact))
                    {
                        CargarGrilla(fact.NFactura, fact.Usuario);
                        ClearForm();
                        btnAgregarFijo.Visible = true;
                        btnModifiFijo.Visible = false;
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'>Validador('Fijo');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch (Exception excep)
            {
                string popupScript = "<script language='JavaScript'>alert('A Ocurrido el Siguente Error <br/>"+excep.Message+"');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
        //Modificado el 22/10/2014
        protected void btnModificarvari_Click(object sender, EventArgs e)
        {
            try
            {
                if (validador(2))
                {
                    Factura fact = new Factura();
                    fact.ID_Factura = Convert.ToInt32(Request.QueryString["modi"]);
                    fact.NFactura = Convert.ToInt32(Request.QueryString["id"]);
                    fact.OT = txtOTVari.Text;
                    fact.Proceso = ddlExterno.SelectedItem.ToString();
                    fact.Cantidad = Convert.ToInt32(txtCantidadVari.Text.Replace(".", string.Empty));
                    fact.Observacion = txtObservVari.Text;
                    fact.Tipo = ddlTipo.SelectedItem.ToString();
                    fact.Formato = txtAncho.Text + " x " + txtLargo.Text;
                    fact.PrecioUnit = Convert.ToDouble(txtPreUnitVari.Text);
                    fact.Barniz = ddlBarniz.SelectedItem.ToString();
                    fact.Usuario = lblUsuario.Text;
                    fact.M2 = txtM2.Text;
                    fact.Costo = "Variable";
                    fact.Cant = txtCantidadM2.Text.Replace(".", string.Empty);
                    fact.Total = txtTotalVari.Text.Replace(".", string.Empty);
                    Controller_Factura controlFac = new Controller_Factura();

                    if (controlFac.UpdateDetFactura(fact))
                    {
                        CargarGrilla(fact.NFactura, fact.Usuario);
                        btnagregarvari.Visible = true;
                        btnModificarvari.Visible = false;
                        ClearForm();
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'>Validador('Variable');</script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch (Exception excep)
            {
                string popupScript = "<script language='JavaScript'>alert('A Ocurrido el Siguente Error <br/>" + excep.Message + "');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        [WebMethod]
        public static string DeleteItem(string ID_DetFactura)
        {
            Controller_Factura controlFac = new Controller_Factura();
            if (controlFac.DeleteDetFactura(ID_DetFactura))
            {
                return "OK";
            }
            else
            {
                return "Error";
            }
        }

        public bool validador(int Tipo)
        {
            Boolean respuesta = true;
            if (Tipo == 1)
            {
                if (txtOTFijo.Text.Trim() == "")
                {
                    respuesta = false;
                }
                if (ddlProceso.SelectedItem.Text == "Seleccionar")
                {
                    respuesta = false;
                }
                if (txtCantidadFijo.Text.Trim() == "")
                {
                    respuesta = false;
                }
                if (txtPrecioUniFijo.Text.Trim() == "")
                {
                    respuesta = false;
                }
                if (txtTotalFijo.Text.Trim() == "")
                {
                    respuesta = false;
                }
            }
            else if (Tipo == 2)
            {
                if (txtOTVari.Text == "")
                {
                    respuesta = false;
                }
                if (ddlExterno.SelectedItem.Text == "Seleccionar")
                {
                    respuesta = false;
                }
                if (txtCantidadVari.Text == "")
                {
                    respuesta = false;
                }
                if (ddlTipo.SelectedItem.Text == "Seleccionar")
                {
                    respuesta = false;
                }
                if (txtAncho.Text == "")
                {
                    respuesta = false;
                }
                if (txtLargo.Text == "")
                {
                    respuesta = false;
                }
                if (txtPreUnitVari.Text == "")
                {
                    respuesta = false;
                }
                if (ddlBarniz.SelectedItem.Text == "Seleccionar")
                {
                    respuesta = false;
                }
                if (txtTotalVari.Text.Trim() == "")
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}