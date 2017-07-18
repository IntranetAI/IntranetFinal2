<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="AtenderSolicitudPesa.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.AtenderSolicitudPesa" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <meta http-equiv="refresh" content="60;URL=http://localhost:6847/ModuloBodegaPliegos/view/atendersolicitudpesa.aspx?id=3&cat=10">--%>

    <script type="text/javascript">
        function Atender(ot, componente, codigo) {
            window.open('CrearPalletPesa.aspx?ot=' + ot + '&comp=' + componente + '&Codigo=' + codigo, 'Atener Solicitud', 'left=45,top=50,width=1170 ,height=840,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<div style="height:500px;width:1100px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right"  SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                    </telerik:GridBoundColumn>  

                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>   
                    
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="190px" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="290px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>


                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Cantidad" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="StockFL" UniqueName="StockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
                    </telerik:GridBoundColumn>
                            
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
        <asp:Button ID="btnFiltro" runat="server" onclick="btnFiltro_Click" 
        Text="Button" Visible="False" />
        </div>
</asp:Content>
