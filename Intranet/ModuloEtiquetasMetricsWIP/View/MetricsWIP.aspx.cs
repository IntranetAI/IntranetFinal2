using Intranet.ModuloEtiquetasMetricsWIP.Controller;
using Intranet.ModuloEtiquetasMetricsWIP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.ModuloEtiquetasMetricsWIP.View
{
    public partial class MetricsWIP : System.Web.UI.Page
    {
        EtiquetasController ec = new EtiquetasController();
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {
            if (txtOT.Text != "")
            {
                lblTabla.Text = ec.ResultadoFiltro(txtOT.Text, ddlPliego.SelectedValue.ToString(), "KBA", 0);
            }
        }
        [WebMethod]
        public static string CargarPliegosOT(string OT)
        {
            EtiquetasController c = new EtiquetasController();
            List<Etiquetas> lista = c.ListaPliegosOT(OT, "", "", -1);
            List<Etiquetas> lista2 = new List<Etiquetas>();
            //ListaPliegosOT
            int contador = 1;
            Etiquetas insert1 = new Etiquetas();
            insert1.Pliego = "Todos";
            lista2.Insert(0, insert1);
            foreach (Etiquetas ps in lista)
            {
                Etiquetas objst = new Etiquetas();
                //objst.Componente = ps.Componente;
                objst.Pliego = ps.Pliego;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string[] CargarTabla(string OT,string Pliego)
        {
            EtiquetasController ec = new EtiquetasController();
            return new[] { ec.ResultadoFiltro(OT, (Pliego == "Todos" ? "" : Pliego), "KBA", 0) };
        }
        [WebMethod]
        public static string[] CrearOrden(string ObjId, int Cantidad, string Usuario)
        {
            int resp = 0;int respXintra = 0;
            EtiquetasController ec = new EtiquetasController();

            if ((ObjId != "" && ObjId != "0") && Cantidad > 0)
            {
                resp = ec.CrearEtiqueta(ObjId, Cantidad);
                if (resp > 0)
                {
                    respXintra = ec.CrearEtiquetaxIntranet(resp, ObjId, Cantidad);
                }
            }
            return new[] { resp.ToString() };
        }
    }
}