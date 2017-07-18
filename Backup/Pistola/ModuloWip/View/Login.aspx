<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Intranet.ModuloWip.View.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            height: 19px;
        }
        #form1
        {
            width: 204px;
        }
        .style4
        {
            width: 266px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
       <table style="width: 97%;">
            <%--<tr>
                <td class="style1" colspan="3">
                   <div align="center">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/quadlogo.PNG" 
                        Width="130px" Visible="false"/>
                   </div>
                </td>
            </tr>--%>
            <tr>
                <td colspan="3">
                    <h2 style="color: rgb(23, 130, 239); font-size: 12px; font-weight: bold;">
                        A Impresores S.A.</h2>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label1" runat="server" Text="Usuario:" Font-Bold="True" 
                        Font-Size="Small"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtUsuario" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label2" runat="server" Text="Clave:" Font-Bold="True" 
                        Font-Size="Small"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Button ID="Button1" runat="server" Text="Iniciar Sesión"  Height="36px" 
                        Width="99px" onclick="Button1_Click"/>
                    <%--<asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/Images/botonLogin.PNG" onclick="ImageButton1_Click" 
                        Height="36px" Width="99px" />--%>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
