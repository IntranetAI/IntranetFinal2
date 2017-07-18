<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Mantenedor_Presupuesto.aspx.cs" Inherits="Intranet.ModuloComercial.View.Mantenedor_Presupuesto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function Agregar() {
            var Usuario = '<%= Session["Usuario"] %>';

            onload(window.open('Mantenedor_ValorTrimestral.aspx?user=' + Usuario, 'Valor Trimestral', 'toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=yes,directories=no, width=410,height=320,left=340,top=200'));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnFiltro" runat="server" Text="Asignar" Width="73px" Style="height: 26px"
        Visible="false" OnClick="btnFiltro_Click" />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="500px"
        Width="1090px">
        <asp:TabPanel runat="server" HeaderText="Lista Guia Despacho" ID="TabPanel1">
            <HeaderTemplate>
                Valor Trimestre Q<br />
                &nbsp;
            </HeaderTemplate>
            <ContentTemplate>
                <div align="right" style="width: 100%;">
                    <a id="ida" runat="server" onclick="javascript:Agregar()" style="color: #000000;
                        text-decoration: blink;">
                        <img alt="" src="../../Images/boton-mas_azul.jpg" width="20" />Agregar Valor Trimestral&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </a>
                </div>
                <div style="max-height: 500px; width: 1070px; overflow: auto; border: 1px inset blue;">
                    <telerik:RadGrid ID="RadGridValorQ" runat="server" BorderWidth="0px" Skin="Outlook"
                        Height="100%" GridLines="None">
                        <ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID_Trimestre">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado Guia De Despacho !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="ValorTrimestre" HeaderText="Valor Trimestre"
                                    SortExpression="ValorTrimestre" UniqueName="ValorTrimestre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreTrimestre" HeaderText="Nombre Trimestre"
                                    SortExpression="NombreTrimestre" UniqueName="NombreTrimestre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="Fecha Inicio" SortExpression="FechaInicio"
                                    UniqueName="FechaInicio">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="Fecha Termino" UniqueName="FechaTermino">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" SortExpression="Estado"
                                    UniqueName="Estado">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UsuarioCreador" HeaderText="Usuario" SortExpression="UsuarioCreador"
                                    UniqueName="UsuarioCreador">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Orden de Carga" ID="TabPanel2">
            <HeaderTemplate>
                Lista Papeles
            </HeaderTemplate>
            <ContentTemplate>
                <div align="right" style="width: 1070px;">
                    <a title="Exportar a Excel">
                        <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                            Width="20px" Visible="True" OnClick="ibExcel_Click" /></a>
                </div>
                <div style="max-height: 480px; width: 1070px; overflow: auto; border: 1px inset blue;">
                    <telerik:RadGrid ID="RadGridPapeles" runat="server" BorderWidth="0px" Skin="Outlook"
                        Width="1600px" Height="475px" OnItemCommand="RadGrid1_ItemCommand">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID_Papel">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado Ordenes !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="ID_Papel" HeaderText="ID_Papel" UniqueName="ID_Papel"
                                    Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="Gramaje">
                                    <HeaderTemplate>
                                        Gramaje
                                    </HeaderTemplate>
                                    <ItemStyle Width="30px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGramaje" runat="server" Width="30px" Text='<%#Eval("Gramaje") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="Presentación">
                                    <HeaderTemplate>
                                        Presentación
                                    </HeaderTemplate>
                                    <ItemStyle Width="50px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPresentacion" runat="server" Width="50px" Text='<%#Eval("Presentacion") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="Costo Papel Tonelada">
                                    <HeaderTemplate>
                                        Costo Papel Tonelada
                                    </HeaderTemplate>
                                    <ItemStyle Width="30px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCostoPapelTonelada" runat="server" Width="50px" Text='<%#Eval("CostoPapelTonelada") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="Gasto Bodega">
                                    <HeaderTemplate>
                                        Gasto Bodega
                                    </HeaderTemplate>
                                    <ItemStyle Width="30px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGastoBodega" runat="server" Width="30px" Text='<%#Eval("GastoBodega") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="Componente">
                                    <HeaderTemplate>
                                        Componente
                                    </HeaderTemplate>
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtComponente" runat="server" Width="100px" Text='<%#Eval("Componente") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn CommandName="Modificar" Text="Modificar" UniqueName="Modificar"
                                    HeaderText="Modificar">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="TipoPapel" HeaderText="Tipo Papel" UniqueName="TipoPapel"
                                    ItemStyle-Width="150px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" UniqueName="Marca">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombrePapel" HeaderText="Nombre Papel" UniqueName="NombrePapel">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Origen" HeaderText="Origen" UniqueName="Origen">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="GastoImportacion" HeaderText="Gasto Import."
                                    UniqueName="GastoImportacion">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CostoCIFUS" HeaderText="Costo Cifus" UniqueName="CostoCIFUS">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BodegaSeguro" HeaderText="Bodegaje, Seguros y Otros"
                                    UniqueName="BodegaSeguro">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Obsolencia" HeaderText="Obsolecencia & Margen"
                                    UniqueName="Obsolencia">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CortePliego" HeaderText="Corte Pliegos" UniqueName="CortePliego">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ValorBase" HeaderText="Valor Base" UniqueName="ValorBase">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="InferiorCL" HeaderText="Inferior CL" UniqueName="InferiorCL">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FacturaCL" HeaderText="Factura CL" UniqueName="FacturaCL">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SuperiorCL" HeaderText="Superior CL" UniqueName="SuperiorCL">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Empresas" HeaderText="Empresas" UniqueName="Empresas">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ValorTrimestre" HeaderText="ValorTrimestre" UniqueName="ValorTrimestre"
                                    Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true">
                        </ClientSettings>
                        <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>
