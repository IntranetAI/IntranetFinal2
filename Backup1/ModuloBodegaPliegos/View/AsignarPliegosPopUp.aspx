<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarPliegosPopUp.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.AsignarPliegosPopUp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asignar Pliegos</title>
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
                width: 57px;
            }
            </style>
    <script src="../../js/funciones.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <div align="center">
        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;<asp:Label ID="lblPreID"
            runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:Label ID="lblSolicitado" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
    </div>
    <br />
    <div>
        <div class="divTitulo">
    Datos Papel Solicitado</div>
    <div class="divSeccion">
<table style="width: 100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Código Producto:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;
                    <asp:Label ID="lblCodigoProducto" runat="server"></asp:Label>
                </td>
                <td class="style18">
                    &nbsp;
                    <asp:Label ID="Label14" runat="server" Text="Descripción:" Font-Bold="True"></asp:Label>
                    </td>
                <td colspan="2">
                    <asp:Label ID="lblPapel" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    </td>
                <td class="style6">
                    <asp:Label ID="Label19" runat="server" Text="Gramaje:  " Font-Bold="True"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;
                    <asp:Label ID="lblGramaje" runat="server"></asp:Label>
                </td>
                <td class="style8">
                    &nbsp;
                    &nbsp;<asp:Label ID="Label20" runat="server" Text="Ancho:  " Font-Bold="True"></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;<asp:Label ID="lblAncho" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label10" runat="server" Text="Largo:  " Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="lblLargo" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label21" runat="server" Text="Certificación:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;
                    <asp:Label ID="lblCertificacion" runat="server"></asp:Label>
                </td>
                <td class="style18">
                    &nbsp;
                    <asp:Label ID="Label25" runat="server" Text="Tipo Certificación:" 
                        Font-Bold="True"></asp:Label>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblTipoCertificacion" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            </table>
    </div>
                            <div class="divTitulo">
                                Detalle SKU</div>
    <div class="divSeccion">
    <div style="height:250px;width:1115px; overflow:auto;" >
    



    <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn  DataField="ID"  visible="false" HeaderText="ID" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" SortExpression="ID" UniqueName="ID">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Descripción Papel" ItemStyle-Width="450px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>
<%--                    <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" SortExpression="Cliente" UniqueName="Cliente">
                    </telerik:GridBoundColumn>--%>
                        
                             
                    <telerik:GridBoundColumn DataField="Sector" HeaderText="Ubicacion" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" SortExpression="Sector" UniqueName="Sector">
                    </telerik:GridBoundColumn>    
                    
<%--                    <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ubicacion" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" SortExpression="Ubicacion" UniqueName="Ubicacion">
                    </telerik:GridBoundColumn>--%>
                    
                    
                    <telerik:GridBoundColumn DataField="NroPallet" HeaderText="NroPallet" ItemStyle-Width="90px" SortExpression="NroPallet" UniqueName="NroPallet">
                    </telerik:GridBoundColumn>
             

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Cantidad" ItemStyle-Width="60px" SortExpression="StockFL" ItemStyle-HorizontalAlign="Right" UniqueName="StockFL">
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
                    <asp:Button ID="btnAnadirPapel" runat="server" Text="Añadir Papel a Asignar" 
                        Width="165px" onclick="btnAnadirPapel_Click" /></div>
    </div>

                        <div class="divTitulo">
                            Detalle Papel</div>
    <div class="divSeccion">
      <div style="height:250px;width:1115px; overflow:auto;" >
  <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False"   CellPadding="4"  OnRowDeleting="Gridview1_RowDeleting"
              ForeColor="#333333">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

                    <Columns>
                     <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID"  />
                      <asp:BoundField DataField="CodigoProducto" ItemStyle-Width="80px" HeaderText="Codigo" SortExpression="CodigoProducto"  />
                       <asp:BoundField DataField="Papel" ItemStyle-Width="350px" HeaderText="Papel" SortExpression="Papel"  />
                        <asp:BoundField DataField="Cliente" ItemStyle-Width="60px" HeaderText="Cliente" SortExpression="Cliente"   ReadOnly="True" />
                         <asp:BoundField DataField="Sector" ItemStyle-Width="60px" HeaderText="Sector" SortExpression="Sector" />
                         <asp:BoundField DataField="Ubicacion" ItemStyle-Width="60px" HeaderText="Ubicacion" SortExpression="Ubicacion" />
                         <asp:BoundField DataField="NroPallet" ItemStyle-Width="60px" HeaderText="NroPallet" SortExpression="NroPallet" />
                         <asp:BoundField DataField="Gramaje" ItemStyle-Width="60px" HeaderText="Gramaje" SortExpression="Gramaje" />
                         <asp:BoundField DataField="Ancho" ItemStyle-Width="60px" HeaderText="Ancho" SortExpression="Ancho" />
                         <asp:BoundField DataField="Largo" ItemStyle-Width="60px" HeaderText="Largo" SortExpression="Largo" />
                         <asp:BoundField DataField="Antiguedad" ItemStyle-Width="60px" HeaderText="Antiguedad" SortExpression="Antiguedad" />
                         <asp:BoundField DataField="StockFL" ItemStyle-Width="60px" HeaderText="StockFL" SortExpression="StockFL" />
                         


                      <asp:TemplateField HeaderText="Asignar" SortExpression="StockFL" >

                             <ItemTemplate>
                                <asp:Label ID="lblCantidad" runat="server" Visible="false" Text='<%# Bind("StockFL") %>'></asp:Label>
                                <asp:TextBox ID="txtCantidad"  Width="100px" runat="server"  Text='<%# Bind("StockFL") %>' MaxLength="6"></asp:TextBox>
                            </ItemTemplate>

                             

                        </asp:TemplateField>

                        
                      <asp:TemplateField HeaderText="Factor" SortExpression="Factor" >

                             <ItemTemplate>
            <asp:DropDownList ID="ddlFactor" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
            </asp:DropDownList>
                            </ItemTemplate>

                             

                        </asp:TemplateField>

                                            <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkdelete" runat="server" CommandName="Delete" >Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White"/>

                </asp:GridView>
    </div>

    </div>
    </div>

        <div align="center">
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar" 
                onclick="btnAsignar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2"
                runat="server" Text="Cancelar" onclick="Button2_Click" />

    </div>
    </form>
</body>
</html>
