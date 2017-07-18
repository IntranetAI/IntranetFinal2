<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina_Inicio.aspx.cs" Inherits="Intranet.View.Pagina_Inicio" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/ConfiguracionPantalla.js" type="text/javascript"></script>
   <link id="Link2" runat="server" rel="icon" href="../images/faviconqg.ico" type="image/ico" />
   <link REL="SHORTCUT ICON" HREF="../images/faviconqg.ico">
    <title>A Impresores S.A.</title>
             <style type="text/css">
    .total {
    border: 0px dashed maroon;
    margin: auto;
    width: 1200px;
} 
</style>

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
            setInterval("MantenSesion()", 10000); //1080000
    
        </script>




    <link href="../css/menuysubmenu.css" rel="stylesheet" type="text/css" />
    </head>
<body style="background-image: url(../images/fondointento.jpg);">
<div class="total">
<br />
   <form id="form1" runat="server">
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
     </asp:ToolkitScriptManager>

    <%--   inicio nombreusuario y cerrar session--%>
    <div style="margin-top:-20px;margin-left:450px;">
    <div style="margin-top:-20px;margin-bottom:-5px;width:700px;text-align:right;">
            <asp:Label ID="lblNombreUsuario" runat="server" ForeColor="White" Font-Bold="True"></asp:Label>
            &nbsp;
            
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
</div>
         <div style="margin-top:-25px;margin-bottom:-5px;margin-left:570px; border-radius:45px 15px 5px 15px;border:1px solid #4B66AD;
                      width:130px;-webkit-box-shadow: -5px -5px 10px #2C2D36;">
                  &nbsp;&nbsp;&nbsp;  
                 
            <a href="../ModuloJefatura/View/adminUsuarios.aspx" title="Administrar Jefatura">
                      <asp:Image ID="Image1" 
            runat="server" Height="25px" ImageUrl="~/Images/admin-jefatura.png" 
            Width="25px" /></a>
              &nbsp;&nbsp;<a  href="../ModuloUsuario/View/Mensajeria.aspx" title="Mensajeria"><asp:Image ID="imgMensajeria" runat="server" Height="25px" 
            ImageUrl="~/Images/mensajeria.png" Width="25px" /></a> 
             &nbsp;&nbsp;
             <a title="Cerrar Sesión">
                  <%--                 <asp:Image ID="Image2" runat="server" Height="25px" Width="25px" ImageUrl="~/Images/CerrarSession.png" />--%>
                  <asp:ImageButton ID="ibCerrarSesion" runat="server" Height="23px" 
                      ImageUrl="~/Images/CerrarSession.png" onclick="ibCerrarSesion_Click" 
                      Width="23px" />
                 
             </a>
        </div>
     </div>
     <%--fin user y cs--%>
    <div  style="width:92%;height:90%; float:inherit;margin:auto; background:#fff;">

    <table>
        <tr>
            <td style="height:165px;">
                <div>
                    <object type="application/x-shockwave-flash" data="../../images/head.swf" width="1095px" height="190px" title="a Impresores S.A">
                    <param name="movie" value="imag/flash/head.swf" />
                    <param name="bgcolor" value="FFFFFF" />
                    <name="wmode" value="transparent" />
                    </object>
                </div>
           </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <div id="navegacion" style="margin-left:-35px;margin-top:-20px;" ><%--style="margin-top:-50px;"--%>
                <ul>
                    <li><a href="#" class="b-hover">Inicio</a></li>
                    <li><a href="../pags/Nosotros.aspx" >Nosotros</a></li>
                    <li><a href="../pags/Noticias.aspx" >Noticias</a></li>
                    <li><a href="../ModuloComercial/view/modulocomercial.aspx?id=3" >Comercial</a></li>
                    <li><a href="../ModuloProduccion/view/Suscripcion.aspx?id=1">Produccion</a></li>
                    <li><a href="../ModuloAdmin/view/Administracion.aspx?id=2" >Administracion</a></li>
                    <li><a href="#">Seguridad y salud</a></li>
                    <li><a href="#" >RRHH</a></li>
                    <li><a href="#">LEAN</a></li>
                    <li><a href="#">Link de interes</a></li>
                        <%--    <li><a href="#">&nbsp;&nbsp;&nbsp;</a></li>--%>
                </ul>
                </div> 
            </td>
       </tr>
    </table>
        <%--separacion entre menu y noticias--%>
        <br />
        <br />
        <div style="text-align:center;height:200px;">
        Noticias
        <br />
        <br />
        <br />
        <br />
        
        </div>

       
</div>

<%-- div todo contenido--%>
      <div style="position:inherit;" align="center"> <asp:Label ID="lblFooter" runat="server" Font-Size="Small" ForeColor="#666666" 
                        Text="© 2016 A Impresores S.A. Todos los derechos reservados. " ></asp:Label>
                        </div>
</form>
</div> 
</body>
</html>
