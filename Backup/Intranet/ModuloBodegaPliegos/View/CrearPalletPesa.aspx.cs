using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloBodegaPliegos.Controller;
using Intranet.ModuloBodegaPliegos.Model;
using Intranet.ModuloWip.Controller;
using Intranet.ModuloWip.Model;
using System.Data;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class CrearPalletPesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Controller_Cortadora cc = new Controller_Cortadora();
                string ot = Request.QueryString["ot"];
                string compo = Request.QueryString["comp"];
                string codigo = Request.QueryString["Codigo"];
                BodegaPliegos d = cc.BuscaTotalCant(ot, compo, codigo);
                lblOT.Text = d.OT;
                lblNombreOT.Text = d.NombreOT;
                lblComponente.Text = d.Componente;
                lblPapel.Text = d.Papel;
                lblCodigo.Text = d.CodigoProducto;
                lblMarca.Text = "";
                lblGramaje.Text = d.Gramaje;
                lblAncho.Text = d.Ancho;
                lblLargo.Text = d.Largo;
                lblCantidad.Text = d.StockFL;              

                int sol = Convert.ToInt32(d.StockFL.Replace(".",""));
                int ca = cc.CantidadPallet(d.OT, d.Componente, d.CodigoProducto, 0);
                lblTotalSolicitado.Text = d.StockFL;
                lblTotalCreado.Text = ca.ToString().Replace(",", ".");
                int resul = sol - ca;
                lblTotalFaltante.Text = resul.ToString().Replace(",", ".");
                this.BindDummyRow();
            }
        }
        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("OT");
            dummy.Columns.Add("NombreOT");
            dummy.Columns.Add("Ubicacion");
            dummy.Columns.Add("Posicion");
            dummy.Columns.Add("ID_Control");
            dummy.Columns.Add("Pliego");
            dummy.Columns.Add("Pliegos_Impresos");
            dummy.Columns.Add("Peso_pallet");
            dummy.Columns.Add("Maquina_Proceso");
            dummy.Columns.Add("Estado_Pallet2");
            dummy.Columns.Add("Fecha_Modificacion");
            dummy.Columns.Add("Usuario");
            dummy.Columns.Add("VerMas");

            dummy.Rows.Add();
            gvCustomers.DataSource = dummy;
            gvCustomers.DataBind();
        }
        [WebMethod]
        public static string[] BuscarOT(string loc)
        {
            Controller_Cortadora cc = new Controller_Cortadora();
            //string v = "";
            //string ot = "";
            //string compo = "";
            //string codigo = "";

            //if (loc.IndexOf("=") > 0)
            //{
            //    v = loc.Substring(loc.IndexOf("="), loc.IndexOf("&") - loc.IndexOf("="));
            //    string[] v2 = v.Split(',');
            //    ot = v2[0];
            //    compo = v2[1];
            //    codigo = v2[2];
            //}

            //BodegaPliegos d = cc.BuscaTotalCant(ot);
            //return new[] { d.OT, d.NombreOT, d.Componente, d.Papel, d.Gramaje, d.Ancho, d.Largo, d.StockFL };
            return new[] { "" };

        }
        [WebMethod]
        public static string[] CrearPallet(string OT, string NombreOT, string Comp,string Codigo, string Papel, int Ancho, int Largo, int Gramaje, int Cantidad, float Peso,int Faltante, string loc)
        {
            Controller_Cortadora cc = new Controller_Cortadora();

            if (OT != ""  && Comp != "" && Cantidad != 0 && Peso != 0 && Codigo!="")
            {
                if ((Faltante-Cantidad) >= 0)
                {
                    string r = "";
                    r = cc.IngresarPallet("", Codigo, OT, Comp, NombreOT, Papel, "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, "Sistema", "", "","", 0);//poner idtrabajo
                    if (r != "")
                    {
                        //string[] ll = loc.Split('?');
                        //string b = ll[1];
                        //string[] v2 = b.Split('&');
                        //string ot = v2[0].Replace("ot=", "");
                        //string compo = v2[1].Replace("comp=", "");
                        //string codigo = v2[2].Replace("Codigo=", "");


                        return new[] { "OK" };
                    }
                    else
                    {
                        return new[] { "Error" };
                    }
                }
                else
                {
                    return new[] { "Error2" };
                }
            }
            else
            {
                return new[] { "Error3" };
            }

        }
       

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {

        }
    }
}