<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecepcionOrdenCompraFactura.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.RecepcionOrdenCompraFactura" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <style type="text/css">
        
.divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    font-weight: bold;
    padding-top: 5px;
    padding-bottom: 5px;
    border: 1px solid #959595;
    text-align: left;
    color:#003e7e;
}
.divSeccion{
    padding-top: 10px;
    padding-bottom: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
}
        .style1
        {
            width: 79px;
        }
        .style2
        {
            width: 123px;
        }
        .style3
        {
            width: 146px;
        }
        .style4
        {
            width: 91px;
        }
        .style5
        {
            width: 91px;
            height: 23px;
        }
        .style6
        {
            width: 146px;
            height: 23px;
        }
        .style7
        {
            height: 23px;
        }
    </style>
    <script  type="text/javascript" language="javascript">
        $(document).ready(function () {
            document.getElementById("form1").onsubmit = function () {
                return false;
            }
            $("#ddlDocumento").change(function () {
                var select2 = document.getElementById("<%= ddlDocumento.ClientID %>");
                var docu = select2.options[select2.selectedIndex].text;
                document.getElementById("lblTipo1").innerHTML = docu + ':';
                document.getElementById("lblTipo2").innerHTML = docu + ':';
                document.getElementById("lblTipo3").innerHTML = docu + ':';
            });
            $("#txtPliegos").change(function () {
                CalculaKilos();
            });

        });
        function CalculaKilos() {
            var pliegos = eval(document.getElementById("<%= txtPliegos.ClientID%>").value);
            var Largo = eval(document.getElementById("lblLargo").innerHTML);
            var Gram = eval(document.getElementById("lblGramaje").innerHTML);
            var Anch = eval(document.getElementById("lblAncho").innerHTML);

            var calculapeso = 0;
            calculapeso = ((Gram * Largo * Anch) / 1000000000) * pliegos;
            document.getElementById("<%= txtPeso.ClientID%>").value = calculapeso.toFixed(2);
        }
        function CrearFactura() {
            var select2 = document.getElementById("<%= ddlDocumento.ClientID %>");
            var docu = select2.options[select2.selectedIndex].text;
            var oc = document.getElementById("lblNroOC").innerHTML;
            var item = document.getElementById("lblItem").innerHTML;
            var MaxRecepcion = document.getElementById("lblMaxRecep").innerHTML;
            var usuario = document.getElementById("lblUsuario").innerHTML;
            var factura = document.getElementById("<%= txtNroFactura.ClientID %>").value;
            var cantidad = document.getElementById("<%= txtCantidad.ClientID %>").value;
            var observacion = document.getElementById("<%= txtObservacion.ClientID %>").value;
            $.ajax({
                url: "RecepcionOrdenCompraFactura.aspx/CreaFactura",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OC':'" + oc + "','IDItem':'" + item + "','Documento':'"+docu+"','Factura':'" + factura + "','Cantidad':'" + eval(cantidad) + "','Observacion':'" + observacion + "','Usuario':'" + usuario + "','MaxCantidad':'" + eval(MaxRecepcion) + "'}",
                success: function (msg) {
                    if (msg.d[0] != '0') {

                        document.getElementById("lblNroFactura").innerHTML = factura;
                        document.getElementById("lblCantidad").innerHTML = cantidad;
                        document.getElementById("lblIDFactura").innerHTML = msg.d[0];

                        document.getElementById("divFactura").style.display = 'none';
                        document.getElementById("divPallets").style.display = 'block';
                    }
                    else {
                        alert(msg.d[1]);
                    }

                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function CrearPallet() {
            var OC = document.getElementById("lblNroOC").innerHTML;
            var idetalleOC = document.getElementById("lblItem").innerHTML;
            var docuLote = document.getElementById("lblIDFactura").innerHTML; 
            var CodigoItem = document.getElementById("lblSKU").innerHTML;
            var Papel = document.getElementById("lblPapel").innerHTML;
            var Gramaje = document.getElementById("lblGramaje").innerHTML;
            var Ancho = document.getElementById("lblAncho").innerHTML;
            var Largo = document.getElementById("lblLargo").innerHTML;
            var Cantidad = document.getElementById("<%= txtPliegos.ClientID %>").value;
            var Kilos = document.getElementById("<%= txtPeso.ClientID %>").value;
            var Costomedioingreso = '0';
            var CreadoPor = document.getElementById("lblUsuario").innerHTML;
            var faltante = document.getElementById("lblTotalFaltante").innerHTML;
            $.ajax({
                url: "RecepcionOrdenCompraFactura.aspx/IngresoaStock",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OC':'"+OC+"','idDetalleOC':'" + idetalleOC + "','DocumentoLote':'"+docuLote+"','CodigoItem':'" + CodigoItem + "','Papel':'" + Papel + "','Gramaje':'" + eval(Gramaje)
                + "','Ancho':'" + eval(Ancho) + "','Largo':'" + eval(Largo) + "','Cantidad':'" + eval(Cantidad) + "','Kilos':'" + eval(Kilos) + "','CostoMedioIngreso':'" + eval(Costomedioingreso)
                + "','CreadoPor':'" + CreadoPor + "','CantidadFaltante':'" + eval(faltante) + "'}",
                success: function (msg) {

                    if (msg.d[0] == 'Error') {
                        alert('No puede ingresar mas de lo recepcionado');
                    } else {
                        window.open('EtiquetaBP.aspx?Pro=0&Folio=' + msg.d[0], 'Impresion Pallet Bodega Pliegos', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
                        alert('¡Pallet Generado Correctamente!');
                        CargarFaltantes(idetalleOC);
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False"></asp:ToolkitScriptManager>
    <div id="divFactura" ><%--style="display:none;"--%>
    <div class="divTitulo">Recepcionar Factura</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label64" runat="server" Font-Bold="True" Text="Orden Compra:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblNroOC" runat="server"></asp:Label>
                    <asp:Label ID="lblItem" runat="server"></asp:Label>
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label63" runat="server" Text="Tipo Documento:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDocumento" runat="server" Width="173px">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                        <asp:ListItem>Guia</asp:ListItem>
                        <asp:ListItem>Factura</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Nro." Font-Bold="True"></asp:Label>
                &nbsp;<asp:Label ID="lblTipo1" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNroFactura" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Cant." Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="lblTipo2" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Label ID="Label4" runat="server" Text="(* Max. a Recepcionar: "></asp:Label>
                    <asp:Label ID="lblMaxRecep" runat="server" Text="0"></asp:Label>
&nbsp;<asp:Label ID="Label6" runat="server" Text="Pliegos)."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" Text="Observación:" Font-Bold="True"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtObservacion" runat="server" Height="74px" TextMode="MultiLine" 
                        Width="300px"></asp:TextBox>
                        <input id="Button3" type="button" value="Agregar Factura" onclick="javascript:CrearFactura();" style="width:120px;" />
                    </td>
            </tr>
            </table>
    </div>
    </div>
        <div id="divPallets"   ><%--style="display:none;"--%>
    <div class="divTitulo">Crear Pallets</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    </td>
                <td class="style6">
                    <asp:Label ID="Label60" runat="server" Font-Bold="True" Text="Nro."></asp:Label>
                &nbsp;<asp:Label ID="lblTipo3" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="lblNroFactura" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="lblIDFactura" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="lblIDItem" runat="server"></asp:Label>
                    <asp:Label ID="lblOC2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style6">
                    <asp:Label ID="lblppp" runat="server" Font-Bold="True" Text="Papel:"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="lblSKU" runat="server"></asp:Label>
&nbsp;
                    <asp:Label ID="lblPapel" runat="server"></asp:Label>
&nbsp;<asp:Label ID="lblGramaje" runat="server"></asp:Label>
                    <asp:Label ID="lblAncho" runat="server"></asp:Label>
                    <asp:Label ID="lblLargo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label62" runat="server" Font-Bold="True" Text="Cantidad:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCantidad" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label59" runat="server" Font-Bold="True" Text="SKU Entrada:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSKUSalida" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label24" runat="server" Text="Cantidad de Pliegos:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPliegos" runat="server" BackColor="Yellow"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label25" runat="server" Text="Peso Pliegos:" Font-Bold="True"></asp:Label>
                </td>22
                <td>
                    <asp:TextBox ID="txtPeso" runat="server" BackColor="Yellow"></asp:TextBox>
&nbsp;<asp:Label ID="Label26" runat="server" Text="KGs."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
     
                <div align="center">
        <input id="btnGuardar" type="button" value="Crear Pallet" onclick="javascript:CrearPallet();" style="width:182px;" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;        
         <input id="Button2" type="button" value="Nueva Solicitud" onclick="javascript:NuevaSolicitud();" style="width:182px;" />

               </div>
                  <br /><br />

               <div align="right" style="margin-left:500px;">
    <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:400px;">
  <tbody>
      <tr style="background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Cantidad Solicitada</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16"></td>

  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDespachado" runat="server">Total Recepcionado Factura:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblTotalSolicitado" runat="server">0</asp:Label>
&nbsp;<asp:Label ID="Label30" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server">Total Creado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblTotalCreado" runat="server">0</asp:Label>
&nbsp;<asp:Label ID="Label31" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        <asp:Label ID="Label32" runat="server" Text="Cantidad Faltante:"></asp:Label>
        </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblTotalFaltante" runat="server">0</asp:Label>
&nbsp;<asp:Label ID="Label33" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
    
  </tr>
</tbody></table>
</div>
        
    </div>

            <br />
    </div>
      <br />
        <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="Cerrar Ventana" /></div>

    </form>
</body>
</html>
