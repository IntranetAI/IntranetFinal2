<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="DevolucionPallet.aspx.cs" Inherits="Intranet.ModuloWip.View.DevolucionPallet" %>

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
             width: 289px;
         }
         .style5
         {
             width: 289px;
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
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:Panel ID="pnlOT" runat="server">  
   <fieldset id="fs1" style="width: 1000px;margin-left:31px;">
   <legend>Datos OT</legend>
       <table style="width:100%;">
           <tr>
               <td class="style5">
                   &nbsp;</td>
               <td class="style9">
                <asp:Label ID="Label3" runat="server" Text="OT:" Font-Bold="True"></asp:Label>
               </td>
               <td>
                <asp:TextBox ID="txtOT" runat="server" MaxLength="9"></asp:TextBox>
               &nbsp;&nbsp;
                   <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                       onclick="btnBuscar_Click" />
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="style5">
                   &nbsp;</td>
               <td class="style9">
                <asp:Label ID="Label4" runat="server" Text="Cliente:" Font-Bold="True"></asp:Label>
               </td>
               <td>
                <asp:Label ID="txtCliente" runat="server"></asp:Label>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="style5">
                   &nbsp;</td>
               <td class="style9">
                   <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Tiraje OT:"></asp:Label>
               </td>
               <td>
                   <asp:Label ID="lblTirajeOT" runat="server"></asp:Label>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
       </table>
   </fieldset>
   </asp:Panel>
    <asp:Panel ID="pnlPallet" runat="server" Visible="false">  
   <fieldset id="Fieldset2" style="margin-left:31px;width:1000px;">
   <legend>Datos Pallet</legend>
       <table style="width:100%;">
           <tr>
               <td class="style19" colspan="3">
                   <asp:Label ID="Label15" runat="server" Font-Bold="True" 
                       Text="Seleccione Pallet a Devolver:"></asp:Label>
               </td>
           </tr>
           <tr>
               <td class="style22" colspan="3" align="center">
                   <div style="border:1px solid blue;min-height:50px; max-height:150px;overflow-y:auto;width:980px;" >
                <telerik:RadGrid ID="RadGridOT" BorderWidth="0px" runat="server"  Skin="Outlook" Width="960px"
                      GridLines="None">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID_Control">
                        <NoRecordsTemplate>
                            <div style="text-align:center;">
                                <br />
                                ¡ No se han encontrado registros !<br /></div>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn" >
                                <HeaderTemplate>Todas 
                                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                                </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect"  runat="server" />
                                    </ItemTemplate>
                              </telerik:GridTemplateColumn >
                            <telerik:GridBoundColumn DataField="OT" HeaderText="OT" 
                                ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                <ItemStyle Width="30px" />
                            </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                                SortExpression="NombreOT" UniqueName="NombreOT">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="ID_Control" HeaderText="Pallet" 
                                ReadOnly="True" SortExpression="ID_Control" UniqueName="ID_Control" ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                                                                                    
                            <telerik:GridBoundColumn DataField="Pliego"   HeaderText="Pliego" UniqueName="Pliego" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="Pliegos_Impresos" HeaderText="Cant. Pliegos" 
                                ReadOnly="True" SortExpression="Pliegos_Impresos" UniqueName="Pliegos_Impresos" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Peso_pallet" HeaderText="Peso Pallet" 
                                ReadOnly="True" SortExpression="Peso_pallet" UniqueName="Peso_pallet" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle Width="40px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Maquina_Proceso" HeaderText="Pallets" 
                                ReadOnly="True" SortExpression="Maquina_Proceso" UniqueName="Maquina_Proceso" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Estado_Pallet2" HeaderText="Estado" 
                                ReadOnly="True" SortExpression="Estado_Pallet2" UniqueName="Estado_Pallet2">
                            </telerik:GridBoundColumn>

                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="True">
                    </ClientSettings>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                        EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                </div>
               
               
               </td>
           </tr>
           <tr>
               <td><asp:Label ID="Label8" runat="server" Text="Causa Devolución:" Font-Bold="True"></asp:Label></td>
               <td>
               
                <asp:DropDownList ID="ddlCausa" runat="server" Width="162px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlCausa_SelectedIndexChanged" >
                    <asp:ListItem>Seleccionar</asp:ListItem>
                    <asp:ListItem>Repinte</asp:ListItem>
                    <asp:ListItem>Secado</asp:ListItem>
                    <asp:ListItem>Calse</asp:ListItem>
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
   </asp:Panel>
    <asp:Panel ID="PanelCantidad" runat="server" Visible="false">  
      <fieldset id="Fieldset3" style="width: 1000px;margin-left:31px;">
   <legend>Datos Devolución</legend>
          <table style="width:100%;">
              <tr>
                  <td class="style26">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" 
                    Text="Pallet:"></asp:Label>
                  </td>
                  <td class="style25">
                <asp:DropDownList ID="ddlPliego" runat="server" Width="162px" AutoPostBack="True" 
                          ontextchanged="ddlPliego_TextChanged">
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
                                   <div style="max-height:80px;width:900px; overflow-y:auto;" >
            <telerik:radgrid ID="RadGrid2" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID_Control">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" UniqueName="OT"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ID_Control" HeaderText="Pallet"  UniqueName="Pallet"   >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Pliegos_Impresos" HeaderText="Cantidad"  UniqueName="Cantidad"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
              </Columns>
              </MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
              
              </div>
               </td>
              </tr>
              </table>
   </fieldset>
   </asp:Panel>
    <br />

    <div align="center" style="width: 1029px" id="divMensaje" runat="server" visible="false">
       <asp:Image ID="imgMensaje" runat="server" />&nbsp; <asp:Label ID="lblMensaje" 
            runat="server"></asp:Label>
            
    </div>

    <div align="center" style="width: 1029px">
        <asp:Button ID="btnGuardarDev" 
            runat="server" Text="Guardar Devolución" onclick="btnGuardarDev_Click" 
            Visible="False" /> &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir Devolucion" 
            Visible="False" onclick="btnImprimir_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
            Text="Nueva Devolucion" Visible="False" />
    </div>
</asp:Content>
