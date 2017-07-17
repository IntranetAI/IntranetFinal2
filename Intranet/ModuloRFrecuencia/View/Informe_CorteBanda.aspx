<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_CorteBanda.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Informe_CorteBanda" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div runat="server" id="divbotones" style="text-align: right; width: 940px; margin-top: -20px;
        margin-left: -10px;">
        <a title="Buscar OTs por Filtro">
            <asp:ImageButton ID="ibMostrarFiltro" runat="server" Height="20px" ImageUrl="~/images/buscar.png"
                Width="20px" OnClick="ibMostrarFiltro_Click" />
        </a>&nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" OnClick="ibExcel_Click" /></a>
    </div>
    <asp:Panel ID="PanelFiltro" runat="server" Visible="false">
        <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;width:935px;"
            align="center">
            <tr>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>
                </td>
                <td class="style2">
                    <asp:Label ID="Label4" runat="server" Text="Codigo Bob.:"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtCodigoBob" runat="server"></asp:TextBox>
                </td>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Maquina:"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlMaquina" runat="server">
                        <asp:ListItem>Todas</asp:ListItem>
                        <asp:ListItem>Lithoman</asp:ListItem>
                        <asp:ListItem>M600</asp:ListItem>
                        <asp:ListItem>Dimensionadora</asp:ListItem>
                        <asp:ListItem>Web 1</asp:ListItem>
                        <asp:ListItem>Web 2</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style2">
                    <div style="margin-top: -15px; margin-left: 40px; text-align: right;">
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" ImageUrl="~/images/cerrar.PNG"
                            OnClick="ImageButton2_Click" Style="width: 16px" /></div>
                </td>
            </tr>
            <tr>
                <td style="width: 81;">
                    <asp:Label ID="Label2" runat="server" Text="Categoria:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategoria" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="width: 95;">
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
                <td>
                    <div style="margin-left: 17px;">
                        <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click1"
                            Style="height: 26px" />
                    </div>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Height="600px" Width="935px" Direction="NotSet"
        ClientIDMode="Inherit">
        <div style="overflow-y: scroll; max-height: 550px; margin-left: -10px;">
            <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" AllowSorting="True"
                Width="928px">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="VerMas">
                    <NoRecordsTemplate>
                        <div style="text-align: center;">
                            <br />
                            ¡ No se han encontrado Trabajo !<br />
                        </div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="VerMas" HeaderText="Maquina" ReadOnly="True" SortExpression="VerMas" UniqueName="VerMas">
                            <ItemStyle Width="80px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NumeroOp" HeaderText="OT" ReadOnly="True" SortExpression="NumeroOp" UniqueName="NumeroOp">
                            <ItemStyle Width="60px" />
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn DataField="pliego" HeaderText="pliego" SortExpression="pliego" UniqueName="pliego">
                            <ItemStyle Width="30px" />
                        </telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn DataField="Lote" HeaderText="Motivo" UniqueName="Lote">
                            <ItemStyle Width="100px" />
                        </telerik:GridBoundColumn>
                   <%--     <telerik:GridBoundColumn DataField="Porc_Buenas" HeaderText="Categoria" UniqueName="Porc_Buenas">
                            <ItemStyle Width="20px" />
                        </telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn DataField="Porc_Malas" HeaderText="Proveedor" UniqueName="Porc_Malas">
                            <ItemStyle Width="100px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Codigo" HeaderText="Codigo Bobina" UniqueName="Codigo">
                            <ItemStyle Width="60px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Gramage" HeaderText="Gr." UniqueName="Gramage">
                            <ItemStyle Width="30px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Ancho" HeaderText="An." UniqueName="Ancho">
                            <ItemStyle Width="30px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Tipo" HeaderText="Tipo" UniqueName="Tipo">
                            <ItemStyle Width="60px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" UniqueName="Marca">
                            <ItemStyle Width="100px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Fecha" UniqueName="Ubicacion">
                            <ItemStyle Width="85px" />
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                </ClientSettings>
                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
    </asp:Panel>
    <script type="text/javascript">
        $('#accordion ul:eq(8)').show();
    </script>
</asp:Content>
