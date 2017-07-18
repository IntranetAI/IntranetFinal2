<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Informe_Externo.aspx.cs" Inherits="Intranet.ModuloDespacho.View.Informe_Externo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
        align="center" width="910px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
            </td>
            <td>
                Proveedor:
            </td>
            <td>
                <asp:TextBox ID="txtproveedor" runat="server"></asp:TextBox>
            </td>
            <td>
                Nro. Factura
            </td>
            <td>
                <asp:TextBox ID="txtnroFactura" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                    Format="dd-MM-yyyy">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" Enabled="True"
                    Format="dd-MM-yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td colspan="2">
                <div align="right" style="width: 184px;">
                    <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" Style="height: 26px"
                        OnClick="btnFiltro_Click" />
                </div>
            </td>
        </tr>
    </table>
    <div align="right" style="width: 1095px;">
        <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" OnClick="ibExcel_Click" />Inf. Facturas</a>&nbsp;&nbsp; 
        <a title="Exportar a Excel Mensual">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" onclick="ImageButton1_Click" />Inf. Mensual</a></div>
    <%--<br />--%>
    <div style="border: 1px solid blue; width: 1095px; min-height: 300px; max-height: 400px;
        overflow-y: auto;">
        <telerik:RadGrid ID="RadGridOT" BorderWidth="0px" runat="server" Skin="Outlook" GridLines="None">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                <NoRecordsTemplate>
                    <div style="text-align: center;">
                        <br />
                        ¡ No se han encontrado registros !<br />
                    </div>
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>
                    <telerik:GridBoundColumn DataField="M2" HeaderText="N°" UniqueName="M2" ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Ciudad" HeaderText="Fecha" UniqueName="Ciudad"
                        ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Producto" UniqueName="NombreOT"
                        ItemStyle-Width="200px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Nombre" HeaderText="Proveedor" UniqueName="Nombre">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NFactura" HeaderText="N° Factura" UniqueName="NFactura"
                        ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Sucursal" HeaderText="Valor Neto" UniqueName="Sucursal"
                        ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Rut" HeaderText="I.V.A 19%" UniqueName="Rut"
                        ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Tipo" HeaderText="Total" UniqueName="Tipo" ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Proceso" HeaderText="" UniqueName="Proceso">
                    </telerik:GridBoundColumn>
                    <%--  <telerik:GridBoundColumn DataField="VerMas" HeaderText="Detalle" 
                                ReadOnly="True" SortExpression="VerMas" UniqueName="VerMas">
                                <ItemStyle Width="50px" />
                            </telerik:GridBoundColumn>
                    --%>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="True">
            </ClientSettings>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
    <br />
</asp:Content>
