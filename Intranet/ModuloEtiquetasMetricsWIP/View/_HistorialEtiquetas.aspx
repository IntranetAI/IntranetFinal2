<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_HistorialEtiquetas.aspx.cs" Inherits="Intranet.ModuloEtiquetasMetricsWIP.View._HistorialEtiquetas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Historial Etiquetas</title>
        <script  type="text/javascript" language="javascript">
               function HistorialEtiquetas(id) {

                   window.open('_Etiqueta.aspx?id=' + id, 'Etiqueta', 'left=45,top=90,width=1170 ,height=840,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');

           }
        
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" style="font-size: 30px;">
           <b> <asp:Label ID="lblOT" runat="server" Text="Label"></asp:Label> - <asp:Label ID="lblNombreOT" runat="server" Text="Label"></asp:Label></b>
            <br />
            <asp:Label ID="lblPliego" runat="server" Text="Label"></asp:Label>
        </div>
    <div>
        <asp:Label ID="lblTabla" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
