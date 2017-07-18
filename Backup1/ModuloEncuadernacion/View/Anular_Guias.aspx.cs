using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloEncuadernacion.Controller;
using Intranet.ModuloEncuadernacion.Model;
using System.Drawing;
using Telerik.Web.UI;

namespace Intranet.ModuloEncuadernacion.View
{
    public partial class Anular_Guias : System.Web.UI.Page
    {
        Controller_InfDespacho cID = new Controller_InfDespacho();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Prod_Terminados> lisPT = new List<Prod_Terminados>();
            lisPT = cID.BuscaPalletAnularGuia(txtCodigoPallet.Text);

            RadGrid1.DataSource = cID.BuscaPalletAnularGuia(txtCodigoPallet.Text);
            RadGrid1.DataBind();

            if (lisPT.Count != 0)
            {

                DivMensaje.Visible = false;

            }
            else
            {

                //poner error qe no existe o fue cerrada
                DivMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "El Pallet no ha sido encontrado.";
                lblMensaje.ForeColor = Color.White;
                DivMensaje.Attributes.Add("style", "background-color:Red");
            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            int contadorInsert = 0;
            List<Prod_Terminados> list = new List<Prod_Terminados>();
            // StringBuilder str = new StringBuilder();
            if (txtDevolucion.Text != "")
            {
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    GridDataItem row = RadGrid1.Items[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {
                        contadorInsert++;

                        bool resp = cID.Anular_Guias(Convert.ToInt32(row["id_ProductosTerminados"].Text),txtDevolucion.Text,Session["Usuario"].ToString());

                    }
                }
                //contador
                if (contadorInsert != 0)
                {
                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/tick.png";
                    lblMensaje.Text = "Registros Eliminados Correctamente";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Green;");
                }
                else
                {
                    DivMensaje.Visible = true;
                    imgMensaje.ImageUrl = "../../Images/cross.png";
                    lblMensaje.Text = "No ha Seleccionado Guias para Eliminar";
                    lblMensaje.ForeColor = Color.White;
                    DivMensaje.Attributes.Add("style", "background-color:Red;");
                }


                RadGrid1.DataSource = cID.BuscaPalletAnularGuia(txtCodigoPallet.Text);
                RadGrid1.DataBind();
            }
            else
            {
                DivMensaje.Visible = true;
                imgMensaje.ImageUrl = "../../Images/cross.png";
                lblMensaje.Text = "Debe ingresar Motivo de la Eliminacion";
                lblMensaje.ForeColor = Color.White;
                DivMensaje.Attributes.Add("style", "background-color:Red;");
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Anular_Guias.aspx?id=6");
        }
    }
}