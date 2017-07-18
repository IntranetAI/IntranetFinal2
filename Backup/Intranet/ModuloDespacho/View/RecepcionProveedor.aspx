<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="RecepcionProveedor.aspx.cs" Inherits="Intranet.ModuloDespacho.View.RecepcionProveedor" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 319px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="center">
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Ingrese OT: "></asp:Label>
    <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
    <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
        onclick="btnFiltro_Click" />
    </div>
    <br />
    <br />
        <div align="center" id="DivGrilla" runat="server"
        style="height:502px;width:1090px; overflow:auto;border:1px inset blue;" >
       <%-- ClientSettings-EnablePostBackOnRowClick="true"  --%>
    <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook" 
                Height="500px" OnItemCommand="contactsGrid_ItemCommand" >  
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="id_Proveedor">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>

                                
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" SortExpression="OT" 
                                UniqueName="OT" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" 
                            UniqueName="NombreOT" ItemStyle-Width="190px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>


                            
                            <telerik:GridBoundColumn DataField="NombrePliego" HeaderText="Pliego" 
                            UniqueName="NombrePliego" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            


                           
                           
                           <telerik:GridBoundColumn DataField="CantidadPliego" HeaderText="Tiraje Pliego" 
                            UniqueName="CantidadPliego" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Forma" HeaderText="Forma" 
                            UniqueName="Forma" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
              
              
                            <telerik:GridBoundColumn DataField="ProcesoExterno" HeaderText="Proceso Externo" 
                            UniqueName="ProcesoExterno" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Total" HeaderText="Cantidad Enviada" 
                            UniqueName="Total" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="GeneradaPor" HeaderText="Generada Por" 
                            UniqueName="GeneradaPor" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="FechaGeneracion" HeaderText="Fecha Generacion" 
                            UniqueName="FechaGeneracion" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
    </div>
    <div style="height:502px;width:1090px;" id="divDetalle" runat="server">
    
    <div align="center">Detalle OT 
        <asp:Label ID="lblOT" runat="server" Font-Bold="True"></asp:Label>
        

        </div>
        <br />
    
            <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
