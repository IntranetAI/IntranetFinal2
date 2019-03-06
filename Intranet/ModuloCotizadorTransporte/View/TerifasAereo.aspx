<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TerifasAereo.aspx.cs" Inherits="Intranet.ModuloCotizadorTransporte.View.TerifasAereo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
          <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">--%>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css"/>
      
    
    
    <script type="text/javascript" lang="javascript">
        $(document).ready(function () {
            listUsers();
        });
        function saveTarifa() {
            var ciudad = document.getElementById("txtCiudad").value;
            var de1a3 = document.getElementById("txtDe01a03").value;
            var de4a150 = document.getElementById("txtDe04a150").value;
            var de151a500 = document.getElementById("txtDe151a500").value;
            var de501aInf = document.getElementById("txtDe501aInfinito").value;
            $.ajax({
                url: "Inicio.aspx/saveTarifa",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Ciudad':'" + ciudad + "','de01a03':'" + de1a3 + "','de04a150':'" + de4a150 + "','de151a500':'"+de151a500+"','de501aInf':'"+de501aInf+"'}",
                success: function (msg) {
                    if (msg.d[0] == 'Error') {
                        $('#divMensaje').removeClass("alert alert-success col-xs-12");
                        $('#divMensaje').addClass("alert alert-danger col-xs-12");
                        $('#divMensaje').show();
                        $('#divMensaje').html('<b>Error!</b> ' + msg.d[1]);
                        $('#divMensaje').delay(6000).hide(500);
                    } else {
                        //$('#divMensaje').remove();
                        $('#divMensaje').removeClass("alert alert-danger col-xs-12");
                        $('#divMensaje').addClass("alert alert-success col-xs-12");
                        $('#divMensaje').show();
                        $('#divMensaje').html('<b>Tarifa Aerea</b> creada correctamente.');
                        $('#divMensaje').delay(6000).hide(500);
                        listUsers();
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function UpdateTarifa() {
            var aereo = $('#<%=lblIdAereos.ClientID %>').text();
            var ciudad= document.getElementById("txtCiudad_2").value;
            var de01a03 = document.getElementById("txtDe01a03_2").value;
            var de04a150 = document.getElementById("txtDe04a150_2").value;
            var de151a500 = document.getElementById("txtDe151a500_2").value;
            var de501aInf = document.getElementById("txtDe501aInfinito_2").value;
            $.ajax({
                url: "Inicio.aspx/UpdateTarifa",
                type: "POST",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IdAereo':'"+aereo+"','Ciudad':'" + ciudad + "','de01a03':'" + de01a03 + "','de04a150':'" + de04a150 + "','de151a500':'" + de151a500 + "','de501aInf':'" + de501aInf + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'Error') {
                        $('#divMensaje').removeClass("alert alert-success col-xs-12");
                        $('#divMensaje').addClass("alert alert-danger col-xs-12");
                        $('#divMensaje').show();
                        $('#divMensaje').html('<b>Error!</b> ' + msg.d[1]);
                        $('#divMensaje').delay(6000).hide(500);
                    } else {
                        //$('#divMensaje').remove();
                        $('#divMensaje').removeClass("alert alert-danger col-xs-12");
                        $('#divMensaje').addClass("alert alert-success col-xs-12");
                        $('#divMensaje').show();
                        $('#divMensaje').html('<b>Tarifa Aerea</b> Modificado correctamente.');
                        $('#divMensaje').delay(6000).hide(500);
                        listUsers();
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error+1!');
                }
            });
        }
         function DeleteTarifa() {
            var idAereos = $('#<%=idAereoDelete.ClientID %>').text();
            $.ajax({
                url: "Inicio.aspx/DeleteTarifa",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IdAereo':'" + idAereos + "'}",
                success: function (msg) {
                    if (msg.d[0] == 'Error') {
                        $('#divMensaje').removeClass("alert alert-success col-xs-12");
                        $('#divMensaje').addClass("alert alert-danger col-xs-12");
                        $('#divMensaje').show();
                        $('#divMensaje').html('<b>Error!</b> ' + msg.d[1]);
                        $('#divMensaje').delay(6000).hide(500);
                    } else {
                        //$('#divMensaje').remove();
                        $('#divMensaje').removeClass("alert alert-danger col-xs-12");
                        $('#divMensaje').addClass("alert alert-success col-xs-12");
                        $('#divMensaje').show();
                        $('#divMensaje').html('<b>Tarifa Aerea</b> Eliminado correctamente.');
                        $('#divMensaje').delay(6000).hide(500);
                        listUsers();
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function listUsers() {
            var table = $("#table-users").DataTable({
                destroy: true,
                reponsive: false,
                ajax: {
                    method: "POST",
                    url: "Inicio.aspx/getTarifas",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: 
                        function (d) {
                        return JSON.stringify(d);
                    },
                    dataSrc: "d.data"
                },
                columns: [
                    { "data": "Ciudad" },
                    { "data": "de01a03" },
                    { "data": "de04a150" },
                    { "data": "de151a500" },
                    { "data": "de501aInfinito" },
                    { "data": "Opciones" }
                ]
            });
        }
        function NuevoTarifa() {
            $("#myModal1").modal("show");
        }
        function ModificaTarifa(idAereo,ciudad, de01a03, de04a150, de151a500, de501aInfinito) {
            $('#<%=lblIdAereos.ClientID %>').html(idAereo);
            document.getElementById("txtCiudad_2").value = ciudad;
            document.getElementById("txtDe01a03_2").value = de01a03;
            document.getElementById("txtDe04a150_2").value = de04a150;
            document.getElementById("txtDe151a500_2").value = de151a500;
            document.getElementById("txtDe501aInfinito_2").value = de501aInfinito;
            $("#myModal2").modal("show");
        }
        function EliminaTarifa(idAereo, d01a03, de04a150, de151a500,de500aInf) {
            $('#<%=idAereoDelete.ClientID %>').html(idAereo);
            $('#<%=lblDe01a03.ClientID %>').html(d01a03);
            $('#<%=lblDe04a150.ClientID %>').html(de04a150);
            $('#<%=lblDe151a500.ClientID %>').html(de151a500);
            $('#<%=lblDe501aInf.ClientID %>').html(de500aInf);
            $("#myModal3").modal("show");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

    <div style="padding:10px;"> 
                <div id="divMensaje"></div>
            <button type="button" class="btn btn-default" style="background-color:#009798;color:white;" onclick="NuevoTarifa();">Nueva Tarifa Aerea</button>
             <table id="table-users" class="display" style="width:100%;">
                 <thead>
                     <tr>
                         <th>Ciudad</th>
                         <th>01-03 Kgs</th>
                         <th>04-150 Kgs</th>
                         <th>151-500 Kgs</th>
                         <th>500+ Kgs</th>
                         <th>Opciones</th>
                     </tr>
                 </thead>
            </table>
        </div>
                <%--MODAL INGRESAR NUEVO RAMAL--%>
      <div class="modal fade" id="myModal1" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <%--header--%>
                <div class="modal-header">
                  <h4 class="modal-title">Nueva Tarifa Aerea</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <%--modal body--%>
                <div class="modal-body">
                 
                   <div class="form-horizontal">
                       <div class="row">
                           <div class="col-md-4"><b>Ciudad:</b></div>
                           <div class="col-md-8"><input id="txtCiudad" class="form-control"  type="text" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>01-03 Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe01a03" class="form-control"  type="number" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>04-150 Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe04a150" class="form-control"  type="number" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>151-500 Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe151a500" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito" class="form-control"  type="number" /></div>
                       </div>
                   </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="saveTarifa();">Guardar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                 </div>


            </div>
        </div>
      </div>


                        <%--MODAL MODIFICAR NUEVO RAMAL--%>
      <div class="modal fade" id="myModal2" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <%--header--%>
                <div class="modal-header">
                  <h4 class="modal-title">Modificar Tarifa Aerea</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <%--modal body--%>
                <div class="modal-body">
                 
                   <div class="form-horizontal">
                       <asp:Label ID="lblIdAereos" runat="server" Text="Label"></asp:Label>
                       <div class="row">
                           <div class="col-md-4"><b>Ciudad:</b></div>
                           <div class="col-md-8"><input id="txtCiudad_2" class="form-control"  type="text" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>01-03 Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe01a03_2" class="form-control"  type="number" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>04-150 Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe04a150_2" class="form-control"  type="number" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>151-500 Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe151a500_2" class="form-control"  type="number" /></div>
                       </div>
                      <div class="row">
                           <div class="col-md-4"><b>501+ Kgs:</b></div>
                           <div class="col-md-8"><input id="txtDe501aInfinito_2" class="form-control"  type="number" /></div>
                       </div>
                   </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="UpdateTarifa();">Modificar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                 </div>


            </div>
        </div>
      </div>



  <%--MODAL ELMINAR RAMAL--%>
      <div class="modal fade" id="myModal3" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <%--header--%>
                <div class="modal-header">
                  <h4 class="modal-title">Eliminar Tarifa Aerea</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <%--modal body--%>
                <div class="modal-body">
                 
                   <div class="form-horizontal">
                       
                       <div class="row">
                           <asp:Label ID="idAereoDelete" runat="server" Text="Label"></asp:Label>
                           <div class="col-md-12">
                               <table class="table table-bordered">
                                   <thead>
                                       <tr>
                                           <th>Ciudad</th>
                                           <th>01-03</th>
                                           <th>04-150</th>
                                           <th>151-500</th>
                                           <th>500+</th>
                                       </tr>
                                   </thead>
                                   <tbody>
                                       <tr>
                                           <td><asp:Label ID="lblCiudad" runat="server" Text="Label"></asp:Label></td>
                                           <td><asp:Label ID="lblDe01a03" runat="server" Text="Label"></asp:Label></td>
                                           <td><asp:Label ID="lblDe04a150" runat="server" Text="Label"></asp:Label></td>
                                           <td><asp:Label ID="lblDe151a500" runat="server" Text="Label"></asp:Label></td>
                                           <td><asp:Label ID="lblDe501aInf" runat="server" Text="Label"></asp:Label></td>
                                       </tr>
                                   </tbody>
                               </table>
                               <p>¿Desea eliminar el registro?</p>

                           </div>
                       </div>
                       
                   </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="DeleteTarifa();">Eliminar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                 </div>


            </div>
        </div>
      </div>
    </form>
</body>
</html>
