using Intranet.ModuloEtiquetasMetricsWIP.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloEtiquetasMetricsWIP.View
{
    public partial class EtiquetasWip : System.Web.UI.Page
    {
        EtiquetasController ec = new EtiquetasController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCantidad.Attributes.Add("onkeypress", "return solonumeros(event);");
                RadGrid1.DataSource = "";
                RadGrid1.DataBind();
            }
        }
        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {
            if (txtOT.Text != "")
            {
                RadGrid1.DataSource = ec.Produccion_EstadisticaEnc(txtOT.Text, (ddlPliego.SelectedValue.ToString() == "Seleccione..." ? "" : ddlPliego.SelectedValue.ToString()), ddlMaquina.SelectedValue.ToString(), 0);
                RadGrid1.DataBind();
            }
        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            if (lblObjId.Text != "" || lblObjId.Text != "0")
            {
              //  resultado = ec.CrearEtiqueta(lblObjId.Text, Convert.ToInt32(txtCantidad.Text));
                if (resultado > 0)
                {
                    //funciona
                    lblResultado.Text = resultado.ToString();
                }
                else
                {
                    //no funciona
                    lblResultado.Text = "No funciona, vuelve a intentarlo";
                }
            }
        }

        [WebMethod]
        public static string[] CrearOrden(string ObjId,int Cantidad,string Usuario)
        {
            int resp = 0;
            EtiquetasController ec = new EtiquetasController();

            if ((ObjId != "" && ObjId != "0") && Cantidad > 0)
            {
                resp = ec.CrearEtiqueta(ObjId, Cantidad);
            }
            return new[] { resp.ToString()};
        }

    }
}