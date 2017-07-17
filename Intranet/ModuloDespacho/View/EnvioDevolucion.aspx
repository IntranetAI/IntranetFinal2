<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="EnvioDevolucion.aspx.cs" Inherits="Intranet.ModuloDespacho.View.EnvioDevolucion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 294px;
            height: 30px;
        }
        .style4
        {
            height: 30px;
            width: 440px;
        }
        .style5
        {
            width: 147px;
        }
        .style6
        {
            height: 30px;
            width: 147px;
        }
        .style8
        {
            width: 488px;
        }
        .style9
        {
            width: 488px;
            height: 30px;
        }
        .style10
        {
            width: 440px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 80%;">
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style10">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                    Text="Buscar Devolucion Por:"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdOT" runat="server" Text="OT" GroupName="rdBuscar" 
                    AutoPostBack="True" />
&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdFolio" runat="server" Text="Folio" Checked="true" 
                    GroupName="rdBuscar" AutoPostBack="True" />
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                </td>
            <td class="style4">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblFolio" runat="server" Text="Folio:" Font-Bold="True"></asp:Label>
            &nbsp;
                <asp:TextBox ID="txtFolio" runat="server"></asp:TextBox>
                <asp:Label ID="lblOT" runat="server" Font-Bold="True" Text="OT:" 
                    Visible="False"></asp:Label>
                <asp:TextBox ID="txtOT" runat="server" Visible="False"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" />
            </td>
            <td class="style6">
                </td>
        </tr>
    </table>
    <div align="center" id="divResultado" visible="false" runat="server">
                <asp:Image ID="imgResultado" runat="server" Height="20px" Width="20px" />            
                &nbsp;<asp:Label ID="lblResultado" runat="server"></asp:Label>            
            </div>


    <div align="center" id="DivGrilla" runat="server"
        style="height:502px;width:1090px; overflow:auto;border:1px inset blue;" >
    <telerik:radgrid ID="RadGrid1" runat="server" BorderWidth="0px"  Skin="Outlook" Height="500px"  ClientSettings-EnablePostBackOnRowClick="true"  OnItemCommand="contactsGrid_ItemCommand">  
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

    <div align="center" id="divBotones" visible="false" runat="server">
<asp:Button ID="btnGenerar" runat="server" Text="Generar Envio" 
            onclick="btnGenerar_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" Visible="False" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
            Text="Nuevo" />
    </div>
</asp:Content>
