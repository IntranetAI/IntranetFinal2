using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using System.Web.Services;

namespace Intranet.ModuloProduccion.View
{
    public partial class ingresoCSR : System.Web.UI.Page
    {
        bool respuesta;
        string color;
        DateTime fechaAntigua;
        ProduccionController control = new ProduccionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosFecha();
            }
        }
        public void CargarDatosFecha()
        {
            if (Session["variable"].ToString() == "1")
            {
                string OT = Session["nOT"].ToString();
                OrdenController controlorden = new OrdenController();
                Orden orden = controlorden.BuscarPorOT(OT);
                lblOT.Text = orden.NumeroOT;
                lblNomOT.Text = orden.NombreOT;
                lblCliente.Text = orden.NombreCliente;
                int numero = Convert.ToInt32(orden.Ejemplares);
                lblTiraje.Text = numero.ToString("N0");

                if (Session["FechaSolicitada"].ToString() != "&nbsp;")
                {
                    //fechaAntigua = Convert.ToDateTime(Session["fechaSolicitada"].ToString());
                    txtFecha.Text = Session["FechaSolicitada"].ToString();
                }
            }
            if (Session["variable"].ToString() == "2")
            {
                string OT = Session["nOT"].ToString();
                OrdenController controlorden = new OrdenController();
                Orden orden = controlorden.BuscarPorOT(OT);
                lblOT.Text = orden.NumeroOT;
                lblNomOT.Text = orden.NombreOT;
                lblCliente.Text = orden.NombreCliente;
                int numero = Convert.ToInt32(orden.Ejemplares);
                lblTiraje.Text = numero.ToString("N0");
                if (Session["observacion"].ToString() != "&nbsp;")
                {
                    txtObservacion.Text = Session["observacion"].ToString();
                }
                string f = Session["FechaSolicitada"].ToString();

                string[] str = f.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                año = año.Substring(0, 4);
                txtFecha.Text = dia+"/"+mes+"/"+año;
                bntAgregar.Visible = false;
                btnModificar.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string fecs = fechaAntigua.ToString();
            if (txtFecha.Text != "")
            {


                if (Session["FechaSolicitada"].ToString() == txtFecha.Text)
                {
                    color = "BLACK";
                }
                else
                {
                    color = "GREEN";
                }
                string f = txtFecha.Text;

                string[] str = f.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];

                respuesta = control.ingresarCSR(lblOT.Text, txtObservacion.Text, Convert.ToDateTime(mes+"/"+dia+"/"+año), color);
                if (respuesta != false)
                {
                    //string popupScript = "<script language='JavaScript'>alert('  Fecha CSR ingresada Correctamente ');location.href='csr.aspx?id=1' </script>";
                    //Page.RegisterStartupScript("PopupScript", popupScript);
                    Response.Redirect("csr.aspx?id=1");
                }
                else
                {
                    string popupScript = "<script language='JavaScript'>alert(' Error al ingresar '); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }

            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtFecha.Text != "")
            {
                string f = txtFecha.Text;

                string[] str = f.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                respuesta = control.ModificarCSR(lblOT.Text, txtObservacion.Text, Convert.ToDateTime(mes+"/"+dia+"/"+año));

                if (respuesta != false)
                {
                    Response.Redirect("csr.aspx?id=1");
                    //string popupScript = "<script language='JavaScript'>alert('  Fecha CSR Modificada Correctamente ');location.href='csr.aspx' </script>";
                    //Page.RegisterStartupScript("PopupScript", popupScript);
                }
                else
                {
                    string popupScript = "<script language='JavaScript'>alert('  Ha ocurrido un error ');location.href='csr.aspx' </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("csr.aspx?id=1");
        }


    }
}