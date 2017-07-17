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
    public partial class AtenderPesa : System.Web.UI.Page
    {
        Controller_Cortadora cc = new Controller_Cortadora();
        Controller_Dimensionadora dd = new Controller_Dimensionadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = cc.CargaPendientesPesa();
                RadGrid1.DataBind();
                RadGrid2.DataSource = dd.CargaPendientesDimensionadora(0);
                RadGrid2.DataBind();   
            }
        }
        [WebMethod]
        public static string[] CargaSolicitud(string IDCorte,string OT,string Componente,string SKU)
        {
            try
            {
                Controller_Cortadora cc = new Controller_Cortadora();
                BodegaPliegos d = cc.BuscaTotalCant(IDCorte, Componente, SKU);
                int sol = Convert.ToInt32(d.StockFL.Replace(".", ""));
                int ca = cc.CantidadPallet(d.OT, d.Componente, d.CodigoProducto, 0);
                int resul = sol - ca;
                return new[] { d.OT, d.NombreOT.ToUpper(), d.Componente, d.Papel.ToUpper(), d.CodigoProducto, d.Gramaje, d.Ancho, d.Largo, d.StockFL, ca.ToString().Replace(",", "."), resul.ToString().Replace(",", "."), d.SKUSalida, d.FAncho, d.FLargo };
            }
            catch
            {
                return new[] { "" };
            }
        }
        [WebMethod]
        public static string[] CrearPallet(string IDCorte, int Pliegos, float Peso, string Tipo, int Faltante, string Usuario, string SKUSalida)
        {
            Controller_Cortadora cc = new Controller_Cortadora();
            if (IDCorte == "" || Pliegos >= 0 || Peso >= 0)
            {
                if (Tipo == "Cerrar" || ((Faltante - Pliegos) == 0))
                {
                    string r = "";
                    r = cc.IngresarPalletCorte(IDCorte, Pliegos, Peso, Usuario, SKUSalida, 0);
                   // r = cc.IngresarPallet(FolioOrigen, Codigo, OT, Comp, NombreOT, Papel.Replace(Codigo, "").Trim(), "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioAnterior, FolioOrigen, "GUILLOTINA", 3);//poner idtrabajo
                    if (r != "")
                    {
                        return new[] { "OK", r, "0" };
                    }
                    else
                    {
                        return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                    }
                }
                else
                {
                    if ((Faltante - Pliegos) > 0)
                    {
                        string r = "";
                        r = cc.IngresarPalletCorte(IDCorte, Pliegos, Peso, Usuario, SKUSalida, 1);
                     //   r = cc.IngresarPallet(FolioOrigen, Codigo, OT, Comp, NombreOT, Papel.Replace(Codigo, "").Trim(), "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioAnterior, FolioOrigen, "GUILLOTINA", 2);//poner idtrabajo
                        if (r != "")
                        {
                            return new[] { "OK", r, "0" };
                        }
                        else
                        {
                            return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                        }
                    }
                    else
                    {
                        return new[] { "¡La Cantidad ingresada no puede ser mayor a la faltante!" };
                    }
                }
            }
            else
            {
                return new[] { "¡Debe Ingresar todos los campos!" };
            }

           
            //if (OT != "" && Comp != "" && Cantidad != 0 && Peso != 0 && Codigo != "" && Codigo!="Seleccionar")
            //{
            //    if (Procedencia.ToUpper()=="STOCK")
            //    {
            //        if (Tipo == "Cerrar" || ((Faltante - Cantidad) == 0))
            //        {
            //            string r = "";
            //            r = cc.IngresarPallet(FolioOrigen, Codigo, OT, Comp, NombreOT, Papel.Replace(Codigo, "").Trim(), "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioAnterior, FolioOrigen,"GUILLOTINA", 5);//poner idtrabajo
            //            if (r != "")
            //            {
            //                return new[] { "OK", r, "0" };
            //            }
            //            else
            //            {
            //                return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
            //            }
            //        }
            //        else
            //        {
            //            if ((Faltante - Cantidad) > 0)
            //            {
            //                string r = "";
            //                r = cc.IngresarPallet(FolioOrigen, Codigo, OT, Comp, NombreOT, Papel.Replace(Codigo, "").Trim(), "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioAnterior, FolioOrigen,"GUILLOTINA", 4);//poner idtrabajo
            //                if (r != "")
            //                {
            //                    return new[] { "OK", r, "0" };
            //                }
            //                else
            //                {
            //                    return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
            //                }
            //            }
            //            else
            //            {
            //                return new[] { "¡La Cantidad ingresada no puede ser mayor a la faltante!" };
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (Tipo == "Cerrar" || ((Faltante - Cantidad) == 0))
            //        {
            //            string r = "";
            //            r = cc.IngresarPallet(FolioOrigen, Codigo, OT, Comp, NombreOT, Papel.Replace(Codigo, "").Trim(), "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioAnterior, FolioOrigen,"GUILLOTINA", 3);//poner idtrabajo
            //            if (r != "")
            //            {
            //                return new[] { "OK", r, "0" };
            //            }
            //            else
            //            {
            //                return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
            //            }
            //        }
            //        else
            //        {
            //            if ((Faltante - Cantidad) > 0)
            //            {
            //                string r = "";
            //                r = cc.IngresarPallet(FolioOrigen, Codigo, OT, Comp, NombreOT, Papel.Replace(Codigo, "").Trim(), "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioAnterior, FolioOrigen,"GUILLOTINA", 2);//poner idtrabajo
            //                if (r != "")
            //                {
            //                    return new[] { "OK", r, "0" };
            //                }
            //                else
            //                {
            //                    return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
            //                }
            //            }
            //            else
            //            {
            //                return new[] { "¡La Cantidad ingresada no puede ser mayor a la faltante!" };
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    return new[] { "¡Debe Ingresar todos los campos!" };
            //}
        }


        [WebMethod]
        public static string CargaPalletCreados(string Folio,string OT,string Componente)
        {
            Controller_Cortadora cc = new Controller_Cortadora();
            string res = cc.CargaPalletCreados(Folio, OT, Componente, 0);
            return res;
        }
        [WebMethod]
        public static string[] CargaSolicitudTrabajo(string IDTrabajo)//string Folio,
        {
            Controller_Dimensionadora cc = new Controller_Dimensionadora();
            BodegaPliegos d = cc.CargaSolicitudTrabajo("", "", "", "", IDTrabajo, 0);
            int sol = Convert.ToInt32(d.SolicitadoFL.Replace(".", ""));
            int ca = cc.CargaCantidadTrabajos(d.OT, d.Componente, d.CodigoProducto, "", IDTrabajo, 2);
            int resul = sol - ca;
            return new[] { d.OT, d.NombreOT.ToUpper(), d.Componente, d.Papel.ToUpper(), d.CodigoProducto, d.Gramaje, d.Ancho, d.Largo, d.SolicitadoFL, ca.ToString().Replace(",", "."), resul.ToString().Replace(",", "."), d.Folio, d.FCAncho, d.FCLargo };
        }

        [WebMethod]
        public static string[] CrearSolicitudCorte(string FolioOrigen, string OT, string NombreOT, string Comp, string SKU, string Papel, int Ancho, int Largo, int Gramaje, int Cantidad, float Peso, int Faltante, string loc, int Factor, string Folio, int FAncho, int FLargo, string Usuario, string IDT, string Tipo)
        {
            Controller_Dimensionadora cc = new Controller_Dimensionadora();
            Controller_Cortadora cp = new Controller_Cortadora();
            string r = "";
            if (OT != "" && Comp != "" && Cantidad != 0 && Peso != 0 && SKU != "" && SKU != "Seleccionar")
            {
                //if (OT == "Stock")
                //{
                    #region Stock
                    if (FAncho == Ancho || FLargo == Largo)
                    {
                        //finalizar pallet y generar etiqueta BP
                        if (Tipo.ToLower() == "cerrar" || ((Faltante - Cantidad) == 0))
                        {
                            r = cp.IngresarPallet(FolioOrigen, SKU, OT, Comp, NombreOT, Papel, "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioOrigen, IDT,"DIMENSIONADORA", 3);
                            if (r != "")
                            {
                                return new[] { "OK", r, "0" };
                            }
                            else
                            {
                                return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                            }
                        }
                        else
                        {
                            if ((Faltante - Cantidad) > 0)
                            {

                                r = cp.IngresarPallet(FolioOrigen, SKU, OT, Comp, NombreOT, Papel, "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioOrigen, IDT, "DIMENSIONADORA", 2);
                                if (r != "")
                                {
                                    return new[] { "OK", r, "0" };
                                }
                                else
                                {
                                    return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                                }
                            }
                            else
                            {
                                return new[] { "¡La Cantidad ingresada no puede ser mayor a la faltante!" };
                            }
                        }
                    }
                    else
                    {
                        //si cambia el formato generar SC
                        if (FAncho<Ancho || FLargo<Largo)
                        {
                            if (Tipo == "CERRAR" || ((Faltante - Cantidad) == 0))
                            {

                                //r = cc.CrearSolicitudCorte(OT, Comp, Papel, SKU, Gramaje, Ancho, Largo, FAncho, FLargo, Factor, Cantidad, Peso, Usuario, Folio, IDT, 1);
                                r = cc.CrearSolicitudCorte("", SKU, OT, Comp, NombreOT, Papel, "", Gramaje,Ancho, Largo, Cantidad, Peso, Usuario, Folio, IDT, "", 5);
                                if (r != "")
                                {
                                    return new[] { "OK", r, "1" };
                                }
                                else
                                {
                                    return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                                }
                            }
                            else
                            {

                                if ((Faltante - Cantidad) > 0)
                                {
                                    r = cc.CrearSolicitudCorte("", SKU, OT, Comp, NombreOT, Papel, "",Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, Folio, IDT, "", 4);
                                    if (r != "")
                                    {
                                        return new[] { "OK", r, "1" };
                                    }
                                    else
                                    {
                                        return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                                    }
                                }
                                else
                                {
                                    return new[] { "¡La Cantidad ingresada no puede ser mayor a la faltante!" };
                                }
                            }
                        }
                        else
                        {
                            return new[] { "¡El Formato de corte no puede ser mayor a el formato del papel!" };//el formato de corte no puede ser mayor
                        }
                    }
                    #endregion 
                //}
                //else
                //{
                //    #region crear pallet para ot

                //    if (FAncho > Ancho || FLargo > Largo)
                //    {
                //        return new[] { "Error4" };
                //    }
                //    else
                //    {
                //        if (FAncho == Ancho || FLargo == Largo)
                //        {
                //            if (Tipo == "Cerrar" || ((Faltante - Cantidad) == 0))
                //            {
                //                r = cp.IngresarPallet(FolioOrigen, "", OT, Comp, NombreOT, Papel, "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioOrigen, IDT, 3);
                //                if (r != "")
                //                {
                //                    return new[] { "OK", r, "0" };
                //                }
                //                else
                //                {
                //                    return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                //                }
                //            }
                //            else
                //            {
                //                if ((Faltante - Cantidad) > 0)
                //                {

                //                    r = cp.IngresarPallet(FolioOrigen, "", OT, Comp, NombreOT, Papel, "Sin Marca", Gramaje, Ancho, Largo, Cantidad, Peso, Usuario, FolioOrigen, IDT, 2);
                //                    if (r != "")
                //                    {
                //                        return new[] { "OK", r, "0" };
                //                    }
                //                    else
                //                    {
                //                        return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                //                    }
                //                }
                //                else
                //                {
                //                    return new[] { "¡La Cantidad ingresada no puede ser mayor a la faltante!" };
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if (FAncho < Ancho || FLargo < Largo)
                //            {
                //                if (Tipo == "CERRAR" || ((Faltante - Cantidad) == 0))
                //                {

                //                    r = cc.CrearSolicitudCorte(OT, Comp, Papel, SKU, Gramaje, Ancho, Largo, FAncho, FLargo, Factor, Cantidad, Peso, Usuario, Folio, IDT, 1);
                //                    if (r != "")
                //                    {
                //                        return new[] { "OK", r, "1" };
                //                    }
                //                    else
                //                    {
                //                        return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                //                    }
                //                }
                //                else
                //                {

                //                    if ((Faltante - Cantidad) > 0)
                //                    {
                //                        r = cc.CrearSolicitudCorte(OT, Comp, Papel, SKU, Gramaje, Ancho, Largo, FAncho, FLargo, Factor, Cantidad, Peso, Usuario, Folio, IDT, 0);
                //                        if (r != "")
                //                        {
                //                            return new[] { "OK", r, "1" };
                //                        }
                //                        else
                //                        {
                //                            return new[] { "¡Error al Generar el Pallet, vuela a intentarlo!" };
                //                        }
                //                    }
                //                    else
                //                    {
                //                        return new[] { "¡La Cantidad ingresada no puede ser mayor a la faltante!" };
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                return new[] { "¡El Formato de corte no puede ser mayor a el formato del papel!" };//el formato de corte no puede ser mayor
                //            }
                //        }
                //    }
                //    #endregion
                //}
            }
            else
            {
                return new[] { "¡Debe ingrear todos los campos!" };//campos vacios
            }
        }



        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        [WebMethod]
        public static string CargarSKUSalida(string SKU, int Gramaje, int Ancho, int Largo,string Procedencia)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();

            List<BodegaPliegos> lista = new List<BodegaPliegos>();

            if (Procedencia.ToUpper() == "STOCK")
            {
                lista = c.ListaSKU(SKU, Gramaje, Ancho, Largo, 7);
            }
            else
            {
                lista = c.ListaSKU(SKU, Gramaje, Ancho, Largo, 6);
            }
            //2 con metrics, sin metrics 5
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
        public static string CargarSKU(string sku, int Ancho, int Largo)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            List<BodegaPliegos> lista = c.ListaSKU(sku, 0, Ancho, Largo, 0);
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
        public static string CargarSKUaSeleccionar(string sku, int Ancho, int Largo)
        {
            Controller_Dimensionadora c = new Controller_Dimensionadora();
            List<BodegaPliegos> lista = c.ListaSKU(sku, 0, Ancho, Largo, 5);//-1
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
        public static string[] CargarFaltantes(string IDTrabajo)
        {
            Controller_Cortadora cc = new Controller_Cortadora();
            BodegaPliegos d = cc.CargaFaltantesDimensionadora(IDTrabajo, "", 0);
            return new[] { d.Solicitada, d.Asignada, d.Faltante };
        }
        [WebMethod]
        public static string[] CargarFaltantesGuillotina(string IDTrabajo,string FolioOrigen)
        {
            Controller_Cortadora cc = new Controller_Cortadora();
            BodegaPliegos d = cc.CargaFaltantesDimensionadora(IDTrabajo,FolioOrigen, 1);
            return new[] { d.Solicitada, d.Asignada, d.Faltante };
        }

    }
}