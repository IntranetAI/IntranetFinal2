<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearOC.aspx.cs" Inherits="Intranet.ModuloBodegaPliegos.View.CrearOC" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crear Orden de Compra</title>
    <link href="../../Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.10/js/dataTables.bootstrap.min.js"></script>
 <style type="text/css">
 .body{padding-right: 0px;padding-left: 0px;}
 textboxcorto {padding-right: 2px;padding-left: 0px;}
     .style1
     {
         width: 144px;
     }
     .style2
     {
         width: 162px;
     }
     .style7
     {
         width: 344px;
     }
     .style9
     {
         width: 89px;
     }
     .style10
     {
         width: 668px;
     }
     .style11
     {
         width: 438px;
     }
     .style12
     {
         width: 285px;
     }
     .style13
     {
         width: 841px;
     }
     .style14
     {
         width: 118px;
     }
     .style19
     {
         width: 93px;
     }
     .style20
     {
         width: 127px;
     }
     .style21
     {
         width: 130px;
     }
     .style22
     {
         width: 138px;
     }
     .style23
     {
         width: 116px;
     }
 </style>
     <script type="text/javascript" language="javascript">

        $(document).ready(function () {
        });
        function cargaDatosProveedor(id) {
            $.ajax({
                url: "CrearOC.aspx/CargarDatosProveedor",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDProveedor':'" + id + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'ERROR') {
                        alert('¡Ha Ocurrido un error al cargar proveedor!');
                    } else {
                        document.getElementById("lblRutProveedor").innerHTML = msg.d[0];
                        document.getElementById("lblProveedor").innerHTML = msg.d[1];
                        document.getElementById("txtCorreo").value = msg.d[2];
                        document.getElementById("txtTelefono").value = msg.d[3];
                        CargaDirecciones(id, msg.d[5]);
                        CargaCondicion(id, msg.d[4]);
                    }
                },
                error: function () {
                    alert('Error al cargar detalle');
                }
            });
        }
        function CargaDirecciones(idProveedor,direccion) {
            var ddlTerritory = document.getElementById("ddlDireccion");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            $.ajax({
                url: "CrearOC.aspx/CargarDirecciones",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDProveedor':'" + idProveedor + "'}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        $("#ddlDireccion").append($("<option></option>").val(value.Direccion).html(value.Direccion));

                    });
                    document.getElementById("ddlDireccion").value = direccion;
                },
                error: function () {
                    alert('¡Error al cargar direcciones!');
                }
            });
        }
        function CargaCondicion(idProveedor,condicion) {
            var ddlTerritory = document.getElementById("ddlCondicionPago");
            var lengthddlTerritory = ddlTerritory.length - 1;
            for (var i = lengthddlTerritory; i >= 0; i--) {
                ddlTerritory.options[i] = null;
            }
            $.ajax({
                url: "CrearOC.aspx/CargarCondicion",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDProveedor':'" + idProveedor + "'}",
                success: function (data) {
                    var jsdata = JSON.parse(data.d);
                    $.each(jsdata, function (key, value) {
                        $("#ddlCondicionPago").append($("<option></option>").val(value.Direccion).html(value.Direccion));

                    });
                    document.getElementById("ddlCondicionPago").value = condicion;
                    document.getElementById("txtContacto").focus();
                },
                error: function () {
                    alert('¡Error al cargar direcciones!');
                }
            });
        }
        function BuscarProveedor() {
            var usuario = document.getElementById("txtProveedor").value;
            var rut = document.getElementById("txtRut").value;
            $.ajax({
                url: "CrearOC.aspx/muestraProveedores",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'NombreProveedor':'" + usuario + "','Rut':'"+rut+"'}",
                success: function (data) {
                    var algo = data.d.replace(/_/g, '"');
                    $('#tblProveedores').DataTable({
                        "searching": false,
                        "scrollY": "450px",
                        "scrollCollapse": true,
                        "paging": false,
                        "bDestroy": true,
                        "aaData": JSON.parse(algo),
                        "aoColumns": [

                                {
                                    "mDataProp": "Rut"
                                },
                                {
                                    "mDataProp": "Proveedor"
                                },
                                {
                                    "mDataProp": "Seleccionar"
                                }]
//                                ,
//                        "aoColumnDefs": [{ "bVisible": false, "aTargets": [8]}]
                    });
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
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
            Pedido de Compra   &nbsp; &nbsp; <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#viewCrearOC" id="PopupInserto">
                <span class="glyphicon glyphicon-plus"></span>Buscar Proveedor</button></div>
        <div class="panel-footer" style="padding:5px;">
            <table class="table table-condensed">
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style9">
                        &nbsp;</td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style12">
                        <b>Nombre Proveedor:</b>
                    </td>
                    <td class="style13">
                            <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style11">
                        
                        <b>Rut Proveedor:</b></td>
                    <td class="style10">
                        <asp:Label ID="lblRutProveedor" runat="server"></asp:Label>
                    </td>
                    <td class="style7">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style9">
                        &nbsp;</td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style12">
                        <b>Dirección:</b></td>
                    <td class="style13">
                               <div class="col-sm-12." id="DivDireccionDesp">
                                    <asp:DropDownList ID="ddlDireccion" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style11">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style7">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style9">
                        &nbsp;</td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style12">
                        <b>Contacto:</b></td>
                    <td class="style13">
                            <asp:TextBox ID="txtContacto" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style11">
                        <b>Correo:</b></td>
                    <td class="style10">
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td class="style7">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style9">
                        &nbsp;</td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style12">
                        <b>Condicion Pago:</b></td>
                    <td class="style13">
                                <div class="col-sm-12." id="Div1">
                                    <asp:DropDownList ID="ddlCondicionPago" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style11">
                        <b>Telefono:</b></td>
                    <td class="style10">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td class="style7">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style9">
                        &nbsp;</td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style12">
                        <b>Fecha Entrega:</b></td>
                    <td class="style13">
                        <asp:TextBox ID="txtFechaEntrega" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFechaEntrega" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style11">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style7">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style9">
                        &nbsp;</td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style12">
                        <b>Observación:</b></td>
                    <td class="style13">
                            <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style11">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style7">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
    <div id="DivHistorialRequerimiento">
      <div class="panel panel-primary">
        <div class="panel-body" style="padding:5px;">
            Items Agregados&nbsp; &nbsp;
            <button type="button" class="btn btn-primary" data-toggle="modal" onclick="javascript:MostrarFormReq();" id="Button1">
                <span class="glyphicon glyphicon-plus"></span>Agregar Item</button>
        </div>
     

            <table style="width: 100%;margin-bottom:0px;"  id="tblHistorial" class="table table-striped table-bordered" cellspacing="0" >
                <thead>
                    <tr>
                        <th data-field="NroRequerimiento" data-align="right" data-sortable="true">
                           Cod. Item
                        </th>
                        <th data-field="FechaVB" data-align="right" data-sortable="true">
                            Descripcion
                        </th>
                        <th data-field="PagColor" data-align="right" data-sortable="true">
                            Cant. Pliegos
                        </th>
                        <th data-field="PagImproof" data-align="right" data-sortable="true">
                            KGs
                        </th>
                        <th data-field="PagArmado" data-align="right" data-sortable="true">
                           Valor Unitario
                        </th>
                        <th data-field="TipoArchivo" data-align="right" data-sortable="true">
                            Valor Total
                        </th>
                        <th data-field="RevisaCSR" data-align="right" data-sortable="true">
                            IVA %
                        </th>
                        <th data-field="Observacion" data-align="right" data-sortable="true">
                            Total + IVA
                        </th>
                    </tr>
                </thead>
                
            </table>
     
    </div>
    </div>

    </div>
                <%--<div id="DivCrearOC" >
        <div class="panel panel-primary">
        <div class="panel-body" style="padding:5px;">
            Buscar Proveedor</div>
        <div class="panel-footer">
            <table class="table table-condensed" style="padding:5px;">
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style1">
                        Nombre Proveedor:</td>
                    <td>
                          <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtFecha" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
               
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style2">
                        Rut Cliente: 
                    </td>
                    <td>
                                         
                        <asp:TextBox ID="txtPagColor" runat="server" 
                                  CssClass="form-control"></asp:TextBox>
                                         
                    </td>
                    <td>
                     <button type="button" class="btn btn-primary" onclick="javascript:GuardarRequerimiento();" data-dismiss="modal" id="Button3">
                        Buscar</button></td>
                </tr>
                </table>
        </div>
    </div>
     <div class="panel panel-primary">
        <div class="panel-body" style="padding:5px;">
            Direcciones &nbsp; &nbsp;
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

       <button type="button" class="btn btn-primary" onclick="javascript:MostrarHistorial();" data-dismiss="modal">
                        Volver</button>
                        </div>
                   
</div>--%>
<div class="modal fade bs-example-modal-lg" id="viewCrearOC" role="dialog"><%--class="modal fade bs-example-modal-lg" id="viewCrearOC" role="dialog"--%>
        <div class="modal-dialog modal-lg" style="width:920px;">  
            <!-- Modal content-->
            <div class="modal-content" style="height:700px;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">
                        Buscar Proveedor</h4>
                </div>
                <div class="modal-body">
                <table class="table table-condensed" style="padding:5px;">
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style1">
                        Nombre Proveedor:</td>
                    <td>
                          <asp:TextBox ID="txtProveedor" runat="server" CssClass="form-control"></asp:TextBox>

               
                    </td>
                    <td style="vertical-align: bottom;padding: 8px;" class="style2">
                        Rut Cliente: 
                    </td>
                    <td>
                                         
                        <asp:TextBox ID="txtRut" runat="server" 
                                  CssClass="form-control"></asp:TextBox>
                                         
                    </td>
                    <td>
                     <button type="button" class="btn btn-primary" onclick="javascript:BuscarProveedor();" data-toggle="modal" id="Button4">
                        Buscar</button></td>
                </tr>
                </table>
                <div class="panel panel-primary">
        <div class="panel-body" style="padding:5px;">
            Direcciones &nbsp; &nbsp;
        </div>
            <table  id="tblProveedores" class="table table-striped table-bordered"  style="width: 100%;margin-bottom:0px;"  cellspacing="0" >
                <thead>
                    <tr>
                        <th data-field="Rut" style="width:200px;" data-align="right" data-sortable="true">
                            Rut Proveedor
                        </th>
                        <th data-field="Proveedor" data-align="right" data-sortable="true">
                            Nombre Proveedor
                        </th>
                        <th data-field="Seleccionar" style="width:100px;" data-align="right" data-sortable="true">
                            
                        </th>
                    </tr>
                </thead>
                
            </table>

    </div>
                </div>

            
            </div>
      </div>
    </div>

    <div ><%--class="modal fade bs-example-modal-lg" id="viewCrearOC" role="dialog"--%>
        <div class="modal-dialog modal-lg" style="width:920px;">  
            <!-- Modal content-->
            <div class="modal-content" style="height:700px;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">
                        Agregar Item</h4>
                </div>
                <div class="modal-body">
                <table style="padding:5px;">
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style20">
                        Tipo de Papel:</td>
                    <td colspan="3">
                          <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="style21">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom;padding: 8px;" class="style20">
                        Gramaje</td>
                    <td class="style23">
                                         
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td style="vertical-align: bottom;padding: 8px;" align="right" class="style14">
                        &nbsp;&nbsp;
                        Ancho:</td>
                    <td class="style22">
                                         
                        <asp:TextBox ID="TextBox4" runat="server"   CssClass="form-control"></asp:TextBox></td>
                    <td class="style19" align="right">
                        &nbsp;&nbsp;
                        Largo:</td>
                    <td class="style21">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td> &nbsp; &nbsp; &nbsp;
                     <button type="button" class="btn btn-primary" onclick="javascript:BuscarProveedor();" data-toggle="modal" id="Button2">
                        Buscar</button></td>
                </tr>
                </table>
                <br />
                <div class="panel panel-primary">
        <div class="panel-body" style="padding:5px;">
            Papeles&nbsp; &nbsp;
        </div>
            <table  id="Table1" class="table table-striped table-bordered"  style="width: 100%;margin-bottom:0px;"  cellspacing="0" >
                <thead>
                    <tr>
                        <th data-field="Rut" style="width:200px;" data-align="right" data-sortable="true">
                            Rut Proveedor
                        </th>
                        <th data-field="Proveedor" data-align="right" data-sortable="true">
                            Nombre Proveedor
                        </th>
                        <th data-field="Seleccionar" data-align="right" data-sortable="true">
                            
                        </th>
                    </tr>
                </thead>
                
            </table>

    </div>
                </div>

            
            </div>
      </div>
    </div>
    </form>
</body>
</html>
