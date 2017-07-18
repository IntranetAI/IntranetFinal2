<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="ProcesarSolicitudCorte.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.ProcesarSolicitudCorte" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script  type="text/javascript" language="javascript">
         function SelectAllCheckboxes(spanChk) {

             // Added as ASPX uses SPAN for checkbox
             var oItem = spanChk.children;
             var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
             xState = theBox.checked;
             elm = theBox.form.elements;

             for (i = 0; i < elm.length; i++)
                 if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                     //elm[i].click();
                     if (elm[i].checked != xState)
                         elm[i].click();
                     //elm[i].checked=xState;
                 }
         }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div align="center">
    <asp:Label ID="Label1" runat="server" Text="Código Pallet (Folio): "></asp:Label>&nbsp;
    <asp:TextBox ID="txtFolio"
        runat="server" AutoPostBack="True" ontextchanged="txtFolio_TextChanged"></asp:TextBox>
    <asp:Button ID="btnFiltro" runat="server" Text="Button" 
        onclick="btnFiltro_Click" Visible="False" /></div>
<br />
<br />
<div style="height:510px;width:1095px; overflow:auto;" >
<telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="ID" Visible="false" HeaderText="ID" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="ID" UniqueName="ID">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="NroPallet" HeaderText="NroPallet" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="NroPallet" UniqueName="NroPallet">
                    </telerik:GridBoundColumn>
                        
                    <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ubicacion" ItemStyle-Width="120px" SortExpression="Ubicacion" UniqueName="Ubicacion">
                    </telerik:GridBoundColumn>         
                                 <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Componente" ItemStyle-Width="40px"  SortExpression="Componente" UniqueName="Componente">
                    </telerik:GridBoundColumn>       
                    
                                        <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" ItemStyle-Width="40px"  SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn>  


                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="300px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>
                    
                    

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Cantidad Asignada" ItemStyle-Width="50px" SortExpression="StockFL" UniqueName="StockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" ItemStyle-Width="65px" SortExpression="Estado" UniqueName="Estado">
                    </telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateColumn" ><HeaderTemplate>Todas <asp:CheckBox id="chkAll3" runat="server" onclick="javascript:SelectAllCheckboxes(this);" /></HeaderTemplate>
                <ItemTemplate>
              <asp:CheckBox ID="chkSelect"  runat="server" Checked="false"/></ItemTemplate>
              
              </telerik:GridTemplateColumn >
<%--
                    <telerik:GridBoundColumn DataField="Detalle" HeaderText="Detalle" ItemStyle-Width="50px" SortExpression="Detalle" UniqueName="Detalle">
                    </telerik:GridBoundColumn> --%>                               
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
                    <asp:Button ID="btnRecepcionar" runat="server" Text="Recepcionar Seleccionados" 
                        onclick="btnRecepcionar_Click" /></div>
                        <br />
                        <br />
</asp:Content>
