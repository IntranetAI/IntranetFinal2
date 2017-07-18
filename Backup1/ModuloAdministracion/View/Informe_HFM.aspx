<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="Informe_HFM.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.Informe_HFM" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server" Visible="true">
    <table style="background-color:#EEE;border:1px solid #999;padding:5px;margin-left:-4px;border-radius:10px 10px 10px 10px;" align="center" width="890px">
        <tr>
            <td><asp:Label ID="lblAño" runat="server" Text="Año"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlAño" runat="server">
                </asp:DropDownList>
            </td>
            <td><asp:Label ID="lblMes" runat="server" Text="Mes : "></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlMes" runat="server">
                </asp:DropDownList>
            </td>
            <td>
            <div style="margin-left:17px;">
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar"  Width="73px" 
                     style="height: 26px" onclick="btnFiltro_Click" /><%--onclick="btnFiltro_Click1"--%>
           </div>    
            </td>

        </tr>
    </table>
    <br />
        </asp:Panel>
    <div style="width:950px;max-height:430px;overflow-y:auto;margin-left:-10px;margin-top:-10px;">
    <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" Width="932px"  >
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="">
            <NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado Registro !<br /></div></NoRecordsTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridBoundColumn DataField="Entidad" UniqueName="Entidad" HeaderText="Entidad">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Año" HeaderText="Año" UniqueName="Año">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Mes" HeaderText="Mes" UniqueName="Mes">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NCuenta" HeaderText="N° Cuenta" UniqueName="NCuenta">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Nombre_Cuen" HeaderText="Nombre Cuenta" UniqueName="Nombre_Cuen">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Saldo" HeaderText="Saldo" UniqueName="Saldo" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                            
              </Columns></MasterTableView>
              
              
              <ClientSettings EnableRowHoverStyle="true"></ClientSettings><HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
              
              </telerik:radgrid>
              </div>
        <div align="center">
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" 
                 Visible="False" onclick="btnExportar_Click" />
           
            
         </div>

    
        
    <br />
</asp:Content>
