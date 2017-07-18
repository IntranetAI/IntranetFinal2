using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloProduccion.Controller;

namespace Intranet.ModuloProduccion.View
{
    public partial class SolicitudRequerimientosOP : System.Web.UI.Page
    {
        Controller_Requerimientos rr = new Controller_Requerimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string OT = Request.QueryString["OT"];
                Requerimientos r = rr.CargaDatosOT(OT, "", 0);
                lblOT.Text = r.OT;
                lblNombreOT.Text = r.NombreOT;
                lblFechaCreacion.Text = Convert.ToDateTime(r.FechaCreacion).ToString("dd/MM/yyyy");
                lblTiraje.Text = r.Tiraje;
                lblCliente.Text = r.Cliente;
                string rut = r.RutCliente;
                lblFormatoImpresion.Text = r.Ancho;
                lblPaginas.Text = r.Paginas;


                ddlDireccion.DataSource = rr.ListaDireccionesClientes("", rut.Replace(".", "").Replace("-", ""), 1);
                ddlDireccion.DataTextField = "Direccion";
                ddlDireccion.DataValueField = "IDDireccion";
                ddlDireccion.DataBind();
                ddlDireccion.Items.Insert(0, new ListItem("Seleccione...", "Seleccione..."));
                rdDireccionNo.Checked = true;
            }
        }
    }
}