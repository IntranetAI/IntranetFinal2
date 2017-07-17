<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirPrograma.aspx.cs" Inherits="Intranet.ModuloProduccion.View.ImprimirPrograma" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Programa de Producción</title>
<style>
table {
    border-collapse: collapse;
    font-family: "Arial", serif; 
    font-size: 10px;
    font-size-adjust: 0.5; 
    
}

 td, th {
    border: 1px solid black;
}
</style>
<script type="text/javascript">
    var t = 0;
    retardo = 100;
    function cargando() {
        document.getElementById("sumaHoras").style.width = ++t + "%";
        if (t < 100) setTimeout("cargando()", retardo);
    }
</script>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
    <div>
    

        <%--    <div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>--%>
   
    
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

   </div>
    </form>
    </body>
</html>
