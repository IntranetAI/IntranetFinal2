<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manifiesto_CargaDetalle.aspx.cs"
    Inherits="Intranet.ModuloDespacho.View.Manifiesto_CargaDetalle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ToolkitScriptManager>
    N° de Factura<asp:Label ID="lblNFactura" runat="server" Text=""></asp:Label>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="300px"
        Width="570px">
        <asp:TabPanel runat="server" HeaderText="Costo Fijo" ID="TabPanel0">
            <HeaderTemplate>
                Producto Terminado</HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            OT
                        </td>
                        <td style="width: 70px;">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 110px;">
                            Nombre OT
                        </td>
                        <td>
                            <asp:Label ID="lblNombreOtFijo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Tipo Envio
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoEnvio" runat="server">
                                <asp:ListItem>Pallet</asp:ListItem>
                                <asp:ListItem>A Piso</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Cantidad"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div style="max-height: 130px; overflow-y: scroll;">
                                <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook">
                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="NFactura">
                                        <NoRecordsTemplate>
                                            <div style="text-align: center;">
                                                <br />
                                                ¡ No se han encontrado OTs Nuevas !<br />
                                            </div>
                                        </NoRecordsTemplate>
                                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" UniqueName="OT">
                                                <ItemStyle Width="50px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" UniqueName="Cantidad">
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Proceso" HeaderText="Proceso" UniqueName="Proceso">
                                                <ItemStyle Width="150px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PrecioUnit" HeaderText="Precio Unitario" UniqueName="PrecioUnit">
                                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Total" HeaderText="Total" Visible="False" UniqueName="Total">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Action" HeaderText="Editar/Eliminar" UniqueName="Action">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="True">
                                    </ClientSettings>
                                    <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        
                        <td colspan="4" align="center">
                            <asp:Button ID="btnAgregarFijo" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                        </td>
                        
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" HeaderText="Costo Variable" ID="TabPanel1">
            <HeaderTemplate>Planificado</HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            OT
                        </td>
                        <td style="width: 70px;">
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 100px;">
                            Nombre OT
                        </td>
                        <td>
                            <asp:Label ID="lblNombreOTVari" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr><td colspan="4"></td></tr>
                    <tr>
                        <td>
                        </td>
                        <td style="width: 70px;">
                            <asp:Button ID="btnagregarvari" runat="server" Text="Agregar" OnClick="btnagregarvari_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnModificarvari" runat="server" Text="Modificar" Visible="False"
                                OnClick="btnModificarvari_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    <div style="max-height: 130px; overflow-y: scroll;">
        <telerik:RadGrid ID="RgTemporal" runat="server" Skin="Outlook">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="NFactura">
                <NoRecordsTemplate>
                    <div style="text-align: center;">
                        <br />
                        ¡ No se han encontrado OTs Nuevas !<br />
                    </div>
                </NoRecordsTemplate>
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" UniqueName="OT" ItemStyle-Width="50px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" UniqueName="Cantidad"
                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Proceso" HeaderText="Proceso" ItemStyle-Width="150px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PrecioUnit" HeaderText="Precio Unitario" ItemStyle-Width="80px"
                        ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Total" HeaderText="Total" Visible="false" ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Action" HeaderText="Editar/Eliminar">
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
    <div align="center">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />&nbsp;
        <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
    </div>
    <asp:Label ID="lblUsuario" runat="server" Visible="false"></asp:Label>
    </form>
</body>
</html>
