<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true"
    CodeBehind="InformeProOTRegiones.aspx.cs" Inherits="Intranet.ModuloDespacho.View.InformeProOTRegiones" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <style type="text/css">
        .filtering
        {
            border: 1px solid #999;
            margin-bottom: 5px;
            margin: center;
            padding: 4px;
            background-color: #EEE;
        }
        .Grilla
        {
            margin-bottom: 5px;
            margin: center;
            padding: 10px;
        }
        .style1
        {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="filtering" align="center" width="885px" style="border-radius: 10px 10px 10px 10px;
        margin-left: 20px; margin-top: 6px;">
        <tr>
            <td class="style5">
            </td>
            <td class="style20">
                <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>
            </td>
            <td class="style20">
                &nbsp;</td>
            <td class="style11">
                
            </td>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;
            </td>
            <td class="style13">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td class="style1">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtFechaInicio" runat="server" Style="margin-left: 0px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                    Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
            <td class="style1">
                <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" Enabled="True"
                    Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                </asp:CalendarExtender>
            </td>
            <td class="style1">
            </td>
            <td class="style1">
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click1"
                    Style="height: 26px" />
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <%--       </asp:Panel>--%>
    <%--fin filtro--%>
    &nbsp;<div runat="server" id="divbotones" style="text-align: right; margin-bottom: 1px;
        width: 931px; margin-top: -20px;">
        <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" OnClick="ibExcel_Click" Visible="False" />
        </a>
    </div>
    <asp:Panel ID="pnlResultados" runat="server" Width="880px">
        <div style="height: 500px; width: 930px; overflow: auto; border: 1px inset blue;">
            <telerik:RadGrid ID="RadGrid1" runat="server" BorderWidth="0px" Skin="Outlook" Height="300px">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                    <NoRecordsTemplate>
                        <div style="text-align: center;">
                            <br />
                            ¡ No se han encontrado OTs Nuevas !<br />
                        </div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" ReadOnly="True" SortExpression="OT"
                            UniqueName="OT" ItemStyle-Width="40px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT"
                            SortExpression="NombreOT" UniqueName="NombreOT" ItemStyle-Width="200px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Despachado" ItemStyle-HorizontalAlign="Right"
                            ReadOnly="True" SortExpression="Proveedor" UniqueName="Proveedor" ItemStyle-Width="60px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Comuna" HeaderText="Guias RM" SortExpression="Comuna"
                            UniqueName="Comuna" ItemStyle-Width="70px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Embalaje" HeaderText="Guias Regiones" UniqueName="Embalaje"
                            ItemStyle-Width="70px">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
        <br />
    </asp:Panel>
    <script type="text/javascript">
        $('#accordion ul:eq(7)').show();
    </script>
  
</asp:Content>
