<%@ Page Title="" Language="C#" MasterPageFile="~/Estructura/View/MasterAplicaciones.Master" AutoEventWireup="true" CodeBehind="Informe_MensualSobreProd.aspx.cs" Inherits="Intranet.ModuloProduccion.View.Informe_MensualSobreProd" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div runat="server" id="divbotones" style="text-align: right; width: 100%;">
        &nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" OnClick="ibExcel_Click" /></a>
    </div>
    <asp:Panel ID="Panel2" runat="server" Visible="true">
        <table style="background-color: #EEE; border: 1px solid #999; padding: 5px;
            margin-bottom: 5px; border-radius: 10px 10px 10px 10px;" align="center" width="945px;">
            <tr>
                <td style="width: 95;">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fechas : "></asp:Label>
                </td>
                <td style="width: 134;">
                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="128px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td>a</td>
                <td style="width: 134;">
                    <asp:TextBox ID="txtFechaTermino" runat="server" Width="128px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaTermino"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td style="width: 100px;" colspan="2">
                    <div style="margin-left: 17px;">
                        <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click1"
                            Style="height: 26px" />
                    </div>
                </td>144
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Height="600px" Width="100%" Direction="NotSet"
        ClientIDMode="Inherit">
        <div style="overflow-y: scroll; max-height: 550px;">
            <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" 
                Width="99.8%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Maquina">
                    <NoRecordsTemplate>
                        <div style="text-align: center;">
                            <br />
                            ¡ No se han encontrado Trabajo !<br />
                        </div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="Clasificacion" HeaderText="Sector" ReadOnly="True"
                            SortExpression="Clasificacion" UniqueName="Clasificacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" ReadOnly="True"
                            SortExpression="Maquina" UniqueName="Maquina">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Operador" HeaderText="Planificado Total" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="Producido Total" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Planificado" HeaderText="Planificado Cons. Esperado" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Producido" HeaderText="Producido Cons. Esperado" ItemStyle-HorizontalAlign="Right"
                            UniqueName="Producido">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DesperdicioAcerto" HeaderText="Diferencia"
                            ItemStyle-HorizontalAlign="Right">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Proceso" HeaderText="%" UniqueName="Proceso">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Planificado Cons. Sobre" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DesperdicioVirando" HeaderText="Producida Cons. Sobre"
                            ItemStyle-HorizontalAlign="Right">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CodMaquina" HeaderText="Diferencia"
                            ItemStyle-HorizontalAlign="Right">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="%" UniqueName="FechaInicio">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="DAcerto" HeaderText="Planificado Cons. Bajo" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DVirando" HeaderText="Producida Cons. Bajo"
                            ItemStyle-HorizontalAlign="Right">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Tipo" HeaderText="Diferencia"
                            ItemStyle-HorizontalAlign="Right">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Horas" HeaderText="%" UniqueName="Horas">
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
</asp:Content>
