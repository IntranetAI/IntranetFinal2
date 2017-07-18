<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleOT.aspx.cs" Inherits="Intranet.ModuloProyectos.View.DetalleOT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <script src="../../js/jquery.min.js" type="text/javascript"></script>
        <script type="text/javascript">
             function newRespuesta(id) {
                 location.href = '../../ModuloUsuario/view/RedactarRespuesta.aspx?id=' + id;
             };
           
</script>

<%--<script type="text/javascript">

    function contar() {
        var elementos = document.getElementsByName("checkintento");
        texto = "";
        var contador = 0;
        for (x = 0; x < elementos.length; x++) {
            texto = texto + elementos[x].checked + "-" + elementos[x].value + ".";
            PageMethods.NoLeido(elementos[x].checked, elementos[x].value, '<%= Session["Usuario"]%>');
        }
        alert('Mensaje(s) Marcado(s) como Leido Correctamente');
        window.location.href = 'Gestion.aspx?id=1'
    }

</script>--%>
 <style type="text/css">

        .Grilla
        {
          
            margin-bottom: 5px;
            
        }
            </style>
                <style type="text/css">
.mailRevisido {
	font-family: "Trebuchet MS", "Helvetica", "Arial",  "Verdana", "sans-serif";
font-size: 86%;
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

                    .style6
                    {
                        width: 154px;
                    }
                    .style7
                    {
                        width: 279px;
                    }

                </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="True"></asp:ToolkitScriptManager>
    <br />
  
         <div style='text-align:center;font-weight:bold;'>
              <asp:Label ID="lblnombreot" runat="server" Font-Size="X-Large"></asp:Label>
              <br />
           
            </div>   <br />
                <asp:Panel ID="Panel1" runat="server" Height="610px" Width="940px" Visible="true">
                  
                       
                      
                  
                    <asp:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" 
                        Height="600px" Width="949px">
                        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Mensajeria">
                        <HeaderTemplate>Mensajeria</HeaderTemplate>
                        <ContentTemplate><br />
                        <div style="text-align:right;">
                                <a title="Marcar Mensaje Leido" onclick="contar();">
                                
                                  <asp:Image ID="Image2" ImageUrl="~/Images/mensaje-leido.png" Width="25px"    runat="server" />  Marcar Leido
                                </a>

                                  &nbsp;   &nbsp; 
                                <a title="Crear Nuevo Mensaje"><asp:ImageButton ID="ibCrearMensaje" runat="server" 
                                    ImageUrl="~/Images/write-message.png" Width="25px" 
                                        onclick="ibCrearMensaje_Click" />&nbsp;Crear Mensaje
                                </a>
                                &nbsp; 
                                  
                                    <a title="Imprimir Mensajes" id="imprimirmensaje" runat="server">
                                       <asp:Image ID="Image4" runat="server"   
                                        ImageUrl="~/Images/print-message.jpg" Width="25px"/>&nbsp;Imprimir
                                    </a>&nbsp;&nbsp;<a title="Orden Ascendiente">
                                    <asp:ImageButton ID="ibAsc" runat="server" ImageUrl="~/Images/orden-asc.png" 
                                        Width="25px" onclick="ibAsc_Click" />
                                    </a><a title="Orden Descendiente">
                                    <asp:ImageButton ID="ibDesc" runat="server" ImageUrl="~/Images/orden-desc.png" 
                                        Width="25px" onclick="ibDesc_Click" /> &nbsp;Ordenamiento
                                    </a>
                                    </div>
                        <asp:Label   ID="lblMensajeria" runat="server"> </asp:Label>
                        </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Fecha de Entrega">
                        <HeaderTemplate>Fecha de Entrega</HeaderTemplate>
                        <ContentTemplate>
                        <telerik:RadGrid ID="RadGrid4" runat="server" Skin="Outlook">
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                                            <NoRecordsTemplate>
                                                <div style="text-align:center;">
                                                    <br />
                                                    ¡ No se han encontrado registros !<br /></div>
                                            </NoRecordsTemplate>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                 <%--                               <telerik:GridBoundColumn DataField="IDProduccion" HeaderText="IDProduccion" Visible="false" SortExpression="IDProduccion" UniqueName="IDProduccion">
                                                </telerik:GridBoundColumn>--%>
     
                                                <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" ItemStyle-Width="30px" ReadOnly="True" SortExpression="OT" 
                                                    UniqueName="OT">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" ItemStyle-Width="300px" SortExpression="NombreOT" UniqueName="NombreOT">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Cant" HeaderText="Cant. a Despachar" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" 
                                                    UniqueName="Cant">
                                            </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="FechaDes" HeaderText="Fecha Entrega" ItemStyle-Width="150px" SortExpression="FechaDes" UniqueName="FechaDes"  DataFormatString="{0:dd/MM/yyyy HH:mm}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Despachado" HeaderText="% Entrega" ItemStyle-Width="300px" UniqueName="Despachado">
                                                </telerik:GridBoundColumn>
                            
                            
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                        </ClientSettings>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                                            EnableImageSprites="True">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                        </ContentTemplate>
                        </asp:TabPanel>
                                    <asp:TabPanel ID="TabPanel4" runat="server">
                <HeaderTemplate>
                    Pliegos Impresos
                </HeaderTemplate>
                <ContentTemplate>
                    <div style="height: 590px; width: 98%; overflow: auto;">
                    <telerik:RadGrid ID="RadGrid22" runat="server" Skin="Outlook">
                        <PagerStyle Mode="NumericPages" />
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Nombre">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="Nombre" HeaderText="Maquina" ItemStyle-Width="80px"
                                    SortExpression="Nombre" UniqueName="Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Proceso" ItemStyle-Width="180px"
                                    SortExpression="Description" UniqueName="Description">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" ItemStyle-Width="30px"
                                    SortExpression="Pliego" UniqueName="Pliego">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CantSolicitada" HeaderText="CantSolicitada" ItemStyle-Width="40px"
                                    UniqueName="CantSolicitada">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CantProducida" HeaderText="CantProducida" ItemStyle-Width="40px"
                                    SortExpression="CantProducida" UniqueName="CantProducida">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="HoraInicio" HeaderText="HoraInicio" ItemStyle-Width="130px"
                                    SortExpression="HoraInicio" UniqueName="HoraInicio">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="HoraFin" HeaderText="HoraFin" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="130px" UniqueName="HoraFin">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel6" runat="server">
                        <HeaderTemplate>Historial Despacho</HeaderTemplate>
                        <ContentTemplate>
                        <telerik:RadGrid ID="RadGrid5" runat="server" Skin="Outlook">
                                        <PagerStyle Mode="NumericPages" />
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                                            <NoRecordsTemplate>
                                                <div style="text-align:center;">
                                                    <br />
                                                    ¡ No se han encontrado  !<br /></div>
                                            </NoRecordsTemplate>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <%--<telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" 
                                                    ItemStyle-Width="30px" ReadOnly="True" SortExpression="OT" 
                                                    UniqueName="OT">
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" 
                                                    ItemStyle-Width="40px" SortExpression="Folio" UniqueName="Folio">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaImpresion" HeaderText="Fecha Impresion" ItemStyle-Width="100px" SortExpression="FechaImpresion" UniqueName="FechaImpresion"  DataFormatString="{0:dd/MM/yyyy HH:mm}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Destinatario" HeaderText="Destinatario" 
                                                    ItemStyle-Width="250px" UniqueName="Destinatario">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Sucursal" HeaderText="Sucursal" ItemStyle-Width="360px" SortExpression="Sucursal" UniqueName="Sucursal">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Comuna" HeaderText="Comuna" ItemStyle-Width="90px" SortExpression="Comuna" UniqueName="Comuna">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Despachado" HeaderText="Cant." 
                                                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="40px" 
                                                    UniqueName="Despachado">
                                                </telerik:GridBoundColumn>
                                                
                                                
                                                <%--<telerik:GridTemplateColumn>
                                                    <HeaderTemplate>
                                                        Seleccionar Todas
                                                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" 
              runat="server" type="checkbox" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn--%>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                        </ClientSettings>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                                            EnableImageSprites="True">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                        
                        </ContentTemplate>
                        </asp:TabPanel>

                      <asp:TabPanel ID="TabPanel2" runat="server">
                        <HeaderTemplate>Estado OT</HeaderTemplate>
                        <ContentTemplate>

                        
                            <br />
                            <div align="center">
                                <asp:Label ID="Label1" runat="server" Text="Estado Actual" Font-Bold="True" 
                                    Font-Size="Large"></asp:Label></div>
                                    <br />
                            <table style="width:100%;">
                                <tr>
                                    <td class="style7">
                                        &nbsp;</td>
                                    <td class="style6">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Cliente: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCliente" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        &nbsp;</td>
                                    <td class="style6">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Tiraje OT:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTirajeOT" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        &nbsp;</td>
                                    <td class="style6">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Estado:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEstadoActual" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        &nbsp;</td>
                                    <td class="style6">
                                        <asp:Label ID="Label9" runat="server" Font-Bold="True" 
                                            Text="Fecha Liquidación:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFechaLiquidacion" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />

                            <div align="center">

                             <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; width:800px;">
                                 <tr runat="server" 
                                     style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
                                     <td runat="server" 
                                         style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
                                         Total Despachado</td>
                                     <td runat="server" 
                                         style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
                                         Fecha 1er Despacho</td>
                                     <td runat="server" 
                                         style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
                                         Fecha Ultimo Despacho</td>
                                     <td runat="server" 
                                         style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
                                         Devolución</td>
                                     <td runat="server" 
                                         style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
                                         Faltante</td>
                                 </tr>
                                 <tr runat="server" 
                                     style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;">
                                     <td runat="server" 
                                         style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                         <asp:Label ID="lblDespachado" runat="server"></asp:Label>
                                         &nbsp; &nbsp; &nbsp; &nbsp;</td>
                                     <td runat="server" 
                                         style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                         <asp:Label ID="lblPrimerDesp" runat="server"></asp:Label>
                                     </td>
                                     <td runat="server" 
                                         style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                                         <asp:Label ID="lblUltDesp" runat="server"></asp:Label>
                                     </td>
                                     <td runat="server" 
                                         style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                         <asp:Label ID="lblDevolucion" runat="server"></asp:Label>
                                         &nbsp; &nbsp; &nbsp; &nbsp;
                                     </td>
                                     <td runat="server" 
                                         style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                         <asp:Label ID="lblFaltante" runat="server"></asp:Label>
                                         &nbsp; &nbsp; &nbsp; &nbsp;</td>
                                 </tr>
                                </table>
                            </div>
                            <br />
                            <br />
                            <div align="center">
                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Large" 
                                    Text="Historial Estado OT"></asp:Label>
                            </div>
                            <asp:Label ID="lblTablaHistorial" runat="server"></asp:Label>
                        </ContentTemplate>
                        </asp:TabPanel>
                        </asp:TabContainer>
                    
    </asp:Panel>
             
  <br />
    <br />
    <div align="center">  
        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Ventana" />
    </div>
    </form>
</body>
</html>
