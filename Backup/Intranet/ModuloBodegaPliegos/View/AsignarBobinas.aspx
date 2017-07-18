<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarBobinas.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.AsignarBobinas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            .style1
            {
                width: 192px;
            }
               .style2
               {
                   width: 355px;
               }
               .style3
               {
                   width: 140px;
               }
        </style>
</head>
<body>
  <form id="form1" runat="server">
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <br />
    <br />
    <div>
                        <div class="divTitulo">
                            Asignar Papel de Bobinas</div>
    <div class="divSeccion">

    <div style="height:450px;width:1115px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="CodigoProducto" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" ItemStyle-Width="100px" SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn>         
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="350px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="StockFL" ItemStyle-Width="60px" SortExpression="StockFL" ItemStyle-HorizontalAlign="Right" UniqueName="StockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Antiguedad" HeaderText="Antiguedad" ItemStyle-Width="60px" SortExpression="Antiguedad" UniqueName="Antiguedad">
                    </telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateColumn" ><HeaderTemplate>
              </HeaderTemplate><ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server"  Checked="false"/>
              </ItemTemplate>
              </telerik:GridTemplateColumn >
                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>


</div>
<div align="center">

        <table style="width: 100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="Label9" runat="server" Text="Ingrese Kilos a Solicitar:"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </div>
        <br />
        <div align="center">
            <asp:Button ID="Button1" runat="server" Text="Grabar" onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2"
                runat="server" Text="Cancelar" onclick="Button2_Click" /></div>
    </div>
    </div>
    </form>
</body>
</html>
