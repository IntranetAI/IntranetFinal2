﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reasignar_Ubicacion.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.Reasignar_Ubicacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reasignar Ubicación</title>
     <script src="../../javascripts/jquery-1.9.1.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 19px;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <asp:Panel ID="pnlInicio" runat="server" Width="233px">
        <div align="center">
            <asp:Label ID="Label4" runat="server" Text="Label" style="color: rgb(23, 130, 239);font-size: 12px;font-weight: bold">Ubicación</asp:Label>
<%--            <h2 style="color: rgb(23, 130, 239); font-size: 12px; font-weight: bold; width: 229px;">
                Ubicación
            </h2>--%>
        </div><asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Small"
            Text="Codigo:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtCodigo" runat="server" AutoPostBack="True" OnTextChanged="txtCodigo_TextChanged"
            Width="100px"></asp:TextBox>
    </asp:Panel>
    <asp:Panel ID="pnlDetalle" runat="server" Width="234px" Visible="False">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Small" 
                        Text="OT:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOT" runat="server" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Nombre:" 
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td class="style1">
                    <asp:Label ID="lblNombreOT" runat="server" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Small" 
                        Text="Papel:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPapel" runat="server" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Small" 
                        Text="Cantidad:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCantidad" runat="server" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Ubicación:" Font-Bold="True" 
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblUbicacion" runat="server" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="X-Small" 
                        Text="N. Ubicación:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUbicacion" runat="server" Width="72px" ></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    &nbsp;&nbsp;
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="68px" Visible="False"
        OnClick="btnGuardar_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Width="68px" OnClick="btnNuevo_Click"
        Visible="False" />
    &nbsp;&nbsp;
    <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnCancelar_Click"
        Width="69px" />
    &nbsp;&nbsp;
    <br />
    <div align="center" style="width: 233px" id="DivMensaje" runat="server">
        <asp:Image ID="Image1" runat="server" />
        <asp:Label ID="lblMensaje" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label>
    </div>
    <br />
    <div style="visibility: hidden;">
        <asp:Label ID="lblNombre" runat="server" /></div>
         <div style="visibility:hidden;"><asp:Label ID="lblTipo" runat="server" /></div> 
    </form>
</body>
</html>
