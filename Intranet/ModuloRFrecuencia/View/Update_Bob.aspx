<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Update_Bob.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Update_Bob" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">
    function openGame(OT, NombreOT, Pliego) {
        window.open('Registro_Mod.aspx?ot=' + OT + '&not=' + NombreOT + '&pl=' + Pliego, 'Detalle Bobina', 'left=300,top=100,width=360 ,height=400,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
    function Agregar() {
        onload(window.open('Consumo_Bobina.aspx?Bodega=1', 'Consumo Bobina', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=540,left=340,top=200'));
    }
</script>
    <style type="text/css">
        .style2
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divbotones" style="text-align: right; width: 1095px; margin-top: -20px;
        margin-left: -10px;">
        <a id="A1" runat="server" onclick="javascript:Agregar()"  style="color: #000000; text-decoration: blink;">
            <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" />Agregar
        </a>
        <a title="Actualizar OTs Nuevas">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png"
                Height="20px" Width="20px" OnClick="ImageButton1_Click" />
        </a>&nbsp;&nbsp; <a title="Buscar OTs por Filtro">
            <asp:ImageButton ID="ibMostrarFiltro" runat="server" Height="20px" ImageUrl="~/images/buscar.png"
                Width="20px" OnClick="ibMostrarFiltro_Click" />
        </a>&nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" OnClick="ibExcel_Click" />
        </a>
    </div>
    <asp:Panel ID="PanelFiltro" runat="server" Visible="false">
        <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
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
                    <asp:Label ID="Label2" runat="server" Text="Tipo Papel:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTipPapel" runat="server"></asp:TextBox>
                </td>
                <td style="width: 95;">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td>
                    <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" Enabled="True"
                        Format="dd/MM/yyyy" TargetControlID="txtFechaTermino">
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
    <div style="width: 1097px; max-height: 500px; min-height: 200px; overflow-y: auto;">
        <telerik:RadGrid ID="RadGridBob" runat="server" Skin="Outlook" AllowSorting="True"
            Width="1080px">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="pliego">
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
                    <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Maquina" SortExpression="Ubicacion"
                        UniqueName="Ubicacion">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NumeroOp" HeaderText="Nº OT" SortExpression="NumeroOp"
                        UniqueName="NumeroOp">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Codigo" HeaderText="Nº Bob." ItemStyle-HorizontalAlign="Right"
                        SortExpression="ID_Bobina" UniqueName="ID_Bobina">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliegos" ItemStyle-Width="127px"
                        UniqueName="Pliego">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" SortExpression="Marca"
                        UniqueName="Marca">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Gramage" HeaderText="Gr" UniqueName="Gramage">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Lote" HeaderText="P. Bruto" ItemStyle-HorizontalAlign="Right"
                        UniqueName="Lote">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Porc_Malas" HeaderText="P. Tapa" ItemStyle-HorizontalAlign="Right"
                        UniqueName="Porc_Malas">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Porc_Perdida" HeaderText="P. Envoltura" ItemStyle-HorizontalAlign="Right"
                        UniqueName="Porc_Perdida">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Tipo" HeaderText="P. Escarpe" ItemStyle-HorizontalAlign="Right"
                        UniqueName="Tipo">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cono" HeaderText="P. Cono" ItemStyle-HorizontalAlign="Right"
                        UniqueName="Cono">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Saldo" ItemStyle-HorizontalAlign="Right"
                        UniqueName="Proveedor">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VerMas" HeaderText="" UniqueName="VerMas">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="True">
            </ClientSettings>
            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
        <%--   </asp:Panel>--%>
    </div>
</asp:Content>
