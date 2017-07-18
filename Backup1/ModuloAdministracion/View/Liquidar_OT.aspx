<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true"
    CodeBehind="Liquidar_OT.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.Liquidar_OT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function openGame(OT, NombreOT) {
            window.open('Det_facturacion.aspx?ot=' + OT, 'Detalle OT', 'left=160,top=100,width=1115 ,height=793,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
        function imprSelec(Datos) {
            window.open('Det_facturacion_print.aspx?id=' + Datos, 'Imprimir', 'left=160,top=100,width=1020 ,height=770,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divbotones" style="text-align: right; width: 950px; margin-top: -10px;
        margin-left: -10px;">
        <a title="Actualizar OTs Nuevas">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png"
                Height="20px" Width="20px" OnClick="ImageButton1_Click" />
        </a>&nbsp;&nbsp; <a title="Buscar OTs por Filtro">
            <asp:ImageButton ID="ibMostrarFiltro" runat="server" Height="20px" ImageUrl="~/images/buscar.png"
                Width="20px" OnClick="ibMostrarFiltro_Click" />
        </a>&nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/print-message.jpg"
                Width="20px" Visible="True" onclick="ibExcel_Click" />
        </a>
    </div>
    <asp:Panel ID="PanelFiltro" runat="server" Visible="false">
        <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;width:950px;margin-left:-10px;"
            align="center">
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNumeroOT" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNombreOT" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Cliente:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCliente" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <div style="margin-top: -15px; margin-left: 40px; text-align: right;">
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" ImageUrl="~/images/cerrar.PNG"
                            OnClick="ImageButton2_Click" Style="width: 16px" /></div>
                </td>
            </tr>
            <tr>
                <td style="width: 81;">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="70px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaInicio0_CalendarExtender" runat="server" 
                        Format="dd/MM/yyyy" TargetControlID="txtFechaInicio">
                    </asp:CalendarExtender>
                </td>
                <td style="width: 95;">
                    <asp:Label ID="lblFechaTermino0" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaTermino" runat="server" Width="70px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaTermino0_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
                    </asp:CalendarExtender>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <div style="margin-left: 17px;">
                        <asp:Button ID="btnFiltro" runat="server" OnClick="btnFiltro_Click1" 
                            Style="height: 26px" Text="Filtrar" Width="73px" />
                    </div>
                </td>
                <td>
                    
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    <div style="margin-left: -10px; width: 950px; max-height: 500px; min-height: 200px;
        overflow-y: auto;">
        <telerik:RadGrid ID="RadGridLiq" runat="server" Skin="Outlook" AllowSorting="True">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Ancho">
                <NoRecordsTemplate>
                    <div style="text-align: center;">
                        <br />
                        ¡ No se han encontrado Trabajo !<br />
                    </div>
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>
                    <telerik:GridBoundColumn DataField="ID_Bobina" HeaderText="Codigo" SortExpression=""
                        UniqueName="Codigo" Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="OT" SortExpression="Ancho"
                        UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Certif" HeaderText="Producto" SortExpression="Certif"
                        UniqueName="Certif">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CodItem" HeaderText="Cliente" SortExpression="CodItem"
                        UniqueName="CodItem">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cons_Bobina" HeaderText="Tiraje" ItemStyle-HorizontalAlign="Right"
                        UniqueName="Cons_Bobina">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cons_Plancha" HeaderText="Fecha" UniqueName="Cons_Plancha"
                        ItemStyle-Width="65px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cons_Otros" HeaderText="" SortExpression="Cons_Otros"
                        UniqueName="Cons_Otros" ItemStyle-Width="60px">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="True">
            </ClientSettings>
            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
</asp:Content>
