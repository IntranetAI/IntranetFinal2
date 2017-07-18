<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirInformePorOT.aspx.cs" Inherits="Intranet.ModuloDespacho.View.ImprimirInformePorOT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .style1
        {
            width: 242px;
        }
    </style>

</head>
<body onload="window.print();">
    <form id="form1" runat="server">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False"></asp:ToolkitScriptManager>
                <div>
                    <table style="width:100%;">
                        <tr>
                            <td class="style1">
                                <asp:Image ID="Image1" runat="server" Height="54px" 
                                    ImageUrl="~/Images/logo color lateral.jpg" Width="184px" />
                            </td>
                            <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
       <asp:Label ID="lblTitulo" runat="server" Text="INFORME POR OT" Font-Bold="True" 
           Font-Size="X-Large"></asp:Label>
                                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Label ID="lblTitulo2" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </td>
                        </tr>
                    </table>
    <br />
                        <telerik:radgrid ID="RadGrid1" runat="server"   Skin="Outlook"

                     >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT" ItemStyle-Width="30px">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="TipoMovimiento" HeaderText="Tipo Movimiento" SortExpression="TipoMovimiento" 
                                UniqueName="TipoMovimiento" ItemStyle-Width="50px">
                                </telerik:GridBoundColumn>

                                   <telerik:GridBoundColumn DataField="Folio" HeaderText="Nº Guia" ItemStyle-HorizontalAlign="Center" 
                                ReadOnly="True" SortExpression="Folio" UniqueName="Folio" ItemStyle-Width="70px">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="NombreOT" ItemStyle-Width="180px">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Sucursal" 
                            UniqueName="Cliente" ItemStyle-Width="200px">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="FechaImpresion" HeaderText="Fecha Despacho" 
                                SortExpression="FechaImpresion" UniqueName="FechaImpresion" ItemStyle-Width="80px" DataFormatString="{0:dd/MM/yyyy HH:mm}"></telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="TirajeTotal" HeaderText="Tiraje Total" 
                            UniqueName="TirajeTotal" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                           
                           
                           <telerik:GridBoundColumn DataField="Despachado" HeaderText="Total Des." 
                            UniqueName="Despachado" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
              
              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>

                                 <telerik:radgrid ID="RadGrid2" Visible="false" runat="server" Skin="Outlook" >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT" ItemStyle-Width="30px">
                                </telerik:GridBoundColumn>

                                
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT" 
                                UniqueName="NombreOT" ItemStyle-Width="250px">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" 
                            UniqueName="Cliente" ItemStyle-Width="250px">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="FechaMinima" HeaderText="Fecha Inicio" 
                                SortExpression="FechaMinima" UniqueName="FechaMinima" ItemStyle-Width="160px" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"></telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn DataField="FechaMaxima" HeaderText="Fecha Termino" 
                                SortExpression="FechaMaxima" UniqueName="FechaMaxima" ItemStyle-Width="160px" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"></telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="TirajeTotal" HeaderText="Tiraje Total" 
                            UniqueName="TirajeTotal" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                           
                           
                           <telerik:GridBoundColumn DataField="Despachado" HeaderText="Total Despachado" 
                            UniqueName="Despachado" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
              
              
              
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
    </div>
    </form>
</body>
</html>
