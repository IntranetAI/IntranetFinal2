<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="HistorialOC.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.HistorialOC" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function CreaOC() {
        window.open('CrearOC.aspx', 'Detalle Informe Producción', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnFiltro" runat="server" Text="Button" />
<br />
<input id="btnCortadora"  onclick="javascript:CreaOC();" type="button"  value="Crear OC" />
<br />
<div style="height:490px;width:1085px; overflow:auto;" >
                        <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="FechaCreacion" 
                        SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" SortExpression="OT" 
                        UniqueName="OT">
                        <ItemStyle Width="30px" />
                    </telerik:GridBoundColumn>         
             
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" 
                        SortExpression="NombreOT" UniqueName="NombreOT">
                        <ItemStyle Width="160px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Componente"  
                        SortExpression="Componente" UniqueName="Componente">
                        <ItemStyle Width="40px" />
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" 
                        SortExpression="Papel" UniqueName="Papel">
                        <ItemStyle Width="190px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje"  
                        SortExpression="Gramaje" UniqueName="Gramaje">
                        <ItemStyle HorizontalAlign="Right" Width="30px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" 
                        SortExpression="Ancho" UniqueName="Ancho">
                        <ItemStyle HorizontalAlign="Right" Width="30px" />
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" 
                        SortExpression="Largo" UniqueName="Largo">
                        <ItemStyle HorizontalAlign="Right" Width="30px" />
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="SolicitadoFL" HeaderText="Sol. FL" 
                        SortExpression="SolicitadoFL" UniqueName="SolicitadoFL">
                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="SolicitadoKG" HeaderText="Sol. KG" 
                        SortExpression="SolicitadoKG" UniqueName="SolicitadoKG">
                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Procesado" HeaderText="Procesado" 
                        SortExpression="Procesado" UniqueName="Procesado">
                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                        SortExpression="Estado" UniqueName="Estado">
                        <ItemStyle Width="80px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" 
                        SortExpression="Accion" UniqueName="Accion">
                        <ItemStyle Width="50px" />
                    </telerik:GridBoundColumn>
                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
            </div>
</asp:Content>
