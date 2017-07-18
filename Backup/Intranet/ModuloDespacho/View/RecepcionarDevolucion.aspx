<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="RecepcionarDevolucion.aspx.cs" Inherits="Intranet.ModuloDespacho.View.RecepcionarDevolucion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 403px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 80%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Ingrese Folio: "></asp:Label>
                <asp:TextBox ID="txtFolio" runat="server" AutoPostBack="True" 
                    ontextchanged="txtFolio_TextChanged"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div id="divMensaje" align="center" runat="server">
        <asp:Image ID="imgMensaje" runat="server" /><asp:Label ID="lblMensaje" 
            runat="server"></asp:Label>
    </div>
  
        <div align="center" id="DivGrilla" runat="server"
        style="height:502px;width:1090px; overflow:auto;border:1px inset blue;" >
    <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook" 
                Height="500px"  >  
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Folio">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado OTs Nuevas !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
            <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" 
                                ReadOnly="True" SortExpression="Folio" UniqueName="Folio" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                                </telerik:GridBoundColumn>

                                
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" SortExpression="OT" 
                                UniqueName="OT" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                                </telerik:GridBoundColumn>
                               
                            
                            <telerik:GridBoundColumn DataField="Producto" HeaderText="Producto" 
                            UniqueName="Producto" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="TirajeOT" HeaderText="Tiraje OT" 
                            UniqueName="TirajeOT" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            
                                  <telerik:GridBoundColumn DataField="Cliente" HeaderText="Cliente" 
                                SortExpression="Cliente" UniqueName="Cliente" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Left"></telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="CausaDevolucion" HeaderText="Causa Devolucion" 
                            UniqueName="CausaDevolucion" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                           
                           
                           <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" 
                            UniqueName="Observacion" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
              
              
                            <telerik:GridBoundColumn DataField="Total_Dev" HeaderText="Total Devolucion" 
                            UniqueName="Total_Dev" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="CreadaPor" HeaderText="Creada por" 
                            UniqueName="CreadaPor" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha Creacion" 
                            UniqueName="FechaCreacion" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>

              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
    </div>
    <br />
    <div align="center" >
        <asp:Button ID="btnRecepcionar" runat="server" Text="Recepcionar" 
            Visible="False" onclick="btnRecepcionar_Click" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" Visible="False" 
            Width="97px" onclick="btnRechazar_Click"/>
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFiltro" runat="server" onclick="btnNuevo_Click" 
            Text="Nuevo" Visible="False" />
    </div>
</asp:Content>
