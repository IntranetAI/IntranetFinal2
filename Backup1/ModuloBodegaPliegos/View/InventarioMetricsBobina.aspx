<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventarioMetricsBobina.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.InventarioMetricsBobina" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function Solicitud(ot, componente, codigoproducto) {
            window.open('AsignarBobinas.aspx?ot=' + ot + '&componente=' + componente + '&codproducto=' + codigoproducto, 'Detalle Informe Producción', 'left=45,top=90,width=1170 ,height=840,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
</script>
        <style type="text/css">
.divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    font-weight: bold;
    padding: 5px;
    border: 1px solid #959595;
    text-align: left;
}
.divSeccion{
    padding: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
}
.divEtiqueta{
    display: inline-block;
    padding: 5px;
    font-weight: bold;
    text-align: left;
}
.divCampo{
    display: inline-block;
    text-align: left;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Consulta Inventario Metrics Bobina" Font-Bold="True" 
            Font-Size="X-Large"></asp:Label>
        <br />
    </div>
    <table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 825px;" 
        align="center">

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label10" runat="server" Text="Marca:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                <asp:Label ID="Label11" runat="server" Text="Descripción:"></asp:Label>
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtNombreOT" runat="server"></asp:TextBox>
               </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label7" runat="server" Text="Gramaje:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                &nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Ancho:"></asp:Label>
               
               </td>
            <td class="style4">
               
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
               
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

                </td>
        </tr>
        </table>
        <br />
                            <div class="divTitulo">
    Inventario Papel</div>
    <div class="divSeccion">
     <div style="height:250px;width:1115px; overflow:auto;" >
        <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="CodigoProducto" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" ItemStyle-Width="100px" SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn>         
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="250px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="StockFL" ItemStyle-Width="30px" SortExpression="StockFL" ItemStyle-HorizontalAlign="Right" UniqueName="StockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Antiguedad" HeaderText="Antiguedad" ItemStyle-Width="60px" SortExpression="Antiguedad" UniqueName="Antiguedad">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Seleccionar" HeaderText="Seleccionar" ItemStyle-Width="50px" SortExpression="Seleccionar" UniqueName="Seleccionar">
                    </telerik:GridBoundColumn>
                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
     </div>
    </div>
                <br />
                    <div class="divTitulo">
    Papel a Solicitar</div>
    <div class="divSeccion">

    <telerik:radgrid ID="RadGrid2" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>                 

                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="CodigoProducto" ItemStyle-Width="40px"  SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" ItemStyle-Width="190px" SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Width="190px" SortExpression="Descripcion" UniqueName="Descripcion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="190px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" ItemStyle-Width="30px" SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="CantRequerida" HeaderText="CantRequerida" ItemStyle-Width="30px" SortExpression="CantRequerida" UniqueName="CantRequerida">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="CantSolicitada" HeaderText="CantSolicitada" ItemStyle-Width="30px" SortExpression="CantSolicitada" UniqueName="CantSolicitada">
                    </telerik:GridBoundColumn>

                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
    </div>
   
    <div align="right">
        <table style="width: 500px;">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <div align="center">Pliegos</div></td>
                <td>
                    <div align="center">Pliegos</div>
                </td>
            </tr>
            <tr>
                <td>
                   <div align="center">Papel Solicitado</div>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                   <div align="center">Papel Asignado</div>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">Saldo por Asignar</div></td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="Grabar" onclick="Button1_Click" />&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
        <asp:Button ID="Button3" runat="server" Text="Volver" onclick="Button3_Click" /></div>
    
         </form>
</body>
</html>
