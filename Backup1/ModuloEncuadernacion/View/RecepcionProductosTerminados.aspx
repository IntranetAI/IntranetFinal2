<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="RecepcionProductosTerminados.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.RecepcionProductosTerminados" %>
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
            width: 242px;
        }
        .style3
        {
            width: 234px;
        }
        .style4
        {
            width: 231px;
        }
        .style5
        {
            width: 98px;
        }
        .style8
        {
            width: 242px;
        }
        .style9
        {
            width: 231px;
            height: 23px;
        }
        .style10
        {
            width: 98px;
            height: 23px;
        }
        .style11
        {
            height: 23px;
            width: 242px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<div align="center">
 <h3 style="color: rgb(23, 130, 239);">Recepción Productos Terminados</h3>
</div>--%>
<asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderStyle="None">
     
    <table style="width: 100%;">
        
        <tr>
            <td class="style4">
            </td>
            <td class="style5">
            </td>
            <td class="style8">
                </td>
            <td class="style8">
            </td>
        </tr>
        <tr>
            <td class="style9">
                </td>
            <td class="style10">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Código Pallet: "></asp:Label>
                </td>
            <td class="style11">
                <asp:TextBox ID="txtCodigo" runat="server" AutoPostBack="True" 
                    ontextchanged="txtCodigo_TextChanged"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnFiltro_Click" />
                </td>
            <td class="style11">
                </td>
        </tr>
        </table>
                    <div align="center" id="DivMensaje" runat="server">
             <asp:Image ID="imgMensaje" runat="server" />
                &nbsp;
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
               
            </div>

            <div align="right" style="width: 844px">
            <a    title="Aprobar Productos Terminados Seleccionados">
                <asp:ImageButton ID="ibAprobar" runat="server" ImageUrl="~/Images/check.png" 
                    Width="20px" OnClick="ibAprobar_Click1"   />
                <asp:Label ID="Label1" runat="server" Text="Aprobar"></asp:Label>
                
            </a>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

           <a    title="Rechazar Productos Terminados Seleccionados">
                <asp:ImageButton ID="ibRechazar" runat="server" ImageUrl="~/Images/cross.png" 
                    Width="20px" onclick="ibRechazar_Click"   />
                <asp:Label ID="Label2" runat="server" Text="Rechazar"></asp:Label>
                
            </a>
            </div>
    
     <div style="border:1px solid blue;height:500px;Width:1087px; overflow:scroll;" >
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
                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                </telerik:GridBoundColumn>  
                 
                <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px" 
                    SortExpression="Observacion" UniqueName="Observacion">
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                </telerik:GridBoundColumn> 

<%--           <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" 
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" 
                    SortExpression="Estado" UniqueName="Estado">
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                </telerik:GridBoundColumn>--%>

<%--                                 <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                  
              <ItemStyle CssClass="editCell" Width="70px"></ItemStyle>
                            <ItemTemplate>        

                                <asp:ImageButton  ID="imgEliminar" ImageUrl="~/Images/editar-icono-9796-128.png"  Width="17px" CommandName="CustomEdit" runat="server" />
                            </ItemTemplate>
                        
              </telerik:GridTemplateColumn>--%>

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
    <div align="center" style="width: 1096px">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Registros" 
            onclick="btnGuardar_Click" Visible="False" />
        &nbsp;&nbsp;
        <asp:Button ID="btnImprimir" runat="server" onclick="btnImprimir_Click" 
            Text="Imprimir" Visible="False" />
    </div>
    <br />
       </asp:Panel>
</asp:Content>
