<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true" CodeBehind="ControlOTEmitidas.aspx.cs" Inherits="Intranet.ModuloAdministracion.View.ControlOTEmitidas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        
.divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    font-weight: bold;
    padding-top: 5px;
    padding-bottom: 5px;
    border: 1px solid #959595;
    text-align: left;
}
.divSeccion{
    padding-top: 10px;
    padding-bottom: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
}
.divEtiqueta{
    display: inline-block;
    padding: 5px;
    font-weight: bold;
    text-align: left;
}
.divCampo{
    display: inline-block;
    text-align: left;
}
  
    .style1
    {
        height: 23px;
    }
  
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="divTitulo" style="width:920px">
                    Control OT Emitidas</div>
    <div class="divSeccion" style="width:920px;height:400px;">
        <table style="width: 100%;">
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style1">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style1">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="OT:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFiltro" runat="server" onclick="btnFiltro_Click" 
                        Text="Buscar" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style1">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Nombre OT:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Cliente:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Tiraje:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTiraje" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    </td>
                <td class="style1">
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Estado:"></asp:Label>
                </td>
                <td class="style1">
                    <asp:DropDownList ID="ddlEstado" runat="server">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                        <asp:ListItem>En Proceso</asp:ListItem>
                        <asp:ListItem>Liquidada</asp:ListItem>
                        <asp:ListItem>Anulada</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style4">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Fecha Emision:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="txtFechaEmision" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" 
                        Text="Ultima Modificacion:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblUltimaMod" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Observacion:"></asp:Label>
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    <asp:TextBox ID="txtObservacion" runat="server" Height="96px" 
                        TextMode="MultiLine" Width="358px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                        onclick="btnGuardar_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
