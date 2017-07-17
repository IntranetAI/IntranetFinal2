using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;
using System.Web.Services;
using Intranet.ModuloBodegaPliegos.Model;
using System.Web.Script.Serialization;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class SolicitudDimensionadoPapelDetalle : System.Web.UI.Page
    {
        Controller_Dimensionadora d = new Controller_Dimensionadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtAncho.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtLargo.Attributes.Add("onkeypress", "return solonumeros(event);");
            txtPliegos.Attributes.Add("onkeypress", "return solonumeros(event);");
            if (!IsPostBack)
            {
                string sku = Request.QueryString["sku"];
                lblSKU.Text = sku;
                lblPaperStock.Text = Request.QueryString["Papel"];
                lblGramStock.Text = Convert.ToInt32(Convert.ToDouble(Request.QueryString["Gramaje"])).ToString();
                lblAnchStock.Text = Convert.ToInt32(Convert.ToDouble(Request.QueryString["Ancho"])).ToString();
                RadGrid1.DataSource = d.ListaStockDisponibleDetalle(sku, "", 0, 0,"","", 1);
                RadGrid1.DataBind();

                bool r = d.EliminaPendientes(Session["Usuario"].ToString(), 0);
                //eliminar registros pendientes
                lblSKUStock.Text = sku;
            }
        }
        [WebMethod]
        public static string[] BuscarOT(string OT)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            BodegaPliegos b = c.BuscaOT(OT, "", 0);
            return new[] { b.NombreOT };

        }
        [WebMethod]
        public static string CargarPliegosProgramado(string OT)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            List<BodegaPliegos> lista = c.ListaComponenteOT(OT, "", 1);
            List<BodegaPliegos> lista2 = new List<BodegaPliegos>();

            int contador = 1;
            BodegaPliegos insert1 = new BodegaPliegos();
            insert1.Componente = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (BodegaPliegos ps in lista)
            {
                BodegaPliegos objst = new BodegaPliegos();
                objst.Componente = ps.Componente;
      
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string[] BuscarOTComponente(string OT,string Componente)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            BodegaPliegos b = c.BuscaOT(OT, Componente, 2);
            string ancho = "";
            string largo = "";
            try
            {
                string[] a = b.FormatoPapel.Split('x');
                ancho = a[0];
                largo = a[1];
            }
            catch
            {
            }
            return new[] { b.Papel, ancho, largo, b.Gramaje, b.PliegosSol, b.Ancho, b.Largo, b.Kilos };

        }
        [WebMethod]
        public static string[] BuscarFolio(string Usuario)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            string b = c.InsertEncabezado(Usuario, "", 3);
            return new[] { b };

        }
        [WebMethod]
        public static string[] GuardarTrabajo(string Folio,string OT,string NombreOT,string Componente,string SKU,string Papel,int Gramaje,int Ancho,int Largo,int Pliegos,string Usuario, double KilosRestantes)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            double kilos = 0;
            double anc = Convert.ToDouble(Ancho);
            double larg = Convert.ToDouble(Largo);
            double gram = Convert.ToDouble(Gramaje);
            double ff = Convert.ToDouble(1000000000);
            double plieg = Convert.ToDouble(Pliegos);
            kilos = (((anc * larg * gram) / ff) * plieg);
            string Respuesta = "";

            double k = (KilosRestantes - kilos);
            if (SKU != "Seleccionar" && Papel != "Seleccionar")
            {
                if (k >= 0)
                {
                    int r = c.GuardarTrabajo(Folio, OT, NombreOT, Componente, SKU, Papel, Gramaje, Ancho, Largo, Pliegos, kilos, Usuario, 0);
                    if (r > 0)
                    {
                        Respuesta = "OK";
                    }
                    else
                    {
                        Respuesta = "ERROR";
                    }
                }
                else
                {
                    Respuesta = "ERROR2";
                }
            }
            else
            {
                Respuesta = "ERROR";
            }

            return new[] { Respuesta };

        }

        [WebMethod]
        public static string[] CargaTabla(string Folio)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            string Tabla = c.CargarTabla(Folio, "", "", "", "", "", 0, 0, 0, 0, 0, "", 1);
            return new[] { Tabla };
        }

        [WebMethod]
        public static string[] EliminarIngreso(string IDRegistro)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            string resultado = "ERROR";
            bool res = c.EliminaRegistro(IDRegistro, "", "", "", "", "", 0, 0, 0, 0, 0, "", 2);
            if (res == true)
            {
                resultado = "OK";
            }
            return new[] { resultado };
        }

        [WebMethod]
        public static string[] ParaStock(int Largo,string SKU,string Papel,int Gramaje,int Ancho)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            string ff = "";
            string[] v = SKU.Split('.');
            ff = v[0] + "." + v[1];
           
            BodegaPliegos r = c.ParaStock("", "", "", "", ff, Papel, Gramaje, Ancho, Largo, 0, 0, "", 3);
            if (r == null)
            {
                return new[] { "Error", "", "", "" };
            }
            else                    
            {
                return new[] { "OK", r.CodigoProducto, r.Ancho, r.Largo };
            }
            
        }
        [WebMethod]
        public static string[] GuardarParaStock12(string Folio, string SKU, string Papel, int Gramaje, int Ancho, int Largo, int Pliegos, double Peso, string Usuario, string KilosRestantes)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            string Respuesta = "";
            double k = (Convert.ToDouble(KilosRestantes) - Peso);

            if (k >= 0)
            {
                int r = c.GuardarTrabajo(Folio, "Stock", "Stock", "Stock", SKU, Papel, Gramaje, Ancho, Largo, Pliegos, Peso, Usuario, 0);
                if (r > 0)
                {
                    Respuesta = "OK";
                }
                else
                {
                    Respuesta = "ERROR";
                }
            }
            else
            {
                Respuesta = "ERROR2";
            }

            return new[] { Respuesta };

        }


        [WebMethod]
        public static string[] FaltanteAsignar(string Usuario, int KGAsignados,string Folio)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            BodegaPliegos b = c.CantidadRestante(Usuario,Folio, 0);

            int pliegos = Convert.ToInt32(b.PliegosSol);
            double kilosSol = Convert.ToDouble(b.SolicitadoKG);
            double kilosAsig = Convert.ToDouble(KGAsignados);

            double restante = (kilosAsig - kilosSol);

            return new[] { b.PliegosSol, b.SolicitadoKG, restante.ToString(), kilosAsig.ToString() };

        }
        [WebMethod]
        public static string[] FinalizarSolicitud(string Bobinas, double FaltaAsignar, string Folio, double KilosBobinas, string SKU,double Peso, string Usuario)
        {
            string respuesta = "";
           
            Controller_Dimensionadora c = new Controller_Dimensionadora();


            if (KilosBobinas >0)
            {
                if (Folio != "0" && Peso > 0)
                {
                    if (FaltaAsignar > -1)
                    {
                        string bob = Bobinas.Substring(0, Bobinas.Length - 1);

                        bool b = c.TerminarSolicitud(bob.Replace(".", "").Replace("-", ","), Folio, SKU, Usuario, 0);

                        if (b == true)
                        {
                            respuesta = "OK";
                        }
                        else
                        {
                            respuesta = "ERROR";
                        }
                    }
                    else
                    {
                        respuesta = "ERROR3";
                    }
                }
                else
                {
                    respuesta = "ERROR4";
                }

            }
            else
            {
                respuesta = "ERROR2";
            }



            return new[] { respuesta};

        }
        [WebMethod]
        public static string[] EnviarCorreos(string Folio)
        {
            string res = "";
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            bool T = c.generarCorreo(Folio);
            if (T == true)
            {
                res = "OK";
            }
            else
            {
                res = "ERROR";
            }
            return new[] { res };
        }
        //EliminarIngreso
        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargarSKU(string sku,int Ancho, int Largo)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            List<BodegaPliegos> lista = c.ListaSKU(sku,0, Ancho, Largo, 4);//0
            List<BodegaPliegos> lista2 = new List<BodegaPliegos>();

            int contador = 1;
            BodegaPliegos insert1 = new BodegaPliegos();
            insert1.Papel = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (BodegaPliegos ps in lista)
            {
                BodegaPliegos objst = new BodegaPliegos();
                //objst.Componente = ps.Componente;
                objst.Papel = ps.Papel;
                objst.CodigoProducto = ps.CodigoProducto;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string CargarSKUStock(string Papel,int Gramaje, int Ancho, int Largo)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            List<BodegaPliegos> lista = c.ListaSKU(Papel, Gramaje, Ancho, Largo, 3);//0
            List<BodegaPliegos> lista2 = new List<BodegaPliegos>();

            int contador = 1;
            BodegaPliegos insert1 = new BodegaPliegos();
            insert1.Papel = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (BodegaPliegos ps in lista)
            {
                BodegaPliegos objst = new BodegaPliegos();
                //objst.Componente = ps.Componente;
                objst.Papel = ps.Papel;
                objst.CodigoProducto = ps.CodigoProducto;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
    }
}