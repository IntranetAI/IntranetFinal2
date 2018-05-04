using Intranet.ModuloEtiquetasMetricsWIP.Controller;
using Intranet.ModuloEtiquetasMetricsWIP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloEtiquetasMetricsWIP.View
{
    public partial class _Etiqueta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string eti = Request.QueryString["id"];
                EtiquetasController ec = new EtiquetasController();
                Etiquetas et = ec.Carga_Etiqueta(eti, 1);
                lblOT.Text = et.OT;
                lblNombreOT.Text = et.NombreOT;
                lblFechaCreacion.Text = et.FechaCreacion;
                lblTiraje.Text = et.Tiraje2;
                lblCliente.Text = et.Cliente;
                lblElemento.Text = et.Elemento;
                lblPliego.Text = et.Pliego;
                lblActividad.Text = et.Actividad;
                lblProxActividad.Text = et.ProximaActividad;
                lblObs.Text = et.Observacion;
                lblMaquina.Text = et.Maquina;
                lblOperador.Text = et.Operador;
                lblPeso.Text = et.Peso;
                lblCantidad.Text = et.Cantidad;
                lblFechaImpresion.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                lblIdPallet.Text = eti.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Barcode", "Barcode(" + eti + ");", true);

                //string script = @"<script type='text/javascript'>Barcode(" + eti + "); </script>";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
            }
        }
    }
}