using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Controller;
using Telerik.Web.UI;
using Intranet.ModuloRFrecuencia.Model;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Pliego_Bobina_Cons : System.Web.UI.Page
    {
        OrdProduccion_Controller controlOTP = new OrdProduccion_Controller();
        Bobina_Controller controlBo = new Bobina_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["OT"].ToString() != "" && Request.QueryString["Pliego"].ToString() != "&nbsp;")
                    {
                        string pliego =Request.QueryString["Pliego"].ToString();
                        if (pliego == "")
                        {
                            pliego = "&nbsp;";
                        }
                        CargarBobConsumir(Request.QueryString["OT"].ToString(), pliego);
                        OrdenProduccion OrdenP = controlOTP.ListOrPro(txtOT.Text);
                        lblNombreOT.Text = OrdenP.Nombre_OT;
                    }
                }
                catch
                {
                    Cargar();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        public void Cargar()
        {
            string Maquina = controlBo.BuscarMaquinaUser(GetDireccionIp(Request));
            if (txtOT.Text.Trim() != "")
            {
                RadGrid2.DataSource = controlOTP.listaOrPliegos(txtOT.Text.Trim(), Maquina);
                OrdenProduccion OrdenP = controlOTP.ListOrPro(txtOT.Text);
                lblNombreOT.Text = OrdenP.Nombre_OT;
            }
            else
            {
                RadGrid2.DataSource = "";
            }
            RadGrid2.DataBind();
            divDatos.Visible = false;
            divPliego.Visible = false;
            divOT.Visible = true;
        }

        public static string GetDireccionIp(System.Web.HttpRequest request)
        {
            // Recuperamos la IP de la máquina del cliente
            // Primero comprobamos si se accede desde un proxy
            string ipAddress1 = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            // Acceso desde una máquina particular
            string ipAddress2 = request.ServerVariables["REMOTE_ADDR"];

            string ipAddress = string.IsNullOrEmpty(ipAddress1) ? ipAddress2 : ipAddress1;

            // Devolvemos la ip
            return ipAddress;
        }

        public void CargarBobinas()
        {
            string Pliego = lblNombrePliego.Text;
            string Maquina = controlBo.BuscarMaquinaUser(GetDireccionIp(Request));
            if (lblNombrePliego.Text == "" && Maquina == "Dimensionadora")
            {
                Pliego = "&nbsp;";
            }
            RadGrid4.DataSource = controlBo.listarBobinaPend(txtOT.Text, Pliego, 1);
            RadGrid5.DataSource = controlBo.listarBobinaPend(txtOT.Text, Pliego, 2);
            RadGrid4.DataBind();
            RadGrid5.DataBind();
        }

        public void CargarBobConsumir(string Ot, string pliego)
        {
            divDatos.Visible = true;
            divPliego.Visible = true;
            divOT.Visible = false;
            txtOT.Text = Ot;
            lblNombrePliego.Text = pliego;
            string Maquina = controlBo.BuscarMaquinaUser(GetDireccionIp(Request));
            RadGrid4.DataSource = controlBo.listarBobinaPend(txtOT.Text, pliego, 1);
            RadGrid5.DataSource = controlBo.listarBobinaPend(txtOT.Text, pliego, 2);
            RadGrid4.DataBind();
            RadGrid5.DataBind();
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "RowClick")
            {
                GridDataItem item = (GridDataItem)e.Item;
                lblNombrePliego.Text = item["Papel_Solicitud"].Text.Trim();
                if (lblNombrePliego.Text == " ")
                {
                    lblNombrePliego.Text = "&nbsp;";
                }
                lblTirajePliego.Text = item["TirajePliego"].Text.Replace(",",".");
                divDatos.Visible = true;
                divPliego.Visible = true;
                divOT.Visible = false;
                CargarBobinas();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Cargar();
        }

        protected void RadGrid4_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "RowClick")
            {
                GridDataItem item = (GridDataItem)e.Item;
                //string OP = item["NumeroOp"].Text;
                //int Codigo = Convert.ToInt32(item["ID_Bobina"].Text);
                //Response.Redirect("Bobina_Agregar.aspx?OT=" + OP + "&Codigo=" + Codigo + "");
                string popupScript = "<script language='JavaScript'> onload(window.open('Consumo_Bobina.aspx?OT=" + txtOT.Text + "&pliego=" + lblNombrePliego.Text + "&code=" + item["ID_Bobina"].Text + "','Consumo Bobina', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=500,left=340,top=200'));</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }
    }
}