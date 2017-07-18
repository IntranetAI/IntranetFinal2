<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="AtenderSolicitudPapel2.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.AtenderSolicitudPapel2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Atender Solicitud</title>
    <script type="text/javascript">
        function Asignar(id, ot, componente, solFL, solKG, preid, usuario) {
            window.open('AsignarPliegosPopUp.aspx?id=' + id + '&ot=' + ot + '&comp=' + componente + '&solFL=' + solFL + '&solKG=' + solKG + '&preid=' + preid + '&usuario=' + usuario, 'Detalle Informe Producción', 'left=45,top=90,width=1170 ,height=840,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
</script>
<script type="text/javascript">
    function openGame(OT) {
        var respuesta = PageMethods.Delete(OT);
        location.reload();
    }
    </script>
<script type="text/javascript">
    function Consultar(ot, componente, papel, gramaje, ancho, preid,usuario) {
        window.open('InventarioMetricsBobina.aspx?ot=' + ot + '&componente=' + componente + '&papel=' + papel + '&gramaje=' + gramaje + '&ancho=' + ancho + '&preid=' + preid + '&usuario=' + usuario, 'Detalle Informe Producción', 'left=45,top=90,width=1170 ,height=800,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
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
    .style2
    {
            width: 143px;
        }
    .style4
    {
        }
    .style6
    {
        width: 143px;
        height: 23px;
    }
    .style7
    {
        width: 155px;
        height: 23px;
    }
    .style8
    {
        width: 168px;
        height: 23px;
    }
    .style9
    {
        height: 23px;
    }
    .style10
    {
        width: 610px;
    }
        .style11
        {
            width: 167px;
        }
        .style14
        {
            width: 87px;
        }
        .style15
        {
            width: 141px;
        }
        .style16
        {
            width: 83px;
        }
        .style17
        {
            width: 83px;
            height: 23px;
        }
        .style18
        {
            width: 168px;
        }
        .style19
        {
            width: 166px;
        }
        .style20
        {
            width: 243px;
        }
        .style21
        {
            width: 230px;
        }
        .style22
        {
            width: 230px;
            height: 22px;
        }
        .style23
        {
            height: 22px;
        }
    </style>
    <script src="../../js/funciones.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
                &nbsp;<asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>


    <div align="center">
    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:Label ID="lblPreID"
        runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>
        <div class="divTitulo">
        Detalle OP</div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label3" runat="server" Text="Numero OP:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style19">
                    &nbsp;
                    <asp:Label ID="lblOT" runat="server"></asp:Label>
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:Label ID="Label8" runat="server" Text="Nombre OP:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label5" runat="server" Text="Componente:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style19">
                    &nbsp;
                    <asp:Label ID="lblComponente" runat="server"></asp:Label>
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:Label ID="Label7" runat="server" Text="Fecha Creacion OP:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFechaCreacion" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label4" runat="server" Text="Formato Papel:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style19">
                    &nbsp;
                    <asp:Label ID="lblFormatoPapel" runat="server"></asp:Label>
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:Label ID="Label26" runat="server" Font-Bold="True" 
                        Text="Formato Impresion:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFormatoImpresionAncho" runat="server"></asp:Label>
&nbsp;X
                    <asp:Label ID="lblFormatoImpresionLargo" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;</td>
                <td class="style15">
                    <asp:Label ID="Label9" runat="server" Text="Cliente:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style4" colspan="3">
                &nbsp;
                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>

    <div class="divTitulo">
    Datos Papel Solicitado</div>
    <div class="divSeccion">
<table style="width: 100%;">
            <tr>
                <td class="style16">
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
                <td class="style17">
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
                <td class="style16">
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
            <table style="width:100%;">
                <tr>
                    <td>
    Inventario Papel Bodega Pliegos</td>
                    <td align="right">
                        <asp:ImageButton ID="imgBuscar" runat="server" ImageUrl="~/Images/buscar.png" 
                            Width="20px" onclick="imgBuscar_Click" />
&nbsp;
                        <asp:LinkButton ID="btnBuscar" runat="server" onclick="btnBuscar_Click">Buscar</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    <div class="divSeccion">
     <div style="height:130px;width:1120px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                            
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="290px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Pliegos" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="StockFL" UniqueName="StockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Antiguedad" HeaderText="Antiguedad" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" SortExpression="Antiguedad" UniqueName="Antiguedad">
                    </telerik:GridBoundColumn>
                    
<%--
                    <telerik:GridBoundColumn DataField="PliegosSol" HeaderText="PliegosSol" ItemStyle-Width="50px" SortExpression="PliegosSol" UniqueName="PliegosSol">
                    </telerik:GridBoundColumn>--%>

<%--                    <telerik:GridBoundColumn DataField="Asignar" HeaderText="Asignar" ItemStyle-Width="50px" SortExpression="Asignar" UniqueName="Asignar">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Inventario" HeaderText="Inventario" ItemStyle-Width="50px" SortExpression="Inventario" UniqueName="Inventario">
                    </telerik:GridBoundColumn>--%>

                                
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
    Papel Asignado</div>
    <div class="divSeccion">
         <div style="height:130px;width:1120px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid2" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>

                    <telerik:GridBoundColumn DataField="ID" HeaderText="ID" ItemStyle-Width="40px"  SortExpression="ID" UniqueName="ID">
                    </telerik:GridBoundColumn> 

                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="40px"  SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>     

                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="290px" ItemStyle-HorizontalAlign="Center" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>
             
<%--                    <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ubicacion" ItemStyle-Width="100px" SortExpression="Ubicacion" UniqueName="Ubicacion">
                    </telerik:GridBoundColumn>--%>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" ItemStyle-Width="30px" SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="stockFL" HeaderText="Asignado" ItemStyle-Width="30px"  SortExpression="stockFL" UniqueName="stockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="30px"  SortExpression="Accion" UniqueName="Accion">
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
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="style10">
                <div align="center">
                 <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:450px;">
  <tbody><tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">Formato Corte</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;"></td>

  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        <asp:Label ID="lblDespachado" runat="server">Ancho (mm):</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:TextBox ID="txtAncho" runat="server"  MaxLength="3" BackColor="Yellow"></asp:TextBox>
                                    </td>
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        <asp:Label ID="Label2" runat="server">Largo (mm):</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:TextBox ID="txtLargo" runat="server"  MaxLength="3" 
                                        BackColor="Yellow"></asp:TextBox>
                                    </td>
    
  </tr>
</tbody></table>
</div>
                   </td>
                <td>
                                    <div align="center">
                 <table id="Table1" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:450px;">
  <tbody><tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style21">&nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
        Pliegos</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
        Kilos </td>

  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style21">
        <asp:Label ID="Label6" runat="server">Papel Solicitado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblSolicitadoFL" runat="server"></asp:Label>
      </td>
                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                            <asp:Label ID="lblSolicitadoKG" runat="server"></asp:Label>
      </td>
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style21">
        <asp:Label ID="Label11" runat="server">Papel Asignado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                    <asp:Label ID="lblAsignadoFL" runat="server"></asp:Label>
        </td>
                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                            <asp:Label ID="lblAsignadoKG" runat="server"></asp:Label>
        </td>
    
  </tr>
      <tr style="background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style22">
        <asp:Label ID="Label12" runat="server">Saldo Por Asignar:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style23">
                                    <asp:Label ID="lblSaldoFL" runat="server"></asp:Label>
          </td>
                                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style23">
                                            <asp:Label ID="lblSaldoKG" runat="server"></asp:Label>
          </td>
    
  </tr>
</tbody></table>
</div></td>
            </tr>
            </table>
    </div>

    <div align="center">
        <asp:Button ID="btnGrabar" runat="server" Text="Grabar"
            style="height: 26px" onclick="btnGrabar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFiltro"
            runat="server" Text="Cancelar" onclick="Button2_Click" />
    </div>
    
    </form>
</body>
</html>
