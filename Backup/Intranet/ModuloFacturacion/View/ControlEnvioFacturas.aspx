<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="ControlEnvioFacturas.aspx.cs" Inherits="Intranet.ModuloFacturacion.View.ControlEnvioFacturas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function OpenFactura(Factura, TipoDoc) {
        window.open('Vista_FacturaElectronica.aspx?Fac=' + Factura + '&TipoDoc=' + TipoDoc, 'Detalle Factura Electronica', 'left=45,top=50,width=1045 ,height=910,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
    function Filtro(Estado) {
        if (Estado == 'Si') {
            document.getElementById('divFiltro').style.display = "block";
        }
        else {
            document.getElementById('divFiltro').style.display = "none";
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divFiltro" style="display: block">
        <table style="background-color: #EEE; border: 1px solid #999; margin-left: 12%; border-radius: 10px 10px 10px 10px;
            width: 900px;" align="center">
            <tr>
                <td>
                    &nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOT" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Cliente:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
                    <div style="margin-top: -20px; margin-left: 200px; text-align: right; width: 20px;">
                        <a onclick="javascript:Filtro('No');">
                            <asp:Image ID="Image2" runat="server" Height="16px" Width="16px" ImageUrl="~/images/cerrar.PNG" />
                        </a>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaInicio" runat="server" Style="margin-left: 0px" Width="80px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                        Format="dd-MM-yyyy">
                    </asp:CalendarExtender>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" Enabled="True"
                        Format="dd-MM-yyyy" TargetControlID="txtFechaTermino">
                    </asp:CalendarExtender>
                </td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Ver  OTs Proceso" />
                </td>
                <td>
                    <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click1" />
                </td>
            </tr>
        </table>
    </div>
    <div align="right" style="margin-bottom: 5px; margin-right: 20px;">
        <a onclick="javascript:Filtro('Si');">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/buscar.png" Height="20px"
                Width="20px" />
        </a>&nbsp;&nbsp;
    </div>
    <div style="height: 490px; width: 1085px; overflow: auto;">
        <telerik:radgrid id="RadGrid1" runat="server" skin="Outlook">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Nfactura"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
        <Columns>
            <telerik:GridBoundColumn DataField="Nfactura" HeaderText="N° Factura" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Nfactura" UniqueName="Nfactura">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="TipoDocumento" HeaderText="Tipo Fact." SortExpression="TipoDocumento" UniqueName="TipoDocumento" ItemStyle-Width="100px">
            </telerik:GridBoundColumn>
                        
            <telerik:GridBoundColumn DataField="Fecha_Creacion" HeaderText="Fecha Emision" ItemStyle-Width="80px"  SortExpression="Fecha_Creacion" UniqueName="Fecha_Creacion">
            </telerik:GridBoundColumn>         
             
            <telerik:GridBoundColumn DataField="RutCliente" HeaderText="Rut Cliente" ItemStyle-Width="70px" SortExpression="RutCliente" UniqueName="RutCliente">
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn DataField="Nombre_Cliente" HeaderText="Nombre Cliente" ItemStyle-Width="250px"  SortExpression="Nombre_Cliente" UniqueName="Nombre_Cliente" >
            </telerik:GridBoundColumn>               
            <telerik:GridBoundColumn DataField="Valor_Neto" HeaderText="Valor Neto"  ItemStyle-Width="90px"  SortExpression="Valor_Neto" UniqueName="Valor_Neto" ItemStyle-HorizontalAlign="Right">
            </telerik:GridBoundColumn>     
            <telerik:GridBoundColumn DataField="Valor_Iva" HeaderText="Valor IVA"  ItemStyle-Width="90px"  SortExpression="Valor_Iva" UniqueName="Valor_Iva" ItemStyle-HorizontalAlign="Right">
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn DataField="Valor_total" HeaderText="Valor Total" ItemStyle-Width="90px" SortExpression="Valor_total" UniqueName="Valor_total" ItemStyle-HorizontalAlign="Right">
            </telerik:GridBoundColumn>
                    

            <telerik:GridBoundColumn DataField="CondicionVenta" HeaderText="Cond. Venta" ItemStyle-Width="80px" SortExpression="CondicionVenta" UniqueName="CondicionVenta">
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn DataField="VerMas" HeaderText="" ItemStyle-Width="50px" SortExpression="VerMas" UniqueName="VerMas">
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
</asp:Content>
