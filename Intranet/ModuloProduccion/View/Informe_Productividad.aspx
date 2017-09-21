<%@ Page Title="" Language="C#" MasterPageFile="~/Estructura/View/MasterAplicaciones.Master"
    AutoEventWireup="true" CodeBehind="Informe_Productividad.aspx.cs" Inherits="Intranet.ModuloProduccion.View.Informe_Productividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Estructura/Javascript/canvasjs.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
     table#tablaMaquina, th, #tablaMaquina td {
        border: 1px solid black;border-collapse: collapse;
      }
      .canvasjs-chart-credit
          {
              display:none;
          }
      @media print
       {
           page {
              size: landscape;
            }
          h1
          {
              font-size:12pt;
              margin-top: 0px;
              margin-bottom: 0px;
          }
          table#tablaMaquina, th, #tablaMaquina td 
          {
              font-family:georgia, times, serif;
              font-size:8pt
          }
          #lblMenuAplicacionesPrincipal ,#divbotones, #tablaCab , #tablaFiltro
          {
              display:none;
          }
          #divScroll
          {
                overflow-y : visible !important;
                max-height : none;
          }
          .graficos
          {
              margin-left:-150px !important;
          }
          
          #chartContainer1, #chartContainer1 .canvasjs-chart-canvas ,#chartContainer3 ,#chartContainer3 .canvasjs-chart-canvas ,#chartContainer2 ,#chartContainer2 .canvasjs-chart-canvas ,#chartContainer4 ,#chartContainer4 .canvasjs-chart-canvas
          {
              width:700px !important;
          }
       }
      
    </style>
    <script type="text/javascript">
       

        function cargarGraficos() {
            var select = document.getElementById("ContentPlaceHolder1_ddlMaquina");
            var Maquina = select.options[select.selectedIndex].text;
            var arrayTiraje = [];
            var arrayPreparacion = [];
            var arrayImproductivo = [];
            var arrayGiros = [];
            $.ajax({
                url: "Informe_Productividad.aspx/CargarDatosSemana1",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Maquina':'" + Maquina + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblMaquina").innerHTML = Maquina;
                    var data = JSON.parse(msg.d);
                    $.each(data, function (key, value) {
                        arrayTiraje.push({ label: value.DiasSemana, y: parseFloat(eval(value.HorasTiraje)) });
                        arrayPreparacion.push({ label: value.DiasSemana, y: parseFloat(eval(value.HorasPreparacion)) });
                        arrayImproductivo.push({ label: value.DiasSemana, y: parseFloat(eval(value.HorasImproductivo)) });
                        arrayGiros.push({ label: value.DiasSemana, y: parseInt(eval(value.GirosImpresion)) });
                        var lblConcatFecha = "ContentPlaceHolder1_Dia" + eval(key + 1);
                        var lblConcatHoras = "ContentPlaceHolder1_lblTHoras" + eval(key + 1);
                        var lblConcatHPre = "ContentPlaceHolder1_lblHPrepa" + eval(key + 1);
                        var lblConcatHTiraje = "ContentPlaceHolder1_lblHTiraje" + eval(key + 1);
                        var lblConcatHImpro = "ContentPlaceHolder1_lblHImpro" + eval(key + 1);
                        var lblConcatGiros = "ContentPlaceHolder1_lblGiros" + eval(key + 1);
                        var lblConcatEntradas = "ContentPlaceHolder1_lblEntradas" + eval(key + 1);
                        var lblConcatTiraje = "ContentPlaceHolder1_lblTiraje" + eval(key + 1);
                        var lblConcatEntMin = "ContentPlaceHolder1_lblEntradaMin" + eval(key + 1);
                        var lblConcatHAlmuerzo = "ContentPlaceHolder1_lblHAlmuerzo" + eval(key + 1);
                        var lblConcatHMante = "ContentPlaceHolder1_lblMantencion" + eval(key + 1);
                        var lblConcatImpresHour = "ContentPlaceHolder1_lblImpRunHour" + eval(key + 1);
                        var lblConcatImpresCreHour = "ContentPlaceHolder1_lblImpressCreHour" + eval(key + 1);
                        var lblConcatUtilozation = "ContentPlaceHolder1_lblUtilization" + eval(key + 1);
                        var lblConcatUptime = "ContentPlaceHolder1_lblUptime" + eval(key + 1);
                        var lblConcatHOperacion = "ContentPlaceHolder1_lblHOperacion" + eval(key + 1);
                        var lblConcatHPreprensa = "ContentPlaceHolder1_lblHPreprensa" + eval(key + 1);
                        var lblConcatHPapel = "ContentPlaceHolder1_lblHPapel" + eval(key + 1);
                        var lblConcatHIdle = "ContentPlaceHolder1_lblHIdle" + eval(key + 1);

                        if (eval(key + 1) <= 8) {
                            document.getElementById(lblConcatHoras).innerHTML = value.TotalHoras;
                            document.getElementById(lblConcatFecha).innerHTML = value.DiasSemana;
                            document.getElementById(lblConcatHPre).innerHTML = value.HorasPreparacion;
                            document.getElementById(lblConcatHTiraje).innerHTML = value.HorasTiraje;
                            document.getElementById(lblConcatHImpro).innerHTML = value.HorasImproductivo;
                            document.getElementById(lblConcatGiros).innerHTML = value.GirosImpresion;
                            document.getElementById(lblConcatEntradas).innerHTML = value.Entradas;
                            document.getElementById(lblConcatTiraje).innerHTML = value.Pliegos_Impresos;
                            document.getElementById(lblConcatEntMin).innerHTML = parseFloat(eval(eval(eval(value.HorasPreparacion) * 24) / eval(value.Entradas))).toFixed(2);
                            document.getElementById(lblConcatHAlmuerzo).innerHTML = value.Imp_Almuerzo;
                            document.getElementById(lblConcatHMante).innerHTML = value.Imp_Mantenimiento;
                            document.getElementById(lblConcatImpresHour).innerHTML = parseInt(eval(eval(value.GirosImpresion) / eval(value.HorasTiraje)));
                            document.getElementById(lblConcatImpresCreHour).innerHTML = parseInt(eval(eval(value.GirosImpresion) / eval(value.TotalHoras)));
                            document.getElementById(lblConcatUtilozation).innerHTML = parseInt((eval(value.HorasPreparacion) + eval(value.HorasTiraje)) * 100 / eval(value.TotalHoras)) + "%";
                            document.getElementById(lblConcatUptime).innerHTML = parseInt((eval(value.HorasTiraje) * 100) / eval(value.TotalHoras)) + "%";
                            document.getElementById(lblConcatHOperacion).innerHTML = value.Imp_Operacion;
                            document.getElementById(lblConcatHPreprensa).innerHTML = value.Imp_Preprensa;
                            document.getElementById(lblConcatHPapel).innerHTML = value.Imp_Papel;
                            document.getElementById(lblConcatHIdle).innerHTML = value.Imp_SinTrabajo;
                        }

                    });
                    var chart = new CanvasJS.Chart("chartContainer1", {
                        title: {
                            text: "Makeready Hours / Day",
                            fontSize: 24
                        },
                        data: [{
                            type: "line",
                            dataPoints: arrayPreparacion
                        }]
                    });
                    chart.render();

                    var chart2 = new CanvasJS.Chart("chartContainer2", {
                        title: {
                            text: "Run Hours / Day",
                            fontSize: 24
                        },
                        data: [{
                            type: "line",
                            dataPoints: arrayTiraje
                        }]
                    });
                    chart2.render();

                    var chart3 = new CanvasJS.Chart("chartContainer3", {
                        title: {
                            text: "Gross Impressions / Day",
                            fontSize: 24
                        },
                        data: [{
                            type: "line",
                            dataPoints: arrayGiros
                        }]
                    });
                    chart3.render();

                    var chart4 = new CanvasJS.Chart("chartContainer4", {
                        title: {
                            text: "Delay Hours / Day",
                            fontSize: 24
                        },
                        data: [{
                            type: "line",
                            dataPoints: arrayImproductivo
                        }]
                    });
                    chart4.render();
                    cargarDatosWeek1();
                    cargarDatosWeek4();
                    cargarDatosYear();
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });

        }

        function cargarDatosWeek1() {
            var select = document.getElementById("ContentPlaceHolder1_ddlMaquina");
            var Maquina = select.options[select.selectedIndex].text;
            $.ajax({
                url: "Informe_Productividad.aspx/CargarDatosAnuales",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Maquina':'" + Maquina + "','Procedimiento':'1'}",
                success: function (msg) {
                    var data = JSON.parse(msg.d);
                    $.each(data, function (key, value) {
                        document.getElementById("ContentPlaceHolder1_DiaSemana1").innerHTML = value.DiasSemana;
                        document.getElementById("ContentPlaceHolder1_lblTHorasS1").innerHTML = value.TotalHoras;
                        document.getElementById("ContentPlaceHolder1_lblHPrepaS1").innerHTML = value.HorasPreparacion;
                        document.getElementById("ContentPlaceHolder1_lblHTirajeS1").innerHTML = value.HorasTiraje;
                        document.getElementById("ContentPlaceHolder1_lblHImproS1").innerHTML = value.HorasImproductivo;
                        document.getElementById("ContentPlaceHolder1_lblGirosS1").innerHTML = value.GirosImpresion;
                        document.getElementById("ContentPlaceHolder1_lblImpressWeekS1").innerHTML = value.GirosImpresion;
                        document.getElementById("ContentPlaceHolder1_lblTirajes1").innerHTML = value.Pliegos_Impresos;
                        document.getElementById("ContentPlaceHolder1_lblEntradass1").innerHTML = value.Entradas;
                        document.getElementById("ContentPlaceHolder1_lblMakeWeekS1").innerHTML = value.Entradas;
                        document.getElementById("ContentPlaceHolder1_lblEntradaMins1").innerHTML = "";
                        document.getElementById("ContentPlaceHolder1_lblHAlmuerzos1").innerHTML = value.Imp_Almuerzo;
                        document.getElementById("ContentPlaceHolder1_lblMantencions1").innerHTML = value.Imp_Mantenimiento;
                        document.getElementById("ContentPlaceHolder1_lblHOperacions1").innerHTML = value.Imp_Operacion;
                        document.getElementById("ContentPlaceHolder1_lblHPreprensas1").innerHTML = value.Imp_Preprensa;
                        document.getElementById("ContentPlaceHolder1_lblHPapels1").innerHTML = value.Imp_Papel;
                        document.getElementById("ContentPlaceHolder1_lblHIdles1").innerHTML = value.Imp_SinTrabajo;
                        document.getElementById("ContentPlaceHolder1_lblImpRunHours1").innerHTML = parseInt(eval(eval(value.GirosImpresion) / eval(value.HorasTiraje)));
                        document.getElementById("ContentPlaceHolder1_lblImpressCreHours1").innerHTML = parseInt(eval(eval(value.GirosImpresion) / eval(value.TotalHoras)));
                        document.getElementById("ContentPlaceHolder1_lblUtilizations1").innerHTML = parseInt((eval(value.HorasPreparacion) + eval(value.HorasTiraje)) * 100 / eval(value.TotalHoras)) + "%";
                        document.getElementById("ContentPlaceHolder1_lblUptimes1").innerHTML = parseInt((eval(value.HorasTiraje) * 100) / eval(value.TotalHoras)) + "%";
                        // }
                    });
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });

        }

        function cargarDatosWeek4() {
            var select = document.getElementById("ContentPlaceHolder1_ddlMaquina");
            var Maquina = select.options[select.selectedIndex].text;
            $.ajax({
                url: "Informe_Productividad.aspx/CargarDatosAnuales",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Maquina':'" + Maquina + "','Procedimiento':'2'}",
                success: function (msg) {
                    var data = JSON.parse(msg.d);
                    $.each(data, function (key, value) {
                        document.getElementById("ContentPlaceHolder1_DiaSemana4").innerHTML = value.DiasSemana;
                        document.getElementById("ContentPlaceHolder1_lblTHorasS4").innerHTML = value.TotalHoras;
                        document.getElementById("ContentPlaceHolder1_lblHPrepaS4").innerHTML = value.HorasPreparacion;
                        document.getElementById("ContentPlaceHolder1_lblHTirajeS4").innerHTML = value.HorasTiraje;
                        document.getElementById("ContentPlaceHolder1_lblHImproS4").innerHTML = value.HorasImproductivo;
                        document.getElementById("ContentPlaceHolder1_lblGirosS4").innerHTML = value.GirosImpresion;
                        document.getElementById("ContentPlaceHolder1_lblImpressWeekS4").innerHTML = parseInt(eval(value.GirosImpresion) / 4);
                        document.getElementById("ContentPlaceHolder1_lblTirajes4").innerHTML = value.Pliegos_Impresos;
                        document.getElementById("ContentPlaceHolder1_lblEntradass4").innerHTML = value.Entradas;
                        document.getElementById("ContentPlaceHolder1_lblMakeWeekS4").innerHTML = parseInt(eval(value.Entradas) / 4);
                        document.getElementById("ContentPlaceHolder1_lblEntradaMins4").innerHTML = "";
                        document.getElementById("ContentPlaceHolder1_lblHAlmuerzos4").innerHTML = value.Imp_Almuerzo;
                        document.getElementById("ContentPlaceHolder1_lblMantencions4").innerHTML = value.Imp_Mantenimiento;
                        document.getElementById("ContentPlaceHolder1_lblHOperacions4").innerHTML = value.Imp_Operacion;
                        document.getElementById("ContentPlaceHolder1_lblHPreprensas4").innerHTML = value.Imp_Preprensa;
                        document.getElementById("ContentPlaceHolder1_lblHPapels4").innerHTML = value.Imp_Papel;
                        document.getElementById("ContentPlaceHolder1_lblHIdles4").innerHTML = value.Imp_SinTrabajo;
                        document.getElementById("ContentPlaceHolder1_lblImpRunHours4").innerHTML = parseInt(eval(eval(value.GirosImpresion) / eval(value.HorasTiraje)));
                        document.getElementById("ContentPlaceHolder1_lblImpressCreHours4").innerHTML = parseInt(eval(eval(value.GirosImpresion) / eval(value.TotalHoras)));
                        document.getElementById("ContentPlaceHolder1_lblUtilizations4").innerHTML = parseInt((eval(value.HorasPreparacion) + eval(value.HorasTiraje)) * 100 / eval(value.TotalHoras)) + "%";
                        document.getElementById("ContentPlaceHolder1_lblUptimes4").innerHTML = parseInt((eval(value.HorasTiraje) * 100) / eval(value.TotalHoras)) + "%";
                    });
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });

        }

        function cargarDatosYear() {
            var select = document.getElementById("ContentPlaceHolder1_ddlMaquina");
            var Maquina = select.options[select.selectedIndex].text;
            $.ajax({
                url: "Informe_Productividad.aspx/CargarDatosAnuales",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Maquina':'" + Maquina + "','Procedimiento':'3'}",
                success: function (msg) {
                    var data = JSON.parse(msg.d);
                    $.each(data, function (key, value) {
                        document.getElementById("ContentPlaceHolder1_DiaAnual").innerHTML = value.DiasSemana;
                        document.getElementById("ContentPlaceHolder1_lblTHorasAnual").innerHTML = value.TotalHoras;
                        document.getElementById("ContentPlaceHolder1_lblHPrepaAnual").innerHTML = value.HorasPreparacion;
                        document.getElementById("ContentPlaceHolder1_lblHTirajeAnual").innerHTML = value.HorasTiraje;
                        document.getElementById("ContentPlaceHolder1_lblHImproAnual").innerHTML = value.HorasImproductivo;
                        document.getElementById("ContentPlaceHolder1_lblGirosAnual").innerHTML = value.GirosImpresion;
                        document.getElementById("ContentPlaceHolder1_lblImpressWeekAnual").innerHTML = parseInt(eval(value.GirosImpresion) / 52);
                        document.getElementById("ContentPlaceHolder1_lblTirajeAnual").innerHTML = value.Pliegos_Impresos;
                        document.getElementById("ContentPlaceHolder1_lblEntradasAnual").innerHTML = value.Entradas;
                        document.getElementById("ContentPlaceHolder1_lblMakeWeekAnual").innerHTML = parseInt(eval(value.Entradas) / 52);
                        document.getElementById("ContentPlaceHolder1_lblEntradaMinAnual").innerHTML = "";
                        document.getElementById("ContentPlaceHolder1_lblHAlmuerzoAnual").innerHTML = value.Imp_Almuerzo;
                        document.getElementById("ContentPlaceHolder1_lblMantencionAnual").innerHTML = value.Imp_Mantenimiento;
                        document.getElementById("ContentPlaceHolder1_lblHOperacionAnual").innerHTML = value.Imp_Operacion;
                        document.getElementById("ContentPlaceHolder1_lblHPreprensaAnual").innerHTML = value.Imp_Preprensa;
                        document.getElementById("ContentPlaceHolder1_lblHPapelAnual").innerHTML = value.Imp_Papel;
                        document.getElementById("ContentPlaceHolder1_lblHIdleAnual").innerHTML = value.Imp_SinTrabajo;
                        document.getElementById("ContentPlaceHolder1_lblImpRunHourAnual").innerHTML = parseInt(eval(eval(value.GirosImpresion) / eval(value.HorasTiraje)));
                        document.getElementById("ContentPlaceHolder1_lblImpressCreHourAnual").innerHTML = parseInt(eval(eval(value.GirosImpresion) / eval(value.TotalHoras)));
                        document.getElementById("ContentPlaceHolder1_lblUtilizationAnual").innerHTML = parseInt((eval(value.HorasPreparacion) + eval(value.HorasTiraje)) * 100 / eval(value.TotalHoras)) + "%";
                        document.getElementById("ContentPlaceHolder1_lblUptimeAnual").innerHTML = parseInt((eval(value.HorasTiraje) * 100) / eval(value.TotalHoras)) + "%";
                    });
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });

        }
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tablaFiltro" style="background-color: #EEE; border: 1px solid #999; padding: 5px;
        margin-bottom: 5px; border-radius: 10px 10px 10px 10px;" align="center" width="945px;">
        <tr>
            <td>
                Seccion
            </td>
            <td>
                <asp:DropDownList ID="ddlSeccion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSeccion_SelectedIndexChanged">
                    <asp:ListItem>Todas</asp:ListItem>
                    <asp:ListItem>Rotativas</asp:ListItem>
                    <asp:ListItem>Planas</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Maquina
            </td>
            <td>
                <asp:DropDownList ID="ddlMaquina" runat="server">
                    <asp:ListItem>Seleccione...</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 100px;" colspan="2">
                <div style="margin-left: 17px;">
                    <asp:Button ID="btnFiltro" runat="server" Text="Filtrar" Width="73px" OnClick="btnFiltro_Click"
                        Style="height: 26px" />
                </div>
            </td>
        </tr>
    </table>
    <div id="divbotones" style="text-align: right; width: 100%; margin-top: -20px;">
        <a title="Imprimir" onclick="javascript:print();">
            <img alt="" src="../../Images/print-message.jpg" height="20px" width="20px" />Imprimir</a>
    </div>
    <div id="divScroll" style="overflow-y: auto; max-height: 790px;">
        <table id="tablaMaquina" style="border-style: groove; border-width: thin; width: 98.8%;"
            align="center">
            <thead>
                <tr>
                    <td colspan="14" align="center" style="border-style: groove; border-width: thin">
                        <h1>
                            <asp:Label ID="lblMaquina" runat="server" Text=""></asp:Label></h1>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2" style="width: 260px;">
                    </td>
                    <td align="center">
                        <strong>Año</strong>
                    </td>
                    <td align="center">
                        <strong>4 Semanas</strong>
                    </td>
                    <td align="center">
                        <strong>Semana</strong>
                    </td>
                    <td align="center" colspan="8">
                        <strong>Diariamente</strong>
                    </td>
                    <td align="center" colspan="2">
                        <strong>Target</strong>
                    </td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:Label ID="DiaAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="DiaSemana4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="DiaSemana1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Dia1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Dia2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Dia3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Dia4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Dia5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Dia6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Dia7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Dia8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </thead>
            <tbody align="right">
                <tr>
                    <td>
                        Total Horas
                    </td>
                    <td>
                        <asp:Label ID="lblTHorasAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHorasS4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHorasS1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHoras1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHoras2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHoras3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHoras4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHoras5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHoras6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHoras7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTHoras8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Horas Preparación
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepaAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepaS4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepaS1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepa1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepa2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepa3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepa4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepa5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepa6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepa7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPrepa8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Horas Tiraje
                    </td>
                    <td>
                        <asp:Label ID="lblHTirajeAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTirajeS4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTirajeS1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTiraje1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTiraje2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTiraje3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTiraje4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTiraje5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTiraje6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTiraje7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHTiraje8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Horas Improductivas
                    </td>
                    <td>
                        <asp:Label ID="lblHImproAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImproS4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImproS1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImpro1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImpro2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImpro3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImpro4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImpro5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImpro6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImpro7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHImpro8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Impresiones (Giros)
                    </td>
                    <td>
                        <asp:Label ID="lblGirosAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGirosS4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGirosS1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGiros1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGiros2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGiros3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGiros4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGiros5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGiros6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGiros7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGiros8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Promedio Impresiones /Semana
                    </td>
                    <td>
                        <asp:Label ID="lblImpressWeekAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressWeekS4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressWeekS1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Impresiones Netas (Buenos)
                    </td>
                    <td>
                        <asp:Label ID="lblTirajeAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTirajes4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTirajes1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTiraje1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTiraje2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTiraje3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTiraje4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTiraje5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTiraje6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTiraje7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTiraje8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        N° Preparaciones
                    </td>
                    <td>
                        <asp:Label ID="lblEntradasAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradass4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradass1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradas1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradas2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradas3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradas4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradas5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradas6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradas7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradas8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Promedio preparaciones /Semana
                    </td>
                    <td>
                        <asp:Label ID="lblMakeWeekAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMakeWeekS4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMakeWeekS1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Minutos/Preparación
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMinAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMins4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMins1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMin1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMin2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMin3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMin4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMin5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMin6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMin7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntradaMin8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Giros /Preparación
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label81" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label82" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label83" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label84" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label85" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label86" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label87" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label88" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Run Waste
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        WASTE Over Run (over NET QTY)
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label97" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label98" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label99" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label100" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label101" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label102" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label103" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label104" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Gross - Net
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label105" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label106" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label107" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label108" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label109" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label110" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label111" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label112" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Total Waste
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label113" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label114" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label115" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label116" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label117" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label118" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label119" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label120" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Utilization (MR + Run vs. Crewed Hours)
                    </td>
                    <td>
                        <asp:Label ID="lblUtilizationAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilizations4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilizations1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilization1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilization2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilization3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilization4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilization5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilization6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilization7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUtilization8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Uptime % (Run vs. Crewed Hours)
                    </td>
                    <td>
                        <asp:Label ID="lblUptimeAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptimes4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptimes1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptime1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptime2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptime3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptime4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptime5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptime6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptime7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUptime8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Impressions / Run Hour
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHourAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHours4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHours1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHour1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHour2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHour3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHour4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHour5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHour6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHour7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpRunHour8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Gross Impressions / Crewed Hour
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHourAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHours4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHours1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHour1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHour2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHour3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHour4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHour5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHour6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHour7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImpressCreHour8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Colación
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzoAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzos4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzos1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzo1" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzo2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzo3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzo4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzo5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzo6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzo7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHAlmuerzo8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Press Operations
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacionAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacions4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacions1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacion1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacion2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacion3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacion4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacion5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacion6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacion7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHOperacion8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Prepress
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensaAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensas4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensas1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensa1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensa2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensa3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensa4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensa5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensa6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensa7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPreprensa8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Paper
                    </td>
                    <td>
                        <asp:Label ID="lblHPapelAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapels4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapels1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapel1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapel2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapel3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapel4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapel5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapel6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapel7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHPapel8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mantenimento
                    </td>
                    <td>
                        <asp:Label ID="lblMantencionAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencions4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencions1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencion1" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencion2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencion3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencion4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencion5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencion6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencion7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMantencion8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Idle
                    </td>
                    <td>
                        <asp:Label ID="lblHIdleAnual" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdles4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdles1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdle1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdle2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdle3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdle4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdle5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdle6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdle7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblHIdle8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </tbody>
        </table>
        <table style="width: 98.8%;" align="center">
            <tr>
                <td style="width: 50%; border: 1px solid #bbbbbb; border-collapse: collapse;">
                    <div id="chartContainer1" style="height: 280px; width: 100%;">
                    </div>
                </td>
                <td class="graficos" style="width: 50%; border: 1px solid #bbbbbb; border-collapse: collapse;">
                    <div id="chartContainer2" style="height: 280px; width: 100%;">
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 50%; border: 1px solid #bbbbbb; border-collapse: collapse;">
                    <div id="chartContainer3" style="height: 280px; width: 100%;">
                    </div>
                </td>
                <td class="graficos" style="width: 50%; border: 1px solid #bbbbbb; border-collapse: collapse;">
                    <div id="chartContainer4" style="height: 280px; width: 100%;">
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
