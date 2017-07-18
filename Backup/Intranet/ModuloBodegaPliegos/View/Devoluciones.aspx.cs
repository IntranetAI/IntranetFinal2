using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.ModuloBodegaPliegos.Controller;
using System.Web.Services;
using Intranet.ModuloBodegaPliegos.Model;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class Devoluciones : System.Web.UI.Page
    {
        Controller_Devoluciones cd = new Controller_Devoluciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = cd.ListaDevoluciones("", "", "", DateTime.Now, DateTime.Now,-2);
                RadGrid1.DataBind();
            }
        }

        protected void btnFiltro_Click1(object sender, EventArgs e)
        {
            try
            {
                if (txtFechaInicio.Text != "" && txtFechaTermino.Text != "")
                {
                    string[] str = txtFechaInicio.Text.Split('/');
                    DateTime fi = Convert.ToDateTime(str[1] + "/" + str[0] + "/" + str[2] + " 00:00:00");
                    string[] str2 = txtFechaTermino.Text.Split('/');
                    DateTime ft = Convert.ToDateTime(str2[1] + "/" + str2[0] + "/" + str2[2] + " 23:59:59");
                    RadGrid1.DataSource = cd.ListaDevoluciones(txtOT.Text, "", txtNroPallet.Text, fi, ft, -1);
                    RadGrid1.DataBind();
                }
                else
                {
                    RadGrid1.DataSource = cd.ListaDevoluciones(txtOT.Text, "", txtNroPallet.Text, DateTime.Now, DateTime.Now, 0);
                    RadGrid1.DataBind();
                }

            }
            catch
            {
            }
        }
        [WebMethod]
        public static string[] ProcesarDevolucion(string Folio, string SKU)
        {
            try
            {
                Controller_Devoluciones cd = new Controller_Devoluciones();
                BodegaPliegos d = cd.CargaDevoluciones("", "", Folio, DateTime.Now, DateTime.Now, 1);

                return new[] { d.OT, d.NombreOT, d.Componente, d.CodigoProducto, d.Papel, d.Gramaje, d.Ancho, d.Largo, d.SolicitadoFL, d.Procedencia };
            }
            catch
            {
                return new[] { "" };
            }
        }
        [WebMethod]
        public static string[] CargaFaltantes(string IDConsumo)
        {
            try
            {
                Controller_Devoluciones cd = new Controller_Devoluciones();
                BodegaPliegos d = cd.CargaFaltantes(IDConsumo, "", "", DateTime.Now, DateTime.Now, 2);

                return new[] { d.Pliegos };
            }
            catch
            {
                return new[] { "" };
            }

        }
        [WebMethod]
        public static string[] CrearDevolucion(string Folio,string OT,string NombreOT,string Componente,string SKU,string Papel,int Gramaje,int Ancho,int Largo,
            int Pliegos, double Peso, string MotivoDevolucion, string Procedencia, string Usuario, int MaxDevolver)
        {
            if (Folio != "")
            {
                if ((MaxDevolver - Pliegos) >= 0)
                { 
                    Controller_Devoluciones cd = new Controller_Devoluciones();
                    string r = cd.InsertarDevolucion(Folio, OT, NombreOT, Componente, SKU, Papel, Gramaje, Ancho, Largo, Pliegos, Peso, MotivoDevolucion, Procedencia, Usuario, 0);// cd.InsertarDevolucion(IDConsumo, OT, NombreOT, Componente, SKU, Papel, Gramaje, Ancho, Largo, Pliegos, Peso, Usuario, 0);
                    if (r!="")
                    {
                        return new[] { "OK", r };
                    }
                    else
                    {
                        return new[] { "Error al ingresar la devolucion" };
                    }
                }
                else
                {
                    return new[] { "La cantidad a devolver no puede ser mayor a la faltante" };
                }
            }
            else
            {
                return new[] { "ha ocurrido un error, vuelva a intentarlo" };
            }

        }
    }
}