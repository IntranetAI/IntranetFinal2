<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Intranet.View.ResetPassword" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="MSCaptcha" namespace="MSCaptcha" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link id="Link2" runat="server" rel="icon" href="../images/faviconqg.ico" type="image/ico" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/ConfiguracionPantalla.js" type="text/javascript"></script>
       <title>Intranet A Impresores S.A.</title>

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
               setInterval("MantenSesion()", 1080000);
    
    </script>

</head>
<body style="background-image: url(../../images/fondointento.jpg);">
<br />
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
         </asp:ToolkitScriptManager>
  <div  style="width:92%;height:850px; float:inherit;margin:auto; background:#fff;">
      <table>
        <tr>
            <td style="height:165px;">
                <div>
                    <%--<object type="application/x-shockwave-flash" data="../../images/header.swf" width="1135px" height="190px" title="a Impresores S.A">
                    <param name="movie" value="imag/flash/head.swf" />
                    <param name="bgcolor" value="FFFFFF" />
                    <name="wmode" value="transparent" />
                    </object>--%>
                                        <asp:Image ID="Image1" runat="server" 
                        ImageUrl="~/Images/Logo color lateral.jpg" Width="1095px" />
                </div>
           </td>
        </tr>
    </table>
      <%-- fin imagen flash--%>
  <div style="text-align:center; height: 565px;">
        <asp:Panel ID="pnlRecover" runat="server" Height="454px"> 
          <h2 style="color: rgb(23, 130, 239);font-size: 30px; font-weight: bold;">Recuperación de Clave Secreta</h2>
          <div style="text-align:center; height: 189px;">

              &nbsp;
              <table style="width: 100%;">
                  <tr>
                      <td>
                          <asp:Label ID="lblpaso" runat="server" Font-Bold="True" ForeColor="Gray" 
                              Text="Paso 1:"></asp:Label>
                          &nbsp;
                          <asp:Label ID="lblmsj" runat="server" ForeColor="Gray" 
                              Text="Ingrese su Usuario y Correo."></asp:Label>
                      </td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp; &nbsp;
                          <asp:Label ID="lblUsername" runat="server" Font-Bold="True" ForeColor="Gray" 
                              Text="Usuario:"></asp:Label>
                          &nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="txtUsuario" runat="server" Width="230px"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="lblPIN" runat="server" Font-Bold="True" ForeColor="Gray" 
                              Text="Correo:"></asp:Label>
                          &nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="txtCorreo" runat="server" Width="230px"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblCaptcha" runat="server" ForeColor="Gray" 
                            Text="Código de Seguridad:" Font-Bold="True" Visible="False"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div style="margin-left:530px;">
                        <cc1:CaptchaControl ID="CaptchaControl1"  runat="server" Height="60px" 
                            Width="180px" /></div>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                            ID="lblcodigo" runat="server" ForeColor="Gray" 
                            Text="Ingrese código de Seguridad"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtCaptcha" runat="server" Width="180px"></asp:TextBox>
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td>
                          <asp:Label ID="lblaglo" runat="server"></asp:Label>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      </td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                          <asp:ImageButton ID="ibRecuperar" runat="server" 
                              ImageUrl="~/Images/botonRecuperar.png" onclick="ibRecuperar_Click" />
                          &nbsp;&nbsp; &nbsp;&nbsp;
                          <asp:ImageButton ID="ibSalir" runat="server" ImageUrl="~/Images/botonSalir.png" 
                              onclick="ibSalir_Click" />
                      </td>
                  </tr>
              </table>
                  </asp:Panel>
              <br />   <%--comienzo segundo panel--%>

          </div>
    
  
  
  
  </div>
    <div style="position:inherit;" align="center"> 
        <asp:Label ID="lblFooter" runat="server" Font-Size="Small" ForeColor="#666666" 
        Text="© 2016 A Impresores S.A. Todos los derechos reservados. " ></asp:Label>
    </div>
    <%--fin pie de pagina--%>
    </form>
</body>
</html>
