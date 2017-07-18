<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioClave.aspx.cs" Inherits="Intranet.View.CambioClave" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="MSCaptcha" namespace="MSCaptcha" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/ConfiguracionPantalla.js" type="text/javascript"></script>
    <link id="Link2" runat="server" rel="icon" href="../images/faviconqg.ico" type="image/ico" />
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
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager runat="server">
    </asp:ToolkitScriptManager>
 <div  style="width:92%;height:697px; float:inherit;margin:auto; background:#fff;">
       <table>
        <tr>
            <td style="height:165px;">
                <div>
                    <object type="application/x-shockwave-flash" data="../../images/header.swf" width="1135px" height="190px" title="a Impresores S.A">
                    <param name="movie" value="imag/flash/head.swf" />
                    <param name="bgcolor" value="FFFFFF" />
                    <name="wmode" value="transparent" />
                    </object>
                </div>
           </td>
        </tr>
    </table>
       <%--         --%>




      <div style="text-align:center; height: 565px;">
         <asp:Panel ID="pnlRecover" runat="server" Height="454px"> 
          <h2 style="color: rgb(23, 130, 239);font-size: 30px; font-weight: bold;">Cambio de Clave Secreta  </h2>  
              <table style="width:100%;">
                  <tr>
                      <td>
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Gray" 
                              Text="Clave:"></asp:Label>
                          &nbsp;
                          <asp:TextBox ID="txtClave" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td>
                          <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Gray" 
                              Text="Reingrese Clave:"></asp:Label>
                          &nbsp;
                          <asp:TextBox ID="txtClave2" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      </td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:ImageButton ID="ibCambiarClave" runat="server" 
                              ImageUrl="~/Images/botonCambiarPassword.png" onclick="ibCambiarClave_Click" />
                          &nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:ImageButton ID="ibSalir" runat="server" 
                              ImageUrl="~/Images/botonSalir.png" />
                      </td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      </td>
                  </tr>
              </table>
            

        


          </asp:Panel>
              <br />   <%--comienzo segundo panel--%>

          </div>
    
    </div>
    </form>
</body>
</html>
