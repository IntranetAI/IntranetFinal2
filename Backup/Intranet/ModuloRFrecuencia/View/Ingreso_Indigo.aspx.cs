using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloProduccion.Controller;
using Intranet.ModuloProduccion.Model;
using Intranet.ModuloRFrecuencia.Model;
using Intranet.ModuloRFrecuencia.Controller;
using System.Data.SqlClient;
using System.Data;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Ingreso_Indigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtInicio.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
            txtTermino.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
            txtPliego_Impresos.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
            txtPliego_Malos.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
            txtAncho.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
            txtLargo.Attributes.Add("onkeypress", "return pulsarTiraje(event);");
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Indigo idg = new Indigo();
            idg.OT = txtOT.Text;
            idg.NombreOT = lblNombreOT.Text;
            idg.Tiraje = Convert.ToInt32(txtTiraje.Text.Replace(".",string.Empty));
            idg.Pliego = txtPliego.Text;
            idg.Maquina = ddlMaquina.SelectedItem.ToString();
            idg.ClickInicio = Convert.ToInt32(txtInicio.Text.Replace(".",string.Empty));
            idg.ClickFinal = Convert.ToInt32(txtTermino.Text.Replace(".", string.Empty));
            idg.CantidadClick = idg.ClickFinal-idg.ClickInicio;
            idg.Papel = txtPapel.Text;
            idg.Buenos = Convert.ToInt32(txtPliego_Impresos.Text.Replace(".",string.Empty));
            idg.Malos = Convert.ToInt32(txtPliego_Malos.Text.Replace(".",string.Empty));
            idg.Color = ddlColor1.SelectedItem.ToString() + "/" + ddlColor2.SelectedItem.ToString();
            idg.Formato = txtAncho.Text + " x " + txtLargo.Text;
            idg.Observacion = txtObservacion.Text;
            idg.Usuario = Session["Usuario"].ToString();
            Indigo_Controller controlHP = new Indigo_Controller();
            if (controlHP.InsertIndigo(idg))
            {
                string popupScript4 = "<script language='JavaScript'>window.opener.location='HPIndigo.aspx?id=13&cat=3';window.close();</script>";
                Page.RegisterStartupScript("PopupScript", popupScript4);
            }
            else
            {
                string popupScript4 = "<script language='JavaScript'>alert('Error al ingreso');</script>";
                Page.RegisterStartupScript("PopupScript", popupScript4);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            string popupScript4 = "<script language='JavaScript'>window.opener.location='HPIndigo.aspx?id=13&cat=3';window.close();</script>";
            Page.RegisterStartupScript("PopupScript", popupScript4);
        }

        protected void txtOT_TextChanged(object sender, EventArgs e)
        {
            OrdenController controlOT = new OrdenController();
            Indigo_Controller controlHP = new Indigo_Controller();
            Orden ot = controlOT.BuscarPorOT(txtOT.Text);
            string Dato = ot.NombreOT;
            if (Dato != null)
            {
                lblNombreOT.Text = Dato;
                txtInicio.Text = controlHP.MaxClick().ToString("N0").Replace(",",".");
                txtTiraje.Focus();
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText)
        {
            //  
            // return (from m in nombres where m.StartsWith(prefixText,StringComparison.CurrentCultureIgnoreCase) select m).Take(count).ToArray();
            Conexion con = new Conexion();
            SqlCommand cmd = con.AbrirConexionIntranet();
            cmd.CommandText = "Select distinct TOP 15 Papel from intranet2.dbo.Partes_Indigo Where Papel like @prefixText";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 250).Value = prefixText + "%";
            DataTable dt = new DataTable();
            da.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["Papel"].ToString(), i);
                i++;
            }
            return items;
        }
    }
}