<%@ Page Title="" Language="C#" MasterPageFile="~/View/index.Master" AutoEventWireup="true"
    CodeBehind="Devolucion_Prov.aspx.cs" Inherits="Intranet.ModuloDespacho.View.Devolucion_Prov" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divTitulo
        {
            background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
            font-weight: bold;
            padding: 5px;
            border: 1px solid #959595;
            text-align: left;
        }
        .divSeccion
        {
            padding: 10px;
            border: 1px solid #959595;
            border-top: 0px;
            margin-bottom: 2px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function DatosOT() {
            var OT = document.getElementById("<%= txtOT.ClientID %>").value;
            $.ajax({
                url: "Devolucion_Prov.aspx/DatosOT",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OT':'" + OT + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblDatosOTs").innerHTML = msg.d[0];
                },
                error: function () {
                    alert('no funca');
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divTitulo">
        N° de OT : 
        <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
        &nbsp;
        <input id="btnFiltro1" type="button" value="button" onclick = "javascript:DatosOT();"/>
        <asp:Button ID="btnFiltro" runat="server" Text="Button" Visible="false"/>
    </div>
    <div class="divSeccion">
        <asp:Label ID="lblDatosOTs" runat="server" Text=""></asp:Label>
    </div>
    <div class="divTitulo">Devolución</div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblCodigo" runat="server" Text="Codigo:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCodigos" runat="server">
                    </asp:DropDownList>
                </td>
                <td rowspan="6">
                    <div id="tblCalculoPliegos">
                        <table id='tblRegistro' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC;
                            margin: 0 auto; margin-top: 0px; width: 350px;'>
                            <tbody>
                                <tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif;
                                    color: #003e7e; text-align: left;'>
                                    <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        Resumen Operacion
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                                        text-align: center;' class="style16">
                                        Interior
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        Tapa
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        Total
                                    </td>
                                </tr>
                                <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                                    color: #333; vertical-align: text-top;'>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label20" runat="server" Text="Cantidad Pliegos A3"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;' class="style16">
                                        <asp:Label ID="lblCantPliegosInt" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                                    color: #333; vertical-align: text-top;'>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label1" runat="server" Text="Cantidad de Clicks"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;' class="style16">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                                    color: #333; vertical-align: text-top;'>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label26" runat="server" Text="Merma"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;' class="style16">
                                        <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                                    color: #333; vertical-align: text-top;'>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label30" runat="server" Text="Peso Pedido"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;' class="style16">
                                        <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                                        text-align: center;'>
                                        <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lblTiraje" runat="server" Text="Tiraje:"></asp:Label></td>
                <td><asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Label ID="lblPeso" runat="server" Text="Peso :"></asp:Label></td>
                <td><asp:TextBox ID="txtPeso" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td><asp:Button ID="btnGuardar" runat="server" Text="Button" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
