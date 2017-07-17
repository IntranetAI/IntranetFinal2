<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true"
    CodeBehind="Ingreso_PalletWip.aspx.cs" EnableEventValidation="false" Inherits="Intranet.ModuloWip.View.Ingreso_PalletWip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    </style>
    <script type="text/javascript">
    function BuscarOT() {
        var OT = document.getElementById("<%= txtOT.ClientID%>").value;
        $.ajax({
            url: "Ingreso_PalletWip.aspx/BuscarOT",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'OT':'" + OT + "'}",
            success: function (msg) {
                document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = msg.d[0];
                document.getElementById("ContentPlaceHolder1_lblCliente").innerHTML = msg.d[1];
                document.getElementById("ContentPlaceHolder1_lblTotal").innerHTML = msg.d[2];
            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
        var ddlTerritory = document.getElementById("<%= ddlProgramado.ClientID %>");
        var lengthddlTerritory = ddlTerritory.length - 1;
        for (var i = lengthddlTerritory; i >= 0; i--) {
            ddlTerritory.options[i] = null;
        }
        $.ajax({
            url: "Ingreso_PalletWip.aspx/CargarPliegosProgramado",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'OT':'" + OT + "'}",
            success: function (data) {
                var jsdata = JSON.parse(data.d);
                $.each(jsdata, function (key, value) {
                    $('#<%=ddlProgramado.ClientID%>').append($("<option></option>").val(value.Forma).html(value.Prox_Proceso));

                });
            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
        var ddlTerritory2 = document.getElementById("<%= ddlSinPrograma.ClientID %>");
        var lengthddlTerritory = ddlTerritory2.length - 1;
        for (var i = lengthddlTerritory; i >= 0; i--) {
            ddlTerritory2.options[i] = null;
        }
        $.ajax({
            url: "Ingreso_PalletWip.aspx/CargarPliegosSinProgr",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'OT':'" + OT + "'}",
            success: function (data) {
                var jsdata = JSON.parse(data.d);
                $.each(jsdata, function (key, value) {
                    $('#<%=ddlSinPrograma.ClientID%>').append($("<option></option>").val(value.Pliego).html(value.Pliego));

                });
            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
    }

    function CargarMaquina(Maquina) {
        if (Maquina == "Servicio Externo") {
            document.getElementById("ContentPlaceHolder1_lblMaquina").innerHTML = "Proceso Externo:";
        }
        else {
            document.getElementById("ContentPlaceHolder1_lblMaquina").innerHTML = "Maquina:";
        }
        var ddlTerritory = document.getElementById("<%= ddlMaquina.ClientID %>");
        var lengthddlTerritory = ddlTerritory.length - 1;
        for (var i = lengthddlTerritory; i >= 0; i--) {
            ddlTerritory.options[i] = null;
        }
        $.ajax({
            url: "Ingreso_PalletWip.aspx/CargarMaquina",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'Maquina':'" + Maquina + "'}",
            success: function (data) {
                var jsdata = JSON.parse(data.d);
                $.each(jsdata, function (key, value) {
                    $('#<%=ddlMaquina.ClientID%>').append($("<option></option>").val(value.OT).html(value.OT));

                });

            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
    }

    function CantidadPliegos(Pliego) {
        var OT = document.getElementById("<%= txtOT.ClientID%>").value;
        $.ajax({
            url: "Ingreso_PalletWip.aspx/CantidadPliegos",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'OT':'" + OT + "','Pliego':'"+ Pliego +"'}",
            success: function (msg) {
                document.getElementById("ContentPlaceHolder1_lblTirajePlg").innerHTML = msg.d[0];
                document.getElementById("ContentPlaceHolder1_lblRestantes").innerHTML = msg.d[1];
            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
    }

    function DestinoPallet(Origen){
        var ddlTerritory = document.getElementById("<%= ddlDestino.ClientID %>");
        var lengthddlTerritory = ddlTerritory.length - 1;
        for (var i = lengthddlTerritory; i >= 0; i--) {
            ddlTerritory.options[i] = null;
        }
        if(Origen =="Digital"){
            $('#<%=ddlDestino.ClientID%>').append($("<option></option>").val(2).html("Servicio Externo"));
            $('#<%=ddlDestino.ClientID%>').append($("<option></option>").val(3).html("Directo a Encuadernacion"));
        }
        else {
            $('#<%=ddlDestino.ClientID%>').append($("<option></option>").val(1).html("Almacenamiento Wip"));
            $('#<%=ddlDestino.ClientID%>').append($("<option></option>").val(2).html("Servicio Externo"));
            $('#<%=ddlDestino.ClientID%>').append($("<option></option>").val(3).html("Directo a Encuadernacion"));
            $('#<%=ddlDestino.ClientID%>').append($("<option></option>").val(4).html("Taller Digital"));
        }
    }

    function GrabarPallet() {

        var OT = document.getElementById("<%= txtOT.ClientID%>").value;
        var NombreOT = document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML;
        var TirajeOT = document.getElementById("ContentPlaceHolder1_lblTotal").innerHTML;
        var select1 = document.getElementById("<%= ddlMaquina.ClientID %>");
        var Maquina = select1.options[select1.selectedIndex].text;

        var Pliego = "";
        var select2 = document.getElementById("<%= ddlProgramado.ClientID %>");
        var Programado = select2.options[select2.selectedIndex].text;

        var select3 = document.getElementById("<%= ddlSinPrograma.ClientID %>");
        var SinPrograma = select3.options[select3.selectedIndex].text;
        var tabla =document.getElementById("tableDatosPallet").style.display;
        var PliegoMetrics = "";
        if(tabla == "block"){
            if (Programado != "Seleccionar") {
                Pliego = Programado;
                PliegoMetrics = select2.options[select2.selectedIndex].value;
            }
            else if (SinPrograma != "Seleccionar") {
                Pliego = document.getElementById("<%= txtNuevoNombre.ClientID%>").value;
            }
        }
        else{
            var selectDigital = document.getElementById("<%= ddlPliegoDigital1.ClientID %>");
            Pliego = selectDigital.options[selectDigital.selectedIndex].text;
        }
        
        var select4 = document.getElementById("<%= ddlDestino.ClientID %>");
        var Destino = select4.options[select4.selectedIndex].text;
        
        var IDTipoPallet = 0;
        var TipoPallet = "";
        if(tabla == "block"){
            if ($("#ContentPlaceHolder1_rbnNormal").attr("checked")) {
                IDTipoPallet = 1;
                TipoPallet = "Pliego Normal";
            }
            else if ($("#ContentPlaceHolder1_rbnEspecial").attr("checked")) {
                IDTipoPallet = 2;
                TipoPallet = "Pliego Especial";
            }
        }
        else{
            IDTipoPallet = 1;
            TipoPallet = "Pliego Normal";
        }

        var Pliegos_Impresos = 0;
        var Peso_pallet = 0;
        if(tabla == "block"){
            Pliegos_Impresos = document.getElementById("<%= txtPliegosImpresos.ClientID%>").value;
            Peso_pallet = document.getElementById("<%= txtPesoPallet.ClientID%>").value;
        }
        else{
            Pliegos_Impresos = document.getElementById("<%= txtCantidadDigital.ClientID%>").value;
        }
        
        
        $.ajax({
            url: "Ingreso_PalletWip.aspx/GrabarPallet",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'OT':'" + OT + "','Pliego':'" + Pliego + "','NombreOT':'" + NombreOT + "','TirajeOT':'" + TirajeOT + "','Maquina':'" + Maquina + "','Destino':'" + Destino +
                    "','IDTipoPallet':'" + IDTipoPallet + "','TipoPallet':'" + TipoPallet + "','Pliegos_Impresos':'" + Pliegos_Impresos + "','Peso_pallet':'" + Peso_pallet + "','Usuario':'<%=Session["Usuario"] %>','PliegoMetrics':'"+PliegoMetrics+"'}",
            success: function (msg) {
                if(msg.d[0]=="OK"){
                    document.getElementById("ContentPlaceHolder1_lblCodigo").innerHTML = msg.d[1];
                    document.getElementById("btnImprimir").style.visibility = "visible";
                    document.getElementById("btnGuardar").style.visibility = "hidden";
                }
                else{
                    document.getElementById("btnImprimir").style.visibility = "hidden";
                    document.getElementById("btnGuardar").style.visibility = "visible";
                    alert(msg.d[0]);
                }
            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
    }

    function GrabarPalletMultiple() {

        var OT = document.getElementById("<%= txtOT.ClientID%>").value;
        var NombreOT = document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML;
        var TirajeOT = document.getElementById("ContentPlaceHolder1_lblTotal").innerHTML;
        var select1 = document.getElementById("<%= ddlMaquina.ClientID %>");
        var Maquina = select1.options[select1.selectedIndex].text;

        var Pliego = "";
        var select2 = document.getElementById("<%= ddlProgramado.ClientID %>");
        var Programado = select2.options[select2.selectedIndex].text;

        var select3 = document.getElementById("<%= ddlSinPrograma.ClientID %>");
        var SinPrograma = select3.options[select3.selectedIndex].text;
        var PliegoMetrics = "";
        if (Programado != "Seleccionar") {
            Pliego = Programado;
            PliegoMetrics = select2.options[select2.selectedIndex].value;
        }
        else if (SinPrograma != "Seleccionar") {
            Pliego = document.getElementById("<%= txtNuevoNombre.ClientID%>").value;
        }
        
        var select4 = document.getElementById("<%= ddlDestino.ClientID %>");
        var Destino = select4.options[select4.selectedIndex].text;
        
        var IDTipoPallet = 0;
        var TipoPallet = "";
        if ($("#ContentPlaceHolder1_rbnNormal").attr("checked")) {
            IDTipoPallet = 1;
            TipoPallet = "Pliego Normal";
        }
        else if ($("#ContentPlaceHolder1_rbnEspecial").attr("checked")) {
            IDTipoPallet = 2;
            TipoPallet = "Pliego Especial";
        }
        
        var Pliegos_Impresos = document.getElementById("<%= txtPliegosImpresos.ClientID%>").value;
        var Peso_pallet = document.getElementById("<%= txtPesoPallet.ClientID%>").value;
        var CodigoPallet = document.getElementById("ContentPlaceHolder1_lblCodigo").innerHTML;
        var IsMultiple = document.getElementById("ContentPlaceHolder1_lblIsMultiple").innerHTML;
        
        $.ajax({
            url: "Ingreso_PalletWip.aspx/GrabarPalletMultiple",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'OT':'" + OT + "','Pliego':'" + Pliego + "','NombreOT':'" + NombreOT + "','TirajeOT':'" + TirajeOT + "','Maquina':'" + Maquina + "','Destino':'" + Destino +
                    "','IDTipoPallet':'" + IDTipoPallet + "','TipoPallet':'" + TipoPallet + "','Pliegos_Impresos':'" + Pliegos_Impresos + "','Peso_pallet':'" + Peso_pallet + 
                    "','Usuario':'<%=Session["Usuario"] %>','CodigoPallet':'"+CodigoPallet+"','IsMultiple':'"+IsMultiple+"','PliegoMetrics':'"+PliegoMetrics+"'}",
            success: function (msg) {
                
                if(msg.d[0]=="OK"){
                    document.getElementById("ContentPlaceHolder1_lblCodigo").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblIsMultiple").innerHTML = msg.d[2];
                    document.getElementById("ContentPlaceHolder1_lblPliegosMulti").innerHTML = msg.d[3];
                    document.getElementById("btnImprimir").style.visibility = "visible";
                    document.getElementById("btnGuardar").style.visibility = "hidden";
                }
                else{
                    document.getElementById("btnImprimir").style.visibility = "hidden";
                    document.getElementById("btnGuardar").style.visibility = "visible";
                    alert(msg.d[0]);
                }
            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
    }

    function Imprimir(){
        var Codigo = document.getElementById("ContentPlaceHolder1_lblCodigo").innerHTML;

        if(document.getElementById("ContentPlaceHolder1_lblPliegosMulti").innerHTML!=""){
            onload(window.open("Etiqueta_Wip2.aspx?cd="+ Codigo,"Imprimir Etiqueta Wip","toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=750,height=700,left=340,top=200"));    
        }
        else{
        onload(window.open("Etiqueta_Wip.aspx?cd="+ Codigo,"Imprimir Etiqueta Wip","toolbar=no, location=yes,status=no,menubar=no,scrollbars=no,resizable=no, width=750,height=700,left=340,top=200"));
        }
        document.getElementById("btnGuardar").style.visibility = "visible";
        document.getElementById("btnMultiples").style.visibility = "hidden";
        document.getElementById("ContentPlaceHolder1_ddlSinPrograma").selectedIndex = 0;
        document.getElementById("ContentPlaceHolder1_ddlProgramado").selectedIndex = 0;
        document.getElementById("ContentPlaceHolder1_lblTirajePlg").innerHTML = "0";
        document.getElementById("ContentPlaceHolder1_lblIsMultiple").innerHTML = "";
        document.getElementById("ContentPlaceHolder1_lblPliegosMulti").innerHTML = "";
        document.getElementById("ContentPlaceHolder1_ckbMultiple").checked = 0;
        document.getElementById("ContentPlaceHolder1_rbnNormal").checked = 0;
        document.getElementById("ContentPlaceHolder1_rbnEspecial").checked = 0;
        document.getElementById("<%= txtNuevoNombre.ClientID%>").value = "";
        document.getElementById("<%=txtNuevoNombre.ClientID%>").disabled = true;
        document.getElementById("ContentPlaceHolder1_ddlSinPrograma").disabled = false;
        document.getElementById("ContentPlaceHolder1_ddlProgramado").disabled = false;

    }

    $(document).ready(function () {
        document.getElementById("form1").onsubmit=function(){
            return false;
        }
        $("#ContentPlaceHolder1_txtOT").keypress(function(e) {
            if(e.which == 13) {
                BuscarOT(); 
            }
        });

        $("#ContentPlaceHolder1_txtOT").change(function() {
            BuscarOT(); 
        });

        $("#ContentPlaceHolder1_rbnRotativa, #ContentPlaceHolder1_rbnPlana, #ContentPlaceHolder1_rbnServExt, #ContentPlaceHolder1_rbnDigital").change(function () {
            if ($("#ContentPlaceHolder1_rbnRotativa").attr("checked")) {
                CargarMaquina("Rotativa");
                DestinoPallet("Rotativa");
                document.getElementById("tableDatosPallet").style.display = "block";
                document.getElementById("divDigital").style.display= "none";
            }
            else if ($("#ContentPlaceHolder1_rbnPlana").attr("checked")) {
                CargarMaquina("Planas");
                DestinoPallet("Planas");
                document.getElementById("tableDatosPallet").style.display = "block";
                document.getElementById("divDigital").style.display= "none";
            }
            else if ($("#ContentPlaceHolder1_rbnDigital").attr("checked")) {
                CargarMaquina("Digital");
                DestinoPallet("Digital");
                document.getElementById("tableDatosPallet").style.display = "none";
                document.getElementById("divDigital").style.display= "block";
            }
            else if ($("#ContentPlaceHolder1_rbnServExt").attr("checked")) {
                CargarMaquina("Servicio Externo");
                DestinoPallet("Servicio Externo");
                document.getElementById("tableDatosPallet").style.display = "block";
                document.getElementById("divDigital").style.display= "none";

                var contador = 0;
                $.ajax({
                    url: "Ingreso_PalletWip.aspx/CargarPliegosSinProgr",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'OT':'" + document.getElementById("<%= txtOT.ClientID%>").value + "'}",
                    success: function (data) {
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            contador = contador+1;
                        });
                        if(contador == 1){
                            var texto = "DIGITAL";
                            var cadena= document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML.toUpperCase();
                            if (cadena.indexOf(texto) != -1) {
                                document.getElementById("tableDatosPallet").style.display = "none";
                                document.getElementById("divDigital").style.display= "block";
                            }
                        }
                    },
                    error: function () {
                        alert('¡Ha Ocurrido un Error!');
                    }
                });
            }
            
        });

        $("#ContentPlaceHolder1_ckbMultiple").change(function () {
            if ($("#ContentPlaceHolder1_ckbMultiple").attr("checked")) {
                document.getElementById("btnMultiples").style.visibility = "visible";
                document.getElementById("btnGuardar").style.visibility = "hidden";
            }
            else{
                document.getElementById("btnMultiples").style.visibility = "hidden";
                document.getElementById("btnGuardar").style.visibility = "visible";
            }
        });

        $("#ContentPlaceHolder1_ddlProgramado").change(function () {
            var select = document.getElementById("<%= ddlProgramado.ClientID %>");
            var Programado = select.options[select.selectedIndex].text;
            if (Programado == "Seleccionar") {
                document.getElementById("<%=txtNuevoNombre.ClientID%>").disabled = true;
                document.getElementById("ContentPlaceHolder1_ddlSinPrograma").disabled = false;
                document.getElementById("ContentPlaceHolder1_ddlSinPrograma").selectedIndex = 0;
                document.getElementById("ContentPlaceHolder1_lblTirajePlg").innerHTML = "0";
                document.getElementById("ContentPlaceHolder1_lblRestantes").style.visibility = "hidden";
                document.getElementById("ContentPlaceHolder1_Label21").style.visibility = "hidden";
            }
            else {
                var select = document.getElementById("<%= ddlMaquina.ClientID %>");
                var Maquina = select.options[select.selectedIndex].text;
                if(Maquina=="Indigo"){
                    document.getElementById("ContentPlaceHolder1_lblTirajePlg").innerHTML = document.getElementById("ContentPlaceHolder1_lblTotal").innerHTML;
                    document.getElementById("ContentPlaceHolder1_lblRestantes").innerHTML = document.getElementById("ContentPlaceHolder1_lblTotal").innerHTML;
                }
                else{
                    CantidadPliegos(Programado);
                }
                document.getElementById("ContentPlaceHolder1_ddlSinPrograma").disabled = true;
                document.getElementById("ContentPlaceHolder1_lblRestantes").style.visibility = "visible";
                document.getElementById("ContentPlaceHolder1_Label21").style.visibility = "visible";
            }
        });

        $("#ContentPlaceHolder1_ddlSinPrograma").change(function () {
            var select = document.getElementById("<%= ddlSinPrograma.ClientID %>");
            var Programado = select.options[select.selectedIndex].text;
            if (Programado == "Seleccionar") {
                document.getElementById("ContentPlaceHolder1_ddlProgramado").disabled = false;
                document.getElementById("<%=txtNuevoNombre.ClientID%>").disabled = true;
                document.getElementById("ContentPlaceHolder1_ddlProgramado").selectedIndex = 0;
                document.getElementById("ContentPlaceHolder1_lblTirajePlg").innerHTML = "0";
                document.getElementById("ContentPlaceHolder1_lblRestantes").style.visibility = "hidden";
                document.getElementById("ContentPlaceHolder1_Label21").style.visibility = "hidden";
            }
            else {
                var select = document.getElementById("<%= ddlMaquina.ClientID %>");
                var Maquina = select.options[select.selectedIndex].text;
                if(Maquina=="Indigo"){
                    document.getElementById("ContentPlaceHolder1_lblTirajePlg").innerHTML = document.getElementById("ContentPlaceHolder1_lblTotal").innerHTML;
                    document.getElementById("ContentPlaceHolder1_lblRestantes").innerHTML = document.getElementById("ContentPlaceHolder1_lblTotal").innerHTML;
                }
                else{
                    CantidadPliegos(Programado);
                }
                document.getElementById("ContentPlaceHolder1_ddlProgramado").disabled = true;
                document.getElementById("<%=txtNuevoNombre.ClientID%>").disabled = false;
                document.getElementById("ContentPlaceHolder1_lblRestantes").style.visibility = "visible";
                document.getElementById("ContentPlaceHolder1_Label21").style.visibility = "visible";
            }
        });

        $("#ContentPlaceHolder1_ddlMaquina").change(function () {
            if ($("#ContentPlaceHolder1_rbnDigital").attr("checked")) {
                var Tiraje = document.getElementById("ContentPlaceHolder1_lblTotal").innerHTML;
                var OT = document.getElementById("<%= txtOT.ClientID%>").value;
                
                var ddlTerritory = document.getElementById("<%= ddlProgramado.ClientID %>");
                var lengthddlTerritory = ddlTerritory.length - 1;
                for (var i = lengthddlTerritory; i >= 0; i--) {
                    ddlTerritory.options[i] = null;
                }

                var ddlTerritory2 = document.getElementById("<%= ddlSinPrograma.ClientID %>");
                var lengthddlTerritory2 = ddlTerritory2.length - 1;
                for (var i = lengthddlTerritory2; i >= 0; i--) {
                    ddlTerritory2.options[i] = null;
                }

                $.ajax({
                    url: "Ingreso_PalletWip.aspx/CargarPliegosDigital",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'OT':'" + OT + "','Tiraje':'"+Tiraje+"'}",
                    success: function (data) {
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            $('#<%=ddlProgramado.ClientID%>').append($("<option></option>").val(value.Forma).html(value.Prox_Proceso));
                            $('#<%=ddlSinPrograma.ClientID%>').append($("<option></option>").val(value.Forma).html(value.Prox_Proceso));
                        });
                    },
                    error: function () {
                        alert('¡Ha Ocurrido un Error!');
                    }
                });
            }
            else{
            }
        });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="divTitulo">
        Datos de la OTs</div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td style="width: 11px;">
                    &nbsp;
                </td>
                <td style="width: 120px;">
                    <asp:Label ID="Label3" runat="server" Text="Numero OT:"></asp:Label>
                </td>
                <td style="width: 300px;">
                    <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
                </td>
                <td style="width: 120px;">
                    <asp:Label ID="Label8" runat="server" Text="Nombre OT:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblNombreOT" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="width: 120px;">
                    <asp:Label ID="Label9" runat="server" Text="Cliente:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Tiraje OT:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divTitulo">
        Origen/ Destino Pallet</div>
    <div class="divSeccion">
        <table style="width: 100%;">
            <tr>
                <td style="width: 11px;">
                    &nbsp;
                </td>
                <td style="width: 70px;">
                    <asp:Label ID="Label1" runat="server" Text="Origen:"></asp:Label>
                </td>
                <td style="width: 320px;">
                    <asp:RadioButton ID="rbnRotativa" runat="server" GroupName="Origen" Text="Rotativa" />
                    <asp:RadioButton ID="rbnPlana" runat="server" GroupName="Origen" Text="Plana" />
                    <asp:RadioButton ID="rbnDigital" runat="server" GroupName="Origen" Text="Digital" />
                    <asp:RadioButton ID="rbnServExt" runat="server" GroupName="Origen" Text="Serv. Ext." />
                </td>
                <td style="width: 110px;">
                    <asp:Label ID="lblMaquina" runat="server" Text="Maquina:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMaquina" runat="server">
                        <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 120px;">
                    <asp:Label ID="Label4" runat="server" Text="Destino:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDestino" runat="server">
                        <asp:ListItem Value="1">Almacenamiento Wip</asp:ListItem>
                        <asp:ListItem Value="2">Servicio Externo</asp:ListItem>
                        <asp:ListItem Value="3">Directo a Encuadernacion</asp:ListItem>
                        <asp:ListItem Value="4">Taller Digital</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divTitulo">
        Datos del Pallet</div>
    <div class="divSeccion">
        <table id="tableDatosPallet" style="width: 100%;display:block;">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Plg. Programado:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProgramado" runat="server">
                        <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label10" runat="server" Text="Plg. S/n Pro.:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSinPrograma" runat="server">
                        <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label11" runat="server" Text="Nuevo Nombre:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNuevoNombre" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Tipos de Pliegos:"></asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="rbnNormal" runat="server" GroupName="TipoPallet" Text="Pliego Normal" />
                    <asp:RadioButton ID="rbnEspecial" runat="server" GroupName="TipoPallet" Text="Pliego Especial" />
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label13" runat="server" Text="Tiraje del Pliego:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTirajePlg" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label14" runat="server" Text="Pliegos Multiples:"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ckbMultiple" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Pliegos Impresos:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPliegosImpresos" runat="server"></asp:TextBox>&nbsp;
                    <asp:Label ID="Label21" runat="server" ForeColor="Red" Text="* Plg. Restantes: "
                        Style="visibility: hidden;"></asp:Label>
                    <asp:Label ID="lblRestantes" runat="server" Style="visibility: hidden;"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label16" runat="server" Text="Peso Pallet:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPesoPallet" runat="server"></asp:TextBox>
                </td>
                <td>
                    <input id="btnMultiples" type="button" value="Agregar" style="visibility: hidden;"
                        onclick="javascript:GrabarPalletMultiple();" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <div id="divDigital" style="display:none;">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Pliego: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPliegoDigital1" runat="server">
                            <asp:ListItem>Pliego</asp:ListItem>
                            <asp:ListItem>Tapa</asp:ListItem>
                            <asp:ListItem>Pliego + Tapa</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Cantidad: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCantidadDigital" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <asp:Label ID="lblPliegosMulti" runat="server" Text=""></asp:Label>
    <div align="center">
        <input id="btnGuardar" type="button" value="Crear Pallet" onclick="javascript:GrabarPallet();" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="btnImprimir" type="button" value="Imprimir" style="visibility: hidden"
            onclick="javascript:Imprimir();" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFiltro" runat="server" Text="Nuevo Registro" OnClick="btnFiltro_Click" />
    </div>
    <div style="visibility: hidden;">
        <asp:Label ID="lblCodigo" runat="server" Text=""></asp:Label><asp:Label ID="lblIsMultiple"
            runat="server" Text=""></asp:Label>
    </div>
    <br />
    <br />
</asp:Content>
