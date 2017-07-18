<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Intranet.View.Model.Registro" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="MSCaptcha" namespace="MSCaptcha" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../js/funciones.js" type="text/javascript"></script>
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
           <h2 style="color: rgb(23, 130, 239);font-size: 30px; font-weight: bold;">&nbsp;&nbsp;&nbsp;&nbsp; Creación de Cuentas</h2>
       
            <asp:Panel ID="pnlRut" runat="server" Height="99px">
          
            <%--  inicio contenido--%>

     <div style="text-align:center;">
     
     
         <table style="width:100%; height: 91px;">
             <tr>
                 <td>
                     <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Gray" 
                         Text="Paso 1:"></asp:Label>
                     <asp:Label ID="Label8" runat="server" ForeColor="Gray" 
                         Text="Ingrese Rut para la Creación de su Cuenta."></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lblRut" runat="server" Visible="False"></asp:Label>
                     <asp:Label ID="lblNombre" runat="server" Visible="False"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                     <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="Gray" 
                         Text="Rut:"></asp:Label>
&nbsp;
                     <asp:TextBox ID="txtRut" runat="server" MaxLength="8"></asp:TextBox>
                     -<asp:TextBox ID="txtDV" runat="server" Width="20px" MaxLength="1"></asp:TextBox>
                     &nbsp;&nbsp;
                     <asp:ImageButton ID="ibValidar" runat="server" 
                         ImageUrl="~/Images/botonVerificar.png" onclick="ibValidar_Click" Width="90px" />
                     &nbsp;</td>
             </tr>
             </table>
     
     
     </div>

      </asp:Panel>

     
           <%--fin contenido--%>
       
       
           <asp:Panel ID="pnlRespuesta" runat="server" Visible="False">
               <table style="width:100%;">
                   <tr>
                       <td>
                           <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="Paso 2:"></asp:Label>
                           <asp:Label ID="Label14" runat="server" ForeColor="Gray" 
                               Text="Ingrese Campos Correspondientes para la Creación de su Cuenta."></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="Nombre:" class="label"></asp:Label>
                           &nbsp;
                           <asp:TextBox ID="TextBox2" runat="server" Width="220px" Enabled="False"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="Rut:"></asp:Label>
                           &nbsp;
                           <asp:TextBox ID="txtRutCompleto" runat="server" Width="220px" Enabled="False"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="Cargo: "></asp:Label>
                           &nbsp;&nbsp;<asp:TextBox ID="txtCargo" runat="server" Enabled="False" Width="220px"></asp:TextBox>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="Área: "></asp:Label>
                           &nbsp;
                           <asp:TextBox ID="txtCentroCosto" runat="server" Enabled="False" Width="220px"></asp:TextBox>
                           &nbsp;&nbsp;&nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                           <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="Usuario:"></asp:Label>
                           &nbsp;
                           <asp:TextBox ID="txtUsername" runat="server" MaxLength="25" Width="220px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                           <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="Clave:"></asp:Label>
                           &nbsp;
                           <asp:TextBox ID="txtPass" runat="server" MaxLength="50" TextMode="Password" 
                               Width="220px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;
                           <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="Reingrese Clave:"></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="txtPass2" runat="server" MaxLength="50" TextMode="Password" 
                               Width="220px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="PIN:"></asp:Label>
                           &nbsp;
                           <asp:TextBox ID="txtPin" runat="server" MaxLength="4" TextMode="Password" 
                               Width="220px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp; &nbsp;
                           <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Gray" 
                               Text="Reingrese PIN:"></asp:Label>
                           &nbsp;
                           <asp:TextBox ID="txtPin2" runat="server" MaxLength="4" Width="220px" 
                               TextMode="Password"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Gray" 
                         Text="Correo:"></asp:Label>
                                                &nbsp;
                        <asp:TextBox ID="txtCorreo" runat="server" Width="220px" MaxLength="100"></asp:TextBox>
                        </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <div style="margin-left: 545px;">
                               <cc1:CaptchaControl ID="CaptchaControl1" runat="server" Height="60px" 
                                   Width="180px" />
                           </div>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblcodigo" runat="server" ForeColor="Gray" 
                               Text="Ingrese código de Seguridad"></asp:Label>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> 
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:TextBox ID="txtCaptcha" runat="server" MaxLength="10" Width="180px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:ImageButton ID="ibCrearCuenta" runat="server" 
                               ImageUrl="~/Images/botonCrearCuenta.png" onclick="ibCrearCuenta_Click" />
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:ImageButton ID="ibSalir" runat="server" ImageUrl="~/Images/botonSalir.png" 
                               PostBackUrl="~/View/Login.aspx" />
                       </td>
                   </tr>
               </table>

           </asp:Panel>
       
       
       </div>


    </div>
       <%--inicio pie de pagina--%>
       <br />
    <div style="position:inherit;" align="center"> 
        <asp:Label ID="lblFooter" runat="server" Font-Size="Small" ForeColor="#666666" 
        Text="© 2016 A Impresores S.A. Todos los derechos reservados. " ></asp:Label>
    </div>
       <%--fin pie de pagina--%>
    </form>
</body>
</html>
