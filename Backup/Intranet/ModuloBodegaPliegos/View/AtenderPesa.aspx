<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="AtenderPesa.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.AtenderPesa" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        
.divTitulo{
    background: linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%);  
    background: -moz-linear-gradient(top, #D3D7DA 0%, #E2EBF4 100%); 
    background: -webkit-linear-gradient(top, #D3D7DA 0%,#E2EBF4 100%);
    font-weight: bold;
    padding-top: 5px;
    padding-bottom: 5px;
    border: 1px solid #959595;
    text-align: left;
    color:#003e7e;
}
.divSeccion{
    padding-top: 10px;
    padding-bottom: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
}
    .style2
    {
        width: 91px;
    }
    .style3
    {
        width: 243px;
    }
    .style4
    {
        width: 125px;
    }
    .style5
    {
        width: 179px;
    }
    .style6
    {
        width: 105px;
    }
    .style7 
    {
        width: 301px;
    }
    .style8
    {
        width: 208px;
    }
    .style9
    {
        width: 146px;
    }
    </style>
    <script  type="text/javascript" language="javascript">
        $(document).ready(function () {
            document.getElementById("form1").onsubmit = function () {
                return false;
            }
                $("#ContentPlaceHolder1_txtAnchoD").change(function () {
                var anc= document.getElementById("<%= txtAnchoD.ClientID%>").value;
                var larg =document.getElementById("<%= txtLargoD.ClientID%>").value;
                var sk=document.getElementById("ContentPlaceHolder1_lblSKUD").innerHTML;
                 CargaSKUaSeleccionar(sk,anc,larg);

                 });

                $("#ContentPlaceHolder1_txtLargoD").change(function () {
                var anc= document.getElementById("<%= txtAnchoD.ClientID%>").value;
                var larg =document.getElementById("<%= txtLargoD.ClientID%>").value;
                var sk=document.getElementById("ContentPlaceHolder1_lblSKUD").innerHTML;
                 CargaSKUaSeleccionar(sk,anc,larg);

                 });
                $("#ContentPlaceHolder1_txtPliegos").change(function () {
                       CalculaKilosGuillotina();
                 });
                $("#ContentPlaceHolder1_txtPliegosD").change(function () {
                       CalculaKilosDimensionadora();
                 });
        });
        function CalculaKilosGuillotina(){
                 var pliegos=eval( document.getElementById("<%= txtPliegos.ClientID%>").value);
                 var Largo=eval(document.getElementById("ContentPlaceHolder1_lblFLargo").innerHTML);
                 var Gram=eval(document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML);
                 var Anch=eval(document.getElementById("ContentPlaceHolder1_lblFancho").innerHTML);
                 
                 var calculapeso=0;
                 calculapeso=((Gram*Largo*Anch)/1000000000)*pliegos;
                 document.getElementById("<%= txtPeso.ClientID%>").value=calculapeso.toFixed(2);
        }
        function CalculaKilosDimensionadora(){
                 var pliegos=eval( document.getElementById("<%= txtPliegosD.ClientID%>").value);
                 var Largo=eval( document.getElementById("<%= txtLargoD.ClientID%>").value);
                 var Gram=eval(document.getElementById("ContentPlaceHolder1_lblGramajeD").innerHTML);
                 var Anch=eval( document.getElementById("<%= txtAnchoD.ClientID%>").value);
                 
                 var calculapeso=0;
                 calculapeso=((Gram*Largo*Anch)/1000000000)*pliegos;
                 document.getElementById("<%= txtPesoD.ClientID%>").value=calculapeso.toFixed(2);
        }
        function Cortadora() {
            document.getElementById('btnCortadora').style.backgroundColor = '#0078AD';
            document.getElementById('btnDimensionadora').style.backgroundColor = '#C0C0C0';
            document.getElementById("divCortadora").style.display = "block";
            document.getElementById("divDimensionadora").style.display = "none";   
        }
        function Dimensionadora() {
            document.getElementById('btnCortadora').style.backgroundColor  = '#C0C0C0';
            document.getElementById('btnDimensionadora').style.backgroundColor = '#0078AD';
            document.getElementById("divCortadora").style.display = "none";
            document.getElementById("divDimensionadora").style.display = "block";
        }
        function Atender(idcorte,ot, componente, sku, Folio,FolioAnterior,procedencia,costomedio) {
           if(procedencia=='DIMENSIONADORA' && eval(costomedio)==0){
                alert('¡Aun no se ha termino de cortar la solicitud!');
                location.href='AtenderPesa.aspx?id=3&Cat=10';
            }
            else{
                $.ajax({
                url: "AtenderPesa.aspx/CargaSolicitud",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDCorte':'"+idcorte+"','OT':'" + ot + "','Componente':'" + componente + "','SKU':'" + sku + "','FolioOrigen':'"+Folio+"','FolioAnterior':'"+FolioAnterior+"'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblOT").innerHTML = msg.d[0];
                    document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML = msg.d[2];
                    document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML = msg.d[3];
                    document.getElementById("ContentPlaceHolder1_lblCodigo").innerHTML = msg.d[4];
                    document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML = msg.d[5];
                    document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML = msg.d[6];
                    document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML = msg.d[7];
                    document.getElementById("ContentPlaceHolder1_lblCantidad").innerHTML = msg.d[8];
                    //document.getElementById("ContentPlaceHolder1_lblTotalSolicitado").innerHTML = msg.d[8];
                    document.getElementById("ContentPlaceHolder1_lblTotalCreado").innerHTML = msg.d[9];
                    document.getElementById("ContentPlaceHolder1_lblTotalFaltante").innerHTML = msg.d[10];
                    document.getElementById("ContentPlaceHolder1_lblFancho").innerHTML=msg.d[12];
                    document.getElementById("ContentPlaceHolder1_lblFLargo").innerHTML=msg.d[13];
                    document.getElementById("divSolicitudesCortadora").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_lblFolioGuillotina").innerHTML = Folio;
                    document.getElementById("ContentPlaceHolder1_lblFolioOrigenCorte").innerHTML = FolioAnterior;
                    document.getElementById("ContentPlaceHolder1_lblProcedencia").innerHTML=procedencia;
                    document.getElementById("ContentPlaceHolder1_lblIDCorte").innerHTML=idcorte;
                    CargarFaltantesGuillotina(idcorte,FolioAnterior);
                    CerrarPallet();
                    document.getElementById("divDatosSolicitud").style.display = "block";
                    document.getElementById("divSolicitudDimensionadora").style.display = "none";
                    //CargaSKUSalida(msg.d[11],msg.d[5],msg.d[6],msg.d[7],procedencia);
                    CargaSKUSalida(msg.d[11],msg.d[5],msg.d[12],msg.d[13],procedencia);
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
            }

        }
        function CargaSKUSalida(SKU,Gramaje,Ancho,Largo,procedencia){
                $.ajax({
                url: "AtenderPesa.aspx/CargarSKUSalida",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'SKU':'" + SKU + "','Gramaje':'"+eval(Gramaje)+"','Ancho':'"+eval(Ancho)+"','Largo':'"+eval(Largo)+"','Procedencia':'"+procedencia+"'}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        $('#<%=ddlSKUSalida.ClientID%>').append($("<option></option>").val(value.CodigoProducto).html(value.Papel));

                    });
                },
                error: function () {
                    alert('¡Error al cargar Componentes!');
                }
            });
             
        }
        function VerPallet() {
            document.getElementById("Registros").style.display = 'block';
            document.getElementById("Registros2").style.display = 'block';
            CargaPalletCreados();
        }
        function CerrarPallet() {
            document.getElementById("Registros").style.display = 'none';
            document.getElementById("Registros2").style.display = 'none';

        }
        function NuevaSolicitud() {
            location.href='AtenderPesa.aspx?id=3&Cat=10';
        }
        function CrearPallet(tipo) {
            var OT = document.getElementById("ContentPlaceHolder1_lblOT").innerHTML;
            var NombreOT = document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML;
            var comp = document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML;

            var select2 = document.getElementById("<%= ddlSKUSalida.ClientID %>");
            var Codigo = select2.options[select2.selectedIndex].value;
            var Papel=select2.options[select2.selectedIndex].text;

            var procedencia= document.getElementById("ContentPlaceHolder1_lblProcedencia").innerHTML;
            var ancho = document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML;
            var largo = document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML;
            var gramaje = document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML;
            var asignadoPliegos = document.getElementById("<%= txtPliegos.ClientID %>").value;
            var asignadoPeso = document.getElementById("<%= txtPeso.ClientID %>").value;
            var Faltante = document.getElementById("ContentPlaceHolder1_lblTotalFaltante").innerHTML;
            var loc = document.location.href;
            var folioOrigen = document.getElementById("ContentPlaceHolder1_lblFolioGuillotina").innerHTML;
            var folioAnterior = document.getElementById("ContentPlaceHolder1_lblFolioOrigenCorte").innerHTML;
            var Usuario = '<%= Session["Usuario"] %>';
            $.ajax({
                url: "AtenderPesa.aspx/CrearPallet",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OT':'" + OT + "','NombreOT':'" + NombreOT + "','Comp':'" + comp + "','Codigo':'" + Codigo + "','Papel':'" + Papel +
                "','Ancho':'" + eval(ancho) + "','Largo':'" + eval(largo) + "','Gramaje':'" + eval(gramaje) + "','Cantidad':'" + eval(asignadoPliegos) +
                "','Peso':'" + eval(asignadoPeso) + "','Faltante':'" + eval(Faltante) + "','loc':'" + loc + "','FolioOrigen':'" + folioOrigen + "','Tipo':'"+tipo+"','Usuario':'"+Usuario+"','FolioAnterior':'"+folioAnterior+"','Procedencia':'"+procedencia+"'}",
                success: function (msg) {
                    if (msg.d[0] == 'OK') {

                        window.open('EtiquetaBP.aspx?Pro='+msg.d[2]+'&Folio=' + msg.d[1], 'Impresion Pallet Bodega Pliegos', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
                        alert('¡Pallet Generado Correctamente!');
                        if(tipo=='Cerrar'){
                            location.href='AtenderPesa.aspx?id=3&Cat=10';
                        }else{
                            
                            CargaPalletCreados();
                            CargarFaltantesGuillotina(folioOrigen,folioAnterior);
                            document.getElementById("divSolicitudesCortadora").style.display = "none";
                            document.getElementById("<%= txtPliegos.ClientID%>").value = "";
                            document.getElementById("<%= txtPeso.ClientID%>").value = "";
                        }
                    } else {
                        alert(msg.d[0]);
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function CrearPallet2(tipo) {
            var select2 = document.getElementById("<%= ddlSKUSalida.ClientID %>");
            var Codigo = select2.options[select2.selectedIndex].value;
            var Papel=select2.options[select2.selectedIndex].text;
            var asignadoPliegos = document.getElementById("<%= txtPliegos.ClientID %>").value;
            var asignadoPeso = document.getElementById("<%= txtPeso.ClientID %>").value;
            var Faltante = document.getElementById("ContentPlaceHolder1_lblTotalFaltante").innerHTML;
            var idCorte=document.getElementById("ContentPlaceHolder1_lblIDCorte").innerHTML;
            var Usuario = '<%= Session["Usuario"] %>';
            $.ajax({
                url: "AtenderPesa.aspx/CrearPallet",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDCorte':'"+idCorte+"','Pliegos':'"+eval(asignadoPliegos)+"','Peso':'"+eval(asignadoPeso)+"','Tipo':'"+tipo+"','Faltante':'"+eval(Faltante)+"','Usuario':'"+Usuario+"','SKUSalida':'"+Codigo+"'}",
                success: function (msg) {
                    if (msg.d[0] == 'OK') {
                        window.open('EtiquetaBP.aspx?Pro='+msg.d[2]+'&Folio=' + msg.d[1], 'Impresion Pallet Bodega Pliegos', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
                        alert('¡Pallet Generado Correctamente!');
                        if(tipo=='Cerrar'){
                            location.href='AtenderPesa.aspx?id=3&Cat=10';
                        }else{
                            
//                            CargaPalletCreados();
//                            CargarFaltantesGuillotina(folioOrigen,folioAnterior);
//                            document.getElementById("divSolicitudesCortadora").style.display = "none";
//                            document.getElementById("<%= txtPliegos.ClientID%>").value = "";
//                            document.getElementById("<%= txtPeso.ClientID%>").value = "";
                        }
                    } else {
                        alert(msg.d[0]);
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function ReCargarTablaGuillotina() {
            var OT = document.getElementById("ContentPlaceHolder1_lblOT").innerHTML;
            var comp = document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML;
            var skk = document.getElementById("ContentPlaceHolder1_lblCodigo").innerHTML;
            $.ajax({
                url: "AtenderPesa.aspx/CargaSolicitud",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OT':'" + OT + "','Componente':'" + comp + "','SKU':'" + skk + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblOT").innerHTML = msg.d[0];
                    document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML = msg.d[2];
                    document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML = msg.d[3];
                    document.getElementById("ContentPlaceHolder1_lblCodigo").innerHTML = msg.d[4];
                    document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML = msg.d[5];
                    document.getElementById("ContentPlaceHolder1_lblAncho").innerHTML = msg.d[6];
                    document.getElementById("ContentPlaceHolder1_lblLargo").innerHTML = msg.d[7];
                    document.getElementById("ContentPlaceHolder1_lblCantidad").innerHTML = msg.d[8];
                    document.getElementById("ContentPlaceHolder1_lblTotalSolicitado").innerHTML = msg.d[8];
                    document.getElementById("ContentPlaceHolder1_lblTotalCreado").innerHTML = msg.d[9];
                    document.getElementById("ContentPlaceHolder1_lblTotalFaltante").innerHTML = msg.d[10];
                    document.getElementById("divSolicitudesCortadora").style.display = "none";
                    document.getElementById("<%= txtPliegos.ClientID%>").value = "";
                    document.getElementById("<%= txtPeso.ClientID%>").value = "";
                    CerrarPallet();
                },
                error: function () {
                   // alert('¡Ha Ocurrido un Error!');
                   location.href='AtenderPesa.aspx?id=3&Cat=10';
                }
            });
        }
        function CargaPalletCreados() {
            var Fol = document.getElementById("ContentPlaceHolder1_lblFolioGuillotina").innerHTML;
            var OT = document.getElementById("ContentPlaceHolder1_lblOT").innerHTML;
            var COMPO = document.getElementById("ContentPlaceHolder1_lblComponente").innerHTML;
            $.ajax({
                url: "AtenderPesa.aspx/CargaPalletCreados",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Folio':'" + Fol + "','OT':'"+OT+"','Componente':'"+COMPO+"'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblPalletCreadoG").innerHTML = msg.d;
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }

        function Procesar(Folio, id) {
            $.ajax({
                url: "AtenderPesa.aspx/CargaSolicitudTrabajo",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDTrabajo':'" + id + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblOTD").innerHTML = msg.d[0];
                    document.getElementById("ContentPlaceHolder1_lblNombreOTD").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblComponenteD").innerHTML = msg.d[2];
                    document.getElementById("ContentPlaceHolder1_lblPapelD").innerHTML = msg.d[3];
                    document.getElementById("ContentPlaceHolder1_lblSKUD").innerHTML = msg.d[4];
                    document.getElementById("ContentPlaceHolder1_lblGramajeD").innerHTML = msg.d[5];
                    document.getElementById("ContentPlaceHolder1_lblAnchoD").innerHTML = msg.d[6];
                    document.getElementById("ContentPlaceHolder1_lblLargoD").innerHTML = msg.d[7];
                    document.getElementById("ContentPlaceHolder1_lblAsignadoD").innerHTML = msg.d[8];


                    document.getElementById("ContentPlaceHolder1_lblTotalSolicitadoD").innerHTML = msg.d[8];
                    document.getElementById("ContentPlaceHolder1_lblTotalCreadoD").innerHTML = msg.d[9];
                    document.getElementById("ContentPlaceHolder1_lblTotalFaltanteD").innerHTML = msg.d[10];
                    document.getElementById("divDimensionadora").style.display = "none";
                    

                    document.getElementById("ContentPlaceHolder1_lblFolioTrabajo").innerHTML = msg.d[11];
                    document.getElementById("ContentPlaceHolder1_lblIDTrabajo").innerHTML = id;

                     document.getElementById("divDatosSolicitud").style.display = "none";
                     document.getElementById("divSolicitudDimensionadora").style.display = "block";

                     if(msg.d[0]=='Stock')
                     {
                     document.getElementById("ContentPlaceHolder1_lblFIAncho").innerHTML = '';
                     document.getElementById("ContentPlaceHolder1_lblFILargo").innerHTML = '';
                     
                    document.getElementById("<%= txtAnchoD.ClientID%>").value = msg.d[6];
                    document.getElementById("<%= txtLargoD.ClientID%>").value = msg.d[7];
                    document.getElementById("ContentPlaceHolder1_lblFormatoDimensionadora").innerHTML=msg.d[6]+' mm x '+msg.d[7]+' mm';
                    CargaSKUaSeleccionar(msg.d[4],msg.d[6],msg.d[7]);

                     }else{
                     document.getElementById("ContentPlaceHolder1_lblFIAncho").innerHTML = msg.d[12];
                     document.getElementById("ContentPlaceHolder1_lblFILargo").innerHTML = msg.d[13];
                     
                    document.getElementById("<%= txtAnchoD.ClientID%>").value = msg.d[12];
                    document.getElementById("<%= txtLargoD.ClientID%>").value = msg.d[13];
                    document.getElementById("ContentPlaceHolder1_lblFormatoDimensionadora").innerHTML=msg.d[6]+' mm x '+msg.d[7]+' mm';
                    CargaSKUaSeleccionar(msg.d[4],msg.d[12],msg.d[13]);
                    }

                    CargarFaltantes(id);



                },
                error: function () {
                    alert('¡Ha Ocurrido un Error al procesar!');
                }
            });
        }
        function CrearSolicitudCorte(tipo) {
            var OT = document.getElementById("ContentPlaceHolder1_lblOTD").innerHTML;
            var NombreOT = document.getElementById("ContentPlaceHolder1_lblNombreOTD").innerHTML;
            var comp = document.getElementById("ContentPlaceHolder1_lblComponenteD").innerHTML;
            var Papel = document.getElementById("ContentPlaceHolder1_lblPapelD").innerHTML;


            var select2 = document.getElementById("<%= ddlSKUEntrada.ClientID %>");
            var Codigo = select2.options[select2.selectedIndex].value;
                 


            var FAncho = document.getElementById("<%= txtAnchoD.ClientID %>").value;
            var FLargo = document.getElementById("<%= txtLargoD.ClientID %>").value;
            var gramaje = document.getElementById("ContentPlaceHolder1_lblGramajeD").innerHTML;
            var Ancho = document.getElementById("ContentPlaceHolder1_lblAnchoD").innerHTML;
            var Largo = document.getElementById("ContentPlaceHolder1_lblLargoD").innerHTML;
            var asignadoPliegos = document.getElementById("<%= txtPliegosD.ClientID %>").value;
            var asignadoPeso = document.getElementById("<%= txtPesoD.ClientID %>").value;
            var Faltante = document.getElementById("ContentPlaceHolder1_lblTotalFaltanteD").innerHTML;
            var loc = document.location.href;
            var folioOrigen = document.getElementById("ContentPlaceHolder1_lblFolioTrabajo").innerHTML;
            var select2 = document.getElementById("<%= ddlFactor.ClientID %>");
            var Factor = select2.options[select2.selectedIndex].text;
            var idT=document.getElementById("ContentPlaceHolder1_lblIDTrabajo").innerHTML;
            var folioori=document.getElementById("ContentPlaceHolder1_lblFolioTrabajo").innerHTML;

            $.ajax({
                url: "AtenderPesa.aspx/CrearSolicitudCorte",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'FolioOrigen':'"+folioori+"','OT':'" + OT + "','NombreOT':'" + NombreOT + "','Comp':'" + comp + "','SKU':'" + Codigo + "','Papel':'" + Papel +
                "','Ancho':'" + eval(Ancho) + "','Largo':'" + eval(Largo) + "','Gramaje':'" + eval(gramaje) + "','Cantidad':'" + eval(asignadoPliegos) +
                "','Peso':'" + eval(asignadoPeso) + "','Faltante':'" + eval(Faltante) + "','loc':'" + loc + "','Factor':'"+eval(Factor)+"','Folio':'"+folioOrigen+"','FAncho':'"+eval(FAncho)+"','FLargo':'"+eval(FLargo)+"','Usuario':'<%=Session["Usuario"] %>','IDT':'"+idT+"','Tipo':'"+tipo+"'}",
                success: function (msg) {
                    if (msg.d[0] == 'OK') {

                        window.open('EtiquetaBP.aspx?Pro='+ msg.d[2]+'&Folio=' + msg.d[1], 'Impresion Pallet Bodega Pliegos', 'left=45,top=30,width=1170 ,height=880,scrollbars=no,dependent=no,toolbar=no,location=no,status=no,directories=no,menubar=no,status=no,resizable=yes');
                        alert('¡Pallet Generado Correctamente!');
                        if(tipo=='CERRAR'){
                        location.href='AtenderPesa.aspx?id=3&Cat=10';
                        }

                        document.getElementById("<%= txtPliegosD.ClientID %>").value='';
                        document.getElementById("<%= txtPesoD.ClientID %>").value='';
                        CargarFaltantes(idT);

                    } else{
                        alert(msg.d[0]);
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
            function CargaSKUaSeleccionar(sku, ancho,Largo){
                     var ddlTerritory = document.getElementById("<%= ddlSKUEntrada.ClientID %>");
                     var lengthddlTerritory = ddlTerritory.length - 1;
                    for (var i = lengthddlTerritory; i >= 0; i--) {
                    ddlTerritory.options[i] = null;
                    }
             $.ajax({
                     url: "AtenderPesa.aspx/CargarSKUaSeleccionar",//CargarSKU
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'sku':'" + sku + "','Ancho':'"+eval(ancho)+"','Largo':'"+eval(Largo)+"'}",
                     success: function (data) {
                         var jsdata = JSON.parse(data.d);
                         $.each(jsdata, function (key, value) {
                             $('#<%=ddlSKUEntrada.ClientID%>').append($("<option></option>").val(value.CodigoProducto).html(value.Papel));

                         });
                     },
                     error: function () {
                         alert('¡Error al cargar Componentes en sku a seleccionar!');
                     }
                 });
             }
         function CargarFaltantes(id) {
            $.ajax({
                url: "AtenderPesa.aspx/CargarFaltantes",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDTrabajo':'" + id + "'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblTotalSolicitadoD").innerHTML = msg.d[0];
                    document.getElementById("ContentPlaceHolder1_lblTotalCreadoD").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblTotalFaltanteD").innerHTML = msg.d[2];
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error al cargar faltantes dimensionadora!');
                }
            });
        }
       function CargarFaltantesGuillotina(id,folioorigen) {
            $.ajax({
                url: "AtenderPesa.aspx/CargarFaltantesGuillotina",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDTrabajo':'" + id + "','FolioOrigen':'"+folioorigen+"'}",
                success: function (msg) {
                    document.getElementById("ContentPlaceHolder1_lblTotalSolicitado").innerHTML = msg.d[0];
                    document.getElementById("ContentPlaceHolder1_lblTotalCreado").innerHTML = msg.d[1];
                    document.getElementById("ContentPlaceHolder1_lblTotalFaltante").innerHTML = msg.d[2];
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error al cargar faltantes dimensionadora!');
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div align="center"><input id="btnCortadora"   
        onclick="javascript:Cortadora();" type="button"  value="Guillotina" 
        
        style="background-color:#0078AD; height: 32px; width: 136px; color:White;font-weight:bold;border-radius:8px 8px 8px 8px;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<input id="btnDimensionadora"   onclick="javascript:Dimensionadora();" type="button"  value="Dimensionadora" 
        
        style="background-color:#C0C0C0; height: 32px; width: 136px; color:White;font-weight:bold;border-radius:8px 8px 8px 8px;" />
    <asp:Button ID="btnFiltro" runat="server" Text="Button" Visible="False" />
    
</div>
<br />
<div id="divCortadora">
<div id="divSolicitudesCortadora">
                <div class="divTitulo">
                    Solicitud Guillotina Pendientes</div>
    <div class="divSeccion">
<div id="GridCortadora" style="height:500px;width:1100px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid1" runat="server"  Skin="Outlook" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Fecha" ItemStyle-Width="45px" ItemStyle-HorizontalAlign="Right"  SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                    </telerik:GridBoundColumn>  
<%--                    <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" SortExpression="Folio" UniqueName="Folio">
                    </telerik:GridBoundColumn>--%>
                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="45px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>   
                    
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="190px" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="290px" SortExpression="Papel" UniqueName="Papel">
                    </telerik:GridBoundColumn>


                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Cantidad" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="StockFL" UniqueName="StockFL">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="Asignar" HeaderText="Procesado" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Asignar" UniqueName="Asignar">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="50px" SortExpression="Accion" UniqueName="Accion">
                    </telerik:GridBoundColumn>
                            
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
         </div>
        </div><%--fin divSeccionGrillaCortadora--%>
        </div>
       <%-- cambio contenido al atender--%>


       <div id="divDatosSolicitud"  ><%--style="display:none;"--%>
    <div class="divTitulo">Datos de la Solicitud</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label11" runat="server" Text="OT:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblOT" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label12" runat="server" Text="Nombre OT:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label13" runat="server" Text="Componente:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblComponente" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="lblFolioGuillotina"  runat="server"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblFolioOrigenCorte" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lblIDCorte" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label15" runat="server" Text="Papel Solicitado:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style11" colspan="3">
                    <asp:Label ID="lblPapel" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="Codigo:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label29" runat="server" Font-Bold="True" Text="Marca:"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblMarca" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label16" runat="server" Text="Gramaje:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblGramaje" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label20" runat="server" Text="Ancho:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblAncho" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label19" runat="server" Text="Largo: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblLargo" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label21" runat="server" Text="Total Asignado:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblCantidad" runat="server"></asp:Label>
&nbsp;&nbsp;
                    <asp:Label ID="Label23" runat="server" Text="   Pliegos."></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label65" runat="server" Font-Bold="True" Text="Procedencia:"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblProcedencia" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label67" runat="server" Font-Bold="True" Text="Formato Corte:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblFancho" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="Label69" runat="server" Text=" X "></asp:Label>
                    <asp:Label ID="lblFLargo" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
            <div class="divTitulo" id="Registros" >
                <table style="width:100%;">
                    <tr>
                        <td>
                            Ver Pallets Creados</td>
                        <td>
                            <div align="right"><a style="color:Blue;text-decoration: underline;font-size:15px;"  onclick="javascript:CerrarPallet();">Cerrar</a></div></td>
                    </tr>
                </table>
    </div>
    <div class="divSeccion" id="Registros2">
    <div style="height:200px;overflow:auto;">
        <asp:Label ID="lblPalletCreadoG" runat="server"></asp:Label>
    </div>
    </div>
        <div class="divTitulo">
            <table style="width:100%;">
                <tr>
                    <td>
                        Crear Pallets</td>
                    <td>
                      <div align="right"> 
                          <a style="color:Blue;text-decoration: underline;font-size:15px;" onclick="javascript:VerPallet();">Ver Creados</a></div></td>
                </tr>
            </table>
    </div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label59" runat="server" Font-Bold="True" Text="SKU Salida:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSKUSalida" runat="server" Width="173px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label24" runat="server" Text="Cantidad de Pliegos:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPliegos" runat="server" BackColor="Yellow"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label25" runat="server" Text="Peso Pliegos:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPeso" runat="server" BackColor="Yellow"></asp:TextBox>
&nbsp;<asp:Label ID="Label26" runat="server" Text="KGs."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <div align="center">
        <input id="btnGuardar" type="button" value="Crear Pallet" onclick="javascript:CrearPallet2('Normal');" style="width:182px;" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Button5" type="button" value="Crear y Finalizar sol." onclick="javascript:CrearPallet2('Cerrar');" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;        
         <input id="Button1" type="button" value="Nueva Solicitud" onclick="javascript:NuevaSolicitud();" style="width:182px;" />

               </div>
        </div>
        <br />
        <div align="right" style="margin-left:500px;">
    <table id="tblRegistro" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:400px;">
  <tbody>
      <tr style="background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Cantidad Solicitada</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16"></td>

  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDespachado" runat="server">Total Solicitado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblTotalSolicitado" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label30" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server">Total Creado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblTotalCreado" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label31" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
    
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        <asp:Label ID="Label32" runat="server" Text="Cantidad Faltante:"></asp:Label>
        </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblTotalFaltante" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label33" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
    
  </tr>
</tbody></table>
</div>
</div>
    </div>
    <div id="divDimensionadora" > <%--style="display:none;"--%>
                <div class="divTitulo">
                    Solicitud Dimensionadora Pendientes</div>
    <div class="divSeccion">
    <div id="GridDimensionadora" style="height:500px;width:1100px; overflow:auto;" >
    <telerik:radgrid ID="RadGrid2" runat="server"  Skin="Outlook" 
            onneeddatasource="RadGrid2_NeedDataSource" >
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT"><NoRecordsTemplate><div style="text-align:center;"><br />¡ No se han encontrado registros !<br /></div></NoRecordsTemplate><CommandItemSettings ExportToPdfText="Export to Pdf" />
                
                <Columns>
                    <telerik:GridBoundColumn DataField="FechaCreacion" HeaderText="Folio" ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center"  SortExpression="FechaCreacion" UniqueName="FechaCreacion">
                    </telerik:GridBoundColumn>  

                    <telerik:GridBoundColumn DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="CodigoProducto" UniqueName="CodigoProducto">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="OT" HeaderText="OT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"  SortExpression="OT" UniqueName="OT">
                    </telerik:GridBoundColumn>   
                    
                    <telerik:GridBoundColumn DataField="NombreOT" HeaderText="NombreOT" ItemStyle-Width="185px" ItemStyle-HorizontalAlign="Left" SortExpression="NombreOT" UniqueName="NombreOT">
                    </telerik:GridBoundColumn>
             
                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="290px" SortExpression="Papel" ItemStyle-HorizontalAlign="Left" UniqueName="Papel">
                    </telerik:GridBoundColumn>


                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"  SortExpression="Gramaje" UniqueName="Gramaje">
                    </telerik:GridBoundColumn>               
                    
                    
                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Largo" HeaderText="Largo" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="Largo" UniqueName="Largo">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Cantidad" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="StockFL" UniqueName="StockFL">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Marca" HeaderText="Procesado" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Marca" UniqueName="Marca">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Accion" HeaderText="Accion" ItemStyle-Width="40px" SortExpression="Accion" UniqueName="Accion">
                    </telerik:GridBoundColumn>
                            
                </Columns>

                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                    EnableImageSprites="True">
                </HeaderContextMenu>
                </telerik:radgrid>
         </div>
    </div>
    </div>
           <div id="divSolicitudDimensionadora" ><%--style="display:none;"--%>
    <div class="divTitulo">Datos de la Solicitud</div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" Text="OT:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblOTD" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label4" runat="server" Text="Nombre OT:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblNombreOTD" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label6" runat="server" Text="Componente:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblComponenteD" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="lblIDTrabajo" runat="server"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblFolioTrabajo" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label9" runat="server" Text="Papel Solicitado:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style11" colspan="3">
                    <asp:Label ID="lblPapelD" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Codigo:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblSKUD" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Marca:"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblMarcaD" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label28" runat="server" Text="Gramaje:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblGramajeD" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label35" runat="server" Text="Ancho:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblAnchoD" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label37" runat="server" Text="Largo: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblLargoD" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label39" runat="server" Text="Total Asignado:" Font-Bold="True"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblAsignadoD" runat="server"></asp:Label>
&nbsp;&nbsp;
                    <asp:Label ID="Label41" runat="server" Text="   Pliegos."></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="Label60" runat="server" Font-Bold="True" 
                        Text="Formato Impresion:"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="lblFIAncho" runat="server"></asp:Label>
                    <asp:Label ID="Label62" runat="server" Text="X"></asp:Label>
                    <asp:Label ID="lblFILargo" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
        <div class="divTitulo">
                        Crear Pallets
    </div>
    <div class="divSeccion">
        <table style="width:100%;">
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label66" runat="server" Font-Bold="True" 
                        Text="Formato Dimensionadora:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFormatoDimensionadora" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label55" runat="server" Text="Formato Corte (AxL):" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAnchoD" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
&nbsp;<asp:Label ID="Label56" runat="server" Text=" X"></asp:Label>
&nbsp;<asp:TextBox ID="txtLargoD" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                    <asp:Label ID="Label57" runat="server" Text="(mm)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label63" runat="server" Font-Bold="True" Text="SKU Entrada:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSKUEntrada" runat="server" Width="173px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label58" runat="server" Text="Factor:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlFactor" runat="server" Width="173px">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem Value="4"></asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label43" runat="server" Text="Cantidad de Pliegos:" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPliegosD" runat="server" BackColor="Yellow"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Label ID="Label44" runat="server" Text="Peso Pliegos:" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPesoD" runat="server" BackColor="Yellow"></asp:TextBox>
&nbsp;<asp:Label ID="Label45" runat="server" Text="KGs."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <div align="center"><input id="Button2" type="button" value="Crear Pallet" onclick="javascript:CrearSolicitudCorte('NORMAL');"  style="width:182px;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="Button4" type="button" value="Crear y Finalizar sol." onclick="javascript:CrearSolicitudCorte('CERRAR');" />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="Button3" type="button" value="Nueva Solicitud" onclick="javascript:NuevaSolicitud();" style="width:182px;" />

               

               </div>
        </div>
        <br />
        <div align="right" style="margin-left:500px;">
                         <table id="Table1" runat="server" cellspacing="0" cellpadding="0" style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:400px;">
  <tbody>
      <tr style="background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
    <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style16">Cantidad Solicitada</td>
    <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;" 
              class="style16"></td>

  </tr>
  
  <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label46" runat="server">Total Solicitado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblTotalSolicitadoD" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label48" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label49" runat="server">Total Creado:</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;</td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblTotalCreadoD" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label51" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
    
  </tr>
    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333;  vertical-align: text-top;">
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;" 
          class="style20">
        <asp:Label ID="Label52" runat="server" Text="Cantidad Faltante:"></asp:Label>
        </td>
    <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;">
                                    <asp:Label ID="lblTotalFaltanteD" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label54" runat="server" Text="Pliegos."></asp:Label>
                                    </td>
    
  </tr>
</tbody></table>
</div>
</div>
</asp:Content>
