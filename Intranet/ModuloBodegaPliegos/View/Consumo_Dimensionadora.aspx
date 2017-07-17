<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Consumo_Dimensionadora.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.Consumo_Dimensionadora" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 38px;
        }
    </style>
  <script type="text/javascript">
        function Agregar() {
            var ot = document.getElementById("ContentPlaceHolder1_lblOT").innerHTML;
            var nombreOT = document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML;
            var folio = document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
            var componente = document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML;
            var tiraje = document.getElementById("ContentPlaceHolder1_lblCantidad").innerText;
            onload(window.open('Consumo_BobinaDimensionadora.aspx?o=' + ot + '&c=' + componente + '&f=' + folio + '&t=' + tiraje+'&n='+nombreOT, 'Consumo Bobina', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=500,left=340,top=200'));
        }
        function Falla(id) {
            var Usuario = '<%= Session["Usuario"]%>';
            onload(window.open('../../ModuloRFrecuencia/View/Falla_Corte.aspx?id=' + id + '&User=' + Usuario, 'Consumo Bobina', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=627,height=500,left=340,top=200'));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color: #EEE; border: 1px solid #999; width: 825px;">
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="OT:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Folio:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFolio" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click1" />
            </td>
        </tr>
    </table>
    <br />
    <div id="divDimensionadora" runat="server" style="display: block;">
        <%--style="display:none;"--%>
        <div class="divSeccion">
            <div id="GridDimensionadora" style="height: 500px; width: 1100px; overflow: auto;">
                <telerik:RadGrid ID="RadGrid2" runat="server" Skin="Outlook"  ClientSettings-EnablePostBackOnRowClick="true"
                    onitemcommand="RadGrid2_ItemCommand">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                        <NoRecordsTemplate>
                            <div style="text-align: center;">
                                <br />
                                ¡ No se han encontrado registros !<br />
                            </div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Folio" ItemStyle-Width="65px"
                                ItemStyle-HorizontalAlign="Center" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"
                                SortExpression="OT" UniqueName="OT">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Componente" HeaderText="Componente" ItemStyle-Width="50px"
                                ItemStyle-HorizontalAlign="Center" SortExpression="Componente" UniqueName="Componente">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="185px"
                                ItemStyle-HorizontalAlign="Left" SortExpression="NombreOT" UniqueName="NombreOT">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="290px"
                                SortExpression="Papel" ItemStyle-HorizontalAlign="Left" UniqueName="Papel">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px"
                                ItemStyle-HorizontalAlign="Right" SortExpression="Gramaje" UniqueName="Gramaje">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="40px"
                                ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px"
                                ItemStyle-HorizontalAlign="Right" SortExpression="Largo" UniqueName="Largo">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StockFL" HeaderText="Cantidad" ItemStyle-Width="30px"
                                ItemStyle-HorizontalAlign="Right" SortExpression="StockFL" UniqueName="StockFL">
                            </telerik:GridBoundColumn>
                        <%--    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="40px"
                                SortExpression="Accion" UniqueName="Accion">
                            </telerik:GridBoundColumn>--%>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="true">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </div>
        </div>
    </div>
    <div runat="server" id="divPliego" visible="false">
        <fieldset style="width: 1066px;">
            <legend>Información Bobina</legend>
            <table width="100%">
                <tr>
                    <td>OT:</td>
                    <td>
                        <asp:Label ID="lblOT" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Componente</td>
                    <td>
                        <asp:Label ID="lblComponente" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Folio</td>
                    <td><asp:Label ID="lblFolio" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Nombre OT</td>
                    <td>
                        <asp:Label ID="lblNombreOT" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Cantidad</td>
                    <td>
                        <asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </fieldset>
        <fieldset style="width: 1066px;">
            <legend>Información Bobina</legend>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="290px"
                Width="1070px">
                <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Asignación Bobina">
                    <ContentTemplate>
                        <div align="right" style="width: 1050px;">
                            <a id="ida" runat="server" onclick="javascript:Agregar()" style="color: #000000;
                                text-decoration: blink;">
                                <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" />Agregar Bobina
                            </a>

                        </div>
                        <div style="height: 280px; width: 1050px; overflow: auto;">
                            <telerik:RadGrid ID="RadGrid4" runat="server" Skin="Outlook" 
                                OnItemCommand="RadGrid4_ItemCommand">
<ClientSettings EnableRowHoverStyle="True" EnablePostBackOnRowClick="True"></ClientSettings>

<MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOp"><NoRecordsTemplate>
                                        <div style="text-align: center;">
                                            <br />
                                            ¡ No se han encontrado registros !<br />
                                        </div>
                                    
</NoRecordsTemplate>

<CommandItemSettings ExportToPdfText="Export to Pdf" />
<Columns>
<telerik:GridBoundColumn DataField="ID_Bobina" HeaderText="Nº OT" ReadOnly="True"
                                            SortExpression="ID_Bobina" UniqueName="ID_Bobina" Visible="False">
<ItemStyle Width="30px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="NumeroOp" HeaderText="Nº OT" ReadOnly="True"
                                            SortExpression="NumeroOp" UniqueName="NumeroOp">
<ItemStyle Width="30px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Codigo" HeaderText="Codigo Bobina" SortExpression="Codigo"
                                            UniqueName="Codigo">
<ItemStyle Width="80px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Marca" HeaderText="Marca de Bobina" SortExpression="Marca"
                                            UniqueName="Marca">
<ItemStyle Width="150px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Proveedor" HeaderText="Tipo de Papel" SortExpression="Proveedor"
                                            UniqueName="Proveedor">
<ItemStyle Width="150px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Gramage" HeaderText="Gramage" UniqueName="Gramage">
<ItemStyle HorizontalAlign="Right" Width="50px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" UniqueName="Ancho">
<ItemStyle HorizontalAlign="Right" Width="50px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Fecha_Consumo" HeaderText="Fecha" SortExpression="FechaDes"
                                            UniqueName="FechaDes" DataFormatString="{0:dd/MM/yyyy HH:mm}">
<ItemStyle Width="150px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Peso_Original" HeaderText="Peso Bobina" UniqueName="Peso_Original">
<ItemStyle Width="80px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Cono" HeaderText="Corte Banda" UniqueName="Cono">
<ItemStyle Width="30px" />
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Tipo" HeaderText="Estado Bobina" UniqueName="Despachado">
<ItemStyle Width="150px" />
</telerik:GridBoundColumn>
</Columns>
</MasterTableView>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True"></HeaderContextMenu>
</telerik:RadGrid>

                        </div>
                    
</ContentTemplate>
                
</asp:TabPanel>
                <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Bobinas Consumidas">
                    <ContentTemplate>
                        <div style="height: 280px; width: 1050px; overflow: auto;">
                            <telerik:RadGrid ID="RadGrid5" runat="server" Skin="Outlook">
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="NumeroOp">
                                    <NoRecordsTemplate>
                                        <div style="text-align: center;">
                                            <br />
                                            ¡ No se han encontrado registros !<br />
                                        </div>
                                    </NoRecordsTemplate>
                                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Codigo" HeaderText="Codigo Bobina" SortExpression="NombreOT"
                                            UniqueName="NombreOT">
                                            <ItemStyle Width="80px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Tipo de Papel" SortExpression="NombreOT"
                                            UniqueName="NombreOT">
                                            <ItemStyle Width="150px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Gramage" HeaderText="Gramage" UniqueName="Cant">
                                            <ItemStyle HorizontalAlign="Right" Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" UniqueName="Ancho"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Fecha_Consumo" HeaderText="Fecha" SortExpression="FechaDes"
                                            UniqueName="FechaDes" DataFormatString="{0:dd/MM/yyyy HH:mm}">
                                            <ItemStyle Width="150px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Peso_Original" HeaderText="Peso Bobina" UniqueName="Peso_Original"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Peso_Tapa" HeaderText="Peso Tapa" UniqueName="Peso_Tapa"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Peso_emboltorio" HeaderText="Peso Envoltorio"
                                            UniqueName="Peso_emboltorio" ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PesoEscarpe" HeaderText="Peso Escarpe" UniqueName="PesoEscarpe"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Peso_Cono" HeaderText="Peso Cono" UniqueName="Peso_Cono"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Saldo" HeaderText="Saldo" UniqueName="Saldo"
                                            ItemStyle-Width="30px">
                                        </telerik:GridBoundColumn>
                                        </Columns>
                                </MasterTableView><ClientSettings EnableRowHoverStyle="True">
                                </ClientSettings>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                </HeaderContextMenu>
                            </telerik:RadGrid></div>
                    
</ContentTemplate>
                
</asp:TabPanel>
            </asp:TabContainer>
        </fieldset>
    </div>

            </table>


</asp:Content>
