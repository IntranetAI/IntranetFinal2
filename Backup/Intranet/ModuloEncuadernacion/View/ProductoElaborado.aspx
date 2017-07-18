<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductoElaborado.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.ProductoElaborado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style ="width:100%">
        <tr>
            <td>Codigo Barra</td>
            <td><asp:TextBox ID="txtCodigoBarra" runat="server" AutoPostBack="True" 
                    ontextchanged="txtCodigoBarra_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Codigo Ingr.</td>
            <td><asp:Label ID="lblCodigo" runat="server" Text=""></asp:Label> </td>
        </tr>
        <tr>
            <td>Tipo Producto</td>
            <td>
                <asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>Cant. Solicitada</td>
            <td>
                <asp:Label ID="lblValidado" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>Cant. Faltante</td>
            <td>
                <asp:Label ID="lblFalta" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr><td colspan ="2" align="center">
            <asp:Button ID="btnSalir" runat="server" Text="Cerrar Ventana" 
                onclick="btnSalir_Click" /> </td></tr>
    </table>
    </form>
</body>
</html>
