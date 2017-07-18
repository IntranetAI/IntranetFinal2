<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="InformePorOTPreGuia.aspx.cs" Inherits="Intranet.ModuloDespacho.View.InformePorOTPreID" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp"  %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table align="center" width="800px" style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:65px;border-radius:10px 10px 10px 10px;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style20">
                <asp:Label ID="Label3" runat="server" Text="OT:"></asp:Label>

            </td>
            <td class="style6">
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>

            </td>
            <td class="style20">
           
                <asp:Label ID="Label6" runat="server" Text="Estado:"></asp:Label>
           
                </td>
            <td class="style11">
                <asp:DropDownList ID="ddlEstado" runat="server" Width="163px">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem Value="1">En Proceso</asp:ListItem>
                    <asp:ListItem Value="2">Impreso</asp:ListItem>
                    <asp:ListItem Value="3">Anulado</asp:ListItem>
                    <asp:ListItem Value="4">En Creacion</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style8">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td>
<asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" style="height: 26px" />
           
    
            </td>
        </tr>
        </table>
        <div runat="server" id="divbotones"  
        style="text-align:right;margin-bottom:1px;width:927px;" >
            &nbsp;

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
  


  &nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
    <asp:ImageButton ID="ibExcel" 
                   runat="server" Height="20px" 
                   ImageUrl="~/Images/Excel-icon.png" Width="20px" 
        onclick="ibExcel_Click" 
                   />
                   </a>
               &nbsp;&nbsp;&nbsp;  


       </div>

   <div runat="server" id="divGrillaGuias" visible="true"  style="height:545px;width:940px; overflow:auto;" >
            <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Registros !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="OT" HeaderText="OT"  UniqueName="OT" ItemStyle-Width="20px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" UniqueName="NombreOT" ItemStyle-Width="150px"  >
                </telerik:GridBoundColumn>
                
                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" UniqueName="Estado"  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px"  >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NroPreGuia" HeaderText="Pre Guia" UniqueName="NroPreGuia" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="NroGuia" HeaderText="N° Guia" ItemStyle-HorizontalAlign="Center"  UniqueName="NroGuia" ItemStyle-Width="30px"  >
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Sucursal"  HeaderText="Sucursal"  UniqueName="Sucursal" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Left">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="FechaDespacho" HeaderText="Fecha Despacho" ItemStyle-Width="90px" UniqueName="FechaDespacho"  ItemStyle-HorizontalAlign="Center">
                </telerik:GridBoundColumn>
                
                <telerik:GridBoundColumn DataField="TirajeOT" HeaderText="Tiraje OT" SortExpression="TirajeOT" UniqueName="TirajeOT" ItemStyle-Width="30px"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="CantidadGuia" HeaderText="Cantidad" SortExpression="CantidadGuia" UniqueName="CantidadGuia" ItemStyle-Width="30px"  ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
              </Columns>
              </MasterTableView>
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:radgrid>
              </div>
</asp:Content>
