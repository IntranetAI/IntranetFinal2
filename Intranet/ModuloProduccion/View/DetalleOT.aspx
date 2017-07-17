<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleOT.aspx.cs" Inherits="Intranet.ModuloProduccion.View.DetalleOT" EnableEventValidation="false"%>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui-1.10.3.js" type="text/javascript"></script>
    <script type="text/javascript">
        function newRespuesta(id) {
            document.getElementById("DIVCrearMensaje").style.display = "none";
            document.getElementById("DIVCrearRespuesta").style.display = "block";
            document.getElementById("DIVListMensaje").style.display = "none";
            var uusuario = document.getElementById("txtVarUsuario").value;
            $.ajax({
                url: "DetalleOT.aspx/Cargar_referenciaMensaje",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'ID':'" + id + "', 'Usuario':'" + uusuario + "'}",
                success: function (data) {
                    if (data.d[1] != "") {
                        document.getElementById("TabContainer2_TabPanel1_lblMensajeReferencia").innerHTML = data.d[0];
                        document.getElementById("TabContainer2_TabPanel1_lblAsuntoR").innerHTML = data.d[1];
                        document.getElementById("TabContainer2_TabPanel1_lblOTR").innerHTML = data.d[2];
                        document.getElementById("TabContainer2_TabPanel1_lblNombreOTR").innerHTML = data.d[3];
                        document.getElementById("TabContainer2_TabPanel1_lblCatAsuntoR").innerHTML = data.d[4];
                        document.getElementById("TabContainer2_TabPanel1_lblTipoMensajeR").innerHTML = data.d[5];
                        document.getElementById("txtIDMensaje").value = id;
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        };

        function CrearRespuesta() {
            var ID = document.getElementById("txtIDMensaje").value;
            var uusuario = document.getElementById("txtVarUsuario").value;
            var respuesta = document.getElementById("TabContainer2_TabPanel1_txtRespuesta").value;
            $.ajax({
                url: "DetalleOT.aspx/CrearRespuesta",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'ID':'" + ID + "','Usuario':'" + uusuario + "','Respuesta':'" + respuesta + "'}",
                success: function (data) {
                    if (data.d[0] == "OK") {
                        alert("Respuesta Creada Correctamente.");
                        document.getElementById("DIVrespuestaSiAdjunto").style.display = "block";
                        document.getElementById("DIVBotonesCrearRespuesta").style.display = "none";
                        document.getElementById("txtIDRespuesta").value = data.d[1];
                    }
                    else {
                        alert(data.d[0]);
                        document.getElementById("DIVrespuestaSiAdjunto").style.display = "none";
                        document.getElementById("DIVBotonesCrearRespuesta").style.display = "block";
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });

        }

        function imprimir() {
            var titulo = document.getElementById("Label2").innerHTML;
            var OT = titulo.slice(4, titulo.search("-")).trim();
            window.open('DetalleOT_print.aspx?id=' + OT, 'Imprimir', 'left=160,top=100,width=1020 ,height=770,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
        }

        function contar() {
            var oot = document.getElementById("txtVarOT").value;
            var uusuario = document.getElementById("txtVarUsuario").value;
            var elementos = document.getElementsByName("checkintento");
            for (x = 0; x < elementos.length; x++) {
                if (elementos[x].checked) {
                    $.ajax({
                        url: "DetalleOT.aspx/NoLeido",
                        type: "post",
                        dataType: "json",
                        contentType: "application/json;charset=utf-8",
                        data: "{'estado':'" + elementos[x].checked + "','idmensaje':'" + elementos[x].value + "','usuario':'" + uusuario + "'}",
                        success: function (data) {
                            if (data.d != 0) {
                                alert('Mensaje(s) Marcado(s) como Leido Correctamente ');
                            }
                            else {
                                alert('¡Ha Ocurrido un Error!');
                            }

                        },
                        error: function () {
                            alert('¡Ha Ocurrido un Error!');
                        }
                    });
                }
                window.location.href = 'DetalleOT.aspx?ot=' + oot;
            }
        }
        function MostrarDivNewMensaje() {
            var titulo = document.getElementById("Label2").innerHTML;
            var ot = titulo.slice(4, titulo.search("-"));
            document.getElementById("TabContainer2_TabPanel1_txtNOT").value = ot.toString().trim();
            document.getElementById("DIVCrearMensaje").style.display = "block";
            document.getElementById("DIVCrearRespuesta").style.display = "none";
            document.getElementById("DIVListMensaje").style.display = "none";
        }

        function MostrarDivListMensaje() {
            var titulo = document.getElementById("Label2").innerHTML;
            var OT = titulo.slice(4, titulo.search("-")).trim();
            location.href = 'DetalleOT.aspx?OT=' + OT + '&Mensajeria=1';

        }

        function CrearMensaje() {
            var OT = document.getElementById("TabContainer2_TabPanel1_txtNOT").value;
            var NombreOT = document.getElementById("TabContainer2_TabPanel1_lblNombreOT").innerHTML;
            var Comentario = document.getElementById("TabContainer2_TabPanel1_txtMensaje").value;
            var select = document.getElementById("TabContainer2_TabPanel1_ddlTipoMensaje");
            var TipoMensaje = select.options[select.selectedIndex].text;
            var select2 = document.getElementById("TabContainer2_TabPanel1_ddlCategoria");
            var categoria = select2.options[select2.selectedIndex].text;
            var idcategoria = select2.options[select2.selectedIndex].value;
            var select3 = document.getElementById("TabContainer2_TabPanel1_ddlAsunto");
            var Asunto = select3.options[select3.selectedIndex].text;
            var Urgente = document.getElementById("TabContainer2_TabPanel1_chkImportancia").checked;
            $.ajax({
                url: "DetalleOT.aspx/CrearMensaje",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OT':'" + OT + "','NombreOT':'" + NombreOT + "','TipoMensaje':'" + TipoMensaje + "','Categoria':'" + categoria + "','Asunto':'" + Asunto + "','Comentario':'" + Comentario + "','Usuario':'" + document.getElementById("txtVarUsuario").value + "','urgente':'" + Urgente + "','idcategoria':'" + idcategoria + "'}",
                success: function (data) {
                    if (data.d[1] == "OK") {
                        alert('Mensaje creado correctamente');
                        document.getElementById("lblidAdjuntoM").value = data.d[0];
                        document.getElementById("DIVmensajeSiAdjunto").style.display = "block";
                        document.getElementById("DIVBotonesCrearMensaje").style.display = "none";
                    }
                    else {
                        alert(data.d[1]);
                        document.getElementById("DIVmensajeSiAdjunto").style.display = "none";
                        document.getElementById("DIVBotonesCrearMensaje").style.display = "block";
                        document.getElementById("DIVBotonSalirNuevo").style.display = "none";
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }

        function Mensajeadjunto(EstadoDIV) {
            if (EstadoDIV == "Si") {
                document.getElementById("DIVMensajeAdjunto").style.display = "block";
                document.getElementById("DIVBotonSalirNuevo").style.display = "block";
                document.getElementById("DIVmensajeSiAdjunto").style.display = "none";
            }
            else {
                document.getElementById("DIVMensajeAdjunto").style.display = "none";
                document.getElementById("DIVBotonSalirNuevo").style.display = "none";
                document.getElementById("DIVmensajeSiAdjunto").style.display = "block";
                MostrarDivListMensaje();
            }
        }

        function Respuestaadjunto(EstadoDIV) {
            if (EstadoDIV == "Si") {
                document.getElementById("DIVAdjuntarRespuesta").style.display = "block";
                document.getElementById("DIVBotonSalirNuevo").style.display = "block";
                document.getElementById("DIVrespuestaSiAdjunto").style.display = "none";
                document.getElementById("DIVBotonSalirNuevoR").style.display = "block";
            }
            else {
                document.getElementById("DIVAdjuntarRespuesta").style.display = "none";
                document.getElementById("DIVBotonSalirNuevo").style.display = "none";
                document.getElementById("DIVrespuestaSiAdjunto").style.display = "block";
                document.getElementById("DIVBotonSalirNuevoR").style.display = "none";
                MostrarDivListMensaje();
            }
        }

        function AdjuntoArchivos() {
            document.getElementById("DIVListMensaje").style.display = "none";
            document.getElementById("DIVCrearRespuesta").style.display = "none";
            document.getElementById("DIVCrearMensaje").style.display = "block";
            document.getElementById("DIVBotonesCrearMensaje").style.display = "none";
            document.getElementById("DIVMensajeAdjunto").style.display = "block";
            document.getElementById("DIVBotonSalirNuevo").style.display = "block";
        }

        function AdjuntoArchivos2() {
            document.getElementById("DIVListMensaje").style.display = "none";
            document.getElementById("DIVCrearRespuesta").style.display = "block";
            document.getElementById("DIVCrearMensaje").style.display = "none";
            document.getElementById("DIVBotonesCrearRespuesta").style.display = "none";
            document.getElementById("DIVrespuestaSiAdjunto").style.display = "none";
            document.getElementById("DIVAdjuntarRespuesta").style.display = "block";
            document.getElementById("DIVBotonSalirNuevoR").style.display = "block";
        }

        $(document).ready(function () {
            $("#TabContainer2_TabPanel1_ddlTipoMensaje").change(function () {
                var select = document.getElementById("TabContainer2_TabPanel1_ddlTipoMensaje");
                var Tipo = select.options[select.selectedIndex].text;
                if (Tipo != "Seleccionar") {
                    document.getElementById("TabContainer2_TabPanel1_ddlCategoria").disabled = false;
                    document.getElementById("TabContainer2_TabPanel1_ddlAsunto").disabled = true;
                    document.getElementById("TabContainer2_TabPanel1_ddlAsunto").selectedIndex = 0;
                }
                else {
                    document.getElementById("TabContainer2_TabPanel1_ddlCategoria").disabled = true;
                    document.getElementById("TabContainer2_TabPanel1_ddlCategoria").selectedIndex = 0;
                    document.getElementById("TabContainer2_TabPanel1_ddlAsunto").disabled = true;
                    document.getElementById("TabContainer2_TabPanel1_ddlAsunto").selectedIndex = 0;
                }

            });

            $("#TabContainer2_TabPanel1_ddlCategoria").change(function () {
                var select = document.getElementById("TabContainer2_TabPanel1_ddlCategoria");
                var categoria = select.options[select.selectedIndex].text;
                if (categoria != "Seleccionar") {
                    var ddlTerritory = document.getElementById("TabContainer2_TabPanel1_ddlAsunto");
                    var lengthddlTerritory = ddlTerritory.length - 1;
                    for (var i = lengthddlTerritory; i >= 0; i--) {
                        ddlTerritory.options[i] = null;
                    }
                    $.ajax({
                        url: "DetalleOT.aspx/CargarAsuntosMensajes",
                        type: "post",
                        dataType: "json",
                        contentType: "application/json;charset=utf-8",
                        data: "{'ID':'" + eval(select.options[select.selectedIndex].value) + "'}",
                        success: function (data) {
                            var jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {
                                $('#TabContainer2_TabPanel1_ddlAsunto').append($("<option></option>").val(value.IDMail).html(value.Asunto));

                            });
                        },
                        error: function () {
                            alert('¡Ha Ocurrido un Error!');
                        }
                    });
                    document.getElementById("TabContainer2_TabPanel1_ddlAsunto").disabled = false;
                }
                else {
                    document.getElementById("TabContainer2_TabPanel1_ddlAsunto").disabled = true;
                    document.getElementById("TabContainer2_TabPanel1_ddlAsunto").selectedIndex = 0;
                }

            });
        });
    </script>
    <style type="text/css">
        .mailRevisido
        {
            font-family: "Trebuchet MS" , "Helvetica" , "Arial" , "Verdana" , "sans-serif";
            font-size: 100%; /*86%;*/
        }
        .ui-accordion .ui-accordion-header
        {
            display: block;
            cursor: pointer;
            position: relative;
            margin-top: 2px;
            padding: .5em .5em .5em .7em;
            min-height: 0; /* support: IE7 */
        }
        /*Estilo para las letra tanto el tamaño como estilo de ellas*/
        .ui-helper-reset
        {
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
        .ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default
        {
            border: 1px solid #d3d3d3;
            background: #e6e6e6;
            font-weight: normal;
            color: #555555;
        }
        .ui-state-hover, .ui-widget-content .ui-state-hover, .ui-widget-header .ui-state-hover, .ui-state-focus, .ui-widget-content .ui-state-focus, .ui-widget-header .ui-state-focus
        {
            border: 1px solid #999999;
            font-weight: normal;
            color: #212121;
            
        }
        .ui-accordion .ui-accordion-icons
        {
            padding-left: 2.2em;
        }
        /*Estilo de aparesca blanco del titulo  en un cuadrado*/
        .ui-state-active, .ui-widget-content .ui-state-active, .ui-widget-header .ui-state-active
        {
            border: 10px solid #aaaaaa;
            background: #ffffff;
            font-weight: normal;
            color: #212121;
        }
        
        /*Borde de la tabla*/
        .ui-corner-all, .ui-corner-top, .ui-corner-left, .ui-corner-tl
        {
            border-top-left-radius: 4px;
        }
        .ui-corner-all, .ui-corner-top, .ui-corner-right, .ui-corner-tr
        {
            border-top-right-radius: 4px;
        }
        .ui-corner-all, .ui-corner-bottom, .ui-corner-left, .ui-corner-bl
        {
            border-bottom-left-radius: 4px;
        }
        .ui-corner-all, .ui-corner-bottom, .ui-corner-right, .ui-corner-br
        {
            border-bottom-right-radius: 4px;
        }
        /*Contenido*/
        .ui-accordion .ui-accordion-content
        {
            padding: 1em 2.2em;
            border-top: 0;
            overflow: auto;
        }
        /*Eliminar el border mayor del mensaje*/
        .ui-helper-reset
        {
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
        .ui-widget-content
        {
            border: 1px solid #aaaaaa;
            color: #222222;
        }
        /*BOrde de contenido */
        .ui-tabs .ui-tabs-panel
        {
            display: block;
            border-width: 0;
            padding: 1em 1.4em;
            background: none;
        }
    </style>
    <style type="text/css">
        .divTitulo
        {
            background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);
            background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
            font-weight: bold;
            padding: 5px;
            border: 1px solid #959595;
            text-align: left;
        }
        .divSeccion
        {
            padding: 10px;
            border: 1px solid #959595;
            border-top: 0px;
            margin-bottom: 2px;
        }
        .style1
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True">
    </telerik:RadScriptManager>
    <div>
        <div align="center">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>
        <br />
        <asp:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="1" Height="650px"
            Width="1100px">
            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Mensajeria">
                <HeaderTemplate>
                    Mensajeria
                </HeaderTemplate>
                <ContentTemplate>
                    <div align="right">
                        <a title="Mensajes que Requieren Información">
                            <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/MensajeRequerirInf.JPG" Width="20px" Height="20px"/> = Requiere Información</a>
                        <a title="Mensajes que Requieren Información">
                            <asp:Image ID="Image15" runat="server" ImageUrl="~/Images/MensajeEntregaInf.JPG" Width="20px" Height="20px" /> = Entrega Información</a>
                        <a title="Marcar Mensaje Leido" onclick="contar();">
                            <asp:Image ID="Image2" ImageUrl="~/Images/mensaje-leido.png" Width="25px" runat="server" />
                            Marcar Leido&nbsp;&nbsp;</a>
                        <a title="Crear Nuevo Mensaje" onclick="MostrarDivNewMensaje();">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/write-message.png" Width="25px" />Crear Mensaje
                            &nbsp;&nbsp;</a>
                        <a title="Imprimir Mensajes" id="imprimirmensaje" runat="server" onclick="window.print();">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/print-message.jpg" Width="25px" />&nbsp;Imprimir
                        </a>&nbsp;&nbsp;
                        <a title="Orden Ascendiente">
                            <asp:ImageButton ID="ibAsc" runat="server" ImageUrl="~/Images/orden-asc.png" Width="25px"
                                OnClick="ibAsc_Click" />
                        </a><a title="Orden Descendiente">
                            <asp:ImageButton ID="ibDesc" runat="server" ImageUrl="~/Images/orden-desc.png" Width="25px"
                                OnClick="ibDesc_Click" />
                            &nbsp;Ordenamiento </a>
                    </div>
                    <div id="DIVCrearRespuesta" style="display:none;">
                        <div class="divTitulo">
                            Responder Mensaje
                        </div>
                        <div class="divSeccion">
                            <asp:Label ID="lblMensajeReferencia" runat="server"></asp:Label>
                            <br />
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width:100px;">
                                        &nbsp;
                                    </td>
                                    <td style="width:145px;">
                                        <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Gray" Text="OT: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblOTR" runat="server" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="lblidRespuesta" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="width:145px;">
                                        <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="Gray" 
                                            Text="Nombre OT: "></asp:Label>
                                    </td>
                                    <td><asp:Label ID="lblNombreOTR" runat="server"></asp:Label></td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:100px;">
                                    </td>
                                    <td>
                                        
                                        <asp:Label ID="Label23" runat="server" Text="Tipo Mensaje:" Font-Bold="True" ForeColor="Gray" ></asp:Label>
                                        
                                    </td>
                                    <td>
                                        
                                        <asp:Label ID="lblTipoMensajeR" runat="server"></asp:Label>
                                        
                                    </td>
                                    
                                    <td>
                                        <asp:Label ID="Label25" runat="server" Text="Categoria Asunto:" Font-Bold="True" ForeColor="Gray" ></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCatAsuntoR" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:100px;">
                                        &nbsp;
                                    </td>
                                    <td class="style10">
                                        <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Gray" Text="Asunto: "></asp:Label>
                                    </td>
                                    
                                    <td>
                                        <asp:Label ID="lblAsuntoR" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:100px;">
                                        &nbsp;
                                    </td>
                                    <td style="vertical-align:top;">
                                        <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="Gray" Text="Respuesta: "></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtRespuesta" runat="server" Height="100px" MaxLength="200" 
                                            TextMode="MultiLine" Width="635px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:100px;">
                                        &nbsp;
                                    </td>
                                    <td class="style10">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <div align="center" id="DIVBotonesCrearRespuesta" style="display:block;">
                                <input id="btnResponder" type="button" value="Responder" onclick="javascript:CrearRespuesta();"/>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="btnSalirRespuesta" type="button" value="Salir" onclick="javascript:MostrarDivListMensaje();" />
                            </div>
                            <div align="center" id="DIVrespuestaSiAdjunto" style="display:none;">
                                <br />
                                <asp:Label ID="lblRespuestaAdjunto" runat="server" ForeColor="Red">¿Desea Adjuntar Archivo?</asp:Label>
                                &nbsp;&nbsp;<input id="btnRsi" type="button" value="Si" onclick="javascript:Respuestaadjunto('Si')"/>
                                &nbsp;&nbsp;
                                <input id="btnRNo" type="button" value="No" onclick="javascript:Respuestaadjunto('No')" />
                                <br />
                            </div>
                            
                            <div style="display:none;" id="DIVAdjuntarRespuesta">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="4">
                                            <div align="center">
                                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Adjuntar Archivos"></asp:Label></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style19">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="Gray" Text="Seleccione: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FileUpload2" runat="server" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnAdjuntarRespuesta" runat="server" Text="Adjuntar" 
                                                onclick="btnAdjuntarRespuesta_Click" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style19">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <div style="max-height: 150px;min-height: 150px; width: 588px; overflow: auto; text-align: center;">
                                                <telerik:RadGrid ID="RadGrid2" runat="server" BorderWidth="0px" GridLines="None"
                                                    Skin="Outlook">
                                                    <ClientSettings EnableRowHoverStyle="True">
                                                    </ClientSettings>
                                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="Archivo">
                                                        <NoRecordsTemplate>
                                                            <div style="text-align: center;">
                                                                <br />
                                                                ¡ No se han encontrado registros !<br />
                                                            </div>
                                                        </NoRecordsTemplate>
                                                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="Archivo" HeaderText="Archivo" SortExpression="Archivo"
                                                                UniqueName="Archivo">
                                                                <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                                    </HeaderContextMenu>
                                                </telerik:RadGrid>
                                            </div>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="center" id="DIVBotonSalirNuevoR" style="display:none;">
                                <input id="Button1" type="button" value="Cerrar Mensaje / Salir" onclick="javascript:MostrarDivListMensaje();"/>
                            </div>
                        </div>
                    </div>
                    <div id="DIVCrearMensaje" style="display:none;">
                        <div class="divTitulo">
                            Crear Mensaje
                        </div>
                        <div class="divSeccion">
                            <table>
                                <tr>
                                    <td style="width:100px;"></td>
                                    <td style="width:145px;"><asp:Label ID="Label100" runat="server" Font-Bold="True" Text="OT:"></asp:Label></td>
                                    <td style="width:145px;"><asp:TextBox ID="txtNOT" runat="server" Enabled="False" MaxLength="10"></asp:TextBox></td>
                                    <td style="width:145px;"><asp:Label ID="Label101" runat="server" Font-Bold="True" Text="Nombre OT:"></asp:Label></td>
                                    <td style="width:350px;">
                                        <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="width:100px;"></td>
                                    <td style="width:145px;"><asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Tipo Mensaje:"></asp:Label></td>
                                    <td style="width:145px;"><asp:DropDownList ID="ddlTipoMensaje" runat="server">
                                            <asp:ListItem>Seleccionar</asp:ListItem>
                                            <asp:ListItem>Requerir Información</asp:ListItem>
                                            <asp:ListItem>Entregar información</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="width:145px;"></td>
                                    <td style="width:350px;"></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="width:100px;"></td>
                                    <td style="width:145px;"><asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Categoria Asunto:"></asp:Label></td>
                                    <td style="width:145px;"><asp:DropDownList ID="ddlCategoria" runat="server">
                                            <asp:ListItem>Seleccionar</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="width:145px;"></td>
                                    <td style="width:350px;"></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="width:100px;"></td>
                                    <td style="width:145px;">
                                        <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Asunto:"></asp:Label>
                                    </td>
                                    <td style="width:145px;"><asp:DropDownList ID="ddlAsunto" runat="server">
                                            <asp:ListItem>Seleccionar</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="width:145px;"></td>
                                    <td style="width:350px;"></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="width:100px;"></td>
                                    <td style="width:145px;">
                                        <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="Comentario:"></asp:Label>
                                    </td>

                                    <td colspan="3">
                                        <asp:TextBox ID="txtMensaje" runat="server" Height="100px" MaxLength="200" TextMode="MultiLine"
                                            Width="635px"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="chkImportancia" runat="server" Text="Mensaje Urgente" />
                                        &nbsp;<asp:Label ID="Label8" runat="server" ForeColor="Red" Text="(Esta Opción envía Correo)"></asp:Label></td>
                                    <td></td>
                                </tr>
                            </table>
                            
                            <div align="center" id="DIVBotonesCrearMensaje">
                                <input id="btnRedactar" type="button" value="Crear Mensaje" onclick="javascript:CrearMensaje();" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="btnSalir" type="button" value="Salir" Width="86px" onclick="javascript:MostrarDivListMensaje();"/>
                            </div>
                            <div align="center" style="display:none;" id="DIVmensajeSiAdjunto">
                                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblMensajeNuevo" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblDeseaAdjuntar" runat="server" ForeColor="Red" Text="¿Desea Adjuntar Archivo?"></asp:Label>
                                &nbsp;&nbsp;
                                <input id="btnSi" type="button" value="Si" onclick="javascript:Mensajeadjunto('Si');" />
                                &nbsp;&nbsp;
                                <input id="btnNo" type="button" value="No" onclick="javascript:Mensajeadjunto('No');" />
                            </div>
                            
                            <div style="display:none;" id="DIVMensajeAdjunto">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style15" colspan="4">
                                            <div align="center">
                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Adjuntar Archivos"></asp:Label></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="Label6" runat="server" Text="Seleccione: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnAdjuntarMensaje" runat="server" Text="Adjuntar" 
                                                onclick="btnAdjuntarMensaje_Click" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <div style="max-height: 150px; width: 588px;min-height: 100px; overflow: auto; text-align: center;">
                                            <telerik:RadGrid ID="RadGrid1" runat="server" BorderWidth="0px" Skin="Outlook" GridLines="None">
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="Archivo">
                                                    <NoRecordsTemplate>
                                                        <div style="text-align: center;">
                                                            <br />
                                                            ¡ No se han encontrado registros !<br />
                                                        </div>
                                                    </NoRecordsTemplate>
                                                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Archivo" HeaderText="Archivo" SortExpression="Archivo"
                                                            UniqueName="Archivo">
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <ClientSettings EnableRowHoverStyle="True">
                                                </ClientSettings>
                                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                            </div>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="center" id="DIVBotonSalirNuevo" style="display:none;">
                                <input id="btnSalirNuevo" type="button" value="Cerrar Mensaje / Salir" onclick="javascript:MostrarDivListMensaje();"/>
                            </div>
                        </div>
                    </div>
                    <div style="height: 600px; overflow-y: scroll;" id="DIVListMensaje">
                        <asp:Label ID="lblmensajeria" runat="server"></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Fecha de Entrega">
                <HeaderTemplate>
                    Fecha de Entrega
                </HeaderTemplate>
                <ContentTemplate>
                    <div style="height: 590px; width: 98%; overflow: auto;">
                        <telerik:RadGrid ID="RadGrid4" runat="server" Skin="Outlook">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                                <NoRecordsTemplate>
                                    <div style="text-align: center;">
                                        <br />
                                        ¡ No se han encontrado registros !<br />
                                    </div>
                                </NoRecordsTemplate>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridBoundColumn DataField="OT" HeaderText="Nº OT" ItemStyle-Width="30px"
                                        ReadOnly="True" SortExpression="OT" UniqueName="OT">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" ItemStyle-Width="300px"
                                        SortExpression="NombreOT" UniqueName="NombreOT">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TirajeGenerado" HeaderText="Cant. a Despachar" ItemStyle-HorizontalAlign="Right"
                                        ItemStyle-Width="50px" UniqueName="TirajeGenerado">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaDes" HeaderText="Fecha Entrega" ItemStyle-Width="150px"
                                        SortExpression="FechaDes" UniqueName="FechaDes" DataFormatString="{0:dd/MM/yyyy HH:mm}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Despachado" HeaderText="% Entrega" ItemStyle-Width="300px"
                                        UniqueName="Despachado">
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
            <asp:TabPanel ID="TabPanel2" runat="server">
                <HeaderTemplate>
                    Programacion de produccion
                </HeaderTemplate>
                <ContentTemplate>
                    <div style="height: 590px; width: 98%; overflow: auto;">
                        <telerik:RadGrid ID="RadGrid12" runat="server" Skin="Outlook">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="Nombre">
                                <NoRecordsTemplate>
                                    <div style="text-align: center;">
                                        <br />
                                        ¡ No se han encontrado registros !<br />
                                    </div>
                                </NoRecordsTemplate>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Nombre" HeaderText="Maquina" ItemStyle-Width="80px"
                                        SortExpression="Nombre" UniqueName="Nombre">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Observaciones" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="200px" UniqueName="Description">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" ItemStyle-Width="50px"
                                        SortExpression="Pliego" UniqueName="Pliego" ItemStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CantSolicitada" HeaderText="Pliegos Planificados"
                                        ItemStyle-Width="130px" UniqueName="CantSolicitada" ItemStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="HoraInicio" HeaderText="Hora Inicio Estimado"
                                        ItemStyle-Width="160px" UniqueName="HoraInicio" ItemStyle-HorizontalAlign="Center">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="HoraFin" HeaderText="Hora Fin Estimado" ItemStyle-Width="160px"
                                        UniqueName="HoraFin" ItemStyle-HorizontalAlign="Center">
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
            <asp:TabPanel ID="TabPanel8" runat="server">
                <HeaderTemplate>
                    Produccion Encuadernacion
                </HeaderTemplate>
                <ContentTemplate>
                    <div align="right" style="width: 98%;">
                        <asp:Button ID="btnCargarEncuadernacion" runat="server" Text="Cargar Detalle" OnClick="btnCargarEncuadernacion_Click" />
                    </div>
                    <div style="height: 590px; width: 98%; overflow: auto;">
                        <telerik:RadGrid ID="RadGrid7" runat="server" BorderWidth="0px" Skin="Outlook">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                                <NoRecordsTemplate>
                                    <div style="text-align: center;">
                                        <br />
                                        ¡ No se han encontrado OTs Nuevas !<br />
                                    </div>
                                </NoRecordsTemplate>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ReadOnly="True" SortExpression="OT"
                                        UniqueName="OT" ItemStyle-Width="30px">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" SortExpression="NombreOT"
                                        UniqueName="NombreOT" ItemStyle-Width="220px">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Pliego" HeaderText="Pliego" ItemStyle-HorizontalAlign="Center"
                                        ReadOnly="True" SortExpression="Pliego" UniqueName="Pliego" ItemStyle-Width="40px">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Forma" HeaderText="Forma" SortExpression="Forma"
                                        UniqueName="Forma" ItemStyle-Width="20px">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Maquina" HeaderText="Maquina" UniqueName="Maquina"
                                        ItemStyle-Width="100px">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Buenos" HeaderText="Buenos" UniqueName="Buenos"
                                        ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaInicio" HeaderText="FechaInicio" UniqueName="FechaInicio"
                                        ItemStyle-Width="115px" ItemStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaTermino" HeaderText="FechaTermino" UniqueName="FechaTermino"
                                        ItemStyle-Width="115px" ItemStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Operacion" HeaderText="Operacion" UniqueName="Operacion"
                                        ItemStyle-Width="190px">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="true">
                            </ClientSettings>
                            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel7" runat="server">
                <HeaderTemplate>
                    Entregados Enc.
                </HeaderTemplate>
                <ContentTemplate>
                    <div style="height: 590px; width: 98%; overflow: auto;">
                    <telerik:RadGrid ID="RadGrid3" BorderWidth="0px" runat="server" Skin="Outlook">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="id_ProductosTerminados">
                            <NoRecordsTemplate>
                                <div style="text-align: center;">
                                    <br />
                                    ¡ No se han encontrado registros !<br />
                                </div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="cod_Pallet" Visible="false" HeaderText="Pallet"
                                    ReadOnly="True" SortExpression="cod_Pallet" UniqueName="cod_Pallet">
                                    <ItemStyle Width="40px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ReadOnly="True" SortExpression="OT"
                                    UniqueName="OT">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreOT" HeaderText="Nombre OT" SortExpression="NombreOT"
                                    UniqueName="NombreOT">
                                    <ItemStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Terminacion" HeaderText="Terminacion" UniqueName="Terminacion">
                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TipoEmbalaje" HeaderText="Tipo Embalaje" UniqueName="TipoEmbalaje">
                                    <ItemStyle Width="60px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total"
                                    UniqueName="Total">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn Visible="false" DataField="FechaCreacion" HeaderText="FechaCreacion"
                                    ReadOnly="True" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                                    <ItemStyle Width="100px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Observacion" HeaderText="Observacion" ReadOnly="True"
                                    SortExpression="Observacion" UniqueName="Observacion">
                                    <ItemStyle Width="40px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn Visible="false" DataField="Validado" HeaderText="Validado"
                                    ReadOnly="True" SortExpression="Validado" UniqueName="Validado">
                                    <ItemStyle Width="40px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaValidacion" HeaderText="Fecha Creación"
                                    ReadOnly="True" SortExpression="FechaValidacion" UniqueName="FechaValidacion">
                                    <ItemStyle Width="100px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Modificado" HeaderText="Estado" ReadOnly="True"
                                    SortExpression="Modificado" UniqueName="Modificado">
                                    <ItemStyle Width="30px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="True">
                        </ClientSettings>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel6" runat="server">
                <HeaderTemplate>
                    Historial Despacho
                </HeaderTemplate>
                <ContentTemplate>
                    <div style="height: 590px; width: 98%; overflow: auto;">
                        <div align="right" style="padding-bottom: 10px;">
                            <a title="Exportar a Excel">
                                <asp:ImageButton ID="ibExportExcel" runat="server" Height="25px" ImageUrl="~/Images/Excel-icon.png"
                                    Width="25px" Visible="False" />
                            </a>
                        </div>
                        <telerik:RadGrid ID="RadGrid5" runat="server" Skin="Outlook">
                            <PagerStyle Mode="NumericPages" />
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                                <NoRecordsTemplate>
                                    <div style="text-align: center;">
                                        <br />
                                        ¡ No se han encontrado !<br />
                                    </div>
                                </NoRecordsTemplate>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" ItemStyle-Width="40px"
                                        SortExpression="Folio" UniqueName="Folio">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaImpresion" HeaderText="Fecha Impresion"
                                        ItemStyle-Width="100px" SortExpression="FechaImpresion" UniqueName="FechaImpresion"
                                        DataFormatString="{0:dd/MM/yyyy HH:mm}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Destinatario" HeaderText="Destinatario" ItemStyle-Width="250px"
                                        UniqueName="Destinatario">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Sucursal" HeaderText="Sucursal" ItemStyle-Width="360px"
                                        SortExpression="Sucursal" UniqueName="Sucursal">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Comuna" HeaderText="Comuna" ItemStyle-Width="90px"
                                        SortExpression="Comuna" UniqueName="Comuna">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Despachado" HeaderText="Cant." ItemStyle-HorizontalAlign="Right"
                                        ItemStyle-Width="40px" UniqueName="Despachado">
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
           
        </asp:TabContainer>
    </div>
    <div style="display:none;">
        <asp:TextBox ID="txtVarUsuario" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtVarOT" runat="server"></asp:TextBox>
        <asp:TextBox ID="lblidAdjuntoM" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtIDMensaje" runat="server"> </asp:TextBox>
        <asp:TextBox ID="txtIDRespuesta" runat="server"></asp:TextBox>
        </div>
    <div align="center">
        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Ventana" 
            onclick="btnCerrar_Click" />
    </div>
    </form>
</body>
</html>
