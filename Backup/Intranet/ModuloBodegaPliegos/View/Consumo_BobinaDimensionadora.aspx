<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consumo_BobinaDimensionadora.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.Consumo_BobinaDimensionadora" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" runat="server">
    <fieldset>
        <legend>Datos OT</legend>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="OT" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOT" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Pliego" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPliego" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Folio"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFolio" runat="server"></asp:Label>
                </td>
                <td>Cantidad</td>
                <td><asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label> </td>
            </tr>
        </table>
    </fieldset>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <fieldset style="width: 578px; height: 355px;">
        <div style="margin-top: 5px;">
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Height="300px"
                Width="570px">
                <asp:TabPanel runat="server" HeaderText="Codigo Bobina" ID="TabPanel0">
                    <HeaderTemplate>
                        Agregar</HeaderTemplate>
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 120px;">
                                    Codigo Bobina
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodigoB" runat="server" AutoPostBack="True" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" Visible="False">
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Proveedor">
                                            <NoRecordsTemplate>
                                                <div style="text-align: center;">
                                                    <br />
                                                    ¡ No se han encontrado OTs Nuevas !<br />
                                                </div>
                                            </NoRecordsTemplate>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Proveedor" ReadOnly="True"
                                                    SortExpression="Proveedor" UniqueName="Proveedor">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" UniqueName="Marca"
                                                    SortExpression="Marca">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tipo" HeaderText="Tipo de Papel" ReadOnly="True"
                                                    UniqueName="Tipo">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Peso_Original" HeaderText="Peso Original" SortExpression="Peso_Original"
                                                    UniqueName="Peso_Original" DataType="System.Int32" DataFormatString="{0:N0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Gramage" HeaderText="Gramage" UniqueName="Gramage"
                                                    DataType="System.Int32" DataFormatString="{0:N0}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" UniqueName="Ancho"
                                                    DataType="System.Int32" DataFormatString="{0:N0}">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView><ClientSettings EnableRowHoverStyle="True">
                                        </ClientSettings>
                                        <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px;">
                                    Bobina
                                </td>
                                <td>
                                    <asp:Label ID="lblBobina" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &#160;&#160;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px;">
                                    Estado Bobina
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" OnTextChanged="ddlEstado_TextChanged">
                                        <asp:ListItem Value="1">En Buen Estado</asp:ListItem>
                                        <asp:ListItem Value="2">En Mal Estado</asp:ListItem>
                                    </asp:DropDownList>
                                    &#160;&nbsp;<asp:DropDownList ID="ddlResponsable" runat="server" AutoPostBack="True"
                                         Visible="False" onselectedindexchanged="ddlResponsable_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                        <asp:ListItem Value="2">Rollero</asp:ListItem>
                                        <asp:ListItem Value="3">Almacén</asp:ListItem>
                                        <asp:ListItem Value="4">Otros Daños</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblcausa" runat="server" Text="Tipo Daño" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCausa" runat="server" Visible="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblPeso_tapa" runat="server">Peso Tapas</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTapa" runat="server"></asp:TextBox>&#160;Kg.
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblPesoEnvoltura" runat="server">Peso Envoltura</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmboltorio" runat="server"></asp:TextBox>&#160;Kg.
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblEscarpe" runat="server">Peso Escarpe</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEscarpe" runat="server"></asp:TextBox>&#160;Kg.
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <br />
                                    <div runat="server" id="Validacion" visible="False">
                                        <asp:Image ID="Image" runat="server" /><asp:Label ID="lblvalidacion" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtobs" runat="server" TextMode="MultiLine" Visible="False" 
                                            Width="409px"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" 
                                        onclick="btnGrabar_Click" />
                                    <asp:Button ID="btnVolver" runat="server" Text="Cancelar" 
                                        onclick="btnVolver_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Cierre Bobina" ID="TabPanel1">
                    <HeaderTemplate>
                        Cierre</HeaderTemplate>
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3">
                                    <telerik:RadGrid ID="RadGrid2" runat="server" Skin="Outlook">
                                        <ClientSettings EnableRowHoverStyle="True">
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Proveedor">
                                            <NoRecordsTemplate>
                                                <div style="text-align: center;">
                                                    <br />
                                                    ¡ No se han encontrado OTs Nuevas !<br />
                                                </div>
                                            </NoRecordsTemplate>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo"
                                                    UniqueName="Codigo">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Proveedor" ReadOnly="True"
                                                    SortExpression="Proveedor" UniqueName="Proveedor">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" SortExpression="Marca"
                                                    UniqueName="Marca">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tipo" HeaderText="Tipo de Papel" ReadOnly="True"
                                                    UniqueName="Tipo">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Peso_Original" DataFormatString="{0:N0}" DataType="System.Int32"
                                                    HeaderText="Peso Original" SortExpression="Peso" UniqueName="Peso_Original">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Gramage" DataFormatString="{0:N0}" DataType="System.Int32"
                                                    HeaderText="Gramage" UniqueName="Gramage">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Ancho" DataFormatString="{0:N0}" DataType="System.Int32"
                                                    HeaderText="Ancho" UniqueName="Ancho">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView><HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"
                                            EnableImageSprites="True">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid><asp:Label ID="IDBobina" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Peso Tapa
                                </td>
                                <td>
                                    <asp:Label ID="lbltapa" runat="server"></asp:Label>&#160;Kg.
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Peso Envoltura
                                </td>
                                <td>
                                    <asp:Label ID="lblEnvoltura" runat="server"></asp:Label>&#160;Kg.
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Peso Escarpe
                                </td>
                                <td>
                                    <asp:Label ID="lblEscarClose" runat="server"></asp:Label>&#160;Kg.
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Residuo
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSaldo" runat="server" AutoPostBack="True" OnTextChanged="ddlSaldo_TextChanged">
                                        <asp:ListItem Value="0">Seleccione..</asp:ListItem>
                                        <asp:ListItem Value="1">Con Saldo</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Saldo</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblConoR" runat="server" Text="Peso Cono" Visible="False"></asp:Label><asp:Label
                                        ID="lblPesoFBobina" runat="server" Text="Peso Saldo" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCono" runat="server" Visible="False"></asp:TextBox>&#160;<asp:TextBox
                                        ID="txtSaldo" runat="server" Visible="False"></asp:TextBox><asp:Label ID="lblKilos"
                                            runat="server" Text="Kg." Visible="False"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <div id="Validacion0" runat="server" visible="False">
                                        <asp:Image ID="Image0" runat="server" /><asp:Label ID="lblvalidacion0" runat="server"></asp:Label></div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btnConsumir" runat="server" Text="Cerrar Bobina" 
                                        onclick="btnConsumir_Click" /></input></input></input></input></input></input></input></input></input></input></input><asp:Button
                                        ID="btnVolverB" runat="server" OnClick="btnVolver_Click" Text="Volver" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </div>
    </fieldset>
    <asp:Label ID="lblUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblSKU" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblNombreOt" runat="server" Visible="false"></asp:Label>
    
    </form>
</body>
</html>
