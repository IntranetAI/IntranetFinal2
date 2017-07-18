<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="DevolucionInterna.aspx.cs" Inherits="Intranet.ModuloDespacho.View.DevolucionInterna" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
             height: 23px;
         }
         .style3
         {
             width: 35px;
         }
         .style4
         {
             height: 23px;
             width: 221px;
         }
         .style6
         {
             width: 131px;
         }
         .style8
         {
             height: 23px;
             width: 84px;
         }
         .style9
         {
             width: 84px;
         }
         .style10
         {
             width: 270px;
         }
         .style11
         {
             height: 23px;
             width: 270px;
         }
         .style12
         {
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <fieldset id="fs1" style="width: 1000px;margin-left:31px;">
   <legend>Datos OT</legend>
       <table style="width:100%;">
           <tr>
               <td class="style12" colspan="4">
               <div align="center">
                   <asp:Label ID="Label1" runat="server" 
                       Text="* Este tipo de devolución sólo afecta al Informe Despachos de Encuadernación" 
                       ForeColor="Red"></asp:Label></div>
                   </td>
           </tr>
           <tr>
               <td class="style12">
                   &nbsp;</td>
               <td class="style9">
                <asp:Label ID="Label3" runat="server" Text="OT:" Font-Bold="True"></asp:Label>
               </td>
               <td class="style10">
                <asp:TextBox ID="txtOT" runat="server" AutoPostBack="True" MaxLength="9" 
                    ontextchanged="txtOT_TextChanged"></asp:TextBox>
                   <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                       onclick="btnBuscar_Click" />
                   <asp:Label ID="idDev" runat="server" Visible="False"></asp:Label>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="style4">
                   </td>
               <td class="style8">
                <asp:Label ID="Label4" runat="server" Text="Cliente:" Font-Bold="True"></asp:Label>
               </td>
               <td class="style11">
                <asp:Label ID="txtCliente" runat="server"></asp:Label>
               </td>
               <td class="style2">
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="style12">
                   &nbsp;</td>
               <td class="style9">
                <asp:Label ID="Label6" runat="server" Text="Producto:" Font-Bold="True"></asp:Label>
               </td>
               <td class="style10">
                <asp:Label ID="txtProducto" runat="server" Font-Bold="True"></asp:Label>
               </td>
               <td>
                   <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Tiraje OT:"></asp:Label>
                   <asp:Label ID="lblTirajeOT" runat="server"></asp:Label>
               </td>
           </tr>
       </table>
   </fieldset>


   <fieldset id="Fieldset2" style="width: 1000px;margin-left:31px;">
   <legend>Datos Despacho</legend>
       <table style="width:100%;">
           <tr>
               <td class="style19" colspan="3">
                   <asp:Label ID="Label15" runat="server" Font-Bold="True" 
                       Text="Seleccione Guias a Devolver:"></asp:Label>
               </td>
           </tr>
           <tr>
               <td class="style22" colspan="3" align="center">
               
                   <div runat="server" id="divGrillaGuias" visible="true" 
                       style="height:130px;width:900px; overflow:auto;" >
                       <%--grilla guias de QGCHILE--%>
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="guia">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="guia" HeaderText="N° Guia"  UniqueName="guia" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Sucursal" HeaderText="Terminacion" UniqueName="Sucursal" ItemStyle-Width="220px"  >
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="Tipo Embalaje" UniqueName="TipoEmbalaje" ItemStyle-Width="60px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Despachado" HeaderText="Despachado" ItemStyle-Width="60px" UniqueName="Despachado"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaDespacho" HeaderText="Fecha Despacho" SortExpression="FechaDespacho" UniqueName="FechaDespacho" ItemStyle-Width="120px" DataFormatString="{0:dd-MM-yyyy HH:mm:ss}" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

                              <telerik:GridTemplateColumn UniqueName="TemplateColumn" ItemStyle-Width="30px" >
                <HeaderTemplate>Todas 
                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect"  runat="server" />
                    </ItemTemplate>
              </telerik:GridTemplateColumn >


              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
   <%--           GRILLA GUIAS CLIENTE--%>
              
              </div>
               
               
               </td>
           </tr>
           <tr>
               <td class="style6">
                <asp:Label ID="Label8" runat="server" Text="Causa Devolución:" Font-Bold="True"></asp:Label>
               </td>
               <td>
               
                <asp:DropDownList ID="ddlCausa" runat="server" Width="162px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlCausa_SelectedIndexChanged" >
                    <asp:ListItem>Redistribucion</asp:ListItem>
                    <asp:ListItem>Arreglos</asp:ListItem>
                    <asp:ListItem>Otros</asp:ListItem>
                </asp:DropDownList>
               
               
               </td>
               <td class="style23">
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="style6">
                   <asp:Label ID="lblObservacion" runat="server" Font-Bold="True" 
                       Text="Observación:"></asp:Label>
               </td>
               <td>
               
                   <asp:Label ID="Label16" runat="server" Font-Size="Small" ForeColor="Red" 
                       Text="(* El Campo Observacion es OBLIGATORIO)"></asp:Label>
                   <br />
               
                <asp:TextBox ID="txtComentario" runat="server" Height="46px" TextMode="MultiLine" 
                    Width="644px" Wrap="False"></asp:TextBox>
               
               
               </td>
               <td class="style23">
                   &nbsp;</td>
           </tr>
       </table>
   </fieldset>
      <fieldset id="Fieldset3" style="width: 1000px;margin-left:31px;">
   <legend>Datos Devolución</legend>
          <table style="width:100%;">
              <tr>
                  <td class="style26">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" 
                    Text="Tipo de Embalaje:"></asp:Label>
                  </td>
                  <td class="style25">
                <asp:DropDownList ID="ddlTipoEmbalaje" runat="server" Width="162px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem>Fajo</asp:ListItem>
                    <asp:ListItem>Zuncho</asp:ListItem>
                    <asp:ListItem>CMC</asp:ListItem>
                    <asp:ListItem>Caja</asp:ListItem>
                    <asp:ListItem>Embolsado</asp:ListItem>
                    <asp:ListItem>Paquete</asp:ListItem>
                </asp:DropDownList>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" Text="Cantidad Recepcionada:" 
                    Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                          onclick="btnAgregar_Click" Enabled="False" />
                  &nbsp;<asp:Label ID="Label17" runat="server" Text="* Maximo a Devolver: " 
                          ForeColor="Red"></asp:Label>
                      <asp:Label ID="lblRestantes" runat="server"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td class="style24" colspan="3" align="center">
                                   <div style="height:110px;width:900px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid2" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="OT" HeaderText="OT"  UniqueName="OT"   >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="Tipo Embalaje" UniqueName="TipoEmbalaje"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad"  UniqueName="Cantidad"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>




              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
              
              </div>
               
                
                
                  </td>
              </tr>
              </table>
   </fieldset>

    <br />

    <div align="center" style="width: 1029px" id="divMensaje" runat="server" visible="false">
       <asp:Image ID="imgMensaje" runat="server" />&nbsp; <asp:Label ID="lblMensaje" 
            runat="server"></asp:Label>
            
    </div>

    <div align="center" style="width: 1029px">
        <asp:Button ID="btnGuardarDev" 
            runat="server" Text="Guardar Devolución" onclick="btnGuardarDev_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir Devolucion" 
            Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
            Text="Nueva Devolucion" Visible="False" />
    </div>
</asp:Content>
