<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Metrics_HistorialPallet.aspx.cs" Inherits="Intranet.ModuloWip.View.Metrics_HistorialPallet" %>
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
    <div align="center">

    
        <asp:Label ID="lblEncabezado" runat="server"></asp:Label>
    </div>
        <br />
      <div style="border:1px solid blue;min-height:300px; max-height:466px;overflow-y:auto;" >
               <telerik:RadGrid ID="RadGridOT" BorderWidth="0px" runat="server"  Skin="Outlook" 
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="FechaCreacion">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>


                              <telerik:GridBoundColumn DataField="Movimiento" HeaderText="Movimiento" 
                                SortExpression="Movimiento" UniqueName="Movimiento">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ubicacion" 
                                UniqueName="Ubicacion">
                                <ItemStyle Width="120px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Posicion" HeaderText="Posicion" 
                                ReadOnly="True" SortExpression="Posicion" UniqueName="Posicion" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="80px"/>
                            </telerik:GridBoundColumn>

                            
                            <telerik:GridBoundColumn DataField="Usuario" HeaderText="Usuario" 
                                ReadOnly="True" SortExpression="Usuario" UniqueName="Usuario" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="80px"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha" 
                                ReadOnly="True" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                                <ItemStyle Width="120px" />
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
    </form>
</body>
</html>
