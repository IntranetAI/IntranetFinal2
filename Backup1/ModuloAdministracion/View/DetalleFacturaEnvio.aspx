<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleFacturaEnvio.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.DetalleFacturaEnvio" %>
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

                <telerik:GridBoundColumn DataField="NombreItem" HeaderText="NombreItem" UniqueName="NombreItem" ItemStyle-Width="200px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="CantItem" HeaderText="Cantidad" UniqueName="CantItem" ItemStyle-Width="40px"  >
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

                                 <telerik:GridBoundColumn DataField="Mensaje" HeaderText="Mensaje" UniqueName="Mensaje" ItemStyle-Width="50px"  >
                 <ItemStyle  HorizontalAlign="Left"/>
                </telerik:GridBoundColumn>   

                <telerik:GridBoundColumn DataField="CreadaPor" HeaderText="Creada Por" UniqueName="CreadaPor" ItemStyle-Width="120px"  >
                 <ItemStyle  HorizontalAlign="Right"/>
                </telerik:GridBoundColumn>   

      
                              
                    
              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
    </div>
    <br />
    <div align="center">
    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir"  />
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCerrarVentana" runat="server" Text="Cerrar Ventana"  />
    </div>
    </form>
</body>
</html>
