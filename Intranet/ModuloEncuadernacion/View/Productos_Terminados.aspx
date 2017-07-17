<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="Productos_Terminados.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.Productos_Terminados" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/funciones.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
        .style3
        {
            height: 25px;
            width: 316px;
        }
        .style4
        {
            height: 25px;
            width: 147px;
        }
        .style9
        {
        }
        .style12
        {
            height: 25px;
            width: 211px;
        }
        .style13
        {
            width: 149px;
        }
        .style14
        {
            width: 229px;
        }
        .style18
        {
            width: 197px;
        }
        .style19
        {
            width: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<div align="center">
 <h3 style="color: rgb(23, 130, 239);">Formulario Productos Terminados</h3>
</div>--%>

     <div align="right" style="width: 1097px;padding-top:-10px;">
         <asp:Button ID="Button1" runat="server" Text="inf. Operario"  /></div>
    
<asp:Panel ID="pnlResultado" runat="server" Width="1095px">
            
                   <table style="width:80%;">
                       <tr>
                           <td class="style12">
                               &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                           <td class="style4">
                               <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Codigo Pallet:"></asp:Label>
                           </td>
                           <td class="style1">
                               <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="True"></asp:TextBox>
                               &nbsp;&nbsp;<asp:Button ID="btnFiltro" runat="server" onclick="btnBuscarPallet_Click" 
                                   Text="Buscar" />
                               &nbsp;&nbsp;
                               <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
                                   Text="Generar Código" />
                               <asp:Label ID="lblcodigo" runat="server" Visible="False"></asp:Label>
                           </td>
                       </tr>
                   </table>
              
             
               <asp:Panel ID="pnlError" runat="server" Visible="False">
                   <div align="center" id="DivError" runat="server">
                       <asp:Image ID="imgError" runat="server" />
                       <asp:Label ID="lblError" runat="server"></asp:Label>
                   </div>
               </asp:Panel>
     <table style="width:100%;">
         <tr>
             <td class="style19">
                 &nbsp;</td>
             <td class="style13">
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="OT:"></asp:Label>
             </td>
             <td class="style14">
                 <asp:TextBox ID="txtOT" runat="server" MaxLength="30" AutoPostBack="True" 
                     ontextchanged="txtOT_TextChanged"></asp:TextBox>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style19">
                 &nbsp;</td>
             <td class="style13">
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Nombre OT:"></asp:Label>
             </td>
             <td class="style9" colspan="2">
                 <asp:Label ID="txtNombreOT" runat="server" Font-Bold="True"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="style19">
                 &nbsp;</td>
             <td class="style13">
                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Terminación:"></asp:Label>
             </td>
             <td class="style14">
                 &nbsp;<asp:DropDownList ID="ddlTerminacion" runat="server" Width="155px"  >
                     <asp:ListItem>Ejemplares</asp:ListItem>
                     <asp:ListItem>Pliegos</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style19">
                 &nbsp;</td>
             <td class="style13">
                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Tipo Embalaje:"></asp:Label>
             </td>
             <td class="style14">
                 &nbsp;<asp:DropDownList ID="ddlTipoEmbalaje" runat="server" Width="155px" 
                     AutoPostBack="True" 
                     onselectedindexchanged="ddlTipoEmbalaje_SelectedIndexChanged">
                     <asp:ListItem>Seleccione...</asp:ListItem>
                     <asp:ListItem>Fajo</asp:ListItem>
                     <asp:ListItem>Zuncho</asp:ListItem>
                     <asp:ListItem>CMC</asp:ListItem>
                     <asp:ListItem>Caja</asp:ListItem>
                     <asp:ListItem>Embolsado</asp:ListItem>
                     <asp:ListItem>Paquete</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style19">
                 &nbsp;</td>
             <td class="style13">
                 <asp:Label ID="lblCantidad" runat="server" Font-Bold="True" Text="Cantidad:"></asp:Label>
             </td>
             <td class="style14">
                 <asp:TextBox ID="txtCantidad" runat="server" AutoPostBack="True" 
                     ontextchanged="txtCantidad_TextChanged"></asp:TextBox>
             </td>
             <td>
                 <asp:Label ID="lblEjemplares" runat="server" Font-Bold="True" 
                     Text="Ejemplares: "></asp:Label>
                 <asp:TextBox ID="txtEjemplares" runat="server" AutoPostBack="True" 
                     ontextchanged="txtEjemplares_TextChanged"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style19">
                 &nbsp;</td>
             <td class="style13">
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Total Ejemplares:"></asp:Label>
             </td>
             <td class="style14">
                 <asp:Label ID="txtTotal" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style19">
                 &nbsp;</td>
             <td class="style13">
                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Modelo:"></asp:Label>
             </td>
             <td class="style14">
                 <asp:DropDownList ID="ddlModelo" runat="server" Width="155px">
                     <asp:ListItem>Sin Modelo</asp:ListItem>
                     <asp:ListItem>1</asp:ListItem>
                     <asp:ListItem>2</asp:ListItem>
                     <asp:ListItem>3</asp:ListItem>
                     <asp:ListItem>4</asp:ListItem>
                     <asp:ListItem>5</asp:ListItem>
                     <asp:ListItem>6</asp:ListItem>
                     <asp:ListItem>7</asp:ListItem>
                     <asp:ListItem>8</asp:ListItem>
                     <asp:ListItem>9</asp:ListItem>
                     <asp:ListItem>10</asp:ListItem>
                     <asp:ListItem>Especial</asp:ListItem>
                     <asp:ListItem>Sobrante</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style19">
                 &nbsp;</td>
             <td class="style13">
                 <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Observación:"></asp:Label>
             </td>
             <td class="style9" colspan="2">
                 <asp:TextBox ID="txtObservacion" runat="server" Height="53px" TextMode="MultiLine" 
                     Width="473px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style19">
                 &nbsp;</td>
             <td class="style13">
                 &nbsp;</td>
             <td class="style14">
                 <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="89px" 
                     onclick="btnAgregar_Click" />
             </td>
             <td>
                 <asp:Button ID="btnNew" runat="server" Text="Nuevo" Width="79px" 
                     onclick="btnNew_Click" style="height: 26px" />
             </td>
         </tr>
    </table>
                <div align="center" id="DivMensaje" runat="server">
             <asp:Image ID="imgMensaje" runat="server" />
                &nbsp;
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
               
            </div>
     <asp:Label ID="Label11" runat="server" Text="Detalle OT - Pallet"></asp:Label>
                   &nbsp;<asp:Label ID="lblCodigoGrid" runat="server" Font-Bold="True"></asp:Label>
     <br />
     <div style="border:1px solid blue;height:175px;width:1088px; overflow:scroll;margin-bottom:5px;" ><%-- Height="200px" Width="800px"--%>
    <telerik:RadGrid ID="RadGrid1" runat="server" BorderWidth="0px" 
             OnItemCommand="contactsGrid_ItemCommand"  Skin="Outlook" >

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
                    ItemStyle-Width="50px" ReadOnly="True" SortExpression="OT" 
                    UniqueName="OT">
                    <ItemStyle Width="50px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="360px" 
                    SortExpression="NombreOT" UniqueName="NombreOT">
                    <ItemStyle HorizontalAlign="Left" Width="360px" />
                </telerik:GridBoundColumn>      

                                <telerik:GridBoundColumn DataField="Terminacion" HeaderText="Terminación" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" 
                    SortExpression="Terminacion" UniqueName="Terminacion">
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                </telerik:GridBoundColumn>  
                
             
                <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="Embalaje" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" 
                    SortExpression="TipoEmbalaje" UniqueName="TipoEmbalaje">
                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                </telerik:GridBoundColumn>  

              <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" 
                    SortExpression="Cantidad" UniqueName="Cantidad">
                  <ItemStyle HorizontalAlign="Left" Width="60px" />
                </telerik:GridBoundColumn>  


                <telerik:GridBoundColumn   DataField="Ejemplares" HeaderText="Ejemplares" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Ejemplares" UniqueName="Ejemplares">
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                </telerik:GridBoundColumn>  

                
                <telerik:GridBoundColumn DataField="Total" HeaderText="Total" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40px" 
                    SortExpression="Total" UniqueName="Total">
                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                </telerik:GridBoundColumn>  


                <telerik:GridBoundColumn DataField="Modelo" HeaderText="Modelo" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="170px" 
                    SortExpression="Modelo" UniqueName="Modelo">
                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                </telerik:GridBoundColumn>  
                 
                <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Observacion" UniqueName="Observacion">
                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                </telerik:GridBoundColumn> 


                 <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                  
                            <ItemStyle CssClass="editCell" Width="70px"></ItemStyle>
                            <ItemTemplate>        
                             <%--<asp:Image ID="imgEliminar" runat="server" ImageUrl="~/Images/delete_icon.png"  Width="17px"> </asp:Image>--%>

                                <asp:ImageButton  ID="imgEliminar" ImageUrl="~/Images/delete_icon.png"  Width="17px" CommandName="CustomEdit" runat="server" />
                            </ItemTemplate>
                             <%--<asp:LinkButton ID="LinkButton3" runat="server" CommandName="CustomEdit">Asignar/Revisar</asp:LinkButton>--%>
                            </telerik:GridTemplateColumn>

<%--              <telerik:GridTemplateColumn UniqueName="TemplateColumn" >
                <HeaderTemplate>Seleccionar Todas 
                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect"  runat="server" />
                    </ItemTemplate>
              </telerik:GridTemplateColumn >--%>


            </Columns>
        </MasterTableView>
        <ClientSettings EnableRowHoverStyle="true">
        </ClientSettings>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
            EnableImageSprites="True">
        </HeaderContextMenu>
    </telerik:RadGrid>

</div>
   

    <div align="center">
            <asp:Button ID="btnCerrarPallet" runat="server" Text="Guardar/Cerrar Pallet" 
                onclick="btnCerrarPallet_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnImprimir" runat="server" onclick="btnImprimir_Click" 
                Text="Imprimir" Visible="False" Width="89px" />
   </div>      
    <br />
    </asp:Panel>
</asp:Content>
