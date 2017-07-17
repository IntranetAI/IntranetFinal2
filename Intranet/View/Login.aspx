<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Intranet.View.Login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--   <link type="image/x-icon" rel="Shortcut Icon" href="../images/faviconqg.ico" >
   <link id="Link2" runat="server" rel="icon" href="../images/faviconqg.ico" type="image/ico" />--%>
    <link href="../images/faviconqg.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <%--<script src="../js/ConfiguracionPantalla.js" type="text/javascript"></script>--%>
    <%--    <script src="../js/funciones.js" type="text/javascript"></script>--%>
    <title>Intranet A Impresores S.A.</title>
    <style type="text/css">
        
    </style>
    <script language="javascript" type="text/javascript">
        function tamaño() {
            var ancho = eval(window.innerWidth);
            var largo = eval(window.innerHeight);
            document.getElementById("PantallaCompleta").style.width = ancho;
            document.getElementById("PantallaCompleta").style.height = window.outerHeight;
            document.getElementById("divcental").style.width = "99.9%";
            document.getElementById("divcental").style.height = ((window.outerHeight - 100) * 0.98) + "px";
        }
        function CambiodeAlturascreen() {
            var h = window.outerHeight;
            document.getElementById("divcental").style.height = ((h - 100) * 0.98) + "px"
        }

        var controlador = "MantenedordeSesion.ashx";
        function MantenSesion() {
            var head = document.getElementsByTagName('head').item(0);
            script = document.createElement('script');
            script.src = controlador;
            script.setAttribute('type', 'text/javascript');
            script.defer = true;
            head.appendChild(script);

        }
        setInterval("MantenSesion()", 1080000);
    
    </script>
</head>
<body style="background-image: url(../../images/fondointento.jpg);" onresize="CambiodeAlturascreen()">
    <div id="PantallaCompleta" class="total">
        <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div id="divcental" style="background: #fff;">
            <table>
                <tr>
                    <td colspan="4">
                        <div align="center">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Logo color lateral.jpg"
                                Width="90%" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <h2 style="color: rgb(23, 130, 239); font-size: 30px; font-weight: bold;">
                            Intranet</h2>
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" ForeColor="Gray"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" Style="margin-bottom: 0px" Width="180px"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblpass" runat="server" Text="Clave:" ForeColor="Gray"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblPin" runat="server" Text=" PIN:" ForeColor="Gray"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPIN" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="ibIngresar" runat="server" ImageUrl="~/Images/botonLogin.PNG"
                            OnClick="ibIngresar_Click" />
                    </td>
                    <td>
                    </td>
                </tr>
                
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblpts" runat="server" ForeColor="Gray" Text="..............................................................................................."></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align:right;">
                        <asp:Label ID="Label1" runat="server" ForeColor="Gray" Text="»"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbOlvidoPass" runat="server" ForeColor="Gray" PostBackUrl="~/View/ResetPassword.aspx">Olvidó su Clave Secreta</asp:LinkButton>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align:right;">
                        <asp:Label ID="Label2" runat="server" ForeColor="Gray" Text="»"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="lkRegistro" runat="server" ForeColor="Gray" PostBackUrl="~/View/Registro.aspx">Registrate</asp:LinkButton>
                    </td>
                    <td></td>
                </tr>
            </table>
            
            <div style="position: fixed; bottom: 0; z-index: 999999; width: 100%" align="center">
                <asp:Label ID="Label3" runat="server" Font-Size="Small" ForeColor="#666666" Text="© 2016 A Impresores S.A. Todos los derechos reservados. "></asp:Label>
            </div>
            <%--fin pie de pagina--%>
        </div>
        </form>
    </div>
</body>
</html>
