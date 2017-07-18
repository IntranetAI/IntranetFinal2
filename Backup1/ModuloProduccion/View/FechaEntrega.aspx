<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true"
    CodeBehind="FechaEntrega.aspx.cs" Inherits="Intranet.ModuloProduccion.View.FechaEntrega" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <style type="text/css">
        #popup
        {
            left: 0;
            position: absolute;
            top: 0;
            width: 100%;
            z-index: 1001;
        }
        
        #popup2
        {
            left: 0;
            position: absolute;
            top: 0;
            width: 100%;
            z-index: 1001;
        }
        
        .content-popup
        {
            margin: 0px auto;
            margin-top: 50px;
            padding: 10px;
            width: 900px;
            min-height: 250px;
            border-radius: 4px;
            background-color: #FFFFFF;
            box-shadow: 0 2px 5px #666666;
        }
        
        .close
        {
            position: relative;
            left: 880px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#open').click(function () {
                $('#popup').fadeIn('fast');
                $('#popup').fadeIn('slow');
                //$('body').css('opacity', '0.5');
                return false;
            });

            $('#close').click(function () {
                $('#popup').fadeOut('fast');
                //$('body').css('opacity', '1');
                return false;
            });

            $('#open2').click(function () {
                $('#popup2').fadeIn('fast');
                //$('body').css('opacity', '0.5');
                return false;
            });

            $('#close2').click(function () {
                $('#popup2').fadeOut('fast');
                //$('body').css('opacity', '1');
                return false;
            });
        });
    </script>
    <style type="text/css">
        .filtering
        {
            border: 1px solid #999;
            margin-bottom: 5px;
            margin: center;
            padding: 10px;
            background-color: #EEE;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: right; width: 940px; margin-top: -20px;">
        <a title="Actualizar Registros">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png"
                Height="20px" Width="20px" OnClick="ImageButton1_Click" />
        </a>&nbsp;&nbsp;<a title="Buscar OTs por Filtro"><asp:ImageButton ID="ibMostrarFiltro"
            runat="server" Height="20px" ImageUrl="~/images/buscar.png" Width="20px" OnClick="ibMostrarFiltro_Click" />
        </a>
    </div>
    <asp:Panel ID="pnlFiltro" runat="server" Visible="False">
        <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; margin-left: -10px;
            margin-bottom: 5px; border-radius: 10px 10px 10px 10px;" align="center" width="945px">
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
                    <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
                </td>
                <td class="style8">
                    &nbsp;&nbsp;&nbsp;
                </td>
                <td class="style13">
                    <asp:Label ID="Label5" runat="server" Text="Nombre Cliente: "></asp:Label>
                    <asp:TextBox ID="txtCliente" runat="server" Width="163px"></asp:TextBox>
                </td>
                <td>
                    <div style="text-align: right; margin-top: -10px;">
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" ImageUrl="~/images/cerrar.PNG"
                            OnClick="ImageButton2_Click" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;
                </td>
                <td class="style21">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                </td>
                <td class="style22">
                    <asp:TextBox ID="txtFechaInicio" runat="server" Style="margin-left: 0px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td class="style21">
                    <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
                <td class="style10">
                    <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaTermino_CalendarExtender" runat="server" Enabled="True"
                        TargetControlID="txtFechaTermino" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td class="style23">
                    &nbsp;
                </td>
                <td class="style19">
                    <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click1"
                        Style="height: 26px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table style="margin-left: -10px;">
        <tr>
            <td>
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="530px"
                    Width="940px">
                    <asp:TabPanel runat="server" HeaderText="OTs sin Fecha Asignada " ID="TabPanel1">
                        <ContentTemplate>
                            <div style="height: 520px; width: 925px; overflow: auto;">
                                <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" Skin="Outlook" OnItemCommand="contactsGrid_ItemCommand">
                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOT">
                                        <NoRecordsTemplate>
                                            <div style="text-align: center;">
                                                <br />
                                                ¡ No se han encontrado registros !<br />
                                            </div>
                                        </NoRecordsTemplate>
                                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="NumeroOT" HeaderText="Nº OT" ReadOnly="True"
                                                SortExpression="NumeroOT" UniqueName="NumeroOT">
                                                <ItemStyle Width="15px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre" SortExpression="NombreOT"
                                                UniqueName="NombreOT">
                                                <ItemStyle Width="170px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ClienteOT" HeaderText="ClienteOT" UniqueName="ClienteOT">
                                                <ItemStyle Width="200px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Ejemplares" HeaderText="Tiraje" UniqueName="Ejemplares">
                                                <ItemStyle HorizontalAlign="Right" Width="25px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn Visible="False" DataField="observacion" HeaderText="Comentario CSR"
                                                ReadOnly="True" SortExpression="observacion" UniqueName="observacion">
                                                <ItemStyle Width="200px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaSolicitada" HeaderText="Fecha Solicitada por Cliente"
                                                SortExpression="FechaSolicitada" UniqueName="FechaSolicitada" Visible="False">
                                                <ItemStyle Width="50px" HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                                <ItemStyle CssClass="editCell" Width="80px"></ItemStyle>
                                                <ItemTemplate>
                                                    <%--<a href="#" id="open">Abrir ventana 1</a>--%>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="CustomEdit">Asignar Fecha</asp:LinkButton></ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="True">
                                    </ClientSettings>
                                    <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="OTs con Fecha Asignada">
                        <ContentTemplate>
                            <div style="height: 520px; width: 925px; overflow: auto;">
                                <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" Skin="Outlook" OnItemCommand="contactsGrid_ItemCommand">
                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOT">
                                        <NoRecordsTemplate>
                                            <div style="text-align: center;">
                                                <br />
                                                ¡ No se han encontrado registros !<br />
                                            </div>
                                        </NoRecordsTemplate>
                                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="NumeroOT" HeaderText="Nº OT" ReadOnly="True"
                                                SortExpression="NumeroOT" UniqueName="NumeroOT">
                                                <ItemStyle Width="15px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre" SortExpression="NombreOT"
                                                UniqueName="NombreOT">
                                                <ItemStyle Width="200px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ClienteOT" Visible="true" HeaderText="ClienteOT"
                                                UniqueName="ClienteOT">
                                                <ItemStyle Width="200px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Ejemplares" HeaderText="Tiraje" UniqueName="Ejemplares">
                                                <ItemStyle HorizontalAlign="Right" Width="25px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tiraje" HeaderText="Cantidad Despacho" UniqueName="Tiraje">
                                                <ItemStyle HorizontalAlign="Right" Width="25px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn Visible="false" DataField="observacion" HeaderText="Comentario CSR"
                                                ReadOnly="True" SortExpression="observacion" UniqueName="observacion">
                                                <ItemStyle Width="200px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaSolicitada" HeaderText="Fecha Solicitada"
                                                SortExpression="FechaSolicitada" UniqueName="FechaSolicitada" Visible="false">
                                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaProduccion" HeaderText="Fecha Produccion"
                                                DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" SortExpression="FechaProduccion" UniqueName="FechaProduccion">
                                                <ItemStyle Width="120px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                                <ItemStyle CssClass="editCell" Width="35px"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="CustomEdit">Revisar/Modificar</asp:LinkButton></ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="True">
                                    </ClientSettings>
                                    <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </td>
        </tr>
    </table>
    <div id="popup" style="display: none;">
    <div class="content-popup">
        <div class="close"><a href="#" id="close"><img src="images/close.png"/></a></div>
        <div>Contenido VENTANA 1</div>
    </div>
    </div>
</asp:Content>
