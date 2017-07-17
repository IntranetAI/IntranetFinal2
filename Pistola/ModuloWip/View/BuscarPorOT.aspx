<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarPorOT.aspx.cs" Inherits="Intranet.ModuloWip.View.BuscarPorOT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        var controlador = "MantenedordeSesion.ashx";
        function MantenSesion() {
            var head = document.getElementsByTagName('head').item(0);
            script = document.createElement('script');
            script.src = controlador;
            script.setAttribute('type', 'text/javascript');
            script.defer = true;
            head.appendChild(script);

        }
        setInterval("MantenSesion()", 1080000); //1080000
    
    </script>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Panel ID="pnlInicio" runat="server" Width="233px">
        <div align="center">
            <h2 style="color: rgb(23, 130, 239); font-size: 12px; font-weight: bold; width: 229px;">
                Buscar Por OT</h2>
        </div>
                            &nbsp;&nbsp;<asp:Label ID="lblBuscarOT" runat="server" Font-Bold="True" 
            Font-Size="Small" Text="OT :"></asp:Label>
        &nbsp;<asp:TextBox ID="txtCodigo" runat="server" AutoPostBack="True" 
                        ontextchanged="txtCodigo_TextChanged" Width="100px"></asp:TextBox>
    </asp:Panel>

    </div>
    
    <asp:Panel ID="pnlDetalle" runat="server" Width="234px" Visible="False">
       
    </asp:Panel>
    <%--<asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
        Text="Guardar" />--%>
    <asp:Button ID="btnSalir" runat="server" Text="Salir"  Width="69px" 
        onclick="btnSalir_Click" />
    <br />
    <div align ="center" style="width: 233px" id="DivMensaje" runat="server">
        <asp:Image ID="Image1" runat="server" />
    <asp:Label ID="lblMensaje" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label>
    </div>
    <br />
    <div style="visibility:hidden;"><asp:Label ID="lblNombre" runat="server" /></div> 
       <div style="visibility:hidden;"><asp:Label ID="lblTipo" runat="server" /></div> 
    </form>
</body>
</html>
