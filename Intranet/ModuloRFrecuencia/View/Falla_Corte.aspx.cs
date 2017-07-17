using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloRFrecuencia.Controller;
using System.Web.Services;
using Intranet.ModuloRFrecuencia.Model;
using System.Web.Script.Serialization;

namespace Intranet.ModuloRFrecuencia.View
{
    public partial class Falla_Corte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblIDBobina.Text = Request.QueryString["id"];
                lblUsuario.Text = Request.QueryString["User"];
                Cargar_OrigenCorte();
            }
        }

        public void Cargar_OrigenCorte()
        {
            Bobina_Controller controlbob = new Bobina_Controller();
            DropDownList1.DataSource = controlbob.ListarOrigenesCorte();
            DropDownList1.DataTextField = "Lote";
            DropDownList1.DataValueField = "Lote";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Seleccione..."));
        }

        [WebMethod]
        public static string Carga_Motivo(string TipoOrigen)
        {
            Bobina_Controller controlbob = new Bobina_Controller();
            List<Bobina> lista = controlbob.ListarMotivoCorte(TipoOrigen);
            List<Bobina> lista2 = new List<Bobina>();
            int contador = 1;
            Bobina insert1 = new Bobina();
            insert1.Lote = "Seleccione...";
            lista2.Insert(0, insert1);
            foreach (Bobina ps in lista)
            {
                Bobina objst = new Bobina();
                objst.Lote = ps.Lote;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }

        [WebMethod]
        public static string GuardarMotivo(string Usuario, string IDBobina, string Origen, string Motivo)
        {
            string respuesta = "Error";
            Bobina_Controller controlbob = new Bobina_Controller();
            Bobina bobina = new Bobina();
            bobina.Codigo = IDBobina;
            bobina.Proveedor = Origen;
            bobina.VerMas = Usuario;
            bobina.pliego = Motivo;
            if (Origen != "Seleccione..." && Motivo != "Seleccione...")
            {
                if (controlbob.InsertMotivoCorte(bobina))
                {
                    respuesta = "OK";
                }
            }
            return respuesta;
        }
    }
}