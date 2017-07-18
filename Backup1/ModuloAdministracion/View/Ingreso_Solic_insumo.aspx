<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso_Solic_insumo.aspx.cs"
    Inherits="Intranet.ModuloAdministracion.View.Ingreso_Solic_insumo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC;
        margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width: 1400px; margin-left: 15px;">
        <tbody>
            <tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif;
                color: #003e7e; text-align: left;">
                <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                    text-align: center; width: 50px;">
                    Codigo
                </td>
                <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                    text-align: center; width: 350px;">
                    Descripcion
                </td>
                <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                    text-align: center; width: 80px;">
                    Stock
                </td>
                <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                    text-align: center; width: 100px;">
                    Grupo
                </td>
                <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                    text-align: center; width: 60px;">
                    Cantidad
                </td>
                <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                    text-align: center; width: 60px;">
                    OT
                </td>
                <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                    text-align: center; width: 350px;">
                    Nombre OT
                </td>
                <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
                    text-align: center; width: 100px;">
                    Maquina
                </td>
            </tr>
            <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                color: #333; vertical-align: text-top;">
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: left; width: 50px;">
                    <asp:Label ID="lblCodigo" runat="server" Text=""></asp:Label>
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: left; width: 350px;">
                    <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: right; width: 80px;">
                    <asp:Label ID="lblStock" runat="server" Text=""></asp:Label>
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: left; width: 100px;">
                    <asp:Label ID="lblGrupo" runat="server" Text=""></asp:Label>
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: left; width: 60px;">
                    <asp:TextBox ID="txtCantidad" runat="server" Width="60px"></asp:TextBox>
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: left; width: 60px;">
                    <asp:TextBox ID="txtOT" runat="server" Width="60px" AutoPostBack="True" 
                        ontextchanged="TextBox2_TextChanged"></asp:TextBox>
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: left; width: 350px;">
                    <asp:Label ID="lblNombreOT" runat="server" Text=""></asp:Label>
                </td>
                <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: left; width: 100px;">
                    <asp:DropDownList ID="ddlMaquina" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
                color: #333; vertical-align: text-top;">
                <td colspan="8" style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
                    text-align: center;"><div runat="server" id="Validacion" visible="False">
                        <asp:Image ID="Image1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                        onclick="btnAgregar_Click" /></td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
