<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Informe_Bodegas.aspx.cs" Inherits="Intranet.ModuloWip.View.Informe_Bodegas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color: #EEE; border: 1px solid #999; padding: 5px; border-radius: 10px 10px 10px 10px;"
        align="center" width="910px">
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Lugar de Ubicación :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlBodega" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBodega_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Rack :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlNumeroRack" runat="server"></asp:DropDownList>
            </td>
            <td>
                <div align="right" style="width: 184px;">
                    <asp:Button ID="btnFiltro" runat="server" OnClick="btnFiltro_Click" Style="height: 26px"
                        Text="Filtrar" Width="73px" />
                </div>
            </td>
        </tr>
    </table>
    <div style="min-height:400px;margin-top:5px;"><asp:Label ID="RackUbicacion" runat="server" Text=""></asp:Label></div>
    <br />
    <asp:Label ID="Label10" runat="server"></asp:Label>
</asp:Content>
