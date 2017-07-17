<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Etiqueta_Wip.aspx.cs" Inherits="Intranet.ModuloWip.View.Etiqueta_Wip" %>

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
            width: 150px;
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
    <div align="center">
    
        <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="XX-Large" 
            Text="Control Wip"></asp:Label>
        <br />
        <br />
    
    </div>
    <table style="width:100%;" border="1px">
        <tr>
            <td class="style2" align="center" rowspan="2" style="padding:20px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo color lateral.jpg" width="159px" height="39px" />
            </td>
            <td align="center" colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Numero OT" 
                    Font-Size="X-Large"></asp:Label>
        
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblOT" runat="server" Font-Size="110px" Font-Bold="True"></asp:Label>
          
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Nombre OT" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="lblNombreOT" runat="server" Font-Size="XX-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Fecha Creación" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Tiraje" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Pliego" 
                    Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="lblFechaCreacion" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblTiraje" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblPliego" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="Hora Creación" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Pliegos Impresos" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="Peso Pallet" 
                    Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="lblHora" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblEjemplar" runat="server" Font-Size="X-Large"></asp:Label><asp:Label ID="lblPallet" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblCantidad" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Operador" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="Máquina" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="Destino" 
                    Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="lblOperador" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblMaquina" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblDestino" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" align="center" colspan="3">
                <br />
                <asp:Image ID="imgCodigo" runat="server" Height="150px"/>
                <br />
                <asp:Label ID="lblCodigo" runat="server" Font-Size="110px" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
        </tr>
    </table>
    </form>
    </body>
</html>
