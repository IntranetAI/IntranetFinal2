<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleDevolucionInterna.aspx.cs" Inherits="Intranet.ModuloDespacho.View.DetalleDevolucionInterna" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css">
        .style1
        {
            margin-left: 40px;
        }
        .style2
        {
        }
        .style3
        {
            width: 211px;
            margin-left: 40px;
        }
        .style4
        {
        }
        .style5
        {
            width: 202px;
        }
    </style>
</head>

<body onload="window.print();">
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ToolkitScriptManager>
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Devolución Interna a Encuadernación" 
            Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        
        <br />
        <br />
        
    </div>
    
        <table style="width:100%;" border="1px">
            <tr>
                <td class="style3">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo color lateral.jpg" 
                        Height="50px" Width="172px" />
                </td>
                <td class="style2" colspan="2">
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="OT:" 
                        Font-Bold="True"></asp:Label>
&nbsp;&nbsp;<asp:Label ID="lblOT" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="Cliente:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style2" colspan="2">
                    <asp:Label ID="lblCliente" runat="server" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label6" runat="server" Text="Producto:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style2" colspan="2">
                    <asp:Label ID="lblProducto" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Tiraje OT:" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style4" colspan="2">
                    <asp:Label ID="lblTirajeOT" runat="server" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label7" runat="server" Text="Causa Devolución:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblCausa" runat="server" Font-Size="Large"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Observación:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                    <asp:Label ID="lblObservacion" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label8" runat="server" Text="Cantidad Recepcionada:" 
                        Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblCantidad" runat="server" Font-Size="Large"></asp:Label>
                &nbsp;<asp:Label ID="Label11" runat="server" Text="Ejemplares." Font-Size="Large"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="3">
                    &nbsp;</td>
            </tr>
        </table>
    <fieldset>
    <legend>Detalle Devolución</legend>
      
      <div id="divGuias">
      <br />
        <div align="center">
          <asp:Label ID="Label4" runat="server" Text="Detalle Guias Devueltas" 
                Font-Size="Large"></asp:Label>
        </div>
        <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="guia">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="guia" HeaderText="N° Guia"  UniqueName="guia" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Sucursal" HeaderText="Tipo Devolucion" UniqueName="Sucursal" ItemStyle-Width="220px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="60px" UniqueName="Cantidad"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaDespacho" HeaderText="Fecha Despacho" SortExpression="FechaDespacho" UniqueName="FechaDespacho" ItemStyle-Width="120px" DataFormatString="{0:dd-MM-yyyy HH:mm}" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
      </div>
      <br />
      <br />
      <div id="divEmbalaje">
        <div align="center">
          <asp:Label ID="Label5" runat="server" Text="Detalle Devolucion" 
                Font-Size="Large"></asp:Label>
        </div>
        <telerik:radgrid ID="RadGrid2" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="OT" HeaderText="OT"  UniqueName="OT"   >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="Tipo Embalaje" UniqueName="TipoEmbalaje"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad Ejemplares"  UniqueName="Cantidad"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>




              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
      </div>
    </fieldset>
    <div align="center" style="width: 919px">
    <br />
        <asp:Image ID="imgCodigo" runat="server" />
 <br />
        <asp:Label ID="lblFolio" runat="server"></asp:Label>
         </div>  


          
   
    

    </form>
</body>
</html>
