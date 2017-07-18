<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleFacturaProveedor.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.DetalleFacturaProveedor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
    <br />
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" 
            Font-Size="X-Large"></asp:Label></div>
    <br />
    <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Folio">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" UniqueName="Folio" ItemStyle-Width="40px"  >
                <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn DataField="RutEmisor" HeaderText="Rut Emisor"  UniqueName="RutEmisor" ItemStyle-Width="30px"  >
                <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>


       <%--         <telerik:GridBoundColumn DataField="NombreEmisor" HeaderText="NombreEmisor" UniqueName="NombreEmisor" ItemStyle-Width="250px"  >
                </telerik:GridBoundColumn>--%>

                <telerik:GridBoundColumn DataField="NombreItem" HeaderText="NombreItem" UniqueName="NombreItem" ItemStyle-Width="200px"  >
                </telerik:GridBoundColumn>
                                                
                <telerik:GridBoundColumn DataField="CantItem" HeaderText="Cant. Item" UniqueName="CantItem" ItemStyle-Width="40px"  >
                <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="PrecioItem" HeaderText="PrecioItem" UniqueName="PrecioItem" ItemStyle-Width="40px"  >
                <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="FechaEmision" HeaderText="FechaEmision" UniqueName="FechaEmision" ItemStyle-Width="50px"  >
                <ItemStyle  HorizontalAlign="Center"/>
                </telerik:GridBoundColumn>

                
                 <telerik:GridBoundColumn DataField="FechaVencimiento" HeaderText="Fecha Venc." UniqueName="FechaVencimiento" ItemStyle-Width="50px"  >
                 <ItemStyle  HorizontalAlign="Center"/>
                </telerik:GridBoundColumn>   

                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" UniqueName="Estado" ItemStyle-Width="130px"  >
                <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>
      
                              
                    
              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
    </div>
    <p>
        &nbsp;</p>
        <div align="center">
    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir"  />
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCerrarVentana" runat="server" Text="Cerrar Ventana" 
                onclick="btnCerrarVentana_Click" />
    </div>
    </form>
</body>
</html>
