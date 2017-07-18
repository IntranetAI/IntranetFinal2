<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="InformeFinishENC.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.InformeFinishENC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100;
            height: 142px;
        }
        .style3
        {
            height: 142px;
        }
        .style4
        {
            width: 100;
            height: 50px;
        }
        .style5
        {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div runat="server" id="divbotones" style="text-align: right; width: 100%;">
        &nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp; <a title="Exportar a Excel">
            <asp:ImageButton ID="ibExcel" runat="server" Height="20px" ImageUrl="~/Images/Excel-icon.png"
                Width="20px" Visible="True" OnClick="ibExcel_Click" /></a>
    </div>
    <asp:Panel ID="Panel2" runat="server" Visible="true" Width="1082px">
        <table style="background-color: #EEE; border: 1px solid #999; padding: 5px;
            margin-bottom: 5px; border-radius: 10px 10px 10px 10px; width: 650px;" align="center">
            <tr>
                <td class="style4">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Sector : "></asp:Label>
                </td>
                <td class="style4">
                    <asp:DropDownList ID="ddlSector" runat="server" style="margin-left: 19px">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    <asp:Label ID="Label2" runat="server" Text="Fecha:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:DropDownList ID="ddlMes" runat="server">
                        <asp:ListItem Value="01">Enero</asp:ListItem>
                        <asp:ListItem Value="02">Febrero</asp:ListItem>
                        <asp:ListItem Value="03">Marzo</asp:ListItem>
                        <asp:ListItem Value="04">Abril</asp:ListItem>
                        <asp:ListItem Value="05">Mayo</asp:ListItem>
                        <asp:ListItem Value="06">Junio</asp:ListItem>
                        <asp:ListItem Value="07">Julio</asp:ListItem>
                        <asp:ListItem Value="08">Agosto</asp:ListItem>
                        <asp:ListItem Value="09">Septiembre</asp:ListItem>
                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style4">
                    <div style="margin-left: 25px;">
                        <asp:DropDownList ID="ddlAño" runat="server" Width="65px">
                        </asp:DropDownList>
                    </div>
                </td>
                <td class="style5">
                    <asp:Button ID="btnFiltro" runat="server" OnClick="btnFiltro_Click1" 
                        Style="height: 26px" Text="Filtrar" Width="73px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Height="600px" Width="100%" Direction="NotSet" ClientIDMode="Inherit">
    <div runat="server" id="divGrilla" style="height:70%;width:101%; overflow:auto;border:1px; ">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />
    </asp:Panel>
</asp:Content>
