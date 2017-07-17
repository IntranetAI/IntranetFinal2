<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="OrdenCompra.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.OrdenCompra" %>
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
        width: 65px;
    }
    .style3
    {
        width: 496px;
    }
    .style4
    {
        width: 145px;
    }
    .style6
    {
        width: 10px;
    }
    .style7
    {
        width: 136px;
    }
    .style11
    {
        width: 65px;
        height: 23px;
    }
    .style12
    {
        width: 145px;
        height: 23px;
    }
    .style13
    {
        width: 300px;
        height: 23px;
    }
    .style15
    {
        height: 23px;
    }
    .style16
    {
        width: 300px;
    }
    .style17
    {
        width: 153px;
        height: 23px;
    }
    .style18
    {
        width: 153px;
    }
    .style19
    {
        width: 110px;
    }
    .style20
    {
        width: 65px;
        height: 26px;
    }
    .style21
    {
        width: 145px;
        height: 26px;
    }
    .style22
    {
        width: 300px;
        height: 26px;
    }
    .style23
    {
        width: 153px;
        height: 26px;
    }
    .style24
    {
        height: 26px;
    }
    .style25
    {
        width: 10px;
        height: 30px;
    }
    .style26
    {
        width: 136px;
        height: 30px;
    }
    .style27
    {
        width: 388px;
        height: 30px;
    }
    .style28
    {
        width: 110px;
        height: 30px;
    }
    .style29
    {
        height: 30px;
    }
    .style30
    {
        width: 388px;
    }
    </style>


<script  type="text/javascript" language="javascript">
    $(document).ready(function () {

        var select = document.getElementById("<%= ddlMoneda.ClientID %>");
        var answer = select.options[select.selectedIndex].text;
        $.getJSON('http://mindicador.cl/api', function (data) {
            var dailyIndicators = data;
            //            $("<p/>", {
            //                html: 'El valor actual de la UF es $' + dailyIndicators.uf.valor
            //            }).appendTo("body");
            //  alert("Valor Dolar: "+dailyIndicators.dolar.valor);

            if (answer == 'Pesos') {
                document.getElementById("ContentPlaceHolder1_lblMoneda").innerHTML = "Valor Peso: $";
                document.getElementById("ContentPlaceHolder1_lblMoneda2").innerHTML = "en Pesos.";
                document.getElementById("ContentPlaceHolder1_lblValorMoneda").innerHTML = "1";
            } else if (answer == 'Dolar') {
                document.getElementById("ContentPlaceHolder1_lblMoneda").innerHTML = "Valor Dolar: $";
                document.getElementById("ContentPlaceHolder1_lblMoneda2").innerHTML = "en Dolares.";
                document.getElementById("ContentPlaceHolder1_lblValorMoneda").innerHTML = dailyIndicators.dolar.valor;
            } else if (answer == 'Euro') {
                document.getElementById("ContentPlaceHolder1_lblMoneda").innerHTML = "Valor Euro: $";
                document.getElementById("ContentPlaceHolder1_lblMoneda2").innerHTML = "en Euros.";
                document.getElementById("ContentPlaceHolder1_lblValorMoneda").innerHTML = dailyIndicators.euro.valor;
            } else {
                document.getElementById("ContentPlaceHolder1_lblMoneda").innerHTML = "";
                document.getElementById("ContentPlaceHolder1_lblValorMoneda").innerHTML = "";
            }
        }).fail(function () {
            console.log('Error al consumir la API!');
        });

        $("#ContentPlaceHolder1_ddlMoneda").change(function () {
            var select = document.getElementById("<%= ddlMoneda.ClientID %>");
            var answer = select.options[select.selectedIndex].text;
            $.getJSON('http://mindicador.cl/api', function (data) {
                var dailyIndicators = data;
                //            $("<p/>", {
                //                html: 'El valor actual de la UF es $' + dailyIndicators.uf.valor
                //            }).appendTo("body");
                //  alert("Valor Dolar: "+dailyIndicators.dolar.valor);

                if (answer == 'Pesos') {
                    document.getElementById("ContentPlaceHolder1_lblMoneda").innerHTML = "Valor Peso: $";
                    document.getElementById("ContentPlaceHolder1_lblValorMoneda").innerHTML = "1";
                    document.getElementById("ContentPlaceHolder1_lblMoneda2").innerHTML = "en Pesos.";
                } else if (answer == 'Dolar') {
                    document.getElementById("ContentPlaceHolder1_lblMoneda").innerHTML = "Valor Dolar: $";
                    document.getElementById("ContentPlaceHolder1_lblValorMoneda").innerHTML = dailyIndicators.dolar.valor;
                    document.getElementById("ContentPlaceHolder1_lblMoneda2").innerHTML = "en Dolares.";
                } else if (answer == 'Euro') {
                    document.getElementById("ContentPlaceHolder1_lblMoneda").innerHTML = "Valor Euro: $";
                    document.getElementById("ContentPlaceHolder1_lblValorMoneda").innerHTML = dailyIndicators.euro.valor;
                    document.getElementById("ContentPlaceHolder1_lblMoneda2").innerHTML = "en Euros.";
                } else {
                    document.getElementById("ContentPlaceHolder1_lblMoneda").innerHTML = "";
                    document.getElementById("ContentPlaceHolder1_lblValorMoneda").innerHTML = "";
                }
            }).fail(function () {
                console.log('Error al consumir la API!');
            });
        });


    });
    function FinalizarOC() {
        var Rut = document.getElementById("<%= txtRut.ClientID%>").value;
        var CodCliente = document.getElementById("ContentPlaceHolder1_lblCodProveedor").innerHTML;
        var select3 = document.getElementById("<%= ddlProveedor.ClientID %>");
        var Proveedor = select3.options[select3.selectedIndex].text;

        var select4 = document.getElementById("<%= ddlMoneda.ClientID %>");
        var Moneda = select4.options[select4.selectedIndex].text;

        var select2 = document.getElementById("<%= ddlDireccion.ClientID %>");
        var Direccion = select2.options[select2.selectedIndex].text;
        var Contacto = document.getElementById("<%= txtContacto.ClientID%>").value;

        var Correo = document.getElementById("<%= txtCorreo.ClientID%>").value;
        var Telefono = document.getElementById("<%= txtTelefono.ClientID%>").value;
        var select = document.getElementById("<%= ddlCondicionPago.ClientID %>");
        var CondicionPago = select.options[select.selectedIndex].text;
        var FechaEntrega = document.getElementById("<%= txtFechaEntrega.ClientID%>").value;
        var Observacion = document.getElementById("<%= txtObservacion.ClientID%>").value;
        var ValorMoneda = document.getElementById("ContentPlaceHolder1_lblValorMoneda").innerHTML;

        var Usuario = '<%= Session["Usuario"] %>';
        $.ajax({
            url: "OrdenCompra.aspx/CrearOrden",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'Rut':'" + Rut + "','CodCliente':'" + CodCliente + "','Proveedor':'" + Proveedor + "','Direccion':'" + Direccion + "','Contacto':'" + Contacto + "','Correo':'" + Correo +
                    "','Telefono':'" + Telefono + "','CondicionPago':'" + CondicionPago + "','FechaEntrega':'" + FechaEntrega + "','Observacion':'" + Observacion + "','Usuario':'" + Usuario + "','ValorMoneda':'" + eval(ValorMoneda) + "','Moneda':'"+Moneda+"'}",
            success: function (msg) {
                if (eval(msg.d[0]) > 0) {

                    window.open('OrdenCompraPDF.aspx?id=' + msg.d[0], 'Impresion Pallet Bodega Pliegos', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
                    alert('¡Orden de Compra N°' + msg.d[0] + ' Finalizada Correctamente');
                    location.href = 'OrdenCompra.aspx?id=3&Cat=10';

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
    function Habilitar() {
        var contador = document.getElementById("ContentPlaceHolder1_lblContador").innerHTML;
        if (eval(contador > 0)) {
            document.getElementById("btnFinalizarOC").style.display = 'block';
        }
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="divTitulo">
                   Pedido de Compra </div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label32" runat="server" Font-Bold="True" 
                        Text="Nombre Proveedor:"></asp:Label>
                </td>
                <td class="style16">
                    <asp:TextBox ID="txtNombreProveedor" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style18">
                    <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="Rut Proveedor:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" />
                    <asp:Button ID="btnFiltro" runat="server" Text="Button" Visible="False" />
                    <asp:Label ID="lblCodProveedor" runat="server" style="display:none;"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style12">
                    <asp:Label ID="Label1" runat="server" Text="Proveedor:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style13">
                    <asp:DropDownList ID="ddlProveedor" runat="server" Width="173px" 
                        AutoPostBack="True" onselectedindexchanged="ddlProveedor_SelectedIndexChanged">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style17">
                    &nbsp;&nbsp;
                </td>
                <td class="style15">
                    &nbsp;</td>
                <td class="style15">
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="Label4" runat="server" Text="Direccion:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style13">
                    <asp:DropDownList ID="ddlDireccion" runat="server" Width="173px">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style17">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Moneda:"></asp:Label>
                </td>
                <td class="style15">
                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="173px">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                        <asp:ListItem>Pesos</asp:ListItem>
                        <asp:ListItem>Dolar</asp:ListItem>
                        <asp:ListItem>Euro</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblMoneda" runat="server" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblValorMoneda" runat="server"></asp:Label>
                </td>
                <td class="style15">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style20">
                    &nbsp;
                </td>
                <td class="style21">
                    <asp:Label ID="Label6" runat="server" Text="Contacto:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style22">
                    <asp:TextBox ID="txtContacto" runat="server"></asp:TextBox>
                </td>
                <td class="style23">
                    <asp:Label ID="Label31" runat="server" Font-Bold="True" Text="Correo:"></asp:Label>
                </td>
                <td class="style24">
                    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="Telefono:"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td class="style24">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label9" runat="server" Text="Condicion de Pago:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style16">
                    <asp:DropDownList ID="ddlCondicionPago" runat="server" Width="173px">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style18">
                    <asp:Label ID="Label8" runat="server" Text="Fecha Entrega:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaEntrega" runat="server" ></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="txtFechaEntrega" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Observación:"></asp:Label>
                </td>
                <td class="style16">
                    <asp:TextBox ID="txtObservacion" runat="server" Height="45px" 
                        TextMode="MultiLine" Width="305px"></asp:TextBox>
                </td>
                <td class="style18">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    </div>
                    <div class="divTitulo">
                        Items Orden de Compra</div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    <asp:Label ID="Label33" runat="server" Font-Bold="True" Text="Buscar Papel:"></asp:Label>
                </td>
                <td class="style30">
                    <asp:TextBox ID="txtPapel" runat="server" Width="230px"></asp:TextBox>
                    <asp:Button ID="btnBuscarSKU" runat="server" Text="Buscar" 
                        onclick="btnBuscarSKU_Click" />
                </td>
                <td class="style19">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                </td>
                <td class="style7">
                    <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Papel:"></asp:Label>
                </td>
                <td class="style30">
                    <asp:DropDownList ID="ddlPapel" runat="server" Width="230px" 
                        AutoPostBack="True" onselectedindexchanged="ddlPapel_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style19">
                    <asp:Label ID="Label11" runat="server" Text="Codigo Item:" Font-Bold="True" 
                        Font-Italic="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSKU" runat="server"></asp:Label>
                    <asp:Label ID="lblGramaje" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblAncho" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblLargo" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    <asp:Label ID="Label34" runat="server" Font-Bold="True" Text="Papel:"></asp:Label>
                </td>
                <td class="style30">
                    <asp:Label ID="lblPapel" runat="server"></asp:Label>
                </td>
                <td class="style19">
                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Stock Actual:"></asp:Label>
                </td>
                <td>
                &nbsp;
                    <asp:Label ID="lblStock" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="Label29" runat="server" Text="Pliegos."></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp;
                </td>
                <td class="style26">
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="Pliegos:"></asp:Label>
                </td>
                <td class="style27">
                    <asp:TextBox ID="txtPliegos" runat="server" AutoPostBack="True" 
                        ontextchanged="txtPliegos_TextChanged"></asp:TextBox>
                    &nbsp;<asp:Label ID="Label28" runat="server" Text="Pliegos."></asp:Label>
                </td>
                <td class="style28">
                    <asp:Label ID="Label13" runat="server" Text="Cantidad(KG):" Font-Bold="True"></asp:Label>
                </td>
                <td class="style29">
                    <asp:Label ID="lblKilos" runat="server"></asp:Label>
                    <asp:Label ID="Label14" runat="server" Text="KG"></asp:Label>
                </td>
                <td class="style29">
                    </td>
                <td class="style29">
                    </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                </td>
                <td class="style7">
                    <asp:Label ID="Label15" runat="server" Text="Valor Unitario:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style30">
                    <asp:TextBox ID="txtValorUnitario" runat="server" AutoPostBack="True" 
                        ontextchanged="txtValorUnitario_TextChanged"></asp:TextBox>
                &nbsp;<asp:Label ID="lblMoneda2" runat="server"></asp:Label>
                </td>
                <td class="style19">
                    <asp:Label ID="Label17" runat="server" Text="Costo Total:" Font-Bold="True"></asp:Label>
&nbsp;
                    </td>
                <td>
                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAgregarItem" runat="server" 
                        Text="Agregar Item" onclick="btnAgregarItem_Click" />
                    <asp:Label ID="Label30" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
        <div style="height:200px;width:1085px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="CodigoItem">
                    <NoRecordsTemplate>
                        <div style="text-align:center;">
                            <br />
                            ¡ No se han encontrado registros !<br /></div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="CodigoItem" HeaderText="Cod. Item" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoItem" UniqueName="CodigoItem">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Papel" HeaderText="Producto" ItemStyle-Width="280px" ItemStyle-HorizontalAlign="Left" SortExpression="Papel" UniqueName="Papel">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CantidadPliegos" HeaderText="Pliegos" ItemStyle-Width="60px" SortExpression="CantidadPliegos" ItemStyle-HorizontalAlign="Right"  UniqueName="CantidadPliegos">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CantidadKG" HeaderText="KG" ItemStyle-Width="60px" SortExpression="CantidadKG" ItemStyle-HorizontalAlign="Right"  UniqueName="CantidadKG">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorUnitario" HeaderText="Valor Unitario" ItemStyle-Width="40px"  SortExpression="ValorUnitario" ItemStyle-HorizontalAlign="Right"  UniqueName="ValorUnitario">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CostoTotal" HeaderText="Valor Total" ItemStyle-Width="50px" SortExpression="CostoTotal" ItemStyle-HorizontalAlign="Right"  UniqueName="CostoTotal">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IVA" HeaderText="IVA %"   ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right"   SortExpression="IVA" UniqueName="IVA">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TotalConIVA" HeaderText="Total + IVA"   ItemStyle-HorizontalAlign="Right"  ItemStyle-Width="50px" SortExpression="TotalConIVA" UniqueName="TotalConIVA">
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
        <div align="center">
            
              <input id="btnFinalizarOC" type="button" value="Finalizar Orden Compra" onclick="javascript:FinalizarOC();" style="width:182px;display:none;" />
            <asp:Label ID="lblContador" runat="server" Text="0" style="display:none;"></asp:Label>
        </div>
    </div>
</asp:Content>
