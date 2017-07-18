<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="SolicitudDimensionadoPapel.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.SolicitudDimensionadoPapel" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function Solicitud(sku, nombre, gramaje, ancho) {
        location.href = 'SolicitudDimensionadoPapelDetalle.aspx?id=3&cat=10&sku=' + sku + '&Papel=' + nombre + '&Gramaje=' + gramaje + '&Ancho=' + ancho;
    }
</script>
 <style type="text/css">
        
.divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    font-weight: bold;
    padding-top: 5px;
    padding-bottom: 5px;
    border: 1px solid #959595;
    text-align: left;
}
.divSeccion{
    padding-top: 10px;
    padding-bottom: 10px;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="divTitulo">
                    Paso 1: Seleccione tipo de bobinas a solicitar</div>
    <div class="divSeccion">
    <br />
    <table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 825px;" 
        align="center">

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label1" runat="server" Text="SKU:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtSku" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                <asp:Label ID="Label11" runat="server" Text="Tipo Papel:"></asp:Label>
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtPapel" runat="server"></asp:TextBox>
               </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label2" runat="server" Text="Gramaje:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtGramaje" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                   <asp:Label ID="Label18" runat="server" Text="Ancho:"></asp:Label>
               
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtAncho" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label19" runat="server" Text="Marca:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                <asp:Label ID="Label20" runat="server" Text="Certificación:"></asp:Label>
               
               </td>
            <td class="style4">
               
                <asp:DropDownList ID="ddlCertificacion" runat="server" Width="173px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem>FSC</asp:ListItem>
                    <asp:ListItem>PEFC</asp:ListItem>
                </asp:DropDownList>
               
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
        <div style="height:490px;width:1085px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="SKU" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>
                        
      
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="290px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                              


                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Stock Disponible(KG)" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="StockFL" UniqueName="StockFL">
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
                    </asp:Content>
