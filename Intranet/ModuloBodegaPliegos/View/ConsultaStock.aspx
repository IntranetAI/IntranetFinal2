<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="ConsultaStock.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.ConsultaStock" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="background-color:#EEE;border:1px solid #999;margin-left:12%;border-radius:10px 10px 10px 10px; width: 825px;" 
        align="center">

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label1" runat="server" Text="SKU:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtSku" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                <asp:Label ID="Label11" runat="server" Text="Tipo Papel:"></asp:Label>
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtPapel" runat="server"></asp:TextBox>
               </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
               
                &nbsp;</td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label2" runat="server" Text="Gramaje:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtGramaje" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">

                   <asp:Label ID="Label18" runat="server" Text="Ancho:"></asp:Label>
               
               </td>
            <td class="style4">
               
                <asp:TextBox ID="txtAncho" runat="server"></asp:TextBox>
               
               </td>
            <td class="style2">
                <asp:Label ID="Label19" runat="server" Text="Largo: "></asp:Label>
               </td>
            <td class="style6">
               
                <asp:TextBox ID="txtLargo" runat="server"></asp:TextBox>

                </td>
        </tr>

        <tr>
               <td class="style4">
               &nbsp;&nbsp;
                   <asp:Label ID="Label20" runat="server" Text="Marca:"></asp:Label>
               
            </td>
            <td class="style4">
               
                <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
               
               </td>
            <td class="style4">
                <asp:Label ID="Label21" runat="server" Text="Certificación:"></asp:Label>
               </td>
            <td class="style4">
               
                <asp:DropDownList ID="ddlCertificacion" runat="server" Width="173px">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                    <asp:ListItem>FSC</asp:ListItem>
                    <asp:ListItem>PEFC</asp:ListItem>
                </asp:DropDownList>
               </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
               
                <asp:Button ID="btnFiltro" runat="server" Text="Filtrar"  Width="73px" 
                    onclick="btnFiltro_Click1" />

                </td>
        </tr>
        </table>
        <br />
                <div style="height:490px;width:1085px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="SKU" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="320px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>
                    
                     <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left"  SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Certificacion" HeaderText="Cert." ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left"  SortExpression="Certificacion" UniqueName="Certificacion">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Pliegos" HeaderText="Pliegos" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Pliegos" UniqueName="Pliegos">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Kilos" HeaderText="Kilos" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Kilos" UniqueName="Kilos">
                    </telerik:GridBoundColumn>
                                
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
                </div>
</asp:Content>
