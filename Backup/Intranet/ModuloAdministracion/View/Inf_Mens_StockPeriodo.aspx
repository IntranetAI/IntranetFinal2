<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Inf_Mens_StockPeriodo.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.Inf_Mens_StockPeriodo" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
        align="center" width="910px">
        <tr>
            <td>
                Mes :
            </td>
            <td>
                <asp:DropDownList ID="ddlMes" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                Año :
            </td>
            <td>
                <asp:DropDownList ID="ddlAnos" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                Informe :
            </td>
            <td>
                <asp:DropDownList ID="ddlInforme" runat="server">
                    <asp:ListItem Value="">Seleccionar Informe</asp:ListItem>
                    <asp:ListItem Value="Planchas">Stock por Periodo Planchas</asp:ListItem>
                    <asp:ListItem Value="Bobinas">Stock por Periodo Bobinas</asp:ListItem>
                    <asp:ListItem Value="Pliegos">Stock por Periodo Pliegos</asp:ListItem>
                    <asp:ListItem Value="Insumos">Stock por Periodo Insumos</asp:ListItem>
                    <asp:ListItem Value="Tintas">Stock por Periodo Tintas</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td> <div align="right">
                    <asp:Button ID="btnFiltro" runat="server" Text="Buscar" Width="73px" Style="height: 26px"
                        OnClick="btnFiltro_Click" />
                </div></td>
        </tr>
    </table>
    <div align="right" style="width: 940px;">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Excel-icon.png"
            Width="23px" onclick="ImageButton1_Click" />
    </div>
    <div style="border: 1px solid blue; min-height:300px; max-height: 450px; overflow-y:scroll; width: 950px;
        margin-left: -10px;">
        <telerik:RadGrid ID="RadGridInsumo" BorderWidth="0px" runat="server" Skin="Outlook"
            GridLines="None">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="CodItem">
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
                    <telerik:GridBoundColumn DataField="Descricao" HeaderText="Descripción">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CostoMedio" HeaderText="Cos. Medio" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="110px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SaldoInicial" HeaderText="SaldoInicial" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="110px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SaldoTotalIngreso" HeaderText="Grupo">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SaldoFinal" HeaderText="" ItemStyle-Width="70px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Inventarioinicial" HeaderText="" ItemStyle-Width="70px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ValorFinalPesos" HeaderText="" ItemStyle-Width="70px">
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
