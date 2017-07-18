using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using Telerik.Web.UI;

namespace Intranet.ModuloProduccion.View
{
    public partial class Prod_Agregar_Fecha : System.Web.UI.Page
    {
        List<Intranet.ModuloProduccion.Model.Produccion> lista = new List<Intranet.ModuloProduccion.Model.Produccion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string OT = Request.QueryString["cd"];
                CargarGrilla(OT);
                CargarDatosFecha(OT);
            }
        }

        public void CargarGrilla(string OT)
        {
            ProduccionController proControl = new ProduccionController();
            lista = proControl.listarFechaProdAgregar(OT);
            RadGrid1.DataSource = lista;
            RadGrid1.DataBind();
        }

        public void CargarDatosFecha(string OT)
        {
            OrdenController controlorden = new OrdenController();
            Orden orden = controlorden.BuscarPorOT(OT);
            lblOT.Text = orden.NumeroOT;
            lblNomOT.Text = orden.NombreOT;
            lblCliente.Text = orden.NombreCliente;
            int numero = Convert.ToInt32(orden.Ejemplares);
            lblTiraje.Text = numero.ToString("N0");
            if (lista.Count > 0)
            {
                int pendiente = Convert.ToInt32(orden.Ejemplares);
                foreach (Intranet.ModuloProduccion.Model.Produccion pro in lista)
                {
                    pendiente = pendiente - Convert.ToInt32(pro.TirajeProd);
                }
                txtCantidad.Text = pendiente.ToString();
            }
            else
            {
                txtCantidad.Text = orden.Ejemplares;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string validador = Validador();
            if (validador == "")
            {
                Intranet.ModuloProduccion.Model.Produccion pro = new Intranet.ModuloProduccion.Model.Produccion();
                pro.NumeroOT = lblOT.Text;
                pro.NombreOT = lblNomOT.Text;
                pro.ClienteOT = lblCliente.Text;
                pro.Ejemplares = txtCantidad.Text;
                pro.observacion = txtObservacion.Text;
                int Hora = Convert.ToInt32(ddlHora.SelectedValue.ToString());
                string f = txtFecha.Text;

                string[] str = f.Split('/');
                string dia = str[0];
                string mes = str[1];
                string año = str[2];
                DateTime Fehora;
                if (Hora == 24)
                {
                    Fehora = Convert.ToDateTime(mes + "/" + dia + "/" + año + " 23:59:59");
                }
                else
                {
                    Fehora = Convert.ToDateTime(mes + "/" + dia + "/" + año + " " + Hora + ":00:00");
                }
                string usuario = Session["Usuario"].ToString();
                ProduccionController controlpro = new ProduccionController();
                string idProduccion = controlpro.InsertarFecha(pro, usuario, Fehora);
                if (idProduccion == "ok")
                {
                    Session["Correo"] = "EnviodeCorreo";
                    LimpiarForm();
                }
                else
                {
                    string popupScript = "<script language='JavaScript'>alert('" + idProduccion + " Ha ocurrido un error al ingresar, vuelva a intentarlo '); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
                CargarGrilla(lblOT.Text);
                CargarDatosFecha(lblOT.Text);
            }
            else
            {
                string popupScript = "<script language='JavaScript'>alert('" + validador + ", vuelva a intentarlo '); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void contactsGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "CustomEdit")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int idProduccion = Convert.ToInt32(item["IDProduccion"].Text);
                string ot = item["NumeroOT"].Text;
                ProduccionController proControl = new ProduccionController();
                if (proControl.EliminarFe(idProduccion))
                {
                    Session["Correo"] = "EliminarDatos";
                    LimpiarForm();
                }
                CargarGrilla(ot);
                CargarDatosFecha(ot);
            }
        }

        public void LimpiarForm()
        {
            txtFecha.Text = String.Empty;
            txtObservacion.Text = String.Empty;
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Correo"].ToString() == "EnviodeCorreo")
                {
                    ProduccionController controlpro = new ProduccionController();
                    if (controlpro.EnviarCorreo(lblOT.Text, Session["Usuario"].ToString()))
                    {
                        string popupScript = "<script language='JavaScript'>window.opener.location.reload();window.close(); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                    else
                    {
                        string popupScript = "<script language='JavaScript'>alert(' Ha ocurrido un error al ingresar, vuelva a intentarlo '); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript);
                    }
                }
                else
                {
                    string popupScript = "<script language='JavaScript'>window.opener.location.reload();window.close(); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
            catch (Exception a)
            {
                if (a.Message == "Referencia a objeto no establecida como instancia de un objeto.")
                {
                    string popupScript = "<script language='JavaScript'>window.opener.location.reload();window.close(); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'>window.opener.location.reload();window.close();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        public string Validador()
        {
            string Error = "";
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                if (Convert.ToInt32(txtCantidad.Text) <= 0)
                {
                    Error = "* Se debe Ingresar un valor Mayor a 0";
                }
            }
            if (string.IsNullOrEmpty(txtFecha.Text.Trim()))
            {
                Error = Error + " *Fecha Entrega No puede ser Nula";
            }

            return Error;
        }
    }
}