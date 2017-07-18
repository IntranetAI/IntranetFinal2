using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloJefatura.Controller;
using Intranet.ModuloJefatura.Model;
using System.Text;
using Telerik.Web.UI;

namespace Intranet.ModuloJefatura.View
{
    public partial class AsignarGerencia : System.Web.UI.Page
    {
        Controller_centroCosto cc = new Controller_centroCosto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarArea();
                cargarCentroCosto();
                TabPanel2.Enabled = false;
            }
        }
        public void cargarCentroCosto()
        {
            RadGrid1.DataSource = cc.ListarCentroCosto();
            RadGrid1.DataBind();
        }
        protected void contactsGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {


        }
        protected void contactsGrid_ItemCommand2(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {


        }
        public void cargarArea()
        {
            ddlArea.DataSource = Controller_centroCosto.ListarArea(7);
            ddlArea.DataTextField = "NombreArea";
            ddlArea.DataValueField = "IDArea";
            ddlArea.DataBind();

            ddlArea.Items.Insert(0, new ListItem("Seleccione..."));

        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            int sumaReg = 0;
            if (ddlArea.SelectedValue.ToString() != "Seleccione..." && TabContainer1.ActiveTabIndex==0)
            {
                List<centroCosto> list = new List<centroCosto>();
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    GridDataItem row = RadGrid1.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        sumaReg++;
                        centroCosto asi = new centroCosto();
                        asi.cod_CentroCosto = Convert.ToInt32(row["cod_CentroCosto"].Text);
                        asi.CentroCosto = row["CentroCosto"].Text;
                        list.Add(asi);
                    }
                }
                //contador
              
                //llamada procedimiento
                cc.AsignarGerencia(Convert.ToInt32(ddlArea.SelectedValue.ToString()), list);
              
                //controlot.AsignarOT(list, IDUsuario);
                //carga de gridviews
                cargarCentroCosto();
                //mensaje 
                string popupScript = "<script language='JavaScript'> alert(' ¡Se ha Asignado " + sumaReg.ToString() + " centros de costos a "+ddlArea.SelectedItem.ToString()+"! ');location.href='asignarGerencia.aspx'</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('Debe seleccionar el Área a cargo para asignar centros de costos');location.href='asignarGerencia.aspx'</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            cargarCentroCosto();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPanel2.Enabled = true;

            //Label1.Text= ddlArea.SelectedValue.ToString();
            RadGrid2.DataSource = cc.ListarCCAsignados(8, Convert.ToInt32(ddlArea.SelectedValue.ToString()));
            RadGrid2.DataBind();
        }

        protected void btnDesasignar_Click(object sender, EventArgs e)
        {
            int sumaReg = 0;
            if (ddlArea.SelectedValue.ToString() != "Seleccione..." && TabContainer1.ActiveTabIndex==1)
            {
                List<centroCosto> list = new List<centroCosto>();
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < RadGrid2.Items.Count; i++)
                {
                    GridDataItem row = RadGrid2.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        sumaReg++;
                        centroCosto asi = new centroCosto();
                        asi.cod_CentroCosto = Convert.ToInt32(row["cod_CentroCosto"].Text);
                        asi.CentroCosto = row["CentroCosto"].Text;
                        list.Add(asi);
                    }
                }
                //contador

                //llamada procedimiento
                cc.DESAsignarGerencia(list);

                //controlot.AsignarOT(list, IDUsuario);
                //carga de gridviews
                cargarCentroCosto();
                
                //mensaje 
                string popupScript = "<script language='JavaScript'> alert(' ¡Se han Desasignado " + sumaReg.ToString() + " centros de costos a " + ddlArea.SelectedItem.ToString() + "! ');location.href='asignarGerencia.aspx'</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            else
            {
                string popupScript = "<script language='JavaScript'> alert('Debe seleccionar el Área a cargo para desasignar centros de costos');location.href='asignarGerencia.aspx'</script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
            cargarCentroCosto();
        }

    }
}