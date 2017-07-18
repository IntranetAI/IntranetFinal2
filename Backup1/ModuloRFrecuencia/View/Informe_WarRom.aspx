<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true"
    CodeBehind="Informe_WarRom.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Informe_WarRom" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divbotones" style="text-align: right; width: 940px; margin-top: -20px;
        margin-left: -10px;">
        <a title="Actualizar OTs Nuevas">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png"
                Height="20px" Width="20px" OnClick="ImageButton1_Click" />
        </a>&nbsp;&nbsp; <a title="Buscar OTs por Filtro">
            <asp:ImageButton ID="ibMostrarFiltro" runat="server" Height="20px" ImageUrl="~/images/buscar.png"
                Width="20px" OnClick="ibMostrarFiltro_Click" />
        </a>
        <%--&nbsp;&nbsp;&nbsp;<a title="Exportar a PDF"><asp:ImageButton 
                   ID="ibPDF" runat="server" Height="20px" 
                   ImageUrl="~/Images/pdf-icon.jpg" Width="20px" 
        onclick="ibPDF_Click" Visible="True" />
                   </a>--%>
        &nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
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
                <td>
                    <div style="margin-top: -20px; margin-left: 40px; text-align: right;">
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" ImageUrl="~/images/cerrar.PNG"
                            OnClick="ImageButton2_Click" Style="width: 16px" /></div>
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
                        <telerik:GridBoundColumn DataField="OT" HeaderText="Codigo Bobina" ItemStyle-HorizontalAlign="Right"
                            ReadOnly="True" SortExpression="Codigo_Bobina" UniqueName="Codigo_Bobina">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Tipo_Papel" SortExpression="Tipo_Papel"
                            UniqueName="Tipo_Papel">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Total_B" HeaderText="Gramaje" ItemStyle-HorizontalAlign="Right"
                            UniqueName="Gramaje">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BBuenas" HeaderText="Peso Bobina" ItemStyle-HorizontalAlign="Right"
                            UniqueName="PesoBobina">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ConsumoMaquina" HeaderText="Consumo"
                            ItemStyle-HorizontalAlign="Right">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BMalas_QG" HeaderText="Estado Bobina" UniqueName="Estado Bobina">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Pesos_Tapas" HeaderText="Kilos Escarpe" ItemStyle-HorizontalAlign="Right"
                            UniqueName="KilosEscarpe">
                        </telerik:GridBoundColumn>
                        <%--     
                            <telerik:GridBoundColumn DataField="Peso_Tapa" HeaderText="P. Tapa" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_Cono" HeaderText="P. Cono" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PesoEscarpe" HeaderText="P. Escarpe" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Peso_emboltorio" HeaderText="P. Envoltura" 
                            UniqueName="Ejemplares" DataType="System.Int32" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="50px"  />
                            </telerik:GridBoundColumn>
                        --%>
                        <telerik:GridBoundColumn DataField="Pesos_Conos" HeaderText="% Perdida" UniqueName="Porc_Perdida">
                            <ItemStyle Width="20px" />
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
