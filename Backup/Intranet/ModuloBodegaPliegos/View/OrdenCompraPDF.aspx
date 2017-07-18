<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdenCompraPDF.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.OrdenCompraPDF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .style1
        {
            width: 305px;
        }
        .style8
        {
            width: 237px;
        }
        .style12
        {
            height: 22px;
        }
        .style13
        {
            width: 237px;
            height: 22px;
        }
        .style15
        {
            height: 22px;
            width: 184px;
        }
        .style18
        {
            width: 210px;
        }
        .style19
        {
            height: 22px;
            width: 210px;
        }
        .style21
        {
            height: 21px;
        }
        .style23
        {
            width: 184px;
        }
        .style26
        {
            height: 21px;
            }
        .style27
        {
        }
        .style28
        {
            height: 21px;
            width: 83px;
        }
        .style29
        {
        }
        .style32
        {
            height: 21px;
            width: 110px;
        }
        .style33
        {
            width: 110px;
        }
        .style34
        {
            height: 20px;
            width: 110px;
        }
        .style35
        {
            height: 20px;
        }
        .style36
        {
            height: 20px;
            width: 83px;
        }
        .style37
        {
            height: 20px;
            }
        .style38
        {
            height: 23px;
        }
        </style>

</head>
<body>
    <form id="form1" runat="server">
<table style="width:100%;" border="0" > 
       <tr> 
           <td class="style1" align="left"> 
               <img height="109px" alt="Logo Quad" 
                   src="../../Images/Logo%20color%20lateral.jpg" width="252pt" /></td> 
           <td align="center"> 

               <table style="border:1px solid black;border-collapse:collapse;width:100%;" border="1">
                   <tr >
                       <td>
                           Orden de Compra</td>
                       <td>
                           Fecha Orden</td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           Condición de Pago</td>
                       <td>
                           Moneda</td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
               </table>

               </td> 
       </tr> 
   </table>
    <table style="width: 100%;">
        <tr>
            <td>
                <div>Enviar a: A Impresores S.A.</div>
                <div>direccion......</div>
            </td>
            <td>
                <div>Facturar a: A Impresores S.A.</div>
                <div>direccion......</div>
                <div>Rut:</div>
                <div>Telefono:</div>
            </td>
        </tr>
        </table>
<%--   <table> 
       <tr> 
           <td align="center" class="style24"> 
              <div style="font-weight: bold;font-size:15px;font-style:italic;">Orden de Compra N°   Request.QueryString[id]  </div> 
              <div align="right" style="font-size:7px;font-style:italic;">Emitida Por:   o.CreadoPor     Convert.ToDateTime(o.FechaCreacion).ToString(dd/MM/yyyy)  </div> 
           </td> 
       </tr> 
       </table> --%>



       <table style="width:100%;"> 
<tr> 
<td class="style32"><a style="font-weight: bold;font-size:9px;">  Proveedor:</a></td> 
<td class="style26"><a style="font-size:9px;">    o.Proveedor    </a></td> 
    <td class="style28" >&nbsp;</td> 
    <td class="style21" ><a style="font-size:9px;">   o.Rut   </a></td> 
</tr> 
<tr> 
<td class="style33" ><a style="font-weight: bold;font-size:9px;">  Direccion:</a></td> 
<td class="style27" ><a style="font-size:9px;">    o.Direccion    </a></td> 
    <td class="style29" colspan="2" >&nbsp;</td> 
</tr> 
<tr> 
<td class="style33" ><a style="font-weight: bold;font-size:9px;">  Rut:</a></td> 
<td class="style27" >&nbsp;</td> 
    <td class="style29" >&nbsp;</td> 
    <td >&nbsp;</td> 
</tr> 
<tr> 
<td class="style34" ><a style="font-weight: bold;font-size:9px;">  Contacto:</a></td> 
<td class="style37" ><a style="font-size:9px;">    o.Contacto    </a></td> 
    <td class="style36" ><a style="font-weight: bold;font-size:9px;">  Correo:</a></td> 
    <td class="style35" ><a style="font-size:9px;">    o.Email    </a></td> 
</tr> 
<tr> 
<td class="style33" ><a style="font-weight: bold;font-size:9px;">  Telefono:</a></td> 
<td class="style27" ><a style="font-size:9px;">    o.Telefono    </a></td> 
    <td class="style29" ><a style="font-weight: bold;font-size:9px;">  Fecha de Entrega:</a></td> 
    <td ><a style="font-size:9px;">    Convert.ToDateTime(o.FechaEntrega).ToString(dd/MM/yyyy)    </a></td> 
</tr>  
</table>  
<br />
                <table style="border:1px solid black;border-collapse:collapse;width:100%;" border="1"> 
                <tr> 
                <th style="border:1px solid black;" class="style23">Descripcion</th> 
                    <th style="border:1px solid black;" class="style8">Cantidad</th> 
                    <th style="border:1px solid black;" class="style18">Precio</th> 
                    <th style="border:1px solid black;">Total</th> 
                </tr> 
                <tr> 
                <td style="border:1px solid black;" class="style15">Table cell 1</td> 
                    <td style="border:1px solid black;" class="style13">Table cell 2</td> 
                    <td style="border:1px solid black;" class="style19"></td> 
                    <td style="border:1px solid black;" class="style12"></td> 
                </tr> 
                <tr> 
                <td style="border:1px solid black;" class="style23">Table cell 3</td> 
                    <td style="border:1px solid black;" class="style8">Table cell 4</td> 
                    <td style="border:1px solid black;" class="style18">&nbsp;</td> 
                    <td style="border:1px solid black;">&nbsp;</td> 
                </tr> 
                </table>
                <br />
        <a style="font-size:9px;">ANOTAR EN GUIA/FACTURA LOS NÚMEROS DE ORDEN DE COMPRA</a><br /><br /> 
        <br /> 

   <table style="border:1px solid black;border-collapse:collapse;width:100%;" border="1">
                   <tr >
                       <td>
                           <div>Observación:</div>
                           <div>asdadsdsaasdasd</div>
                           <br />
                           </td>
                   </tr>
               </table>       
        <br />
        <br />
        <br />
               <div align="center"> 
                  __________________________<br /> 
                  <a style="font-weight: bold;font-size:9px;"> 
                  Rafael Maroto<br /> 
                  Sub-Gerente de Abastecimiento 
                  </a></div>
                  <br />

                   <a style="font-size:9px;">UNA VEZ QUE EL MATERIAL Y/O SERVICIO HAYA SIDO ENTREGADO Y REALIZADO, LAS FACTURAS ELECTRONICAS DEBEN SER ENVIADAS POR CORREO ELECTRÓNICO A: HAROLDO.RIOS@QGCHILE.CL; MARCELO.ROMERO@QGCHILE.CL</a>
<table style='width:100%;'> 
<tr>  
<td class='style32'><a style='font-weight: bold;font-size:9px;'>  Proveedor:</a></td>  
<td class='style26'><a style='font-size:9px;' > FERROSTAL CHILE S.A.C </a></td>  
    <td class='style28' >&nbsp;</td>  
    <td class='style21' ><a style='font-size:9px;'>   &nbsp;</a></td>  
    <td class='style21' >&nbsp;</td>  
</tr>  
<tr>  
<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Direccion:</a></td>  
<td class='style27' ><a style='font-size:9px;'> AV. SANTA MARIA 2810, SANTIAGO </a></td>  
    <td class='style29' >&nbsp;</td>  
    <td >&nbsp;</td>  
    <td >&nbsp;</td>  
</tr>  
<tr>  
<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Rut:</a></td>  
<td class='style27' >91336000-1</td>  
    <td class='style29' >&nbsp;</td>  
    <td >&nbsp;</td>  
    <td >&nbsp;</td>  
</tr>  
<tr>  
<td class='style34' ><a style='font-weight: bold;font-size:9px;'>  Contacto:</a></td>  
<td class='style37' ><a style='font-size:9px;'> ANDRES GALLARDO </a></td>  
    <td class='style36' ><a style='font-weight: bold;font-size:9px;'>  Correo:</a></td>  
    <td class='style35' colspan="2" ><a style='font-size:9px;align'>   andres.gallardo@ferrostaal.com  </a></td>  
</tr>  
<tr>  
<td class='style33' ><a style='font-weight: bold;font-size:9px;'>  Telefono:</a></td>  
<td class='style27' ><a style='font-size:9px;'>   22372020   </a></td>  
    <td class='style29' ><a style='font-weight: bold;font-size:9px;'>  Fecha de Entrega:</a></td>  
    <td ><a style='font-size:9px;'> 17/03/2016  </a></td>  
    <td >&nbsp;</td>  
</tr>   
</table>   
    </form>
    <table style="width:100%;">
        <tr>
            <td class="style38">
                Proveedor</td>
            <td class="style38" colspan="4">
                FERROSTAL CHILE S.A.C</td>
            <td class="style38">
                </td>
        </tr>
        <tr>
            <td class="style38">
                Direccion</td>
            <td class="style38" colspan="4">
                AV. SANTA MARIA 2810, SANTIAGO</td>
            <td class="style38">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style38">
                Contacto</td>
            <td class="style38" colspan="3">
                ANDRES GALLARDO</td>
            <td class="style38">
                Correo:</td>
            <td class="style38" colspan="3">
                andres.gallardo@ferrostaal.com</td>
        </tr>
    </table>
    </table> 
               
                  <br />
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td>
                            valor</td>
                        <td>
                            12</td>
                    </tr>
                    <tr>
                        <td>
                            iva</td>
                        <td>
                            15</td>
                    </tr>
                    <tr>
                        <td>
                            total</td>
                        <td>
                            27</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
