<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Stock_Insumo.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.Stock_Insumo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function openGame(Codigo, Descripcion, Stock, Grupo) {
        window.open('Ingreso_Solic_insumo.aspx?Id='+Codigo+'&Des='+Descripcion+'&Sto='+Stock+'&Gr='+Grupo, 'Solicitar Stock', 'left=160,top=300,width=1300 ,height=115,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
        align="center" width="910px">
        <tr>
            <td>
                Cod Item :
            </td>
            <td>
                <asp:TextBox ID="txtCodItem" runat="server"></asp:TextBox>
            </td>
            <td>
                Descripción
            </td>
            <td>
                <asp:TextBox ID="txtDescrip" runat="server"></asp:TextBox>
            </td>
            <td>
                Grupo
            </td>
            <td>
                <asp:TextBox ID="txtGrupo" runat="server"></asp:TextBox>
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
                    <telerik:GridBoundColumn DataField="NombrePapel" HeaderText="Descripción">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Gramage" HeaderText="Stock" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="110px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Certif" HeaderText="Solicitado" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="110px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Lote" HeaderText="Grupo">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Tipo" HeaderText="" ItemStyle-Width="70px">
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
