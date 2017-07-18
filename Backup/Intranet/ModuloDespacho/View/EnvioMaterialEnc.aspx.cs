using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloDespacho.Model;
using Intranet.ModuloDespacho.Controller;
using System.Drawing;

namespace Intranet.ModuloDespacho.View
{
    public partial class EnvioMaterialEnc : System.Web.UI.Page
    {
        bool respuesta = false;
        string folio = "";
        Controller_OTComercial cot = new Controller_OTComercial();
        protected void Page_Load(object sender, EventArgs e)
        {
            OTComercial oc = cot.Cargar_OT("", txtOT.Text, "", 0, 0, 0, "", "", "", 0);
            lblNombreOT.Text = oc.NombreOT;
            lblTirajeOT.Text = oc.TirajeOT;
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lblNombreOT.Text != "" && lblTirajeOT.Text != "" && txtOT.Text != "" && txtDescripcion.Text != "" && txtCantidadAEnviar.Text != "" && txtPeso.Text != "")
            {
                string f = cot.buscarFolio("", "", "", 0, 0, 0, "", "", "", 2);
                int n = Convert.ToInt32(f.Replace("DE-", "")) + 1;
                string v = "";
                if (n.ToString().Length == 1)
                {
                    v = "DE-00000" + n.ToString();
                }
                else if (n.ToString().Length == 2)
                {
                    v = "DE-0000" + n.ToString();
                }
                else if (n.ToString().Length == 3)
                {
                    v = "DE-000" + n.ToString();
                }
                else if (n.ToString().Length == 4)
                {
                    v = "DE-00" + n.ToString();
                }
                else if (n.ToString().Length == 5)
                {
                    v = "DE-0" + n.ToString();
                }
                folio = v;


                respuesta = cot.insertOTComercial(folio, txtOT.Text.ToUpper(), lblNombreOT.Text, Convert.ToInt32(lblTirajeOT.Text), Convert.ToInt32(txtCantidadAEnviar.Text), Convert.ToInt32(txtPeso.Text), txtDescripcion.Text.ToUpperInvariant(), Session["Usuario"].ToString(), "", 1);
                if (respuesta == true)
                {
                    lblMensaje.Text = "Registro Ingresado Correctamente. Imprima el documento.";
                    btnImprimir.Visible = true;
                    btnGuardar.Visible = false;
                    divMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                  
                    lblMensaje.ForeColor = Color.White;
                    lblMensaje.Attributes.Add("style", "background-color:Green");

                    btnImprimir.Attributes.Add("onclick", "window.open('DetalleOTComercial.aspx?Cod=" + folio + "','Procesar Documento','toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=730,height=650,left=340,top=200')");
                    
                }
                else
                {
                    divMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";

                    lblMensaje.ForeColor = Color.White;
                    lblMensaje.Attributes.Add("style", "background-color:Red");



                    lblMensaje.Text = "Ha ocurrido un error, vuelva a intentarlo.";
                    btnImprimir.Visible = false;
                    btnGuardar.Visible = true;
                }
            }
            else
            {
                divMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";

                lblMensaje.ForeColor = Color.White;
                lblMensaje.Attributes.Add("style", "background-color:Red");
                lblMensaje.Text = "Debe ingresar todos los campos.";
                btnImprimir.Visible = false;
                btnGuardar.Visible = true;
            }
        }
    }
}