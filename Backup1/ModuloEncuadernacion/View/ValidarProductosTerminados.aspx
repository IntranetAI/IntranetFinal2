<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="ValidarProductosTerminados.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.ValidarProductosTerminados" %>

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
        .style1
        {
            height: 23px;
        }
        .style3
        {
            width: 297px;
        }
        .style6
        {
            height: 23px;
            width: 109px;
        }
        .style7
        {
            height: 23px;
            width: 388px;
        }
        .style8
        {
            height: 23px;
            width: 391px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<div align="center">
 <h3 style="color: rgb(23, 130, 239);">Validación Productos Terminados</h3>
</div>--%>
<asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderStyle="None">
     
    <table style="width: 100%;">
        
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style6">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Código Pallet: "></asp:Label>
                </td>
            <td class="style1">
                <asp:TextBox ID="txtCodigo" runat="server" AutoPostBack="True" 
                    ontextchanged="txtCodigo_TextChanged"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Button" Visible="False" 
                    onclick="btnFiltro_Click" />
                </td>
            <td class="style1">
                </td>
        </tr>
        </table>
                    <div align="center" id="DivMensaje" runat="server">
             <asp:Image ID="imgMensaje" runat="server" />
                &nbsp;
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
               
            </div>

            <div align="right" style="width: 1090px">
            <a    title="Aprobar Productos Terminados Seleccionados">
                <asp:ImageButton ID="ibAprobar" runat="server" ImageUrl="~/Images/check.png" 
                    Width="20px" OnClick="ibAprobar_Click1"   />
                <asp:Label ID="Label1" runat="server" Text="Aprobar"></asp:Label>
                
            </a>

                &nbsp;&nbsp;

           <a    title="Rechazar Productos Terminados Seleccionados">
                <asp:ImageButton ID="ibRechazar" runat="server" ImageUrl="~/Images/cross.png" 
                    Width="20px" onclick="ibRechazar_Click"   />
                <asp:Label ID="Label2" runat="server" Text="Rechazar"></asp:Label>
                
            </a>
            </div>
    
     <div style="border:1px solid blue;height:500px;Width:1093px; overflow:scroll;" >
    <telerik:RadGrid ID="RadGrid1"  runat="server" BorderWidth="0px" OnItemCommand="contactsGrid_ItemCommand" Skin="Outlook" >

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
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="400px" 
                    SortExpression="NombreOT" UniqueName="NombreOT">
                    <ItemStyle HorizontalAlign="Left" Width="400px" />
                </telerik:GridBoundColumn>      

                                <telerik:GridBoundColumn DataField="Terminacion" HeaderText="Terminación" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" 
                    SortExpression="Terminacion" UniqueName="Terminacion">
                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                </telerik:GridBoundColumn>  
                
             
                <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="TipoEmbalaje" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" 
                    SortExpression="TipoEmbalaje" UniqueName="TipoEmbalaje">
                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                </telerik:GridBoundColumn>  

              <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Cantidad" UniqueName="Cantidad">
                  <ItemStyle HorizontalAlign="Left" Width="50px" />
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
                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                </telerik:GridBoundColumn>  
                 
                <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Observacion" UniqueName="Observacion">
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                </telerik:GridBoundColumn> 

              <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Estado" UniqueName="Estado">
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                </telerik:GridBoundColumn> 

                                 <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                  
              <ItemStyle CssClass="editCell" Width="70px"></ItemStyle>
                            <ItemTemplate>        
                             <%--<asp:Image ID="imgEliminar" runat="server" ImageUrl="~/Images/delete_icon.png"  Width="17px"> </asp:Image>--%>

                                <asp:ImageButton  ID="imgEliminar" ImageUrl="~/Images/editar-icono-9796-128.png"  Width="17px" CommandName="CustomEdit" runat="server" />
                            </ItemTemplate>
                             <%--<asp:LinkButton ID="LinkButton3" runat="server" CommandName="CustomEdit">Asignar/Revisar</asp:LinkButton>--%>
              </telerik:GridTemplateColumn>

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
    <br />
    <div align="center" style="width: 1091px">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Registros" 
            onclick="btnGuardar_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btnImprimir" runat="server" onclick="btnImprimir_Click" 
            Text="Imprimir" Visible="False" />
    </div>
    <br />
       </asp:Panel>
</asp:Content>
