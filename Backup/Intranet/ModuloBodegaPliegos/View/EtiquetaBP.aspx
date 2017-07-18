<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EtiquetaBP.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.EtiquetaBP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 298px;
        }
        </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
<div align="center">
    
        <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="35pt" 
            Text="Bodega Pliegos"></asp:Label>
</div>
    <table style="width:100%;" border="1px">
        <tr>
            <td class="style2" rowspan="2">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/LOGO A.png" 
                    Height="97px" Width="244px" 
                />
            </td>
            <td colspan="2" align="center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Numero OT" 
                    Font-Size="35pt"></asp:Label>
        
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblOT" runat="server" Font-Size="70pt" Font-Bold="True"></asp:Label>
          
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Nombre OT" 
                    Font-Size="25pt"></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="lblNombreOT" runat="server" Font-Size="25pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label31" runat="server" Font-Bold="True" Text="SKU" 
                    Font-Size="25pt"></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="lblSKU" runat="server" Font-Size="25pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Papel" 
                    Font-Size="25pt"></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="lblPapel" runat="server" Font-Size="25pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="Gramaje" 
                    Font-Size="25pt"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label29" runat="server" Font-Bold="True" Text="Ancho" 
                    Font-Size="25pt"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label30" runat="server" Font-Bold="True" Text="Largo" 
                    Font-Size="25pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="lblGramaje" runat="server" Font-Size="40pt" Font-Bold="True"></asp:Label>
            </td>
            <td align="center"> 
                <asp:Label ID="lblAncho" runat="server" Font-Size="40pt" Font-Bold="True"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblLargo" runat="server" Font-Size="40pt" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Componente" 
                    Font-Size="25pt"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Cantidad" 
                    Font-Size="25pt"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="Peso Pallet" 
                    Font-Size="25pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="lblComponente" runat="server" Font-Size="25pt"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblCantidadPliegos" runat="server" Font-Size="25pt"></asp:Label>
                <asp:Label 
                    ID="lblCantidadPliegos0" runat="server" Font-Size="20pt">  Pliegos.</asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblPesoPallet" runat="server" Font-Size="25pt"></asp:Label>
                <asp:Label ID="lblCantidadPliegos1" runat="server" Font-Size="X-Large">KG.</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label34" runat="server" Font-Bold="True" Text="Formato Dimensionadora" 
                    Font-Size="25pt"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Operador" 
                    Font-Size="25pt"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Fecha Creación" 
                    Font-Size="25pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="lblFormatoAnterior" runat="server" Font-Size="25pt"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblOperador" runat="server" Font-Size="25pt"></asp:Label>
            </td>
            <td style="margin-left: 120px" align="center">
                <asp:Label ID="lblFechaCreacion" runat="server" Font-Size="25pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                <br />
            </td>
        </tr>
        </table>
        <br /> <br />

                        <div style="margin-left:200px;">
                <asp:Image ID="imgCodigo" runat="server" Height="200px" Width="1500px"/>
          </div>
    <div align="center">
                <asp:Label ID="lblCodigo" runat="server" Font-Size="70pt" Font-Bold="True"></asp:Label>
    </div>


    </form>
    </body>
</html>
