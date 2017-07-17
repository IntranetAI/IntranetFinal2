<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtenderSolicitudBuscaPapelStock.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.AtenderSolicitudBuscaPapelStock" %>
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
              width: 45px;
          }
          .style2
          {
              width: 215px;
          }
          .style4
          {
              width: 155px;
          }
          .style5
          {
              width: 109px;
          }
          .style6
          {
              width: 156px;
          }
          .style7
          {
              width: 153px;
          }
          .style8
          {
              width: 151px;
          }
          .style9
          {
              width: 150px;
          }
          .style11
          {
              width: 65px;
          }
          .style12
          {
              width: 56px;
          }
          .style13
          {
              width: 127px;
          }
      </style>
    <script type="text/javascript">
        function Asignar(id, ot, componente, solFL, solKG, preid, usuario) {
            window.open('AsignarPliegosPopUp.aspx?id=' + id + '&ot=' + ot + '&comp=' + componente + '&solFL=' + solFL + '&solKG=' + solKG + '&preid=' + preid + '&usuario=' + usuario, 'Detalle Informe Producción', 'left=45,top=90,width=1170 ,height=840,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="true" EnableScriptGlobalization="True" 
                EnableScriptLocalization="False">
            </asp:ToolkitScriptManager>
    <div>
       <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Consulta Inventario Bodega Pliegos" Font-Bold="True" 
            Font-Size="X-Large"></asp:Label>
           <br />
           <asp:Label ID="lblSolicitado" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
    </div>
    <table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 825px;" 
        align="center">

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label11" runat="server" Text="Tipo Papel:"></asp:Label>
               
            </td>
            <td class="style4" colspan="2">
               
                <asp:TextBox ID="txtPapel" runat="server" Width="250px"></asp:TextBox>
               
               </td>
            <td class="style13">
               
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label7" runat="server" Text="Gramaje:"></asp:Label>
               
            </td>
            <td class="style12">
               
                <asp:TextBox ID="txtGramaje" runat="server"></asp:TextBox>
               
               </td>
            <td class="style5">
                &nbsp;
                   <asp:Label ID="Label3" runat="server" Text="Ancho:"></asp:Label>
               
               </td>
            <td class="style13">
               
                <asp:TextBox ID="txtAncho" runat="server"></asp:TextBox>
               
               </td>
            <td class="style11">
            &nbsp;<asp:Label ID="Label26" runat="server" Text="Largo:"></asp:Label>
               </td>
            <td class="style6">
               
                <asp:TextBox ID="txtLargo" runat="server"></asp:TextBox>

                </td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label10" runat="server" Text="Marca:"></asp:Label>
               
            </td>
            <td class="style12">
               
                <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
               
               </td>
            <td class="style5">
            &nbsp;
                <asp:Label ID="Label28" runat="server" Text="Certificación:"></asp:Label>
               
               </td>
            <td class="style13">
               
                <asp:DropDownList ID="ddlCertificacion" runat="server" Width="173px">
                </asp:DropDownList>
               </td>
            <td class="style11">
                &nbsp;</td>
            <td class="style6">
               
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

                </td>
        </tr>
        </table>
    </div>
    <br />
            <div class="divTitulo">
                <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
    Datos Papel Solicitado</div>
    <div class="divSeccion">
<table style="width: 100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Código Producto:" Font-Bold="True"></asp:Label>
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
                    <asp:Label ID="Label4" runat="server" Text="Largo:  " Font-Bold="True"></asp:Label>
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
 Inventario Papel Bodega Pliegos
        </div>
    <div class="divSeccion">
     <div style="height:530px;width:1120px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                            
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="340px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left"  SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn>    

                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Certificacion" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"  SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>    

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Stock(FL)" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="StockFL" UniqueName="StockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Antiguedad" HeaderText="Antiguedad" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" SortExpression="Antiguedad" UniqueName="Antiguedad">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="Asignar" HeaderText="Asignar" ItemStyle-Width="50px" SortExpression="Asignar" UniqueName="Asignar">
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
    <div align="center">
        <asp:Button ID="btnVolver" runat="server" Text="Volver" 
            onclick="btnVolver_Click" Width="71px" /></div>
    </form>
</body>
</html>
