<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_Inventario.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Informe_Inventario" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 228px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-10px;border-radius:10px 10px 10px 10px;" align="center" width="945px">
               
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Nombre Inventario:"></asp:Label>
            </td>
            <td style="width:134px;">
                <%--<asp:DropDownList ID="ddlInventarios" runat="server">
                </asp:DropDownList>--%>
                <asp:TextBox ID="txtNombreLista" runat="server"></asp:TextBox>
            </td>
            <td style="width:95px;">
                &nbsp;</td>
            <td style="width:134px;">
                
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" OnClick="btnFiltro_Click" />
            </td>
            <td style="width:300px;" colspan ="2">
            <div style="margin-left:17px;">
                
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ModuloRFrecuencia/View/Informe_Inventario_Listas.aspx">Ver Listas</asp:LinkButton>
           </div>
            </td>

        </tr>
    </table>
    <br />
           <div runat="server" id="divbotones" style="text-align: right; width: 100%; 
            margin-left: -10px;">
            <a title="Exportar a Excel">
                <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                    Width="20px" Visible="True" OnClick="ibExcel_Click" /></a>
        </div>
        <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" AllowSorting="True" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Codigo">
                    <NoRecordsTemplate>
                        <div style="text-align: center;">
                            <br />
                            ¡ No se han encontrado Trabajo !<br />
                        </div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" UniqueName="Codigo">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="SKU" HeaderText="SKU" SortExpression="SKU" UniqueName="SKU">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" SortExpression="Papel" UniqueName="Papel">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Kilos" HeaderText="Kilos" SortExpression="Kilos" UniqueName="Kilos">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Bodega" HeaderText="Bodega" SortExpression="Bodega" UniqueName="Bodega">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Ubicacion" HeaderText="Ub" SortExpression="Ubicacion" UniqueName="Ubicacion">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                </ClientSettings>
                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
