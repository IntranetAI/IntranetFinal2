<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="EnvioaProveedor.aspx.cs" Inherits="Intranet.ModuloDespacho.View.EnvioaProveedor" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

    function habilitar() {
        document.getElementById("divMostrar").disabled = true;
    }
</script>
    <style type="text/css">
        .style3
        {
            width: 91px;
        }
        .style5
        {
            width: 104px;
        }
        .style6
        {
            width: 374px;
        }
        .style7
        {
            height: 23px;
        }
        .style8
        {
            height: 23px;
            width: 135px;
        }
        .style10
        {
            height: 23px;
            width: 261px;
        }
        .style11
        {
            width: 261px;
        }
        .style12
        {
            height: 23px;
            width: 281px;
        }
        .style14
        {
            width: 135px;
        }
        .style15
        {
            width: 307px;
        }
        .style16
        {
            width: 285px;
        }
        .style17
        {
            width: 133px;
        }
        .style18
        {
            width: 281px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
    <table style="width:99%;">
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Buscar OT:"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtNumeroOT" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltro" runat="server" Text="Buscar" 
                    onclick="btnFiltro_Click" />
                <asp:Label ID="lblidProcesoExterno" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
    <br />
    <div id="divMostrar" >
    <fieldset>
    <legend>Datos OT</legend>


        <table style="width:99%;">
            <tr>
                <td class="style12">
                </td>
                <td class="style8">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Nombre OT:"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
                <td class="style7">
                </td>
            </tr>
            <tr>
                <td class="style18">
                    &nbsp;</td>
                <td class="style14">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Tiraje:"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="lblTirajeOT" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style18">
                    &nbsp;</td>
                <td class="style14">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Pliegos:"></asp:Label>
                </td>
                <td class="style11">
                    <asp:DropDownList ID="ddlPliegos" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlPliegos_SelectedIndexChanged" 
                        style="height: 22px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>


    </fieldset>

    <fieldset>
    <legend>Datos Pliego</legend>
        <table style="width:100%;">
            <tr>
                <td class="style16">
                    &nbsp;</td>
                <td class="style17">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Proceso Externo:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblProcesoExterno" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style16">
                    &nbsp;</td>
                <td class="style17">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Forma:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblForma" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style16">
                    &nbsp;</td>
                <td class="style17">
                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Tiraje Pliego:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTirajePliego" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style16">
                    &nbsp;</td>
                <td class="style17">
                    <asp:Label ID="Label17" runat="server" Font-Bold="True" 
                        Text="Cantidad a Enviar:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCantidadAEnviar" runat="server"></asp:TextBox>
                    <asp:Label ID="lblR" runat="server" Text="* Pliegos Restantes:" ForeColor="Red"></asp:Label>
                &nbsp;<asp:Label ID="lblRestantes" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style16">
                    &nbsp;</td>
                <td class="style17">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </fieldset>
    </div>
    <div align="center" style="width: 1092px">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
            onclick="Button1_Click" /></div>
</asp:Content>
