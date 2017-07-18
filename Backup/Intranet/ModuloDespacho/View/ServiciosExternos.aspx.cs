using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;

namespace Intranet.ModuloDespacho.View
{
    public partial class ServiciosExternos : System.Web.UI.Page
    {
        Controller_Factura sv = new Controller_Factura();
        DateTime f = Convert.ToDateTime("1900-01-01");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid4.DataSource = "";
                RadGrid4.DataBind();
            }
            try
            {
                if (Session["IDf"].ToString() != "0")
                {
                    RadGrid4.DataSource = sv.Listar_DetalleFactura(Session["IDf"].ToString(), "", "", "", "", "", "",f, 5);
                    RadGrid4.DataBind();

                    Factura ff = sv.CargaEncabezado(Session["IDf"].ToString(), "", "", "", "", "", "",f, 6);

                    txtRut.Text = ff.Rut;
                    txtProveedor.Text = ff.Nombre;
                    lblDireccion.Text = ff.Sucursal;
                    lblComuna.Text = ff.Comuna;
                    lblCiudad.Text = ff.Ciudad;
                    txtFecha.Text = ff.OT;
                    txtNroFactura.Text = ff.NFactura.ToString();
                    btnFiltro.Visible = false;
                    btnNuevo.Visible = true;

                    btnDet.Visible = false;

                    int total = 0;
                    for (int i = 0; i < RadGrid4.Items.Count; i++)
                    {

                        total = total + Convert.ToInt32(RadGrid4.Items[i]["Total"].Text.Replace(".", ""));
                    }
                    lblValorNeto.Text = "$ " + total.ToString("N0").Replace(",", ".");
                    double iva = Convert.ToDouble(total) * 0.19;
                    lblIVA.Text = "$ " + Convert.ToInt32(iva).ToString("N0").Replace(",", ".");

                    lblCostoTotal.Text = "$ " + (total + Convert.ToInt32(iva)).ToString("N0").Replace(",", ".");
                    Session["IDf"] = "0";                    
                }
            }
            catch
            {
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {

            if (txtProveedor.Text != "")
            {
                Factura s = sv.BuscarProveedor("", txtProveedor.Text,"","","","", "",f,1);

                txtRut.Text = s.Rut;
                lblDireccion.Text = s.Sucursal;
                lblComuna.Text = s.Comuna;
                lblCiudad.Text = s.Ciudad;

            }
        }
        protected void txtRut_TextChanged(object sender, EventArgs e)
        {
            Factura s = sv.BuscarProveedor(txtRut.Text, "", "", "", "", "", "", f, 0);

            txtProveedor.Text = s.Nombre;
            lblDireccion.Text = s.Sucursal;
            lblComuna.Text = s.Comuna;
            lblCiudad.Text = s.Ciudad;
        }

        protected void txtNroFactura_TextChanged(object sender, EventArgs e)
        {
           sv.EliminarRegistrosPendientes("", "", "", "", "", "", Session["Usuario"].ToString(),f, 7);
            bool r = sv.ValidacionFactura(txtRut.Text.Trim(), "", "", "", "", txtNroFactura.Text.Trim(),"",f, 2);
            if (r == true)
            {
                //ingresar
                lblValidacionFactura.Text = "";
                btnDet.Visible = true;
                
              
            }
            else
            {
                lblValidacionFactura.Text = "* El Número de factura ya ha sido ingresado";
                btnDet.Visible = true;

                cargaContenido(txtRut.Text, txtNroFactura.Text);

                //modificar aqui

            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            int v = 0;
            if (txtRut.Text != "" && txtProveedor.Text != "" && txtNroFactura.Text != "")
            {
                bool r = sv.ValidacionFactura(txtRut.Text, "", "", "", "", txtNroFactura.Text, "",f, 2);
                if (r == true)
                {
                    string fechaI = txtFecha.Text;
                    string[] str = fechaI.Split('/');
                    string dia = str[0];
                    string mes = str[1];
                    string año = str[2];
                    año = año.Substring(0, 4);
                    string fechaInicio = mes + "/" + dia + "/" + año;

                    DateTime fechafac = Convert.ToDateTime(fechaInicio);
                    v = sv.IngresoFactura(txtRut.Text, txtProveedor.Text, lblDireccion.Text, lblComuna.Text, lblCiudad.Text, txtNroFactura.Text, Session["Usuario"].ToString(), fechafac, 3);
                    if (v != 0)
                    {
                        Session["IDf"] = v;
                        string popupScript = "<script language='JavaScript'>openGame(\"" + v + "\") </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    else
                    {
                      
                    }
                }
                else
                {
                    int idd = sv.BuscaID(txtRut.Text, "", "", "", "", txtNroFactura.Text, "", f, 10);
                    Session["IDf"] = idd;
                    string popupScript = "<script language='JavaScript'>openGame(\"" + idd + "\") </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiciosExternos.aspx?id=8&Cat=6");
        }

        public void cargaContenido(string rut,string nrFactura)
        {
            RadGrid4.DataSource = sv.Listar_DetalleFactura(rut, "", "", "", "", nrFactura, "",f, 8);
            RadGrid4.DataBind();

            Factura ff = sv.CargaEncabezado(rut, "", "", "", "", nrFactura, "",f, 9);

            txtRut.Text = ff.Rut;
            txtProveedor.Text = ff.Nombre;
            lblDireccion.Text = ff.Sucursal;
            lblComuna.Text = ff.Comuna;
            lblCiudad.Text = ff.Ciudad;
            txtNroFactura.Text = ff.NFactura.ToString();

            btnFiltro.Visible = false;
            btnNuevo.Visible = true;


            int total = 0;
            for (int i = 0; i < RadGrid4.Items.Count; i++)
            {
                total = total + Convert.ToInt32(RadGrid4.Items[i]["Total"].Text.Replace(".", ""));
            }
            lblValorNeto.Text = "$ " + total.ToString("N0").Replace(",", ".");
            double iva = Convert.ToDouble(total) * 0.19;
            lblIVA.Text = "$ " + Convert.ToInt32(iva).ToString("N0").Replace(",", ".");

            lblCostoTotal.Text = "$ " + (total + Convert.ToInt32(iva)).ToString("N0").Replace(",", ".");
            //Session["IDf"] = "0";    
        }
    }
}