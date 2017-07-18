<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requerimientos.aspx.cs" Inherits="Intranet.ModuloPreprensa.View.Requerimientos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Solicitud de Requerimientos Preprensa</title>
     <link href="../../Css/bootstrap.css" rel="stylesheet" type="text/css" />
     <script src="../../js/jquery-1.11.3.min.js" type="text/javascript"></script>
      <script src="../../js/bootstrap.min.js" type="text/javascript"></script>




<script type="text/javascript" src="https://cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.10/js/dataTables.bootstrap.min.js"></script>

 <style type="text/css">
 .body
 {
    padding-right: 0px;
    padding-left: 0px;
 }
 textboxcorto
 {
     padding-right: 2px;padding-left: 0px;
 }
 </style>

 
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {



            CargaDirecciones(document.getElementById("lblRutCliente").innerHTML);
            CargaTipoArchivo();
            CargaTipo();
            muestraDirecciones();
            cargaHistorial();
            document.getElementById("lblClienteD").innerHTML = document.getElementById("lblCliente").innerHTML;
            $("#ddlDireccion").change(function () {
                DetalleDireccion();
            });
            $("#ddlPais").change(function () {
                CargaRegion();
            });
            $("#ddlRegion").change(function () {
                CargaCiudad();
            });
            $("#ddlCiudad").change(function () {
                CargaComuna();
            });
            var data3 = { "result": [
  { "FirstName": "Test1", "LastName": "User" },
  { "FirstName": "user", "LastName": "user" },
  { "FirstName": "Ropbert", "LastName": "Jones" },
  { "FirstName": "hitesh", "LastName": "prajapti" }
  ]
            }



        });
        function GuardarRequerimiento() {
            var select1 = document.getElementById("ddlHora");
            var hora = select1.options[select1.selectedIndex].text;
            var select2 = document.getElementById("ddlMinuto");
            var minuto = select2.options[select2.selectedIndex].text;
            var select3 = document.getElementById("ddlTipoDeArchivo");
            var TipoArchivo = select3.options[select3.selectedIndex].text;
            var OT = document.getElementById("lblOP").innerHTML;
            var nombreOT = document.getElementById("lblNombreOP").innerHTML;
            var cliente = document.getElementById("lblCliente").innerHTML;
            var rutcliente = document.getElementById("lblRutCliente").innerHTML;
            var Fecha = document.getElementById("txtFecha").value;
            var pagColor = document.getElementById("txtPagColor").value;
            var pagImproof = document.getElementById("txtPagImproof").value;
            var pagArmado = document.getElementById("txtPagArmado").value;
            var observ = document.getElementById("txtObservacion").value;
            var RevisaCSR = '';
            if (document.getElementById("rdSi").checked == true) {
                RevisaCSR = 'Si';
            } else {
            RevisaCSR = 'No';
            }
        var usuario = document.getElementById("lblUsuario").innerHTML;
        $.ajax({
            url: "Requerimientos.aspx/FinalizarRequerimiento",
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: "{'OT':'" + OT + "','NombreOT':'" + nombreOT + "','Cliente':'" + cliente + "','RutCliente':'" + rutcliente +
            "','FechaVB':'" + Fecha + "','HoraVB':'" + eval(hora) + "','MinutoVB':'" + eval(minuto) + "','PagColor':'" + eval(pagColor) +
            "','PagImproof':'" + eval(pagImproof) + "','PagArmado':'" + eval(pagArmado) + "','TipoArchivo':'" + TipoArchivo + "','RevisaCSR':'" + RevisaCSR +
            "','Observacion':'" + observ + "','CreadoPor':'" + usuario + "'}",
            success: function (msg) {
                if (msg.d[0] != 'ERROR') {
                    LimpiaRequerimiento();
                } else {
                    alert('error al finalizar solicitud');
                }
            },
            error: function () {
                alert('¡Ha Ocurrido un Error!');
            }
        });
            
        }
        function NuevaDireccion() {
            document.getElementById("divDireccionCSR").style.display = 'block';
            document.getElementById("ddlPais").style.display = 'block';
            document.getElementById("DivRegion").style.display = 'block';
            document.getElementById("ddlCiudad").style.display = 'block';
            document.getElementById("ddlComuna").style.display = 'block';
            document.getElementById("DivDireccionDesp").style.display = 'none';
            document.getElementById("lblPais").style.display = 'none';
            document.getElementById("lblRegion").style.display = 'none';
            document.getElementById("lblCiudad").style.display = 'none';
            document.getElementById("lblComuna").style.display = 'none';
            document.getElementById("lblTipoDireccion").innerHTML = '1';
            CargaPais();
            LimpiaNuevaDireccion();
        }
        function LimpiaNuevaDireccion() {
            document.getElementById("ddlTipo").selectedIndex = 0;
            document.getElementById("ddlDireccion").selectedIndex = 0;
            document.getElementById("lblPais").innerHTML = '';
            document.getElementById("lblRegion").innerHTML = '';
            document.getElementById("lblCiudad").innerHTML = '';
            document.getElementById("lblComuna").innerHTML = '';

            document.getElementById("txtNroTipo").value = '';
            document.getElementById("txtPiso").value = '';
            document.getElementById("txtContacto").value = '';
            document.getElementById("txtArea").value = '';
            document.getElementById("txtTelefono").value = '';
            document.getElementById("txtCelular").value = '';
            document.getElementById("txtCorreo").value = '';
            document.getElementById("txtObservacionDireccion").value = '';
        }
        function LimpiaGuardarDireccion() {
            document.getElementById("divDireccionCSR").style.display = 'none';
            document.getElementById("ddlPais").style.display = 'none';
            document.getElementById("DivRegion").style.display = 'none';
            document.getElementById("ddlCiudad").style.display = 'none';
            document.getElementById("ddlComuna").style.display = 'none';
            document.getElementById("DivDireccionDesp").style.display = 'block';
            document.getElementById("lblPais").style.display = 'block';
            document.getElementById("lblRegion").style.display = 'block';
            document.getElementById("lblCiudad").style.display = 'block';
            document.getElementById("lblComuna").style.display = 'block';
        }
        function LimpiaRequerimiento() {
            document.getElementById("ddlHora").selectedIndex = 0;
            document.getElementById("ddlMinuto").selectedIndex = 0;
            document.getElementById("ddlTipoDeArchivo").selectedIndex = 0;
            document.getElementById("txtFecha").value = '';
            document.getElementById("txtPagColor").value = '';
            document.getElementById("txtPagImproof").value = '';
            document.getElementById("txtPagArmado").value = '';
            document.getElementById("txtObservacion").value = '';
            document.getElementById("rdNo").checked == true;
        }

        function GuardarDireccion() {
            var idDireccion = '';
            var rutCliente = '';
            var cliente = '';
            var direccion = '';
            var pais = '';
            var region = '';
            var ciudad = '';
            var comuna = '';
            var tipo = '';
            var nrotipo = '';
            var piso = '';
            var contacto = '';
            var codTelefono = '';
            var AreaTelefono = '';
            var telefono = '';
            var AreaCelular = '';
            var celular = '';
            var correo = '';
            var observacion = '';
            var usuario = '';
            var TipoDireccion = document.getElementById("lblTipoDireccion").innerHTML;
            if (TipoDireccion == '1') {
                idDireccion = '0';
                direccion = document.getElementById("txtDireccion").value;
                var select2 = document.getElementById("ddlPais");
                pais = select2.options[select2.selectedIndex].text;
                var select3 = document.getElementById("ddlRegion");
                region = select3.options[select3.selectedIndex].text;
                var select4 = document.getElementById("ddlCiudad");
                ciudad = select4.options[select4.selectedIndex].text;
                var select5 = document.getElementById("ddlComuna");
                comuna = select5.options[select5.selectedIndex].text;
            } else {
                var select1 = document.getElementById("ddlDireccion");
                direccion = select1.options[select1.selectedIndex].text;
                idDireccion = select1.options[select1.selectedIndex].value;
                pais = document.getElementById("lblPais").innerHTML;
                region = document.getElementById("lblRegion").innerHTML;
                ciudad = document.getElementById("lblCiudad").innerHTML;
                comuna = document.getElementById("lblComuna").innerHTML;
            }
            rutCliente = document.getElementById("lblRutCliente").innerHTML;
            cliente = document.getElementById("lblClienteD").innerHTML; 
            var select2 = document.getElementById("ddlTipo");
            tipo = select2.options[select2.selectedIndex].text;           
            nrotipo = document.getElementById("txtNroTipo").value;
            piso = document.getElementById("txtPiso").value;
            contacto = document.getElementById("txtContacto").value;
            codTelefono = document.getElementById("txtCodigo").value;
            AreaTelefono = document.getElementById("txtArea").value;
            telefono = document.getElementById("txtTelefono").value;
            AreaCelular = document.getElementById("txtCelCodigo").value;
            celular = document.getElementById("txtCelular").value;
            correo = document.getElementById("txtCorreo").value;
            observacion = document.getElementById("txtObservacionDireccion").value;
            usuario = document.getElementById("lblUsuario").innerHTML;

            $.ajax({
                url: "Requerimientos.aspx/GuardaDirecciones",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDDireccion':'" + idDireccion + "','RutCliente':'" + rutCliente + "','Cliente':'" + cliente + "','Direccion':'" + direccion + "','Pais':'" + pais + "','Region':'" + region + "','Ciudad':'" + ciudad +
                "','Comuna':'" + comuna + "','Tipo':'" + tipo + "','NroTipo':'" + nrotipo + "','Piso':'" + piso + "','Contacto':'" + contacto +
                "','CodTelefono':'" + codTelefono + "','AreaTelefono':'" + AreaTelefono + "','Telefono':'" + telefono +
                "','AreaCelular':'" + AreaCelular + "','Celular':'" + celular + "','Correo':'" + correo + "','Observacion':'" + observacion + "','Usuario':'" + usuario + "','TipoDireccion':'" + TipoDireccion + "'}",
                success: function (msg) {
                    if (msg.d[0] != 'Error') {
                        muestraDirecciones();
                        LimpiaGuardarDireccion();
                        LimpiaNuevaDireccion();
                        CargaDirecciones(document.getElementById("lblRutCliente").innerHTML);
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });

        }

        function muestraDirecciones() {
            var usuario = document.getElementById("lblUsuario").innerHTML;
            $.ajax({
                url: "Requerimientos.aspx/muestraDirecciones",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Usuario':'" + usuario + "'}",
                success: function (data) {
                    var algo = data.d.replace(/_/g, '"');
                    $('#tblDirecciones').DataTable({
                        "searching": false,
                        "scrollY": "55px",
                        "scrollCollapse": true,
                        "paging": false,
                        "bDestroy": true,
                        "aaData": JSON.parse(algo),
                        "aoColumns": [

                                {
                                    "mDataProp": "Cliente"
                                },
                                {
                                    "mDataProp": "Direccion"
                                },
                                {
                                    "mDataProp": "Comuna"
                                },
                                {
                                    "mDataProp": "Tipo"
                                },
                                {
                                    "mDataProp": "NroTipo"
                                },
                                {
                                    "mDataProp": "Piso"
                                },
                                {
                                    "mDataProp": "Contacto"
                                },
                                {
                                    "mDataProp": "Observacion"
                                },
                                {
                                    "mDataProp": "Editar"
                                }]
                                ,
                                "aoColumnDefs": [{ "bVisible": false, "aTargets": [8]}]
                    });
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function MostarBotonesagregar() {
            document.getElementById("PopupModelos").style.visibility = "visible";
           // document.getElementById("
        }
        function DetalleDireccion() {
            var select2 =  document.getElementById("ddlDireccion");
            var idDireccion = select2.options[select2.selectedIndex].value;
            var Direccion = select2.options[select2.selectedIndex].text;
            $.ajax({
                url: "Requerimientos.aspx/CargarDireccionesDetalle",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDDireccion':'" + idDireccion + "','Direccion':'" + Direccion + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'Error') {
                        alert('Error al carga detalle direccion');
                    } else {
                        document.getElementById("lblPais").innerHTML = msg.d[0];
                        document.getElementById("lblRegion").innerHTML = msg.d[1];
                        document.getElementById("lblCiudad").innerHTML = msg.d[2];
                        document.getElementById("lblComuna").innerHTML = msg.d[3];
                        document.getElementById("ddlTipo").value = msg.d[4];
                        document.getElementById("txtNroTipo").value = msg.d[5];
                        document.getElementById("txtPiso").value = msg.d[6];
                        document.getElementById("txtContacto").value = msg.d[7];
                        document.getElementById("txtCodigo").value = msg.d[8];
                        document.getElementById("txtArea").value = msg.d[9];
                        document.getElementById("txtTelefono").value = msg.d[10];
                        document.getElementById("txtCelCodigo").value = msg.d[11];
                        document.getElementById("txtCelular").value = msg.d[12];
                        document.getElementById("txtCorreo").value = msg.d[13];
                        if (msg.d[4] != '' && msg.d[5] != '') {
                            document.getElementById("txtCodigo").value = '+562';
                            document.getElementById("txtCelCodigo").value = '+569';
                        } else {

                            document.getElementById("ddlTipo").style.display = 'block';
                            document.getElementById("txtNroTipo").style.display = 'block';
                            document.getElementById("txtPiso").style.display = 'block';
                            document.getElementById("txtContacto").style.display = 'block';
                            document.getElementById("txtCodigo").style.display = 'block';
                            document.getElementById("txtArea").style.display = 'block';
                            document.getElementById("txtTelefono").style.display = 'block';
                            document.getElementById("txtCelCodigo").style.display = 'block';
                            document.getElementById("txtCelular").style.display = 'block';
                            document.getElementById("txtCorreo").style.display = 'block';
                        }
                    }
                },
                error: function () {
                    alert('Error al cargar detalle');
                }
            });
        }

        function CargaDirecciones(rut) {
            var ddlTerritory = document.getElementById("ddlDireccion");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            $.ajax({
                url: "Requerimientos.aspx/CargarDirecciones",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Rut':'" + rut + "'}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        $("#ddlDireccion").append($("<option></option>").val(value.IDDireccion).html(value.Direccion));

                    });
                },
                error: function () {
                    alert('¡Error al cargar direcciones!');
                }
            });

        }
        function CargaTipo() {
            var ddlTerritory = document.getElementById("ddlTipo");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            $.ajax({
                url: "Requerimientos.aspx/CargarTipo",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        $("#ddlTipo").append($("<option></option>").val(value.IDDireccion).html(value.Direccion));

                    });
                },
                error: function () {
                    alert('¡Error al cargar direcciones!');
                }
            });

        }
        function CargaTipoArchivo() {
            var ddlTerritory = document.getElementById("ddlTipoDeArchivo");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            $.ajax({
                url: "Requerimientos.aspx/CargarTipoArchivo",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        $("#ddlTipoDeArchivo").append($("<option></option>").val(value.IDDireccion).html(value.Direccion));

                    });
                },
                error: function () {
                    alert('¡Error al cargar direcciones!');
                }
            });

        }
        function CargaPais() {
            var ddlTerritory = document.getElementById("ddlPais");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            var rut = '';
            $.ajax({
                url: "Requerimientos.aspx/CargaPais",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDPais':'" + rut + "'}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        $("#ddlPais").append($("<option></option>").val(value.IDDireccion).html(value.Direccion));

                    });
                },
                error: function () {
                    alert('¡Error al cargar direcciones!');
                }
            });

        }
        function CargaRegion() {
            var ddlTerritory = document.getElementById("ddlRegion");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            var select2 = document.getElementById("ddlPais");
            var idpais = select2.options[select2.selectedIndex].value;
            if (idpais != 'Seleccionar') {

                $.ajax({
                    url: "Requerimientos.aspx/CargaRegion",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'IDPais':'" + idpais + "'}",
                    success: function (data) {
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            $("#ddlRegion").append($("<option></option>").val(value.IDDireccion).html(value.Direccion));

                        });
                    },
                    error: function () {
                        alert('¡Error al cargar direcciones!');
                    }
                });
            }
        }
        function CargaCiudad() {
            var ddlTerritory = document.getElementById("ddlCiudad");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            var select2 = document.getElementById("ddlRegion");
            var idpais = select2.options[select2.selectedIndex].value;
            if (idpais != 'Seleccionar') {
                $.ajax({
                    url: "Requerimientos.aspx/CargaCiudad",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'IDRegion':'" + idpais + "'}",
                    success: function (data) {
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            $("#ddlCiudad").append($("<option></option>").val(value.IDDireccion).html(value.Direccion));

                        });
                    },
                    error: function () {
                        alert('¡Error al cargar direcciones!');
                    }
                });
            }

        }
        function CargaComuna() {
            var ddlTerritory = document.getElementById("ddlComuna");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            var select2 = document.getElementById("ddlCiudad");
            var idpais = select2.options[select2.selectedIndex].value;
            if (idpais != 'Seleccionar') {
                $.ajax({
                    url: "Requerimientos.aspx/CargaComuna",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    data: "{'idCiudad':'" + idpais + "'}",
                    success: function (data) {
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            $("#ddlComuna").append($("<option></option>").val(value.IDDireccion).html(value.Direccion));

                        });
                    },
                    error: function () {
                        alert('¡Error al cargar direcciones!');
                    }
                });
            }
        }
        function MostrarFormReq() {
            document.getElementById("DivNuevoRequerimiento").style.display = 'block';
            document.getElementById("DivHistorialRequerimiento").style.display = 'none';

            document.getElementById("DivModificarReq").style.display = 'none';
            document.getElementById("DivFinalizarReq").style.display = 'block';
            document.getElementById("PopupInserto").style.display = 'block';
            document.getElementById("DivFooterRequerimiento").style.display = 'block';
            document.getElementById("DivFooterModificar").style.display = 'none';
            

            LimpiaRequerimiento();
            LimpiaGuardarDireccion();
            LimpiaNuevaDireccion();

            $.ajax({
                url: "Requerimientos.aspx/limpiaRegistro",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDRequerimiento':'10'}",
                success: function (data) {
                    var algo = data.d.replace(/_/g, '"');
                    $('#tblDirecciones').DataTable({
                        "searching": false,
                        "scrollY": "55px",
                        "scrollCollapse": true,
                        "paging": false,
                        "bDestroy": true,
                        "aaData": JSON.parse(algo),
                        "aoColumns": [

                                {
                                    "mDataProp": "Cliente"
                                },
                                {
                                    "mDataProp": "Direccion"
                                },
                                {
                                    "mDataProp": "Comuna"
                                },
                                {
                                    "mDataProp": "Tipo"
                                },
                                {
                                    "mDataProp": "NroTipo"
                                },
                                {
                                    "mDataProp": "Piso"
                                },
                                {
                                    "mDataProp": "Contacto"
                                },
                                {
                                    "mDataProp": "Observacion"
                                },
                                {
                                    "mDataProp": "Editar"
                                }],
                                "aoColumnDefs": [{ "bVisible": false, "aTargets": [8]}]
                    });
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
           
                            

        }
        function MostrarHistorial() {
            document.getElementById("DivHistorialRequerimiento").style.display = 'block';
            document.getElementById("DivNuevoRequerimiento").style.display = 'none';
        }
        function cargaHistorial() {
            var OT = document.getElementById("lblOP").innerHTML;
            var tabll;
            $.ajax({
                url: "Requerimientos.aspx/cargaHistoriales",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'OT':'" + OT + "'}",
                success: function (data) {
                    var algo = data.d.replace(/_/g, '"');
                    tabll = $('#tblHistorial').DataTable({
                        "searching": false,
                        "scrollY": "250vh",
                        "scrollCollapse": true,
                        "paging": false,
                        "bDestroy": true,
                        "aaData": JSON.parse(algo),
                        "aoColumns": [

                                {
                                    "mDataProp": "NroRequerimiento"
                                },
                                {
                                    "mDataProp": "FechaVB"
                                },
                                {
                                    "mDataProp": "PagColor"
                                },
                                {
                                    "mDataProp": "PagImproof"
                                },
                                {
                                    "mDataProp": "PagArmado"
                                },
                                {
                                    "mDataProp": "TipoArchivo"
                                },
                                {
                                    "mDataProp": "RevisaCSR"
                                },
                                {
                                    "mDataProp": "Observacion"
                                },
                                {
                                    "mDataProp": "CreadoPor"
                                },
                                {
                                    "mDataProp": "FechaCreacion"
                                },
                                {
                                    "mDataProp": "Direcciones"
                                }]
                    });
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function VerSolicitud(idreq) {
            document.getElementById("DivNuevoRequerimiento").style.display = 'block';
            document.getElementById("DivHistorialRequerimiento").style.display = 'none';


            document.getElementById("PopupInserto").style.display = 'none';
            document.getElementById("DivFinalizarReq").style.display = 'none';
            document.getElementById("DivModificarReq").style.display = 'block';
            $.ajax({
                url: "Requerimientos.aspx/ModificaRequerimiento",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDRequerimiento':'" + idreq + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'Error') {
                        alert('Error al carga detalle direccion');
                    } else {
                        document.getElementById("txtFecha").value = msg.d[0];
                        document.getElementById("ddlHora").value = msg.d[1];
                        document.getElementById("ddlMinuto").value = msg.d[2];
                        document.getElementById("txtPagColor").value = msg.d[3];
                        document.getElementById("txtPagImproof").value = msg.d[4];
                        document.getElementById("txtPagArmado").value = msg.d[5];
                        document.getElementById("ddlTipoDeArchivo").value = msg.d[6];
                        document.getElementById("txtObservacion").value = msg.d[8];
                        if (msg.d[7] == 'Si') {
                            document.getElementById("rdSi").checked = true;

                        } else {
                            document.getElementById("rdNo").checked = true;

                        }
                        cargaDireccionesEdit(idreq);
                    }
                },
                error: function () {
                    alert('Error al cargar detalle');
                }
            });
        }
        function cargaDireccionesEdit(idReq) {
            var usuario = document.getElementById("lblUsuario").innerHTML;
            $.ajax({
                url: "Requerimientos.aspx/cargaDireccionesEdit",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDRequerimiento':'" + idReq + "'}",
                success: function (data) {
                    var algo = data.d.replace(/_/g, '"');
                    $('#tblDirecciones').DataTable({
                        "searching": false,
                        "scrollY": "55px",
                        "scrollCollapse": true,
                        "paging": false,
                        "bDestroy": true,
                        "aaData": JSON.parse(algo),
                        "aoColumns": [

                                {
                                    "mDataProp": "Cliente"
                                },
                                {
                                    "mDataProp": "Direccion"
                                },
                                {
                                    "mDataProp": "Comuna"
                                },
                                {
                                    "mDataProp": "Tipo"
                                },
                                {
                                    "mDataProp": "NroTipo"
                                },
                                {
                                    "mDataProp": "Piso"
                                },
                                {
                                    "mDataProp": "Contacto"
                                },
                                {
                                    "mDataProp": "Observacion"
                                },
                                {
                                    "mDataProp": "Editar"
                                }]
                    });
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function VerDireccionEdit(idDireccion) {
            document.getElementById("Button2").style.display = 'none';

            document.getElementById("DivFooterRequerimiento").style.display = 'none';
            document.getElementById("DivFooterModificar").style.display = 'block';
            $.ajax({
                url: "Requerimientos.aspx/CargaDireccionModi",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDDireccion':'" + idDireccion + "'}",
                success: function (msg) {
                    if (msg.d[0] != 'Error') {
                        //document.getElementById("ddlDireccion").outerHTML = msg.d[1];
                       // document.getElementById("ddlDireccion").text = msg.d[1];
                        var ddlReport = document.getElementById("ddlDireccion");
                        ddlReport.options[ddlReport.selectedIndex].text = msg.d[1];
                        document.getElementById("lblIDDireccion").innerHTML = msg.d[0];
                        document.getElementById("lblPais").innerHTML = msg.d[2];
                        document.getElementById("lblRegion").innerHTML = msg.d[3];
                        document.getElementById("lblCiudad").innerHTML = msg.d[4];
                        document.getElementById("lblComuna").innerHTML = msg.d[5];
                        document.getElementById("ddlTipo").value = msg.d[6];
                        document.getElementById("txtNroTipo").value = msg.d[7];
                        document.getElementById("txtPiso").value = msg.d[8];
                        document.getElementById("txtContacto").value = msg.d[9];
                        document.getElementById("txtCodigo").value = msg.d[10];
                        document.getElementById("txtArea").value = msg.d[11];
                        document.getElementById("txtTelefono").value = msg.d[12];
                        document.getElementById("txtCelCodigo").value = msg.d[13];
                        document.getElementById("txtCelular").value = msg.d[14];
                        document.getElementById("txtCorreo").value = msg.d[15];
                        document.getElementById("txtObservacionDireccion").value = msg.d[16];
                    } else {
                        alert('Error al cargar direccion');
                    }
                },
                error: function () {
                    alert('Error al cargar detalle');
                }
            });
        }
        function ModificarDireccion() {
            var select1 = document.getElementById("ddlDireccion");
            var Direccion = select1.options[select1.selectedIndex].text;
            var select2 = document.getElementById("ddlTipo");
            var Tipo = select2.options[select2.selectedIndex].value;
            var nroTipo = document.getElementById("txtNroTipo").value;
            var piso = document.getElementById("txtPiso").value;
            var contacto = document.getElementById("txtContacto").value;
            var codTelefono = document.getElementById("txtCodigo").value;
            var areaTelefono = document.getElementById("txtArea").value;
            var telefono = document.getElementById("txtTelefono").value;
            var areaCelular = document.getElementById("txtCelCodigo").value;
            var celular = document.getElementById("txtCelular").value;
            var correo = document.getElementById("txtCorreo").value;
            var observacion = document.getElementById("txtObservacionDireccion").value;
            var IDDireccion = document.getElementById("lblIDDireccion").innerHTML;
            $.ajax({
                url: "Requerimientos.aspx/ModificaDireccion",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDDireccion':'" + IDDireccion + "','Direccion':'" + Direccion + "','Tipo':'" + Tipo + "','NroTipo':'" + nroTipo + "','Piso':'" + piso
                + "','Contacto':'" + contacto + "','CodTelefono':'" + codTelefono + "','AreaTelfono':'" + areaTelefono + "','Telefono':'" + telefono + "','AreaCelular':'" + areaCelular
                +"','Celular':'"+celular+"','Correo':'"+observacion+"'}",
                success: function (msg) {
                    if (msg.d[0] != 'Error') {
                    } else {
                        alert('Error al cargar direccion');
                    }
                },
                error: function () {
                    alert('Error al cargar detalle');
                }
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                EnablePageMethods="True">
            </asp:ToolkitScriptManager>
    <div style="padding:15px;">
    <div class="panel panel-primary">
        <div class="panel-body" style="padding:5px;">
            Crear Solicitud</div>
        <div class="panel-footer" style="padding:5px;">
            <table class="table table-condensed">
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                        <b>Número OP:</b>
                    </td>
                    <td>
                            <asp:Label ID="lblOP" runat="server"></asp:Label>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;">
                        <b>Nombre OP:</b>
                    </td>
                    <td>
                        <asp:Label ID="lblNombreOP" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                        <b>Cliente:</b></td>
                    <td colspan="2">
                            <asp:Label ID="lblCliente" runat="server"></asp:Label>
                            <asp:Label ID="lblRutCliente" runat="server" style="display:none;"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                        <b>Fecha Creación:</b></td>
                    <td>
                            <asp:Label ID="lblFechaCreacion" runat="server"></asp:Label>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;">
                        <b>CSR:</b></td>
                    <td>
                        <asp:Label ID="lblCSR" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                       <b>Tiraje:</b></td>
                    <td>
                            <asp:Label ID="lblTiraje" runat="server"></asp:Label>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;">
                        <b>Formato Cerrado:</b></td>
                    <td>
                        <asp:Label ID="lblFormatoCerrado" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div id="DivHistorialRequerimiento">
      <div class="panel panel-primary">
        <div class="panel-body" style="padding:5px;">
            Requerimientos Realizados &nbsp; &nbsp;
            <button type="button" class="btn btn-primary" data-toggle="modal" onclick="javascript:MostrarFormReq();" id="Button1">
                <span class="glyphicon glyphicon-plus"></span>Agregar</button>
        </div>
     

            <table style="width: 100%;margin-bottom:0px;"  id="tblHistorial" class="table table-striped table-bordered" cellspacing="0" >
                <thead>
                    <tr>
                        <th data-field="NroRequerimiento" data-align="right" data-sortable="true">
                            Nro Req.
                        </th>
                        <th data-field="FechaVB" data-align="right" data-sortable="true">
                            Fecha V°B
                        </th>
                        <th data-field="PagColor" data-align="right" data-sortable="true">
                            Pags. Color
                        </th>
                        <th data-field="PagImproof" data-align="right" data-sortable="true">
                            Pags. Improof
                        </th>
                        <th data-field="PagArmado" data-align="right" data-sortable="true">
                            Pags. Armado
                        </th>
                        <th data-field="TipoArchivo" data-align="right" data-sortable="true">
                            Tipo Archivo
                        </th>
                        <th data-field="RevisaCSR" data-align="right" data-sortable="true">
                            Revisa CSR
                        </th>
                        <th data-field="Observacion" data-align="right" data-sortable="true">
                            Observacion
                        </th>
                        <th data-field="CreadoPor" data-align="right" data-sortable="true">
                            Usuario
                        </th>
                        <th data-field="FechaCreacion" data-align="right" data-sortable="true">
                            Creacion
                        </th>
                        <th data-field="Direcciones" data-align="right" data-sortable="true">
                            Direcciones
                        </th>
                    </tr>
                </thead>
                
            </table>
     
    </div>
    </div>

    <div id="DivNuevoRequerimiento" style="display:none;">
        <div class="panel panel-primary">
        <div class="panel-body" style="padding:5px;">
            Requerimientos</div>
        <div class="panel-footer">
            <table class="table table-condensed" style="padding:5px;">
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                        Fecha V°B°:</td>
                    <td>
                          <div class="col-sm-6">
                          <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFecha" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
                          </div>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;">
                        Hora:
                    </td>
                    <td>
                  
                            <div class="col-sm-5"> <asp:DropDownList ID="ddlHora" runat="server" CssClass="form-control">
                                <asp:ListItem>00</asp:ListItem>
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem>03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>06</asp:ListItem>
                                <asp:ListItem>07</asp:ListItem>
                                <asp:ListItem>08</asp:ListItem>
                                <asp:ListItem>09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                            </asp:DropDownList></div>
                            &nbsp;<div class="col-sm-5"> <asp:DropDownList ID="ddlMinuto" runat="server" CssClass="form-control">
                                <asp:ListItem>00</asp:ListItem>
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem>03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>06</asp:ListItem>
                                <asp:ListItem>07</asp:ListItem>
                                <asp:ListItem>08</asp:ListItem>
                                <asp:ListItem>09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                                <asp:ListItem>26</asp:ListItem>
                                <asp:ListItem>27</asp:ListItem>
                                <asp:ListItem>28</asp:ListItem>
                                <asp:ListItem>29</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>31</asp:ListItem>
                                <asp:ListItem>32</asp:ListItem>
                                <asp:ListItem>33</asp:ListItem>
                                <asp:ListItem>34</asp:ListItem>
                                <asp:ListItem>35</asp:ListItem>
                                <asp:ListItem>36</asp:ListItem>
                                <asp:ListItem>37</asp:ListItem>
                                <asp:ListItem>38</asp:ListItem>
                                <asp:ListItem>39</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>41</asp:ListItem>
                                <asp:ListItem>42</asp:ListItem>
                                <asp:ListItem>43</asp:ListItem>
                                <asp:ListItem>44</asp:ListItem>
                                <asp:ListItem>45</asp:ListItem>
                                <asp:ListItem>46</asp:ListItem>
                                <asp:ListItem>47</asp:ListItem>
                                <asp:ListItem>48</asp:ListItem>
                                <asp:ListItem>49</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>51</asp:ListItem>
                                <asp:ListItem>52</asp:ListItem>
                                <asp:ListItem>53</asp:ListItem>
                                <asp:ListItem>54</asp:ListItem>
                                <asp:ListItem>55</asp:ListItem>
                                <asp:ListItem>56</asp:ListItem>
                                <asp:ListItem>57</asp:ListItem>
                                <asp:ListItem>58</asp:ListItem>
                                <asp:ListItem>59</asp:ListItem>
                            </asp:DropDownList></div>
                        
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                        N° Páginas Color:</td>
                    <td>
                          <div class="col-sm-6"><asp:TextBox ID="txtPagColor" runat="server" 
                                  CssClass="form-control"></asp:TextBox></div>
                          </td>
                    <td style="vertical-align: bottom;padding: 8px;">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                        N° Páginas Improof:</td>
                    <td>
                        <div class="col-sm-6"><asp:TextBox ID="txtPagImproof" runat="server" 
                                CssClass="form-control"></asp:TextBox></div>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                        N° Páginas Armado:</td>
                    <td>
                       <div class="col-sm-6"><asp:TextBox ID="txtPagArmado" runat="server" 
                               CssClass="form-control"></asp:TextBox></div>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                        Tipo de Archivo:</td>
                    <td>
                            <div class="col-sm-6"> 
                            <asp:DropDownList ID="ddlTipoDeArchivo" runat="server" CssClass="form-control">
                            </asp:DropDownList></div>
                        
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;">
                        Revisa CSR:</td>
                    <td>
                        <asp:RadioButton ID="rdSi" runat="server" Text="SI" GroupName="chkRevisa"  />
                            <asp:RadioButton ID="rdNo" runat="server" Text="NO" Checked="True" 
                            GroupName="chkRevisa"  /></td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;">
                        Observación:</td>
                    <td colspan="3">
                    <div class="col-sm-6">
                            <asp:TextBox ID="txtObservacion" runat="server" Height="77px" TextMode="MultiLine" 
                                Width="555px" CssClass="form-control"></asp:TextBox></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
     <div class="panel panel-primary">
        <div class="panel-body" style="padding:5px;">
            Direcciones &nbsp; &nbsp;
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#InsertoModal" id="PopupInserto">
                <span class="glyphicon glyphicon-plus"></span>Agregar</button>
        </div>
            <table  id="tblDirecciones" class="table table-striped table-bordered"  style="width: 100%;margin-bottom:0px;"  cellspacing="0" >
                <thead>
                    <tr>
                        <th data-field="Cliente" data-align="right" data-sortable="true">
                            Cliente
                        </th>
                        <th data-field="Direccion" data-align="right" data-sortable="true">
                            Direccion
                        </th>
                        <th data-field="Comuna" data-align="right" data-sortable="true">
                            Comuna
                        </th>
                        <th data-field="Tipo" data-align="right" data-sortable="true">
                            Tipo
                        </th>
                        <th data-field="NroTipo" data-align="right" data-sortable="true">
                            NroTipo
                        </th>
                        <th data-field="Piso" data-align="right" data-sortable="true">
                            Piso
                        </th>
                        <th data-field="Contacto" data-align="right" data-sortable="true">
                            Contacto
                        </th>
                        <th data-field="Observacion" data-align="right" data-sortable="true">
                            Observacion
                        </th>
                        <th data-field="Editar" data-align="right" data-sortable="true">
                            editar
                        </th>
                    </tr>
                </thead>
                
            </table>

    </div>
                <div align="center" id="DivFinalizarReq">
      <button type="button" class="btn btn-primary" onclick="javascript:GuardarRequerimiento();" data-dismiss="modal" id="btnFinalizar">
                        Finalizar Requerimiento</button>
        &nbsp;&nbsp
       <button type="button" class="btn btn-primary" onclick="javascript:MostrarHistorial();" data-dismiss="modal">
                        Volver</button>
                    </div>
       <div align="center" id="DivModificarReq">
      <button type="button" class="btn btn-primary" onclick="javascript:ModificarRequerimiento();" data-dismiss="modal" id="btnModificarReq">
                        Modificar Requerimiento</button>
        &nbsp;&nbsp
       <button type="button" class="btn btn-primary" onclick="javascript:MostrarHistorial();" data-dismiss="modal">
                        Volver</button>
                    </div>
</div>


    <div >
        <asp:Label ID="lblArray" runat="server"></asp:Label>

        </div>

       <div class="modal fade bs-example-modal-lg" id="InsertoModal" role="dialog">
        <div class="modal-dialog modal-lg" style="width:920px;">  
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">
                        Agregar Direcciones</h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tr>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">
                                Cliente:</td>
                            <td colspan="2" align="left">
                                <asp:Label ID="lblClienteD" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Dirección:</td>
                            <td align="left" colspan="2">
                                <div class="col-sm-12." id="DivDireccionDesp">
                                    <asp:DropDownList ID="ddlDireccion" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                  <div id="divDireccionCSR" class="col-sm-12." style="display:none;">
                                      <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                                  </div>
                            </td>
                            <td>

                                <button type="button" class="btn btn-primary" onclick="javascript:NuevaDireccion();" id="Button2">
                <span class="glyphicon glyphicon-plus"></span>Agregar</button>
                                </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Pais:</td>
                            <td>
                               <div align="left" class="col-sm-5.">
                                    <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control" style="display:none;">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblPais" runat="server"></asp:Label>
                                </div></td>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Región:</td>
                            <td align="left" colspan="3">
                             <asp:Label ID="lblRegion" runat="server"></asp:Label>
                                <div id="DivRegion" class="col-sm-5"  style="display:none;">
                                    <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" >
                                    </asp:DropDownList>
                                </div>
                                
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Ciudad:</td>
                            <td align="left">

                                <div class="col-sm-5.">
                                    <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="form-control" 
                                        style="display:none;">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                                </div>

                            </td>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Comuna:</td>
                            <td align="left" colspan="2">
 
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="ddlComuna" runat="server" CssClass="form-control" 
                                        style="display:none;">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblComuna" runat="server"></asp:Label>
                                </div>
 
                            </td>
                            <td>

                            </td>
                        </tr>
                        
                        <tr>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Tipo:</td>
                            <td align="left">
                                <div class="col-sm-14.">
                                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" >
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">
                                <asp:Label 
                                    ID="lblTipoNro" runat="server"></asp:Label>
&nbsp;N° : </td>
                            <td align="left">
                                <div class="col-sm-6 textboxcorto" style="padding-right:0px;padding-left:0px;">
                                    <asp:TextBox ID="txtNroTipo" runat="server" CssClass="form-control" ></asp:TextBox>
                                   
                                </div>
                            </td>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;"> 
                                Piso:</td>
                            <td align="left">
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtPiso" runat="server" CssClass="form-control"></asp:TextBox>
                                   
                                </div>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Contacto:</td>
                            <td align="left">
                                <div class="col-sm-10. textboxcorto">
                                    <asp:TextBox ID="txtContacto" runat="server" CssClass="form-control"></asp:TextBox>
                                   
                                </div>
                            </td>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Telefono:</td>
                            <td align="left">
                            <div class="col-sm-2 textboxcorto" style="padding-right:1px;padding-left:1px;">
                                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" 
                                        style="padding: 0px 0px;" >+562</asp:TextBox>
                                    </div>
                             <div class="col-sm-1 textboxcorto"  style="padding-right:1px;padding-left:1px;">
                                    <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" style="padding: 0px 0px;" ></asp:TextBox>
                                    </div>
                                <div class="col-sm-3 textboxcorto"  style="padding-right:1px;padding-left:1px;">
                                   <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" style="padding: 0px 0px;"></asp:TextBox>
                                   
                                </div>
                            </td>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">
                                Celular:</td>
                            <td align="left">
                         <div class="col-sm-3 textboxcorto" style="padding-right:1px;padding-left:1px;">
                                    <asp:TextBox ID="txtCelCodigo" runat="server" CssClass="form-control" style="padding: 0px 0px;" >+569</asp:TextBox>
                                    </div>
                                <div class="col-sm-5 textboxcorto" style="padding-right:1px;padding-left:1px;">
                                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"  ></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Correo:</td>
                            <td align="left">
                                <div class="col-sm-12. textboxcorto">
                                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" ></asp:TextBox>
                                    
                                </div>
                            </td>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td style="vertical-align: middle;padding: 8px;font-weight: bold;">Observación:</td>
                            <td align="left" colspan="5">
                                <div class="col-sm-12.">
                                    <asp:TextBox ID="txtObservacionDireccion" runat="server" CssClass="form-control" 
                                        Height="77px" TextMode="MultiLine" Width="555px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        </table>
                </div>
                <div class="modal-footer" id="DivFooterRequerimiento">
                    <asp:Label ID="lblUsuario" runat="server" Text="Label" style="display:none;"></asp:Label>
                    <asp:Label ID="lblTipoDireccion" runat="server" Text="0" style="display:none;"></asp:Label>
                    <button type="button" class="btn btn-primary" onclick="javascript:GuardarDireccion();" data-dismiss="modal" id="btnGuardarDirecc">
                        Guardar Direccion</button>
                    <button type="button" class="btn btn-default" onclick="javascript:LimpiarFormulario('Inserto');" data-dismiss="modal">
                        Cerrar</button>
                </div>
                                <div class="modal-footer" id="DivFooterModificar">
                    <asp:Label ID="lblIDDireccion" runat="server" Text="Label" style="display:none;"></asp:Label>
                    <button type="button" class="btn btn-primary" onclick="javascript:ModificarDireccion();" data-dismiss="modal" id="Button3">
                        Modificar Direccion</button>
                    <button type="button" class="btn btn-default" onclick="javascript:LimpiarFormulario('Inserto');" data-dismiss="modal">
                        Cerrar</button>
                </div>
            </div>
      </div>
    </div>


    </div>
    </form>
</body>
</html>
