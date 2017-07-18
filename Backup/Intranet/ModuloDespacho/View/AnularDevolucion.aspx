<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="AnularDevolucion.aspx.cs" Inherits="Intranet.ModuloDespacho.View.AnularDevolucion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
.divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    font-weight: bold;
    padding: 5px;
    border: 1px solid #959595;
    text-align: left;
}
.divSeccion{
    padding: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
}
    .style3
    {
        width: 461px;
    }
    .style6
    {
    }
    .style9
    {
        width: 148px;
    }
    .style11
    {
        width: 147px;
    }
    .style12
    {
        width: 138px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="center">  <asp:Label ID="Label3" runat="server" 
        Text="Código Devolucion:"></asp:Label>
&nbsp;
                <asp:TextBox ID="txtFolio" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnFiltro_Click" />
                    
                    </div>
    <div align="center" id="DivMensaje" runat="server">
    <asp:Image ID="imgMensaje" runat="server" />
                &nbsp;
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
              
    </div>
    <asp:Panel ID="Panel1" runat="server">
    <br />

    <div class="divTitulo"> Detalle Devolución </div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="OT: "></asp:Label>
                    &nbsp;
                </td>
                <td class="style6">
                    <asp:Label ID="lblOT" runat="server" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Nombre OT:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Cliente:  "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Tiraje OT:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="lblTirajeOT" runat="server"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" 
                        Text="Cant. Devolucion:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblcanDevolucion" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" 
                        Text="Causa Devolucion:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="lblCausaDevolucion" runat="server"></asp:Label>
                </td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Observacion"></asp:Label>
                </td>
                <td class="style6" colspan="3">
                    <asp:Label ID="lblObservacion" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Creada Por:"></asp:Label>
                    &nbsp;
                </td>
                <td class="style6">
                    <asp:Label ID="lblCreadaPor" runat="server"></asp:Label>
                  
                </td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="Label17" runat="server" Font-Bold="True" 
                        Text="Estado Devolucion:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="lblEstadoDevolucion" runat="server"></asp:Label>
                </td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style12">
                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Tipo Devolucion:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="lblTipoDevolucion" runat="server"></asp:Label>
                </td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="Causa Anulacion:"></asp:Label>
        <asp:TextBox ID="txtDevolucion" runat="server" Height="98px" 
            TextMode="MultiLine" Width="816px"></asp:TextBox>
        <br />
        <br />
                <div align="center">
                <asp:Button ID="btnAnular" runat="server" onclick="btnAnular_Click" 
                    Text="Anular Devolucion" Enabled="False" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" Text="Nuevo" 
                    Width="83px" Enabled="False" />
                </div>
        </div>
    <br />


        <br />
    </asp:Panel>
    <br />

             </asp:Content>
