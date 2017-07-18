<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Etiqueta.aspx.cs" Inherits="Intranet.ModuloWip.View.Etiqueta" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .divTitulo
        {
            background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
            font-weight: bold;
            padding: 5px;
            border: 1px solid #959595;
            text-align: left;
        }
        .divSeccion
        {
            padding: 10px;
            border: 1px solid #959595;
            border-top: 0px;
            margin-bottom: 2px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function imprSelec(muestra) {
            var ficha = document.getElementById(muestra);
            var ventimp = window.open(' ', 'popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            setTimeout(function () { ventimp.print(); ventimp.close(); }, 500);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <asp:Image ID="Image1" runat="server"  width='1100px' height='400px' />    
    </div>
    <div>
        &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Size="130" Font-Bold="true"></asp:Label></div>
    <%--<div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server"
            Text="Directo Despacho" Font-Size="40" Font-Bold="true"></asp:Label></div>--%>
    <br />
    </form>
</body>
</html>
