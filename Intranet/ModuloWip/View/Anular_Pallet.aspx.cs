using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;
using Telerik.Web.UI;
using System.Drawing;

namespace Intranet.ModuloWip.View
{
    public partial class Anular_Pallet : System.Web.UI.Page
    {
        Controller_WipControl wipControl = new Controller_WipControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGridOT.DataSource = "";
                RadGridOT.DataBind();
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(txtCodigoPallet.Text.Substring(0, 1).ToUpper());
                Model_Wip_Control wip = new Model_Wip_Control();
                wip.OT = txtCodigoPallet.Text.ToString().Trim(); wip.IDTipoPallet = 1;
                wip.Pliego = ""; wip.Ubicacion = ""; wip.Tarea = ""; wip.Forma = "";
                RadGridOT.DataSource = wipControl.ListOTUbi_Buscar(wip);
                RadGridOT.DataBind();
            }
            catch
            {
                RadGridOT.DataSource = wipControl.BusquedaPorFolioyOT(txtCodigoPallet.Text.Trim(), "");
                RadGridOT.DataBind();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Anular_Pallet.aspx?id=8&Cat=5");
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            int contador = 0;
            List<Model_Wip_Control> list = new List<Model_Wip_Control>();
            string Codigo_Pallet = "";
            for (int i = 0; i < RadGridOT.Items.Count; i++)
            {
                GridDataItem row = RadGridOT.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                Model_Wip_Control mw = new Model_Wip_Control();
                if (isChecked)
                {
                    mw.ID_Control = row["ID_Control"].Text;
                    list.Add(mw);
                    Codigo_Pallet = Codigo_Pallet + row["ID_Control"].Text+ ",";
                }
            }
            if (Codigo_Pallet != "")
            {
                Codigo_Pallet = Codigo_Pallet.Substring(0, Codigo_Pallet.Length - 1);
                string[] str = Codigo_Pallet.Split(',');
                for (int i = 0; i < str.Length; i++)
                {
                    if (wipControl.EliminarPallet(str[i], Session["Usuario"].ToString(), txtDevolucion.Text.Trim()))
                    {
                        contador++;
                    }
                }
            }
            if (contador > 0)
            {
                DivMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/tick.png";
                lblMensaje.Text = "Registros Eliminados Correctamente";
                lblMensaje.ForeColor = Color.White;
                DivMensaje.Attributes.Add("style", "background-color:Green;");
            }
            else if (Codigo_Pallet == "")
            {
                DivMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "No ha Seleccionado Pallet para Eliminar";
                lblMensaje.ForeColor = Color.White;
                DivMensaje.Attributes.Add("style", "background-color:Red;");
            }
        }        
    }
}