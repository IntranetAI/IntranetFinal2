<%@ Page Title="" Language="C#" MasterPageFile="~/View/Aplicaciones.Master" AutoEventWireup="true" CodeBehind="SolicitudDimensionadoPapelDetalle.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.SolicitudDimensionadoPapelDetalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../js/funciones.js" type="text/javascript"></script>
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
}
.divSeccion{
    padding-top: 10px;
    padding-bottom: 10px;
    border: 1px solid #959595;
    border-top: 0px;
    margin-bottom: 2px;
}
.divEtiqueta{
    display: inline-block;
    padding: 5px;
    font-weight: bold;
    text-align: left;
}
.divCampo{
    display: inline-block;
    text-align: left;
}

     .style2
     {
         width: 21px;
     }
     .style3
     {
         width: 176px;
     }
     .style4
     {
         width: 149px;
     }
     .style5
     {
     }

     .style6
     {
         width: 20px;
     }
     .style7
     {
         width: 151px;
     }
     .style8
     {
         width: 20px;
         height: 26px;
     }
     .style9
     {
         width: 151px;
         height: 26px;
     }
     .style10
     {
         height: 26px;
     }
     .style11
     {
         height: 26px;
         width: 238px;
     }
     .style12
     {
         width: 238px;
     }

     #btnFinalizarSolicitud
     {
         width: 210px;
     }

     .style13
     {
         width: 213px;
     }
     .style14
     {
         width: 21px;
         height: 26px;
     }
     .style15
     {
         width: 149px;
         height: 26px;
     }
     .style16
     {
         width: 213px;
         height: 26px;
     }

    </style>
         <script  type="text/javascript" language="javascript">
             function contar() {
                 var elementos = document.getElementsByName("checkintento");
                 var bobinas = "";
                 var suma = 0;
                 for (x = 0; x < elementos.length; x++) {
                     if (elementos[x].checked) {
                         suma = suma + eval(elementos[x].id);
                         bobinas = bobinas + "." + elementos[x].alt + ".-";
                     }
                 }
         
                 document.getElementById("ContentPlaceHolder1_lblKGAsinados").innerHTML = suma;
                 document.getElementById("ContentPlaceHolder1_lblBobinasSeleccionadas").innerHTML = bobinas;
                 CantidadFaltante();
             }

             $(document).ready(function () {
                 document.getElementById("form1").onsubmit=function(){
                    return false;
                  }
                
                 $("#ContentPlaceHolder1_txtPliegosStock").keypress(function(e) {
                    if(e.which == 13) {
                        CalculoKilos();
                    }
                   });
                 $("#ContentPlaceHolder1_txtPesoStock").keypress(function(e) {
                    if(e.which == 13) {
                        CalculoPliegos();
                    }
                   });
                 $("#ContentPlaceHolder1_txtPliegos").keypress(function(e) {
                    if(e.which == 13) {
                        CalculoKilosOT(); 
                    }
                   });
                 $("#ContentPlaceHolder1_txtPesoOT").keypress(function(e) {
                   if(e.which == 13) {
                        CalculoPliegosOT(); 
                        
                    }
                   });
                 $("#ContentPlaceHolder1_rdStock").change(function () {
                     document.getElementById("divOT1234").style.display = 'none';
                     document.getElementById("DivStock").style.display = 'block';
                     var ss=document.getElementById("ContentPlaceHolder1_lblPaperStock").innerHTML;
                     document.getElementById("ContentPlaceHolder1_lblPapelStock").innerHTML=ss;
                 });
                 $("#ContentPlaceHolder1_rdOT").change(function () {
                     if ($("#ContentPlaceHolder1_rdOT").attr("checked")) {
                         document.getElementById("divOT1234").style.display = 'block';
                         document.getElementById("DivStock").style.display = 'none';
                     }
                 });
                 $("#ContentPlaceHolder1_txtPliegos").change(function () {
                        CalculoKilosOT(); 
                 }); 
                 $("#ContentPlaceHolder1_txtPesoOT").change(function () {
                        CalculoPliegosOT(); 
                 });           
                 $("#ContentPlaceHolder1_txtOT").change(function () {
                     BuscarOT();
                 });
                 $("#ContentPlaceHolder1_txtLargoStock").change(function () {
                   // ParaStock();
                   var foll=document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
                         if(foll=='0'){
                             FolioEnc();
                             }
                     document.getElementById("ContentPlaceHolder1_lblSKUStock").innerHTML == 'Stock';
                     document.getElementById("ContentPlaceHolder1_lblAnchoStock").innerHTML = document.getElementById("ContentPlaceHolder1_lblAnchStock").innerHTML;
                     document.getElementById("ContentPlaceHolder1_lblLargoStock").innerHTML = document.getElementById("<%= txtLargoStock.ClientID %>").value;

                     
                     CargaSKUStock(document.getElementById("ContentPlaceHolder1_lblSKUStock").innerHTML,document.getElementById("ContentPlaceHolder1_lblGramStock").innerHTML,document.getElementById("ContentPlaceHolder1_lblAnchoStock").innerHTML,document.getElementById("ContentPlaceHolder1_lblLargoStock").innerHTML);
                 });
                 $("#ContentPlaceHolder1_txtPliegosStock").change(function () {
                
                     CalculoKilos();
                 });
                 $("#ContentPlaceHolder1_txtPesoStock").change(function () {
                 
                    CalculoPliegos();
                 });
                 $("#ContentPlaceHolder1_txtAncho").change(function () {
                         var anc= document.getElementById("<%= txtAncho.ClientID%>").value;
                         var larg =document.getElementById("<%= txtLargo.ClientID%>").value;
                         var sku=document.getElementById("ContentPlaceHolder1_lblSKU").innerHTML;
                 CargaSKUaSeleccionar(sku,anc,larg);

                 });
                 $("#ContentPlaceHolder1_txtLargo").change(function () {
                         var anc= document.getElementById("<%= txtAncho.ClientID%>").value;
                         var larg =document.getElementById("<%= txtLargo.ClientID%>").value;
                         var sku=document.getElementById("ContentPlaceHolder1_lblSKU").innerHTML;
                 CargaSKUaSeleccionar(sku,anc,larg);

                 });
                 $("#ContentPlaceHolder1_ddlComponente").change(function () {
                     var select2 = document.getElementById("<%= ddlComponente.ClientID %>");
                     var Programado = select2.options[select2.selectedIndex].text;
                     if (Programado == "Seleccionar") {
                         document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML = "";
                         document.getElementById("<%= txtAncho.ClientID%>").value = "";
                         document.getElementById("<%= txtLargo.ClientID%>").value = "";
                     }
                     else {
                         BuscarOTyComponente();
                         var foll=document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
                         if(foll=='0'){
                             FolioEnc();
                             
                             }
                         
                     }
                 });
             });
             function CargaSKUStock(Papel,Gramaje, ancho,Largo){
                         var ddlTerritory = document.getElementById("<%= ddlSKUStock.ClientID %>");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
             $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/CargarSKUStock",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'Papel':'" + Papel + "','Gramaje':'"+eval(Gramaje)+"','Ancho':'"+eval(ancho)+"','Largo':'"+eval(Largo)+"'}",
                     success: function (data) {
                         var jsdata = JSON.parse(data.d);
                         $.each(jsdata, function (key, value) {
                             $('#<%=ddlSKUStock.ClientID%>').append($("<option></option>").val(value.CodigoProducto).html(value.Papel));

                         });
                     },
                     error: function () {
                         alert('¡Error al cargar Componentes!');
                     }
                 });
             }

             function BuscarOT() {
                 var OT = document.getElementById("<%= txtOT.ClientID%>").value;
                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/BuscarOT",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'OT':'" + OT + "'}",
                     success: function (msg) {
                         document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML = msg.d[0];
                     },
                     error: function () {
                         alert('¡Error al cargar la OT!');
                     }
                 });
                 var ddlTerritory = document.getElementById("<%= ddlComponente.ClientID %>");
                 var lengthddlTerritory = ddlTerritory.length - 1;
                 for (var i = lengthddlTerritory; i >= 0; i--) {
                     ddlTerritory.options[i] = null;
                 }
                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/CargarPliegosProgramado",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'OT':'" + OT + "'}",
                     success: function (data) {
                         var jsdata = JSON.parse(data.d);
                         $.each(jsdata, function (key, value) {
                             $('#<%=ddlComponente.ClientID%>').append($("<option></option>").val(value.Componente).html(value.Componente));

                         });
                     },
                     error: function () {
                         alert('¡Error al cargar Componentes!');
                     }
                 });
             } 
             function BuscarOTyComponente() {
                 var OT = document.getElementById("<%= txtOT.ClientID%>").value;
                 var select2 = document.getElementById("<%= ddlComponente.ClientID %>");
                 var Programado = select2.options[select2.selectedIndex].text;
                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/BuscarOTComponente",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'OT':'" + OT + "','Componente':'" + Programado + "'}",
                     success: function (msg) {
                         document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML = msg.d[0];
                         //document.getElementById("<%= txtAncho.ClientID%>").value = msg.d[1];
                         document.getElementById("<%= txtAncho.ClientID%>").value =document.getElementById("ContentPlaceHolder1_lblAnchStock").innerHTML;
                         document.getElementById("<%= txtLargo.ClientID%>").value = msg.d[2];
                         document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML = msg.d[3];
                         document.getElementById("ContentPlaceHolder1_lblPliegosSolicitados").innerHTML = msg.d[4];
                         document.getElementById("ContentPlaceHolder1_lblFIAncho").innerHTML = msg.d[5];
                         document.getElementById("ContentPlaceHolder1_lblIFLargo").innerHTML = msg.d[6];
                         document.getElementById("ContentPlaceHolder1_lblKilosSolicitados").innerHTML = msg.d[7];


                         CargaSKUaSeleccionar('03.04.0354',document.getElementById("ContentPlaceHolder1_lblAnchStock").innerHTML,msg.d[2]);
                         
                     },
                     error: function () {
                         alert('¡Error al cargar datos componente!');
                     }
                 });
             }
              function CargaSKUaSeleccionar(sku, ancho,Largo){
              var sku2=document.getElementById("ContentPlaceHolder1_lblSKU").innerHTML;
                     var ddlTerritory = document.getElementById("<%= ddlSKU.ClientID %>");
                     var lengthddlTerritory = ddlTerritory.length - 1;
                    for (var i = lengthddlTerritory; i >= 0; i--) {
                    ddlTerritory.options[i] = null;
                    }
             $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/CargarSKU",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'sku':'" + sku2 + "','Ancho':'"+eval(ancho)+"','Largo':'"+eval(Largo)+"'}",
                     success: function (data) {
                         var jsdata = JSON.parse(data.d);
                         $.each(jsdata, function (key, value) {
                             $('#<%=ddlSKU.ClientID%>').append($("<option></option>").val(value.CodigoProducto).html(value.Papel));

                         });
                     },
                     error: function () {
                         alert('¡Error al cargar Componentes!');
                     }
                 });
             }
             function FolioEnc() {

                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/BuscarFolio",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'Usuario':'<%=Session["Usuario"] %>'}",
                     success: function (msg) {
                         document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML = msg.d[0];
                     },
                     error: function () {
                         alert('¡Error al cargar Folio!');
                     }
                 });
             }
               function GrabarIngreso() {

               var select2 = document.getElementById("<%= ddlSKU.ClientID %>");
                 var sku = select2.options[select2.selectedIndex].value;
                 var papel=select2.options[select2.selectedIndex].text;

                 var Folio=document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
                 var ot=document.getElementById("<%= txtOT.ClientID%>").value;
                 var not=document.getElementById("ContentPlaceHolder1_lblNombreOT").innerHTML;
                 var select2 = document.getElementById("<%= ddlComponente.ClientID %>");
                 var Componente = select2.options[select2.selectedIndex].text;
                 //var papel=document.getElementById("ContentPlaceHolder1_lblPapel").innerHTML;
                 //var sku=document.getElementById("ContentPlaceHolder1_lblSKU").innerHTML;
                 var Gramaje=document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML;
                 var ancho=document.getElementById("<%= txtAncho.ClientID%>").value;
                 var largo=document.getElementById("<%= txtLargo.ClientID%>").value;
                 var Pliegos=document.getElementById("<%= txtPliegos.ClientID%>").value;
                 var kilosrestantes=document.getElementById("ContentPlaceHolder1_lblTotalKGAsignar").innerHTML;
                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/GuardarTrabajo",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'Folio':'"+Folio+"','OT':'"+ot+"','NombreOT':'"+not+"','Componente':'"+Componente+
                     "','SKU':'"+sku+"','Papel':'"+papel+"','Gramaje':'"+eval(Gramaje)+"','Ancho':'"+eval(ancho)+"','Largo':'"+eval(largo)+"','Pliegos':'"+eval(Pliegos)+"','Usuario':'<%=Session["Usuario"] %>','KilosRestantes':'"+eval(kilosrestantes)+"'}",
                     success: function (msg) {
                       
                       if( msg.d[0]=="OK")
                       {
                            alert('¡Ingresado Correctamente!');
                            CargaTabla();
                            CantidadFaltante();
                       }
                       else if(msg.d[0]=="ERROR2")
                       {
                         alert('¡La cantidad restante por asignar debe ser mayor o igual a 0, para asignar un nuevo trabajo debe agregar otra bobina!');
                       }
                       else
                       {
                            alert('¡Error al ingresar!');
                       }
                     },
                     error: function () {
                         alert('¡Error Campos Vacios!');
                     }
                 });
             }
           function CargaTabla() {
                var Folio=document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/CargaTabla",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'Folio':'" + Folio + "'}",
                     success: function (msg) {
                         document.getElementById("ContentPlaceHolder1_lblTablaTrabajos").innerHTML = msg.d[0];
                     },
                     error: function () {
                         alert('¡Error al cargar datos componente!');
                     }
                 });
             }
             function EliminarIngreso(id){
                     $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/EliminarIngreso",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'IDRegistro':'" + id + "'}",
                     success: function (msg) {
                     if(msg.d[0]=='OK'){
                        alert('Registro Eliminado Correctamente');
                        CargaTabla();
                        CantidadFaltante();
                     }else{
                        alert('Ha ocurrido un error, vuelva a intentarlo');
                     }
                     },
                     error: function () {
                         alert('¡Error al cargar datos componente!');
                     }
                 });
             }

              function ParaStock(){
                 var largo=document.getElementById("<%= txtLargoStock.ClientID%>").value;
                 var sku=document.getElementById("ContentPlaceHolder1_lblSKU").innerHTML;
                 var papel=document.getElementById("ContentPlaceHolder1_lblPaperStock").innerHTML;
                 var Gram=document.getElementById("ContentPlaceHolder1_lblGramStock").innerHTML;
                 var Anch=document.getElementById("ContentPlaceHolder1_lblAnchStock").innerHTML;
                     $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/ParaStock",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                     data: "{'Largo':'" + eval(largo) + "','SKU':'" + sku + "','Papel':'" + papel + "','Gramaje':'" + eval(Gram) + "','Ancho':'" + eval(Anch) + "'}",
                     success: function (msg) {
                     if(msg.d[0]=='OK'){
                         document.getElementById("ContentPlaceHolder1_lblSKUStock").innerHTML = msg.d[1];
                         document.getElementById("ContentPlaceHolder1_lblAnchoStock").innerHTML = msg.d[2];
                         document.getElementById("ContentPlaceHolder1_lblLargoStock").innerHTML = msg.d[3];

                         var foll=document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;


                         if(foll=='0'){
                             FolioEnc();


                             }

                        }else{
                         alert('No Existe SKU para el papel con esas caracteristicas');
                         }
                         
                     },
                     error: function () {
                         alert('¡Error al cargar datos componente!');
                     }
                 });
             }


               function CalculoKilos(){
                 var pliegos=eval( document.getElementById("<%= txtPliegosStock.ClientID%>").value);
                 var peso=eval(document.getElementById("<%= txtPesoStock.ClientID%>").value);
                 var Largo=eval(document.getElementById("ContentPlaceHolder1_lblLargoStock").innerHTML);
                 var Gram=eval(document.getElementById("ContentPlaceHolder1_lblGramStock").innerHTML);
                 var Anch=eval(document.getElementById("ContentPlaceHolder1_lblAnchoStock").innerHTML);
                 
                 var calculapeso=0;
                 calculapeso=((Gram*Largo*Anch)/1000000000)*pliegos;
                 document.getElementById("<%= txtPesoStock.ClientID%>").value=calculapeso.toFixed(2);


             }
             function CalculoPliegos(){
                 var pliegos=eval( document.getElementById("<%= txtPliegosStock.ClientID%>").value);
                 var p=document.getElementById("<%= txtPesoStock.ClientID%>").value.replace(",",".");
                 var peso=eval(p);
                 var Largo=eval(document.getElementById("ContentPlaceHolder1_lblLargoStock").innerHTML);
                 var Gram=eval(document.getElementById("ContentPlaceHolder1_lblGramStock").innerHTML);
                 var Anch=eval(document.getElementById("ContentPlaceHolder1_lblAnchoStock").innerHTML);
                 
                 document.getElementById("<%= txtPesoStock.ClientID%>").value=peso;
                 var calculapliegos=0;

                 calculapliegos=(peso/((Gram*Largo*Anch)/1000000000));
                 document.getElementById("<%= txtPliegosStock.ClientID%>").value=Math.round(calculapliegos);
             }
             function PesoAutomatico(){
                document.getElementById("<%= txtPesoStock.ClientID%>").value=document.getElementById("ContentPlaceHolder1_lblTotalKGAsignar").innerHTML;
                CalculoPliegos();
             }
             function PesoAutomatico2(){
                document.getElementById("<%= txtPesoOT.ClientID%>").value=document.getElementById("ContentPlaceHolder1_lblTotalKGAsignar").innerHTML;
                CalculoPliegosOT();
             }
                           
             function CalculoKilosOT(){
                 var pliegos=eval( document.getElementById("<%= txtPliegos.ClientID%>").value);
                 var peso=eval(document.getElementById("<%= txtPesoOT.ClientID%>").value);
                 var Largo=eval( document.getElementById("<%= txtLargo.ClientID%>").value);
                 var Gram=eval(document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML);
                 var Anch=eval( document.getElementById("<%= txtAncho.ClientID%>").value);
                 
                 var calculapeso=0;
                 calculapeso=((Gram*Largo*Anch)/1000000000)*pliegos;
                 document.getElementById("<%= txtPesoOT.ClientID%>").value=calculapeso.toFixed(2);


             }
             function CalculoPliegosOT(){
                 var pliegos=eval( document.getElementById("<%= txtPliegos.ClientID%>").value);
                 var p=document.getElementById("<%= txtPesoOT.ClientID%>").value.replace(",",".");
                 var peso=eval(p);
                 var Largo=eval( document.getElementById("<%= txtLargo.ClientID%>").value);
                 var Gram=eval(document.getElementById("ContentPlaceHolder1_lblGramaje").innerHTML);
                 var Anch=eval( document.getElementById("<%= txtAncho.ClientID%>").value);
                 
                 document.getElementById("<%= txtPesoOT.ClientID%>").value=peso;
                 var calculapliegos=0;

                 calculapliegos=(peso/((Gram*Largo*Anch)/1000000000));
                 document.getElementById("<%= txtPliegos.ClientID%>").value=Math.round(calculapliegos);
             }
             
             function GrabaIngresoSt() {
                 var Folio=document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
                 
               //  var papel=document.getElementById("ContentPlaceHolder1_lblPapelStock").innerHTML;
                 

                 var select2 = document.getElementById("<%= ddlSKUStock.ClientID %>");
                 var sku = select2.options[select2.selectedIndex].value;
                 var papel=select2.options[select2.selectedIndex].text;

                 //var sku=document.getElementById("ContentPlaceHolder1_lblSKUStock").innerHTML;
                 
                 var Gramaje=document.getElementById("ContentPlaceHolder1_lblGramStock").innerHTML;
             
                 var ancho=document.getElementById("ContentPlaceHolder1_lblAnchoStock").innerHTML;
             
                 var largo=document.getElementById("ContentPlaceHolder1_lblLargoStock").innerHTML;
         
                 var Pliegos=document.getElementById("<%= txtPliegosStock.ClientID%>").value;
              
                 var Peso=document.getElementById("<%= txtPesoStock.ClientID%>").value;

                 var kilosrestantes=document.getElementById("ContentPlaceHolder1_lblTotalKGAsignar").innerHTML;
                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/GuardarParaStock12",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                    data: "{'Folio':'"+Folio+"','SKU':'"+sku+"','Papel':'"+papel+"','Gramaje':'"+eval(Gramaje)+"','Ancho':'"+eval(ancho)+"','Largo':'"+eval(largo)+"','Pliegos':'"+eval(Pliegos)+"','Peso':'"+eval(Peso)+"','Usuario':'<%=Session["Usuario"] %>','KilosRestantes':'"+kilosrestantes+"'}",
                     success: function (msg) {
                       
                       if( msg.d[0]=="OK")
                       {
                            alert('¡Ingresado Correctamente!');
                            CargaTabla();
                            CantidadFaltante();
                       }
                       else if(msg.d[0]=="ERROR2")
                       {
                         alert('¡La cantidad restante por asignar debe ser mayor o igual a 0, para asignar un nuevo trabajo debe agregar otra bobina!');
                       }
                       else
                       {
                            alert('¡Error al ingresar!');
                       }
                     },
                     error: function () {
                         alert('¡Error Campos Vacios!');
                     }
                 });
             }

            function CantidadFaltante() {
             var folio=document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
            var kasig=document.getElementById("ContentPlaceHolder1_lblKGAsinados").innerHTML;
                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/FaltanteAsignar",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                    data: "{'Usuario':'<%=Session["Usuario"] %>','KGAsignados':'"+eval(kasig)+"','Folio':'"+folio+"'}",
                     success: function (msg) {
                     document.getElementById("ContentPlaceHolder1_lblTotalPliegos").innerHTML = msg.d[0];
                     document.getElementById("ContentPlaceHolder1_lblTotalKGPliegos").innerHTML = msg.d[1];
                     document.getElementById("ContentPlaceHolder1_lblTotalKGAsignar").innerHTML = msg.d[2];
                     document.getElementById("ContentPlaceHolder1_lblTotalKGAsignado").innerHTML = msg.d[3];

                     },
                     error: function () {
                         alert('¡Error Campos Vacios!');
                     }
                 });
             }

          function FinalizarSolicitud() {
            var Bobinas=document.getElementById("ContentPlaceHolder1_lblBobinasSeleccionadas").innerHTML;
            var FaltaAsignar=document.getElementById("ContentPlaceHolder1_lblTotalKGAsignar").innerHTML;
            var folio=document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
            var kilosBob=document.getElementById("ContentPlaceHolder1_lblKGAsinados").innerHTML;
            var sku=document.getElementById("ContentPlaceHolder1_lblSKU").innerHTML;
            var peso=document.getElementById("ContentPlaceHolder1_lblTotalKGPliegos").innerHTML;
                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/FinalizarSolicitud",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                    data: "{'Bobinas':'"+Bobinas+"','FaltaAsignar':'"+eval(FaltaAsignar)+"','Folio':'"+folio+"','KilosBobinas':'"+eval(kilosBob)+"','SKU':'"+sku+"','Peso':'"+eval(peso)+"','Usuario':'<%=Session["Usuario"] %>'}",
                     success: function (msg) {
                       if( msg.d[0]=="OK")
                       {
                            alert('¡Solicitud Finalizada Correctamente!');
                            EnviarCorreo();
                       }
                       else if(msg.d[0]=="ERROR")
                       {
                            alert('¡Error al Finalizar, vuelva a intentarlo!');
                       }
                       else if(msg.d[0]=="ERROR2")
                       {
                            alert('¡Debe Seleccionar Bobinas a la Solicitud!');
                       }
                       else if(msg.d[0]=="ERROR3")
                       {
                            alert('¡La Cantidad Faltante por Asignar debe ser igual a 0!');
                       }
                       else if(msg.d[0]=="ERROR4")
                       {
                            alert('¡Debe Asignar Trabajos a las Bobinas Seleccionadas!');
                       }
                       else
                       {
                       alert('¡Error!');
                       }
                     },
                     error: function () {
                         alert('¡Error Campos Vacios!');
                     }
                 });
             }
            function EnviarCorreo() {
            var folio=document.getElementById("ContentPlaceHolder1_lblFolio").innerHTML;
                 $.ajax({
                     url: "SolicitudDimensionadoPapelDetalle.aspx/EnviarCorreos",
                     type: "post",
                     dataType: "json",
                     contentType: "application/json;charset=utf-8",
                    data: "{'Folio':'"+folio+"'}",
                     success: function (msg) {
                       if( msg.d[0]=="OK")
                       {
                          location.href='SolicitudDimensionadoPapel.aspx?id=3&Cat=10';
                       }
                       else
                       {
                       alert('¡Error!');
                       }
                     },
                     error: function () {
                         alert('¡Error Campos Vacios!');
                     }
                 });
             }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="divTitulo">
                    Paso 2: Seleccione Bobinas a solicitar
                    </div>
                    <div style="height:200px;width:1085px; overflow:auto;padding-top:10px;" >
                        <telerik:radgrid ID="RadGrid1" runat="server" 
                Skin="Outlook" >
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="OT">
                                <NoRecordsTemplate>
                                    <div style="text-align:center;">
                                        <br />
                                        ¡ No se han encontrado registros !<br /></div>
                                </NoRecordsTemplate>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Componente" HeaderText="Codigo Bob." ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="Componente" UniqueName="Componente">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Papel" HeaderText="Papel" ItemStyle-Width="290px" SortExpression="Papel" UniqueName="Papel">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Gramaje" HeaderText="Gramaje" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right"  SortExpression="Gramaje" UniqueName="Gramaje">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Ancho" HeaderText="Ancho" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Right" SortExpression="Ancho" UniqueName="Ancho">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="StockFL" HeaderText="Cantidad(KG)" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="StockFL" UniqueName="StockFL">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Accion" HeaderText="" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" SortExpression="Accion" UniqueName="Accion">
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
                    <div align="right" style="padding-top:10px;">
                        <asp:Label ID="lblPaperStock" runat="server" ></asp:Label>
                        <asp:Label ID="lblGramStock" runat="server"  ></asp:Label>
                        <asp:Label ID="lblAnchStock" runat="server" ></asp:Label>
                        <asp:Label ID="lblSKU" runat="server" ></asp:Label>
                        <asp:Label ID="lblFolio" runat="server" >0</asp:Label><%--style="display:none;"--%>
                        <asp:Label ID="lblBobinasSeleccionadas" runat="server" ></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="Cantidad Asignada: " Font-Bold="True"></asp:Label>
                        <asp:Label ID="lblKGAsinados"
            runat="server" Text="0"></asp:Label>
            &nbsp;<asp:Label ID="Label11" runat="server" Text="KGs."></asp:Label>
&nbsp;
                    </div>
                    
                
    <asp:Button ID="btnFiltro" runat="server" Text="Button" Visible="False" 
                    onclick="btnFiltro_Click" />

                    <div class="divTitulo">
                    Paso 3: Asignar trabajos a la solicitud</div>
    <div class="divSeccion">
    <div > 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Asignar a:  "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="rdOT" runat="server" Text="OT" Checked="True" 
            GroupName="Asignar" />
        &nbsp;&nbsp;
        <asp:RadioButton ID="rdStock"
            runat="server" Text="Stock" GroupName="Asignar" />&nbsp;</div>
            <div id="divOT1234" style="display:block;">
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="OT:"></asp:Label>
                </td>
                <td class="style13">
                    <asp:TextBox ID="txtOT" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Nombre OT:   "></asp:Label>
                    <asp:Label ID="lblNombreOT" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Componente:"></asp:Label>
                </td>
                <td class="style13">
                    <asp:DropDownList ID="ddlComponente" runat="server" Width="173px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblGramaje" runat="server" style="display:none;"></asp:Label><%--style="display:none;"--%>
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" 
                        Text="Pliegos Solicitados:  "></asp:Label>
                    <asp:Label ID="lblPliegosSolicitados" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label33" runat="server" Font-Bold="True" 
                        Text="Kilos Solicitados:"></asp:Label>
&nbsp;<asp:Label ID="lblKilosSolicitados" runat="server"></asp:Label>
&nbsp;<asp:Label ID="Label34" runat="server" Text="KG."></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Formato (AxL):"></asp:Label>
                </td>
                <td class="style13">
                    <asp:TextBox ID="txtAncho" runat="server" Width="50px" Enabled="False"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="  X  "></asp:Label>
                    <asp:TextBox ID="txtLargo" runat="server" Width="50px"></asp:TextBox>
                &nbsp;<asp:Label ID="Label13" runat="server" Text="mm"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Papel:   "></asp:Label>
                    <asp:Label ID="lblPapel" runat="server"></asp:Label>
                &nbsp;&nbsp;
                    <asp:Label ID="Label30" runat="server" Font-Bold="True" 
                        Text="Formato Impresion:"></asp:Label>
                    <asp:Label ID="lblFIAncho" runat="server"></asp:Label>
                    <asp:Label ID="Label32" runat="server" Text="X"></asp:Label>
                    <asp:Label ID="lblIFLargo" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label29" runat="server" Font-Bold="True" Text="Cargar a SKU:"></asp:Label>
                </td>
                <td class="style5" colspan="2">
                    <asp:DropDownList ID="ddlSKU" runat="server" Width="284px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    </td>
                <td class="style15">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" 
                        Text="Cantidad de Pliegos:"></asp:Label>
                </td>
                <td class="style16">
                    <asp:TextBox ID="txtPliegos" runat="server"></asp:TextBox>
                </td>
                <td class="style10">
                    </td>
                <td class="style10">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                        <asp:Label ID="Label28" runat="server" Font-Bold="True" 
                            Text="Peso Pliegos (KG):"></asp:Label>
                </td>
                <td class="style13">
                    <asp:TextBox ID="txtPesoOT" runat="server"></asp:TextBox> <a title="Copia el peso por asignar" onclick="javascript:PesoAutomatico2()">(*)</a>
                </td>
                <td>
                    <input id="btnGuardar" onclick="javascript:GrabarIngreso();" type="button" 
                        value="Asignar" /></td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </div>
        <div id="DivStock" ><%--style="display:none;"--%>
        
            <table style="width: 100%;">
                <tr>
                    <td class="style8">
                    </td>
                    <td class="style9">
                        <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Largo:"></asp:Label>
                    </td>
                    <td class="style11">
                        <asp:TextBox ID="txtLargoStock" runat="server"></asp:TextBox>
                    </td>
                    <td class="style10">
                        <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="Papel:  "></asp:Label>
                        <asp:Label ID="lblPapelStock" runat="server"></asp:Label>
                    </td>
                    <td class="style10">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style7">
                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="SKU Stock:"></asp:Label>
                    </td>
                    <td class="style12">
                        <asp:DropDownList ID="ddlSKUStock" runat="server" Width="173px">
                        </asp:DropDownList>
                        <asp:Label ID="lblSKUStock" runat="server" style="display:none;">0</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Formato (AxL):"></asp:Label>
                    &nbsp;
                    <asp:Label ID="lblAnchoStock" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="Label26" runat="server" Text="X "></asp:Label>
                        <asp:Label ID="lblLargoStock" runat="server"></asp:Label>
                &nbsp;mm</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style7">
                        <asp:Label ID="Label22" runat="server" Font-Bold="True" 
                            Text="Cantidad de Pliegos:"></asp:Label>
                    </td>
                    <td class="style12">
                        <asp:TextBox ID="txtPliegosStock" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" style="display:none;"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style7">
                        <asp:Label ID="Label23" runat="server" Font-Bold="True" 
                            Text="Peso Pliegos (KG):"></asp:Label>
                    </td>
                    <td class="style12">
                        <asp:TextBox ID="txtPesoStock" runat="server"></asp:TextBox><a title="Copia el peso por asignar" onclick="javascript:PesoAutomatico()">(*)</a>
                    </td>
                    <td>
                        &nbsp;
                    <input id="btnGuardarStock" onclick="javascript:GrabaIngresoSt();" type="button" 
                        value="Asignar" /></td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        </div>
        <div style="height:100px;width:1085px; overflow:auto;" >
  <%--         <table id="Table1" runat="server" cellpadding="0" cellspacing="0" 
                    style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:1060px;margin-left:3px;">
                    <tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
                        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;">
                            OT</td>
                        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:250px;">
                            Nombre OT</td>
                        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:150px;">
                            Componente</td>
                        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:150px;">
                            Componente</td>
                        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:110px;">
                            Formato Corte</td>
                        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:120px;">
                            Pliegos Asignados</td>
                        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:120px;">
                            Peso Pliegos</td>
                        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;width:80px;">
                            &nbsp;</td>
                        
                    </tr>
                    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;">
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;">
                        &nbsp; &nbsp; &nbsp; &nbsp;</td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:left;width:350px;">
    
                        </td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:200px;">
                        1000</td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:110px;">
                        1000</td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:120px;">
                        1000</td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:right;width:120px;">
                        1000</td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;width:80px;">
                        1000</td>
                    </tr>
                </table>--%>
                <asp:Label ID="lblTablaTrabajos" runat="server"></asp:Label>
                </div>
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;
                &nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="btnFinalizarSolicitud" onclick="javascript:FinalizarSolicitud();" type="button" 
                        value="Finalizar Solicitud" />
                
                </td>
            <td>
<div align="right" style="margin-left:380px;">
                <table id="tblRegistro" runat="server" cellpadding="0" cellspacing="0" 
                    style="border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; margin-bottom: 15px; width:400px;margin-left:3px;">
                    <tr style="height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif; color: #003e7e; text-align: left;">
                        <td style="font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
                            &nbsp;</td>
                        <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
                            Pliegos</td>
                        <td style="font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;text-align:center;">
                            KG</td>
                        
                    </tr>
                    <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;">
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                            <asp:Label ID="lblDespachado" runat="server">KG Bobinas Asignado:</asp:Label>
                            &nbsp; &nbsp; &nbsp; &nbsp;</td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                            <asp:Label ID="lblPrimerDesp" runat="server">-</asp:Label>
                        </td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                            <asp:Label ID="lblTotalKGAsignado" runat="server">0</asp:Label>
                        </td>
                    </tr>
                                        <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;">
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                            <asp:Label ID="Label2" runat="server">Pliegos Asignados:</asp:Label>
                            &nbsp; &nbsp; &nbsp; &nbsp;</td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                            <asp:Label ID="lblTotalPliegos" runat="server">0</asp:Label>
                        </td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                            <asp:Label ID="lblTotalKGPliegos" runat="server">0</asp:Label>
                        </td>

                    </tr>
                                        <tr style="height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif; color: #333; vertical-align: text-top;">
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                            <asp:Label ID="Label16" runat="server">Cantidad por Asignar:</asp:Label>
                            &nbsp; &nbsp; &nbsp; &nbsp;</td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                            <asp:Label ID="Label17" runat="server">-</asp:Label>
                        </td>
                        <td style="font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;text-align:center;">
                            <asp:Label ID="lblTotalKGAsignar" runat="server">0</asp:Label>
                        </td>

                    </tr>
                </table>
                </div>
            </td>
        </tr>
        </table>
</asp:Content>
