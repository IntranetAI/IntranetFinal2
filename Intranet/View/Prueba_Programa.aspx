<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba_Programa.aspx.cs" Inherits="Intranet.View.Prueba_Programa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Programa de Producción</title>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    
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
        $(function () {
            $('[id*=lstFruits]').multiselect({
                includeSelectAllOption: true
            });
            $("#Button1").click(function () {
                alert($(".multiselect-selected-text").html());
            });
        });
    </script>
<script type="text/javascript">
    var t = 0;
    retardo = 100;
    function cargando() {
        document.getElementById("sumaHoras").style.width = ++t + "%";
        if (t < 100) setTimeout("cargando()", retardo);
    }
</script>
</head>
   <body ><%--onload="window.print();"--%>
        <form id="form1" runat="server">
        <div>
    

            <%--    <div><span style='float:right'>" + ip.Horas + "</span><b>" + ip.OT + "</b> " + ip.NombreOT + "</div>--%>
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
           <asp:ListBox ID="lstFruits" runat="server" SelectionMode="Multiple">
                <asp:ListItem Text="LITHOMAN" Value="MR408" />
                <asp:ListItem Text="WEB 1" Value="M1016" />
                <asp:ListItem Text="WEB 2" Value="M2016" />
                <asp:ListItem Text="M600" Value="M6001" />
                <asp:ListItem Text="10P" Value="SH102" />
                <asp:ListItem Text="XL" Value="SHXL2" />
                <asp:ListItem Text="KBA" Value="KBA" />
            </asp:ListBox>
       <asp:DropDownList ID="DropDownList1" runat="server">
           <asp:ListItem>1 MES</asp:ListItem>
           <asp:ListItem>2 MESES</asp:ListItem>
           <asp:ListItem>3 MESES</asp:ListItem>
           <asp:ListItem>4 MESES</asp:ListItem>
           <asp:ListItem>5 MESES</asp:ListItem>
           <asp:ListItem>6 MESES</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
 
       <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
   
            
         
   
            
       </div>
        </form>
    </body>
</html>
