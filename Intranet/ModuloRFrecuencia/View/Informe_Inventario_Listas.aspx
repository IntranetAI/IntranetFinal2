<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_Inventario_Listas.aspx.cs" Inherits="Intranet.ModuloRFrecuencia.View.Informe_Inventario_Listas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
            function CopiarId(id) {
                document.getElementById("ContentPlaceHolder1_txtIdLista").value = id;
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-10px;border-radius:10px 10px 10px 10px;" align="center" width="945px">
               
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblFechaInicio" runat="server" Text="ID Inventario:"></asp:Label>
            </td>
            <td class="auto-style2">
                <%--<asp:DropDownList ID="ddlInventarios" runat="server">
                </asp:DropDownList>--%>
                <asp:TextBox ID="txtIdLista" runat="server"></asp:TextBox>
                
                <asp:Button ID="btnFiltro" runat="server" Text="Eliminar" OnClick="btnFiltro_Click" />
            </td>
            <td class="auto-style3">
                </td>
            <td class="auto-style2">
                
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ModuloRFrecuencia/View/Informe_Inventario.aspx">Volver al informe</asp:LinkButton>
            </td>
            <td colspan ="2" class="auto-style4">
            <div style="margin-left:17px;">
                
           </div>
            </td>
        </tr>
    </table>
    <br />
    <div runat="server" id="divGrilla" style="height:650px;width:100%; overflow:auto;border:1px inset blue; ">
    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Outlook" AllowSorting="True" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="idInventario">
                    <NoRecordsTemplate>
                        <div style="text-align: center;">
                            <br />
                            ¡ No se han encontrado Trabajo !<br />
                        </div>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    
                    <Columns>

                        <telerik:GridBoundColumn DataField="idInventario" HeaderText="ID" SortExpression="idInventario" UniqueName="idInventario">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NombreInventario" HeaderText="NombreInventario" SortExpression="NombreInventario" UniqueName="NombreInventario">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="FechaCreacion" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Accion" HeaderText="" SortExpression="Accion" UniqueName="Accion">
                        </telerik:GridBoundColumn>

                    </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                </ClientSettings>
                <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
</div>
</asp:Content>
