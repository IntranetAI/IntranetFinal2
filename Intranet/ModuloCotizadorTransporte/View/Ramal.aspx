<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Intranet.ModuloCotizadorTransporte.View.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css"/>
      
    
    
    <script type="text/javascript" lang="javascript">
        $(document).ready(function () {
            //dtUsers();
            listUsers();
            $('#divMensaje').hide();
            $('#<%=lblIdRamal.ClientID %>').hide();
            $('#<%=idRamalDelete.ClientID %>').hide();
        });

        function saveRamal() {
            var nRamal = document.getElementById("txtNombreRamal").value;
            var ciudad = document.getElementById("txtCiudad").value;
            var valor = document.getElementById("txtValor").value;
            $.ajax({
                url: "Inicio.aspx/saveRamal",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'NombreRamal':'" + nRamal + "','Ciudad':'"+ciudad+"','Valor':'"+valor+"'}",
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
                        $('#divMensaje').html('<b>Ramal</b> creado correctamente.');
                        $('#divMensaje').delay(6000).hide(500);
                        listUsers();
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function UpdateRamal() {
            var idRamal = $('#<%=lblIdRamal.ClientID %>').text();
            var nRamal = document.getElementById("txtNombreRamal2").value;
            var ciudad = document.getElementById("txtCiudad2").value;
            var valor = document.getElementById("txtValor2").value;
            $.ajax({
                url: "Inicio.aspx/UpdateRamal",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'idRamal':'"+idRamal+"','NombreRamal':'" + nRamal + "','Ciudad':'" + ciudad + "','Valor':'" + valor + "'}",
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
                        $('#divMensaje').html('<b>Ramal</b> Modificado correctamente.');
                        $('#divMensaje').delay(6000).hide(500);
                        listUsers();
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }
        function DeleteRamal() {
            var idRamal = $('#<%=idRamalDelete.ClientID %>').text();
            $.ajax({
                url: "Inicio.aspx/DeleteRamal",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'idRamal':'"+idRamal+"'}",
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
                        $('#divMensaje').html('<b>Ramal</b> Eliminado correctamente.');
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
                    url: "Inicio.aspx/getRamal",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: function (d){
                        return JSON.stringify(d);
                    },
                    dataSrc: "d.data"
                },
                columns: [
                    { "data": "Ramal" },
                    { "data": "Ciudad" },
                    { "data": "Valor" },
                    { "data": "Opciones" }
                ]
            });
        }
        function NuevoRamal() {
                $("#myModal1").modal("show");
        }
        function ModificaRamal(idRamal, nRamal, nCiudad, nValor) {
            $('#<%=lblIdRamal.ClientID %>').html(idRamal);
            document.getElementById("txtNombreRamal2").value = nRamal;
            document.getElementById("txtCiudad2").value = nCiudad;
            document.getElementById("txtValor2").value = nValor;
            $("#myModal2").modal("show");
        }
        function EliminaRamal(idRamal, nRamal, nCiudad, nValor) {
            $('#<%=idRamalDelete.ClientID %>').html(idRamal);
            $('#<%=lblRamal.ClientID %>').html(nRamal);
            $('#<%=lblCiudad.ClientID %>').html(nCiudad);
            $('#<%=lblValor.ClientID %>').html(nValor);
            $("#myModal3").modal("show");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div id="divMensaje">
        </div>
        <div style="padding:10px;"> 
            <%--<input type="submit" value="Nuevo Ramal" class="btn btn-default" style="background-color:#009798;color:white;"/>--%>
            <%--<a class="btn btn-default"  href='javascript:alerta(\"" + 3 + "\");' > Nuevo Ramal </a>--%>
            <button type="button" class="btn btn-default" style="background-color:#009798;color:white;" onclick="NuevoRamal();">Nuevo Ramal</button>
             <table id="table-users" class="display" style="width:100%;">
                 <thead>
                     <tr>
                         <th>Ramal</th>
                         <th>Ciudad</th>
                         <th>Valor</th>
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
                  <h4 class="modal-title">Nuevo Ramal</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <%--modal body--%>
                <div class="modal-body">
                 
                   <div class="form-horizontal">
                       <div class="row">
                           <div class="col-md-4"><b>Nombre Ramal:</b></div>
                           <div class="col-md-8"><input id="txtNombreRamal" class="form-control"  type="text" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>Ciudad:</b></div>
                           <div class="col-md-8"><input id="txtCiudad" class="form-control"  type="text" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>Valor:</b></div>
                           <div class="col-md-8"><input id="txtValor" class="form-control"  type="text" /></div>
                       </div>
                   </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="saveRamal();">Guardar</button>
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
                  <h4 class="modal-title">Modificar Ramal</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <%--modal body--%>
                <div class="modal-body">
                 
                   <div class="form-horizontal">
                       
                       <div class="row">
                           <asp:Label ID="lblIdRamal" runat="server" Text="Label"></asp:Label>
                           <div class="col-md-4"><b>Nombre Ramal:</b></div>
                           <div class="col-md-8"><input id="txtNombreRamal2" class="form-control"  type="text" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>Ciudad:</b></div>
                           <div class="col-md-8"><input id="txtCiudad2" class="form-control"  type="text" /></div>
                       </div>
                       <div class="row">
                           <div class="col-md-4"><b>Valor:</b></div>
                           <div class="col-md-8"><input id="txtValor2" class="form-control"  type="text" /></div>
                       </div>
                   </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="UpdateRamal();">Modificar</button>
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
                  <h4 class="modal-title">Eliminar Ramal</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <%--modal body--%>
                <div class="modal-body">
                 
                   <div class="form-horizontal">
                       
                       <div class="row">
                           <asp:Label ID="idRamalDelete" runat="server" Text="Label"></asp:Label>
                           <div class="col-md-12">
                               <table class="table table-bordered">
                                   <thead>
                                       <tr>
                                           <th>Ramal</th>
                                           <th>Ciudad</th>
                                           <th>Valor</th>
                                       </tr>
                                   </thead>
                                   <tbody>
                                       <tr>
                                           <td><asp:Label ID="lblRamal" runat="server" Text="Label"></asp:Label></td>
                                           <td><asp:Label ID="lblCiudad" runat="server" Text="Label"></asp:Label></td>
                                           <td><asp:Label ID="lblValor" runat="server" Text="Label"></asp:Label></td>
                                       </tr>
                                   </tbody>
                               </table>
                               <p>¿Desea eliminar el registro?</p>

                           </div>
                       </div>
                       
                   </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="DeleteRamal();">Eliminar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                 </div>


            </div>
        </div>
      </div>

    </form>
</body>
</html>
