using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using Intranet.ModuloBodegaPliegos.Controller;
using Intranet.ModuloBodegaPliegos.Model;

namespace Intranet.ModuloBodegaPliegos.View
{
    public partial class OrdenCompraPDF : System.Web.UI.Page
    {
        Controller_OrdenCompra oc = new Controller_OrdenCompra();
        protected void Page_Load(object sender, EventArgs e)
        {

            OrdenesCompra o = oc.GeneraPDF(Request.QueryString["id"], "", 7);
            string contenido ="<div align='right' style='font-weight: bold;font-size:10px;'>Orden de Compra</div>" + "<table style='width:100%;' border='0' >" +
       "<tr>"+
           "<td class='style1' align='left'>"+
                "<img height='95px' alt='Logo AImpresores'" +
                   "src='http://intranet.qgchile.cl/Images/LOGO%20A.png' width='240px' ></td>" +
           "<td align='center'>"+
               "<table style='border:1px solid black;border-collapse:collapse;width:100%;' border='1'>"+
                   "<tr >"+
                       "<td align='center' style='font-size:9px;'>" +
                           "Orden de Compra</td>" +
                       "<td align='center' style='font-size:9px;'>" +
                           "Fecha Orden</td>" +
                   "</tr>"+
                   "<tr>"+
                       "<td align='center' style='font-weight: bold;font-size:9px;'>" +
                           o.NroOC + "</td>" +
                       "<td align='center' style='font-weight: bold;font-size:9px;'>" +
                            Convert.ToDateTime(o.FechaCreacion).ToString("dd/MM/yyyy")+ "</td>" +
                   "</tr>"+
                   "<tr>"+
                       "<td align='center' style='font-size:9px;'>" +
                           "Condición de Pago</td>" +
                       "<td align='center' style='font-size:9px;'>" +
                           "Moneda</td>" +
                   "</tr>"+
                   "<tr>"+
                       "<td align='center' style='font-weight: bold;font-size:9px;'>" +
                           o.CondicionPago+"</td>" +
                       "<td align='center' style='font-weight: bold;font-size:9px;'>" +
                           o.Moneda+"</td>" +
                   "</tr>"+
                    "<tr>" +
                       "<td colspan='2' align='right' style='font-weight: bold;font-size:8px;'>" +
                           "Generado Por: "+o.CreadoPor +" "+Convert.ToDateTime(o.FechaCreacion).ToString("dd/MM/yyyy HH:mm")+"</td>" +
                   "</tr>" +
               "</table>"+
               "</td>"+ 
       "</tr>"+ 
   "</table>"+
    "<table style='width: 100%;'>"+
        "<tr>"+
            "<td>"+
                "<div><a style='font-weight: bold;font-size:11px;'>Enviar a: A Impresores S.A.</a></div>" +
                "<div><a style='font-size:11px;'>Avda. Las Parcelas, No 4568, Estación Central<br />Santiago, Chile.</a></div>" +
            "</td>"+
            "<td>"+
                "<div><a style='font-weight: bold;font-size:11px;'>Facturar a: A Impresores S.A.</a></div>" +
                "<div><a style='font-size:11px;'>Avda. Gladys Marin No 6920, Estación Central<br />Santiago, Chile.</a></div>" +
                "<div><a style='font-size:11px;'>R.U.T.: 96830710-k</a></div>" +
                "<div><a style='font-size:11px;'>Tel: 4405700</a></div>" +
            "</td>"+
        "</tr>"+
        "</table>"+

//        "<table style='width:100%;'> " +
//"<tr>" +
//"<td class='style32'><a style='font-weight: bold;font-size:9px;'>  Proveedor:</a></td>" +
//"<td class='style26'><a style='font-size:9px;' > FERROSTAL CHILE S.A.C </a></td>  " +
//    "<td class='style28' >&nbsp;</td>  " +
//    "<td class='style21' ><a style='font-size:9px;'>   &nbsp;</a></td>  " +
//"</tr>  " +
//"<tr>  " +
//"<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Direccion:</a></td>  " +
//"<td class='style27' ><a style='font-size:9px;'> AV. SANTA MARIA 2810, SANTIAGO </a></td>  " +
//    "<td class='style29' >&nbsp;</td>  " +
//    "<td >&nbsp;</td>  " +
//"</tr>  " +
//"<tr>  " +
//"<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Rut:</a></td>  " +
//"<td class='style27' >91336000-1</td>  " +
//    "<td  >&nbsp;</td>  " +
//    "<td colspan='2'>&nbsp;</td>  " +
//"</tr>  " +
//"<tr>  " +
//"<td class='style34' ><a style='font-weight: bold;font-size:9px;'>  Contacto:</a></td>  " +
//"<td colspan='2' ><a style='font-size:9px;'> ANDRES GALLARDO </a></td>  " +
//    "<td class='style36' ><a style='font-weight: bold;font-size:9px;'>  Correo:</a></td>  " +
//    "<td colspan='2' ><a style='font-size:9px;'>   andres.gallardo@ferrostaal.com  </a></td>  " +
//"</tr>  " +
//"<tr>  " +
//"<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Telefono:</a></td>  " +
//"<td colspan='2' ><a style='font-size:9px;'>   22372020   </a></td>  " +
//    "<td class='style29' ><a style='font-weight: bold;font-size:9px;'>  Fecha de Entrega:</a></td>  " +
//    "<td colspan='2'><a style='font-size:9px;'> 17/03/2016  </a></td>  " +
//"</tr>   " +
//"</table>  " +
       "<br /><table style='width:100%;'>" +
       "<tr> " +
"<td class='style32'><a style='font-weight: bold;font-size:10px;'>  Rut:</a></td> " +
"<td class='style26' colspan='3'><a style='font-size:10px;' >" + o.Rut + "</a></td> " +

   "</tr> " +
"<tr> " +
"<td class='style32'><a style='font-weight: bold;font-size:10px;'>  Proveedor:</a></td> " +
"<td class='style26' colspan='3'><a style='font-size:10px;' >" + o.Proveedor.ToUpper() + "</a></td> " +
                // "<td class='style28' >&nbsp;</td> " +
                //"<td class='style21' ><a style='font-size:9px;'>   o.Rut   </a></td> " +
   "</tr> " +
   "<tr> " +
   "<td class='style33' ><a style='font-weight: bold;font-size:10px;'>  Direccion:</a></td> " +
   "<td class='style27' colspan='3'><a style='font-size:10px;'>"+o.Direccion.ToUpper()+"</a></td> " +
                //"<td class='style29' >&nbsp;</td> " +
                //"<td >&nbsp;</td> " +
   "</tr> " +
                //"<tr> " +
                //"<td class='style33' ><a style='font-weight: bold;font-size:10px;'>  Rut:</a></td> " +
                //"<td class='style27' ><a style='font-size:10px;'>91336000-1</a></td> " +
                //    "<td class='style29' >&nbsp;</td>" +
                //    "<td >&nbsp;</td> " +
                //"</tr> " +
   "<tr> " +
   "<td class='style34' ><a style='font-weight: bold;font-size:10px;'>  Contacto:</a></td> " +
   "<td class='style37' ><a style='font-size:10px;'>"+o.Contacto+"</a></td> " +
       "<td class='style36' ><a style='font-weight: bold;font-size:10px;'>  Correo:</a></td> " +
       "<td class='style35' ><a style='font-size:8px;'>"+o.Email+"</a></td> " +
   "</tr> " +
   "<tr> " +
   "<td class='style33' ><a style='font-weight: bold;font-size:10px;'>  Telefono:</a></td> " +
   "<td class='style27' ><a style='font-size:10px;'>"+o.Telefono+"</a></td> " +
       "<td class='style29' ><a style='font-weight: bold;font-size:10px;'>  Fecha de Entrega:</a></td> " +
       "<td ><a style='font-size:10px;'>"+Convert.ToDateTime(o.FechaEntrega).ToString("dd/MM/yyyy")+"</a></td> " +
   "</tr>  " +
   "</table>  " +
                   oc.GeneraItemsPDF(Request.QueryString["id"], "", 8) +
    "<table style='width:100%;'>" +
           " <tr>" +
              "  <td>" +
               "     &nbsp;</td>" +
                "<td>" +
   "   <table style='width:100%;'>" +
                  "      <tr>" +
                   "         <td align='right'>" +
                    "           <a style='font-size:9px;'> Subtotal:</a></td>" +
                     "       <td align='right'>" +
                      "         <a style='font-size:9px;'>"+o.Unidad+" $ "+Convert.ToDouble(o.ValorTotal).ToString("N2")+"</a></td>" +
                       " </tr>" +
                        "<tr>" +
                         "   <td align='right'>" +
                          "     <a style='font-size:9px;'> I.V.A.:</a></td>" +
                           " <td align='right'>" +
                            "    <a style='font-size:9px;'>" + o.Unidad + " $ " + Convert.ToDouble(o.ValorIVA).ToString("N2") + "</a></td>" +
                        "</tr>" +
                        "<tr>" +
                          "  <td align='right'>" +
                           "     <a style='font-weight: bold;font-size:9px;'> Total:</a></td>" +
                            "<td align='right'>" +
                             "   <a style='font-weight: bold;font-size:9px;'>" + o.Unidad + " $ " + Convert.ToDouble(o.ValorTotalConIVA).ToString("N2") + "</a></td>" +
                        "</tr>" +
                    "</table>" +
                "</td>" +
            "</tr>" +
        "</table>" +
                //       "<table>"+
                //        "<tr>"+
                //         "<td>"+
                //         "       &nbsp;</td>"+
                //          "  <td>"+
                //"                    <div>Valor</div>"+
                //"                    <div>Valor</div>" +
                //"                    <div>Valor</div>" +

   //          "</td>"+
                //      //     "    <table style='font-size:12px;' border='1'> "+
                //      // "<tr> "+
                //      //  "   <td> "+
                //      //   "     <div align='center' style='font-weight: bold;font-size:9px;'>Valor</div> "+
                //      //    "     </td> "+
                //      //    " <td> "+
                //      //     "   <div align='right' style='font-size:9px;'>  10.000.000,00  </div></td> "+
                //      // "</tr> "+
                //      // "<tr> "+
                //      // "    <td> "+
                //      // "        <div align='center' style='font-weight: bold;font-size:9px;'>I.V.A</div></td> "+
                //      // "    <td> "+
                //      // "       <div align='right' style='font-size:9px;'>  1.900.000,00 </div></td> "+
                //      //" </tr> "+
                //      //" <tr> "+
                //      //"     <td> "+
                //      //"         <div align='center' style='font-weight: bold;font-size:9px;'>Total</div></td> "+
                //      //"     <td> "+
                //      //"         <div align='right' style='font-size:9px;'>  11.900.000,00  </div></td> "+
                //      //" </tr></table> </td>"+
                //      "  </tr>"+
                //    "</table>" +
                //"<table style='border:1px solid black;border-collapse:collapse;width:100%;' border='1'> "+ 
                //"<tr> "+ 
                //"<th style='border:1px solid black;' class='style23'>Descripcion</th> "+ 
                //    "<th style='border:1px solid black;' class='style8'>Cantidad</th> "+ 
                //    "<th style='border:1px solid black;' class='style18'>Precio</th> "+ 
                //    "<th style='border:1px solid black;'>Total</th> "+ 
                //"</tr> "+ 
                //"<tr> "+ 
                //"<td style='border:1px solid black;' class='style15'>Table cell 1</td> "+ 
                //    "<td style='border:1px solid black;' class='style13'>Table cell 2</td>"+  
                //    "<td style='border:1px solid black;' class='style19'></td> "+ 
                //    "<td style='border:1px solid black;' class='style12'></td> "+ 
                //"</tr> "+ 
                //"<tr> "+ 
                //"<td style='border:1px solid black;' class='style23'>Table cell 3</td> "+ 
                //    "<td style='border:1px solid black;' class='style8'>Table cell 4</td> "+ 
                //    "<td style='border:1px solid black;' class='style18'>&nbsp;</td> "+ 
                //    "<td style='border:1px solid black;'>&nbsp;</td> "+ 
                //"</tr> "+ 
                //"</table>"+ 

           "<a style='font-size:10px;'>ANOTAR EN GUIA/FACTURA LOS NÚMEROS DE ORDEN DE COMPRA</a><br /><br />" +


      "<table style='border:1px solid black;border-collapse:collapse;width:100%;' border='1'>" +
                      "<tr >" +
                          "<td>" +
                              "<div><a style='font-weight: bold;font-size:9px;'>Observación:</a></div>" +
                              "<div><a style='font-size:9px;'>"+ o.Observacion+"</a></div>" +
                              "<br />" +
                              "</td>" +
                      "</tr>" +
                  "</table>    " +
           "<br />" +
           "<div align='center'> __________________________<br /> " +
                     "<a style='font-weight: bold;font-size:9px;'> " +
                     "Rafael Maroto<br /> " +
                     "Sub-Gerente de Abastecimiento " +
                     "</a></div>" +
                     "<br />" +

                      "<a style='font-weight: bold;font-size:8px;'>UNA VEZ QUE EL MATERIAL Y/O SERVICIO HAYA SIDO ENTREGADO Y REALIZADO, LAS FACTURAS ELECTRONICAS DEBEN SER ENVIADAS POR CORREO ELECTRÓNICO A: HAROLDO.RIOS@QGCHILE.CL; MARCELO.ROMERO@QGCHILE.CL</a>";
//            string contenido = "<table style='width:100%;' border='0' >" +
//       "<tr>" +
//           "<td class='style1' align='left'>" +
//               "<img height='109px' alt='Logo Quad' src='http://falabella.qgchile.cl/images/quadlogo.PNG' width='252px' /></td>" +
//           "<td align='center'>" +
//                              "<div style='font-weight: bold;font-size:18px;'>QUAD/GRAPHICS CHILE S.A.</div>" +
//               "<div style='font-size:8px;'>Av. Gladys Marín Millie 6920, Estación Central, Santiago de Chile" +
//               "<br />" +
//                   "Teléfono: 4405700 / Fax: 4405890<br />" +
//                   "Rut: 96.830.710-k" +
//               "<br /> <br /></div>" +
//               "</td>" +
//       "</tr>" +
//   "</table>" +

//   "<table>" +
//       "<tr>" +
//           "<td align='center' class='style24'>" +
//              "<div style='font-weight: bold;font-size:15px;font-style:italic;'>Orden de Compra N° " + Request.QueryString["id"] + "</div>" +
//              "<div align='right' style='font-size:7px;font-style:italic;'>Emitida Por: " + o.CreadoPor + " " + Convert.ToDateTime(o.FechaCreacion).ToString("dd/MM/yyyy") + "</div>" +
//           "</td>" +
//       "</tr>" +
//       "</table>" +


//        "<a>______________________________________________________________________________</a>" +

////"<table style='width:100%;'>" +
//                //"<tr>" +
//                //"<td class='style32'><a style='font-weight: bold;font-size:9px;'>  Proveedor</a></td>" +
//                //"<td class='style26'><a style='font-size:9px;'>" + o.Proveedor + "</a></td>" +
//                //    "<td class='style28' ><a style='font-weight: bold;font-size:9px;'>  Rut</a></td>" +
//                //    "<td class='style21' ><a style='font-size:9px;'>" + o.Rut + "</a></td>" +
//                //"</tr>" +
//                //"<tr>" +
//                //"<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Direccion</a></td>" +
//                //"<td class='style27' ><a style='font-size:9px;'>" + o.Direccion + "</a></td>" +
//                //    "<td class='style29' >&nbsp;</td>" +
//                //    "<td >&nbsp;</td>" +
//                //"</tr>" +
//                //"<tr>" +
//                //"<td class='style33' >&nbsp;</td>" +
//                //"<td class='style27' >&nbsp;</td>" +
//                //    "<td class='style29' >&nbsp;</td>" +
//                //    "<td >&nbsp;</td>" +
//                //"</tr>" +
//                //"<tr>" +
//                //"<td class='style34' ><a style='font-weight: bold;font-size:9px;'>  Contacto</a></td>" +
//                //"<td class='style37' ><a style='font-size:9px;'>" + o.Contacto + "</a></td>" +
//                //    "<td class='style36' ></td>" +
//                //    "<td class='style35' ></td>" +
//                //"</tr>" +
//                //"<tr>" +
//                //"<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Telefono</a></td>" +
//                //"<td class='style27' ><a style='font-size:9px;'>" + o.Telefono + "</a></td>" +
//                //    "<td class='style29' ><a style='font-weight: bold;font-size:9px;'>  Correo</a></td>" +
//                //    "<td ><a style='font-size:9px;'>" + o.Email + "</a></td>" +
//                //"</tr>" +
//                //"</table>" +
//       "<table style='width:100%;'>" +
//"<tr>" +
//"<td class='style32'><a style='font-weight: bold;font-size:9px;'>  Proveedor:</a></td>" +
//"<td class='style26' colspan='2'><a style='font-size:9px;'>  " + o.Proveedor + "  </a></td>" +
//    "<td class='style28' ><a style='font-weight: bold;font-size:9px;'>  Rut:</a></td>" +
//    "<td class='style21' ><a style='font-size:9px;'> " + o.Rut + " </a></td>" +
//"</tr>" +
//"<tr>" +
//"<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Direccion:</a></td>" +
//"<td class='style27' colspan='2' ><a style='font-size:9px;'>  " + o.Direccion + "  </a></td>" +
//    "<td class='style29' >&nbsp;</td>" +
//    "<td >&nbsp;</td>" +
//"</tr>" +
//"<tr>" +
//"<td class='style33' >&nbsp;</td>" +
//"<td class='style27' >&nbsp;</td>" +
//"<td class='style27' >&nbsp;</td>" +
//    "<td class='style29' >&nbsp;</td>" +
//    "<td >&nbsp;</td>" +
//"</tr>" +
//"<tr>" +
//"<td class='style34' ><a style='font-weight: bold;font-size:9px;'>  Contacto:</a></td>" +
//"<td class='style37' colspan='2' ><a style='font-size:9px;'>  " + o.Contacto + "  </a></td>" +
//    "<td class='style36' ><a style='font-weight: bold;font-size:9px;'>  Correo:</a></td>" +
//    "<td class='style35' ><a style='font-size:9px;'>  " + o.Email + "  </a></td>" +
//"</tr>" +
//"<tr>" +
//"<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Telefono:</a></td>" +
//"<td class='style27' colspan='2' ><a style='font-size:9px;'>  " + o.Telefono + "  </a></td>" +
//    "<td class='style29' ><a style='font-weight: bold;font-size:9px;'>  Fecha de Entrega:</a></td>" +
//    "<td ><a style='font-size:9px;'>  " + Convert.ToDateTime(o.FechaEntrega).ToString("dd/MM/yyyy") + "  </a></td>" +
//"</tr> " +
//"</table> " +
//"<a>______________________________________________________________________________</a>" +



//        "<a style='font-size:9px;'>Solicitamos despachar lo siguiente:</a><br /><br />" +

////        "<table style='border:1px solid black;border-collapse:collapse;width:100%;' border='1'>" +
//                //"<tr>" +
//                //"<th style='border:1px solid black;' class='style23'>Descripcion</th>" +
//                //    "<th style='border:1px solid black;' class='style8'>Cantidad</th>" +
//                //    "<th style='border:1px solid black;' class='style18'>Precio</th>" +
//                //    "<th style='border:1px solid black;'>Total</th>" +
//                //"</tr>" +
//                //"<tr>" +
//                //"<td style='border:1px solid black;' class='style15'>Table cell 1</td>" +
//                //    "<td style='border:1px solid black;' class='style13'>Table cell 2</td>" +
//                //    "<td style='border:1px solid black;' class='style19'></td>" +
//                //    "<td style='border:1px solid black;' class='style12'></td>" +
//                //"</tr>" +
//                //"<tr>" +
//                //"<td style='border:1px solid black;' class='style23'>Table cell 3</td>" +
//                //    "<td style='border:1px solid black;' class='style8'>Table cell 4</td>" +
//                //    "<td style='border:1px solid black;' class='style18'>&nbsp;</td>" +
//                //    "<td style='border:1px solid black;'>&nbsp;</td>" +
//                //"</tr>" +
//                //"</table>"+
//oc.GeneraItemsPDF(Request.QueryString["id"], "", 8) +
//        "<br />" +
//   "<table style='width:100%;' align='center'>" +
//       "<tr>" +
//           "<td align='center' class='style20'>" +



//           "<table style='width:100%;font-size:12px;margin-top:-50px;' border='1'>" +
//       "<tr>" +
//           "<td>" +
//               "<div align='center' style='font-weight: bold;font-size:9px;'>Observacion</div>" +

//               "</td>" +

//       "</tr>" +
//       "<tr>" +
//          "<td  >" +
//               "<div align='center'><a style='font-size:9px;'>" +
//               o.Observacion +
//               "</a></div><br /></td>" +

//       "</tr>" +
//        "</table>" +
//               "</td>" +
//           "<td >" +
//                  "<br /><table style='width:50%;font-size:12px;' border='1'>" +
//       "<tr>" +
//           "<td>" +
//              "<div align='center' style='font-weight: bold;font-size:9px;'>Valor</div>" +

//               "</td>" +
//           "<td>" +
//              "<div align='right' style='font-size:9px;'>" + Convert.ToDouble(o.ValorTotal).ToString("N2") + "</div></td>" +
//       "</tr>" +
//       "<tr>" +
//           "<td>" +
//               "<div align='center' style='font-weight: bold;font-size:9px;'>I.V.A</div></td>" +
//           "<td>" +
//              "<div align='right' style='font-size:9px;'>" + Convert.ToDouble(o.ValorIVA).ToString("N2") + "</div></td>" +
//       "</tr>" +
//       "<tr>" +
//           "<td>" +
//               "<div align='center' style='font-weight: bold;font-size:9px;'>Total</div></td>" +
//           "<td>" +
//               "<div align='right' style='font-size:9px;'>" + Convert.ToDouble(o.ValorTotalConIVA).ToString("N2") + "</div></td>" +
//       "</tr></table>" +
//                  "<br />" +
//                  "<br />" +
//                  "<br /><div align='center'>" +
//                  "__________________________<br />" +
//                  "<a style='font-weight: bold;font-size:9px;'>" +
//                  "V°B°<br />" +
//                  "Rafael Maroto<br />" +
//                  "Gerente de Abastecimiento" +
//                  "</a></div>" +
//                  "</td>" +
//       "</tr>" +
//   "</table>";
     
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(Request.PhysicalApplicationPath + "PDF\\" + Request.QueryString["id"] + ".pdf", FileMode.Create));
            document.Open();
            iTextSharp.text.html.simpleparser.HTMLWorker hw =
                         new iTextSharp.text.html.simpleparser.HTMLWorker(document);
            hw.Parse(new StringReader(contenido));
            document.Close();

                Response.Redirect("../../PDF/" + Request.QueryString["id"] + ".pdf");
            
            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment; filename=MySamplePDF");
            //Response.WriteFile(Request.PhysicalApplicationPath + "\\MySamplePDF.pdf");
            //Response.End();
        }
        }
    }
