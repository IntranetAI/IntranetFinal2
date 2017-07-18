<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Informe_EntregaPallet.aspx.cs" Inherits="Intranet.ModuloWip.View.Informe_EntregaPallet" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
        align="center" width="500px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="N° OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
            </td>
            <td>
                    <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" Style="height: 26px"
                        OnClick="btnFiltro_Click" />
              
            </td>
        </tr>
    </table>
    <div align="right" style="width: 98%; margin-top: 5px;">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Excel-icon.png"
            Width="23px" OnClick="ImageButton1_Click" />
    </div>
    <div style="border: 1px solid blue; max-height: 450px; overflow-y: scroll; width: 98%;">
        <telerik:RadGrid ID="RadGridInforme" BorderWidth="0px" runat="server" Skin="Outlook" GridLines="None">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                <NoRecordsTemplate>
                    <div style="text-align: center;">
                        <br />
                        ¡ No se han encontrado registros !<br />
                    </div>
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ReadOnly="True" SortExpression="OT"
                        UniqueName="OT">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT"
                        UniqueName="NombreOT">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TotalTiraje" HeaderText="TotalTiraje" UniqueName="TotalTiraje">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Pliegos_Impresos" HeaderText="Entregado" SortExpression="Pliegos_Impresos"
                     ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Serv Ext" UniqueName="Maquina"
                        ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Maquina_Proceso" HeaderText="Almacenado" UniqueName="Maquina_Proceso"
                        ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Estado_Pallet2" HeaderText="Estado OT" SortExpression="Estado_Pallet2"
                        UniqueName="Estado_Pallet2" ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VerMas" HeaderText="" SortExpression="VerMas"
                        UniqueName="VerMas">
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
