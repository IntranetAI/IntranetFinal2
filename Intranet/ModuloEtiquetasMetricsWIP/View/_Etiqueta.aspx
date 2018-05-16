<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Etiqueta.aspx.cs" Inherits="Intranet.ModuloEtiquetasMetricsWIP.View._Etiqueta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-barcode.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                
            });
            function Barcode(codigo) {
    	    document.getElementById("CodigoBarra").value = codigo;
    	    $("#barcodeTarget").barcode(document.getElementById("CodigoBarra").value, "code39", { barWidth: 8, barHeight:130, showHRI: false });
    	    
    	}
	</script>
</head>
<body onload="window.print();window.close();" >
    <form id="form1" runat="server">
<br /><br /><br /><input type="text" id="CodigoBarra" style="visibility:hidden;" /><br /><br /><br />                
		<table border="1" style="height:316mm; width:279mm;font-family:Arial;">
			<tr>
				<td align="center" colspan="2" style="font-size:22pt; font-weight:bold"> OP </td>
				<td align="center"  colspan="2" style="font-size:14pt; font-weight:bold"> Trabajo </td>
			</tr>
			<tr>
				<td align="center" colspan="2" style="font-size:66pt; font-weight:bold">
                    <asp:Label ID="lblOT" runat="server"></asp:Label>
&nbsp;</td>
				<td align="center"  colspan="2" style="font-size:34pt; font-weight:bold">
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
&nbsp;</td>
			</tr>
			<tr>
				<td align="center" style="font-size:14pt; font-weight:bold"> FECHA IMPR. </td>
				<td align="center" style="font-size:14pt; font-weight:bold"> TIRAJE </td>
				<td align="center" colspan="2" style="font-size:14pt; font-weight:bold"> CLIENTE </td>
			</tr>
			<tr>
				<td align="center" style="font-size:24pt">
                    <asp:Label ID="lblFechaCreacion" runat="server"></asp:Label>
                </td>
				<td align="center" style="font-size:24pt">
                    <asp:Label ID="lblTiraje" runat="server"></asp:Label>
                </td>
				<td align="center" colspan="2" style="font-size:24pt">
                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                </td>
			</tr>
			<tr>
				<td align="center" style="font-size:14pt; font-weight:bold"> ELEMENTO </td>
				<td align="center" style="font-size:14pt; font-weight:bold"> Pliego </td>
				<td align="center" style="font-size:14pt; font-weight:bold"> ACTIVIDAD </td>
				<td align="center" style="font-size:14pt; font-weight:bold"> PRÓX. ACTIVIDAD </td>
			</tr>
			<tr>
				<td align="center" style="font-size:14pt">
                    <asp:Label ID="lblElemento" runat="server"></asp:Label>
                </td>
				<td align="center" style="font-size:14pt">
                    <asp:Label ID="lblPliego" runat="server"></asp:Label>
                </td>
				<td align="center" style="font-size:14pt">
                    <asp:Label ID="lblActividad" runat="server"></asp:Label>
                </td>
				<td align="center" style="font-size:14pt">
                    <asp:Label ID="lblProxActividad" runat="server"></asp:Label>
                </td>
			</tr>
			<tr>
				<td colspan="4" align="Left" style="font-size:24pt">
                    <asp:Label ID="lblObs" runat="server"></asp:Label>
                </td>
			</tr>
			<tr>
				<td align="center" style="font-size:14pt; font-weight:bold"> MÁQUINA </td>
				<td align="center" style="font-size:14pt; font-weight:bold"> OPERADOR </td>
				<td align="center" style="font-size:14pt; font-weight:bold"> PESO (KG) </td>
				<td align="center" style="font-size:14pt; font-weight:bold"> CANTIDAD </td>
			</tr>
			<tr>
				<td align="center" style="font-size:24pt">
                    <asp:Label ID="lblMaquina" runat="server"></asp:Label>
                </td>
				<td align="center" style="font-size:24pt">
                    <asp:Label ID="lblOperador" runat="server"></asp:Label>
                </td>
				<td align="center" style="font-size:24pt">
                    <asp:Label ID="lblPeso" runat="server"></asp:Label>
                </td>
				<td align="center" style="font-size:24pt">
                    <asp:Label ID="lblCantidad" runat="server"></asp:Label>
                </td>
			</tr>
			<tr>
				<td align="center" style="font-size:150pt;" colspan="4">
                    <div id="barcodeTarget"></div>
				</td>
			</tr>
			<tr>
				<td align="center" style="font-size:20pt" colspan="4">
                    <asp:Label ID="lblIdPallet" runat="server"></asp:Label>
                </td>
			</tr>
			<tr>
				<td align="left" style="font-size:9pt" colspan="3">  &nbsp;Metrics WIP - Intranet -
                    <asp:Label ID="lblFechaImpresion" runat="server"></asp:Label>
&nbsp;</td>
				<td align="right" style="font-size:9pt" >  1ª impresión </td>
			</tr>
		</table>
    </form>
</body>
</html>
