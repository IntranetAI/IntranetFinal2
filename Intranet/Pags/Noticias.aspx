<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="Intranet.Pags.Noticias" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/ConfiguracionPantalla.js" type="text/javascript"></script>
     <link id="Link2" runat="server" rel="icon" href="../images/faviconqg.ico" type="image/ico" />
       <title>Intranet A Impresores S.A.</title>
        <link href="../css/menuysubmenu.css" rel="stylesheet" type="text/css" />
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
    <div  style="width:92%;height:866px; float:inherit;margin:auto; background:#fff;">
    
    <%--inicio tabla menu y banner--%>
        <table>
        <tr>
            <td style="height:165px;">
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
    <div>
       <br />
 <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Noticias.PNG" Width="877px" />
    </div>
    </div>
    </form>
    </div>
</body>
</html>
