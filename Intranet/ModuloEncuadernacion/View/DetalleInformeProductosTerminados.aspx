<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleInformeProductosTerminados.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.DetalleInformeProductosTerminados" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <div>
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" 
            Font-Size="X-Large"></asp:Label>
    
    </div>
    <div align="right">
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" 
            onclick="btnImprimir_Click" Width="97px" />
    </div>
    <br />
        <%--    <div style="border:1px solid blue;height:478px;overflow:scroll;" >--%>
                <telerik:RadGrid ID="RadGrid3" BorderWidth="0px" runat="server"  Skin="Outlook">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="id_ProductosTerminados">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="cod_Pallet" HeaderText="Pallet" 
                                ReadOnly="True" SortExpression="cod_Pallet" UniqueName="cod_Pallet">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                                SortExpression="NombreOT" UniqueName="NombreOT">
                                <ItemStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Terminacion"   HeaderText="Terminacion" UniqueName="Terminacion">
                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="Tipo Embalaje" 
                                UniqueName="TipoEmbalaje">
                                <ItemStyle Width="60px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Total" HeaderText="Total" 
                                ReadOnly="True" SortExpression="Total" UniqueName="Total">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn Visible="false" DataField="FechaCreacion" HeaderText="FechaCreacion" 
                                ReadOnly="True" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" 
                                ReadOnly="True" SortExpression="Observacion" UniqueName="Observacion">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Validado" HeaderText="Validado" 
                                ReadOnly="True" SortExpression="Validado" UniqueName="Validado">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="FechaValidacion" HeaderText="FechaValidacion" 
                                ReadOnly="True" SortExpression="FechaValidacion" UniqueName="FechaValidacion">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Modificado" HeaderText="Estado" 
                                ReadOnly="True" SortExpression="Modificado" UniqueName="Modificado">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>

                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                        EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                </div>
    
<%--    </div>--%>
    <br />
    <div align="center">
        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Ventana" 
            onclick="btnCerrar_Click" /></div>
    </form>
</body>
</html>
