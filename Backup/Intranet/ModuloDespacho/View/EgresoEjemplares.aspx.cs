using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Intranet.ModuloDespacho.Controller;
using Intranet.ModuloDespacho.Model;
using System.Web.Script.Serialization;
namespace Intranet.ModuloDespacho.View
{
    public partial class EgresoEjemplares : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCantidad.Attributes.Add("onkeypress", "return solonumeros(event);");
            if (!IsPostBack)
            {

                #region Existencia
                lblExistencia.Text = "<table id='tblRegistro' runat='server' cellpadding='0' cellspacing='0' " +
                    "style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:940px;margin-left:45px;'>" +
                    "<tr style='background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;'>" +
                    "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                    "       OT </td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:500px;'>" +
                            "Nombre OT</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:200px;'>" +
                            "Tipo Ejemplar</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:100px;'>" +
                            "Saldo en Existencia</td>" +
                        "<td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:70px;'>" +
                            "</td>" +

                    "</tr>"+
                    "<tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;'>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;'>" +
                        "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                         "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                        "</td>" +
                        "<td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;'>" +
                         "</td>" +
                    "<tr></table>";
                #endregion
            }

        }
        [WebMethod]
        public static string[] BuscarOT(string OT)
        {
            Controller_EstadoOT c = new Controller_EstadoOT();
            Estado_OT b = c.BuscarOT(OT, 0);
            return new[] { b.NombreOT, b.Cliente };

        }
        //BuscarExistencia
        [WebMethod]
        public static string[] BuscarExistencia(string OT)
        {
            Controller_EstadoOT c = new Controller_EstadoOT();
            string b = c.BuscaExistencia(OT, 1);
            return new[] { b };

        }
        [WebMethod]
        public static string CargaArea(string Area)
        {
            int tipo = 0;
            if (Area == "CSR")
            {
                tipo = 2;
            }
            else if (Area == "Vendedores")
            {
                tipo = 3;
            }
            else if (Area == "Bodega de Rezago")
            {
                tipo = 4;
            }
            else if (Area == "Facturacion")
            {
                tipo = 5;
            }
            else if (Area == "Biblioteca")
            {
                tipo = 7;
            }
            else if (Area == "Despacho")
            {
                tipo = 8;
            }
            else if (Area == "Bodega Materias Primas")
            {
                tipo = 9;
            }
            else if (Area == "Encuadernacion")
            {
                tipo = 10;
            }
            else if (Area == "Control de Calidad")
            {
                tipo = 11;
            }
            Controller_EstadoOT c = new Controller_EstadoOT();
            List<Estado_OT> lista = c.ListarArea("", tipo);
            List<Estado_OT> lista2 = new List<Estado_OT>();

            int contador = 1;
            Estado_OT insert1 = new Estado_OT();
            insert1.Cliente = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Estado_OT ps in lista)
            {
                Estado_OT objst = new Estado_OT();
                objst.Cliente = ps.Cliente;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string[] CrearEgresoss(int CantidadMaxima,string OT, string NombreOT, string Tipo, int Cantidad, string AreaEntrega, string Usuario, string Motivo,string Observacion, string CreadoPor)
        {
            string resp = "";
            if (OT != "" && NombreOT != "" && Tipo != "" && Cantidad != 0 && AreaEntrega != "Seleccione..." && Usuario != "Seleccionar" && Motivo != "Seleccionar" && Observacion != "")
            {
                if (Cantidad <= CantidadMaxima)
                {
                    Controller_EstadoOT c = new Controller_EstadoOT();
                    bool b = c.IngresaEgreso(OT, NombreOT, Tipo, Cantidad, AreaEntrega, Usuario, Motivo, Observacion, CreadoPor, 0);
                    if (b == true)
                    {
                        resp = "OK";
                    }
                    else
                    {
                        resp = "ERROR";
                    }
                }
                else
                {
                    resp = "ERROR3";
                }
            }
            else
            {
                resp = "ERROR2";
            }
           

            return new[] { resp };

        }
        [WebMethod]
        public static string CargaMotivo(string Area)
        {
            int tipo = 0;
            if (Area == "CSR")
            {
                tipo = 4;
            }
            else if (Area == "Vendedores")
            {
                tipo = 5;
            }
            Controller_EstadoOT c = new Controller_EstadoOT();
            List<Estado_OT> lista = c.ListarArea("", tipo);
            List<Estado_OT> lista2 = new List<Estado_OT>();

            int contador = 1;
            Estado_OT insert1 = new Estado_OT();
            insert1.Cliente = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Estado_OT ps in lista)
            {
                Estado_OT objst = new Estado_OT();
                objst.Cliente = ps.Cliente;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
        [WebMethod]
        public static string CargaMotivos(string Area)
        {

            Controller_EstadoOT c = new Controller_EstadoOT();
            List<Estado_OT> lista = c.ListarArea(Area, 6);
            List<Estado_OT> lista2 = new List<Estado_OT>();

            int contador = 1;
            Estado_OT insert1 = new Estado_OT();
            insert1.Cliente = "Seleccionar";
            lista2.Insert(0, insert1);
            foreach (Estado_OT ps in lista)
            {
                Estado_OT objst = new Estado_OT();
                objst.Cliente = ps.Cliente;
                lista2.Insert(contador, objst);
                contador++;
            }

            JavaScriptSerializer jscript = new JavaScriptSerializer();
            return jscript.Serialize(lista2);
        }
    }
}