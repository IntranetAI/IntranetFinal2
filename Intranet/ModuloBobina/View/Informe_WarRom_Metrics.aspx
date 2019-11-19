<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_WarRom_Metrics.aspx.cs" Inherits="Intranet.ModuloBobina.View.Informe_WarRom_Metrics" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" autocomplete="off">
    <div runat="server" id="divbotones" style="text-align: right; width: 940px; margin-top: -20px;
        margin-left: -10px;">
       <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" OnClick="ibExcel_Click" /></a>
    </div>
    <asp:Panel ID="Panel2" runat="server" Visible="true">
        <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; margin-left: -10px;
            margin-bottom: 5px; border-radius: 10px 10px 10px 10px;" align="center" width="945px;">
            <tr>
                <td style="width: 95;">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha : "></asp:Label>
                </td>
                <td style="width: 134;">
                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="128px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td style="width: 500px;" colspan="2">
                    <div style="margin-left: 17px;">
                        <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click1"
                            Style="height: 26px" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Height="600px" Width="935px" Direction="NotSet"
        ClientIDMode="Inherit">
        <div style="overflow-y: scroll; height: 550px; margin-left: -10px;">
            <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" AllowSorting="True"
                Width="928px">
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
                        <telerik:GridBoundColumn DataField="Codigo_Bobina" HeaderText="Codigo Bobina" ItemStyle-HorizontalAlign="Right"
                            ReadOnly="True" SortExpression="Codigo_Bobina" UniqueName="Codigo_Bobina">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipoPapel" HeaderText="Tipo Papel" SortExpression="TipoPapel"
                            UniqueName="TipoPapel">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-HorizontalAlign="Right"
                            UniqueName="Gramaje">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PesoInicial" HeaderText="Peso Inicial" ItemStyle-HorizontalAlign="Right"
                            UniqueName="PesoInicial">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ConsumoBobina" HeaderText="Consumo"
                            ItemStyle-HorizontalAlign="Right">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OrigenPerdida" HeaderText="Estado Bobina" UniqueName="OrigenPerdida">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MotivoPerdida" HeaderText="MotivoPerdida" UniqueName="MotivoPerdida" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Escarpe" HeaderText="Kilos Escarpe" ItemStyle-HorizontalAlign="Right"
                            UniqueName="Escarpe">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PorcentajePerdidas" HeaderText="% Perdida" UniqueName="PorcentajePerdidas">
                            <ItemStyle Width="20px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OT" HeaderText="OT" UniqueName="OT" Visible="false">
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
