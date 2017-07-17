using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Controller;
using Intranet.ModuloRFrecuencia.Model;
using System.Data.SqlClient;
using System.Data;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Registro_Mod : System.Web.UI.Page
    {
        Bobina_Controller bobControl = new Bobina_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string OT = Request.QueryString["OT"];
                string Pliego = Request.QueryString["pl"];
                string Codigo_Bob = Request.QueryString["not"];
                Label2.Text = OT + " :- ";
                txtOT.Text = OT;
                Label1.Text = Pliego;
                Bobina bob = bobControl.BuscarBobinaCerrar(Convert.ToInt32(Codigo_Bob));
                //CargarTipo(bob.Proveedor);
                CargarDatos(bob);
                TabContainer2.TabIndex = 0;
                TabContainer2.Tabs[1].Enabled = false;
            }
        }

        //public void CargarTipo(string Proveedor)
        //{
        //    if (Proveedor == "Sin Confirmar")
        //    {
        //        TabContainer2.TabIndex = 1;
        //        TabContainer2.Tabs[0].Enabled = false;
        //    }
        //    else 
        //    {
        //        TabContainer2.TabIndex = 0;
        //        TabContainer2.Tabs[1].Enabled = false;
        //    }
        //}

        public void CargarDatos(Bobina bob)
        {
            lblBobina.Text = bob.Codigo.ToString();
            try
            {
                ddlMaquina.Items.FindByValue(bob.Ubicacion.ToString().ToUpper()).Selected = true;
            }
            catch
            {
                ddlMaquina.Items.FindByValue(bob.Ubicacion.ToString()).Selected = true;
            }
            OrdProduccion_Controller controlOrdPro = new OrdProduccion_Controller();
            ddlPliego.DataSource = controlOrdPro.listaOrPliegos(txtOT.Text.Trim(), ddlMaquina.SelectedItem.Text);
            ddlPliego.DataTextField = "Papel_Solicitud";
            ddlPliego.DataValueField = "Papel_Solicitud";
            ddlPliego.DataBind();
            ddlPliego.Items.Insert(0, new ListItem("Sin Pliego", "Sin Pliego"));
            try
            {
                ddlPliego.Items.FindByValue(bob.pliego.ToString()).Selected = true;
            }
            catch {
                ddlPliego.Items.FindByValue("Sin Pliego").Selected = true;
            }
            txtPesoBruto.Text = bob.Peso_Original.ToString();
            txtPesoTapa.Text = bob.Peso_Tapa.ToString();
            txtPesoEmb.Text = bob.Peso_emboltorio.ToString();
            txtPesoEsc.Text = bob.PesoEscarpe.ToString();
            txtPesoCono.Text = bob.Peso_Cono.ToString();
            txtSaldo.Text = bob.Saldo.ToString();
            string[] Usuario = bob.Cono.ToString().Split(' ');
            lblUser.Text = Usuario[0] + " " + Usuario[2];
        }

        //metodo Autocompletar El Tipo de Bobina
        //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        //public static string[] GetCompletionList(string prefixText)
        //{
        //    //  
        //    // return (from m in nombres where m.StartsWith(prefixText,StringComparison.CurrentCultureIgnoreCase) select m).Take(count).ToArray();
        //    Conexion con = new Conexion();
        //    SqlCommand cmd = con.AbrirConexionIntranet();
        //    cmd.CommandText = "select Distinct Tipo  from Papel_P2B where isnull(Tipo,'????') != '????' and Tipo <> ('Sin Confirmar') and Tipo like  @prefixText";

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    string[] items = new string[dt.Rows.Count];
        //    int i = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        items.SetValue(dr["Tipo"].ToString(), i);
        //        i++;
        //    }
        //    return items;
        //}

        ////metodo Autocompletar El Marca de Bobina
        //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        //public static string[] GetCompletionList1(string prefixText)
        //{
        //    //  
        //    // return (from m in nombres where m.StartsWith(prefixText,StringComparison.CurrentCultureIgnoreCase) select m).Take(count).ToArray();
        //    Conexion con = new Conexion();
        //    SqlCommand cmd = con.AbrirConexionIntranet();
        //    cmd.CommandText = "select Distinct top 15 Marca  from Papel_P2B where isnull(Tipo,'????') != '????' and Tipo <> ('Sin Confirmar') and Marca like  @prefixText";

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    string[] items = new string[dt.Rows.Count];
        //    int i = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        items.SetValue(dr["Marca"].ToString(), i);
        //        i++;
        //    }
        //    return items;
        //}

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    if ((txtMarca.Text.Trim() != "") && (txtTipo.Text.Trim() != "") && (ddlProveedor.SelectedItem.Text != "Seleccionar"))
        //    {
        //        Bobina bob = new Bobina();
        //        bob.Codigo = lblBobina.Text;
        //        bob.Proveedor = ddlProveedor.SelectedItem.Text.Trim();
        //        bob.Marca = txtMarca.Text.Trim();
        //        bob.Tipo = txtTipo.Text.Trim();
        //        bob.Ubicacion = txtUbicacion.Text.Trim().ToUpper();
        //        bob.Lote = txtLote.Text.Trim();
        //        if (bobControl.ActualizarTipPap(bob, 0))
        //        {
        //            TabContainer2.Tabs[1].Enabled = false;
        //            TabContainer2.Tabs[0].Enabled = true;
        //            TabContainer2.TabIndex = 1;
        //            string popupScript = "<script language='JavaScript'>window.opener.location.reload();window.close(); </script>";
        //            Page.RegisterStartupScript("PopupScript", popupScript);
        //        }
        //        else
        //        {
        //            TabContainer2.Tabs[1].Enabled = true;
        //            TabContainer2.Tabs[0].Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        TabContainer2.Tabs[1].Enabled = true;
        //        TabContainer2.Tabs[0].Enabled = false;
        //    }
        //}

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            string popupScript = "<script language='JavaScript'>window.close(); </script>";
            Page.RegisterStartupScript("PopupScript", popupScript);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Bobina bob = new Bobina();
            bob.ID_Bobina = Convert.ToInt32(Request.QueryString["not"]);
            if (bobControl.ActualizarTipPap(bob,2))
            {
                string popupScript = "<script language='JavaScript'>window.opener.location.reload();window.close(); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Bobina bob = new Bobina();
            bob.ID_Bobina = Convert.ToInt32(Request.QueryString["not"]);
            bob.NumeroOp = txtOT.Text;
            if (ddlMaquina.SelectedItem.ToString() == "Dimensionadora")
            {
                bob.pliego = "&nbsp;";
            }
            else
            {
                bob.pliego = ddlPliego.SelectedItem.Text;
            }
            bob.Peso_Original = Convert.ToInt32(txtPesoBruto.Text);
            bob.Peso_Tapa = Convert.ToDouble(txtPesoTapa.Text);
            bob.Peso_emboltorio = Convert.ToDouble(txtPesoEmb.Text);
            bob.PesoEscarpe = Convert.ToDouble(txtPesoEsc.Text);
            bob.Peso_Cono = Convert.ToDouble(txtPesoCono.Text);
            bob.Saldo = Convert.ToInt32(txtSaldo.Text);
            bob.Ubicacion = ddlMaquina.SelectedItem.Text.Trim();
            if (bobControl.ActualizarTipPap(bob, 1))
            {
                string popupScript = "<script language='JavaScript'>window.opener.location.reload();window.close(); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
                string popupScript = "<script language='JavaScript'>Alert('Error al intentar ingresar'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            OrdProduccion_Controller controlOrdPro = new OrdProduccion_Controller();
            ddlPliego.DataSource = controlOrdPro.listaOrPliegos(txtOT.Text.Trim(), ddlMaquina.SelectedItem.Text);
            ddlPliego.DataTextField = "Papel_Solicitud";
            ddlPliego.DataValueField = "Papel_Solicitud";
            ddlPliego.DataBind();
            ddlPliego.Items.Insert(0, new ListItem("Sin Pliego", "Sin Pliego"));
        }

    }
}