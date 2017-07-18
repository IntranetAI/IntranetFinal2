<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MensajesNoLeidos.aspx.cs" Inherits="Intranet.ModuloProduccion.View.MensajesNoLeidos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Imprimir Mensajes</title>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
           <style type="text/css">
.mailRevisido {
	font-family: "Trebuchet MS", "Helvetica", "Arial",  "Verdana", "sans-serif";
font-size: 90%;
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

<style type="text/css">
.divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    font-weight: bold;
    padding: 5px;
    border: 1px solid #959595;
    text-align: left;
}
.divSeccion{
    padding: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
}
    .style4
    {
        width: 159px;
    }
    .style8
    {
        width: 114px;
    }
    .style10
    {
        width: 112px;
    }
    .style13
    {
        width: 161px;
    }
    .style15
    {
    }
    .style17
    {
        width: 158px;
    }
    .style18
    {
        width: 102px;
    }
    .style19
    {
        width: 145px;
    }
</style>



</head>
<body onload="window.print();">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
