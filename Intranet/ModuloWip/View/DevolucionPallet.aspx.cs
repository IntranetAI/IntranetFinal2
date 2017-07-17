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
    public partial class DevolucionPallet : System.Web.UI.Page
    {
        public static List<Model_Wip_Control> lista = new List<Model_Wip_Control>();
        public static int Impresos = 0;
        Controller_WipControl wipControl = new Controller_WipControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lista = new List<Model_Wip_Control>();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Model_Wip_Control wip = new Model_Wip_Control();
            wip.OT = txtOT.Text.ToString().Trim(); wip.IDTipoPallet = 1;
            List<Model_Wip_Control> lista = wipControl.ListOTUbi_Buscar(wip);
            int contador = 0;
            foreach(Model_Wip_Control x in lista)
            {
                if (contador == 0)
                {
                    txtCliente.Text = x.NombreOT;
                    lblTirajeOT.Text = x.TotalTiraje.ToString("N0").Replace(",",".");
                }
                contador++;
            }
            RadGridOT.DataSource = lista;
            RadGridOT.DataBind();
            pnlPallet.Visible = true;
            PanelCantidad.Visible = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ddlPliego.SelectedItem.ToString() != "Seleccione...")
            {
                if (Impresos >= Convert.ToInt32(txtCantidad.Text))
                {
                    Model_Wip_Control wip = new Model_Wip_Control();
                    wip.OT = txtOT.Text.Trim();
                    wip.NombreOT = lblTirajeOT.Text.Trim();
                    wip.ID_Control = ddlPliego.SelectedItem.ToString();
                    wip.Pliegos_Impresos = Convert.ToInt32(txtCantidad.Text);
                    wip.Usuario = Session["Usuario"].ToString();
                    lista.Add(wip);
                    ddlPliego.Items.Remove(new ListItem(wip.ID_Control));
                    Impresos = 0;
                    txtCantidad.Text = "";
                    btnAgregar.Enabled = false;
                }
            }
            CargarDatos();

        }

        public void CargarDatos()
        {
            RadGrid2.DataSource = lista;
            RadGrid2.DataBind();
            if (Convert.ToInt32(ddlPliego.Items.Count) == 1)
            {
                btnGuardarDev.Visible = true;
            }
        }

        protected void btnGuardarDev_Click(object sender, EventArgs e)
        {
            string query = "";
            foreach(Model_Wip_Control wip in lista)
            {
                query = query + " update Wip_Pallet Pliegos_Impresos= "+wip.Pliegos_Impresos+", Estado_Pallet=9  where ID_Control = '"+wip.ID_Control+"';"+
                                "insert into Wip_Mov_Pallet (ID_ControlWip,ID_Control, Maquina_Proceso,Ant_Proceso,Pliegos_Impresos,Peso_Pallet,Fecha_Modificacion,Estado_Pallet,Ubicacion, Usuario) "+
                                "select ID_ControlWip, ID_Control, 'Devolución', Maquina_Proceso, " + wip.Pliegos_Impresos + ", Peso_Pallet, GETDATE()," +
                                "9, 'Devolución', '"+wip.Usuario+"' from Wip_Mov_Pallet where ID_Control = '" + wip.ID_Control + "' and Estado_Pallet = 20; ";
            }

            if (wipControl.Devolucion(query))
            {
                divMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/tick.png";
                lblMensaje.Text = "Ingresado Correctamente";
                lblMensaje.ForeColor = Color.White;
                divMensaje.Attributes.Add("style", "background-color:Green;");
                btnGuardarDev.Visible = false;
                btnNuevo.Visible = true;
            }
            else
            {
                divMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "No ha Podido Ingresar Registro. Vuelva a Intentarlo";
                lblMensaje.ForeColor = Color.White;
                divMensaje.Attributes.Add("style", "background-color:Red;");
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("DevolucionPallet.aspx?id=8&cat=5");
        }

        public string BuscarPallet()
        {
            string Pallets = "";
            for (int i = 0; i < RadGridOT.Items.Count; i++)
            {
                GridDataItem row = RadGridOT.Items[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {
                    Pallets = Pallets + row["ID_Control"].Text + ",";

                }

            }
            return Pallets;
        }

        protected void ddlCausa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string res = BuscarPallet();
            if (res.Length > 0)
            {
                if (RadGrid2.Items.Count == 0)
                {
                    PanelCantidad.Visible = true;
                    RadGrid2.DataSource = "";
                    RadGrid2.DataBind();
                    List<string> pallet = new List<string>();
                    int cantidad = 0;
                    for (int i = 0; i < RadGridOT.Items.Count; i++)
                    {
                        GridDataItem row = RadGridOT.Items[i];
                        bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                        if (isChecked)
                        {
                            pallet.Add(row["ID_Control"].Text);
                            cantidad = cantidad + Convert.ToInt32(row["Pliegos_Impresos"].Text);
                        }

                    }
                    ddlPliego.DataSource = pallet;
                    ddlPliego.DataBind();
                    ddlPliego.Items.Insert(0, new ListItem("Seleccione..."));
                    lblRestantes.Text = cantidad.ToString("N0").Replace(",", ".");
                    pnlOT.Visible = false;
                }
            }

        }

        protected void ddlPliego_TextChanged(object sender, EventArgs e)
        {
            if (ddlPliego.SelectedItem.ToString() != "Seleccione...")
            {
                btnAgregar.Enabled = true;
                int cantidad = 0;
                for (int i = 0; i < RadGridOT.Items.Count; i++)
                {
                    GridDataItem row = RadGridOT.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                    if (isChecked && row["ID_Control"].Text.ToString() == ddlPliego.SelectedItem.Text.ToString())
                    {
                        cantidad = Convert.ToInt32(row["Pliegos_Impresos"].Text);
                        Impresos = cantidad;
                    }
                }

                txtCantidad.Text = cantidad.ToString();
            }
            else
            {
                Impresos = 0;
                txtCantidad.Text = "";
                btnAgregar.Enabled = false;
            }
        }
    }
}