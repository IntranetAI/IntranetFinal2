<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true"
    CodeBehind="InfDespachoFuturo.aspx.cs" Inherits="Intranet.ModuloDespacho.View.InfDespachoFuturo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#acco").accordion();
            $("#accordion").show();
        });

        function DetalleOT(OT) {
            window.open('../../ModuloProduccion/View/DetalleOT.aspx?ot=' + OT, 'Detalle OT', 'left=160,top=100,width=1115 ,height=793,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        };
           
    </script>
    <style type="text/css">
        .Grilla
        {
            margin-bottom: 5px;
            margin: center;
            padding: 10px;
        }
    </style>
    <style type="text/css">
        .mailRevisido
        {
            font-family: "Trebuchet MS" , "Helvetica" , "Arial" , "Verdana" , "sans-serif";
            font-size: 86%;
        }
        .ui-accordion .ui-accordion-header
        {
            display: block;
            cursor: pointer;
            position: relative;
            margin-top: 2px;
            padding: .5em .5em .5em .7em;
            min-height: 0; /* support: IE7 */
        }
        /*Estilo para las letra tanto el tamaño como estilo de ellas*/
        .ui-helper-reset
        {
            margin: 0;
            padding: 0;
            border: 0;
            outline: 0;
            line-height: 1.3;
            text-decoration: none;
            font-size: 100%;
            list-style: none;
        }
        /*Estilo de aparesca plomo del titulo  en un cuadrado*/
        .ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default
        {
            border: 1px solid #d3d3d3;
            background: #e6e6e6 url(images/ui-bg_glass_75_e6e6e6_1x400.png) 50% 50% repeat-x;
            font-weight: normal;
            color: #555555;
        }
        .ui-state-hover, .ui-widget-content .ui-state-hover, .ui-widget-header .ui-state-hover, .ui-state-focus, .ui-widget-content .ui-state-focus, .ui-widget-header .ui-state-focus
        {
            border: 1px solid #999999;
            background: #dadada url(images/ui-bg_glass_75_dadada_1x400.png) 50% 50% repeat-x;
            font-weight: normal;
            color: #212121;
        }
        .ui-accordion .ui-accordion-icons
        {
            padding-left: 2.2em;
        }
        /*Estilo de aparesca blanco del titulo  en un cuadrado*/
        .ui-state-active, .ui-widget-content .ui-state-active, .ui-widget-header .ui-state-active
        {
            border: 10px solid #aaaaaa;
            background: #ffffff url(images/ui-bg_glass_65_ffffff_1x400.png) 50% 50% repeat-x;
            font-weight: normal;
            color: #212121;
        }
        
        /*Borde de la tabla*/
        .ui-corner-all, .ui-corner-top, .ui-corner-left, .ui-corner-tl
        {
            border-top-left-radius: 4px;
        }
        .ui-corner-all, .ui-corner-top, .ui-corner-right, .ui-corner-tr
        {
            border-top-right-radius: 4px;
        }
        .ui-corner-all, .ui-corner-bottom, .ui-corner-left, .ui-corner-bl
        {
            border-bottom-left-radius: 4px;
        }
        .ui-corner-all, .ui-corner-bottom, .ui-corner-right, .ui-corner-br
        {
            border-bottom-right-radius: 4px;
        }
        /*Contenido*/
        .ui-accordion .ui-accordion-content
        {
            padding: 1em 2.2em;
            border-top: 0;
            overflow: auto;
        }
        /*Eliminar el border mayor del mensaje*/
        .ui-helper-reset
        {
            margin: 0;
            padding: 0;
            border: 0;
            outline: 0;
            line-height: 1.3;
            text-decoration: none;
            font-size: 100%;
            list-style: none;
        }
        /*borde cuadrado del mensaje*/
        .ui-widget-content
        {
            border: 1px solid #aaaaaa;
            color: #222222;
        }
        /*BOrde de contenido */
        .ui-tabs .ui-tabs-panel
        {
            display: block;
            border-width: 0;
            padding: 1em 1.4em;
            background: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divbotones" style="text-align: right; width: 936px; margin-top: -15px;">
        &nbsp;<a title="Buscar OTs por Filtro"><asp:ImageButton ID="ibMostrarFiltro" runat="server"
            Height="20px" ImageUrl="~/Images/buscar.png" Width="20px" OnClick="ibMostrarFiltro_Click"
            Visible="False" />
        </a><a title="Actualizar OTs Nuevas">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Refresh.png"
                Height="20px" Width="20px" OnClick="ImageButton1_Click" />
        </a>&nbsp;&nbsp;<a title="Exportación a PDF"><asp:ImageButton ID="ibExportacionPDF"
            runat="server" Height="20px" ImageUrl="~/Images/pdf-icon.jpg" Width="20px" OnClick="ibExportacionPDF_Click"
            Visible="False" />
        </a>&nbsp;&nbsp;&nbsp;<a title="Exportación a Excel"><asp:ImageButton ID="ibExportacionExcel"
            runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png" Width="20px"
            OnClick="ibExportacionExcel_Click" />
        </a>
    </div>
    <asp:Panel ID="panelFt" runat="server">
        <table align="center" width="895px" style="background-color: #EEE; border: 1px solid #999;
            border-radius: 10px 10px 10px 10px; margin-left: 15px; margin-top: 5px;">
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Nombre Cliente: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCliente" runat="server" Width="163px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaInicio" runat="server" Style="margin-left: 0px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td>
                    <asp:Label ID="lblFechaTermino" runat="server" Text="Fecha Termino: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaTermino" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy"
                        TargetControlID="txtFechaTermino">
                    </asp:CalendarExtender>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click1"
                        Style="height: 26px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%--inicio container--%>
    <table class="Grilla" align="center" width="900px" style="margin-left: -22px;">
        <tr>
            <td>
            </td>
            <td>
                <div id="divGrilla" runat="server" style="height: 500px; width: 940px; overflow: auto;">
                    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" OnItemCommand="contactsGrid_ItemCommand"
                        ClientSettings-Selecting-AllowRowSelect="true" ClientSettings-EnablePostBackOnRowClick="true">
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
                                    UniqueName="OT">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT"
                                    UniqueName="NombreOT">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente"
                                    UniqueName="Cliente">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Cant" HeaderText="Tiraje" UniqueName="Cant" ItemStyle-HorizontalAlign="Right">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TirajeGenerado" HeaderText="Cant. a Despachar"
                                    UniqueName="TirajeGenerado" ItemStyle-HorizontalAlign="Right">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TirajeAcumulado" HeaderText="Cant. Desp." UniqueName="TirajeAcumulado"
                                    ItemStyle-HorizontalAlign="Right">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fechafalsa" HeaderText="Total Desp." UniqueName="Fechafalsa"
                                    ItemStyle-HorizontalAlign="Right">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaDes" HeaderText="Fecha Entrega" ItemStyle-Width="115px"
                                    SortExpression="FechaDes" UniqueName="FechaDes" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Despachado" HeaderText="Despachada" ItemStyle-Width="85px"
                                    UniqueName="Despachado" ItemStyle-HorizontalAlign="Left">
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
                <%--<asp:Label ID="Label6" runat="server" Text=""></asp:Label>--%>
                </div>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <br>
</asp:Content>
