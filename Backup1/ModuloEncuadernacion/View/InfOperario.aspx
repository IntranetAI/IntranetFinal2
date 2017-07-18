<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfOperario.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.InfOperario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
        }
        .style4
        {
            width: 91px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo color lateral.jpg" width="159px" height="39px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    
    </div>
    <table style="width:100%;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" align="right">
                    <asp:Label ID="Label1" runat="server" Text="Operador: " 
                        Font-Bold="True"></asp:Label>
                </td>
            <td>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblOperador" runat="server"></asp:Label>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" align="right">
                    <asp:Label ID="Label3" runat="server" Text="Turno:" Font-Bold="True"></asp:Label>
                </td>
            <td>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblTurno" runat="server"></asp:Label>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" align="right">
                    <asp:Label ID="Label5" runat="server" Text="Máquina: " Font-Bold="True"></asp:Label>
                </td>
            <td>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlMaquina" runat="server" Width="150px" 
                        AutoPostBack="True" onselectedindexchanged="ddlMaquina_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" align="right">
                    <asp:Label ID="Label6" runat="server" Text="Proceso:" Font-Bold="True"></asp:Label>
                </td>
            <td>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlProceso" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                    <asp:Button ID="Button1" runat="server" Text="Guardar" 
                        onclick="Button1_Click" />
                </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
