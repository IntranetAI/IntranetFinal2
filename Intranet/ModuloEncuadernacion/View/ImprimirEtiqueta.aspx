<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirEtiqueta.aspx.cs" Inherits="Intranet.ModuloEncuadernacion.View.ImprimirEtiqueta" %>

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
            width: 200px;
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
    <div align="center">
    
        <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="XX-Large" 
            Text="Formulario Producto Terminado"></asp:Label>
        <br />
        <br />
    
    </div>
    <table style="width:100%;" border="1px">
        <tr>
            <td class="style2" align="center" rowspan="2" style="padding:20px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo color lateral.jpg" width="159px" height="39px" />
            </td>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="OP" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Nombre OP" 
                    Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblOP" runat="server" Font-Size="XX-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblNombreOP" runat="server" Font-Size="XX-Large"></asp:Label>
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
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Cliente" 
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
                <asp:Label ID="lblCliente" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td align="center">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Terminación" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Tipo Embalaje" 
                    Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td align="center">
                <asp:Label ID="lblTerminacion" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblEmbalaje" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Cantidad Bultos en Pallet" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Ejemplares por Bulto" 
                    Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Total Ejemplares" 
                    Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Label ID="lblCantidad" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblEjemplares" runat="server" Font-Size="X-Large"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="lblTotal" runat="server" Font-Size="X-Large"></asp:Label>
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
                <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="Ultimo Proceso" 
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
                <asp:Label ID="lblProceso" runat="server" Font-Size="X-Large"></asp:Label>
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
                <asp:Image ID="imgCodigo" runat="server" />
                <br />
                <asp:Label ID="lblCodigo" runat="server"></asp:Label>
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
