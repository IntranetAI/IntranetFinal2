<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="RecepcionOrdenCompra.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.RecepcionOrdenCompra" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    .style2
    {
        width: 61px;
    }
    .style3
    {
        width: 304px;
    }
    .style4
    {
        width: 187px;
    }
    .style5
    {
    }
    .style6
    {
        width: 134px;
    }
    .style7
    {
        width: 412px;
    }
    .style8
    {
        width: 194px;
    }
    .style9
    {
        width: 61px;
        height: 23px;
    }
    .style10
    {
        height: 23px;
    }
    .style11
    {
        width: 264px;
        height: 23px;
    }
    .style12
    {
        width: 134px;
        height: 23px;
    }
    .style13
    {
        height: 23px;
    }
</style>
    <script  type="text/javascript" language="javascript">
        $(document).ready(function () {
            document.getElementById("form1").onsubmit = function () {
                return false;
            }
        });
        function Procesar(idItem) {
            $.ajax({
                url: "RecepcionOrdenCompra.aspx/CargaItemCompra",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'idItem':'" + idItem + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblidDetalleOC").innerHTML = idItem;
                    document.getElementById("ContentPlaceHolder1_lblOC").innerHTML = msg.d[0];
                    document.getElementById("ContentPlaceHolder1_lblSKU").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblSKUSalida").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML = msg.d[2];
                    document.getElementById("ContentPlaceHolder1_lblPliegosSolicitados").innerHTML = msg.d[3];
                    document.getElementById("ContentPlaceHolder1_lblKilosSolicitados").innerHTML = msg.d[4];
                    document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML = msg.d[5];
                    document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML = msg.d[6];
                    document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML = msg.d[7];
                    document.getElementById("ContentPlaceHolder1_lblValorUnitario").innerHTML = msg.d[12];
                    document.getElementById("ContentPlaceHolder1_lblIDItem").innerHTML = idItem;


                    if (msg.d[8] != '0') {
                        document.getElementById("ContentPlaceHolder1_txtPliegosEntregados").value = msg.d[9];
                        document.getElementById("ContentPlaceHolder1_lblKilosEntregados").innerHTML = msg.d[10];
                        document.getElementById("ContentPlaceHolder1_txtObservacion").value = msg.d[11];
                        document.getElementById("ContentPlaceHolder1_txtPliegosEntregados").disabled = 'disabled';
                        document.getElementById("ContentPlaceHolder1_txtObservacion").disabled = 'disabled';
                        document.getElementById("btnGuardar2").style.display = 'none';
                    }
                    CargarFaltantes(idItem);
                    Habilitar();
                    CargaFacturasCreadas();
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function CargarFaltantes(idItem) {
            $.ajax({
                url: "RecepcionOrdenCompra.aspx/CargarFaltantes",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'idItem':'" + idItem + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'ERROR') {
                       
                    } else {
                        document.getElementById("ContentPlaceHolder1_lblTotalSolicitado").innerHTML = msg.d[1];
                        document.getElementById("ContentPlaceHolder1_lblTotalCreado").innerHTML = msg.d[0];
                        document.getElementById("ContentPlaceHolder1_lblTotalFaltante").innerHTML = msg.d[2];
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function CargarFaltantes2() {
            var idItem = document.getElementById("ContentPlaceHolder1_lblIDItem").innerHTML;
            $.ajax({
                url: "RecepcionOrdenCompra.aspx/CargarFaltantes",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'idItem':'" + idItem + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'ERROR') {
                       
                    } else {
                        document.getElementById("ContentPlaceHolder1_lblTotalSolicitado").innerHTML = msg.d[0];
                        document.getElementById("ContentPlaceHolder1_lblTotalCreado").innerHTML = msg.d[1];
                        document.getElementById("ContentPlaceHolder1_lblTotalFaltante").innerHTML = msg.d[2];
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function SincronizarFaltantes() {
            CargarFaltantes2();
        }
        setInterval("SincronizarFaltantes()", 1000); //1080000
        function RecepcionarFactura() {
            var CreadoPor = '<%= Session["Usuario"] %>';
            var OC = document.getElementById("ContentPlaceHolder1_lblOC").innerHTML;
            var idit = document.getElementById("ContentPlaceHolder1_lblIDItem").innerHTML
            var Papel = document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML;
            var Gramaje = document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML;
            var Ancho = document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML;
            var Largo = document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML;
            var CodigoItem = document.getElementById("ContentPlaceHolder1_lblSKU").innerHTML;
            window.open('RecepcionOrdenCompraFactura.aspx?oc=' + OC + '&usu=' + CreadoPor + '&item=' + idit + '&Papel=' + Papel + '&Gramaje=' + Gramaje + '&Ancho=' + Ancho + '&Largo=' + Largo + '&Sku=' + CodigoItem, 'Agregar Factura', 'left=100,top=100,width=1115 ,height=791,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
        function CrearPallet() {
            var idetalleOC = document.getElementById("ContentPlaceHolder1_lblidDetalleOC").innerHTML;
            var CodigoItem = document.getElementById("ContentPlaceHolder1_lblSKU").innerHTML;
            var Papel = document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML;
            var Gramaje = document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML;
            var Ancho = document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML;
            var Largo = document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML;
            var Cantidad = document.getElementById("<%= txtPliegos.ClientID %>").value;
            var Kilos = document.getElementById("<%= txtPeso.ClientID %>").value;
            var Costomedioingreso = document.getElementById("ContentPlaceHolder1_lblValorUnitario").innerHTML;
            var CreadoPor = '<%= Session["Usuario"] %>';
            var faltante = document.getElementById("ContentPlaceHolder1_lblTotalFaltante").innerHTML;

            $.ajax({
                url: "RecepcionOrdenCompra.aspx/IngresoaStock",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'idDetalleOC':'" + idetalleOC + "','CodigoItem':'" + CodigoItem + "','Papel':'" + Papel + "','Gramaje':'" + eval(Gramaje)
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
        function CargaFacturasCreadas() {
            var idItem = document.getElementById("ContentPlaceHolder1_lblIDItem").innerHTML;
            var OC = document.getElementById("ContentPlaceHolder1_lblOC").innerHTML;
            $.ajax({
                url: "RecepcionOrdenCompra.aspx/CargaFacturas",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDItem':'" + idItem + "','OC':'" + OC + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblFacturas").innerHTML = msg.d;
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function Habilitar() {

            document.getElementById("divDatosSolicitud").style.display = 'block';
            document.getElementById("divSolicitudesCortadora").style.display = 'none'; 
        }
        function NuevaSolicitud() {
            location.href = 'RecepcionOrdenCompra.aspx?id=3&Cat=10';
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="divSolicitudesCortadora">
                <div class="divTitulo">
                    Ordenes de compra pendientes<asp:Button ID="btnFiltro" runat="server" 
                        Text="Button" Visible="False" />
                </div>
    <div class="divSeccion">
<div id="GridCortadora" style="height:500px;width:1100px; overflow:auto;" >
<telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="idItem"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="NroOC" HeaderText="Orden Compra" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"  SortExpression="NroOC" UniqueName="NroOC">
                    </telerik:GridBoundColumn>  

                    <telerik:GridBoundColumn DataField="CodigoItem" HeaderText="SKU" ItemStyle-Width="45px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoItem" UniqueName="CodigoItem">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Left"  SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>   
                    
                    <telerik:GridBoundColumn DataField="CantidadPliegos" HeaderText="Pliegos" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="CantidadPliegos" UniqueName="CantidadPliegos">
                    </telerik:GridBoundColumn>
             
                    <telerik:GridBoundColumn DataField="CantidadKG" HeaderText="KG" ItemStyle-Width="60px" SortExpression="CantidadKG" ItemStyle-HorizontalAlign="Right" UniqueName="CantidadKG">
                    </telerik:GridBoundColumn>


                    <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left"  SortExpression="Observacion" UniqueName="Observacion">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha Solicitud" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                    </telerik:GridBoundColumn>


                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
                    </telerik:GridBoundColumn>
                            
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
         </div>
        </div>
        </div>


       <div id="divDatosSolicitud" ><%--style="display:none;"--%>
    <div class="divTitulo">Datos de la Solicitud</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label60" runat="server" Font-Bold="True" 
                        Text="Nro Orden Compra:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblOC" runat="server"></asp:Label>
                    <asp:Label ID="lblIDItem" runat="server">0</asp:Label>
                </td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style10">
                    <asp:Label ID="lblGramaje" runat="server" style="display:none;"></asp:Label>
                    <asp:Label ID="lblAncho" runat="server" style="display:none;"></asp:Label>
                    <asp:Label ID="lblLargo" runat="server" style="display:none;"></asp:Label>
                    <asp:Label ID="lblidDetalleOC" runat="server" style="display:none;"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    <asp:Label ID="Label11" runat="server" Text="SKU:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="lblSKU" runat="server"></asp:Label>
                    <asp:Label ID="lblValorUnitario" runat="server"></asp:Label>
                </td>
                <td class="style12">
                    <asp:Label ID="Label13" runat="server" Text="Papel:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style10" colspan="2">
                    <asp:Label ID="lblPapel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    </td>
                <td class="style10">
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" 
                        Text="Pliegos Solicitados:"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="lblPliegosSolicitados" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="Label63" runat="server" Text=" Pliegos."></asp:Label>
                </td>
                <td class="style12">
                    <asp:Label ID="Label16" runat="server" Text="Kilos Solicitados:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblKilosSolicitados" runat="server">0</asp:Label>
                    &nbsp;<asp:Label ID="Label64" runat="server" Text="KG."></asp:Label>
                </td>
                <td class="style13">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label20" runat="server" Text="Kilos Entregados:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblKilosEntregados" runat="server">0</asp:Label>
                    <asp:Label ID="Label65" runat="server" Text="KG."></asp:Label>
                </td>
                <td class="style6">
                <input id="btnGuardar2" type="button" value="Agregar Factura" onclick="javascript:RecepcionarFactura();"  /></td>
                <td class="style10">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    </div>
        <div class="divTitulo">
            <table style="width:100%;">
                <tr>
                    <td>
                        Facturas Ingresadas</td>
                    <td>
                      </td>
                </tr>
            </table>
    </div>
    <div class="divSeccion">
    <div style="height:200px;overflow:auto;">
        <asp:Label ID="lblFacturas" runat="server"></asp:Label>
    </div>
        </div>

        <div class="divTitulo">
            <table style="width:100%;">
                <tr>
                    <td>
                        Crear Pallets</td>
                    <td>
                      </td>
                </tr>
            </table>
    </div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label59" runat="server" Font-Bold="True" Text="SKU Entrada:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSKUSalida" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label24" runat="server" Text="Cantidad de Pliegos:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPliegos" runat="server" BackColor="Yellow"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label25" runat="server" Text="Peso Pliegos:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPeso" runat="server" BackColor="Yellow"></asp:TextBox>
&nbsp;<asp:Label ID="Label26" runat="server" Text="KGs."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <div align="center">
        <input id="btnGuardar" type="button" value="Crear Pallet" onclick="javascript:CrearPallet();" style="width:182px;" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;        
         <input id="Button1" type="button" value="Nueva Solicitud" onclick="javascript:NuevaSolicitud();" style="width:182px;" />

               </div>
        </div>
        <br />
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
        <asp:Label ID="Label2" runat="server">Total Creado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
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

</asp:Content>
