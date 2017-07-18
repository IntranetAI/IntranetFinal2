<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true"
    CodeBehind="Compras.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.Compras" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
        align="center" width="910px">
        <tr>
            <td>
                Nro. Pedido :
            </td>
            <td>
                <asp:TextBox ID="txtPedido" runat="server"></asp:TextBox>
            </td>
            <td>
                Cod Item :
            </td>
            <td>
                <asp:TextBox ID="txtCodItem" runat="server"></asp:TextBox>
            </td>
            <td>
                Proveedor
            </td>
            <td>
                <asp:TextBox ID="txtProveedor" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>Fecha Inicio</td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" 
                    TargetControlID="txtFechaInicio">
                </asp:CalendarExtender>
            </td>
            <td>Fecha Termino</td>
            <td><asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" 
                    TargetControlID="txtFechaTermino">
                </asp:CalendarExtender></td>
            <td>Estado</td>            
            <td><asp:DropDownList ID="ddlEstado" runat="server">
                <asp:ListItem Value="">Todos</asp:ListItem>
                <asp:ListItem Value="0">Solicitado</asp:ListItem>
                <asp:ListItem Value="1">Rec/Parc</asp:ListItem>
                <asp:ListItem Value="2">Recepcionado</asp:ListItem>
            </asp:DropDownList></td>
            <td>
                <div align="right">
                    <asp:Button ID="btnFiltro" runat="server" Text="Buscar" Width="73px" Style="height: 26px"
                        OnClick="btnFiltro_Click" />
                </div>
            </td>
        </tr>
    </table>
    <div align="right" style="width: 940px;">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Excel-icon.png"
            Width="23px" onclick="ImageButton1_Click" />
    </div>
    <div style="border: 1px solid blue; min-height:300px; max-height: 450px; overflow-y: scroll; width: 943px;
        margin-left: -8px;">
        <telerik:RadGrid ID="RadGridCompras" BorderWidth="0px" runat="server" Skin="Outlook"
            GridLines="None">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="NroPedido">
                <NoRecordsTemplate>
                    <div style="text-align: center;">
                        <br />
                        ¡ No se han encontrado registros !<br />
                    </div>
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>
                    <telerik:GridBoundColumn DataField="CodItem" HeaderText="Cod Item">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Proveedor">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CantidadSoli" HeaderText="Solicitado" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="70px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CantidadRecep" HeaderText="Recepcion." ItemStyle-HorizontalAlign="Right" ItemStyle-Width="70px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ValorUnitario" HeaderText="Precio Un." ItemStyle-HorizontalAlign="Right" ItemStyle-Width="70px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="70px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Fecha_Entrega" HeaderText="Fecha" ItemStyle-Width="70px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" ItemStyle-Width="80px">
                    </telerik:GridBoundColumn>
                    
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="True">
            </ClientSettings>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
</asp:Content>
