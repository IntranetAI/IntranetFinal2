<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Intranet.ModuloWip.View.Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="pnlWip" runat="server" Width="233px">
        <div align="center">
            <h2 style="color: rgb(23, 130, 239); font-size: 12px; font-weight: bold; width: 229px;">
                Menú WIP
            </h2>
        </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Ajustar Ubicación" Width="180px" 
                    onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnConsumo" runat="server" Text="Ajustar Peso/Cantidad" Width="180px" 
                    onclick="btnConsumo_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Eliminar Pallet" Width="180px" 
                    onclick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSalir" runat="server" Text="Salir" Width="180px" 
                    onclick="btnSalir_Click" />
            </td>
        </tr>
    </table>            
    </asp:Panel>
        <asp:Panel ID="pnlBP" runat="server" Width="233px">
        <div align="center">
            <h2 style="color: rgb(23, 130, 239); font-size: 12px; font-weight: bold; width: 229px;">
                Menú Bodega Pliegos
            </h2>
        </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Asignar Ubicación" Width="180px" onclick="Button2_Click" 
                    />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button4" runat="server" Text="Reasignar Ubicación" 
                    Width="180px" onclick="Button4_Click"   />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Salir" Width="180px" 
                    onclick="btnSalir_Click" />
            </td>
        </tr>
    </table>            
    </asp:Panel>
<%--
    <div align="center">
            <h2 style="color: rgb(23, 130, 239); font-size: 12px; font-weight: bold; width: 229px;">
                Ubicación
            </h2>
    </div>--%>
    
    </div>
    <div style="visibility:hidden;"><asp:Label ID="lblNombre" runat="server" /></div>    
    <div style="visibility:hidden;"><asp:Label ID="lblTipo" runat="server" /></div>   
    </form>
</body>
</html>
