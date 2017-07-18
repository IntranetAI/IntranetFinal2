<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Help_Desk.aspx.cs" Inherits="Intranet.ModuloAdmin.View.Help_Desk" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function Agregar() {
            onload(window.open('Help_DeskFormulario.aspx', 'Mesa Ayuda', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=440,height=300,left=380,top=200'));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
        align="center" width="910px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Incidencias/Ticket :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Departamento :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDepartamento" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Nivel Incidencia: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlNivel" runat="server">
                    <asp:ListItem>Todas</asp:ListItem>
                    <asp:ListItem>Critico</asp:ListItem>
                    <asp:ListItem>Grave</asp:ListItem>
                    <asp:ListItem>Medio</asp:ListItem>
                    <asp:ListItem>Leve</asp:ListItem>
                </asp:DropDownList>
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
            <td>
            </td>
            <td>
                <div align="right" style="width: 184px;">
                    <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" Style="height: 26px"
                        OnClick="btnFiltro_Click" />
                </div>
            </td>
        </tr>
    </table>
    <div align="right">
        <a id="A1" runat="server" onclick="javascript:Agregar()" style="color: #000000; text-decoration: blink;">
            <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" />Agregar </a>&nbsp;&nbsp;</div>
    <%--<br />--%>
    <div style="border: 1px solid blue; min-height: 300px; max-height: 466px; overflow-y: auto;">
        <telerik:RadGrid ID="RadGridHelpDesk" BorderWidth="0px" runat="server" Skin="Outlook" GridLines="None">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Incidencia">
                <NoRecordsTemplate>
                    <div style="text-align: center;">
                        <br />
                        ¡ No se han encontrado registros !<br />
                    </div>
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>
                    <telerik:GridBoundColumn DataField="OT" HeaderText="Prioridad" ReadOnly="True" SortExpression="OT"
                        UniqueName="OT">
                        <ItemStyle Width="30px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Incidencia" HeaderText="Incidencias" SortExpression="Incidencia"
                        UniqueName="Incidencias">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NivelIncidencia" HeaderText="Nivel Incidencia" UniqueName="NivelIncidencia">
                        <ItemStyle Width="80px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Area" HeaderText="Area-Departamento" ReadOnly="True"
                        SortExpression="Area" UniqueName="Area" ItemStyle-HorizontalAlign="Right">
                        <ItemStyle Width="200px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Usuario" HeaderText="Solicitante" ReadOnly="True"
                        SortExpression="Usuario" UniqueName="Usuario" ItemStyle-HorizontalAlign="Center">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FeIncidencia" HeaderText="Fe.Ini. Incidencia"
                        UniqueName="FeIncidencia" ItemStyle-HorizontalAlign="Right">
                        <ItemStyle Width="100px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FeSolucion" HeaderText="Fe.Sol. Incidencia"
                        ReadOnly="True" SortExpression="FeSolucion" UniqueName="FeSolucion"
                        ItemStyle-HorizontalAlign="Right">
                        <ItemStyle Width="100px" />
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridBoundColumn DataField="Peso_pallet" HeaderText="Solución a Incidencia"
                        ReadOnly="True" SortExpression="Peso_pallet" UniqueName="Peso_pallet" ItemStyle-HorizontalAlign="Right">
                        <ItemStyle Width="40px" />
                    </telerik:GridBoundColumn>--%>
                    <telerik:GridBoundColumn DataField="Solucion" HeaderText="" ReadOnly="True" SortExpression="VerMas"
                        UniqueName="VerMas">
                        <ItemStyle Width="50px" />
                    </telerik:GridBoundColumn>
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
