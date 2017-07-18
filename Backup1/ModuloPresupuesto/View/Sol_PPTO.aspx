<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sol_PPTO.aspx.cs" Inherits="Intranet.ModuloPresupuesto.View.Sol_PPTO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script>
        function algo() {
            document.getElementById("trPreprensa32").style.display = "none";
            var select = document.getElementById("ddlPagPliego");
            var Doblez = select.options[select.selectedIndex].text;
            var PagInterior = document.getElementById("txtPaginasInterior").value;
            var select1 = document.getElementById("ddlColorInterior");
            var ColorInterior = select1.options[select1.selectedIndex].text;
            var select2 = document.getElementById("ddlMaquinaInterior");
            var MaquinaInterior = select2.options[select2.selectedIndex].text;
            var Tiraje = document.getElementById("txtTiraje").value;

            var select3 = document.getElementById("ddlGramajeInterior");
            var PapelInterior = select3.options[select3.selectedIndex].value;
            var Gramageinterior = select3.options[select3.selectedIndex].text;

            var select4 = document.getElementById("ddlGramajetapa");
            var PapelTapa = select4.options[select4.selectedIndex].value;
            var Gramagetapas = select4.options[select4.selectedIndex].text;

            var Desarrollo = document.getElementById("txtDesarrollo").value;
            var Anchobanda = document.getElementById("txtAnchobanda").value;
            var select13 = document.getElementById("ddlCantTapas");
            var PagTapas = select13.options[select13.selectedIndex].text;
            var select5 = document.getElementById("ddlColorTapa");
            var ColorTapas = select5.options[select5.selectedIndex].text;
            var select6 = document.getElementById("ddlMaquinaTapa");
            var MaquinaTapas = select6.options[select6.selectedIndex].text;
            var LargoTapas = document.getElementById("txtLargotapa").value;
            var anchoTapas = document.getElementById("txtanchoTapa").value;
            var select7 = document.getElementById("ddlBarUV");
            var BarnizUV = select7.options[select7.selectedIndex].text;
            var select8 = document.getElementById("ddlLaminado");
            var Laminado = select8.options[select8.selectedIndex].text;
            var select9 = document.getElementById("ddlDripOff");
            var DripOFF = select9.options[select9.selectedIndex].text;
            var select10 = document.getElementById("ddlTipoEncuadernacion");
            var Encuadernacion = select10.options[select10.selectedIndex].text;
            var select11 = document.getElementById("dllBarnizInterior");
            var BarnizInterior = select11.options[select11.selectedIndex].text;
            var select12 = document.getElementById("ddlBarnizTapa");
            var BarnizTapa = select12.options[select12.selectedIndex].text;

            var select13 = document.getElementById("ddlEmpresa");
            var Empresa = select13.options[select13.selectedIndex].text;

            $.ajax({
                url: "Sol_PPTO.aspx/PrePrensa",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Doblez':'" + eval(Doblez) + "','PagInterior':'" + eval(PagInterior) + "','ColorInterior':'" + ColorInterior + "','MaquinaInterior':'" + MaquinaInterior +
                        "','Tiraje':'" + Tiraje + "','PapelInterior':'" + PapelInterior + "','PapelTapa':'" + PapelTapa + "','GramajeInterior':'" + Gramageinterior + "','Desarrollo':'" + Desarrollo +
                        "','Anchobanda':'" + Anchobanda + "','PagTapas':'" + PagTapas + "','ColorTapas':'" + ColorTapas + "','MaquinaTapas':'" + MaquinaTapas + "','Gramagetapas':'" + Gramagetapas +
                        "','LargoTapas':'" + LargoTapas + "','anchoTapas':'" + anchoTapas + "','BarnizUV':'" + BarnizUV + "','Laminado':'" + Laminado + "','DripOFF':'" + DripOFF +
                        "','Encuadernacion':'" + Encuadernacion + "','BarnizInterior':'" + BarnizInterior + "','BarnizTapa':'" + BarnizTapa + "','Empresa':'" + Empresa + "'}",

                success: function (msg) {
                    document.getElementById("preprensa32pagInt").innerHTML = msg.d[0];
                    document.getElementById("preprensa24pagInt").innerHTML = msg.d[1];
                    document.getElementById("preprensa16pagInt").innerHTML = msg.d[2];
                    document.getElementById("preprensa12pagInt").innerHTML = msg.d[3];
                    document.getElementById("preprensa08pagInt").innerHTML = msg.d[4];
                    document.getElementById("preprensa04pagInt").innerHTML = msg.d[5];
                    document.getElementById("lblImpInteriorFijo").innerHTML = msg.d[6];
                    document.getElementById("lblImpInteriorVari").innerHTML = msg.d[7];
                    document.getElementById("lblPapelInteriorFijo").innerHTML = msg.d[8];
                    document.getElementById("lblPapelInteriorVari").innerHTML = msg.d[9];
                    document.getElementById("preprensatapaInt").innerHTML = msg.d[10];
                    document.getElementById("lblImpTapasFijo").innerHTML = msg.d[11];
                    document.getElementById("lblImpTapasVari").innerHTML = msg.d[12];
                    document.getElementById("lblPapelTapasFijo").innerHTML = msg.d[13];
                    document.getElementById("lblPapelTapasVari").innerHTML = msg.d[14];
                    document.getElementById("lblTermiBarUVFijo").innerHTML = msg.d[15];
                    document.getElementById("lblTermiBarUVVari").innerHTML = msg.d[16];
                    document.getElementById("lblTermiLaminVari").innerHTML = msg.d[17];
                    document.getElementById("lblDripOffFijo").innerHTML = msg.d[18];
                    document.getElementById("lblDripOffVari").innerHTML = msg.d[19];
                    document.getElementById("lblNombreEncuadernacion").innerHTML = Encuadernacion;
                    document.getElementById("lblEncuadernacionFijo").innerHTML = msg.d[20];
                    document.getElementById("lblEncuadernacionVari").innerHTML = msg.d[21];
                    document.getElementById("lblCosturaHilo32pag").innerHTML = msg.d[22];
                    document.getElementById("lblCosturaHilo24pag").innerHTML = msg.d[23];
                    document.getElementById("lblCosturaHilo16pag").innerHTML = msg.d[24];
                    document.getElementById("lblCosturaHilo12pag").innerHTML = msg.d[25];
                    document.getElementById("lblCosturaHilo08pag").innerHTML = msg.d[26];
                    document.getElementById("lblCosturaHilo04pag").innerHTML = msg.d[27];
                    document.getElementById("lblBarnizAcuosoInteriorFijo").innerHTML = msg.d[28];
                    document.getElementById("lblBarnizAcuosoInteriorVari").innerHTML = msg.d[29];
                    document.getElementById("lblBarnizAcuosoTapaFijo").innerHTML = msg.d[30];
                    document.getElementById("lblBarnizAcuosoTapaVari").innerHTML = msg.d[31];
                    document.getElementById("lblNombreBarniz").innerHTML = " " + BarnizUV;
                    document.getElementById("lblNombrelaminado").innerHTML = " " + Laminado;
                    document.getElementById("lblPlisadoTapaFijo").innerHTML = msg.d[32];
                    document.getElementById("lblPlisadoTapaVari").innerHTML = msg.d[33];
                    document.getElementById("lblEmbalaje").innerHTML = msg.d[34];
                    document.getElementById("lblSuministro").innerHTML = msg.d[35];
                    document.getElementById("lblEncajado").innerHTML = msg.d[36];
                    document.getElementById("preprensaTotpagTot").innerHTML = msg.d[37];
                    document.getElementById("lblTotalImpresion").innerHTML = msg.d[38];
                    document.getElementById("lblTotalCosturaHilo").innerHTML = msg.d[39];
                    document.getElementById("lblTotalEncuadernacion").innerHTML = msg.d[40];
                    document.getElementById("lblTotalPapel").innerHTML = msg.d[41];
                    document.getElementById("lblTotalTerminaciones").innerHTML = msg.d[42];
                    document.getElementById("lblTotalDespacho").innerHTML = msg.d[43];
                    document.getElementById("").innerHTML ) msg.d[44];
                    document.getElementById("").innerHTML ) msg.d[44];
                    document.getElementById("").innerHTML ) msg.d[44];
                    document.getElementById("").innerHTML ) msg.d[44];
                    document.getElementById("").innerHTML ) msg.d[44];
                    document.getElementById("").innerHTML ) msg.d[44];
                    document.getElementById("").innerHTML ) msg.d[44];
                    document.getElementById("").innerHTML ) msg.d[44];

                    if (msg.d[0] != "0") {
                        document.getElementById("trPreprensa32").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trPreprensa32").style.display = "none";
                    }
                    if (msg.d[1] != "0") {
                        document.getElementById("trPreprensa24").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trPreprensa24").style.display = "none";
                    }
                    if (msg.d[2] != 0) {
                        document.getElementById("trPreprensa16").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trPreprensa16").style.display = "none";
                    }
                    if (msg.d[3] != 0) {
                        document.getElementById("trPreprensa12").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trPreprensa12").style.display = "none";
                    }
                    if (msg.d[4] != 0) {
                        document.getElementById("trPreprensa08").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trPreprensa08").style.display = "none";
                    }
                    if (msg.d[5] != 0) {
                        document.getElementById("trPreprensa04").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trPreprensa04").style.display = "none";
                    }
                    if (msg.d[10] != 0) {
                        document.getElementById("trPreprensaTapas").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trPreprensa04").style.display = "none";
                    }
                    if (PapelInterior != "") {
                        document.getElementById("trPaginasInterior").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trPaginasInterior").style.display = "none";
                    }
                    if (PagTapas != "0") {
                        document.getElementById("trPaginasTapas").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trPaginasTapas").style.display = "none";
                    }
                    if (msg.d[28] != 0) {
                        document.getElementById("trBarnizInterior").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trBarnizInterior").style.display = "none";
                    }
                    if (msg.d[30] != 0) {
                        document.getElementById("trBarnizTapas").style.display = "table-row";
                    }
                    else {
                        document.getElementById("trBarnizTapas").style.display = "none";
                    }
                    if (msg.d[22] != 0) {
                        document.getElementById("trCosturaHilo32").style.display = "table-row";
                    }
                    if (msg.d[23] != 0) {
                        document.getElementById("trCosturaHilo24").style.display = "table-row";
                    }
                    if (msg.d[24] != 0) {
                        document.getElementById("trCosturaHilo16").style.display = "table-row";
                    }
                    if (msg.d[25] != 0) {
                        document.getElementById("trCosturaHilo12").style.display = "table-row";
                    }
                    if (msg.d[26] != 0) {
                        document.getElementById("trCosturaHilo08").style.display = "table-row";
                    }
                    if (msg.d[27] != 0) {
                        document.getElementById("trCosturaHilo04").style.display = "table-row";
                    }
                    if (msg.d[20] != 0) {
                        document.getElementById("trEncua").style.display = "table-row";
                    }
                    if (msg.d[8] != 0) {
                        document.getElementById("trPapelInterior").style.display = "table-row";
                    }
                    if (msg.d[13] != 0) {
                        document.getElementById("trPapelTapas").style.display = "table-row";
                    }
                    if (msg.d[16] != 0) {
                        document.getElementById("trBarnizUV").style.display = "table-row";
                    }
                    if (msg.d[17] != 0) {
                        document.getElementById("trlaminado").style.display = "table-row";
                    }
                    if (msg.d[18] != 0) {
                        document.getElementById("trDripOff").style.display = "table-row";
                    }
                    if (msg.d[32] != 0) {
                        document.getElementById("trPlisadoTapas").style.display = "table-row";
                    }
                    document.getElementById("trDespEmbalaje").style.display = "table-row";
                    document.getElementById("trDespCaja").style.display = "table-row";
                    document.getElementById("trDespEncajado").style.display = "table-row";
                    document.getElementById("trDespCMC").style.display = "table-row";
                    document.getElementById("DIVtabladetalle").style.display = "block";

                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }

        function CargaGramajePapel(Componente, TipoPapel) {
            var select = "";
            var answer = "";
            if (Componente == "Interior") {
                select = document.getElementById("<%= ddlPapelInterior.ClientID %>");
                answer = select.options[select.selectedIndex].text;
                var ddlTerritory = document.getElementById("<%= ddlGramajeInterior.ClientID %>");
                var lengthddlTerritory = ddlTerritory.length - 1;
                for (var i = lengthddlTerritory; i >= 0; i--) {
                    ddlTerritory.options[i] = null;
                }
            }
            else if (Componente=="Tapa") {
                select = document.getElementById("<%= ddlPapelTapa.ClientID %>");
                answer = select.options[select.selectedIndex].text;
                var ddlTerritory = document.getElementById("<%= ddlGramajetapa.ClientID %>");
                var lengthddlTerritory = ddlTerritory.length - 1;
                for (var i = lengthddlTerritory; i >= 0; i--) {
                    ddlTerritory.options[i] = null;
                }
            }
            $.ajax({
                url: "Sol_PPTO.aspx/CargarGramaje",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'TipoPapel':'" + TipoPapel + "','Componente':'" + Componente + "'}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        if (Componente == "Interior") {
                            $('#<%=ddlGramajeInterior.ClientID%>').append($("<option></option>").val(value.ValorPapel).html(value.Gramaje));
                        }
                        else if (Componente=="Tapa") {
                            $('#<%=ddlGramajetapa.ClientID%>').append($("<option></option>").val(value.ValorPapel).html(value.Gramaje));
                        }
                    });

                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }

        $(document).ready(function () {
            $("#ddlPapelInterior").change(function () {
                CargaGramajePapel("Interior",this.value);
            });

            $("#ddlPapelTapa").change(function () {
                CargaGramajePapel("Tapa", this.value);
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal" role="form">
    <div class="container">
        <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">Panel Prensa</a></h3>
            </div>
            <div id="collapse1" class="panel-collapse  collapse  in">
            <div class="panel-body">
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Nombre">
                        Nombre:</label>
                    <div class="col-sm-10">
                        <input id="Nombre" class="form-control" type="text" placeholder="Nombre Presupuesto" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlEmpresa">
                        Empresa:</label>
                    <div class="col-sm-7">
                        <select id="ddlEmpresa" class="form-control">
                            <option>Seleccionar</option>
                            <option>Santillana</option>
                            <option>SM Chile</option>
                            <option>Grupo Planeta Chilena</option>
                            <option>Penguin Random House</option>
                        </select>
                    </div>
                    <label class="control-label col-sm-1" for="txtTiraje">
                        Cantidad:</label>
                    <div class="col-sm-2">
                        <input id="txtTiraje" class="form-control" type="text" placeholder="Cantidad" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlFormato">
                        Formato Cerrado:</label>
                    <div class="col-sm-3">
                        <div class="input-group ">
                            <input id="txtDoblez" class="form-control" type="text" />
                            <span class="input-group-addon">X</span>
                            <input id="txtPagInt" class="form-control" type="text" />
                            <span class="input-group-addon">Cms.</span>
                        </div>
                    </div>
                    <label class="control-label col-sm-2" for="ddlPagPliego">
                        N° Pag. Pliego:</label>
                    <div class="col-sm-2">
                        <select id="ddlPagPliego" class="form-control">
                            <option>Seleccionar</option>
                            <option>8</option>
                            <option>12</option>
                            <option>16</option>
                            <option>24</option>
                            <option>32</option>
                        </select>
                    </div>
                    <label class="control-label col-sm-1" for="txtCantidadMedios">
                        Medios:</label>
                    <div class="col-sm-2">
                        <input id="txtCantidadMedios" class="form-control" type="text" placeholder="Cant.x Medios" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlTipoEncuadernacion">
                        Encuadernación:</label>
                    <div class="col-sm-6">
                        <select id="ddlTipoEncuadernacion" class="form-control">
                            <option>Seleccionar</option>
                            <option>2 Corchetes al Lomo</option>
                            <option>Entapado Hot Melt</option>
                            <option>Entapado Pur</option>
                            <option>Costura Hilo y Entapado Hot Melt</option>
                            <option>Espiral Plástico</option>
                        </select>
                    </div>
                    
                    
                </div>
            </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">Panel Interior</a></h3>
            </div>
            <div id="collapse2" class="panel-collapse collapse in">
            <div class="panel-body">
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlTipoEncuadernacion">
                        Paginas:</label>
                    <div class="col-sm-2">
                        <input id="txtPaginasInterior" class="form-control" type="text" placeholder="Paginas Interior" />
                    </div>
                    <label class="control-label col-sm-2" for="ddlColorInterior">
                        Color:</label>
                    <div class="col-sm-2">
                        <select id="ddlColorInterior" class="form-control">
                            <option>Seleccionar</option>
                            <option>1-1</option>
                            <option>2-2</option>
                            <option>4-4</option>
                            <option>5-5</option>
                        </select>
                    </div>
                    <label class="control-label col-sm-2" for="ddlMaquinaInterior">
                        Maquina:</label>
                    <div class="col-sm-2">
                        <select id="ddlMaquinaInterior" class="form-control">
                            <option>Seleccionar</option>
                            <option>Planas</option>
                            <option>Rotativas</option>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlPapelInterior">
                        Papel:</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlPapelInterior" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <label class="control-label col-sm-2" for="ddlGramajeInterior">
                        Gramaje:</label>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="ddlGramajeInterior" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="txtDesarrollo">
                        Desarrollo:</label>
                    <div class="col-sm-2">
                        <input id="txtDesarrollo" class="form-control" type="text" placeholder="Desarrollo" />
                    </div>
                    <label class="control-label col-sm-2" for="txtAnchobanda">
                        Ancho Banda:</label>
                    <div class="col-sm-2">
                        <input id="txtAnchobanda" class="form-control" type="text" placeholder="Ancho Banda" />
                    </div>
                    <label class="control-label col-sm-2" for="dllBarnizInterior">
                        Barniz:</label>
                    <div class="col-sm-2">
                        <select id="dllBarnizInterior" class="form-control">
                            <option>Sin Barniz</option>
                            <option>Tiro/Retiro</option>
                        </select>
                    </div>
                </div>
            </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">Panel Tapas</a></h3>
            </div>
            <div id="collapse3" class="panel-collapse collapse in">
            <div class="panel-body">
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlCantTapas">
                        Pliegos x Tapas:</label>
                    <div class="col-sm-2">
                        <select id="ddlCantTapas" class="form-control" >
                            <option>0</option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>6</option>
                            <option>8</option>
                        </select>
                    </div>
                    <label class="control-label col-sm-2" for="ddlColorTapa">
                        Color:</label>
                    <div class="col-sm-2">
                        <select id="ddlColorTapa" class="form-control">
                            <option>Seleccionar</option>
                            <option>4-0</option>
                            <option>4-1</option>
                            <option>4-4</option>
                        </select>
                    </div>
                    <label class="control-label col-sm-2" for="ddlMaquinaTapa">
                        Maquina:</label>
                    <div class="col-sm-2">
                        <select id="ddlMaquinaTapa" class="form-control">
                            <option>Seleccionar</option>
                            <option>Planas</option>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlPapelTapa">
                        Papel:</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlPapelTapa" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <label class="control-label col-sm-2" for="ddlGramajetapa">
                        Gramaje:</label>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="ddlGramajetapa" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="txtLargotapa">
                        Largo:</label>
                    <div class="col-sm-2">
                        <input id="txtLargotapa" class="form-control" type="text" placeholder="Largo" />
                    </div>
                    <label class="control-label col-sm-2" for="txtanchoTapa">
                        Ancho:</label>
                    <div class="col-sm-2">
                        <input id="txtanchoTapa" class="form-control" type="text" placeholder="Ancho" />
                    </div>
                    <label class="control-label col-sm-2" for="ddlBarnizTapa">
                        Barniz:</label>
                    <div class="col-sm-2">
                        <select id="ddlBarnizTapa" class="form-control">
                            <option>Sin Barniz</option>
                            <option>Tiro</option>
                            <option>Retiro</option>
                            <option>Tiro/Retiro</option>
                        </select>
                    </div>
                </div>
            </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">Panel Terminación</a></h3>
            </div>
            <div id="collapse4" class="panel-collapse collapse in">
            <div class="panel-body">
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlBarUV">
                        Barniz UV:</label>
                    <div class="col-sm-2">
                        <select id="ddlBarUV" class="form-control">
                            <option>Sin Barniz</option>
                            <option>UV Parejo</option>
                            <option>UV Selectivo</option>
                        </select>
                    </div>
                    <label class="control-label col-sm-2" for="ddlLaminado">
                        Laminado:</label>
                    <div class="col-sm-2">
                        <select id="ddlLaminado" class="form-control">
                            <option>Sin Laminado</option>
                            <option>Poli Mate</option>
                            <option>Poli Brillante</option>
                            <option>Termolaminado</option>
                        </select>
                    </div>
                    <label class="control-label col-sm-2" for="ddlQuinto">
                        5 Color:</label>
                    <div class="col-sm-2">
                        <select id="ddlQuinto" class="form-control">
                            <option>Sin Color</option>
                            <option>Oro</option>
                            <option>Plata</option>
                            <option>Flúo</option>
                            <option>PMS</option>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="ddlDripOff">
                        Drip Off:</label>
                    <div class="col-sm-2">
                        <select id="ddlDripOff" class="form-control">
                            <option>Sin Drip Off</option>
                            <option>Con Drip Off</option>
                        </select>
                    </div>
                    <label class="control-label col-sm-2" for="ddlTipoEncuadernacion">
                        Glitter:</label>
                    <div class="col-sm-2">
                        <input id="Text15" class="form-control" type="text" placeholder="Paginas Interior" />
                    </div>
                    <label class="control-label col-sm-2" for="ddlTipoEncuadernacion">
                        Cuño:</label>
                    <div class="col-sm-2">
                        <input id="Text17" class="form-control" type="text" placeholder="Paginas Interior" />
                    </div>
                </div> 
            </div>
            </div>
        </div>
        
        <button type="button" class="btn btn-primary" onclick="javascript:algo();">
            Guardar</button>
        </div>
        <div id="DIVtabladetalle" class="panel panel-default" style="display: block;">
            <div class="panel-heading">
                Tabla Detalle</div>
            <!-- Table -->
            <table class="table table-hover table-condensed">
                <thead>
                    <tr>
                        <th colspan="2">
                            Tipo Proceso
                        </th>
                        <th>
                            Costo Fijo
                        </th>
                        <th>
                            Costo Variable
                        </th>
                        <th>
                            Totales
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="2">PREPRENSA</td>
                        <td class="text-right"></td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="preprensaTotpagTot">0</label></td>
                    </tr>
                    <tr id="trPreprensa32" style="display:none;">
                        <td colspan="2" align="center">Pre prensa 32 Pág</td>
                        <td class="text-right"><label id="preprensa32pagInt">0</label></td>
                        <td></td>
                        <td class="text-right"><label id="preprensa32pagTot">0</label></td>
                    </tr>
                    <tr id="trPreprensa24" style="display:none;">
                        <td colspan="2" align="center">Pre prensa 24 Pág</td>
                        <td class="text-right"><label id="preprensa24pagInt">0</label></td>
                        <td></td>
                        <td class="text-right"><label id="preprensa24pagTot">0</label></td>
                    </tr>
                    <tr id="trPreprensa16" style="display:none;">
                        <td colspan="2" align="center">Pre prensa 16 Pág</td>
                        <td class="text-right"><label id="preprensa16pagInt">0</label></td>
                        <td></td>
                        <td class="text-right"><label id="preprensa16pagTot">0</label></td>
                    </tr>
                    <tr id="trPreprensa12" style="display:none;">
                        <td colspan="2" align="center">Pre prensa 12 Pág</td>
                        <td class="text-right"><label id="preprensa12pagInt">0</label></td>
                        <td></td>
                        <td class="text-right"><label id="preprensa12pagTot">0</label></td>
                    </tr>
                    <tr id="trPreprensa08" style="display:none;">
                        <td colspan="2" align="center">Pre prensa 8 Pág</td>
                        <td class="text-right"><label id="preprensa08pagInt">0</label></td>
                        <td></td>
                        <td class="text-right"><label id="preprensa08pagTot">0</label></td>
                    </tr>
                    <tr id="trPreprensa04" style="display:none;">
                        <td colspan="2" align="center">Pre prensa 4 Pág</td>
                        <td class="text-right"><label id="preprensa04pagInt">0</label></td>
                        <td></td>
                        <td class="text-right"><label id="preprensa04pagTot">0</label></td>
                    </tr>
                    <tr id="trPreprensaTapas" style="display:none;"> 
                        <td colspan="2" align="center">Pre prensa Tapas</td>
                        <td class="text-right"><label id="preprensatapaInt">0</label></td>
                        <td></td>
                        <td class="text-right"><label id="preprensatapaTot">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">Impresión</td>
                        <td class="text-right"></td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="lblTotalImpresion">0</label></td>
                    </tr>
                    <tr id="trPaginasInterior" style="display:none;">  
                        <td colspan="2" align="center">Páginas Interior</td>
                        <td class="text-right"><label id="lblImpInteriorFijo">0</label></td>
                        <td class="text-right"><label id="lblImpInteriorVari">0</label></td>
                        <td class="text-right"><label id="lblImpInteriorTota">0</label></td>
                    </tr>
                    <tr id="trBarnizInterior" style="display:none;">
                        <td colspan="2" align="center">Barniz Acuoso Interior</td>
                        <td class="text-right"><label id="lblBarnizAcuosoInteriorFijo">0</label></td>  
                        <td class="text-right"><label id="lblBarnizAcuosoInteriorVari">0</label></td>
                        <td class="text-right"><label id="lblBarnizAcuosoInteriorTota">0</label></td>
                    </tr>
                    <tr id="trPaginasTapas" style="display:none;">
                        <td colspan="2" align="center">Páginas Tapas</td>
                        <td class="text-right"><label id="lblImpTapasFijo">0</label></td>
                        <td class="text-right"><label id="lblImpTapasVari">0</label></td>
                        <td class="text-right"><label id="lblImpTapasTota">0</label></td>
                    </tr>
                    <tr id="trBarnizTapas" style="display:none;">
                        <td colspan="2" align="center">Barniz Acuoso Tapas</td>
                        <td class="text-right"><label id="lblBarnizAcuosoTapaFijo">0</label></td>
                        <td class="text-right"><label id="lblBarnizAcuosoTapaVari">0</label></td>
                        <td class="text-right"><label id="lblBarnizAcuosoTapaTota">0</label></td>
                    </tr>
                    <tr id="trPlisadoTapas" style="display:none;">
                        <td colspan="2" align="center">Plisado Tapas</td>
                        <td class="text-right"><label id="lblPlisadoTapaFijo">0</label></td>
                        <td class="text-right"><label id="lblPlisadoTapaVari">0</label></td>
                        <td class="text-right"><label id="Label21">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">Costura Hilo</td>
                        <td class="text-right"></td>
                        <td class="text-right"></td> 
                        <td class="text-right"><label id="lblTotalCosturaHilo">0</label></td>
                    </tr>
                    <tr id="trCosturaHilo32" style="display:none;">
                        <td colspan="2" align="center">32 Pág</td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="lblCosturaHilo32pag">0</label></td>
                        <td class="text-right"><label id="Label26">0</label></td>
                    </tr>
                    <tr id="trCosturaHilo24" style="display:none;">
                        <td colspan="2" align="center">24 Pág</td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="lblCosturaHilo24pag">0</label></td>
                        <td class="text-right"><label id="Label27">0</label></td>
                    </tr>
                    <tr id="trCosturaHilo16" style="display:none;">
                        <td colspan="2" align="center">16 Pág</td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="lblCosturaHilo16pag">0</label></td>
                        <td class="text-right"><label id="Label28">0</label></td>
                    </tr>
                    <tr id="trCosturaHilo12" style="display:none;">
                        <td colspan="2" align="center">12 Pág</td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="lblCosturaHilo12pag">0</label></td>
                        <td class="text-right"><label id="Label29">0</label></td>
                    </tr>
                    <tr id="trCosturaHilo08" style="display:none;">
                        <td colspan="2" align="center">8 Pág</td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="lblCosturaHilo08pag">0</label></td>
                        <td class="text-right"><label id="Label30">0</label></td>
                    </tr>
                    <tr id="trCosturaHilo04" style="display:none;">
                        <td colspan="2" align="center">4 Pág</td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="lblCosturaHilo04pag">0</label></td>
                        <td class="text-right"><label id="Label31">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">Encuadernación</td>
                        <td class="text-right"></td>
                        <td class="text-right"></td> 
                        <td class="text-right"><label id="lblTotalEncuadernacion">0</label></td>
                    </tr>
                    <tr id="trEncua" style="display:none;">
                        <td colspan="2" align="center"><label id="lblNombreEncuadernacion"></label></td>
                        <td class="text-right"><label id="lblEncuadernacionFijo">0</label></td>
                        <td class="text-right"><label id="lblEncuadernacionVari">0</label></td>
                        <td class="text-right"><label id="lblEncuadernacionTota">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">Despacho</td>
                        <td class="text-right"></td>
                        <td class="text-right"></td> 
                        <td class="text-right"><label id="lblTotalDespacho">0</label></td>
                    </tr>
                    <tr id="trDespEmbalaje" style="display:none;">
                        <td colspan="2" align="center">Embalaje y Despacho</td>
                        <td class="text-right"><label id="lblEmbalaje">0</label></td>
                        <td class="text-right"><label id="Label18">0</label></td>
                        <td class="text-right"><label id="Label19">0</label></td>
                    </tr>
                    <tr id="trDespCaja" style="display:none;">
                        <td colspan="2" align="center">Suministro Caja </td>
                        <td class="text-right"><label id="Label16">0</label></td>
                        <td class="text-right"><label id="lblSuministro">0</label></td>
                        <td class="text-right"><label id="Label25">0</label></td>
                    </tr>
                    <tr id="trDespEncajado" style="display:none;">
                        <td colspan="2" align="center">Encajado</td>
                        <td class="text-right"><label id="Label32">0</label></td>
                        <td class="text-right"><label id="lblEncajado">0</label></td>
                        <td class="text-right"><label id="Label34">0</label></td>
                    </tr>
                    <tr id="trDespCMC" style="display:none;">
                        <td colspan="2" align="center">CMC</td>
                        <td class="text-right"><label id="Label35">0</label></td>
                        <td class="text-right"><label id="Label36">0</label></td>
                        <td class="text-right"><label id="Label37">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">Papel</td>
                        <td class="text-right"></td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="lblTotalPapel">0</label></td>
                    </tr>
                    <tr id="trPapelInterior" style="display:none;">
                        <td colspan="2" align="center">Papel Interior</td>
                        <td class="text-right"><label id="lblPapelInteriorFijo">0</label></td>
                        <td class="text-right"><label id="lblPapelInteriorVari">0</label></td>
                        <td class="text-right"><label id="lblPapelInteriorTota">0</label></td>
                    </tr>
                    <tr id="trPapelTapas" style="display:none;">
                        <td colspan="2" align="center">Papel Tapas</td>
                        <td class="text-right"><label id="lblPapelTapasFijo">0</label></td>
                        <td class="text-right"><label id="lblPapelTapasVari">0</label></td>
                        <td class="text-right"><label id="lblPapelTapasTota">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">Terminaciones</td>
                        <td class="text-right"></td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="lblTotalTerminaciones">0</label></td>
                    </tr>
                    <tr id="trBarnizUV" style="display:none;">
                        <td colspan="2" align="center">Barniz UV<label id="lblNombreBarniz"></label></td> 
                        <td class="text-right"><label id="lblTermiBarUVFijo">0</label></td>
                        <td class="text-right"><label id="lblTermiBarUVVari">0</label></td>
                        <td class="text-right"><label id="lblTermiBarUVTota">0</label></td>
                    </tr> 
                    <tr id="trlaminado" style="display:none;">
                        <td colspan="2" align="center">Laminado<label id="lblNombrelaminado"></td>
                        <td class="text-right"><label id="lblTermiLaminFijo">0</label></td>
                        <td class="text-right"><label id="lblTermiLaminVari">0</label></td>
                        <td class="text-right"><label id="lblTermiLaminTota">0</label></td>
                    </tr>
                    <tr id="trDripOff" style="display:none;">
                        <td colspan="2" align="center">Drip Off</td>
                        <td class="text-right"><label id="lblDripOffFijo">0</label></td>
                        <td class="text-right"><label id="lblDripOffVari">0</label></td>
                        <td class="text-right"><label id="lblDripOffTota">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">SubTotal</td>
                        <td class="text-right"><label id="Label38">0</label></td>
                        <td class="text-right"><label id="Label39">0</label></td>
                        <td class="text-right"><label id="Label40">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">4% Comision</td>
                        <td class="text-right"><label id="Label41">0</label></td>
                        <td class="text-right"><label id="Label42">0</label></td>
                        <td class="text-right"><label id="Label43">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">Precio Neto</td>
                        <td class="text-right"><label id="Label44">0</label></td>
                        <td class="text-right"><label id="Label45">0</label></td>
                        <td class="text-right"><label id="Label46">0</label></td>
                    </tr>
                    <tr>
                        <td colspan="2">Precio Unitario</td>
                        <td class="text-right"></td>
                        <td class="text-right"></td>
                        <td class="text-right"><label id="Label49">0</label></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
