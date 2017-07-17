<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EtiquetaProductoEnProceso.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.EtiquetaProductoEnProceso" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Solicitud Producto en Proceso</title>
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
            height: 22px;
        }
        .style2
        {
            height: 23px;
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
                        <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <div>
        <div align="center">
    

    
        <table style="width:100%;">
            <tr>
                <td class="style32">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/quadlogo.PNG" 
                        Height="72px" Width="181px"  />
                    <br />
                    </td>
                <td class="style32">
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large">Solicitud Entrega Producto En Proceso</asp:Label>
                    </td>
            </tr>
        </table>
        </div>
        <div class="divTitulo">
            <asp:Label ID="Label29" runat="server" Font-Size="X-Large" Text="Detalle OP"></asp:Label>
                    </div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style25">
                    <asp:Label ID="Label3" runat="server" Text="Numero OP:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style26">
                    &nbsp;
                    <asp:Label ID="lblOT" runat="server" Font-Size="Large"></asp:Label>
                </td>
                <td class="style33">
                    &nbsp;
                    <asp:Label ID="Label8" runat="server" Text="Nombre OP:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style34">
                    <asp:Label ID="lblNombreOT" runat="server" Font-Size="Large"></asp:Label>
                </td>
                <td class="style28">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style25">
                    <asp:Label ID="Label5" runat="server" Text="Componente:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style26">
                    &nbsp;
                    <asp:Label ID="lblComponente" runat="server" Font-Size="Large"></asp:Label>
                </td>
                <td class="style33">
                    &nbsp;
                    <asp:Label ID="Label7" runat="server" Text="Fecha Creacion OP:" 
                        Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
                <td class="style34">
                    <asp:Label ID="lblFechaCreacion" runat="server" Font-Size="Large"></asp:Label>
                </td>
                <td class="style28">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style25">
                    <asp:Label ID="Label4" runat="server" Text="Formato Corte:" 
                        Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
                <td class="style26">
                    &nbsp;
                    <asp:Label ID="lblFormatoCorte" runat="server" Font-Size="Large"></asp:Label>
                </td>
                <td class="style33">
                &nbsp;
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" 
                        Text="Cantidad Solicitada (FL):" Font-Size="Large"></asp:Label>
                </td>
                <td class="style34">
                    <asp:Label ID="lblCantidadSolicitada" runat="server" Font-Size="Large"></asp:Label>
                </td>
                <td class="style28">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style25">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style33">
                    &nbsp;
                    <asp:Label ID="Label26" runat="server" Font-Bold="True" 

                        Text="Cantidad Asignada (FL):" Font-Size="Large"></asp:Label>
                </td>
                <td class="style34">
                    <asp:Label ID="lblCantidadAsignada" runat="server" Font-Size="Large"></asp:Label>
                </td>
                <td class="style28">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style25">
                    <asp:Label ID="Label9" runat="server" Text="Cliente:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style4" colspan="3">
                &nbsp;
                    <asp:Label ID="lblCliente" runat="server" Font-Size="Large"></asp:Label>
                    &nbsp;
                </td>
                <td class="style28">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
        <div class="divTitulo">
            <asp:Label ID="Label28" runat="server" Font-Size="X-Large" Text="Detalle Papel"></asp:Label>
                    </div>
    <div class="divSeccion">
     <div style="height:130px;width:905px; overflow:auto;" align="center" >
    <telerik:radgrid ID="RadGrid1" runat="server" Width="890px"  Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                            
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="290px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="FCAncho" Visible="false" HeaderText="FCAncho" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="FCAncho" UniqueName="FCAncho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="FCLargo" HeaderText="FCLargo" Visible="false" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="FCLargo" UniqueName="FCLargo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>
                    
                

                    <telerik:GridBoundColumn DataField="Antiguedad" HeaderText="Antiguedad" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="Antiguedad" UniqueName="Antiguedad">
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
    <div class="divTitulo">
        <asp:Label ID="Label30" runat="server" Font-Size="X-Large" 
            Text="Detalle Pallets a Entregar"></asp:Label>
                    </div>
    <div class="divSeccion">
         <div style="height:210px;width:905px; overflow:auto;" align="center" >
    <telerik:radgrid ID="RadGrid2" runat="server" Width="890px"
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>

                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="40px"  SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>     

                    <telerik:GridBoundColumn DataField="NroPallet" HeaderText="NroPallet" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center" SortExpression="NroPallet" UniqueName="NroPallet">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Sector" HeaderText="Sector" ItemStyle-Width="100px" SortExpression="Sector" UniqueName="Sector">
                    </telerik:GridBoundColumn>
             
                    <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ubicacion" ItemStyle-Width="100px" SortExpression="Ubicacion" UniqueName="Ubicacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" ItemStyle-Width="40px"  SortExpression="Cliente" UniqueName="Cliente">
                    </telerik:GridBoundColumn>             
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="stockFL" HeaderText="Asignado" ItemStyle-Width="30px"  SortExpression="stockFL" UniqueName="stockFL">
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

    <table style="width: 100%;">
        <tr>
            <td>
 <table id="Table2" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:450px;">
  <tbody>
      <tr style="background: #707070; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style1"></td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style1">
        <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Formato Corte" 
            Font-Bold="True"></asp:Label>
      </td>
          <%--<td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
        Kilos </td>--%>

  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style21">
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium">Ancho (mm):</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblFCAncho" runat="server" Font-Size="Medium"></asp:Label>
      </td>
      <%--                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                            <asp:Label ID="lblSolicitadoKG" runat="server"></asp:Label>
      </td>--%>
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style21">
        <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Medium">Largo (mm):</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblFCLargo" runat="server" Font-Size="Medium"></asp:Label>
        </td>
        <%--                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                            <asp:Label ID="lblAsignadoKG" runat="server"></asp:Label>
        </td>--%>
    
  </tr>
      <tr style="background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">


          <%--                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style23">
                                            <asp:Label ID="lblSaldoKG" runat="server"></asp:Label>
          </td>--%>
    
  </tr>
</tbody></table>
            </td>
            <td>
 <table id="Table1" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:450px;">
  <tbody>
      <tr style="background: #707070; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style1"></td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style1">
        <asp:Label ID="Label31" runat="server" Font-Size="Medium" Text="Pliegos" 
            Font-Bold="True"></asp:Label>
      </td>
          <%--<td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
        Kilos </td>--%>

  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style21">
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium">Papel Solicitado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblSolicitadoFL" runat="server" Font-Size="Medium"></asp:Label>
      </td>
      <%--                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                            <asp:Label ID="lblSolicitadoKG" runat="server"></asp:Label>
      </td>--%>
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style21">
        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium">Papel Asignado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblAsignadoFL" runat="server" Font-Size="Medium"></asp:Label>
        </td>
        <%--                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                            <asp:Label ID="lblAsignadoKG" runat="server"></asp:Label>
        </td>--%>
    
  </tr>
      <tr style="background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style22">
        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Medium">Saldo Por Asignar:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style23">
                                    <asp:Label ID="lblSaldoFL" runat="server" Font-Size="Medium"></asp:Label>
          </td>
          <%--                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style23">
                                            <asp:Label ID="lblSaldoKG" runat="server"></asp:Label>
          </td>--%>
    
  </tr>
</tbody></table>
            </td>
        </tr>
        </table>
    
  <br />
  <br />
            <div style="margin-left:350px;">
               <asp:Image ID="imgCodigo" runat="server" Height="150px" />
             </div>
                         <div align="center">
           
                    <br />
                    
      <asp:Label ID="lblCodigo" runat="server" Font-Size="XX-Large"></asp:Label>
       

        </div>
              

    </div>
    </form>
</body>
</html>
