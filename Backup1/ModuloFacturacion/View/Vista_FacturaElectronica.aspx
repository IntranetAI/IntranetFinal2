<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vista_FacturaElectronica.aspx.cs" Inherits="Intranet.ModuloFacturacion.View.Vista_FacturaElectronica" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 269px;
            height: 66px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <img class="style1" src="../../Images/qgLogoPDF.JPG" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="border-style: solid; width: 190px; font-size: 22px; font-weight: bold;
                    vertical-align: top;">
                    Rut .: 96.830.710-K
                </td>
            </tr>
        </table>
        <table style="width: 100%; border-style: solid; border-width: 1px; border-color: black;">
            <tr style="border-top: solid;">
                <td colspan="4" align="center" style="font-size: 20px;">
                    <asp:Label ID="lblTipo" runat="server" Text="" Font-Bold="true"></asp:Label>
                    <strong>Estandar N°</strong>&nbsp;
                    <asp:Label ID="lblNFactura" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    R.U.T :
                </td>
                <td>
                    <asp:Label ID="lblRut" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
                <td style="width: 100px;">
                    Fecha
                </td>
                <td>
                    <asp:Label ID="lblFecha" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    Nombre:
                </td>
                <td>
                    <asp:Label ID="lblNombreCliente" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
                <td style="width: 100px;">
                    Comuna
                </td>
                <td>
                    <asp:Label ID="lblComuna" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    Giro
                </td>
                <td>
                    <asp:Label ID="lblgiro" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
                <td style="width: 100px;">
                    Ciudad
                </td>
                <td>
                    <asp:Label ID="lblCiudad" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    Sucursal
                </td>
                <td>
                    <asp:Label ID="lblSucursal" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
                <td style="width: 100px;">
                    Pais
                </td>
                <td>
                    <asp:Label ID="lblPais" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    Dirección
                </td>
                <td>
                    <asp:Label ID="lblDireccion" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 100%; border-style: solid; border-width: 1px; border-color: black;">
            <tr>
                <td style="width: 120px;">
                    Vendedor
                </td>
                <td style="width: 300px;">
                    <asp:Label ID="lblVendedor" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
                <td style="width: 100px;">
                    Agencia
                </td>
                <td>
                    <asp:Label ID="lblAgencia" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 120px;">
                    Condicion Venta
                </td>
                <td>
                    <asp:Label ID="lblCondicion" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Guías
                </td>
                <td colspan="3">
                    <asp:Label ID="lblGuias" runat="server" Text=":" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 100%; border-style: solid; border-width: 1px; border-color: black;">
            <tr>
                <td align="center" style="width: 100px;">
                    Cantidad
                </td>
                <td align="center" style="border-left: 1px solid black;">
                    Descripción
                </td>
                <td align="center" style="width: 130px; border-left: 1px solid black;">
                    Valor Unitario
                </td>
                <td align="center" style="width: 150px; border-left: 1px solid black;">
                    Total
                </td>
            </tr>
        </table>
        <asp:Label ID="lblTablaDetalle" runat="server" Text=""></asp:Label>
        <br />
        <div runat="server" id="DIVreferencia" visible="false">
            <table style="width: 100%; border-style: solid; border-width: 1px; border-color: black;">
                <tr>
                    <td style="width: 100px;vertical-align:top;">
                        Referencia
                    </td>
                    <td>
                        :
                        <asp:Label ID="lblReferencia" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">Razón</td>
                    <td>:<asp:DropDownList ID="ddlRazon" runat="server">
                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            <asp:ListItem Value="1">Anula</asp:ListItem>
                            <asp:ListItem Value="2">Corrige Texto</asp:ListItem>
                            <asp:ListItem Value="3">Corrige Monto</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div runat="server" id="DIVOrdenCompra" visible="false">
            <table style="width: 100%; border-style: solid; border-width: 1px; border-color: black;">
                <tr>
                    <td style="width: 100px;">OCN°</td>
                    <td style="width: 180px;">:<asp:TextBox ID="txtNOrdenCompra" runat="server"></asp:TextBox></td>
                    <td style="width: 100px;">Fecha</td>
                    <td style="width: 180px;">:<asp:TextBox ID="txtFechaOC" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>
            </table>
        </div>
        <br />
        <table style="width: 100%; border-style: solid; border-width: 1px; border-color: black;">
            <tr>
                <td rowspan="4" style="vertical-align: top;">
                    SON
                    <asp:Label ID="lblTotalTexto" runat="server" Text=""></asp:Label>
                </td>
                <td rowspan="4" style="width: 100px;">
                    &nbsp;
                </td>
                <td align='right' style="width: 100px;">
                    <asp:Label ID="lblValor_Neto" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px;">
                    0
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px;">
                    <asp:Label ID="lblIVa" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="width: 100px;">
                    Total
                </td>
                <td align="right" style="width: 100px;">
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="Cargar A SII" OnClick="Button1_Click" />&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Salir" onclick="Button2_Click" />
    </div>
    </form>
</body>
</html>
