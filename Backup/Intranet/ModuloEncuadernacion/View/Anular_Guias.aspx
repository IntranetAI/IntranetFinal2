<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Anular_Guias.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.Anular_Guias" %>

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
     <style type="text/css">
         .style2
         {
             width: 344px;
         }
         .style3
         {
             width: 671px;
         }
         .style4
         {
             width: 332px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<div align="center">
 <h3 style="color: rgb(23, 130, 239);">Anular Guias/Pallets</h3>
</div>--%>

<div align="center">  <asp:Label ID="Label3" runat="server" Text="Código Pallet:"></asp:Label>
&nbsp;
                <asp:TextBox ID="txtCodigoPallet" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnFiltro_Click" />
                    
                    </div>
    <div align="center" id="DivMensaje" runat="server">
    <asp:Image ID="imgMensaje" runat="server" />
                &nbsp;
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
              
    </div>
    <br />

         <div style="border:1px solid blue;height:350px;Width:1094px; overflow:scroll;" >
    <telerik:RadGrid ID="RadGrid1"  runat="server" BorderWidth="0px" Skin="Outlook" >

        <MasterTableView AutoGenerateColumns="False" DataKeyNames="id_ProductosTerminados">
            <NoRecordsTemplate>
                <div style="text-align:center;">
                    <br />¡ No se han encontrado registros !<br /></div>
            </NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>

              <telerik:GridBoundColumn Visible="false" DataField="id_ProductosTerminados" HeaderText="id_ProductosTerminados" 
                    ItemStyle-Width="50px" ReadOnly="True" SortExpression="id_ProductosTerminados" 
                    UniqueName="id_ProductosTerminados">
                    <ItemStyle Width="50px" />
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                    ItemStyle-Width="40px" ReadOnly="True" SortExpression="OT" 
                    UniqueName="OT">
                    <ItemStyle Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px" 
                    SortExpression="NombreOT" UniqueName="NombreOT">
                    <ItemStyle HorizontalAlign="Left" Width="400px" />
                </telerik:GridBoundColumn>      

                                <telerik:GridBoundColumn DataField="Terminacion" HeaderText="Terminación" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="90px" 
                    SortExpression="Terminacion" UniqueName="Terminacion">
                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                </telerik:GridBoundColumn>  
                
             
                <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="Tipo de Embalaje" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" 
                    SortExpression="TipoEmbalaje" UniqueName="TipoEmbalaje">
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                </telerik:GridBoundColumn>  

              <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad de Bultos" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" 
                    SortExpression="Cantidad" UniqueName="Cantidad">
                  <ItemStyle HorizontalAlign="Right" Width="100px" />
                </telerik:GridBoundColumn>  


                <telerik:GridBoundColumn   DataField="Ejemplares" HeaderText="Ejemplares por Bulto" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" 
                    SortExpression="Ejemplares" UniqueName="Ejemplares">
                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                </telerik:GridBoundColumn>  

                
                <telerik:GridBoundColumn DataField="Total" HeaderText="Total Ejemplares" 
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" 
                    SortExpression="Total" UniqueName="Total">
                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                </telerik:GridBoundColumn>  

                <telerik:GridBoundColumn visible="false" DataField="NombreOperario" HeaderText="Operario" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="NombreOperario" UniqueName="NombreOperario">
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                </telerik:GridBoundColumn>  


              <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Estado" UniqueName="Estado">
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                </telerik:GridBoundColumn> 



              <telerik:GridTemplateColumn UniqueName="TemplateColumn" >
                <HeaderTemplate>Todas 
                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect"  runat="server" />
                    </ItemTemplate>
              </telerik:GridTemplateColumn >


            </Columns>
        </MasterTableView>
        <ClientSettings EnableRowHoverStyle="true">
        </ClientSettings>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
            EnableImageSprites="True">
        </HeaderContextMenu>
    </telerik:RadGrid>
    </div>
    <div align="center" style="width: 1093px">
        <br />
    <asp:Label ID="Label4" runat="server" Text="Causa Eliminacion:" Font-Bold="True" 
            Font-Size="Large"></asp:Label>
    <asp:TextBox ID="txtDevolucion" runat="server" Height="98px" TextMode="MultiLine" 
            Width="764px" Wrap="False"></asp:TextBox>

</div>    <br />
    <br />
    <div align="center" style="margin-bottom:5px;">
        <asp:Button ID="btnAnular" runat="server" Text="Anular Guias/Pallet" 
            onclick="btnAnular_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" onclick="btnNuevo_Click" 
            Width="83px" />
    </div>
</asp:Content>
