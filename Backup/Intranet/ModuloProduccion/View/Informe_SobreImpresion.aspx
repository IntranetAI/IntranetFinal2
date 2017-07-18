<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Informe_SobreImpresion.aspx.cs" Inherits="Intranet.ModuloProduccion.View.Informe_SobreImpresion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div runat="server" id="divbotones" style="text-align: right; width: 1100px; margin-top: -20px;">
        &nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" OnClick="ibExcel_Click" /></a>
    </div>
    <asp:Panel ID="Panel2" runat="server" Visible="true">
        <table style="background-color: #EEE; border: 1px solid #999; padding: 5px;
            margin-bottom: 5px; border-radius: 10px 10px 10px 10px;" align="center" width="800px;">
            <tr>
                <td style="width: 95;">
                    <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>
                </td>
                <td style="width: 134;">
                    <asp:TextBox ID="txtOT" runat="server" Width="128px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 100px;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 95;">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha : "></asp:Label>
                </td>
                <td style="width: 134;">
                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="128px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" 
                        TargetControlID="txtFechaInicio">
                    </asp:CalendarExtender>
                </td>
                <td>
                    Seccion</td>
                <td>
                    <asp:DropDownList ID="ddlSeccion" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlSeccion_SelectedIndexChanged">
                        <asp:ListItem>Todas</asp:ListItem>
                        <asp:ListItem Value="IMP ROT">Rotativas</asp:ListItem>
                        <asp:ListItem Value="IMP PLANA">Planas</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Maquina</td>
                <td>
                    <asp:DropDownList ID="ddlMaquina" runat="server">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 100px;">
                    <div style="margin-left: 17px;">
                        <asp:Button ID="btnFiltro" runat="server" OnClick="btnFiltro_Click1" 
                            Style="height: 26px" Text="Filtrar" Width="73px" />
                    </div>
                </td>
                <td>
                    <div style="margin-top: -20px; margin-left: 40px; text-align: right;">
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Height="600px" Width="1095px" Direction="NotSet"
        ClientIDMode="Inherit">
        <div style="overflow-y: scroll; max-height: 550px;">
            <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" 
                Width="1075px">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Maquina">
                    <NoRecordsTemplate>
                        <div style="text-align: center;">
                            <br />
                            ¡ No se han encontrado Trabajo !<br />
                        </div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ReadOnly="True"
                            SortExpression="Maquina" UniqueName="Maquina">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-HorizontalAlign="Right"
                            ReadOnly="True" SortExpression="OT" UniqueName="OT">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT"
                            UniqueName="NombreOT">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" ItemStyle-HorizontalAlign="Left"
                            UniqueName="Pliego">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Planificado" HeaderText="Cant. Planificado" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Buenos" HeaderText="Cant. Producida" ItemStyle-HorizontalAlign="Right"
                            UniqueName="Buenos">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Producido" HeaderText="% Producción"
                            ItemStyle-HorizontalAlign="Right">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Proceso" HeaderText="Control Wip" UniqueName="Proceso">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Tipo" HeaderText="Papeles" Visible="false"
                            UniqueName="Tipo">
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn DataField="CodMaquina" HeaderText="Costo SobreImpresion" UniqueName="CodMaquina" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle Width="20px" />
                        </telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="Consumo KG" UniqueName="FechaInicio" ItemStyle-HorizontalAlign="Right" Visible="false">
                            <ItemStyle Width="20px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Operador" HeaderText="Operador" UniqueName="Operador">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                </ClientSettings>
                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </asp:Panel>
    <script type="text/javascript">
        $('#accordion ul:eq(8)').show();
    </script>
</asp:Content>
