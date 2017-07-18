<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirMensajes.aspx.cs" Inherits="Intranet.ModuloUsuario.View.ImprimirMensajes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="../../js/jquery.min.js" type="text/javascript"></script>

 <style>
.mailRevisido {
	font-family: "Trebuchet MS", "Helvetica", "Arial",  "Verdana", "sans-serif";
font-size: 75%;
}
.ui-accordion .ui-accordion-header {
	display: block;
	cursor: pointer;
	position: relative;
	margin-top: 2px;
	padding: .5em .5em .5em .7em;
	min-height: 0; /* support: IE7 */
}
/*Estilo para las letra tanto el tamaño como estilo de ellas*/
.ui-helper-reset {
	margin: 0;
	padding: 0;
	border: 0;
	outline: 0;
	line-height: 1.3;
	text-decoration: none;
	font-size: 100%;
	list-style: none;
    
}
/*Estilo de aparesca plomo del titulo  en un cuadrado*/
.ui-state-default,
.ui-widget-content .ui-state-default,
.ui-widget-header .ui-state-default {
	border: 1px solid #d3d3d3;
	background: #e6e6e6 url(images/ui-bg_glass_75_e6e6e6_1x400.png) 50% 50% repeat-x;
	font-weight: normal;
	color: #555555;
}
.ui-state-hover,
.ui-widget-content .ui-state-hover,
.ui-widget-header .ui-state-hover,
.ui-state-focus,
.ui-widget-content .ui-state-focus,
.ui-widget-header .ui-state-focus {
	border: 1px solid #999999;
	background: #dadada url(images/ui-bg_glass_75_dadada_1x400.png) 50% 50% repeat-x;
	font-weight: normal;
	color: #212121;
}
.ui-accordion .ui-accordion-icons {
	padding-left: 2.2em;
}
/*Estilo de aparesca blanco del titulo  en un cuadrado*/
.ui-state-active,
.ui-widget-content .ui-state-active,
.ui-widget-header .ui-state-active {
	border: 10px solid #aaaaaa;
	background: #ffffff url(images/ui-bg_glass_65_ffffff_1x400.png) 50% 50% repeat-x;
	font-weight: normal;
	color: #212121;
}

/*Borde de la tabla*/
.ui-corner-all,
.ui-corner-top,
.ui-corner-left,
.ui-corner-tl {
	border-top-left-radius: 4px;
}
.ui-corner-all,
.ui-corner-top,
.ui-corner-right,
.ui-corner-tr {
	border-top-right-radius: 4px;
}
.ui-corner-all,
.ui-corner-bottom,
.ui-corner-left,
.ui-corner-bl {
	border-bottom-left-radius: 4px;
}
.ui-corner-all,
.ui-corner-bottom,
.ui-corner-right,
.ui-corner-br {
	border-bottom-right-radius: 4px;
}
/*Contenido*/
.ui-accordion .ui-accordion-content {
	padding: 1em 2.2em;
	border-top: 0;
	overflow: auto;
}
/*Eliminar el border mayor del mensaje*/
.ui-helper-reset {
	margin: 0;
	padding: 0;
	border: 0;
	outline: 0;
	line-height: 1.3;
	text-decoration: none;
	font-size: 100%;
	list-style: none;
}
/*borde cuadrado del mensaje*/
.ui-widget-content {
	border: 1px solid #aaaaaa;
	color: #222222;
}
/*BOrde de contenido */
.ui-tabs .ui-tabs-panel {
	display: block;
	border-width: 0;
	padding: 1em 1.4em;
	background: none;
}

</style>
</head>
<body onload="window.print();"><%--onload="window.print();"--%>
    <form id="form1" runat="server">
    <div style="text-align:center;">
     <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>

    </div>
   
    <br />
    <br />
    <br />


    <asp:Label ID="lblCargaMensaje" runat="server"></asp:Label>


    </form>
</body>
</html>
