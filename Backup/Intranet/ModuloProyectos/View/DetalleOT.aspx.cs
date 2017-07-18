using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloUsuario.Controller;
using Intranet.ModuloDespacho.Model;
using System.Drawing;
using Intranet.ModuloProyectos.Controller;

namespace Intranet.ModuloProyectos.View
{
    public partial class DetalleOT : System.Web.UI.Page
    {
        Controller_EstadoOT eo = new Controller_EstadoOT();
        OrdenController controlOT = new OrdenController();
        ProduccionController controlpro = new ProduccionController();
        DespachoController controldes = new DespachoController();
        Mail_Controller controlm = new Mail_Controller();
        Controller_Proyectos cp = new Controller_Proyectos();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                btnCerrar.Attributes.Add("onclick", "window.close();");

                //string OT = Request.QueryString["ot"];
                lblnombreot.Text = "OT: " + Request.QueryString["ot"] + " - " + Request.QueryString["not"];

                lblMensajeria.Text = controlm.listarMensajes(Request.QueryString["ot"], Session["Usuario"].ToString(), 1);
                RadGrid4.DataSource = controldes.ListarProduccionOT_tablaTemporal_Detalle(Request.QueryString["ot"]);
                RadGrid4.DataBind();

                RadGrid5.DataSource = controldes.ListarDespacho(Request.QueryString["ot"]);
                RadGrid5.DataBind();

                CargaRegistros(Request.QueryString["ot"]);

                lblTablaHistorial.Text = cp.Carga_HistorialOT(Request.QueryString["ot"]);

                ProduccionController pc = new ProduccionController();
                RadGrid22.DataSource = pc.Lista_Pliegos_Impresos(Request.QueryString["ot"]).OrderBy(o => o.Pliego);
                RadGrid22.DataBind();
            }
            catch
            {
            }
        }

        public void CargaRegistros( string OT)
        {

            tblRegistro.Visible = true;

            Estado_OT et = eo.BuscarOTLiquidar(OT, 1);
       
            //lblNombreOT.Text = et.NombreOT;
            lblCliente.Text = et.Cliente;
            int ti = Convert.ToInt32(et.TirajeTotal);
            lblTirajeOT.Text = ti.ToString("N0").Replace(",", ".");
            string e = et.Estado;
            if (et.Estado == "1")
            {
                lblEstadoActual.ForeColor = Color.Blue;
                lblEstadoActual.Text = "En Proceso.";
            }
            else if (et.Estado == "A")
            {
                lblEstadoActual.ForeColor = Color.Blue;
                lblEstadoActual.Text = "En Proceso.";
            }
            else if (et.Estado == "E")
            {
                lblEstadoActual.ForeColor = Color.Red;
                lblEstadoActual.Text = "Liquidada.";
            }
            else if (et.Estado == "L")
            {
                lblEstadoActual.ForeColor = Color.Blue;
                lblEstadoActual.Text = "En Proceso.";
            }
            else
            {
                lblEstadoActual.ForeColor = Color.Red;
                lblEstadoActual.Text = "Liquidada.";
            }

            if (et.FechaMaxima != "")
            {
                DateTime fc = Convert.ToDateTime(et.FechaMaxima);
                lblFechaLiquidacion.Text = fc.ToString("dd/MM/yyyy HH:mm:ss");
            }
            else
            {
                lblFechaLiquidacion.Text = "Sin Fecha de Liquidacion";
            }

            //datos adicionales
            int devolucion = Convert.ToInt32(et.Devolucion);
            DateTime fmin = Convert.ToDateTime(et.OT);
            DateTime fmax = Convert.ToDateTime(et.Saldo);
            int totalDesp = Convert.ToInt32(et.TotalDespachado);

            lblDespachado.Text = totalDesp.ToString("N0").Replace(",", ".");
            lblPrimerDesp.Text = fmin.ToString("dd/MM/yyyy HH:mm:ss");
            lblUltDesp.Text = fmax.ToString("dd/MM/yyyy HH:mm:ss");
            lblDevolucion.Text = devolucion.ToString("N0").Replace(",", ".");

            int saldo = (ti - (totalDesp - devolucion));
            if (saldo <= 0)
            {
                lblFaltante.Text = "0";
            }
            else
            {
                lblFaltante.Text = saldo.ToString("N0").Replace(",", ".");

            }

        
        }
        protected void ibCrearMensaje_Click(object sender, ImageClickEventArgs e)
        {
            Session["Usu"] = Session["Usuario"].ToString();
            Session["OT"] = Label2.Text;

            Response.Redirect("../../ModuloUsuario/View/redactarMensaje.aspx?var=1");
        }

        protected void ibAsc_Click(object sender, ImageClickEventArgs e)
        {
            Mail_Controller controlm = new Mail_Controller();
            lblMensajeria.Text = "";
            lblMensajeria.Text = controlm.listarMensajes(Label2.Text, Session["Usuario"].ToString(), 1);//forma asc

            if (lblMensajeria.Text == "")
            {
              
            }
            else
            {
                //22
            }
        }
        protected void ibDesc_Click(object sender, ImageClickEventArgs e)
        {
            Mail_Controller controlm = new Mail_Controller();
            lblMensajeria.Text = "";
            lblMensajeria.Text = controlm.listarMensajes(Label2.Text, Session["Usuario"].ToString(), 2);//forma asc

            if (lblMensajeria.Text == "")
            {
               
            }
            else
            {
                //22
            }
        }
    }
}