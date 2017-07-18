<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="Intranet.Pags.Nosotros" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/ConfiguracionPantalla.js" type="text/javascript"></script>
  <link id="Link2" runat="server" rel="icon" href="../images/faviconqg.ico" type="image/ico" />
  <link href="../css/menuysubmenu.css" rel="stylesheet" type="text/css" />
    <link href="../css/menuAcordion.css" rel="stylesheet" type="text/css" />
  <title>Intranet A Impresores S.A.</title>
  <style type="text/css">
    .nada
    {
        background-image: url(../../images/fondointento.jpg);
    } 
    .total {
    border: 0px dashed maroon;
    margin: auto;
    width: 1200px;
} 
</style>
      <script language="javascript" type="text/javascript">

          var controlador = "../View/MantenedordeSesion.ashx";
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
<div class="total">
 <br />
    <form id="form1" runat="server">
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
         </asp:ToolkitScriptManager>

          <%--   inicio nombreusuario y cerrar session--%>
    <div style="margin-top:-20px;margin-left:600px;">
        <asp:Label ID="lblNombreUsuario" runat="server" ForeColor="White" 
            Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lkCerrarSesion" runat="server" 
            onclick="lkCerrarSesion_Click">Cerrar Sesión</asp:LinkButton>
     </div>
     <%--fin user y cs--%>
    <div  style="width:92%;height:866px; float:inherit;margin:auto; background:#fff;">

    <%--inicio tabla menu y banner--%>
        <table>
        <tr>
            <td style="height:120px;">
                <div>
                    <object type="application/x-shockwave-flash" data="../../images/head.swf" width="1095px" height="190px" title="World Color">
                    <param name="movie" value="imag/flash/head.swf" />
                    <param name="bgcolor" value="FFFFFF" />
                    <name="wmode" value="transparent" />
                    </object>
                </div>
           </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <div id="navegacion" style="margin-left:-35px;margin-top:-15px;" ><%--style="margin-top:-50px;"--%>
                <ul>
                    <li><a href="../View/Pagina_Inicio.aspx" class="b-hover">Inicio</a></li>
                    <li><a href="Nosotros.aspx" >Nosotros</a></li>
                      <li><a href="Noticias.aspx" >Noticias</a></li>
                    <li><a href="#" >Comercial</a></li>
                    <li><a href="../ModuloProduccion/view/Suscripcion.aspx?id=1">Produccion</a></li>
                    <li><a href="#" >Administracion</a></li>
                    <li><a href="#">Seguridad y salud</a></li>
                    <li><a href="#" >RRHH</a></li>
                     <li><a href="#">LEAN</a></li>
                    <li><a href="#">Link de interes</a></li>
                   <%-- <li><a href="#">&nbsp;&nbsp;&nbsp;</a></li>--%>
                </ul>
                </div> 
            </td>
       </tr>
    </table>
    <%--fin tabla menu y banner--%>
        <%--separacion entre menu y noticias--%>

       <div style="width:200px;float:left;margin-top:-15px;">
               <div id="submenu" >
                    <h2 style="width:150px;margin-left:25px;">A Impresores</h2>
                    <%--<uc1:submenu  ID="submenu1" runat="server"/>--%>
                  <%--  <uc1:menulateral  ID="menulateral" runat="server"/>--%>

  <ul>
    <li><a href="Historia.aspx">Historia</a></li>
    <li><a href="MisionyVision.aspx">Mision-Vision-Valores</a></li>
    <li><a href="#">Nuestros Socios</a></li>
    <li><a href="Clientes.aspx">Clientes</a>
  </ul>

               </div>
        
       </div>
        <div style="width:800px;padding-left:250px;">
        <h3 style="color:#0078AD;">
            <asp:Label ID="Label9" runat="server" Font-Size="X-Large" Text="Nosotros"></asp:Label>
            </h3>
            
        
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/tickAzul.PNG" />


        &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Gray" 
                Text="QUÉ SIGNIFICA SER FUNCIONARIO DE A IMPRESORES S.A."></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" ForeColor="#4C4C4C" 
                Text="Los funcionarios de nuestra Compañía son el factor más importante, por lo cual son respetados por el valor que agregan a nuestros productos y servicios, brindándoles oportunidades apropiadas y equitativas para su desarrollo, crecimiento, retribución y logros profesionales y personales al interior de la Organización."></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#4C4C4C" 
                Text="&quot;Trabajo en Equipo&quot;... esa es la clave"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Font-Italic="True" ForeColor="#4C4C4C" 
                Text="“Algunas de las principales razones del éxito logrado han sido nuestro compromiso con el servicio al cliente así como la capacidad para producir en tiempo y forma un producto de alta calidad. Para tal efecto, aplicamos una política orientada al Trabajo en Equipo, donde las personas son el pilar de una estructura tecnológica de última generación."></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" ForeColor="#4C4C4C" 
                Text="Hoy como A Impresores S.A. reafirmamos este sentir, ya que la base de un buen negocio es el óptimo desarrollo de las relaciones interpersonales: trabajador - empresa - cliente - consumidor.”"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#4C4C4C" 
                Text="CARLOS HERNAN AGUIRRE VARGAS "></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" ForeColor="#4C4C4C" 
                Text="Gerente General"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" ForeColor="#4C4C4C" 
                Text="A Impresores S.A."></asp:Label>


        </div>

        </div>
    </form>
    </div>
</body>
</html>
