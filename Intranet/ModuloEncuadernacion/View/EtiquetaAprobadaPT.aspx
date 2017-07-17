<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EtiquetaAprobadaPT.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.EtiquetaAprobadaPT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print();">
            
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ToolkitScriptManager>
    <div align="center">
    
        <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="XX-Large" 
            Text="Detalle Productos Terminados"></asp:Label>
            <br />

    <br />
    <br />
    <br />
    </div>
    <table style="width:100%;" border="1px">
        <tr>
            <td class="style2" align="center" style="padding:20px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo color lateral.jpg" width="159px" height="39px" />
            </td>
            <td align="center">
<asp:Label ID="Label2" runat="server" Text="Detalle Pallet " Font-Bold="True" 
            Font-Size="X-Large"></asp:Label>

        <asp:Label ID="lblPallet" runat="server" Font-Bold="True" Font-Italic="False" 
            Font-Size="X-Large"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="style3" align="center" colspan="2">
            <telerik:RadGrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook" >

        <MasterTableView AutoGenerateColumns="False" DataKeyNames="id_ProductosTerminados">
            <NoRecordsTemplate>
                <div style="text-align:center;">
                    <br />¡ No se han encontrado registros !<br /></div>
            </NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>

              <telerik:GridBoundColumn Visible="false" DataField="id_ProductosTerminados" HeaderText="id_ProductosTerminados" 
                    ItemStyle-Width="50px" ReadOnly="True" SortExpression="id_ProductosTerminados" 
                    UniqueName="id_ProductosTerminados">
                    <ItemStyle Width="50px" />
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                    ItemStyle-Width="50px" ReadOnly="True" SortExpression="OT" 
                    UniqueName="OT">
                    <ItemStyle Width="50px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="360px" 
                    SortExpression="NombreOT" UniqueName="NombreOT">
                    <ItemStyle HorizontalAlign="Left" Width="360px" />
                </telerik:GridBoundColumn>      

                                <telerik:GridBoundColumn DataField="Terminacion" HeaderText="Terminación" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" 
                    SortExpression="Terminacion" UniqueName="Terminacion">
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                </telerik:GridBoundColumn>  
                
             
                <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="TipoEmbalaje" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" 
                    SortExpression="TipoEmbalaje" UniqueName="TipoEmbalaje">
                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                </telerik:GridBoundColumn>  

              <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Bultos" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" 
                    SortExpression="Cantidad" UniqueName="Cantidad">
                  <ItemStyle HorizontalAlign="Left" Width="60px" />
                </telerik:GridBoundColumn>  


                <telerik:GridBoundColumn   DataField="Ejemplares" HeaderText="Unidad Empaque" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Ejemplares" UniqueName="Ejemplares">
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                </telerik:GridBoundColumn>  

                
                <telerik:GridBoundColumn DataField="Total" HeaderText="Total" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40px" 
                    SortExpression="Total" UniqueName="Total">
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>  

                

                <telerik:GridBoundColumn DataField="Modelo" HeaderText="Modelo" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="60px" 
                    SortExpression="Modelo" UniqueName="Modelo">
                    <ItemStyle HorizontalAlign="Right" Width="60px" />
                </telerik:GridBoundColumn>  
                 
                <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="170px" 
                    SortExpression="Observacion" UniqueName="Observacion">
                    <ItemStyle HorizontalAlign="Left" Width="170px" />
                </telerik:GridBoundColumn> 



<%--              <telerik:GridTemplateColumn UniqueName="TemplateColumn" >
                <HeaderTemplate>Seleccionar Todas 
                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect"  runat="server" />
                    </ItemTemplate>
              </telerik:GridTemplateColumn >--%>


            </Columns>
        </MasterTableView>
        <ClientSettings EnableRowHoverStyle="true">
        </ClientSettings>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
            EnableImageSprites="True">
        </HeaderContextMenu>
    </telerik:RadGrid>

            </td>
        </tr>
        <tr>
            <td class="style1" align="center" colspan="2">
                <br />
                <asp:Image ID="imgCodigo" runat="server" />
                <br />
                <asp:Label ID="lblCodigo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center" colspan="2">
                <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="Validado Por: "></asp:Label>
                &nbsp;<asp:Label ID="lblUsuario" runat="server"></asp:Label>
&nbsp;
                <asp:Label ID="lblFechaCreacion" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center" colspan="2">
&nbsp;
                </td>
        </tr>
    </table>
    </form>
    </body>
</html>
