<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleOTComercial.aspx.cs" Inherits="Intranet.ModuloDespacho.View.DetalleOTComercial" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            margin-left: 40px;
        }
        .style2
        {
        }
        .style3
        {
            width: 230px;
            margin-left: 40px;
        }
        .style4
        {
        }
        .style5
        {
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ToolkitScriptManager>
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Envio Material OT Comercial" 
            Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        
        <br />
        <br />
        
    </div>
    <div align="center">
        <table style="width:700px;" border="1px">
            <tr>
                <td class="style3">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo color lateral.jpg" 
                        Height="50px" Width="172px" />
                </td>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="OT:" 
                        Font-Bold="True"></asp:Label>
&nbsp;&nbsp;<asp:Label ID="lblOT" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label6" runat="server" Text="Producto:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="lblProducto" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Tiraje OT:" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lblTirajeOT" runat="server" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label8" runat="server" Text="Cantidad Enviada:" 
                        Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblCantidad" runat="server" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Large" 
                        Text="Peso:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblPeso" runat="server" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label10" runat="server" Text="Observación:" Font-Bold="True" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblObservacion" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    &nbsp;<div align="center" >
    <br />
        <asp:Image ID="imgCodigo" runat="server" />
 <br />
        <asp:Label ID="lblFolio" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <asp:Label ID="lblCreadaPor" runat="server"></asp:Label>
         </div>  


          
   
    

    </form>
</body>
</html>
